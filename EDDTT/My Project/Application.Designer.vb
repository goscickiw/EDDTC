﻿'Copyright 2019 Wojciech Gościcki (goscickiw)
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

'------------------------------------------------------------------------------
' <auto-generated>
'     Ten kod został wygenerowany przez narzędzie.
'     Wersja wykonawcza:4.0.30319.42000
'
'     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
'     kod zostanie ponownie wygenerowany.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    'UWAGA: Ten plik został wygenerowany automatycznie; nie należy go bezpośrednio modyfikować.  Aby wprowadzić zmiany
    ' lub jeśli napotkasz w tym pliku błędy kompilacji, przejdź do Projektanta projektu
    ' (przejdź do obszaru Właściwości projektu lub kliknij dwukrotnie węzeł Mój Projekt w
    ' Eksploratorze rozwiązań) i wprowadź zmiany na karcie Aplikacja.
    '
    Partial Friend Class MyApplication
        
        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>  _
        Public Sub New()
            MyBase.New(Global.Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
            Me.IsSingleInstance = false
            Me.EnableVisualStyles = true
            Me.SaveMySettingsOnExit = true
            Me.ShutDownStyle = Global.Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses
        End Sub
        
        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>  _
        Protected Overrides Sub OnCreateMainForm()
            Me.MainForm = Global.EDDTT.Main
        End Sub
    End Class
End Namespace
