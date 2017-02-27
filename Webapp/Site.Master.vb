Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Public Class Site
    Inherits System.Web.UI.MasterPage
    Dim vNombreSP As String
    Dim vArgumentos As String
    Dim cnn As New Webapp.Conexion
    Dim ds As DataSet
    Dim Destinatario As String
    Dim Nombre As String
    Dim Clave As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = True Then Exit Sub
        If Day(DateTime.Now) = 1 Then
            Msg1d.Visible = False
            Exit Sub
        End If
        If IsNothing(Session("UsuarioAct.Usuario")) Then
            Pan_Log.Visible = True
            Pan_Logout.Visible = False
        Else
            Pan_Log.Visible = False
            Pan_Logout.Visible = True
            lblUsarioRegistrado.Text = Session("UsuarioAct.NomCorto")

        End If

        If Session("UsuarioAct.Agente") = 1 Then
            backAgente.Visible = True
        Else
            Session("UsuarioAct.Agente") = 0
            backAgente.Visible = False
        End If

        If Session("Usuario.Menu") = 0 Then
            btnInicio.Visible = False
            btnCampañas.Visible = False
            btnPagoIncentivo.Visible = False
            btnListaTomaCon.Visible = False
            btnTransacciones.Visible = False
        Else
            Session("Usuario.Menu") = 1
            btnInicio.Visible = True
            btnCampañas.Visible = True
            btnPagoIncentivo.Visible = True
            btnListaTomaCon.Visible = True
            btnTransacciones.Visible = True
        End If
    End Sub

    Private Sub btnCampañas_Click(sender As Object, e As EventArgs) Handles btnCampañas.Click
        Response.Redirect("~/Campañas.aspx")
        Pan_Log.Visible = False
        Pan_Logout.Visible = True
    End Sub

    Private Sub btnListaTomaCon_Click(sender As Object, e As EventArgs) Handles btnListaTomaCon.Click
        Response.Redirect("~/TomaConocimiento.aspx")
        Pan_Log.Visible = False
        Pan_Logout.Visible = True
    End Sub

    Private Sub btnAcceder_Click(sender As Object, e As EventArgs) Handles btnAcceder.Click

        If tbUsuario.Text = "" Then
            lblError.Text = "* Debe ingresar Usuario"
            Exit Sub
        End If
        If tbContraseña.Text = "" Then
            lblError.Text = "* Debe ingresar Contraseña"
            Exit Sub
        End If
        'Agente
        Dim vNombreSP2 As String = "IF EXISTS (select * from PGUsuarios where Rut=" & tbUsuario.Text & ") SELECT 1 ELSE SELECT 0"
        Dim vArgumentos2 As String = ""
        Dim ds2 As DataSet = cnn.EjecutarSP(vNombreSP2, vArgumentos2)
        If (ds2.Tables(0).Rows(0).Item(0) = 1) Then
            Dim vNombreSP3 As String = "EXEC PGSesionPanelPec"
        Dim vArgumentos3 = "@Rut='" & tbUsuario.Text & "'" & _
                     ", @Contraseña=" & tbContraseña.Text
        Dim ds3 As DataSet = cnn.EjecutarSP(vNombreSP3, vArgumentos3)
        If (ds3.Tables(0).Rows(0).Item("idEstado") = 0) Then
            Dim vNombreSP4 As String = "EXEC PGRolesUsuarioInfo"
            Dim vArgumentos4 = "@idUsuario=" & ds3.Tables(0).Rows(0).Item("idUsuario") & _
                         ", @Periodo=" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha) & "" & _
                         ", @Red=1"
                Dim ds4 As DataSet = cnn.EjecutarSP(vNombreSP4, vArgumentos4)
                If ds4.Tables(0).Rows(0).Item("idEstado") = 1 Then
                    Exit Sub
                End If
                If ds4.Tables(0).Rows(0).Item("Rol") = "Regional" Then
                        Session("UsuarioAct.Regional") = 1
                        Session("UsuarioAct.id") = ds4.Tables(0).Rows(0).Item("idUsuario")
                    End If
                    If ds4.Tables(0).Rows(0).Item("Rol") = "Acceso Completo" Then
                        Session("UsuarioAct.Admin") = 1
                End If
                If ds4.Tables(0).Rows(0).Item("Rol") = "Agente" Then
                    Session("UsuarioAct.Admin") = 0
                    Session("UsuarioAct.Usuario") = Nothing
                    Exit Sub
                End If
                    If ds4.Tables(0).Rows(0).Item("Rol") = "Jefe Red" Then
                        Session("UsuarioAct.Admin") = 1
                    End If
                    Pan_Log.Visible = False
                    Pan_Logout.Visible = True
                    Session("UsuarioAct.Usuario") = ds4.Tables(0).Rows(0).Item("Usuario")
                    Session("UsuarioAct.id") = ds4.Tables(0).Rows(0).Item("idUsuario")
                'Session("UsuarioAct.Agente") = 1
                    Session("Usuario.Menu") = 0
                    Session("UsuarioAct.NomCorto") = ds4.Tables(0).Rows(0).Item("Usuario")
                    backAgente.Visible = True
                Response.Redirect("~/Admin.aspx")
                End If
            End If
            'Fin 
            Dim vNombreSP1 As String = "IF EXISTS (select * from CPECUsuarios where Rut=" & tbUsuario.Text & _
                                       " and Periodo=" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha) & ") SELECT 1 ELSE SELECT 0"
            Dim vArgumentos1 As String = ""
            Dim ds1 As DataSet = cnn.EjecutarSP(vNombreSP1, vArgumentos1)

            If (ds1.Tables(0).Rows(0).Item(0) = 0) Then
                lblError.Text = "Usuario no existe en sistema"
                Exit Sub
            Else

                vNombreSP = "EXEC CPECIniciarSesion"
                vArgumentos = "@Rut='" & tbUsuario.Text & "'" & _
                             ", @Contraseña=" & tbContraseña.Text & _
                             ", @Periodo =" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha)
                ds = cnn.EjecutarSP(vNombreSP, vArgumentos)

                If ds.Tables(0).Rows(0).Item("IdEstado") <> 0 Then
                    lblError.Text = "Rut y/o Clave incorrecto <br/>* Si no recuerda contraseña favor click en ¿Olvidó su contraseña?"
                    Exit Sub
                End If

                If Len(tbContraseña.Text) < 6 Then
                    If tbContraseña.Text = Left(tbUsuario.Text, 5) Then
                        lblError.Text = "Contraseña debe tener como mínimo 6 dígitos."
                        tbContraseña.Visible = True
                        tbUsuario.ReadOnly = True
                        tbContraseña.Text = ""
                        tbContraseña.Visible = False
                        btnAcceder.Visible = False
                        btnCambiarC.Visible = True
                        btnCancelar.Visible = True
                        tbContraseña1.Visible = True
                        Session("UsuarioAct.Rut") = tbUsuario.Text
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Cambiar", "CambiarContraseña();", True)
                        Exit Sub
                    End If

                    If tbContraseña.Text <> Left(tbUsuario.Text, 5) Then
                        Session("UsuarioAct.Rut") = tbUsuario.Text
                        lblError.Text = "* Contraseña incorrecta"
                        Exit Sub
                    End If

                End If

                If ds.Tables(0).Rows(0).Item("Contraseña") = Left(tbUsuario.Text, 5) Then
                    Session("UsuarioAct.Usuario") = ds.Tables(0).Rows(0).Item("Usuario")
                    Session("UsuarioAct.Rut") = tbUsuario.Text
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "Cambiar", "CambiarContraseña();", True)
                    lblError.Text = "Contraseña debe tener como mínimo 6 dígitos."
                Else

                    If Len(ds.Tables(0).Rows(0).Item("Contraseña")) < 6 Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Cambiar", "CambiarContraseña();", True)
                        Session("UsuarioAct.Usuario") = Nothing
                        Exit Sub
                    Else
                        Session("UsuarioAct.Usuario") = ds.Tables(0).Rows(0).Item("Usuario")
                        Session("UsuarioAct.Sucursal2") = ds.Tables(0).Rows(0).Item("Sucursal")
                        Session("UsuarioAct.NomCorto") = ds.Tables(0).Rows(0).Item("NomCorto")
                        Session("UsuarioAct.NombBt") = ds.Tables(0).Rows(0).Item("NombBt")
                        Session("UsuarioAct.SoloNombre") = ds.Tables(0).Rows(0).Item("SoloNombre")
                        Session("UsuarioAct.Rut") = tbUsuario.Text
                        Session("UsuarioAct.Contraseña") = tbContraseña.Text
                        Session("UsuarioAct.Agente") = 0
                        Session("Usuario.Menu") = 1
                        Pan_Log.Visible = False
                        Pan_Logout.Visible = True
                        Response.Redirect("~/Campañas.aspx")
                        lblUsarioRegistrado.Text = Session("UsuarioAct.NomCorto")
                    End If

                End If
            End If
    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Session("UsuarioAct.Usuario") = Nothing
        Session("UsuarioAct.Regional") = Nothing
        Session("UsuarioAct.Admin") = Nothing
        Response.Redirect("~/default.aspx")
    End Sub

    Private Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        Response.Redirect("~/default.aspx")
    End Sub

    Private Sub btnCambiarC_Click(sender As Object, e As EventArgs) Handles btnCambiarC.Click
        If Len(tbContraseña1.Text) < 6 Then
            lblError.Text = "Contraseña debe tener 6 dígitos como mínimo."
            Exit Sub
        End If
        If IsNumeric(tbContraseña1.Text) = True Then
            If Len(tbContraseña1.Text) > 5 Then
                vNombreSP = "UPDATE CPECUsuarios set  Contraseña=" & tbContraseña1.Text & _
                      " where  Rut=" & tbUsuario.Text & _
                      " AND Periodo=" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha)
                vArgumentos = ""
                ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
                Pan_Log.Visible = True
                tbContraseña1.Visible = False
                tbContraseña.Visible = True
                btnCambiarC.Visible = False
                btnAcceder.Visible = True
                tbUsuario.ReadOnly = False
                btnCancelar.Visible = False
                lblError.Text = "Ingresar con contraseña nueva"
                Exit Sub
            Else
                Session("UsuarioAct.Usuario") = Nothing
                lblError.Text = "Contraseña debe tener como mínimo 6 dígitos."
                Response.Redirect("~/default.aspx")
            End If
        Else
            Session("UsuarioAct.Usuario") = Nothing
            lblError.Text = "Contraseña debe ser numérica."
            Response.Redirect("~/default.aspx")
        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Session("UsuarioAct.Usuario") = Nothing
        Response.Redirect("~/default.aspx")
    End Sub

    Private Sub btnPagoIncentivo_Click(sender As Object, e As EventArgs) Handles btnPagoIncentivo.Click
        Response.Redirect("~/PagoIncentivos.aspx")
        Pan_Log.Visible = False
        Pan_Logout.Visible = True
    End Sub

    Private Sub btnRecMail_Click(sender As Object, e As EventArgs) Handles btnRecMail.Click
        Dim strMsg As String = Nothing
        Dim SmtpServer As New SmtpClient()
        Dim mail As New MailMessage()
        Dim vN As String = "IF EXISTS (select * from CPECUsuarios where Email='" & tbRecEmail.Text & _
                                   "' and Periodo=" & VarSQL(DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1), TipoVar.Fecha) & ") SELECT 1 ELSE SELECT 0"
        Dim vArg As String = ""
        Dim ds1 As DataSet = cnn.EjecutarSP(vN, vArg)
        If (ds1.Tables(0).Rows(0).Item(0) = 0) Then
            lblError.Text = "Correo no existe en sistema"
            Exit Sub
        End If

        vNombreSP = "Select * from CPECUsuarios  where Email='" & tbRecEmail.Text & "' order by Periodo Desc"
        vArgumentos = ""
        ds = cnn.EjecutarSP(vNombreSP, vArgumentos)
        SmtpServer.Credentials = New Net.NetworkCredential("cemmott@losheroes.cl", "Heroes.91")

        SmtpServer.Host = "smtp.losheroes.losheroes.cl"
        SmtpServer.Port = "25"
        SmtpServer.EnableSsl = False

        Dim image1 As LinkedResource = New LinkedResource("D:\Users\cemmott\Desktop\Trabajo\Proyecto CPEC\RELEASE CPEC\CPEC-Produccion Actualizado V1.10\Webapp\assets\img\Edificio.jpg", MediaTypeNames.Image.Jpeg)
        image1.ContentId = "Images1"

        mail = New MailMessage()
        mail.From = New MailAddress("noreply@losheroes.cl", "Panel Ejecutivos PEC")

        mail.To.Add(tbRecEmail.Text)
        mail.Bcc.Add("cemmott@losheroes.cl")


        mail.Subject = "Recuperación de Contraseña  -  Panel PEC"

        'mail.Body =
        ' 'strMsg = "<table style''font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif" & _
        '           "<tr> <td style=''color:#004358;font-size:16px''> <b>  Estimado(a) &nbsp; " & ds.Tables(0).Rows(0).Item("NombRRHH") & " ,</b><br /><br /> </td> </tr>" & _
        '           "<tr> <td style=''color:#004358;font-size:16px''> Tu contraseña actual  es :  &nbsp; " & Clave & "<br /><br /> </td></tr>" & _
        '           "<tr> <td style=''color:#004358;font-size:13px''> Si ha recibido este correo electrónico y usted no ha solicitado la recuperación " & _
        '           "de su contraseña, puede ignorar este mensaje. <br /> Este email se envía de forma automática por lo que rogamos no responder. </td><img src=cid:Images1 alt='image description'></tr></table>"

        Dim vCuerpo As String = LeerArchivo(MapPath("~/Plantillas/PlantillaMail.html"))
        vCuerpo = Replace(vCuerpo, "<<contraseña>>", ds.Tables(0).Rows(0).Item("Contraseña"))
        vCuerpo = Replace(vCuerpo, "<<nombreusuario>>", ds.Tables(0).Rows(0).Item("NombRRHH"))

        Dim av1 As AlternateView = AlternateView.CreateAlternateViewFromString(vCuerpo, Nothing, MediaTypeNames.Text.Html)
        av1.LinkedResources.Add(image1)

        mail.AlternateViews.Add(av1)
        mail.IsBodyHtml = True
        SmtpServer.Send(mail)
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Cambiar", "EnvioCorreo();", True)
    End Sub

    Function LeerArchivo(RutaArchivo As String) As String

        Dim tmp As String
        Try
            ' Open the file using a stream reader.
            Using sr As New System.IO.StreamReader(RutaArchivo)
                tmp = sr.ReadToEnd()
            End Using
        Catch e As Exception
            tmp = "ERROR: " & e.Message
        End Try

        Return tmp

    End Function



    Private Sub btnTransacciones_Click(sender As Object, e As EventArgs) Handles btnTransacciones.Click
        Response.Redirect("~/Transacciones.aspx")
        Pan_Log.Visible = False
        Pan_Logout.Visible = True
    End Sub

    Private Sub backAgente_Click(sender As Object, e As EventArgs) Handles backAgente.Click
        Response.Redirect("~/Agente.aspx")
    End Sub
End Class