<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AficanRegional.aspx.vb" Inherits="WebApp.AficanRegional" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <br />
    <asp:Label ID="lblNombre" runat="server" Text="" Font-Size="21px" ForeColor="#003366"></asp:Label> <br /><br />
    <Table class="Totalestabla" border="1">
        <Tr>
            <td width="270px" bgcolor="#0e4438" ><asp:Label ID="Label1" runat="server" Text="Regionales" ForeColor="White" Font-Size="12px"></asp:Label></td>
            
            <td width="70px" bgcolor="#0e4438" ><asp:Label ID="Label3" runat="server" Text="Meta" ForeColor="White" Font-Size="12px"></asp:Label></td>
            <td width="70px" bgcolor="#0e4438" ><asp:Label ID="Label2" runat="server" Text="Red" ForeColor="White" Font-Size="12px"></asp:Label></td>
            <td width="70px" bgcolor="#0e4438" ><asp:Label ID="Label4" runat="server" Text="% Cump" ForeColor="White" Font-Size="12px"></asp:Label></td>
            
            <td width="70px" bgcolor="#0e4438" ><asp:Label ID="Label6" runat="server" Text="Meta" ForeColor="White" Font-Size="12px"></asp:Label></td>
            <td width="70px" bgcolor="#0e4438" ><asp:Label ID="Label5" runat="server" Text="In"  ForeColor="White" Font-Size="12px"></asp:Label></td>
            <td width="70px" bgcolor="#0e4438" ><asp:Label ID="Label7" runat="server" Text="% Cump" ForeColor="White" Font-Size="12px"></asp:Label></td>
            
            <td width="70px" bgcolor="#0e4438" ><asp:Label ID="Label9" runat="server" Text="Meta" ForeColor="White" Font-Size="12px"></asp:Label></td>
            <td width="70px" bgcolor="#0e4438" ><asp:Label ID="Label8" runat="server" Text="Out" ForeColor="White" Font-Size="12px"></asp:Label></td>
            <td width="70px" bgcolor="#0e4438" ><asp:Label ID="Label10" runat="server" Text="% Cump" ForeColor="White" Font-Size="12px"></asp:Label></td>

            <td width="70px" bgcolor="#0e4438" ><asp:Label ID="Label21" runat="server" Text="Meta" ForeColor="White" Font-Size="12px"></asp:Label></td>
            <td width="70px" bgcolor="#0e4438" ><asp:Label ID="Label22" runat="server" Text="Ben" ForeColor="White" Font-Size="12px"></asp:Label></td>
            <td width="70px" bgcolor="#0e4438" ><asp:Label ID="Label23" runat="server" Text="% Cump" ForeColor="White" Font-Size="12px"></asp:Label></td>
            
            <td width="70px" bgcolor="#0e4438" ><asp:Label ID="Label12" runat="server" Text="Meta" ForeColor="White" Font-Size="12px"></asp:Label></td>
            <td width="70px" bgcolor="#0e4438" ><asp:Label ID="Label11" runat="server" Text="FFAA" ForeColor="White" Font-Size="12px"></asp:Label></td>
            <td width="70px" bgcolor="#0e4438" ><asp:Label ID="Label13" runat="server" Text="% Cump" ForeColor="White" Font-Size="12px"></asp:Label></td>

            <td width="70px" bgcolor="#580002" ><asp:Label ID="Label14" runat="server" Text="Meta Total" ForeColor="White" Font-Size="12px"></asp:Label></td>
            <td width="70px" bgcolor="#580002" ><asp:Label ID="Label15" runat="server" Text="Total Afiliaciones" ForeColor="White" Font-Size="12px"></asp:Label></td>
            <td width="70px" bgcolor="#580002" ><asp:Label ID="Label16" runat="server" Text="% Cump Prop" ForeColor="White" Font-Size="12px"></asp:Label></td>
               
        </Tr>
    </Table>
    

    <Table class="Totalestabla" border="1">
        <Tr>
            <td width="270px"><asp:Label ID="lblTotales" runat="server" Text="Totales" Font-Size="13px"></asp:Label></td>
            
            <td width="70px"><asp:Label ID="lblMetaRed" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="70px"><asp:Label ID="lblAfiRed" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="70px"><asp:Label ID="lblCumpRed" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            
            <td width="70px"><asp:Label ID="lblMetaIn" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="70px"><asp:Label ID="lblAfiIn" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="70px"><asp:Label ID="lblCumpIn" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            
            <td width="70px"><asp:Label ID="lblMetaOut" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="70px"><asp:Label ID="lblAfiOut" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="70px"><asp:Label ID="lblCumpOut" runat="server" Text="" Font-Size="13px"></asp:Label></td>

            <td width="70px"><asp:Label ID="lblMetaBen" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="70px"><asp:Label ID="lblAfiBen" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="70px"><asp:Label ID="lblCumpBen" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            
            <td width="70px"><asp:Label ID="lblMetaFFAA" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="70px"><asp:Label ID="lblAfiFFAA" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="70px"><asp:Label ID="lblCumpFFAA" runat="server" Text="" Font-Size="13px"></asp:Label></td>

            <td width="70px"><asp:Label ID="lblMetaTotal" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="70px"><asp:Label ID="lblTotalAfi" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="70px"><asp:Label ID="lblCumPropTotal" runat="server" Text="" Font-Size="13px"></asp:Label></td>
                
        </Tr>
    </Table>
    
    <asp:GridView runat="server"  ID="gv1" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeader="false" CssClass="Grid1" >
        <AlternatingRowStyle BackColor="White" BorderColor="#003300" BorderWidth="1px" />
        <Columns>

            <%--<asp:BoundField DataField="Usuario" HeaderText="Agente" />--%>

            <asp:TemplateField HeaderText="Regionales" >                 
                <ItemStyle Width="270px" HorizontalAlign="Left"   Font-Size="13px" />
                <ItemTemplate> 
                    <asp:LinkButton runat="server" 
                                    ID="lbUsuarioRegional" 
                                    Text='<%# Bind("Usuario")%>' 
                                    CommandName = "VerRegional"
                                    CommandArgument='<%# Bind("IdUsuarioRegional")%>'
                                    ToolTip="Ver Agentes a Cargo" 
                                    ForeColor="#003366"
                                    />
                </ItemTemplate>   
            </asp:TemplateField> 

            
            <asp:BoundField DataField="MetaRed" HeaderText="Meta Red" >
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="AfiliacionesRed" HeaderText="Afiliaciones Red">
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="PrcPropCumRed" HeaderText="% Cump" DataFormatString="{0:P1}" >
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>
           
            <asp:BoundField DataField="MetaIn" HeaderText="Meta In">
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="AfiliacionesIn" HeaderText="Afiliaciones In">
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="PrcPropCumIn" HeaderText="% Cump" DataFormatString="{0:P1}">
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>
            
            <asp:BoundField DataField="MetaOut" HeaderText="Meta Out" >
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="AfiliacionesOut" HeaderText="Afiliaciones Out" >
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="PrcPropCumOut" HeaderText="% Cump" DataFormatString="{0:P1}" >
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="MetaBen" HeaderText="Meta Ben" >
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="AfiliacionesBen" HeaderText="Afiliaciones Ben" >
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="PrcPropCumBen" HeaderText="% Cump" DataFormatString="{0:P1}" >
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>
                       
            <asp:BoundField DataField="MetaFfaa" HeaderText="Meta FFAA" >
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="AfiliacionesFfaa" HeaderText="Afiliaciones FFAA" >
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="PrcPropCumFfaa" HeaderText="% Cump" DataFormatString="{0:P1}" >
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="MetaTotal" HeaderText="Meta Total" >
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="TotalAfi" HeaderText="Total Afiliaciones">
                 <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="CumpPropTotal" HeaderText="% Cump" DataFormatString="{0:P1}" >
                  <ItemStyle Width="70px" Font-Size="13px"></ItemStyle>
            </asp:BoundField>

        </Columns>

        <EditRowStyle BackColor="#7C6F57" BorderColor="#006600" BorderStyle="Solid" BorderWidth="1px" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" Font-Size="Small" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" Font-Size="Small" HorizontalAlign="Center" BorderColor="#006600" BorderWidth="1px" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    <div>
       <br />
        <asp:Label ID="lblExtraccion" runat="server" Text="" ForeColor="#cc0000"></asp:Label>

        <asp:Label ID="Label17" runat="server" Text="Meta:     " ForeColor="#0F33A6" Font-Size="15px" ></asp:Label>
        <asp:Label ID="Label19" runat="server" Text="Corresponde a la Meta Total del Mes" ForeColor="#cc0000" Font-Size="15px"></asp:Label><br />

        <asp:Label ID="Label18" runat="server" Text="% Cump: " ForeColor="#0F33A6" Font-Size="15px"></asp:Label>
         <asp:Label ID="Label20" runat="server" Text="Corresponde al Cumplimiento Proporcional a la fecha actual" ForeColor="#cc0000" Font-Size="15px"></asp:Label>
    </div> <br />

     <asp:button id="btnBack" runat="server" text="Volver" OnClientClick="JavaScript: window.history.back(1); return false;"></asp:button>

</asp:Content>
