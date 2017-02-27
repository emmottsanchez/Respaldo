Imports System.Net
Public Class Transacciones
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
        LlenarDatos()
        DataActualizada()
    End Sub

    Private Sub LlenarDatos()
        Dim thisDate As Date
        thisDate = Today
        Dim Año As Integer = Year(thisDate)
        Dim Mes As String = Month(thisDate)
        If Mes = "1" Then
            Mes = "01"
        End If
        If Mes = "2" Then
            Mes = "02"
        End If
        If Mes = "3" Then
            Mes = "03"
        End If
        If Mes = "4" Then
            Mes = "04"
        End If
        If Mes = "5" Then
            Mes = "05"
        End If
        If Mes = "6" Then
            Mes = "06"
        End If
        If Mes = "7" Then
            Mes = "07"
        End If
        If Mes = "8" Then
            Mes = "08"
        End If
        If Mes = "9" Then
            Mes = "09"
        End If
        vNombreSP = "select * from CPECTransaccionesLicenciasVTA where Rut=" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & _
                   " and Año='" & Año & "' and Mes='" & Mes & "'"
        vArgumentos = ""
        Dim ds As DataSet = cnn.EjecutarSP(vNombreSP, vArgumentos)
        If ds.Tables(0).Rows.Count > 0 Then
            lblLM.Text = Nz(ds.Tables(0).Rows(0).Item("LM"), 0)
            lblMsg.Visible = False
        Else
            lblLM.Text = "Sin Datos"
            lblMsg.Visible = True

        End If

        Dim Año2 As Integer = Year(thisDate)
        Dim Mes2 As Integer = Month(thisDate)

        Dim vNombreS As String = "select * from CPECTransaccionesCuponesVTA where RutPec=" & VarSQL(Session("UsuarioAct.Rut"), TipoVar.Numerico) & _
           " and AñoEntrega='" & Año2 & "' and MesEntrega='" & Mes2 & "'"
        Dim vArgumento As String = ""
        Dim ds1 As DataSet = cnn.EjecutarSP(vNombreS, vArgumento)
        If ds1.Tables(0).Rows.Count > 0 Then
            lblPG.Text = Nz(ds1.Tables(0).Rows(0).Item("Cupones"), 0)
            lblMsg.Visible = False
        Else
            lblPG.Text = "Sin Datos"
            lblMsg.Visible = True
            Exit Sub
        End If

    End Sub

    Sub DataActualizada()
        vNombreSP = "select top 1 (convert(datetime,FEC_REC)) as Fecha from LicenciasMedicas2015 group by FEC_REC order by FEC_REC desc"
        vArgumentos = ""
        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
        If ds.Tables(0).Rows.Count < 1 Then
            lblLMed.Text = "(No existen datos en sistema para este periodo)"
        Else
            lblLMed.Text = "Licencias actualizadas al: " & ds.Tables(0).Rows(0).Item("Fecha")
        End If

        Dim vN As String = "SELECT TOP 1 (CAST(DiaEntrega AS varchar(2)) +'-'+ CAST(MesEntrega AS VARCHAR(2)) +'-'+ CAST(AñoEntrega AS varchar(4))) AS Fecha FROM PGCupones ORDER BY DiaEntrega DESC"
        Dim vA As String = ""
        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
        If ds.Tables(0).Rows.Count < 1 Then
            lblCupon.Text = "(No existen datos en sistema para este periodo)"
        Else
            lblCupon.Text = "Cupones actualizados al: " & ds.Tables(0).Rows(0).Item("Fecha")
        End If
    End Sub

End Class