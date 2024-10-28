using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

using Inv.BusinessLogic;
using Inv.BusinessEntities;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Xml;


namespace Fac.UI.Win
{
    public partial class frmGuiaTransportista : frmBase
    {
        bool esVista = true;
        public frmGuiaTransportista() {
            InitializeComponent();
            
            crearColumnas();
            Oncargar();
            
        }
        public frmGuiaTransportista(frmMDI formularioPadre) {
            InitializeComponent();
            
            //HabilitarBotones(true, true, true, false, true, true, false);
            crearColumnas();
            Oncargar();
            
        }
        private fabcGuiasTransporte frmHijo { get; set; }
        private frmMDI frmParent { get; set; }
        public static frmGuiaTransportista Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmGuiaTransportista(formParent);
            _aForm = new frmGuiaTransportista(formParent);
            return _aForm;
        }
        private static frmGuiaTransportista _aForm;

        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a,
            cancelar_a, expmovi_a, importarMP;

        #region "Seguridad"
        private void accesobotonesperfil()
        {
                SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.CodModulo, 
                this.Name, out nuevo_a, out editar_a, out eliminar_a, out ver_a, out imprimir_a, 
                out refrescar_a, out importar_a, out vista_a, out guardar_a, out cancelar_a,
                out expmovi_a, out importarMP);
        }
        private void ComportarmientoBotones(string accion)
        {
            OcultarBotones();
            switch (accion)
            {
                case "cargar":
                    if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar); }
                    if (ver_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbVer); }
                    HabilitaBotonPorNombre(BaseRegBotones.cbbCopiar);
					HabilitaBotonPorNombre(BaseRegBotones.cbbImportar);
                    break;

                case "nuevo":
                    if (guardar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar); }
                    if (cancelar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar); }
                    break;

                case "editar":                                                            
                    if (guardar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar); }
                    if (cancelar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar); }
                    break;

                case "grabar":                    
                    if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar); }
                    break;

                case "cancelar":
                    if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    break;
            }

        }
        #endregion
        void crearColumnas() {
            RadGridView grilla = this.CreateGridVista(this.gridControl);
            //Fecha
            this.CreateGridColumn(this.gridControl, "Fecha", "FAC34FECHA", 0, "{0:dd/MM/yyyy}", 70, true, false, true);
            
             this.CreateGridColumn(this.gridControl, "FAC34SERIEGUIA", "FAC34SERIEGUIA", 0, "", 100, true, false, false);
            //Nro de coumento de Guia de transporte
            this.CreateGridColumn(this.gridControl, "N° Documento", "FAC34NROGUIA", 0, "", 100, true, false, true);

            //Destinatario
            this.CreateGridColumn(this.gridControl, "Cod.Destinatario", "FAC34DESCODEMP", 0, "", 100, true, false, false);
            this.CreateGridColumn(this.gridControl, "Destinatario", "FAC34DESDESEMP", 0, "", 150, true, false, true);
            
            //Domicilio del destinatario
            this.CreateGridColumn(this.gridControl, "Cod.Dom.Destinatario", "FAC34DESCODESTAB", 0, "", 100, true, false, false);
            this.CreateGridColumn(this.gridControl, "Dom.Destinatario", "FAC34DESDESESTAB", 0, "", 120, true, false, true);

            // Motivo de traslado
            this.CreateGridColumn(this.gridControl, "Cod.Motivo", "FAC34MOTRASLCOD", 0, "", 100, true, false, false);
            this.CreateGridColumn(this.gridControl, "Desc.Motivo", "FAC34MOTRASLDESC", 0, "", 100, true, false, true);
            
            //Detalle Motivo
            this.CreateGridColumn(this.gridControl, "Det.Motivo", "FAC34MOTRASLDESCEXTRA", 0, "", 100, true, false, true);

            //Tipo OC 
            this.CreateGridColumn(this.gridControl, "Cod.Tipo OC", "FAC34OCTIPCOD", 0, "", 100, true, false, false);
            this.CreateGridColumn(this.gridControl, "Tipo OC", "FAC34OCTIPDES", 0, "", 100, true, false, true);

            //Numero OC
            this.CreateGridColumn(this.gridControl, "Nro OC", "FAC34OCNRO", 0, "", 100, true, false, true);
            
            //Contenedor            
            this.CreateGridColumn(this.gridControl, "Contenedor", "FAC34CONTENEDOR", 0, "", 100, true, false, true);
            
            //Precinto
            this.CreateGridColumn(this.gridControl, "Precinto", "FAC34PRECINTO", 0, "", 100, true, false, true);
            this.CreateGridColumn(this.gridControl, "Tip Doc", "FAC01COD", 0, "", 100, true, false, false);
            this.CreateGridColumn(this.gridControl, "correlativo", "FAC34CORRELATIVOGUIA", 0, "", 100, true, false, false);


            // Estado de envio de Guias Electronicas
            
            this.CreateGridColumn(this.gridControl, "G.E Estado Envio", "GuiaElecEstadoEnvioaSUNAT", 0, "", 100, true, false, true);
            this.CreateGridColumn(this.gridControl, "G.E Estado SUNAT ", "GuiaElecEstadoSunat", 0, "", 150, true, false, true);
            this.CreateGridColumn(this.gridControl, "G.E Observacion", "GuiaElecObservaciones", 0, "", 220, true, false, true);

            
            
            this.CreateGridColumn(this.gridControl, "Cod.Estado proceso", "FAC34ESTADOPROCESOCOD", 0, "", 20, true, false, false);
            this.CreateGridColumn(this.gridControl, "G.F Estado", "GuiaFisicaEstado", 0, "", 100, true, false, true);
            this.CreateGridColumn(this.gridControl, "G.F Observacion", "GuiaFisicaObservacion", 0, "", 200, true, false, true);
            
            
            //campos ocultos
            this.CreateGridColumn(this.gridControl, "FAC34CLAVE", "FAC34CLAVE", 0, "", 100, true, false, false);
            
            this.CreateGridColumn(this.gridControl, "FAC34CODEMP", "FAC34CODEMP", 0, "", 100, true, false, false);
            //codigo de plantilla
            this.CreateGridColumn(this.gridControl, "Plantilla", "FAC03COD", 0, "", 100, true, false, false);
            //tipo de documento
                   
            this.CreateGridColumn(this.gridControl, "Unid.Transportista", "FAC34TRAYCODIGO",0, "", 70, true, false, false);
            this.CreateGridColumn(this.gridControl, "Transportista", "FAC34CHOFNOMBRE",0, "", 280, true, false, false);

            
            //Estado  del documento
            this.CreateGridColumn(this.gridControl, "Cod.Estado", "FAC34ESTADO", 0, "", 70, true, false, false);
            //this.CreateGridColumn(this.gridControl, "Estado", "FAC67DESESTADO", 0, "", 70, true, false, true);

            this.CreateGridColumn(this.gridControl, "Estado de llenado", "FAC34ESTADOLLENADO", 0, "", 100, true, false, false); // oculto
            
            
          
        }
		private void CrearColumnasImportacion() {

            RadGridView grilla = this.CreateGridVista(this.dgvImportacion);

            this.CreateGridColumn(grilla, "Empresa", "Empresa", 0, "", 70, true, false, false);
            this.CreateGridColumn(grilla, "Anio", "Anio", 0, "", 70, true, false, false);
            this.CreateGridColumn(grilla, "Mes", "Mes", 0, "", 70, true, false, false);
            this.CreateGridColumn(grilla, "Fila", "Contador", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "Item", "Item", 0, "", 70, true, false, false);
            this.CreateGridColumn(grilla, "CANTIDAD", "CANTIDAD", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "UNIMED", "UNIMED", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "PRODUCTO", "PRODUCTO", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "PESO", "PESO", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "FECHA", "FECHA", 0, "{0:dd/MM/yyyy}", 70, true, false, true);
            this.CreateGridColumn(grilla, "GUIA_SERIE", "GUIA_SERIE", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "GUIA_NRO", "GUIA_NRO", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "MOTIVO_DEL_TRASLADO", "MOTIVO_DEL_TRASLADO", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "DOMICILIO_DE_PARTIDA", "DOMICILIO_DE_PARTIDA", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "DOMICILIO_DE_DESTINO", "DOMICILIO_DE_DESTINO", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "CLIENTE_RUC", "CLIENTE_RUC", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "CLIENTE", "CLIENTE", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "TRANSPORTISTA_RUC", "TRANSPORTISTA_RUC", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "TRANSPORTISTA", "TRANSPORTISTA", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "LICENCIA_CONDUCTOR_NRO", "LICENCIA_CONDUCTOR_NRO", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "CONDUCTOR", "CONDUCTOR", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "VEHICULO_MARCA", "VEHICULO_MARCA", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "VEHICULO_PLACA", "VEHICULO_PLACA", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "REMOLQUE_MARCA", "REMOLQUE_MARCA", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "REMOLQUE_PLACA", "REMOLQUE_PLACA", 0, "", 70, true, false, true);            
            this.CreateGridColumn(grilla, "CONTRATISTA", "CONTRATISTA", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "LABOR", "LABOR", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "USUARIO", "USUARIO", 0, "", 70, true, false, true);

            string[] contadordecampos = { "Contador" };

            Util.AddGridSummaryCount(grilla, contadordecampos);

           
        }

        private void CrearColumnasValidacion() {
            RadGridView grilla = this.CreateGridVista(this.dgvValidacion);
            CreateGridColumn(grilla, "Fila", "Contador", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "USUARIO", "USUARIO", 0, "", 70, true, false, false);
            CreateGridColumn(grilla, "Errorcod", "Errorcod", 0, "", 120, true, false, true);
            CreateGridColumn(grilla, "Errordes", "Errordes", 0, "", 200, true, false, true);

            CreateGridColumn(grilla, "Empresa", "Empresa", 0, "", 70, true, false, false);
            CreateGridColumn(grilla, "Anio", "Anio", 0, "", 70, true, false, false);
            CreateGridColumn(grilla, "Mes", "Mes", 0, "", 70, true, false, false);
            
            CreateGridColumn(grilla, "Item", "Item", 0, "", 70, true, false, false);
            CreateGridColumn(grilla, "CANTIDAD", "CANTIDAD", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "UNIMED", "UNIMED", 0, "", 70, true, false, false);
            CreateGridColumn(grilla, "PRODUCTO", "PRODUCTO", 0, "", 70, true, false, false);
            CreateGridColumn(grilla, "PESO", "PESO", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "FECHA", "FECHA", 0, "{0:dd/MM/yyyy}", 70, true, false, true);
            CreateGridColumn(grilla, "GUIA_SERIE", "GUIA_SERIE", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "GUIA_NRO", "GUIA_NRO", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "MOTIVO_DEL_TRASLADO", "MOTIVO_DEL_TRASLADO", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "DOMICILIO_DE_PARTIDA", "DOMICILIO_DE_PARTIDA", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "DOMICILIO_DE_DESTINO", "DOMICILIO_DE_DESTINO", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "CLIENTE_RUC", "CLIENTE_RUC", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "CLIENTE", "CLIENTE", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "TRANSPORTISTA_RUC", "TRANSPORTISTA_RUC", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "TRANSPORTISTA", "TRANSPORTISTA", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "LICENCIA_CONDUCTOR_NRO", "LICENCIA_CONDUCTOR_NRO", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "CONDUCTOR", "CONDUCTOR", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "VEHICULO_MARCA", "VEHICULO_MARCA", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "VEHICULO_PLACA", "VEHICULO_PLACA", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "REMOLQUE_MARCA", "REMOLQUE_MARCA", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "REMOLQUE_PLACA", "REMOLQUE_PLACA", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "CONTRATISTA", "CONTRATISTA", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "LABOR", "LABOR", 0, "", 70, true, false, true);

            string[] contadordecampos= { "Contador" };

            Util.AddGridSummaryCount(grilla, contadordecampos);


           
        }
        private void CargarImportacion() {
            try
            {

                var lista = Fac_GuiaTransporteLogic.Instance.TraeGuiasImportadas(Logueo.CodigoEmpresa, Logueo.UserName);
                this.dgvImportacion.DataSource = lista;
            }
            catch (Exception ex) {
                
                Util.ShowError("Error :" + ex.Message);
            }
        }
        
        public void Oncargar()
        {
            try
            {
                var lista = Fac_GuiaTransporteLogic.Instance.TraerGuiasTransporte(Logueo.CodigoEmpresa, Logueo.Anio,
                    Logueo.Mes, "", "*");
                this.gridControl.DataSource = lista;

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al listar guias de transporte:" + ex.Message);
            }
        }
        public void RefrescarEstadoProceso() 
        {
            string tipdoc = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC01COD");
            string guia_numero = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC34CORRELATIVOGUIA");
            string serie = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC34SERIEGUIA");
            string guia_id = serie + "-" + guia_numero;

            DataTable dt = Efact_GuiaLogic.Instance.Traer_EstadoProceso(Logueo.CodigoEmpresa,Logueo.Anio, Logueo.Mes);
          
               string fac34nroguia = "";
               string ticket = "";
                //Encontrar match con la grilla y el SP
                foreach (DataRow row in dt.Rows)
                {
                     fac34nroguia = row["serieNumero"].ToString();
                     ticket = row["ticket"].ToString();

                        GET_CDR(ticket, fac34nroguia);
                }

            Oncargar();
            
       
        }
        public class Code
        {
            public string code { get; set; }
            public string description { get; set; }

        }
         //POST TOKEN
        public dynamic POST_TOKEN()
        {
            dynamic contenido = string.Empty;

            string access_token = "";
            try
            {


                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.1
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                DataTable dt = Efact_GuiaLogic.Instance.Traer_EFACT_SERVICIOSAPI("URL_para_obtener_el_token_POST");
                string urlpost1 = dt.Rows[0]["URL"].ToString();

                DataTable usuario = Efact_GuiaLogic.Instance.Traer_EFACT_SERVICIOSAPI("USUARIO_EFACT");
                DataTable password = Efact_GuiaLogic.Instance.Traer_EFACT_SERVICIOSAPI("CONTRASENA_EFACT");
                string usuariodt = usuario.Rows[0]["URL"].ToString();
                string passwordt = password.Rows[0]["URL"].ToString();

                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                HttpWebRequest solicitud = (HttpWebRequest)HttpWebRequest.Create(urlpost1);
                //string dataq = "username=20420310383&password=53c418a1e7dc6fbf8c0b3ae42ea210e388da9598bec6203264f7860c3475e7d1&grant_type=password";
                solicitud.Method = "POST";
                solicitud.Accept = "*/*";
                solicitud.ContentType = "application/x-www-form-urlencoded";
                solicitud.Headers["Authorization"] = "Basic Y2xpZW50OnNlY3JldA==";
                string json = "username=" + usuariodt + "&password=" + passwordt + "&grant_type=password";
                byte[] data = Encoding.UTF8.GetBytes(json);
                solicitud.ContentLength = data.Length;
                using (Stream stream = solicitud.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                using (WebResponse response = solicitud.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            string responseFromServer = reader.ReadToEnd();

                            string token_String = responseFromServer.ToString();
                            dynamic deserealizar = JsonConvert.DeserializeObject(token_String);
                            access_token = deserealizar.access_token;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ===> " + ex);
            }
            return access_token;
        }
         // END TOKEN
        public void GET_CDR(string ticket,string numeroguia)
        {
            string guia_tipo = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC01COD");
            string guia_numero = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC34CORRELATIVOGUIA");
            string serie = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC34SERIEGUIA");
            string guia_id = serie + "-" + guia_numero;
            string tipdocemisor = "6"; //logueo.RucEmpresa;
            string numerodumentoemisor = Logueo.RucEmpresa;

            string code = "";
            string description = "";
            string mensaje = "";
            int flag = 1;
            string mensajesunat = "";
            Code deserealizar = new Code();
            string date = "";
            try
            {
                DataTable dt = Efact_GuiaLogic.Instance.Traer_EFACT_SERVICIOSAPI("URL_metodo_para_obtener_el_CDR");
                string url = dt.Rows[0]["URL"].ToString() + ticket;
                //string url = "https://ose-qa-rest.efact.pe/api-efact-ose/v1/cdr/" + ticket;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                string access_token = POST_TOKEN();
                request.Method = "GET";
                request.Accept = "*/*";
                request.Headers.Add("Authorization", "Bearer " + access_token);



                using (HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream respuestaStream = respuesta.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(respuestaStream);
                        string contenido = reader.ReadToEnd();
                        string responseserver = contenido.ToString();
                        //VER ESTADOS :: EFACT
                        HttpStatusCode statuscode = ((HttpWebResponse)respuesta).StatusCode;
                        int estadoapi = (int)statuscode;

                        if (estadoapi == 200)//GUIA ACEPTADA ::OK
                        {
                            code = GetXmlValue(contenido, "cbc:ResponseCode");
                            mensajesunat = GetXmlValue(contenido, "cbc:Description");
                            // deserealizar.code = estadoapi.ToString();
                            deserealizar.description = description;
                            deserealizar.code = code;
                            string XmlSunat = responseserver;
                            //(exdescription, 1);
                            string Metodo = "GET_CDR";
                            Efact_GuiaLogic.Instance.Insertar_EfactResponse(tipdocemisor, numerodumentoemisor, guia_tipo, numeroguia, code, ticket, mensajesunat, XmlSunat, Metodo, "ACEPTADA", out flag, out mensaje);
                            Util.ShowMessage("Se actualizon las guias",1);
                            
                            //MessageBox.Show(mensajesunat);

                        }


                        else // registrar estado en proceso
                        {
                            deserealizar = JsonConvert.DeserializeObject<Code>(responseserver);
                            code = deserealizar.code;
                            description = deserealizar.description;
                            date = DateTime.Now.ToString();
                            string metodo = "GET_CDR";
                            Efact_GuiaLogic.Instance.Insertar_EfactErrorLog(numerodumentoemisor, numeroguia, guia_tipo, tipdocemisor, code, description, date, metodo, out flag, out mensaje);
                            Efact_GuiaLogic.Instance.Insertar_EfactResponse(tipdocemisor, numerodumentoemisor, guia_tipo, numeroguia, code, ticket, "ERROR:: GET_CDR", "", metodo, "EN PROCESO", out flag, out mensaje);
                            
                            //Util.ShowMessage(exdescription, 1);
                            //MessageBox.Show(description);
                        }
                    }
                }

            }

            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (HttpWebResponse response = (HttpWebResponse)ex.Response)
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                string responseFromServer = reader.ReadToEnd();
                                string token_String = responseFromServer.ToString();
                                deserealizar = JsonConvert.DeserializeObject<Code>(token_String);
                                code = deserealizar.code;
                                description = deserealizar.description;
                                string metodo = "GET_CDR";
                                date = DateTime.Now.ToString();
                                string Mensaje = "";
                                //if (code == "1033")
                                //{
                                //   int valorestado = 0;
                                //    TicketVerdadero_GETCDR();

                                //    if(valorestado == 1)
                                //     {
                                //      return deserealizar;
                                //     }

                                //}
                                Efact_GuiaLogic.Instance.Insertar_EfactErrorLog(numerodumentoemisor, numeroguia, guia_tipo, tipdocemisor, code, description, date, metodo, out flag, out Mensaje);
                                Efact_GuiaLogic.Instance.Insertar_EfactResponse(tipdocemisor, numerodumentoemisor, guia_tipo, numeroguia, code, ticket, "ERROR:: GET_CDR", "", metodo, "ERROR EN SUNAT", out flag, out mensaje);
                                
                                //MessageBox.Show(exdescription);
                                //Util.ShowMessage(description, 1);

                            }
                        }
                    }
                }

            }
        }
        //GET CDR
        public static string GetXmlValue(string xml, string elementName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(elementName);
            if (nodeList.Count > 0)
            {
                XmlNode node = nodeList[0];
                return node.InnerText;
            }

            return null;
        }


        private RadContextMenu menuEstadoProceso = new RadContextMenu();
        private void frmGuiaTransportista_Load(object sender, EventArgs e)
        {
            Oncargar();
            OcultarBotones();
            OcultarCopiaGuia();
            VerVentanaEstadoDocumento(false);
            CargarPeriodos();
            accesobotonesperfil();
            HabilitaBotonPorNombre(BaseRegBotones.cbbRefrescar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);


            HabilitaBotonPorNombre(BaseRegBotones.cbbCamEst);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVer);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVista);
            HabilitaBotonPorNombre(BaseRegBotones.cbbImprimir);

            HabilitaBotonPorNombre(BaseRegBotones.cbbCopiar);
			HabilitaBotonPorNombre(BaseRegBotones.cbbImportar);
            RadMenuItem itmGuiaEnProceso = new RadMenuItem("En proceso");
            RadMenuItem itmGuiaEmitido = new RadMenuItem("Emitido");
            RadMenuItem itmGuiaAceptado = new RadMenuItem("Aceptado");
            

            itmGuiaEnProceso.Name = "itmGuiaEnProceso";
            itmGuiaAceptado.Name = "itmGuiaAceptado";
            itmGuiaEmitido.Name = "itmGuiaEmitido";

            itmGuiaEnProceso.Click += new EventHandler(itmAplicarProceso_Click);
            itmGuiaAceptado.Click += new EventHandler(itmAplicarProceso_Click);
            itmGuiaEmitido.Click += new EventHandler(itmAplicarProceso_Click);

            menuEstadoProceso.Items.Add(itmGuiaEnProceso);
            menuEstadoProceso.Items.Add(itmGuiaEmitido);
            menuEstadoProceso.Items.Add(itmGuiaAceptado);

            int ancho = (this.ClientSize.Width) / 2;
            int alto = (this.ClientSize.Height) / 2;

            popupEstadoDocumento.Location = new Point(ancho + this.popupEstadoDocumento.Width, alto);

            ComportarmientoBotones("cargar");

			//crear columna importar
            CrearColumnasImportacion();
            CrearColumnasValidacion();
            
            
            //ocultar la ventana de importar por defecto al iniciar el formulario
            this.popupImportar.Hide();

        }
        void itmAplicarProceso_Click(object sender, EventArgs e)
        {
            string codigoProcesoDoc = "";
            string nombreControl = ((RadMenuItem)(sender)).Name;
            string anteriorProcesoDoc = Util.GetCurrentCellText(gridControl, "FAC34ESTADOPROCESOCOD");
            
            
            if (nombreControl == "itmGuiaEnProceso")
            {
                codigoProcesoDoc = "01";
            }
            else if (nombreControl == "itmGuiaEmitido")
            {
                codigoProcesoDoc = "02";
            }
            else if (nombreControl == "itmGuiaAceptado")
            {
                codigoProcesoDoc = "03";
                VerVentanaEstadoDocumento(true);
            }

            if (codigoProcesoDoc != "03")
            {
                if (anteriorProcesoDoc != codigoProcesoDoc)
                {
                    ActualizarEstadoGuia(codigoProcesoDoc);
                }
            }
            
        }
        
        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (gridControl.RowCount == 0) return;
            var celda = gridControl.CurrentRow.Cells;

            if (celda["FAC34NROGUIA"].Value == null)
            {
                MessageBox.Show("El registro seleccionado no tiene numero de guia", "Sistema", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            string cod = gridControl.CurrentRow.Cells["FAC34NROGUIA"].Value.ToString();
            
            var instancia = fabcGuiasTransporte.Instance(this);
            instancia.Estado = FormEstate.View;
            var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is fabcGuiasTransporte);

            if (frmexiste != null)
            {
                instancia.BringToFront();

                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            instancia.indice = gridControl.CurrentRow.Index;
            instancia.codigoGuia = cod;

            instancia.MdiParent = this.ParentForm;
            ((RadDock)(ctrl)).ActivateMdiChild(instancia);
            instancia.Show();
          
        }

        private void frmGuiaTransportista_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void frmGuiaTransportista_Enter(object sender, EventArgs e)
        {            
            //Oncargar();      
        }
        
        private void gridControl_DoubleClick(object sender, EventArgs e)
        {
            if (gridControl.Rows.Count == 0) {
                var instancia = fabcGuiasTransporte.Instance(this);
                instancia.Estado = FormEstate.View;
                var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is fabcGuiasTransporte);

                if (frmexiste != null)
                {
                    instancia.BringToFront();

                    return;
                }
                Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
                instancia.MdiParent = this.ParentForm;
                ((RadDock)(ctrl)).ActivateMdiChild(instancia);
                instancia.Show();
            }
        }
        private void ActualizarEstadoGuia(string codigoActualProceso)
        {

            try
            {
                //string estadodeproceso = "01";

                // 1. Obtener los registros seleccionados de la grilla.
                string estadoproceso = "", estadoprocesoactual = "",clavebusqueda="";
                string[] lista = new string[gridControl.SelectedRows.Count];


                clavebusqueda = Util.GetCurrentCellText(gridControl.SelectedRows[0], "FAC34CLAVE");
                estadoproceso = Util.GetCurrentCellText(gridControl.SelectedRows[0], "FAC34ESTADOPROCESOCOD");
                

                int x = 0;
                for (x = 0; x < gridControl.SelectedRows.Count; x++)
                {

                    estadoprocesoactual = Util.GetCurrentCellText(gridControl.SelectedRows[x], "FAC34ESTADOPROCESOCOD");
                    if (estadoproceso != estadoprocesoactual)
                    {
                        Util.ShowAlert("Debe seleccionar registro con el mismo estado de proceso");
                        return;
                    }
                    lista[x] = Logueo.CodigoEmpresa + "|" +
                               Util.GetCurrentCellText(gridControl.SelectedRows[x], "FAC01COD") + "|" +
                               Util.GetCurrentCellText(gridControl.SelectedRows[x], "FAC34NROGUIA");

                    Logueo.rowselectedbyuser[x] = Logueo.CodigoEmpresa +
                                Util.GetCurrentCellText(gridControl.SelectedRows[x], "FAC01COD") +
                                Util.GetCurrentCellText(gridControl.SelectedRows[x], "FAC34NROGUIA");
                }
                Logueo.countofrowsselectedbyuser = x;
                // 2.Ejecutar el procedimiento
                string xml = Util.ConvertiraXMLdinamico(lista);

                string fechaEstadoProceso = dtpFechaEstadoDoc.Text;
                string observacionEstadoProceso = txtObservacionEstadoDoc.Text;
                string horaEstadoProceso = txtHoraEstadoDoc.Text;

                //Validar la lectura de hora cuando es proceso de 03 -  Aceptado
                if (codigoActualProceso == "01" || codigoActualProceso == "02")
                {
                    horaEstadoProceso = "";
                }


                if (codigoActualProceso == "03")
                {
                    string hora = horaEstadoProceso.Substring(0, 2);
                    string minutos = horaEstadoProceso.Substring(3, 2);

                    if (Util.ValidarHora(hora) == false)
                    {
                        Util.ShowError("Validar hora"); return;
                    }

                    if (Util.ValidarMinuto(minutos) == false)
                    {
                        Util.ShowError("Validar minutos");
                        return;
                    }
                }
                
                string str_mensaje = "";                
                int int_flag = 0;
                      

                estadoproceso = codigoActualProceso;
                //Actualizar los estados de los documentos seleccionados
                Fac_GuiaTransporteLogic.Instance.ActualizarEstadoProceso(xml, estadoproceso, observacionEstadoProceso,
                fechaEstadoProceso, horaEstadoProceso, "P", out int_flag, out str_mensaje);

                Util.ShowMessage(str_mensaje, int_flag);
                //3.Guardar la lista de filas afectados por el proceso
                //GridViewSelectedRowsCollection rowsselectedbyuser = gridControl.SelectedRows;



                if (int_flag == 1)
                {
                    Oncargar();
                    VerVentanaEstadoDocumento(false);
                }

                gridControl.ClearSelection();

                Util.enfocarFila(gridControl, "FAC34CLAVE", clavebusqueda);

                //// 4.Resalta las filas seleccionados 
                //for (int z = 0; z < Logueo.countofrowsselectedbyuser; z++)
                //{

                //    string codigodebusqueda = Logueo.rowselectedbyuser[z].ToString();
                //    Util.OnEnfocarRegistro(gridControl, codigodebusqueda, "FAC34CLAVE");
                //}

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al actualido estado guia ." + ex.Message);
            }
        }
        
       
        
        protected override void OnNuevo()
        {
            var instancia = fabcGuiasTransporte.Instance(this);
            instancia.Estado = FormEstate.New;
            var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is fabcGuiasTransporte);

            if (frmexiste != null)
            {
                instancia.BringToFront();

                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];            
            instancia.MdiParent = this.ParentForm;
     
            ((RadDock)(ctrl)).ActivateMdiChild(instancia);
            instancia.Show();
            
        }
        protected override void OnEditar()
        {
            if (gridControl.RowCount == 0) return;
            var instancia = fabcGuiasTransporte.Instance(this);
            instancia.Estado = FormEstate.Edit;
            var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is fabcGuiasTransporte);

            if (frmexiste != null)
            {
                instancia.BringToFront();

                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            instancia.codigoGuia = gridControl.CurrentRow.Cells["FAC34NROGUIA"].Value.ToString();
            string EstadoProcesoSUNAT = gridControl.CurrentRow.Cells["GuiaElecEstadoSunat"].Value.ToString();
            string EstadoEnvioASunat = gridControl.CurrentRow.Cells["GuiaElecEstadoEnvioaSUNAT"].Value.ToString();
            //string GuiaElecObservaciones = gridControl.CurrentRow.Cells["GuiaElecObservaciones"].Value.ToString();
            if (EstadoProcesoSUNAT == "ACEPTADA" && EstadoEnvioASunat == "ENVIADA")
            {
                Util.ShowMessage("No se puede Editar una guia ya enviada y aceptada por la SUNAT", 1);
                return;
            }
            else
            {
                instancia.MdiParent = this.ParentForm;

                ((RadDock)(ctrl)).ActivateMdiChild(instancia);
                instancia.Show();
            }
        }
        //boton de vista previa de imprimir
        protected override void OnVista()
        {
            if (gridControl.RowCount == 0) return;
            string tipdoc = string.Empty;
            string nroguia = string.Empty;

            string plantillaAct = string.Empty;

            string plantillaUlt = string.Empty;
            //if (gridControl.Rows.Count == 0)
            //{
            //    MessageBox.Show("No tiene registros");
            //    return;
            //}
            var codigosSeleccionados = new string[gridControl.SelectedRows.Count];
            var x = 0;

            foreach (var filaSeleccionado in gridControl.SelectedRows)
            {
                //09 guia de transportista
               
                 tipdoc = filaSeleccionado.Cells["FAC01COD"].Value.ToString();
                 nroguia = filaSeleccionado.Cells["FAC34NROGUIA"].Value.ToString();
                codigosSeleccionados[x] = tipdoc + nroguia;
          
                plantillaAct = filaSeleccionado.Cells["FAC03COD"].Value.ToString();
                
                x++;
                
                if ( x > 1 && plantillaAct != plantillaUlt)
                {
                    MessageBox.Show("::ERROR : Los documentos seleccionados debe ser del mismo codigo de plantilla.");
                    return;
                }
                plantillaUlt = plantillaAct;
            }
            Cursor.Current = Cursors.WaitCursor;

            
            DataTable datosGuia = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Rep_Guias(Logueo.CodigoEmpresa,
                                                                                       Util.ConvertiraXML(codigosSeleccionados));
            

            Reporte reporte = new Reporte("Guia");
            reporte.Ruta = Logueo.GetRutaReporte();
            if (datosGuia.Rows.Count == 0)
            {
                MessageBox.Show("La guia no contiene detalle");
                return;
            }
            if (datosGuia.Rows[0]["FAC03COD"].ToString() == "01")
            {
                reporte.Nombre = "RptGuiasExportacion.rpt";
            }
            else if (datosGuia.Rows[0]["FAC03COD"].ToString() == "02")
            {
                reporte.Nombre = "RptGuiasNacional.rpt";
            }
            else if (datosGuia.Rows[0]["FAC03COD"].ToString() == "03")
            {
                reporte.Nombre = "RptGuiasObras.rpt";
            }

            reporte.DataSource = datosGuia;

            ReporteControladora control = new ReporteControladora(reporte);
            if (esVista)
            {
                control.VistaPrevia(enmWindowState.Normal);
            }
            else {
                control.Imprimir();
            }
            Cursor.Current = Cursors.Default;
            esVista = true;
        }
        protected override void OnImprimir()
        {
            esVista = false;
            OnVista();

        }
        
        protected override void OnVer()
        {
            if (gridControl.RowCount == 0) return;
            var celda = gridControl.CurrentRow.Cells;

            if (celda["FAC34NROGUIA"].Value == null)
            {
                MessageBox.Show("El registro seleccionado no tiene numero de guia", "Sistema", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            
            var instancia = fabcGuiasTransporte.Instance(this);
            instancia.Estado = FormEstate.View;
            var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is fabcGuiasTransporte);

            if (frmexiste != null)
            {
                instancia.BringToFront();

                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            instancia.indice = gridControl.CurrentRow.Index;
            instancia.codigoGuia = gridControl.CurrentRow.Cells["FAC34NROGUIA"].Value.ToString();
            instancia.MdiParent = this.ParentForm;
            
        
            ((RadDock)(ctrl)).ActivateMdiChild(instancia);
            instancia.Show();
        }
         protected override void OnEliminar()
        {
            if (gridControl.RowCount == 0) return;
            int indice = 0;
            string msj = string.Empty;
            int flag = 1;

            DialogResult respuesta = MessageBox.Show("Desea eliminar el documento", "Sistema", MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            string tipdoc = gridControl.CurrentRow.Cells["FAC01COD"].Value.ToString();
            string numerodoc = gridControl.CurrentRow.Cells["FAC34NROGUIA"].Value.ToString();
            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {

                Fac_GuiaTransporteLogic.Instance.Spu_Fact_Del_FAC34_GUIAREMISION(Logueo.CodigoEmpresa,
                    tipdoc, numerodoc,out flag, out msj);
                MessageBox.Show(msj, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                
                indice = this.gridControl.MasterView.CurrentRow.Index;
                Oncargar();
                if (indice > 0)
                {
                    gridControl.MasterView.Rows[indice - 1].IsSelected = true;
                    gridControl.MasterView.Rows[indice - 1].IsCurrent = true;
                }
            }            
            //refresco los datos de la grilla
           
        }
        protected override void OnCambiar()
        {
            if (gridControl.RowCount == 0) return;
            var celda = gridControl.CurrentRow.Cells;

            if (celda["FAC34NROGUIA"].Value == null)
            {
                MessageBox.Show("El registro seleccionado no tiene numero de guia", "Sistema", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            var instancia = fabcGuiasTransporte.Instance(this);
            instancia.Estado = FormEstate.ChangeState;
            var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is fabcGuiasTransporte);

            if (frmexiste != null)
            {
                instancia.BringToFront();

                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            instancia.codigoGuia = gridControl.CurrentRow.Cells["FAC34NROGUIA"].Value.ToString();
            instancia.MdiParent = this.ParentForm;
            
            ((RadDock)(ctrl)).ActivateMdiChild(instancia);
            instancia.Show();
        }
        protected override void OnRefrescar() 
        {

            
            RefrescarEstadoProceso();
            Oncargar();
            Cursor.Current = Cursors.AppStarting;
            Util.ShowMessage("Lista Actualizada",1);
        
        }

        //boton para copiar los documentos seleccionados
        protected override void OnCopiar()
        {
            MostrarCopiaGuia();
        }

        private void gridControl_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            GridDataCellElement cell = e.ContextMenuProvider as GridDataCellElement;
            if (cell == null)
            {
                return;
            }
            //set the first context menu to be displayed for cells in the second column   

            //Util.GetCurrentCellText(gridControl, "FAC34ESTADOPROCESOCOD");

            if (cell.ColumnInfo.Name == "GuiaFisicaEstado")
            {
                e.ContextMenu = menuEstadoProceso.DropDown;
            }
            else {
                e.Cancel = false;
            }
            //if (cell.ColumnIndex == 1)
            //{

            //    e.ContextMenu = menuEstadoProceso.DropDown;
            //}
            
        }

        private void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            
            if(gridControl.RowCount == 0) return;
            try
            {

                GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
                if (cellElement == null) return;

                if (e.CellElement.ColumnInfo is GridViewCommandColumn)
                {

                    RadButtonElement commandButton = ((RadButtonElement)((GridCommandCellElement)e.CellElement).Children[0]);

                    if (Util.convertiracadena(gridControl.Rows[e.RowIndex].Cells["FAC34OCNRO"].Value) != "")
                    {
                        //habilitarBotonProdDet(e.Column.Name, cellElement, true);
                        e.CellElement.DrawFill = true;
                        e.CellElement.ForeColor = Color.Red;
                        e.CellElement.NumberOfColors = 1;
                        e.CellElement.BackColor = Color.Yellow;
                    }
                    else
                    {
                        //habilitarBotonProdDet(e.Column.Name, cellElement, false);
                        e.CellElement.DrawFill = true;
                        e.CellElement.ForeColor = Color.Yellow;
                        e.CellElement.NumberOfColors = 1;
                        e.CellElement.BackColor = Color.Green;
                    }
                }
                //if (e.CellElement.ColumnInfo.Name == "FAC34OCNRO")
                //{
                //    e.CellElement.DrawFill = true;
                //    e.CellElement.ForeColor = Color.Red;
                //    e.CellElement.NumberOfColors = 1;
                //    e.CellElement.BackColor = Color.Yellow;
                //}
                //else
                //{
                //    e.CellElement.DrawFill = true;
                //    e.CellElement.ForeColor = Color.Yellow;
                //    e.CellElement.NumberOfColors = 1;
                //    e.CellElement.BackColor = Color.Green;
                //}
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
            
        }

        private void gridControl_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {

        }
        #region "Copiar documento"
        private void CargarPeriodos()
        {
            try
            {
                var periodo = PeriodoLogic.Instance.PeriodoTraerTodos(Logueo.CodigoEmpresa);
                cboCopiarPeriodo.DataSource = periodo;
                cboCopiarPeriodo.DisplayMember = "ccb03des";
                cboCopiarPeriodo.ValueMember = "ccb03cod";


                string anio = "";
                string mes = "";

                mes = DateTime.Now.Month.ToString("0#");
                anio = DateTime.Now.Year.ToString();

                cboCopiarPeriodo.SelectedValue = anio + mes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void MostrarCopiaGuia()
        {
            string str_CodigoDocumento = "";
            //gpxCopiar.Show();
            //gpxCopiar.BringToFront();
            popupCopiarDoc.BringToFront();
            popupCopiarDoc.Visible = true;

            string tipdoc = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC01COD");
            string serie = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC34SERIEGUIA");
            string fechaDocumentoOrigen = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC34FECHA");
            txtCopiarSerie.Text = serie;
            string nroGuia = string.Empty;            

            Fac_GuiaTransporteLogic.Instance.DameNroDocumentoGuia(Logueo.CodigoEmpresa, tipdoc, serie, out nroGuia);
            txtCopiarDocNro.Text = nroGuia;

            

            dtpCopiarFecha.Value = Convert.ToDateTime(fechaDocumentoOrigen);
        }
        private void OcultarCopiaGuia()
        {
            //gpxCopiar.Hide();
            //gpxCopiar.SendToBack();
            popupCopiarDoc.SendToBack();
            popupCopiarDoc.Visible = false;
            txtCopiarSerie.Text = ""; txtCopiarDocNro.Text = "";
            dtpCopiarFecha.Value = DateTime.Now;
        }
        //boton para copiar los documentos seleccionados
    
       
        private void btnGuardarCopia_Click(object sender, EventArgs e)
        {
            string mesDocCopiar, nroGuiaOrigen, str_mensaje;
            int int_flag = 0;

            mesDocCopiar = ""; nroGuiaOrigen = ""; str_mensaje = "";

            nroGuiaOrigen = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC34NROGUIA");
            mesDocCopiar = cboCopiarPeriodo.SelectedValue.ToString();
            
            try
            {

                if (validar_fecha_vs_periodo(dtpCopiarFecha.Value, mesDocCopiar) == true)
                {
                    return;
                }
                if (txtCopiarDocNro.Text.Trim() == "")
                {
                    Util.ShowAlert("Ingrese Nro Factura"); return;
                }
                if (dtpCopiarFecha.Text == "")
                {
                    Util.ShowAlert("Fecha no Valida"); return;
                }
                if (txtCopiarSerie.Text == "")
                {
                    Util.ShowAlert("Ingrese serie"); return;
                }
                string tipoDeDocumento = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC01COD");
                Cursor.Current = Cursors.WaitCursor;
                // Asigno el procedimiento para guardar la copia
                DocumentoLogic.Instance.CopiarGuiaRemision(Logueo.CodigoEmpresa, tipoDeDocumento,
                    nroGuiaOrigen, txtCopiarSerie.Text.Trim(), txtCopiarDocNro.Text.Trim(),
                    Logueo.Anio, mesDocCopiar.Substring(4, 2), dtpCopiarFecha.Text,
                    out int_flag, out str_mensaje);
                Cursor.Current = Cursors.Default;
                if (int_flag == 1)
                {
                    
                    Util.ShowMessage(str_mensaje, int_flag);
                    Cursor.Current = Cursors.WaitCursor;
                    Oncargar();
                    string nuevoNroGuia = txtCopiarSerie.Text.Trim() + "-" + txtCopiarDocNro.Text.Trim();
                    
                    Util.enfocarFila(gridControl, "FAC34NROGUIA", nuevoNroGuia);
                    
                    OcultarCopiaGuia();
                    OnEditar();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Util.ShowAlert(str_mensaje);
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);

            }
        }
        
        private void btnCancelarCopia_Click(object sender, EventArgs e)
        {
            OcultarCopiaGuia();
        }
        bool validar_fecha_vs_periodo(DateTime fecha, string periodactivo)
        {

            string mesdefecha, aniodefecha;
            //inicializo la funcion
            bool bandera = false;
            mesdefecha = fecha.Month.ToString();
            if (mesdefecha.Length == 2)
            {
                mesdefecha = fecha.Month.ToString();
            }
            else
            {
                mesdefecha = "0" + mesdefecha;
            }
            aniodefecha = fecha.Year.ToString();
            if (Convert.ToDouble(aniodefecha + mesdefecha) == Convert.ToDouble(periodactivo))
            {
                //bandera = true;
            }
            else
            {
                if (Convert.ToDouble(aniodefecha + mesdefecha) > Convert.ToDouble(periodactivo))
                {
                    MessageBox.Show("Error: Fecha no valida \n Posiblemente Sea De Un Periodo Posterior Al Periodo Actual \n DEBE CORREGIR LA FECHA PARA SEGUIR TRABAJANDO ",
                        "Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    bandera = false;
                }
                else
                {
                    if (MessageBox.Show("Error: Fecha no valida\n Posiblemente Sea De Un Periodo Anterior Al Periodo Actual\n ¿ESTA SEGURO QUE LA FECHA QUE ESTA INGRESANDO ES CORRECTA?", "Sistema", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                    {
                        bandera = false;
                    }
                    else
                    {
                        bandera = true;
                    }
                }
            }
            return bandera;

        }
        #endregion
        #region "Aceptar documento"
        private void limpiarControlEstadoDocumento()
        {
            txtObservacionEstadoDoc.Text = "";
            dtpFechaEstadoDoc.SetToNullValue();
            //txtHoraEstadoDoc.Text = "";
            txtHoraEstadoDoc.Value = null;
        }

        private void VerVentanaEstadoDocumento(bool valor)
        {

            try
            {
                if (valor == false)
                {
                    popupEstadoDocumento.Visible = false;
                    popupEstadoDocumento.SendToBack();

                }
                else
                {
                    popupEstadoDocumento.Visible = true;
                    popupEstadoDocumento.BringToFront();
                }

                //Personaliza titulo de ventan del documento a procesar
                radLabel1.Text = "Aceptar Guia:" +
                                  Util.GetCurrentCellText(gridControl.CurrentRow, "FAC34NROGUIA");

                limpiarControlEstadoDocumento();
                string fechaDocumento = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC34FECHA");
                if (fechaDocumento != "")
                {
                    DateTime fecha = Convert.ToDateTime(fechaDocumento);
                    fecha.AddDays(1);
                    dtpFechaEstadoDoc.Value = fecha;
                    dtpFechaEstadoDoc.Focus();
                }

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar ventana :" + ex.Message);
            }
        }

        private void btnCancelarEstadoDoc_Click(object sender, EventArgs e)
        {
            VerVentanaEstadoDocumento(false);
        }

        private void dtpFechaEstadoDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Down)
            {
                txtHoraEstadoDoc.Focus();
            }


        }
        private void txtHoraEstadoDoc_KeyDown(object sender, KeyEventArgs e)
        {
            Util.FocusNextControl(e);
        }

        private void btnGuardarEstadoDoc_Click(object sender, EventArgs e)
        {

            ActualizarEstadoGuia("03"); // actualizacion de estado del documento a Aceptado.

        }
        private void txtObservacionEstadoDoc_KeyDown(object sender, KeyEventArgs e)
        {
            Util.FocusNextControl(e);

        }

        #endregion
		private void Importar() {
            
            try
            {
                
                OpenFileDialog opf = new OpenFileDialog();

                var fic = "";
                var filename = "";

                if (opf.ShowDialog() == DialogResult.OK && opf.FileName.Length > 0)
                {
                    fic = opf.FileName;
                    filename = opf.SafeFileName;
                }
                else return;


                // Limpiar tabla antes de importar
                string msjlimpiar = string.Empty;

                Fac_GuiaTransporteLogic.Instance.EliminarGuiasImportadas(Logueo.CodigoEmpresa, Logueo.UserName);
                


                // Recorrer el archivo e importar
                var sr = new System.IO.StreamReader(fic, Encoding.Default);
                string msj = string.Empty;
                int contadorFila = 0;

                Cursor.Current = Cursors.WaitCursor;
                while (!sr.EndOfStream)
                {

                    string[] linea = sr.ReadLine().Split('|');
                    //if (linea[1] != "T")
                    //{
                    //armar xml
                    //dasd
                    string xmkl;
                    /**/
                    //_ImportarDocumento.flag = linea[1];
                    GuiaTransporte guiacabecera = new GuiaTransporte();
                    DetalleGuiaTransporte guiadetalle = new DetalleGuiaTransporte();
                    guiacabecera.FAC34CODEMP = Logueo.CodigoEmpresa;
                    guiacabecera.FAC01COD = "09"; // valor por defecto a este documento
                    //01/01/2000                                                            
                    //tomar el varlo del mes del periodo
                    guiacabecera.FAC34MM = Logueo.Mes;

                    //tomar el varlo del año del periodo
                    guiacabecera.FAC34AA = Logueo.Anio;

                    string cerosformato = "0000000";
                    string cerosprefijo = cerosformato.Substring(0, 7 - linea[7].Length);
                    string numeroguiaformateado = cerosprefijo + linea[7];
                    guiacabecera.FAC34NROGUIA = numeroguiaformateado;


                    // datos del excel segun orde de columna
                    double cantidad = 0;
                    if (linea[1] == "")
                    {
                        cantidad = 0;
                    }
                    else
                    {
                        cantidad = Convert.ToDouble(linea[1]);
                    }


                    guiadetalle.FAC35CANTIDAD = cantidad;
                    // * cantidad - FAC35CANTIDAD

                    guiadetalle.FAC35UNIMED = Util.convertiracadena(linea[2]);
                    //* unidad de medida - FAC35UNIMED

                    guiadetalle.FAC35CODPROD = Util.convertiracadena(linea[3]);// descripcion de producto -> FAC35CODPROD(consultar a que codigo de producto ingresar)
                    //* producto -FAC35CODPROD  -FAC35DESCPROD
                    double peso = 0;
                    if (linea[4] == "")
                    {
                        peso = 0;
                    }
                    else
                    {
                        peso = Convert.ToDouble(linea[4]);
                    }

                    guiadetalle.FA35PESO = peso;
                    //* peso -FA35PESO

                    //asignar valor de fecha si es diferente de vacio
                    if (linea[5] != "")
                    {
                        guiacabecera.FAC34FECHA = Convert.ToDateTime(linea[5]);
                    }
                    //* fecha FAC34FECHA

                    guiacabecera.FAC34SERIEGUIA = Util.convertiracadena(linea[6]);
                    //serie -  FAC34SERIEGUIA

                    guiacabecera.FAC34CORRELATIVOGUIA = Util.convertiracadena(linea[7]);
                    //numero de guia  -FAC34CORRELATIVOGUIA o FAC34NROGUIA

                    guiacabecera.FAC34MOTRASLCOD = Util.convertiracadena(linea[8]);
                    //motivo de traslado //FAC34MOTRASLCOD //--FAC34MOTRASLDESC

                    guiacabecera.FAC34ORIDOMPARTIDA = linea[9];

                    //domicilio de partida -- FAC34ORIDOMPARTIDA

                    guiacabecera.FAC34DESTDIRECCION = linea[10];
                    //domicilio de destino -- FAC34DESTDIRECCION

                    guiacabecera.FAC34CLICOD = linea[11];
                    //ruc cliente //    FAC34CLICOD

                    guiacabecera.FAC34CODTRANSPORTISTA = linea[13];
                    guiacabecera.FAC34DESTRANSPORTISTA = linea[14];
                    //cliente // descripcion del cliente que trae de lectura de codigo cliente
                    //transportista // FAC34CODTRANSPORTISTA
                    guiacabecera.FAC34CHOFLICCONDUCIR = linea[15];
                    //numero licencia conducir  //FAC34CHOFLICCONDUCIR

                    guiacabecera.FAC34CHOFNOMBRE = linea[16];
                    //conductor //FAC34CHOFNOMBRE

                    guiacabecera.FAC34TRAYMARCA = linea[17];
                    //vehiculo marca // FAC34TRAYMARCA
                    guiacabecera.FAC34TRAYPLACA = linea[18];
                    //vehiculo placa // FAC34TRAYPLACA
                    guiadetalle.FAC35DESCPROD = linea[3];
                    guiacabecera.FAC34MOTRASLDESC = linea[8];
                    guiacabecera.FAC34CLIDES = linea[12];

                    guiacabecera.FAC34TRAYMARCASR = linea[19];
                    guiacabecera.FAC34TRAYPLACASR = linea[20];

                    //remolque marca
                    //remolque placa


                    string mensaje = "";
                    int flag = 0;
                    string contratista = linea[21];
                    string labor = linea[22];
                    int itemOrden = Convert.ToInt32(linea[0]);

                    contadorFila++;

                    Fac_GuiaTransporteLogic.Instance.InsertarGuiasTransporte(guiacabecera, guiadetalle, contadorFila, itemOrden, contratista, labor,
                                                                                            Logueo.UserName, out flag, out mensaje);


                    //si importacion fue exitoso
                    if (flag == 1)
                    {
                        CargarImportacion();
                        this.popupImportar.Show();
                    }

                }
                Cursor.Current = Cursors.Default;

                
            }
            catch (Exception ex)
            {                
                Util.ShowError("Error en importar documento :" + ex.Message);
            }
            
        }
        protected override void OnImportar()
        {
            this.popupImportar.Show();
            
        }

        private void btnCancelaImportar_Click(object sender, EventArgs e)
        {
            this.popupImportar.Hide();
            //limpiar datos visualmente de las tablas
            this.dgvImportacion.DataSource = null;
            this.dgvValidacion.DataSource = null;
            
            
        }
        private void Validar() {
            //realizar la validacion de lso registros insertados a tabla temporal            
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataTable dt =

                Fac_GuiaTransporteLogic.Instance.ValidacionImporteGuias(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, Logueo.UserName, "IV");


                this.dgvValidacion.DataSource = dt;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) {
                Util.ShowError("error:" + ex.Message);
                
            }
        }
      

        private void btnImportarRegistros_Click(object sender, EventArgs e)
        {
            Importar();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            Validar();
        }

        private void btnAceptarImportar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            int flag = 0;
            

            try
            {
                Validar();
                if (dgvValidacion.Rows.Count > 0) {
                    Util.ShowAlert("Error al guardar, corriga las validaciones de la importacion");
                    return;
                }


                Fac_GuiaTransporteLogic.Instance.InsertarGuiaRemisionImportada(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, Logueo.UserName, out flag, out mensaje);
                if (flag == 1)
                {
                    Util.ShowMessage(mensaje, flag);

                    

                    //refresco la grilla principal de guias de transportista
                    Oncargar();

                    //ocultar la ventana
                    this.popupImportar.Hide();
                    //limpiar los datagridview
                    this.dgvImportacion.DataSource = null;
                    this.dgvValidacion.DataSource = null;

                }
                else if (flag == -1)
                {
                    Util.ShowError(mensaje);
                }
            }
            catch (Exception ex) {
                Util.ShowAlert("Error al guardar los datos importados:" + ex.Message);
                
            }
        }



    }
}
