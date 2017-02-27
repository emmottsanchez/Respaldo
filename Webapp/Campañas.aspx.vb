Imports System.Net
Public Class Campañas
    Inherits System.Web.UI.Page
    Dim vNombreSP As String
    Dim vArgumentos As String
    Dim cnn As New Webapp.Conexion
    Dim ds As DataSet
    Dim co As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("Usuario.Menu") = 1
        'Validador 1er día del Mes
        If Day(DateTime.Now) = 1 Then
            panelNoAceptado.Visible = False
            panelDia1.Visible = True
            Exit Sub
        End If
        If IsNothing(Session("UsuarioAct.Usuario")) Then
            Response.Redirect("~/default.aspx")
            Exit Sub
        End If
        If Page.IsPostBack = True Then Exit Sub
        ValidarTomaCon()
        Flash()
        Pensionados()
        Trabajador()
        DataActualizada()
        Seguros()
        LlenarDatos()
    End Sub

    Sub Flash()
        Dim val As String = "IF EXISTS(Select * from CPECFlashVta where Rut=" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & _
                            " AND Periodo>='2017-02-01') SELECT 1 ELSE SELECT 0"
        vArgumentos = ""
        Dim ds1 As DataSet = cnn.EjecutarSP(val, vArgumentos)
        If (ds1.Tables(0).Rows(0).Item(0) = 0) Then
            Exit Sub
        Else
            pnlCampañaFlash.Visible = True
            vNombreSP = "Select * from CPECFlashVta where Rut =" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & _
                        " and Periodo >='2017-02-01'"
            vArgumentos = ""
            ds = cnn.EjecutarSP(vNombreSP, vArgumentos)

            lblAfiFlash.Text = Nz(ds.Tables(0).Rows(0).Item("Afiliaciones"), 0)
            lblMetaAfiFlash.Text = Nz(ds.Tables(0).Rows(0).Item("MetaAfi"), 0)
            lblCumpAfiFlash.Text = (Nz(ds.Tables(0).Rows(0).Item("CumpAfi"), 0)) & "%"
            lblNomFlash.Text = Session("UsuarioAct.SoloNombre")
            'lblDFlash.Text = Nz(ds.Tables(0).Rows(0).Item("Periodo"), 0)
            'lblCredFlash.Text = FormatNumber(ds.Tables(0).Rows(0).Item("CredTrab"), 0)
            'lblMetaCredFlash.Text = FormatNumber(ds.Tables(0).Rows(0).Item("MetaCredTrab"), 0)
            'lblCumpCredFlash.Text = FormatPercent(ds.Tables(0).Rows(0).Item("CumpTrab"), 0)

            lblGrupoFlash.Text = ds.Tables(0).Rows(0).Item("ColorFlash")
            Dim color As String
            color = ds.Tables(0).Rows(0).Item("ColorFlash")
            If color = "Azul" Then
                lblGrupoFlash.ForeColor = Drawing.Color.Blue
            End If

            If color = "Verde" Then
                lblGrupoFlash.ForeColor = Drawing.Color.Green
            End If

            If color = "Naranjo" Then
                lblGrupoFlash.ForeColor = Drawing.Color.Orange
            End If
        End If

        Dim Cred As Integer
        Dim Afi As Integer

        Afi = lblAfiFlash.Text
        Cred = ds.Tables(0).Rows(0).Item("MetaAfi")

        If Afi < Cred Then
            lblSitFlash.Text = "¡¡ Vamos que queda poco para <br/> obtener el incentivo mensual !!"
            lblSitFlash.ForeColor = Drawing.Color.SteelBlue

        Else
            lblSitFlash.Text = "Felicitaciones, has logrado obtener el incentivo del mes...<br/> recuerda que puedes seguir aumentando tu incentivo."
            lblSitFlash.ForeColor = Drawing.Color.DarkGreen
        End If

    End Sub

    Sub Pensionados()
        Dim val As String = "IF EXISTS(select * from CPECUsuarioPensVta where Rut=" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & _
                           " , Periodo=" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha) & ") SELECT 1 ELSE SELECT 0"
        vArgumentos = ""
        Dim ds1 As DataSet = cnn.EjecutarSP(val, vArgumentos)
        If (ds1.Tables(0).Rows(0).Item(0) = 0) Then
            Exit Sub
        Else
            'pnlPensionados.Visible= True
            vNombreSP = "CPECUsuarioPensInfo"
            vArgumentos = "@Rut='" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & "'" & _
                          ", @Periodo=" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha)

            ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
            
                lblCreditosP.Text = FormatNumber(ds.Tables(0).Rows(0).Item("Creditos"), 0)
                lblAfiliacionesP.Text = FormatNumber(ds.Tables(0).Rows(0).Item("Afiliaciones"), 0)
            lblNombreSegPen.Text = Session("UsuarioAct.SoloNombre")
            lblNombreSegPen2.Text = Session("UsuarioAct.SoloNombre")

            Dim ResulCrP As String
            ResulCrP = ds.Tables(0).Rows(0).Item("GanoCred")
            If ResulCrP = "No Gano" Then
                lblCumpleMetaCredP.Text = "¡¡ Vamos que queda poco para <br/> obtener el incentivo mensual !!"
                lblCumpleMetaCredP.ForeColor = Drawing.Color.SteelBlue

            Else
                lblCumpleMetaCredP.Text = "Felicitaciones, has logrado obtener el incentivo del mes...<br/> recuerda que puedes seguir aumentando tu incentivo."
                lblCumpleMetaCredP.ForeColor = Drawing.Color.DarkGreen
            End If
                'lblGrupoP.Text = ds.Tables(0).Rows(0).Item("ColorPensionado")
                'lblAfiRest.Text = FormatNumber(ds.Tables(0).Rows(0).Item("AfiRest"), 0)
                'lblCredRest.Text = FormatNumber(ds.Tables(0).Rows(0).Item("CredRest"), 0)

            'If ds.Tables(0).Rows(0).Item("GanoCred") = 0 Then
            '    lblText1Afi.Text = "* Felicidades, ya lograste cumplir con el requisito de afiliaciones para obtener incentivo."
            '    lblText2Afi.Visible = False
            '    lblAfiRest.Visible = False
            'End If

            'If ds.Tables(0).Rows(0).Item("CredRest") = 0 Then
            '    lblText1Cred.Text = "* Felicidades, ya lograste cumplir con el requisito de crédito para obtener incentivo."
            '    lblText2Cred.Visible = False
            '    lblCredRest.Visible = False
            'End If

            Dim Cred As Integer
            Dim Afi As Integer
            Dim Total As Integer

            Afi = ds.Tables(0).Rows(0).Item("AfiRest")
            Cred = ds.Tables(0).Rows(0).Item("CredRest")
            Total = Afi + Cred

            'If Total = 0 Then
            '    lblText1Cred.Text = "* Felicidades, ya lograste cumplir con los requisitos de afiliación y crédito."
            '    lblText1Afi.Visible = False
            '    lblRequisitos.Visible = False
            '    lblRecu.Visible = False
            'End If


            'Dim Grupo As String
            'Grupo = ds.Tables(0).Rows(0).Item("ColorPensionado")

            'If Grupo = "Grupo 1" Then
            '    lblRequisitos.Text = "Meta de Afiliaciones o Crédito"
            'ElseIf Grupo = "Grupo 2" Then
            '    lblRequisitos.Text = "Meta de Afiliaciones o Crédito"
            'Else
            '    lblRequisitos.Text = "Meta de Afiliaciones o Crédito"
            'End If

            If ds.Tables(0).Rows(0).Item("MetaAfiPen") = 0 Then
                lblsituacion.Visible = False
            End If

            If ds.Tables(0).Rows(0).Item("MetaCredPen") = 0 Then
                lblsituacion.Visible = False
                Exit Sub
            End If

            Dim Resultado As String
            Resultado = ds.Tables(0).Rows(0).Item("Gano")

            If Resultado = "No Gano" Then
                lblsituacion.Text = "¡¡ Vamos que queda poco para <br/> obtener el incentivo mensual !!"
                lblsituacion.ForeColor = Drawing.Color.SteelBlue

            Else
                lblsituacion.Text = "Felicitaciones, has logrado obtener el incentivo del mes...<br/> recuerda que puedes seguir aumentando tu incentivo."
                lblsituacion.ForeColor = Drawing.Color.DarkGreen
            End If
        End If
    End Sub

    Sub Trabajador()
        Dim val As String = "IF EXISTS(select * from CPECUsuarioTrabVta where Rut=" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & _
                         " and Periodo=" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha) & ") SELECT 1 ELSE SELECT 0"
        vArgumentos = ""
        Dim ds1 As DataSet = cnn.EjecutarSP(val, vArgumentos)
        If (ds1.Tables(0).Rows(0).Item(0) = 0) Then
            Exit Sub
        Else
            'pnlTrabajadores.Visible = True

            vNombreSP = "CPECUsuarioTrabInfo"
            vArgumentos = "@Rut='" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & "'" & _
                          ", @Periodo=" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha)

            ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
            lblNombreTr.Text = Session("UsuarioAct.SoloNombre")
            'lblGrupoT.Text = ds.Tables(0).Rows(0).Item("ColorTrabajador")

            lblCredRestT.Text = FormatNumber(ds.Tables(0).Rows(0).Item("CredRest"), 0)
            lblCredT.Text = FormatNumber(ds.Tables(0).Rows(0).Item("Creditos"), 0)

            If ds.Tables(0).Rows(0).Item("CredRest") = 0 Then
                lblText1CredT.Text = "* Felicidades, ya lograste cumplir con el requisito para obtener incentivo."
                lblText2CredT.Visible = False
                lblCredRestT.Visible = False
            End If

            If ds.Tables(0).Rows(0).Item("metaCredTrab") = 0 Then
                lblGanoT.Visible = False
                Exit Sub
            End If

            Dim Resultado2 As String
            Resultado2 = ds.Tables(0).Rows(0).Item("Gano")

            If Resultado2 = "No Gano" Then
                lblGanoT.Text = "¡¡ Vamos que queda poco para <br/> obtener el incentivo mensual !!"
                lblGanoT.ForeColor = Drawing.Color.SteelBlue
            Else
                lblGanoT.Text = "Felicitaciones, recuerda que puedes seguir aumentando tu incentivo."
                lblGanoT.ForeColor = Drawing.Color.DarkGreen
            End If
        End If
    End Sub

    Private Sub LlenarDatos()
        vNombreSP = "EXEC CPECIniciarSesion "
        vArgumentos = "@Rut='" & Session("UsuarioAct.Rut") & "'" & _
                     ", @Contraseña=" & Session("UsuarioAct.Contraseña") & _
                     ", @Periodo =" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha)
        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
        If (ds.Tables(0).Rows(0).Item("IdEstado") = -11) Then
            Exit Sub
        Else

            If ds.Tables(0).Rows(0).Item("MetaCredTrab") = 0 Then
                pnlTrabajadores.Visible = False
            Else
                pnlTrabajadores.Visible = True
            End If
            If ds.Tables(0).Rows(0).Item("MetaAfiPen") = 0 Then
                pnlPensionados.Visible = False
                lblDAfi.Visible = False
            Else
                pnlPensionados.Visible = True
            End If
            If ds.Tables(0).Rows(0).Item("MetaCredPen") = 0 Then
                pnlCredPens.Visible = False
            Else
                pnlCredPens.Visible = True
            End If

            Session("UsuarioAct.Sucursal") = ds.Tables(0).Rows(0).Item("Cod_Sucursal")
            Session("UsuarioAct.NombreEquipo") = ds.Tables(0).Rows(0).Item("NombreEquipo")
            lblSegmentoPensionado.Text = Nz(ds.Tables(0).Rows(0).Item("ColorPensionado"), 0)
            'lblMetaAfiPens.Text = Nz(FormatNumber(ds.Tables(0).Rows(0).Item("MetaAfiPen"), 0), 0)
            'lblMetaCredPen.Text = Nz(FormatNumber(ds.Tables(0).Rows(0).Item("MetaCredPen"), 0), 0)
            lblMetaAfiPens2.Text = FormatNumber(ds.Tables(0).Rows(0).Item("MetaAfiPen"), 0)
            lblMetaCredPend2.Text = FormatNumber(ds.Tables(0).Rows(0).Item("MetaCredPen"), 0)
            'lblSegmentoTrab.Text = Nz(ds.Tables(0).Rows(0).Item("ColorTrabajador"), 0)
            lblSucursal3.Text = Nz(ds.Tables(0).Rows(0).Item("Sucursal"), 0)
            Dim color As String
            color = Nz(ds.Tables(0).Rows(0).Item("ColorTrabajador"), "")
            If color = "Azul" Then
                'lblSegmentoTrab.ForeColor = Drawing.Color.Blue
                lblSegmentoPensionado.ForeColor = Drawing.Color.Blue
            End If

            If color = "Verde" Then
                'lblSegmentoTrab.ForeColor = Drawing.Color.Green
                lblSegmentoPensionado.ForeColor = Drawing.Color.Green
            End If

            If color = "Naranjo" Then
                'lblSegmentoTrab.ForeColor = Drawing.Color.Orange
                lblSegmentoPensionado.ForeColor = Drawing.Color.Orange
            End If
            lblMinVenta.Text = Nz(FormatNumber(ds.Tables(0).Rows(0).Item("MetaCredTrab"), 0), 0)
            lblImportante.Text = "- 1 Afiliación de un Pensionado FFAA ➡ Suma 2 Afiliaciones."
            panelRequisitos.Visible = True
            If ds.Tables(0).Rows(0).Item("TomaConocimiento") = 1 Then
                panelAceptacion.Visible = False
            Else
                panelAceptacion.Visible = True
            End If

        End If
        vNombreSP = "Select DiasRestantes=((select DiasHabMes from fechas where Fecha = dbo.FecSinHora(getdate())) - (dbo.DiaHabil((Select top 1 fecha_contable from Creditos group by fecha_contable order by fecha_contable desc))))"
        vArgumentos = ""
        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
        lblDiasRest.Text = ds.Tables(0).Rows(0).Item(0)
        lblDiasRest2.Text = ds.Tables(0).Rows(0).Item(0)
        lblDiasRestT.Text = ds.Tables(0).Rows(0).Item(0)
        Rank()
    End Sub

    Function GetIPAddress() As String
        Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
        Dim sIPAddress As String = context.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If String.IsNullOrEmpty(sIPAddress) Then
            Return context.Request.ServerVariables("REMOTE_ADDR")
        Else
            Dim ipArray As String() = sIPAddress.Split(New [Char]() {","c})
            Return ipArray(0)
        End If
    End Function

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        If chkAcepto.Checked = True Then
            panelAceptacion.Visible = False
            vNombreSP = "UPDATE CPECUsuarios set  TomaConocimiento=1, FechaAcepto =" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), Day(DateTime.Now)), TipoVar.Fecha) & _
                        " where  Usuario='" & Session("UsuarioAct.Usuario") & "'" & _
                        " AND Periodo=" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha)
            vArgumentos = ""
            ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
            panelAceptacion.Visible = False
            panelMensaje.Visible = True
            panelCompleto.Visible = True
            panelNoAceptado.Visible = False
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "MostrarMensaje();", True)
            If Nz((Session("UsuarioAct.NombreEquipo")), 0) = "0" Then

                Dim ipdir As String = GetIPAddress()
                Dim host As IPHostEntry = Dns.GetHostEntry(ipdir)
                Dim vNombreSP2 As String = "update CPECUsuarios set  NombreEquipo='" & host.HostName & "' where  Usuario='" & Session("UsuarioAct.Usuario") & "'" & _
                                           " AND Periodo=" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha)
                vArgumentos = ""
                ds = cnn.EjecutarSP(vNombreSP2, vArgumentos)
            End If
        Else

            'btnEnviar.Visible = False
            lblError2.Text = "Debe aceptar condiciones para continuar"
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "MostrarMensajeError();", True)

        End If

    End Sub

    Private Sub ValidarTomaCon()
        vNombreSP = "EXEC CPECIniciarSesion "
        vArgumentos = "@Rut='" & Session("UsuarioAct.Rut") & "'" & _
                     ", @Contraseña=" & Session("UsuarioAct.Contraseña") & _
                     ", @Periodo =" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha)
        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
        If ds.Tables(0).Rows(0).Item("idEstado") = -11 Then
            panelNoAceptado.Visible = False
            Exit Sub
        End If

        If ds.Tables(0).Rows(0).Item("TomaConocimiento") = 1 Then
            panelNoAceptado.Visible = False
            Exit Sub
        Else
            panelNoAceptado.Visible = True
            panelCompleto.Visible = False

        End If

        If Session("UsuarioAct.Agente") = 1 Then
            lblAgenteNoT.Visible = True
            panelNoAceptado.Visible = False
            panelCompleto.Visible = False
        Else
            lblAgenteNoT.Visible = False
        End If

    End Sub

    Sub DataActualizada()
        vNombreSP = "select isnull(max(fecha_contable),0)as fecha_contable,ISNULL((COUNT(*)),0) as Cn from Creditos"
        vArgumentos = ""

        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)


        If ds.Tables(0).Rows(0).Item("Cn") = 0 Then
            lblDCred.Text = "(No existen datos en sistema para este periodo)"
        Else
            lblDCred.Text = "Créditos actualizados al: " & ds.Tables(0).Rows(0).Item("fecha_contable")

        End If

        Dim vNombreS As String = "select ISNULL(MAX(FECHA_PREAFILIACION),0)as FECHA_PREAFILIACION,ISNULL((COUNT(*)),0) as Cn from Afiliaciones"
        Dim vArgumento As String = ""

        Dim ds1 As DataSet = cnn.EjecutarSP(vNombreS, vArgumento)

        If ds1.Tables(0).Rows(0).Item("Cn") = 0 Then
            lblDAfi.Text = "(No existen datos en sistema para este periodo)"
        Else
            lblDAfi.Text = "Afiliaciones actualizadas al: " & ds1.Tables(0).Rows(0).Item("FECHA_PREAFILIACION")
        End If

    End Sub

    Sub Seguros()
        lblNombre4.Text = Session("UsuarioAct.SoloNombre")
        Dim vNombreS As String = "select convert(varchar(10),ISNULL(MAX(Periodo),0),112)as fecha from CPECSeguimientoDiarioSeguros"
        Dim vArgumento As String = ""

        Dim ds As DataSet = cnn.EjecutarSP(vNombreS, vArgumento)


        Dim val As String = "IF EXISTS(select * from CPECSeguimientoDiarioSeguros where Rut=" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & _
                            " and Periodo='" & ds.Tables(0).Rows(0).Item("fecha") & "') SELECT 1 ELSE SELECT 0"
        vArgumentos = ""
        Dim ds1 As DataSet = cnn.EjecutarSP(val, vArgumentos)
        If (ds1.Tables(0).Rows(0).Item(0) = 0) Then
            plSeguros.Visible = False
            Exit Sub
        Else
            vNombreSP = "select * from CPECSeguimientoDiarioSeguros where Rut=" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & _
                        " and Periodo='" & ds.Tables(0).Rows(0).Item("fecha") & "'"
            vArgumentos = ""
            ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
            plSeguros.Visible = True
            lblMiColorPens.Text = (ds.Tables(0).Rows(0).Item("ColorPens"))
            lblMiColorTrab.Text = (ds.Tables(0).Rows(0).Item("ColorTrab"))
            lblMiColorCes.Text = (ds.Tables(0).Rows(0).Item("ColorCes"))
            lblMiRankPens.Text = FormatNumber(ds.Tables(0).Rows(0).Item("RankIndPens"), 0)
            lblMiRankTrab.Text = FormatNumber(ds.Tables(0).Rows(0).Item("RankIndTrab"), 0)
            lblMiRankCes.Text = FormatNumber(ds.Tables(0).Rows(0).Item("RankCes"), 0)
            lblMiSeguroPens.Text = FormatNumber(ds.Tables(0).Rows(0).Item("CantidadIndPens"), 0)
            lblMiSeguroTrab.Text = FormatNumber(ds.Tables(0).Rows(0).Item("CantidadIndTrab"), 0)
            lblMiSeguroCes.Text = FormatNumber(ds.Tables(0).Rows(0).Item("CantidadSegCes"), 0)
            lblDSeguros.Text = "Seguros actualizados al: " & FormatDateTime(ds.Tables(0).Rows(0).Item("Periodo"), 0)
        End If
    End Sub


    Sub Rank()

        Dim QryP As String = "SELECT * FROM CPECRankPensVTA WHERE Rut='" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & "'"
        Dim Ar As String = ""
        Dim ds As DataSet = cnn.EjecutarSP(QryP, Ar)
        If ds.Tables(0).Rows(0).Item("Rut") = Session("UsuarioAct.Rut") Then
            lblRkCredPens.Text = Nz(FormatNumber(ds.Tables(0).Rows(0).Item("RankCredP201701"), 0), 0) & "°"
            lblRkAfPens.Text = Nz(FormatNumber(ds.Tables(0).Rows(0).Item("RankAfi201701"), 0), 0) & "°"
        Else
            lblRkCredPens.Text = ""
            lblRkAfPens.Text = ""
        End If


        Dim QryP2 As String = "SELECT * FROM CPECRankTrabVTA WHERE Rut='" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & "'"
        Dim Ar2 As String = ""
        Dim d As DataSet = cnn.EjecutarSP(QryP2, Ar2)
        If d.Tables(0).Rows(0).Item("Rut") = Session("UsuarioAct.Rut") Then
            lblRkCredTr.Text = Nz(FormatNumber(d.Tables(0).Rows(0).Item("RankCredT201701"), 0), 0) & "°"
        Else
            lblRkCredTr.Text = ""
        End If


    End Sub

End Class