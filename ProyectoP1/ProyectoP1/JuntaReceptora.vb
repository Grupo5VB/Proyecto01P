Public Class JuntaReceptora
    Private _numero As Integer
    Property Numero() As Integer
        Get
            Return _numero
        End Get
        Set(value As Integer)
            _numero = value
        End Set
    End Property
    Private _genero As String
    Property Genero() As String
        Get
            Return _genero
        End Get
        Set(value As String)
            _genero = value
        End Set
    End Property

    Private _votantes As ArrayList

End Class
