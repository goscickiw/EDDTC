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
Imports System.IO
Imports System.Text


Public Class Main


    Private Const problematic As String = "\"""
    Private Const replacement As String = "╬"

    Dim file_encoding As Encoding = Nothing


#Region "Setting EDD Repository"

    'Set EDD repository
    Private Sub Set_edd_repo_location(sender As Object, e As EventArgs) Handles b_edd_repo_browse.Click
        If set_edd_repo.ShowDialog() = DialogResult.OK Then
            My.Settings.edd_repo_set = False
            My.Settings.edd_repo_dir = set_edd_repo.SelectedPath
            Check_edd_repo()
            Refresh_settings()
        End If
    End Sub

    'Manually re-check EDD repository
    Private Sub Manually_check_edd_repo(sender As Object, e As EventArgs) Handles b_edd_repo_check.Click
        If Not String.IsNullOrWhiteSpace(My.Settings.edd_repo_dir) Then
            Check_edd_repo()
            Refresh_settings()
        Else
            MsgBox("EDD repository directory is empty. Nothing to check.", MsgBoxStyle.Information, "Re-Check Repository")
        End If
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
                MsgBox("The following subdirectories are not present in the " & .edd_repo_dir & " directory:" &
                       Environment.NewLine & Environment.NewLine & missing_subdirectories & Environment.NewLine &
                       "Please choose a correct EDDiscovery repository directory or check the File Detection Settings.",
                       MsgBoxStyle.Exclamation, "Missing Translation Subdirectories")
                .edd_repo_set = False
                Refresh_settings()
                Return False
            End If

            Dim missing_example_files As String = Nothing
            For Each filepath As String In Filepaths_main_uc_je_ed(.lang_exfile_name)
                If Not File.Exists(filepath) Then
                    missing_example_files += filepath & Environment.NewLine
                End If
            Next
            If Not String.IsNullOrWhiteSpace(missing_example_files) Then
                MsgBox("The following example files are not present in the repository:" & Environment.NewLine &
                       missing_example_files & Environment.NewLine &
                       "Please choose a correct EDDiscovery repository directory or check the File Detection Settings.",
                       MsgBoxStyle.Exclamation, "Missing Example Files")
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

#Region "Detecting and setting paths"

    'Set file paths manually
    Private Sub Set_example_file_path(sender As Object, e As EventArgs) Handles b_example_browse.Click, b_translation_browse.Click

        If My.Settings.warn_before_clearing AndAlso dg_translation.Rows.Count <> 0 AndAlso
            MsgBox("You have a translation loaded at the moment. If you continue, all unsaved progress will be lost. Do you want to continue?",
                   MsgBoxStyle.OkCancel, "Set Path") = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        If set_file_path.ShowDialog() = DialogResult.OK Then
            Select Case True
                Case sender Is b_example_browse
                    tb_example_path.Text = set_file_path.FileName
                Case sender Is b_translation_browse
                    tb_translation_path.Text = set_file_path.FileName
            End Select
        End If

    End Sub

    'Auto-Set Paths
    Private Sub Auto_detect_paths(sender As Object, e As EventArgs) Handles b_setpaths_mainfile.Click, b_setpaths_uc.Click, b_setpaths_je.Click, b_setpaths_ed.Click

        If My.Settings.warn_before_clearing AndAlso dg_translation.Rows.Count <> 0 AndAlso
            MsgBox("You have a translation loaded at the moment. If you continue, all unsaved progress will be lost. Do you want to continue?",
                   MsgBoxStyle.OkCancel, "Set Path") = MsgBoxResult.Cancel Then
            Exit Sub
        End If

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

        tb_example_path.Text = example_paths_list(file_type_index)
        tb_translation_path.Text = translation_paths_list(file_type_index)

        l_status.Text = "Ready to load files"

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
                    If file IsNot Nothing AndAlso file.ToString() Like Format_to_detector(.lang_mainfile_naming) AndAlso
                        Not file.ToString.ToLower.Contains(.lang_exfile_name.ToLower) Then
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

        Dim lang_short As String = Get_short_name(main_file_name, My.Settings.lang_mainfile_naming)

        Dim files_list As New List(Of String) From {
            My.Settings.edd_repo_dir & My.Settings.lang_mainfile_path & main_file_name,
            My.Settings.edd_repo_dir & My.Settings.lang_uc_path & String.Format(My.Settings.lang_uc_naming, lang_short),
            My.Settings.edd_repo_dir & My.Settings.lang_je_path & String.Format(My.Settings.lang_je_naming, lang_short),
            My.Settings.edd_repo_dir & My.Settings.lang_ed_path & String.Format(My.Settings.lang_ed_naming, lang_short)
        }

        Return files_list

    End Function

    'Clear everything when file paths change
    Private Sub Clear_everything_on_file_path_change(sender As Object, e As EventArgs) Handles tb_translation_path.TextChanged, tb_example_path.TextChanged
        Clear_everything()
    End Sub

#End Region


#Region "Loading Files"

    'Manual load
    Private Sub b_load_compare_Click(sender As Object, e As EventArgs) Handles b_load_compare.Click

        If My.Settings.warn_before_clearing AndAlso dg_translation.Rows.Count <> 0 AndAlso
            MsgBox("You have a translation loaded at the moment. If you continue, all unsaved progress will be lost. Do you want to continue?",
                   MsgBoxStyle.OkCancel, "Load Files") = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        Load_files()
    End Sub

    'Loading function
    Private Sub Load_files()

        Clear_everything()

        'Reading example file
        If String.IsNullOrWhiteSpace(tb_example_path.Text) Then
            MsgBox("Example file path cannot be empty.", MsgBoxStyle.Exclamation, "Cannot Load")
            l_status.Text = "Cannot Load - example file path is empty"
            Exit Sub
        ElseIf Not Directory.Exists(Path.GetDirectoryName(tb_example_path.Text)) Then
            MsgBox("Example file directory does not exist." & Environment.NewLine & "Change repository directory or File Detection Settings.",
                   MsgBoxStyle.Exclamation, "Cannot Load")
            l_status.Text = "Cannot Load - example file directory does not exist"
            Exit Sub
        ElseIf Not File.Exists(tb_example_path.Text) Then
            MsgBox("Example file does not exist in this directory. Check if it has been removed or its name changed." &
                   Environment.NewLine & "If its name has been changed, change its name or name format in File Detection Settings accordingly.",
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
            MsgBox("Translation file directory does not exist." & Environment.NewLine & "Change repository directory or File Detection Settings.",
                   MsgBoxStyle.Exclamation, "Cannot Load")
            l_status.Text = "Cannot Load - translation file directory does not exist"
            Exit Sub
        ElseIf Not File.Exists(tb_translation_path.Text) Then
            MsgBox("Translation file does not exist in this directory. Check if it has been removed or its name changed." &
                   Environment.NewLine & "If its name has been changed, change its name format in File Detection Settings accordingly.",
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
        Translation_hide_show_rows(False)

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

            If Nospace(line) Like "*:""*""*" And Not line Like "//*" Then

                Dim line_elements As New List(Of String) From {
                    Nothing,
                    Nothing,
                    Nothing,
                    Nothing
                }

                For sect_index As Integer = line_index To 0 Step -1
                    Dim sect_line As String = array(sect_index)
                    If sect_line Like "SECTION *" Then
                        line_elements(0) = sect_line.Substring(8)
                        If Not sectorder.Items.Contains(line_elements(0)) Then
                            sectorder.Items.Add(line_elements(0))
                        End If
                        Exit For
                    End If
                Next

                line_elements(1) = line.Substring(0, line.IndexOf(":"))

                line_elements(2) = line.Substring(line.IndexOf("""") + 1)
                line_elements(2) = line_elements(2).Substring(0, line_elements(2).IndexOf(""""))

                If Nospace(line) Like "*:""*""=>""*""" And Not line Like "*@" Then
                    line_elements(3) = line.Substring(line.IndexOf("=>"))
                    line_elements(3) = line_elements(3).Substring(line_elements(3).IndexOf("""") + 1)
                    line_elements(3) = line_elements(3).Substring(0, line_elements(3).IndexOf(""""))
                End If

                'Changing ╬ back to \"
                For i As Integer = 0 To line_elements.Count - 1
                    If Not String.IsNullOrWhiteSpace(line_elements(i)) AndAlso line_elements(i).Contains(replacement) Then
                        line_elements(i) = line_elements(i).Replace(replacement, problematic)
                    End If
                Next

                dg.Rows.Add(line_elements(0), line_elements(1), line_elements(2), line_elements(3))
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

#Region "Applying Differences to Translation"

    'Apply differences
    'TODO Something probably in here (or when saving translation) caused a section to be split in two. Needs to be diagnosed and fixed.
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

            l_status.Text = String.Format("Added {0} IDs.", added_id_count)

            If removed_id_count > 0 Then
                l_status.Text += String.Format(" Removed {0} IDs.", removed_id_count)
            End If

            'Update_id_counters()
            Translation_hide_show_rows(False)

        Else

            MsgBox("No differences found, nothing to apply.", MsgBoxStyle.Exclamation, "No Differences Found")

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

#Region "Creating New Language"

    Private Sub Create_new_language_file_set(sender As Object, e As EventArgs) Handles b_new_lang.Click

        Dim new_language_name As String = InputBox(String.Format("Enter language name (in that language){0}and ISO 639-1 code.{0}{0}Example: {1}", Environment.NewLine,
                                                                 String.Format(My.Settings.lang_mainfile_naming.Substring(0, My.Settings.lang_mainfile_naming.IndexOf(".")), "english", "en")),
                                                                 "Create New Language")

        If String.IsNullOrWhiteSpace(new_language_name) Then
            Exit Sub
        End If

        With My.Settings

            If Not new_language_name Like Format_to_detector(.lang_mainfile_naming.Substring(0, .lang_mainfile_naming.IndexOf("."))) Then
                MsgBox("New language name has incorrect format.", MsgBoxStyle.Exclamation, "Cannot create new language")
                Exit Sub
            End If

            Dim example_filepaths_list As List(Of String) = Filepaths_main_uc_je_ed(.lang_exfile_name)

            For Each filepath As String In example_filepaths_list
                If Not File.Exists(filepath) Then
                    MsgBox(String.Format("{0} does not exist. Cannot create new translation.", filepath), MsgBoxStyle.Critical, "Missing Example File")
                    Exit Sub
                End If
            Next

            Dim newlang_filepaths_list As List(Of String) = Filepaths_main_uc_je_ed(new_language_name & .lang_mainfile_naming.Substring(.lang_mainfile_naming.IndexOf(".")))

            If File.Exists(newlang_filepaths_list(0)) AndAlso MsgBox(new_language_name & " already exists. Do you want to overwrite that translation?",
                                                                     MsgBoxStyle.OkCancel, "Translation Already Exists") = DialogResult.Cancel Then
                Exit Sub
            End If

            'Reading example
            Dim file_reader As New StreamReader(example_filepaths_list(0), True)
            file_encoding = file_reader.CurrentEncoding
            Dim example As String
            Try
                example = file_reader.ReadToEnd()
            Catch ex As Exception
                MsgBox(String.Format("Failed to load example file {0}:{1}{1}{2}", example_filepaths_list(0),
                                     Environment.NewLine, ex.Message), MsgBoxStyle.Critical, "Loading Error")
                l_status.Text = String.Format("Failed to load {0}", example_filepaths_list(0))
                file_reader.Close()
                Exit Sub
            End Try
            file_reader.Close()

            Dim example_array() As String = Split(example, Environment.NewLine)
            Dim lines_list As New List(Of String)(example_array)

            'Removing example inclusions
            For exmp_line_index As Integer = lines_list.Count - 1 To 0 Step -1
                Dim current_line As String = lines_list(exmp_line_index)
                If String.IsNullOrWhiteSpace(current_line) OrElse current_line Like "include *" Then
                    lines_list.RemoveAt(exmp_line_index)
                End If
            Next

            'Adding inclusions
            For i As Integer = 1 To 3
                lines_list.Add(String.Empty)
                lines_list.Add(String.Format("include {0}", Path.GetFileName(newlang_filepaths_list(i))))
            Next

            'New line at end of file
            lines_list.Add(String.Empty)
            Dim newlang_array() As String = lines_list.ToArray()
            Dim new_file As String = Join(newlang_array, Environment.NewLine)
            'Saving new translation main file
            Dim file_writer As New StreamWriter(newlang_filepaths_list(0), False, file_encoding)
            Try
                pb_progress.Value = 0
                pb_progress.Maximum = new_file.Length
                For Each chr As Char In new_file
                    file_writer.Write(chr)
                    pb_progress.Value += 1
                Next
            Catch ex As Exception
                MsgBox(String.Format("Failed to save translation file {0}:{1}{1}{2}", Path.GetFileName(newlang_filepaths_list(0)),
                                         Environment.NewLine, ex.Message), MsgBoxStyle.Critical, "Saving Error")
                l_status.Text = String.Format("Failed to save {0}", Path.GetFileName(newlang_filepaths_list(0)))
                file_writer.Close()
                Exit Sub
            End Try
            file_writer.Close()
            'Copying other translation files
            For i As Integer = 1 To 3
                My.Computer.FileSystem.CopyFile(example_filepaths_list(i), newlang_filepaths_list(i), True)
            Next

            l_status.Text = String.Format("Successfully created {0} translation files.", new_language_name)

            Detect_languages()
            If cb_language.Items.Contains(new_language_name) Then
                cb_language.SelectedIndex = cb_language.Items.IndexOf(new_language_name)
            End If

            'Auto-Set & Auto-Load
            If .auto_set_on_new_language Then
                If My.Settings.warn_before_clearing AndAlso dg_translation.Rows.Count <> 0 AndAlso
                    MsgBox("You have a translation loaded at the moment. If you continue, all unsaved progress will be lost. Do you want to continue?",
                           MsgBoxStyle.OkCancel, "Auto-Load New Language") = MsgBoxResult.Cancel Then
                    Exit Sub
                End If
                Clear_everything()
                tb_example_path.Text = example_filepaths_list(0)
                tb_translation_path.Text = newlang_filepaths_list(0)
                If .auto_load_files Then
                    Load_files()
                End If
            End If

        End With

    End Sub

#End Region

#Region "Saving Translation File"

    'TODO Something probably in here (or when applying differences) caused a section to be split in two. Needs to be diagnosed and fixed.
    Private Sub Save_translation(sender As Object, e As EventArgs) Handles b_save_translation.Click

        If dg_translation.Rows.Count > 0 Then

            'Creating list of strings from Translation rows
            pb_progress.Value = 0
            pb_progress.Maximum = dg_translation.Rows.Count
            Dim lines_list As New List(Of String)
            Dim previous_section As String = Nothing
            For Each row As DataGridViewRow In dg_translation.Rows
                If Not String.IsNullOrWhiteSpace(row.Cells(0).Value) AndAlso Not row.Cells(0).Value = previous_section Then
                    previous_section = row.Cells(0).Value
                    lines_list.Add(String.Empty)
                    lines_list.Add(String.Format("SECTION {0}", row.Cells(0).Value))
                    lines_list.Add(String.Empty)
                End If
                If String.IsNullOrWhiteSpace(row.Cells(3).Value) Then
                    lines_list.Add(String.Format("{0}: ""{1}"" @", row.Cells(1).Value, row.Cells(2).Value))
                Else
                    lines_list.Add(String.Format("{0}: ""{1}"" => ""{2}""", row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value))
                End If
                pb_progress.Value += 1
            Next

            lines_list.Add(String.Empty)

            'Adding inclusions
            If cb_tran_inclusions.Items.Count > 0 Then
                For Each item As String In cb_tran_inclusions.Items
                    'lines_list.Add("include " & item)
                    lines_list.Add(String.Format("include {0}", item))
                    lines_list.Add(String.Empty)
                Next
            End If

            'Converting the list of lines into single string
            Dim lines_array() As String = lines_list.ToArray()
            Dim file_text As String = Join(lines_array, Environment.NewLine)

            'Checking path and encoding
            If String.IsNullOrWhiteSpace(tb_translation_path.Text) Then
                MsgBox("Translation File path cannot be empty." & Environment.NewLine &
                       "(it shouldn't be possible for this error to appear - please report an issue)", MsgBoxStyle.Exclamation, "Cannot Save")
                l_status.Text = "Saving Failed - translation file path is empty"
                Exit Sub
            ElseIf Not Directory.Exists(Path.GetDirectoryName(tb_translation_path.Text)) Then
                Dim msg As String = "Translation file directory does not exist or has been changed." & Environment.NewLine &
                    "Please do not change any of the following directories between loading and saving files with this program:" &
                    Environment.NewLine & Environment.NewLine &
                    My.Settings.edd_repo_dir & My.Settings.lang_mainfile_path & Environment.NewLine &
                    My.Settings.edd_repo_dir & My.Settings.lang_uc_path & Environment.NewLine &
                    My.Settings.edd_repo_dir & My.Settings.lang_je_path & Environment.NewLine &
                    My.Settings.edd_repo_dir & My.Settings.lang_ed_path
                MsgBox(msg, MsgBoxStyle.Exclamation, "Cannot Save")
                l_status.Text = "Saving Failed - file path changed after loading file"
                Exit Sub
            ElseIf file_encoding Is Nothing Then
                MsgBox("File encoding has not been detected properly." & Environment.NewLine &
                       "(it shouldn't be possible for this error to appear - please report an issue)", MsgBoxStyle.Exclamation, "Cannot Save")
                l_status.Text = "Saving Failed - file encoding not detected"
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


#Region "Table Filtering"

    'Search
    Private Sub Update_search_filter(sender As Object, e As EventArgs) Handles b_tran_search.Click, b_tran_search_reset.Click

        Translation_hide_show_rows(sender Is b_tran_search)

    End Sub

    'Hide or show all IDs in translation depending on "Hide Translated" and "Search" options
    Private Sub Translation_hide_show_rows(search_mode As Boolean)
        If dg_translation.Rows.Count > 0 Then
            Dim dg_util As New RowFilteringOptimization(dg_translation)
            dg_util.Start()
            pb_progress.Value = 0
            pb_progress.Maximum = dg_translation.Rows.Count
            For Each row As DataGridViewRow In dg_translation.Rows
                Dim match As Boolean = Not search_mode OrElse String.IsNullOrWhiteSpace(tb_tran_search.Text)
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

    'Convert format string to detector string
    Private Function Format_to_detector(str As String) As String
        Return String.Format(str, "*", "*", "*", "*", "*", "*", "*", "*", "*", "*")
    End Function

    'Remove spaces from string
    Private Function Nospace(str As String) As String
        Return str.Replace(" ", "")
    End Function

    'Go to section in Translation
    Private Sub Translation_go_to_section(sender As Object, e As EventArgs) Handles cb_tran_sectorder.SelectedIndexChanged
        Dim section As String = cb_tran_sectorder.SelectedItem.ToString()
        For Each row As DataGridViewRow In dg_translation.Rows
            If row.Cells(0).Value = section And Not row.Visible = False Then
                dg_translation.CurrentCell = row.Cells(0)
                Exit For
            End If
        Next
    End Sub

    'Go to section in Example
    Private Sub Example_go_to_section(sender As Object, e As EventArgs) Handles cb_exmp_sectorder.SelectedIndexChanged
        Dim section As String = cb_exmp_sectorder.SelectedItem.ToString()
        For Each row As DataGridViewRow In dg_example.Rows
            If row.Cells(0).Value = section Then
                dg_example.CurrentCell = row.Cells(0)
                Exit For
            End If
        Next
    End Sub

    'Copy example text to translation text
    Private Sub Copy_example_dc(sender As Object, e As DataGridViewCellEventArgs) Handles dg_translation.CellDoubleClick, dg_diffs.CellDoubleClick
        If e.ColumnIndex = 2 AndAlso Not e.RowIndex < 0 Then
            sender.Rows(e.RowIndex).Cells(3).Value = sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        End If
    End Sub
    Private Sub Copy_example_sc(sender As Object, e As DataGridViewCellEventArgs) Handles dg_translation.CellClick, dg_diffs.CellClick
        If e.ColumnIndex = 2 AndAlso Not e.RowIndex < 0 AndAlso String.IsNullOrWhiteSpace(sender.Rows(e.RowIndex).Cells(3).Value) Then
            sender.Rows(e.RowIndex).Cells(3).Value = sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        End If
    End Sub

    'Get short language name
    Private Function Get_short_name(lang_mainfile As String, naming As String) As String
        Dim lang_short_start As Integer = naming.IndexOf("{")
        Return lang_mainfile.Substring(lang_short_start, lang_mainfile.IndexOf(naming(lang_short_start + 3)))
    End Function

    'Clear all tables
    Private Sub Clear_everything()

        dg_example.Rows.Clear()
        cb_exmp_inclusions.Items.Clear()
        cb_exmp_sectorder.Items.Clear()

        dg_translation.Rows.Clear()
        cb_tran_inclusions.Items.Clear()
        cb_tran_sectorder.Items.Clear()

        dg_diffs.Rows.Clear()

        pb_progress.Value = 0
        l_file_encoding.Text = "Not Loaded"
        l_status.Text = "Ready"

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
    Private Sub Update_settings(sender As Object, e As EventArgs) Handles cb_autoload.Click, cb_auto_set_on_new_language.Click,
        cb_autocheck_repo.Click, cb_warn_before_clearing.Click, cb_tran_hide_translated.Click, cb_tran_wordwrap.Click,
        cb_tran_show_example.Click, cb_diff_wordwrap.Click, cb_diff_ignore_removed.Click, cb_exmp_wordwrap.Click,
        cb_exmp_show_translation.Click

        With My.Settings
            Select Case True

                Case sender Is cb_autoload
                    .auto_load_files = sender.Checked

                Case sender Is cb_auto_set_on_new_language
                    .auto_set_on_new_language = sender.Checked

                Case sender Is cb_autocheck_repo
                    .auto_check_edd_repo = sender.Checked

                Case sender Is cb_warn_before_clearing
                    .warn_before_clearing = sender.Checked

                Case sender Is cb_tran_hide_translated
                    .tran_hide_translated = sender.Checked
                    Translation_hide_show_rows(False)

                Case sender Is cb_tran_wordwrap
                    .tran_wordwrap = sender.Checked

                Case sender Is cb_tran_show_example
                    .tran_show_example = sender.Checked

                Case sender Is cb_diff_wordwrap
                    .diff_wordwrap = sender.Checked

                Case sender Is cb_diff_ignore_removed
                    .diff_ignore_removed = sender.Checked

                Case sender Is cb_exmp_wordwrap
                    .exmp_wordwrap = sender.Checked

                Case sender Is cb_exmp_show_translation
                    .exmp_show_translation = sender.Checked

            End Select
        End With

        Refresh_settings()

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
            cb_auto_set_on_new_language.Checked = .auto_set_on_new_language
            cb_autocheck_repo.Checked = .auto_check_edd_repo
            cb_warn_before_clearing.Checked = .warn_before_clearing

            cb_tran_hide_translated.Checked = .tran_hide_translated
            cb_tran_wordwrap.Checked = .tran_wordwrap
            cb_tran_show_example.Checked = .tran_show_example

            cb_diff_wordwrap.Checked = .diff_wordwrap
            cb_diff_ignore_removed.Checked = .diff_ignore_removed

            cb_exmp_wordwrap.Checked = .exmp_wordwrap
            cb_exmp_show_translation.Checked = .exmp_show_translation

            If .diff_wordwrap Then
                dg_diffs.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            Else
                dg_diffs.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False
            End If

            If .tran_wordwrap Then
                dg_translation.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            Else
                dg_translation.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False
            End If
            c_tran_example.Visible = .tran_show_example

            If .exmp_wordwrap Then
                dg_example.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            Else
                dg_example.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False
            End If
            c_exmp_translation.Visible = .exmp_show_translation

        End With

    End Sub

    'Open File Detection Settings dialog
    Private Sub Open_path_settings(sender As Object, e As EventArgs) Handles b_file_detection_settings.Click
        FileDetectionSettings.ShowDialog()
    End Sub

    Private Sub Open_about_dialog(sender As Object, e As EventArgs) Handles b_about.Click
        About.ShowDialog()
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
        Text = My.Application.Info.ProductName
        Icon = My.Resources.EDDTC
        cb_tran_inclusions.ComboBox.ContextMenuStrip = edit_translation_inclusions
        With My.Settings
            If Not (Correct_format(.lang_mainfile_naming, 1) And Correct_format(.lang_uc_naming, 0) And
                Correct_format(.lang_je_naming, 0) And Correct_format(.lang_ed_naming, 0)) Then
                My.Settings.Reset()
                MsgBox("Some naming format settings were not correct. As this would prevent the program from starting, settings were reset to default.", MsgBoxStyle.Critical, "Invalid Settings")
            End If
            Refresh_settings()
            If .auto_check_edd_repo AndAlso Not String.IsNullOrWhiteSpace(.edd_repo_dir) Then
                Check_edd_repo()
            Else
                Detect_languages()
            End If
        End With
    End Sub

    'Actions to do when program closes
    Private Sub On_close(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If Not String.IsNullOrWhiteSpace(cb_language.Text) Then
            My.Settings.last_language = cb_language.Text
        End If

    End Sub

#End Region


End Class
