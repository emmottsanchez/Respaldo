<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Transacciones.aspx.vb" Inherits="Webapp.Transacciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">     

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <center>
        <!--<asp:Label runat="server" ID="lblMsg" Font-Bold="true" Font-Size="30px" Text="No existen Datos en Sistema" Visible="false"></asp:label>-->
    <!--Panel-->
     <asp:Panel runat="server" Width="55%" ID="plTran" class="panel-body">
         <div class="panel panel-body"  style="position:absolute;margin-left:-230px;margin-top:-10px;width:270px;border:groove;text-align:left">
            <asp:Label runat="server" ID="lblLMed" Font-Bold="true"></asp:Label><br />
             <asp:Label runat="server" ID="lblCupon" Font-Bold="true"></asp:Label>
        </div>
    <h1 style="text-align:center;"">Transacciones PEC Mes Actual</h1><br />
        <table class="table table-bordered table-hover" style="width:70%">
            <tr>
                <th style="font-size:16px;background-color:#BDBDBD">Concepto</th>
                <th style="font-size:16px;background-color:#BDBDBD"">Cantidad</th>
            </tr>
            <tr>
                <td style="font-size:16px;">Licencias Médicas ingresadas</td>
                <td style="text-align:center"><asp:Label runat="server" ID="lblLM"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-size:16px;">Cupones Entregados para campaña sucursal *</td>
                <td style="text-align:center"><asp:Label runat="server" ID="lblPG"></asp:Label></td>
            </tr>
        </table>
         <asp:Label runat="server" Text=" * Los Cupones entregados obedecen a rut unicos de afiliados que han pasado por Total Pack." Font-Size="15px" Font-Bold="true" style="color:red"></asp:Label><br />       
    </asp:Panel>
        </center>
    <!--Fin Instrucciones -->
</asp:Content>