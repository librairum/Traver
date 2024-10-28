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
namespace Inv.UI.Win.Procesos
{
    public partial class frmDocuMP : frmBase
    {
        #region "Documento"
        public static frmDocuMP formulario;
        private frmMDI FrmParent { get; set; }
        private static frmDocuMP _aForm;
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
        public static frmDocuMP Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmDocuMP(mdiPrincipal);
            _aForm = new frmDocuMP(mdiPrincipal);
            return _aForm;
        }
        public static frmDocuMP Instancia()
        {
            return _aForm;
        }
        public frmDocuMP(frmMDI padre)
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

            cbbGuardar = menu.Items["cbbGuardar"];
            cbbCancelar = menu.Items["cbbCancelar"];
            cbbExportarMovimientos = menu.Items["cbbExportarMovimientos"];
            accesobtonesxperfil();
            ComportarmientoBotones("cargar");
            //this.cargarPermisos(this.Name);
            //HabilitarBotones(true, true, true, true, true, true, true, false);
            //this.Nuevo = (variable.Substring(0, 1).CompareTo("1") == 0);--
            //this.eliminar = (variable.Substring(5, 1).CompareTo("1") == 0);--

            //this.gestionrBotonesxopcformulario(nuevo, eliminar, Editar);--


            
            formulario = this;
        }
        private void Crearcolumnas()
        {
            RadGridView grilla =  this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(grilla, "E/S", "Transaccion", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Cod.Tran.", "TipoDoc", 0, "", 80, true, false, true);
            this.CreateGridColumn(grilla, "Transaccion", "in12DesLar", 0, "", 200, true, false, true);
            this.CreateGridColumn(grilla, "Número", "CodigoDoc", 0, "", 120, true, false, true);
            this.CreateGridColumn(grilla, "Fecha", "FechaDoc", 0, "{0:dd/MM/yyyy}", 90, true, false, true);
            this.CreateGridColumn(grilla, "Doc Referencia", "CodigoTransa", 0, "", 80, true, false, true);
            this.CreateGridColumn(grilla, "Documento", "in15Descripcion", 0, "", 250, true, false, true);
            this.CreateGridColumn(grilla, "Referencia", "ReferenciaDoc", 0, "", 200, true, false, true);

            this.CreateGridColumn(grilla, "Moneda", "Moneda", 0, "", 120, true, false, true);
            this.CreateGridColumn(grilla, "Tipo de Cambio", "TipoCambio", 0, "", 135, true, false, true);
            //this.CreateGridColumn(grilla, "Tipo de Cambio", "in15Descripcion", 0, "", 120, true, false, true);          
        }
        protected override void OnBuscar()
        {
            Listar();
        }        
        public void Listar()
        {
            try
            {
                //base.OnBuscar();
                var lista = DocumentoLogic.Instance.TraerDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, "In06CodDoc", "In06CodDoc", "*",
                    (this.rbEntradas.CheckState == CheckState.Checked) ? "E" : "S", Logueo.MP_codnaturaleza);
               
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
            frmMoviMP.Instance(this).Show();
            this.Cursor = Cursors.Default;
            //var instancia = frmMoviMP.Instance(this);
            ////para valir uso esta variable
            //var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMovi);

            //if (frmexiste != null)
            //{
            //    instancia.BringToFront();
            //    //instancia.Focus();
            //    return;
            //}
            //Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            //instancia._esEntrada = rbEntradas.CheckState == CheckState.Checked ? true : false;
            
            //instancia.Estado = FormEstate.New;
            //instancia.MdiParent = this.ParentForm;
            
            //((RadDock)(ctrl)).ActivateMdiChild(instancia);
            //instancia.Show();
        }
        protected override void OnRefrescar()
        {
            Listar();
        }        
        protected override void OnEditar()
        {
            if (this.gridControl.RowCount == 0)
                return;
            Estado = FormEstate.Edit;
            Cursor = Cursors.WaitCursor;
            frmMoviMP.Instance(this).Show();
            Cursor = Cursors.Default;
            //string tipoDocumento = string.Empty;
            //string codigoDocumento = string.Empty;
            //tipoDocumento = this.gridControl.CurrentRow.Cells["TipoDoc"].Value.ToString();
            //codigoDocumento = this.gridControl.CurrentRow.Cells["CodigoDoc"].Value.ToString();
            //instancia unica del formulario
            /*--------------------------------------/*/
            //var instancia = frmMoviMP.Instance(this);
            ////para validar uso esta variable
            //var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMovi);

            //if (frmexiste != null)
            //{
            //    instancia.BringToFront();

            //    return;
            //}
            ////busco el control radDock(contenedor de formularios) en formulario padre frmMDI
            //Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            //instancia.esEntrada = rbEntradas.CheckState == CheckState.Checked ? true : false;
            ////envio de datos del documento a editar habia formulario movimiento
            //instancia.tipoDocumento = tipoDocumento;
            //instancia.nroDocumento = codigoDocumento;

            ////indico es modod edicion
            //instancia.Estado = FormEstate.Edit;
            
            ////indico el formulario hijo frmMovi es hijo del padre de frmDocu
            ////el formulario padre de frmDocu es frmMDI
            //instancia.MdiParent = this.ParentForm;
            
            ////cuando encuentoe el control lo convierto e 
            ////indico abrir esa ventana en el contenedor principa
            //((RadDock)(ctrl)).ActivateMdiChild(instancia);

            ////envio desde el formulario frmDocu el valor de la grilla hacia una variable
            ////tipo gridview _grid 
            //instancia._grid = gridControl;

            ////muestro el formulario 
            //instancia.Show();
        }        
        protected override void OnVer()
        {
            Estado = FormEstate.View;
            Cursor = Cursors.WaitCursor;
            frmMoviMP.Instance(this).Show();
            Cursor = Cursors.Default;
          //  string tipoDocumento = string.Empty;
          //  string codigoDocumento = string.Empty;

          //  tipoDocumento = this.gridControl.CurrentRow.Cells["TipoDoc"].Value.ToString();
          //  codigoDocumento = this.gridControl.CurrentRow.Cells["CodigoDoc"].Value.ToString();
          //  /*Codigo para validar formulario repetido*/
          //  /*instancia del formulario*/
          //    /*--------------------------------------/*/
          //  var instancia = frmMoviMP.Instance(this);
          //  instancia.pos = this.gridControl.CurrentRow.Index;
          //  //para valir uso esta variable

          //  var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMovi);

          //  if (frmexiste != null)
          //  {
          //      instancia.BringToFront();
          ////      frmexiste.BringToFront();
          //      //instancia.Focus();
          //      return;
          //  }

          //  Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
          //  instancia._esEntrada = (rbEntradas.IsChecked ? true : false);
          //  instancia._nroDocumento = codigoDocumento; 
          //  instancia._tipoDocumento = tipoDocumento; 
          //  instancia.Estado = FormEstate.View;
          //  instancia.MdiParent = this.ParentForm;

          //  ((RadDock)(ctrl)).ActivateMdiChild(instancia);
          //  //instancia.gridAyuda = gridControl;
          //  instancia._grid = gridControl;
          //  instancia.pos = gridControl.CurrentRow.Index;
                        
          //  instancia.Show();
        }
        protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;
            string[] registros = new string[this.gridControl.SelectedRows.Count];
            int x = 0;
            foreach (GridViewRowInfo fila in gridControl.SelectedRows)
            {

                registros[x] = Util.GetCurrentCellText(fila, "TipoDoc") + "|" +
                               Util.GetCurrentCellText(fila, "CodigoDoc");
                x++;
            }

            //xmlDetalle
            var datos = DocumentoLogic.Instance.TraeRepResExpSalMPDet(Logueo.CodigoEmpresa,
            Logueo.Anio, Logueo.Mes, Util.ConvertiraXMLdinamico(registros));

            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();
            reporte.Nombre = "RptValeResMP.rpt";
            
            reporte.DataSource = datos;

            reporte.FormulasFields.Add(new Formula("Ano", Logueo.Anio));
            reporte.FormulasFields.Add(new Formula("Mes", Logueo.Mes));
            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));

            ReporteControladora control = new ReporteControladora(reporte);
            //control.Imprimir();
            control.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.WaitCursor;

        }

        protected override void OnEliminar()
        {
            if (this.gridControl.RowCount == 0)
                return;
            try
            {
                DialogResult result = RadMessageBox.Show("Está seguro de eliminar el movimiento", Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR, MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
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

                    DocumentoLogic.Instance.EliminarDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, tipoDocumento, codigoDocumento, transMov, fechaDoc, tipoCambio, moneda, out msgRetorno);

                    RadMessageBox.Show(msgRetorno, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);
                    OnBuscar();
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

                //
                var codigosSeleccionados = new string[gridControl.SelectedRows.Count];
                var y = 0;
                string TipDocAnterior;

                foreach (var filaSeleccionado in gridControl.SelectedRows)
                {
                  codigosSeleccionados[y] = filaSeleccionado.Cells["TipoDoc"].Value.ToString() + '|' + filaSeleccionado.Cells["CodigoDoc"].Value.ToString();
                  y++;
                //// === Validar que solo se pueda agrupar una solo transaccion 
                //    if filaSeleccionado.Cells["TipoDoc"].Value.ToString()==TipDocAnterior
                //        {

                //        VALIDAR :: Solo se puede agrupar una misma transaccion
                //        return 
                //        }

                //        TipDocAnterior = filaSeleccionado.Cells["TipoDoc"].Value.ToString();
                //// === Validar que no se puede agrupar Cod Doc Alfanumerico
                //    if filaSeleccionado.Cells["CodigoDoc"].Value.ToString()==numero
                //        {
                //        VALIDAR :: No se puede agrupar, Codigos AlfaNumericos
                //        return
                //        }
                }

                List<Documento> CabeceraDoc = DocumentoLogic.Instance.TraeResExpSalMP(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, Util.ConvertiraXMLdinamico(codigosSeleccionados));
                foreach (Documento filacabecera in CabeceraDoc)
                    {
                    sbCabecera.AppendLine(Logueo.CodigoEmpresa + "¦" + Logueo.Anio + "¦" +
                    Logueo.Mes + "¦" + filacabecera.TipoDoc + "¦" +
                    filacabecera.CodigoDoc + "¦" + filacabecera.FechaDoc.Value.ToShortDateString() + "¦" +
                    filacabecera.IN06CODTRAANTERIOR + "¦" + filacabecera.Transaccion + "¦" +
                    filacabecera.Moneda + "¦" + filacabecera.TipoCambio + "¦" +
                    filacabecera.CodigoProveedor + "¦" + filacabecera.CodigoCliente + "¦" +
                    filacabecera.CentroCostoMP + "¦" +
                    filacabecera.Responsable + "¦" + filacabecera.ResponsableReceptor + "¦" +
                    filacabecera.CodigoObra + "¦" + filacabecera.CodigoMaquina + "¦" +
                    filacabecera.Lote + "¦" + filacabecera.Pedido + "¦" +
                    filacabecera.ReferenciaDoc + "¦" + filacabecera.CodigoAlmacenEmisor + "¦" +
                    filacabecera.CodigoAlmacenReceptor + "¦" + filacabecera.Item + "¦" +
                    filacabecera.AnioItem + "¦" + filacabecera.Observacion + "¦" +
                    filacabecera.OrdenCompra + "¦" + filacabecera.FlagVen + "¦" + "" + "¦");
                    }

                List<MovimientoResponse> detalle = DocumentoLogic.Instance.TraeResExpSalMPDet(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, Util.ConvertiraXMLdinamico(codigosSeleccionados));
                 
                int orden;
                orden = 1;

                    foreach (MovimientoResponse filaDetalle in detalle)
                    {
                        sbDetalle.AppendLine(filaDetalle.CodigoEmpresa + "¦" +
                            filaDetalle.Anio + "¦" +
                            filaDetalle.Mes + "¦" +
                            filaDetalle.CodigoTipoDocumento + "¦" +
                            filaDetalle.CodigoDocumento + "¦" +
                            filaDetalle.CodigoArticulo + "¦" +
                            orden + "¦" +
                            "0" + "¦" +
                            filaDetalle.UnidadMedida + "¦" +
                            filaDetalle.FechaDoc.Value.ToShortDateString() + "¦" +
                            filaDetalle.CodigoAlmacen + "¦" +
                            filaDetalle.IN07CODTRAANTERIOR + "¦" +
                            filaDetalle.Transaccion + "¦" +
                            filaDetalle.Cantidad + "¦" +
                            Util.Redondear(filaDetalle.CostoUnidad, 2) + "¦" +
                            Util.Redondear(filaDetalle.CostoSoles, 2) + "¦" +
                            Util.Redondear(filaDetalle.CostoDolares, 2) + "¦" +
                            Util.Redondear(filaDetalle.Importe, 2) + "¦" +
                            Util.Redondear(filaDetalle.ImporteSoles, 2) + "¦" +
                            Util.Redondear(filaDetalle.ImporteDolar, 2) + "¦" +
                            Util.Redondear(filaDetalle.CostoAlmacen, 2) + "¦" +
                            Util.Redondear(filaDetalle.ImporteAlmacen, 2) + "¦" +
                            Util.Redondear(filaDetalle.CostoAlmacenSoles, 2) + "¦" +
                            Util.Redondear(filaDetalle.ImporteAlmacenSoles, 2) + "¦" +
                            Util.Redondear(filaDetalle.CostoAlmacenDolar, 2) + "¦" +
                            Util.Redondear(filaDetalle.ImporteAlmacenDolar, 2) + "¦" +
                            filaDetalle.NroCaja + "¦" +
                            filaDetalle.CodBloqProv + "¦" +
                            Util.convertiracadena(filaDetalle.Largo) + "¦" + Util.convertiracadena(filaDetalle.Ancho) + "¦" +
                            Util.convertiracadena(filaDetalle.Alto) + "¦" + Util.convertiracadena(filaDetalle.LargoCan) + "¦" +
                            Util.convertiracadena(filaDetalle.AnchoCan) + "¦" + Util.convertiracadena(filaDetalle.AltoCan) + "¦");

                        orden++;
                    }

                Cursor.Current = Cursors.Default;

                string rutaBase = "";
                FolderBrowserDialog diag = new FolderBrowserDialog();
                if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string folder = diag.SelectedPath;  //selected folder path
                    rutaBase = folder;
                }
                System.IO.File.WriteAllText(System.IO.Path.Combine(rutaBase, "MP_CABE_DOCU" + Logueo.Anio + Logueo.Mes + ".txt"), sbCabecera.ToString(), Encoding.Default);
                System.IO.File.WriteAllText(System.IO.Path.Combine(rutaBase, "MP_DETA_DOCU" + Logueo.Anio + Logueo.Mes + ".txt"), sbDetalle.ToString(), Encoding.Default);
                Util.ShowMessage("Exportacion exitosa", 1);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al generar exportacion de movimiento");
            }
        }
        protected  void OnExportarMovimientos_ant()
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

                    sbCabecera.AppendLine(Logueo.CodigoEmpresa + "¦" + Logueo.Anio + "¦" +
                    Logueo.Mes + "¦" + CabeceraDoc.TipoDoc + "¦" +
                    CabeceraDoc.CodigoDoc + "¦" + CabeceraDoc.FechaDoc.Value.ToShortDateString() + "¦" +
                    CabeceraDoc.IN06CODTRAANTERIOR + "¦" + CabeceraDoc.Transaccion + "¦" +
                    CabeceraDoc.Moneda + "¦" + CabeceraDoc.TipoCambio + "¦" +
                    CabeceraDoc.CodigoProveedor + "¦" + CabeceraDoc.CodigoCliente + "¦" +
                    CabeceraDoc.CentroCostoMP + "¦" + 
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
                            Util.Redondear(filaDetalle.CostoUnidad, 2) + "¦" +
                            Util.Redondear(filaDetalle.CostoSoles, 2) + "¦" +
                            Util.Redondear(filaDetalle.CostoDolares, 2) + "¦" +
                            Util.Redondear(filaDetalle.Importe, 2) + "¦" +
                            Util.Redondear(filaDetalle.ImporteSoles, 2) + "¦" +
                            Util.Redondear(filaDetalle.ImporteDolar, 2) + "¦" +
                            Util.Redondear(filaDetalle.CostoAlmacen, 2) + "¦" +
                            Util.Redondear(filaDetalle.ImporteAlmacen, 2) + "¦" +
                            Util.Redondear(filaDetalle.CostoAlmacenSoles, 2) + "¦" +
                            Util.Redondear(filaDetalle.ImporteAlmacenSoles, 2) + "¦" +
                            Util.Redondear(filaDetalle.CostoAlmacenDolar, 2) + "¦" +
                            Util.Redondear(filaDetalle.ImporteAlmacenDolar, 2) + "¦" +
                            filaDetalle.NroCaja + "¦" +
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
                System.IO.File.WriteAllText(System.IO.Path.Combine(rutaBase, "MP_CABE_DOCU" + Logueo.Anio + Logueo.Mes + ".txt"), sbCabecera.ToString(), Encoding.Default);
                System.IO.File.WriteAllText(System.IO.Path.Combine(rutaBase, "MP_DETA_DOCU" + Logueo.Anio + Logueo.Mes + ".txt"), sbDetalle.ToString(), Encoding.Default);
                Util.ShowMessage("Exportacion exitosa", 1);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al generar exportacion de movimiento");
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
        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (gridControl.IsLoaded) {
                if (gridControl.RowCount > 0) {
                    if (e.Row.Cells["CodigoDoc"].Value != null)
                    {
                        OnVer();
                    }
                }
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
        private void frmDocuMP_Activated(object sender, EventArgs e)
        {
            OnBuscar();
        }



    }
}
