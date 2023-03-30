Imports devDept.Eyeshot.Entities
Imports devDept.Eyeshot.Fem
Imports devDept.Geometry
Imports System.Threading

Public Class VerticeClass

    Sub FindAll(path As String, vertices As List(Of Point3D))
        Dim count2 As Integer
        Dim istep As Integer
        Dim NoOfVertices As Integer
        Dim tr = New Translate()
        Dim streamClass = New StreamRW

        For Each item As String In streamClass.FileRead(path).ToList

            If (istep = 1) And (count2 < NoOfVertices) Then
                tr.SumVertices(vertices, item)
                count2 = count2 + 1
            ElseIf (istep = 1) And (count2 = NoOfVertices) Then
                istep = 0
                count2 = 0
            End If

            If item.Contains("elements:") Then
                istep = 0
            ElseIf item.Contains("vertices:") Then
                Dim ForSplit = Split(item, " ")
                Integer.TryParse(ForSplit(1), NoOfVertices)
                istep = 1
            End If
        Next
    End Sub
End Class
