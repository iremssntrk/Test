Imports System.Runtime.Remoting
Imports devDept.Eyeshot.Entities
Imports devDept.Eyeshot.Fem
Imports devDept.Geometry
Imports devDept.Geometry.Entities
Imports devDept.Graphics
Imports devDept.Eyeshot
Imports System.Threading
Imports FemMeshDrawingFromFile.MainWindow
Imports System.Globalization

Public Class SimulationClass
    Dim _model As Simulation

    Shared Sub New()
        MyCulture = CultureInfo.InvariantCulture.Clone()
        MyCulture.NumberFormat.NumberDecimalSeparator = "."
    End Sub

    Public Sub New(model As Simulation)
        _model = model
        _model.ActionMode = devDept.Eyeshot.actionType.SelectVisibleByPick
    End Sub
    Public NumberOfPanel As Integer

    Public Shared MyCulture As CultureInfo

    Public Event ProgressChanged(current_val As Integer)

    Public Function Read(path As String) As BlockWrapper
        Dim streamClass As StreamRW = New StreamRW()
        Dim lines = streamClass.FileRead(path).ToList
        Dim istep As Integer

        Dim count = 0

        Dim block = New BlockWrapper

        While count < lines.Count
            Dim pname = lines(count)
            count += 1

            Dim panel = New PanelWrapper()
            panel.Name = pname

            Dim vcount = Convert.ToInt32(lines(count).Split(" ")(1))
            panel.NumberOfVertices = vcount
            count += 1

            For i = 0 To vcount - 1
                Dim vline = lines(count)
                count += 1
                Dim larrary = vline.Split(" ")

                Dim x = Convert.ToDouble(larrary(0), MyCulture)
                Dim y = Convert.ToDouble(larrary(1), MyCulture)
                Dim z = Convert.ToDouble(larrary(2), MyCulture)

                Dim node = New Node(x, y, z)

                If node.X < panel.Min Then
                    panel.Min = node.X
                End If

                If node.X > panel.Max Then
                    panel.Max = node.X
                End If

                node.VonMises = x
                panel.Vertices.Add(node)
            Next

            Dim ecount = Convert.ToInt32(lines(count).Split(" ")(1))
            panel.NumberOfElement = ecount
            count += 1

            For i = 0 To ecount - 1
                Dim eline = lines(count)
                count += 1
                Dim earray = eline.Split(" ")

                If earray.Length = 3 Then
                    Dim i1 = Convert.ToInt32(eline.Split(" ")(0))
                    Dim i2 = Convert.ToInt32(eline.Split(" ")(1))
                    Dim i3 = Convert.ToInt32(eline.Split(" ")(2))

                    Dim tria = New TriaWrapper(i1, i2, i3, panel.Vertices)
                    panel.Elements.Add(tria)
                ElseIf earray.Length = 4 Then
                    Dim i1 = Convert.ToInt32(eline.Split(" ")(0))
                    Dim i2 = Convert.ToInt32(eline.Split(" ")(1))
                    Dim i3 = Convert.ToInt32(eline.Split(" ")(2))
                    Dim i4 = Convert.ToInt32(eline.Split(" ")(3))

                    Dim quad = New QuadWrapper(i1, i2, i3, i4, panel.Vertices)
                    panel.Elements.Add(quad)

                End If
            Next

            block.Panels.Add(panel)

            If panel.Min < block.GlobalMin Then
                block.GlobalMin = panel.Min
            End If
            If panel.Max > block.GlobalMax Then
                block.GlobalMax = panel.Max
            End If
        End While

        Return block
    End Function

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
                        Dim legend = _model.ActiveViewport.Legend
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
