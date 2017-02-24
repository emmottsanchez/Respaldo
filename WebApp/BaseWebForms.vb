Public Class BaseWebForms
    Inherits System.Web.UI.Page

    'Gestion de transacciones en BD
    Public cnn As New WebApp.Conexion
    Public ds As DataSet
    Public vNombreSP As String
    Public vArgumentos As String

    'Lectura de parámetros de carga
    Public vArgApe As String
    Public vArgAct As String

    'Gestion de Mensajes usuario
    Public Enum TipoMensaje
        MsgInformacion
        MsgError
    End Enum

    Sub DesplegarMensaje(ByVal Tipo As TipoMensaje, Mensaje As String)


        Dim PanMsg1 As Panel = Me.Master.FindControl("cphPrincipal").FindControl("PanMsg1")
        Dim PanMsg11 As Panel = Me.Master.FindControl("cphPrincipal").FindControl("PanMsg11")
        Dim lblInfoUsr As Label = Me.Master.FindControl("cphPrincipal").FindControl("lblInfoUsr")

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

    Function ObtIdRegDesdeConsultaActiva(FormAct As String, NomCampoId As String) As String

        Dim vId As String = "0"
        If (Session(FormAct & ".ConsultaActiva") IsNot Nothing) Then

            Dim vArgApe = FormatoAplicacion(Nz(Session(FormAct & ".ConsultaActiva"), ""))
            Dim vArgAct = ObtenerArgumento(NomCampoId, vArgApe)
            If vArgAct.Length > 0 Then vId = vArgAct
        End If

        ObtIdRegDesdeConsultaActiva = vId

    End Function

End Class
