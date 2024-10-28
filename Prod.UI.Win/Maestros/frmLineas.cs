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
using Telerik.WinControls.UI;
namespace Prod.UI.Win.Maestros
{
    public partial class frmLineas : frmBaseMante
    {

        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a,
            cancelar_a, expmovi_a, importarMP;
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
        private bool isLoaded = true;
        private frmMDI FrmParent { get; set; }
        private static frmLineas _aForm;
        public static frmLineas Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmLineas(mdiPrincipal);
            _aForm = new frmLineas(mdiPrincipal);
            return _aForm;
        }
      
        Linea linea = new Linea();
        public frmLineas(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            crearColumnas();
            OnBuscar();
            menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
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
            OnCancelar();
            isLoaded = true;
        }
                          
        #region "Metodos de formulario"
        private void accesobtonesxperfil()
        {
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.codModulo, this.Name, 
                                                                    out nuevo_a, out editar_a, out eliminar_a, 
                                                                    out ver_a, out imprimir_a, out refrescar_a, 
                                                                    out importar_a, out vista_a, out guardar_a,
                                                                    out cancelar_a, out expmovi_a, out importarMP);
        }
        private void ComportarmientoBotones(string accion)
        {

            switch (accion)
            {
                case "cargar":
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
                    break;
            }

        }
        #endregion
        bool Validar() {
            cbbGuardar.IsMouseOver = false;
            if (this.txtCodigo.Text.Length == 0 || string.IsNullOrEmpty(txtCodigo.Text)) 
            {
                RadMessageBox.Show("Ingresar Codigo.", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtCodigo.Focus();
                return false;
            }
            if (this.txtDescripcion.Text.Length == 0 || string.IsNullOrEmpty(txtDescripcion.Text.Trim())) 
            {
                RadMessageBox.Show("Ingresar Descripcinn.", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtDescripcion.Focus();
                return false;
            }
            return true;
        }

        void limpiar() {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
        }
        void cargarEntidad() {
            linea.codigoEmpresa = Logueo.CodigoEmpresa;
            linea.codigo = txtCodigo.Text;
            linea.descripcion = txtDescripcion.Text;
        }

        void crearColumnas() {
            RadGridView grilla = CreateGridVista(this.gridControl);
            this.CreateGridColumn(grilla, "codigoEmpresa", "codigoEmpresa", 0, "", 30, true, false, false);
            this.CreateGridColumn(grilla, "codigo", "codigo", 0, "", 150);
            this.CreateGridColumn(grilla, "descripcion", "descripcion", 0, "", 300);
        }
        void enfocaRegistroAnterior()
        {
            int indice = gridControl.CurrentRow.Index;
            //OnCargar();
            OnBuscar();
            if (indice > 0)
            {
                gridControl.MasterView.Rows[indice - 1].IsSelected = true;
                gridControl.MasterView.Rows[indice - 1].IsCurrent = true;
            }
        }
        protected override void OnBuscar() {
            var lista = LineaLogic.Instance.LineaTraer(Logueo.CodigoEmpresa);
            this.gridControl.DataSource = lista;
        }
        protected override void OnCancelar() {
            Estado = FormEstate.List;
            limpiar();
            OnBuscar();            
            txtCodigo.Enabled = false; 
            txtDescripcion.Enabled = false;
            //HabilitarBotones(true, true, true, false, false, false);
            ComportarmientoBotones("cancelar");
        }
        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            txtDescripcion.Enabled = true;
            limpiar();
            
            txtCodigo.Enabled = false;

            string codigo = string.Empty;
            LineaLogic.Instance.LineaGeneraCodigo(Logueo.CodigoEmpresa, out codigo);
            txtCodigo.Text = codigo;

            txtDescripcion.Focus();

            //HabilitarBotones(false, false, false, true, true, false);
            ComportarmientoBotones("nuevo");
        }
        protected override void OnEditar()
        {
            if (gridControl.ChildRows.Count == 0) return;
            Estado = FormEstate.Edit;
            txtDescripcion.Enabled = true;
            //HabilitarBotones(false, false, false, true, true, false);
            ComportarmientoBotones("editar");
        }
        protected override void OnEliminar()
        {
            if (gridControl.ChildRows.Count == 0) return;

            DialogResult res = RadMessageBox.Show("¿Desea eliminar el registro?", "Sistema", 
                                                MessageBoxButtons.YesNo, 
                                                RadMessageIcon.Question,MessageBoxDefaultButton.Button2);
            if (res == System.Windows.Forms.DialogResult.Yes) {
                cargarEntidad();
                string msj = string.Empty;
                LineaLogic.Instance.LineaEliminar(linea, out msj);
                RadMessageBox.Show(msj);                
                OnCancelar();
                enfocaRegistroAnterior();
            }
            
         
        }
        
        protected override void OnGuardar()
        {
            cargarEntidad();
            string msj = string.Empty;
            if (Estado == FormEstate.New)
            {
                LineaLogic.Instance.LineaInsertar(linea, out msj);
                cbbNuevo.Focus();
                cbbNuevo.IsMouseOver = true;
            }
            else {
                LineaLogic.Instance.LineaActualizar(linea, out msj);
                cbbNuevo.IsMouseOver = false;
            }
            
            RadMessageBox.Show(msj,"Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
            linea.codigo = txtCodigo.Text;
            OnCancelar();
            Util.enfocarFila(gridControl, "codigo", linea.codigo);
            ComportarmientoBotones("grabar");
        }

        void CargarRegistro() 
        {
            try
            {
                if (this.gridControl.RowCount == 0)
                    return;

                string codigo = string.Empty;
                codigo = this.gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                var fila = LineaLogic.Instance.LineaTraerRegistro(Logueo.CodigoEmpresa, codigo);

                if (fila != null) {
                    this.txtCodigo.Text = fila.codigo;
                    this.txtDescripcion.Text = fila.descripcion;
                }
            }
            catch (Exception ex) {
                Util.ShowError(ex.Message);
            }
        }
        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                var row = e.CurrentRow.Cells;

                  //Si no ha cargado la pantalla por complet 
                if (!isLoaded) return;
                if (gridControl.Rows.Count == 0) return;
                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["codigo"].Value != null)
                    {
                        CargarRegistro();
                    }
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
      
    }
}
