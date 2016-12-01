Public Class EmisionVoto
    Private _numCertficado As String
    Public Property numCertificado() As String
        Get
            Return _numCertficado
        End Get
        Set(ByVal value As String)
            _numCertficado = value
        End Set
    End Property
End Class
