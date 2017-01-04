Imports System.Xml

Module Module1

    Dim op As String = ""
    Dim opcion As Byte
    Const LOGIN As Byte = 1
    Const SINGIN As Byte = 2
    Const CHPASSWORD As Byte = 3
    Const OUT As Byte = 4

    Dim cedula As String
    Dim usuarioCand As String
    Dim claveCand As String
    Dim idCand As String


    Dim binomios As New ArrayList()
    Dim concejales As New ArrayList()
    Dim alcaldes As New ArrayList()

    Dim votoTemp As New ArrayList()

    Dim votosBinomio As New ArrayList()
    Dim votosConcejal As New ArrayList()
    Dim votosAlcalde As New ArrayList()


    Dim ruta = "C:\Users\Galo\Source\Repos\Proyecto01P\ProyectoP1\SistVotoElectronico.xml"
    ''Dim ruta = "C:\Users\Olguis\Source\Repos\Proyecto01P16\ProyectoP1\SistVotoElectronico.xml"

    Dim xmlDoc As New XmlDocument()


    Enum OpMain  'sucesivo o consecutivo
        Invalid
        Votante
        Candidato
        Admin
        Out
    End Enum

    Enum OpMainAdm
        Invalid
        Dignidades
        Candidatos
        Estadisticas
        Out
    End Enum

    Sub Main()
        xmlDoc.Load(ruta)
        CargarCandidatos(xmlDoc)
        Console.Title = "SISTEMA VOTO ELECTRONICO"
        Console.WriteLine(vbTab & vbTab & "  SISTEMA VOTO ELECTRÓNICO" & vbCrLf)
        Do
            MenuPrincipal()
            op = Console.ReadLine()
            Try
                opcion = CByte(op) 'Byte.Parse()
            Catch ex As OverflowException
                opcion = OpMainAdm.Invalid
            End Try

            'opcion = CByte(op) 'Byte.Parse()
            'Console.WriteLine("Ud ha ingresado: {0}", op)

            Select Case opcion
                Case OpMain.Votante
                    Console.WriteLine("Votante")
                    MenuLogVotante(xmlDoc)
                Case OpMain.Candidato
                    Console.WriteLine("Candidato")
                    MenuLogCandidato(xmlDoc)
                Case OpMain.Admin
                    Console.WriteLine("Administrador")
                    IngresoAdministrador()
                Case OpMain.Out
                    Console.WriteLine("Cerrando aplicación")
                Case Else
                    Console.WriteLine("**** OPCION INVALIDA: [{0}]", opcion)
            End Select

            Console.ReadLine()
        Loop Until opcion = OUT
        Console.WriteLine("Saliendo del Sistema")
        Console.ReadLine()

    End Sub

    Private Sub CargarCandidatos(xmlDoc As XmlDocument)
        Dim raiz As XmlNodeList = xmlDoc.GetElementsByTagName("sistema")
        For Each nodo As XmlNode In raiz
            For Each registro As XmlNode In nodo.ChildNodes
                For Each usuarios As XmlNode In registro.ChildNodes
                    For Each usuario As XmlNode In usuarios
                        If usuario.Name = "candidato" Then
                            Select Case usuario.Attributes(1).Value
                                Case "presi"
                                    Dim bin As New Candidato(usuario.Attributes(3).Value, usuario.InnerText)
                                    binomios.Add(bin)
                                Case "vice"
                                    Dim bin As New Candidato(usuario.Attributes(3).Value, usuario.InnerText)
                                    binomios.Add(bin)
                                Case "conc"
                                    Dim bin As New Candidato(usuario.Attributes(3).Value, usuario.InnerText)
                                    concejales.Add(bin)
                                Case "alcalde"
                                    Dim bin As New Candidato(usuario.Attributes(3).Value, usuario.InnerText)
                                    alcaldes.Add(bin)
                            End Select
                        End If
                    Next
                Next
            Next
        Next
    End Sub

    Private Sub IngresoAdministrador()
        Dim usuario As String
        Dim contraseña As String
        Console.Clear()
        Console.WriteLine(vbTab & "INICIAR SESION ADMINISTRADOR " & vbCrLf)
        Console.Write(" INGRESE SU USUARIO : " & vbTab)
        usuario = Console.ReadLine()
        Console.Write(" INGRESE SU PASSWORD : " & vbTab)
        contraseña = Console.ReadLine()
        Dim raiz As XmlNodeList = xmlDoc.GetElementsByTagName("sistema")
        For Each nodo As XmlNode In raiz
            For Each registro As XmlNode In nodo.ChildNodes
                For Each usuarios As XmlNode In registro.ChildNodes
                    For Each candidatos As XmlNode In usuarios
                        If candidatos.Name = "administrador" Then
                            If candidatos.Attributes(1).Value = usuario And candidatos.Attributes(2).Value = contraseña Then
                                MenuAdministrador()
                            Else
                                Console.WriteLine("Administrador no registrado")
                            End If
                        End If
                        Exit For
                    Next
                Next
            Next
        Next

    End Sub

    Private Sub MenuAdministrador()
        Console.Clear()
        Console.WriteLine(vbTab & "MENU ADMINISTRADOR " & vbCrLf)
        Console.WriteLine(vbTab & vbTab & "{0}. ADMINISTRAR DIGNIDADES", LOGIN)
        Console.WriteLine(vbTab & vbTab & "{0}. ADMINISTRAR CANDIDATOS", SINGIN)
        Console.WriteLine(vbTab & vbTab & "{0}. ESTADISTICAS", CHPASSWORD)
        Console.WriteLine(vbTab & vbTab & "{0}. CERRAR SECCION", OUT)
        Console.Write(vbCrLf & "ESCOGA 1 OPCIÓN : ")

        Do
            op = Console.ReadLine()
            Try
                opcion = CByte(op) 'Byte.Parse()
            Catch ex As OverflowException
                opcion = OpMainAdm.Invalid
            End Try

            'opcion = CByte(op) 'Byte.Parse()
            Console.WriteLine("Ud ha ingresado: {0}", op)

            Select Case opcion
                Case OpMainAdm.Dignidades
                    Console.WriteLine("ADMINISTRAR DIGNIDADES")
                    MenuAdmDignidades()
                Case OpMainAdm.Candidatos
                    Console.WriteLine("ADMINISTRAR CANDIDATOS")
                    MenuAdmCandidatos()
                Case OpMainAdm.Estadisticas
                    Console.WriteLine("ESTADISTICAS")
                    MenuAdmEstadisticas()
                Case OpMainAdm.Out
                    'Console.WriteLine("Volviendo al menu principal")
                    Console.Clear()
                    MenuPrincipal()
                Case Else
                    Console.WriteLine("**** OPCION INVALIDA: [{0}]", opcion)
            End Select

            Console.ReadLine()
        Loop Until opcion = OUT
    End Sub

    Private Sub MenuLogCandidato(xmlDoc As XmlDocument)
        Console.Clear()
        Console.WriteLine(vbTab & "INICIAR SESION CANDIDATO " & vbCrLf)
        Console.Write(" INGRESE SU USUARIO : " & vbTab)
        usuarioCand = Console.ReadLine()
        Console.Write(" INGRESE SU PASSWORD : " & vbTab)
        claveCand = Console.ReadLine()
        Dim raiz As XmlNodeList = xmlDoc.GetElementsByTagName("sistema")
        For Each nodo As XmlNode In raiz
            For Each registro As XmlNode In nodo.ChildNodes
                For Each usuarios As XmlNode In registro.ChildNodes
                    For Each candidatos As XmlNode In usuarios
                        If candidatos.Name = "candidato" Then
                            If candidatos.Attributes(1).Value = usuarioCand And candidatos.Attributes(2).Value = claveCand Then
                                idCand = candidatos.Attributes(0).Value
                                MenuCandidatos()
                            Else
                                Console.WriteLine("Candidato no registrado")
                            End If
                        End If
                        'Exit For
                    Next
                Next
            Next
        Next
    End Sub

    Sub MenuCandidatos()
        Console.Clear()
        Console.WriteLine(vbTab & vbTab & "  SISTEMA VOTO ELECTRÓNICO" & vbCrLf)
        Console.WriteLine(vbTab & vbTab & "  CANDIDATOS" & vbCrLf)
        Console.WriteLine("OPCIÓN 1. MOSTRAR RESULTADOS" & vbCrLf)
        Console.WriteLine("OPCIÓN 2. SALIR" & vbCrLf)
        Console.Write(vbCrLf & "ESCOGA 1 OPCIÓN : ")
        opcion = Console.ReadLine()
        If opcion = 1 Then
            mostrarResulCand(xmlDoc)
        Else
            Console.WriteLine(vbTab & vbTab & "Regresando al Menú Principal...")
            Console.ReadLine()
            MenuPrincipal()
        End If

    End Sub

    Sub mostrarResulCand(xmlDoc As XmlDocument)
        Console.Clear()
        Dim raiz As XmlNodeList = xmlDoc.GetElementsByTagName("sistema")
        For Each nodo As XmlNode In raiz
            For Each dignidades As XmlNode In nodo.ChildNodes
                For Each dignidad As XmlNode In dignidades
                    If dignidad.Name = "dignidad" Then
                        If dignidad.Attributes(0).Value = idCand Then
                            Console.WriteLine(dignidad.Name & ": " & dignidad.Attributes(1).Value)
                            For Each ListDignidades As XmlNode In dignidad.ChildNodes
                                Console.WriteLine(ListDignidades.Name & ": " & ListDignidades.InnerText)
                            Next
                        End If
                    End If
                Next
            Next
        Next
        Console.WriteLine(vbTab & vbTab & "Regresando al Menú Candidato...")
        Console.ReadLine()
        MenuCandidatos()
    End Sub

    Sub MenuPrincipal()
        Console.Clear()
        Console.WriteLine(vbTab & vbTab & "  SISTEMA VOTO ELECTRÓNICO" & vbCrLf)
        Console.WriteLine("INGRESAR COMO: " & vbCrLf & vbCrLf)
        Console.WriteLine(vbTab & vbTab & "{0}. Votante", LOGIN)
        Console.WriteLine(vbTab & vbTab & "{0}. Candidato", SINGIN)
        Console.WriteLine(vbTab & vbTab & "{0}. Administrador", CHPASSWORD)
        Console.WriteLine(vbTab & vbTab & "{0}. Salir", OUT)
        Console.Write(vbCrLf & "ESCOGA 1 OPCIÓN : ")
    End Sub

    Sub MenuLogVotante(xmlDoc As XmlDocument)
        ''Dim cedula As String
        Console.Clear()
        Console.WriteLine(vbTab & "INICIAR SESION VOTANTE " & vbCrLf)
        Console.Write(" INGRESE SU NÚMERO DE CÉDULA : " & vbTab)
        cedula = Console.ReadLine()
        Dim raiz As XmlNodeList = xmlDoc.GetElementsByTagName("sistema")
        For Each nodo As XmlNode In raiz
            For Each registro As XmlNode In nodo.ChildNodes
                For Each usuarios As XmlNode In registro.ChildNodes
                    For Each votante As XmlNode In usuarios
                        If votante.Name = "votante" Then
                            If votante.Attributes(0).Value = cedula Then
                                If votante.Attributes(1).Value = "no" Then
                                    MenuCandPresi()
                                    Exit For
                                Else
                                    Console.WriteLine("El votante ya sufragó")
                                    Console.WriteLine(" ")
                                    Exit For
                                End If
                            Else
                                Console.WriteLine(" ")
                                Console.WriteLine("Ingrese un número de cédula válido...")
                                ''Exit For
                            End If
                        End If
                    Next
                Next
            Next
        Next
    End Sub

    Sub MenuCandPresi()
        Dim lista As String = ""
        Dim opMenu As Integer = 1
        votoTemp.Clear()
        Console.Clear()
        Console.WriteLine(vbTab & vbTab & vbTab & "  SISTEMA VOTO ELECTRÓNICO" & vbCrLf)
        Console.WriteLine(vbTab & vbTab & "  CANDIDATOS A PRESIDENTE Y VICEPRESIDENTE" & vbCrLf)
        For Each bin As Candidato In binomios
            If lista = bin.OrgPolitica Then
                Console.WriteLine(vbTab & "Vicepresidente: " & bin.Nombres & vbCrLf)
            Else
                lista = bin.OrgPolitica
                Console.WriteLine("Opción " & opMenu & " : " & " Lista " & lista & vbCrLf & vbTab & "Presidente: " & bin.Nombres)
                opMenu += 1
            End If
        Next
        Console.WriteLine("OPCIÓN 5. Voto Nulo" & vbCrLf)
        Console.WriteLine("OPCIÓN 6. Voto Blanco" & vbCrLf)
        Try
            Do
                Console.Write(vbCrLf & "ESCOGA 1 OPCIÓN : ")
                opcion = Console.ReadLine()
            Loop While opcion > 6
        Catch ex As OverflowException
            Console.WriteLine("La opción no es correcta")
        End Try
        votoTemp.Add(opcion)
        MenuCandConcejal()
    End Sub

    Sub MenuCandConcejal()
        Dim opMenu As Integer = 1
        Console.Clear()
        Console.WriteLine(vbTab & vbTab & "  SISTEMA VOTO ELECTRÓNICO" & vbCrLf)
        Console.WriteLine(vbTab & vbTab & "  CANDIDATOS A CONCEJALES" & vbCrLf)
        For Each conc As Candidato In concejales
            Console.WriteLine("Opción " & opMenu & " : " & " Lista " & conc.OrgPolitica & vbCrLf & vbTab & "Nombre: " & conc.Nombres & vbCrLf)
            opMenu += 1
        Next
        Console.WriteLine("OPCIÓN 5. Voto Nulo" & vbCrLf)
        Console.WriteLine("OPCIÓN 6. Voto Blanco" & vbCrLf)
        Try
            Do
                Console.Write(vbCrLf & "ESCOGA 1 OPCIÓN : ")
                opcion = Console.ReadLine()
            Loop While opcion > 6
        Catch ex As OverflowException
            Console.WriteLine("La opción no es correcta")
        End Try
        votoTemp.Add(opcion)
        MenuCandAlcalde()

    End Sub

    Sub MenuCandAlcalde()
        Dim opMenu As Integer = 1
        Dim validacion As Integer
        Console.Clear()
        Console.WriteLine(vbTab & vbTab & "  SISTEMA VOTO ELECTRÓNICO" & vbCrLf)
        Console.WriteLine(vbTab & vbTab & "  CANDIDATOS A ALCALDE" & vbCrLf)

        For Each alca As Candidato In alcaldes
            Console.WriteLine("Opción " & opMenu & " : " & " Lista " & alca.OrgPolitica & vbCrLf & vbTab & "Nombre: " & alca.Nombres & vbCrLf)
            opMenu += 1
        Next
        Console.WriteLine("OPCIÓN 5. Voto Nulo" & vbCrLf)
        Console.WriteLine("OPCIÓN 6. Voto Blanco" & vbCrLf)
        Try
            Do
                Console.Write(vbCrLf & "ESCOGA 1 OPCIÓN : ")
                opcion = Console.ReadLine()
            Loop While opcion > 6
        Catch ex As OverflowException
            Console.WriteLine("La opción no es correcta")
        End Try
        votoTemp.Add(opcion)
        Console.WriteLine("Validación de voto:  ")
        Console.WriteLine("Todos los datos son correctos?")
        Console.WriteLine("Si son correctos PRESIONE ( 1 ) para imprimir su voto, si no son correctos PRESIONE ( 2 ) para volver a votar.")
        validacion = Console.ReadLine()
        Select Case validacion
            Case "1"
                GuardarVoto(votoTemp, xmlDoc)
            Case "2"
                MenuCandPresi()
            Case Else
                Console.WriteLine("Opción no válida....")
        End Select
        ''Console.ReadLine()

    End Sub

    Private Sub GuardarVoto(votoTemp As ArrayList, xmlDoc As XmlDocument)
        votosBinomio.Clear()
        votosConcejal.Clear()
        votosAlcalde.Clear()

        Dim raiz As XmlNodeList = xmlDoc.GetElementsByTagName("sistema")
        For Each nodo As XmlNode In raiz
            For Each dignidades As XmlNode In nodo.ChildNodes
                For Each dignidad As XmlNode In dignidades
                    If dignidad.Name = "dignidad" Then
                        If dignidad.Attributes(0).Value = "104" Then
                            For Each listas As XmlNode In dignidad.ChildNodes
                                votosBinomio.Add(listas.InnerText)
                            Next
                        ElseIf dignidad.Attributes(0).Value = "105" Then
                            For Each listas As XmlNode In dignidad.ChildNodes
                                votosConcejal.Add(listas.InnerText)
                            Next
                        Else
                            For Each listas As XmlNode In dignidad.ChildNodes
                                votosAlcalde.Add(listas.InnerText)
                            Next
                        End If
                    End If
                Next
            Next
        Next

        Dim temporal As Integer = 0

        For i As Integer = 1 To 6 Step 1
            If votoTemp(0) = i Then
                temporal = CInt(votosBinomio(i - 1))
                temporal += 1
                votosBinomio(i - 1) = CStr(temporal)
            End If
            If votoTemp(1) = i Then
                temporal = CInt(votosConcejal(i - 1))
                temporal += 1
                votosConcejal(i - 1) = CStr(temporal)
            End If
            If votoTemp(2) = i Then
                temporal = CInt(votosAlcalde(i - 1))
                temporal += 1
                votosAlcalde(i - 1) = CStr(temporal)
            End If
        Next

        GuardarVotoXml(votosBinomio, votosConcejal, votosAlcalde, xmlDoc)
        Console.WriteLine("Validando su voto....")
        Console.ReadLine()
        Console.WriteLine("Gracias por cumplir con su deber ciudadano....")
        Console.ReadLine()
        Console.WriteLine("Regresando al Menú principal....")
        Console.ReadLine()
        MenuPrincipal()
    End Sub

    Private Sub GuardarVotoXml(votosBinomio As ArrayList, votosConcejal As ArrayList, votosAlcalde As ArrayList, xmlDoc As XmlDocument)
        xmlDoc.Load(ruta)
        Dim raiz As XmlNodeList = xmlDoc.GetElementsByTagName("sistema")
        For Each nodo As XmlNode In raiz
            For Each dignidades As XmlNode In nodo.ChildNodes
                For Each dignidad As XmlNode In dignidades
                    If dignidad.Name = "dignidad" Then
                        If dignidad.Attributes(0).Value = "104" Then
                            Dim i As Integer = 0
                            For Each listas As XmlNode In dignidad.ChildNodes
                                listas.InnerText = votosBinomio(i)
                                i += 1
                            Next
                        ElseIf dignidad.Attributes(0).Value = "105" Then
                            Dim i As Integer = 0
                            For Each listas As XmlNode In dignidad.ChildNodes
                                listas.InnerText = votosConcejal(i)
                                i += 1
                            Next
                        Else
                            Dim i As Integer = 0
                            For Each listas As XmlNode In dignidad.ChildNodes
                                listas.InnerText = votosAlcalde(i)
                                i += 1
                            Next
                        End If
                    End If
                    For Each votante As XmlNode In dignidad
                        If votante.Name = "votante" Then
                            If votante.Attributes(0).Value = cedula Then
                                votante.Attributes(1).InnerText = "si"
                            End If
                        End If
                    Next
                Next
            Next
        Next
        xmlDoc.Save(ruta)
        xmlDoc.Load(ruta)
    End Sub

    Sub MenuAdmDignidades()
        Console.Clear()
        Console.WriteLine(vbTab & vbTab & "  SISTEMA VOTO ELECTRÓNICO" & vbCrLf)
        Console.WriteLine(vbTab & vbTab & "  ADMINISTAR DIGNIDADES" & vbCrLf)
        Console.WriteLine("OPCIÓN 1. CREAR" & vbCrLf)
        Console.WriteLine("OPCIÓN 2. MODIFICAR" & vbCrLf)
        Console.WriteLine("OPCIÓN 3. CONSULTAR" & vbCrLf)
        Console.WriteLine("OPCIÓN 4. ELIMINAR" & vbCrLf)
        Console.Write(vbCrLf & "ESCOGA 1 OPCIÓN : ")
        opcion = Console.ReadLine()
        MenuAdministrador()
    End Sub

    Sub MenuAdmCandidatos()
        Console.Clear()
        Console.WriteLine(vbTab & vbTab & "  SISTEMA VOTO ELECTRÓNICO" & vbCrLf)
        Console.WriteLine(vbTab & vbTab & "  ADMINISTAR DIGNIDADES" & vbCrLf)
        Console.WriteLine("OPCIÓN 1. CREAR" & vbCrLf)
        Console.WriteLine("OPCIÓN 2. MODIFICAR" & vbCrLf)
        Console.WriteLine("OPCIÓN 3. CONSULTAR" & vbCrLf)
        Console.WriteLine("OPCIÓN 4. ELIMINAR" & vbCrLf)
        Console.Write(vbCrLf & "ESCOGA 1 OPCIÓN : ")
        opcion = Console.ReadLine()
        MenuAdministrador()
    End Sub

    Sub MenuAdmEstadisticas()
        Console.Clear()
        Console.WriteLine(vbTab & vbTab & "  SISTEMA VOTO ELECTRÓNICO" & vbCrLf)
        Console.WriteLine(vbTab & vbTab & "  ADMINISTAR DIGNIDADES" & vbCrLf)
        Console.WriteLine("OPCIÓN 1. MOSTRAR RESULTADOS" & vbCrLf)
        Console.WriteLine("OPCIÓN 2. VOTOS POR DIGNIDAD" & vbCrLf)
        Console.WriteLine("OPCIÓN 3. LISTAR CANDIDATOS" & vbCrLf)
        Console.Write(vbCrLf & "ESCOGA 1 OPCIÓN : ")
        opcion = Console.ReadLine()
        MenuAdministrador()
    End Sub


End Module
