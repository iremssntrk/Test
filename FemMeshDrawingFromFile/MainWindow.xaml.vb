Imports System.Runtime.Remoting
Imports devDept.Eyeshot.Entities
Imports devDept.Eyeshot.Fem
Imports devDept.Geometry
Imports devDept.Geometry.Entities
Imports devDept.Graphics

Class MainWindow

    Dim fileSelect As FileSelect
    Dim simulation As SimulationClass
    Dim Path As String
    Public Sub New()
        InitializeComponent()
        fileSelect = New FileSelect()
        simulation = New SimulationClass(sim1)
    End Sub


    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim _path = fileSelect.OpenFile()
        simulation.Simulate(_path)
    End Sub

End Class

