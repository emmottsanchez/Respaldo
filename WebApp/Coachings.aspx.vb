Public Class Coachings
    Inherits BaseWebForms

    Const vFormAct As String = "Coachings"

    'Gestion de transacciones en BD
    Dim lbl As Label

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = True Then Exit Sub

        CargarDdls(sender, e)

        Dim vArgApe = FormatoAplicacion(Nz(Session(vFormAct & ".ConsultaActiva"), ""))

        vArgAct = ObtenerArgumento("IdUsrCreacion", vArgApe)
        If vArgAct.Length > 0 Then ddlParConsUsuarioCreacion.SelectedValue = vArgAct

        vArgAct = ObtenerArgumento("CodSucursal", vArgApe)
        If vArgAct.Length > 0 Then ddlParConsSucursal.SelectedValue = vArgAct

        vArgAct = ObtenerArgumento("FecCreacionDesde", vArgApe)
        If vArgAct.Length > 0 Then tbParConsFecCreacionDesde.Text = VarControl(vArgAct, TipoVar.Fecha)

        vArgAct = ObtenerArgumento("FecCreacionHasta", vArgApe)
        If vArgAct.Length > 0 Then tbParConsFecCreacionHasta.Text = VarControl(vArgAct, TipoVar.Fecha)

        vArgAct = ObtenerArgumento("Colaborador", vArgApe)
        If vArgAct.Length > 0 Then tbParConsColaborador.Text = VarControl(vArgAct, TipoVar.Texto)

        CargarGv1()

        If Not Session("Sistema.MensajeInicial") Is Nothing Then
            DesplegarMensaje(TipoMensaje.MsgInformacion, Session("Sistema.MensajeInicial"))
            Session("Sistema.MensajeInicial") = Nothing
        End If

    End Sub

    Sub CargarDdls(sender As Object, e As Object)

        'Cargar listados en elementos DropDownList de la página enlazados a datos

        Select Case Session("UsuarioAct.RolPeriodoAct")
            Case "Acceso Completo" 'Todos los usuarios
                ds = cnn.EjecutarSP("PGRolesUsuarioInfo", "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha) & ", " & _
                                                          "@Ordenar=Usuario")
                With ddlParConsUsuarioCreacion
                    .DataValueField = "IdUsuario"
                    .DataTextField = "Usuario"
                    .DataSource = ds
                    .DataBind()
                    .Items.Insert(0, New ListItem("(Todos)", "0"))
                End With

            Case "Jefe Red" 'Todos los usuarios dependientes en la red
                ds = cnn.EjecutarSP("PGRolesUsuarioInfo", "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha) & ", " & _
                                                          "@Red=" & Session("UsuarioAct.Red") & ", " & _
                                                          "@Ordenar=Usuario")
                With ddlParConsUsuarioCreacion
                    .DataValueField = "IdUsuario"
                    .DataTextField = "Usuario"
                    .DataSource = ds
                    .DataBind()
                    .Items.Insert(0, New ListItem("(Todos)", "0"))
                End With

            Case "Regional"
                ds = cnn.EjecutarSP("PGAgentesRegionalInfo", "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha) & ", " & _
                                                             "@IdUsuarioRegional=" & Session("UsuarioAct.IdUsuario") & ", " & _
                                                             "@Ordenar=UsuarioAgente")
                With ddlParConsUsuarioCreacion                    
                    If ds.Tables(0).Rows(0).Item("IdEstado") = 0 Then
                        .DataValueField = "IdUsuarioAgente"
                        .DataTextField = "UsuarioAgente"
                        .DataSource = ds
                        .DataBind()
                        .Items.Insert(0, New ListItem("<" & Session("UsuarioAct.Usuario") & ">", Session("UsuarioAct.IdUsuario")))
                        .Items.Insert(0, New ListItem("(Todos los usuarios dependientes)", "-1"))
                    Else
                        .Items.Insert(0, New ListItem("<" & Session("UsuarioAct.Usuario") & ">", Session("UsuarioAct.IdUsuario")))
                    End If
                End With

            Case "Agente"
                With ddlParConsUsuarioCreacion
                    .Items.Insert(0, New ListItem(Session("UsuarioAct.Usuario"), Session("UsuarioAct.IdUsuario")))
                End With

        End Select

        ds = cnn.EjecutarSP("SucursalesBTInfo", "")
        With ddlParConsSucursal
            .DataValueField = "CODIGO BT"
            .DataTextField = "SUCURSAL BT"
            .DataSource = ds
            .DataBind()
            .Items.Insert(0, New ListItem("(Seleccionar)", "0"))
        End With

    End Sub

    Sub CargarGv1()

        vNombreSP = "PGCoachingsInfo"
        vArgumentos = ""

        If Me.ddlParConsUsuarioCreacion.SelectedValue <> "0" Then

            If Me.ddlParConsUsuarioCreacion.SelectedValue = "-1" Then
                'Consulta por usuario asociado a regional
                vArgumentos += ", @IdUsuarioRegional=" & Session("UsuarioAct.IdUsuario") & _
                               ", @PeriodoUsuarioRegional=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha)
            Else
                'Consulta por usuario normal (agente o regional)
                vArgumentos += ", @IdUsrCreacion=" & VarSQL(Me.ddlParConsUsuarioCreacion.SelectedValue, TipoVar.Numerico, True)
            End If

        End If

        If Me.ddlParConsSucursal.SelectedValue <> "0" Then _
          vArgumentos += ", @CodSucursal=" & VarSQL(Me.ddlParConsSucursal.SelectedValue, TipoVar.Numerico, True)

        If Me.tbParConsFecCreacionDesde.Text <> "" Then _
            vArgumentos += ", @FecCreacionDesde=" & VarSQL(Me.tbParConsFecCreacionDesde.Text, TipoVar.Fecha)

        If Me.tbParConsFecCreacionHasta.Text <> "" Then _
            vArgumentos += ", @FecCreacionHasta=" & VarSQL(Me.tbParConsFecCreacionHasta.Text, TipoVar.Fecha)

        If tbParConsColaborador.Text <> "" Then _
            vArgumentos += ", @Colaborador=" & VarSQL(Me.tbParConsColaborador.Text, TipoVar.Texto, True)

        If Session("UsuarioAct.Red") > 0 Then _
            vArgumentos += ", @RedUsuario=" & VarSQL(Session("UsuarioAct.Red").ToString, TipoVar.Texto, True)

        If Not IsNothing(Session(vFormAct & ".Ordenar")) Then
            vArgumentos = vArgumentos & ", @Ordenar=" & VarSQL(Session(vFormAct & ".Ordenar"), TipoVar.Texto)
        End If

        vArgumentos = Mid(vArgumentos, 3)

        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)

        With ds.Tables(0).Rows(0)
            If .Item("IdEstado") <> 0 Then
                gv1.Visible = False
                DesplegarMensaje(TipoMensaje.MsgError, .Item("EstadoUsr"))
                If .Item("IdEstado") <> 1 Then
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

        Session(vFormAct & ".ConsultaActiva") = vArgumentos

    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        CargarGv1()
    End Sub

    Private Sub gv1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv1.RowCommand

        Select Case e.CommandName
            Case "Detalle"
                Dim vArgumentos As String = "@IdCoaching=" & e.CommandArgument

                Session("Coaching.ConsultaActiva") = vArgumentos
                Session("Coaching.FormPrev") = "~/" & vFormAct & ".aspx"
                Response.Redirect("Coaching.aspx")

        End Select

    End Sub

    Protected Sub Ordenar(sender As Object, e As EventArgs) Handles lbFecCreacion.Click, _
                                                                    lbUsuarioCreacion.Click, _
                                                                    lbSucursal.Click, _
                                                                    lbColaborador.Click

        Dim vNomVarSesion As String = Replace(Request.Url.Segments.Last(), ".aspx", "") & ".Ordenar"
        Dim lb As LinkButton = sender
        Dim vCampo As String = lb.CommandArgument

        If Session(vNomVarSesion) <> vCampo & " ASC" Then
            Session(vNomVarSesion) = vCampo & " ASC"
        Else
            Session(vNomVarSesion) = vCampo & " DESC"
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

    Private Sub gv1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gv1.RowDeleting

        Dim IdUsrCreacion As Integer = gv1.DataKeys(e.RowIndex).Values("IdUsrCreacion")
        Dim IdUsrActual As Integer = Session("UsuarioAct.IdUsuario")

        If IdUsrCreacion <> IdUsrActual Then
            DesplegarMensaje(TipoMensaje.MsgError, "Sólo se pueden eliminar coachings creados por el mismo usuario")
            Exit Sub
        End If

        Dim vIdCoaching As String = gv1.DataKeys(e.RowIndex).Values("IdCoaching").ToString()

        vNombreSP = "PGCoachingsGest"
        vArgumentos = "@IdCoaching= -" & vIdCoaching

        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)

        If ds.Tables(0).Rows(0).Item("IdEstado") = 0 Then
            DesplegarMensaje(TipoMensaje.MsgInformacion, "Registro eliminado OK.")
        Else
            DesplegarMensaje(TipoMensaje.MsgError, ds.Tables(0).Rows(0).Item("EstadoUsr"))
            Dim lblInfoTec As Label = CType(Master.FindControl("lblInfoTec"), Label)
            lblInfoTec.Text = vNombreSP & " " & vArgumentos & "<br>" & _
                              ds.Tables(0).Rows(0).Item("EstadoTec")
            Exit Sub
        End If

        CargarGv1()


    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        ddlParConsUsuarioCreacion.SelectedValue = ddlParConsUsuarioCreacion.Items(0).Value
        ddlParConsSucursal.SelectedValue = "0"
        tbParConsColaborador.Text = ""
    End Sub

    Protected Sub btnAgregarCoaching_Click(sender As Object, e As EventArgs) Handles btnAgregarCoaching.Click
        Session("Coaching.ConsultaActiva") = "IdCoaching=0"
        Session("Coaching.FormPrev") = "~/" & vFormAct & ".aspx"
        Response.Redirect("~/Coaching.aspx")
    End Sub

End Class
