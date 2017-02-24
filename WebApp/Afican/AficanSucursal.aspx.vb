Public Class AficanSucursal

    Inherits BaseWebForms

    Const vFormAct As String = "Agente"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Page.IsPostBack = True Then Exit Sub

        Cargar_Grilla()
        Cargar_Datos_Totales()
        
    End Sub

    Private Sub Cargar_Grilla()

        vArgApe = FormatoAplicacion(Nz(Session(vFormAct & ".ConsultaActiva"), ""))
        vArgAct = ObtenerArgumento("IdUsuarioAgente", vArgApe)


        Dim SpNombre As String
        Dim SpArgumento As String


        SpNombre = "PGAficanTotalesSucursalInfo"

        SpArgumento = "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha) & _
                ", @IdUsuarioAgente= " & vArgAct



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
        lblNombre.Text = "Agente: " & ds1.Tables(0).Rows(0).Item("Usuario") & " - " & NomMes(Session("App.PeriodoActivo")) & " " & Year(Session("App.PeriodoActivo"))
        gv1.Visible = True
        gv1.DataSource = ds1
        gv1.DataBind()

    End Sub

    Private Sub Cargar_Datos_Totales()


        vArgApe = FormatoAplicacion(Nz(Session(vFormAct & ".ConsultaActiva"), ""))
        vArgAct = ObtenerArgumento("IdUsuarioAgente", vArgApe)

        Dim SpNombre As String
        Dim SpArgumento As String


        SpNombre = "PGAficanTotalesAgenteInfo"

        SpArgumento = "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha) & _
                      ", @IdUsuarioAgente= " & vArgAct


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
        lblAfiFFAA.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("AfiliacionesFfaa"), 0)
        lblMetaFFAA.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("MetaFfaa"), 0)
        lblCumpFFAA.Text = FormatPercent(ds1.Tables(0).Rows(0).Item("PrcPropCumFfaa"), 1)
        lblMetaTotal.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("MetaTotal"), 0)
        lblTotalAfi.Text = FormatNumber(ds1.Tables(0).Rows(0).Item("TotalAFi"), 0)
        lblCumPropTotal.Text = FormatPercent(ds1.Tables(0).Rows(0).Item("CumpPropTotal"), 1)



    End Sub

    Private Sub gv1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv1.RowCommand

        Select Case e.CommandName
            Case "VerSucursal"
                Session("AficanSucursal.Id") = e.CommandArgument
                Response.Redirect("~/Afican/AficanPec.aspx")

        End Select


    End Sub


End Class


