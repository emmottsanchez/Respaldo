<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="TomaConocimiento.aspx.vb" Inherits="Webapp.TomaConocimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <br /><center><div class="row">
					<h1>Mis Tomas de Conocimiento</h1>
                    <asp:Label ID="lblAño" runat="server" ForeColor="#cc3300" Font-Bold="true" Font-Size="18px" Text="Año: "></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlAño" Height="23px" Width="80px">
                    </asp:DropDownList>
					&nbsp;<asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
					<p></p>
                </div>

    <asp:GridView runat="server" ID="GridTomaCon" AutoGenerateColumns="False" CellPadding="4"  ForeColor="#333333" Width="319px" >
        <AlternatingRowStyle BackColor="White" BorderColor="#003300" BorderWidth="1px" />
        <Columns>
             <asp:TemplateField ItemStyle-Width="75px" ItemStyle-HorizontalAlign="center" >    
                 <HeaderTemplate>
                     <center><asp:Label runat="server" Text="Mes" ></asp:Label></center>
                 </HeaderTemplate> 
                 <ItemTemplate>
                     <asp:Label ID="Mes" runat="server" Text='<%#Bind("Mes")%>' ForeColor="#000000" ></asp:Label>
                 </ItemTemplate>
            </asp:TemplateField> 
                 
            <asp:TemplateField ItemStyle-HorizontalAlign="center" ItemStyle-Width="80px" >   
                <HeaderTemplate >
                     <center><asp:Label runat="server" Text="Toma Conocimiento" ></asp:Label></center>
                </HeaderTemplate>                
                <ItemTemplate>
                     <asp:Label ID="TomaCon" runat="server" Text='<%#Bind("TomaConocimiento")%>' ForeColor="#000000" ></asp:Label>
                 </ItemTemplate>  
            </asp:TemplateField>

                <asp:TemplateField ItemStyle-HorizontalAlign="center" ItemStyle-Width="70px" >   
                <HeaderTemplate>
                     <center><asp:Label runat="server" Text="Fecha"></asp:Label></center>
                </HeaderTemplate>                
                <ItemTemplate>
                     <asp:Label ID="TomaCon" runat="server" Text='<%#Bind("FechaAcepto")%>' ForeColor="#000000" ></asp:Label>
                 </ItemTemplate>  
            </asp:TemplateField>
            </Columns>
        <EditRowStyle BackColor="#2461BF" BorderColor="#006600" BorderStyle="Solid" BorderWidth="1px" />
        <FooterStyle BackColor="#193B67" Font-Bold="True" Font-Size="13px" ForeColor="White" />
        <HeaderStyle BackColor="#193B67" ForeColor="White" Font-Size="14px" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFFFF" Font-Size="13px" HorizontalAlign="Center" BorderColor="#006600" BorderWidth="1px" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />

    </asp:GridView>
                </center>

</asp:Content>