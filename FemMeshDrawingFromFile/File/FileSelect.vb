Imports Microsoft.Win32

Public Class FileSelect
    Public Function OpenFile() As String
        Dim fileDialog As OpenFileDialog = New OpenFileDialog()
        fileDialog.Filter = "txt|*.txt"
        Dim path As String
        If (fileDialog.ShowDialog().Value) Then
            path = fileDialog.FileName
        End If
        Return path
    End Function

End Class
