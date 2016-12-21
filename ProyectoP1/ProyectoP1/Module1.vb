Imports System.Xml

Module Module1

    Dim op As String = ""
    Dim opcion As Byte
    Dim votoDig As Integer
    Dim votoNulo As Integer
    Dim votoBlanco As Integer
    Dim listaPSC As Integer
    Dim listaFE As Integer
    Dim listaCREO As Integer
    Dim listaAlianzaP As Integer
    Const LOGIN As Byte = 1
    Const SINGIN As Byte = 2
    Const CHPASSWORD As Byte = 3
    Const OUT As Byte = 4

    Dim ruta = "C:\Users\Olguis\Source\Repos\Proyecto01P13\ProyectoP1\ProyectoP1\SistVotoElectronico.xml"
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
        Console.Title = "SISTEMA VOTO ELECTRONICO"
        'Console.ForegroundColor = ConsoleColor.Yellow
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
            Console.WriteLine("Ud ha ingresado: {0}", op)

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
        Console.WriteLine("GRACIAS, BYE")
        Console.ReadLine()

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
        MenuAdministrador()
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
        Dim usuario As String
        Dim clave As String
        Console.Clear()
        Console.WriteLine(vbTab & "INICIAR SESION CANDIDATO " & vbCrLf)
        Console.Write(" INGRESE SU USUARIO : " & vbTab)
        usuario = Console.ReadLine()
        Console.Write(" INGRESE SU PASSWORD : " & vbTab)
        clave = Console.ReadLine()
        Dim raiz As XmlNodeList = xmlDoc.GetElementsByTagName("sistema")
        For Each nodo As XmlNode In raiz
            For Each registro As XmlNode In nodo.ChildNodes
                For Each usuarios As XmlNode In registro.ChildNodes
                    For Each candidatos As XmlNode In usuarios
                        If candidatos.Name = "candidato" Then
                            If candidatos.Attributes(1).Value = usuario And candidatos.Attributes(2).Value = clave Then
                                MostrarResultadoCandidato()
                            Else
                                Console.WriteLine("Candidato no registrado")
                            End If
                        End If
                    Next
                Next
            Next
        Next

    End Sub

    Private Sub MostrarResultadoCandidato()
        Console.Clear()
        Console.WriteLine(vbTab & "MOSTRAR RESULTADOS" & vbCrLf)
        Console.WriteLine(vbTab & vbTab & "LISTA 6:" & listaPSC)
        Console.WriteLine(vbTab & vbTab & "LISTA 10:" & listaFE)
        Console.WriteLine(vbTab & vbTab & "LISTA 21-23:" & listaCREO)
        Console.WriteLine(vbTab & vbTab & "LISTA 35:" & listaAlianzaP)
        Console.WriteLine(vbTab & vbTab & "VOTO POR DIGNIDAD:" & votoDig)
        Console.WriteLine(vbTab & vbTab & "VOTO NULO:" & votoNulo)
        Console.WriteLine(vbTab & vbTab & "VOTO BLANCO:" & votoBlanco)

    End Sub

    Sub MenuPrincipal()
        Console.WriteLine("INGRESAR COMO: " & vbCrLf & vbCrLf)
        Console.WriteLine(vbTab & vbTab & "{0}. Votante", LOGIN)
        Console.WriteLine(vbTab & vbTab & "{0}. Candidato", SINGIN)
        Console.WriteLine(vbTab & vbTab & "{0}. Administrador", CHPASSWORD)
        Console.WriteLine(vbTab & vbTab & "{0}. Salir", OUT)
        Console.Write(vbCrLf & "ESCOGA 1 OPCIÓN : ")

    End Sub

    Sub MenuLogVotante(xmlDoc As XmlDocument)
        Dim cedula As String
        Dim cedVot As String
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
                                MenuCandPresi()
                            Else
                                Console.WriteLine("Votante no registrado")
                            End If
                        End If
                    Next
                Next
            Next
        Next
    End Sub

    Sub MenuCandPresi()
        Console.Clear()
        Console.WriteLine(vbTab & vbTab & vbTab & "  SISTEMA VOTO ELECTRÓNICO" & vbCrLf)
        Console.WriteLine(vbTab & vbTab & "  CANDIDATOS A PRESIDENTE Y VICEPRESIDENTE" & vbCrLf)
        Console.WriteLine("OPCIÓN 1. LISTA 6 PSC" & vbCrLf & vbTab & "Presidente : Cinthya Viteri" & vbCrLf & vbTab & "Vicepresidente : Mauricio Pozo" & vbCrLf)
        Console.WriteLine("OPCIÓN 2. LISTA 10 FE" & vbCrLf & vbTab & "Presidente : Abdalá Bucaram" & vbCrLf & vbTab & "Vicepresidente : Ramiro Aguilar" & vbCrLf)
        Console.WriteLine("OPCIÓN 3. LISTA 21 - 23 CREO - SUMA" & vbCrLf & vbTab & "Presidente : Guillermo Lasso" & vbCrLf & vbTab & "Vicepresidente : Andrés Paez" & vbCrLf)
        Console.WriteLine("OPCIÓN 4. LISTA 35 ALIANZA PAIS" & vbCrLf & vbTab & "Presidente : Lenin Moreno" & vbCrLf & vbTab & "Vicepresidente : Jorge Glas" & vbCrLf)
        Console.WriteLine("OPCIÓN 5. Voto Nulo" & vbCrLf)
        Console.WriteLine("OPCIÓN 6. Voto Blanco" & vbCrLf)
        Console.Write(vbCrLf & "ESCOGA 1 OPCIÓN : ")
        opcion = Console.ReadLine()
        MenuCandConcejal()
    End Sub

    Sub MenuCandConcejal()
        Console.Clear()
        Console.WriteLine(vbTab & vbTab & "  SISTEMA VOTO ELECTRÓNICO" & vbCrLf)
        Console.WriteLine(vbTab & vbTab & "  CANDIDATOS A CONCEJALES" & vbCrLf)
        Console.WriteLine("OPCIÓN 1. LISTA 6 PSC" & vbCrLf & vbTab & "Luis Fernández" & vbCrLf)
        Console.WriteLine("OPCIÓN 2. LISTA 10 FE" & vbCrLf & vbTab & "Angélica Ramos" & vbCrLf)
        Console.WriteLine("OPCIÓN 3. LISTA 21 - 23 CREO - SUMA" & vbCrLf & vbTab & "Rodrigo Sánchez" & vbCrLf)
        Console.WriteLine("OPCIÓN 4. LISTA 35 ALIANZA PAIS" & vbCrLf & vbTab & "Ana Macías" & vbCrLf)
        Console.WriteLine("OPCIÓN 5. Voto Nulo" & vbCrLf)
        Console.WriteLine("OPCIÓN 6. Voto Blanco" & vbCrLf)
        Console.Write(vbCrLf & "ESCOGA 1 OPCIÓN : ")
        opcion = Console.ReadLine()
        MenuPrincipal()
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
