Public Class AficanRegional
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Llenar_Grilla1()
        Llenar_Datos_Totales()

    End Sub

    Private Sub Llenar_Grilla1()

        Dim SpNombre As String
        Dim SpArgumento As String


        SpNombre = "PGAficanTotalesRegionalInfo"

        SpArgumento = "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha)


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
        lblNombre.Text = "Afiliaciones Red" & " - " & NomMes(Session("App.PeriodoActivo")) & " " & Year(Session("App.PeriodoActivo"))
        gv1.Visible = True
        gv1.DataSource = ds1
        gv1.DataBind()


    End Sub

    Private Sub Llenar_Datos_Totales()

        Dim SpNombre As String
        Dim SpArgumento As String


        SpNombre = "PGAficanTotalesRedInfo"

        SpArgumento = "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha)


        Dim cnn As New WebApp.Conexion
        Dim ds1 As DataSet = cnn.EjecutarSP(SpNombre, SpArgumento)

        With ds1.Tables(0).Rows(0)
            If .Item("IdEstado") <> 0 Then
                gv1.Visible = False

                If .Item("IdEstado") <> 1 Then


                End If
                Exit Sub
            End If
        End With
        lblExtraccion.Text = ""

        lblAfiRed.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("AfiliacionesRed"), 0)
        lblMetaRed.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("MetaRed"), 0)
        lblCumpRed.Text = FormatPercent(ds1.Tables(0).Rows(0).Item("PrcPropCumRed"), 1)
        lblAfiIn.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("AfiliacionesIn"), 0)
        lblMetaIn.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("MetaIn"), 0)
        lblCumpIn.Text = FormatPercent(ds1.Tables(0).Rows(0).Item("PrcPropCumIn"), 1)
        lblAfiOut.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("AfiliacionesOut"), 0)
        lblMetaOut.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("MetaOut"), 0)
        lblCumpOut.Text = FormatPercent(ds1.Tables(0).Rows(0).Item("PrcPropCumOut"), 1)
        lblAfiBen.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("AfiliacionesBen"), 0)
        lblMetaBen.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("MetaBen"), 0)
        lblCumpBen.Text = FormatPercent(ds1.Tables(0).Rows(0).Item("PrcPropCumBen"), 1)
        lblAfiFFAA.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("AfiliacionesFfaa"), 0)
        lblMetaFFAA.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("MetaFfaa"), 0)
        lblCumpFFAA.Text = FormatPercent(ds1.Tables(0).Rows(0).Item("PrcPropCumFfaa"), 1)
        lblMetaTotal.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("MetaTotal"), 0)
        lblTotalAfi.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("TotalAFi"), 0)
        lblCumPropTotal.Text = FormatPercent(ds1.Tables(0).Rows(0).Item("CumpPropTotal"), 1)


    End Sub
    Private Sub gv1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv1.RowCommand

        Select Case e.CommandName
            Case "VerRegional"
                Session("Regional.ConsultaActiva") = "IdUsuarioRegional=" & e.CommandArgument
                Response.Redirect("~/Afican/AficanAgente.aspx")

        End Select


    End Sub

End Class