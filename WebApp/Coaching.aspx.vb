Public Class Coaching
    Inherits BaseWebForms

    Const vFormAct As String = "Coaching"

    Dim vIdCoaching As String, _
        vCodSucursal As String, _
        vColaborador As String, _
        vConductaPrioritariaAnterior As String, _
        vFortalezas As String, _
        vOportunidadesMejora As String, _
        vConductaPrioritaria As String, _
        vPlanTactico As String, _
        vFecProximaSesion As String, _
        vFecRevisionPlanTactico As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = True Then Exit Sub

        vIdCoaching = ObtIdRegDesdeConsultaActiva(vFormAct, "IdCoaching")

        CargarDdls()

        If vIdCoaching = "0" Then
            lblTitulo.Text = "Crear nuevo registro de Coaching"

            lblUsuarioCreacion.Text = Session("UsuarioAct.Usuario")
            lblFecCreacion.Text = VarControl(DateTime.Today, TipoVar.Fecha)

            Dim vArgApe = FormatoAplicacion(Nz(Session(vFormAct & ".ConsultaActiva"), ""))
            vCodSucursal = ObtenerArgumento("CodSucursal", vArgApe)
            ddlSucursal.SelectedValue = vCodSucursal

            btnAceptar.Text = "Crear"
        Else
            lblTitulo.Text = "Detalle de Coaching"
            CargarRegistro()            
            btnAceptar.Text = "Modificar"
        End If

        If Not Session("Sistema.MensajeInicial") Is Nothing Then
            DesplegarMensaje(TipoMensaje.MsgInformacion, Session("Sistema.MensajeInicial"))
            Session("Sistema.MensajeInicial") = Nothing
        End If

    End Sub


    Sub CargarDdls()

        ''Cargar listados en elementos DropDownList de la página
        ds = cnn.EjecutarSP("SucursalesBTInfo", "")
        With ddlSucursal
            .DataValueField = "CODIGO BT"
            .DataTextField = "SUCURSAL BT"
            .DataSource = ds
            .DataBind()
            .Items.Insert(0, New ListItem("(Seleccionar)", "0"))
        End With

    End Sub

    Sub CargarRegistro()

        ds = cnn.EjecutarSP("PGCoachingsInfo", "@IdCoaching=" & vIdCoaching)
        With ds.Tables(0).Rows(0)
            lblUsuarioCreacion.Text = VarControl(.Item("UsuarioCreacion"), TipoVar.Texto)
            ddlSucursal.SelectedValue = VarControl(.Item("CodSucursal"), TipoVar.Numerico)
            tbColaborador.Text = VarControl(.Item("Colaborador"), TipoVar.Texto)
            lblFecCreacion.Text = VarControl(.Item("FecCreacion"), TipoVar.Fecha)
            tbConductaPrioritariaAnterior.Text = VarControl(.Item("ConductaPrioritariaAnterior"), TipoVar.Texto)
            tbFortalezas.Text = VarControl(.Item("Fortalezas"), TipoVar.Texto)
            tbOportunidadesMejora.Text = VarControl(.Item("OportunidadesMejora"), TipoVar.Texto)
            tbConductaPrioritaria.Text = VarControl(.Item("ConductaPrioritaria"), TipoVar.Texto)
            tbPlanTactico.Text = VarControl(.Item("PlanTactico"), TipoVar.Texto)
            tbFecProximaSesion.Text = VarControl(.Item("FecProximaSesion"), TipoVar.Fecha)
            tbFecRevisionPlanTactico.Text = VarControl(.Item("FecRevisionPlanTactico"), TipoVar.Fecha)

            If .Item("IdUsrCreacion") <> Session("UsuarioAct.IdUsuario") Then btnAceptar.Enabled = False
        End With

    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If IsNothing(Session("UsuarioAct.IdUsuario")) Then Response.Redirect("~/Default.aspx")

        If ValidarRegistro() = False Then Exit Sub

        'Cargar variables
        vIdCoaching = ObtIdRegDesdeConsultaActiva(vFormAct, "IdCoaching")
        vCodSucursal = VarSQL(ddlSucursal.SelectedValue, TipoVar.Numerico, True)
        vColaborador = VarSQL(tbColaborador.Text, TipoVar.Texto)

        vConductaPrioritariaAnterior = VarSQL(tbConductaPrioritariaAnterior.Text, TipoVar.Texto)
        vFortalezas = VarSQL(tbFortalezas.Text, TipoVar.Texto)
        vOportunidadesMejora = VarSQL(tbOportunidadesMejora.Text, TipoVar.Texto)
        vConductaPrioritaria = VarSQL(tbConductaPrioritaria.Text, TipoVar.Texto)
        vPlanTactico = VarSQL(tbPlanTactico.Text, TipoVar.Texto)
        vFecProximaSesion = VarSQL(tbFecProximaSesion.Text, TipoVar.Fecha)
        vFecRevisionPlanTactico = VarSQL(tbFecRevisionPlanTactico.Text, TipoVar.Fecha)

        vNombreSP = "PGCoachingsGest"
        vArgumentos = "@IdCoaching=" & vIdCoaching & ", " & _
                      "@CodSucursal=" & vCodSucursal & ", " & _
                      "@Colaborador=" & vColaborador & ", " & _
                      "@ConductaPrioritariaAnterior=" & vConductaPrioritariaAnterior & ", " & _
                      "@Fortalezas=" & vFortalezas & ", " & _
                      "@OportunidadesMejora=" & vOportunidadesMejora & ", " & _
                      "@ConductaPrioritaria=" & vConductaPrioritaria & ", " & _
                      "@PlanTactico=" & vPlanTactico & ", " & _
                      "@FecProximaSesion=" & vFecProximaSesion & ", " & _
                      "@FecRevisionPlanTactico=" & vFecRevisionPlanTactico & ", " & _
                      "@IdUsrGestor=" & Session("UsuarioAct.IdUsuario")

        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)

        If ds.Tables(0).Rows(0).Item("IdEstado") <> 0 Then
            DesplegarMensaje(TipoMensaje.MsgError, ds.Tables(0).Rows(0).Item("EstadoUsr"))
            Dim lblInfoTec As Label = CType(Master.FindControl("lblInfoTec"), Label)
            lblInfoTec.Text = vNombreSP & " " & vArgumentos & "<br>" & _
                              ds.Tables(0).Rows(0).Item("EstadoTec")
            Exit Sub
        End If

        Session("Sistema.MensajeInicial") = "Coaching registrado OK."
        btnVolver_Click(sender, e)

    End Sub

    Function ValidarRegistro() As Boolean

        ValidarRegistro = False

        If ddlSucursal.SelectedValue = "0" Then
            DesplegarMensaje(TipoMensaje.MsgError, "Debe indicar Sucursal")
            Exit Function
        End If

        If tbColaborador.Text = "" Then
            DesplegarMensaje(TipoMensaje.MsgError, "Debe indicar Colaborador")            
            Exit Function
        End If

        If tbConductaPrioritariaAnterior.Text.Length > 300 Then
            DesplegarMensaje(TipoMensaje.MsgError, "[Conducta prioritaria anterior] (" & tbConductaPrioritariaAnterior.Text.Length & " car) supera el límite permitido (300 car)")
            Exit Function
        End If

        If tbFortalezas.Text.Length > 500 Then
            DesplegarMensaje(TipoMensaje.MsgError, "[Fortalezas] (" & tbFortalezas.Text.Length & " car) supera el límite permitido (500 car)")
            Exit Function
        End If

        If tbOportunidadesMejora.Text.Length > 500 Then
            DesplegarMensaje(TipoMensaje.MsgError, "[Oportunidades de mejora] (" & tbOportunidadesMejora.Text.Length & " car) supera el límite permitido (500 car)")
            Exit Function
        End If

        If tbConductaPrioritaria.Text.Length > 300 Then
            DesplegarMensaje(TipoMensaje.MsgError, "[Conducta prioritaria] (" & tbConductaPrioritaria.Text.Length & " car) supera el límite permitido (300 car)")            
            Exit Function
        End If

        If tbPlanTactico.Text = "" Then
            DesplegarMensaje(TipoMensaje.MsgError, "Debe indicar Plan táctico")
            Exit Function
        End If

        If tbPlanTactico.Text.Length > 300 Then
            DesplegarMensaje(TipoMensaje.MsgError, "[Plan táctico] (" & tbPlanTactico.Text.Length & " car) supera el límite permitido (300 car)")
            Exit Function
        End If

        ValidarRegistro = True

    End Function

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If IsNothing(Session("UsuarioAct.IdUsuario")) Then Response.Redirect("~/Default.aspx")
        Response.Redirect(Session(vFormAct & ".FormPrev"))
    End Sub


End Class