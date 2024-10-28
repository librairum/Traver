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
using Prod.UI.Win.Comunes;
namespace Prod.UI.Win.Maestros
{
    public partial class frmActividadNivel2 : frmBaseMante
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
        private frmMDI FrmParent { get; set; }
        private static frmActividadNivel2 _aForm;
        public static frmActividadNivel2 Instance(frmMDI mdiPrincipal) {
            if (_aForm != null) return new frmActividadNivel2(mdiPrincipal);    
            _aForm = new frmActividadNivel2(mdiPrincipal);
            return _aForm;
        }
        ActividadNivel2 actividad2 = new ActividadNivel2();
        public frmActividadNivel2(frmMDI padre) {
            InitializeComponent();
            FrmParent = padre;
            this.crearColumnas();

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
            accesobtonesxperfil();
            ComportarmientoBotones("cargar");
            OnCancelar();
        }
        private void accesobtonesxperfil()
        {
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.codModulo, this.Name, out nuevo_a, out editar_a,
                out eliminar_a, out ver_a, out imprimir_a, out refrescar_a, out importar_a, out vista_a,
                out guardar_a, out cancelar_a, out expmovi_a, out importarMP);
        }
       
        void cargarEntidad() {
            actividad2.codigoEmpresa = Logueo.CodigoEmpresa;
            actividad2.codigo = this.txtCodigo.Text.Trim();
            actividad2.descripcion = this.txtDescripcion.Text.Trim();
            actividad2.codigoActividad = this.txtCodActividadLineal1.Text.Trim();            
            actividad2.codigoLinea = this.txtCodigoLinea.Text.Trim();
        }
        void HabilitarControles(bool valor) {

            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = valor;
            
            txtCodigoLinea.Enabled = valor;
            txtdescripcionLinea.Enabled = false;

            txtCodActividadLineal1.Enabled = valor;
            txtDesActividadLineal1.Enabled = false;
            
        }
        void crearColumnas() {
            RadGridView grilla = this.CreateGridVista(gridControl);
            this.CreateGridColumn(grilla, "Empresa", "codigoEmpresa", 0, "", 30, true, false, false);
            this.CreateGridColumn(grilla, "Linea", "codigoLinea", 0, "", 120, true, false, true);
            this.CreateGridColumn(grilla, "Linea", "descripcionLinea", 0, "", 120);
            this.CreateGridColumn(grilla, "Actividad", "codigoActividad", 0, "", 120, true, false, true);
            this.CreateGridColumn(grilla, "Actividad", "descripcionActividad", 0, "", 120);
            this.CreateGridColumn(grilla, "Codigo", "codigo", 0, "", 120);
            this.CreateGridColumn(grilla, "Descripcion", "descripcion", 0, "", 200);
        }
        bool Validar() {
            if (txtDescripcion.Text.Trim() == "") {
                RadMessageBox.Show("Ingresar descripcion", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtDescripcion.Focus();
                return false;
            }
            if(txtCodigoLinea.Text.Trim() == "" || txtdescripcionLinea.Text.Trim() == "???"){
                RadMessageBox.Show("Ingresar linea", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtdescripcionLinea.Focus();
                return false;
            }
            if (txtCodActividadLineal1.Text.Trim() == "" || txtDesActividadLineal1.Text.Trim() == "???") {
                RadMessageBox.Show("Ingresar Actividad linea 1", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtDesActividadLineal1.Focus();
                return false;
            }
            
            return true;
        }
        void limpiar() {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            
            txtCodigoLinea.Text = "";
            txtdescripcionLinea.Text = "";

            txtCodActividadLineal1.Text = "";
            txtDesActividadLineal1.Text = "";
        }
        protected override void OnBuscar()
        {
            var lista = ActividadNivel2Logic.Instance.ActividadNivel2Traer(Logueo.CodigoEmpresa);
            this.gridControl.DataSource = lista;
        }
        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            txtDescripcion.Enabled = true;
            limpiar();
            string codigo = string.Empty;
            ActividadNivel2Logic.Instance.ActividdadNivel2TraeCodigo(Logueo.CodigoEmpresa, out codigo);            
            txtCodigo.Text = codigo;
            txtCodigo.Enabled = false;
            HabilitarControles(true);
            //HabilitarBotones(false, false, false, true, true, false);
            ComportarmientoBotones("nuevo");
            SendKeys.Send("{TAB}");
        }
        protected override void OnEditar()
        {
            if (gridControl.ChildRows.Count == 0) return;
            Estado = FormEstate.Edit;
            HabilitarControles(true);
            ComportarmientoBotones("editar");
            //HabilitarBotones(false, false, false, true, true, false);
        }
        protected override void OnEliminar()
        {
            if (gridControl.ChildRows.Count == 0) return;
            cargarEntidad();
            string msj = string.Empty;
            DialogResult res = MessageBox.Show("Desea eliminar", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == System.Windows.Forms.DialogResult.Yes) { 
                //eliminar
                ActividadNivel2Logic.Instance.ActividadNivel2Eliminar(actividad2, out msj);
                RadMessageBox.Show(msj, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            OnCancelar();
        }

        protected override void OnGuardar()
        {
            try
            {
                if (!Validar()) return;
                cargarEntidad();
                string msj = string.Empty;
                if (Estado == FormEstate.New) {

                    ActividadNivel2Logic.Instance.ActividadNivel2Insertar(actividad2, out msj);

                }
                else if (Estado == FormEstate.Edit) {
                    ActividadNivel2Logic.Instance.ActividadNivel2Actualizar(actividad2, out msj);
                }
                
                RadMessageBox.Show(msj, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                ComportarmientoBotones("grabar");
                OnCancelar();
                Util.enfocarFila(gridControl, "", actividad2.codigo);
            }
            catch (Exception ex) {
                OnCancelar();
            }
        }
        protected override void OnCancelar()
        {
            Estado = FormEstate.List;
            limpiar();
            OnBuscar();
            HabilitarControles(false);
            ComportarmientoBotones("cancelar");
            //HabilitarBotones(true, true, true, false, false, false);            
        }

        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (gridControl.ChildRows.Count == 0) return;
            if (e.CurrentRow != null) {
                GridViewRowInfo info = this.gridControl.CurrentRow;
                this.txtCodigo.Text = info.Cells["codigo"].Value.ToString();
                this.txtDescripcion.Text = info.Cells["descripcion"].Value.ToString();
                this.txtCodigoLinea.Text = info.Cells["codigoLinea"].Value.ToString();
                this.txtCodActividadLineal1.Text = info.Cells["codigoActividad"].Value.ToString();
                //GridViewRowInfo info = this.gridControl.CurrentRow;
                //actividad2.codigoLinea = info.Cells["codigoLinea"].Value.ToString();
                //actividad2.codigoActividad = info.Cells["codigoActividad"].Value.ToString();
                //actividad2.codigo = info.Cells["codigo"].Value.ToString();
                //actividad2.codigoEmpresa = info.Cells["codigoEmpresa"].Value.ToString();
                //var registro = ActividadNivel2Logic.Instance.ActividadNivel2TraerRegistro(actividad2);
                //if (registro != null) {
                //    this.txtCodigo.Text = registro.codigo;
                //    this.txtDescripcion.Text = registro.descripcion;
                //    this.txtCodigoLinea.Text = registro.codigoLinea;
                //    this.txtCodActividadLineal1.Text = registro.codigoActividad;
                    
                //}
            }
        }

        private void txtCodigoLinea_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCodigoLinea.Text.Trim())) {
                txtdescripcionLinea.Text = "";
                return;
            }
            var dataLinea = LineaLogic.Instance.LineaTraerRegistro(Logueo.CodigoEmpresa, txtCodigoLinea.Text);
            if (dataLinea != null)
            {
                txtdescripcionLinea.Text = dataLinea.descripcion;
            }
            else {
                txtdescripcionLinea.Text = "???";
            }
            
        }

        private void txtCodActividadLineal1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCodActividadLineal1.Text.Trim())) {
                txtDesActividadLineal1.Text = "";
                return;
            }
            string descripcion = string.Empty;

            //ActividadNivel1Logic.Instance.ActividadNivel1TraerxLinea(Logueo.CodigoEmpresa, txtCodigoLinea.Text.Trim(),
            //                                            txtCodActividadLineal1.Text.Trim(), out descripcion);
            //var query = actividad.Find(x => x.codigo.Equals(txtCodActividadLineal1.Text.Trim()));
            //if (query.descripcion == "") return;
            GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtCodigoLinea.Text + txtCodActividadLineal1.Text, "ACTIVIDADNIVEL1", out descripcion);
            txtDesActividadLineal1.Text = descripcion;
        }

        private void txtCodigoLinea_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void txtCodActividadLineal1_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCodigoLinea.Text.Trim() == "" || txtdescripcionLinea.Text == "???") {               
                return;
            }
            if (e.KeyValue == (char)Keys.F1) {
                frmBusqueda frm = new frmBusqueda(enmAyuda.enmActividadNivel1, txtCodigoLinea.Text.Trim());                
                frm.ShowDialog();
                //"ACTIVIDADNIVEL1"
                if (frm.Result != null) {
                    string descripcion = "";
                    txtCodActividadLineal1.Text = frm.Result.ToString();
                    GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtCodigoLinea.Text + txtCodActividadLineal1.Text, "ACTIVIDADNIVEL1", out descripcion);
                    txtDesActividadLineal1.Text = descripcion;
                    //txtCodActividadLineal1.Text = ((ActividadNivel1)frm.Result).codigo;
                    //txtDesActividadLineal1.Text = ((ActividadNivel1)frm.Result).descripcion;
                }

            }
        }

        private void txtCodigoLinea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1) {
                frmBusqueda frm = new frmBusqueda(enmAyuda.enmLinea);
                frm.ShowDialog();
                if (frm.Result != null) {
                    txtCodigoLinea.Text = frm.Result.ToString();
                    string descripcion = "";
                    GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtCodigoLinea.Text, "LINEAPROD", out descripcion);
                    txtdescripcionLinea.Text = descripcion;
                    //txtdescripcionLinea.Text = ((Linea)frm.Result).descripcion;
                }
            }
        }
    }
}
