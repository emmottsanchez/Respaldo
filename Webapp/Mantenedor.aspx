<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Mantenedor.aspx.vb" MasterPageFile="~/Site.Master" Inherits="Webapp.Mantenedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
    
    <link rel="icon" type="image/png" href="assets/icon.png" />

    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/jquery-1.8.3.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>

<body>
    <script>
        function MostrarMensajeDelete() {
            alert("Registro Borrado");
        }
    </script>
</body>
        <br />
        <center>
       
        <asp:Panel runat="server" ID="plMantenedorUser" Visible="false">
            <h3>Mantenedor Usuarios PEC</h3>
            <asp:Label runat="server" Text="MES:" Font-Bold="true" Font-Size="16px"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlMes">
            </asp:DropDownList>
            <asp:Button ID="btnEnviar" runat="server" Text="Button" /><br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" DataKeyNames="IdUsuario" DataSourceID="SqlDataSource1" CellSpacing="2" ForeColor="Black" Width="98%" PageSize="12">
                <Columns>
                    <asp:CommandField ShowEditButton="True" ButtonType="Image" CancelImageUrl="~/assets/img/icon_cancel.png" DeleteImageUrl="~/assets/img/icon_delete.jpg" EditImageUrl="~/assets/img/icono_Edit.png" UpdateImageUrl="~/assets/img/icono_update.png" />
                    <asp:BoundField DataField="IdUsuario" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="IdUsuario" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Font-Size="13px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Rut" HeaderText="Rut" SortExpression="Rut" >
                    <ItemStyle Font-Size="13px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Dv" HeaderText="Dv" SortExpression="Dv" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Font-Size="13px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" >
                    <ItemStyle Font-Size="13px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NombRRHH" HeaderText="NombRRHH" SortExpression="NombRRHH" >
                    <ItemStyle Font-Size="13px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NombBt" HeaderText="NombBt" SortExpression="NombBt" >
                    <ItemStyle Font-Size="13px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CodSucursal" HeaderText="CodSuc" SortExpression="CodSucursal" >
                    <ItemStyle Font-Size="13px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" SortExpression="Sucursal" >
                    <ItemStyle Font-Size="13px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Contraseña" HeaderText="Clave" SortExpression="Contraseña" >
                    <ItemStyle Font-Size="13px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TomaConocimiento" HeaderText="Toma Conocimiento" SortExpression="TomaConocimiento" >
                    <HeaderStyle Width="50px" />
                    <ItemStyle Font-Size="13px" HorizontalAlign="Center" Width="40px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="FechaAcepto" HeaderText="Fecha Acepto" ReadOnly="True" SortExpression="FechaAcepto" >
                    <ItemStyle Font-Size="13px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField>
                    <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" Runat="server" OnClientClick="return confirm('¿Desea eliminar el registro?');" CommandName="Delete">Eliminar
                    </asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Produccion %>" DeleteCommand="DELETE FROM [CPECUsuarios] WHERE [IdUsuario] = @IdUsuario" InsertCommand="INSERT INTO [CPECUsuarios] ([Rut], [Dv], [Usuario], [NombRRHH], [NombBt], [CodSucursal], [Sucursal], [ColorPensionado], [MetaAfiPen], [MetaCredPen], [ColorTrabajador], [MetaCredTrab], [NomCorto], [SoloNombre], [MetaAfiPen_ind], [MetaCredPen_ind], [Contraseña], [NombreEquipo], [TomaConocimiento], [FechaAcepto]) VALUES (@Rut, @Dv, @Usuario, @NombRRHH, @NombBt, @CodSucursal, @Sucursal, @ColorPensionado, @MetaAfiPen, @MetaCredPen, @ColorTrabajador, @MetaCredTrab, @NomCorto, @SoloNombre, @MetaAfiPen_ind, @MetaCredPen_ind, @Contraseña, @NombreEquipo, @TomaConocimiento, @FechaAcepto)" SelectCommand="SELECT IdUsuario, Rut, Dv, Usuario, NombRRHH, NombBt, CodSucursal, Sucursal, Contraseña, TomaConocimiento, CONVERT (char(10), FechaAcepto, 126) AS FechaAcepto FROM CPECUsuarios WHERE (MONTH(Periodo) = @ddlMes)" UpdateCommand="UPDATE [CPECUsuarios] SET [Rut] = @Rut, [Dv] = @Dv, [Usuario] = @Usuario, [NombRRHH] = @NombRRHH, [NombBt] = @NombBt, [CodSucursal] = @CodSucursal, [Sucursal] = @Sucursal, [ColorPensionado] = @ColorPensionado, [MetaAfiPen] = @MetaAfiPen, [MetaCredPen] = @MetaCredPen, [ColorTrabajador] = @ColorTrabajador, [MetaCredTrab] = @MetaCredTrab, [NomCorto] = @NomCorto, [SoloNombre] = @SoloNombre, [MetaAfiPen_ind] = @MetaAfiPen_ind, [MetaCredPen_ind] = @MetaCredPen_ind, [Contraseña] = @Contraseña, [NombreEquipo] = @NombreEquipo, [TomaConocimiento] = @TomaConocimiento, [FechaAcepto] = @FechaAcepto WHERE [IdUsuario] = @IdUsuario">
                <DeleteParameters>
                    <asp:Parameter Name="IdUsuario" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Periodo" Type="DateTime" />
                    <asp:Parameter Name="Rut" Type="Int32" />
                    <asp:Parameter Name="Dv" Type="String" />
                    <asp:Parameter Name="Usuario" Type="String" />
                    <asp:Parameter Name="NombRRHH" Type="String" />
                    <asp:Parameter Name="NombBt" Type="String" />
                    <asp:Parameter Name="CodSucursal" Type="Int32" />
                    <asp:Parameter Name="Sucursal" Type="String" />
                    <asp:Parameter Name="ColorPensionado" Type="String" />
                    <asp:Parameter Name="MetaAfiPen" Type="Int32" />
                    <asp:Parameter Name="MetaCredPen" Type="Int32" />
                    <asp:Parameter Name="ColorTrabajador" Type="String" />
                    <asp:Parameter Name="MetaCredTrab" Type="Int32" />
                    <asp:Parameter Name="NomCorto" Type="String" />
                    <asp:Parameter Name="SoloNombre" Type="String" />
                    <asp:Parameter Name="MetaAfiPen_ind" Type="Int32" />
                    <asp:Parameter Name="MetaCredPen_ind" Type="Int32" />
                    <asp:Parameter Name="Contraseña" Type="Int32" />
                    <asp:Parameter Name="NombreEquipo" Type="String" />
                    <asp:Parameter Name="TomaConocimiento" Type="Int32" />
                    <asp:Parameter Name="FechaAcepto" Type="DateTime" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlMes" Name="ddlMes" PropertyName="SelectedValue" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Periodo" Type="DateTime" />
                    <asp:Parameter Name="Rut" Type="Int32" />
                    <asp:Parameter Name="Dv" Type="String" />
                    <asp:Parameter Name="Usuario" Type="String" />
                    <asp:Parameter Name="NombRRHH" Type="String" />
                    <asp:Parameter Name="NombBt" Type="String" />
                    <asp:Parameter Name="CodSucursal" Type="Int32" />
                    <asp:Parameter Name="Sucursal" Type="String" />
                    <asp:Parameter Name="ColorPensionado" Type="String" />
                    <asp:Parameter Name="MetaAfiPen" Type="Int32" />
                    <asp:Parameter Name="MetaCredPen" Type="Int32" />
                    <asp:Parameter Name="ColorTrabajador" Type="String" />
                    <asp:Parameter Name="MetaCredTrab" Type="Int32" />
                    <asp:Parameter Name="NomCorto" Type="String" />
                    <asp:Parameter Name="SoloNombre" Type="String" />
                    <asp:Parameter Name="MetaAfiPen_ind" Type="Int32" />
                    <asp:Parameter Name="MetaCredPen_ind" Type="Int32" />
                    <asp:Parameter Name="Contraseña" Type="Int32" />
                    <asp:Parameter Name="NombreEquipo" Type="String" />
                    <asp:Parameter Name="TomaConocimiento" Type="Int32" />
                    <asp:Parameter Name="FechaAcepto" Type="DateTime" />
                    <asp:Parameter Name="IdUsuario" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
        </asp:Panel>

            </center>

</asp:Content>
