Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data

Imports System.IO

Public Class Conexion

    Private cnnAct As New SqlConnection()

    Public Sub New()

        Dim sCadConexionActiva As String = My.Settings("CadConexionActiva")
        cnnAct.ConnectionString = ConfigurationManager.ConnectionStrings(sCadConexionActiva).ConnectionString

    End Sub

    Public Function EjecutarSP(ByVal NombreSP As String, ByVal Argumentos As String) As DataSet

        Dim ds As New DataSet

        Try
            Dim strEjec As String = NombreSP & " " & Argumentos

            cnnAct.Open()

            'crear objeto Data Adapter para asocir Comando y Conexión
            Dim da As New SqlDataAdapter(strEjec, cnnAct)

            'Transferir datos a dataset
            da.Fill(ds)

        Catch ex As SqlException
            'Controlador de errores 
            Dim dt As New DataTable()
            dt.Columns.Add("IdEstado", System.Type.GetType("System.Int32"))
            dt.Columns.Add("EstadoTec", System.Type.GetType("System.String"))
            dt.Columns.Add("EstadoUsr", System.Type.GetType("System.String"))

            Dim dr As DataRow
            dr = dt.NewRow()
            dr("IdEstado") = -11
            dr("EstadoTec") = Err.Description & "(" & Err.Number & ")"
            dr("EstadoUsr") = "Error en ejecución de Proceso"
            dt.Rows.Add(dr)

            ds.Tables.Add(dt)
            GoTo Salir
        End Try

Salir:
        If cnnAct.State = ConnectionState.Open Then cnnAct.Close()
        Return ds

    End Function



End Class


