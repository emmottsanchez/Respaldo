Imports System.Net
Public Class PagoIncentivos
    Inherits System.Web.UI.Page
    Dim vNombreSP As String
    Dim vArgumentos As String
    Dim cnn As New Webapp.Conexion
    Dim ds As DataSet
    Dim co As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("Usuario.Menu") = 1
        If IsNothing(Session("UsuarioAct.Usuario")) Then
            Response.Redirect("~/default.aspx")
            Exit Sub
        End If
        If Page.IsPostBack = True Then Exit Sub
        LlenarDll()
        LlenarDatos()
    End Sub

    Private Sub LlenarDll()

        vNombreSP = "SET LANGUAGE Spanish SELECT  distinct(datename(year,Periodo)) as Año " & _
                    " FROM CPECPagoIncentivos where Rut=" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & " order by Año desc"
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        If ds.Tables(0).Rows.Count > 0 Then
            ddlAño.DataValueField = "Año"
            ddlAño.DataTextField = "Año"
            ddlAño.DataSource = ds
            ddlAño.DataBind()
            DDL()
        Else
            plCalculo.Visible = False
            plPagoInc.Visible = False
            lblMsg.Visible = True
            Exit Sub
        End If

    End Sub

    Sub DDL()
        If IsNothing(Session("UsuarioAct.ActDDL")) Then
            Dim vNombre As String = "SET LANGUAGE Spanish SELECT distinct(datename(MONTH,Periodo)) as Mes,MONTH(Periodo) as NM, Periodo,Sucursal from CPECPagoIncentivos" & _
                                   " where Rut=" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & " and Year(Periodo)=2017 " & _
                                   " ORDER BY Periodo desc"
            Dim vArgumento As String = ""
            Dim ds1 As DataSet = cnn.EjecutarSP(vNombre, vArgumento)
            If ds1.Tables(0).Rows.Count > 0 Then
                ddlMes.DataValueField = "NM"
                ddlMes.DataTextField = "Mes"
                ddlMes.DataSource = ds1
                ddlMes.DataBind()
                lblSucursalActual.Text = ds1.Tables(0).Rows(0).Item("Sucursal")
            Else
                plPagoInc.Visible = False
                lblMsg.Visible = True
                Exit Sub
            End If
        Else
            Dim vNombre As String = "SET LANGUAGE Spanish SELECT distinct(datename(MONTH,Periodo)) as Mes,MONTH(Periodo) as NM, Periodo,Sucursal from CPECPagoIncentivos" & _
                                   " where Rut=" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & " and Year(Periodo)=" & Session("UsuarioAct.ActDDL") & _
                                   " ORDER BY Periodo desc"
            Dim vArgumento As String = ""
            Dim ds1 As DataSet = cnn.EjecutarSP(vNombre, vArgumento)
            If ds1.Tables(0).Rows.Count > 0 Then
                ddlMes.DataValueField = "NM"
                ddlMes.DataTextField = "Mes"
                ddlMes.DataSource = ds1
                ddlMes.DataBind()
                lblSucursalActual.Text = ds1.Tables(0).Rows(0).Item("Sucursal")
            Else
                plPagoInc.Visible = False
                lblMsg.Visible = True
                Exit Sub
            End If
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        LlenarDatos()
    End Sub

    Private Sub LlenarDatos()

        vNombreSP = "select * from CPECPagoIncentivos where Rut=" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & _
                   " and Periodo=' " & ddlAño.SelectedValue & "-" & ddlMes.SelectedValue & "-01" & "'"
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)

        If ddlAño.SelectedValue > 2016 Then
            tbIncentivo.Visible = False
            tbIncentivo2.Visible = True
            tb1.Visible = False
            tb2.Visible = True
            lblMsg1.Visible = False
            lblMsg2.Visible = True
            lblMetaT.Visible = False
            lblMetaT2.Visible = True
        Else
            tbIncentivo2.Visible = False
            tbIncentivo.Visible = True
            tb2.Visible = False
            tb1.Visible = True
            lblMsg2.Visible = False
            lblMsg1.Visible = True
            lblMetaT2.Visible = False
            lblMetaT.Visible = True
        End If

        If ds.Tables(0).Rows.Count > 0 Then
            lblCrTrDeal.Text = "$" & (FormatNumber(Nz(ds.Tables(0).Rows(0).Item("MontoVentaDealer"), 0), 0))
            lblCrTrCred.Text = "$" & (FormatNumber(Nz(ds.Tables(0).Rows(0).Item("MontoVentaPec"), 0), 0))
            lblMetaT.Text = " Meta Creditos : $" & Nz((ds.Tables(0).Rows(0).Item("MetaTrabajador")), 0)
            lblAfReal.Text = Nz(FormatNumber(ds.Tables(0).Rows(0).Item("AfiPens"), 0), 0)
            lblCrPeReal.Text = Nz(FormatNumber(ds.Tables(0).Rows(0).Item("VentaCredPens"), 0), 0)
            lblAfCumSuc.Text = Nz((ds.Tables(0).Rows(0).Item("MetaSucursal")), 0)
            lblConAfPenY.Text = Nz((FormatNumber(ds.Tables(0).Rows(0).Item("MetaAfiPenY"))), 0)
            lblConCrPenY.Text = Nz(FormatNumber(ds.Tables(0).Rows(0).Item("MetaCredPenY"), 0), 0)
            lblConAfPenO.Text = Nz(FormatNumber(ds.Tables(0).Rows(0).Item("MetaAfiPenO"), 0), 0)
            lblConCrPen0.Text = Nz(ds.Tables(0).Rows(0).Item("MetaCredPenO"), 0)
            lblPenCond.Text = Nz(ds.Tables(0).Rows(0).Item("Condicion"), "Ninguna")
            lblIncen.Text = Nz(FormatNumber(ds.Tables(0).Rows(0).Item("IncentivoPens"), 0), 0)
            lblCredTrabTotalInc.Text = "$" & Nz(FormatNumber(ds.Tables(0).Rows(0).Item("MontoIncentivo"), 0), 0)
            lblAfiliacion2.Text = Nz(FormatNumber(ds.Tables(0).Rows(0).Item("AfiPens"), 0), 0)
            lblCredPensionado2.Text = "$" & Nz(FormatNumber(ds.Tables(0).Rows(0).Item("VentaCredPens"), 0), 0)
            lblCredTrabajador2.Text = "$" & (FormatNumber(Nz(ds.Tables(0).Rows(0).Item("MontoVentaPec"), 0), 0))
            lblCumMetaTrab.Text = Nz((ds.Tables(0).Rows(0).Item("CumpleMeta")), 0)
            lblCumpleMeta2.Text = Nz(ds.Tables(0).Rows(0).Item("Cumplemas2"), 0)
            lblIncentivoAfiliacion2.Text = "$" & (FormatNumber(Nz(ds.Tables(0).Rows(0).Item("IncentivoPens"), 0), 0))
            lblIncentivoCredPens2.Text = "$" & (FormatNumber(Nz(ds.Tables(0).Rows(0).Item("IncentivoCredPens"), 0), 0))
            lblIncentivoCredTrab2.Text = "$" & Nz(FormatNumber(ds.Tables(0).Rows(0).Item("MontoIncentivo"), 0), 0)
            lblRankingAfiliacion2.Text = Nz(ds.Tables(0).Rows(0).Item("Ranking Afiliación"), 0)
            lblRankingCredPens2.Text = Nz(ds.Tables(0).Rows(0).Item("Ranking Créd. Pensionados"), 0)
            lblRankingCredTrab2.Text = Nz(ds.Tables(0).Rows(0).Item("Ranking Créd. Trabajadores"), 0)
            lblIncentivoRankAfiliacion2.Text = "$" & (FormatNumber(Nz(ds.Tables(0).Rows(0).Item("Comisión Ranking Afiliación"), 0), 0))
            lblIncentivoRankCredPens2.Text = "$" & (FormatNumber(Nz(ds.Tables(0).Rows(0).Item("Comisión Ranking Cred Pensionado"), 0), 0))
            lblIncentivoRankCredTrab2.Text = "$" & (FormatNumber(Nz(ds.Tables(0).Rows(0).Item("Comisión Ranking Cred Trabajador"), 0), 0))
            lblComisionFinal2.Text = "$" & (FormatNumber(Nz(ds.Tables(0).Rows(0).Item("Comisión TOTAL"), 0), 0))
            lblMetaAfiliacion.Text = (FormatNumber(Nz(ds.Tables(0).Rows(0).Item("MetaAfi"), 0), 0))
            lblMetaCreditoPens.Text = "$" & (FormatNumber(Nz(ds.Tables(0).Rows(0).Item("MetaCredPen"), 0), 0))
            lblMetaT2.Text = "$" & (FormatNumber(Nz(ds.Tables(0).Rows(0).Item("MetaCredTrab"), 0), 0))
            plCalculo.Visible = True
            If ds.Tables(0).Rows(0).Item("Periodo") > "2016-11-01" Then
                lblCrTrDeal.Text = ""
                lblDealerV.Text = ""
            Else
                lblCrTrDeal.Text = "$" & (FormatNumber(Nz(ds.Tables(0).Rows(0).Item("MontoVentaDealer"), 0), 0))
                lblDealerV.Text = "Venta DEALER ($200)X$MM"
            End If
            DatosSeguros()
        Else
            lblCrTrDeal.Text = ""
            Exit Sub
        End If
        If lblPenCond.Text = "O" Then
            lblPenCond.Text = (ds.Tables(0).Rows(0).Item("Condicion")) & "<br/> (" & (ds.Tables(0).Rows(0).Item("CondicionO")) & ")"
            If lblAfCumSuc.Text = "SI" Then
                lblIncPens.Text = FormatNumber(((lblIncen.Text) / 2), 0)
            Else
                lblIncPens.Text = FormatNumber((lblIncen.Text), 0)
            End If
        End If
        If lblPenCond.Text = "Y" Then
            lblPenCond.Text = (ds.Tables(0).Rows(0).Item("Condicion")) & "<br/>(AMBAS)"
            If lblAfCumSuc.Text = "SI" Then
                lblIncPens.Text = FormatNumber(((lblIncen.Text) / 2), 0)
            Else
                lblIncPens.Text = FormatNumber((lblIncen.Text), 0)
            End If
        End If
    End Sub

    Private Sub DatosSeguros()

        vNombreSP = "select * from CPECPagoIncentivoSeguros where Rut=" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & _
                   " and Periodo='" & ddlAño.SelectedValue & "-" & ddlMes.SelectedValue & "-01" & "'"
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        If ds.Tables(0).Rows.Count > 0 Then
            lblColPens.Text = Nz((ds.Tables(0).Rows(0).Item("ColorPens")), "-")
            lblRankPens.Text = Nz((ds.Tables(0).Rows(0).Item("RanPensParaGanar")), "-")
            lblColTrab.Text = Nz((ds.Tables(0).Rows(0).Item("ColorTrab")), "-")
            lblRankTrab.Text = Nz((ds.Tables(0).Rows(0).Item("RanTrabParaGanar")), "-")
            lblColCes.Text = Nz((ds.Tables(0).Rows(0).Item("ColorCes")), "-")
            lblRankCes.Text = Nz((ds.Tables(0).Rows(0).Item("RanCesParaGanar")), "-")
            lblVentasPens.Text = Nz(FormatNumber(ds.Tables(0).Rows(0).Item("CantidadIndPens"), 0), "-")
            lblVentasTrab.Text = Nz(FormatNumber(ds.Tables(0).Rows(0).Item("CantidadIndTrab"), 0), "-")
            lblVentasCes.Text = Nz(FormatNumber(ds.Tables(0).Rows(0).Item("CantidadSegCes"), 0), "-")
            lblRCes.Text = Nz((ds.Tables(0).Rows(0).Item("RankCes")), "-")
            lblRPens.Text = Nz((ds.Tables(0).Rows(0).Item("RankIndPens")), "-")
            lblRTrab.Text = Nz((ds.Tables(0).Rows(0).Item("RankIndTrab")), "-")
            lblIncenCes.Text = FormatNumber(ds.Tables(0).Rows(0).Item("IncentivoCes"), 0)
            lblIncenTrab.Text = FormatNumber(ds.Tables(0).Rows(0).Item("IncentivoTrab"), 0)
            lblIncenPens.Text = FormatNumber(ds.Tables(0).Rows(0).Item("IncentivoPens"), 0)
            lblTotalIncentivoF.Text = FormatNumber(ds.Tables(0).Rows(0).Item("TotalIncentivo"), 0)
            lblValorTrab.Text = "$" & Nz(FormatNumber(ds.Tables(0).Rows(0).Item("ValorTrab"), 0), 0)
            lblValorPens.Text = "$" & Nz(FormatNumber(ds.Tables(0).Rows(0).Item("ValorPens"), 0), 0)
            lblValorCes.Text = "$" & Nz(FormatNumber(ds.Tables(0).Rows(0).Item("ValorCes"), 0), 0)
        Else
            lblColPens.Text = ""
            lblRankTrab.Text = ""
            lblColTrab.Text = ""
            lblRankTrab.Text = ""
            lblColCes.Text = ""
            lblRankCes.Text = ""
        End If
    End Sub

    Private Sub ddlAño_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAño.SelectedIndexChanged
        Session("UsuarioAct.ActDDL") = ddlAño.SelectedValue
        DDL()

    End Sub
End Class