<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PathSettings
    Inherits System.Windows.Forms.Form

    'Formularz przesłania metodę dispose, aby wyczyścić listę składników.
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

    'Wymagane przez Projektanta formularzy systemu Windows
    Private components As System.ComponentModel.IContainer

    'UWAGA: następująca procedura jest wymagana przez Projektanta formularzy systemu Windows
    'Możesz to modyfikować, używając Projektanta formularzy systemu Windows. 
    'Nie należy modyfikować za pomocą edytora kodu.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tb_exfile_name = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tb_mainfile_naming = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_mainfile_path = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tb_uc_naming = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_uc_path = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tb_je_naming = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_je_path = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.tb_ed_naming = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_ed_path = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox1.Controls.Add(Me.tb_exfile_name)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.tb_mainfile_naming)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tb_mainfile_path)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(284, 118)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Translations"
        '
        'tb_exfile_name
        '
        Me.tb_exfile_name.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_exfile_name", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_exfile_name.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_exfile_name.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb_exfile_name.Location = New System.Drawing.Point(3, 95)
        Me.tb_exfile_name.Name = "tb_exfile_name"
        Me.tb_exfile_name.Size = New System.Drawing.Size(278, 20)
        Me.tb_exfile_name.TabIndex = 5
        Me.tb_exfile_name.Text = Global.EDDTT.My.MySettings.Default.lang_exfile_name
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Full example file name:"
        '
        'tb_mainfile_naming
        '
        Me.tb_mainfile_naming.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_mainfile_naming", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_mainfile_naming.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_mainfile_naming.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb_mainfile_naming.Location = New System.Drawing.Point(3, 62)
        Me.tb_mainfile_naming.Name = "tb_mainfile_naming"
        Me.tb_mainfile_naming.Size = New System.Drawing.Size(278, 20)
        Me.tb_mainfile_naming.TabIndex = 3
        Me.tb_mainfile_naming.Text = Global.EDDTT.My.MySettings.Default.lang_mainfile_naming
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "File name format:"
        '
        'tb_mainfile_path
        '
        Me.tb_mainfile_path.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_mainfile_path", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_mainfile_path.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_mainfile_path.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.tb_mainfile_path.Location = New System.Drawing.Point(3, 29)
        Me.tb_mainfile_path.Name = "tb_mainfile_path"
        Me.tb_mainfile_path.Size = New System.Drawing.Size(278, 20)
        Me.tb_mainfile_path.TabIndex = 1
        Me.tb_mainfile_path.Text = Global.EDDTT.My.MySettings.Default.lang_mainfile_path
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Path:"
        '
        'GroupBox2
        '
        Me.GroupBox2.AutoSize = True
        Me.GroupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox2.Controls.Add(Me.tb_uc_naming)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.tb_uc_path)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(284, 85)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "UserControls"
        '
        'tb_uc_naming
        '
        Me.tb_uc_naming.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_uc_naming", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_uc_naming.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_uc_naming.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb_uc_naming.Location = New System.Drawing.Point(3, 62)
        Me.tb_uc_naming.Name = "tb_uc_naming"
        Me.tb_uc_naming.Size = New System.Drawing.Size(278, 20)
        Me.tb_uc_naming.TabIndex = 3
        Me.tb_uc_naming.Text = Global.EDDTT.My.MySettings.Default.lang_uc_naming
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(202, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "File name format (only 1 asterisk allowed):"
        '
        'tb_uc_path
        '
        Me.tb_uc_path.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_uc_path", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_uc_path.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_uc_path.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.tb_uc_path.Location = New System.Drawing.Point(3, 29)
        Me.tb_uc_path.Name = "tb_uc_path"
        Me.tb_uc_path.Size = New System.Drawing.Size(278, 20)
        Me.tb_uc_path.TabIndex = 1
        Me.tb_uc_path.Text = Global.EDDTT.My.MySettings.Default.lang_uc_path
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Path:"
        '
        'GroupBox3
        '
        Me.GroupBox3.AutoSize = True
        Me.GroupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox3.Controls.Add(Me.tb_je_naming)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.tb_je_path)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(0, 203)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(284, 85)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "JournalEvents"
        '
        'tb_je_naming
        '
        Me.tb_je_naming.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_je_naming", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_je_naming.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_je_naming.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb_je_naming.Location = New System.Drawing.Point(3, 62)
        Me.tb_je_naming.Name = "tb_je_naming"
        Me.tb_je_naming.Size = New System.Drawing.Size(278, 20)
        Me.tb_je_naming.TabIndex = 3
        Me.tb_je_naming.Text = Global.EDDTT.My.MySettings.Default.lang_je_naming
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(202, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "File name format (only 1 asterisk allowed):"
        '
        'tb_je_path
        '
        Me.tb_je_path.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_je_path", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_je_path.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_je_path.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.tb_je_path.Location = New System.Drawing.Point(3, 29)
        Me.tb_je_path.Name = "tb_je_path"
        Me.tb_je_path.Size = New System.Drawing.Size(278, 20)
        Me.tb_je_path.TabIndex = 1
        Me.tb_je_path.Text = Global.EDDTT.My.MySettings.Default.lang_je_path
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Path:"
        '
        'GroupBox4
        '
        Me.GroupBox4.AutoSize = True
        Me.GroupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox4.Controls.Add(Me.tb_ed_naming)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.tb_ed_path)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(0, 288)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(284, 85)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "EliteDangerous"
        '
        'tb_ed_naming
        '
        Me.tb_ed_naming.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_ed_naming", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_ed_naming.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_ed_naming.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb_ed_naming.Location = New System.Drawing.Point(3, 62)
        Me.tb_ed_naming.Name = "tb_ed_naming"
        Me.tb_ed_naming.Size = New System.Drawing.Size(278, 20)
        Me.tb_ed_naming.TabIndex = 3
        Me.tb_ed_naming.Text = Global.EDDTT.My.MySettings.Default.lang_ed_naming
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(202, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "File name format (only 1 asterisk allowed):"
        '
        'tb_ed_path
        '
        Me.tb_ed_path.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_ed_path", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_ed_path.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_ed_path.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.tb_ed_path.Location = New System.Drawing.Point(3, 29)
        Me.tb_ed_path.Name = "tb_ed_path"
        Me.tb_ed_path.Size = New System.Drawing.Size(278, 20)
        Me.tb_ed_path.TabIndex = 1
        Me.tb_ed_path.Text = Global.EDDTT.My.MySettings.Default.lang_ed_path
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Path:"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Location = New System.Drawing.Point(205, 379)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 9
        Me.OK_Button.Text = "OK"
        '
        'PathSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 414)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PathSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Path Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tb_exfile_name As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tb_mainfile_naming As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tb_mainfile_path As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents tb_uc_naming As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tb_uc_path As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents tb_je_naming As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tb_je_path As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents tb_ed_naming As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tb_ed_path As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents OK_Button As Button
End Class
