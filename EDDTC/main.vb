Imports System.IO
Imports System.Text

Public Class main


    Dim file_encoding As Encoding = Nothing


#Region "Load Files"

    'Compare Files
    Private Sub compare_files(sender As Object, e As EventArgs) Handles b_compare_files.Click

        'Reading example file
        If String.IsNullOrWhiteSpace(tb_example.Text) Then
            MsgBox("Example file path cannot be empty.", MsgBoxStyle.Exclamation, "Cannot Load")
            l_status.Text = "Cannot Load - example file path is empty"
            Exit Sub
        ElseIf Not Directory.Exists(Path.GetDirectoryName(tb_example.Text)) Then
            MsgBox("Example file directory does not exist." & Environment.NewLine & "Change repository directory or Path Settings.", MsgBoxStyle.Exclamation, "Cannot Load")
            l_status.Text = "Cannot Load - example file directory does not exist"
            Exit Sub
        ElseIf Not File.Exists(tb_example.Text) Then
            MsgBox("Example file does not exist in this directory. Check if it has been removed or its name changed." & Environment.NewLine & "If its name has been changed, change its name or name format in Path Settings accordingly.", MsgBoxStyle.Exclamation, "Cannot Load")
            l_status.Text = "Cannot Load - example file does not exist"
            Exit Sub
        End If
        Dim example_reader As New StreamReader(tb_example.Text, True)
        Dim example As String
        Try
            example = example_reader.ReadToEnd()
        Catch ex As Exception
            MsgBox("Failed to load example file " & Path.GetFileName(tb_example.Text) & ":" & Environment.NewLine & Environment.NewLine & ex.Message, MsgBoxStyle.Critical, "Loading Error")
            l_status.Text = "Failed to load " & Path.GetFileName(tb_example.Text)
            example_reader.Close()
            Exit Sub
        End Try
        example_reader.Close()

        'Reading translation file
        If String.IsNullOrWhiteSpace(tb_translation.Text) Then
            MsgBox("Translation File path cannot be empty.", MsgBoxStyle.Exclamation, "Cannot Load")
            l_status.Text = "Cannot Load - translation file path is empty"
            Exit Sub
        ElseIf Not Directory.Exists(Path.GetDirectoryName(tb_translation.Text)) Then
            MsgBox("Translation file directory does not exist." & Environment.NewLine & "Change repository directory or Path Settings.", MsgBoxStyle.Exclamation, "Cannot Load")
            l_status.Text = "Cannot Load - translation file directory does not exist"
            Exit Sub
        ElseIf Not File.Exists(tb_translation.Text) Then
            MsgBox("Translation file does not exist in this directory. Check if it has been removed or its name changed." & Environment.NewLine & "If its name has been changed, change its name format in Path Settings accordingly.", MsgBoxStyle.Exclamation, "Cannot Load")
            l_status.Text = "Cannot Load - translation file does not exist"
            Exit Sub
        End If
        Dim translation_reader As New StreamReader(tb_translation.Text, True)
        Dim translation As String
        Try
            file_encoding = translation_reader.CurrentEncoding
            translation = translation_reader.ReadToEnd()
        Catch ex As Exception
            MsgBox("Failed to load translation file " & Path.GetFileName(tb_translation.Text) & ":" & Environment.NewLine & Environment.NewLine & ex.Message, MsgBoxStyle.Critical, "Loading Error")
            l_status.Text = "Failed to load " & Path.GetFileName(tb_translation.Text)
            translation_reader.Close()
            Exit Sub
        End Try
        translation_reader.Close()

        'Converting file content to DataGridViews
        Dim example_id_count As Integer = file_contents_to_grid(example, dg_example, lb_exmp_sectorder, lb_exmp_inclusions, pb_progress)
        Dim translation_id_count As Integer = file_contents_to_grid(translation, dg_translation, lb_tran_sectorder, lb_tran_inclusions, pb_progress)
        l_status.Text = "Loaded " & example_id_count & " IDs from " & Path.GetFileName(tb_example.Text) & " and " & translation_id_count & " IDs from " & Path.GetFileName(tb_translation.Text) & "."

        'Finding added/removed IDs
        dg_diffs.Rows.Clear()
        Dim added_count As Integer = find_diffs(dg_example, dg_translation, dg_diffs, "Added")
        Dim removed_count As Integer = 0
        If My.Settings.diff_ignore_removed = False Then
            removed_count = find_diffs(dg_translation, dg_example, dg_diffs, "Removed")
        End If

        Update_id_counters()
        Translation_hide_show_rows()

        If added_count = 0 And removed_count = 0 Then
            l_status.Text += " No differences found."
            tc_datatables.SelectedIndex = 1
        ElseIf added_count > 0 And removed_count = 0 Then
            l_status.Text += " Found " & added_count & " added IDs."
            tc_datatables.SelectedIndex = 0
        ElseIf added_count = 0 And removed_count > 0 Then
            l_status.Text += " Found " & removed_count & " removed IDs."
            tc_datatables.SelectedIndex = 0
        ElseIf added_count > 0 And removed_count > 0 Then
            l_status.Text += " Found " & added_count & " added IDs and " & removed_count & " removed IDs."
            tc_datatables.SelectedIndex = 0
        End If

    End Sub

    'Process file contents into data for DataGridViews
    Private Function file_contents_to_grid(file_content As String, dg As DataGridView, sectorder As ListBox, includes As ListBox, pb As ToolStripProgressBar)

        Dim array() As String = Split(file_content, Environment.NewLine)
        dg.Rows.Clear()
        sectorder.Items.Clear()
        includes.Items.Clear()

        Dim found_count As Integer = 0

        pb.Value = 0
        pb.Maximum = array.Length - 1

        For line_index = 0 To array.Length - 1

            Dim line As String = array(line_index)

            'Changing \" to '' (changes are later reverted when saving)
            Dim problematic As String = "\" & Chr(34)
            Dim replacement As String = "''"
            line = line.Replace(problematic, replacement)

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

                dg.Rows.Add(line_sect, line_name, line_exmp, line_trns)
                found_count += 1

            ElseIf line Like "include *" Then

                Dim line_include As String = line.Substring(8)
                If Not includes.Items.Contains(line_include) Then
                    includes.Items.Add(line_include)
                End If

            End If

            pb.Value = line_index

        Next

        Return found_count

    End Function

    'Find differences and add to differences table
    Private Function find_diffs(dg_from As DataGridView, dg_to As DataGridView, dg_diff As DataGridView, difftype As String)

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

#Region "Create New Translation"

    'Create New Translation
    Private Sub create_new_translation(sender As Object, e As EventArgs) Handles b_create_new.Click

        Dim new_language_name As String = InputBox("Enter language name (in that language)" & Environment.NewLine & "and ISO 639-1 code." & Environment.NewLine & Environment.NewLine & "Example: english-en", "New Translation")
        If Not String.IsNullOrWhiteSpace(new_language_name) AndAlso new_language_name Like "*-*" Then

            Dim exmp_short As String = My.Settings.example_name.Substring(0, My.Settings.example_name.IndexOf("-"))
            Dim exmp_tlf As String = My.Settings.edd_repo_path & My.Settings.tlf_files_path & My.Settings.example_name
            Dim exmp_uc As String = My.Settings.edd_repo_path & My.Settings.uc_files_path & Insert_at(My.Settings.uc_files_naming, exmp_short, "*")
            Dim exmp_je As String = My.Settings.edd_repo_path & My.Settings.je_files_path & Insert_at(My.Settings.je_files_naming, exmp_short, "*")
            Dim exmp_ed As String = My.Settings.edd_repo_path & My.Settings.ed_files_path & Insert_at(My.Settings.ed_files_naming, exmp_short, "*")

            Dim new_short As String = new_language_name.Substring(0, new_language_name.IndexOf("-"))
            Dim new_tlf As String = My.Settings.edd_repo_path & My.Settings.tlf_files_path & new_language_name & ".tlf"
            Dim new_uc As String = My.Settings.edd_repo_path & My.Settings.uc_files_path & Insert_at(My.Settings.uc_files_naming, new_short, "*")
            Dim new_je As String = My.Settings.edd_repo_path & My.Settings.je_files_path & Insert_at(My.Settings.je_files_naming, new_short, "*")
            Dim new_ed As String = My.Settings.edd_repo_path & My.Settings.ed_files_path & Insert_at(My.Settings.ed_files_naming, new_short, "*")


            If Not File.Exists(exmp_tlf) Then
                MsgBox(My.Settings.example_name & " does not exist. Cannot create new translation.", MsgBoxStyle.Critical, "Missing Example File")
                Exit Sub
            ElseIf Not File.Exists(exmp_uc) Then
                MsgBox(Path.GetFileName(exmp_uc) & " does not exist. Cannot create new translation.", MsgBoxStyle.Critical, "Missing Example File")
                Exit Sub
            ElseIf Not File.Exists(exmp_je) Then
                MsgBox(Path.GetFileName(exmp_je) & " does not exist. Cannot create new translation.", MsgBoxStyle.Critical, "Missing Example File")
                Exit Sub
            ElseIf Not File.Exists(exmp_ed) Then
                MsgBox(Path.GetFileName(exmp_ed) & " does not exist. Cannot create new translation.", MsgBoxStyle.Critical, "Missing Example File")
                Exit Sub
            End If

            If File.Exists(new_tlf) AndAlso MsgBox(new_language_name & " already exists. Do you want to overwrite that translation?", MsgBoxStyle.OkCancel, "Translation Already Exists") = DialogResult.Cancel Then
                Exit Sub
            End If

            'Reading example
            Dim file_reader As New StreamReader(exmp_tlf, True)
            file_encoding = file_reader.CurrentEncoding
            Dim example As String
            Try
                example = file_reader.ReadToEnd()
            Catch ex As Exception
                MsgBox("Failed to load example file " & My.Settings.example_name & ":" & Environment.NewLine & Environment.NewLine & ex.Message, MsgBoxStyle.Critical, "Loading Error")
                l_status.Text = "Failed to load " & My.Settings.example_name
                file_reader.Close()
                Exit Sub
            End Try
            file_reader.Close()

            Dim example_array() As String = Split(example, Environment.NewLine)
            Dim example_list As New List(Of String)(example_array)

            'Removing example inclusions
            For exmp_line_index As Integer = example_list.Count - 1 To 0 Step -1
                Dim current_line As String = example_list(exmp_line_index)
                If String.IsNullOrWhiteSpace(current_line) OrElse current_line Like "include *" Then
                    example_list.RemoveAt(exmp_line_index)
                End If
            Next

            'Adding new inclusions
            example_list.Add(String.Empty)
            example_list.Add("include " & Path.GetFileName(new_uc))
            example_list.Add(String.Empty)
            example_list.Add("include " & Path.GetFileName(new_je))
            example_list.Add(String.Empty)
            example_list.Add("include " & Path.GetFileName(new_ed))
            example_list.Add(String.Empty)

            Dim new_array() As String = example_list.ToArray()
            Dim new_file As String = Join(new_array, Environment.NewLine)

            'Saving new translation main file
            Dim file_writer As New StreamWriter(new_tlf, False, file_encoding)
            Try
                pb_progress.Value = 0
                pb_progress.Maximum = new_file.Length
                For Each chr As Char In new_file
                    file_writer.Write(chr)
                    pb_progress.Value += 1
                Next
            Catch ex As Exception
                MsgBox("Failed to save translation file " & Path.GetFileName(new_tlf) & ":" & Environment.NewLine & Environment.NewLine & ex.Message, MsgBoxStyle.Critical, "Saving Error")
                l_status.Text = "Failed to save " & Path.GetFileName(new_tlf)
                file_writer.Close()
                Exit Sub
            End Try
            file_writer.Close()

            'Copying other translation files from example
            My.Computer.FileSystem.CopyFile(exmp_uc, new_uc, True)
            My.Computer.FileSystem.CopyFile(exmp_je, new_je, True)
            My.Computer.FileSystem.CopyFile(exmp_ed, new_ed, True)

            l_status.Text = "Successfully created " & new_language_name & " translation files. You can load it by pressing Get Paths, choosing it and pressing Get Paths again."

        Else
            MsgBox("Translation name is empty or has incorrect format.", MsgBoxStyle.Exclamation, "Cannot Create Translation")
        End If
    End Sub

#End Region

#Region "Insert new IDs into Translation View"

    Private Sub apply_diffs(sender As Object, e As EventArgs) Handles b_apply_diffs.Click
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

                    ElseIf lb_tran_sectorder.Items.Contains(diff_row_section) Then

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
                        Dim index_inorder As Integer = lb_exmp_sectorder.Items.IndexOf(diff_row_section)

                        If index_inorder = 0 Then
                            lb_tran_sectorder.Items.Insert(0, diff_row_section)
                        ElseIf index_inorder > 0 And index_inorder < lb_exmp_sectorder.Items.Count - 1 Then
                            Dim previous_section As String = lb_exmp_sectorder.Items(lb_exmp_sectorder.Items.IndexOf(diff_row_section) - 1).ToString()
                            lb_tran_sectorder.Items.Insert(lb_tran_sectorder.Items.IndexOf(previous_section) + 1, diff_row_section)
                        ElseIf index_inorder = lb_exmp_sectorder.Items.Count - 1 Then
                            lb_tran_sectorder.Items.Add(diff_row_section)
                        End If

                        Dim section_order_index As Integer = lb_tran_sectorder.Items.IndexOf(diff_row_section)

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

                        ElseIf section_order_index > 0 And section_order_index < lb_tran_sectorder.Items.Count - 1 Then

                            Dim previous_section_in_order As String = lb_tran_sectorder.Items(section_order_index - 1).ToString()

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

                        ElseIf section_order_index = lb_tran_sectorder.Items.Count - 1 Then

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
                        If lb_tran_sectorder.Items.Contains(diff_section) And Not lb_exmp_sectorder.Items.Contains(diff_section) Then

                            lb_tran_sectorder.Items.Remove(diff_section)

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

            Update_id_counters()
            Translation_hide_show_rows()

        Else

            MsgBox("No differences found, nothing to apply.", MsgBoxStyle.Exclamation, "No Differences Found")

        End If
    End Sub

#End Region

#Region "Save translation file and Reload"

    Private Sub save_and_reload(sender As Object, e As EventArgs) Handles b_save_translation.Click
        If dg_translation.Rows.Count > 0 Then

            'Checking path and encoding
            If String.IsNullOrWhiteSpace(tb_translation.Text) Then
                MsgBox("Translation File path cannot be empty." & Environment.NewLine & "(it shouldn't be possible for this error to appear - please report an issue)", MsgBoxStyle.Exclamation, "Cannot Save")
                l_status.Text = "Saving Failed - translation file path is empty"
                Exit Sub
            ElseIf Not Directory.Exists(Path.GetDirectoryName(tb_translation.Text)) Then
                Dim msg As String = "Translation file directory does not exist or has been changed." & Environment.NewLine
                msg += "Please do not change any of the following directories between loading and saving files with this program:" & Environment.NewLine & Environment.NewLine
                msg += My.Settings.edd_repo_path & My.Settings.tlf_files_path & Environment.NewLine
                msg += My.Settings.edd_repo_path & My.Settings.uc_files_path & Environment.NewLine
                msg += My.Settings.edd_repo_path & My.Settings.je_files_path & Environment.NewLine
                msg += My.Settings.edd_repo_path & My.Settings.ed_files_path
                MsgBox(msg, MsgBoxStyle.Exclamation, "Cannot Save")
                l_status.Text = "Saving Failed - file path changed after loading file"
                Exit Sub
            ElseIf file_encoding Is Nothing Then
                MsgBox("File encoding has not been detected properly." & Environment.NewLine & "(it shouldn't be possible for this error to appear - please report an issue)", MsgBoxStyle.Exclamation, "Cannot Save")
                l_status.Text = "Saving Failed - file encoding not detected"
                Exit Sub
            End If

            'Preparations
            Dim problematic As String = "\" & Chr(34)
            Dim replacement As String = "''"
            pb_progress.Value = 0
            pb_progress.Maximum = dg_translation.Rows.Count

            'Creating list of strings from Translation rows
            Dim file_list As New List(Of String)
            Dim previous_section As String = Nothing
            For Each row As DataGridViewRow In dg_translation.Rows
                If String.IsNullOrWhiteSpace(row.Cells(0).Value) OrElse row.Cells(0).Value = previous_section Then
                    If String.IsNullOrWhiteSpace(row.Cells(3).Value) Then
                        file_list.Add(row.Cells(1).Value & ": " & Chr(34) & row.Cells(2).Value.Replace(replacement, problematic) & Chr(34) & " @")
                    Else
                        file_list.Add(row.Cells(1).Value & ": " & Chr(34) & row.Cells(2).Value.Replace(replacement, problematic) & Chr(34) & " => " & Chr(34) & row.Cells(3).Value.Replace(replacement, problematic) & Chr(34))
                    End If
                Else
                    previous_section = row.Cells(0).Value
                    file_list.Add(String.Empty)
                    file_list.Add("SECTION " & row.Cells(0).Value)
                    file_list.Add(String.Empty)
                    If String.IsNullOrWhiteSpace(row.Cells(3).Value) Then
                        file_list.Add(row.Cells(1).Value & ": " & Chr(34) & row.Cells(2).Value.Replace(replacement, problematic) & Chr(34) & " @")
                    Else
                        file_list.Add(row.Cells(1).Value & ": " & Chr(34) & row.Cells(2).Value.Replace(replacement, problematic) & Chr(34) & " => " & Chr(34) & row.Cells(3).Value.Replace(replacement, problematic) & Chr(34))
                    End If
                End If
                pb_progress.Value += 1
            Next

            file_list.Add(String.Empty)

            'Adding includes
            If lb_tran_inclusions.Items.Count > 0 Then
                For Each item As String In lb_tran_inclusions.Items
                    file_list.Add("include " & item)
                    file_list.Add(String.Empty)
                Next
            End If

            'Converting the list of lines into single string
            Dim file_array() As String = file_list.ToArray()
            Dim file_text As String = Join(file_array, Environment.NewLine)

            'Checking path again just to be sure
            If Not Directory.Exists(Path.GetDirectoryName(tb_translation.Text)) Then
                Dim msg As String = "Translation file directory does not exist or has been changed." & Environment.NewLine
                msg += "Please do not change any of the following directories while saving files with this program:" & Environment.NewLine & Environment.NewLine
                msg += My.Settings.edd_repo_path & My.Settings.tlf_files_path & Environment.NewLine
                msg += My.Settings.edd_repo_path & My.Settings.uc_files_path & Environment.NewLine
                msg += My.Settings.edd_repo_path & My.Settings.je_files_path & Environment.NewLine
                msg += My.Settings.edd_repo_path & My.Settings.ed_files_path
                MsgBox(msg, MsgBoxStyle.Exclamation, "Cannot Save")
                l_status.Text = "Saving Failed - file path changed while saving"
                Exit Sub
            End If

            'Saving to file
            Dim file_writer As New StreamWriter(tb_translation.Text, False, file_encoding)
            Try
                pb_progress.Value = 0
                pb_progress.Maximum = file_text.Length
                For Each chr As Char In file_text
                    file_writer.Write(chr)
                    pb_progress.Value += 1
                Next
            Catch ex As Exception
                MsgBox("Failed to save translation file " & Path.GetFileName(tb_translation.Text) & ":" & Environment.NewLine & Environment.NewLine & ex.Message, MsgBoxStyle.Critical, "Saving Error")
                l_status.Text = "Failed to save " & Path.GetFileName(tb_translation.Text)
                file_writer.Close()
                Exit Sub
            End Try
            file_writer.Close()

            l_status.Text = "Successfully saved " & Path.GetFileName(tb_translation.Text)

        Else
            MsgBox("File has not been loaded. Nothing to save.", MsgBoxStyle.Exclamation, "Cannot Save")
        End If
    End Sub

#End Region


#Region "Adding/Editing/Removing Inclusions"
    'Add new inclusion
    Private Sub tr_incl_add_Click(sender As Object, e As EventArgs) Handles tr_incl_add.Click
        Dim new_inclusion As String = InputBox("File name:", "New Inclusion")
        If Not String.IsNullOrWhiteSpace(new_inclusion) Then
            lb_tran_inclusions.Items.Add(new_inclusion)
        End If
    End Sub

    'Edit inclusion
    Private Sub tr_incl_edit_Click(sender As Object, e As EventArgs) Handles tr_incl_edit.Click
        If lb_tran_inclusions.SelectedItem IsNot Nothing Then
            Dim selected_index As Integer = lb_tran_inclusions.SelectedIndex
            Dim selected_inclusion As String = lb_tran_inclusions.Items(selected_index)
            Dim edited_inclusion As String = InputBox("File name:", "Edit Inclusion", selected_inclusion)
            If Not String.IsNullOrWhiteSpace(edited_inclusion) Then
                lb_tran_inclusions.Items(selected_index) = edited_inclusion
            End If
        Else
            MsgBox("Select an inclusion first.", MsgBoxStyle.Information, "Edit Inclusion")
        End If
    End Sub

    'Remove selected inclusion
    Private Sub tr_incl_remove_Click(sender As Object, e As EventArgs) Handles tr_incl_remove.Click
        If lb_tran_inclusions.SelectedItem IsNot Nothing Then
            If MsgBox("Are you sure that you want to remove the " & lb_tran_inclusions.SelectedItem.ToString() & " inclusion?", MsgBoxStyle.OkCancel, "Remove Inclusion") = MsgBoxResult.Ok Then
                lb_tran_inclusions.Items.Remove(lb_tran_inclusions.SelectedItem)
            End If
        Else
            MsgBox("Select an inclusion first.", MsgBoxStyle.Information, "Remove Inclusion")
        End If
    End Sub
#End Region


#Region "Setting Paths"

    'Set location of EDDiscovery Repository
    Private Sub set_edd_repo_location(sender As Object, e As EventArgs) Handles b_repo_browse.Click
        If set_edd_repo.ShowDialog() = DialogResult.OK Then
            My.Settings.edd_repo_path = set_edd_repo.SelectedPath
        End If
    End Sub

    'Get translation file paths
    Private Sub get_file_paths_from_repo(sender As Object, e As EventArgs) Handles b_getpaths.Click
        If cb_language.Items.Count() = 0 Then

            Dim tlf_dir As New DirectoryInfo(tb_repo_dir.Text & My.Settings.tlf_files_path)

            If tlf_dir.Exists Then

                For Each file In tlf_dir.GetFiles()
                    If file IsNot Nothing Then
                        If file.ToString Like My.Settings.tlf_files_naming Then
                            If Not file.ToString.ToLower.Contains(My.Settings.example_name.ToLower) Then
                                cb_language.Items.Add(file.ToString)
                            End If
                        End If
                    End If
                Next

                If cb_language.Items.Count() > 0 Then
                    cb_language.Text = cb_language.Items.Item(0)
                    l_status.Text = "Set file and language and press Get Paths again to automatically set file paths"
                Else
                    MsgBox("No translation files found!", MsgBoxStyle.Exclamation, "Error")
                End If

            Else
                MsgBox(My.Settings.tlf_files_path & " directory does not exist.", MsgBoxStyle.Exclamation, "Error")
            End If

        ElseIf Not String.IsNullOrWhiteSpace(cb_language.Text) Then

            Dim lang_short As String = cb_language.Text.Substring(0, cb_language.Text.IndexOf("-"))
            Dim exmp_short As String = My.Settings.example_name.Substring(0, My.Settings.example_name.IndexOf("-"))

            If rb_aa_tlf.Checked Then
                tb_example.Text = tb_repo_dir.Text & My.Settings.tlf_files_path & My.Settings.example_name
                tb_translation.Text = tb_repo_dir.Text & My.Settings.tlf_files_path & cb_language.Text
            ElseIf rb_aa_uc.Checked Then
                tb_example.Text = tb_repo_dir.Text & My.Settings.uc_files_path & Insert_at(My.Settings.uc_files_naming, exmp_short, "*"c)
                tb_translation.Text = tb_repo_dir.Text & My.Settings.uc_files_path & Insert_at(My.Settings.uc_files_naming, lang_short, "*"c)
            ElseIf rb_aa_je.Checked Then
                tb_example.Text = tb_repo_dir.Text & My.Settings.je_files_path & Insert_at(My.Settings.je_files_naming, exmp_short, "*"c)
                tb_translation.Text = tb_repo_dir.Text & My.Settings.je_files_path & Insert_at(My.Settings.je_files_naming, lang_short, "*"c)
            ElseIf rb_aa_ed.Checked Then
                tb_example.Text = tb_repo_dir.Text & My.Settings.ed_files_path & Insert_at(My.Settings.ed_files_naming, exmp_short, "*"c)
                tb_translation.Text = tb_repo_dir.Text & My.Settings.ed_files_path & Insert_at(My.Settings.ed_files_naming, lang_short, "*"c)
            End If
        End If

    End Sub

    'Set example file path
    Private Sub set_example_file_path(sender As Object, e As EventArgs) Handles b_example_browse.Click
        If set_file_path.ShowDialog() = DialogResult.OK Then
            tb_example.Text = set_file_path.FileName
        End If
    End Sub

    'Set translation file path
    Private Sub set_translation_file_path(sender As Object, e As EventArgs) Handles b_translation_browse.Click
        If set_file_path.ShowDialog() = DialogResult.OK Then
            tb_translation.Text = set_file_path.FileName
        End If
    End Sub

    'Clear everything when file paths change
    Private Sub clear_output_on_file_path_change(sender As Object, e As EventArgs) Handles tb_translation.TextChanged, tb_example.TextChanged
        dg_example.Rows.Clear()
        lb_exmp_inclusions.Items.Clear()
        lb_exmp_sectorder.Items.Clear()

        dg_translation.Rows.Clear()
        lb_tran_inclusions.Items.Clear()
        lb_tran_sectorder.Items.Clear()

        dg_diffs.Rows.Clear()
    End Sub

#End Region

#Region "Settings"

    'Load settings
    Private Sub on_start(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = My.Application.Info.Title & " v." & My.Application.Info.Version.ToString()
        Me.Icon = My.Resources.EDDTC

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
        col_tra_example.Visible = My.Settings.tran_showexample

        If My.Settings.exmp_wordwrap Then
            dg_example.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        Else
            dg_example.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False
        End If
        col_exm_translation.Visible = My.Settings.exmp_showtranslation

    End Sub

    'Open path and naming settings, restore previous if cancelled
    Private Sub open_path_settings(sender As Object, e As EventArgs) Handles b_path_settings.Click
        Dim temp_tlf_path As String = My.Settings.tlf_files_path
        Dim temp_tlf_naming As String = My.Settings.tlf_files_naming
        Dim temp_uc_path As String = My.Settings.uc_files_path
        Dim temp_uc_naming As String = My.Settings.uc_files_naming
        Dim temp_je_path As String = My.Settings.je_files_path
        Dim temp_je_naming As String = My.Settings.je_files_naming
        Dim temp_ed_path As String = My.Settings.ed_files_path
        Dim temp_ed_naming As String = My.Settings.ed_files_naming
        Dim temp_ex_name As String = My.Settings.example_name
        If path_settings.ShowDialog() = DialogResult.Cancel Then
            With My.Settings
                .tlf_files_path = temp_tlf_path
                .tlf_files_naming = temp_tlf_naming
                .uc_files_path = temp_uc_path
                .uc_files_naming = temp_uc_naming
                .je_files_path = temp_je_path
                .je_files_naming = temp_je_naming
                .ed_files_path = temp_ed_path
                .ed_files_naming = temp_ed_naming
                .example_name = temp_ex_name
            End With
        End If
    End Sub

    'Set Differences view word wrap
    Private Sub diff_set_wordwrap(sender As Object, e As EventArgs) Handles cb_diff_wordwrap.CheckedChanged
        My.Settings.diff_wordwrap = cb_diff_wordwrap.Checked
        If My.Settings.diff_wordwrap Then
            dg_diffs.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        Else
            dg_diffs.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False
        End If
    End Sub

    'Set Translation view word wrap
    Private Sub tran_set_wordwrap(sender As Object, e As EventArgs) Handles cb_tran_wordwrap.CheckedChanged
        My.Settings.tran_wordwrap = cb_tran_wordwrap.Checked
        If My.Settings.tran_wordwrap Then
            dg_translation.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        Else
            dg_translation.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False
        End If
    End Sub

    'Show/Hide Example Text in Translation File
    Private Sub set_show_example_in_translation(sender As Object, e As EventArgs) Handles cb_tran_showexample.CheckedChanged
        My.Settings.tran_showexample = cb_tran_showexample.Checked
        col_tra_example.Visible = My.Settings.tran_showexample
    End Sub

    'Set Example view word wrap
    Private Sub exmp_set_wordwrap(sender As Object, e As EventArgs) Handles cb_exmp_wordwrap.CheckedChanged
        My.Settings.exmp_wordwrap = cb_exmp_wordwrap.Checked
        If My.Settings.exmp_wordwrap Then
            dg_example.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        Else
            dg_example.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False
        End If
    End Sub

    'Show/Hide Translation Text in Example File
    Private Sub set_show_translation_in_example(sender As Object, e As EventArgs) Handles cb_exmp_showtranslation.CheckedChanged
        My.Settings.exmp_showtranslation = cb_exmp_showtranslation.Checked
        col_exm_translation.Visible = My.Settings.exmp_showtranslation
    End Sub

    'Ignore removed IDs
    Private Sub set_ignore_removed(sender As Object, e As EventArgs) Handles cb_diff_ignore_removed.CheckedChanged
        My.Settings.diff_ignore_removed = cb_diff_ignore_removed.Checked
    End Sub

    'Set to show only untranslated or all IDs
    Private Sub set_hide_translated(sender As Object, e As EventArgs) Handles cb_tran_hide_translated.CheckedChanged
        My.Settings.tran_hide_translated = cb_tran_hide_translated.Checked
        Translation_hide_show_rows()
    End Sub

#End Region


#Region "Other"

    'Update ID counters
    Private Sub Update_id_counters()
        l_diff_total.Text = "Total IDs: " & dg_diffs.Rows.Count
        l_tran_total.Text = "Total IDs: " & dg_translation.Rows.Count
        l_exmp_total.Text = "Total IDs: " & dg_example.Rows.Count
    End Sub

    'Insert word into string at char
    Private Function Insert_at(str As String, word As String, chr As Char)
        If str.Contains(chr) Then
            Dim output As String = str.Substring(0, str.IndexOf(chr)) & word
            output += str.Substring(str.IndexOf(chr) + 1, str.Length - (str.IndexOf(chr) + 1))
            Return output
        Else
            Return str
        End If
    End Function

    'Auto change tabs
    Private Sub Change_tabs(sender As Object, e As EventArgs) Handles tc_viewoptions.SelectedIndexChanged, tc_datatables.SelectedIndexChanged
        If sender Is tc_datatables Then
            tc_viewoptions.SelectedIndex = tc_datatables.SelectedIndex
        ElseIf sender Is tc_viewoptions Then
            tc_datatables.SelectedIndex = tc_viewoptions.SelectedIndex
        End If
    End Sub

    'Hide or show all IDs in translation depending on "Hide Translated" and "Search" options
    'TODO Make it not slow?
    Private Sub Translation_hide_show_rows()
        If dg_translation.Rows.Count > 0 Then
            pb_progress.Value = 0
            pb_progress.Maximum = dg_translation.Rows.Count
            For Each row As DataGridViewRow In dg_translation.Rows
                Dim found As Boolean = String.IsNullOrWhiteSpace(tb_tran_search.Text)
                For Each cell As DataGridViewCell In row.Cells
                    If Not String.IsNullOrWhiteSpace(cell.Value) AndAlso cell.Value Like "*" & tb_tran_search.Text & "*" Then
                        found = True
                        Exit For
                    End If
                Next
                row.Visible = (String.IsNullOrWhiteSpace(row.Cells(3).Value) OrElse Not My.Settings.tran_hide_translated) AndAlso found
                pb_progress.Value += 1
            Next
        End If
    End Sub

    'Go to section in Translation
    Private Sub Translation_go_to_section(sender As Object, e As EventArgs) Handles lb_tran_sectorder.SelectedIndexChanged
        Dim section As String = lb_tran_sectorder.SelectedItem.ToString()
        For Each row As DataGridViewRow In dg_translation.Rows
            If row.Cells(0).Value = section And Not row.Visible = False Then
                dg_translation.CurrentCell = row.Cells(0)
                Exit For
            End If
        Next
    End Sub

    'Go to section in Example
    Private Sub Example_go_to_section(sender As Object, e As EventArgs) Handles lb_exmp_sectorder.SelectedIndexChanged
        Dim section As String = lb_exmp_sectorder.SelectedItem.ToString()
        For Each row As DataGridViewRow In dg_example.Rows
            If row.Cells(0).Value = section Then
                dg_example.CurrentCell = row.Cells(0)
                Exit For
            End If
        Next
    End Sub

    'Copy example text to translation text
    Private Sub Copy_example_dc(sender As Object, e As DataGridViewCellEventArgs) Handles dg_translation.CellDoubleClick, dg_diffs.CellDoubleClick
        If e.ColumnIndex = 2 Then
            sender.Rows(e.RowIndex).Cells(3).Value = sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        End If
    End Sub
    Private Sub Copy_example_sc(sender As Object, e As DataGridViewCellEventArgs) Handles dg_translation.CellClick, dg_diffs.CellClick
        If e.ColumnIndex = 2 AndAlso String.IsNullOrWhiteSpace(sender.Rows(e.RowIndex).Cells(3).Value) Then
            sender.Rows(e.RowIndex).Cells(3).Value = sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        End If
    End Sub

    'Search in Translation
    Private Sub b_tran_search_Click(sender As Object, e As EventArgs) Handles b_tran_search.Click, b_tran_resetsearch.Click
        If sender Is b_tran_resetsearch Then
            tb_tran_search.Text = Nothing
        End If
        Translation_hide_show_rows()
    End Sub

    'Show program information
    Private Sub Show_info(sender As Object, e As EventArgs) Handles b_about.Click
        about.ShowDialog()
    End Sub

#End Region


End Class
