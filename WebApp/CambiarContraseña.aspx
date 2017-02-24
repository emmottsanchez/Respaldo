<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CambiarContraseña.aspx.vb" Inherits="WebApp.CambiarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <div class="TituloPrincipal">
        <table style="width:100%">
            <tr style="height:32px;">
                <td style="width:270px"><asp:Label ID="Label1" runat="server" Text="Cambiar contraseña usuario" Font-Size="18px"></asp:Label>&nbsp;&nbsp; </td>
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
    <br />

    <div style="height:400px; overflow:auto" >                
        <table class="lblEstandar">
            <tr>
                <td>Usuario</td>
                <td><asp:Label runat="server" ID="lbUsuario" /></td>
            </tr>
            <tr>
                <td>Contraseña anterior</td>
                <td><asp:TextBox runat="server" ID="tbContraseñaAnterior" CssClass="txtEstandar" TextMode="Password" /></td>
            </tr>
            <tr>
                <td>Contraseña Nueva</td>
                <td><asp:TextBox runat="server" ID="tbContraseñaNueva1" CssClass="txtEstandar" TextMode="Password" /></td>
            </tr>
            <tr>
                <td>Repetir Contraseña Nueva</td>
                <td><asp:TextBox runat="server" ID="tbContraseñaNueva2" CssClass="txtEstandar" TextMode="Password" /></td>
            </tr>
        </table>

        <br />

        &nbsp;&nbsp;
        <asp:Button ID="btnAceptar" runat="server" CssClass="btnEstandar" Text="Aceptar" Width="100" Height="25" />
        &nbsp;&nbsp;
        <asp:Button ID="btnCancelar" runat="server" CssClass="btnEstandar" Text="Cancelar" Width="100" Height="25"/>

    </div>
</asp:Content>
