Public Class AficanPec
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = True Then Exit Sub

        Llenar_Grilla()
        Llenar_Datos_Totales()

    End Sub

    Private Sub Llenar_Grilla()

        Dim SpNombre As String
        Dim SpArgumento As String


        SpNombre = "PGAficanTotalesPecInfo"

        SpArgumento = "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha) & _
                ", @CodSucursal= " & Session("AficanSucursal.Id")



        Dim cnn As New WebApp.Conexion
        Dim ds1 As DataSet = cnn.EjecutarSP(SpNombre, SpArgumento)

        With ds1.Tables(0).Rows(0)
            If .Item("IdEstado") <> 0 Then
                gv1.Visible = False
                lblExtraccion.Text = "No cuenta con registros para este periodo"
                If .Item("IdEstado") <> 1 Then


                End If
                Exit Sub
            End If
        End With
        lblExtraccion.Text = ""
        lblNombre.Text = "Sucursal: " & ds1.Tables(0).Rows(0).Item("SUCURSAL BT") & " - " & NomMes(Session("App.PeriodoActivo")) & " " & Year(Session("App.PeriodoActivo"))
        gv1.Visible = True
        gv1.DataSource = ds1
        gv1.DataBind()

    End Sub

    Private Sub Llenar_Datos_Totales()

        Dim SpNombre As String
        Dim SpArgumento As String


        SpNombre = "PGAficanTotalesSucursalInfo"

        SpArgumento = "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha) & _
                ", @CodSucursal= " & Session("AficanSucursal.Id")



        Dim cnn As New WebApp.Conexion
        Dim ds1 As DataSet = cnn.EjecutarSP(SpNombre, SpArgumento)

        With ds1.Tables(0).Rows(0)
            If .Item("IdEstado") <> 0 Then
                gv1.Visible = False
                lblExtraccion.Text = "No cuenta con registros para este periodo"
                If .Item("IdEstado") <> 1 Then


                End If
                Exit Sub
            End If
        End With
        lblExtraccion.Text = ""


        lblAfiRed.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("AfiliacionesRed"), 0)
        lblAfiIn.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("AfiliacionesIn"), 0)
        lblAfiOut.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("AfiliacionesOut"), 0)
        lblAfiFFAA.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("AfiliacionesFfaa"), 0)
        lblTotalAfi.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("AfiliacionesFfaa"), 0)

    End Sub

End Class