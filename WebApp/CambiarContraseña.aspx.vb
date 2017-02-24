Public Class CambiarContraseña
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = True Then Exit Sub
        If IsNothing(Session("UsuarioAct.IdUsuario")) Then Response.Redirect("~/Default.aspx")

        lbUsuario.Text = Session("UsuarioAct.Usuario")

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        If IsNothing(Session("UsuarioAct.IdUsuario")) Then Response.Redirect("~/Default.aspx")

        'Cerrar sesión si se viene desde form Default
        If Session("CambiarContraseña.FormPrev") = "~/Default.aspx" Then
            Session("UsuarioAct.IdUsuario") = Nothing
        End If

        Response.Redirect(Session("CambiarContraseña.FormPrev"))

    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If IsNothing(Session("UsuarioAct.IdUsuario")) Then Response.Redirect("~/Default.aspx")

        If tbContraseñaAnterior.Text = "" Or _
           tbContraseñaNueva1.Text = "" Or _
           tbContraseñaNueva2.Text = "" Then
            DesplegarMensaje(TipoMensaje.MsgError, "Debe completar todos los datos solicitados")
            Exit Sub
        End If

        If tbContraseñaNueva1.Text <> tbContraseñaNueva2.Text Then
            DesplegarMensaje(TipoMensaje.MsgError, "Los valores de Contraseña nueva no coinciden")
            Exit Sub
        End If

        'Invocar procedimiento de cambio de contraseña
        Dim vIdUsuario As String = Session("UsuarioAct.IdUsuario")
        Dim vContraseñaAnterior As String = VarSQL(tbContraseñaAnterior.Text, TipoVar.Texto)
        Dim vContraseñaNueva As String = VarSQL(tbContraseñaNueva1.Text, TipoVar.Texto)

        Dim vNombreSP As String = "PGUsuariosCambiarContraseña"
        Dim vArgumentos As String = "@IdUsuario=" & vIdUsuario & ", " & _
                                    "@ContraseñaAnterior=" & vContraseñaAnterior & ", " & _
                                    "@ContraseñaNueva=" & vContraseñaNueva

        Dim cnn As New WebApp.Conexion
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)

        If ds.Tables(0).Rows(0).Item("IdEstado") = 0 Then
            Session("Sistema.MensajeInicial") = "Contraseña cambiada OK."
            Response.Redirect("~/MenuPrincipal.aspx")
        Else
            DesplegarMensaje(TipoMensaje.MsgError, ds.Tables(0).Rows(0).Item("EstadoUsr"))
            Dim lblInfoTec As Label = CType(Master.FindControl("lblInfoTec"), Label)
            lblInfoTec.Text = vNombreSP & " " & vArgumentos & "<br>" & _
                              ds.Tables(0).Rows(0).Item("EstadoTec")
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

End Class