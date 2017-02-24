<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Coachings.aspx.vb" Inherits="WebApp.Coachings" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <div class="TituloPrincipal">
        <table style="width:100%">
            <tr style="height:32px;">

                <td style="width:300px"><asp:Label ID="lblTitulo" runat="server" Text="Listado de Coachings" Font-Size="18px"></asp:Label>&nbsp;&nbsp; </td>
                <td style="width:30px">&nbsp;</td>                
                <td style="width:30px">&nbsp;</td>                                
                
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
    <asp:Panel runat="server" ID="PanConsulta" CssClass="PanelConsulta">
        <table>
          <tr>
            <td>
                <asp:Label ID="Label18" runat="server" Text="Usuario coach"></asp:Label>
              </td>
            <td>&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlParConsUsuarioCreacion" runat="server" CssClass="ddlEstandar" />
                
              </td>
            <td></td>
            <td>
                <asp:Label ID="Label3" runat="server" CssClass="lblEstandar" Text="Sucursal" />
              </td>
              <td>
                  <asp:DropDownList ID="ddlParConsSucursal" runat="server" CssClass="ddlEstandar" />
              </td>
              <td>
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
              <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnConsultar" runat="server" cssClass="ui-button ui-state-default ui-corner-all" Text="Consultar" ToolTip="Realizar consulta según parámetros" Width="103px" />
              </td>
          </tr>
            <tr>
                <td>
                    <asp:Label ID="Label19" runat="server" Text="Fecha desde"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbParConsFecCreacionDesde" runat="server" CssClass="txtEstandar datepickered" Width="70px" Enabled="False"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label20" runat="server" Text="Fecha hasta"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbParConsFecCreacionHasta" runat="server" CssClass="txtEstandar datepickered" Width="70px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" CssClass="lblEstandar" Text="Colaborador" />
                </td>
                <td>
                    <asp:TextBox ID="tbParConsColaborador" runat="server" CssClass="txtEstandar" Width="130px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnLimpiar" runat="server" cssClass="ui-button ui-state-default ui-corner-all" Text="Limpiar" ToolTip="Limpiar parámetros de consulta" Width="103px" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
          </table>
    </asp:Panel>

    <div >
        <table class="TablaEncabezadoDatos">
            <tr>
                <td style="width:110px">                    
                    <asp:LinkButton ID="lbFecCreacion" runat="server" Text="Fecha" CommandArgument="FecCreacion" ToolTip="Ordenar" />
                </td>
                <td style="width:330px">
                    <asp:LinkButton ID="lbUsuarioCreacion" runat="server" Text="Usuario Coach" CommandArgument="UsuarioCreacion" ToolTip="Ordenar" />
                </td>
                <td style="width:210px">                    
                    <asp:LinkButton ID="lbSucursal" runat="server" Text="Sucursal" CommandArgument="Sucursal" ToolTip="Ordenar" />
                </td>
                <td style="width:330px">
                    <asp:LinkButton ID="lbColaborador" runat="server" Text="Colaborador" CommandArgument="Colaborador" ToolTip="Ordenar" />
                </td>
                <td style="background-color:transparent; padding-left:5px; vertical-align:top">
                    <asp:Button ID="btnAgregarCoaching" runat="server" Text="Agregar Coaching" CssClass="BotonMenu" Width="120px" Height="25px" />
                </td>
            </tr>
        </table>        
    </div>


    <div class="TablaDatos"  style="overflow:auto" >        
        <asp:GridView ID="gv1" runat="server" AutoGenerateColumns = "False" 
            DataKeyNames = "IdCoaching, IdUsrCreacion" 
            ShowHeader="False"
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
                <ItemStyle Width="105px" VerticalAlign="Top" />
                <ItemTemplate> 
                    <asp:Label ID="lblFecCreacion" runat="server" Text='<%# Bind("FecCreacion", "{0:dd-MMM-yyyy}")%>' Width="100px" ></asp:Label> 
                </ItemTemplate>   
            </asp:TemplateField> 

            <asp:TemplateField >                 
                <ItemStyle Width="325px" VerticalAlign="Top" />
                <ItemTemplate> 
                    <asp:Label ID="lblUsuarioCreacion" runat="server" Text='<%# Bind("UsuarioCreacion")%>' Width="320px" ></asp:Label> 
                </ItemTemplate>   
            </asp:TemplateField>

            <asp:TemplateField > 
                <ItemStyle Width="205px" VerticalAlign="Top" />
                <ItemTemplate> 
                    <asp:Label ID="lblSucursal" runat="server" Text='<%# Bind("Sucursal")%>' Width="200px" ></asp:Label> 
                </ItemTemplate>   
            </asp:TemplateField> 

            <asp:TemplateField >                 
                <ItemStyle Width="325px" VerticalAlign="Top"/>
                <ItemTemplate> 
                    <asp:Label ID="lblColaborador" runat="server" Text='<%# Bind("Colaborador")%>' Width="320px" ></asp:Label> 
                </ItemTemplate>   
            </asp:TemplateField>
                                                                                                      
            <asp:TemplateField ShowHeader="False" > 
                <ItemStyle VerticalAlign="Top"/>
                <ItemTemplate>
                    <asp:ImageButton ID="ibDetalle" runat="server" CausesValidation="False" CommandName="Detalle" CommandArgument='<%# Bind("IdCoaching")%>' ToolTip="Detalle Registro" ImageUrl="~/Imagenes/detalle.png" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="ibEliminar" runat="server" CommandName="Delete" ToolTip="Eliminar Registro" ImageUrl="~/Imagenes/eliminar.png" OnClientClick="return confirm('¿Esta seguro de eliminar este registro?');" />
                </ItemTemplate> 
            </asp:TemplateField>

        </Columns>

    </asp:GridView>
</div>


    <asp:Button ID="btnVolver" runat="server" CssClass="BotonMenu" Text="<< Volver"/>

</asp:Content>
