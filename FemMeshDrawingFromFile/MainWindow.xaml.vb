Imports System.Collections.ObjectModel
Imports System.Runtime.Remoting
Imports System.Threading
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Threading
Imports devDept.Eyeshot
Imports devDept.Eyeshot.Entities
Imports devDept.Eyeshot.Fem
Imports devDept.Geometry
Imports devDept.Geometry.ConstraintSolver
Imports devDept.Geometry.Entities
Imports devDept.Geometry.Triangulation
Imports devDept.Graphics

Class MainWindow
    Public Delegate Sub simm(path As String)
    Dim fileSelect As FileSelect
    Dim simulation As SimulationClass
    Dim simulationEntity As SimulationEntity
    Dim _path As String
    Dim findFromEntireFile As FindFromEntireFile
    Dim findPoint As FindPoint

    Dim _block As BlockWrapper

    Private _colortable As List(Of System.Windows.Media.Color)

    Private _alpha As Byte = 255

    Public Sub New()
        InitializeComponent()
        _colortable = CreateColorTable()
        fileSelect = New FileSelect()
        simulation = New SimulationClass(sim1)
        findFromEntireFile = New FindFromEntireFile()
        findPoint = New FindPoint()
        AddHandler simulation.ProgressChanged, AddressOf ProgressUpdate
        simulationEntity = New SimulationEntity()
    End Sub


    Private Async Sub Button_Click(sender As Object, e As RoutedEventArgs)
        _path = fileSelect.OpenFile()


        _block = simulation.Read(_path)
        Debug.WriteLine("Block created")
        'Plot()
        Return


        Dim vertices = New List(Of Point3D)
        findFromEntireFile.FindAllVertices(_path, vertices)
        Dim xMin = findPoint.PointXMin(vertices)
        Dim xMax = findPoint.PointXMax(vertices)
        Dim entities As List(Of Entity)
        Dim thread_pars = New ThreadStart(Sub()
                                              entities = simulation.Simulate(_path, Me, xMin, xMin)
                                              Application.Current.Dispatcher.Invoke(
                                                New Action(
                                                Sub()
                                                    sim1.Entities.AddRange(entities)
                                                    sim1.Invalidate()
                                                    Dim legend = sim1.ActiveViewport.Legend
                                                    legend.SetRange(xMin, xMax)



                                                    'Dim elobscol = New ObservableCollection(Of Brush)
                                                    'For i = 0 To shellcolors.Count - 1
                                                    '    Dim scbrush = New SolidColorBrush(shellcolors(i))
                                                    '    elobscol.Add(scbrush)
                                                    'Next


                                                    'legend.ColorTable(elobscol)




                                                End Sub))
                                          End Sub)

        Dim process = New Thread(thread_pars)
        process.Start()
        'Task.WaitAll(simulate_task)

        'Dim entities = simulate_task.Result

        'Application.Current.Dispatcher.Invoke(
        '    New Action(
        '    Sub()
        '        sim1.Entities.AddRange(entities)
        '    End Sub))
    End Sub

    Private Shared Function CreateColorTable()
        Dim colortable = New List(Of System.Windows.Media.Color)
        Dim alpha = 255
        For i = 0 To 255
            colortable.Add(System.Windows.Media.Color.FromArgb(alpha, 0, i, 255))
        Next
        For i = 1 To 255
            colortable.Add(System.Windows.Media.Color.FromArgb(alpha, 0, 255, 255 - i))
        Next
        For i = 1 To 255
            colortable.Add(System.Windows.Media.Color.FromArgb(alpha, i, 255, 0))
        Next
        For i = 1 To 255
            colortable.Add(System.Windows.Media.Color.FromArgb(alpha, 255, 255 - i, 0))
        Next
        Return colortable
    End Function

    Private Function GetColorRange(localmin As Double, localmax As Double, globalmin As Double, globalmax As Double) As List(Of Color)
        Dim localcolortable = New List(Of Color)
        Dim limitedcolortable = New List(Of Color)
        Dim colorstep = 1
        Dim cumindex = 0.0

        Dim tol = cumindex - (_colortable.Count - 1)

        While Math.Abs(tol) > Math.Pow(10, -6)
            Dim rndinx = CType(Math.Round(cumindex, 0), Integer)
            limitedcolortable.Add(_colortable(rndinx))
            cumindex += colorstep
            tol = cumindex - (_colortable.Count - 1)
        End While

        If Not limitedcolortable.Contains(_colortable.Last()) Then
            limitedcolortable.Add(_colortable.Last())
        End If

        Dim maxcolortableindex = limitedcolortable.Count - 1
        If localmin = 0 And localmax = 0 Then
            If globalmin = globalmax Then
                localcolortable.Add(limitedcolortable.First())
            Else
                Dim index = (0 - globalmin) / (globalmax - globalmin) * (maxcolortableindex - 0)
                Dim rndindex = CType(Math.Round(index, 0), Integer)
                localcolortable.Add(limitedcolortable(rndindex))
            End If
        ElseIf globalmax = globalmin Then
            If globalmax > 0 Then
                localcolortable.Add(limitedcolortable.Last())
            Else
                localcolortable.Add(limitedcolortable(0))
            End If
        Else
            Dim minindexval = maxcolortableindex - (globalmax - localmin) / (globalmax - globalmin) * (maxcolortableindex - 0)
            Dim minindex = CType(Math.Round(minindexval, 0), Integer)
            Dim maxindexval = maxcolortableindex - (globalmax - localmax) / (globalmax - globalmin) * (maxcolortableindex - 0)
            Dim maxindex = CType(Math.Round(maxindexval, 0), Integer)

            For i As Integer = minindex To maxindex
                localcolortable.Add(limitedcolortable(i))
            Next
        End If
        Return localcolortable
    End Function

    Private Sub Plot()
        sim1.Entities.Clear()
        Select Case PlotTypeCbx.SelectedIndex
            Case 0
                'Nodal Plot
                Dim mat = New Material("Steel", System.Drawing.Color.Gray)
                Dim legend = sim1.ActiveViewport.Legends(0)
                legend.IsSlave = False



                Dim paneldict = New Dictionary(Of PanelWrapper, FemMesh)
                Dim count = 0

                For Each panel In _block.Panels
                    Debug.WriteLine($"Creating femmesh for panel: {panel.Name}, count = {count}")
                    count += 1
                    Dim elements = New List(Of Element)
                    For i = 0 To panel.Elements.Count - 1
                        Select Case panel.Elements(i).GetType()
                            Case GetType(TriaWrapper)
                                Dim twrapper = DirectCast(panel.Elements(i), TriaWrapper)
                                Dim tria = New Tria3Element(twrapper.I1, twrapper.I2, twrapper.I3, mat, panel.Vertices)
                                elements.Add(tria)

                            Case GetType(QuadWrapper)
                                Dim qwrapper = DirectCast(panel.Elements(i), QuadWrapper)
                                Dim quad = New Quad4Element(qwrapper.I1, qwrapper.I2, qwrapper.I3, qwrapper.I4, mat, panel.Vertices)
                                elements.Add(quad)
                        End Select
                    Next

                    Dim femmesh = New FemMesh(panel.Vertices, elements)
                    femmesh.ColorMethod = colorMethodType.byEntity
                    femmesh.EntityData = panel
                    femmesh.Color = System.Drawing.Color.FromArgb(_alpha, System.Drawing.Color.Gray)
                    paneldict.Add(panel, femmesh)
                    sim1.Entities.Add(femmesh)
                Next

                count = 0
                For Each pditem In paneldict
                    Dim panelwrapper = pditem.Key
                    Debug.WriteLine($"Nodal plotting femmesh for panel: {panelwrapper.Name}, count= {count}")
                    count += 1

                    Dim femmesh = pditem.Value

                    Dim limited_color_table = GetColorRange(panelwrapper.Min, panelwrapper.Max, _block.GlobalMin, _block.GlobalMax)

                    Dim elobscol = New ObservableCollection(Of Brush)
                    For i = 0 To limited_color_table.Count - 1
                        Dim scbrush = New SolidColorBrush(limited_color_table(i))
                        elobscol.Add(scbrush)
                    Next

                    legend.ColorTable = elobscol
                    legend.SetRange(panelwrapper.Min, panelwrapper.Max)

                    femmesh.ContourPlot = True
                    femmesh.PlotMode = FemMesh.plotType.VonMises
                    femmesh.ComputePlot(sim1, legend, True)
                Next

                Debug.WriteLine("Nodal plot completed")
            Case 1
                'Elementer plot
                Dim normals As List(Of Vector3D) = New List(Of Vector3D)()
                For Each panel In _block.Panels
                    Debug.WriteLine($"Creating elemanter drawing for panel: {panel.Name}")
                    Dim elements = New List(Of Element)
                    For i = 0 To panel.Elements.Count - 1
                        Select Case panel.Elements(i).GetType()
                            Case GetType(TriaWrapper)
                                Dim twrapper = DirectCast(panel.Elements(i), TriaWrapper)
                                Dim matindex = GetIndex(twrapper.Center.X, _block.GlobalMin, _block.GlobalMax, _colortable)

                                Dim r = _colortable(matindex).R
                                Dim g = _colortable(matindex).G
                                Dim b = _colortable(matindex).B

                                Dim mat = New Material("Steel", System.Drawing.Color.FromArgb(255, r, g, b))
                                Dim tria = New Tria3Element(twrapper.I1, twrapper.I2, twrapper.I3, mat, panel.Vertices)
                                elements.Add(tria)

                                Dim diff As Vector3D = Vector3D.Subtract(panel.Vertices(i + 2), panel.Vertices(i))
                                Dim diff2 As Vector3D = Vector3D.Subtract(panel.Vertices(i + 1), panel.Vertices(i))
                                Dim normal As Vector3D = Vector3D.Cross(diff, diff2)
                                panel.Normal = normal
                                normal.Normalize()

                            Case GetType(QuadWrapper)

                                Dim qwrapper = DirectCast(panel.Elements(i), QuadWrapper)
                                Dim matindex = GetIndex(qwrapper.Center.X, _block.GlobalMin, _block.GlobalMax, _colortable)

                                Dim r = _colortable(matindex).R
                                Dim g = _colortable(matindex).G
                                Dim b = _colortable(matindex).B

                                Dim mat = New Material("Steel", System.Drawing.Color.FromArgb(255, r, g, b))

                                Dim quad = New Quad4Element(qwrapper.I1, qwrapper.I2, qwrapper.I3, qwrapper.I4, mat, panel.Vertices)

                                elements.Add(quad)


                                Dim diff As Vector3D = Vector3D.Subtract(panel.Vertices(i + 1), panel.Vertices(i))
                                Dim diff2 As Vector3D = Vector3D.Subtract(panel.Vertices(i + 2), panel.Vertices(i))
                                Dim normal As Vector3D = Vector3D.Cross(diff, diff2)
                                panel.Normal = normal
                                normal.Normalize()
                                normals.Add(normal)

                        End Select
                    Next

                    Dim femmesh = New FemMesh(panel.Vertices, elements)

                    femmesh.ColorMethod = colorMethodType.byEntity
                    femmesh.EntityData = panel
                    femmesh.Color = System.Drawing.Color.FromArgb(_alpha, System.Drawing.Color.Gray)
                    sim1.Entities.Add(femmesh)
                Next
                Debug.WriteLine("Elemanter plot completed")
        End Select

        sim1.Invalidate()
        sim1.ZoomFit()
    End Sub

    Private Sub sim1_SelectionChanged(sender As Object, e As devDept.Eyeshot.Workspace.SelectionChangedEventArgs) Handles sim1.SelectionChanged
        ObjectPropertyGrid.SelectedObject = simulationEntity.FindPropertyOfSelected(sim1.Entities)
    End Sub

    Private Shared Function GetIndex(elval As Double, minval As Double, maxval As Double, colortable As List(Of Color)) As Integer
        If minval = 0 And maxval = 0 Then
            Return 0
        ElseIf minval = maxval Then
            Return 0
        Else
            Return CInt(Math.Round(colortable.Count - 1 - (colortable.Count - 1) * (maxval - elval) / (maxval - minval), 0))
        End If
    End Function

    Private Sub ProgressUpdate(current As Integer)
        ProgressBar.Dispatcher.BeginInvoke(
           Sub()
               Debug.WriteLine("Update called")
               ProgressBar.Value = (100 * simulation.NumberOfPanel) / 1942
           End Sub)
    End Sub

    Private Sub PlotTypeCbx_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles PlotTypeCbx.SelectionChanged
        Debug.WriteLine("Plot type selection changed")

    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        If _block IsNot Nothing Then
            Plot()
        End If
    End Sub


End Class




