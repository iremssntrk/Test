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
    Public Sub New(Model As Simulation)
        _model = Model
    End Sub

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

    Sub SumElement(Mat As Material, vertices As List(Of Point3D), item As String)
        Dim element As List(Of Integer) = New List(Of Integer)

        Dim temp As Integer
        Dim tArray() As String
        tArray = Split(item, " ")
        For k = 0 To UBound(tArray)
            Double.TryParse(tArray(k), temp)
            element.Add(temp)
        Next k
        If (element.Count) = 4 Then
            FemmeshGenerator(element, vertices, Mat)
        ElseIf (element.Count) = 3 Then
            MeshGenerator(element, vertices, Mat)
        End If

    End Sub


    Sub FemmeshGenerator(element As List(Of Integer), vertices As List(Of Point3D), mat As Material)
        Dim triangles As List(Of Element) = New List(Of Element)
        Dim quad = New Quad4(element(0), element(1), element(2), element(3), mat)
        triangles.Add(quad)
        Dim mesh As FemMesh = New FemMesh(vertices, triangles)
        mesh.ColorMethod = colorMethodType.byEntity
        _model.Entities.Add(mesh)
    End Sub

    Sub MeshGenerator(element As List(Of Integer), vertices As List(Of Point3D), mat As Material)
        'Dim triangles As List(Of IndexTriangle) = New List(Of IndexTriangle)
        Dim triangles As List(Of Element) = New List(Of Element)
        Dim color As Color = New Color()
        color.R = 5
        color.G = 5
        color.B = 10
        Dim tri1 As Tria3 = New Tria3(element(0), element(1), element(2), mat)
        triangles.Add(tri1)
        Dim mesh As FemMesh = New FemMesh(vertices, triangles)
        mesh.ColorMethod = colorMethodType.byEntity
        _model.Entities.Add(mesh)
    End Sub

End Class


