Public Class Candidato
    Inherits Usuario

    Private _usuario As String
    Public Property Usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property

    Private _clave As String
    Public Property clave() As String
        Get
            Return _clave
        End Get
        Set(ByVal value As String)
            _clave = value
        End Set
    End Property

    Private _orgPolitica As String
    Public Property OrgPolitica() As String
        Get
            Return _orgPolitica
        End Get
        Set(ByVal value As String)
            _orgPolitica = value
        End Set
    End Property

    Private _dignidad As String
    Public Property Dignidad() As String
        Get
            Return _dignidad
        End Get
        Set(ByVal value As String)
            _dignidad = value
        End Set
    End Property

End Class
