
Imports System.Web.UI.WebControls.TableCell
Imports System.Web.UI.WebControls.GridView
Imports System.Object
Imports System.Web.UI.Control
Imports System.Web.UI.WebControls.WebControl
Imports System.Web.UI.WebControls.BaseDataBoundControl
Imports System.Web.UI.WebControls.DataBoundControl
Imports System.Web.UI.WebControls.CompositeDataBoundControl
Public Class Agente
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
        If Session("UsuarioAct.Admin") = 1 Then
            DDLDatosAdmin()
            Datos()
            Metas()
            MetaSuc()
            DataActualizada()
            Session("Usuario.Menu") = 0
            Exit Sub
        End If
        If Session("UsuarioAct.regional") = 1 Then
            DDLDatosRegional()
            Datos()
            Metas()
            MetaSuc()
            DataActualizada()
            Session("Usuario.Menu") = 0
            Exit Sub
        End If
        'DDLDatos()
        'Datos()
        'Metas()
        ' MetaSuc()
        'DataActualizada()
        'Session("UsuarioAct.Agente") = 0
        'Session("Usuario.Menu") = 0
    End Sub

    Sub DDLDatosRegional()
        vNombreSP = "select * from CPECRegionalSucursalVTA where idUsuario=" & Session("UsuarioAct.id")
        vArgumentos = ""
        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
        ddlSuc.DataValueField = "Sucursal"
        ddlSuc.DataTextField = "Sucursal"
        ddlSuc.DataSource = ds
        ddlSuc.DataBind()
        Session("UsuarioAct.Admin") = 0
        Session("UsuarioAct.regional") = 1
    End Sub

    Sub DDLDatosAdmin()
        Dim vN As String = "select distinct([Sucursal BT]) as Sucursal from sucursales where [Codigo BT]>0 and Dependencia='Red Comercial' order by [Sucursal BT] ASC"
        Dim vAr As String = ""
        ds = cnn.EjecutarSP(vN, vAr)
        ddlSuc.DataValueField = "Sucursal"
            ddlSuc.DataTextField = "Sucursal"
            ddlSuc.DataSource = ds
        ddlSuc.DataBind()
        Session("UsuarioAct.Admin") = 1
    End Sub

    Sub DDLDatos()
        vNombreSP = "EXEC PGSucursalesAgenteInfo"
        vArgumentos = "@IdUsuarioAgente=" & Session("UsuarioAct.id") & "" & _
                     ", @Periodo =" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha)
        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)

        If ds.Tables(0).Rows(0).Item("IdEstado") <> 0 Then
            lblErr.Text = "No existen Datos"
            Session("UsuarioAct.Usuario") = Nothing
            Response.Redirect("~/default.aspx")
        Else
            ddlSuc.DataValueField = "Sucursal"
            ddlSuc.DataTextField = "Sucursal"
            ddlSuc.DataSource = ds
            ddlSuc.DataBind()
        End If
    End Sub

    Sub Datos()
        'ddlSuc.SelectedIndex = 0
        vNombreSP = "select * from CPECAgenteSucursalVTA where Sucursal='" & ddlSuc.SelectedValue & "'"
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        GridDatos.Visible = True
        If ds.Tables(0).Rows.Count > 0 Then
            GridDatos.DataSource = ds
            GridDatos.DataBind()
        Else
            GridDatos.Visible = False
        End If

    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Metas()
        Datos()
        MetaSuc()
    End Sub

    Sub Metas()
        vNombreSP = "select * FROM CPECUSUARIOS WHERE Sucursal='" & ddlSuc.SelectedValue & "' and Periodo=" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha)
        vArgumentos = ""
        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
        If ds.Tables(0).Rows.Count > 0 Then
            Session("UsuarioAct.Sucursal") = ds.Tables(0).Rows(0).Item("CodSucursal")
            Session("UsuarioAct.NombreEquipo") = ds.Tables(0).Rows(0).Item("NombreEquipo")
            ' lblSegmentoPensionado.Text = Nz(ds.Tables(0).Rows(0).Item("ColorPensionado"), 0)
            lblMetaAfiPens.Text = Nz(FormatNumber(ds.Tables(0).Rows(0).Item("MetaAfiPen"), 0), 0)
            lblMetaCredPen.Text = Nz(FormatNumber(ds.Tables(0).Rows(0).Item("MetaCredPen"), 0), 0)
            lblMetaAfiPens2.Text = FormatNumber(ds.Tables(0).Rows(0).Item("MetaAfiPen_ind"), 0)
            lblMetaCredPend2.Text = FormatNumber(ds.Tables(0).Rows(0).Item("MetaCredPen_ind"), 0)
            lblSegmentoTrab.Text = Nz(ds.Tables(0).Rows(0).Item("ColorTrabajador"), 0)
            'lblSucursal3.Text = Nz(ds.Tables(0).Rows(0).Item("Sucursal"), 0)
            Dim color As String
            color = ds.Tables(0).Rows(0).Item("ColorTrabajador")

            lblMinVenta.Text = "Mínimo venta crédito trabajadores: " & FormatNumber(ds.Tables(0).Rows(0).Item("MetaCredTrab"), 0)
            lblImportante.Text = "- 1 Afiliación de un Pensionado FFAA ➡ Suma 2 Afiliaciones."
            panelRequisitos.Visible = True
        Else
            Exit Sub
        End If

    End Sub


    Private Sub btnBuscarPEC_Click(sender As Object, e As EventArgs) Handles btnBuscarPEC.Click
        If Len(txtRut.Text) = 0 Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Cambiar", "IngresarRut();", True)
            Exit Sub
        End If

        vNombreSP = "select Usuario,Contraseña,NombBT,Sucursal,NomCorto from CPECUsuarios where Periodo=" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha) & _
                    " and Rut=" & txtRut.Text
        vArgumentos = ""
        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
        If ds.Tables(0).Rows.Count = 0 Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Cambiar", "IngresarRut();", True)
            Exit Sub
        Else
            Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
            Session("UsuarioAct.Usuario") = ds.Tables(0).Rows(0).Item("Usuario")
            Session("UsuarioAct.Rut") = txtRut.Text
            Session("UsuarioAct.Contraseña") = ds.Tables(0).Rows(0).Item("Contraseña")
            Session("UsuarioAct.NombBt") = ds.Tables(0).Rows(0).Item("NombBT")
            Session("UsuarioAct.Sucursal2") = ds.Tables(0).Rows(0).Item("Sucursal")
            Session("UsuarioAct.Agente") = 1
            Session("UsuarioAct.NomCorto") = ds.Tables(0).Rows(0).Item("NomCorto")
            Response.Redirect("~/default.aspx")
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Cambiar", "IngresarRut();", True)
            Exit Sub
        End If

    End Sub

    Sub MetaSuc()

        vNombreSP = "SELECT CumAfiliaciones,CumCredPenMto,Sucursal FROM PGTotalesSucursalVta WHERE PERIODO=" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha) & _
                    " and Sucursal='" & ddlSuc.SelectedValue & "'"
        vArgumentos = ""
        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
        If ds.Tables(0).Rows.Count = 0 Then
            lblErr.Text = "No existen Datos"
            txtMetaAf.Text = ""
            txtMetaCr.Text = ""
            txtTotMet.Text = ""
            Exit Sub
        Else
            txtMetaAf.Text = " % Cumplimiento Afiliación: " & FormatPercent(Nz(ds.Tables(0).Rows(0).Item("CumAfiliaciones"), 0))
            txtMetaCr.Text = " % Cumplimiento Créditos: " & FormatPercent(Nz(ds.Tables(0).Rows(0).Item("CumCredPenMto"), 0))
            Dim Af As Integer = Nz(ds.Tables(0).Rows(0).Item("CumAfiliaciones"), 0) * 100
            Dim Cr As Integer = Nz(ds.Tables(0).Rows(0).Item("CumCredPenMto"), 0) * 100
            If Af < 90 Then
                txtTotMet.Text = "Incentivos NO se duplican"
                txtTotMet.ForeColor = Drawing.Color.Red
            Else
                Af = 1
            End If

            If Cr < 90 Then
                txtTotMet.Text = "Incentivos NO se duplican"
                txtTotMet.ForeColor = Drawing.Color.Red
            Else
                Cr = 1
            End If

            If Cr = Af Then
                txtTotMet.Text = "Incentivos SI se duplican"
                txtTotMet.ForeColor = Drawing.Color.Green
            
            End If
            Exit Sub
            End If

    End Sub

    Dim dTotal As Integer = 0
    Private Sub GridDatos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            dTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Afiliaciones_Pensionado"))
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(1).Text = "Total:"
            e.Row.Cells(2).Text = FormatNumber(dTotal.ToString("c"), 0)
            e.Row.Cells(2).HorizontalAlign = WebControls.HorizontalAlign.Center
            e.Row.Font.Bold = True
        End If
    End Sub
    Dim dTotal2 As Integer = 0
    Private Sub GridDatos_RowDataBound2(sender As Object, ed As GridViewRowEventArgs) Handles GridDatos.RowDataBound
        If ed.Row.RowType = DataControlRowType.DataRow Then
            dTotal2 += Convert.ToDecimal(DataBinder.Eval(ed.Row.DataItem, "Creditos_Pensionados"))
        End If
        If ed.Row.RowType = DataControlRowType.Footer Then
            ' ed.Row.Cells(1).Text = "Total:"
            ed.Row.Cells(3).Text = FormatCurrency(dTotal2.ToString("c"), 0)
            ed.Row.Cells(3).HorizontalAlign = WebControls.HorizontalAlign.Center
            ed.Row.Font.Bold = True
        End If
    End Sub
    Dim dTotal3 As Integer = 0
    Private Sub GridDatos_RowDataBound3(sender As Object, ed As GridViewRowEventArgs) Handles GridDatos.RowDataBound
        If ed.Row.RowType = DataControlRowType.DataRow Then
            dTotal3 += Convert.ToDecimal(DataBinder.Eval(ed.Row.DataItem, "Creditos_Trabajador"))
        End If
        If ed.Row.RowType = DataControlRowType.Footer Then
            ' ed.Row.Cells(1).Text = "Total:"
            ed.Row.Cells(4).Text = FormatCurrency(dTotal3.ToString("c"), 0)
            ed.Row.Cells(4).HorizontalAlign = WebControls.HorizontalAlign.Center
            ed.Row.Font.Bold = True
        End If
    End Sub
    Dim dTotal4 As Integer = 0
    Private Sub GridDatos_RowDataBound4(sender As Object, ed As GridViewRowEventArgs) Handles GridDatos.RowDataBound
        If ed.Row.RowType = DataControlRowType.DataRow Then
            dTotal4 += Convert.ToDecimal(DataBinder.Eval(ed.Row.DataItem, "CantidadIndPens"))
        End If
        If ed.Row.RowType = DataControlRowType.Footer Then
            ' ed.Row.Cells(1).Text = "Total:"
            ed.Row.Cells(5).Text = FormatNumber(dTotal4.ToString("c"), 0)
            ed.Row.Cells(5).HorizontalAlign = WebControls.HorizontalAlign.Center
            ed.Row.Font.Bold = True
        End If
    End Sub
    Dim dTotal5 As Integer = 0
    Private Sub GridDatos_RowDataBound5(sender As Object, ed As GridViewRowEventArgs) Handles GridDatos.RowDataBound
        If ed.Row.RowType = DataControlRowType.DataRow Then
            dTotal5 += Convert.ToDecimal(DataBinder.Eval(ed.Row.DataItem, "CantidadIndTrab"))
        End If
        If ed.Row.RowType = DataControlRowType.Footer Then
            ' ed.Row.Cells(1).Text = "Total:"
            ed.Row.Cells(6).Text = FormatNumber(dTotal5.ToString("c"), 0)
            ed.Row.Cells(6).HorizontalAlign = WebControls.HorizontalAlign.Center
            ed.Row.Font.Bold = True
        End If
    End Sub
    Dim dTotal6 As Integer = 0
    Private Sub GridDatos_RowDataBound6(sender As Object, ed As GridViewRowEventArgs) Handles GridDatos.RowDataBound
        If ed.Row.RowType = DataControlRowType.DataRow Then
            dTotal6 += Convert.ToDecimal(DataBinder.Eval(ed.Row.DataItem, "CantidadSegCes"))
        End If
        If ed.Row.RowType = DataControlRowType.Footer Then
            ' ed.Row.Cells(1).Text = "Total:"
            ed.Row.Cells(7).Text = FormatNumber(dTotal6.ToString("c"), 0)
            ed.Row.Cells(7).HorizontalAlign = WebControls.HorizontalAlign.Center
            ed.Row.Font.Bold = True
        End If
    End Sub
    Dim dTotal7 As Integer = 0
    Private Sub GridDatos_RowDataBound7(sender As Object, ed As GridViewRowEventArgs) Handles GridDatos.RowDataBound
        If ed.Row.RowType = DataControlRowType.DataRow Then
            dTotal7 += Convert.ToDecimal(DataBinder.Eval(ed.Row.DataItem, "LM"))
        End If
        If ed.Row.RowType = DataControlRowType.Footer Then
            ' ed.Row.Cells(1).Text = "Total:"
            ed.Row.Cells(8).Text = FormatNumber(dTotal7.ToString("c"), 0)
            ed.Row.Cells(8).HorizontalAlign = WebControls.HorizontalAlign.Center
            ed.Row.Font.Bold = True
        End If
    End Sub
    Dim dTotal8 As Integer = 0
    Private Sub GridDatos_RowDataBound8(sender As Object, ed As GridViewRowEventArgs) Handles GridDatos.RowDataBound
        If ed.Row.RowType = DataControlRowType.DataRow Then
            dTotal8 += Convert.ToDecimal(DataBinder.Eval(ed.Row.DataItem, "Cupones"))
        End If
        If ed.Row.RowType = DataControlRowType.Footer Then
            ' ed.Row.Cells(1).Text = "Total:"
            ed.Row.Cells(9).Text = FormatNumber(dTotal8.ToString("c"), 0)
            ed.Row.Cells(9).HorizontalAlign = WebControls.HorizontalAlign.Center
            ed.Row.Font.Bold = True
        End If
    End Sub
    Sub DataActualizada()
        vNombreSP = "select isnull(max(fecha_contable),0)as fecha_contable,ISNULL((COUNT(*)),0) as Cn from Creditos"
        vArgumentos = ""
        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
        If ds.Tables(0).Rows(0).Item("Cn") = 0 Then
            lblCr.Text = "(No existen datos en sistema para este periodo)"
        Else
            lblCr.Text = "Créditos actualizados al: " & ds.Tables(0).Rows(0).Item("fecha_contable")
        End If

        Dim vNombreS As String = "select ISNULL(MAX(FECHA_PREAFILIACION),0)as FECHA_PREAFILIACION,ISNULL((COUNT(*)),0) as Cn from Afiliaciones"
        Dim vArgumento As String = ""

        Dim ds1 As DataSet = cnn.EjecutarSP(vNombreS, vArgumento)

        If ds1.Tables(0).Rows(0).Item("Cn") = 0 Then
            lblAf.Text = "(No existen datos en sistema para este periodo)"
        Else
            lblAf.Text = "Afiliaciones actualizadas al: " & FormatDateTime(ds1.Tables(0).Rows(0).Item("FECHA_PREAFILIACION"), 0)
        End If

        Dim vNombre As String = "select top 1 Periodo from CPECSeguimientoDiarioSeguros order by Periodo desc"
        Dim vArgumen As String = ""
        Dim ds2 As DataSet = cnn.EjecutarSP(vNombre, vArgumen)
        lblSeg.Text = "Seguros actualizados al: " & FormatDateTime(ds2.Tables(0).Rows(0).Item("Periodo"), 0)

        Dim vNomb As String = "Set Language spanish select Periodo from LicenciasRutDiarioVTA order by Periodo desc"
        Dim vArg As String = ""
        Dim ds3 As DataSet = cnn.EjecutarSP(vNomb, vArg)
        lblLcM.Text = "Licencias actualizados al: " & FormatDateTime(ds3.Tables(0).Rows(0).Item("Periodo"), 0)
      
        Dim vNom As String = "select DiaEntrega,MesEntrega,AñoEntrega from cuponesRutDiarioVTA order by DiaEntrega desc"
        Dim vAr As String = ""
        Dim ds4 As DataSet = cnn.EjecutarSP(vNom, vAr)
        lblCup.Text = "Cupones actualizados al: " & ds4.Tables(0).Rows(0).Item("DiaEntrega") & "-" & ds4.Tables(0).Rows(0).Item("MesEntrega") & "-" & ds4.Tables(0).Rows(0).Item("AñoEntrega")
    End Sub

End Class