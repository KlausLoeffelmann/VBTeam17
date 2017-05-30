Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports NewInVb2017

<TestClass()> Public Class UnitTest1

    <TestMethod()>
    Public Async Function TestTuples() As Task
        Dim returnTuple = Await (New MainForm).TupleTest()

    End Function

End Class