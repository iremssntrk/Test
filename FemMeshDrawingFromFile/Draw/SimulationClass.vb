Imports System.Runtime.Remoting
Imports devDept.Eyeshot.Entities
Imports devDept.Eyeshot.Fem
Imports devDept.Geometry
Imports devDept.Geometry.Entities
Imports devDept.Graphics
Imports devDept.Eyeshot
Imports System.Threading

Public Class SimulationClass
    Dim _model As Simulation
    Public Sub New(model As Simulation)
        _model = model
        _model.ActionMode = devDept.Eyeshot.actionType.SelectVisibleByPick
    End Sub
    Public NumberOfPanel As Integer

    Public Event ProgressChanged(current_val As Integer)

    Function Simulate(path As String, mw As MainWindow, xMin As Double, xMax As Double) As List(Of Entity)
        Dim entities = New List(Of Entity)
        Dim istep As Integer
        Dim Mat As Material = New Material("steel")
        Dim element As List(Of Integer) = New List(Of Integer)
        Dim count As Integer
        Dim count2 As Integer
        Dim NoOfVertices As Integer
        Dim NoOfElement As Integer
        Dim Name As String
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
                translate.SumTriangles(Mat, item, triangles, vertices, xMin, xMax)
                count = count + 1
            ElseIf (istep = 2) And (count = NoOfElement) Then
                istep = 0
                count = 0
                Dim mesh As FemMesh = New FemMesh(vertices, triangles)
                Dim panel As Panel = New Panel()
                panel.Name = Name
                panel.Elements = NoOfElement
                panel.Vertices = NoOfVertices
                mesh.EntityData = panel
                mesh.ColorMethod = colorMethodType.byEntity
                entities.Add(mesh)
                NumberOfPanel = NumberOfPanel + 1
                Thread.Sleep(2)
                RaiseEvent ProgressChanged(NumberOfPanel)
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
            If (istep = 0) Then
                Name = item
            End If

        Next
        '_model.Invalidate()

        Return entities
    End Function
End Class
