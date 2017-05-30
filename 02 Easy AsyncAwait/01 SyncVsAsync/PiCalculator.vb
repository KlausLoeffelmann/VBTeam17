Imports System.Numerics
Imports System.Text
Imports System.Threading

''' <summary>
''' Pi Calculator. 
''' Algorithm shamelessly stolen and translated/refactored to vb.net from this Blog:
''' http://latkin.org/blog/2012/11/03/the-bailey-borwein-plouffe-algorithm-in-c-and-f/
''' </summary>
Public NotInheritable Class PiCalc

    Private Const NumHexDigits As Integer = 16
    Private Const Epsilon As Double = 1.0E-17
    Private Const NumTwoPowers As Integer = 25
    Private Const PORTIONS_SIZE = 6

    Private Shared twoPowers(NumTwoPowers - 1) As Double

    Private hexChars As New Dictionary(Of String, Integer) From {{"0", 0},
                                                                {"1", 1},
                                                                {"2", 2},
                                                                {"3", 3},
                                                                {"4", 4},
                                                                {"5", 5},
                                                                {"6", 6},
                                                                {"7", 7},
                                                                {"8", 8},
                                                                {"9", 9},
                                                                {"A", 10},
                                                                {"B", 11},
                                                                {"C", 12},
                                                                {"D", 13},
                                                                {"E", 14},
                                                                {"F", 15}}

    Private myProgressCallback As Action(Of Integer, String)

    Sub New()
        InitializeTwoPowers()
    End Sub

    Function CalculatePiHex(digitPosition As Integer, numHexDigits As Integer) As String

        Dim pid, s1, s2, s3, s4 As Double
        Dim hexDigits As String


        '  Digits generated follow immediately after digitPosition.
        s1 = Series(1, digitPosition)
        s2 = Series(4, digitPosition)
        s3 = Series(5, digitPosition)
        s4 = Series(6, digitPosition)

        pid = 4.0R * s1 - 2.0R * s2 - s3 - s4
        pid = pid - CInt(Fix(pid)) + 1.0R
        hexDigits = ConvertToHexDigits(pid, numHexDigits)
        Return hexDigits
    End Function

    ' Returns the first NumHexDigits hex digits of the fraction of x.
    Private Shared Function ConvertToHexDigits(ByVal x As Double, ByVal numDigits As Integer) As String
        Dim hexChars As String = "0123456789ABCDEF"
        Dim sb As New StringBuilder(numDigits)
        Dim y As Double = Math.Abs(x)

        For i As Integer = 0 To numDigits - 1
            y = 16.0R * (y - Math.Floor(y))
            sb.Append(hexChars.Chars(CInt(Fix(y))))
        Next i

        Return sb.ToString()
    End Function

    ' This routine evaluates the series  sum_k 16^(n-k)/(8*k+m) 
    '    using the modular exponentiation technique.
    Private Shared Function Series(ByVal m As Integer, ByVal n As Integer) As Double
        Dim denom As Double, pow As Double, sum As Double = 0R, term As Double

        '  Sum the series up to n.
        For k As Integer = 0 To n - 1
            denom = 8 * k + m
            pow = n - k
            term = ModPow16(pow, denom)
            sum = sum + term / denom
            sum = sum - CInt(Fix(sum))
        Next k

        '  Compute a few terms where k >= n.
        For k As Integer = n To n + 100
            denom = 8 * k + m
            term = Math.Pow(16.0R, CDbl(n - k)) / denom

            If term < Epsilon Then
                Exit For
            End If

            sum = sum + term
            sum = sum - CInt(Fix(sum))
        Next k

        Return sum
    End Function

    ' Fill the power of two table
    Private Shared Sub InitializeTwoPowers()
        twoPowers(0) = 1.0R

        For i As Integer = 1 To NumTwoPowers - 1
            twoPowers(i) = 2.0R * twoPowers(i - 1)
        Next i
    End Sub

    ' ModPow16 = 16^p mod m.  This routine uses the left-to-right binary 
    '  exponentiation scheme.
    Private Shared Function ModPow16(ByVal p As Double, ByVal m As Double) As Double
        Dim i As Integer
        Dim pow1, pow2, result As Double

        If m = 1.0R Then
            Return 0R
        End If

        ' Find the greatest power of two less than or equal to p.
        For i = 0 To NumTwoPowers - 1
            If twoPowers(i) > p Then
                Exit For
            End If
        Next i

        pow2 = twoPowers(i - 1)
        pow1 = p
        result = 1.0R

        ' Perform binary exponentiation algorithm modulo m.
        For j As Integer = 1 To i
            If pow1 >= pow2 Then
                result = 16.0R * result
                result = result - CInt(Fix(result / m)) * m
                pow1 = pow1 - pow2
            End If

            pow2 = 0.5 * pow2

            If pow2 >= 1.0R Then
                result = result * result
                result = result - CInt(Fix(result / m)) * m
            End If
        Next j

        Return result
    End Function

    Public Function CalculatePiDecimalString(digitsCount As Integer,
                                             Optional progress As IProgress(Of Tuple(Of Integer, Integer)) = Nothing) As String

        'We can only precisly calculte a limitted number of digits in one go,
        'so we portion the floating point digits in chunks of n (PORTION_SIZE).
        Dim portions = digitsCount \ PORTIONS_SIZE
        Dim lastRunDigitsCount = digitsCount Mod PORTIONS_SIZE
        Dim currentDigitsCount = 0
        Dim sb As New StringBuilder
        Dim updatecounter As Integer

        Dim returnValue = New System.Numerics.BigInteger()

        For portionsCount = 0 To portions
            Dim thisRunDigitsCount = If(portionsCount = portions,
                                             lastRunDigitsCount, PORTIONS_SIZE)

            Dim piHex = CalculatePiHex(currentDigitsCount, thisRunDigitsCount)

            For count = 0 To piHex.Length - 1
                returnValue += hexChars(piHex(count))
                returnValue = returnValue << 4
            Next
            currentDigitsCount += thisRunDigitsCount
            updatecounter += 1
            If updatecounter = 10 Then
                updatecounter = 0
                If progress IsNot Nothing Then
                    progress.Report(New Tuple(Of Integer, Integer)(portionsCount * 1000 \ portions, portionsCount * PORTIONS_SIZE))
                End If
            End If

        Next
        returnValue = returnValue >> 4

        Dim decimalDigits = returnValue.ToString.Length

        For count = 1 To decimalDigits
            returnValue *= 10
        Next

        For count = 0 To digitsCount - 1
            returnValue = returnValue >> 4
        Next

        Return "3." & returnValue.ToString

    End Function

    Public Function CalculatePiDirectly(maxDigits As Integer,
                                        Optional progress As IProgress(Of Tuple(Of Integer, String)) = Nothing) As String
        Dim TWO As BigInteger = 2
        Dim TEN As BigInteger = 10
        Dim k As BigInteger = 2
        Dim a As BigInteger = 4
        Dim b As BigInteger = 1
        Dim a1 As BigInteger = 12
        Dim b1 As BigInteger = 4

        Dim sb As New StringBuilder

        Dim digitCount = -1

        Do
            Dim p As BigInteger = k * k
            Dim q = TWO * k + BigInteger.One
            k = k + BigInteger.One
            Dim tempa1 = a1
            Dim tempb1 = b1

            a1 = p * a + q * a1
            b1 = p * b + q * b1
            a = tempa1
            b = tempb1
            Dim d As BigInteger = a / b
            Dim d1 As BigInteger = a1 / b1

            Do While d = d1
                If digitCount = -1 Then
                    sb.Append(" ")
                    sb.Append(d.ToString)
                    digitCount += 1
                Else
                    sb.Append(d.ToString)
                    digitCount += 1
                End If

                If digitCount Mod 10 = 0 Then
                    sb.Append(" ")
                End If

                progress?.Report(New Tuple(Of Integer, String)(digitCount, d.ToString))

                a = TEN * (a Mod b)
                a1 = TEN * (a1 Mod b1)
                d = a / b
                d1 = a1 / b1
            Loop
            If digitCount = maxDigits Then
                Exit Do
            End If
        Loop

        Return sb.ToString

    End Function

End Class