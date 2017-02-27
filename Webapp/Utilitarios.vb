Module Utilitarios

    Public Function ContarOcurrenciasString(Expresion As String, Buscar As String) As Long
        ContarOcurrenciasString = Expresion.Length - Expresion.Replace(Buscar, "").Length
    End Function

    Public Function VerificarAtributoUsuarioAct(AtributoUsuario As String, CadAtributos As String) As Boolean

        'Salir si es que no existe listado de atributos
        If IsNothing(CadAtributos) Then
            VerificarAtributoUsuarioAct = False
            Exit Function
        End If

        If CadAtributos.ToString.Length = 0 Then
            VerificarAtributoUsuarioAct = False
            Exit Function
        End If

        If InStr(CadAtributos, "[" & AtributoUsuario & "]") > 0 Then
            VerificarAtributoUsuarioAct = True
        Else
            VerificarAtributoUsuarioAct = False
        End If

    End Function

    Function NomMes(Fecha As Date) As String

        NomMes = ""

        Select Case Month(Fecha)
            Case 1
                NomMes = "Enero"
            Case 2
                NomMes = "Febrero"
            Case 3
                NomMes = "Marzo"
            Case 4
                NomMes = "Abril"
            Case 5
                NomMes = "Mayo"
            Case 6
                NomMes = "Junio"
            Case 7
                NomMes = "Julio"
            Case 8
                NomMes = "Agosto"
            Case 9
                NomMes = "Sepiembre"
            Case 10
                NomMes = "Octubre"
            Case 11
                NomMes = "Noviembre"
            Case 12
                NomMes = "Diciembre"
        End Select

    End Function

    Function FechaEsp(Fecha As Date) As String
        'Devuelve fecha en formato dd-mm-aaaa
        'para asignar en controles de formulario

        Dim dia As String, mes As String, año As String

        dia = Day(Fecha)
        If Len(dia) = 1 Then dia = "0" & dia

        mes = Month(Fecha)
        If Len(mes) = 1 Then mes = "0" & mes

        año = Year(Fecha)

        FechaEsp = dia & "-" & mes & "-" & año

    End Function

    Function FechaTxt(Fecha As Date) As String
        Dim tmp As String

        tmp = Day(Fecha) & " de "

        Select Case Month(Fecha)
            Case 1
                tmp = tmp & "Enero, "
            Case 2
                tmp = tmp & "Febrero, "
            Case 3
                tmp = tmp & "Marzo, "
            Case 4
                tmp = tmp & "Abril, "
            Case 5
                tmp = tmp & "Mayo, "
            Case 6
                tmp = tmp & "Junio, "
            Case 7
                tmp = tmp & "Julio, "
            Case 8
                tmp = tmp & "Agosto, "
            Case 9
                tmp = tmp & "Sepiembre, "
            Case 10
                tmp = tmp & "Octubre, "
            Case 11
                tmp = tmp & "Noviembre, "
            Case 12
                tmp = tmp & "Diciembre, "
        End Select

        tmp = tmp & Year(Fecha)

        FechaTxt = tmp

    End Function

    Public Function ObtenerArgumento(ByVal Argumento As String, ByVal cadArgumentos As String) As String
        'v 02/09/2013
        'Devuelve el valor de un argumento dentro de una cadena de argumentos
        'Ej: ObtenerArgumento("Par2", "Par1=101;Par2=Hola;Par3=#01-01-11#") devuelve "Hola"

        'Insertar separador inicio y fin cadena argumentos
        If Left(cadArgumentos, 1) <> ";" Then cadArgumentos = ";" & cadArgumentos
        If Right(cadArgumentos, 1) <> ";" Then cadArgumentos = cadArgumentos & ";"

        'Buscar posicion del primer caracter del argumento en la cadena
        Dim PosIniNombre As Integer
        PosIniNombre = InStr(1, cadArgumentos, ";" & Argumento & "=", vbTextCompare)

        'Salir si el argumento no fué encontrado
        If PosIniNombre = 0 Then
            ObtenerArgumento = ""
            Exit Function
        End If

        'Buscar posiciones de inicio y fin del valor 
        Dim PosIniValor As Integer, PosFinValor As Integer
        PosIniValor = InStr(PosIniNombre, cadArgumentos, "=") + 1
        PosFinValor = InStr(PosIniValor, cadArgumentos, ";") - 1

        If PosIniValor > PosFinValor Then
            ObtenerArgumento = ""
            Exit Function
        End If

        'Obtener valor de argumento entre marcadores
        ObtenerArgumento = Mid(cadArgumentos, PosIniValor, PosFinValor - PosIniValor + 1)

    End Function

    Function FormatoAplicacion(ByVal strFormatoSQL As String) As String

        'Transformar cadena de consulta en cadena de parámetros para habilitar búsqueda
        '"@Par1=valor1, @Par2=valor2" -> "Par1=valor1;Par2=valor2"
        Dim strTmp As String = strFormatoSQL

        'Eliminar '@' y reemplazar ',' por ';'
        strTmp = Replace(strTmp, ", @", ";")
        strTmp = Replace(strTmp, "@", "")

        'Eliminar delimitadores de texto
        strTmp = Replace(strTmp, "='", "=")
        strTmp = Replace(strTmp, "';", ";")
        If Right(strTmp, 1) = "'" Then strTmp = Left(strTmp, strTmp.Length - 1)

        FormatoAplicacion = strTmp

    End Function

    Function Aleatorio(Minimo As Long, Maximo As Long) As Long
        Randomize() ' inicializar la semilla
        Aleatorio = CLng((Minimo - Maximo) * Rnd + Maximo)
    End Function

    Function CDate2(Fecha As String) As Date

        'Devuelve un valor del tipo Fecha para cadenas del tipo dd-mm-yyyy
        'independiente de la configuración regional del host del proceso

        If Fecha.Length <> 10 Then Exit Function

        If Mid(Fecha, 3, 1) <> "-" And Mid(Fecha, 3, 1) <> "/" Then Exit Function
        If Mid(Fecha, 6, 1) <> "-" And Mid(Fecha, 6, 1) <> "/" Then Exit Function

        CDate2 = DateSerial(Year:=Mid(Fecha, 7, 4), _
                            Month:=Mid(Fecha, 4, 2), _
                            Day:=Mid(Fecha, 1, 2))

    End Function

    Function Nz(Valor, ValorSiNulo)
        Nz = IIf(Not (Valor Is DBNull.Value), Valor, ValorSiNulo)
    End Function

    Function DigVer(ByVal Num As Long) As String
        'V2.0: 16/04/2002

        Dim Sum As Long
        Sum = 0

        Dim TXNum As String
        TXNum = CStr(Num)

        Dim Dig As String
        Dim Fac As String

        Dim i As Long
        For i = 0 To Len(TXNum) - 1

            Dig = Mid(TXNum, Len(TXNum) - i, 1)
            Fac = (i Mod 6) + 2

            Sum = Sum + CLng(Dig) * CLng(Fac)
        Next

        Dim DV As Single
        DV = 11 - Sum + (Sum \ 11) * 11

        Select Case DV
            Case 10
                DigVer = "K"
            Case 11
                DigVer = "0"
            Case Else
                DigVer = DV
        End Select

    End Function


    Public Enum TipoVar
        Numerico
        Texto
        Booleano
        Fecha
    End Enum

    Public Enum FormatoNum
        SinFormato
        SepMiles
        SepMiles2Dec
    End Enum

    Function VarSQL(ByVal Valor As String, ByVal Tipo As TipoVar, Optional CeroNulo As Boolean = False, Optional EliminarComodinesSQL As Boolean = True) As String

        'Devuelve un valor de variable en formato de SQL Server
        'Usado para componer cadenas de argumentos para SP        

        If Valor Is DBNull.Value Then
            VarSQL = "NULL"
            Exit Function
        End If

        If IsNothing(Valor) Then
            VarSQL = "NULL"
            Exit Function
        End If

        If Valor.Length = "0" Then
            VarSQL = "NULL"
            Exit Function
        End If

        If Valor = "0:00:00" Then
            VarSQL = "NULL"
            Exit Function
        End If

        'Eliminar cadenas de SQL Injection
        If EliminarComodinesSQL = True Then
            Valor = Replace(Valor, "SELECT", "")
            Valor = Replace(Valor, "UPDATE", "")
            Valor = Replace(Valor, "DELETE", "")
            Valor = Replace(Valor, "DROP", "")
            Valor = Replace(Valor, " UNION ", "")
            Valor = Replace(Valor, "%", "")
            Valor = Replace(Valor, " TOP ", "")
            Valor = Replace(Valor, " GROUP ", "")
            Valor = Replace(Valor, "=", "")
            Valor = Replace(Valor, ">", "")
            Valor = Replace(Valor, "<", "")
            Valor = Replace(Valor, "IIF", "")
            Valor = Replace(Valor, "FROM", "")
            Valor = Replace(Valor, " OR ", "")
            Valor = Replace(Valor, " AND ", "")
            Valor = Replace(Valor, " IN ", "")
            Valor = Replace(Valor, " CHR ", "")
            Valor = Replace(Valor, " ASC(", "")
            Valor = Replace(Valor, " CurDir ", "")
            Valor = Replace(Valor, "LEN(", "")
            Valor = Replace(Valor, "SHELL", "")
            Valor = Replace(Valor, "ASCII", "")
            Valor = Replace(Valor, "SUBSTRING", "")
            Valor = Replace(Valor, "LENGTH", "")
            Valor = Replace(Valor, "exists", "")
        End If

        Select Case Tipo
            Case TipoVar.Numerico
                VarSQL = Replace(Valor, ",", ".")

            Case TipoVar.Texto
                VarSQL = "'" & Replace(Valor, "'", "''") & "'"

            Case TipoVar.Booleano
                If Valor = "True" Then
                    VarSQL = "1"
                Else
                    VarSQL = "0"
                End If

            Case TipoVar.Fecha
                VarSQL = "'" & String.Format("{0:yyyyMMdd}", CDate2(Valor)) & "'"

            Case Else
                VarSQL = "NULL"

        End Select

        If VarSQL = "0" And CeroNulo Then VarSQL = "NULL"
        If VarSQL = "'0'" And CeroNulo Then VarSQL = "NULL"

    End Function

    Function VarControl(ByVal Valor As Object, ByVal Tipo As TipoVar, Optional NuloCero As Boolean = False, Optional FormatoNum As FormatoNum = Utilitarios.FormatoNum.SinFormato) As String
        'Devuelve valor de variable para ser asignada a control

        Select Case Tipo
            Case TipoVar.Numerico
                If Valor Is DBNull.Value Then
                    VarControl = ""
                ElseIf Valor.ToString = "" Then
                    VarControl = ""
                ElseIf Not IsNumeric(Valor) Then
                    VarControl = ""
                Else
                    VarControl = Valor
                End If

                If VarControl = "" And NuloCero Then VarControl = 0
                If Right(VarControl, 3) = ".00" Then VarControl = Left(VarControl, Len(VarControl) - 3)
                If Right(VarControl, 3) = ",00" Then VarControl = Left(VarControl, Len(VarControl) - 3)

                If IsNumeric(VarControl) And FormatoNum = Utilitarios.FormatoNum.SepMiles Then _
                  VarControl = Replace(Format(CLng(VarControl), "#,###,##0"), ",", ".")

                If IsNumeric(VarControl) And FormatoNum = Utilitarios.FormatoNum.SepMiles2Dec Then _
                  VarControl = Replace(Format(CLng(VarControl), "#,###,##0.00"), ",", ".")

            Case TipoVar.Texto
                If Valor Is DBNull.Value Then
                    VarControl = ""
                ElseIf Valor.ToString = "" Then
                    VarControl = ""
                Else
                    VarControl = Valor
                End If

                If VarControl = "" And NuloCero Then VarControl = "0"

            Case TipoVar.Fecha
                'FechaStr("20110301") = "02/03/2011" (Desde parámetro consulta)
                'FechaStr("Ene  1 2011 12:00AM") = "01/01/2011" (Desde campo FechaStr)
                If Valor Is DBNull.Value Then
                    VarControl = ""
                ElseIf Valor.ToString = "" Then
                    VarControl = ""
                ElseIf Valor.ToString.Length = 8 Then

                    If IsNumeric(Left(Valor.ToString, 4)) Then
                        'yyyymmdd
                        VarControl = Mid(Valor.ToString, 7, 2) & "-" & _
                                     Mid(Valor.ToString, 5, 2) & "-" & _
                                     Mid(Valor.ToString, 1, 4)
                    Else
                        'dd/mm/yy o dd-mm-yy
                        VarControl = Mid(Valor.ToString, 1, 2) & "-" & _
                                     Mid(Valor.ToString, 4, 2) & "-" & _
                                     "20" & Mid(Valor.ToString, 7, 2)
                    End If

                ElseIf Not IsDate(Valor) Then
                    VarControl = ""
                Else
                    VarControl = CDate(Valor)
                End If


            Case TipoVar.Booleano
                If Valor Is DBNull.Value Then
                    VarControl = False
                ElseIf Valor.ToString = "" Then
                    VarControl = False
                ElseIf Not IsNumeric(Valor) Then
                    VarControl = False
                ElseIf Valor = 0 Then
                    VarControl = False
                Else
                    VarControl = True
                End If

            Case Else
                VarControl = ""
        End Select

    End Function

End Module
