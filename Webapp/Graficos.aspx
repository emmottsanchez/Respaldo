<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Graficos.aspx.vb" MasterPageFile="~/Site.Master" Inherits="Webapp.Graficos" %>
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
        <br /><br />
        <center>
           <asp:Panel runat="server" ID="plMantenedorGr" Visible="false" Height="860px">
               <asp:Label runat="server" Text="2016-10"></asp:Label>&nbsp;<asp:Label runat="server" BackColor="#ECE6C6" Width="15px" Height="15px"></asp:Label>&nbsp;&nbsp;
            <asp:Label runat="server" Text="2015-11"></asp:Label>&nbsp;<asp:Label runat="server" BackColor="#DEB7B8" Width="15px" Height="15px"></asp:Label>&nbsp;&nbsp;
            <asp:Label runat="server" Text="2016-11"></asp:Label>&nbsp;<asp:Label runat="server" BackColor="#337AFF" Width="15px" Height="15px"></asp:Label><br />
            <div class="col-sm-6">
               <div style="margin-left:80px"><h3>Gráfico Afiliaciones FFAA ejecutivos PEC</h3></div>
                <div style="margin-left:74px"><asp:Label runat="server" ID="lblMesAct3"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblMesAnt3"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblAñoAnt3"></asp:Label></div><br />
                <div style="margin-left:74px"><asp:Label runat="server" ID="lblPFVMesAc"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblPFVMesAn"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblPFVAñAnt"></asp:Label></div>
            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Width="650px"><Series>
                <asp:Series Name="Series1" ChartType="Spline" XValueMember="habil" YValueMembers="MesActual" BorderWidth="6" Font="Microsoft Sans Serif, 8pt"></asp:Series>
                <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series2" XValueMember="habil" YValueMembers="MesAnterior"  BorderWidth="3">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series3" XValueMember="habil" YValueMembers="AñoAnterior" >
                </asp:Series>
                </Series><ChartAreas><asp:ChartArea Name="ChartArea1">
                    <AxisY Title="N° Afiliaciones">
                    </AxisY>
                    </asp:ChartArea></ChartAreas></asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Produccion %>" SelectCommand=" select * from CPECGraficoAfiliaciones order by habil asc"></asp:SqlDataSource><br />
                <div style="margin-left:80px"><h3>Gráfico Créditos Trabajadores ejecutivos PEC</h3></div>
                <div style="margin-left:74px"><asp:Label runat="server" ID="lblMesAct"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblMesAnt"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblAñoAnt"></asp:Label></div><br />
                <div style="margin-left:74px"><asp:Label runat="server" ID="lblPecMAct"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblPecMAnt"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblPecAÑAnt"></asp:Label></div>
                <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource3" Width="650px">
                    <Series>
                        <asp:Series ChartType="Spline" Name="Series1" XValueMember="habil" YValueMembers="MesActual"  BorderWidth="6">
                        </asp:Series>
                        <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series2" XValueMember="habil" YValueMembers="MesAnterior"  BorderWidth="3">
                        </asp:Series>
                        <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series3" XValueMember="habil" YValueMembers="AñoAnterior" >
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisY Title="Millones en Créditos">
                            </AxisY>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Produccion %>" SelectCommand="select * from CPECGraficoCredTrad  order by habil asc"></asp:SqlDataSource><br />
                <div style="margin-left:74px"><asp:Label runat="server" ID="lblCredMAct"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblCredMAnt"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblCredAñAnt"></asp:Label></div>
                </div><div class="col-sm-6">
                 <div style="margin-left:45px"><h3>Gráfico Afiliaciones Tradicionales ejecutivos PEC</h3></div>
                    <div style="margin-left:74px"><asp:Label runat="server" ID="lblMesAct4"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblMesAnt4"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblAñoAnt4"></asp:Label></div><br />
                    <div style="margin-left:74px"><asp:Label runat="server" ID="lblPAfTrMAct"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblPAfTrMAnt"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblPAfTrAñAnt"></asp:Label></div>
                 <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource2" Width="650px">
                    <Series>
                        <asp:Series ChartType="Spline" Name="Series1" XValueMember="habil" YValueMembers="MesActual"  BorderWidth="6">
                        </asp:Series>
                        <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series2" XValueMember="habil" YValueMembers="MesAnterior"  BorderWidth="3">
                        </asp:Series>
                        <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series3" XValueMember="habil" YValueMembers="AñoAnterior" >
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisY Title="N° Afiliaciones">
                            </AxisY>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Produccion %>" SelectCommand="   select * from CPECGraficoAfiliacionTrad order by habil asc"></asp:SqlDataSource>
                   <br />
                <div style="margin-left:45px"><h3>Gráfico Créditos Pensionados ejecutivos PEC</h3></div>
                    <div style="margin-left:74px"><asp:Label runat="server" ID="lblMesAct2"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblMesAnt2"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblAñoAnt2"></asp:Label><br /></div><br />
                    <div style="margin-left:74px"><asp:Label runat="server" ID="lblPMesAc"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblPMesAn"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblPAñoAn"></asp:Label></div>
                   <asp:Chart ID="Chart4" runat="server" DataSourceID="SqlDataSource4" Width="650px">
                       <Series>
                           <asp:Series ChartType="Spline"  Name="Series1" XValueMember="habil" YValueMembers="MesActual"  BorderWidth="6">
                           </asp:Series>
                           <asp:Series ChartType="Spline"  Name="Series2" XValueMember="habil" YValueMembers="MesAnterior"  BorderWidth="3">
                           </asp:Series>
                           <asp:Series ChartType="Spline"  Name="Series3" XValueMember="habil" YValueMembers="AñoAnterior" >
                           </asp:Series>
                       </Series>
                       <ChartAreas>
                           <asp:ChartArea Name="ChartArea1">
                               <AxisY Title="Millones en Créditos">
                               </AxisY>
                           </asp:ChartArea>
                       </ChartAreas>
                   </asp:Chart>
                   <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Produccion %>" SelectCommand="select * from CPECGraficoCredPens order by habil asc"></asp:SqlDataSource><br />
                    <div style="margin-left:74px"><asp:Label runat="server" ID="LblCMesAct"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="LblCMesAnt"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="LblCAñoAn"></asp:Label></div>
                </div>
           <br />
        </asp:Panel>

            </center>

</asp:Content>
