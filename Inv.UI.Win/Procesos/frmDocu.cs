using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessLogic;
using Inv.BusinessEntities;
using Telerik.WinControls.UI;
using System.Linq;
using Telerik.WinControls.UI.Docking;
namespace Inv.UI.Win
{
    public partial class frmDocu : frmBase
    {
        
        #region "Documento"
        public static frmDocu formulario;
        private frmMDI FrmParent { get; set; }
        private static frmDocu _aForm;
        public static frmDocu Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmDocu(mdiPrincipal);
            _aForm = new frmDocu(mdiPrincipal);
            return _aForm;
        }
        public static frmDocu Instancia()
        {
            return _aForm;
        }
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a, cancelar_a, expmovi_a, importarMP;
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbEditar;
        RadCommandBarBaseItem cbbEliminar;

        RadCommandBarBaseItem cbbVer;
        RadCommandBarBaseItem cbbVista;
        RadCommandBarBaseItem cbbImprimir;
        RadCommandBarBaseItem cbbRefrescar;
        RadCommandBarBaseItem cbbImportar;

        RadCommandBarBaseItem cbbGuardar;
        RadCommandBarBaseItem cbbCancelar;
        RadCommandBarBaseItem cbbExportarMovimientos;
        public frmDocu(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Crearcolumnas();
            OnBuscar();
            //eventos de panel
            panelErrores.MouseMove += new MouseEventHandler(panel_MouseMove);
            panelErrores.MouseDown += new MouseEventHandler(panel_MouseDown);
            btnCerrarModal.Click += new EventHandler(panel_Cerrar);
            // Ocultar panel de importacion
            crearcolImportacion();
            panelErrores.Hide();
            menu = toolBar.CommandBarElement.Rows[0].Strips[0];
            cbbNuevo = menu.Items["cbbNuevo"];
            cbbEditar = menu.Items["cbbEditar"];
            cbbEliminar = menu.Items["cbbEliminar"];

            cbbVer = menu.Items["cbbVer"];
            cbbVista = menu.Items["cbbVista"];
            cbbImprimir = menu.Items["cbbImprimir"];
            cbbRefrescar = menu.Items["cbbRefrescar"];
            cbbImportar = menu.Items["cbbImportar"];

            cbbGuardar = menu.Items["cbbGuardar"];
            cbbCancelar = menu.Items["cbbCancelar"];
            cbbExportarMovimientos = menu.Items["cbbExportarMovimientos"];
            accesobtonesxperfil();

            ComportarmientoBotones("cargar");
            //this.cargarPermisos(this.Name);

            this.gridControl.FilterChanged += new GridViewCollectionChangedEventHandler(gridControl_FilterChanged);
            formulario = this;
        }
        private void accesobtonesxperfil()
        {
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.codModulo, this.Name, out nuevo_a,
                                                                    out editar_a, out eliminar_a, out ver_a, out imprimir_a,
                                                                     out refrescar_a, out importar_a, out vista_a,
                                                                    out guardar_a, out cancelar_a, out expmovi_a, out importarMP);
        }
        private void ComportarmientoBotones(string accion)
        {

            switch (accion)
            {
                case "cargar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ver_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = vista_a ? ElementVisibility.Visible :
                                                                 ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = imprimir_a ? ElementVisibility.Visible :
                                                                      ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = refrescar_a ? ElementVisibility.Visible :
                                                                        ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = importar_a ? ElementVisibility.Visible :
                                                                      ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = guardar_a ? ElementVisibility.Visible :
                                                                    ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = cancelar_a ? ElementVisibility.Visible :
                                                                        ElementVisibility.Collapsed;
                    if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                                                                                             ElementVisibility.Collapsed;
                    break;
                case "nuevo":

                    if (cbbNuevo != null) cbbNuevo.Visibility = ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = guardar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = cancelar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                                                                                             ElementVisibility.Collapsed;
                    break;
                case "editar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = guardar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = cancelar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                                                                                             ElementVisibility.Collapsed;
                    break;
                case "grabar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = ElementVisibility.Collapsed;
                    if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                                                                                             ElementVisibility.Collapsed;
                    break;
                case "cancelar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = ElementVisibility.Collapsed;
                    if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                                                                                             ElementVisibility.Collapsed;
                    break;
            }

        }

        private void Crearcolumnas()
        {
            RadGridView grilla =  this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(grilla, "E/S", "Transaccion", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Cod.Tran.", "TipoDoc", 0, "", 80, true, false, true);
            this.CreateGridColumn(grilla, "Transaccion", "in12DesLar", 0, "", 200, true, false, true);
            this.CreateGridColumn(grilla, "Número", "CodigoDoc", 0, "", 120, true, false, true);
            this.CreateGridColumn(grilla, "Fecha", "FechaDoc", 0, "{0:dd/MM/yyyy}", 90, true, false, true);
            // Datos documento referencia
            this.CreateGridColumn(grilla, "Doc Referencia", "CodigoTransa", 0, "", 80, true, false, true);
            this.CreateGridColumn(grilla, "Prov/Cli Doc Referencia", "ctactedocresnombre", 0, "", 200, true, false, true);
            this.CreateGridColumn(grilla, "Documento", "in15Descripcion", 0, "", 250, true, false, true);
            this.CreateGridColumn(grilla, "Referencia", "ReferenciaDoc", 0, "", 200, true, false, true);
            
            this.CreateGridColumn(grilla, "Moneda", "Moneda", 0, "", 120, true, false, true);
            this.CreateGridColumn(grilla, "Tipo de Cambio", "TipoCambio", 0, "", 135, true, false, true);
            //this.CreateGridColumn(grilla, "Tipo de Cambio", "in15Descripcion", 0, "", 120, true, false, true);          
        }
        protected override void OnBuscar()
        {
            this.Cursor = Cursors.WaitCursor;
            Listar();
            this.Cursor = Cursors.Default;
        }        
        public void Listar()
        {
            try
            {
                //base.OnBuscar();
                var lista = DocumentoLogic.Instance.TraerDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, 
                    "In06CodDoc", "In06CodDoc", "*",
                    (this.rbEntradas.CheckState == CheckState.Checked) ? "E" : "S", "03");
                this.gridControl.DataSource = lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected override void OnNuevo()
        {
            
            Estado = FormEstate.New;
            this.Cursor = Cursors.WaitCursor;
            frmMovi.Instance(this).Show();
            this.Cursor = Cursors.Default;         
        }
        protected override void OnRefrescar()
        {
            Listar();
        }        
        protected override void OnEditar()
        {
            if (this.gridControl.ChildRows.Count == 0)
                return;
            Estado = FormEstate.Edit;
            this.Cursor = Cursors.WaitCursor;
            frmMovi.Instance(this).Show();
            this.Cursor = Cursors.Default;          
        }        
        protected override void OnVer()
        {
            if (this.gridControl.ChildRows.Count == 0) return;
            Estado = FormEstate.View;
            this.Cursor = Cursors.WaitCursor;
            frmMovi.Instance(this).Show();  //instancia.Show();            
            this.Cursor = Cursors.Default;
            //string tipoDocumento = string.Empty;
            //string codigoDocumento = string.Empty;

            //tipoDocumento = this.gridControl.CurrentRow.Cells["TipoDoc"].Value.ToString();
            //codigoDocumento = this.gridControl.CurrentRow.Cells["CodigoDoc"].Value.ToString();
            /*Codigo para validar formulario repetido*/
            /*instancia del formulario*/
          //  var instancia = frmMovi.Instance(this);
      
          //  //para valir uso esta variable

          //  var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMovi);

          //  if (frmexiste != null)
          //  {
          //      instancia.BringToFront();
          ////      frmexiste.BringToFront();
          //      //instancia.Focus();
          //      return;
          //  }

            //Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            //instancia._esEntrada = (rbEntradas.IsChecked ? true : false);
            //instancia._nroDocumento = codigoDocumento; 
            //instancia._tipoDocumento = tipoDocumento; 
            
            //instancia.MdiParent = this.ParentForm;

            //((RadDock)(ctrl)).ActivateMdiChild(instancia);
            //instancia.gridAyuda = gridControl;
            //instancia._grid = gridControl;
            
            //instancia.pos = gridControl.CurrentRow.Index;
            //Estado = FormEstate.View;
            //this.Cursor = Cursors.WaitCursor;
            //frmMovi.Instance(this).Show();  //instancia.Show();            
            //this.Cursor = Cursors.Default;
        }
        protected override void OnEliminar()
        {
            

            if (this.gridControl.RowCount == 0)
                return;

            try
            {
                
                string TipDoc = gridControl.CurrentRow.Cells["TipoDoc"].Value.ToString();
                string nroDoc = gridControl.CurrentRow.Cells["CodigoDoc"].Value.ToString();
                int cantidad = 0;
                DocumentoLogic.Instance.TraerCantidadDetallexNroDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, TipDoc, nroDoc, out cantidad);
                
                if(cantidad > 0){
                    RadMessageBox.Show("No se puede eliminar porque el documento tiene detalle. ", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }
                DialogResult result = RadMessageBox.Show("Está seguro de eliminar el movimiento", Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR,
                                                            MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    string tipoDocumento = string.Empty;
                    string codigoDocumento = string.Empty;
                    string transMov = string.Empty;
                    string fechaDoc = string.Empty;
                    string moneda = string.Empty;
                    double tipoCambio = 0;

                    string msgRetorno = string.Empty;

                    tipoDocumento = this.gridControl.CurrentRow.Cells["TipoDoc"].Value.ToString();
                    codigoDocumento = this.gridControl.CurrentRow.Cells["CodigoDoc"].Value.ToString();
                    transMov = this.gridControl.CurrentRow.Cells["Transaccion"].Value.ToString();
                    fechaDoc = string.Format("{0:yyyyMMdd}", DateTime.Parse(this.gridControl.CurrentRow.Cells["FechaDoc"].Value.ToString()));
                    moneda = this.gridControl.CurrentRow.Cells["Moneda"].Value.ToString();
                    tipoCambio = double.Parse(this.gridControl.CurrentRow.Cells["TipoCambio"].Value.ToString());

                    DocumentoLogic.Instance.EliminarDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, tipoDocumento, codigoDocumento, transMov, fechaDoc,
                                                              tipoCambio, moneda, out msgRetorno);

                    RadMessageBox.Show(msgRetorno, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);
                    OnBuscar();
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception)
            {

                RadMessageBox.Show(Constantes.MensajesGenericos.MSG_ERROR_INESPERADO, Constantes.MensajesGenericos.MSG_TITULO_ERROR, MessageBoxButtons.OK, RadMessageIcon.Info);
            }


        }
        protected override void OnImportar()
        {
            ImportarArchivoTexto();
        }
        #region ExportarMovimientos
        protected override void OnExportarMovimientos()
        {
            if(this.gridControl.Rows.Count == 0){
                ShowAlertOk("Sistema", "No tiene movimientos para exportar");  
            }
            //IN06CODEMP, IN06AA, IN06MM, IN06TIPDOC, IN06CODDOC
            string[] lineas = null;
            StringBuilder sb = new StringBuilder();
            for(int i = 0 ; i < this.gridControl.Rows.Count; i++)
            {
                //capturo valores de empresa, año , mes, tipoDocumento , codigoDocumento
                string codigoEmpresa = Logueo.CodigoEmpresa;
                string anio = Logueo.Anio;
                string mes = Logueo.Mes;
                string tipoDocumento = this.gridControl.Rows[i].Cells["TipoDoc"].Value.ToString();
                string nroDocumento = this.gridControl.Rows[i].Cells["CodigoDoc"].Value.ToString();
                Documento CabeceraDoc = DocumentoLogic.Instance.ObtenerDocumento(codigoEmpresa,anio, mes, 
                                        tipoDocumento, nroDocumento);                
                
                string flag = "C";                
                sb.AppendLine("|"+ flag +  // 1
                              "|" + Logueo.CodigoEmpresa +  //2
                              "|"+CabeceraDoc.TipoDoc+  //3
                              "|"+ CabeceraDoc.CodigoDoc + //4
                                         "|"+ CabeceraDoc.FechaDoc.Value.ToShortDateString()+ //5 
                                         "|"+CabeceraDoc.CodigoTransa+ //6
                                         "|"+ CabeceraDoc.ReferenciaDoc+ //7
                                         "|"+CabeceraDoc.CodigoProveedor+  //8
                                         "|"+CabeceraDoc.Moneda+ //9
                                         "|"+ CabeceraDoc.ResponsableReceptor+  //10
                                         "|"+CabeceraDoc.Responsable+  // 11
                                         "|"+CabeceraDoc.IN06NOTASALIDA+  //12
                                         "|"+CabeceraDoc.CodigoCentroCosto+  //13
                                         "|"+CabeceraDoc.CodigoObra+ //14                                         
                                         "|"+CabeceraDoc.IN06DOCRESCTACTETIPANA+ //15
                                         "|"+CabeceraDoc.IN06DOCRESCTACTENUMERO+ //16
                                         "|" + CabeceraDoc.CodigoMaquina + // 17
                                         "|"+CabeceraDoc.codigoLinea+ //18
                                         "|"+CabeceraDoc.codigoActiNivel1+ //19
                                         "|" + CabeceraDoc.codigoTurno+ // 20
                                         "|"+ CabeceraDoc.IN06CANTERACOD + // 21
                                         "|" + CabeceraDoc.IN06CONTRATISTACOD + // 22
                                         "|" + CabeceraDoc.IN06PRODNATURALEZA + // 23
                                         "|" + CabeceraDoc.OrigenTipo+ // 24
                                         "|"+ CabeceraDoc.Anio + // 25
                                         "|" + CabeceraDoc.Mes + // 26
                                         "|");
                //Si encuentro una orden de trabajo
                var ordentrabajo = OrdenTrabajoLogic.Instance.TraerOrdenTrabajo(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, nroDocumento, tipoDocumento);
                if (ordentrabajo.Count > 0)
                {
                    //Traer las ordenes de trabajo
                    for (int j = 0; j < ordentrabajo.Count; j++)
                    {
                        string codigoOT = string.Empty;
                        var registroOT = ordentrabajo[j];
                        string flagOT = "OT";
                        sb.AppendLine("|" + flagOT +
                                      "|"+ registroOT.codigoEmpresa+ 
                                      "|" +registroOT.codigo + 
                                      "|" + registroOT.codigoProducto+ 
                                      "|" +registroOT.DocuIngresoAlmacenAnio+ 
                                      "|"+ registroOT.DocuIngresoAlmacenMes+ 
                                      "|" +registroOT.DocuIngresoAlmacenTipDoc+ 
                                      "|" + registroOT.DocuIngresoAlmacenCodDoc+ 
                                      "|"+ registroOT.OrigenMP +
                                      "|"  + registroOT.PRO13AA + 
                                      "|" +registroOT.PRO13MM + 
                                      "|" + registroOT.PRO13LINEACOD +
                                      "|"+ registroOT.PRO13ACTIVIDADNIVELCOD + "|");                        

                        string CodigoOrdenTrabajo = string.Empty;
                        CodigoOrdenTrabajo = registroOT.codigo;
                        var detalle = DocumentoLogic.Instance.TraerMovimiento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, tipoDocumento,
                                                                           nroDocumento, CodigoOrdenTrabajo);    
                        //Recorremos todo el detalle 
                        for (int k = 0; k < detalle.Count; k++) { 
                            
                            string pedvendestinno = "";
                            string flagDetalle = "D";
                            sb.AppendLine("|"+ flagDetalle +"|"+detalle[k].CodigoEmpresa+ 
                                          "|"+detalle[k].Anio+ 
                                          "|"+detalle[k].Mes+ 
                                          "|"+detalle[k].CodigoTipoDocumento+
                                          "|"+detalle[k].CodigoDocumento+ 
                                          "|"+detalle[k].CodigoArticulo+ 
                                          "|"+detalle[k].Orden.ToString()+ 
                                          "|"+detalle[k].UnidadMedida+
                                          "|"+detalle[k].FechaDoc.Value.ToShortDateString()+
                                          "|"+detalle[k].CodigoAlmacen+ 
                                          "|"+detalle[k].CodigoTransaccion+
                                          "|"+detalle[k].Transaccion+ 
                                          "|"+detalle[k].Cantidad.ToString()+
                                          "|"+ detalle[k].CostoSoles.ToString()+ 
                                          "|"+ detalle[k].CostoDolares.ToString()+ 
                                          "|" +detalle[k].Importe.ToString()+ 
                                          "|" + detalle[k].ImporteSoles.ToString()+ 
                                          "|" +detalle[k].ImporteDolar.ToString()+ 
                                          "|"+ detalle[k].CostoAlmacen.ToString()+ 
                                          "|"+ detalle[k].ImporteAlmacen.ToString()+ 
                                          "|"+ detalle[k].CostoAlmacenSoles.ToString()+ 
                                          "|" +detalle[k].CostoAlmacenDolar.ToString()+ 
                                          "|" +detalle[k].ImporteAlmacenDolar.ToString()+
                                          "|"+detalle[k].CuentaGasto+
                                          "|"+ detalle[k].CuentaIngreso+ 
                                          "|"+detalle[k].Largo.ToString()+ 
                                          "|" +detalle[k].Ancho.ToString()+ 
                                          "|"+detalle[k].Alto.ToString()+
                                          "|"+detalle[k].LargoCan.ToString()+
                                          "|" +detalle[k].AnchoCan.ToString()+ 
                                          "|"+detalle[k].AltoCan.ToString()+ 
                                          "|"+detalle[k].PromedioSoles.ToString()+
                                          "|"+detalle[k].PromedioDolar.ToString()+
                                          "|"+detalle[k].Estado+ 
                                          "|"+detalle[k].CodigoBloque+ 
                                          "|"+detalle[k].CodBloqProv+ 
                                          "|"+detalle[k].OrdenProduccion+ 
                                          "|"+detalle[k].NroCaja+ 
                                          "|"+detalle[k].NroPedidoVenta+ 
                                          "|"+pedvendestinno+ 
                                          "|"+detalle[k].IN07DocIngAA+
                                          "|"+detalle[k].IN07DocIngMM+ 
                                          "|"+detalle[k].IN07DocIngTIPDOC+ 
                                          "|"+detalle[k].IN07DocIngCODDOC+ 
                                          "|"+detalle[k].IN07DocIngKEY+
                                          "|"+detalle[k].IN07DocIngORDEN.ToString()+ 
                                          "|"+detalle[k].in07pedvennum+ 
                                          "|"+detalle[k].in07pedvencodprod+ 
                                          "|"+detalle[k].in07pedvenitem+
                                          "|"+detalle[k].in07observacion+ 
                                          "|"+(detalle[k].Largo * detalle[k].Ancho * detalle[k].Alto).ToString()+
                                          "|"+detalle[k].IN07FLAGSTOCKREAL + "|");                                                        

                        }
                    }                                        

                }
                else { 
                    //traer los detalles
                    string CodigoOrdenTrabajo = string.Empty;
                  
                    var detalle = DocumentoLogic.Instance.TraerMovimiento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, tipoDocumento,
                                                                       nroDocumento, "");
                    //Recorremos todo el detalle 
                    for (int k = 0; k < detalle.Count; k++)
                    {

                        string pedvendestinno = "";
                        string flagDetalle = "D";
                        sb.AppendLine("|"+flagDetalle+ // 1
                            "|"+detalle[k].CodigoEmpresa + //2
                            "|" + detalle[k].Anio + // 3
                            "|" + detalle[k].Mes + //4
                            "|" + detalle[k].CodigoTipoDocumento + //5
                            "|" + detalle[k].CodigoDocumento + // 6
                            "|" + detalle[k].CodigoArticulo + //7
                            "|" + detalle[k].Orden.ToString() + //8
                            "|" + detalle[k].UnidadMedida + // 9
                            "|" + detalle[k].FechaDoc.Value.ToShortDateString() + // 10
                            "|" + detalle[k].CodigoAlmacen + //11
                            "|" + detalle[k].CodigoTransaccion + //12
                            "|" + detalle[k].Transaccion + //13
                            "|" + detalle[k].Cantidad.ToString() + //14
                            "|" + detalle[k].CostoSoles.ToString() + //15
                            "|" + detalle[k].CostoDolares.ToString() + //16
                            "|" + detalle[k].Importe.ToString() + //17
                            "|" + detalle[k].ImporteSoles.ToString() + //18
                            "|" + detalle[k].ImporteDolar.ToString() + //19
                            "|" + detalle[k].CostoAlmacen.ToString() + //20
                            "|" + detalle[k].ImporteAlmacen.ToString() + //21
                            "|" + detalle[k].CostoAlmacenSoles.ToString() + //22
                            "|" + detalle[k].CostoAlmacenDolar.ToString() + // 23
                            "|" + detalle[k].ImporteAlmacenDolar.ToString() + // 24
                            "|" + detalle[k].CuentaGasto + //25
                            "|" + detalle[k].CuentaIngreso + //26
                            "|" + detalle[k].Largo.ToString() + // 27
                            "|" + detalle[k].Ancho.ToString() + // 28
                            "|" + detalle[k].Alto.ToString() + //29
                            "|" + detalle[k].LargoCan.ToString() + //30
                            "|" + detalle[k].AnchoCan.ToString() + // 31
                            "|" + detalle[k].AltoCan.ToString() + //32
                            "|" + detalle[k].PromedioSoles.ToString() + // 33
                            "|" + detalle[k].PromedioDolar.ToString() + //34
                            "|" + detalle[k].Estado + //35
                            "|" + detalle[k].CodigoBloque + //36
                            "|" + detalle[k].CodBloqProv + //39
                            "|" + detalle[k].OrdenProduccion + //40
                            "|" + detalle[k].NroCaja + //41
                            "|" + detalle[k].NroPedidoVenta + //42
                            "|" + pedvendestinno + //43
                            "|" + detalle[k].IN07DocIngAA + //44
                            "|" + detalle[k].IN07DocIngMM + // 45
                            "|" + detalle[k].IN07DocIngTIPDOC + // 46
                            "|" + detalle[k].IN07DocIngCODDOC + // 47
                            "|" + detalle[k].IN07DocIngKEY + // 48
                            "|" + detalle[k].IN07DocIngORDEN.ToString() + // 49
                            "|" + detalle[k].in07pedvennum + // 50
                            "|" + detalle[k].in07pedvencodprod + // 51
                            "|" + detalle[k].in07pedvenitem + //52
                            "|" + detalle[k].in07observacion + //53
                            "|" + (detalle[k].Largo * detalle[k].Ancho * detalle[k].Alto).ToString() + //54
                            "|" + detalle[k].IN07FLAGSTOCKREAL +  // 55
                            "|");
                    }
                }                
            }
            

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.Title = "Guardar Archivo texto";
            sfd.RestoreDirectory = true;
            string ruta = string.Empty;
            if (sfd.ShowDialog() == DialogResult.OK) {
                ruta = sfd.FileName;
            }

     
            System.IO.File.WriteAllText(ruta, string.Empty);
            System.IO.File.WriteAllText(ruta, sb.ToString());

            
        }
        #endregion
        private void rbEntradas_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            OnBuscar();
        }
        private void rbSalidas_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            OnBuscar();
        }
        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (!gridControl.IsLoaded) return;
            if (gridControl.RowCount == 0) return;                            
            if (e.Row.Cells["CodigoDoc"].Value != null)
            {
                OnVer();
            }                            
        }
        private void gridControl_FilterPopupRequired(object sender, FilterPopupRequiredEventArgs e)
        {
            if (e.Column.Name == "FechaDoc")
            {
                e.FilterPopup = new RadListFilterPopup(e.Column, true);
            }
        }
        
        #endregion


        
        #region ImportarDocumento
        private void ImportarArchivoTexto()
        {
            ImportarDocumento _ImportarDocumento = new ImportarDocumento();
            OpenFileDialog opf = new OpenFileDialog();
            
            var fic = "";
            var filename = "";
            try
            {
                if (opf.ShowDialog() == DialogResult.OK && opf.FileName.Length > 0)
                {
                    fic = opf.FileName;
                    filename = opf.SafeFileName;
                }
                else return;

                // Limpiar tabla antes de importar
                string msjlimpiar = string.Empty;
                DocumentoLogic.Instance.DocumentoImportarEliminar(Logueo.CodigoEmpresa, Logueo.UserName, out msjlimpiar);


                // Recorrer el archivo e importar
                var sr = new System.IO.StreamReader(fic, Encoding.Default);
                string msj = string.Empty;

                while (!sr.EndOfStream)
                {

                    string[] linea = sr.ReadLine().Split('|');
                    if (linea[1] != "T")
                    {
                        /**/
                        _ImportarDocumento.flag = linea[1];
                        //_ImportarDocumento.IN07CODEMP = string.IsNullOrEmpty(linea[2]) ? null : linea[2];
                        _ImportarDocumento.IN07CODEMP = Logueo.CodigoEmpresa;
                        _ImportarDocumento.IN07TRANSA = string.IsNullOrEmpty(linea[3]) ? null : linea[3];
                        _ImportarDocumento.IN07AA = string.IsNullOrEmpty(linea[4]) ? null : linea[4];
                        _ImportarDocumento.IN07MM = string.IsNullOrEmpty(linea[5]) ? null : linea[5];
                        _ImportarDocumento.IN07TIPDOC = string.IsNullOrEmpty(linea[6]) ? null : linea[6];
                        _ImportarDocumento.IN07CODDOC = string.IsNullOrEmpty(linea[7]) ? null : linea[7];
                        _ImportarDocumento.IN07FECDOC = string.IsNullOrEmpty(linea[8]) ? null : linea[8];
                        _ImportarDocumento.IN06CODTRA = string.IsNullOrEmpty(linea[9]) ? null : linea[9];
                        _ImportarDocumento.IN06REFDOC = string.IsNullOrEmpty(linea[10]) ? null : linea[10];
                        _ImportarDocumento.IN06CODPRO = string.IsNullOrEmpty(linea[11]) ? null : linea[11];
                        
                        //_ImportarDocumento.IN07CODCLI = string.IsNullOrEmpty(linea[11]) ? null : linea[11];
                        _ImportarDocumento.IN06MONEDA = string.IsNullOrEmpty(linea[12]) ? "S" : linea[12];
                        _ImportarDocumento.IN06CENCOS = string.IsNullOrEmpty(linea[13]) ? "" : linea[13];
                        _ImportarDocumento.IN06OBRA = string.IsNullOrEmpty(linea[14]) ? "" : linea[14];

                        _ImportarDocumento.in07pedvennum = string.IsNullOrEmpty(linea[15]) ? "" : linea[15];
                        _ImportarDocumento.IN07PROVMATPRIMA = string.IsNullOrEmpty(linea[16]) ? "" : linea[16];
                        //_ImportarDocumento.IN07ORDPROD = string.IsNullOrEmpty(linea[17]) ? "" : linea[17];
                        _ImportarDocumento.IN07CODCLI = string.IsNullOrEmpty(linea[17]) ? "" : linea[17];
                        _ImportarDocumento.IN07PEDVEN = string.IsNullOrEmpty(linea[18]) ? "" : linea[18];
                        _ImportarDocumento.IN07NROCAJA = string.IsNullOrEmpty(linea[19]) ? "" : linea[19];
                        _ImportarDocumento.IN07CODALM = string.IsNullOrEmpty(linea[20]) ? "" : linea[20];
                        _ImportarDocumento.IN07KEY = string.IsNullOrEmpty(linea[21]) ? "" : linea[21];
                        _ImportarDocumento.IN07UNIMED = string.IsNullOrEmpty(linea[22]) ? null : linea[22];
                        _ImportarDocumento.IN07ANCHO = string.IsNullOrEmpty(linea[23]) ? 0 : double.Parse(linea[23]);
                        _ImportarDocumento.IN07LARGO = string.IsNullOrEmpty(linea[24]) ? 0 : double.Parse(linea[24]);
                        _ImportarDocumento.IN07ALTO = string.IsNullOrEmpty(linea[25]) ? 0 : double.Parse(linea[25]);
                        _ImportarDocumento.IN07CANART = string.IsNullOrEmpty(linea[26]) ? 0 : double.Parse(linea[26]);
                        _ImportarDocumento.IN07AREAXUNI = string.IsNullOrEmpty(linea[27]) ? 0 : double.Parse(linea[27]);
                        _ImportarDocumento.IN07COSUNI = string.IsNullOrEmpty(linea[28]) ? 0 : double.Parse(linea[28]);
                        _ImportarDocumento.codigousuario = string.IsNullOrEmpty(Logueo.UserName) ? "" : Logueo.UserName;
                        //_ImportarDocumento.sistema = string.IsNullOrEmpty(Logueo.NombreEmpresa) ? "" : Logueo.NombreEmpresa;
                        _ImportarDocumento.sistema = "ALMACEN";
                        // Asigno valo 0 a pedido de venta, pues no puede ser nulo
                        _ImportarDocumento.IN07ORDEN = 0;

                        // Inserto la liena en la base de datos
                        DocumentoLogic.Instance.DocumentoImportarInsertar(_ImportarDocumento, out msj);
                    }

                }
                TraerArchivoImportado();
                panelErrores.Show();
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void TraerArchivoImportado()
        {
            dgvErrores.DataSource = DocumentoLogic.Instance.TraerImportacion(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,"ALMACEN",Logueo.UserName);

        }
        private void crearcolImportacion()
        {
            RadGridView grilla = this.CreateGridVista(this.dgvErrores);
            
            this.CreateGridColumn(grilla, "Errores", "errores", 0, "", 150);
            this.CreateGridColumn(grilla, "Orden", "IN07ORDEN", 0, "", 70);
            this.CreateGridColumn(grilla, "Empresa", "IN07CODEMP", 0, "", 70);
            this.CreateGridColumn(grilla, "Anio", "IN07AA", 0, "", 70);
            this.CreateGridColumn(grilla, "Mes", "IN07MM", 0, "", 70);
            this.CreateGridColumn(grilla, "Doc.Tipo", "IN07TIPDOC", 0, "", 80);
            this.CreateGridColumn(grilla, "Doc.Numero", "IN07CODDOC", 0, "", 120);
            this.CreateGridColumn(grilla, "Prod.Codigo", "IN07KEY", 0, "", 120);
            
            this.CreateGridColumn(grilla, "Uni. Med", "IN07UNIMED", 0, "", 70);
            this.CreateGridColumn(grilla, "Fecha", "IN07FECDOC", 0, "", 70);
            this.CreateGridColumn(grilla, "Almacen", "IN07CODALM", 0, "", 70);
            this.CreateGridColumn(grilla, "Cod.Transaccion", "IN07CODTRA", 0, "", 50, true, false, false);
            this.CreateGridColumn(grilla, "Transacion", "IN07TRANSA", 0, "", 80);
            this.CreateGridColumn(grilla, "Cantidad", "IN07CANART", 0, "", 80);
            this.CreateGridColumn(grilla, "Precio", "IN07COSUNI", 0, "", 70);
            this.CreateGridColumn(grilla, "Largo", "IN07LARGO", 0, "", 70);
            this.CreateGridColumn(grilla, "Ancho", "IN07ANCHO", 0, "", 70);
            this.CreateGridColumn(grilla, "Espesor", "IN07ALTO", 0, "", 70);
            this.CreateGridColumn(grilla, "Pedido", "IN07PEDVENTA", 0, "", 50,true,false,false);
            this.CreateGridColumn(grilla, "Ord.Producto", "IN07ORDPROD", 0, "", 100);
            this.CreateGridColumn(grilla, "Caja", "IN07NROCAJA", 0, "", 70);
            this.CreateGridColumn(grilla, "Ped.Venta", "IN07PEDVEN", 0, "", 100);
            this.CreateGridColumn(grilla, "in07pedvennum", "in07pedvennum", 0, "", 50, true, false, false);
            this.CreateGridColumn(grilla, "Pedido Codprod",
                                              "in07pedvencodprod", 0, "", 120, true, false, false);
            this.CreateGridColumn(grilla, "in07pedvenitem", "in07pedvenitem", 0, "", 50, true, false, false);
            this.CreateGridColumn(grilla, "in07observacion", "in07observacion", 0, "", 50, true, false, false);
            this.CreateGridColumn(grilla, "Areaxuni", "IN07AREAXUNI", 0, "", 80);
            this.CreateGridColumn(grilla, "IN07FLAGSTOCKREAL", "IN07FLAGSTOCKREAL",
                                              0, "", 50, true, false, false);
            this.CreateGridColumn(grilla, "Proveedor", "IN07PROVMATPRIMA", 0, "", 80);
            this.CreateGridColumn(grilla, "Cod.Transaccion", "IN06CODTRA", 0, "", 150);
            this.CreateGridColumn(grilla, "Doc.Ref", "IN06REFDOC", 0, "", 70);
            this.CreateGridColumn(grilla, "Moneda", "IN06MONEDA", 0, "", 70);
            this.CreateGridColumn(grilla, "Cod.Proveedor", "IN06CODPRO", 0, "", 90);
            this.CreateGridColumn(grilla, "C.Costos", "IN06CENCOS", 0, "", 80);
            this.CreateGridColumn(grilla, "Obra", "IN06OBRA", 0, "", 70);
            this.CreateGridColumn(grilla, "Flag", "flag", 0, "", 50, true, false, false);
            this.CreateGridColumn(grilla, "Cant.Errores", "Canterrores", 0, "", 120);
        }
        private void generarDocumento()
        {
            string msg = string.Empty;
            if (Convert.ToInt32(dgvErrores.Rows[0].Cells["Canterrores"].Value) > 0)
            {
                MessageBox.Show("Corregir los registros con error");
                return;
            }
            else

            {
                DocumentoLogic.Instance.DocumentoImportarGenerar(Logueo.CodigoEmpresa,Logueo.UserName,out msg);
                MessageBox.Show(msg);
                panelErrores.Hide();
                OnBuscar();
            }
        }
        private void panel_Cerrar(object sende, EventArgs e) {
            panelErrores.Hide();
        }
        private Point MouseDownLocation;
        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                panelErrores.Left = e.X + panelErrores.Left - MouseDownLocation.X;
                //this.Left = e.X + this.Left - MouseDownLocation.X;
                panelErrores.Top = e.Y + panelErrores.Top - MouseDownLocation.Y;
                //this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            generarDocumento();
        }
        #endregion

        private void gridControl_FilterChanged(object sender, Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
        {           
        }
        //private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        //{
        //    if (!gridControl.IsLoaded) return;
        //    if (gridControl.RowCount == 0) return;
        //    if (e.Row.Cells["CodigoDoc"].Value != null)
        //    {
        //        OnVer();
        //    }
        //}
    }
}
