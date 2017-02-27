<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.vb" Inherits="Webapp._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
      <asp:Panel runat="server" ID="plMantenedor" Visible="false" Width="90%">
        <center><asp:Label runat="server" Text="Mantención Sistema PEC" Font-Size="25px" ></asp:Label></center><br />
        <table class=" table-bordered" >
            <tr style="background-color:black;color:white" >
                <th>Menú</th>
                <th>Concepto</th>
                <th style="font-size:16px">Tabla SQL</th>
                <th style="font-size:16px">Archivo de Carga</th>
                <th style="font-size:16px">Responsable Envio</th>
                <th style="font-size:16px">Canal de Envio</th>
                <th style="font-size:16px">periodicidad</th>
            </tr>
            <tr>
                <td style="font-size:16px"></td>
                <td style="font-size:14px">Dotación Ejecutivos PEC</td>
                <td style="font-size:13px">CPECUsuarios</td>
                <td style="font-size:13px">Dotación Ejecutivos Plataforma Comercial-(Dia-Mes)</td>
                <td style="font-size:13px">Nicolas Lucero</td>
                 <td style="font-size:13px">Correo</td>
                <td style="font-size:13px">Semanal</td>
            </tr>
            <tr>
                <td style="font-size:16px" rowspan="4">Campañas Comerciales</td>
                <td style="font-size:14px">Seguimiento Diario Seguros</td>
                <td style="font-size:13px">CPECSeguimientoDiarioSeguros</td>
                <td style="font-size:13px">Reporte Red Comercial-(fecha)</td>
                <td style="font-size:13px">Katherine Vilche</td>
                <td style="font-size:13px">Carpeta Compartida (Bases Seguimiento Diario Seguros)</td>
                <td style="font-size:13px">Diario</td>
            </tr>
            <tr>
                <td style="font-size:14px">Seguimiento Campañas Flash</td>
                <td style="font-size:13px"></td>
                <td style="font-size:13px"></td>
                <td style="font-size:13px"></td>
                 <td style="font-size:13px"></td>
                <td style="font-size:13px"></td>
            </tr>
            <tr>
                <td style="font-size:14px">Seguimiento Campañas Trabajadores</td>
                <td style="font-size:13px"></td>
                <td style="font-size:13px"></td>
                <td style="font-size:13px"></td>
                 <td style="font-size:13px"></td>
                <td style="font-size:13px"></td>
            </tr>
            <tr>
                <td style="font-size:14px">Seguimiento Campañas Pensionados</td>
                <td style="font-size:13px"></td>
                <td style="font-size:13px"></td>
                <td style="font-size:13px"></td>
                 <td style="font-size:13px"></td>
                <td style="font-size:13px"></td>
            </tr>
            <tr>
                <td style="font-size:16px">Toma de Conocimiento</td>
                <td style="font-size:14px">Toma Conocimiento</td>
                <td style="font-size:13px">CPECUsuarios</td>
                <td style="font-size:13px">Columna TomaConocimiento en Tabla CPECUsuarios</td>
                <td style="font-size:13px">Sistema</td>
                <td style="font-size:13px">Sistema guarda Acciones en tabla</td>
                <td style="font-size:13px">Diario</td>
            </tr>
            <tr>
                <td style="font-size:16px" rowspan="2">Pagos de Incentivos</td>
                <td style="font-size:14px">Pago Incentivo Seguros</td>
                <td style="font-size:13px">CPECPagoIncentivoSeguros</td>
                <td style="font-size:13px">Calculo Incentivo Seguros-(Mes-Año)</td>
                <td style="font-size:13px">Carolina Fuentes</td>
                <td style="font-size:13px">Correo</td>
                <td style="font-size:13px">Mensual</td>
            </tr>
            <tr>
                <td style="font-size:14px">Pago Incentivo Trabajadores y Pensionados</td>
                <td style="font-size:13px">CPECPagoIncentivos</td>
                <td style="font-size:13px">Calculo Campañas por PEC-(Mes-Año)</td>
                <td style="font-size:13px">Carolina Fuentes</td>
                <td style="font-size:13px">Correo</td>
                <td style="font-size:13px">Mensual</td>
            </tr>
        </table>
    </asp:Panel>
  </asp:Content>