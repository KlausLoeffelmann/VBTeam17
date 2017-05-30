Public Class Participant

    Private Const EARLIEST_AGE = #1950-01-01#

    Private Shared myFirstNames As String() = New String() {
         "Adriana", "Stephan", "Andreas", "Lisa",
         "Daniel", "Guido", "Paul", "Lars", "Carola", "Mads"}

    Private Shared myLastNames As String() = New String() {
         "Mayor", "Spooner", "Miller", "Doe", "Löffelmann",
         "Landwerth", "Torgersen"}

    Private Shared myAddressLine As String() = New String() {
        "1719 Bellevue Way SE", "1249 110th Ave NE", "4780 42th Ave NE",
        "1810 130th Ave NE", "929 4th Ave", "1052 W Seneca St",
        "7764 32nd Avenue NE", "NE 140th St", "68th Ave NE"}

    Private Shared myCities As String() = New String() {
        "Kirkland", "Bellevue", "Monroe",
        "Woodinville", "Pleasanton", "Seattle",
        "Issaquah", "Sammamish", "Redmond"}

    Private Shared myZips As String() = New String() {
        "98033", "98034", "98040",
        "98123", "94566", "94567",
        "98027", "98028", "98052"}


    Property Id As Guid
    Public Property FirstName As String
    Public Property LastName As String
    Public Property DateOfBirth As Date?
    Property Addressline1 As String
    Property Addressline2 As String
    Property City As String
    Property Zip As String
    Property State As UsState

    Public ReadOnly Property Age As Integer?
        Get
            Return CInt((Now - DateOfBirth)?.TotalDays / 365)
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return $"{If(LastName, "- - -")}, " &
               $"{If(FirstName, " - - -")}: " &
               $"{If(Age.ToString, "--")} years."
    End Function

    Public Shared Iterator Function GetDemoData(count As Integer) As IEnumerable(Of Participant)

        'We need that to demo the new Exception Helper!
        If count < 1 Then
            Return
        End If

        Dim randomGen = New Random(Now.Millisecond)
        For counter = 1 To count
            Dim birthDate = New Date(EARLIEST_AGE.Ticks +
                                     randomGen.Next(CInt((#2002-01-01#.Ticks -
                                                          EARLIEST_AGE.Ticks) / 10000000000)) * 10000000000)
            Yield New Participant With
                {.FirstName = myFirstNames(randomGen.Next(myFirstNames.Length - 1)),
                 .LastName = myLastNames(randomGen.Next(myLastNames.Length - 1)),
                 .Addressline1 = myAddressLine(randomGen.Next(myAddressLine.Length - 1)),
                 .City = myCities(randomGen.Next(myCities.Length - 1)),
                 .Zip = myZips(randomGen.Next(myZips.Length - 1)),
                 .State = UsState.RandomState,
                 .DateOfBirth = birthDate}
        Next
    End Function
End Class
