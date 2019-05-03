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
Partial Class About
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
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label

    'Wymagane przez Projektanta formularzy systemu Windows
    Private components As System.ComponentModel.IContainer

    'UWAGA: następująca procedura jest wymagana przez Projektanta formularzy systemu Windows
    'Możesz to modyfikować, używając Projektanta formularzy systemu Windows. 
    'Nie należy modyfikować za pomocą edytora kodu.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.LabelProductName = New System.Windows.Forms.Label()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.l_github_page = New System.Windows.Forms.LinkLabel()
        Me.TextBoxLicense = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelProductName
        '
        Me.LabelProductName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelProductName.AutoSize = True
        Me.LabelProductName.Location = New System.Drawing.Point(6, 8)
        Me.LabelProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelProductName.MaximumSize = New System.Drawing.Size(0, 17)
        Me.LabelProductName.Name = "LabelProductName"
        Me.LabelProductName.Size = New System.Drawing.Size(73, 13)
        Me.LabelProductName.TabIndex = 0
        Me.LabelProductName.Text = "Product name"
        '
        'LabelVersion
        '
        Me.LabelVersion.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelVersion.AutoSize = True
        Me.LabelVersion.Location = New System.Drawing.Point(6, 38)
        Me.LabelVersion.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelVersion.MaximumSize = New System.Drawing.Size(0, 17)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(42, 13)
        Me.LabelVersion.TabIndex = 0
        Me.LabelVersion.Text = "Version"
        Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCopyright
        '
        Me.LabelCopyright.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelCopyright.AutoSize = True
        Me.LabelCopyright.Location = New System.Drawing.Point(6, 68)
        Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelCopyright.MaximumSize = New System.Drawing.Size(0, 17)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(51, 13)
        Me.LabelCopyright.TabIndex = 0
        Me.LabelCopyright.Text = "Copyright"
        Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(497, 297)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "&OK"
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.Location = New System.Drawing.Point(274, 12)
        Me.TextBoxDescription.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.TextBoxDescription.Multiline = True
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.ReadOnly = True
        Me.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxDescription.Size = New System.Drawing.Size(298, 123)
        Me.TextBoxDescription.TabIndex = 1
        Me.TextBoxDescription.TabStop = False
        Me.TextBoxDescription.Text = "Description"
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 1
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.Controls.Add(Me.LabelProductName, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelVersion, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCopyright, 0, 2)
        Me.TableLayoutPanel.Controls.Add(Me.l_github_page, 0, 3)
        Me.TableLayoutPanel.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 4
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(253, 123)
        Me.TableLayoutPanel.TabIndex = 0
        '
        'l_github_page
        '
        Me.l_github_page.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.l_github_page.AutoSize = True
        Me.l_github_page.Location = New System.Drawing.Point(3, 100)
        Me.l_github_page.Name = "l_github_page"
        Me.l_github_page.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.l_github_page.Size = New System.Drawing.Size(70, 13)
        Me.l_github_page.TabIndex = 3
        Me.l_github_page.TabStop = True
        Me.l_github_page.Tag = "https://github.com/goscickiw/EDDTT"
        Me.l_github_page.Text = "GitHub page"
        '
        'TextBoxLicense
        '
        Me.TextBoxLicense.Location = New System.Drawing.Point(12, 141)
        Me.TextBoxLicense.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.TextBoxLicense.Multiline = True
        Me.TextBoxLicense.Name = "TextBoxLicense"
        Me.TextBoxLicense.ReadOnly = True
        Me.TextBoxLicense.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxLicense.Size = New System.Drawing.Size(560, 150)
        Me.TextBoxLicense.TabIndex = 2
        Me.TextBoxLicense.TabStop = False
        Me.TextBoxLicense.Text = "License"
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.OKButton
        Me.ClientSize = New System.Drawing.Size(584, 332)
        Me.Controls.Add(Me.TextBoxLicense)
        Me.Controls.Add(Me.TextBoxDescription)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Controls.Add(Me.OKButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxDescription As TextBox
    Friend WithEvents TableLayoutPanel As TableLayoutPanel
    Friend WithEvents TextBoxLicense As TextBox
    Friend WithEvents l_github_page As LinkLabel
End Class
