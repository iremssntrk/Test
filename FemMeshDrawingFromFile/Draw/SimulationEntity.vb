
Imports devDept.Eyeshot

Public Class SimulationEntity
    Public Function FindPropertyOfSelected(entities As EntityList) As Panel
        Dim panel As Panel = New Panel
        For Each entity In entities
            If entity.Selected Then
                panel = DirectCast(entity.EntityData, Panel)
            End If
        Next
        Return panel
    End Function
End Class
