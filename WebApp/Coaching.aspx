<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Coaching.aspx.vb" Inherits="WebApp.Coaching" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">


    <div class="TituloPrincipal">
        <table style="width:100%">
            <tr style="height:32px;">

                <td style="width:300px"><asp:Label ID="lblTitulo" runat="server" Text="Reporte de Coaching" Font-Size="18px"></asp:Label>&nbsp;&nbsp; </td>
                
                <td >
                    <div id="Mensaje1" style="display:none">
                        <asp:Panel ID="PanMsg1" runat="server" style="padding: 0 .7em;">                                    
                            <table><tr>
                                <td><asp:Panel ID="PanMsg11" runat="server" ><span style="float: left; margin-right: .3em;"></span></asp:Panel></td>
                                <td ><asp:Label ID="lblInfoUsr" runat="server" CssClass="ui-widget" Font-Size="12px"></asp:Label></td>
                            </tr></table>                                		                    		                                                                        
                        </asp:Panel>
                    </div>
                    </td>
                </tr>
            </table>                
    </div>

    <table>
        <tr>
            <td><asp:Label ID="Label2" runat="server" CssClass="lblEstandar" Text="Coach (Agente de Sucursal)" /></td>
            <td><asp:Label ID="lblUsuarioCreacion" runat="server" CssClass="lblEstandar" /></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label12" runat="server" CssClass="lblEstandar" Text="Sucursal" /></td>
            <td>
                <asp:DropDownList ID="ddlSucursal" runat="server" CssClass="ddlEstandar" />                
                <asp:Label ID="Label13" runat="server" CssClass="lblEstandar" Text="&nbsp;&nbsp;*" ForeColor="Red" Font-Bold="true" />
            </td>
        </tr>        
        <tr>
            <td><asp:Label ID="Label3" runat="server" CssClass="lblEstandar" Text="Colaborador (Ejecutivo PEC / Promotor)" /></td>
            <td><asp:Textbox runat="server" ID="tbColaborador" CssClass="txtEstandar" />
                 <asp:Label ID="Label10" runat="server" CssClass="lblEstandar" Text="&nbsp;&nbsp;*" ForeColor="Red" Font-Bold="true" /> 
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label4" runat="server" CssClass="lblEstandar" Text="Fecha de la sesión" /></td>
            <td><asp:Label ID="lblFecCreacion" runat="server" CssClass="lblEstandar" /></td>
        </tr>
    </table>
    <br />

    <asp:Label ID="Label1" runat="server" CssClass="lblEstandar" Text="Conducta prioritaria anterior" Font-Size="14px" /><br />
    <asp:Textbox runat="server" ID="tbConductaPrioritariaAnterior" CssClass="txtEstandar" Width="800px" TextMode="MultiLine" Rows="4" />
    <br /><br />

    <asp:Label ID="Label5" runat="server" CssClass="lblEstandar" Text="Fortalezas" Font-Size="14px" /><br />
    <asp:Textbox runat="server" ID="tbFortalezas" CssClass="txtEstandar" Width="800px" TextMode="MultiLine" Rows="10" />
    <br /><br />

    <asp:Label ID="Label6" runat="server" CssClass="lblEstandar" Text="Oportunidades de mejora" Font-Size="14px" /><br />
    <asp:Textbox runat="server" ID="tbOportunidadesMejora" CssClass="txtEstandar" Width="800px" TextMode="MultiLine" Rows="10" />
    <br /><br />

    <asp:Label ID="Label7" runat="server" CssClass="lblEstandar" Text="Conducta prioritaria" Font-Size="14px" /><br />
    <asp:Textbox runat="server" ID="tbConductaPrioritaria" CssClass="txtEstandar" Width="800px" TextMode="MultiLine" Rows="4" />
    <br /><br />

    <asp:Label ID="Label8" runat="server" CssClass="lblEstandar" Text="Plan táctico" Font-Size="14px" />
    <asp:Label ID="Label14" runat="server" CssClass="lblEstandar" Text="&nbsp;&nbsp;*" ForeColor="Red" Font-Bold="true" />
    <br />
    <asp:Textbox runat="server" ID="tbPlanTactico" CssClass="txtEstandar" Width="800px" TextMode="MultiLine" Rows="4" />
    <br /><br />

    <br />

    <table>
        <tr>
            <td><asp:Label ID="Label9" runat="server" CssClass="lblEstandar" Text="Fecha de la próxima sesión" /></td>
            <td><asp:Textbox runat="server" ID="tbFecProximaSesion" Width="70px" CssClass="txtEstandar datepickered" /></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label11" runat="server" CssClass="lblEstandar" Text="Fecha de revisión Plan Táctico" /></td>
            <td><asp:Textbox runat="server" ID="tbFecRevisionPlanTactico" Width="70px" CssClass="txtEstandar datepickered" /></td>
        </tr>
    </table>
    <br /><br /><br />

    <asp:Button runat="server" ID="btnAceptar" CssClass="BotonMenu" Width="100px" Height="30px" />
    &nbsp;&nbsp;
    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="BotonMenu" Width="100px" Height="30px" />

</asp:Content>
