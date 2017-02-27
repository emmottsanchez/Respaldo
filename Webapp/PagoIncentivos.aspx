<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PagoIncentivos.aspx.vb" Inherits="Webapp.PagoIncentivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">     

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
<center>    
    &nbsp;&nbsp;&nbsp<asp:Label runat="server" id="lblRut" Font-Size="21px" Text="Busqueda Rut PEC:" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:TextBox runat="server" ID="txtRut" Width="85px"></asp:TextBox>&nbsp;&nbsp;<asp:Button runat="server" Text="Buscar" id="btnBus" class="btn btn-primary"/>    
    <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblNombPec" Font-Bold="true" Font-Size="16px"></asp:Label>
    <asp:Label runat="server" ID="lblMsg" Font-Bold="true" Font-Size="30px" Text="No existen Datos en Sistema" Visible="false"></asp:label></br>
       <!--Instrucciones -->
     <asp:Panel runat="server" ID="plCalculo" Visible="true" style="margin-left:-5px">
    <div class="panel panel-default col-sm-3" style="margin-left:-15px">
       
      <div class="panel-body">
           <div class="panel-body">
            <asp:Label ID="lblInstrucciones" runat="server" Font-Bold="true" Text="Calculo Incentivo:" Font-Size="19px"></asp:Label><br />
            <asp:Label ID="lblIncentivoPensionado" Font-Size="15px" runat="server" Font-Underline="true" Font-Bold="true" Text="Pensionados"></asp:Label><br /><br />
          <table class="table table-bordered" style="width:40px;text-align:center" id="tb1" runat="server">
              <tr style="font-size:12px;">
                  <th>Condición</th>
                  <th>Afiliación</th>
                  <th>Créditos</th>
              </tr>
              <tr>
                  <td><asp:Label runat="server" Text=" Y "></asp:Label></td>
                  <td><asp:Label runat="server" ID="lblConAfPenY"></asp:Label></td>
                  <td><asp:Label runat="server" ID="lblConCrPenY"></asp:Label></td>
              </tr>
              <tr>
                  <td><asp:Label runat="server" Text=" O "></asp:Label></td>
                  <td><asp:Label runat="server" ID="lblConAfPenO"></asp:Label></td>
                  <td><asp:Label runat="server" ID="lblConCrPen0"></asp:Label></td>
              </tr>
          </table>          
          <table class="table table-bordered" style="width:40px;text-align:center" id="tb2" runat="server">
              <tr style="font-size:12px;">
                  <th>Afiliación</th>
                  <th>Créditos</th>
              </tr>
              <tr>
                  <td><asp:Label runat="server" ID="lblMetaAfiliacion"></asp:Label></td>
                  <td><asp:Label runat="server" ID="lblMetaCreditoPens"></asp:Label></td>
              </tr>
          </table>          
          <asp:Label ID="Label2" Font-Size="12px" runat="server" Font-Bold="true" Text="Afiliación: Monto a Pagar $1.000 X c/u <br/>Crédito: Monto a Pagar $1.000 X $MM" ></asp:Label><br /><br />
          <asp:Label ID="lblMsg1" Font-Size="12px" runat="server" style="color:#CF0303;" Font-Bold="true" Text="Importante:</br> Si tu sucursal cumple el 90% en afiliación y crédito pensionado tu incentivo  se duplica." ></asp:Label>
          <asp:Label ID="lblMsg2" Font-Size="12px" runat="server" style="color:#CF0303;" Font-Bold="true" Text="Importante:</br> Si tu cumples 2 o más metas individuales se te pagara $1.500 por meta cumplida." ></asp:Label><br /><br />
           <hr style="width:260px"/>
          <asp:Label ID="lblCalTrab" Font-Size="15px" runat="server" Font-Underline="true" Font-Bold="true" Text="Trabajadores"></asp:Label><br /><br />
          <asp:Label ID="lblMetaT" Font-Size="13px" runat="server" Font-Bold="true" ></asp:Label>
          <asp:Label ID="lblMetaT2" Font-Size="13px" runat="server" Font-Bold="true" ></asp:Label><br />
          <hr style="width:260px"/>
          <asp:Label ID="Label3" Font-Size="15px" runat="server" Font-Underline="true" Font-Bold="true" Text="Seguros"></asp:Label><br /><br />
          <table style="width:260px;text-align:center;border-color:black;border: 1px solid #dddddd;" border="1px">
              <tr style="border: 1px solid #dddddd">
                  <th></th>
                  <th style="text-align:center;font-size:13px;">Color</th>
                  <th style="text-align:center;font-size:13px">Ranking</th>
                  <th style="text-align:center;font-size:13px">$c/u</th>
              </tr>
              <tr>
                  <td> <asp:Label runat="server" Text=" Pensionado"></asp:Label></td>
                  <td><asp:Label ID="lblColPens" Font-Size="12px" runat="server"  ></asp:Label></td>                  
                  <td><asp:Label ID="lblRankPens" Font-Size="12px" runat="server" ></asp:Label></td>  
                  <td><asp:Label ID="lblValorPens" Font-Size="12px" runat="server"  ></asp:Label></td>  
              </tr>
              <tr>
                  <td> <asp:Label runat="server" Text="Trabajador"></asp:Label></td>
                  <td><asp:Label ID="lblColTrab" Font-Size="12px" runat="server"  ></asp:Label></td>
                  <td><asp:Label ID="lblRankTrab" Font-Size="12px" runat="server" ></asp:Label></td>                  
                  <td><asp:Label ID="lblValorTrab" Font-Size="12px" runat="server" ></asp:Label></td>                                  
              </tr>
              <tr>
                  <td><asp:Label runat="server" Text="Cesantía"></asp:Label></td>
                  <td><asp:Label ID="lblColCes" Font-Size="12px" runat="server" ></asp:Label></td>
                  <td><asp:Label ID="lblRankCes" Font-Size="12px" runat="server" ></asp:Label></td>       
                  <td><asp:Label ID="lblValorCes" Font-Size="12px" runat="server" ></asp:Label></td>                                             
              </tr>
          </table>
         </div>
            </div>
     </asp:Panel>

<asp:Panel runat="server" Width="640px" ID="plPagoInc" style="margin-left:45px; margin-bottom: 0px;">
    <h1 style="text-align:center;"">Pago de Incentivos</h1><br />
    <div style="text-align:left;">
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label9" runat="server" Text="Sucursal: " Font-Bold="true"  Font-Size="18px"></asp:Label>
    <asp:Label ID="lblSucursalActual" runat="server"  Font-Bold="true"  ForeColor="#ff6600"  Font-Size="17px"></asp:Label>            
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblAño" runat="server" ForeColor="#cc3300" Font-Bold="true" Font-Size="18px" Text="Año: "></asp:Label>
    <asp:DropDownList runat="server" ID="ddlAño" Height="23px" Width="70px" AutoPostBack="true"></asp:DropDownList>
        &nbsp;&nbsp;<asp:Label ID="lblMes" runat="server" ForeColor="#cc3300" Font-Bold="true" Font-Size="18px" Text="Mes: "></asp:Label>
    <asp:DropDownList runat="server" ID="ddlMes" Height="23px" Width="100px"></asp:DropDownList>
	&nbsp;&nbsp;&nbsp;<asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
    </div><br />
    <asp:Label runat="server" style="color:#CF0303;" Font-Bold="true" Text="* Los pagos reflejados son por Mes desfasado:"></asp:Label>
    <asp:Label runat="server" style="color:#CF0303;" Font-Bold="true" Text="Mes seleccionado ➡ Pago por gestion del mes anterior"></asp:Label><br /><br />
    <div id="tbIncentivo" runat="server">
    <table border="1px" style="text-align:center">
                <tr style="background-color:#193B67;color:white" >
                    <th style="width:120px;text-align:center;font-size:15px;">Segmento</th>
                    <th style="width:100px;text-align:center;font-size:15px">Concepto</th>
                    <th style="width:90px;text-align:center;font-size:15px">Venta Realizada</th>
                    <th style="width:100px;text-align:center;font-size:15px">Condición</th>
                    <th style="width:120px;text-align:center;font-size:14px">Incentivo $</th>
                    <th style="width:120px;text-align:center;font-size:14px">Cumplimiento Sucursal ($2.000)</th>
                    <th style="width:90px;text-align:center;font-size:15px">Total Incentivo</th></tr>
                    <tr style="height:35px">
                        <td align="center" rowspan="2">
                            <asp:Label runat="server" Text="PENSIONADOS"></asp:Label>
                        </td>
                        <td align="center" >
                            <asp:Label runat="server" Text="AFILIACIÓN"></asp:Label>
                        </td>
                        <td align="center" >
                            <asp:Label ID="lblAfReal" runat="server"></asp:Label>
                        </td>
                        <td align="center" rowspan="2" >
                            <asp:Label ID="lblPenCond" runat="server"></asp:Label>
                        </td>
                        <td align="center" rowspan="2">
                            <asp:Label id="lblIncPens" runat="server"></asp:Label>
                        </td>
                        <td align="center" rowspan="2">
                            <asp:Label ID="lblAfCumSuc" runat="server"></asp:Label>
                        </td>
                        <td align="center" rowspan="2">
                            <asp:Label ID="lblIncen" runat="server"></asp:Label>
                        </td>
                </tr>
    <tr style="height:35px">
        <td align="center">
            <asp:Label runat="server" Text="CRÉDITO"></asp:Label>
        </td>
        <td align="center">
            <asp:Label ID="lblCrPeReal" runat="server"></asp:Label>
        </td>
    </tr>
  </table><br /><br />
      <table border="1px" style="text-align:center;width:620px;height:75px">
           <tr style="background-color:#193B67;color:white" >
                    <th style="text-align:center;font-size:15px;">Segmento</th>
                    <th style="text-align:center;font-size:15px">Concepto</th>
                    <th style="text-align:center;font-size:15px"><asp:Label runat="server" Text="Venta DEALER ($200)X$MM" ID="lblDealerV"></asp:Label></th>
                    <th style="text-align:center;font-size:15px">Venta PEC ($1.000)X $MM</th>
                    <th style="text-align:center;font-size:15px">Cumple Meta</th>
                    <th style="text-align:center;font-size:15px">Total Incentivo</th></tr>
          <tr style="height:35px">
        <td align="center" >
                            <asp:Label runat="server" Text="TRABAJADORES"></asp:Label>
                        </td>
        <td align="center">
            <asp:Label runat="server" Text="CRÉDITO"></asp:Label>
        </td>
        <td align="center">
            <asp:Label ID="lblCrTrDeal" runat="server"></asp:Label>
        </td>
        <td align="center">
            <asp:Label ID="lblCrTrCred" runat="server"></asp:Label>
        </td>
        <td align="center">
            <asp:Label ID="lblCumMetaTrab" runat="server"></asp:Label>
        </td>
        <td align="center">
            <asp:Label ID="lblCredTrabTotalInc" runat="server"></asp:Label>
        </td>
    </tr>
      </table>
        </div>
    <div id="tbIncentivo2" runat="server">
    <table border="1px" style="text-align:center">
                <tr style="background-color:#193B67;color:white" >
                    <th style="width:100px;text-align:center;font-size:15px">Concepto</th>
                    <th style="width:90px;text-align:center;font-size:15px">Venta Realizada</th>
                    <th style="width:120px;text-align:center;font-size:15px">Cumple 2 o mas metas Ind.</th>
                    <th style="width:120px;text-align:center;font-size:14px">$ Incentivo X Cumplimiento metas Ind.</th>
                    <th style="width:100px;text-align:center;font-size:14px">Lugar en el Ranking</th>
                    <th style="width:120px;text-align:center;font-size:14px">$ Incentivo por Ranking</th>
                    <th style="width:90px;text-align:center;font-size:15px">$ Comisión Total</th></tr>
                    <tr style="height:35px">
                        <td align="center" >
                            <asp:Label runat="server" Text="AFILIACIÓN"></asp:Label>
                        </td>
                        <td align="center" >
                            <asp:Label ID="lblAfiliacion2" runat="server"></asp:Label>
                        </td>
                        <td align="center" rowspan="3" >
                            <asp:Label ID="lblCumpleMeta2" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label id="lblIncentivoAfiliacion2" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblRankingAfiliacion2" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblIncentivoRankAfiliacion2" runat="server"></asp:Label>
                        </td>
                        <td align="center" rowspan="3">
                            <asp:Label ID="lblComisionFinal2" runat="server"></asp:Label>
                        </td>
                </tr>
    <tr style="height:35px">
        <td align="center">
            <asp:Label runat="server" Text="CRED. PENSIONADO"></asp:Label>
        </td>
        <td align="center">
            <asp:Label ID="lblCredPensionado2" runat="server"></asp:Label>
        </td>
        <td align="center">
            <asp:Label ID="lblIncentivoCredPens2" runat="server"></asp:Label>
        </td>
        <td align="center">
            <asp:Label ID="lblRankingCredPens2" runat="server"></asp:Label>
        </td>
        <td align="center">
            <asp:Label ID="lblIncentivoRankCredPens2" runat="server"></asp:Label>
        </td>

    </tr>
          <tr style="height:35px">
        <td align="center">
            <asp:Label runat="server" Text="CRED. TRABAJADOR"></asp:Label>
        </td>
        <td align="center">
            <asp:Label ID="lblCredTrabajador2" runat="server"></asp:Label>
        </td>
        <td align="center">
            <asp:Label ID="lblIncentivoCredTrab2" runat="server"></asp:Label>
        </td>
        <td align="center">
            <asp:Label ID="lblRankingCredTrab2" runat="server"></asp:Label>
        </td>
        <td align="center">
            <asp:Label ID="lblIncentivoRankCredTrab2" runat="server"></asp:Label>
        </td>
    </tr>
  </table><br /><br />
        </div>
    <hr Style="width:630px;" />
         <asp:Label ID="Label13" runat="server" ForeColor="#cc3300" Font-Bold="true" Font-Size="21px" Text="SEGUROS "></asp:Label>
         <br /><br />
         <table border="1px" style="text-align:center;height:115px;width:620px;">
           <tr style="background-color:#193B67;color:white" >
                    <th style="width:120px;text-align:center;font-size:15px;">Concepto</th>
                    <th style="width:100px;text-align:center;font-size:15px">N° Ventas</th>
                    <th style="width:100px;text-align:center;font-size:15px">Ranking</th>
                    <th style="width:100px;text-align:center;font-size:15px">Incentivo</th>
                    <th style="width:90px;text-align:center;font-size:15px">Total Incentivo</th>
           </tr>
        <tr>
        <td align="center" >
                            <asp:Label runat="server" Text="Ind. Pensionado"></asp:Label>
                        </td>
        <td align="center">
           <asp:Label ID="lblVentasPens" runat="server"></asp:Label>
        </td>
        <td align="center">
            <asp:Label ID="lblRPens" runat="server"></asp:Label>
        </td>
        <td align="center">
           <asp:Label ID="lblIncenPens" runat="server"></asp:Label>
        </td>
        <td align="center" rowspan="3">
           <asp:Label ID="lblTotalIncentivoF" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td align="center" >
            <asp:Label runat="server" Text="Ind. Trabajador"></asp:Label>
        </td>
        <td align="center">
           <asp:Label ID="lblVentasTrab" runat="server"></asp:Label>
        </td>
        <td align="center">
           <asp:Label ID="lblRTrab" runat="server"></asp:Label>
        </td>
        <td align="center">
           <asp:Label ID="lblIncenTrab" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td align="center" >
            <asp:Label runat="server" Text="Cesantía"></asp:Label>
        </td>
        <td align="center">
           <asp:Label ID="lblVentasCes" runat="server"></asp:Label>
        </td>
        <td align="center">
           <asp:Label ID="lblRCes" runat="server"></asp:Label>
        </td>
        <td align="center">
           <asp:Label ID="lblIncenCes" runat="server"></asp:Label>
        </td>
        </tr>
      </table>
    </asp:Panel>
     <br /><br /><br /><br /><br />

        <br />
    <br /><br />

</center>
    <!--Fin Instrucciones -->
</asp:Content>