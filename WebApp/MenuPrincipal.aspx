<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="MenuPrincipal.aspx.vb" Inherits="WebApp.MenuPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
        .auto-style2 {
            width: 458px;
        }
        .auto-style3 {
            height: 22px;
            width: 488px;
        }
        .auto-style4 {
            width: 166px;
        }
        .auto-style5 {
            height: 22px;
            width: 166px;
        }
        .auto-style6 {
            width: 488px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">

    <%--Título y Contenedor de mensajes--%>
    <div class="TituloPrincipal">
        <table style="width:100%">
            <tr style="height:32px;">                

                <td style="width:480px">
                    <asp:Label ID="lblTitulo" runat="server" Text="Resumen" Font-Size="36px" ></asp:Label></td>
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

    <div style="padding:20px" >
        <table>
            <tr><td class="auto-style4">
                <asp:Label ID="Label2" runat="server" Text="Usuario"></asp:Label>
                </td><td class="auto-style6"><asp:Label ID="lblUsuario" runat="server" Font-Size="20px"></asp:Label></td>
                <td>&nbsp;</td>
                <td><asp:Button ID="btnCambiarContraseña" runat="server" Text="Cambiar contraseña" CssClass="btnEstandar" Width="150" Height="25" /></td>
            </tr>
            <tr><td class="auto-style4">
                <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                </td><td class="auto-style6"><asp:Label ID="lblEmail" runat="server" Font-Size="20px"></asp:Label></td><td>&nbsp;</td><td>&nbsp;</td></tr>
            <tr><td class="auto-style4">
                <asp:Label ID="Label4" runat="server" Text="Rol"></asp:Label>
                </td><td class="auto-style6"><asp:Label ID="lblRol" runat="server" Font-Size="20px"></asp:Label></td><td>&nbsp;</td><td>&nbsp;</td></tr>
            <tr><td class="auto-style4">&nbsp;</td><td class="auto-style6">
                &nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
            <tr><td class="auto-style4">
                <asp:Label ID="Label5" runat="server" Text="Afiliaciones"></asp:Label>
                </td>
                <td class="auto-style6"><asp:Label ID="lblAfiliaciones" runat="server" Font-Size="20px"></asp:Label></td><td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr><td class="auto-style4">
                <asp:Label ID="Label6" runat="server" Text="Créditos Pensionado"></asp:Label>
                </td><td class="auto-style6"><asp:Label ID="lblCredPenCant" runat="server" Font-Size="20px"></asp:Label>
            <asp:Label ID="Label8" runat="server" Text=" por $MM"></asp:Label>
                    <asp:Label ID="lblCredPenMto" runat="server" Font-Size="20px"></asp:Label></td><td>&nbsp;</td><td>&nbsp;</td></tr>
            <tr><td class="auto-style4">
                <asp:Label ID="Label7" runat="server" Text="Créditos Trabajador"></asp:Label>
                </td><td class="auto-style6"><asp:Label ID="lblCredTraCant" runat="server" Font-Size="20px"></asp:Label>
            <asp:Label ID="Label9" runat="server" Text=" por $MM"></asp:Label>
                    <asp:Label ID="lblCredTraMto" runat="server" Font-Size="20px"></asp:Label></td><td>&nbsp;</td><td>&nbsp;</td></tr>
            <tr><td class="auto-style5">
                <asp:Label ID="Label10" runat="server" Text="Cruce Welcome"></asp:Label>
                </td>
                <td class="auto-style3">                    
                    <asp:Label ID="lblCliWelCred" runat="server" Font-Size="20px" />
                    <asp:Label ID="Label11" runat="server" Text=" créditos sobre potencial de " />
                    <asp:Label ID="lblCliWel" runat="server" Font-Size="20px" />
                    <asp:Label ID="Label12" runat="server" Text=" (" />
                    <asp:Label ID="lblCumCliWelCred" runat="server" Font-Size="20px" />
                    <asp:Label ID="Label1" runat="server" Text=")" />
                </td>
                <td class="auto-style1"></td><td class="auto-style1"></td></tr>
            <tr><td class="auto-style5">
                <asp:Label ID="Label13" runat="server" Text="Cupones"></asp:Label>
                </td>
                <td class="auto-style3">                    
                    <asp:Label ID="lblCuponesRutEntregados" runat="server" Font-Size="20px" />
                    <asp:Label ID="Label14" runat="server" Text=" cupones entregados sobre meta de " />
                    <asp:Label ID="lblCuponesMeta" runat="server" Font-Size="20px" />
                    &nbsp;<asp:Label ID="Label15" runat="server" Text="(" />
                    <asp:Label ID="lblCumCupones" runat="server" Font-Size="20px" />
                    <asp:Label ID="Label16" runat="server" Text=")" />
                </td>
                <td class="auto-style1">&nbsp;</td><td class="auto-style1">&nbsp;</td></tr>
            <tr>
                <td class="auto-style5"><asp:Label ID="Label17" runat="server" Text="Seguro Trabajador"></asp:Label></td>
                  <td class="auto-style3">                    
                    <asp:Label ID="lblSegurosTrab" runat="server" Font-Size="20px" />
                    <asp:Label ID="Label19" runat="server" Text=" Seguros Trabajador sobre meta de " />
                    <asp:Label ID="lblMetaTrab" runat="server" Font-Size="20px" />
                    &nbsp;<asp:Label ID="Label21" runat="server" Text="(" />
                    <asp:Label ID="lblCumTrab" runat="server" Font-Size="20px" />
                    <asp:Label ID="Label23" runat="server" Text=")" />
                </td><td>&nbsp;</td><td>&nbsp;</td></tr>
            <tr>
                <td class="auto-style5"><asp:Label ID="Label18" runat="server" Text="Seguro Pensionado"></asp:Label></td>
                  <td class="auto-style3">                    
                    <asp:Label ID="lblSegurosPens" runat="server" Font-Size="20px" />
                    <asp:Label ID="Label22" runat="server" Text=" Seguros Pensionado sobre meta de " />
                    <asp:Label ID="lblMetaPens" runat="server" Font-Size="20px" />
                    &nbsp;<asp:Label ID="Label25" runat="server" Text="(" />
                    <asp:Label ID="lblCumPens" runat="server" Font-Size="20px" />
                    <asp:Label ID="Label27" runat="server" Text=")" />
                </td><td>&nbsp;</td><td>&nbsp;</td><td class="auto-style2">&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
            <tr>
                <td class="auto-style5"><asp:Label ID="Label28" runat="server" Text="Seguro Cesantía"></asp:Label></td>
                  <td class="auto-style3">                    
                    <asp:Label ID="lblSegurosCes" runat="server" Font-Size="20px" />
                    <asp:Label ID="Label30" runat="server" Text=" Seguros Cesantía sobre meta de " />
                    <asp:Label ID="lblMetaCes" runat="server" Font-Size="20px" />
                    &nbsp;<asp:Label ID="Label32" runat="server" Text="(" />
                    <asp:Label ID="lblCumCes" runat="server" Font-Size="20px" />
                    <asp:Label ID="Label34" runat="server" Text=")" />
                </td><td>&nbsp;</td><td>&nbsp;</td><td class="auto-style2">&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
            <tr><td class="auto-style4">
                &nbsp;</td><td class="auto-style6">&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
            </table>

            <asp:Label runat="server" ID="lblAccesosCompartidos" cssclass="lblEstandar" Text="Accesos compartidos" Visible="false" />
            <asp:GridView runat="server" ID="gvAccesosCompartidos" AutoGenerateColumns = "False" 
                DataKeyNames = "" 
                ShowHeader="false"
                ShowFooter="False" 

                RowStyle-ForeColor="#2a4f5e"  
                RowStyle-BackColor= "#f5f5f5"            
                RowStyle-Height = "30px"
            
                AlternatingRowStyle-BackColor="#e8e8e8"            


                GridLines="None" CellPadding="3" CellSpacing ="3"            
                AllowPaging="False"                                
                >

                <Columns>
                    <asp:TemplateField >                 
                        <ItemStyle Width="305px" Font-Size="Small" />
                        <ItemTemplate> 
                            <asp:LinkButton runat="server" 
                                            ID="lbUsuarioRegional" 
                                            Text='<%# Bind("UsuarioEmisor")%>' 
                                            CommandName = "ReiniciarSesion"
                                            CommandArgument='<%# Bind("EmailUsuarioEmisor")%>'                                            
                                            ToolTip="Reiniciar sesión"
                                            OnClientClick="return confirm('¿Esta seguro de reiniciar la sesión usando las credenciales de este usuario?');"
                             />                             
                        </ItemTemplate>   
                    </asp:TemplateField> 

                    <asp:TemplateField>
                        <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="Small"/>
                        <ItemTemplate> 
                            <asp:Label ID="lblFecDesde" runat="server" Text='<%# Bind("FecDesde", "{0:dd-MM-yyyy}")%>' ></asp:Label> 
                        </ItemTemplate>   
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemStyle HorizontalAlign="Center" Font-Size="Small"/>
                        <ItemTemplate> 
                            <asp:Label ID="lblAl" runat="server" Text='al' ></asp:Label> 
                        </ItemTemplate>   
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemStyle Width="80px" HorizontalAlign="Center" Font-Size="Small"/>
                        <ItemTemplate> 
                            <asp:Label ID="lblFecHasta" runat="server" Text='<%# Bind("FecHasta", "{0:dd-MM-yyyy}")%>' ></asp:Label> 
                        </ItemTemplate>   
                    </asp:TemplateField>
                </Columns>



            </asp:GridView>
    </div>

</asp:Content>
