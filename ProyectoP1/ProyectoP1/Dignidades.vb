Public Class Dignidades
    Private _codigoDignidad As String
    Public Property codigoDignidad() As String
        Get
            Return _codigoDignidad
        End Get
        Set(ByVal value As String)
            _codigoDignidad = value
        End Set
    End Property

    Private _nombreDignidad As String
    Public Property nombreDignidad() As String
        Get
            Return _nombreDignidad
        End Get
        Set(ByVal value As String)
            _nombreDignidad = value
        End Set
    End Property
End Class
