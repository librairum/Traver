using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using Inv.BusinessLogic;
using Inv.BusinessEntities;
using System.IO;

namespace Inv.UI.Win
{
    public partial class frmDocuSuministro : frmBase
    {

        public static frmDocuSuministro formulario;
        private frmMDI FrmParent { get; set; }
        private static frmDocuSuministro _aForm;
        public static frmDocuSuministro Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmDocuSuministro(mdiPrincipal);
            _aForm = new frmDocuSuministro(mdiPrincipal);
            return _aForm;
        }
        public frmDocuSuministro(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Crearcolumnas();
            OnBuscar();
            menu = toolBar.CommandBarElement.Rows[0].Strips[0];
            cbbNuevo = menu.Items["cbbNuevo"];
            cbbEditar = menu.Items["cbbEditar"];
            cbbEliminar = menu.Items["cbbEliminar"];

            cbbVer = menu.Items["cbbVer"];
            cbbVista = menu.Items["cbbVista"];
            cbbImprimir = menu.Items["cbbImprimir"];
            cbbRefrescar = menu.Items["cbbRefrescar"];
            cbbImportar = menu.Items["cbbImportar"];
            cbbImportarMP = menu.Items["cbbImportarMP"];
            cbbGuardar = menu.Items["cbbGuardar"];
            cbbCancelar = menu.Items["cbbCancelar"];
            cbbExportarMovimientos = menu.Items["cbbExportarMovimientos"];
            accesobtonesxperfil();

            ComportarmientoBotones("cargar");
            formulario = this;
            
        }
        private void ComportarmientoBotones(string accion)
        {
           // importar_a = false;
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
                    if (cbbImportarMP != null) cbbImportarMP.Visibility = importarMP ? ElementVisibility.Visible :
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
                  //  if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                    //                                                                         ElementVisibility.Collapsed;
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
                  //  if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                    //                                                                         ElementVisibility.Collapsed;
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
                   // if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                     //                                                                        ElementVisibility.Collapsed;
                    break;
            }

        }
        private void accesobtonesxperfil()
        {
            //ocultar exportar documentos cabedocu_ detradocu
            
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.codModulo, this.Name, out nuevo_a,
                                                                    out editar_a, out eliminar_a, out ver_a, out imprimir_a,
                                                                     out refrescar_a, out importar_a, out vista_a,
                                                                    out guardar_a, out cancelar_a, out expmovi_a,out importarMP);
            
        }
        private void Crearcolumnas()
        {
            RadGridView grilla = this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(grilla, "E/S", "Transaccion", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Cod.Tran.", "TipoDoc", 0, "", 80, true, false, true);
            this.CreateGridColumn(grilla, "Transaccion", "in12DesLar", 0, "", 150, true, false, true);
            this.CreateGridColumn(grilla, "Número", "CodigoDoc", 0, "", 100, true, false, true);
            this.CreateGridColumn(grilla, "Fecha", "FechaDoc", 0, "{0:dd/MM/yyyy}", 90, true, false, true);
            // Datos documento referencia
            this.CreateGridColumn(grilla, "Doc.Resp.Tip", "CodigoTransa", 0, "", 80, true, false, true);


            this.CreateGridColumn(grilla, "Doc.Resp.Desc", "in15Descripcion", 0, "", 150, true, false, true);
            this.CreateGridColumn(grilla, "Doc.Resp.Num", "ReferenciaDoc", 0, "", 100, true, false, true);
            this.CreateGridColumn(grilla, "Moneda", "Moneda", 0, "", 120, true, false, true);
            this.CreateGridColumn(grilla, "Doc.Res.CtaCte.Cod", "IN06DOCRESCTACTENUMERO", 0, "", 200, true, false, true);
            this.CreateGridColumn(grilla, "Doc.Res.CtaCte.Desc", "ctactedocresnombre", 0, "", 200, true, false, true);
            
            this.CreateGridColumn(grilla, "CCosto Cod", "CodigoCentroCosto", 0, "", 80, true, false, true);
            this.CreateGridColumn(grilla, "CCosto Desc", "CCostoDesc", 0, "", 150, true, false, true);

            
            this.CreateGridColumn(grilla, "Tipo de Cambio", "TipoCambio", 0, "", 135, true, false, false);

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
                var lista = DocumentoLogic.Instance.TraerDocumento(Logueo.CodigoEmpresa, Logueo.Anio, 
                                                            Logueo.Mes, "In06CodDoc", "In06CodDoc", "*",
                    (this.rbEntradas.CheckState == CheckState.Checked) ? "E" : "S", Logueo.PS_codnaturaleza);
                this.gridControl.DataSource = lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static frmDocuSuministro Instancia()
        {
            return _aForm;
        }
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, 
                     guardar_a, cancelar_a, expmovi_a,importarMP;
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbEditar;
        RadCommandBarBaseItem cbbEliminar;

        RadCommandBarBaseItem cbbVer;
        RadCommandBarBaseItem cbbVista;
        RadCommandBarBaseItem cbbImprimir;
        RadCommandBarBaseItem cbbRefrescar;
        RadCommandBarBaseItem cbbImportar;
        RadCommandBarBaseItem cbbImportarMP;
        RadCommandBarBaseItem cbbGuardar;
        RadCommandBarBaseItem cbbCancelar;
        RadCommandBarBaseItem cbbExportarMovimientos;
        protected override void OnNuevo()
        {

            Estado = FormEstate.New;
            
            this.Cursor = Cursors.WaitCursor;
            
            frmMoviSuministro.Instance(this).Show();
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
            frmMoviSuministro.Instance(this).Show();
            this.Cursor = Cursors.Default;
        }

        protected override void OnVista()
        {

            string mensajeOut = string.Empty;
            string CodigoTipDoc = Util.GetCurrentCellText(gridControl.CurrentRow, "TipoDoc");
            string NroDocumento = Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoDoc");

            GlobalLogic.Instance.InsertarRangoImpresion(Logueo.CodigoEmpresa, "Admin", CodigoTipDoc, NroDocumento, out mensajeOut);
            var datos = DocumentoLogic.Instance.ReporteDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();
            reporte.Nombre = "sqlrepdocumentos.rpt";
            reporte.DataSource = datos;
            reporte.FormulasFields.Add(new Formula("Ano", Logueo.Anio));
            reporte.FormulasFields.Add(new Formula("Mes", Logueo.Mes));
            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));

            //reporte.ParametersFields.Add(new Paramentro("@CodEmp", Logueo.CodigoEmpresa));
            //reporte.ParametersFields.Add(new Paramentro("@Ano", Logueo.Anio));
            //reporte.ParametersFields.Add(new Paramentro("@Mes", Logueo.Mes));

            ReporteControladora control = new ReporteControladora(reporte);
            control.VistaPrevia(enmWindowState.Normal);
            GlobalLogic.Instance.EliminarRangoImpresion(Logueo.CodigoEmpresa, "Admin", CodigoTipDoc, out mensajeOut);


            //Cursor.Current = Cursors.WaitCursor;
            //string[] registros = new string[this.gridControl.SelectedRows.Count];
            //int x = 0;
            //foreach (GridViewRowInfo fila in gridControl.SelectedRows)
            //{

            //    registros[x] = Util.GetCurrentCellText(fila, "TipoDoc") + "|" +
            //                   Util.GetCurrentCellText(fila, "CodigoDoc");

            //    x++;
            //}

            ////xmlDetalle
            //var datos = DocumentoLogic.Instance.TraeReportesMovimientosSuministro(Logueo.CodigoEmpresa,
            //Logueo.Anio, Logueo.Mes, Util.ConvertiraXMLdinamico(registros));
            
            //Reporte reporte = new Reporte("Documento");
            //reporte.Ruta = Logueo.GetRutaReporte();
            //reporte.Nombre = "RptMovimientoSuministro.rpt";
            //reporte.DataSource = datos;
            
            //reporte.FormulasFields.Add(new Formula("Ano", Logueo.Anio));
            //reporte.FormulasFields.Add(new Formula("Mes", Logueo.Mes));
            //reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));

            //ReporteControladora control = new ReporteControladora(reporte);
            ////control.Imprimir();
            //control.VistaPrevia(enmWindowState.Normal);
            //Cursor.Current = Cursors.WaitCursor;

        }
        protected override void OnVer()
        {
            if (this.gridControl.ChildRows.Count == 0) return;
            Estado = FormEstate.View;
            this.Cursor = Cursors.WaitCursor;
            frmMoviSuministro.Instance(this).Show();  //instancia.Show();            
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
                if (this.gridControl.SelectedRows.Count > 1)
                {
                      //DialogResult result = RadMessageBox.Show("¿Está seguro de eliminar los  movimientos seleccionados?", Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR,
                      //                                              MessageBoxButtons.YesNo, RadMessageIcon.Question);

                      //if (result == System.Windows.Forms.DialogResult.Yes)
                      //{
                      //}
                          VerModal();   
                      
                }
                else { 
                
                
                        string TipDoc = gridControl.CurrentRow.Cells["TipoDoc"].Value.ToString();
                        string nroDoc = gridControl.CurrentRow.Cells["CodigoDoc"].Value.ToString();
                        int cantidad = 0;
                        DocumentoLogic.Instance.TraerCantidadDetallexNroDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, TipDoc, nroDoc, out cantidad);

                        if (cantidad > 0)
                        {
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
            }
            catch (Exception)
            {

                RadMessageBox.Show(Constantes.MensajesGenericos.MSG_ERROR_INESPERADO, Constantes.MensajesGenericos.MSG_TITULO_ERROR, MessageBoxButtons.OK, RadMessageIcon.Info);
            }


        }
        protected override void OnExportarMovimientos()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                StringBuilder sbCabecera = new StringBuilder();
                StringBuilder sbDetalle = new StringBuilder();
                string[] registros = new string[this.gridControl.SelectedRows.Count];
                int x = 0;
                x++;
                #region "Consultar datos"
                foreach (GridViewRowInfo fila in gridControl.SelectedRows)
                {
                    string tipoDocumento = Util.GetCurrentCellText(fila, "TipoDoc");
                    string nroDocumento = Util.GetCurrentCellText(fila, "CodigoDoc");
                    Documento CabeceraDoc = DocumentoLogic.Instance.ObtenerDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                                           tipoDocumento, nroDocumento);
                        //sbCabecera.AppendLine("|" + "C" + "|" + Logueo.CodigoEmpresa + "|" + Logueo.Anio + "|" +
                        sbCabecera.AppendLine(Logueo.CodigoEmpresa + "¦" + Logueo.Anio + "¦" +
                        Logueo.Mes + "¦" + CabeceraDoc.TipoDoc + "¦" +
                        CabeceraDoc.CodigoDoc + "¦" + CabeceraDoc.FechaDoc.Value.ToShortDateString() + "¦" +
                        CabeceraDoc.IN06CODTRAANTERIOR + "¦" + CabeceraDoc.Transaccion + "¦" +
                        CabeceraDoc.Moneda + "¦" + CabeceraDoc.TipoCambio + "¦" +
                        CabeceraDoc.CodigoProveedor + "¦" + CabeceraDoc.CodigoCliente + "¦" +
                        CabeceraDoc.CodigoCentroCosto + "¦"+
                        CabeceraDoc.Responsable + "¦" + CabeceraDoc.ResponsableReceptor + "¦" +
                        CabeceraDoc.CodigoObra + "¦" + CabeceraDoc.CodigoMaquina + "¦" +
                        CabeceraDoc.Lote + "¦" + CabeceraDoc.Pedido + "¦" +
                        CabeceraDoc.ReferenciaDoc + "¦" + CabeceraDoc.CodigoAlmacenEmisor + "¦" +
                        CabeceraDoc.CodigoAlmacenReceptor + "¦" + CabeceraDoc.Item + "¦" +
                        CabeceraDoc.AnioItem + "¦" + CabeceraDoc.Observacion + "¦" +
                        CabeceraDoc.OrdenCompra + "¦" + CabeceraDoc.FlagVen + "¦" + "" + "¦");
                    List<MovimientoResponse> detalle = DocumentoLogic.Instance.TraerMovimiento(Logueo.CodigoEmpresa, Logueo.Anio,
                                                               Logueo.Mes, tipoDocumento, nroDocumento, "");
                    #region "Detalle"
                    foreach (MovimientoResponse filaDetalle in detalle)
                    {
                        
                        //sbDetalle.AppendLine("|" + "D" + "|" +
                        sbDetalle.AppendLine(filaDetalle.CodigoEmpresa + "¦" + 
                            filaDetalle.Anio + "¦" + 
                            filaDetalle.Mes + "¦" +
                            filaDetalle.CodigoTipoDocumento + "¦" + 
                            filaDetalle.CodigoDocumento + "¦" +
                            filaDetalle.CodigoArticulo + "¦" + 
                            filaDetalle.Orden + "¦" + 
                            "0" + "¦" + 
                            filaDetalle.UnidadMedida + "¦" +
                            filaDetalle.FechaDoc.Value.ToShortDateString() + "¦" + 
                            filaDetalle.CodigoAlmacen + "¦" + 
                            filaDetalle.IN07CODTRAANTERIOR + "¦" +
                            filaDetalle.Transaccion + "¦" + 
                            filaDetalle.Cantidad + "¦" + 
                            Util.Redondear(filaDetalle.CostoUnidad,2) + "¦" +
                            Util.Redondear(filaDetalle.CostoSoles,2) + "¦" + 
                            Util.Redondear(filaDetalle.CostoDolares,2) + "¦" + 
                            Util.Redondear(filaDetalle.Importe,2) + "¦" + 
                            Util.Redondear(filaDetalle.ImporteSoles,2) + "¦" +
                            Util.Redondear(filaDetalle.ImporteDolar,2) + "¦" + 
                            Util.Redondear(filaDetalle.CostoAlmacen, 2) + "¦" +
                            Util.Redondear(filaDetalle.ImporteAlmacen,2) + "¦" + 
                            Util.Redondear(filaDetalle.CostoAlmacenSoles,2) + "¦" +
                            Util.Redondear(filaDetalle.ImporteAlmacenSoles,2) + "¦" + 
                            Util.Redondear(filaDetalle.CostoAlmacenDolar,2) + "¦" + 
                            Util.Redondear(filaDetalle.ImporteAlmacenDolar,2) + "¦" +
                            filaDetalle.CodBloEmp + "¦" + 
                            filaDetalle.CodBloqProv + "¦" +
                            Util.convertiracadena(filaDetalle.Largo) + "¦" + Util.convertiracadena(filaDetalle.Ancho) + "¦" +
                            Util.convertiracadena(filaDetalle.Alto) + "¦" + Util.convertiracadena(filaDetalle.LargoCan) + "¦" +
                            Util.convertiracadena(filaDetalle.AnchoCan) + "¦" + Util.convertiracadena(filaDetalle.AltoCan) + "¦");
                    }
                    #endregion

                }
                #endregion

                Cursor.Current = Cursors.Default;

                //string rutaBase = @"C:\Users\iatan\Documents\Exportacion\Suministro";

                string rutaBase = "";
                FolderBrowserDialog diag = new FolderBrowserDialog();
                if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string folder = diag.SelectedPath;  //selected folder path
                    rutaBase = folder;    
                }
                System.IO.File.WriteAllText(System.IO.Path.Combine(rutaBase, "CABE_DOCU" + Logueo.Anio + Logueo.Mes + ".txt"), sbCabecera.ToString(),Encoding.Default);
                System.IO.File.WriteAllText(System.IO.Path.Combine(rutaBase, "DETA_DOCU" + Logueo.Anio + Logueo.Mes + ".txt"), sbDetalle.ToString(), Encoding.Default);
                Util.ShowMessage("Exportacion exitosa", 1);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al generar exportacion de movimiento");
            }
        }

        private void frmDocuSuministro_Load(object sender, EventArgs e)
        {
            
            try
            {
                

                this.popupImportar.Hide();
                OcultarModal();
                CrearColumnasImportacion();
                CrearColumnasValidacion();
            }
            catch (Exception ex) {
                Util.ShowError("Error al cargar formulario :" + ex.Message);
            }
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

        private void rbEntradas_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            OnBuscar();
        }

        private void rbSalidas_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            OnBuscar();
        }

        private void EliminarEnBloque() {
            string xml = "";
            try
            {
                string[] codigosSeleccionados = new string[gridControl.SelectedRows.Count];
                int x = 0;
                foreach (var filaSeleccionado in gridControl.SelectedRows)
                {                    
                    codigosSeleccionados[x] = filaSeleccionado.Cells["TipoDoc"].Value.ToString() + "|" + filaSeleccionado.Cells["CodigoDoc"].Value.ToString();                                        
                    x++;
                }
                                
                xml= Util.ConvertiraXMLdinamico(codigosSeleccionados);
                int flag = 0; string mensaje = "";
                DocumentoLogic.Instance.EliminarMovimientoSuministroBloque(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, xml, out flag, out mensaje);
                
                Util.ShowMessage(mensaje, flag);
                OcultarModal();
                OnBuscar();
                
            }
            catch (Exception ex) {
                Util.ShowError("Error al eliminar en blqoue:" + ex.Message);
            }
        }
        #region "importar movimiento de almacen"
        private void CargarImportacion() {
            try
            {
                var lista = DocumentoLogic.Instance.TraeMovimientoAlmacenImportado(Logueo.CodigoEmpresa, Logueo.UserName);
                this.dgvImportacion.DataSource = lista;
            }
            catch (Exception ex) {
                Util.ShowError("Error al cargar:" + ex.Message);
            }
        }
        private void ImportarCabeDOCU() 
        {
         
            try 
            {
                string descripcion = "";
                GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + "00016",
                                                     "RUTXDEFECTOINV", out descripcion);

                OpenFileDialog opf = new OpenFileDialog();
                var fic = "";
                var filename = "";
                opf.InitialDirectory = descripcion;

                if (opf.ShowDialog() == DialogResult.OK && opf.FileName.Length > 0)
                {
                    fic = opf.FileName;
                    filename = opf.SafeFileName;
                }
                  
                else return;
                Cursor.Current = Cursors.WaitCursor;
                var StreamReader = new System.IO.StreamReader(fic, Encoding.Default);
                string msj = string.Empty;
                string cDocuNumer = string.Empty;
                int contador = 0;
                string @cMoneda = "";
                float @nTipoCambio = 0;
                while (!StreamReader.EndOfStream)
                {
                    string[] linea = StreamReader.ReadLine().Split('¦');

                    string @cCodEmp = string.IsNullOrEmpty(linea[0]) ? "" : linea[0];
                    string @cAnno = string.IsNullOrEmpty(linea[1]) ? "" : linea[1];
                    string @cMes = string.IsNullOrEmpty(linea[2]) ? "" : linea[2];
                    string @cTipoDocu = string.IsNullOrEmpty(linea[3]) ? "" : linea[3];
                    string @cDocumento = string.IsNullOrEmpty(linea[4]) ? "" : linea[4];
                    string @dFechaDoc = string.IsNullOrEmpty(linea[5]) ? "" : linea[5];
                    string @cCodTra = string.IsNullOrEmpty(linea[6]) ? "" : linea[6];
                    string @cTransac = string.IsNullOrEmpty(linea[7]) ? "" : linea[7];
                     @cMoneda = string.IsNullOrEmpty(linea[8]) ? "" : linea[8];
                     @nTipoCambio = Convert.ToSingle(string.IsNullOrEmpty(linea[9]) ? "" : linea[9]);
                    string @cCodPro = string.IsNullOrEmpty(linea[10]) ? "" : linea[10];
                    string @cCodCli = string.IsNullOrEmpty(linea[11]) ? "" : linea[11];
                    string @cCenCos = string.IsNullOrEmpty(linea[12]) ? "" : linea[12];
                    string @cRespEnt = string.IsNullOrEmpty(linea[13]) ? "" : linea[13];
                    string @cResprec = string.IsNullOrEmpty(linea[14]) ? "" : linea[14];
                    string @cObra = string.IsNullOrEmpty(linea[15]) ? "" : linea[15];
                    string @cMaquina = string.IsNullOrEmpty(linea[16]) ? "" : linea[16];
                    string @cLote = string.IsNullOrEmpty(linea[17]) ? "" : linea[17];
                    string @cPedido = string.IsNullOrEmpty(linea[18]) ? "" : linea[18];
                    string @cRefDoc = string.IsNullOrEmpty(linea[19]) ? "" : linea[19];
                    string @cAlmaEm = string.IsNullOrEmpty(linea[20]) ? "" : linea[20];
                    string @cAlmaRe = string.IsNullOrEmpty(linea[21]) ? "" : linea[21];
                    string @cItem = string.IsNullOrEmpty(linea[22]) ? "" : linea[22];
                    string @cAnoItem = string.IsNullOrEmpty(linea[23]) ? "" : linea[23];
                    string @cObserva = string.IsNullOrEmpty(linea[24]) ? "" : linea[24];
                    string @cOrdComp = string.IsNullOrEmpty(linea[25]) ? "" : linea[25];
                    string @cFlaVen = string.IsNullOrEmpty(linea[26]) ? "" : linea[26];
                    string @cAlmaPro = string.IsNullOrEmpty(linea[27]) ? "" : linea[27];


                    //string @cProveedor = string.IsNullOrEmpty(linea[10]) ? "" : linea[10];
                    //string @cCliente = string.IsNullOrEmpty(linea[11]) ? "" : linea[11];
                    //string @cCenCosto = string.IsNullOrEmpty(linea[12]) ? "" : linea[12];
                    //string @cResponsable = string.IsNullOrEmpty(linea[13]) ? "" : linea[13];


                    //string @cObra = string.IsNullOrEmpty(linea[15]) ? "" : linea[15];
                    //string @cMaquinas = string.IsNullOrEmpty(linea[16]) ? "" : linea[16];

                    //string @cLotes = string.IsNullOrEmpty(linea[18]) ? "" : linea[18];
                    //string @cPedidos = string.IsNullOrEmpty(linea[19]) ? "" : linea[19];
                    //string @cAlmaEm = string.IsNullOrEmpty(linea[21]) ? "" : linea[20];
                    //string @cAlmaRe = "N";

                    contador = contador + 1;

                   
                        DocumentoLogic.Instance.ImportarCabDOCU(@cCodEmp,
 @cAnno,
 @cMes,
 @cTipoDocu,
 @cDocumento,
 @dFechaDoc,
 @cCodTra,
 @cTransac,
 @cMoneda,
 @nTipoCambio,
 @cCodPro,
 @cCodCli,
 @cCenCos,
 @cRespEnt,
 @cObra,
 @cMaquina,
 @cResprec,
 @cPedido,
 @cAlmaEm,
 @cAlmaRe,
 Logueo.PS_codnaturaleza,
out  @cDocuNumer,
out  msj);
                   
                }

                //Util.ShowMessage(msj, 1);




                //IMPORTAR DETALLE DOCUMENTO
                string directorio = opf.FileName;
                // Obtener solo el nombre del archivo sin la ruta
                string nombreArchivo = Path.GetDirectoryName(directorio);
                    string iniciales = "DETA_DOCU";
                    // Obtener archivos con las iniciales
                    string[] archivos = Directory.GetFiles(nombreArchivo)
                        .Where(file => Path.GetFileName(file).StartsWith(iniciales, StringComparison.OrdinalIgnoreCase))
                        .ToArray();
                    
                    if (archivos.Count() == 0) 
                    {
                        Util.ShowAlert("ERROR :: No se encontro el archivo txt DETA_DOCU en el Escritorio");
                        return;
                    }
                    string archivotxt = archivos[0].ToString();
                 
                    string contenido = File.ReadAllText(archivotxt);

                    ImportarDETADOCU(archivotxt, @nTipoCambio, @cMoneda);

            }catch(Exception ex)
            {
                Util.ShowError("ERROR :: Algo salio mal, vuelve a intentarlo");
            }
        }
        private void ImportarDETADOCU(string fic, float @nTipoCambio, string @cMoneda)
        {
            try
            {
                // recorrer el archivo en importar

                //OpenFileDialog opf = new OpenFileDialog();
                //var fic = "";
                //var filename = "";

                //if (opf.ShowDialog() == DialogResult.OK && opf.FileName.Length > 0)
                //{
                //    fic = opf.FileName;
                //    filename = opf.SafeFileName;
                //}
                //else return;

                var StreamReader = new System.IO.StreamReader(fic, Encoding.Default);
                string @cMsgRetorno = string.Empty;
                int @flagReturn = 0;
                string cDocuNumer = string.Empty;
                int contador = 0;

                while (!StreamReader.EndOfStream)
                {
                    string[] linea = StreamReader.ReadLine().Split('¦');

                    string @cCodEmp = string.IsNullOrEmpty(linea[0]) ? "" : linea[0];
                    string @cAA = string.IsNullOrEmpty(linea[1]) ? "" : linea[1];
                    string @cMM = string.IsNullOrEmpty(linea[2]) ? "" : linea[2];
                    string @cTipDoc = string.IsNullOrEmpty(linea[3]) ? "" : linea[3];
                    string @cCodDoc = string.IsNullOrEmpty(linea[4]) ? "" : linea[4];
                    string @cKey = string.IsNullOrEmpty(linea[5]) ? "" : linea[5];
                    float @nOrden = Convert.ToSingle(string.IsNullOrEmpty(linea[6]) ? "" : linea[6]);
                    float @nOrden2 = Convert.ToSingle(string.IsNullOrEmpty(linea[7]) ? "" : linea[7]);

                    string @cUniMed = string.IsNullOrEmpty(linea[8]) ? "" : linea[8];
                    string @dFecDoc = string.IsNullOrEmpty(linea[9]) ? "" : linea[9];
                    string @cCodAlm = string.IsNullOrEmpty(linea[10]) ? "" : linea[10];
                    string @cCodTra = string.IsNullOrEmpty(linea[11]) ? "" : linea[11];
                    string @cTransa = string.IsNullOrEmpty(linea[12]) ? "" : linea[12];
                    float @nCanArt = Convert.ToSingle(string.IsNullOrEmpty(linea[13]) ? "" : linea[13]);
                    float @nCosUni = Convert.ToSingle(string.IsNullOrEmpty(linea[14]) ? "" : linea[14]);
                    float @nCoUnSo = Convert.ToSingle(string.IsNullOrEmpty(linea[15]) ? "" : linea[15]);
                    float @nCoUnDo = Convert.ToSingle(string.IsNullOrEmpty(linea[16]) ? "" : linea[16]);
                    float @nImport = Convert.ToSingle(string.IsNullOrEmpty(linea[17]) ? "" : linea[17]);
                    float @nImpSol = Convert.ToSingle(string.IsNullOrEmpty(linea[18]) ? "" : linea[18]);
                    float @nImpDol = Convert.ToSingle(string.IsNullOrEmpty(linea[19]) ? "" : linea[19]);
                    float @nCosAlm = Convert.ToSingle(string.IsNullOrEmpty(linea[20]) ? "" : linea[20]);
                    float @nImpAlm = Convert.ToSingle(string.IsNullOrEmpty(linea[21]) ? "" : linea[21]);
                    float @nCoAlSo = Convert.ToSingle(string.IsNullOrEmpty(linea[22]) ? "" : linea[22]);
                    float @nIn07ImAlSo = Convert.ToSingle(string.IsNullOrEmpty(linea[23]) ? "" : linea[23]);
                    float @nCoAlDo = Convert.ToSingle(string.IsNullOrEmpty(linea[24]) ? "" : linea[24]);
                    float @nImAlDo = Convert.ToSingle(string.IsNullOrEmpty(linea[25]) ? "" : linea[25]);

                    //float @nImport = Convert.ToSingle(string.IsNullOrEmpty(linea[11]) ? "" : linea[11]);
                    //float @nTipoCambio = Convert.ToSingle(string.IsNullOrEmpty(linea[13]) ? "" : linea[13]);
                    //string @cMoneda = string.IsNullOrEmpty(linea[14]) ? "" : linea[14];

                    string @IN07CODBLOQUEEMP = string.IsNullOrEmpty(linea[26]) ? "" : linea[26];
                    string @IN07CODBLOQUEPROV = string.IsNullOrEmpty(linea[27]) ? "" : linea[27];
                    decimal @IN07LARGO = Convert.ToDecimal(string.IsNullOrEmpty(linea[28]) ? "" : linea[28]);
                    decimal @IN07ANCHO = Convert.ToDecimal(string.IsNullOrEmpty(linea[29]) ? "" : linea[29]);
                    decimal @IN07ALTO = Convert.ToDecimal(string.IsNullOrEmpty(linea[30]) ? "" : linea[30]);
                    decimal @IN07LARGOCAN = Convert.ToDecimal(string.IsNullOrEmpty(linea[31]) ? "" : linea[31]);
                    decimal @IN07ANCHOCAN = Convert.ToDecimal(string.IsNullOrEmpty(linea[32]) ? "" : linea[32]);
                    decimal @IN07ALTOCAN = Convert.ToDecimal(string.IsNullOrEmpty(linea[33]) ? "" : linea[33]);

                    string @IN07STATUS = "";
                    string @IN07NROCAJA = "";
                    string @IN07ORDPROD = "";
                    string @IN07PEDVEN = "";
                    string @IN07DocIngAA = "";
                    string @IN07DocIngMM = "";
                    string @IN07DocIngTIPDOC = "";
                    string @IN07DocIngCODDOC = "";
                    string @IN07DocIngKEY = "";
                    float @IN07DocIngORDEN = 0;
                    string @IN07FLAGSTOCKREAL = "";
                    string @IN07PROVMATPRIMA= ""; 
                    float @IN07AREAXUNI = 0;
                    string @in07pedvennum = "";
                    string @in07pedvencodprod = "";
                    float @in07pedvenitem = 0;
                    string @IN07CODCLI = "";
                    string @in07observacion = "";
                    string @IN07ORDENTRABAJO = "";
                    string @IN07CALIDADMP = "";

                    string @cAlmaRe = "N";

                    contador = contador + 1;

                    //if (contador > 1) // No se guarda la primera Fila
                    //{
                    DocumentoLogic.Instance.ImportarDETDOCU(@cCodEmp,
 @cAA,
 @cMM,
 @cTipDoc,
 @cCodDoc,
 @cKey,
 @cCodAlm,
 @cCodTra,
 @cTransa,
 @nCanArt,
 @nCosUni,
 @nImport,
 @dFecDoc,
 @nTipoCambio,
 @cMoneda,
 @nOrden,
 @cUniMed,
 @IN07CODBLOQUEEMP,
 @IN07CODBLOQUEPROV,
 @IN07LARGO,
 @IN07ANCHO,
 @IN07ALTO,
 @IN07LARGOCAN,
 @IN07ANCHOCAN,
 @IN07ALTOCAN,
 @IN07STATUS,

 @IN07NROCAJA,
 @IN07ORDPROD,
 @IN07PEDVEN,
 @IN07DocIngAA,
 @IN07DocIngMM,
 @IN07DocIngTIPDOC,
 @IN07DocIngCODDOC,
 @IN07DocIngKEY,
 @IN07DocIngORDEN,
 @IN07FLAGSTOCKREAL,
 @IN07PROVMATPRIMA,
 @IN07AREAXUNI,
 @in07pedvennum,
 @in07pedvencodprod,
 @in07pedvenitem,
 @IN07CODCLI,
 @in07observacion,
 @IN07ORDENTRABAJO,
 @IN07CALIDADMP, 
   
out  @flagReturn,
out  @cMsgRetorno);

                }

                Util.ShowMessage(@cMsgRetorno, @flagReturn);
            }
                    
            catch (Exception ex)
            {
                Util.ShowError("ERROR:: Algo salio mal" + ex);
            }
            Cursor.Current = Cursors.Default;
        }
        private void ImportarMPDet(string fic, float @nTipoCambio, string @cMoneda) 
        {
            try{
            // recorrer el archivo en importar

                //OpenFileDialog opf = new OpenFileDialog();
                //var fic = "";
                //var filename = "";

                //if (opf.ShowDialog() == DialogResult.OK && opf.FileName.Length > 0)
                //{
                //    fic = opf.FileName;
                //    filename = opf.SafeFileName;
                //}
                //else return;

            var StreamReader = new System.IO.StreamReader(fic, Encoding.Default);
            string msj = string.Empty;
            string cDocuNumer = string.Empty;
            int contador = 0;

            while (!StreamReader.EndOfStream)
            {
                string[] linea = StreamReader.ReadLine().Split('¦');

                string @cCodEmp = string.IsNullOrEmpty(linea[0]) ? "" : linea[0];
                string @cAnno = string.IsNullOrEmpty(linea[1]) ? "" : linea[1];
                string @cMes = string.IsNullOrEmpty(linea[2]) ? "" : linea[2];
                string @cTipDoc = string.IsNullOrEmpty(linea[3]) ? "" : linea[3];
                string @cNumDoc = string.IsNullOrEmpty(linea[4]) ? "" : linea[4];
                string @cKey = string.IsNullOrEmpty(linea[5]) ? "" : linea[5];
                float @nOrden = Convert.ToSingle(string.IsNullOrEmpty(linea[6]) ? "" : linea[6]);
                float @nOrden2 = Convert.ToSingle(string.IsNullOrEmpty(linea[7]) ? "" : linea[7]);

                string @cUnidad = string.IsNullOrEmpty(linea[8]) ? "" : linea[8];
                string @dFechaDoc = string.IsNullOrEmpty(linea[9]) ? "" : linea[9];
                string @cCodAlm = string.IsNullOrEmpty(linea[10]) ? "" : linea[10];
                string @cCodTra = string.IsNullOrEmpty(linea[11]) ? "" : linea[11];
                string @cTransa = string.IsNullOrEmpty(linea[12]) ? "" : linea[12];
                float @nCanArt = Convert.ToSingle(string.IsNullOrEmpty(linea[13]) ? "" : linea[13]);
                float @nCosUni = Convert.ToSingle(string.IsNullOrEmpty(linea[14]) ? "" : linea[14]);
                float @CoUnSo = Convert.ToSingle(string.IsNullOrEmpty(linea[15]) ? "" : linea[15]);
                float @nCoUnDo = Convert.ToSingle(string.IsNullOrEmpty(linea[16]) ? "" : linea[16]);
                float @nImport = Convert.ToSingle(string.IsNullOrEmpty(linea[17]) ? "" : linea[17]);
                float @nImpSol = Convert.ToSingle(string.IsNullOrEmpty(linea[18]) ? "" : linea[18]);
                float @nImpDol = Convert.ToSingle(string.IsNullOrEmpty(linea[19]) ? "" : linea[19]);
                float @nCosAlm = Convert.ToSingle(string.IsNullOrEmpty(linea[20]) ? "" : linea[20]);
                float @nImpAlm = Convert.ToSingle(string.IsNullOrEmpty(linea[21]) ? "" : linea[21]);
                float @nCoAlSo = Convert.ToSingle(string.IsNullOrEmpty(linea[22]) ? "" : linea[22]);
                float @nIn07ImAlSo = Convert.ToSingle(string.IsNullOrEmpty(linea[23]) ? "" : linea[23]);
                float nCoAlDo = Convert.ToSingle(string.IsNullOrEmpty(linea[24]) ? "" : linea[24]);
                float nImAlDo = Convert.ToSingle(string.IsNullOrEmpty(linea[25]) ? "" : linea[25]);
                //float @nImport = Convert.ToSingle(string.IsNullOrEmpty(linea[11]) ? "" : linea[11]);
                //float @nTipoCambio = Convert.ToSingle(string.IsNullOrEmpty(linea[13]) ? "" : linea[13]);
                //string @cMoneda = string.IsNullOrEmpty(linea[14]) ? "" : linea[14];
 
                string @IN07CODBLOQUEEMP = string.IsNullOrEmpty(linea[26]) ? "" : linea[26];
                string @IN07CODBLOQUEPROV = string.IsNullOrEmpty(linea[27]) ? "" : linea[27];
                decimal @IN07LARGO = Convert.ToDecimal(string.IsNullOrEmpty(linea[28]) ? "" : linea[28]);
                decimal @IN07ANCHO = Convert.ToDecimal(string.IsNullOrEmpty(linea[29]) ? "" : linea[29]);
                decimal @IN07ALTO = Convert.ToDecimal(string.IsNullOrEmpty(linea[30]) ? "" : linea[30]);
                decimal @IN07LARGOCAN = Convert.ToDecimal(string.IsNullOrEmpty(linea[31]) ? "" : linea[31]);
                decimal @IN07ANCHOCAN = Convert.ToDecimal(string.IsNullOrEmpty(linea[32]) ? "" : linea[32]);
                decimal @IN07ALTOCAN = Convert.ToDecimal(string.IsNullOrEmpty(linea[33]) ? "" : linea[33]);
                string @IN07STATUS = string.IsNullOrEmpty(linea[25]) ? "" : linea[34];

                string @cAlmaRe = "N";

                contador = contador + 1;

                //if (contador > 1) // No se guarda la primera Fila
                //{
                DocumentoLogic.Instance.ImportarMPDet(@cCodEmp,
                @cAnno,
                @cMes,
                @cTipDoc,
                @cNumDoc,
                @cKey,
                @cCodAlm,
                @cCodTra,
                @cTransa,
                @nCanArt,
                @nCosUni,
                @nImport,
                @dFechaDoc,
                @nTipoCambio,
                @cMoneda,
                @nOrden,
                @cUnidad,
                @IN07CODBLOQUEEMP,
                @IN07CODBLOQUEPROV,
                @IN07LARGO,
                @IN07ANCHO,
                @IN07ALTO,
                @IN07LARGOCAN,
                @IN07ANCHOCAN,
                @IN07ALTOCAN,
                @IN07STATUS,
                out  msj);
               
          }

            Util.ShowMessage(msj, 1);
        }catch(Exception ex)
        {
            Util.ShowError("ERROR:: Algo salio mal"+ex);
        }
        }
        private void ImportarMP()
        {
            string descripcion = "";
            GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + "00017",
                                                 "RUTXDEFECTOINV", out descripcion);
            
            
                OpenFileDialog opf = new OpenFileDialog();
                var fic = "";
                var filename = "";
               //abre el Dialog en la carpeta que desees 
                opf.InitialDirectory = descripcion;
                if (opf.ShowDialog() == DialogResult.OK && opf.FileName.Length > 0)
                {
                    fic = opf.FileName;
                    filename = opf.SafeFileName;
                }
                else return;
                try
                {

                    // recorrer el archivo en importar

                    var StreamReader = new System.IO.StreamReader(fic, Encoding.Default);
                    string msj = string.Empty;
                    string cDocuNumer = string.Empty;
                    int contador = 0;
                    string @cMoneda = "";
                    float @nTipoCambio = 0;
                    while (!StreamReader.EndOfStream)
                    {
                        string[] linea = StreamReader.ReadLine().Split('¦');
                    
                        string @cCodEmp = string.IsNullOrEmpty(linea[0]) ? "" : linea[0];
                        string @cAnno = string.IsNullOrEmpty(linea[1]) ? "" : linea[1];
                         string @cMes = string.IsNullOrEmpty(linea[2]) ? "" : linea[2];
                        string @cTipoDocu = string.IsNullOrEmpty(linea[3]) ? "": linea[3];
                       string @cDocumento = string.IsNullOrEmpty(linea[4]) ? "": linea[4];
                       string @dFechaDoc = string.IsNullOrEmpty(linea[5]) ? "": linea[5];
                       string @cCodTra = string.IsNullOrEmpty(linea[6]) ? "" : linea[6];
                        string @cTransac = string.IsNullOrEmpty(linea[7]) ? "": linea[7];
                         @cMoneda = string.IsNullOrEmpty(linea[8]) ? "" : linea[8];
                         @nTipoCambio = Convert.ToSingle(string.IsNullOrEmpty(linea[9]) ? "": linea[9]);
                        string @cProveedor = string.IsNullOrEmpty(linea[10]) ? "" : linea[10];
                        string @cCliente = string.IsNullOrEmpty(linea[11]) ? "" : linea[11];
                        string @cCenCosto = string.IsNullOrEmpty(linea[12]) ? "": linea[12];
                        string @cResponsable = string.IsNullOrEmpty(linea[13]) ? "": linea[13];

                        
                        string @cObra = string.IsNullOrEmpty(linea[15]) ? "" : linea[15];
                        string @cMaquinas = string.IsNullOrEmpty(linea[16]) ? "" : linea[16];

                        string @cLotes = string.IsNullOrEmpty(linea[18]) ? "" : linea[18];
                       string @cPedidos = string.IsNullOrEmpty(linea[19]) ? "": linea[19];
                        //ImportarMP.@cDocumento = string.IsNullOrEmpty(linea[20]) ? null : linea[20];
                       string @cAlmaEm = string.IsNullOrEmpty(linea[21]) ? "": linea[21];
                        string @cAlmaRe = "N";

                        contador = contador + 1;

                        //if (contador > 1) // No se guarda la primera Fila
                        //{
                            DocumentoLogic.Instance.ImportarMPCab(@cCodEmp, @cAnno, @cMes, @cTipoDocu, @cDocumento, @dFechaDoc,
                            @cCodTra,
                            @cTransac,
                            @cMoneda,
                            @nTipoCambio,
                            @cProveedor,
                            @cCliente,
                            @cCenCosto,
                            @cResponsable,
                            @cObra,
                            @cMaquinas,
                            @cLotes,
                            @cPedidos,
                            @cAlmaEm,
                            @cAlmaRe, out cDocuNumer, out msj);
                        //}
                    }

                    //Util.ShowMessage(msj, 1);




                    //ENCONTRAR ARCHIVO CON INICIALES
                    string directorio = opf.FileName;
                    string nombreArchivo = Path.GetDirectoryName(directorio);
                    //Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string iniciales = "MP_DETA_DOCU";
                    // Obtener archivos con las iniciales
                    string[] archivos = Directory.GetFiles(nombreArchivo)
                        .Where(file => Path.GetFileName(file).StartsWith(iniciales, StringComparison.OrdinalIgnoreCase))
                        .ToArray();
                    if (archivos.Count() == 0)
                    {
                        Util.ShowAlert("ERROR :: No se encontro el archivo txt MP_DETA_DOCU en el Escritorio");
                        return;
                    } 

                    string archivotxt = archivos[0].ToString();
                 
                    string contenido = File.ReadAllText(archivotxt);


                    ImportarMPDet(archivotxt, @nTipoCambio, @cMoneda);


                //OpenFileDialog opf = new OpenFileDialog();

                //var fic = "";
                //var filename = "";

                //if (opf.ShowDialog() == DialogResult.OK && opf.FileName.Length > 0)
                //{
                //    fic = opf.FileName;
                //    filename = opf.SafeFileName;
                //}
                //else return;


                //// Limpiar tabla antes de importar
                //string msjlimpiar = string.Empty;
                
                
                //DocumentoLogic.Instance.EliminarMovimientoAlmacenImportado(Logueo.CodigoEmpresa, Logueo.UserName);                


                //// Recorrer el archivo e importar
                //var sr = new System.IO.StreamReader(fic, Encoding.Default);
                //string msj = string.Empty;
                //int contadorFila = 0;
                //int flag = 0;
                //Cursor.Current = Cursors.WaitCursor;
                //string tipoDocumento,fecha, numero, tipoOperacion;
                //double entradaCantidad = 0, entradaCostoUnitario = 0, entradaCostoTotal = 0, salidaCantidad = 0, salidaCostoUnitario = 0, salidaCostoTotal = 0;
                //double saldoFinalCantidad = 0, saldoFinalCostoUnitario = 0, saldoFinalCostoTotal = 0;
                //string productoCodigoContasis = "", productoDescripcionContasis = "", productoUnimed = "", productoCodigoTraver = "", productoCodigoSap = "";
                //string ruc = "", razonSocial= "", ordenDeCompra = "";
                //string comentario = "", campoAdicional1 = "", campoAdicional2 = "", almacen = "";
                

                //while (!sr.EndOfStream)
                //{

                //    string[] linea = sr.ReadLine().Split('|');

                //    fecha = linea[0];
                    
                //    tipoDocumento = linea[1];
                //    numero = linea[2];
                //    tipoOperacion = linea[3];

                //    if (linea[4] == "")
                //    {
                //        entradaCantidad = 0;
                //    } else {
                //        entradaCantidad = Convert.ToDouble(linea[4]);
                //    }
                    
                //    //entradaCantidad = Convert.ToDouble(linea[4]);
                //    if (linea[5] == "") {
                //        entradaCostoUnitario = 0;
                //    }else{
                //        entradaCostoUnitario = Convert.ToDouble(linea[5]);
                //    }


                //    if (linea[6] == "")
                //    {
                //        entradaCostoTotal = 0;
                //    }
                //    else
                //    {
                //        entradaCostoTotal = Convert.ToDouble(linea[6]);
                //    }


                //    if (linea[7] == "")
                //    {                        
                //        salidaCantidad = 0;
                //    }
                //    else {
                //        salidaCantidad = Convert.ToDouble(linea[7]);
                        
                //    }

                //    if (linea[8] == "")
                //    {
                //        salidaCostoUnitario = 0;
                //    }
                //    else {
                //        salidaCostoUnitario = Convert.ToDouble(linea[8]);
                //    }


                //    if (linea[9] == "")
                //    {
                //        salidaCostoTotal = 0;
                //    }
                //    else
                //    {
                //        salidaCostoTotal = Convert.ToDouble(linea[9]);
                //    }


                //    if (linea[10] == "")
                //    {
                //        saldoFinalCantidad = 0;
                //    }
                //    else {
                //        saldoFinalCantidad = Convert.ToDouble(linea[10]);
                //    }


                //    if (linea[11] == "")
                //    {
                //        saldoFinalCostoUnitario = 0;
                //    }
                //    else {
                //        saldoFinalCostoUnitario = Convert.ToDouble(linea[11]);
                //    }


                //    if (linea[12] == "")
                //    {
                //        saldoFinalCostoTotal = 0;
                //    }
                //    else {
                //        saldoFinalCostoTotal = Convert.ToDouble(linea[12]);
                //    }

                    

                //    //almacen

                //    almacen = linea[13];
                //    //producto
                //    productoCodigoContasis = linea[14];

                //    productoDescripcionContasis = linea[15];
                //    productoUnimed = linea[16];
                    
                //    //se agrega un cero adelante al codigo
                //    productoCodigoTraver =linea[17];

                //    productoCodigoSap = linea[18];

                //    //cuenta corriente
                //    ruc = linea[19];
                //    razonSocial = linea[20];
                //    ordenDeCompra = linea[21];

                //    comentario = linea[22];
                //    campoAdicional1 = linea[23];
                //    campoAdicional2 = linea[24];



                //    //if (linea[1] != "T")
                //    //{
                //    //armar xml
                //    //dasd
                    
                    
                //    //aumnetar el contador en 1 para indicar la fila a ingresar en base de datos
                //    contadorFila++;

                //    //DocumentoLogic.Instance.InsertarGuiasTransporte(guiacabecera, guiadetalle, contadorFila, itemOrden, contratista, labor,
                //    //                                                                        Logueo.UserName, out flag, out mensaje);


                //    DocumentoLogic.Instance.InsertarMovimientoAlmacenImportado(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,contadorFila, 
                //        fecha, tipoDocumento, numero, tipoOperacion, entradaCantidad, entradaCostoUnitario, entradaCostoTotal, 
                //        salidaCantidad, salidaCostoUnitario, salidaCostoTotal, saldoFinalCantidad, saldoFinalCostoUnitario, saldoFinalCostoTotal,
                //        almacen, productoCodigoContasis, productoDescripcionContasis, productoUnimed, productoCodigoTraver, productoCodigoSap, 
                //        ruc, razonSocial, ordenDeCompra, comentario, campoAdicional1, campoAdicional2, Logueo.UserName, out flag, out msj);

                    
                //    //si importacion fue exitoso
                //    if (flag == -1)
                //    {
                //        Util.ShowError("Error al importar");
                //    }

                //}
                
                //Cursor.Current = Cursors.Default;

                //if (flag == 1) {
                //    CargarImportacion();
                //    this.popupImportar.Show();
                
            }
            catch (Exception ex)
            {
                Util.ShowError("Error en importar documento :" + ex.Message);
            }

        }
        protected override void OnImportarMP()
        {
            
            ImportarMP();
        }
        protected override void OnImportar()
        {
            ImportarCabeDOCU();
            Listar();
            //this.popupImportar.Show();

        }

        private void btnCancelaImportar_Click(object sender, EventArgs e)
        {
            this.popupImportar.Hide();
            //limpiar datos visualmente de las tablas
            this.dgvImportacion.DataSource = null;
            this.dgvValidacion.DataSource = null;


        }
        private void Validar()
        {
            //realizar la validacion de lso registros insertados a tabla temporal            
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataTable dt = DocumentoLogic.Instance.ValidacionMovimientoAlmacen(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, Logueo.UserName);
                this.dgvValidacion.DataSource = dt;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Util.ShowError("error:" + ex.Message);

            }
        }

        private void CrearColumnasImportacion() {
            RadGridView grilla = this.CreateGridVista(this.dgvImportacion);
            CreateGridColumn(grilla, "Fila", "Contador", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "Empresa", "Empresa", 0, "", 70, true, false, false);
            CreateGridColumn(grilla, "Anio", "Anio", 0, "", 70, true, false, false);
            CreateGridColumn(grilla, "Mes", "Mes", 0, "", 70, true, false, false);
            //Datetime fecha
            CreateGridColumn(grilla, "DOCUMENTO_FECHA", "DOCUMENTO_FECHA", 0, "{0:dd/MM/yyyy}", 70, true, false, true);
            CreateGridColumn(grilla, "DOCUMENTO_TIPO", "DOCUMENTO_TIPO", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "DOCUMENTO_NUMERO", "DOCUMENTO_NUMERO", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "DOCUMENTO_TIPOOPERACION", "DOCUMENTO_TIPOOPERACION", 0, "", 70, true, false, true);
            
            CreateGridColumn(grilla, "ENTRADA_CANTIDAD", "ENTRADA_CANTIDAD", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "ENTRADA_COSTOUNITARIO", "ENTRADA_COSTOUNITARIO", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "ENTRADA_COSTOTOTAL", "ENTRADA_COSTOTOTAL", 0, "", 70, true, false, true);

            CreateGridColumn(grilla, "SALIDA_CANTIDAD", "SALIDA_CANTIDAD", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "SALIDA_COSTOUNITARIO", "SALIDA_COSTOUNITARIO", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "SALIDA_COSTOTOTAL", "SALIDA_COSTOTOTAL", 0, "", 70, true, false, true);


            CreateGridColumn(grilla, "SALDOFINAL_CANTIDAD", "SALDOFINAL_CANTIDAD", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "SALDOFINAL_COSTOUNITARIO", "SALDOFINAL_COSTOUNITARIO", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "SALDOFINAL_COSTOTOTAL", "SALDOFINAL_COSTOTOTAL", 0, "", 70, true, false, true);

            CreateGridColumn(grilla, "ALMACEN", "ALMACEN", 0, "", 70, true, false, true);

            CreateGridColumn(grilla, "PRODUCTO_CODIGOCONTASIS", "PRODUCTO_CODIGOCONTASIS", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "PRODUCTO_DESCRIPCIONCONTASIS", "PRODUCTO_DESCRIPCIONCONTASIS", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "PRODUCTO_UNIMED", "PRODUCTO_UNIMED", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "PRODUCTO_CODIGOTRAVER", "PRODUCTO_CODIGOTRAVER", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "PRODUCTO_CODIGOSAP", "PRODUCTO_CODIGOSAP", 0, "", 70, true, false, true);
            
            //--CUENTACORRIENTE
            CreateGridColumn(grilla, "RUC", "RUC", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "RAZONSOCIAL", "RAZONSOCIAL", 0, "", 70, true, false, true);
            
            //--ORDEN COMPRA
            CreateGridColumn(grilla, "ORDENDECOMPRA", "ORDENDECOMPRA", 0, "", 70, true, false, true);


            //--CAMPOS ADICIONALES		
            CreateGridColumn(grilla, "COMENTARIOS", "COMENTARIOS", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "CAMPOADICIONAL1", "CAMPOADICIONAL1", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "CAMPOADICIONAL2", "CAMPOADICIONAL2", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "USUARIO", "USUARIO", 0, "", 70, true, false, false);            
            /*
           
@PRODUCTO_CODIGOCONTASIS	varchar(7),
@PRODUCTO_DESCRIPCIONCONTASIS varchar(100),
@PRODUCTO_UNIMED	 varchar(50),
@PRODUCTO_CODIGOTRAVER	varchar(8),
@PRODUCTO_CODIGOSAP varchar(20),


@RUC	 varchar(11),
@RAZONSOCIAL varchar(250),

--ORDEN COMPRA
@ORDENDECOMPRA varchar(50),


--CAMPOS ADICIONALES		
@COMENTARIOS varchar(50),
@CAMPOADICIONAL1 varchar(100),
@CAMPOADICIONAL2 varchar(100),
@USUARIO VARCHAR(50),
             */
        }

        private void CrearColumnasValidacion() {
            RadGridView grilla = this.CreateGridVista(this.dgvValidacion);
            CreateGridColumn(grilla, "Fila", "Contador", 0, "", 70, true, false, true);
            CreateGridColumn(grilla, "Errorcod", "Errorcod", 0, "", 120, true, false, true);
            CreateGridColumn(grilla, "Errordes", "Errordes", 0, "", 200, true, false, true);
            
           
            
            /*
             [Empresa] [char](2) NULL,
       [Anio] [char](4) NULL,
       [Mes] [char](2) NULL,
       [Contador] [int] Not NULL,
       [DOCUMENTO_FECHA] [datetime] NULL,
       [DOCUMENTO_TIPO] [char](1) NULL,
       [DOCUMENTO_NUMERO] [varchar](20) NULL,
       [DOCUMENTO_TIPOOPERACION] [varchar](100) NULL,
       [ENTRADA_CANTIDAD] [float] NULL,
       [ENTRADA_COSTOUNITARIO] [float] NULL,
       [ENTRADA_COSTOTOTAL] [float] NULL,
       [SALIDA_CANTIDAD] [float] NULL,
       [SALIDA_COSTOUNITARIO] [float] NULL,
       [SALIDA_COSTOTOTAL] [float] NULL,
       [SALDOFINAL_CANTIDAD] [float] NULL,
       [SALDOFINAL_COSTOUNITARIO] [float] NULL,
       [SALDOFINAL_COSTOTOTAL] [float] NULL,
       Almacen varchar(50),
       [PRODUCTO_CODIGOCONTASIS] [varchar](7) NULL,
       [PRODUCTO_DESCRIPCIONCONTASIS] [varchar](100) NULL,
       [PRODUCTO_UNIMED] [varchar](50) NULL,
       [PRODUCTO_CODIGOTRAVER] [varchar](8) NULL,
       [PRODUCTO_CODIGOSAP] [varchar](20) NULL,
       [RUC] [varchar](11) NULL,
       [RAZONSOCIAL] [varchar](250) NULL,
       [ORDENDECOMPRA] [varchar](50) NULL,
       [COMENTARIOS] [varchar](max) NULL,
       [CAMPOADICIONAL1] [varchar](100) NULL,
       [CAMPOADICIONAL2] [varchar](100) NULL,
       [USUARIO] [varchar](50) NULL,
       [Errorcod] [varchar](5) NULL,   
       [Errordes] [varchar](250) NULL
          
             */
        }

        private void btnImportarRegistros_Click(object sender, EventArgs e)
        {

     
            //LISTA- IMPORTE MP
           // OnImportar();


        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            Validar();
        }
        private void btnAceptarImportar_Click(object sender, EventArgs e)
        {

            ImportarMP ImportarMP = new ImportarMP();
            OpenFileDialog opf = new OpenFileDialog();
            var fic = "";
            var filename = "";
            try
            {

                // recorrer el archivo en importar

                //var StreamReader = new System.IO.StreamReader(fic, Encoding.Default);
                //string msj = string.Empty;
                //string cDocuNumer = string.Empty;
                //int contador = 0;

                //while (!StreamReader.EndOfStream)
                //{
                //    string[] linea = StreamReader.ReadLine().Split('¦');

                //    ImportarMP.IN06CODEMP = string.IsNullOrEmpty(linea[0]) ? null : linea[0];
                //    ImportarMP.IN06AA = string.IsNullOrEmpty(linea[1]) ? null : linea[1];
                //    ImportarMP.IN06MM = string.IsNullOrEmpty(linea[2]) ? null : linea[2];
                //    ImportarMP.IN06TIPDOC = string.IsNullOrEmpty(linea[3]) ? null : linea[3];
                //    ImportarMP.IN06CODDOC = string.IsNullOrEmpty(linea[4]) ? null : linea[4];
                //    ImportarMP.IN06FECDOC = string.IsNullOrEmpty(linea[5]) ? null : linea[5];
                //    ImportarMP.IN06CODTRA = Convert.ToDouble(string.IsNullOrEmpty(linea[6]) ? null : linea[6]);
                //    ImportarMP.IN06TRANSA = string.IsNullOrEmpty(linea[7]) ? null : linea[7];
                //    ImportarMP.IN06MONEDA = string.IsNullOrEmpty(linea[8]) ? null : linea[8];
                //    ImportarMP.IN06CAMBIO = string.IsNullOrEmpty(linea[9]) ? null : linea[9];
                //    ImportarMP.IN06CODPRO = string.IsNullOrEmpty(linea[10]) ? null : linea[10];
                //    ImportarMP.IN06CODCLI = string.IsNullOrEmpty(linea[11]) ? null : linea[11];
                //    ImportarMP.IN06CENCOS = Convert.ToDouble(string.IsNullOrEmpty(linea[12]) ? null : linea[12]);
                //    ImportarMP.IN06RESPENT = Convert.ToDouble(string.IsNullOrEmpty(linea[13]) ? null : linea[13]);
                //    ImportarMP.IN06RESPREC = Convert.ToDouble(string.IsNullOrEmpty(linea[14]) ? null : linea[14]);
                //    ImportarMP.IN06OBRA = Convert.ToDouble(string.IsNullOrEmpty(linea[15]) ? null : linea[15]);
                //    ImportarMP.IN06MAQUINA = Convert.ToDouble(string.IsNullOrEmpty(linea[16]) ? null : linea[16]);
                //    ImportarMP.IN06LOTE = string.IsNullOrEmpty(linea[17]) ? null : linea[17];
                //    ImportarMP.IN06PEDIDO = string.IsNullOrEmpty(linea[18]) ? null : linea[18];
                //    ImportarMP.IN06REFDOC = string.IsNullOrEmpty(linea[19]) ? null : linea[19];
                //    ImportarMP.IN06ALMAEM = string.IsNullOrEmpty(linea[20]) ? null : linea[20];
                //    ImportarMP.IN06ALMARE = string.IsNullOrEmpty(linea[21]) ? null : linea[21];
                //    ImportarMP.IN06FLAVEN = string.IsNullOrEmpty(linea[22]) ? null : linea[22];
                  
                //    contador = contador + 1;

                //    if (contador > 1) // No se guarda la primera Fila
                //    {
                //        DocumentoLogic.Instance.ImportarMPCab(ImportarMP, out cDocuNumer,out msj);
                //    }
                //}

               // Util.ShowMessage(msj, 1);

            }
            catch (Exception ex)
            {
                Util.ShowMessage("Error  "+ex, 1);
            }




            string mensaje = "";
            int flag = 0;


            try
            {
                Validar();
                if (dgvValidacion.Rows.Count > 0)
                {
                    Util.ShowAlert("Error al guardar, corriga las validaciones de la importacion");
                    return;
                }

                DocumentoLogic.Instance.InsertarImpMovAlmacen(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, Logueo.UserName, out flag, out mensaje);
                if (flag == 1)
                {
                    Util.ShowMessage(mensaje, flag);



                    //refresco la grilla principal de guias de transportista
                    OnBuscar();

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
            catch (Exception ex)
            {
                Util.ShowAlert("Error al guardar los datos importados:" + ex.Message);

            }

        }


        #endregion


        #region "Ventana modal eliminacion en blqoue"
        private void VerModal()
        {
            this.popupModal.Show();
            txtclaveConfirmar.Text = "";
        }

        private void OcultarModal() {
            this.popupModal.Hide();
            txtclaveConfirmar.Text = "";
        }
        private void btnAceptarModal_Click(object sender, EventArgs e)
        {
            if (txtclaveConfirmar.Text == "") {
                return;
            }

            //15092022

            if (txtclaveConfirmar.Text.Trim() == Logueo.clavePasada)
            {
                EliminarEnBloque();
            }
            else
            {
                Util.ShowAlert("No se Puede Elimnar , Clave No Valida");
            }

        }

        private void btnCancelarModal_Click(object sender, EventArgs e)
        {
            popupModal.Visible = false;

        }
        #endregion

        private void popupModal_Leave(object sender, EventArgs e)
        {
            OcultarModal();
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            OcultarModal();
        }




    }
}
