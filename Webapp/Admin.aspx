<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admin.aspx.vb" Inherits="Webapp.Agente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script>
        function IngresarRut() {
            alert("Ingresar Rut de PEC valido.");
        }
      </script>
    <center>
        <br /><br /><br />
    <asp:Label runat="server" ID="lblErr"></asp:Label>&nbsp;&nbsp;
    <asp:Label runat="server" Text="Buscador PEC" Font-Bold="true" Font-Size="26px" Font-Underline="true"></asp:Label>
        <br /><br/>
    <asp:Label runat="server" Text="Seleccionar Sucursal" Font-Bold="true"></asp:Label>
    &nbsp;
    <asp:DropDownList runat="server" ID="ddlSuc" Width="150px"></asp:DropDownList>&nbsp; &nbsp;<asp:Button runat="server" ID="btnEnviar" Text="Buscar" class="btn btn-primary"/>
        <div class="panel panel-body" style="position:relative;margin-left:715px;margin-top:-95px;width:260px;border:groove;">
        <asp:Label runat="server" Text="Metas Sucursal" Font-Underline="true" Font-Size="Large"></asp:Label><br />
            <asp:Label runat="server" ID="txtMetaAf"></asp:Label><br />
        <asp:Label runat="server" ID="txtMetaCr"></asp:Label><br />
            <asp:Label runat="server" ID="txtTotMet"></asp:Label>
        </div>
        <div class="panel panel-body" style="position:absolute;margin-left:135px;margin-top:-140px;width:280px;border:groove;text-align:left">
            <asp:Label runat="server" ID="lblAf"></asp:Label><br />
        <asp:Label runat="server" ID="lblCr"></asp:Label><br />
            <asp:Label runat="server" ID="lblSeg"></asp:Label><br />
             <asp:Label runat="server" ID="lblLcM"></asp:Label><br />
             <asp:Label runat="server" ID="lblCup"></asp:Label>
        </div>
         <asp:GridView runat="server" ID="GridDatos" AutoGenerateColumns="False" CellPadding="4"  ForeColor="#333333" Width="80%" ShowFooter="True" HorizontalAlign="Center" >
        <AlternatingRowStyle BackColor="White" BorderColor="#003300" BorderWidth="1px" />
        <Columns>
             <asp:TemplateField ItemStyle-Width="6%" ItemStyle-HorizontalAlign="center" >    
                 <HeaderTemplate>
                     <center><asp:Label runat="server" Text="Rut" ></asp:Label></center>
                 </HeaderTemplate> 
                 <ItemTemplate>
                     <asp:Label ID="RutP"  CommandName="Tr" runat="server" Text='<%#Bind("Rut")%>' ForeColor="#000000" ></asp:Label>
                 </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="6%"></ItemStyle>
            </asp:TemplateField> 
                 
            <asp:TemplateField ItemStyle-HorizontalAlign="center" ItemStyle-Width="29%" >   
                <HeaderTemplate >
                     <center><asp:Label runat="server" Text="Nombre" ></asp:Label></center>
                </HeaderTemplate>                
                <ItemTemplate >
                     <asp:Label ID="NombP" runat="server" Text='<%#Bind("NombRRHH")%>' ForeColor="#000000" Font-Size="12px"></asp:Label>
                 </ItemTemplate>  

<ItemStyle HorizontalAlign="Center" Width="31%"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-Width="8%" ItemStyle-HorizontalAlign="center" >    
                 <HeaderTemplate>
                     <center><asp:Label runat="server" Text="Afiliaciones Pensionado" ></asp:Label></center>
                 </HeaderTemplate> 
                 <ItemTemplate>
                     <asp:Label ID="RutP"  CommandName="Tr" runat="server" Text='<%#Bind("Afiliaciones_Pensionado")%>' ForeColor="#000000" ></asp:Label>
                 </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
            </asp:TemplateField> 

               <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="center">    
                 <HeaderTemplate>
                     <center><asp:Label runat="server" Text="Créditos Pensionado" ></asp:Label></center>
                 </HeaderTemplate> 
                 <ItemTemplate>
                   
                     <asp:Label ID="RutP"  CommandName="Tr"  runat="server" Text='<%#String.Format("{0:C0}",DataBinder.Eval(Container.DataItem,"Creditos_Pensionados"))%>' ForeColor="#000000" ></asp:Label>
                 </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="center" >    
                 <HeaderTemplate>
                     <center><asp:Label runat="server" Text="Créditos Trabajador" ></asp:Label></center>
                 </HeaderTemplate> 
                 <ItemTemplate>
                     <asp:Label ID="RutP"  CommandName="Tr" runat="server" Text='<%#String.Format("{0:C0}",DataBinder.Eval(Container.DataItem,"Creditos_Trabajador"))%>' ForeColor="#000000" ></asp:Label>
                 </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-Width="8%" ItemStyle-HorizontalAlign="center" >    
                 <HeaderTemplate>
                     <center><asp:Label runat="server" Text="Seguros Pensionado" ></asp:Label></center>
                 </HeaderTemplate> 
                 <ItemTemplate>
                     <asp:Label ID="RutP"  CommandName="Tr" runat="server" Text='<%#Bind("CantidadIndPens")%>' ForeColor="#000000" ></asp:Label>
                 </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-Width="8%" ItemStyle-HorizontalAlign="center" >    
                 <HeaderTemplate>
                     <center><asp:Label runat="server" Text="Seguros Trabajador" ></asp:Label></center>
                 </HeaderTemplate> 
                 <ItemTemplate>
                     <asp:Label ID="RutP"  CommandName="Tr" runat="server" Text='<%#Bind("CantidadIndTrab")%>' ForeColor="#000000" ></asp:Label>
                 </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-Width="8%" ItemStyle-HorizontalAlign="center" >    
                 <HeaderTemplate>
                     <center><asp:Label runat="server" Text="Seguros Cesantía" ></asp:Label></center>
                 </HeaderTemplate> 
                 <ItemTemplate>
                     <asp:Label ID="RutP"  CommandName="Tr" runat="server" Text='<%#Bind("CantidadSegCes")%>' ForeColor="#000000" ></asp:Label>
                 </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-Width="7%" ItemStyle-HorizontalAlign="center" >    
                 <HeaderTemplate>
                     <center><asp:Label runat="server" Text="Licencias Médicas" ></asp:Label></center>
                 </HeaderTemplate> 
                 <ItemTemplate>
                     <asp:Label ID="RutP"  CommandName="Tr" runat="server" Text='<%#Bind("LM")%>' ForeColor="#000000" ></asp:Label>
                 </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-Width="6%" ItemStyle-HorizontalAlign="center" >    
                 <HeaderTemplate>
                     <center><asp:Label runat="server" Text="Cupones" ></asp:Label></center>
                 </HeaderTemplate> 
                 <ItemTemplate>
                     <asp:Label ID="RutP"  CommandName="Tr" runat="server" Text='<%#Bind("Cupones")%>' ForeColor="#000000" ></asp:Label>
                 </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
            </asp:TemplateField>
            </Columns>
        <FooterStyle BackColor="#193B67" Font-Bold="True" Font-Size="14px" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
             <EditRowStyle BackColor="#2461BF" BorderColor="#006600" BorderStyle="Solid" BorderWidth="1px" />
        <HeaderStyle BackColor="#193B67" ForeColor="White" Font-Size="14px" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
        <RowStyle BackColor="#FFFFFF" Font-Size="13px" HorizontalAlign="Center" BorderColor="#006600" BorderWidth="1px" VerticalAlign="Middle" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />

    </asp:GridView>
        <asp:Label runat="server" ID="TextBox1"></asp:Label>
        <br />
        <!--<asp:Label runat="server" Text="Ingrese Rut PEC: " Font-Bold="true"></asp:Label>&nbsp; &nbsp;<asp:TextBox runat="server" ID="txtRut" Width="135px" type="number"></asp:TextBox>&nbsp; <asp:Button runat="server" Text="Ver PEC" ID="btnBuscarPEC" class="btn btn-success"/><br /><br />-->
                        <div class="modal-content" style="width:80%;">
                <asp:Panel runat="server" ID="panelRequisitos" Visible="false"  style="text-align:left" width="95%">
                    <br />
                    <asp:Label runat="server" Font-Bold="true" Font-Size="18px" ForeColor="blue" Text="Recuerda que las metas individuales de tus ejecutivos PEC para el Mes Actual son: "></asp:Label>
                    <br />
                    <asp:Label runat="server" Font-Bold="true" ForeColor="#ff6600" Font-Size="19px">Segmento Pensionado  </asp:Label>
                    <br />
                    <asp:Label runat="server" style="font-size:13px">Ganarán incentivo todos aquellos ejecutivos PEC y/o asesores de clientes que cumplan los requisitos asociados a su sucursal, de acuerdo a las siguientes condiciones: </asp:Label>
                    <br /><br />
                    <center>
                        <table class="myTable" style="width:80%">
                            <tr>
                                <th rowspan="2" style="color:#ff0000;border:0px" class="auto-style11">Condición "Y"</th>
                                <th style="background-color:#555CC4;color:white" class="auto-style10">Afiliación Pensionados</th>
                                <th style="background-color:#555CC4;color:white" class="auto-style9">Crédito Pensionado MM$</th>
                            </tr>
                            <tr>
                                
                                <td><asp:Label runat="server" ID="lblMetaAfiPens"></asp:Label></td>
                                <td><asp:Label runat="server" ID="lblMetaCredPen"></asp:Label></td>
                            </tr>
                             <tr>
                                <th rowspan="2" style="color:#ff0000;border:0px" class="auto-style11">Condición "0"</th>
                                <th style="background-color:#555CC4;color:white" class="auto-style10">Afiliación Pensionados</th>
                                <th style="background-color:#555CC4;color:white" class="auto-style9">Crédito Pensionado MM$</th>
                            </tr>
                            <tr>
                                
                                <td><asp:Label runat="server" ID="lblMetaAfiPens2"></asp:Label></td>
                                <td><asp:Label runat="server" ID="lblMetaCredPend2"></asp:Label></td>
                            </tr>
                        </table><br />
                 <asp:Label runat="server" ID="Label8" Font-Bold="true" Font-Size="13px" style="color:#CF0303">IMPORTANTE: </asp:Label>
                <asp:Label runat="server" ID="lblImportante" Font-Bold="true" Font-Size="13px" style="color:#CF0303"></asp:Label>
                        <br />                       
                        <asp:Label ID="Label40" Font-Size="13px" style="color:#CF0303;text-align:center" runat="server" font-Bold="true"  Text="- Si tu sucursal cumple el 90% en afiliación y crédito pensionado tu incentivo  se duplica."></asp:Label>
                    </center>
                    <asp:Panel runat="server" ID="panel2" Visible="True"  style="text-align:left">
                    <h4><asp:Label runat="server" Font-Bold="true" ForeColor="#ff6600" Font-Size="19px">Segmento Trabajador - </asp:Label>
                        <asp:Label id="lblSegmentoTrab" runat="server" Font-Bold="true" Font-Size="19px"></asp:Label></h4>
                    &nbsp;&nbsp;<asp:Label runat="server" ID="lblMinVenta"></asp:Label><br />
                    <br /></asp:Panel></asp:Panel>
		          </div>
</center>
</asp:Content>