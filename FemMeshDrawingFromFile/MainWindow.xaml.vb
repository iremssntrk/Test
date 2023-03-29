Imports System.Runtime.Remoting
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports devDept.Eyeshot
Imports devDept.Eyeshot.Entities
Imports devDept.Eyeshot.Fem
Imports devDept.Geometry
Imports devDept.Geometry.ConstraintSolver
Imports devDept.Geometry.Entities
Imports devDept.Graphics

Class MainWindow

    Dim fileSelect As FileSelect
    Dim simulation As SimulationClass
    Dim simulationEntity As SimulationEntity
    Dim Path As String
    Public Sub New()
        InitializeComponent()
        fileSelect = New FileSelect()
        simulation = New SimulationClass(sim1)
        simulationEntity = New SimulationEntity()
    End Sub


    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim _path = fileSelect.OpenFile()
        simulation.Simulate(_path)
    End Sub

    Private Sub sim1_SelectionChanged(sender As Object, e As devDept.Eyeshot.Workspace.SelectionChangedEventArgs) Handles sim1.SelectionChanged
        ObjectPropertyGrid.SelectedObject = simulationEntity.FindPropertyOfSelected(sim1.Entities)
    End Sub
End Class







