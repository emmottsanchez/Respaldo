Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Data
Public Class Mantenedor
    Inherits System.Web.UI.Page
    Dim vNombreSP As String
    Dim vArgumentos As String
    Dim cnn As New Webapp.Conexion
    Dim ds As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = True Then Exit Sub

        If IsNothing(Session("UsuarioAct.Usuario")) Then
            plMantenedorUser.Visible = False
        Else
            plMantenedorUser.Visible = True
        End If
        CDDL()
    End Sub

    Sub CDDL()

        vNombreSP = "SET LANGUAGE Spanish SELECT  distinct(datename(Month,Periodo)) as Mes,MONTH(Periodo) as N from CPECUsuarios where YEAR(Periodo)=2016 order by MONTH(Periodo) asc"
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        ddlMes.DataValueField = "N"
        ddlMes.DataTextField = "Mes"
        ddlMes.DataSource = ds
        ddlMes.DataBind()
    End Sub
End Class