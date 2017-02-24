Public Class Regional
    Inherits BaseWebForms

    Const vFormAct As String = "Regional"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = True Then Exit Sub

        vArgApe = FormatoAplicacion(Nz(Session(vFormAct & ".ConsultaActiva"), ""))
        vArgAct = ObtenerArgumento("IdUsuarioRegional", vArgApe)

        If vArgAct.Length = 0 Then
            DesplegarMensaje(TipoMensaje.MsgError, "Error - Id registro no establecido")
            Exit Sub
        End If

        vNombreSP = "PGTotalesRegionalInfo"
        vArgumentos = "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha) & ", " & _
                      "@IdUsuarioRegional=" & vArgAct

        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
        With ds.Tables(0).Rows(0)
            If .Item("IdEstado") <> 0 Then
                DesplegarMensaje(TipoMensaje.MsgError, .Item("EstadoUsr"))
                Dim lblInfoTec As Label = CType(Master.FindControl("lblInfoTec"), Label)
                lblInfoTec.Text = vNombreSP & " " & vArgumentos & "<br>" & _
                                  ds.Tables(0).Rows(0).Item("EstadoTec")
                Exit Sub
            End If


            lblTitulo.Text = "Regional " & .Item("UsuarioRegional") & " - " & NomMes(Session("App.PeriodoActivo")) & " " & Year(Session("App.PeriodoActivo"))

            If Not (.Item("MetaAfiliaciones") Is DBNull.Value) Then lblMetaAfiliaciones.Text = FormatNumber(.Item("MetaAfiliaciones"), 0)
            If Not (.Item("MetaPropAfiliaciones") Is DBNull.Value) Then lblMetaPropAfiliaciones.Text = FormatNumber(.Item("MetaPropAfiliaciones"), 0)
            If Not (.Item("Afiliaciones") Is DBNull.Value) Then lblAfiliaciones.Text = FormatNumber(.Item("Afiliaciones"), 0)
            If Not (.Item("AfiliacionesUDH") Is DBNull.Value) Then lblAfiliacionesUDH.Text = FormatNumber(.Item("AfiliacionesUDH"), 0)
            If Not (.Item("CumAfiliaciones") Is DBNull.Value) Then lblCumAfiliaciones.Text = FormatPercent(.Item("CumAfiliaciones"), 0)

            If Not (.Item("CredPenCant") Is DBNull.Value) Then lblCredPenCant.Text = FormatNumber(.Item("CredPenCant"), 0)
            If Not (.Item("CredPenCantUDH") Is DBNull.Value) Then lblCredPenCantUDH.Text = FormatNumber(.Item("CredPenCantUDH"), 0)
            If Not (.Item("MetaCredPenMto") Is DBNull.Value) Then lblMetaCredPenMto.Text = FormatNumber(.Item("MetaCredPenMto"), 1)
            If Not (.Item("MetaPropCredPenMto") Is DBNull.Value) Then lblMetaPropCredPenMto.Text = FormatNumber(.Item("MetaPropCredPenMto"), 1)
            If Not (.Item("CredPenMto") Is DBNull.Value) Then lblCredPenMto.Text = FormatNumber(.Item("CredPenMto"), 1)
            If Not (.Item("CredPenMtoUDH") Is DBNull.Value) Then lblCredPenMtoUDH.Text = FormatNumber(.Item("CredPenMtoUDH"), 1)
            If Not (.Item("CumCredPenMto") Is DBNull.Value) Then lblCumCredPenMto.Text = FormatPercent(.Item("CumCredPenMto"), 0)

            If Not (.Item("CredTraCant") Is DBNull.Value) Then lblCredTraCant.Text = FormatNumber(.Item("CredTraCant"), 0)
            If Not (.Item("CredTraCantUDH") Is DBNull.Value) Then lblCredTraCantUDH.Text = FormatNumber(.Item("CredTraCantUDH"), 0)
            If Not (.Item("MetaCredTraMto") Is DBNull.Value) Then lblMetaCredTraMto.Text = FormatNumber(.Item("MetaCredTraMto"), 1)
            If Not (.Item("MetaPropCredTraMto") Is DBNull.Value) Then lblMetaPropCredTraMto.Text = FormatNumber(.Item("MetaPropCredTraMto"), 1)
            If Not (.Item("CredTraMto") Is DBNull.Value) Then lblCredTraMto.Text = FormatNumber(.Item("CredTraMto"), 1)
            If Not (.Item("CredTraMtoUDH") Is DBNull.Value) Then lblCredTraMtoUDH.Text = FormatNumber(.Item("CredTraMtoUDH"), 1)
            If Not (.Item("CumCredTraMto") Is DBNull.Value) Then lblCumCredTraMto.Text = FormatPercent(.Item("CumCredTraMto"), 0)

            If Not (.Item("CliWel") Is DBNull.Value) Then lblCliWel.Text = FormatNumber(.Item("CliWel"), 0)
            If Not (.Item("CliWelCred") Is DBNull.Value) Then lblCliWelCred.Text = FormatNumber(.Item("CliWelCred"), 0)
            If Not (.Item("CumCliWelCred") Is DBNull.Value) Then lblCumCliWelCred.Text = FormatPercent(.Item("CumCliWelCred"), 0)

            If Not (.Item("CuponesMeta") Is DBNull.Value) Then lblCuponesMeta.Text = FormatNumber(.Item("CuponesMeta"), 0)
            If Not (.Item("CuponesRutEntregados") Is DBNull.Value) Then lblCuponesRutEntregados.Text = FormatNumber(.Item("CuponesRutEntregados"), 0)
            If Not (.Item("CumCupones") Is DBNull.Value) Then lblCumCupones.Text = FormatPercent(.Item("CumCupones"), 0)

            If Not (.Item("MetaTrab") Is DBNull.Value) Then lblMetaTrab.Text = FormatNumber(.Item("MetaTrab"), 0)
            If Not (.Item("MetaPropTrab") Is DBNull.Value) Then lblMetaPropTrab.Text = FormatNumber(.Item("MetaPropTrab"), 0)
            If Not (.Item("SegurosTrab") Is DBNull.Value) Then lblSegTrab.Text = FormatNumber(.Item("SegurosTrab"), 0)
            If Not (.Item("CumpTrab") Is DBNull.Value) Then lblCumpTrab.Text = FormatPercent(.Item("CumpTrab"), 0)

            If Not (.Item("MetaPens") Is DBNull.Value) Then lblMetaPens.Text = FormatNumber(.Item("MetaPens"), 0)
            If Not (.Item("MetaPropPens") Is DBNull.Value) Then lblMetaPropPens.Text = FormatNumber(.Item("MetaPropPens"), 0)
            If Not (.Item("SegurosPens") Is DBNull.Value) Then lblSegPens.Text = FormatNumber(.Item("SegurosPens"), 0)
            If Not (.Item("CumpPens") Is DBNull.Value) Then lblCumpPens.Text = FormatPercent(.Item("CumpTrab"), 0)

            If Not (.Item("MetaCes") Is DBNull.Value) Then lblMetaCes.Text = FormatNumber(.Item("MetaCes"), 0)
            If Not (.Item("MetaPropCes") Is DBNull.Value) Then lblMetaPropCes.Text = FormatNumber(.Item("MetaPropCes"), 0)
            If Not (.Item("SegurosCes") Is DBNull.Value) Then lblSegCes.Text = FormatNumber(.Item("SegurosCes"), 0)
            If Not (.Item("CumpCes") Is DBNull.Value) Then lblCumpCes.Text = FormatPercent(.Item("CumpCes"), 0)
        End With

        CargarGv1()

    End Sub

    Sub CargarGv1()

        vArgApe = FormatoAplicacion(Nz(Session(vFormAct & ".ConsultaActiva"), ""))
        vArgAct = ObtenerArgumento("IdUsuarioRegional", vArgApe)

        vNombreSP = "PGTotalesAgenteInfo"

        vArgumentos = "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha) & ", " & _
                      "@IdUsuarioRegional=" & vArgAct

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

    Protected Sub Ordenar(sender As Object, e As EventArgs) Handles lbUsuarioAgente.Click,
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
            Case "VerAgente"
                Session("Agente.ConsultaActiva") = "IdUsuarioAgente=" & e.CommandArgument
                Session("Agente.Ordenar") = "Sucursal"
                Session("Agente.FormPrev") = "~/Regional.aspx"
                Response.Redirect("~/Agente.aspx")

        End Select

    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        If Not IsNothing(Session(vFormAct & ".FormPrev")) Then
            Response.Redirect(Session(vFormAct & ".FormPrev"))
        Else
            Response.Redirect("~/MenuPrincipal.aspx")
        End If
    End Sub

    'Dim dTotal2 As Integer = 0
    'Private Sub GridDatos_RowDataBound2(sender As Object, e As GridViewRowEventArgs) Handles gv2.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("SegurosTrab")) Then
    '            dTotal2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SegurosTrab"))
    '            Exit Sub
    '        Else
    '            dTotal2 = 0
    '            Exit Sub
    '        End If

    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblT.Text = FormatNumber(dTotal2.ToString("c"), 0)
    '    End If
    'End Sub

    'Dim dTotal3 As Integer = 0
    'Private Sub GridDatos_RowDataBound3(sender As Object, e As GridViewRowEventArgs) Handles gv2.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("SegurosPens")) Then
    '            dTotal3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SegurosPens"))
    '            Exit Sub
    '        Else
    '            dTotal3 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblP.Text = FormatNumber(dTotal3.ToString("c"), 0)
    '    End If
    'End Sub

    'Dim dTotal4 As Integer = 0
    'Private Sub GridDatos_RowDataBound4(sender As Object, e As GridViewRowEventArgs) Handles gv2.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("SegurosCes")) Then
    '            dTotal4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SegurosCes"))
    '            Exit Sub
    '        Else
    '            dTotal4 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblC.Text = FormatNumber(dTotal4.ToString("c"), 0)
    '    End If
    'End Sub

    'Dim dTotal8 As Integer = 0
    'Private Sub GridDatos_RowDataBound8(sender As Object, e As GridViewRowEventArgs) Handles gv2.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("MetaTrab")) Then
    '            dTotal8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaTrab"))
    '            Exit Sub
    '        Else
    '            dTotal8 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblMetaT.Text = FormatNumber(dTotal8.ToString("c"), 0)
    '    End If
    'End Sub
    'Dim dTotal9 As Integer = 0
    'Private Sub GridDatos_RowDataBound9(sender As Object, e As GridViewRowEventArgs) Handles gv2.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("MetaPens")) Then
    '            dTotal9 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaPens"))
    '            Exit Sub
    '        Else
    '            dTotal9 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblMetaP.Text = FormatNumber(dTotal9.ToString("c"), 0)
    '    End If
    'End Sub
    'Dim dTotal10 As Integer = 0
    'Private Sub GridDatos_RowDataBound10(sender As Object, e As GridViewRowEventArgs) Handles gv2.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("MetaCes")) Then
    '            dTotal10 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaCes"))
    '            Exit Sub
    '        Else
    '            dTotal10 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblMetaC.Text = FormatNumber(dTotal10.ToString("c"), 0)
    '    End If
    'End Sub

    'Dim dTotal11 As Decimal = 0
    'Private Sub GridDatos_RowDataBound11(sender As Object, e As GridViewRowEventArgs) Handles gv2.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("MetaPondT")) Then
    '            dTotal11 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaPondT"))
    '            Exit Sub
    '        Else
    '            dTotal11 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblMetaPT.Text = dTotal11
    '    End If
    'End Sub

    'Dim dTotal12 As Decimal = 0
    'Private Sub GridDatos_RowDataBound12(sender As Object, e As GridViewRowEventArgs) Handles gv2.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("MetaPondP")) Then
    '            dTotal12 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaPondP"))
    '            Exit Sub
    '        Else
    '            dTotal12 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblMetaPP.Text = dTotal12
    '    End If
    'End Sub
    'Dim dTotal13 As Decimal = 0
    'Private Sub GridDatos_RowDataBound13(sender As Object, e As GridViewRowEventArgs) Handles gv2.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("MetaPondC")) Then
    '            dTotal13 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaPondC"))
    '            Exit Sub
    '        Else
    '            dTotal13 = 0
    '            Exit Sub
    '        End If
    '    End If
    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        lblMetaPC.Text = dTotal13
    '    End If
    'End Sub
    'Dim dTotal14 As Decimal = 0
    'Dim MetaT As Decimal = 0
    'Private Sub GridDatos_RowDataBound14(sender As Object, e As GridViewRowEventArgs) Handles gv2.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("MetaPondT")) Then
    '            dTotal14 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SegurosTrab"))
    '            MetaT += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaPondT"))

    '            Exit Sub
    '        Else
    '            lblCumpT.Text = "0"
    '            Exit Sub
    '        End If
    '    End If
    '    If MetaT <= 0 Then
    '        lblCumpT.Text = "0"
    '    Else
    '        If e.Row.RowType = DataControlRowType.Footer Then
    '                lblCumpT.Text = FormatPercent((dTotal14 / MetaT), 0)
    '            End If
    '        End If


    'End Sub
    'Dim dTotal15 As Decimal = 0
    'Dim MetaP As Decimal = 0
    'Private Sub GridDatos_RowDataBound15(sender As Object, e As GridViewRowEventArgs) Handles gv2.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("MetaPondP")) Then
    '            dTotal15 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SegurosPens"))
    '            MetaP += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaPondP"))
    '            Exit Sub
    '        Else
    '            lblCumpP.Text = "0"
    '            Exit Sub
    '        End If
    '    End If
    '    If MetaP <= 0 Then
    '        lblCumpP.Text = "0"
    '    Else
    '        If e.Row.RowType = DataControlRowType.Footer Then
    '            lblCumpP.Text = FormatPercent((dTotal15 / MetaP), 0)
    '        End If
    '    End If
    'End Sub
    'Dim dTotal16 As Integer = 0
    'Dim MetaC As Decimal = 0
    'Private Sub GridDatos_RowDataBound17(sender As Object, e As GridViewRowEventArgs) Handles gv2.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        If Not DBNull.Value.Equals(e.Row.DataItem("MetaPondC")) Then
    '            dTotal16 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SegurosCes"))
    '            MetaC += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MetaPondC"))
    '            Exit Sub
    '        Else
    '            lblCumpC.Text = "0"
    '            Exit Sub
    '        End If
    '    End If
    '    If MetaC <= 0 Then
    '        lblCumpC.Text = "0"
    '    Else
    '        If e.Row.RowType = DataControlRowType.Footer Then
    '            lblCumpC.Text = FormatPercent((dTotal16 / MetaC), 0)
    '        End If
    '    End If

    'End Sub
End Class