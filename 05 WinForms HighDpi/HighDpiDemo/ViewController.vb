Imports System.Runtime.CompilerServices

''' <summary>
''' View controller, which works with either of the ParticipantManager Views. 
''' With its help, we can use one controller for all different resolutions.
''' </summary>
Public Class MainViewController

    Private myCalendar As MonthCalendar
    Private myParticipents As CheckedListBox
    Private myUsStates As ComboBox


    Sub New(view As Form, meetingDays As List(Of MeetingDay))
        Me.View = view
        Me.MeetingDays = meetingDays

        mycalendar = view.GetControl(Of MonthCalendar)(ParticipantManager96Dpi.MeetingDateMonthCalendar.Name)
        myParticipents = view.GetControl(Of CheckedListBox)(ParticipantManager96Dpi.ParticipantsCheckedListBox.Name)
        myUsStates = view.GetControl(Of ComboBox)(ParticipantManager96Dpi.UsStatesComboBox.Name)

        myUsStates.DataSource = UsState.CreateStateList

        AddHandler myCalendar.DateSelected,
            Sub(cal As Object, e As DateRangeEventArgs)
                DataToView(e.Start)
            End Sub

        AddHandler myParticipents.SelectedIndexChanged,
            Sub()
                ShowParticipant(DirectCast(myParticipents.SelectedItem,
                                           Participant))
            End Sub

        DataToView(Now.Date)
    End Sub

    Public Sub DataToView(meetingDate As Date)

        Dim currentMeeting = (From item In MeetingDays
                              Where item.MeetingDate = meetingDate).FirstOrDefault

        myParticipents.Items.Clear()
        If currentMeeting?.Participants IsNot Nothing Then
            myParticipents.Items.AddRange(currentMeeting.Participants.ToArray)
        End If
    End Sub

    Public Sub ShowParticipant(participant As Participant)
        For Each textBox In View.GetTaggedControls(Of TextBox)
            textBox.Text = (From item In participant.GetType.GetProperties
                            Where item.Name.ToLower = textBox.Tag.ToString.ToLower).FirstOrDefault?.
                                                                               GetValue(participant)?.ToString
        Next
    End Sub

    Public Property View As Form
    Public Property MeetingDays As List(Of MeetingDay)
End Class

Module FormExtender

    <Extension>
    Public Function GetControl(Of t As Control)(view As Form, name As String) As t
        Return TryCast((From item In view.Controls
                        Where item.GetType.IsAssignableFrom(GetType(t)) AndAlso
                              DirectCast(item, Control).Name = name).FirstOrDefault, t)
    End Function

    ''' <summary>
    ''' Gets all controls of a container of type t which tag property is not empty or null.
    ''' </summary>
    ''' <typeparam name="t"></typeparam>
    ''' <param name="view"></param>
    ''' <returns></returns>
    <Extension>
    Public Function GetTaggedControls(Of t As Control)(view As Form) As IEnumerable(Of t)
        Return (From item In view.Controls
                Where item.GetType.IsAssignableFrom(GetType(t)) AndAlso
                     Not String.IsNullOrWhiteSpace(DirectCast(item, Control).Tag.ToString)).Cast(Of t)
    End Function

End Module
