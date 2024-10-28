using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessEntities;
using Inv.BusinessLogic;
using System.Linq;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
namespace Prod.UI.Win.Procesos
{
    public partial class frmProduccion : frmBase
    {     
        public string codigoDocumento = "";
        public string TipDoc = "";
        public static frmProduccion formulario;
        private frmMDI FrmParent { get; set; }
        private static frmProduccion _aForm;
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

        private void accesobtonesxperfil()
        {
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.codModulo, this.Name, out nuevo_a, 
                                                                    out editar_a, out eliminar_a, out ver_a, out imprimir_a, 
                                                                     out refrescar_a, out importar_a, out vista_a,
                                                                    out guardar_a, out cancelar_a, out expmovi_a, out importarMP);
        }
        public static frmProduccion Instance(frmMDI mdiPrincipal) {
            if (_aForm != null) return new frmProduccion(mdiPrincipal);
            _aForm = new frmProduccion(mdiPrincipal);
            return _aForm;
        }
        public frmProduccion(frmMDI mdiPrincipal)
        {
            InitializeComponent();
            FrmParent = mdiPrincipal;
            crearColumnas();
            OnBuscar();
            //habilitarBotones(true, true, true, true, true, true);
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
            cbbImportar = menu.Items["cbbImportarMovimientos"];
            accesobtonesxperfil();
            
            ComportarmientoBotones("cargar");
            formulario = this;
        }
        OrdenTrabajo orden = new OrdenTrabajo();
        void crearColumnas() {
            RadGridView grilla = this.CreateGridVista(gridControl);

            this.CreateGridColumn(grilla, "Fecha", "FechaDoc", 0, "{0:dd/MM/yyyy}", 90, true, false, true);
            this.CreateGridColumn(grilla, "TipoDoc", "CodTipDoc", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "TipoDocumento", "TipoDocumento", 0, "", 300);
            this.CreateGridColumn(grilla, "Numero", "Numero", 0, "", 100);
            //this.CreateGridColumn(grilla, "Codtransa", "Codtransa", 0, "", 50, true, false);
            this.CreateGridColumn(grilla, "DocRespaldo", "DocRespaldo", 0, "", 200);
            this.CreateGridColumn(grilla, "ReferenciaDoc", "DocRespaldoNro", 0, "", 70);
            this.CreateGridColumn(grilla, "Linea", "Linea", 0, "", 90);
            this.CreateGridColumn(grilla, "Proceso", "Proceso", 0, "", 100);
            this.CreateGridColumn(grilla, "Turno", "Turno", 0, "", 100);
            //this.CreateGridColumn(grilla, "CodTipDoc", "CodTipDoc", 0, "", 100, true, false, false);
            
            this.CreateGridColumn(grilla, "DescripcionMaquina", "DescripcionMaquina", 0, "", 120);
            this.CreateGridColumn(grilla, "OrigenTipo", "OrigenTipo", 0, "", 120);
            gridControl.MultiSelect = false;
        }
        void cargarEntidad() { 
            //orden.codigo 
        }
        public void  listar()
        {
            OnBuscar();
        }    
        protected override void OnBuscar()
        {
            
            var lista = DocumentoLogic.Instance.TraerProduccion(Logueo.CodigoEmpresa,Logueo.Anio,
                                                                Logueo.Mes,(this.rbIngreso.CheckState == CheckState.Checked) ? "E" : "S"
                                                                , Logueo.PP_codnaturaleza); 
            this.gridControl.DataSource = lista;
        }         

        protected override void OnNuevo()
        {
            Cursor.Current = Cursors.WaitCursor;
            
            Estado = FormEstate.New;

            frmDetalleProduccion.Instance(this).Show();
            //ComportarmientoBotones("nuevo");
            Cursor.Current = Cursors.Default;
        }
        protected override void OnEliminar()
        {
            if (gridControl.RowCount == 0) return;

            string CodTipDoc = this.gridControl.CurrentRow.Cells["CodTipDoc"].Value.ToString();
            string nroDoc = this.gridControl.CurrentRow.Cells["Numero"].Value.ToString();

            if (this.gridControl.CurrentRow.Cells["OrigenTipo"].Value.ToString() == "A")
            {
                RadMessageBox.Show("No puede editar o eliminar un documento autogenerado ", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }

            int cantidad = 0;
            DocumentoLogic.Instance.TraerCantidadDetallexNroDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, CodTipDoc, nroDoc, out cantidad);
            
            if (cantidad > 0) {
                RadMessageBox.Show("No se puede eliminar porque el documento tiene detalle. ", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }

            DocumentoLogic.Instance.TraerCantidadOrdenesxNroDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, CodTipDoc, nroDoc, out cantidad);
            if (cantidad > 0) {
                RadMessageBox.Show("No se puede eliminar porque el documento tiene ordenes de trabajo.", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }        

            DialogResult res = RadMessageBox.Show("¿Desea eliminar?", "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (res == System.Windows.Forms.DialogResult.Yes) {
                Documento doc = new Documento();
               
                doc.CodigoEmpresa = Logueo.CodigoEmpresa;              
                doc.Mes = Logueo.Mes;
                doc.Anio = Logueo.Anio;
                doc.TipoDoc = CodTipDoc;
                doc.CodigoDoc = nroDoc;                                
                string mensaje = string.Empty;
                DocumentoLogic.Instance.EliminarProduccionCabecera(doc, out mensaje);
                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                
                OnBuscar();
                //doc.Transaccion
                //eliminar
                
                //DocumentoLogic.Instance.EliminarDocumentoMP(
            }
            
        }

        protected override void OnEditar()
        {

            if (gridControl.ChildRows.Count == 0) return;

            if (this.gridControl.CurrentRow.Cells["OrigenTipo"].Value.ToString() == "A")
            {
                RadMessageBox.Show("No puede editar o eliminar un documento Autogenerado ", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            Estado = FormEstate.Edit;

            frmDetalleProduccion.Instance(this).Show();
            //ComportarmientoBotones("editar");
            Cursor.Current = Cursors.Default;
        }
        protected override void OnVista()
        {
            
        }
        protected override void OnVer()
        {
            if (gridControl.ChildRows.Count == 0) return;
            
            Estado = FormEstate.View;
            Cursor.Current = Cursors.WaitCursor;
            frmDetalleProduccion.Instance(this).Show();
            Cursor.Current = Cursors.Default;
            
        }
        protected override void OnRefrescar()
        {
            OnBuscar();
        }
        private void toolBar_Click(object sender, EventArgs e)
        {

        }

        private void rbSalida_CheckStateChanged(object sender, EventArgs e)
        {
            OnBuscar();
            habilitarBotones(true, true, true, true, false, true);
        }

        private void rbIngreso_CheckStateChanged(object sender, EventArgs e)
        {
            OnBuscar();
            habilitarBotones(true, true, true, true, false, true);
        }

        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            OnVer();
        }
        

    }
}
