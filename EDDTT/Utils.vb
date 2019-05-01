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
Imports System.Text.RegularExpressions

Module Utils

#Region "Checking Format Strings"

    'Check of format string is correct
    Public Function Correct_format(str As String, max_item As Integer) As Boolean

        Dim previous_i As Integer = 0
        Dim found_items As MatchCollection
        Dim regx As New Regex("\{.*?\}")

        If regx.IsMatch(str) Then
            found_items = regx.Matches(str)
        Else
            Return False
        End If

        If max_item > found_items.Count - 1 Then
            Return False
        End If

        For i As Integer = 0 To found_items.Count - 1
            If i > max_item OrElse Not found_items(i).Value = "{" & i & "}" Then
                Return False
            End If
        Next

        Return True
    End Function

#End Region

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

End Module
