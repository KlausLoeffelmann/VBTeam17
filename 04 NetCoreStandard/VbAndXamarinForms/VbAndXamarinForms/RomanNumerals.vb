Public Class RomanNumerals

    Public Shared Function RomanNumeralFromValue(ByVal ArabicNumber As Integer) As String

        Dim count As Integer
        Dim digitValue As Integer
        Dim romanResult As String = ""
        Dim milPostFix As String = ""
        Dim romanNumerals As String

        'We need to handle numbers greater than 3999, since 'M' is the biggest value literal there is.
        If ArabicNumber > 3999 Then
            milPostFix = New String("M"c, ArabicNumber \ 1000)
            ArabicNumber = ArabicNumber Mod 1000
        End If

        'These are the existing roman numerals, ordered from small to big.
        romanNumerals = "IVXLCDM"

        count = 1

        Do While ArabicNumber > 0
            digitValue = ArabicNumber Mod 10

            Select Case digitValue

                'Digits 1 to 3 are added consecutively (I, II, III)
                Case 1 To 3
                    romanResult = New String(CChar(romanNumerals.Substring(count - 1, 1)), digitValue) & romanResult

                    'The 4th digit is the "One" value of the following "Five" Value (IV)
                Case 4
                    romanResult = romanNumerals.Substring(count - 1, 2) & romanResult

                    'The 5th digit got its own numeral (V)
                Case 5
                    romanResult = romanNumerals.Substring(count, 1) & romanResult

                    '6th to 8th: Combination from "One" and "Five" values (VI, VII, VIII)
                Case 6 To 8

                    romanResult = romanNumerals.Substring(count, 1) &
                            New String(CChar(romanNumerals.Substring(count - 1, 1)), digitValue - 5) & romanResult

                    'And finally: a combination from "One" value and "Ten" value (IX)
                Case 9
                    romanResult = romanNumerals.Substring(count - 1, 1) & romanNumerals.Substring(count + 1, 1) & romanResult
            End Select

            count += 2
            ArabicNumber \= 10
        Loop

        Return milPostFix + romanResult

    End Function

End Class
