Public Class Red
    Inherits BaseWebForms

    Const vFormAct As String = "Red"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = True Then Exit Sub

        vNombreSP = "PGTotalesRedInfo"
        vArgumentos = "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha)

        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)

        With ds.Tables(0).Rows(0)
            If .Item("IdEstado") <> 0 Then
                DesplegarMensaje(TipoMensaje.MsgError, .Item("EstadoUsr"))
                Dim lblInfoTec As Label = CType(Master.FindControl("lblInfoTec"), Label)
                lblInfoTec.Text = vNombreSP & " " & vArgumentos & "<br>" &
                                  ds.Tables(0).Rows(0).Item("EstadoTec")
                Exit Sub
            End If

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

            If Not (.Item("CuponesMeta") Is DBNull.Value) Then lblCuponesMeta.Text = FormatNumber(.Item("CuponesMeta"), 0)
            If Not (.Item("CuponesRutEntregados") Is DBNull.Value) Then lblCuponesRutEntregados.Text = FormatNumber(.Item("CuponesRutEntregados"), 0)
            If Not (.Item("CumCupones") Is DBNull.Value) Then lblCumCupones.Text = FormatPercent(.Item("CumCupones"), 0)

            If Not (.Item("CuponesMeta") Is DBNull.Value) Then lblCuponesMeta.Text = FormatNumber(.Item("CuponesMeta"), 0)
            If Not (.Item("CuponesRutEntregados") Is DBNull.Value) Then lblCuponesRutEntregados.Text = FormatNumber(.Item("CuponesRutEntregados"), 0)
            If Not (.Item("CumCupones") Is DBNull.Value) Then lblCumCupones.Text = FormatPercent(.Item("CumCupones"), 0)

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

        vNombreSP = "PGTotalesRegionalInfo"
        vArgumentos = "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha)

        If Not IsNothing(Session(vFormAct & ".Ordenar")) Then _
          vArgumentos += ", @Ordenar=" & VarSQL(Session(vFormAct & ".Ordenar"), TipoVar.Texto)

        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)

        With ds.Tables(0).Rows(0)
            If .Item("IdEstado") <> 0 Then
                gv1.Visible = False
                If .Item("IdEstado") <> 1 Then
                    DesplegarMensaje(TipoMensaje.MsgError, .Item("EstadoUsr"))
                    Dim lblInfoTec As Label = CType(Master.FindControl("lblInfoTec"), Label)
                    lblInfoTec.Text = vNombreSP & " " & vArgumentos & "<br>" &
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

    Private Sub gv1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv1.RowCommand

        Select Case e.CommandName
            Case "VerRegional"
                Session("Regional.ConsultaActiva") = "IdUsuarioRegional=" & e.CommandArgument
                Session("Regional.Ordenar") = "UsuarioAgente"
                Session("Regional.FormPrev") = "~/Red.aspx"
                Response.Redirect("~/Regional.aspx")

        End Select

    End Sub

    Protected Sub Ordenar(sender As Object, e As EventArgs) Handles lbUsuarioRegional.Click,
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
                                                                    lbCumCupones.Click

        Dim lb As LinkButton = sender
        Dim vCampo As String = lb.CommandArgument

        If Session(vFormAct & ".Ordenar") <> vCampo & " ASC" Then
            Session(vFormAct & ".Ordenar") = vCampo & " ASC"
        Else
            Session(vFormAct & ".Ordenar") = vCampo & " DESC"
        End If

        CargarGv1()

    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        If Not IsNothing(Session(vFormAct & ".FormPrev")) Then
            Response.Redirect(Session(vFormAct & ".FormPrev"))
        Else
            Response.Redirect("~/MenuPrincipal.aspx")
        End If
    End Sub


End Class