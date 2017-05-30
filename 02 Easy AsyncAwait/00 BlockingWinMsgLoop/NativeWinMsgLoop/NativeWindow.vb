Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic
Imports PInvoke.User32
Imports PInvoke.Kernel32

'INSTANT VB NOTE: This code snippet uses implicit typing. You will need to set 'Option Infer On' in the VB file or set 'Option Infer' at the project level.

Public NotInheritable Class WinNative

    Private Sub New()
    End Sub

    <DllImport("user32.dll", SetLastError:=True, EntryPoint:="RegisterClassEx")>
    Shared Function RegisterClassEx(<[In]()> ByRef lpWndClass As WNDCLASSEX) As System.UInt16
    End Function

    <DllImport("user32.dll", SetLastError:=True, EntryPoint:="CreateWindowEx")>
    Public Shared Function CreateWindowEx(ByVal dwExStyle As Integer,
                                          ByVal regResult As UInt16,
                                          ByVal lpWindowName As String,
                                          ByVal dwStyle As UInt32,
                                          ByVal x As Integer, ByVal y As Integer,
                                          ByVal nWidth As Integer, ByVal nHeight As Integer,
                                          ByVal hWndParent As IntPtr, ByVal hMenu As IntPtr,
                                          ByVal hInstance As IntPtr, ByVal lpParam As IntPtr) As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True)>
    Shared Function DestroyWindow(ByVal hWnd As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll")>
    Shared Function GetMessage(ByRef lpMsg As MSG,
                               ByVal hWnd As IntPtr,
                               ByVal wMsgFilterMin As UInteger,
                               ByVal wMsgFilterMax As UInteger) As SByte
    End Function

    <DllImport("user32.dll")>
    Shared Function PeekMessage(ByRef lpMsg As MSG,
                                ByVal hWnd As IntPtr,
                                ByVal wMsgFilterMin As UInteger,
                                ByVal wMsgFilterMax As UInteger,
                                ByVal wRemoveMsg As UInteger) As SByte
    End Function

    <DllImport("user32.dll")>
    Shared Function TranslateMessage(<[In]()> ByRef lpMsg As MSG) As Boolean
    End Function

    <DllImport("user32.dll")>
    Shared Function DispatchMessage(<[In]()> ByRef lpmsg As MSG) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Shared Sub PostQuitMessage(ByVal nExitCode As Integer)
    End Sub

    Private Const COLOR_WINDOW As UInteger = 5
    Private Const COLOR_BACKGROUND As UInteger = 1
    Private Const IDC_CROSS As UInteger = 32515

    Public Delegate Function WndProcDel(ByVal hWnd As IntPtr, ByVal msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    Public Shared Function CreateWindow(windowTitel As String,
                                        wndProc As WndProcDel,
                                        rec As Rectangle) As IntPtr
        Dim wind_class As New WNDCLASSEX()

        wind_class.cbSize = Marshal.SizeOf(GetType(WNDCLASSEX))
        wind_class.style = CInt(ClassStyles.CS_HREDRAW Or ClassStyles.CS_VREDRAW Or ClassStyles.CS_DBLCLKS)
        wind_class.hbrBackground = CType(COLOR_BACKGROUND, IntPtr) + 1
        wind_class.cbClsExtra = 0
        wind_class.cbWndExtra = 0
        wind_class.hInstance = Process.GetCurrentProcess().Handle
        wind_class.hIcon = IntPtr.Zero
        wind_class.hCursor = LoadCursor(IntPtr.Zero, New IntPtr(IDC_CROSS))
        wind_class.lpszMenuName = Nothing
        wind_class.lpszClassName = "winClass"
        wind_class.lpfnWndProc = Marshal.GetFunctionPointerForDelegate(wndProc)
        wind_class.hIconSm = IntPtr.Zero
        Dim regResult As UShort = RegisterClassEx(wind_class)

        If regResult = 0 Then
            Dim [error] = GetLastError()
        End If
        Dim wndClass As String = wind_class.lpszClassName

        Dim hWnd As IntPtr = CreateWindowEx(0, regResult, windowTitel,
                                            CUInt(WindowStyles.WS_OVERLAPPEDWINDOW Or WindowStyles.WS_VISIBLE),
                                            rec.X, rec.Y, rec.Width, rec.Height,
                                            IntPtr.Zero, IntPtr.Zero, wind_class.hInstance, IntPtr.Zero)

        If hWnd = (New IntPtr(0)) Then
            Dim [error] = GetLastError()
        End If
        ShowWindow(hWnd, WindowShowStyle.SW_SHOWNORMAL)
        UpdateWindow(hWnd)
        Return hWnd
    End Function

    Public Shared Function CreateButton(caption As String,
                                        ParentWindow As IntPtr,
                                        rec As Rectangle,
                                        uniqueId As UShort) As IntPtr

        Dim hwnd = PInvoke.User32.CreateWindow("BUTTON", caption, WindowStyles.WS_CHILD Or WindowStyles.WS_VISIBLE,
                                rec.X, rec.Y, rec.Width, rec.Height, ParentWindow, New IntPtr(uniqueId),
                                Process.GetCurrentProcess().Handle, IntPtr.Zero)
        Return hwnd

    End Function

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Public Structure WNDCLASSEX
        <MarshalAs(UnmanagedType.U4)>
        Public cbSize As Integer
        <MarshalAs(UnmanagedType.U4)>
        Public style As Integer
        Public lpfnWndProc As IntPtr
        Public cbClsExtra As Integer
        Public cbWndExtra As Integer
        Public hInstance As IntPtr
        Public hIcon As IntPtr
        Public hCursor As IntPtr
        Public hbrBackground As IntPtr
        Public lpszMenuName As String
        Public lpszClassName As String
        Public hIconSm As IntPtr
    End Structure
End Class