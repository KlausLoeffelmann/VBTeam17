Imports System.IO
Imports System.Numerics
Imports System.Runtime.CompilerServices
Imports System.Security.AccessControl
Imports System.Text
Imports System.Threading

Public Class MainForm

    Private Const DIGITS_OF_PI = 100000
    Private Const BYTES_TO_WRITE = 100000000
    Private Const BIG_FILES_NAME = "\demodata.bin"

    Private myStartTime As Date
    Private myPiLabelContent As String = ""
    Private myRandomBytes As Byte() = New Byte(BYTES_TO_WRITE - 1) {}
    Private mySignalEndProgram As Boolean

    Private myUpdateElapsedTimeSuspended As Boolean

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'We do not want to store the throttle setting
        'before InitializeComponent is done, because otherwise
        'the setting always gets overridden with the default value.
        AddHandler ThrottleTrackBar.ValueChanged, AddressOf ThrottleTrackBar_ValueChanged

        'These are the bytes we want to write as demodata.bin on the memory stick.
        Dim randomGenerator = New Random(Now.Millisecond)
        randomGenerator.NextBytes(myRandomBytes)
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'When the Form shows, we take the last folder path from the Settings.
        If Not String.IsNullOrWhiteSpace(My.Settings.LastPathToThumbDriveFolder) Then
            TargetFolder = My.Settings.LastPathToThumbDriveFolder
            If My.Settings.ThrottleValue = 0 Then
                My.Settings.ThrottleValue = 10
            End If
            ThrottleTrackBar.Value = My.Settings.ThrottleValue
        End If

        'Setting the titel label (don't we love string interpolation? :-)
        lblTitel.Text = $"Calculating {DIGITS_OF_PI} digits of Pi ({Math.PI}...)"

        'We schedule this for execution as soon as the message loop is idling again.
        'The remaining code for loading the form can therefore finish first.
        Me.BeginInvoke(New Action(AddressOf StartAfterMainFormLoaded))
    End Sub

    Private Sub StartAfterMainFormLoaded()
        Try
            'So, we're immediately starting calculating PI to 100,000 digits!
            myStartTime = Now
            Dim piResult = DoPiCalc()
            txtPiResult.Visible = True
            txtPiResult.Text = piResult
        Catch ex As Exception
        End Try
    End Sub

    'Updates the UI, so we can see some Pi calculating is going on.
    Public Sub UpdateUI(digitNo As Integer, currentDigit As String)

        'When we throttle the processor to calculate very slowly,
        'we can actually see how each next digit of pi come in.
        If myPiLabelContent.Length < 10 Then
            myPiLabelContent += currentDigit
        Else
            myPiLabelContent = myPiLabelContent.Substring(myPiLabelContent.Length - 9, 9) & currentDigit
        End If

        'Updating the pi-fragment with the newly calculated pi digit.
        lblCurrentPiFragment.Text = myPiLabelContent

        'Updating which No of Pi digit we just calculated.
        lblDigitNo.Text = digitNo.ToString

        'Updating the progress bar.
        piCalculationProgress.Value = CInt(100 / DIGITS_OF_PI * digitNo)

        If Not myUpdateElapsedTimeSuspended Then
            'Also update the time elapsed:
            lblElapsedTime.Text = (Now - myStartTime).ToString("h\:mm\:ss")
        End If

        'Let the app breathe! We need the Message Loop to catch on.
        Application.DoEvents()

        'And this is how we throttle things. We're just suspending the 
        'the thread for n milliseconds. The processor does not do any work
        'in that period of time.
        Thread.Sleep(200 - ThrottleTrackBar.Value * 20)
    End Sub

    Private Sub btnPickPath_Click(sender As Object, e As EventArgs) Handles btnPickPath.Click
        Dim folderGetter As New FolderBrowserDialog With
            {
                .Description = "Pick Path to Thumb Drive:",
                .ShowNewFolderButton = True
            }

        If Not String.IsNullOrWhiteSpace(txtTargetFolder.Text) Then
            folderGetter.SelectedPath = TargetFolder
        End If

        Dim dResult = folderGetter.ShowDialog()
        If dResult = DialogResult.OK Then
            'Setting the target folder also takes care
            'of serializing the setting.
            TargetFolder = folderGetter.SelectedPath
        End If
    End Sub

    'If the path to the file on the thumb drive does not exist,
    'we're creating it first.
    Private Sub EnsureFolderExists()
        Dim testFolderInfo As New DirectoryInfo(TargetFolder)
        If Not testFolderInfo.Exists Then
            testFolderInfo.Create()
        End If
    End Sub

    Public Property TargetFolder As String
        Get
            Return txtTargetFolder.Text
        End Get
        Set(value As String)
            txtTargetFolder.Text = value
            My.Settings.LastPathToThumbDriveFolder = txtTargetFolder.Text
        End Set
    End Property

    'This is the sync version of putting the 100 MByte file on the memory stick.
    'Observe, how the processor workload changes in the task manager,
    'and how "responsive" the app becomes!
    Private Sub btnWriteFileSync_Click(sender As Object, e As EventArgs) Handles btnWriteFileSync.Click

        lblElapsedTime.Text = "Saving File..."

        'There is no active Message Loop at this time, so the
        'WM_PAINT for the label is coming in way too late!
        'That's why we have to force the refresh directly.
        lblElapsedTime.Refresh()

        Try
            EnsureFolderExists()

            Dim fs As FileStream

            fs = New FileStream(TargetFolder & BIG_FILES_NAME, FileMode.Create)
            fs.Write(myRandomBytes, 0,
                     myRandomBytes.Length)
            fs.Flush()
            fs.Close()
        Catch ex As Exception
            MessageBox.Show("Something did not go according to plan..." & vbCrLf &
                            "(did you take the memory stick out?)" & vbCr & vbCr &
                            ex.Message, ex.GetType.ToString)
        End Try
    End Sub

    'This is the old fashion async version.
    'We're just kicking of the "put-the-file-on-stick"-operation...
    Private Sub btnWriteFileAsync_Click(sender As Object, e As EventArgs) Handles btnWriteFileAsync.Click

        lblElapsedTime.Text = "Saving File..."
        'This time, we need no Refresh. Since this event handler is only
        'kicking of the I/O Bound workload (on the same thread, btw!)
        'the message loop continues, and the UI gets updated automatically.

        'However: Since we want to see 'Saving File...' for as long as it takes,
        'we should not update the time elapsed display for the time being.
        myUpdateElapsedTimeSuspended = True

        Try
            EnsureFolderExists()

            Dim fs As FileStream

            'We need to force the FileStream to really be asynchronous. That means,
            'setting the flags, reserving a buffer big enough to hold the complete file
            '(otherwise already BeginWrite would be blocking!), and requesting async File-IO by
            'passing True as last parameter.
            fs = New FileStream(TargetFolder & BIG_FILES_NAME, FileMode.Create,
                                FileAccess.ReadWrite, FileShare.None, BYTES_TO_WRITE, True)

            'We're only kicking of the I/O-Operation. And telling it: 
            '"Call us back. The number is E-n-d-W-r-i-t-e-F-i-l-e-P-r-o-c!"...
            Dim result = fs.BeginWrite(myRandomBytes, 0,
                                       myRandomBytes.Length,
                                       AddressOf EndWriteFileProc, fs)
        Catch ex As Exception
            MessageBox.Show("Something did not go according to plan..." & vbCrLf &
                            "(did you take the memory stick out?)" & vbCr & vbCr &
                            ex.Message, ex.GetType.ToString)
        End Try
    End Sub

    '...and it calls back here, when the component in charge of 
    'your PC (Tablet, Phone equivalent) is done with putting it there.
    'The Processor is doing absolutely nothing for this method in the meantime.
    Private Sub EndWriteFileProc(asyncResult As IAsyncResult)
        Dim fs As FileStream

        fs = DirectCast(asyncResult.AsyncState, FileStream)
        fs.EndWrite(asyncResult)
        fs.Flush()
        fs.Close()

        'We do not need any longer to show "Saving file..."
        myUpdateElapsedTimeSuspended = False

    End Sub

    Public Sub WriteFileCommandProcAsyncInOneMethod(asyncResult As IAsyncResult)

        Dim fs As FileStream

        'Test the state. If asyncResult has a content,
        'this method act as the callback part...
        If asyncResult IsNot Nothing Then
            GoTo CompleteAsyncFileOperation
        End If

        '...otherweise as the kick-off part:
        fs = New FileStream(TargetFolder & BIG_FILES_NAME, FileMode.Create,
                            FileAccess.Write, FileShare.None, BYTES_TO_WRITE, True)

        Dim result = fs.BeginWrite(myRandomBytes, 0,
                                   myRandomBytes.Length,
                                   AddressOf WriteFileCommandProcAsyncInOneMethod,
                                   fs)
        Exit Sub

        'AWAIT! 
        'At this point the app is awaiting the callback of the write operation.
        'And it is doing absolutely nothing!
        '(well, nothing other than cycling the Windows Message Loop).

        'And here comes the callback part:
CompleteAsyncFileOperation:
        fs = DirectCast(asyncResult.AsyncState, FileStream)
        fs.EndWrite(asyncResult)
        fs.Flush()
        fs.Close()
    End Sub

    Private Async Sub btnAwaitWriteFile_Click(sender As Object,
                                              e As EventArgs) Handles btnAwaitWriteFile.Click
        Await WriteFileCommandProcAsync()
    End Sub

    'This is the Async/Await Version.
    Public Async Function WriteFileCommandProcAsync() As Task

        Try
            EnsureFolderExists()

            Dim fs As FileStream

            fs = New FileStream(TargetFolder & BIG_FILES_NAME, FileMode.Create,
                                FileAccess.ReadWrite, FileShare.None, BYTES_TO_WRITE,
                                FileOptions.Asynchronous)

            Dim test = fs.IsAsync

            lblElapsedTime.Text = "Saving File..."
            myUpdateElapsedTimeSuspended = True

            Await fs.WriteAsync(myRandomBytes, 0, BYTES_TO_WRITE).ConfigureAwait(False)
            Await fs.FlushAsync()
            myUpdateElapsedTimeSuspended = False

        Catch ex As Exception
            MessageBox.Show("Something did not go according to plan..." & vbCrLf &
                            "(did you take the memory stick out?)" & vbCr & vbCr &
                            ex.Message, ex.GetType.ToString)
        End Try
    End Function

    'Yet another version, done by a task alone. No await, no async.
    Public Sub WriteFileCommandProcApmTaskCoveredAsync()

        EnsureFolderExists()

        Dim fs As FileStream

        fs = New FileStream(TargetFolder & BIG_FILES_NAME, FileMode.Create,
                                FileAccess.Write, FileShare.None, BYTES_TO_WRITE, True)

        Dim taskToReturn = Task.Factory.FromAsync(AddressOf fs.BeginWrite,
                                                  AddressOf fs.EndWrite,
                                                  myRandomBytes, 0,
                                                  myRandomBytes.Length,
                                                  Nothing).
        ContinueWith(Sub()
                         fs.Flush()
                         fs.Close()
                     End Sub)
    End Sub

    'Simple Pi_Calc Algorithm.
    Private Function DoPiCalc() As String
        Dim piCalc As New PiCalc()

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

                UpdateUI(digitCount, d.ToString)

                a = TEN * (a Mod b)
                a1 = TEN * (a1 Mod b1)
                d = a / b
                d1 = a1 / b1
            Loop
            If digitCount = DIGITS_OF_PI Or mySignalEndProgram Then
                Return sb.ToString
            End If
        Loop
    End Function

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)
        mySignalEndProgram = True
    End Sub

    Private Sub ThrottleTrackBar_ValueChanged(sender As Object, e As EventArgs)
        My.Settings.ThrottleValue = ThrottleTrackBar.Value
    End Sub
End Class

Public Module FileStreamAsyncExtender

    <Extension>
    Public Async Function WriteAsync(fs As FileStream, buffer As Byte()) As Task

        'Await Task.Factory.FromAsync(AddressOf fs.BeginWrite,
        '                             AddressOf fs.EndWrite,
        '                             buffer, 0,
        '                             buffer.Length,
        '                             Nothing)

        Dim tcs As New TaskCompletionSource(Of Boolean)

        Dim result = fs.BeginWrite(buffer, 0,
                                   buffer.Length,
                                   Sub(asyncResult As IAsyncResult)
                                       fs.EndWrite(asyncResult)
                                       fs.Flush()
                                       tcs.TrySetResult(True)
                                   End Sub,
                                   fs)

        Await tcs.Task

    End Function

End Module
