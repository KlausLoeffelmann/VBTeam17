<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.runOnceTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPickPath = New System.Windows.Forms.Button()
        Me.txtTargetFolder = New System.Windows.Forms.TextBox()
        Me.btnWriteFileAsync = New System.Windows.Forms.Button()
        Me.btnAwaitWriteFile = New System.Windows.Forms.Button()
        Me.btnWriteFileSync = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ThrottleTrackBar = New System.Windows.Forms.TrackBar()
        Me.lblElapsedTime = New System.Windows.Forms.Label()
        Me.lblDigitNo = New System.Windows.Forms.Label()
        Me.piCalculationProgress = New System.Windows.Forms.ProgressBar()
        Me.lblCurrentPiFragment = New System.Windows.Forms.Label()
        Me.lblTitel = New System.Windows.Forms.Label()
        Me.txtPiResult = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ThrottleTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'runOnceTimer
        '
        Me.runOnceTimer.Enabled = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnWriteFileAsync, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAwaitWriteFile, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnWriteFileSync, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(13, 12)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(643, 534)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnPickPath)
        Me.Panel1.Controls.Add(Me.txtTargetFolder)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 356)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(637, 112)
        Me.Panel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Path to Folder on USB Thumb Drive:"
        '
        'btnPickPath
        '
        Me.btnPickPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPickPath.Location = New System.Drawing.Point(448, 64)
        Me.btnPickPath.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPickPath.Name = "btnPickPath"
        Me.btnPickPath.Size = New System.Drawing.Size(180, 41)
        Me.btnPickPath.TabIndex = 1
        Me.btnPickPath.Text = "Pick Path..."
        Me.btnPickPath.UseVisualStyleBackColor = True
        '
        'txtTargetFolder
        '
        Me.txtTargetFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTargetFolder.Location = New System.Drawing.Point(8, 29)
        Me.txtTargetFolder.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTargetFolder.Name = "txtTargetFolder"
        Me.txtTargetFolder.Size = New System.Drawing.Size(621, 22)
        Me.txtTargetFolder.TabIndex = 0
        '
        'btnWriteFileAsync
        '
        Me.btnWriteFileAsync.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnWriteFileAsync.Location = New System.Drawing.Point(246, 482)
        Me.btnWriteFileAsync.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnWriteFileAsync.Name = "btnWriteFileAsync"
        Me.btnWriteFileAsync.Size = New System.Drawing.Size(180, 40)
        Me.btnWriteFileAsync.TabIndex = 2
        Me.btnWriteFileAsync.Text = "Write File Async..."
        Me.btnWriteFileAsync.UseVisualStyleBackColor = True
        '
        'btnAwaitWriteFile
        '
        Me.btnAwaitWriteFile.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAwaitWriteFile.Location = New System.Drawing.Point(455, 482)
        Me.btnAwaitWriteFile.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAwaitWriteFile.Name = "btnAwaitWriteFile"
        Me.btnAwaitWriteFile.Size = New System.Drawing.Size(180, 40)
        Me.btnAwaitWriteFile.TabIndex = 3
        Me.btnAwaitWriteFile.Text = "Await Write File..."
        Me.btnAwaitWriteFile.UseVisualStyleBackColor = True
        '
        'btnWriteFileSync
        '
        Me.btnWriteFileSync.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnWriteFileSync.Location = New System.Drawing.Point(22, 482)
        Me.btnWriteFileSync.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnWriteFileSync.Name = "btnWriteFileSync"
        Me.btnWriteFileSync.Size = New System.Drawing.Size(180, 40)
        Me.btnWriteFileSync.TabIndex = 1
        Me.btnWriteFileSync.Text = "Write File Sync..."
        Me.btnWriteFileSync.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel2, 3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.ThrottleTrackBar)
        Me.Panel2.Controls.Add(Me.lblElapsedTime)
        Me.Panel2.Controls.Add(Me.lblDigitNo)
        Me.Panel2.Controls.Add(Me.piCalculationProgress)
        Me.Panel2.Controls.Add(Me.lblCurrentPiFragment)
        Me.Panel2.Controls.Add(Me.lblTitel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(637, 348)
        Me.Panel2.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 245)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(618, 32)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Throttle:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ThrottleTrackBar
        '
        Me.ThrottleTrackBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ThrottleTrackBar.Location = New System.Drawing.Point(197, 282)
        Me.ThrottleTrackBar.Minimum = 1
        Me.ThrottleTrackBar.Name = "ThrottleTrackBar"
        Me.ThrottleTrackBar.Size = New System.Drawing.Size(250, 56)
        Me.ThrottleTrackBar.TabIndex = 5
        Me.ThrottleTrackBar.Value = 10
        '
        'lblElapsedTime
        '
        Me.lblElapsedTime.BackColor = System.Drawing.Color.Transparent
        Me.lblElapsedTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblElapsedTime.Location = New System.Drawing.Point(159, 189)
        Me.lblElapsedTime.Name = "lblElapsedTime"
        Me.lblElapsedTime.Size = New System.Drawing.Size(329, 29)
        Me.lblElapsedTime.TabIndex = 4
        Me.lblElapsedTime.Text = "0:00:00:0"
        Me.lblElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDigitNo
        '
        Me.lblDigitNo.Location = New System.Drawing.Point(10, 151)
        Me.lblDigitNo.Name = "lblDigitNo"
        Me.lblDigitNo.Size = New System.Drawing.Size(618, 24)
        Me.lblDigitNo.TabIndex = 3
        Me.lblDigitNo.Text = "Calculating #### digit"
        Me.lblDigitNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'piCalculationProgress
        '
        Me.piCalculationProgress.Location = New System.Drawing.Point(10, 178)
        Me.piCalculationProgress.Name = "piCalculationProgress"
        Me.piCalculationProgress.Size = New System.Drawing.Size(620, 52)
        Me.piCalculationProgress.TabIndex = 2
        '
        'lblCurrentPiFragment
        '
        Me.lblCurrentPiFragment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCurrentPiFragment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurrentPiFragment.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentPiFragment.Location = New System.Drawing.Point(10, 54)
        Me.lblCurrentPiFragment.Name = "lblCurrentPiFragment"
        Me.lblCurrentPiFragment.Size = New System.Drawing.Size(618, 74)
        Me.lblCurrentPiFragment.TabIndex = 1
        Me.lblCurrentPiFragment.Text = "3.14159265..."
        Me.lblCurrentPiFragment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitel
        '
        Me.lblTitel.AutoSize = True
        Me.lblTitel.Location = New System.Drawing.Point(7, 16)
        Me.lblTitel.Name = "lblTitel"
        Me.lblTitel.Size = New System.Drawing.Size(312, 17)
        Me.lblTitel.TabIndex = 0
        Me.lblTitel.Text = "Calculating Pi (3.1415926...) with 100,000 digits:"
        '
        'txtPiResult
        '
        Me.txtPiResult.Location = New System.Drawing.Point(25, 51)
        Me.txtPiResult.Multiline = True
        Me.txtPiResult.Name = "txtPiResult"
        Me.txtPiResult.Size = New System.Drawing.Size(619, 302)
        Me.txtPiResult.TabIndex = 8
        Me.txtPiResult.Visible = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(669, 562)
        Me.Controls.Add(Me.txtPiResult)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Easy Async and Await"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.ThrottleTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents runOnceTimer As Timer
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnWriteFileSync As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnPickPath As Button
    Friend WithEvents txtTargetFolder As TextBox
    Friend WithEvents btnWriteFileAsync As Button
    Friend WithEvents btnAwaitWriteFile As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblTitel As Label
    Friend WithEvents lblDigitNo As Label
    Friend WithEvents piCalculationProgress As ProgressBar
    Friend WithEvents lblCurrentPiFragment As Label
    Friend WithEvents lblElapsedTime As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ThrottleTrackBar As TrackBar
    Friend WithEvents txtPiResult As TextBox
End Class
