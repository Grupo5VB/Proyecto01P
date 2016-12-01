Public Class RecintoElectoral
    Private _nombre As String
    Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property
    Private _direccion As String
    Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(value As String)
            _direccion = value
        End Set
    End Property
    Private _provincia As String
    Property Provincia() As String
        Get
            Return _provincia
        End Get
        Set(value As String)
            _provincia = value
        End Set
    End Property
    Private _canton As String
    Property Canton() As String
        Get
            Return _canton
        End Get
        Set(value As String)
            _canton = value
        End Set
    End Property
    Private _parroquia As String
    Property Parroquia() As String
        Get
            Return _parroquia
        End Get
        Set(value As String)
            _parroquia = value
        End Set
    End Property
    Private _zona As String
    Property Zona() As String
        Get
            Return _zona
        End Get
        Set(value As String)
            _zona = value
        End Set
    End Property
    Private _recintos As ArrayList
End Class
