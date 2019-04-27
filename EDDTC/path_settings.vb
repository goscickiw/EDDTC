Imports System.Windows.Forms

Public Class path_settings

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Default_Button_Click(sender As Object, e As EventArgs) Handles Default_Button.Click

        With My.Settings
            .tlf_files_path = "\EDDiscovery\Translations\"
            .tlf_files_naming = "*-*.tlf"
            .uc_files_path = "\EDDiscovery\UserControls\"
            .uc_files_naming = "translation-*-uc.tlp"
            .je_files_path = "\EliteDangerous\JournalEvents\"
            .je_files_naming = "translation-*-je.tlp"
            .ed_files_path = "\EliteDangerous\EliteDangerous\"
            .ed_files_naming = "translation-*-ed.tlp"
            .example_name = "example-ex.tlf"
        End With

    End Sub

End Class
