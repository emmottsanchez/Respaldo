<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Agente.aspx.vb" Inherits="WebApp.Agente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <div class="TituloPrincipal">
        <table style="width:100%">
            <tr style="height:32px;">

                <td style="width:600px"><asp:Label ID="lblTitulo" runat="server" Text="Resumen Agente" Font-Size="18px"></asp:Label>&nbsp;&nbsp; </td>
                
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
            <asp:Label ID="Label2" runat="server" CssClass="lblEstandar" Font-Bold="true" Font-Size="16px" Text="Acumulado" />            
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lbAcumuladoUltimoDiaHabil" runat="server" CommandName="SwitchViewByID" CommandArgument="viewUltimoDiaHabil" CssClass="lblEstandar" Text="[ver último día hábil]"></asp:LinkButton>       
        <div style="width:1330px; overflow:auto;margin-left:-40px">
            <table class="TablaEncabezadoDatos">
                <tr>
                    <td style="width:140px"></td>
                    <td colspan="4">Afiliaciones</td>
                    <td style="width:5px">&nbsp;</td>
                    <td colspan="5">Crédito Pensionado</td>
                    <td style="width:5px"></td>
                    <td colspan="5">Crédito Trabajador</td>
                    <td style="width:5px"></td>
                    <td colspan="3">Cruce Welcome</td>
                    <td style="width:5px"></td>
                    <td colspan="3">Entrega Cupones</td>
                    <td style="width:5px"></td>
                    <td colspan="4">Seguro Trabajador</td>
                    <td style="width:5px"></td>
                    <td colspan="4">Seguros Pensionado</td>
                    <td style="width:5px"></td>
                    <td colspan="4">Seguro Cesantia</td>
                </tr>
                <tr>
                    <td style="width:140px">
                        <asp:LinkButton ID="lbSucursal" runat="server" CommandArgument="UsuarioRegional" ToolTip="Ordenar">Sucursal</asp:LinkButton>
                    </td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbMetaAfiliaciones" runat="server" CommandArgument="MetaAfiliaciones" ToolTip="Ordenar">Meta mes</asp:LinkButton>
                    </td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbMetaPropAfiliaciones" runat="server" CommandArgument="MetaPropAfiliaciones" ToolTip="Ordenar">Meta prop</asp:LinkButton>
                    </td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbAfiliaciones" runat="server" CommandArgument="Afiliaciones" ToolTip="Ordenar">Venta acum</asp:LinkButton>
                    </td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbCumAfiliaciones" runat="server" CommandArgument="CumAfiliaciones" ToolTip="Ordenar">% cumpl prop</asp:LinkButton>
                    </td>
                    <td style="width:5px"></td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbCredPenCant" runat="server" CommandArgument="CredPenCant" ToolTip="Ordenar">N° operac</asp:LinkButton>
                    </td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbMetaCredPenMto" runat="server" CommandArgument="MetaCredPenMto" ToolTip="Ordenar">Meta mes</asp:LinkButton>
                    </td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbMetaPropCredPenMto" runat="server" CommandArgument="MetaPropCredPenMto" ToolTip="Ordenar">Meta prop</asp:LinkButton>
                    </td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbCredPenMto" runat="server" CommandArgument="CredPenMto" ToolTip="Ordenar">Venta acum MM$</asp:LinkButton>
                    </td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbCumCredPenMto" runat="server" CommandArgument="CumCredPenMto" ToolTip="Ordenar">% cumpl prop</asp:LinkButton>
                    </td>
                    <td style="width:5px"></td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbCredTraCant" runat="server" CommandArgument="CredTraCant" ToolTip="Ordenar">N° operac</asp:LinkButton>
                    </td>

                    <td style="width:40px">
                        <asp:LinkButton ID="lbMetaCredTraMto" runat="server" CommandArgument="MetaCredTraMto" ToolTip="Ordenar">Meta mes</asp:LinkButton>
                    </td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbMetaPropCredTraMto" runat="server" CommandArgument="MetaPropCredTraMto" ToolTip="Ordenar">Meta prop</asp:LinkButton>
                    </td>

                    <td style="width:40px">
                        <asp:LinkButton ID="lbCredTraMto" runat="server" CommandArgument="CredTraMto" ToolTip="Ordenar">Venta acum MM$</asp:LinkButton>
                    </td>

                    <td style="width:40px">
                        <asp:LinkButton ID="lbCumCredTraMto" runat="server" CommandArgument="CumCredTraMto" ToolTip="Ordenar">% cumpl prop</asp:LinkButton>
                    </td>

                    <td style="width:5px">&nbsp;</td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbCliWel" runat="server" CommandArgument="CliWel" ToolTip="Ordenar">Potencial Mes</asp:LinkButton>
                    </td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbCliWelCred" runat="server" CommandArgument="CliWelCred" ToolTip="Ordenar">N° operac credito</asp:LinkButton>
                    </td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbCumCliWelCred" runat="server" CommandArgument="CumCliWelCred" ToolTip="Ordenar">% Cruce</asp:LinkButton>
                    </td>

                    <td style="width:5px">&nbsp;</td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbCuponesMeta" runat="server" CommandArgument="CuponesMeta" ToolTip="Ordenar">Meta</asp:LinkButton>
                    </td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbCuponesRutEntregados" runat="server" CommandArgument="CuponesRutEntregados" ToolTip="Ordenar">Rut Entreg</asp:LinkButton>
                    </td>
                    <td style="width:40px">
                        <asp:LinkButton ID="lbCumCupones" runat="server" CommandArgument="CumCupones" ToolTip="Ordenar">% cumpl</asp:LinkButton>
                    </td>
                    <td style="width:5px">&nbsp;</td>
                    <td style="width:40px">
                <asp:LinkButton ID="lbMetaTrab" runat="server" CommandArgument="Trab" ToolTip="Ordenar">Meta Mes</asp:LinkButton>
            </td>
            <td style="width:40px">
                <asp:LinkButton ID="lbMetaPropTrab" runat="server" CommandArgument="Trab2" ToolTip="Ordenar">Meta Prop.</asp:LinkButton>
            </td>
            <td style="width:40px">
                <asp:LinkButton ID="lbSegTrab" runat="server" CommandArgument="Trab3" ToolTip="Ordenar">Cant.</asp:LinkButton>
            </td>
            <td style="width:40px">
                <asp:LinkButton ID="lbCumpTrab" runat="server" CommandArgument="Trab4" ToolTip="Ordenar">% Cumpl. Prop.</asp:LinkButton>
            </td>
            <td style="width:5px">&nbsp;</td>
            <td style="width:40px">
                <asp:LinkButton ID="lbMetaPens" runat="server" CommandArgument="Pens" ToolTip="Ordenar">Meta Mes</asp:LinkButton>
            </td>
            <td style="width:40px">
                <asp:LinkButton ID="lbMetaPropPens" runat="server" CommandArgument="Pens2" ToolTip="Ordenar">Meta Prop.</asp:LinkButton>
            </td>
            <td style="width:40px">
                <asp:LinkButton ID="lbSegPens" runat="server" CommandArgument="Pens3" ToolTip="Ordenar">Cant.</asp:LinkButton>
            </td>
            <td style="width:40px">
                <asp:LinkButton ID="lbCumpPens" runat="server" CommandArgument="Pens4" ToolTip="Ordenar">% Cumpl. Prop.</asp:LinkButton>
            </td>
            <td style="width:5px">&nbsp;</td>
            <td style="width:40px">
                <asp:LinkButton ID="lbMetaCes" runat="server" CommandArgument="Ces" ToolTip="Ordenar">Meta Mes</asp:LinkButton>
            </td>
            <td style="width:40px">
                <asp:LinkButton ID="lbMetaPropCes" runat="server" CommandArgument="Ces2" ToolTip="Ordenar">Meta Prop.</asp:LinkButton>
            </td>
            <td style="width:40px">
                <asp:LinkButton ID="lbSegCes" runat="server" CommandArgument="Ces3" ToolTip="Ordenar">Cant.</asp:LinkButton>
            </td>
            <td style="width:40px">
                <asp:LinkButton ID="lbCumpCes" runat="server" CommandArgument="Ces4" ToolTip="Ordenar">% Cumpl. Prop.</asp:LinkButton>
            </td>
                </tr>
                <tr class="d0"">
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Totales" />
                    </td>

                    <td>
                        <asp:Label ID="lblMetaAfiliaciones" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblMetaPropAfiliaciones" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblAfiliaciones" runat="server" />
                    </td>

                    <td>
                        <asp:Label ID="lblCumAfiliaciones" runat="server" />
                    </td>

                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblCredPenCant" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblMetaCredPenMto" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblMetaPropCredPenMto" runat="server" />
                    </td>

                    <td>
                        <asp:Label ID="lblCredPenMto" runat="server" />
                    </td>

                    <td>
                        <asp:Label ID="lblCumCredPenMto" runat="server" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblCredTraCant" runat="server" />
                    </td>

                    <td>
                        <asp:Label ID="lblMetaCredTraMto" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblMetaPropCredTraMto" runat="server" />
                    </td>

                    <td>
                        <asp:Label ID="lblCredTraMto" runat="server" />
                    </td>

                    <td>
                        <asp:Label ID="lblCumCredTraMto" runat="server" />
                    </td>

                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblCliWel" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblCliWelCred" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblCumCliWelCred" runat="server" />
                    </td>

                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblCuponesMeta" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblCuponesRutEntregados" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblCumCupones" runat="server" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblMetaSegTrab" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblMetaSegPondTrab" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblSegurosTrab" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblCumpTrab" runat="server" />
                    </td>
                    <td></td>
                    <td>
                        <asp:Label ID="lblMetaSegPens" runat="server" />
                    </td>
                     <td>
                        <asp:Label ID="lblMetaSegPondPens" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblSegurosPens" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblCumpPens" runat="server" />
                    </td>
                    <td></td>
                    <td>
                        <asp:Label ID="lblMetaSegCes" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblMetaSegPondCes" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblSegurosCes" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblCumpCes" runat="server" />
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
                            <ItemStyle Width="125px" />
                            <ItemTemplate> 
                                <asp:LinkButton runat="server" 
                                                ID="lbSucursal" 
                                                Text='<%# Bind("Sucursal")%>' 
                                                CommandName = "VerSucursal"
                                                CommandArgument='<%# Bind("CodSucursal")%>'
                                                ToolTip="Ver Regional" />
                            </ItemTemplate>   
                        </asp:TemplateField> 

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblMetaAfiliaciones" runat="server" Text='<%# Bind("MetaAfiliaciones", "{0:N0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblMetaPropAfiliaciones" runat="server" Text='<%# Bind("MetaPropAfiliaciones", "{0:N0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblAfiliaciones" runat="server" Text='<%# Bind("Afiliaciones", "{0:N0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCumAfiliaciones" runat="server" Text='<%# Bind("CumAfiliaciones", "{0:P0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>


                        <asp:TemplateField >                 
                            <ItemStyle Width="5px" HorizontalAlign="Center"/>  
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCredPenCant" runat="server" Text='<%# Bind("CredPenCant", "{0:N0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblMetaCredPenMto" runat="server" Text='<%# Bind("MetaCredPenMto", "{0:N1}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblMetaPropCredPenMto" runat="server" Text='<%# Bind("MetaPropCredPenMto", "{0:N1}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCredPenMto" runat="server" Text='<%# Bind("CredPenMto", "{0:N1}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>


                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCumCredPenMto" runat="server" Text='<%# Bind("CumCredPenMto", "{0:P0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="5px" HorizontalAlign="Center"/>  
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCredTraCant" runat="server" Text='<%# Bind("CredTraCant", "{0:N0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemStyle Width="40px" HorizontalAlign="Center"/>  
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>  
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCredTraMto" runat="server" Text='<%# Bind("CredTraMto", "{0:N1}")%>'  ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemStyle Width="50px" HorizontalAlign="Center"/>  
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemStyle Width="5px" HorizontalAlign="Center"/>  
                        </asp:TemplateField>

                        <asp:TemplateField>                 
                            <ItemStyle Width="65px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCliWel" runat="server" Text='<%# Bind("CliWel", "{0:N0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemStyle Width="50px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCliWelCred" runat="server" Text='<%# Bind("CliWelCred", "{0:N0}")%>'  ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCumCliWelCred" runat="server" Text='<%# Bind("CumCliWelCred", "{0:P0}")%>'  ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>


                        <asp:TemplateField >                 
                            <ItemStyle Width="5px" HorizontalAlign="Center"/>  
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCuponesMeta" runat="server" Text='<%# Bind("CuponesMeta", "{0:N0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCuponesRutEntregados" runat="server" Text='<%# Bind("CuponesRutEntregados", "{0:N0}")%>'  ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="45px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCumCupones" runat="server" Text='<%# Bind("CumCupones", "{0:P0}")%>'  ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>
                    

                     <asp:TemplateField >                 
                    <ItemStyle Width="5px" HorizontalAlign="Center"/>  
                </asp:TemplateField>

                <asp:TemplateField >                 
                    <ItemStyle Width="45px" HorizontalAlign="Center"/>
                    <ItemTemplate> 
                        <asp:Label ID="lblMetaTotalSegTrab" runat="server" Text='<%# Bind("MetaTrab", "{0:N0}")%>' ></asp:Label> 
                    </ItemTemplate>   
                </asp:TemplateField>

                <asp:TemplateField >                 
                    <ItemStyle Width="45px" HorizontalAlign="Center"/>
                    <ItemTemplate> 
                        <asp:Label ID="lblMetaPondSegTrab" runat="server" Text='<%# Bind("MetaPropTrab", "{0:N2}")%>' ></asp:Label> 
                    </ItemTemplate>   
                </asp:TemplateField>

                <asp:TemplateField >                 
                    <ItemStyle Width="45px" HorizontalAlign="Center"/>
                    <ItemTemplate> 
                        <asp:Label ID="lblSegTrab" runat="server" Text='<%# Bind("SegurosTrab", "{0:N0}")%>' ></asp:Label> 
                    </ItemTemplate>   
                </asp:TemplateField>

                <asp:TemplateField >                 
                    <ItemStyle Width="45px" HorizontalAlign="Center"/>
                    <ItemTemplate> 
                        <asp:Label ID="lblCumpT" runat="server" Text='<%# Bind("CumpTrab", "{0:P0}")%>' ></asp:Label> 
                    </ItemTemplate>   
                </asp:TemplateField>

                <asp:TemplateField >                 
                            <ItemStyle Width="5px" HorizontalAlign="Center"/>  
                </asp:TemplateField>

                <asp:TemplateField >                 
                    <ItemStyle Width="40px" HorizontalAlign="Center"/>
                    <ItemTemplate> 
                        <asp:Label ID="lblMetaTotalSegPen" runat="server" Text='<%# Bind("MetaPens", "{0:N0}")%>' ></asp:Label> 
                    </ItemTemplate>   
                </asp:TemplateField>

                <asp:TemplateField >                 
                    <ItemStyle Width="40px" HorizontalAlign="Center"/>
                    <ItemTemplate> 
                        <asp:Label ID="lblMetaPondSegP" runat="server" Text='<%# Bind("MetaPropPens", "{0:N2}")%>' ></asp:Label> 
                    </ItemTemplate>   
                </asp:TemplateField>

                <asp:TemplateField >                 
                    <ItemStyle Width="40px" HorizontalAlign="Center"/>
                    <ItemTemplate> 
                        <asp:Label ID="lblSegPens" runat="server" Text='<%# Bind("SegurosPens", "{0:N0}")%>' ></asp:Label> 
                    </ItemTemplate>   
                </asp:TemplateField>

                <asp:TemplateField >                 
                    <ItemStyle Width="45px" HorizontalAlign="Center"/>
                    <ItemTemplate> 
                        <asp:Label ID="lblSegPensCump" runat="server" Text='<%# Bind("CumpPens", "{0:P0}")%>' ></asp:Label> 
                    </ItemTemplate>   
                </asp:TemplateField>

                <asp:TemplateField >                 
                            <ItemStyle Width="5px" HorizontalAlign="Center"/>  
                </asp:TemplateField>

                <asp:TemplateField >                 
                    <ItemStyle Width="40px" HorizontalAlign="Center"/>
                    <ItemTemplate> 
                        <asp:Label ID="lblMetaTotalSegCesa" runat="server" Text='<%# Bind("MetaCes", "{0:N0}")%>' ></asp:Label> 
                    </ItemTemplate>   
                </asp:TemplateField>

                <asp:TemplateField >                 
                    <ItemStyle Width="40px" HorizontalAlign="Center"/>
                    <ItemTemplate> 
                        <asp:Label ID="lblMetaPondSegC" runat="server" Text='<%# Bind("MetaPropCes", "{0:N2}")%>' ></asp:Label> 
                    </ItemTemplate>   
                </asp:TemplateField>

                <asp:TemplateField >                 
                    <ItemStyle Width="45px" HorizontalAlign="Center"/>
                    <ItemTemplate> 
                        <asp:Label ID="lblSegCes" runat="server" Text='<%# Bind("SegurosCes", "{0:N0}")%>' ></asp:Label> 
                    </ItemTemplate>   
                </asp:TemplateField>

                <asp:TemplateField >                 
                    <ItemStyle Width="45px" HorizontalAlign="Center"/>
                    <ItemTemplate> 
                        <asp:Label ID="lblSegCumpCes" runat="server" Text='<%# Bind("CumpCes", "{0:P0}")%>' ></asp:Label> 
                    </ItemTemplate>   
                </asp:TemplateField>

                        </Columns>
                </asp:GridView>
            </div></div>
        </asp:View>
        <asp:View ID="viewUltimoDiaHabil" runat="server">
            <asp:Label ID="Label9" runat="server" CssClass="lblEstandar" Font-Bold="true" Font-Size="16px" Text="Último día hábil" />
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lbUltimoDiaHabilAcumulado" runat="server" CommandName="SwitchViewByID" CommandArgument="viewAcumulado" CssClass="lblEstandar" Text="[ver acumulado]"></asp:LinkButton>

            <table class="TablaEncabezadoDatos" style="width:910px">
                <tr>
                    <td style="width:130px"></td>
                    <td colspan="4" style="width:80px">Afiliaciones</td>
                    <td style="width:10px">&nbsp;</td>
                    <td colspan="5" style="width:80px">Crédito Pensionado</td>
                    <td style="width:10px"></td>
                    <td colspan="2" style="width:80px">Crédito Trabajador</td>
                </tr>
                <tr>
                    <td style="width:100px">
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument="UsuarioRegional" ToolTip="Ordenar">Sucursal</asp:LinkButton>
                    </td>
                    <td style="width:15px">
                        &nbsp;</td>
                    <td style="width:15px">
                        &nbsp;</td>
                    <td style="width:20px">
                        <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument="Afiliaciones" ToolTip="Ordenar">Venta último dia</asp:LinkButton>
                    </td>
                    <td style="width:15px">
                        &nbsp;</td>
                    <td style="width:15px"></td>
                    <td style="width:20px">
                        <asp:LinkButton ID="LinkButton6" runat="server" CommandArgument="CredPenCant" ToolTip="Ordenar">N° operac</asp:LinkButton>
                    </td>
                    <td style="width:15px">
                        &nbsp;</td>
                    <td style="width:15px">
                        &nbsp;</td>
                    <td style="width:20px">
                        <asp:LinkButton ID="LinkButton9" runat="server" CommandArgument="CredPenMto" ToolTip="Ordenar">Venta último dia MM$</asp:LinkButton>
                    </td>
                    <td style="width:15px">
                        &nbsp;</td>
                    <td style="width:15px"></td>
                    <td style="width:30px">
                        <asp:LinkButton ID="LinkButton11" runat="server" CommandArgument="CredTraCant" ToolTip="Ordenar">N° operac</asp:LinkButton>
                    </td>
                    <td style="width:30px">
                        <asp:LinkButton ID="LinkButton12" runat="server" CommandArgument="CredTraMto" ToolTip="Ordenar">Venta último dia MM$</asp:LinkButton>
                    </td>
                </tr>
                <tr class="d0">
                    <td style="width:100px">
                        <asp:Label ID="Label1" runat="server" Text="Totales" />
                    </td>

                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="lblAfiliacionesUDH" runat="server" />
                    </td>

                    <td>
                        &nbsp;</td>

                    <td>
                    </td>
                    <td>
                        <asp:Label ID="CredPenCantUDH" runat="server" />
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>

                    <td>
                        <asp:Label ID="lblCredPenMtoUDH" runat="server" />
                    </td>

                    <td>
                        &nbsp;</td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="CredTraCantUDH" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="CredTraMtoUDH" runat="server" />
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
                            <ItemStyle Width="245px" />
                            <ItemTemplate> 
                                <asp:label runat="server" ID="lblSucursal" Text='<%# Bind("Sucursal")%>' CssClass="lblEstandar" />
                            </ItemTemplate>   
                        </asp:TemplateField> 

                        <asp:TemplateField >                 
                            <ItemStyle Width="25px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="25px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="60px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblAfiliaciones" runat="server" Text='<%# Bind("AfiliacionesUDH", "{0:N0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="25px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="25px" HorizontalAlign="Center"/>  
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="75px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCredPenCant" runat="server" Text='<%# Bind("CredPenCantUDH", "{0:N0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="25px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="25px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >
                            <ItemStyle Width="60px" HorizontalAlign="Center"/>                 
                            <ItemTemplate> 
                                <asp:Label ID="lblCredPenMto" runat="server" Text='<%# Bind("CredPenMtoUDH", "{0:N1}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="25px" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="30px" HorizontalAlign="Center"/>  
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="75px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCredTraCant" runat="server" Text='<%# Bind("CredTraCantUDH", "{0:N0}")%>' ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>

                        <asp:TemplateField >                 
                            <ItemStyle Width="60px" HorizontalAlign="Center"/>
                            <ItemTemplate> 
                                <asp:Label ID="lblCredTraMto" runat="server" Text='<%# Bind("CredTraMtoUDH", "{0:N1}")%>'  ></asp:Label> 
                            </ItemTemplate>   
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>
         </asp:View>
    </asp:MultiView>

    <asp:Button ID="btnVolver" runat="server" CssClass="BotonMenu" Text="<< Volver"/>
</asp:Content>
