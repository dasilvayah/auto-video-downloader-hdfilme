<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.link = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Start = New System.Windows.Forms.Button()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_test = New System.Windows.Forms.Button()
        Me.RadioHigh = New System.Windows.Forms.RadioButton()
        Me.RadioLow = New System.Windows.Forms.RadioButton()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_copy_1 = New System.Windows.Forms.Button()
        Me.btn_copy_2 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dest_path = New System.Windows.Forms.TextBox()
        Me.btn_dest = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btn_download = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'link
        '
        Me.link.Location = New System.Drawing.Point(93, 17)
        Me.link.Name = "link"
        Me.link.Size = New System.Drawing.Size(684, 20)
        Me.link.TabIndex = 0
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(10, 107)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(767, 12)
        Me.ProgressBar1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Link"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 146)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox1.Size = New System.Drawing.Size(319, 316)
        Me.ListBox1.TabIndex = 3
        '
        'Start
        '
        Me.Start.Location = New System.Drawing.Point(539, 72)
        Me.Start.Name = "Start"
        Me.Start.Size = New System.Drawing.Size(107, 27)
        Me.Start.TabIndex = 4
        Me.Start.Text = "Get Films List"
        Me.Start.UseVisualStyleBackColor = True
        '
        'btn_exit
        '
        Me.btn_exit.Location = New System.Drawing.Point(670, 72)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(107, 27)
        Me.btn_exit.TabIndex = 4
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Video Mode"
        '
        'btn_test
        '
        Me.btn_test.Location = New System.Drawing.Point(421, 72)
        Me.btn_test.Name = "btn_test"
        Me.btn_test.Size = New System.Drawing.Size(90, 27)
        Me.btn_test.TabIndex = 4
        Me.btn_test.Text = "test"
        Me.btn_test.UseVisualStyleBackColor = True
        Me.btn_test.Visible = False
        '
        'RadioHigh
        '
        Me.RadioHigh.AutoSize = True
        Me.RadioHigh.Location = New System.Drawing.Point(206, 74)
        Me.RadioHigh.Name = "RadioHigh"
        Me.RadioHigh.Size = New System.Drawing.Size(82, 17)
        Me.RadioHigh.TabIndex = 6
        Me.RadioHigh.Text = "High Quality"
        Me.RadioHigh.UseVisualStyleBackColor = True
        '
        'RadioLow
        '
        Me.RadioLow.AutoSize = True
        Me.RadioLow.Checked = True
        Me.RadioLow.Location = New System.Drawing.Point(93, 74)
        Me.RadioLow.Name = "RadioLow"
        Me.RadioLow.Size = New System.Drawing.Size(80, 17)
        Me.RadioLow.TabIndex = 7
        Me.RadioLow.TabStop = True
        Me.RadioLow.Text = "Low Quality"
        Me.RadioLow.UseVisualStyleBackColor = True
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(421, 146)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox2.Size = New System.Drawing.Size(356, 316)
        Me.ListBox2.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Url List"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(418, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Download List"
        '
        'btn_copy_1
        '
        Me.btn_copy_1.Location = New System.Drawing.Point(54, 125)
        Me.btn_copy_1.Name = "btn_copy_1"
        Me.btn_copy_1.Size = New System.Drawing.Size(128, 21)
        Me.btn_copy_1.TabIndex = 10
        Me.btn_copy_1.Text = "Copy Selected Items"
        Me.btn_copy_1.UseVisualStyleBackColor = True
        '
        'btn_copy_2
        '
        Me.btn_copy_2.Location = New System.Drawing.Point(498, 125)
        Me.btn_copy_2.Name = "btn_copy_2"
        Me.btn_copy_2.Size = New System.Drawing.Size(118, 21)
        Me.btn_copy_2.TabIndex = 11
        Me.btn_copy_2.Text = "Copy Selected Items"
        Me.btn_copy_2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Dest Directory"
        '
        'dest_path
        '
        Me.dest_path.Location = New System.Drawing.Point(93, 43)
        Me.dest_path.Name = "dest_path"
        Me.dest_path.Size = New System.Drawing.Size(590, 20)
        Me.dest_path.TabIndex = 13
        '
        'btn_dest
        '
        Me.btn_dest.Location = New System.Drawing.Point(689, 42)
        Me.btn_dest.Name = "btn_dest"
        Me.btn_dest.Size = New System.Drawing.Size(88, 22)
        Me.btn_dest.TabIndex = 14
        Me.btn_dest.Text = "Open"
        Me.btn_dest.UseVisualStyleBackColor = True
        '
        'btn_download
        '
        Me.btn_download.Location = New System.Drawing.Point(337, 254)
        Me.btn_download.Name = "btn_download"
        Me.btn_download.Size = New System.Drawing.Size(78, 65)
        Me.btn_download.TabIndex = 15
        Me.btn_download.Text = "Download Selected Items"
        Me.btn_download.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 472)
        Me.Controls.Add(Me.btn_download)
        Me.Controls.Add(Me.btn_dest)
        Me.Controls.Add(Me.dest_path)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_copy_2)
        Me.Controls.Add(Me.btn_copy_1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.RadioLow)
        Me.Controls.Add(Me.RadioHigh)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.btn_test)
        Me.Controls.Add(Me.Start)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.link)
        Me.Name = "Form1"
        Me.Text = "Auto Download"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents link As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Start As System.Windows.Forms.Button
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_test As System.Windows.Forms.Button
    Friend WithEvents RadioHigh As System.Windows.Forms.RadioButton
    Friend WithEvents RadioLow As System.Windows.Forms.RadioButton
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_copy_1 As System.Windows.Forms.Button
    Friend WithEvents btn_copy_2 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dest_path As System.Windows.Forms.TextBox
    Friend WithEvents btn_dest As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btn_download As System.Windows.Forms.Button

End Class
