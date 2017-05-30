Imports System.IO
Public Class Contact
    Implements IContact

    Private Shared myFirstNames As String() = New String() {
         "Adriana", "Stephan", "Andreas", "Lisa",
         "Daniel", "Guido", "Paul", "Lars", "Carola", "Mads"}

    Private Shared myLastNames As String() = New String() {
         "Mayor", "Spooner", "Miller", "Doe", "Löffelmann",
         "Landwerth", "Torgersen"}

    Private Const EARLIEST_AGE = #1950-01-01#

    Public Property FirstName As String Implements IContact.FirstName
    Public Property LastName As String Implements IContact.LastName
    Public Property DateOfBirth As Date? Implements IContact.DateOfBirth

    Public ReadOnly Property Age As Integer? Implements IContact.Age
        Get
            Return CInt((Now - DateOfBirth)?.TotalDays / 365)
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return $"{If(LastName, "- - -")}, " &
               $"{If(FirstName, " - - -")}: " &
               $"{If(Age.ToString, "--")} years."
    End Function

    'IntelliSense screenshot scenario.
    Public Async Function WriteFileCommandProcAsync() As Task

        Try
            Dim fs As FileStream
            Dim bytesToWrite(100000) As Byte

            fs = New FileStream(My.Computer.FileSystem.GetTempFileName, FileMode.Create)
            Await fs.WriteAsync(bytesToWrite, 0, bytesToWrite.Count)
            Await fs.FlushAsync

            fs.Close()
        Catch ex As Exception
            MessageBox.Show("Something did not go according to plan..." & vbCrLf &
                            "(did you take the memory stick out?)" & vbCr & vbCr &
                            ex.Message, ex.GetType.ToString)
        End Try
    End Function

    Public Shared Function GetNullEmployee() As Contact
        Return Nothing
    End Function

    Public Shared Iterator Function GetDemoData(count As Integer) As IEnumerable(Of IContact)

        'We need that to demo the new Exception Helper!
        If count < 1 Then
            Return
        End If

        Dim randomGen = New Random(Now.Millisecond)
        For counter = 1 To count
            Dim birthDate = New Date(EARLIEST_AGE.Ticks +
                                     randomGen.Next(CInt((#2002-01-01#.Ticks -
                                                          EARLIEST_AGE.Ticks) / 10000000000)) * 10000000000)
            Yield New Contact With
                {.FirstName = myFirstNames(randomGen.Next(myFirstNames.Length - 1)),
                 .LastName = myLastNames(randomGen.Next(myLastNames.Length - 1)),
                 .DateOfBirth = birthDate}
        Next

        Debug.Print("Done generating test data...")

    End Function

End Class
