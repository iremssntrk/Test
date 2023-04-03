Public Class BlockWrapper
    Public Sub New()
        Panels = New List(Of PanelWrapper)
    End Sub

    Public Panels As List(Of PanelWrapper)


    Public GlobalMin As Double = Double.MaxValue

    Public GlobalMax As Double = Double.MinValue
End Class
