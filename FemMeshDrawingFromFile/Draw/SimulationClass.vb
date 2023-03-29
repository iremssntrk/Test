Imports System.Runtime.Remoting
Imports devDept.Eyeshot.Entities
Imports devDept.Eyeshot.Fem
Imports devDept.Geometry
Imports devDept.Geometry.Entities
Imports devDept.Graphics
Imports devDept.Eyeshot

Public Class SimulationClass
    Dim _model As Simulation
    Public Sub New(model As Simulation)
        _model = model
        _model.ActionMode = devDept.Eyeshot.actionType.SelectVisibleByPick
    End Sub


    Sub Simulate(path As String)
        Dim istep As Integer
        Dim Mat As Material = New Material("steel")
        Dim element As List(Of Integer) = New List(Of Integer)
        Dim count As Integer
        Dim count2 As Integer
        Dim NoOfVertices As Integer
        Dim NoOfElement As Integer
        Dim streamClass As StreamRW = New StreamRW()
        Dim translate As Translate = New Translate()


        Dim triangles As List(Of Element)
        Dim vertices As List(Of Point3D)
        For Each item As String In streamClass.FileRead(path).ToList

            If (istep = 1) And (count2 < NoOfVertices) Then
                translate.SumVertices(vertices, item)
                count2 = count2 + 1
            ElseIf (istep = 1) And (count2 = NoOfVertices) Then
                istep = 0
                count2 = 0
            End If
            If (istep = 2) And (count < NoOfElement) Then
                translate.SumTriangles(Mat, item, triangles)
                count = count + 1
            ElseIf (istep = 2) And (count = NoOfElement) Then
                istep = 0
                count = 0
                Dim mesh As FemMesh = New FemMesh(vertices, triangles)
                mesh.ColorMethod = colorMethodType.byEntity
                _model.Entities.Add(mesh)
            End If


            If item.Contains("elements:") Then
                triangles = New List(Of Element)
                Dim ForSplit = Split(item, " ")
                Integer.TryParse(ForSplit(1), NoOfElement)
                istep = 2
            ElseIf item.Contains("vertices:") Then
                vertices = New List(Of Point3D)
                Dim ForSplit = Split(item, " ")
                Integer.TryParse(ForSplit(1), NoOfVertices)
                istep = 1
            End If
        Next
        _model.Invalidate()

    End Sub
End Class
