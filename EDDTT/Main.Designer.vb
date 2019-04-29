<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Formularz przesłania metodę dispose, aby wyczyścić listę składników.
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

    'Wymagane przez Projektanta formularzy systemu Windows
    Private components As System.ComponentModel.IContainer

    'UWAGA: następująca procedura jest wymagana przez Projektanta formularzy systemu Windows
    'Możesz to modyfikować, używając Projektanta formularzy systemu Windows. 
    'Nie należy modyfikować za pomocą edytora kodu.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ss_mainstatus = New System.Windows.Forms.StatusStrip()
        Me.pb_progress = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.l_file_encoding = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.l_status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ms_mainmenu = New System.Windows.Forms.MenuStrip()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cb_autoload = New System.Windows.Forms.ToolStripMenuItem()
        Me.cb_autocheck_repo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.b_path_settings = New System.Windows.Forms.ToolStripMenuItem()
        Me.b_reset_settings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.b_about = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EDDRepositoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.b_edd_repo_browse = New System.Windows.Forms.ToolStripMenuItem()
        Me.tb_edd_repo_dir = New System.Windows.Forms.ToolStripTextBox()
        Me.b_edd_repo_check = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.l_sel_lang = New System.Windows.Forms.ToolStripLabel()
        Me.cb_language = New System.Windows.Forms.ToolStripComboBox()
        Me.b_new_lang = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.b_auto_set_paths = New System.Windows.Forms.ToolStripMenuItem()
        Me.b_setpaths_mainfile = New System.Windows.Forms.ToolStripMenuItem()
        Me.b_setpaths_uc = New System.Windows.Forms.ToolStripMenuItem()
        Me.b_setpaths_je = New System.Windows.Forms.ToolStripMenuItem()
        Me.b_setpaths_ed = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilePathsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.tb_example_path = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.tb_translation_path = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.b_example_browse = New System.Windows.Forms.ToolStripMenuItem()
        Me.b_translation_browse = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.b_load_compare = New System.Windows.Forms.ToolStripMenuItem()
        Me.b_save_translation = New System.Windows.Forms.ToolStripMenuItem()
        Me.set_edd_repo = New System.Windows.Forms.FolderBrowserDialog()
        Me.tc_tables = New System.Windows.Forms.TabControl()
        Me.tp_translation = New System.Windows.Forms.TabPage()
        Me.dg_translation = New System.Windows.Forms.DataGridView()
        Me.c_tran_section = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_tran_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_tran_example = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_tran_translation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tran_search = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.tb_tran_search = New System.Windows.Forms.ToolStripTextBox()
        Me.b_tran_search = New System.Windows.Forms.ToolStripButton()
        Me.b_tran_search_reset = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.tran_viewoptions = New System.Windows.Forms.ToolStrip()
        Me.b_tran_viewoptions = New System.Windows.Forms.ToolStripDropDownButton()
        Me.cb_tran_hide_translated = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.cb_tran_wordwrap = New System.Windows.Forms.ToolStripMenuItem()
        Me.cb_tran_show_example = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cb_tran_sectorder = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.cb_tran_inclusions = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.l_tran_total_ids = New System.Windows.Forms.ToolStripLabel()
        Me.tp_diffs = New System.Windows.Forms.TabPage()
        Me.dg_diffs = New System.Windows.Forms.DataGridView()
        Me.c_diff_section = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_diff_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_diff_example = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_diff_translation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_diff_addedremoved = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.diffs_viewoptions = New System.Windows.Forms.ToolStrip()
        Me.b_diff_apply = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.b_diff_viewoptions = New System.Windows.Forms.ToolStripDropDownButton()
        Me.cb_diff_wordwrap = New System.Windows.Forms.ToolStripMenuItem()
        Me.cb_diff_ignore_removed = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.l_diff_total_ids = New System.Windows.Forms.ToolStripLabel()
        Me.tp_example = New System.Windows.Forms.TabPage()
        Me.dg_example = New System.Windows.Forms.DataGridView()
        Me.c_exmp_sect = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_exmp_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_exmp_example = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_exmp_translation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.exmp_viewoptions = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.cb_exmp_wordwrap = New System.Windows.Forms.ToolStripMenuItem()
        Me.cb_exmp_show_translation = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.cb_exmp_sectorder = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel()
        Me.cb_exmp_inclusions = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.l_exmp_total_ids = New System.Windows.Forms.ToolStripLabel()
        Me.edit_translation_inclusions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tr_incl_add = New System.Windows.Forms.ToolStripMenuItem()
        Me.tr_incl_edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tr_incl_remove = New System.Windows.Forms.ToolStripMenuItem()
        Me.ss_mainstatus.SuspendLayout()
        Me.ms_mainmenu.SuspendLayout()
        Me.tc_tables.SuspendLayout()
        Me.tp_translation.SuspendLayout()
        CType(Me.dg_translation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tran_search.SuspendLayout()
        Me.tran_viewoptions.SuspendLayout()
        Me.tp_diffs.SuspendLayout()
        CType(Me.dg_diffs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.diffs_viewoptions.SuspendLayout()
        Me.tp_example.SuspendLayout()
        CType(Me.dg_example, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.exmp_viewoptions.SuspendLayout()
        Me.edit_translation_inclusions.SuspendLayout()
        Me.SuspendLayout()
        '
        'ss_mainstatus
        '
        Me.ss_mainstatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pb_progress, Me.ToolStripSeparator13, Me.l_file_encoding, Me.ToolStripSeparator15, Me.l_status})
        Me.ss_mainstatus.Location = New System.Drawing.Point(0, 572)
        Me.ss_mainstatus.Name = "ss_mainstatus"
        Me.ss_mainstatus.Size = New System.Drawing.Size(1154, 23)
        Me.ss_mainstatus.TabIndex = 0
        Me.ss_mainstatus.Text = "Status"
        '
        'pb_progress
        '
        Me.pb_progress.Name = "pb_progress"
        Me.pb_progress.Size = New System.Drawing.Size(100, 17)
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 23)
        '
        'l_file_encoding
        '
        Me.l_file_encoding.Name = "l_file_encoding"
        Me.l_file_encoding.Size = New System.Drawing.Size(69, 18)
        Me.l_file_encoding.Text = "Not Loaded"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 23)
        '
        'l_status
        '
        Me.l_status.Name = "l_status"
        Me.l_status.Size = New System.Drawing.Size(39, 18)
        Me.l_status.Text = "Ready"
        '
        'ms_mainmenu
        '
        Me.ms_mainmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem, Me.ToolStripSeparator1, Me.EDDRepositoryToolStripMenuItem, Me.ToolStripSeparator2, Me.l_sel_lang, Me.cb_language, Me.b_new_lang, Me.ToolStripSeparator4, Me.b_auto_set_paths, Me.FilePathsToolStripMenuItem, Me.ToolStripSeparator3, Me.b_load_compare, Me.b_save_translation})
        Me.ms_mainmenu.Location = New System.Drawing.Point(0, 0)
        Me.ms_mainmenu.Name = "ms_mainmenu"
        Me.ms_mainmenu.Size = New System.Drawing.Size(1154, 27)
        Me.ms_mainmenu.TabIndex = 1
        Me.ms_mainmenu.Text = "Menu"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cb_autoload, Me.cb_autocheck_repo, Me.ToolStripSeparator6, Me.b_path_settings, Me.b_reset_settings, Me.ToolStripSeparator7, Me.b_about})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(54, 23)
        Me.SettingsToolStripMenuItem.Text = "EDDTT"
        '
        'cb_autoload
        '
        Me.cb_autoload.Checked = Global.EDDTT.My.MySettings.Default.auto_load_files
        Me.cb_autoload.CheckOnClick = True
        Me.cb_autoload.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_autoload.Name = "cb_autoload"
        Me.cb_autoload.Size = New System.Drawing.Size(274, 22)
        Me.cb_autoload.Text = "Load and Compare on Auto-Set Paths"
        '
        'cb_autocheck_repo
        '
        Me.cb_autocheck_repo.Checked = True
        Me.cb_autocheck_repo.CheckOnClick = True
        Me.cb_autocheck_repo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_autocheck_repo.Name = "cb_autocheck_repo"
        Me.cb_autocheck_repo.Size = New System.Drawing.Size(274, 22)
        Me.cb_autocheck_repo.Text = "Check EDD repository on startup"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(271, 6)
        '
        'b_path_settings
        '
        Me.b_path_settings.Name = "b_path_settings"
        Me.b_path_settings.Size = New System.Drawing.Size(274, 22)
        Me.b_path_settings.Text = "Path Settings"
        '
        'b_reset_settings
        '
        Me.b_reset_settings.Name = "b_reset_settings"
        Me.b_reset_settings.Size = New System.Drawing.Size(274, 22)
        Me.b_reset_settings.Text = "Reset All Settings to Defaults"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(271, 6)
        '
        'b_about
        '
        Me.b_about.Name = "b_about"
        Me.b_about.Size = New System.Drawing.Size(274, 22)
        Me.b_about.Text = "About"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'EDDRepositoryToolStripMenuItem
        '
        Me.EDDRepositoryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.b_edd_repo_browse, Me.tb_edd_repo_dir, Me.b_edd_repo_check})
        Me.EDDRepositoryToolStripMenuItem.Name = "EDDRepositoryToolStripMenuItem"
        Me.EDDRepositoryToolStripMenuItem.Size = New System.Drawing.Size(97, 23)
        Me.EDDRepositoryToolStripMenuItem.Text = "EDD repository"
        '
        'b_edd_repo_browse
        '
        Me.b_edd_repo_browse.Name = "b_edd_repo_browse"
        Me.b_edd_repo_browse.Size = New System.Drawing.Size(360, 22)
        Me.b_edd_repo_browse.Text = "Set EDD repository directory"
        '
        'tb_edd_repo_dir
        '
        Me.tb_edd_repo_dir.Name = "tb_edd_repo_dir"
        Me.tb_edd_repo_dir.ReadOnly = True
        Me.tb_edd_repo_dir.Size = New System.Drawing.Size(300, 23)
        Me.tb_edd_repo_dir.Text = Global.EDDTT.My.MySettings.Default.edd_repo_dir
        '
        'b_edd_repo_check
        '
        Me.b_edd_repo_check.Name = "b_edd_repo_check"
        Me.b_edd_repo_check.Size = New System.Drawing.Size(360, 22)
        Me.b_edd_repo_check.Text = "Re-Check"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'l_sel_lang
        '
        Me.l_sel_lang.Enabled = Global.EDDTT.My.MySettings.Default.edd_repo_set
        Me.l_sel_lang.Name = "l_sel_lang"
        Me.l_sel_lang.Size = New System.Drawing.Size(93, 20)
        Me.l_sel_lang.Text = "Select language:"
        '
        'cb_language
        '
        Me.cb_language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_language.Enabled = Global.EDDTT.My.MySettings.Default.edd_repo_set
        Me.cb_language.Name = "cb_language"
        Me.cb_language.Size = New System.Drawing.Size(121, 23)
        Me.cb_language.Sorted = True
        '
        'b_new_lang
        '
        Me.b_new_lang.Enabled = Global.EDDTT.My.MySettings.Default.edd_repo_set
        Me.b_new_lang.Name = "b_new_lang"
        Me.b_new_lang.Size = New System.Drawing.Size(98, 23)
        Me.b_new_lang.Text = "New Language"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'b_auto_set_paths
        '
        Me.b_auto_set_paths.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.b_setpaths_mainfile, Me.b_setpaths_uc, Me.b_setpaths_je, Me.b_setpaths_ed})
        Me.b_auto_set_paths.Enabled = Global.EDDTT.My.MySettings.Default.edd_repo_set
        Me.b_auto_set_paths.Name = "b_auto_set_paths"
        Me.b_auto_set_paths.Size = New System.Drawing.Size(98, 23)
        Me.b_auto_set_paths.Text = "Auto-Set Paths"
        '
        'b_setpaths_mainfile
        '
        Me.b_setpaths_mainfile.Name = "b_setpaths_mainfile"
        Me.b_setpaths_mainfile.Size = New System.Drawing.Size(180, 22)
        Me.b_setpaths_mainfile.Text = "tlf (Main File)"
        '
        'b_setpaths_uc
        '
        Me.b_setpaths_uc.Name = "b_setpaths_uc"
        Me.b_setpaths_uc.Size = New System.Drawing.Size(180, 22)
        Me.b_setpaths_uc.Text = "uc (User Controls)"
        '
        'b_setpaths_je
        '
        Me.b_setpaths_je.Name = "b_setpaths_je"
        Me.b_setpaths_je.Size = New System.Drawing.Size(180, 22)
        Me.b_setpaths_je.Text = "je (Journal Events)"
        '
        'b_setpaths_ed
        '
        Me.b_setpaths_ed.Name = "b_setpaths_ed"
        Me.b_setpaths_ed.Size = New System.Drawing.Size(180, 22)
        Me.b_setpaths_ed.Text = "ed (Elite Dangerous)"
        '
        'FilePathsToolStripMenuItem
        '
        Me.FilePathsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.tb_example_path, Me.ToolStripLabel3, Me.tb_translation_path, Me.ToolStripSeparator5, Me.b_example_browse, Me.b_translation_browse})
        Me.FilePathsToolStripMenuItem.Name = "FilePathsToolStripMenuItem"
        Me.FilePathsToolStripMenuItem.Size = New System.Drawing.Size(69, 23)
        Me.FilePathsToolStripMenuItem.Text = "File paths"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(100, 15)
        Me.ToolStripLabel2.Text = "Example file path:"
        '
        'tb_example_path
        '
        Me.tb_example_path.Name = "tb_example_path"
        Me.tb_example_path.ReadOnly = True
        Me.tb_example_path.Size = New System.Drawing.Size(335, 23)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(114, 15)
        Me.ToolStripLabel3.Text = "Translation file path:"
        '
        'tb_translation_path
        '
        Me.tb_translation_path.Name = "tb_translation_path"
        Me.tb_translation_path.ReadOnly = True
        Me.tb_translation_path.Size = New System.Drawing.Size(335, 23)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(392, 6)
        '
        'b_example_browse
        '
        Me.b_example_browse.Name = "b_example_browse"
        Me.b_example_browse.Size = New System.Drawing.Size(395, 22)
        Me.b_example_browse.Text = "Set example file path manually"
        '
        'b_translation_browse
        '
        Me.b_translation_browse.Name = "b_translation_browse"
        Me.b_translation_browse.Size = New System.Drawing.Size(395, 22)
        Me.b_translation_browse.Text = "Set translation file path manually"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'b_load_compare
        '
        Me.b_load_compare.Name = "b_load_compare"
        Me.b_load_compare.Size = New System.Drawing.Size(146, 23)
        Me.b_load_compare.Text = "Load and Compare Files"
        '
        'b_save_translation
        '
        Me.b_save_translation.Name = "b_save_translation"
        Me.b_save_translation.Size = New System.Drawing.Size(92, 23)
        Me.b_save_translation.Text = "Save Changes"
        '
        'set_edd_repo
        '
        Me.set_edd_repo.Description = "Select main EDDiscovery repository folder:"
        Me.set_edd_repo.RootFolder = System.Environment.SpecialFolder.MyComputer
        Me.set_edd_repo.SelectedPath = Global.EDDTT.My.MySettings.Default.edd_repo_dir
        Me.set_edd_repo.ShowNewFolderButton = False
        '
        'tc_tables
        '
        Me.tc_tables.Controls.Add(Me.tp_translation)
        Me.tc_tables.Controls.Add(Me.tp_diffs)
        Me.tc_tables.Controls.Add(Me.tp_example)
        Me.tc_tables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tc_tables.Location = New System.Drawing.Point(0, 27)
        Me.tc_tables.Name = "tc_tables"
        Me.tc_tables.SelectedIndex = 0
        Me.tc_tables.Size = New System.Drawing.Size(1154, 545)
        Me.tc_tables.TabIndex = 2
        '
        'tp_translation
        '
        Me.tp_translation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tp_translation.Controls.Add(Me.dg_translation)
        Me.tp_translation.Controls.Add(Me.tran_search)
        Me.tp_translation.Controls.Add(Me.tran_viewoptions)
        Me.tp_translation.Location = New System.Drawing.Point(4, 22)
        Me.tp_translation.Name = "tp_translation"
        Me.tp_translation.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_translation.Size = New System.Drawing.Size(1146, 519)
        Me.tp_translation.TabIndex = 1
        Me.tp_translation.Text = "Translation"
        Me.tp_translation.UseVisualStyleBackColor = True
        '
        'dg_translation
        '
        Me.dg_translation.AllowUserToAddRows = False
        Me.dg_translation.AllowUserToDeleteRows = False
        Me.dg_translation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg_translation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_translation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_translation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.c_tran_section, Me.c_tran_name, Me.c_tran_example, Me.c_tran_translation})
        Me.dg_translation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_translation.Location = New System.Drawing.Point(3, 53)
        Me.dg_translation.Name = "dg_translation"
        Me.dg_translation.RowHeadersVisible = False
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_translation.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dg_translation.Size = New System.Drawing.Size(1136, 459)
        Me.dg_translation.TabIndex = 6
        '
        'c_tran_section
        '
        Me.c_tran_section.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.c_tran_section.DataPropertyName = "section"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.c_tran_section.DefaultCellStyle = DataGridViewCellStyle1
        Me.c_tran_section.HeaderText = "Section"
        Me.c_tran_section.Name = "c_tran_section"
        Me.c_tran_section.ReadOnly = True
        Me.c_tran_section.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.c_tran_section.Width = 49
        '
        'c_tran_name
        '
        Me.c_tran_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.c_tran_name.DataPropertyName = "id"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.c_tran_name.DefaultCellStyle = DataGridViewCellStyle2
        Me.c_tran_name.HeaderText = "ID"
        Me.c_tran_name.Name = "c_tran_name"
        Me.c_tran_name.ReadOnly = True
        Me.c_tran_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'c_tran_example
        '
        Me.c_tran_example.DataPropertyName = "example"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.c_tran_example.DefaultCellStyle = DataGridViewCellStyle3
        Me.c_tran_example.HeaderText = "Example Text"
        Me.c_tran_example.Name = "c_tran_example"
        Me.c_tran_example.ReadOnly = True
        Me.c_tran_example.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'c_tran_translation
        '
        Me.c_tran_translation.DataPropertyName = "translation"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.c_tran_translation.DefaultCellStyle = DataGridViewCellStyle4
        Me.c_tran_translation.HeaderText = "Translation Text (editable)"
        Me.c_tran_translation.Name = "c_tran_translation"
        Me.c_tran_translation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'tran_search
        '
        Me.tran_search.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel4, Me.tb_tran_search, Me.b_tran_search, Me.b_tran_search_reset, Me.ToolStripButton5, Me.ToolStripButton6})
        Me.tran_search.Location = New System.Drawing.Point(3, 28)
        Me.tran_search.Name = "tran_search"
        Me.tran_search.Size = New System.Drawing.Size(1136, 25)
        Me.tran_search.TabIndex = 9
        Me.tran_search.Text = "Search"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(45, 22)
        Me.ToolStripLabel4.Text = "Search:"
        '
        'tb_tran_search
        '
        Me.tb_tran_search.Name = "tb_tran_search"
        Me.tb_tran_search.Size = New System.Drawing.Size(630, 25)
        '
        'b_tran_search
        '
        Me.b_tran_search.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.b_tran_search.Image = CType(resources.GetObject("b_tran_search.Image"), System.Drawing.Image)
        Me.b_tran_search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.b_tran_search.Name = "b_tran_search"
        Me.b_tran_search.Size = New System.Drawing.Size(46, 22)
        Me.b_tran_search.Text = "Search"
        '
        'b_tran_search_reset
        '
        Me.b_tran_search_reset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.b_tran_search_reset.Image = CType(resources.GetObject("b_tran_search_reset.Image"), System.Drawing.Image)
        Me.b_tran_search_reset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.b_tran_search_reset.Name = "b_tran_search_reset"
        Me.b_tran_search_reset.Size = New System.Drawing.Size(39, 22)
        Me.b_tran_search_reset.Text = "Reset"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButton5.Text = "Previous"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripButton6.Text = "Next"
        '
        'tran_viewoptions
        '
        Me.tran_viewoptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.b_tran_viewoptions, Me.ToolStripSeparator11, Me.ToolStripLabel1, Me.cb_tran_sectorder, Me.ToolStripSeparator12, Me.ToolStripLabel5, Me.cb_tran_inclusions, Me.ToolStripSeparator14, Me.l_tran_total_ids})
        Me.tran_viewoptions.Location = New System.Drawing.Point(3, 3)
        Me.tran_viewoptions.Name = "tran_viewoptions"
        Me.tran_viewoptions.Size = New System.Drawing.Size(1136, 25)
        Me.tran_viewoptions.TabIndex = 1
        Me.tran_viewoptions.Text = "View Options"
        '
        'b_tran_viewoptions
        '
        Me.b_tran_viewoptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.b_tran_viewoptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cb_tran_hide_translated, Me.ToolStripSeparator9, Me.cb_tran_wordwrap, Me.cb_tran_show_example})
        Me.b_tran_viewoptions.Image = CType(resources.GetObject("b_tran_viewoptions.Image"), System.Drawing.Image)
        Me.b_tran_viewoptions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.b_tran_viewoptions.Name = "b_tran_viewoptions"
        Me.b_tran_viewoptions.Size = New System.Drawing.Size(88, 22)
        Me.b_tran_viewoptions.Text = "View options"
        '
        'cb_tran_hide_translated
        '
        Me.cb_tran_hide_translated.CheckOnClick = True
        Me.cb_tran_hide_translated.Name = "cb_tran_hide_translated"
        Me.cb_tran_hide_translated.Size = New System.Drawing.Size(167, 22)
        Me.cb_tran_hide_translated.Text = "Hide Translated"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(164, 6)
        '
        'cb_tran_wordwrap
        '
        Me.cb_tran_wordwrap.CheckOnClick = True
        Me.cb_tran_wordwrap.Name = "cb_tran_wordwrap"
        Me.cb_tran_wordwrap.Size = New System.Drawing.Size(167, 22)
        Me.cb_tran_wordwrap.Text = "Wrap Text in Cells"
        '
        'cb_tran_show_example
        '
        Me.cb_tran_show_example.Checked = True
        Me.cb_tran_show_example.CheckOnClick = True
        Me.cb_tran_show_example.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_tran_show_example.Name = "cb_tran_show_example"
        Me.cb_tran_show_example.Size = New System.Drawing.Size(167, 22)
        Me.cb_tran_show_example.Text = "Show Example"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripLabel1.Text = "Section order:"
        '
        'cb_tran_sectorder
        '
        Me.cb_tran_sectorder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_tran_sectorder.Name = "cb_tran_sectorder"
        Me.cb_tran_sectorder.Size = New System.Drawing.Size(250, 25)
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripLabel5.Text = "Inclusions:"
        '
        'cb_tran_inclusions
        '
        Me.cb_tran_inclusions.Name = "cb_tran_inclusions"
        Me.cb_tran_inclusions.Size = New System.Drawing.Size(250, 25)
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 25)
        '
        'l_tran_total_ids
        '
        Me.l_tran_total_ids.Name = "l_tran_total_ids"
        Me.l_tran_total_ids.Size = New System.Drawing.Size(64, 22)
        Me.l_tran_total_ids.Text = "Total IDs: 0"
        '
        'tp_diffs
        '
        Me.tp_diffs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tp_diffs.Controls.Add(Me.dg_diffs)
        Me.tp_diffs.Controls.Add(Me.diffs_viewoptions)
        Me.tp_diffs.Location = New System.Drawing.Point(4, 22)
        Me.tp_diffs.Name = "tp_diffs"
        Me.tp_diffs.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_diffs.Size = New System.Drawing.Size(1146, 519)
        Me.tp_diffs.TabIndex = 0
        Me.tp_diffs.Text = "Differences"
        Me.tp_diffs.UseVisualStyleBackColor = True
        '
        'dg_diffs
        '
        Me.dg_diffs.AllowUserToAddRows = False
        Me.dg_diffs.AllowUserToDeleteRows = False
        Me.dg_diffs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg_diffs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_diffs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_diffs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.c_diff_section, Me.c_diff_name, Me.c_diff_example, Me.c_diff_translation, Me.c_diff_addedremoved})
        Me.dg_diffs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_diffs.Location = New System.Drawing.Point(3, 28)
        Me.dg_diffs.Name = "dg_diffs"
        Me.dg_diffs.RowHeadersVisible = False
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_diffs.RowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dg_diffs.Size = New System.Drawing.Size(1136, 484)
        Me.dg_diffs.TabIndex = 5
        '
        'c_diff_section
        '
        Me.c_diff_section.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.c_diff_section.DefaultCellStyle = DataGridViewCellStyle6
        Me.c_diff_section.HeaderText = "Section"
        Me.c_diff_section.Name = "c_diff_section"
        Me.c_diff_section.ReadOnly = True
        Me.c_diff_section.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.c_diff_section.Width = 49
        '
        'c_diff_name
        '
        Me.c_diff_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.c_diff_name.DefaultCellStyle = DataGridViewCellStyle7
        Me.c_diff_name.HeaderText = "ID"
        Me.c_diff_name.Name = "c_diff_name"
        Me.c_diff_name.ReadOnly = True
        Me.c_diff_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'c_diff_example
        '
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.c_diff_example.DefaultCellStyle = DataGridViewCellStyle8
        Me.c_diff_example.HeaderText = "Example Text"
        Me.c_diff_example.Name = "c_diff_example"
        Me.c_diff_example.ReadOnly = True
        Me.c_diff_example.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'c_diff_translation
        '
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.c_diff_translation.DefaultCellStyle = DataGridViewCellStyle9
        Me.c_diff_translation.HeaderText = "Translation Text (editable)"
        Me.c_diff_translation.Name = "c_diff_translation"
        Me.c_diff_translation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'c_diff_addedremoved
        '
        Me.c_diff_addedremoved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.c_diff_addedremoved.DefaultCellStyle = DataGridViewCellStyle10
        Me.c_diff_addedremoved.HeaderText = "Added/Removed"
        Me.c_diff_addedremoved.Name = "c_diff_addedremoved"
        Me.c_diff_addedremoved.ReadOnly = True
        Me.c_diff_addedremoved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.c_diff_addedremoved.Width = 95
        '
        'diffs_viewoptions
        '
        Me.diffs_viewoptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.b_diff_apply, Me.ToolStripSeparator8, Me.b_diff_viewoptions, Me.ToolStripSeparator10, Me.l_diff_total_ids})
        Me.diffs_viewoptions.Location = New System.Drawing.Point(3, 3)
        Me.diffs_viewoptions.Name = "diffs_viewoptions"
        Me.diffs_viewoptions.Size = New System.Drawing.Size(1136, 25)
        Me.diffs_viewoptions.TabIndex = 0
        Me.diffs_viewoptions.Text = "View Options"
        '
        'b_diff_apply
        '
        Me.b_diff_apply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.b_diff_apply.Image = CType(resources.GetObject("b_diff_apply.Image"), System.Drawing.Image)
        Me.b_diff_apply.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.b_diff_apply.Name = "b_diff_apply"
        Me.b_diff_apply.Size = New System.Drawing.Size(179, 22)
        Me.b_diff_apply.Text = "Apply Differences to Translation"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'b_diff_viewoptions
        '
        Me.b_diff_viewoptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.b_diff_viewoptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cb_diff_wordwrap, Me.cb_diff_ignore_removed})
        Me.b_diff_viewoptions.Image = CType(resources.GetObject("b_diff_viewoptions.Image"), System.Drawing.Image)
        Me.b_diff_viewoptions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.b_diff_viewoptions.Name = "b_diff_viewoptions"
        Me.b_diff_viewoptions.Size = New System.Drawing.Size(88, 22)
        Me.b_diff_viewoptions.Text = "View options"
        '
        'cb_diff_wordwrap
        '
        Me.cb_diff_wordwrap.CheckOnClick = True
        Me.cb_diff_wordwrap.Name = "cb_diff_wordwrap"
        Me.cb_diff_wordwrap.Size = New System.Drawing.Size(167, 22)
        Me.cb_diff_wordwrap.Text = "Wrap Text in Cells"
        '
        'cb_diff_ignore_removed
        '
        Me.cb_diff_ignore_removed.CheckOnClick = True
        Me.cb_diff_ignore_removed.Name = "cb_diff_ignore_removed"
        Me.cb_diff_ignore_removed.Size = New System.Drawing.Size(167, 22)
        Me.cb_diff_ignore_removed.Text = "Ignore Removed"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'l_diff_total_ids
        '
        Me.l_diff_total_ids.Name = "l_diff_total_ids"
        Me.l_diff_total_ids.Size = New System.Drawing.Size(64, 22)
        Me.l_diff_total_ids.Text = "Total IDs: 0"
        '
        'tp_example
        '
        Me.tp_example.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tp_example.Controls.Add(Me.dg_example)
        Me.tp_example.Controls.Add(Me.exmp_viewoptions)
        Me.tp_example.Location = New System.Drawing.Point(4, 22)
        Me.tp_example.Name = "tp_example"
        Me.tp_example.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_example.Size = New System.Drawing.Size(1146, 519)
        Me.tp_example.TabIndex = 2
        Me.tp_example.Text = "Example"
        Me.tp_example.UseVisualStyleBackColor = True
        '
        'dg_example
        '
        Me.dg_example.AllowUserToAddRows = False
        Me.dg_example.AllowUserToDeleteRows = False
        Me.dg_example.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg_example.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_example.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_example.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.c_exmp_sect, Me.c_exmp_name, Me.c_exmp_example, Me.c_exmp_translation})
        Me.dg_example.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_example.Location = New System.Drawing.Point(3, 28)
        Me.dg_example.Name = "dg_example"
        Me.dg_example.ReadOnly = True
        Me.dg_example.RowHeadersVisible = False
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_example.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.dg_example.Size = New System.Drawing.Size(1136, 484)
        Me.dg_example.TabIndex = 9
        '
        'c_exmp_sect
        '
        Me.c_exmp_sect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.c_exmp_sect.DefaultCellStyle = DataGridViewCellStyle12
        Me.c_exmp_sect.HeaderText = "Section"
        Me.c_exmp_sect.Name = "c_exmp_sect"
        Me.c_exmp_sect.ReadOnly = True
        Me.c_exmp_sect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.c_exmp_sect.Width = 49
        '
        'c_exmp_name
        '
        Me.c_exmp_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.c_exmp_name.DefaultCellStyle = DataGridViewCellStyle13
        Me.c_exmp_name.HeaderText = "ID"
        Me.c_exmp_name.Name = "c_exmp_name"
        Me.c_exmp_name.ReadOnly = True
        Me.c_exmp_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'c_exmp_example
        '
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.c_exmp_example.DefaultCellStyle = DataGridViewCellStyle14
        Me.c_exmp_example.HeaderText = "Example Text"
        Me.c_exmp_example.Name = "c_exmp_example"
        Me.c_exmp_example.ReadOnly = True
        Me.c_exmp_example.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'c_exmp_translation
        '
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.c_exmp_translation.DefaultCellStyle = DataGridViewCellStyle15
        Me.c_exmp_translation.HeaderText = "Translation Text"
        Me.c_exmp_translation.Name = "c_exmp_translation"
        Me.c_exmp_translation.ReadOnly = True
        Me.c_exmp_translation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'exmp_viewoptions
        '
        Me.exmp_viewoptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripSeparator17, Me.ToolStripLabel6, Me.cb_exmp_sectorder, Me.ToolStripSeparator18, Me.ToolStripLabel7, Me.cb_exmp_inclusions, Me.ToolStripSeparator19, Me.l_exmp_total_ids})
        Me.exmp_viewoptions.Location = New System.Drawing.Point(3, 3)
        Me.exmp_viewoptions.Name = "exmp_viewoptions"
        Me.exmp_viewoptions.Size = New System.Drawing.Size(1136, 25)
        Me.exmp_viewoptions.TabIndex = 2
        Me.exmp_viewoptions.Text = "View Options"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cb_exmp_wordwrap, Me.cb_exmp_show_translation})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(88, 22)
        Me.ToolStripDropDownButton1.Text = "View options"
        '
        'cb_exmp_wordwrap
        '
        Me.cb_exmp_wordwrap.CheckOnClick = True
        Me.cb_exmp_wordwrap.Name = "cb_exmp_wordwrap"
        Me.cb_exmp_wordwrap.Size = New System.Drawing.Size(167, 22)
        Me.cb_exmp_wordwrap.Text = "Wrap Text in Cells"
        '
        'cb_exmp_show_translation
        '
        Me.cb_exmp_show_translation.CheckOnClick = True
        Me.cb_exmp_show_translation.Name = "cb_exmp_show_translation"
        Me.cb_exmp_show_translation.Size = New System.Drawing.Size(167, 22)
        Me.cb_exmp_show_translation.Text = "Show Translation"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripLabel6.Text = "Section order:"
        '
        'cb_exmp_sectorder
        '
        Me.cb_exmp_sectorder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_exmp_sectorder.Name = "cb_exmp_sectorder"
        Me.cb_exmp_sectorder.Size = New System.Drawing.Size(250, 25)
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripLabel7.Text = "Inclusions:"
        '
        'cb_exmp_inclusions
        '
        Me.cb_exmp_inclusions.Name = "cb_exmp_inclusions"
        Me.cb_exmp_inclusions.Size = New System.Drawing.Size(250, 25)
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(6, 25)
        '
        'l_exmp_total_ids
        '
        Me.l_exmp_total_ids.Name = "l_exmp_total_ids"
        Me.l_exmp_total_ids.Size = New System.Drawing.Size(64, 22)
        Me.l_exmp_total_ids.Text = "Total IDs: 0"
        '
        'edit_translation_inclusions
        '
        Me.edit_translation_inclusions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tr_incl_add, Me.tr_incl_edit, Me.tr_incl_remove})
        Me.edit_translation_inclusions.Name = "edit_translation_includes"
        Me.edit_translation_inclusions.Size = New System.Drawing.Size(118, 70)
        '
        'tr_incl_add
        '
        Me.tr_incl_add.Name = "tr_incl_add"
        Me.tr_incl_add.Size = New System.Drawing.Size(117, 22)
        Me.tr_incl_add.Text = "Add"
        '
        'tr_incl_edit
        '
        Me.tr_incl_edit.Name = "tr_incl_edit"
        Me.tr_incl_edit.Size = New System.Drawing.Size(117, 22)
        Me.tr_incl_edit.Text = "Edit"
        '
        'tr_incl_remove
        '
        Me.tr_incl_remove.Name = "tr_incl_remove"
        Me.tr_incl_remove.Size = New System.Drawing.Size(117, 22)
        Me.tr_incl_remove.Text = "Remove"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1154, 595)
        Me.Controls.Add(Me.tc_tables)
        Me.Controls.Add(Me.ss_mainstatus)
        Me.Controls.Add(Me.ms_mainmenu)
        Me.MainMenuStrip = Me.ms_mainmenu
        Me.MinimumSize = New System.Drawing.Size(1170, 634)
        Me.Name = "Main"
        Me.Text = "MainForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ss_mainstatus.ResumeLayout(False)
        Me.ss_mainstatus.PerformLayout()
        Me.ms_mainmenu.ResumeLayout(False)
        Me.ms_mainmenu.PerformLayout()
        Me.tc_tables.ResumeLayout(False)
        Me.tp_translation.ResumeLayout(False)
        Me.tp_translation.PerformLayout()
        CType(Me.dg_translation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tran_search.ResumeLayout(False)
        Me.tran_search.PerformLayout()
        Me.tran_viewoptions.ResumeLayout(False)
        Me.tran_viewoptions.PerformLayout()
        Me.tp_diffs.ResumeLayout(False)
        Me.tp_diffs.PerformLayout()
        CType(Me.dg_diffs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.diffs_viewoptions.ResumeLayout(False)
        Me.diffs_viewoptions.PerformLayout()
        Me.tp_example.ResumeLayout(False)
        Me.tp_example.PerformLayout()
        CType(Me.dg_example, System.ComponentModel.ISupportInitialize).EndInit()
        Me.exmp_viewoptions.ResumeLayout(False)
        Me.exmp_viewoptions.PerformLayout()
        Me.edit_translation_inclusions.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ss_mainstatus As StatusStrip
    Friend WithEvents ms_mainmenu As MenuStrip
    Friend WithEvents pb_progress As ToolStripProgressBar
    Friend WithEvents l_status As ToolStripStatusLabel
    Friend WithEvents EDDRepositoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents b_edd_repo_browse As ToolStripMenuItem
    Friend WithEvents tb_edd_repo_dir As ToolStripTextBox
    Friend WithEvents FilePathsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents b_example_browse As ToolStripMenuItem
    Friend WithEvents tb_example_path As ToolStripTextBox
    Friend WithEvents b_translation_browse As ToolStripMenuItem
    Friend WithEvents tb_translation_path As ToolStripTextBox
    Friend WithEvents cb_language As ToolStripComboBox
    Friend WithEvents l_sel_lang As ToolStripLabel
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents b_auto_set_paths As ToolStripMenuItem
    Friend WithEvents b_setpaths_mainfile As ToolStripMenuItem
    Friend WithEvents b_setpaths_uc As ToolStripMenuItem
    Friend WithEvents b_setpaths_je As ToolStripMenuItem
    Friend WithEvents b_setpaths_ed As ToolStripMenuItem
    Friend WithEvents b_new_lang As ToolStripMenuItem
    Friend WithEvents set_edd_repo As FolderBrowserDialog
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents b_path_settings As ToolStripMenuItem
    Friend WithEvents b_edd_repo_check As ToolStripMenuItem
    Friend WithEvents b_reset_settings As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tc_tables As TabControl
    Friend WithEvents tp_diffs As TabPage
    Friend WithEvents tp_translation As TabPage
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents b_load_compare As ToolStripMenuItem
    Friend WithEvents b_save_translation As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents b_about As ToolStripMenuItem
    Friend WithEvents diffs_viewoptions As ToolStrip
    Friend WithEvents b_diff_apply As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents tran_viewoptions As ToolStrip
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents l_diff_total_ids As ToolStripLabel
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents l_tran_total_ids As ToolStripLabel
    Friend WithEvents cb_tran_sectorder As ToolStripComboBox
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
    Friend WithEvents ToolStripSeparator14 As ToolStripSeparator
    Friend WithEvents cb_tran_inclusions As ToolStripComboBox
    Friend WithEvents dg_translation As DataGridView
    Friend WithEvents b_diff_viewoptions As ToolStripDropDownButton
    Friend WithEvents cb_diff_wordwrap As ToolStripMenuItem
    Friend WithEvents cb_diff_ignore_removed As ToolStripMenuItem
    Friend WithEvents b_tran_viewoptions As ToolStripDropDownButton
    Friend WithEvents cb_tran_hide_translated As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents cb_tran_wordwrap As ToolStripMenuItem
    Friend WithEvents cb_tran_show_example As ToolStripMenuItem
    Friend WithEvents dg_diffs As DataGridView
    Friend WithEvents c_diff_section As DataGridViewTextBoxColumn
    Friend WithEvents c_diff_name As DataGridViewTextBoxColumn
    Friend WithEvents c_diff_example As DataGridViewTextBoxColumn
    Friend WithEvents c_diff_translation As DataGridViewTextBoxColumn
    Friend WithEvents c_diff_addedremoved As DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
    Friend WithEvents l_file_encoding As ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator15 As ToolStripSeparator
    Friend WithEvents tp_example As TabPage
    Friend WithEvents dg_example As DataGridView
    Friend WithEvents exmp_viewoptions As ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents cb_exmp_wordwrap As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator17 As ToolStripSeparator
    Friend WithEvents ToolStripLabel6 As ToolStripLabel
    Friend WithEvents cb_exmp_sectorder As ToolStripComboBox
    Friend WithEvents ToolStripSeparator18 As ToolStripSeparator
    Friend WithEvents ToolStripLabel7 As ToolStripLabel
    Friend WithEvents cb_exmp_inclusions As ToolStripComboBox
    Friend WithEvents ToolStripSeparator19 As ToolStripSeparator
    Friend WithEvents l_exmp_total_ids As ToolStripLabel
    Friend WithEvents c_tran_section As DataGridViewTextBoxColumn
    Friend WithEvents c_tran_name As DataGridViewTextBoxColumn
    Friend WithEvents c_tran_example As DataGridViewTextBoxColumn
    Friend WithEvents c_tran_translation As DataGridViewTextBoxColumn
    Friend WithEvents c_exmp_sect As DataGridViewTextBoxColumn
    Friend WithEvents c_exmp_name As DataGridViewTextBoxColumn
    Friend WithEvents c_exmp_example As DataGridViewTextBoxColumn
    Friend WithEvents c_exmp_translation As DataGridViewTextBoxColumn
    Friend WithEvents cb_autoload As ToolStripMenuItem
    Friend WithEvents cb_autocheck_repo As ToolStripMenuItem
    Friend WithEvents tran_search As ToolStrip
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents tb_tran_search As ToolStripTextBox
    Friend WithEvents b_tran_search As ToolStripButton
    Friend WithEvents b_tran_search_reset As ToolStripButton
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripButton6 As ToolStripButton
    Friend WithEvents cb_exmp_show_translation As ToolStripMenuItem
    Friend WithEvents edit_translation_inclusions As ContextMenuStrip
    Friend WithEvents tr_incl_add As ToolStripMenuItem
    Friend WithEvents tr_incl_edit As ToolStripMenuItem
    Friend WithEvents tr_incl_remove As ToolStripMenuItem
End Class
