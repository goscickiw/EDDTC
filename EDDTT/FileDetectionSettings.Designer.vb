'Copyright 2019 Wojciech Gościcki (goscickiw)
'
'Licensed under the Apache License, Version 2.0 (the "License");
'you may Not use this file except In compliance With the License.
'You may obtain a copy Of the License at
'
'    http://www.apache.org/licenses/LICENSE-2.0
'
'Unless required by applicable law Or agreed To In writing, software
'distributed under the License Is distributed On an "AS IS" BASIS,
'WITHOUT WARRANTIES Or CONDITIONS Of ANY KIND, either express Or implied.
'See the License For the specific language governing permissions And
'limitations under the License.
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FileDetectionSettings
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
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.tc_detection_settings = New System.Windows.Forms.TabControl()
        Me.tp_paths_and_naming = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tp_file_structure = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tb_ed_naming = New System.Windows.Forms.TextBox()
        Me.tb_ed_path = New System.Windows.Forms.TextBox()
        Me.tb_je_naming = New System.Windows.Forms.TextBox()
        Me.tb_je_path = New System.Windows.Forms.TextBox()
        Me.tb_uc_naming = New System.Windows.Forms.TextBox()
        Me.tb_uc_path = New System.Windows.Forms.TextBox()
        Me.tb_exfile_name = New System.Windows.Forms.TextBox()
        Me.tb_mainfile_naming = New System.Windows.Forms.TextBox()
        Me.tb_mainfile_path = New System.Windows.Forms.TextBox()
        Me.cb_format_id_spaces = New System.Windows.Forms.CheckBox()
        Me.tb_format_id_translated = New System.Windows.Forms.TextBox()
        Me.tb_format_id_empty = New System.Windows.Forms.TextBox()
        Me.tb_format_inclusion = New System.Windows.Forms.TextBox()
        Me.tb_format_section = New System.Windows.Forms.TextBox()
        Me.tc_detection_settings.SuspendLayout()
        Me.tp_paths_and_naming.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tp_file_structure.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Location = New System.Drawing.Point(269, 427)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 9
        Me.OK_Button.Text = "OK"
        '
        'tc_detection_settings
        '
        Me.tc_detection_settings.Controls.Add(Me.tp_paths_and_naming)
        Me.tc_detection_settings.Controls.Add(Me.tp_file_structure)
        Me.tc_detection_settings.Location = New System.Drawing.Point(12, 12)
        Me.tc_detection_settings.MinimumSize = New System.Drawing.Size(324, 409)
        Me.tc_detection_settings.Name = "tc_detection_settings"
        Me.tc_detection_settings.SelectedIndex = 0
        Me.tc_detection_settings.Size = New System.Drawing.Size(324, 409)
        Me.tc_detection_settings.TabIndex = 10
        '
        'tp_paths_and_naming
        '
        Me.tp_paths_and_naming.BackColor = System.Drawing.SystemColors.Control
        Me.tp_paths_and_naming.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tp_paths_and_naming.Controls.Add(Me.GroupBox4)
        Me.tp_paths_and_naming.Controls.Add(Me.GroupBox3)
        Me.tp_paths_and_naming.Controls.Add(Me.GroupBox2)
        Me.tp_paths_and_naming.Controls.Add(Me.GroupBox1)
        Me.tp_paths_and_naming.Location = New System.Drawing.Point(4, 22)
        Me.tp_paths_and_naming.Name = "tp_paths_and_naming"
        Me.tp_paths_and_naming.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_paths_and_naming.Size = New System.Drawing.Size(316, 383)
        Me.tp_paths_and_naming.TabIndex = 0
        Me.tp_paths_and_naming.Text = "Paths and Naming"
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
        Me.GroupBox4.Location = New System.Drawing.Point(3, 291)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(306, 85)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "EliteDangerous"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(195, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "File name format ({0} = language name):"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(167, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Path (Has to start and end with \):"
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
        Me.GroupBox3.Location = New System.Drawing.Point(3, 206)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(306, 85)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "JournalEvents"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(195, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "File name format ({0} = language name):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(167, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Path (Has to start and end with \):"
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
        Me.GroupBox2.Location = New System.Drawing.Point(3, 121)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(306, 85)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "UserControls"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(195, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "File name format ({0} = language name):"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(167, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Path (Has to start and end with \):"
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
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(306, 118)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Translations"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(302, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "File name format ({0} = language name, {1} = ISO 639-1 code):"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Path (Has to start and end with \):"
        '
        'tp_file_structure
        '
        Me.tp_file_structure.BackColor = System.Drawing.SystemColors.Control
        Me.tp_file_structure.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tp_file_structure.Controls.Add(Me.GroupBox5)
        Me.tp_file_structure.Location = New System.Drawing.Point(4, 22)
        Me.tp_file_structure.Name = "tp_file_structure"
        Me.tp_file_structure.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_file_structure.Size = New System.Drawing.Size(316, 383)
        Me.tp_file_structure.TabIndex = 1
        Me.tp_file_structure.Text = "File Structure"
        '
        'GroupBox5
        '
        Me.GroupBox5.AutoSize = True
        Me.GroupBox5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox5.Controls.Add(Me.GroupBox6)
        Me.GroupBox5.Controls.Add(Me.tb_format_inclusion)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.tb_format_section)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(306, 187)
        Me.GroupBox5.TabIndex = 10
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Sections and Inclusions"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Section ({0} = section name):"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(172, 13)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Inclusion ({0} = included file name):"
        '
        'GroupBox6
        '
        Me.GroupBox6.AutoSize = True
        Me.GroupBox6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox6.Controls.Add(Me.cb_format_id_spaces)
        Me.GroupBox6.Controls.Add(Me.tb_format_id_translated)
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Controls.Add(Me.tb_format_id_empty)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(3, 82)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(300, 102)
        Me.GroupBox6.TabIndex = 11
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Translation IDs"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(199, 13)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Empty ID ({0} = ID name, {1} = example):"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(300, 13)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Translated ID ({0} = ID name, {1} = example, {2} = translation):"
        '
        'tb_ed_naming
        '
        Me.tb_ed_naming.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_ed_naming", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_ed_naming.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_ed_naming.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb_ed_naming.Location = New System.Drawing.Point(3, 62)
        Me.tb_ed_naming.Name = "tb_ed_naming"
        Me.tb_ed_naming.Size = New System.Drawing.Size(300, 20)
        Me.tb_ed_naming.TabIndex = 3
        Me.tb_ed_naming.Text = Global.EDDTT.My.MySettings.Default.lang_ed_naming
        '
        'tb_ed_path
        '
        Me.tb_ed_path.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_ed_path", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_ed_path.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_ed_path.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.tb_ed_path.Location = New System.Drawing.Point(3, 29)
        Me.tb_ed_path.Name = "tb_ed_path"
        Me.tb_ed_path.Size = New System.Drawing.Size(300, 20)
        Me.tb_ed_path.TabIndex = 1
        Me.tb_ed_path.Text = Global.EDDTT.My.MySettings.Default.lang_ed_path
        '
        'tb_je_naming
        '
        Me.tb_je_naming.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_je_naming", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_je_naming.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_je_naming.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb_je_naming.Location = New System.Drawing.Point(3, 62)
        Me.tb_je_naming.Name = "tb_je_naming"
        Me.tb_je_naming.Size = New System.Drawing.Size(300, 20)
        Me.tb_je_naming.TabIndex = 3
        Me.tb_je_naming.Text = Global.EDDTT.My.MySettings.Default.lang_je_naming
        '
        'tb_je_path
        '
        Me.tb_je_path.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_je_path", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_je_path.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_je_path.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.tb_je_path.Location = New System.Drawing.Point(3, 29)
        Me.tb_je_path.Name = "tb_je_path"
        Me.tb_je_path.Size = New System.Drawing.Size(300, 20)
        Me.tb_je_path.TabIndex = 1
        Me.tb_je_path.Text = Global.EDDTT.My.MySettings.Default.lang_je_path
        '
        'tb_uc_naming
        '
        Me.tb_uc_naming.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_uc_naming", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_uc_naming.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_uc_naming.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb_uc_naming.Location = New System.Drawing.Point(3, 62)
        Me.tb_uc_naming.Name = "tb_uc_naming"
        Me.tb_uc_naming.Size = New System.Drawing.Size(300, 20)
        Me.tb_uc_naming.TabIndex = 3
        Me.tb_uc_naming.Text = Global.EDDTT.My.MySettings.Default.lang_uc_naming
        '
        'tb_uc_path
        '
        Me.tb_uc_path.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_uc_path", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_uc_path.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_uc_path.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.tb_uc_path.Location = New System.Drawing.Point(3, 29)
        Me.tb_uc_path.Name = "tb_uc_path"
        Me.tb_uc_path.Size = New System.Drawing.Size(300, 20)
        Me.tb_uc_path.TabIndex = 1
        Me.tb_uc_path.Text = Global.EDDTT.My.MySettings.Default.lang_uc_path
        '
        'tb_exfile_name
        '
        Me.tb_exfile_name.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_exfile_name", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_exfile_name.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_exfile_name.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb_exfile_name.Location = New System.Drawing.Point(3, 95)
        Me.tb_exfile_name.Name = "tb_exfile_name"
        Me.tb_exfile_name.Size = New System.Drawing.Size(300, 20)
        Me.tb_exfile_name.TabIndex = 5
        Me.tb_exfile_name.Text = Global.EDDTT.My.MySettings.Default.lang_exfile_name
        '
        'tb_mainfile_naming
        '
        Me.tb_mainfile_naming.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_mainfile_naming", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_mainfile_naming.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_mainfile_naming.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb_mainfile_naming.Location = New System.Drawing.Point(3, 62)
        Me.tb_mainfile_naming.Name = "tb_mainfile_naming"
        Me.tb_mainfile_naming.Size = New System.Drawing.Size(300, 20)
        Me.tb_mainfile_naming.TabIndex = 3
        Me.tb_mainfile_naming.Text = Global.EDDTT.My.MySettings.Default.lang_mainfile_naming
        '
        'tb_mainfile_path
        '
        Me.tb_mainfile_path.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "lang_mainfile_path", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_mainfile_path.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_mainfile_path.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.tb_mainfile_path.Location = New System.Drawing.Point(3, 29)
        Me.tb_mainfile_path.Name = "tb_mainfile_path"
        Me.tb_mainfile_path.Size = New System.Drawing.Size(300, 20)
        Me.tb_mainfile_path.TabIndex = 1
        Me.tb_mainfile_path.Text = Global.EDDTT.My.MySettings.Default.lang_mainfile_path
        '
        'cb_format_id_spaces
        '
        Me.cb_format_id_spaces.AutoSize = True
        Me.cb_format_id_spaces.Checked = Global.EDDTT.My.MySettings.Default.format_id_spaces
        Me.cb_format_id_spaces.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.EDDTT.My.MySettings.Default, "format_id_spaces", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cb_format_id_spaces.Dock = System.Windows.Forms.DockStyle.Top
        Me.cb_format_id_spaces.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cb_format_id_spaces.Location = New System.Drawing.Point(3, 82)
        Me.cb_format_id_spaces.Name = "cb_format_id_spaces"
        Me.cb_format_id_spaces.Size = New System.Drawing.Size(294, 17)
        Me.cb_format_id_spaces.TabIndex = 11
        Me.cb_format_id_spaces.Text = "Spaces are important when loading"
        Me.cb_format_id_spaces.UseVisualStyleBackColor = True
        '
        'tb_format_id_translated
        '
        Me.tb_format_id_translated.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "format_id_translated", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_format_id_translated.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_format_id_translated.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.tb_format_id_translated.Location = New System.Drawing.Point(3, 62)
        Me.tb_format_id_translated.Name = "tb_format_id_translated"
        Me.tb_format_id_translated.Size = New System.Drawing.Size(294, 20)
        Me.tb_format_id_translated.TabIndex = 16
        Me.tb_format_id_translated.Text = Global.EDDTT.My.MySettings.Default.format_id_translated
        '
        'tb_format_id_empty
        '
        Me.tb_format_id_empty.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "format_id_empty", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_format_id_empty.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_format_id_empty.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.tb_format_id_empty.Location = New System.Drawing.Point(3, 29)
        Me.tb_format_id_empty.Name = "tb_format_id_empty"
        Me.tb_format_id_empty.Size = New System.Drawing.Size(294, 20)
        Me.tb_format_id_empty.TabIndex = 14
        Me.tb_format_id_empty.Text = Global.EDDTT.My.MySettings.Default.format_id_empty
        '
        'tb_format_inclusion
        '
        Me.tb_format_inclusion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "format_inclusion", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_format_inclusion.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_format_inclusion.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.tb_format_inclusion.Location = New System.Drawing.Point(3, 62)
        Me.tb_format_inclusion.Name = "tb_format_inclusion"
        Me.tb_format_inclusion.Size = New System.Drawing.Size(300, 20)
        Me.tb_format_inclusion.TabIndex = 9
        Me.tb_format_inclusion.Text = Global.EDDTT.My.MySettings.Default.format_inclusion
        '
        'tb_format_section
        '
        Me.tb_format_section.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EDDTT.My.MySettings.Default, "format_section", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_format_section.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_format_section.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.tb_format_section.Location = New System.Drawing.Point(3, 29)
        Me.tb_format_section.Name = "tb_format_section"
        Me.tb_format_section.Size = New System.Drawing.Size(300, 20)
        Me.tb_format_section.TabIndex = 3
        Me.tb_format_section.Text = Global.EDDTT.My.MySettings.Default.format_section
        '
        'FileDetectionSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 462)
        Me.Controls.Add(Me.tc_detection_settings)
        Me.Controls.Add(Me.OK_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FileDetectionSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "File Detection Settings"
        Me.tc_detection_settings.ResumeLayout(False)
        Me.tp_paths_and_naming.ResumeLayout(False)
        Me.tp_paths_and_naming.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tp_file_structure.ResumeLayout(False)
        Me.tp_file_structure.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As Button
    Friend WithEvents tc_detection_settings As TabControl
    Friend WithEvents tp_paths_and_naming As TabPage
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents tb_ed_naming As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tb_ed_path As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents tb_je_naming As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tb_je_path As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents tb_uc_naming As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tb_uc_path As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tb_exfile_name As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tb_mainfile_naming As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tb_mainfile_path As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tp_file_structure As TabPage
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents tb_format_inclusion As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents tb_format_section As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents tb_format_id_translated As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents tb_format_id_empty As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cb_format_id_spaces As CheckBox
End Class
