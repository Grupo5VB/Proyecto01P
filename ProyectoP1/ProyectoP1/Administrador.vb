Public Class Administrador
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

End Class
