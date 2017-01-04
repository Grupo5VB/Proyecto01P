Imports System.Xml
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

    Public Function GenerarDignidad(xmlDoc As XmlDocument, id As String, nombre As String)
        Dim dig As XmlElement = xmlDoc.CreateElement("dignidad")
        dig.SetAttribute("id", id)
        dig.SetAttribute("nombre", nombre)
        Dim lista As XmlElement = xmlDoc.CreateElement("lista6")
        lista.InnerText = "0"
        dig.AppendChild(lista)
        Dim lista1 As XmlElement = xmlDoc.CreateElement("lista21-23")
        lista1.InnerText = "0"
        dig.AppendChild(lista1)
        Dim lista2 As XmlElement = xmlDoc.CreateElement("lista10")
        lista2.InnerText = "0"
        dig.AppendChild(lista2)
        Dim lista3 As XmlElement = xmlDoc.CreateElement("lista35")
        lista3.InnerText = "0"
        dig.AppendChild(lista3)
        Dim lista4 As XmlElement = xmlDoc.CreateElement("nulo")
        lista4.InnerText = "0"
        dig.AppendChild(lista4)
        Dim lista5 As XmlElement = xmlDoc.CreateElement("blanco")
        lista5.InnerText = "0"
        dig.AppendChild(lista5)
        Console.WriteLine("Nueva dignidad generada con exito.")
        Return dig
    End Function
    Public Sub AgregarDignidad(ruta As String)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(ruta)
        Dim id, nombre As String
        Console.Clear()
        Console.WriteLine("Ingrese el código de la dignidad: ")
        id = Console.ReadLine()
        Console.WriteLine("Ingrese el nombre de la dignidad: ")
        nombre = Console.ReadLine()
        Dim collection As XmlNode = xmlDoc.GetElementsByTagName("sistema").Item(0)
        collection.AppendChild(GenerarDignidad(xmlDoc, id, nombre))
        xmlDoc.Save(ruta)
    End Sub
End Class
