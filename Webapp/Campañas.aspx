<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Campañas.aspx.vb" Inherits="Webapp.Campañas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script>
            function MostrarMensaje() {
                alert("Toma de Conocimiento Aprobada");
            }
            function MostrarMensajeError() {
                alert("Debes Aceptar condiciones para continuar");
            }
</script>
     <div id="DivMensaje"></div>
    <div style="position: relative;">
  <div style="position: absolute; left:380px; margin-top:25px; top: 2px; width: 500px;">
    <center><asp:Label runat="server" id="lblAgenteNoT" Text="no aceptado Toma Conocimiento" Font-Size="25px" Visible="false"></asp:Label></center>
      </div></div>
    <!--<asp:Label runat="server" Text="Datos No estan disponibles por el momento." Font-Size="25px"></asp:Label></center>
    <asp:Panel runat="server" ID="panelDia1" Visible="false">
        <center><br /><br /><br /><br /><asp:Label runat="server" Font-size="24px" Font-Bold="true" Text="Datos Actualizados serán visibles el día de mañana."></asp:Label></center>
    </asp:Panel>-->
   <asp:Panel runat="server" ID="panelCompleto">
       <asp:Panel runat="server" ID="plInd" Visible="TRUE">
<div style="position: relative;">
  <div style="position: absolute; left:75px">
      <div class="panel panel-default  offset2 span4 pull-left" > 
      <div class="panel-body">
            <asp:Label ID="lblDAfi" runat="server" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="lblDCred" runat="server" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="lblDSeguros" runat="server" Font-Bold="true"></asp:Label><br />
         </div></div>
  </div>
</div><br /></asp:Panel>
    <br /><br /><br />
      <!-- Campaña Flash-section-end -->
    <section class="service section_padding" id="flash">
        <asp:Panel runat="server" ID="pnlCampañaFlash" Visible="false">
		<div class="container">
			<div class="row">
  <div style="position: relative;">
  <div style="position: absolute; margin-left:820px">
      <div class="panel-body">
          <img src="assets/img/Flash201702.jpg" width="120%"/>
         </div>
  </div>
</div>
				<div class="service_title section-title col-text-center text-center wow flipInX">
					<h1>&nbsp;Campaña Flash - De Regreso a Clases</h1>
                    <h4 style="font-size:14px">(Campaña vigente desde: 13 al 28 de Febrero)</h4>
                    <asp:Label ID="Label2" runat="server" ForeColor="#cc3300" Font-Bold="true" Text="Datos provisorios de avance campaña flash."></asp:Label>
					<p></p>
                </div>
	        </div>
		</div>
        <div class="container"> 
           
             <asp:Label ID="lblNomFlash" runat="server" Text="Nombre" Font-Bold="true" ForeColor="#ff6600"></asp:Label>
            <asp:Label ID="Label16" runat="server" Text=", a continuación podrás visualizar cómo vas en la campaña flash."></asp:Label>
          <br /><asp:Label ID="Label23" runat="server" Text="Pertenezco al grupo" Font-Size="20px" Font-Bold="true"></asp:Label>
          <asp:Label ID="lblGrupoFlash" runat="server" Text="" Font-Size="25px" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label17" runat="server" Text="Detalle de mi resultado a la fecha" Font-Bold="true" ForeColor="#ff6600" Font-Size="20px"></asp:Label>
      <br />
            <div class="container">
           <table style="width:100%">
               <tr>
                   <td style="width:60%">
                       <table>
                           <!-- Seccion izquierda-->
                            
                           <tr>
                               <td style="height:40px">
                                   <asp:Label ID="Label18" runat="server" Text="Mis Afiliaciones: "></asp:Label>&nbsp&nbsp
                               </td>
                               <td>
                                   <asp:Label ID="lblAfiFlash" runat="server" Text="Afiliaciones" ForeColor="#003366" Font-Bold="true"></asp:Label>&nbsp&nbsp
                               </td>
                                 <td style="width:15px">&nbsp</td>
                               <td>
                                   <asp:Label ID="Label27" runat="server" Text="Mi Meta: "></asp:Label>&nbsp
                               </td>
                               
                               <td>
                                   <asp:Label ID="lblMetaAfiFlash" runat="server" Text="Meta" ForeColor="#003366" Font-Bold="true"></asp:Label>&nbsp&nbsp
                               </td>
                               <td style="width:15px">&nbsp</td>
                                <td>
                                   <asp:Label ID="Label19" runat="server" Text="Mi % de Cumplimiento: "></asp:Label>&nbsp
                               </td>
                               <td>
                                   <asp:Label ID="lblCumpAfiFlash" runat="server" Text="CumpAfi" ForeColor="#003366" Font-Bold="true"></asp:Label>&nbsp&nbsp
                               </td>
                               <td style="width:5%"></td>
                                 <td style="width:50%">
                       <!-- Seccion derecha-->
                       <center>
                            <asp:Label ID="lblSitFlash" runat="server" Text="" Font-Size="20px" Font-Bold="true"></asp:Label>
                       
                       <br /><br />
                       
                       
                   </center>
                   </td>
                           </tr>
                       </table>
                  </td>
               </tr>
           </table>       
           </div>
         </div>
                   <hr style="width:90%"/>
            </asp:Panel>
	</section><br />
	<!-- Campaña Flash-section-end -->
	
	<!-- -section-start -->
	<section class="service section_padding" id="pensionados">
        <asp:Panel runat="server" ID="pnlPensionados" Visible="false">
		<div class="container">
			<div class="row">
				<div class="service_title section-title col-text-center text-center wow flipInX">
					<h1>Afiliaciones Pensionados </h1>
                    <asp:Label ID="Label6" runat="server" ForeColor="#cc3300" Font-Bold="true" Text="Datos provisorios actualizados a la fecha del segmento pensionados, los cuales serán confirmados al cierre del mes."></asp:Label>
					<p></p>
                </div>
	        </div>
		</div>

        <div class="container"> 
           
             <asp:Label ID="lblNombreSegPen" runat="server" Text="Nombre" Font-Bold="true" ForeColor="#ff6600"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text=", a continuación podrás visualizar cómo va la entrega de beneficios de afiliación <br/> otorgados a nuestros pensionados. Estos datos son válidos para la campaña ''PEC Segmento Pensionados''."></asp:Label>
            
          <br /><br />
            <asp:Label ID="Label3" runat="server" Text="Detalle de mi resultado a la fecha" Font-Bold="true" ForeColor="#ff6600" Font-Size="20px"></asp:Label>
      <br />
            <div class="container">
           <table style="width:100%">
               <tr>
                   <td style="width:50%">
                       <table>
                           <!-- Seccion izquierda-->
                            
                           <tr>
                               <td style="height:40px">
                                   <asp:Label ID="Label5" runat="server" Text="Mis Afiliaciones: "></asp:Label>&nbsp&nbsp
                               </td>
                               <td>
                                   &nbsp;<asp:Label ID="lblAfiliacionesP" runat="server" Text="Afiliaciones" ForeColor="#003366" Font-Bold="true"></asp:Label>
                               </td>
                               <tr>
                                   <td style="font-size:13px;height:40px;"><b>Mi lugar en el Ranking es: </b></td>
                                   <td style="font-size:13px;">&nbsp;<asp:Label runat="server" ID="lblRkAfPens" Font-Bold="true" ForeColor="Green"></asp:Label></td>
                               </tr>
                           </tr>                              
                       </table>
                  </td>
                   <td style="width:50%">
                       <!-- Seccion derecha-->
                       <center>
                            <asp:Label ID="lblsituacion" runat="server" Text="" Font-Size="20px" Font-Bold="true"></asp:Label>
                       
                       <br /><br />
                       
                       
                   </center>
                   </td>
               </tr>
           </table>
            <br /><br />
           </div>

            <asp:Label ID="Label13" runat="server" Text="estas a solo" Font-Bold="true"></asp:Label>&nbsp
            <asp:Label ID="lblDiasRest" runat="server" Text="XXXX" Font-Bold="true" ForeColor="#ff6600"></asp:Label>&nbsp
            <asp:Label ID="Label15" runat="server" Text="días hábiles para el término del mes, animo y vamos por ese incentivo." Font-Bold="true"></asp:Label>
            <br /><br />
            </div>
        <div align="center"><a href="javascript:ventanaSecundaria('assets/img/Terminos y Condiciones.png')">
            <br /><br />
                   <img src="assets/img/ingresar.png"  width="90px" height="90px" /></a><br />
                    <asp:Label ID="Label22" runat="server" Text="Términos y condiciones " Font-Bold="true"></asp:Label>
        </div>
            <hr style="width:90%"/>
            </asp:Panel>
	</section>


       <section class="service section_padding" id="pensionadosCred">
        <asp:Panel runat="server" ID="pnlCredPens" Visible="false">
		<div class="container">
			<div class="row">
				<div class="service_title section-title col-text-center text-center wow flipInX">
					<h1>Créditos Pensionados </h1>
                    <asp:Label ID="Label10" runat="server" ForeColor="#cc3300" Font-Bold="true" Text="Datos provisorios actualizados a la fecha del segmento pensionados, los cuales serán confirmados al cierre del mes."></asp:Label>
					<p></p>
                </div>
	        </div>
		</div>

        <div class="container"> 
           
             <asp:Label ID="lblNombreSegPen2" runat="server" Text="Nombre" Font-Bold="true" ForeColor="#ff6600"></asp:Label>
            <asp:Label ID="Label29" runat="server" Text=", a continuación podrás visualizar cómo va la entrega de beneficios de crédito <br/> otorgados a nuestros pensionados. Estos datos son válidos para la campaña ''PEC Segmento Pensionados''."></asp:Label>
            
          <br /><br />
            <asp:Label ID="Label31" runat="server" Text="Detalle de mi resultado a la fecha" Font-Bold="true" ForeColor="#ff6600" Font-Size="20px"></asp:Label>
      <br />
            <div class="container">
           <table style="width:100%">
               <tr>
                   <td style="width:50%">
                       <table>
                           <!-- Seccion izquierda-->
                            
                           <tr>
                               <td style="height:40px">
                                   <asp:Label ID="Label34" runat="server" Text="Mis Créditos: "></asp:Label>&nbsp&nbsp
                               </td>
                               <td>
                                  <asp:Label ID="Label32" runat="server" Text="$" ForeColor="#003366" Font-Bold="true"></asp:Label>
                                    &nbsp;<asp:Label ID="lblCreditosP" runat="server" Text="Creditos" ForeColor="#003366" Font-Bold="true"></asp:Label> 
                               </td>
                           </tr>
                           <tr>
                               <td style="font-size:13px"><b>Mi lugar en el Ranking es: </b></td>
                               <td style="font-size:13px">&nbsp;<asp:Label runat="server" ID="lblRkCredPens" Font-Bold="true" ForeColor="Green"></asp:Label></td>
                           </tr>
                              
                       </table>
                  </td>
                   <td style="width:50%">
                       <!-- Seccion derecha-->
                       <center>
                            <asp:Label ID="lblCumpleMetaCredP" runat="server" Text="" Font-Size="20px" Font-Bold="true"></asp:Label>
                       
                       <br /><br />
                       
                       
                   </center>
                   </td>
               </tr>
           </table>
            <br /><br />
           </div>

            <asp:Label ID="Label36" runat="server" Text="estas a solo" Font-Bold="true"></asp:Label>&nbsp
            <asp:Label ID="lblDiasRest2" runat="server" Text="XXXX" Font-Bold="true" ForeColor="#ff6600"></asp:Label>&nbsp
            <asp:Label ID="Label40" runat="server" Text="días hábiles para el término del mes, animo y vamos por ese incentivo." Font-Bold="true"></asp:Label>
            <br /><br />
            </div>
        <div align="center"><a href="javascript:ventanaSecundaria('assets/img/Terminos y Condiciones.png')">
            <br /><br />
                   <img src="assets/img/ingresar.png"  width="90px" height="90px" /></a><br />
                    <asp:Label ID="Label41" runat="server" Text="Términos y condiciones " Font-Bold="true"></asp:Label>
        </div>
            <hr style="width:90%"/>
            </asp:Panel>
	</section>
	<!-- service-section-end -->
	<!-- blog-section-start -->
	<section class="blog section_padding text-center" id="trabajadores">
        <asp:Panel runat="server" ID="pnlTrabajadores" Visible="false">
		<div class="container">
			<div class="row" >
				<!--<div class="blog-title section-title wow flipInX" data-wow-delay="0.3s"> -->
					<h1>Créditos Trabajadores</h1>
                     <asp:Label ID="Label4" runat="server" ForeColor="#cc3300" Font-Bold="true" Text="Datos provisorios actualizados a la fecha del segmento Trabajador, los cuales serán confirmados al cierre del mes."></asp:Label>
					<p></p>
				<!-- </div> -->
			</div>
        </div>
        						
        <div class="container" align="left"> 
           
             <asp:Label ID="lblNombreTr" runat="server" Text="Nombre" Font-Bold="true" ForeColor="#ff6600"></asp:Label>
            <asp:Label ID="Label24" runat="server" Text=", a continuación podrás visualizar cómo va el otorgamiento de crédito<br/>  a nuestros afiliados trabajadores. Estos datos son válidos para la campaña ''PEC Segmento Trabajadores''."></asp:Label>
            
          <br /><br />
            <asp:Label ID="Label25" runat="server" Text="Detalle de mi resultado a la fecha" Font-Bold="true" ForeColor="#ff6600" Font-Size="20px"></asp:Label>
      <br />
            <div class="container">
           <table style="width:100%">
               <tr>
                   <td style="width:50%">
                       <table>
                           <!-- Seccion izquierda-->
                            
                           
                           <tr>
                               <td style="height:40px">
                                   <asp:Label ID="Label30" runat="server" Text="Mis Créditos: "></asp:Label>&nbsp&nbsp
                               </td>
                               <td>
                                   <asp:Label ID="Label12" runat="server" Text="$"  Font-Bold="true"></asp:Label>
                                   &nbsp;<asp:Label ID="lblCredT" runat="server" Text="Creditos"  Font-Bold="true"></asp:Label>
                                   </td>
                           </tr>
                           <tr>
                               <td style="font-size:13px"><b>Mi lugar en el Ranking es: </b></td>
                               <td style="font-size:13px">&nbsp;<asp:Label runat="server" ID="lblRkCredTr" Font-Bold="true" ForeColor="Green"></asp:Label></td>
                           </tr>
                              
                       </table>
                  </td>
                  <td style="width:50%">
                       <!-- Seccion derecha-->
                       <center>
                            <asp:Label ID="lblGanoT" runat="server" Text="" Font-Size="20px" Font-Bold="true"></asp:Label>
                       
                       <br /><br />
                       
                       
                   </center>
                   </td>
                              </tr>
                       </table>
                   </center>
                   </td>
               </tr>
           </table>
            <br /><br />
           </div>

            <asp:Label ID="Label37" runat="server" Text="a solo " Font-Bold="true"></asp:Label>
            <asp:Label ID="lblDiasRestT" runat="server" Text="XXXX" Font-Bold="true" ForeColor="#ff6600"></asp:Label>
            <asp:Label ID="Label39" runat="server" Text=" días hábiles para el término del mes, te contamos que:" Font-Bold="true"></asp:Label>
            <br /><br />
            
            <asp:Label ID="lblText1CredT" runat="server" Text="* Te Falta $" Font-Bold="true"></asp:Label>
            <asp:Label ID="lblCredRestT" runat="server" Text="XX" Font-Bold="true" ForeColor="#ff6600"></asp:Label> &nbsp
            <asp:Label ID="lblText2CredT" runat="server" Text="en otorgamiento de crédito para cumplir con el requisito <br/>" Font-Bold="true"></asp:Label>
      </div>
        <div align="center"><a href="javascript:ventanaSecundaria('assets/img/Terminos y Condiciones.png')">
                   <img src="assets/img/ingresar.png" width="90px" height="90px" /></a><br />
                    <asp:Label ID="Label14" runat="server" Text="Términos y condiciones " Font-Bold="true"></asp:Label>
        </div>
        <div align="center">
            <hr style="width:90%" />
        </div></asp:Panel>
         <asp:Panel runat="server" ID="plSeguros" Visible="False">
		<div class="container">
			<div class="row" >
				<!--<div class="blog-title section-title wow flipInX" data-wow-delay="0.3s"> -->
					<h1>Seguros</h1>
                     <asp:Label ID="Label9" runat="server" ForeColor="#ffffff" Font-Bold="true" Text="Datos provisorios actualizados a la fecha del segmento trabajadores, los cuales serán confirmados al cierre del mes."></asp:Label>
					<p></p>
			</div>
        </div>
               <div class="container" align="left"> 
           
             <asp:Label ID="lblNombre4" runat="server" Text="Nombre" Font-Bold="true" ForeColor="#ff6600"></asp:Label>
            <asp:Label ID="Label21" runat="server" Text=", a continuación podrás visualizar el detalle de tus ventas de seguros y ranking en que se encuentran actualmente:"></asp:Label>
            
          <br /><br />
            <asp:Label ID="Label26" runat="server" Text="Detalle de mi resultado a la fecha" Font-Bold="true" ForeColor="#ff6600" Font-Size="20px"></asp:Label><br /><br />
                   <asp:Label runat="server" Width="260px"></asp:Label>
                   <asp:Label runat="server" Width="120px" Text="Color" style="text-align:center" Font-Bold="true" Font-Size="16px"></asp:Label>
                   <asp:Label runat="server" Width="120px" Text="N° Seguros" style="text-align:center" Font-Bold="true" Font-Size="16px"></asp:Label>
                   <asp:Label runat="server" Width="120px" Text="Ranking" style="text-align:center" Font-Bold="true" Font-Size="16px"></asp:Label>
                   <br />
                   <asp:Label runat="server" Text="Segmento Ind. Pensionados:" Font-Size="17px" Font-Bold="true" Width="260px"></asp:Label>
                   <asp:Label runat="server" id="lblMiColorPens" Font-Size="15px" Width="120px" style="text-align:center"></asp:Label>
                   <asp:Label runat="server" id="lblMiSeguroPens"  Font-Size="15px" Width="120px" style="text-align:center"></asp:Label>
                   <asp:Label runat="server" id="lblMiRankPens"  Font-Size="15px" Width="120px" style="text-align:center"></asp:Label><br />
                    <asp:Label runat="server" Text="Segmento Ind. Trabajadores:" Font-Size="17px" Font-Bold="true" Width="260px"></asp:Label>
                   <asp:Label runat="server" id="lblMiColorTrab"  Font-Size="15px" Width="120px" style="text-align:center"></asp:Label>
                   <asp:Label runat="server" id="lblMiSeguroTrab"  Font-Size="15px" Width="120px" style="text-align:center"></asp:Label>
                   <asp:Label runat="server" id="lblMiRankTrab"  Font-Size="15px" Width="120px" style="text-align:center"></asp:Label><br />
                    <asp:Label runat="server" Text="Segmento seguros Cesantía:" Font-Size="17px" Font-Bold="true" Width="260px"></asp:Label>
                   <asp:Label runat="server" id="lblMiColorCes"  Font-Size="15px" Width="120px" style="text-align:center"></asp:Label>
                   <asp:Label runat="server" id="lblMiSeguroCes"  Font-Size="15px" Width="120px" style="text-align:center"></asp:Label>
                   <asp:Label runat="server" id="lblMiRankCes"  Font-Size="15px" Width="120px" style="text-align:center"></asp:Label><br />
               </div>
         </asp:Panel>
	</section>
   </asp:Panel><br /><br />
    <br /><asp:Panel runat="server" ID="panelNoAceptado">
        <center><asp:Label runat="server" Font-Bold="true"  ForeColor="#ff6600" Font-Size="23px" Text="Para ver tus Campañas debes aceptar la Toma de Conocimientos "></asp:Label>
    <br /><asp:Label runat="server" Text="Click aqui → " Font-size="21px"></asp:Label><u><a data-toggle="modal" href="Campañas.aspx#myModal2" style="font-size:20px">Toma de Conocimiento</a></u></center></asp:Panel>
    <!-- Modal TomaConocimiento --> 
    <center>
   <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal2" class="modal fade"  >
                        <div class="modal-content" style="width:1250px;">
                      <div class="modal-body">
                <asp:Panel runat="server" ID="panelRequisitos" Visible="false"  style="text-align:left">
                    &nbsp;&nbsp;&nbsp;<asp:Label runat="server" Font-Bold="true" Font-Size="18px">SUCURSAL: </asp:Label>
                    <asp:Label ID="lblSucursal3" runat="server" Font-Size="19px" ForeColor="#ff6600"></asp:Label>
                    <br />
                    &nbsp;
                    <asp:Label runat="server" Font-Bold="true" ForeColor="#ff6600" Font-Size="19px">Segmento Pensionado y Trabajador </asp:Label>
                       <!--<asp:Label id="lblSegmentoPensionado" runat="server" Font-Bold="true" ForeColor="#ff6600" Font-Size="19px"></asp:Label>-->
                    <br />
                    &nbsp;
                    <asp:Label runat="server" style="font-size:13px">Ganarán incentivo todos aquellos ejecutivos PEC y/o asesores de clientes que cumplan los requisitos asociados a su sucursal, de acuerdo a las siguientes condiciones: </asp:Label>
                    <br /><br />
                    <center>
                        <table class="myTable" style="width:480px">
                             <tr>
                                <th rowspan="2" style="color:#ff0000;border:0px" class="auto-style11">Condición "0"</th>
                                <th style="background-color:#555CC4;color:white" class="auto-style10">Afiliación Pensionados</th>
                                <th style="background-color:#555CC4;color:white" class="auto-style9">Crédito Pensionado MM$</th>
                                <th style="background-color:#555CC4;color:white" class="auto-style9">Crédito Trabajador MM$</th>
                            </tr>
                            <tr>
                                
                                <td><asp:Label runat="server" ID="lblMetaAfiPens2"></asp:Label></td>
                                <td><asp:Label runat="server" ID="lblMetaCredPend2"></asp:Label></td>
                                <td><asp:Label runat="server" ID="lblMinVenta"></asp:Label></td>
                            </tr>
                        </table><br />
                 <asp:Label runat="server" ID="Label8" Font-Bold="true" Font-Size="13px" style="color:#CF0303">IMPORTANTE: </asp:Label>
                <asp:Label runat="server" ID="lblImportante" Font-Bold="true" Font-Size="13px" style="color:#CF0303"></asp:Label>
                        <br />
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label20" Font-Size="13px" style="color:#CF0303;text-align:center" runat="server" font-Bold="true"  Text="- Si cumples al menos 2 de 3 metas individuales, se pagará $1.500.- pesos por meta cumplida."></asp:Label><br />
                    </center></asp:Panel>
                    <asp:Panel runat="server" ID="panel2" Visible="True"  style="text-align:left">
                          <hr style="width:95%" />
                    &nbsp;
                    <asp:Label runat="server" Text="*Considerar:" Font-Bold="true" style="color:#CF0303" Font-Size="15px"></asp:Label><br />
                     <table class="myTable"  style="font-size:12px;width:1150px">
                            <tr>
                                <th style="background-color:#555CC4;color:white;width:100px" >Para Afiliación</th>
                                <td style="text-align:left;width:1050px"" ><asp:Label runat="server" ID="Label7" Text="• Se consideran todas las afiliaciones Tradicionales o EXFFAA con un monto de pensión mayor a la PBS ($102.897.-)"></asp:Label></td>
                            </tr>
                            <tr>
                                <th style="background-color:#555CC4;color:white;width:100px" >Para Créditos</th>
                                
                                <td style="text-align:left;width:1050px"><asp:label runat="server" Text="•	La venta nueva de crédito de pensionados y con grabación de acuerdo a procedimiento (Que el crédito y la grabación sean grabados el mismo día y de manera correcta)<br />•	No se considera la venta de créditos sin interés ($30.000)<br />•	Se considera la venta nueva de crédito con relación cuota renta entre 5% y 25% tal como indica la normativa vigente. Por lo tanto, no se pagará incentivo por la venta nueva de crédito que exceda la relación cuota renta correspondiente para cada tramo.<br />•La venta nueva de crédito de trabajadores (incluye venta propia + Fuerza de venta interna)."></asp:Label></td>
                            </tr>
                        </table></asp:Panel>
                <center>
                <asp:Panel runat="server" ID="panelAceptacion" Visible="false" >        
                <asp:Label runat="server" id="lblTomaCon" font-Bold="true" style="font-size:15px" Text="Declaro haber Tomado Conocimiento y aceptado los mínimos de afiliación y venta incluidos en el presente instrumento *"></asp:Label>
                <br /><asp:CheckBox runat="server" id="chkAcepto" Text="Acepto condiciones" Font-Size="16px" /><br />
                <asp:Button runat="server" id="btnEnviar"  Text="Enviar" ></asp:Button>
                <br /><asp:Label ID="lblError2" runat="server" Font-Bold="true" ForeColor="red" Font-Size="13px"></asp:Label>
				    </asp:Panel>
                <asp:Panel runat="server" ID="panelMensaje" Visible="false" style="text-align:left">
                    <p>Se ha registrado tu respuesta.</p><br /> 
                <br /></asp:Panel>
                    </center>
		          </div></div></div>

    </center>
		          <!-- modal -->

</asp:Content>
