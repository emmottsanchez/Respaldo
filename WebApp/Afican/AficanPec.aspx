<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AficanPec.aspx.vb" Inherits="WebApp.AficanPec" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
      <br />
    <asp:Label ID="lblNombre" runat="server" Font-Size="21px" ForeColor="#003366"></asp:Label>  <br /> <br />

    <table class="Totalestabla" border="1">
        <tr>
            <td width="302px" bgcolor="#0e4438" ><asp:Label ID="Label1" runat="server" Text="PEC" ForeColor="White"  Font-Size="13px"></asp:Label></td>
            <td width="72px" bgcolor="#0e4438" ><asp:Label ID="Label2" runat="server" Text="Red" ForeColor="White" Font-Size="13px"></asp:Label></td>
            <td width="72px" bgcolor="#0e4438" ><asp:Label ID="Label5" runat="server" Text="In"  ForeColor="White" Font-Size="13px"></asp:Label></td>
            <td width="72px" bgcolor="#0e4438" ><asp:Label ID="Label8" runat="server" Text="Out" ForeColor="White" Font-Size="13px"></asp:Label></td>
            <td width="72px" bgcolor="#0e4438" ><asp:Label ID="Label4" runat="server" Text="Ben" ForeColor="White" Font-Size="13px"></asp:Label></td>
            <td width="72px" bgcolor="#0e4438" ><asp:Label ID="Label11" runat="server" Text="FFAA" ForeColor="White" Font-Size="13px"></asp:Label></td>
              <td width="72px" bgcolor="#580002" ><asp:Label ID="Label3" runat="server" Text="Total Afiliaciones" ForeColor="White" Font-Size="13px"></asp:Label></td> 
        </tr>
    </table>
    

    <table class="Totalestabla" border="1">
        <tr>
            <td width="302px"><asp:Label ID="lblTotales" runat="server" Text="Totales" Font-Size="13px"></asp:Label></td>
            <td width="72px"><asp:Label ID="lblAfiRed" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="72px"><asp:Label ID="lblAfiIn" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="72px"><asp:Label ID="lblAfiOut" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="72px"><asp:Label ID="lblAfiBen" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="72px"><asp:Label ID="lblAfiFFAA" runat="server" Text="" Font-Size="13px"></asp:Label></td>
            <td width="72px"><asp:Label ID="lblTotalAfi" runat="server" Text="" Font-Size="13px"></asp:Label></td>                      
        </tr>
    </table>

 <asp:GridView runat="server" ID="gv1" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" ShowHeader="false" CssClass="Grid1">
        <AlternatingRowStyle BackColor="White" BorderColor="#003300" BorderWidth="1px" />
        <Columns>

           <asp:BoundField DataField="UsuarioIngreso" HeaderText="Usuario Pec" >
                  <ItemStyle Width="300px" ForeColor="#003399"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="AfiliacionesRed" HeaderText="Afiliaciones Red" >
                  <ItemStyle Width="70px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="AfiliacionesIn" HeaderText="Afiliaciones In" >
                  <ItemStyle Width="70px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="AfiliacionesOut" HeaderText="Afiliaciones Out" >
                  <ItemStyle Width="70px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="AfiliacionesBen" HeaderText="Afiliaciones Ben" >
                  <ItemStyle Width="70px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="AfiliacionesFfaa" HeaderText="Afiliaciones FFAA" >
                  <ItemStyle Width="70px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="TotalAFi" HeaderText="Total Afiliaciones" >
                  <ItemStyle Width="70px"></ItemStyle>
            </asp:BoundField>
            </Columns>

        <EditRowStyle BackColor="#7C6F57" BorderColor="#006600" BorderStyle="Solid" BorderWidth="1px" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" Font-Size="Small" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center"  />
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
    </div>
    
    <br />

    <asp:button id="btnBack" runat="server" text="Volver" OnClientClick="JavaScript: window.history.back(1); return false;"></asp:button>
</asp:Content>
