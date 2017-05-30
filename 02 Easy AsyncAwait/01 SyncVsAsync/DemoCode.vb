Imports System.Threading

Public Class DemoCode
    Public Async Function ConsumingTasks() As Task
        Await Method1()
        Dim fourtyTwo = Await Method2()
        Debug.Print("The Result of Method 3 is" & Await Method3())

        'Since Method 4 returns a Task(Of Task), awaiting Method 4
        'delivers it's promise of a task which we await again!
        Await Await Method4()
    End Function

    Public Async Function Method1() As Task
        'We're supposed to await some task!
        Await Task.Delay(100)
    End Function

    Public Async Function Method2() As Task(Of Integer)
        'We're supposed to await some task!
        Await Task.Delay(100)

        'We're returning an result.
        Return 42
    End Function

    Public Async Function Method3() As Task(Of String)
        'We're supposed to await some task!
        Await Task.Delay(100)

        'We're returning an result.
        Return "fourtytwo"
    End Function

    Public Async Function Method4() As Task(Of Task)
        'We're supposed to await some task!
        Await Task.Delay(100)

        'We're returning an task doing some expensive CPU Bound work.
        Return Task.Run(
            Sub()
                For I = 1 To 1000
                    Thread.SpinWait(100)
                Next
            End Sub)
    End Function

End Class
