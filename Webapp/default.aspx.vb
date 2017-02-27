Imports System.Net
Public Class _default
    Inherits System.Web.UI.Page
    Dim vNombreSP As String
    Dim vArgumentos As String
    Dim cnn As New Webapp.Conexion
    Dim ds As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(Session("UsuarioAct.Usuario")) Then
            AccesoOk.Visible = False
        Else
            AccesoOk.Visible = True
            lblNombreUsuario.Text = Session("UsuarioAct.NombBt")
            lblSucursalIngreso.Text = Session("UsuarioAct.Sucursal2")

        End If
        'If Session("UsuarioAct.Agente") = 1 Then
        'Session("Usuario.Menu") = 0
        'End If
        Session("Usuario.Menu") = 1
    End Sub

End Class