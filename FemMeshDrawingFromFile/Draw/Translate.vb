Imports System.Runtime.InteropServices
Imports System.Runtime.Remoting
Imports devDept.Eyeshot
Imports devDept.Eyeshot.Entities
Imports devDept.Eyeshot.Fem
Imports devDept.Eyeshot.FontStyleCharData
Imports devDept.Geometry
Imports devDept.Geometry.Entities
Imports devDept.Graphics

Public Class Translate

    Dim _model As Simulation

    Sub SumVertices(vertices As List(Of Point3D), item As String)
        Dim tArray() As String
        tArray = Split(item, " ")
        Dim p(3) As Double
        For i = 0 To UBound(tArray)
            Double.TryParse(tArray(i), p(i))
        Next i
        Dim v As Node = New Node(p(0), p(1), p(2))
        vertices.Add(v)
    End Sub

    Sub SumTriangles(Mat As Material, item As String, triangles As List(Of Element))
        Dim element As List(Of Integer) = New List(Of Integer)
        Dim temp As Integer
        Dim tArray() As String
        tArray = Split(item, " ")
        For k = 0 To UBound(tArray)
            Double.TryParse(tArray(k), temp)
            element.Add(temp)
        Next k
        If (element.Count) = 4 Then
            SumOfQuads(Mat, triangles, element)
        ElseIf (element.Count) = 3 Then
            SumOfTrias(Mat, triangles, element)
        End If

    End Sub

    Sub SumOfQuads(mat As Material, triangles As List(Of Element), Element As List(Of Integer))
        Dim quad = New Quad4(Element(0), Element(1), Element(2), Element(3), mat)
        triangles.Add(quad)
    End Sub

    Sub SumOfTrias(mat As Material, triangles As List(Of Element), Element As List(Of Integer))
        Dim tri1 As Tria3 = New Tria3(Element(0), Element(1), Element(2), mat)
        triangles.Add(tri1)
    End Sub


End Class


