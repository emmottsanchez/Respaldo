<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.vb" Inherits="Webapp._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
     <asp:Panel runat="server" ID="AccesoOk" Visible="false">
         <img src="assets/img/Edificio.jpg"  width="80%" />
                                                 <h1>Bienvenid@</h1>
                        <asp:Label ID="lblNombreUsuario" runat="server" Font-Bold="true" ForeColor="#ff6600" Font-Size="20px"></asp:Label>
                        <br /> <asp:Label ID="Label9" runat="server" Text="Tu sucursal actual es " Font-Bold="true"  Font-Size="16px"></asp:Label> 
                        <asp:Label ID="lblSucursalIngreso" runat="server"  Font-Bold="true"  ForeColor="#ff6600"  Font-Size="17px"></asp:Label>
                        <br />
         </asp:Panel>
  </asp:Content>