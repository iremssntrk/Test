Imports System.IO

Public Class StreamRW

    Public Iterator Function FileRead(path As String) As IEnumerable(Of String)
        Dim line As String
        Dim sr As StreamReader = New StreamReader(path)
        line = sr.ReadLine()
        While Not (line = Nothing)
            Yield line
            line = sr.ReadLine()
        End While
    End Function
End Class



