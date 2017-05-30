Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports RomanNumeralsLib

<TestClass()>
Public Class RomanNumeralsTest

    <TestMethod()>
    Public Sub Test1To20()
        Assert.AreEqual("I", RomanNumerals.RomanNumeralFromValue(1))
        Assert.AreEqual("II", RomanNumerals.RomanNumeralFromValue(2))
        Assert.AreEqual("III", RomanNumerals.RomanNumeralFromValue(3))
        Assert.AreEqual("IV", RomanNumerals.RomanNumeralFromValue(4))
        Assert.AreEqual("V", RomanNumerals.RomanNumeralFromValue(5))
        Assert.AreEqual("VI", RomanNumerals.RomanNumeralFromValue(6))
        Assert.AreEqual("VII", RomanNumerals.RomanNumeralFromValue(7))
        Assert.AreEqual("VIII", RomanNumerals.RomanNumeralFromValue(8))
        Assert.AreEqual("IX", RomanNumerals.RomanNumeralFromValue(9))
        Assert.AreEqual("X", RomanNumerals.RomanNumeralFromValue(10))
        Assert.AreEqual("XI", RomanNumerals.RomanNumeralFromValue(11))
        Assert.AreEqual("XII", RomanNumerals.RomanNumeralFromValue(12))
        Assert.AreEqual("XIII", RomanNumerals.RomanNumeralFromValue(13))
        Assert.AreEqual("XIV", RomanNumerals.RomanNumeralFromValue(14))
        Assert.AreEqual("XV", RomanNumerals.RomanNumeralFromValue(15))
        Assert.AreEqual("XVI", RomanNumerals.RomanNumeralFromValue(16))
        Assert.AreEqual("XVII", RomanNumerals.RomanNumeralFromValue(17))
        Assert.AreEqual("XVIII", RomanNumerals.RomanNumeralFromValue(18))
        Assert.AreEqual("XIX", RomanNumerals.RomanNumeralFromValue(19))
        Assert.AreEqual("XX", RomanNumerals.RomanNumeralFromValue(20))
    End Sub

    <TestMethod()>
    Public Sub TestTensAndHundreds()
        Assert.AreEqual("XX", RomanNumerals.RomanNumeralFromValue(20))
        Assert.AreEqual("XXIV", RomanNumerals.RomanNumeralFromValue(24))
        Assert.AreEqual("XXIX", RomanNumerals.RomanNumeralFromValue(29))
        Assert.AreEqual("XX", RomanNumerals.RomanNumeralFromValue(20))
        Assert.AreEqual("XXXIV", RomanNumerals.RomanNumeralFromValue(34))
        Assert.AreEqual("XXXIX", RomanNumerals.RomanNumeralFromValue(39))
        Assert.AreEqual("XLIX", RomanNumerals.RomanNumeralFromValue(49))
        Assert.AreEqual("LXXXIX", RomanNumerals.RomanNumeralFromValue(89))
        Assert.AreEqual("XCIX", RomanNumerals.RomanNumeralFromValue(99))
    End Sub
End Class
