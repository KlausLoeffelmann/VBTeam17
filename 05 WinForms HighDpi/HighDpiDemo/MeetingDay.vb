Public Class MeetingDay

    Private Const DAYS_FOR_MEETINGS = 12
    Private Const EXCLUDE_SUNDAYS = True
    Private Const EXCLUDE_SATURDAYS = True

    Public Property MeetingDate As Date
    Public Property Participants As IEnumerable(Of Participant)

    Public Shared Function GetDemoData() As List(Of MeetingDay)
        Dim ranGen As New Random(Now.Millisecond)
        Dim meetingDays = New List(Of MeetingDay)

        For days = 0 To DAYS_FOR_MEETINGS - 1
            Dim currentDate = Now.AddDays(days).Date
            If (currentDate.DayOfWeek = DayOfWeek.Saturday And EXCLUDE_SATURDAYS) Or
               (currentDate.DayOfWeek = DayOfWeek.Sunday And EXCLUDE_SUNDAYS) Then
                Continue For
            End If

            Dim meeting = New MeetingDay With {.MeetingDate = currentDate}
            meeting.Participants = Participant.GetDemoData(ranGen.Next(19) + 1)
            meetingDays.Add(meeting)
        Next

        Return meetingDays
    End Function

End Class
