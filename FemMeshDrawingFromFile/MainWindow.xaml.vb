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
Imports devDept.Graphics

Class MainWindow
    Public Delegate Sub simm(path As String)
    Dim fileSelect As FileSelect
    Dim simulation As SimulationClass
    Dim simulationEntity As SimulationEntity
    Dim _path As String
    Dim findFromEntireFile As FindFromEntireFile
    Dim findPoint As FindPoint

    Public Sub New()
        InitializeComponent()
        fileSelect = New FileSelect()
        simulation = New SimulationClass(sim1)
        findFromEntireFile = New FindFromEntireFile()
        findPoint = New FindPoint()
        AddHandler simulation.ProgressChanged, AddressOf ProgressUpdate
        simulationEntity = New SimulationEntity()
    End Sub


    Private Async Sub Button_Click(sender As Object, e As RoutedEventArgs)
        _path = fileSelect.OpenFile()
        Dim vertices = New List(Of Point3D)
        findFromEntireFile.FindAllVertices(_path, vertices)
        Dim xMin = findPoint.PointXMin(vertices)
        Dim xMax = findPoint.PointXMax(vertices)
        Dim entities As List(Of Entity)
        Dim thread_pars = New ThreadStart(Sub()
                                              entities = simulation.Simulate(_path, Me, xMin, xMax)
                                              Application.Current.Dispatcher.Invoke(
                                                New Action(
                                                Sub()
                                                    sim1.Entities.AddRange(entities)
                                                    sim1.Invalidate()
                                                    Dim legend = sim1.ActiveViewport.Legend
                                                    legend.SetRange(xMin, xMax)
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

    Private Sub sim1_SelectionChanged(sender As Object, e As devDept.Eyeshot.Workspace.SelectionChangedEventArgs) Handles sim1.SelectionChanged
        ObjectPropertyGrid.SelectedObject = simulationEntity.FindPropertyOfSelected(sim1.Entities)
    End Sub

    Private Sub ProgressUpdate(current As Integer)
        ProgressBar.Dispatcher.BeginInvoke(
           Sub()
               Debug.WriteLine("Update called")
               ProgressBar.Value = (100 * simulation.NumberOfPanel) / 1942
           End Sub)
    End Sub
End Class




