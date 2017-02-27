Public Class TomaConocimiento
    Inherits System.Web.UI.Page
    Dim vNombreSP As String
    Dim vArgumentos As String
    Dim cnn As New Webapp.Conexion
    Dim ds As DataSet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("UsuarioAct.Usuario")) Then
            Response.Redirect("~/default.aspx")
            Exit Sub
        End If
        If Page.IsPostBack = True Then Exit Sub
        LlenarDll()
        LlenarGv()
        Session("Usuario.Menu") = 1
    End Sub

    Private Sub LlenarGv()
        'ddlAño.SelectedIndex = 0
        vNombreSP = "exec CPECTomaConocimientoInfo "
        vArgumentos = "@Rut=" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & _
                      ", @Periodo=" & ddlAño.SelectedValue
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        GridTomaCon.Visible = True
        GridTomaCon.DataSource = ds
        GridTomaCon.DataBind()

    End Sub

    Private Sub LlenarDll()

        vNombreSP = "SET LANGUAGE Spanish SELECT  distinct(datename(year,Periodo)) as Año " & _
                    " FROM CPECUSUARIOS where Rut=" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & _
                    "order by (datename(year,Periodo)) desc"
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        ddlAño.DataValueField = "Año"
        ddlAño.DataTextField = "Año"
        ddlAño.DataSource = ds
        ddlAño.DataBind()
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        LlenarGv()
    End Sub


End Class