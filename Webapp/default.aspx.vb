Imports System.Net
Public Class _default
    Inherits System.Web.UI.Page
    Dim vNombreSP As String
    Dim vArgumentos As String
    Dim cnn As New Webapp.Conexion
    Dim ds As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("UsuarioAct.Usuario")) Then
            plMantenedor.Visible = False
        Else
            plMantenedor.Visible = True
        End If

    End Sub

End Class