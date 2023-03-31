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
        Dim element As List(Of Integer) = New List(Of Integer)
        Dim panel As Panel
        Dim streamClass As StreamRW = New StreamRW()
        Dim translate As Translate = New Translate()
        Dim triangles As List(Of Element)
        Dim vertices As List(Of Point3D)
        For Each item As String In streamClass.FileRead(path).ToList

            Select Case istep
                Case 0
                    If item.Contains("elements:") Then
                        triangles = New List(Of Element)
                        Dim ForSplit = Split(item, " ")
                        Integer.TryParse(ForSplit(1), panel.Elements)
                        istep = 2
                    ElseIf item.Contains("vertices:") Then
                        vertices = New List(Of Point3D)
                        Dim ForSplit = Split(item, " ")
                        Integer.TryParse(ForSplit(1), panel.Vertices)
                        istep = 1
                    Else
                        panel = New Panel()
                        panel.Name = item
                    End If
                Case 1
                    If (vertices.Count <= panel.Vertices) Then
                        translate.SumVertices(vertices, item)
                    End If
                    If (vertices.Count = panel.Vertices) Then
                        istep = 0
                    End If
                Case 2
                    If (triangles.Count <= panel.Elements) Then
                        translate.SumTriangles(item, triangles, vertices, xMin, xMax)
                    End If
                    If (triangles.Count = panel.Elements) Then
                        Dim mesh As FemMesh = New FemMesh(vertices, triangles)
                        mesh.EntityData = panel
                        mesh.ColorMethod = colorMethodType.byEntity
                        entities.Add(mesh)
                        NumberOfPanel = NumberOfPanel + 1
                        Thread.Sleep(2)
                        RaiseEvent ProgressChanged(NumberOfPanel)
                        istep = 0
                    End If

            End Select

        Next
        '_model.Invalidate()

        Return entities
    End Function
End Class
