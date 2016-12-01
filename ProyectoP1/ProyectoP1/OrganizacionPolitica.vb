Public Class OrganizacionPolitica
    Private _nombre As String
    Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property
    Private _siglas As String
    Property Siglas() As String
        Get
            Return _siglas
        End Get
        Set(value As String)
            _siglas = value
        End Set
    End Property
    Private _candidatos As ArrayList
End Class
