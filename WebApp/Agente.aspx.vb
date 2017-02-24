Public Class Agente
    Inherits BaseWebForms

    Const vFormAct As String = "Agente"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = True Then Exit Sub

        vArgApe = FormatoAplicacion(Nz(Session(vFormAct & ".ConsultaActiva"), ""))
        vArgAct = ObtenerArgumento("IdUsuarioAgente", vArgApe)

        If vArgAct.Length = 0 Then
            DesplegarMensaje(TipoMensaje.MsgError, "Error - Id registro no establecido")
            Exit Sub
        End If

        vNombreSP = "PGTotalesAgenteInfo"
        vArgumentos = "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha) & ", " & _
                      "@IdUsuarioAgente=" & vArgAct

        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
        With ds.Tables(0).Rows(0)
            If .Item("IdEstado") <> 0 Then
                DesplegarMensaje(TipoMensaje.MsgError, .Item("EstadoUsr"))
                Dim lblInfoTec As Label = CType(Master.FindControl("lblInfoTec"), Label)
                lblInfoTec.Text = vNombreSP & " " & vArgumentos & "<br>" & _
                                  ds.Tables(0).Rows(0).Item("EstadoTec")
                Exit Sub
            End If


            lblTitulo.Text = "Agente " & .Item("UsuarioAgente") & " - " & NomMes(Session("App.PeriodoActivo")) & " " & Year(Session("App.PeriodoActivo"))

            If Not (.Item("MetaAfiliaciones") Is DBNull.Value) Then lblMetaAfiliaciones.Text = FormatNumber(.Item("MetaAfiliaciones"), 0)
            If Not (.Item("MetaPropAfiliaciones") Is DBNull.Value) Then lblMetaPropAfiliaciones.Text = FormatNumber(.Item("MetaPropAfiliaciones"), 0)
            If Not (.Item("Afiliaciones") Is DBNull.Value) Then lblAfiliaciones.Text = FormatNumber(.Item("Afiliaciones"), 0)
            If Not (.Item("AfiliacionesUDH") Is DBNull.Value) Then lblAfiliacionesUDH.Text = FormatNumber(.Item("AfiliacionesUDH"), 0)
            If Not (.Item("CumAfiliaciones") Is DBNull.Value) Then lblCumAfiliaciones.Text = FormatPercent(.Item("CumAfiliaciones"), 0)

            If Not (.Item("CredPenCant") Is DBNull.Value) Then lblCredPenCant.Text = FormatNumber(.Item("CredPenCant"), 0)
            If Not (.Item("CredPenCantUDH") Is DBNull.Value) Then CredPenCantUDH.Text = FormatNumber(.Item("CredPenCantUDH"), 0)
            If Not (.Item("MetaCredPenMto") Is DBNull.Value) Then lblMetaCredPenMto.Text = FormatNumber(.Item("MetaCredPenMto"), 1)
            If Not (.Item("MetaPropCredPenMto") Is DBNull.Value) Then lblMetaPropCredPenMto.Text = FormatNumber(.Item("MetaPropCredPenMto"), 1)
            If Not (.Item("CredPenMto") Is DBNull.Value) Then lblCredPenMto.Text = FormatNumber(.Item("CredPenMto"), 1)
            If Not (.Item("CredPenMtoUDH") Is DBNull.Value) Then lblCredPenMtoUDH.Text = FormatNumber(.Item("CredPenMtoUDH"), 1)
            If Not (.Item("CumCredPenMto") Is DBNull.Value) Then lblCumCredPenMto.Text = FormatPercent(.Item("CumCredPenMto"), 0)
            If Not (.Item("CumCredPenMto") Is DBNull.Value) Then lblCumCredPenMto.Text = FormatPercent(.Item("CumCredPenMto"), 0)

            If Not (.Item("CredTraCant") Is DBNull.Value) Then lblCredTraCant.Text = FormatNumber(.Item("CredTraCant"), 0)
            If Not (.Item("CredTraCantUDH") Is DBNull.Value) Then CredTraCantUDH.Text = FormatNumber(.Item("CredTraCantUDH"), 0)
            If Not (.Item("MetaCredTraMto") Is DBNull.Value) Then lblMetaCredTraMto.Text = FormatNumber(.Item("MetaCredTraMto"), 1)
            If Not (.Item("MetaPropCredTraMto") Is DBNull.Value) Then lblMetaPropCredTraMto.Text = FormatNumber(.Item("MetaPropCredTraMto"), 1)
            If Not (.Item("CredTraMto") Is DBNull.Value) Then lblCredTraMto.Text = FormatNumber(.Item("CredTraMto"), 1)
            If Not (.Item("CredTraMtoUDH") Is DBNull.Value) Then CredTraMtoUDH.Text = FormatNumber(.Item("CredTraMtoUDH"), 1)
            If Not (.Item("CumCredTraMto") Is DBNull.Value) Then lblCumCredTraMto.Text = FormatPercent(.Item("CumCredTraMto"), 0)

            If Not (.Item("CliWel") Is DBNull.Value) Then lblCliWel.Text = FormatNumber(.Item("CliWel"), 0)
            If Not (.Item("CliWelCred") Is DBNull.Value) Then lblCliWelCred.Text = FormatNumber(.Item("CliWelCred"), 0)
            If Not (.Item("CumCliWelCred") Is DBNull.Value) Then lblCumCliWelCred.Text = FormatPercent(.Item("CumCliWelCred"), 0)

            If Not (.Item("CuponesMeta") Is DBNull.Value) Then lblCuponesMeta.Text = FormatNumber(.Item("CuponesMeta"), 0)
            If Not (.Item("CuponesRutEntregados") Is DBNull.Value) Then lblCuponesRutEntregados.Text = FormatNumber(.Item("CuponesRutEntregados"), 0)
            If Not (.Item("CumCupones") Is DBNull.Value) Then lblCumCupones.Text = FormatPercent(.Item("CumCupones"), 0)

            If Not (.Item("MetaTrab") Is DBNull.Value) Then lblMetaSegTrab.Text = FormatNumber(.Item("MetaTrab"), 0)
            If Not (.Item("MetaPropTrab") Is DBNull.Value) Then lblMetaSegPondTrab.Text = FormatNumber(.Item("MetaPropTrab"), 0)
            If Not (.Item("SegurosTrab") Is DBNull.Value) Then lblSegurosTrab.Text = FormatNumber(.Item("SegurosTrab"), 0)
            If Not (.Item("CumpTrab") Is DBNull.Value) Then lblCumpTrab.Text = FormatPercent(.Item("CumpTrab"), 0)

            If Not (.Item("MetaPens") Is DBNull.Value) Then lblMetaSegPens.Text = FormatNumber(.Item("MetaPens"), 0)
            If Not (.Item("MetaPropPens") Is DBNull.Value) Then lblMetaSegPondPens.Text = FormatNumber(.Item("MetaPropPens"), 0)
            If Not (.Item("SegurosPens") Is DBNull.Value) Then lblSegurosPens.Text = FormatNumber(.Item("SegurosPens"), 0)
            If Not (.Item("CumpPens") Is DBNull.Value) Then lblCumpPens.Text = FormatPercent(.Item("CumpPens"), 0)

            If Not (.Item("MetaCes") Is DBNull.Value) Then lblMetaSegCes.Text = FormatNumber(.Item("MetaCes"), 0)
            If Not (.Item("MetaPropCes") Is DBNull.Value) Then lblMetaSegPondCes.Text = FormatNumber(.Item("MetaPropCes"), 0)
            If Not (.Item("SegurosCes") Is DBNull.Value) Then lblSegurosCes.Text = FormatNumber(.Item("SegurosCes"), 0)
            If Not (.Item("CumpCes") Is DBNull.Value) Then lblCumpCes.Text = FormatPercent(.Item("CumpCes"), 0)
        End With

        CargarGv1()

    End Sub

    Sub CargarGv1()

        vArgApe = FormatoAplicacion(Nz(Session(vFormAct & ".ConsultaActiva"), ""))
        vArgAct = ObtenerArgumento("IdUsuarioAgente", vArgApe)

        vNombreSP = "PGTotalesSucursalInfo"

        vArgumentos = "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha) & ", " & _
                      "@IdUsuarioAgente=" & vArgAct

        If Not IsNothing(Session(vFormAct & ".Ordenar")) Then _
          vArgumentos += ", @Ordenar=" & VarSQL(Session(vFormAct & ".Ordenar"), TipoVar.Texto)


        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)

        With ds.Tables(0).Rows(0)
            If .Item("IdEstado") <> 0 Then
                gv1.Visible = False
                If .Item("IdEstado") <> 1 Then
                    DesplegarMensaje(TipoMensaje.MsgError, .Item("EstadoUsr"))
                    Dim lblInfoTec As Label = CType(Master.FindControl("lblInfoTec"), Label)
                    lblInfoTec.Text = vNombreSP & " " & vArgumentos & "<br>" & _
                                      ds.Tables(0).Rows(0).Item("EstadoTec")
                End If
                Exit Sub
            End If
        End With


        gv1.Visible = True
        gv1.DataSource = ds.Tables(0)
        gv1.DataBind()

        gv2.Visible = True
        gv2.DataSource = ds.Tables(0)
        gv2.DataBind()

    End Sub

    Protected Sub Ordenar(sender As Object, e As EventArgs) Handles lbSucursal.Click,
                                                                    lbMetaAfiliaciones.Click,
                                                                    lbMetaPropAfiliaciones.Click,
                                                                    lbAfiliaciones.Click,
                                                                    lbCumAfiliaciones.Click,
                                                                    lbCredPenCant.Click,
                                                                    lbMetaCredPenMto.Click,
                                                                    lbMetaPropCredPenMto.Click,
                                                                    lbCredPenMto.Click,
                                                                    lbCumCredPenMto.Click,
                                                                    lbCredTraCant.Click,
                                                                    lbMetaCredTraMto.Click,
                                                                    lbMetaPropCredTraMto.Click,
                                                                    lbCredTraMto.Click,
                                                                    lbCumCredTraMto.Click,
                                                                    lbCliWel.Click,
                                                                    lbCliWelCred.Click,
                                                                    lbCumCliWelCred.Click,
                                                                    lbCuponesMeta.Click,
                                                                    lbCuponesRutEntregados.Click,
                                                                    lbCumCupones.Click,
                                                                    lbMetaTrab.Click,
                                                                    lbMetaPropTrab.Click,
                                                                    lbSegTrab.Click,
                                                                    lbCumpTrab.Click,
                                                                    lbMetaPens.Click,
                                                                    lbMetaPropPens.Click,
                                                                    lbSegPens.Click,
                                                                    lbCumpPens.Click,
                                                                    lbMetaCes.Click,
                                                                    lbMetaPropCes.Click,
                                                                    lbSegCes.Click,
                                                                    lbCumpCes.Click

        Dim lb As LinkButton = sender
        Dim vCampo As String = lb.CommandArgument

        If Session(vFormAct & ".Ordenar") <> vCampo & " ASC" Then
            Session(vFormAct & ".Ordenar") = vCampo & " ASC"
        Else
            Session(vFormAct & ".Ordenar") = vCampo & " DESC"
        End If

        CargarGv1()

    End Sub

    Private Sub gv1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv1.RowCommand

        Select Case e.CommandName
            Case "VerSucursal"
                Session("Sucursal.ConsultaActiva") = "CodSucursal=" & e.CommandArgument
                Session("Sucursal.Ordenar") = "UsuarioIngreso"
                Session("Sucursal.FormPrev") = "~/Agente.aspx"
                Response.Redirect("~/Sucursal.aspx")

        End Select

    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        If Not IsNothing(Session(vFormAct & ".FormPrev")) Then
            Response.Redirect(Session(vFormAct & ".FormPrev"))
        Else
            Response.Redirect("~/MenuPrincipal.aspx")
        End If
    End Sub

    'Dim dTotal As Integer = 0
    'Private Sub GridDatos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("SegurosTrab")) Then
    '            dTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SegurosTrab"))
    '            Exit Sub
    '        Else
    '            dTotal = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblToST.Text = FormatNumber(dTotal.ToString("c"), 0)
    '    End If
    'End Sub
    'Dim dTotal2 As Integer = 0
    'Private Sub GridDatos_RowDataBound2(sender As Object, e As GridViewRowEventArgs) Handles gv1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("SegurosPens")) Then
    '            dTotal2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SegurosPens"))
    '            Exit Sub
    '        Else
    '            dTotal2 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblToSP.Text = FormatNumber(dTotal2.ToString("c"), 0)
    '    End If
    'End Sub
    'Dim dTotal3 As Integer = 0
    'Private Sub GridDatos_RowDataBound3(sender As Object, e As GridViewRowEventArgs) Handles gv1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("SegurosCes")) Then
    '            dTotal3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SegurosCes"))
    '            Exit Sub
    '        Else
    '            dTotal3 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblToSC.Text = FormatNumber(dTotal3.ToString("c"), 0)
    '    End If
    'End Sub
    'Dim dTotal4 As Decimal = 0
    'Private Sub GridDatos_RowDataBound4(sender As Object, e As GridViewRowEventArgs) Handles gv1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("MetaPondT")) Then
    '            dTotal4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaPondT"))
    '            Exit Sub
    '        Else
    '            dTotal4 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblMetaST.Text = dTotal4
    '    End If
    'End Sub
    'Dim dTotal5 As Decimal = 0
    'Private Sub GridDatos_RowDataBound5(sender As Object, e As GridViewRowEventArgs) Handles gv1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("MetaPondP")) Then
    '            dTotal5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaPondP"))
    '            Exit Sub
    '        Else
    '            dTotal5 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblMetaSP.Text = dTotal5
    '    End If
    'End Sub
    'Dim dTotal6 As Decimal = 0
    'Private Sub GridDatos_RowDataBound6(sender As Object, e As GridViewRowEventArgs) Handles gv1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("MetaPondC")) Then
    '            dTotal6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaPondC"))
    '            Exit Sub
    '        Else
    '            dTotal6 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblMetaSC.Text = dTotal6
    '    End If
    'End Sub
    'Dim dTotal7 As Integer = 0
    'Private Sub GridDatos_RowDataBound7(sender As Object, e As GridViewRowEventArgs) Handles gv1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("MetaTotalT")) Then
    '            dTotal7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaTotalT"))
    '            Exit Sub
    '        Else
    '            dTotal7 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblMetaSTT.Text = FormatNumber(dTotal7.ToString("c"), 0)
    '    End If
    'End Sub
    'Dim dTotal8 As Integer = 0
    'Private Sub GridDatos_RowDataBound8(sender As Object, e As GridViewRowEventArgs) Handles gv1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("MetaTotalP")) Then
    '            dTotal8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaTotalP"))
    '            Exit Sub
    '        Else
    '            dTotal8 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblMetaSPT.Text = FormatNumber(dTotal8.ToString("c"), 0)
    '    End If
    'End Sub
    'Dim dTotal9 As Integer = 0
    'Private Sub GridDatos_RowDataBound9(sender As Object, e As GridViewRowEventArgs) Handles gv1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("MetaTotalC")) Then
    '            dTotal9 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaTotalC"))
    '            Exit Sub
    '        Else
    '            dTotal9 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblMetaSCT.Text = FormatNumber(dTotal9.ToString("c"), 0)
    '    End If
    'End Sub
    'Dim dTotal10 As Decimal = 0
    'Dim MetaT As Decimal = 0
    'Private Sub GridDatos_RowDataBound10(sender As Object, e As GridViewRowEventArgs) Handles gv1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("SegurosTrab")) Then
    '            dTotal10 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SegurosTrab"))
    '            MetaT += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaPondT"))
    '            Exit Sub
    '        Else
    '            dTotal10 = 0
    '            MetaT = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If MetaT < 1 Then
    '        LblCumpT.Text = "0"
    '    Else
    '        If e.Row.RowType = DataControlRowType.Footer Then
    '            LblCumpT.Text = FormatPercent((dTotal10.ToString("c")) / (MetaT), 0)
    '        End If
    '    End If
    'End Sub
    'Dim dTotal11 As Decimal = 0
    'Dim MetaP As Decimal = 0
    'Private Sub GridDatos_RowDataBound11(sender As Object, e As GridViewRowEventArgs) Handles gv1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("SegurosPens")) Then
    '            dTotal11 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SegurosPens"))
    '            MetaP += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaPondP"))
    '            Exit Sub
    '        Else
    '            dTotal11 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If MetaP < 1 Then
    '        LblCumpP.Text = "0"
    '    Else
    '        If e.Row.RowType = DataControlRowType.Footer Then
    '            LblCumpP.Text = FormatPercent((dTotal11.ToString("c")) / (MetaP), 0)
    '        End If
    '    End If
    'End Sub
    'Dim dTotal12 As Decimal = 0
    'Dim MetaC As Decimal = 0
    'Private Sub GridDatos_RowDataBound12(sender As Object, e As GridViewRowEventArgs) Handles gv1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("SegurosCes")) Then
    '            dTotal12 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SegurosCes"))
    '            MetaC += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaPondC"))
    '            Exit Sub
    '        Else
    '            dTotal12 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If MetaC < 1 Then
    '        LblCumpC.Text = "0"
    '    Else
    '        If e.Row.RowType = DataControlRowType.Footer Then
    '            LblCumpC.Text = FormatPercent((dTotal12.ToString("c")) / (MetaC), 0)
    '        End If
    '    End If


    'End Sub
End Class