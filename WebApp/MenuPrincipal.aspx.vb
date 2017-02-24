Public Class MenuPrincipal
    Inherits System.Web.UI.Page

    'Gestion de transacciones en BD
    Dim cnn As New WebApp.Conexion
    Dim ds As DataSet
    Dim vNombreSP As String, vArgumentos As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(Session("UsuarioAct.IdUsuario")) Then Response.Redirect("~/Default.aspx")
        If Page.IsPostBack = True Then Exit Sub

        lblTitulo.Text = "Resumen " & NomMes(Session("App.PeriodoActivo")) & " " & Year(Session("App.PeriodoActivo"))
        lblUsuario.Text = Session("UsuarioAct.Usuario")
        lblEmail.Text = Session("UsuarioAct.Email")

        vNombreSP = "PGRolesUsuarioInfo"
        vArgumentos = "@IdUsuario=" & Session("UsuarioAct.IdUsuario") & ", " & _
                      "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha)

        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)

        With ds.Tables(0).Rows(0)
            If .Item("IdEstado") = 1 Then
                DesplegarMensaje(TipoMensaje.MsgError, "Usuario sin rol para este mes")
                Exit Sub
            ElseIf .Item("IdEstado") <> 0 Then
                DesplegarMensaje(TipoMensaje.MsgError, .Item("EstadoUsr"))
                Dim lblInfoTec As Label = CType(Master.FindControl("lblInfoTec"), Label)
                lblInfoTec.Text = vNombreSP & " " & vArgumentos & "<br>" & _
                                  ds.Tables(0).Rows(0).Item("EstadoTec")
                Exit Sub
            End If
        End With

        Session("UsuarioAct.RolPeriodoAct") = ds.Tables(0).Rows(0).Item("Rol")

        lblRol.Text = Session("UsuarioAct.RolPeriodoAct")


        Select Case Session("UsuarioAct.RolPeriodoAct")
            Case "Acceso Completo"
                vNombreSP = "PGTotalesRedInfo"
                vArgumentos = "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha)

            Case "Jefe Red"
                vNombreSP = "PGTotalesRedInfo"
                vArgumentos = "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha)

            Case "Regional"
                vNombreSP = "PGTotalesRegionalInfo"
                vArgumentos = "@IdUsuarioRegional=" & Session("UsuarioAct.IdUsuario") & ", " & _
                              "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha)

            Case "Agente"
                vNombreSP = "PGTotalesAgenteInfo"
                vArgumentos = "@IdUsuarioAgente=" & Session("UsuarioAct.IdUsuario") & ", " & _
                              "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha)

        End Select

        If Session("UsuarioAct.Red") = 0 Or Session("UsuarioAct.Red") = 1 Then

            ds = cnn.EjecutarSP(vNombreSP, vArgumentos)

            With ds.Tables(0).Rows(0)
                If .Item("IdEstado") = 1 Then
                    DesplegarMensaje(TipoMensaje.MsgError, "ERROR - usuario sin información de resumen")
                    Exit Sub
                ElseIf .Item("IdEstado") <> 0 Then
                    DesplegarMensaje(TipoMensaje.MsgError, .Item("EstadoUsr"))
                    Dim lblInfoTec As Label = CType(Master.FindControl("lblInfoTec"), Label)
                    lblInfoTec.Text = vNombreSP & " " & vArgumentos & "<br>" & _
                                      ds.Tables(0).Rows(0).Item("EstadoTec")
                    Exit Sub
                End If

                lblAfiliaciones.Text = FormatNumber(.Item("Afiliaciones"), 0)
                lblCredPenCant.Text = FormatNumber(.Item("CredPenCant"), 0)
                lblCredPenMto.Text = FormatNumber(.Item("CredPenMto"), 0)
                lblCredTraCant.Text = FormatNumber(.Item("CredTraCant"), 0)
                lblCredTraMto.Text = FormatNumber(.Item("CredTraMto"), 0)

                lblCliWel.Text = FormatNumber(Nz(.Item("CliWel"), 0), 0)
                lblCliWelCred.Text = FormatNumber(.Item("CliWelCred"), 0)
                lblCumCliWelCred.Text = FormatPercent(Nz(.Item("CumCliWelCred"), 0), 0)

                lblCuponesMeta.Text = FormatNumber(Nz(.Item("CuponesMeta"), 0), 0)
                lblCuponesRutEntregados.Text = FormatNumber(Nz(.Item("CuponesRutEntregados"), 0), 0)
                lblCumCupones.Text = FormatPercent(Nz(.Item("CumCupones"), 0), 0)

                lblMetaTrab.Text = FormatNumber(Nz(.Item("MetaTrab"), 0), 0)
                lblSegurosTrab.Text = FormatNumber(Nz(.Item("SegurosTrab"), 0), 0)
                lblCumTrab.Text = FormatPercent(Nz(.Item("CumpTrab"), 0), 0)

                lblMetaPens.Text = FormatNumber(Nz(.Item("MetaPens"), 0), 0)
                lblSegurosPens.Text = FormatNumber(Nz(.Item("SegurosPens"), 0), 0)
                lblCumPens.Text = FormatPercent(Nz(.Item("CumpPens"), 0), 0)

                lblMetaCes.Text = FormatNumber(Nz(.Item("MetaCes"), 0), 0)
                lblSegurosCes.Text = FormatNumber(Nz(.Item("SegurosCes"), 0), 0)
                lblCumCes.Text = FormatPercent(Nz(.Item("CumpCes"), 0), 0)
            End With
        End If

        vNombreSP = "PGAccesosCompartidosInfo"
        vArgumentos = "@IdUsuarioReceptor=" & Session("UsuarioAct.IdUsuario") & ", " & _
                      "@FecReferencia=" & VarSQL(DateTime.Today, TipoVar.Fecha)
        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)

        With ds.Tables(0).Rows(0)
            If .Item("IdEstado") = 0 Then
                gvAccesosCompartidos.DataSource = ds
                gvAccesosCompartidos.DataBind()

                lblAccesosCompartidos.Visible = True
                gvAccesosCompartidos.Visible = True
            Else
                lblAccesosCompartidos.Visible = False
                gvAccesosCompartidos.Visible = False
            End If
        End With


        If Not Session("Sistema.MensajeInicial") Is Nothing Then
            DesplegarMensaje(TipoMensaje.MsgInformacion, Session("Sistema.MensajeInicial"))
            Session("Sistema.MensajeInicial") = Nothing
        End If

    End Sub

    Public Enum TipoMensaje
        MsgInformacion
        MsgError
    End Enum

    Sub DesplegarMensaje(ByVal Tipo As TipoMensaje, Mensaje As String)

        Select Case Tipo
            Case TipoMensaje.MsgInformacion
                PanMsg1.CssClass = "ui-widget ui-state-highlight ui-corner-all"
                PanMsg11.CssClass = "ui-icon ui-icon-info"

            Case TipoMensaje.MsgError
                PanMsg1.CssClass = "ui-widget ui-state-error ui-corner-all"
                PanMsg11.CssClass = "ui-icon ui-icon-circle-close"

        End Select

        lblInfoUsr.Text = Mensaje
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "MostrarMensaje();", True)

    End Sub

    Protected Sub btnCambiarContraseña_Click(sender As Object, e As EventArgs) Handles btnCambiarContraseña.Click
        Session("CambiarContraseña.FormPrev") = "~/" & Request.Url.Segments.Last()
        Response.Redirect("~/CambiarContraseña.aspx")
    End Sub

    Private Sub gvAccesosCompartidos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvAccesosCompartidos.RowCommand

        Select Case e.CommandName
            Case "ReiniciarSesion"

                Dim vEmail As String
                vEmail = e.CommandArgument

                Dim vNombreSP As String = "PGIniciarSesion"
                Dim vArgumentos As String = "@Email='" & vEmail & "', " & _
                                            "@Contraseña='88FD8A4C-5D57-4B46-AD43-3B34A45DAA53'"

                Dim cnn As New WebApp.Conexion, ds As DataSet

                ds = cnn.EjecutarSP(vNombreSP, vArgumentos)

                If ds.Tables(0).Rows(0).Item("IdEstado") < 0 Then
                    DesplegarMensaje(TipoMensaje.MsgError, ds.Tables(0).Rows(0).Item("EstadoUsr"))
                    Dim lblInfoTec As Label = CType(Master.FindControl("lblInfoTec"), Label)
                    lblInfoTec.Text = vNombreSP & " " & vArgumentos & "<br>" & _
                                      ds.Tables(0).Rows(0).Item("EstadoTec")
                    Exit Sub
                End If

                'Establecer variables de sesión (replicado en Site.Master.btnIniciarSesion_Click)
                Session("UsuarioAct.IdUsuario") = ds.Tables(0).Rows(0).Item("IdUsuario")
                Session("UsuarioAct.Usuario") = ds.Tables(0).Rows(0).Item("Usuario")
                Session("UsuarioAct.Email") = vEmail
                Session("UsuarioAct.Red") = ds.Tables(0).Rows(0).Item("Red")
                Session("UsuarioAct.Coachings") = ds.Tables(0).Rows(0).Item("Coachings")

                Session("Sistema.MensajeInicial") = "Sesión reiniciada como '" & ds.Tables(0).Rows(0).Item("Usuario") & "'."
                Response.Redirect("~/MenuPrincipal.aspx")
        End Select


    End Sub
End Class