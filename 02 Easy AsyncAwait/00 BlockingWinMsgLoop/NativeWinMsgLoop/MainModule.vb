Imports System.Runtime.InteropServices
Imports System.Threading
Imports PInvoke.User32

Module MainModule

    'The Name of the Button.
    Public Const CAUSE_WORKLOAD_BUTTON_ID = 42

    Private wndProcDelegate As WinNative.WndProcDel = AddressOf WndProc

    Public Sub Main()
        'Let's create the Main Windows
        Dim hWndOfMainWin = WinNative.CreateWindow(
                                "Native Windows Message Loop",     ' Window Titel
                                AddressOf WndProc,                 ' Address of WndProc Method
                                New Rectangle(100, 100, 300, 400)) ' Window Pos and Size

        Dim buttonHwnd = WinNative.CreateButton(
                               "Do some work",                  ' Caption on Button
                               hWndOfMainWin,                   ' Add Button to Window
                               New Rectangle(50, 50, 100, 50),  ' Size auf Button
                               CAUSE_WORKLOAD_BUTTON_ID)        ' Identifier for Message Queue
        'Let's start the Message-Loop
        MessageLoop()
    End Sub

    Public Sub MessageLoop()

        Dim msg As MSG

        'Get Message Waits for a Message until it returns not 0.
        Do While WinNative.GetMessage(msg, IntPtr.Zero, 0, 0) <> 0
            'When we need to get WM_KEYDOWN, WM_KEYUP, we need to do this:
            WinNative.TranslateMessage(msg)
            'Messages get dispatched to WndProc.
            WinNative.DispatchMessage(msg)
        Loop
    End Sub

    Public Sub DoEvents()

        Dim msg As MSG

        If WinNative.PeekMessage(msg, IntPtr.Zero, 0, 0, 0) <> 0 Then
            WinNative.GetMessage(msg, IntPtr.Zero, 0, 0)
            'When we need to get WM_KEYDOWN, WM_KEYUP, we need to do this:
            WinNative.TranslateMessage(msg)
            'Messages get dispatched to WndProc.
            WinNative.DispatchMessage(msg)
        End If
    End Sub

    Private Function WndProc(ByVal hWnd As IntPtr, ByVal msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
        Dim wMsg As WindowMessage = CType(msg, WindowMessage)

        Debug.Print(wMsg.ToString)


        Dim ID_MENU = CInt(wParam.ToInt32 And &B11111111)

        Select Case wMsg
            Case WindowMessage.WM_COMMAND
                Button1_Click

            Case WindowMessage.WM_DESTROY
                PostQuitMessage(0)

            Case Else
        End Select

        'Those messages we did not process, are getting processed here:
        Return DefWindowProc(hWnd, wMsg, wParam, lParam)
    End Function

    ''' <summary>
    ''' Sorgt dafür, dass die lange Operation ausgeführt wird.
    ''' </summary>
    Private Sub Button1_Click()
        For z = Integer.MinValue To Integer.MaxValue - 1
            'This is just another way to burn processor workload like in a loop.
            '(But in addition the hardware can be informed that it is busy waiting).
            Thread.SpinWait(10000)
            'When we want to have this non-blocking, we need to uncomment this.
            'DoEvents()
        Next
    End Sub

End Module
