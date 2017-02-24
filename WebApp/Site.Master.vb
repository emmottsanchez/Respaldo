Public Class Site
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(Session("UsuarioAct.IdUsuario")) Then
            If cphPrincipal.BindingContainer.Page.AppRelativeVirtualPath.ToLower <> "~/default.aspx" Then
                Response.Redirect("~/Default.aspx")
                Exit Sub
            End If
        End If

        If Page.IsPostBack = True Then Exit Sub

        If ddlPeriodo.Items.Count = 0 Then
            Dim cnn As New WebApp.Conexion
            Dim ds As DataSet = cnn.EjecutarSP("PGPeriodosAppInfo", "")

            Session("App.MaxPeriodo") = ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1).Item("Periodo")

            For Each dr As DataRow In ds.Tables(0).Rows
                ddlPeriodo.Items.Insert(0, New ListItem(NomMes(dr.Item("Periodo")) & " " & Year(dr.Item("Periodo")), dr.Item("Periodo")))
            Next

            If Not IsNothing(Session("App.PeriodoActivo")) Then
                ddlPeriodo.SelectedValue = Session("App.PeriodoActivo")
            Else
                Session("App.PeriodoActivo") = ddlPeriodo.SelectedValue
            End If
            Dim Fecha As String = Session("App.PeriodoActivo")
            If Session("App.PeriodoActivo") > Convert.ToDateTime("01/01/2017") Then
                EstablecerFechaDatos()
                lblFechaDatos.Text = "Afiliaciones al " & FechaEsp(Session("App.FecMaxAfiliacion")) & "<br>" &
                                     "Créditos al " & FechaEsp(Session("App.FecMaxCredito")) & "<br>" &
                                     "Cupones al " & FechaEsp(Session("App.FecMaxCupones")) & "<br>" &
                                     "Seguros al " & FechaEsp(Session("App.FecMaxSeguros")) & "<br>"
            Else
                EstablecerFechaDatos()
                lblFechaDatos.Text = "Afiliaciones al " & FechaEsp(Session("App.FecMaxAfiliacion")) & "<br>" &
                                     "Créditos al " & FechaEsp(Session("App.FecMaxCredito")) & "<br>" &
                                     "Cupones al " & FechaEsp(Session("App.FecMaxCupones")) & "<br>" &
                                     "Seguros al : Sin Datos"
            End If

        End If


        If IsNothing(Session("UsuarioAct.IdUsuario")) Then

            If cphPrincipal.BindingContainer.Page.AppRelativeVirtualPath.ToLower <> "~/default.aspx" Then
                Response.Redirect("~/Default.aspx")
                Exit Sub
            End If


            'Hacer visible línea de Inicio de sesion
            tbUsuario.Rows(0).Visible = True
            tbUsuario.Rows(1).Visible = False

            'Hacer invisible controles de Periodo
            lblPeriodo.Visible = False
            ddlPeriodo.Visible = False

            If (Request.Cookies("InicioSesion") IsNot Nothing) Then
                If (Request.Cookies("InicioSesion")("EmailInicioSesion") IsNot Nothing) Then
                    tbEmail.Text = Request.Cookies("InicioSesion")("EmailInicioSesion")
                    cbGuardarEmail.Checked = True
                End If
            End If

        Else
            'Hacer Visible controles de Periodo
            lblPeriodo.Visible = True
            ddlPeriodo.Visible = True


            'Hacer visible línea de Menú y Datos de sesion
            If cphPrincipal.BindingContainer.Page.AppRelativeVirtualPath <> "~/CambiarContraseña.aspx" Then
                btnPrincipal.Visible = True

                If Session("UsuarioAct.Red") = 0 Or Session("UsuarioAct.Red") = 1 Then
                    btnIndicadores.Visible = True
                    btnAfiliacionesCanal.Visible = True
                Else
                    btnIndicadores.Visible = False
                    btnAfiliacionesCanal.Visible = False
                End If

                btnCoachings.Visible = Session("UsuarioAct.Coachings")
            Else
                btnPrincipal.Visible = False
                btnIndicadores.Visible = False
                btnCoachings.Visible = False
            End If

            lblUsuarioSesion.Text = Session("UsuarioAct.Usuario")
            tbUsuario.Rows(0).Visible = False
            tbUsuario.Rows(1).Visible = True
        End If

    End Sub

    Sub EstablecerFechaDatos()

        Dim PeriodoSel As Date = DateSerial(Right(ddlPeriodo.SelectedValue, 4), _
                                            Mid(ddlPeriodo.SelectedValue, 4, 2), _
                                            Left(ddlPeriodo.SelectedValue, 2))

        Dim cnn As New WebApp.Conexion
        Dim ds As DataSet = cnn.EjecutarSP("SELECT dbo.PGLeerCfg(-11) AS FecProceso, dbo.PGLeerCfg(-16) AS FecMaxAfiliacion, dbo.PGLeerCfg(-17) AS FecMaxCredito, dbo.PGLeerCfg(-18) AS FecMaxCupones,dbo.PGLeerCfg(-19) AS FecMaxSeguros", "")
        Dim FecProceso As Date = ds.Tables(0).Rows(0).Item("FecProceso")

        If PeriodoSel.Year = FecProceso.Year And PeriodoSel.Month = FecProceso.Month Then
            'Periodo seleccionado por usuario equivalente a periodo de última fecha de Cruce de afiliaciones
            'Establecer día anterior al cruce como fecha de datos
            Session("App.FecProceso") = ds.Tables(0).Rows(0).Item("FecProceso")
            Session("App.FecMaxAfiliacion") = ds.Tables(0).Rows(0).Item("FecMaxAfiliacion")
            Session("App.FecMaxCredito") = ds.Tables(0).Rows(0).Item("FecMaxCredito")
            Session("App.FecMaxCupones") = ds.Tables(0).Rows(0).Item("FecMaxCupones")
            Session("App.FecMaxSeguros") = ds.Tables(0).Rows(0).Item("FecMaxSeguros")
        Else
            'Periodo seleccionado por usuario distinto (anterior) a periodo última fecha de Cruce de afiliaciones
            'Establecer último día del periodo seleccionado por el usuario como fecha de datos
            FecProceso = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, PeriodoSel))
            Session("App.FecProceso") = FecProceso
            Session("App.FecMaxAfiliacion") = FecProceso
            Session("App.FecMaxCredito") = FecProceso
            Session("App.FecMaxCupones") = FecProceso
            Session("App.FecMaxSeguros") = FecProceso
        End If

    End Sub

    Private Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click

        Dim vNombreSP As String = "PGIniciarSesion"
        Dim vArgumentos As String = "@Email='" & Me.tbEmail.Text & "', " & _
                                    "@Contraseña='" & Me.tbContraseña.Text & "'"

        Dim cnn As New WebApp.Conexion, ds As DataSet
        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)


        If ds.Tables(0).Rows(0).Item("IdEstado") < 0 Then
            lblMsg0.Text = "Acceso Incorrecto"
            Exit Sub
        End If

        'Establecer variables de sesión (replicado en MenuPrincipal.gvAccesosCompartidos_RowCommand)
        Session("UsuarioAct.IdUsuario") = ds.Tables(0).Rows(0).Item("IdUsuario")
        Session("UsuarioAct.Usuario") = ds.Tables(0).Rows(0).Item("Usuario")
        Session("UsuarioAct.Email") = tbEmail.Text
        Session("UsuarioAct.Red") = ds.Tables(0).Rows(0).Item("Red")
        Session("UsuarioAct.Coachings") = ds.Tables(0).Rows(0).Item("Coachings")


        'Guardar email
        If Me.cbGuardarEmail.Checked = True Then
            Response.Cookies("InicioSesion")("EmailInicioSesion") = tbEmail.Text
            Response.Cookies("InicioSesion").Expires = DateTime.Now.AddYears(50)
        End If

        If Session("UsuarioAct.Email") = Me.tbContraseña.Text Then
            Session("CambiarContraseña.FormPrev") = "~/Default.aspx"
            Response.Redirect("~/CambiarContraseña.aspx")
        Else
            Response.Redirect("~/MenuPrincipal.aspx")
        End If


    End Sub

    Protected Sub ddlPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPeriodo.SelectedIndexChanged
        Session("App.PeriodoActivo") = ddlPeriodo.SelectedValue
        EstablecerFechaDatos()
        Response.Redirect("~/MenuPrincipal.aspx")
    End Sub

    Private Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        Session("UsuarioAct.IdUsuario") = Nothing
        Response.Redirect("~/Default.aspx")
    End Sub

    Private Sub btnPrincipal_Click(sender As Object, e As EventArgs) Handles btnPrincipal.Click
        Response.Redirect("~/MenuPrincipal.aspx")
    End Sub

    Private Sub btnIndicadores_Click(sender As Object, e As EventArgs) Handles btnIndicadores.Click

        Select Case Session("UsuarioAct.RolPeriodoAct")
            Case "Acceso Completo", "Jefe Red"
                Session("Red.Ordenar") = "UsuarioRegional"
                Session("Red.FormPrev") = cphPrincipal.BindingContainer.Page.AppRelativeVirtualPath
                Response.Redirect("~/Red.aspx")

            Case "Regional"
                Session("Regional.ConsultaActiva") = "IdUsuarioRegional=" & Session("UsuarioAct.IdUsuario")
                Session("Regional.Ordenar") = "UsuarioAgente"
                Session("Regional.FormPrev") = cphPrincipal.BindingContainer.Page.AppRelativeVirtualPath
                Response.Redirect("~/Regional.aspx")

            Case "Agente"
                Session("Agente.ConsultaActiva") = "IdUsuarioAgente=" & Session("UsuarioAct.IdUsuario")
                Session("Agente.Ordenar") = "Sucursal"
                Session("Agente.FormPrev") = cphPrincipal.BindingContainer.Page.AppRelativeVirtualPath
                Response.Redirect("~/Agente.aspx")

        End Select

    End Sub

    Private Sub btnCoachings_Click(sender As Object, e As EventArgs) Handles btnCoachings.Click

        Dim vDesde As Date = Session("App.PeriodoActivo")
        Dim vHasta As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Session("App.PeriodoActivo")))

        If Session("App.PeriodoActivo") = Session("App.MaxPeriodo") Then
            Session("Coachings.ConsultaActiva") = "FecCreacionDesde=" & VarSQL(vDesde, TipoVar.Fecha)
        Else
            Session("Coachings.ConsultaActiva") = "FecCreacionDesde=" & VarSQL(vDesde, TipoVar.Fecha) & ";" & _
                                                  "FecCreacionHasta=" & VarSQL(vHasta, TipoVar.Fecha)
        End If

        Session("Coachings.FormPrev") = cphPrincipal.BindingContainer.Page.AppRelativeVirtualPath
        Response.Redirect("~/Coachings.aspx")

    End Sub

    Private Sub btnAfiliacionesCanal_Click(sender As Object, e As EventArgs) Handles btnAfiliacionesCanal.Click

        Select Case Session("UsuarioAct.RolPeriodoAct")
            Case "Acceso Completo", "Jefe Red"

                Response.Redirect("~/Afican/AficanRegional.aspx")

            Case "Regional"
                Session("Regional.ConsultaActiva") = "IdUsuarioRegional=" & Session("UsuarioAct.IdUsuario")
                Response.Redirect("~/Afican/AficanAgente.aspx")

            Case "Agente"
                Session("Agente.ConsultaActiva") = "IdUsuarioAgente=" & Session("UsuarioAct.IdUsuario")
                Response.Redirect("~/Afican/AficanSucursal.aspx")

        End Select

    End Sub

End Class