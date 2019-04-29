Imports System.IO
Imports System.Text

Public Class Main


    Private Const problematic As String = "\" & Chr(34)
    Private Const replacement As String = "╬"

    Dim file_encoding As Encoding = Nothing


#Region "Setting EDD Repository"

    'Set EDD repository
    Private Sub Set_edd_repo_location(sender As Object, e As EventArgs) Handles b_edd_repo_browse.Click
        With My.Settings
            .edd_repo_set = False
            Dim temp_edd_repo_dir As String = .edd_repo_dir
            If set_edd_repo.ShowDialog() = DialogResult.OK Then
                .edd_repo_dir = set_edd_repo.SelectedPath
            Else
                .edd_repo_dir = temp_edd_repo_dir
            End If
        End With
        Refresh_settings()
        Check_edd_repo()
    End Sub

    'Manually re-check EDD repository
    Private Sub Manually_check_edd_repo(sender As Object, e As EventArgs) Handles b_edd_repo_check.Click
        Check_edd_repo()
        Refresh_settings()
    End Sub

    'Check if EDD repository has compatible structure
    Private Function Check_edd_repo() As Boolean

        With My.Settings

            Dim missing_subdirectories As String = Nothing
            For Each subdir As String In { .lang_mainfile_path, .lang_uc_path, .lang_je_path, .lang_ed_path}
                If Not Directory.Exists(.edd_repo_dir & subdir) Then
                    missing_subdirectories += subdir & Environment.NewLine
                End If
            Next
            If Not String.IsNullOrWhiteSpace(missing_subdirectories) Then
                MsgBox("The following subdirectories are not present in the repository directory:" & Environment.NewLine & missing_subdirectories &
                       Environment.NewLine & "Please choose a correct EDDiscovery repository directory or check the Path Settings.", MsgBoxStyle.Exclamation, "Missing Translation Subdirectories")
                .edd_repo_set = False
                Refresh_settings()
                Return False
            End If

            Dim missing_example_files As String = Nothing
            For Each filepath As String In Filepaths_main_uc_je_ed(.lang_exfile_name)
                If Not File.Exists(.edd_repo_dir & filepath) Then
                    missing_example_files += filepath & Environment.NewLine
                End If
            Next
            If Not String.IsNullOrWhiteSpace(missing_example_files) Then
                MsgBox("The following example files are not present in the repository:" & Environment.NewLine & missing_example_files &
                       Environment.NewLine & "Please choose a correct EDDiscovery repository directory or check the Path Settings.", MsgBoxStyle.Exclamation, "Missing Example Files")
                .edd_repo_set = False
                Refresh_settings()
                Return False
            End If

            .edd_repo_set = True

        End With

        Refresh_settings()
        Detect_languages()
        Return True

    End Function

#End Region


#Region "File path auto-detection"

    'Auto-Set Paths
    Private Sub Auto_detect_paths(sender As Object, e As EventArgs) Handles b_setpaths_mainfile.Click, b_setpaths_uc.Click, b_setpaths_je.Click, b_setpaths_ed.Click

        Dim mainfile_ext As String = My.Settings.lang_mainfile_naming.Substring(My.Settings.lang_mainfile_naming.IndexOf("."))
        Dim mainfile_name As String = cb_language.Text & mainfile_ext
        Dim translation_paths_list As List(Of String) = Filepaths_main_uc_je_ed(mainfile_name)
        Dim example_paths_list As List(Of String) = Filepaths_main_uc_je_ed(My.Settings.lang_exfile_name)

        Dim file_type_index As Integer = 0
        Select Case True
            Case sender Is b_setpaths_mainfile
                file_type_index = 0
            Case sender Is b_setpaths_uc
                file_type_index = 1
            Case sender Is b_setpaths_je
                file_type_index = 2
            Case sender Is b_setpaths_ed
                file_type_index = 3
        End Select

        tb_example_path.Text = My.Settings.edd_repo_dir & example_paths_list(file_type_index)
        tb_translation_path.Text = My.Settings.edd_repo_dir & translation_paths_list(file_type_index)

        If My.Settings.auto_load_files Then
            Load_files()
        End If

    End Sub

    'Detect languages
    Private Function Detect_languages() As Boolean

        With My.Settings

            cb_language.Items.Clear()
            Dim mainfile_dir As New DirectoryInfo(.edd_repo_dir & .lang_mainfile_path)
            If mainfile_dir.Exists Then
                For Each file In mainfile_dir.GetFiles()
                    If file IsNot Nothing AndAlso file.ToString() Like .lang_mainfile_naming AndAlso Not file.ToString.ToLower.Contains(.lang_exfile_name.ToLower) Then
                        cb_language.Items.Add(file.Name.Substring(0, file.Name.IndexOf(".")))
                    End If
                Next
            End If

            If cb_language.Items.Count > 0 Then
                If cb_language.Items.Contains(My.Settings.last_language) Then
                    cb_language.SelectedIndex = cb_language.Items.IndexOf(My.Settings.last_language)
                Else
                    cb_language.SelectedIndex = 0
                End If
                Return True
            Else
                Return False
            End If

        End With

        Return False
    End Function

    'Generate file paths list for language
    Private Function Filepaths_main_uc_je_ed(main_file_name As String) As List(Of String)

        Dim lang_short_start As Integer = My.Settings.lang_mainfile_naming.IndexOf("*")
        Dim lang_short As String = main_file_name.Substring(lang_short_start, main_file_name.IndexOf(My.Settings.lang_mainfile_naming(lang_short_start + 1)))

        Dim files_list As New List(Of String) From {
            My.Settings.lang_mainfile_path & main_file_name,
            My.Settings.lang_uc_path & Insert_at(My.Settings.lang_uc_naming, lang_short, "*"),
            My.Settings.lang_je_path & Insert_at(My.Settings.lang_je_naming, lang_short, "*"),
            My.Settings.lang_ed_path & Insert_at(My.Settings.lang_ed_naming, lang_short, "*")
        }

        Return files_list

    End Function

#End Region


#Region "Loading Files"

    'Manual load
    Private Sub b_load_compare_Click(sender As Object, e As EventArgs) Handles b_load_compare.Click
        Load_files()
    End Sub

    'Loading function
    Private Sub Load_files()

        'Reading example file
        If String.IsNullOrWhiteSpace(tb_example_path.Text) Then
            MsgBox("Example file path cannot be empty.", MsgBoxStyle.Exclamation, "Cannot Load")
            l_status.Text = "Cannot Load - example file path is empty"
            Exit Sub
        ElseIf Not Directory.Exists(Path.GetDirectoryName(tb_example_path.Text)) Then
            MsgBox("Example file directory does not exist." & Environment.NewLine & "Change repository directory or Path Settings.",
                   MsgBoxStyle.Exclamation, "Cannot Load")
            l_status.Text = "Cannot Load - example file directory does not exist"
            Exit Sub
        ElseIf Not File.Exists(tb_example_path.Text) Then
            MsgBox("Example file does not exist in this directory. Check if it has been removed or its name changed." &
                   Environment.NewLine & "If its name has been changed, change its name or name format in Path Settings accordingly.",
                   MsgBoxStyle.Exclamation, "Cannot Load")
            l_status.Text = "Cannot Load - example file does not exist"
            Exit Sub
        End If
        Dim example_reader As New StreamReader(tb_example_path.Text, True)
        Dim example As String
        Try
            example = example_reader.ReadToEnd()
        Catch ex As Exception
            MsgBox("Failed to load example file " & Path.GetFileName(tb_example_path.Text) & ":" & Environment.NewLine &
                   Environment.NewLine & ex.Message, MsgBoxStyle.Critical, "Loading Error")
            l_status.Text = "Failed to load " & Path.GetFileName(tb_example_path.Text)
            example_reader.Close()
            Exit Sub
        End Try
        example_reader.Close()

        'Reading translation file
        If String.IsNullOrWhiteSpace(tb_translation_path.Text) Then
            MsgBox("Translation File path cannot be empty.", MsgBoxStyle.Exclamation, "Cannot Load")
            l_status.Text = "Cannot Load - translation file path is empty"
            l_file_encoding.Text = "Not Loaded"
            Exit Sub
        ElseIf Not Directory.Exists(Path.GetDirectoryName(tb_translation_path.Text)) Then
            MsgBox("Translation file directory does not exist." & Environment.NewLine & "Change repository directory or Path Settings.",
                   MsgBoxStyle.Exclamation, "Cannot Load")
            l_status.Text = "Cannot Load - translation file directory does not exist"
            Exit Sub
        ElseIf Not File.Exists(tb_translation_path.Text) Then
            MsgBox("Translation file does not exist in this directory. Check if it has been removed or its name changed." &
                   Environment.NewLine & "If its name has been changed, change its name format in Path Settings accordingly.",
                   MsgBoxStyle.Exclamation, "Cannot Load")
            l_status.Text = "Cannot Load - translation file does not exist"
            l_file_encoding.Text = "Not Loaded"
            Exit Sub
        End If
        Dim translation_reader As New StreamReader(tb_translation_path.Text, True)
        Dim translation As String
        Try
            file_encoding = translation_reader.CurrentEncoding
            translation = translation_reader.ReadToEnd()
        Catch ex As Exception
            MsgBox("Failed to load translation file " & Path.GetFileName(tb_translation_path.Text) & ":" & Environment.NewLine &
                   Environment.NewLine & ex.Message, MsgBoxStyle.Critical, "Loading Error")
            l_status.Text = "Failed to load " & Path.GetFileName(tb_translation_path.Text)
            l_file_encoding.Text = "Not Loaded"
            translation_reader.Close()
            Exit Sub
        End Try
        translation_reader.Close()

        'Display Encoding
        If file_encoding IsNot Nothing Then
            l_file_encoding.Text = file_encoding.EncodingName
        Else
            l_file_encoding.Text = "Not Loaded"
        End If

        'Converting file content to DataGridViews
        Dim example_id_count As Integer = File_contents_to_grid(example, dg_example, cb_exmp_sectorder, cb_exmp_inclusions)
        Dim translation_id_count As Integer = File_contents_to_grid(translation, dg_translation, cb_tran_sectorder, cb_tran_inclusions)
        l_status.Text = "Loaded " & example_id_count & " IDs from " & Path.GetFileName(tb_example_path.Text) & " and " &
            translation_id_count & " IDs from " & Path.GetFileName(tb_translation_path.Text) & "."

        'Finding added/removed IDs
        dg_diffs.Rows.Clear()
        Dim added_count As Integer = Find_diffs(dg_example, dg_translation, dg_diffs, "Added")
        Dim removed_count As Integer = 0
        If My.Settings.diff_ignore_removed = False Then
            removed_count = Find_diffs(dg_translation, dg_example, dg_diffs, "Removed")
        End If

        If added_count = 0 And removed_count = 0 Then
            l_status.Text += " No differences found."
            tc_tables.SelectedIndex = 0
        ElseIf added_count > 0 And removed_count = 0 Then
            l_status.Text += " Found " & added_count & " added IDs."
            tc_tables.SelectedIndex = 1
        ElseIf added_count = 0 And removed_count > 0 Then
            l_status.Text += " Found " & removed_count & " removed IDs."
            tc_tables.SelectedIndex = 1
        ElseIf added_count > 0 And removed_count > 0 Then
            l_status.Text += " Found " & added_count & " added IDs and " & removed_count & " removed IDs."
            tc_tables.SelectedIndex = 1
        End If

        'Update_id_counters()
        Translation_hide_show_rows()

    End Sub

    'Process file contents into data for DataGridViews
    Private Function File_contents_to_grid(file_content As String, dg As DataGridView, sectorder As ToolStripComboBox, inclusions As ToolStripComboBox)

        Dim array() As String = Split(file_content, Environment.NewLine)
        dg.Rows.Clear()
        sectorder.Items.Clear()
        inclusions.Items.Clear()

        Dim found_count As Integer = 0

        pb_progress.Value = 0
        pb_progress.Maximum = array.Length - 1

        For line_index = 0 To array.Length - 1

            Dim line As String = array(line_index)

            'Changing \" to ╬ (changes are later reverted)
            If line.Contains(problematic) Then
                line = line.Replace(problematic, replacement)
            End If

            If (line Like "*: " & Chr(34) & "*" & Chr(34) & " *" OrElse line Like "*:" & Chr(34) & "*" & Chr(34) & " *") And Not line Like "//*" Then

                Dim line_sect As String = Nothing
                Dim line_name As String = Nothing
                Dim line_exmp As String = Nothing
                Dim line_trns As String = Nothing

                For sect_index As Integer = line_index To 0 Step -1
                    Dim sect_line As String = array(sect_index)
                    If sect_line Like "SECTION *" Then
                        line_sect = sect_line.Substring(8)
                        If Not sectorder.Items.Contains(line_sect) Then
                            sectorder.Items.Add(line_sect)
                        End If
                        Exit For
                    End If
                Next

                line_name = line.Substring(0, line.IndexOf(":"))

                line_exmp = line.Substring(line.IndexOf(Chr(34)) + 1)
                line_exmp = line_exmp.Substring(0, line_exmp.IndexOf(Chr(34)))

                If (line Like "*: " & Chr(34) & "*" & Chr(34) & " => " & Chr(34) & "*" & Chr(34) _
                    OrElse line Like "*:" & Chr(34) & "*" & Chr(34) & " => " & Chr(34) & "*" & Chr(34)) And Not line Like "* @" Then
                    line_trns = line.Substring(line.IndexOf(" => " & Chr(34)) + 5)
                    line_trns = line_trns.Substring(0, line_trns.IndexOf(Chr(34)))
                End If

                If Not String.IsNullOrWhiteSpace(line_sect) AndAlso line_sect.Contains(replacement) Then
                    line_sect = line_sect.Replace(replacement, problematic)
                End If
                If Not String.IsNullOrWhiteSpace(line_name) AndAlso line_name.Contains(replacement) Then
                    line_name = line_name.Replace(replacement, problematic)
                End If
                If Not String.IsNullOrWhiteSpace(line_exmp) AndAlso line_exmp.Contains(replacement) Then
                    line_exmp = line_exmp.Replace(replacement, problematic)
                End If
                If Not String.IsNullOrWhiteSpace(line_trns) AndAlso line_trns.Contains(replacement) Then
                    line_trns = line_trns.Replace(replacement, problematic)
                End If

                dg.Rows.Add(line_sect, line_name, line_exmp, line_trns)
                found_count += 1

            ElseIf line Like "include *" Then

                Dim line_inclusion As String = line.Substring(8)
                If Not inclusions.Items.Contains(line_inclusion) Then
                    inclusions.Items.Add(line_inclusion)
                End If

            End If

            pb_progress.Value = line_index

        Next

        If sectorder.Items.Count > 0 Then
            sectorder.SelectedIndex = 0
        Else
            sectorder.Text = String.Empty
        End If
        If inclusions.Items.Count > 0 Then
            inclusions.SelectedIndex = 0
        Else
            inclusions.Text = String.Empty
        End If

        Return found_count

    End Function

    'Find differences and add to differences table
    Private Function Find_diffs(dg_from As DataGridView, dg_to As DataGridView, dg_diff As DataGridView, difftype As String)

        Dim style_green As New DataGridViewCellStyle With {.BackColor = Color.LightGreen}
        Dim style_red As New DataGridViewCellStyle With {.BackColor = Color.Salmon}
        Dim style_gray As New DataGridViewCellStyle With {.BackColor = Color.LightGray}

        Dim diff_count As Integer = 0

        For Each row_from As DataGridViewRow In dg_from.Rows

            Dim from_sect As String = row_from.Cells(0).Value
            Dim from_name As String = row_from.Cells(1).Value

            Dim diff_found As Boolean = True
            Dim entire_sect_diff_found As Boolean = True

            For Each row_to As DataGridViewRow In dg_to.Rows
                Dim to_sect As String = row_to.Cells(0).Value
                Dim to_name As String = row_to.Cells(1).Value

                If to_sect = from_sect And to_name = from_name Then
                    entire_sect_diff_found = False
                    diff_found = False
                    Exit For
                ElseIf to_sect = from_sect Then
                    entire_sect_diff_found = False
                End If

            Next

            If diff_found Then

                dg_diff.Rows.Add(row_from.Cells(0).Value, row_from.Cells(1).Value, row_from.Cells(2).Value, row_from.Cells(3).Value, difftype)
                If entire_sect_diff_found Then
                    dg_diff.Rows(dg_diff.Rows.GetLastRow(0)).Cells(0).Style = style_gray
                End If
                If difftype = "Added" Then
                    dg_diff.Rows(dg_diff.Rows.GetLastRow(0)).Cells(4).Style = style_green
                ElseIf difftype = "Removed" Then
                    dg_diff.Rows(dg_diff.Rows.GetLastRow(0)).Cells(4).Style = style_red
                End If

                diff_count += 1

            End If

        Next

        Return diff_count

    End Function

#End Region


#Region "Apply Differences to Translation"

    'Apply differences
    'TODO Something probably in here caused a section to be split in two. Needs to be diagnosed and fixed.
    Private Sub Apply_diffs(sender As Object, e As EventArgs) Handles b_diff_apply.Click
        If dg_diffs.Rows.Count > 0 Then

            pb_progress.Value = 0
            pb_progress.Maximum = dg_diffs.Rows.Count

            Dim added_id_count As Integer = 0
            Dim removed_id_count As Integer = 0

            Dim style_gray As New DataGridViewCellStyle With {.BackColor = Color.LightGray}

            'Apply Added - in separate loops so removing does not interfere with section adding
            For Each diff_row As DataGridViewRow In dg_diffs.Rows
                If diff_row.Cells(4).Value = "Added" Then

                    Dim diff_row_section As String = diff_row.Cells(0).Value

                    If String.IsNullOrWhiteSpace(diff_row_section) Then

                        'When new ID isn't in a section:
                        For file_row_index As Integer = 0 To dg_translation.Rows.Count - 1
                            Dim current_file_row_section As String = dg_translation.Rows(file_row_index).Cells(0).Value
                            Dim previous_file_row_section As String = current_file_row_section
                            If file_row_index > 0 Then
                                previous_file_row_section = dg_translation.Rows(file_row_index - 1).Cells(0).Value
                            End If
                            If file_row_index = dg_translation.Rows.Count - 1 And String.IsNullOrWhiteSpace(current_file_row_section) Then
                                dg_translation.Rows.Add(diff_row.Cells(0).Value, diff_row.Cells(1).Value, diff_row.Cells(2).Value, diff_row.Cells(3).Value)
                                For Each cell As DataGridViewCell In dg_translation.Rows(dg_translation.Rows.GetLastRow(0)).Cells
                                    cell.Style = style_gray
                                Next
                                added_id_count += 1
                                Exit For
                            ElseIf (file_row_index = 0 Or String.IsNullOrWhiteSpace(previous_file_row_section)) And Not String.IsNullOrWhiteSpace(current_file_row_section) Then
                                dg_translation.Rows.Insert(file_row_index, diff_row.Cells(0).Value, diff_row.Cells(1).Value, diff_row.Cells(2).Value, diff_row.Cells(3).Value)
                                For Each cell As DataGridViewCell In dg_translation.Rows(file_row_index).Cells
                                    cell.Style = style_gray
                                Next
                                added_id_count += 1
                                Exit For
                            End If
                        Next

                    ElseIf cb_tran_sectorder.Items.Contains(diff_row_section) Then

                        'When new ID is in a section and that section exists in Translation:
                        For file_row_index As Integer = 0 To dg_translation.Rows.Count - 1
                            Dim current_file_row_section As String = dg_translation.Rows(file_row_index).Cells(0).Value
                            Dim previous_file_row_section As String = current_file_row_section
                            If file_row_index > 0 Then
                                previous_file_row_section = dg_translation.Rows(file_row_index - 1).Cells(0).Value
                            End If
                            If file_row_index = dg_translation.Rows.Count - 1 And current_file_row_section = diff_row_section Then
                                dg_translation.Rows.Add(diff_row.Cells(0).Value, diff_row.Cells(1).Value, diff_row.Cells(2).Value, diff_row.Cells(3).Value)
                                For Each cell As DataGridViewCell In dg_translation.Rows(dg_translation.Rows.GetLastRow(0)).Cells
                                    cell.Style = style_gray
                                Next
                                added_id_count += 1
                                Exit For
                            ElseIf previous_file_row_section = diff_row_section And current_file_row_section <> diff_row_section Then
                                dg_translation.Rows.Insert(file_row_index, diff_row.Cells(0).Value, diff_row.Cells(1).Value, diff_row.Cells(2).Value, diff_row.Cells(3).Value)
                                For Each cell As DataGridViewCell In dg_translation.Rows(file_row_index).Cells
                                    cell.Style = style_gray
                                Next
                                added_id_count += 1
                                Exit For
                            End If
                        Next

                    Else

                        'When new ID is in a section and that section doesn't exist in Translation:
                        Dim index_inorder As Integer = cb_exmp_sectorder.Items.IndexOf(diff_row_section)

                        If index_inorder = 0 Then
                            cb_tran_sectorder.Items.Insert(0, diff_row_section)
                        ElseIf index_inorder > 0 And index_inorder < cb_exmp_sectorder.Items.Count - 1 Then
                            Dim previous_section As String = cb_exmp_sectorder.Items(cb_exmp_sectorder.Items.IndexOf(diff_row_section) - 1).ToString()
                            cb_tran_sectorder.Items.Insert(cb_tran_sectorder.Items.IndexOf(previous_section) + 1, diff_row_section)
                        ElseIf index_inorder = cb_exmp_sectorder.Items.Count - 1 Then
                            cb_tran_sectorder.Items.Add(diff_row_section)
                        End If

                        Dim section_order_index As Integer = cb_tran_sectorder.Items.IndexOf(diff_row_section)

                        If section_order_index = 0 Then

                            For file_row_index As Integer = 0 To dg_translation.Rows.Count - 1
                                Dim current_file_row_section As String = dg_translation.Rows(file_row_index).Cells(0).Value
                                Dim previous_file_row_section As String = current_file_row_section
                                If file_row_index > 0 Then
                                    previous_file_row_section = dg_translation.Rows(file_row_index - 1).Cells(0).Value
                                End If
                                If Not String.IsNullOrWhiteSpace(current_file_row_section) Then
                                    dg_translation.Rows.Insert(file_row_index, diff_row.Cells(0).Value, diff_row.Cells(1).Value, diff_row.Cells(2).Value, diff_row.Cells(3).Value)
                                    For Each cell As DataGridViewCell In dg_translation.Rows(file_row_index).Cells
                                        cell.Style = style_gray
                                    Next
                                    added_id_count += 1
                                    Exit For
                                ElseIf file_row_index = dg_translation.Rows.Count - 1 Then
                                    dg_translation.Rows.Add(diff_row.Cells(0).Value, diff_row.Cells(1).Value, diff_row.Cells(2).Value, diff_row.Cells(3).Value)
                                    For Each cell As DataGridViewCell In dg_translation.Rows(dg_translation.Rows.GetLastRow(0)).Cells
                                        cell.Style = style_gray
                                    Next
                                    added_id_count += 1
                                    Exit For
                                End If
                            Next

                        ElseIf section_order_index > 0 And section_order_index < cb_tran_sectorder.Items.Count - 1 Then

                            Dim previous_section_in_order As String = cb_tran_sectorder.Items(section_order_index - 1).ToString()

                            For file_row_index As Integer = 0 To dg_translation.Rows.Count - 1
                                Dim current_file_row_section As String = dg_translation.Rows(file_row_index).Cells(0).Value
                                Dim previous_file_row_section As String = current_file_row_section
                                If file_row_index > 0 Then
                                    previous_file_row_section = dg_translation.Rows(file_row_index - 1).Cells(0).Value
                                End If
                                If previous_file_row_section = previous_section_in_order And current_file_row_section <> previous_section_in_order Then
                                    dg_translation.Rows.Insert(file_row_index, diff_row.Cells(0).Value, diff_row.Cells(1).Value, diff_row.Cells(2).Value, diff_row.Cells(3).Value)
                                    For Each cell As DataGridViewCell In dg_translation.Rows(file_row_index).Cells
                                        cell.Style = style_gray
                                    Next
                                    added_id_count += 1
                                    Exit For
                                End If
                            Next

                        ElseIf section_order_index = cb_tran_sectorder.Items.Count - 1 Then

                            dg_translation.Rows.Add(diff_row.Cells(0).Value, diff_row.Cells(1).Value, diff_row.Cells(2).Value, diff_row.Cells(3).Value)
                            For Each cell As DataGridViewCell In dg_translation.Rows(dg_translation.Rows.GetLastRow(0)).Cells
                                cell.Style = style_gray
                            Next
                            added_id_count += 1

                        End If

                    End If

                    pb_progress.Value += 1

                End If
            Next

            'Apply Removed - in separate loops so removing does not interfere with section adding
            For Each diff_row As DataGridViewRow In dg_diffs.Rows
                If diff_row.Cells(4).Value = "Removed" Then

                    If My.Settings.diff_ignore_removed = False Then

                        Dim diff_section As String = diff_row.Cells(0).Value
                        Dim diff_name As String = diff_row.Cells(1).Value

                        'Removing rows
                        For Each translation_row As DataGridViewRow In dg_translation.Rows

                            Dim tran_section As String = translation_row.Cells(0).Value
                            Dim tran_name As String = translation_row.Cells(1).Value

                            If diff_section = tran_section And diff_name = tran_name Then

                                dg_translation.Rows.Remove(translation_row)
                                removed_id_count += 1

                            End If

                        Next

                        'Removing sections from translation section order if they aren't present in example
                        If Not String.IsNullOrWhiteSpace(diff_section) AndAlso
                            (cb_tran_sectorder.Items.Contains(diff_section) And Not cb_exmp_sectorder.Items.Contains(diff_section)) Then

                            cb_tran_sectorder.Items.Remove(diff_section)

                        End If

                    End If

                    pb_progress.Value += 1

                End If
            Next

            dg_diffs.Rows.Clear()

            l_status.Text = "Added " & added_id_count & " IDs."

            If removed_id_count > 0 Then
                l_status.Text += " Removed " & removed_id_count & " IDs."
            End If

            'Update_id_counters()
            Translation_hide_show_rows()

        Else

            MsgBox("No differences found, nothing to apply.", MsgBoxStyle.Exclamation, "No Differences Found")

        End If
    End Sub
#End Region


#Region "Table Filtering"

    'Search
    Private Sub Update_search_filter(sender As Object, e As EventArgs) Handles b_tran_search.Click, b_tran_search_reset.Click

        If sender Is b_tran_search_reset Then
            tb_tran_search.Text = String.Empty
        End If

        Translation_hide_show_rows()

    End Sub

    'Hide or show all IDs in translation depending on "Hide Translated" and "Search" options
    Private Sub Translation_hide_show_rows()
        If dg_translation.Rows.Count > 0 Then
            Dim dg_util As New RowFilteringOptimization(dg_translation)
            dg_util.Start()
            pb_progress.Value = 0
            pb_progress.Maximum = dg_translation.Rows.Count
            For Each row As DataGridViewRow In dg_translation.Rows
                Dim match As Boolean = String.IsNullOrWhiteSpace(tb_tran_search.Text)
                If Not match Then
                    For Each cell As DataGridViewCell In row.Cells
                        If Not String.IsNullOrWhiteSpace(cell.Value) AndAlso cell.Value Like "*" & tb_tran_search.Text & "*" Then
                            match = True
                            Exit For
                        End If
                    Next
                End If
                row.Visible = (String.IsNullOrWhiteSpace(row.Cells(3).Value) OrElse Not My.Settings.tran_hide_translated) AndAlso match
                pb_progress.Value += 1
            Next
            dg_util.Finish()
        End If
    End Sub

#End Region


#Region "Adding/Editing/Removing Inclusions"
    'Add new inclusion
    Private Sub Tr_incl_add_Click(sender As Object, e As EventArgs) Handles tr_incl_add.Click
        Dim new_inclusion As String = InputBox("File name:", "New Inclusion")
        If Not String.IsNullOrWhiteSpace(new_inclusion) Then
            cb_tran_inclusions.Items.Add(new_inclusion)
        End If
    End Sub

    'Edit inclusion
    Private Sub Tr_incl_edit_Click(sender As Object, e As EventArgs) Handles tr_incl_edit.Click
        If cb_tran_inclusions.SelectedItem IsNot Nothing Then
            Dim selected_index As Integer = cb_tran_inclusions.SelectedIndex
            Dim selected_inclusion As String = cb_tran_inclusions.Items(selected_index)
            Dim edited_inclusion As String = InputBox("File name:", "Edit Inclusion", selected_inclusion)
            If Not String.IsNullOrWhiteSpace(edited_inclusion) Then
                cb_tran_inclusions.Items(selected_index) = edited_inclusion
            End If
        Else
            MsgBox("Select an inclusion first.", MsgBoxStyle.Information, "Edit Inclusion")
        End If
    End Sub

    'Remove selected inclusion
    Private Sub tr_incl_remove_Click(sender As Object, e As EventArgs) Handles tr_incl_remove.Click
        If cb_tran_inclusions.SelectedItem IsNot Nothing Then
            If MsgBox("Are you sure that you want to remove the " & cb_tran_inclusions.SelectedItem.ToString() & " inclusion?",
                      MsgBoxStyle.OkCancel, "Remove Inclusion") = MsgBoxResult.Ok Then
                cb_tran_inclusions.Items.Remove(cb_tran_inclusions.SelectedItem)
            End If
        Else
            MsgBox("Select an inclusion first.", MsgBoxStyle.Information, "Remove Inclusion")
        End If
    End Sub
#End Region


#Region "Save translation file"

    Private Sub Save_translation(sender As Object, e As EventArgs) Handles b_save_translation.Click
        If dg_translation.Rows.Count > 0 Then

            'Checking path and encoding
            If String.IsNullOrWhiteSpace(tb_translation_path.Text) Then
                MsgBox("Translation File path cannot be empty." & Environment.NewLine & "(it shouldn't be possible for this error to appear - please report an issue)", MsgBoxStyle.Exclamation, "Cannot Save")
                l_status.Text = "Saving Failed - translation file path is empty"
                Exit Sub
            ElseIf Not Directory.Exists(Path.GetDirectoryName(tb_translation_path.Text)) Then
                Dim msg As String = "Translation file directory does not exist or has been changed." & Environment.NewLine
                msg += "Please do not change any of the following directories between loading and saving files with this program:" & Environment.NewLine & Environment.NewLine
                msg += My.Settings.edd_repo_dir & My.Settings.lang_mainfile_path & Environment.NewLine
                msg += My.Settings.edd_repo_dir & My.Settings.lang_uc_path & Environment.NewLine
                msg += My.Settings.edd_repo_dir & My.Settings.lang_je_path & Environment.NewLine
                msg += My.Settings.edd_repo_dir & My.Settings.lang_ed_path
                MsgBox(msg, MsgBoxStyle.Exclamation, "Cannot Save")
                l_status.Text = "Saving Failed - file path changed after loading file"
                Exit Sub
            ElseIf file_encoding Is Nothing Then
                MsgBox("File encoding has not been detected properly." & Environment.NewLine & "(it shouldn't be possible for this error to appear - please report an issue)", MsgBoxStyle.Exclamation, "Cannot Save")
                l_status.Text = "Saving Failed - file encoding not detected"
                Exit Sub
            End If

            'Preparations
            pb_progress.Value = 0
            pb_progress.Maximum = dg_translation.Rows.Count

            'Creating list of strings from Translation rows
            Dim file_list As New List(Of String)
            Dim previous_section As String = Nothing
            For Each row As DataGridViewRow In dg_translation.Rows
                If String.IsNullOrWhiteSpace(row.Cells(0).Value) OrElse row.Cells(0).Value = previous_section Then
                    If String.IsNullOrWhiteSpace(row.Cells(3).Value) Then
                        file_list.Add(row.Cells(1).Value & ": " & Chr(34) & row.Cells(2).Value & Chr(34) & " @")
                    Else
                        file_list.Add(row.Cells(1).Value & ": " & Chr(34) & row.Cells(2).Value & Chr(34) & " => " & Chr(34) & row.Cells(3).Value & Chr(34))
                    End If
                Else
                    previous_section = row.Cells(0).Value
                    file_list.Add(String.Empty)
                    file_list.Add("SECTION " & row.Cells(0).Value)
                    file_list.Add(String.Empty)
                    If String.IsNullOrWhiteSpace(row.Cells(3).Value) Then
                        file_list.Add(row.Cells(1).Value & ": " & Chr(34) & row.Cells(2).Value & Chr(34) & " @")
                    Else
                        file_list.Add(row.Cells(1).Value & ": " & Chr(34) & row.Cells(2).Value & Chr(34) & " => " & Chr(34) & row.Cells(3).Value & Chr(34))
                    End If
                End If
                pb_progress.Value += 1
            Next

            file_list.Add(String.Empty)

            'Adding inclusions
            If cb_tran_inclusions.Items.Count > 0 Then
                For Each item As String In cb_tran_inclusions.Items
                    file_list.Add("include " & item)
                    file_list.Add(String.Empty)
                Next
            End If

            'Converting the list of lines into single string
            Dim file_array() As String = file_list.ToArray()
            Dim file_text As String = Join(file_array, Environment.NewLine)

            'Checking path again just to be sure
            If Not Directory.Exists(Path.GetDirectoryName(tb_translation_path.Text)) Then
                Dim msg As String = "Translation file directory does not exist or has been changed." & Environment.NewLine
                msg += "Please do not change any of the following directories while saving files with this program:" &
                    Environment.NewLine & Environment.NewLine
                msg += My.Settings.edd_repo_dir & My.Settings.lang_mainfile_path & Environment.NewLine
                msg += My.Settings.edd_repo_dir & My.Settings.lang_uc_path & Environment.NewLine
                msg += My.Settings.edd_repo_dir & My.Settings.lang_je_path & Environment.NewLine
                msg += My.Settings.edd_repo_dir & My.Settings.lang_ed_path
                MsgBox(msg, MsgBoxStyle.Exclamation, "Cannot Save")
                l_status.Text = "Saving Failed - file path changed while saving"
                Exit Sub
            End If

            'Saving to file
            Dim file_writer As New StreamWriter(tb_translation_path.Text, False, file_encoding)
            Try
                pb_progress.Value = 0
                pb_progress.Maximum = file_text.Length
                For Each chr As Char In file_text
                    file_writer.Write(chr)
                    pb_progress.Value += 1
                Next
            Catch ex As Exception
                MsgBox("Failed to save translation file " & Path.GetFileName(tb_translation_path.Text) & ":" & Environment.NewLine &
                       Environment.NewLine & ex.Message, MsgBoxStyle.Critical, "Saving Error")
                l_status.Text = "Failed to save " & Path.GetFileName(tb_translation_path.Text)
                file_writer.Close()
                Exit Sub
            End Try
            file_writer.Close()

            l_status.Text = "Successfully saved " & Path.GetFileName(tb_translation_path.Text)

        Else
            MsgBox("File has not been loaded. Nothing to save.", MsgBoxStyle.Exclamation, "Cannot Save")
        End If

    End Sub

#End Region


#Region "Utility Functions"

    'Update table ID counters
    Private Sub Update_table_id_counters(sender As Object, e As EventArgs) Handles dg_translation.RowsAdded, dg_translation.RowsRemoved,
    dg_example.RowsAdded, dg_example.RowsRemoved, dg_diffs.RowsAdded, dg_diffs.RowsRemoved

        Dim id_counter_text As String = String.Format("Total IDs: {0}", sender.Rows.Count)
        Select Case True
            Case sender Is dg_translation
                l_tran_total_ids.Text = id_counter_text
            Case sender Is dg_example
                l_exmp_total_ids.Text = id_counter_text
            Case sender Is dg_diffs
                l_diff_total_ids.Text = id_counter_text
        End Select

    End Sub
    'Private Sub Update_id_counters()
    '    l_diff_total_ids.Text = String.Format("Total IDs: {0}", dg_diffs.Rows.Count)
    '    l_tran_total_ids.Text = String.Format("Total IDs: {0}", dg_translation.Rows.Count)
    '    l_exmp_total_ids.Text = String.Format("Total IDs: {0}", dg_example.Rows.Count)
    'End Sub

    'Insert word into string at char
    Private Function Insert_at(str As String, word As String, chr As Char) As String

        If str.Contains(chr) Then

            Dim output As String = str.Substring(0, str.IndexOf(chr)) & word
            output += str.Substring(str.IndexOf(chr) + 1, str.Length - (str.IndexOf(chr) + 1))
            Return output

        Else

            Return str

        End If

    End Function

    'Clear everything when file paths change
    Private Sub clear_output_on_file_path_change(sender As Object, e As EventArgs) Handles tb_translation_path.TextChanged, tb_example_path.TextChanged
        dg_example.Rows.Clear()
        cb_exmp_inclusions.Items.Clear()
        cb_exmp_sectorder.Items.Clear()

        dg_translation.Rows.Clear()
        cb_tran_inclusions.Items.Clear()
        cb_tran_sectorder.Items.Clear()

        dg_diffs.Rows.Clear()
    End Sub

#End Region


#Region "Settings"

    'Update last used language
    Private Sub Change_language(sender As Object, e As EventArgs) Handles cb_language.SelectedIndexChanged
        If Not String.IsNullOrWhiteSpace(cb_language.Text) Then
            My.Settings.last_language = cb_language.Text
        End If
    End Sub

    'Update settings from unbindable controls
    Private Sub Update_auto_load(sender As Object, e As EventArgs) Handles cb_autoload.Click
        My.Settings.auto_load_files = cb_autoload.Checked
    End Sub
    Private Sub Update_tran_hide_translated(sender As Object, e As EventArgs) Handles cb_tran_hide_translated.Click
        My.Settings.tran_hide_translated = cb_tran_hide_translated.Checked
        Translation_hide_show_rows()
    End Sub
    Private Sub Update_tran_wordwrap(sender As Object, e As EventArgs) Handles cb_tran_wordwrap.Click
        My.Settings.tran_wordwrap = cb_tran_wordwrap.Checked
        Refresh_settings()
    End Sub
    Private Sub Update_tran_show_example(sender As Object, e As EventArgs) Handles cb_tran_show_example.Click
        My.Settings.tran_show_example = cb_tran_show_example.Checked
        Refresh_settings()
    End Sub
    Private Sub Update_diff_wordwrap(sender As Object, e As EventArgs) Handles cb_diff_wordwrap.Click
        My.Settings.diff_wordwrap = cb_diff_wordwrap.Checked
        Refresh_settings()
    End Sub
    Private Sub Update_diff_ignore_removed(sender As Object, e As EventArgs) Handles cb_diff_ignore_removed.Click
        My.Settings.diff_ignore_removed = cb_diff_ignore_removed.Checked
    End Sub
    Private Sub Update_exmp_wordwrap(sender As Object, e As EventArgs) Handles cb_exmp_wordwrap.Click
        My.Settings.exmp_wordwrap = cb_exmp_wordwrap.Checked
        Refresh_settings()
    End Sub
    Private Sub Update_exmp_show_translation(sender As Object, e As EventArgs) Handles cb_exmp_show_translation.Click
        My.Settings.exmp_show_translation = cb_exmp_show_translation.Checked
        Refresh_settings()
    End Sub
    Private Sub Update_auto_check_edd_repo(sender As Object, e As EventArgs) Handles cb_autocheck_repo.Click
        My.Settings.auto_check_edd_repo = cb_autocheck_repo.Checked
    End Sub

    'Refresh settings in unbindable controls
    Private Sub Refresh_settings()
        With My.Settings
            tb_edd_repo_dir.Text = .edd_repo_dir
            set_edd_repo.SelectedPath = .edd_repo_dir
            l_sel_lang.Enabled = .edd_repo_set
            cb_language.Enabled = .edd_repo_set
            b_new_lang.Enabled = .edd_repo_set
            b_auto_set_paths.Enabled = .edd_repo_set
            cb_autoload.Checked = .auto_load_files
            cb_tran_hide_translated.Checked = .tran_hide_translated
            cb_tran_wordwrap.Checked = .tran_wordwrap
            cb_tran_show_example.Checked = .tran_show_example
            cb_diff_wordwrap.Checked = .diff_wordwrap
            cb_diff_ignore_removed.Checked = .diff_ignore_removed
            cb_autocheck_repo.Checked = .auto_check_edd_repo

            If My.Settings.diff_wordwrap Then
                dg_diffs.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            Else
                dg_diffs.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False
            End If

            If My.Settings.tran_wordwrap Then
                dg_translation.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            Else
                dg_translation.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False
            End If
            c_tran_example.Visible = My.Settings.tran_show_example

            If My.Settings.exmp_wordwrap Then
                dg_example.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            Else
                dg_example.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False
            End If
            c_exmp_translation.Visible = My.Settings.exmp_show_translation

        End With
    End Sub

    'Open path settings dialog
    Private Sub Open_path_settings(sender As Object, e As EventArgs) Handles b_path_settings.Click
        PathSettings.ShowDialog()
    End Sub

    'Reset all settings to default
    Private Sub Reset_all_settings(sender As Object, e As EventArgs) Handles b_reset_settings.Click
        If MsgBox("Are you sure that you want to reset all settings to defaults?", MsgBoxStyle.OkCancel, "Reset Settings") = MsgBoxResult.Ok Then
            My.Settings.Reset()
            Refresh_settings()
        End If
    End Sub

#End Region


#Region "Opening and Closing"

    'Actions to do when program opens
    Private Sub On_open(sender As Object, e As EventArgs) Handles MyBase.Load
        cb_tran_inclusions.ComboBox.ContextMenuStrip = edit_translation_inclusions
        Refresh_settings()
        If My.Settings.auto_check_edd_repo AndAlso Not String.IsNullOrWhiteSpace(My.Settings.edd_repo_dir) Then
            Check_edd_repo()
        Else
            Detect_languages()
        End If
    End Sub

    'Actions to do when program closes
    Private Sub On_close(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If Not String.IsNullOrWhiteSpace(cb_language.Text) Then
            My.Settings.last_language = cb_language.Text
        End If

    End Sub

#End Region


End Class


#Region "Row Hiding Optimization"

Public Class RowFilteringOptimization


    Private dg As DataGridView
    Private column_mode_backup(-1) As DataGridViewAutoSizeColumnMode


    Public Sub New(dg As DataGridView)
        Me.dg = dg
    End Sub


    Public Sub Start()

        ReDim column_mode_backup(dg.Columns.Count)
        For Each col As DataGridViewColumn In dg.Columns
            column_mode_backup(col.Index) = col.AutoSizeMode
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next

    End Sub


    Public Sub Finish()

        If dg IsNot Nothing AndAlso Not column_mode_backup.Length < dg.Columns.Count Then
            For Each col As DataGridViewColumn In dg.Columns
                col.AutoSizeMode = column_mode_backup(col.Index)
            Next
        End If

    End Sub


End Class

#End Region
