
Imports devDept.Eyeshot
Imports devDept.Eyeshot.Entities

Public Class SimulationEntity
    Public Function FindPropertyOfSelected(entities As EntityList) As Panel
        Dim panel As Panel = New Panel()
        Dim panelWrap As PanelWrapper = New PanelWrapper()
        For Each entity In entities
            If entity.Selected Then
                panelWrap = DirectCast(entity.EntityData, PanelWrapper)
                panel.Name = panelWrap.Name
                panel.Vertices = panelWrap.NumberOfVertices
                panel.Elements = panelWrap.NumberOfElement
            End If
        Next
        Return panel
    End Function
End Class
