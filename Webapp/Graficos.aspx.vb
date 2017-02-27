Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Data
Public Class Graficos
    Inherits System.Web.UI.Page
    Dim vNombreSP As String
    Dim vArgumentos As String
    Dim cnn As New Webapp.Conexion
    Dim ds As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = True Then Exit Sub

        If IsNothing(Session("UsuarioAct.Usuario")) Then
            plMantenedorGr.Visible = False
        Else
            plMantenedorGr.Visible = True
        End If
        DatosCredTrab()
        DatosCredPens()
        DatosAfiFFAA()
        DatosAfiTrad()
        PecCredTrab()
        PecCredPens()
        PecAfiTrad()
        PecAfiFFAA()
        CredTrab()
        CredPens()
    End Sub

    Sub DatosCredTrab()
        vNombreSP = "select * from CPECGraficoValCredTrab "
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        lblMesAct.Text = "Mes Actual: " & Nz(FormatCurrency((ds.Tables(0).Rows(0).Item("MesActual")), 0), 0)
        lblMesAnt.Text = "Mes Anterior: " & Nz(FormatCurrency((ds.Tables(0).Rows(0).Item("MesAnterior")), 0), 0)
        lblAñoAnt.Text = "Año Anterior: " & Nz(FormatCurrency((ds.Tables(0).Rows(0).Item("AñoAnterior")), 0), 0)

    End Sub

    Sub DatosCredPens()
        vNombreSP = "select * from CPECGraficoValCredPens "
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        lblMesAct2.Text = "Mes Actual: " & Nz(FormatCurrency((ds.Tables(0).Rows(0).Item("MesActual")), 0), 0)
        lblMesAnt2.Text = "Mes Anterior: " & Nz(FormatCurrency((ds.Tables(0).Rows(0).Item("MesAnterior")), 0), 0)
        lblAñoAnt2.Text = "Año Anterior: " & Nz(FormatCurrency((ds.Tables(0).Rows(0).Item("AñoAnterior")), 0), 0)

    End Sub

    Sub DatosAfiFFAA()
        vNombreSP = "select * from CPECGraficoValAfiFFAA "
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        lblMesAct3.Text = "Mes Actual: " & Nz((ds.Tables(0).Rows(0).Item("MesActual")), 0)
        lblMesAnt3.Text = "Mes Anterior: " & Nz((ds.Tables(0).Rows(0).Item("MesAnterior")), 0)
        lblAñoAnt3.Text = "Año Anterior: " & Nz((ds.Tables(0).Rows(0).Item("AñoAnterior")), 0)

    End Sub

    Sub DatosAfiTrad()
        vNombreSP = "select * from CPECGraficoValAfiTrad "
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        lblMesAct4.Text = "Mes Actual: " & Nz((ds.Tables(0).Rows(0).Item("MesActual")), 0)
        lblMesAnt4.Text = "Mes Anterior: " & Nz((ds.Tables(0).Rows(0).Item("MesAnterior")), 0)
        lblAñoAnt4.Text = "Año Anterior: " & Nz((ds.Tables(0).Rows(0).Item("AñoAnterior")), 0)

    End Sub

    Sub PecCredTrab()
        vNombreSP = "select orden=1,COUNT(distinct(p.Rut)) as CredPECPens_201611 from Creditos C join CPECUsuarios p on p.NombBt=C.nombre_usuario_ingreso collate SQL_Latin1_General_CP1_CI_AS" & _
                    " where C.Segmento=32 and year(C.fecha_contable)=2016 and MONTH(C.fecha_contable)=11 and C.estado<>'Anulado' and p.Periodo='2016-11-01'  and C.numero_sucursal not in (81,82) " & _
                    " union select orden=2,COUNT(distinct(p.Rut)) as CredPECPens_201610 from Creditos201610 C join CPECUsuarios p on p.NombBt=C.nombre_usuario_ingreso collate SQL_Latin1_General_CP1_CI_AS" & _
                    " where C.Segmento=32 and year(C.fecha_contable)=2016 and MONTH(C.fecha_contable)=10 and C.estado<>'Anulado' and p.Periodo='2016-11-01'  and C.numero_sucursal not in (81,82) " & _
                    " union select orden=3,COUNT(distinct(p.Rut)) as CredPECPens_201511 from CreditosHis C  join CPECUsuarios p on p.NombBt=C.nombre_usuario_ingreso collate SQL_Latin1_General_CP1_CI_AS" & _
                    " where C.CodSegmentoCli=32 and year(C.fecha_contable)=2015 and MONTH(C.fecha_contable)=11 and C.estado<>'Anulado' and p.Periodo='2016-11-01' and AñoMes=201511  and C.numero_sucursal not in (81,82) "
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        lblPecMAct.Text = "PEC Mes Actual: " & Nz((ds.Tables(0).Rows(0).Item("CredPECPens_201611")), 0)
        lblPecMAnt.Text = "PEC Mes Anterior: " & Nz((ds.Tables(0).Rows(1).Item("CredPECPens_201611")), 0)
        lblPecAÑAnt.Text = "PEC Año Anterior: " & Nz((ds.Tables(0).Rows(2).Item("CredPECPens_201611")), 0)

    End Sub

    Sub PecCredPens()
        vNombreSP = "select orden=1,COUNT(distinct(p.Rut)) as CredPECPens_201611 from Creditos C join CPECUsuarios p on p.NombBt=C.nombre_usuario_ingreso collate SQL_Latin1_General_CP1_CI_AS" & _
                    " where C.Segmento=30 and year(C.fecha_contable)=2016 and MONTH(C.fecha_contable)=11 and C.estado<>'Anulado' and p.Periodo='2016-11-01'  and C.numero_sucursal not in (81,82) " & _
                    " union select orden=2,COUNT(distinct(p.Rut)) as CredPECPens_201610 from Creditos201610 C join CPECUsuarios p on p.NombBt=C.nombre_usuario_ingreso collate SQL_Latin1_General_CP1_CI_AS" & _
                    " where C.Segmento=30 and year(C.fecha_contable)=2016 and MONTH(C.fecha_contable)=10 and C.estado<>'Anulado' and p.Periodo='2016-11-01'  and C.numero_sucursal not in (81,82) " & _
                    " union select orden=3,COUNT(distinct(p.Rut)) as CredPECPens_201511 from CreditosHis C  join CPECUsuarios p on p.NombBt=C.nombre_usuario_ingreso collate SQL_Latin1_General_CP1_CI_AS" & _
                    " where C.CodSegmentoCli=30 and year(C.fecha_contable)=2015 and MONTH(C.fecha_contable)=11 and C.estado<>'Anulado' and p.Periodo='2016-11-01' and AñoMes=201511  and C.numero_sucursal not in (81,82) "
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        lblPMesAc.Text = "PEC Mes Actual: " & Nz((ds.Tables(0).Rows(0).Item("CredPECPens_201611")), 0)
        lblPMesAn.Text = "PEC Mes Anterior: " & Nz((ds.Tables(0).Rows(1).Item("CredPECPens_201611")), 0)
        lblPAñoAn.Text = "PEC Año Anterior: " & Nz((ds.Tables(0).Rows(2).Item("CredPECPens_201611")), 0)

    End Sub

    Sub PecAfiTrad()
        vNombreSP = "SELECT  orden=1,  COUNT(distinct(p.rut)) as PEC FROM dbo.Afiliaciones a join HomologacionDotacion c on a.CREADO_POR=c.NombreSAP collate SQL_Latin1_General_CP1_CI_AS join CPECUsuarios p on p.Rut=c.Rut" & _
                    " WHERE (TRADICIONAL_PBS = 'TRADICIONAL') AND (INGRESO_ACEPTADO > 93543) AND (EN_INGRESO = 'Validación aceptada') AND MES_PROCESO=201611 and p.Periodo='2016-11-01' " & _
                    " union SELECT   orden=2,  COUNT(distinct(p.rut)) FROM dbo.Afiliaciones201610 a join HomologacionDotacion c on a.CREADO_POR=c.NombreSAP collate SQL_Latin1_General_CP1_CI_AS join CPECUsuarios p on p.Rut=c.Rut" & _
                    " WHERE      (TRADICIONAL_PBS = 'TRADICIONAL') AND (INGRESO_ACEPTADO > 93543) AND (EN_INGRESO = 'Validación aceptada') AND MES_PROCESO=201610 and p.Periodo='2016-11-01'" & _
                    " union SELECT  orden=3,   COUNT(distinct(p.rut)) FROM dbo.AfiliacionesHis a join HomologacionDotacion c on a.CREADO_POR=c.NombreSAP collate SQL_Latin1_General_CP1_CI_AS join CPECUsuarios p on p.Rut=c.Rut" & _
                    " WHERE      (TRADICIONAL_PBS = 'TRADICIONAL') AND (INGRESO_ACEPTADO > 93543) AND (EN_INGRESO = 'Validación aceptada') AND MES_PROCESO=201511 and p.Periodo='2016-11-01'"
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        lblPAfTrMAct.Text = "PEC Mes Actual: " & Nz((ds.Tables(0).Rows(0).Item("PEC")), 0)
        lblPAfTrMAnt.Text = "PEC Mes Anterior: " & Nz((ds.Tables(0).Rows(1).Item("PEC")), 0)
        lblPAfTrAñAnt.Text = "PEC Año Anterior: " & Nz((ds.Tables(0).Rows(2).Item("PEC")), 0)
    End Sub

    Sub PecAfiFFAA()
        vNombreSP = "SELECT    orden=1,COUNT(distinct(p.rut)) as PEC FROM dbo.Afiliaciones a join HomologacionDotacion c on a.CREADO_POR=c.NombreSAP collate SQL_Latin1_General_CP1_CI_AS join CPECUsuarios p on p.Rut=c.Rut" & _
                    " WHERE (TRADICIONAL_PBS = 'EXFFAA') AND (INGRESO_ACEPTADO > 93543) AND (EN_INGRESO = 'Validación aceptada') AND MES_PROCESO=201611 and p.Periodo='2016-11-01' " & _
                    " union SELECT   orden=2,  COUNT(distinct(p.rut)) FROM dbo.Afiliaciones201610 a join HomologacionDotacion c on a.CREADO_POR=c.NombreSAP collate SQL_Latin1_General_CP1_CI_AS join CPECUsuarios p on p.Rut=c.Rut" & _
                    " WHERE      (TRADICIONAL_PBS = 'EXFFAA') AND (INGRESO_ACEPTADO > 93543) AND (EN_INGRESO = 'Validación aceptada') AND MES_PROCESO=201610 and p.Periodo='2016-11-01'" & _
                    " union SELECT  orden=3,   COUNT(distinct(p.rut)) FROM dbo.AfiliacionesHis a join HomologacionDotacion c on a.CREADO_POR=c.NombreSAP collate SQL_Latin1_General_CP1_CI_AS join CPECUsuarios p on p.Rut=c.Rut" & _
                    " WHERE      (TRADICIONAL_PBS = 'EXFFAA') AND (INGRESO_ACEPTADO > 93543) AND (EN_INGRESO = 'Validación aceptada') AND MES_PROCESO=201511 and p.Periodo='2016-11-01'"
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        lblPFVMesAc.Text = "PEC Mes Actual: " & Nz((ds.Tables(0).Rows(0).Item("PEC")), 0)
        lblPFVMesAn.Text = "PEC Mes Anterior: " & Nz((ds.Tables(0).Rows(1).Item("PEC")), 0)
        lblPFVAñAnt.Text = "PEC Año Anterior: " & Nz((ds.Tables(0).Rows(2).Item("PEC")), 0)
    End Sub

    Sub CredTrab()
        vNombreSP = "select * from CantCredTrab order by orden asc"
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        lblCredMAct.Text = "N° Creditos Mes Act:" & Nz((ds.Tables(0).Rows(0).Item("Creditos")), 0)
        lblCredMAnt.Text = "N° Creditos Mes Ant:" & Nz((ds.Tables(0).Rows(1).Item("Creditos")), 0)
        lblCredAñAnt.Text = "N° Creditos Año Ant:" & Nz((ds.Tables(0).Rows(2).Item("Creditos")), 0)
    End Sub

    Sub CredPens()
        vNombreSP = "select * from CantCredPens order by orden asc"
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        LblCMesAct.Text = "N° Creditos Mes Act:" & Nz((ds.Tables(0).Rows(0).Item("Creditos")), 0)
        LblCMesAnt.Text = "N° Creditos Mes Ant:" & Nz((ds.Tables(0).Rows(1).Item("Creditos")), 0)
        LblCAñoAn.Text = "N° Creditos Año Ant:" & Nz((ds.Tables(0).Rows(2).Item("Creditos")), 0)
    End Sub

End Class