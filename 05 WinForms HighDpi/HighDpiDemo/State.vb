'From http://stackoverflow.com/questions/7367529/standardized-us-states-array-and-countries-array
Public Class UsState

    Private Shared myCachedList As IList(Of UsState)

    Property Abbreviation As String
    Property Name As String

    Public Overrides Function ToString() As String
        Return $"{Abbreviation} ({Name})"
    End Function

    Public Shared Function CreateStateList() As IList(Of UsState)
        If myCachedList Is Nothing Then
            myCachedList = New List(Of UsState) From {
                New UsState() With {.Abbreviation = "AL", .Name = "Alabama"},
                New UsState() With {.Abbreviation = "AK", .Name = "Alaska"},
                New UsState() With {.Abbreviation = "AR", .Name = "Arkansas"},
                New UsState() With {.Abbreviation = "AZ", .Name = "Arizona"},
                New UsState() With {.Abbreviation = "CA", .Name = "California"},
                New UsState() With {.Abbreviation = "CO", .Name = "Colorado"},
                New UsState() With {.Abbreviation = "CT", .Name = "Connecticut"},
                New UsState() With {.Abbreviation = "DC", .Name = "District of Columbia"},
                New UsState() With {.Abbreviation = "DE", .Name = "Delaware"},
                New UsState() With {.Abbreviation = "FL", .Name = "Florida"},
                New UsState() With {.Abbreviation = "GA", .Name = "Georgia"},
                New UsState() With {.Abbreviation = "HI", .Name = "Hawaii"},
                New UsState() With {.Abbreviation = "ID", .Name = "Idaho"},
                New UsState() With {.Abbreviation = "IL", .Name = "Illinois"},
                New UsState() With {.Abbreviation = "IN", .Name = "Indiana"},
                New UsState() With {.Abbreviation = "IA", .Name = "Iowa"},
                New UsState() With {.Abbreviation = "KS", .Name = "Kansas"},
                New UsState() With {.Abbreviation = "KY", .Name = "Kentucky"},
                New UsState() With {.Abbreviation = "LA", .Name = "Louisiana"},
                New UsState() With {.Abbreviation = "ME", .Name = "Maine"},
                New UsState() With {.Abbreviation = "MD", .Name = "Maryland"},
                New UsState() With {.Abbreviation = "MA", .Name = "Massachusetts"},
                New UsState() With {.Abbreviation = "MI", .Name = "Michigan"},
                New UsState() With {.Abbreviation = "MN", .Name = "Minnesota"},
                New UsState() With {.Abbreviation = "MS", .Name = "Mississippi"},
                New UsState() With {.Abbreviation = "MO", .Name = "Missouri"},
                New UsState() With {.Abbreviation = "MT", .Name = "Montana"},
                New UsState() With {.Abbreviation = "NE", .Name = "Nebraska"},
                New UsState() With {.Abbreviation = "NH", .Name = "New Hampshire"},
                New UsState() With {.Abbreviation = "NJ", .Name = "New Jersey"},
                New UsState() With {.Abbreviation = "NM", .Name = "New Mexico"},
                New UsState() With {.Abbreviation = "NY", .Name = "New York"},
                New UsState() With {.Abbreviation = "NC", .Name = "North Carolina"},
                New UsState() With {.Abbreviation = "NV", .Name = "Nevada"},
                New UsState() With {.Abbreviation = "ND", .Name = "North Dakota"},
                New UsState() With {.Abbreviation = "OH", .Name = "Ohio"},
                New UsState() With {.Abbreviation = "OK", .Name = "Oklahoma"},
                New UsState() With {.Abbreviation = "OR", .Name = "Oregon"},
                New UsState() With {.Abbreviation = "PA", .Name = "Pennsylvania"},
                New UsState() With {.Abbreviation = "RI", .Name = "Rhode Island"},
                New UsState() With {.Abbreviation = "SC", .Name = "South Carolina"},
                New UsState() With {.Abbreviation = "SD", .Name = "South Dakota"},
                New UsState() With {.Abbreviation = "TN", .Name = "Tennessee"},
                New UsState() With {.Abbreviation = "TX", .Name = "Texas"},
                New UsState() With {.Abbreviation = "UT", .Name = "Utah"},
                New UsState() With {.Abbreviation = "VT", .Name = "Vermont"},
                New UsState() With {.Abbreviation = "VA", .Name = "Virginia"},
                New UsState() With {.Abbreviation = "WA", .Name = "Washington"},
                New UsState() With {.Abbreviation = "WV", .Name = "West Virginia"},
                New UsState() With {.Abbreviation = "WI", .Name = "Wisconsin"},
                New UsState() With {.Abbreviation = "WY", .Name = "Wyoming"}
            }
        End If

        Return myCachedList
    End Function

    Public Shared Function RandomState() As UsState
        Dim ran = New Random(Now.Millisecond)
        Dim stateList = CreateStateList()
        Return stateList.Item(ran.Next(stateList.Count - 1))
    End Function

End Class