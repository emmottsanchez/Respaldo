<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Sucursal.aspx.vb" Inherits="WebApp.Sucursal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">

    <div class="TituloPrincipal">
        <table style="width:100%">
            <tr style="height:32px;">

                <td style="width:600px"><asp:Label ID="lblTitulo" runat="server" Text="Resumen Sucursal" Font-Size="18px"></asp:Label>&nbsp;&nbsp; </td>
                
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

    

    <asp:MultiView ID="multiview1" runat="server" ActiveViewIndex="0">  
        <asp:View ID="viewAcumulado" runat="server">
            <asp:Label ID="Label1" runat="server" CssClass="lblEstandar" Font-Bold="true" Font-Size="16px" Text="Acumulado" />            
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lbAcumuladoUltimoDiaHabil" runat="server" CommandName="SwitchViewByID" CommandArgument="viewUltimoDiaHabil" CssClass="lblEstandar" Text="[ver último día hábil]"></asp:LinkButton>
     
            <table class="TablaEncabezadoDatos" style="width:1020px">
                        <tr>
                            <td style="width:310px"></td>
                            <td colspan="4">Afiliaciones</td>
                            <td style="width:50px">&nbsp;</td>
                            <td colspan="5">Crédito Pensionado</td>
                            <td style="width:50px"></td>
                            <td colspan="2">Crédito Trabajador</td>
                        </tr>
                        <tr>
                            <td style="width:310px">
                                <asp:LinkButton ID="lbUsuarioIngreso" runat="server" CommandArgument="UsuarioIngreso" ToolTip="Ordenar">Usuario Ingreso</asp:LinkButton>
                            </td>
                            <td style="width:50px">
                                <asp:LinkButton ID="lbMetaAfiliaciones" runat="server" CommandArgument="MetaAfiliaciones" ToolTip="Ordenar">Meta mes</asp:LinkButton>
                            </td>
                            <td style="width:50px">
                                <asp:LinkButton ID="lbMetaPropAfiliaciones" runat="server" CommandArgument="MetaPropAfiliaciones" ToolTip="Ordenar">Meta prop</asp:LinkButton>
                            </td>
                            <td style="width:50px">
                                <asp:LinkButton ID="lbAfiliaciones" runat="server" CommandArgument="Afiliaciones" ToolTip="Ordenar">Venta acum</asp:LinkButton>
                            </td>
                            <td style="width:50px">
                                <asp:LinkButton ID="lbCumAfiliaciones" runat="server" CommandArgument="CumAfiliaciones" ToolTip="Ordenar">% cumpl prop</asp:LinkButton>
                            </td>
                            <td style="width:50px"></td>
                            <td style="width:50px">
                                <asp:LinkButton ID="lbCredPenCant" runat="server" CommandArgument="CredPenCant" ToolTip="Ordenar">N° operac</asp:LinkButton>
                            </td>
                            <td style="width:50px">
                                <asp:LinkButton ID="lbMetaCredPenMto" runat="server" CommandArgument="MetaCredPenMto" ToolTip="Ordenar">Meta mes</asp:LinkButton>
                            </td>
                            <td style="width:50px">
                                <asp:LinkButton ID="lbMetaPropCredPenMto" runat="server" CommandArgument="MetaPropCredPenMto" ToolTip="Ordenar">Meta prop</asp:LinkButton>
                            </td>
                            <td style="width:50px">
                                <asp:LinkButton ID="lbCredPenMto" runat="server" CommandArgument="CredPenMto" ToolTip="Ordenar">Venta acum MM$</asp:LinkButton>
                            </td>
                            <td style="width:50px">
                                <asp:LinkButton ID="lbCumCredPenMto" runat="server" CommandArgument="CumCredPenMto" ToolTip="Ordenar">% cumpl prop</asp:LinkButton>
                            </td>
                            <td style="width:50px"></td>
                            <td style="width:50px">
                                <asp:LinkButton ID="lbCredTraCant" runat="server" CommandArgument="CredTraCant" ToolTip="Ordenar">N° operac</asp:LinkButton>
                            </td>
                            <td style="width:50px">
                                <asp:LinkButton ID="lbCredTraMto" runat="server" CommandArgument="CredTraMto" ToolTip="Ordenar">Venta acum MM$</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
            
            <table class="TablaTotales">
                        <tr>
                            <td style="width:310px">
                                <asp:Label ID="Label2" runat="server" Text="Totales" />
                            </td>

                            <td style="width:50px">
                                <asp:Label ID="lblMetaAfiliaciones" runat="server" />
                            </td>
                            <td style="width:50px">
                                <asp:Label ID="lblMetaPropAfiliaciones" runat="server" />
                            </td>
                            <td style="width:50px">
                                <asp:Label ID="lblAfiliaciones" runat="server" />
                            </td>
                            <td style="width:50px">
                                <asp:Label ID="lblCumAfiliaciones" runat="server" />
                            </td>

                            <td style="width:50px"></td>

                            <td style="width:50px">
                                <asp:Label ID="lblCredPenCant" runat="server" />
                            </td>
                            <td style="width:50px">
                                <asp:Label ID="lblMetaCredPenMto" runat="server" />
                            </td>
                            <td style="width:50px">
                                <asp:Label ID="lblMetaPropCredPenMto" runat="server" />
                            </td>
                            <td style="width:50px">
                                <asp:Label ID="lblCredPenMto" runat="server" />
                            </td>
                            <td style="width:50px">
                                <asp:Label ID="lblCumCredPenMto" runat="server" />
                            </td>

                            <td style="width:50px"></td>

                            <td style="width:50px">
                                <asp:Label ID="lblCredTraCant" runat="server" />
                            </td>
                            <td style="width:50px">
                                <asp:Label ID="lblCredTraMto" runat="server" />
                            </td>
                        </tr>
                    </table>            
        
            <div class="TablaDatos" >
                <asp:GridView ID="gv1" runat="server" AutoGenerateColumns = "False" 
                    DataKeyNames = "" 
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
                            <ItemStyle Width="305px" />
                            <ItemTemplate> 
                                <asp:Label runat="server" ID="lblUsuarioRegional" Text='<%# Bind("UsuarioIngreso")%>' CssClass="lblEstandar" />
                            </ItemTemplate>   
                        </asp:TemplateField> 

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblAfiliaciones" runat="server" Text='<%# Bind("Afiliaciones", "{0:N0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCredPenCant" runat="server" Text='<%# Bind("CredPenCant", "{0:N0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>  
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCredPenMto" runat="server" Text='<%# Bind("CredPenMto", "{0:N1}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>  
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCredTraCant" runat="server" Text='<%# Bind("CredTraCant", "{0:N0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>


                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCredTraMto" runat="server" Text='<%# Bind("CredTraMto", "{0:N1}")%>'  ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>


                    </Columns>

                </asp:GridView>
            </div>

         </asp:View>

        <asp:View ID="viewUltimoDiaHabil" runat="server">
            <asp:Label ID="Label9" runat="server" CssClass="lblEstandar" Font-Bold="true" Font-Size="16px" Text="Último día hábil" />
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lbUltimoDiaHabilAcumulado" runat="server" CommandName="SwitchViewByID" CommandArgument="viewAcumulado" CssClass="lblEstandar" Text="[ver acumulado]"></asp:LinkButton>

            <table class="TablaEncabezadoDatos" style="width:1020px">
                        <tr>
                            <td style="width:290px"></td>
                            <td colspan="4">Afiliaciones</td>
                            <td style="width:50px">&nbsp;</td>
                            <td colspan="5">Crédito Pensionado</td>
                            <td style="width:50px"></td>
                            <td colspan="2">Crédito Trabajador</td>
                        </tr>
                        <tr>
                            <td style="width:290px">
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument="UsuarioIngreso" ToolTip="Ordenar">Usuario Ingreso</asp:LinkButton>
                            </td>
                            <td style="width:50px">
                                &nbsp;</td>
                            <td style="width:50px">
                                &nbsp;</td>
                            <td style="width:50px">
                                <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument="Afiliaciones" ToolTip="Ordenar">Venta último dia</asp:LinkButton>
                            </td>
                            <td style="width:50px">
                                &nbsp;</td>
                            <td style="width:50px"></td>
                            <td style="width:50px">
                                <asp:LinkButton ID="LinkButton6" runat="server" CommandArgument="CredPenCant" ToolTip="Ordenar">N° operac</asp:LinkButton>
                            </td>
                            <td style="width:50px">
                                &nbsp;</td>
                            <td style="width:50px">
                                &nbsp;</td>
                            <td style="width:50px">
                                <asp:LinkButton ID="LinkButton9" runat="server" CommandArgument="CredPenMto" ToolTip="Ordenar">Venta último dia MM$</asp:LinkButton>
                            </td>
                            <td style="width:50px">
                                &nbsp;</td>
                            <td style="width:50px"></td>
                            <td style="width:50px">
                                <asp:LinkButton ID="LinkButton11" runat="server" CommandArgument="CredTraCant" ToolTip="Ordenar">N° operac</asp:LinkButton>
                            </td>
                            <td style="width:50px">
                                <asp:LinkButton ID="LinkButton12" runat="server" CommandArgument="CredTraMto" ToolTip="Ordenar">Venta último dia MM$</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
            
            <table class="TablaTotales">
                        <tr>
                            <td style="width:310px">
                                <asp:Label ID="Label10" runat="server" Text="Totales" />
                            </td>

                            <td style="width:50px">
                                &nbsp;</td>
                            <td style="width:50px">
                                &nbsp;</td>
                            <td style="width:50px">
                                <asp:Label ID="lblAfiliacionesUDH" runat="server" />
                            </td>
                            <td style="width:50px">
                                &nbsp;</td>

                            <td style="width:50px"></td>

                            <td style="width:50px">
                                <asp:Label ID="lblCredPenCantUDH" runat="server" />
                            </td>
                            <td style="width:50px">
                                &nbsp;</td>
                            <td style="width:50px">
                                &nbsp;</td>
                            <td style="width:50px">
                                <asp:Label ID="lblCredPenMtoUDH" runat="server" />
                            </td>
                            <td style="width:50px">
                                &nbsp;</td>

                            <td style="width:50px"></td>

                            <td style="width:50px">
                                <asp:Label ID="lblCredTraCantUDH" runat="server" />
                            </td>
                            <td style="width:50px">
                                <asp:Label ID="lblCredTraMtoUDH" runat="server" />
                            </td>
                        </tr>
                    </table>            
        
            <div class="TablaDatos">
                <asp:GridView ID="gv2" runat="server" AutoGenerateColumns = "False" 
                    DataKeyNames = "" 
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
                            <ItemStyle Width="305px" />
                            <ItemTemplate> 
                                <asp:Label runat="server" ID="lblUsuarioRegional" Text='<%# Bind("UsuarioIngreso")%>' CssClass="lblEstandar" />
                            </ItemTemplate>   
                        </asp:TemplateField> 

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblAfiliaciones" runat="server" Text='<%# Bind("AfiliacionesUDH", "{0:N0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCredPenCant" runat="server" Text='<%# Bind("CredPenCantUDH", "{0:N0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>  
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCredPenMto" runat="server" Text='<%# Bind("CredPenMtoUDH", "{0:N1}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>  
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCredTraCant" runat="server" Text='<%# Bind("CredTraCantUDH", "{0:N0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>


                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCredTraMto" runat="server" Text='<%# Bind("CredTraMtoUDH", "{0:N1}")%>'  ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>


                    </Columns>

                </asp:GridView>
            </div>

        </asp:View>

    </asp:MultiView>
    <br />

    <asp:Label ID="Label7" runat="server" CssClass="lblEstandar" Font-Bold="true" Font-Size="16px" Text="Acciones en período seleccionado" />
    <br /><br />

    
    <div>
        <table class="TablaEncabezadoDatos" style="width:1050px">
            <tr>
                <td style="width:115px">
                    <asp:Label ID="Label3" runat="server" Text="Fecha" CssClass="lblEstandar" />
                </td>
                <td style="width:80px">
                    <asp:Label ID="Label4" runat="server" Text="Usuario" CssClass="lblEstandar" />
                </td>
                <td style="width:330px">
                    <asp:Label ID="Label5" runat="server" Text="Oportunidad" CssClass="lblEstandar" />
                </td>
                <td style="width:330px">
                    <asp:Label ID="Label6" runat="server" Text="Accion" CssClass="lblEstandar" />
                </td>
                <td style="width:150px">
                    <asp:Label ID="Label8" runat="server" Text="Responsable" CssClass="lblEstandar" />
                </td>
            </tr>
        </table>
    </div>

    <asp:Panel runat="server" ID="PanAgregar" CssClass="PanelAgregar" >
    <table>
        <tr>
            <td style="width:115px"></td>
            <td style="width:80px"></td>
            <td style="width:330px">
                <asp:Textbox ID="tbOportunidadNvo" runat="server" width="320px" TextMode="MultiLine" Rows="3"></asp:Textbox>
            </td>
            <td style="width:330px">
                <asp:Textbox ID="tbAccionNvo" runat="server" width="320px" TextMode="MultiLine" Rows="3"></asp:Textbox>
            </td>
            <td style="vertical-align:top; width:150px">
                <asp:Textbox ID="tbResponsableNvo" runat="server" width="140px"></asp:Textbox>
            </td>
            <td style="background-color:transparent; padding-left:5px; vertical-align:top">
                <asp:ImageButton ID="ibAgregar" runat="server" ImageUrl="~/Imagenes/agregar.png" ToolTip="Agregar nuevo registro de coaching" />
            </td>
        </tr>
    </table>
    </asp:Panel>

    <div class="TablaDatos" >        
        <asp:GridView ID="gvAccionesSucursal" runat="server" AutoGenerateColumns = "False" 
            DataKeyNames = "IdAccionSucursal, IdUsrCreacion" 
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
                <ItemStyle Width="110px" VerticalAlign="Top" />
                <ItemTemplate> 
                    <asp:Label ID="lblFecCreacion" runat="server" Text='<%# Bind("FecCreacion", "{0:dd-MMM-yyyy hh:mm}")%>' Width="105px" ></asp:Label> 
                </ItemTemplate>   
            </asp:TemplateField> 

            <asp:TemplateField >                 
                <ItemStyle Width="75px" VerticalAlign="Top" />
                <ItemTemplate> 
                    <asp:Label ID="lblUsuarioLH" runat="server" Text='<%# Bind("UsuarioLH")%>' Width="70px" ></asp:Label> 
                </ItemTemplate>   
            </asp:TemplateField>

            <asp:TemplateField >                 
                <ItemStyle Width="325px" VerticalAlign="Top"/>
                <ItemTemplate> 
                    <asp:Label ID="lblOportunidad" runat="server" Text='<%# Bind("Oportunidad")%>' Width="320px" ></asp:Label> 
                </ItemTemplate>   
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemStyle Width="325px" VerticalAlign="Top" />
                <ItemTemplate> 
                    <asp:Label ID="lblAccion" runat="server" Text='<%# Bind("Accion")%>' Width="320px" ></asp:Label> 
                </ItemTemplate>   
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemStyle Width="145px" VerticalAlign="Top" />
                <ItemTemplate> 
                    <asp:Label ID="lblResponsable" runat="server" Text='<%# Bind("Responsable")%>' Width="140px" ></asp:Label> 
                </ItemTemplate>   
            </asp:TemplateField>
                                                                                                      
            <asp:TemplateField ShowHeader="False" > 
                <ItemStyle VerticalAlign="Top"/>
                <ItemTemplate>
                    <asp:ImageButton ID="ibEliminar" runat="server" CommandName="Delete" ToolTip="Eliminar Registro" ImageUrl="~/Imagenes/eliminar.png" OnClientClick="return confirm('¿Esta seguro de eliminar este registro?');" />
                </ItemTemplate> 
            </asp:TemplateField>

        </Columns>

    </asp:GridView>
    </div>
    



    <br />
    <asp:Button ID="btnVolver" runat="server" CssClass="BotonMenu" Text="<< Volver"/>

</asp:Content>
