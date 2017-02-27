Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Public Class Site
    Inherits System.Web.UI.MasterPage
    Dim vNombreSP As String
    Dim vArgumentos As String
    Dim cnn As New Webapp.Conexion
    Dim ds As DataSet
    Dim Destinatario As String
    Dim Nombre As String
    Dim Clave As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = True Then Exit Sub

        If IsNothing(Session("UsuarioAct.Usuario")) Then
            Pan_Log.Visible = True
            Pan_Logout.Visible = False
        Else
            Pan_Log.Visible = False
            Pan_Logout.Visible = True
            lblUsuarioRegistrado2.Text = Session("UsuarioAct.Usuario")

        End If
    End Sub

    Private Sub btnAcceder_Click(sender As Object, e As EventArgs) Handles btnAcceder.Click

        If tbUsuario.Text = "" Then
            lblError.Text = "* Debe ingresar Usuario"
            Exit Sub
        End If
        If tbContraseña.Text = "" Then
            lblError.Text = "* Debe ingresar Contraseña"
            Exit Sub
        End If

        'Administrador
        Dim vNombreSPAd As String = "IF EXISTS (select * from CPECAdmin where Rut=" & tbUsuario.Text & _
                                   " and Clave=" & tbContraseña.Text & ") SELECT 1 ELSE SELECT 0"
        Dim vArgumentosAd As String = ""
        Dim d As DataSet = cnn.EjecutarSP(vNombreSPAd, vArgumentosAd)
        If (d.Tables(0).Rows(0).Item(0) = 0) Then
            lblError.Text = "Usuario no existe en sistema"
            Exit Sub
        Else
            Dim vNombreSPA As String = "select * from CPECAdmin where Rut=" & tbUsuario.Text & _
                                  " and Clave=" & tbContraseña.Text
            Dim vArgumentosA As String = ""
            Dim dad As DataSet = cnn.EjecutarSP(vNombreSPA, vArgumentosA)
            Pan_Log.Visible = False
            Pan_Logout.Visible = True
            Session("UsuarioAct.Usuario") = dad.Tables(0).Rows(0).Item("Nombre")
            Response.Redirect("~/PagoIncentivos.aspx")

        End If

        'Fin Admin

    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Session("UsuarioAct.Usuario") = Nothing
        Response.Redirect("~/default.aspx")
    End Sub


    Private Sub btnPagoIncentivo_Click(sender As Object, e As EventArgs) Handles btnPagoIncentivo.Click
        Pan_Log.Visible = False
        Pan_Logout.Visible = True
        Response.Redirect("~/PagoIncentivos.aspx")
    End Sub

    

    Private Sub btnGraficos_Click(sender As Object, e As EventArgs) Handles btnGraficos.Click
        Pan_Log.Visible = False
        Pan_Logout.Visible = True
        Response.Redirect("~/Graficos.aspx")
    End Sub
End Class