<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lstResultList = New System.Windows.Forms.ListBox()
        Me.moveButton = New System.Windows.Forms.Button()
        Me.lstContacts = New System.Windows.Forms.CheckedListBox()
        Me.TestButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lstResultList, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.moveButton, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lstContacts, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(36, 29)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1518, 779)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lstResultList
        '
        Me.lstResultList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstResultList.FormattingEnabled = True
        Me.lstResultList.ItemHeight = 31
        Me.lstResultList.Location = New System.Drawing.Point(916, 6)
        Me.lstResultList.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.lstResultList.Name = "lstResultList"
        Me.lstResultList.Size = New System.Drawing.Size(596, 767)
        Me.lstResultList.TabIndex = 2
        '
        'moveButton
        '
        Me.moveButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.moveButton.Location = New System.Drawing.Point(659, 347)
        Me.moveButton.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.moveButton.Name = "moveButton"
        Me.moveButton.Size = New System.Drawing.Size(198, 85)
        Me.moveButton.TabIndex = 1
        Me.moveButton.Text = "Move >>"
        Me.moveButton.UseVisualStyleBackColor = True
        '
        'lstContacts
        '
        Me.lstContacts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstContacts.FormattingEnabled = True
        Me.lstContacts.Location = New System.Drawing.Point(6, 6)
        Me.lstContacts.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.lstContacts.Name = "lstContacts"
        Me.lstContacts.Size = New System.Drawing.Size(595, 767)
        Me.lstContacts.TabIndex = 3
        '
        'TestButton
        '
        Me.TestButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TestButton.Location = New System.Drawing.Point(694, 911)
        Me.TestButton.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.TestButton.Name = "TestButton"
        Me.TestButton.Size = New System.Drawing.Size(198, 85)
        Me.TestButton.TabIndex = 2
        Me.TestButton.Text = "Test"
        Me.TestButton.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1604, 1087)
        Me.Controls.Add(Me.TestButton)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "MainForm"
        Me.Text = "Tuple Demo"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lstResultList As ListBox
    Friend WithEvents moveButton As Button
    Friend WithEvents lstContacts As CheckedListBox
    Friend WithEvents TestButton As Button
End Class
