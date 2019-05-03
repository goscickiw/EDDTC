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
    Public Function Correct_format(str As String, highest_element_number As Integer) As Boolean
        For i As Integer = 0 To highest_element_number
            Dim element As String = "{" & i & "}"
            If Not str.Contains(element) Then Return False
        Next

        Dim found_elements As MatchCollection
        Dim regx As New Regex("\{(.*?)\}")
        If regx.IsMatch(str) Then
            found_elements = regx.Matches(str)
        Else
            Return False
        End If

        For Each element As Match In found_elements
            Dim val As Integer = Convert.ToInt32(element.Groups(1).Value)
            If val > highest_element_number Then Return False
        Next
        Return True
    End Function

#End Region

#Region "String Operation Functions"

    'Remove spaces from string
    Public Function Nospace(str As String) As String
        Return str.Replace(" ", "")
    End Function

    'Get short language name
    Public Function Get_short_name(lang_mainfile As String, naming As String) As String
        Dim lang_short_start As Integer = naming.IndexOf("{0}")
        Return lang_mainfile.Substring(lang_short_start, lang_mainfile.IndexOf(naming(lang_short_start + 3)))
    End Function

    'Convert format string to detector string
    Public Function Like_format(str As String) As String
        Dim element_count As Integer = 0
        While True
            Dim element As String = "{" & element_count & "}"
            If Not str.Contains(element) Then Exit While
            str = str.Replace(element, "*")
            element_count += 1
        End While
        Return str
    End Function

#End Region

#Region "Unformat"

    'Unformat
    Function Unformat(str As String, format As String, ignore_spaces As Boolean) As String()
        format = Regex.Escape(format).Replace("\{", "{")
        If ignore_spaces Then format = format.Replace("\ ", "\ ?")
        Dim element_count As Integer = 0
        While True
            Dim element As String = "{" & element_count & "}"
            If Not format.Contains(element) Then Exit While
            format = format.Replace(element, String.Format("(?'group{0}'.*)", element_count))
            element_count += 1
        End While

        Dim match As Match = New Regex(format).Match(str)

        If element_count <> match.Groups.Count - 1 Then
            Return Nothing
        Else
            Dim elements As String() = New String(element_count - 1) {}
            For index As Integer = 0 To element_count - 1
                elements(index) = match.Groups(String.Format("group{0}", index)).Value
            Next
            Return elements
        End If
    End Function

#End Region

End Module
