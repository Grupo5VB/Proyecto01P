Public Class Estadistica
    Private _totalVotos As Integer
    Public Property totalVotos() As Integer
        Get
            Return _totalVotos
        End Get
        Set(ByVal value As Integer)
            _totalVotos = value
        End Set
    End Property

    Private _votosValidos As Integer
    Public Property votosValidos() As Integer
        Get
            Return _votosValidos
        End Get
        Set(ByVal value As Integer)
            _votosValidos = value
        End Set
    End Property

    Private _votosNulos As Integer
    Public Property votosNulos() As Integer
        Get
            Return _votosNulos
        End Get
        Set(ByVal value As Integer)
            _votosNulos = value
        End Set
    End Property

    Private _votosBlancos As Integer
    Public Property votosBlancos() As Integer
        Get
            Return _votosBlancos
        End Get
        Set(ByVal value As Integer)
            _votosBlancos = value
        End Set
    End Property
End Class
