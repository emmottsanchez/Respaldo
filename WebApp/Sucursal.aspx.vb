Public Class Sucursal
    Inherits BaseWebForms

    Const vFormAct As String = "Sucursal"

    Dim vIdAccionSucursal As String
    Dim vOportunidad As String
    Dim vAccion As String
    Dim vResponsable As String

    Dim vIdUsrGestor As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = True Then Exit Sub

        vArgApe = FormatoAplicacion(Nz(Session(vFormAct & ".ConsultaActiva"), ""))
        vArgAct = ObtenerArgumento("CodSucursal", vArgApe)

        If vArgAct.Length = 0 Then
            DesplegarMensaje(TipoMensaje.MsgError, "Error - Id registro no establecido")
            Exit Sub
        End If

        vNombreSP = "PGTotalesSucursalInfo"
        vArgumentos = "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha) & ", " & _
                      "@CodSucursal=" & vArgAct

        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
        With ds.Tables(0).Rows(0)
            If .Item("IdEstado") <> 0 Then
                DesplegarMensaje(TipoMensaje.MsgError, .Item("EstadoUsr"))
                Dim lblInfoTec As Label = CType(Master.FindControl("lblInfoTec"), Label)
                lblInfoTec.Text = vNombreSP & " " & vArgumentos & "<br>" & _
                                  ds.Tables(0).Rows(0).Item("EstadoTec")
                Exit Sub
            End If


            lblTitulo.Text = "Sucursal " & .Item("Sucursal") & " - " & NomMes(Session("App.PeriodoActivo")) & " " & Year(Session("App.PeriodoActivo"))

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
            If Not (.Item("CredTraMto") Is DBNull.Value) Then lblCredTraMto.Text = FormatNumber(.Item("CredTraMto"), 1)
            If Not (.Item("CredTraMtoUDH") Is DBNull.Value) Then lblCredTraMtoUDH.Text = FormatNumber(.Item("CredTraMtoUDH"), 1)

        End With

        CargarGv1()
        CargarGvAccionesSucursal()

        If Not Session("Sistema.MensajeInicial") Is Nothing Then
            DesplegarMensaje(TipoMensaje.MsgInformacion, Session("Sistema.MensajeInicial"))
            Session("Sistema.MensajeInicial") = Nothing
        End If

    End Sub

    Sub CargarGv1()

        vArgApe = FormatoAplicacion(Nz(Session(vFormAct & ".ConsultaActiva"), ""))
        vArgAct = ObtenerArgumento("CodSucursal", vArgApe)

        vNombreSP = "PGTotalesPecInfo"

        vArgumentos = "@Periodo=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha) & ", " & _
                      "@CodSucursal=" & vArgAct

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

    Sub CargarGvAccionesSucursal()

        gvAccionesSucursal.Visible = False

        vArgApe = FormatoAplicacion(Nz(Session(vFormAct & ".ConsultaActiva"), ""))
        vArgAct = ObtenerArgumento("CodSucursal", vArgApe)

        vNombreSP = "PGAccionesSucursalInfo"

        vArgumentos = "@CodSucursal=" & vArgAct & ", " & _
                      "@PeriodoCreacion=" & VarSQL(Session("App.PeriodoActivo"), TipoVar.Fecha)

        vArgumentos += ", @Ordenar='IdAccionSucursal DESC'"


        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)

        With ds.Tables(0).Rows(0)
            If .Item("IdEstado") <> 0 Then                
                If .Item("IdEstado") <> 1 Then
                    DesplegarMensaje(TipoMensaje.MsgError, .Item("EstadoUsr"))
                    Dim lblInfoTec As Label = CType(Master.FindControl("lblInfoTec"), Label)
                    lblInfoTec.Text = vNombreSP & " " & vArgumentos & "<br>" & _
                                      ds.Tables(0).Rows(0).Item("EstadoTec")
                End If
                Exit Sub
            End If
        End With


        gvAccionesSucursal.Visible = True
        gvAccionesSucursal.DataSource = ds.Tables(0)
        gvAccionesSucursal.DataBind()

    End Sub


    Protected Sub Ordenar(sender As Object, e As EventArgs) Handles lbUsuarioIngreso.Click, _
                                                                    lbMetaAfiliaciones.Click, _
                                                                    lbMetaPropAfiliaciones.Click, _
                                                                    lbAfiliaciones.Click, _
                                                                    lbCumAfiliaciones.Click, _
                                                                    lbCredPenCant.Click, _
                                                                    lbMetaCredPenMto.Click, _
                                                                    lbMetaPropCredPenMto.Click, _
                                                                    lbCredPenMto.Click, _
                                                                    lbCumCredPenMto.Click, _
                                                                    lbCredTraCant.Click, _
                                                                    lbCredTraMto.Click

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

    Protected Sub ibAgregar_Click(sender As Object, e As ImageClickEventArgs) Handles ibAgregar.Click

        vIdAccionSucursal = "0"

        vOportunidad = VarSQL(tbOportunidadNvo.Text, TipoVar.Texto, True)

        If vOportunidad.Length > 500 Then
            DesplegarMensaje(TipoMensaje.MsgError, "Descripción de [Oportunidad] (" & vOportunidad.Length & " car) supera el límite permitido (500 car)")
            Exit Sub
        End If

        vAccion = VarSQL(tbAccionNvo.Text, TipoVar.Texto, True)
        If vAccion.Length > 500 Then
            DesplegarMensaje(TipoMensaje.MsgError, "Descripción de [Acción] (" & vAccion.Length & " car) supera el límite permitido (500 car)")
            Exit Sub
        End If

        vResponsable = VarSQL(tbResponsableNvo.Text, TipoVar.Texto, True)
        If vResponsable.Length > 50 Then
            DesplegarMensaje(TipoMensaje.MsgError, "Descripción de [Responsable] (" & vResponsable.Length & " car) supera el límite permitido (50 car)")
            Exit Sub
        End If

        vArgApe = FormatoAplicacion(Nz(Session(vFormAct & ".ConsultaActiva"), ""))
        vArgAct = ObtenerArgumento("CodSucursal", vArgApe)

        vIdUsrGestor = Session("UsuarioAct.IdUsuario")

        vNombreSP = "PGAccionesSucursalGest"
        vArgumentos = "@IdAccionSucursal=" & vIdAccionSucursal & ", " & _
                      "@CodSucursal=" & vArgAct & ", " & _
                      "@Oportunidad=" & vOportunidad & ", " & _
                      "@Accion=" & vAccion & ", " & _
                      "@Responsable=" & vResponsable & ", " & _
                      "@IdUsrGestor=" & vIdUsrGestor

        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)

        If ds.Tables(0).Rows(0).Item("IdEstado") = 0 Then
            DesplegarMensaje(TipoMensaje.MsgInformacion, "Registro creado OK.")

            gvAccionesSucursal.EditIndex = -1
            CargarGvAccionesSucursal()

            tbOportunidadNvo.Text = ""
            tbAccionNvo.Text = ""
            tbResponsableNvo.Text = ""
        Else
            DesplegarMensaje(TipoMensaje.MsgError, ds.Tables(0).Rows(0).Item("EstadoUsr"))
            Dim lblInfoTec As Label = CType(Master.FindControl("lblInfoTec"), Label)
            lblInfoTec.Text = vNombreSP & " " & vArgumentos & "<br>" & _
                              ds.Tables(0).Rows(0).Item("EstadoTec")
        End If

    End Sub

    Private Sub gvAccionesSucursal_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvAccionesSucursal.RowDeleting

        Dim IdUsrCreacion As Integer = gvAccionesSucursal.DataKeys(e.RowIndex).Values("IdUsrCreacion")
        Dim IdUsrActual As Integer = Session("UsuarioAct.IdUsuario")

        If IdUsrCreacion <> IdUsrActual Then
            DesplegarMensaje(TipoMensaje.MsgError, "Sólo se pueden eliminar acciones creadas por el mismo usuario")
            Exit Sub
        End If

        vIdAccionSucursal = gvAccionesSucursal.DataKeys(e.RowIndex).Values("IdAccionSucursal").ToString()

        vNombreSP = "PGAccionesSucursalGest"
        vArgumentos = "@IdAccionSucursal= -" & vIdAccionSucursal

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

        CargarGvAccionesSucursal()

    End Sub

End Class