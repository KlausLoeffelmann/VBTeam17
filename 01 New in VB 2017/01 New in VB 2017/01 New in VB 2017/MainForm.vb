Imports System.ComponentModel
Imports NewInCS2017

Public Class MainForm

    'Private myCurrentEmployee As New EmployeeException("We're not hirering!")

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        lstContacts.Items.AddRange(Contact.GetDemoData(100).OfType(Of Object).ToArray)
    End Sub

    Public Async Function TupleTest() As Task(Of (Integer, String))

        'This is a typical example when we have more than one return value:
        Dim parsedDate As Date

        'parsedDate is passed ByRef and is assigned the result of the parsing.
        'success indicates, of if the parsing was successful.
        Dim success = Date.TryParse("2017-10-13", parsedDate)

        If success Then
            'Here, we can use date!
            Debug.Print(parsedDate.ToString)
        End If

        'Tip: This is actually redundant when the names are defined 
        '     in the signature of the method being called.
        Dim returnValue As (Success As Boolean, Value As Date) = TryDateParse("2017-10-13")

        If returnValue.Success Then
            Debug.Print(returnValue.Value.ToString)
        End If

        'This is how you declared and defined Tuples prior to Visual Basic 2017.
        Dim originalTuple As New Tuple(Of Integer, String)(42, "Forty-two")

        Dim ftInteger As Integer = originalTuple.Item1
        Dim ftString As String = originalTuple.Item2

        'This is, how you define a Tuple now:
        Dim newTuple As (Integer, String)

        'And you can assign it with a Tuple literal:
        newTuple = (42, "Zweiundvierzig")

        'When you want to convert an old styled Tuple to a new one:
        newTuple = originalTuple.ToValueTuple

        '...and back:
        originalTuple = newTuple.ToTuple

        'Old styled Tuple elements could only be referenced with Item1, Item2,...
        'VB 2017 Tuple can have named Items:
        Dim alsoTuple As (Checked As Boolean, Person As Contact)
        alsoTuple = (True, Nothing)
        alsoTuple.Checked = (originalTuple.Item1 = 42)

        'Tuple types can also be inferred...
        Dim nextTuple = (True, New Contact)

        '...and even inferred and named in one go:
        Dim anotherTuple = (Checked:=True, Person:=New Contact)

        'We had Hexadecimal Literals in VB before:
        Dim fortytwo = &H2A

        'New in VB 2017:
        'Binary Literals. And digit group separators...
        Dim FORTY_TWO = &B10_10_10

        '...but not only for binary literals!
        Dim Forty_TWO_THOUSAND_AND_FORTY_TWO = 42_042

        Return Await Task.FromResult((FORTY_TWO, "Fourtytwo"))

    End Function

    Public Shared Function TryDateParse(dateAsString As String) As (Success As Boolean, Value As Date)

        Dim dateValue As Date

        'Returning a Tuple.
        Return (Date.TryParse(dateAsString, dateValue),
                 dateValue)

    End Function

    Private Sub moveButton_Click(sender As Object, e As EventArgs) Handles moveButton.Click

        'Getting all Items with the additional Info if they are selected or not:
        'One item of the List is of type Tuple: (IsSelected As Boolean, Contact As Contact).
        Dim allItems = GetListItems()

        Dim selItems = From item In allItems
                       Where item.IsSelected

        For Each selectedItem As (IsSelected As Boolean, Person As Contact) In selItems
            lstResultList.Items.Add(selectedItem.Person)
        Next

    End Sub

    Private Function GetListItems() As IEnumerable(Of (IsSelected As Boolean, Contact As Contact))

        'CheckedListBox doesn't like to be work on with Enumerators,
        'so we create a copy of the collection.
        Dim copyOfOriginalList = New List(Of Contact)(lstContacts.Items.Cast(Of Contact))

        'Tuples can also be created via Select within LINQ Queries:
        Dim listItems = From item In copyOfOriginalList
                        Select (IsSelected:=lstContacts.SelectedItems.IndexOf(item) >= 0,
                                Person:=item)

        Return listItems.ToList

    End Function

    'We are declaring stringFound ByRef, thus having a local ByRef variable.
    Private Function FindNextHelper(ByRef stringFound As String,
                                    didFind As Boolean) As (OriginalString As String, Found As Boolean)

        'Save the old string in case we need it.
        Dim oldString = stringFound

        'Now that stringFound is ByRef, we can read it...
        If stringFound = "Adrian" Then
            '...and write to its referenced target.
            stringFound = "Klaus"
        End If

        Return (oldString, didFind)

    End Function

    Private Sub TestButton_Click(sender As Object, e As EventArgs) Handles TestButton.Click

        'To produce the new Exception Helper Screenshot.
        'Dim NullExceptionContact = Contact.GetNullEmployee.FirstName.Length

        'To test the Ref Return implementation in CSharp.
        'MessageBox.Show(NewInCS2017.ReturnRefDemo.TestSentence())
        'Return

        Dim aSentence = New NewInCS2017.Sentence("Adrian is going to marry Adriana, because Adrian loves Adriana.")

        Dim didFind As Boolean

        'Version #1: Directly with specific helper method.
        Do While FindNextHelper(aSentence.FindNext("Adr", didFind), didFind).Found
        Loop

        MessageBox.Show(aSentence.ToString)

        'Version #2: With a simple generic helper-class:
        aSentence = New NewInCS2017.Sentence("Adrian is going to marry Adriana, because Adrian loves Adriana.")

        Do
            VbByRefHelper(aSentence.FindNext("Adr", didFind),
                                    Function(stringFound) As String
                                        If stringFound = "Adrian" Then
                                            stringFound = "Klaus"
                                            Return stringFound
                                        End If

                                        Return stringFound
                                    End Function)
        Loop While didfind

        MessageBox.Show(aSentence.ToString)

        'Version #3: Because we love Tuples so much, here is even a more esoteric version.
        '            (Not mentioned in the blog post, though!).
        aSentence = New NewInCS2017.Sentence("Adrian is going to marry Adriana, because Adrian loves Adriana.")

        Do While VbByRefHelper(Of String, Boolean)(aSentence.FindNext("Adr", didFind),
                                                   Function(stringFound)
                                                       If stringFound = "Adrian" Then
                                                           stringFound = "Klaus"
                                                       End If
                                                       Return (stringFound, didFind)
                                                   End Function)
        Loop

        MessageBox.Show(aSentence.ToString)


    End Sub

    Public Sub TestSentence()
        'THIS DOES NOT WORK IN VB!!!
        Dim aSentence = New Sentence("Adrian is going to marry Adriana, because Adrian loves Adriana.")
        Dim found = False

        aSentence.FindNext("Adr", found) = "Klaus"


        Do
            ' In CSharp we can declare a local variable as ref - in VB we cannot.
            ' This variable takes the result...
            Dim foundString = aSentence.FindNext("Adr", found)
            If foundString = "Adrian" Then
                ' but via the reference, so writing this variable does actually
                foundString = "Klaus"
            End If
        Loop While found

    End Sub

    Private Function VbByRefHelper(Of t)(ByRef byRefValue As t,
                                               byRefSetter As Func(Of t, t)) As t
        Dim orgValue = byRefValue
        byRefValue = byRefSetter(byRefValue)
        Return orgValue
    End Function

    Private Function VbByRefHelper(Of t, rt)(ByRef byRefValue As t,
                                             byRefSetter As Func(Of t, (ByRefValue As t, ReturnValue As rt))) As rt
        Dim retValue = byRefSetter(byRefValue)
        byRefValue = retValue.ByRefValue
        Return retValue.ReturnValue
    End Function

End Class
