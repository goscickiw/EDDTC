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
Public Class FileDetectionSettings

    Private temp_mainfile_naming As String = Nothing
    Private temp_uc_naming As String = Nothing
    Private temp_je_naming As String = Nothing
    Private temp_ed_naming As String = Nothing

    Private Sub On_open(sender As Object, e As EventArgs) Handles MyBase.Load
        With My.Settings
            temp_mainfile_naming = .lang_mainfile_naming
            temp_uc_naming = .lang_uc_naming
            temp_je_naming = .lang_je_naming
            temp_ed_naming = .lang_ed_naming
        End With
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Close()
    End Sub

    Private Sub On_close(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'TODO Simplify this
        With My.Settings
            If Not Correct_format(.lang_mainfile_naming, 1) Then
                .lang_mainfile_naming = temp_mainfile_naming
                MsgBox("Main file naming format is not correct. Restored previous setting.", MsgBoxStyle.Exclamation, "Invalid Format")
            End If
            If Not Correct_format(.lang_uc_naming, 0) Then
                .lang_uc_naming = temp_uc_naming
                MsgBox("User Controls file naming format is not correct. Restored previous setting.", MsgBoxStyle.Exclamation, "Invalid Format")
            End If
            If Not Correct_format(.lang_je_naming, 0) Then
                .lang_je_naming = temp_je_naming
                MsgBox("Journal Events file naming format is not correct. Restored previous setting.", MsgBoxStyle.Exclamation, "Invalid Format")
            End If
            If Not Correct_format(.lang_ed_naming, 0) Then
                .lang_ed_naming = temp_ed_naming
                MsgBox("Elite Dangerous file naming format is not correct. Restored previous setting.", MsgBoxStyle.Exclamation, "Invalid Format")
            End If
        End With
    End Sub

End Class
