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
    public partial class frmActividadNivel1 : frmBaseMante
    {
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
        private static frmActividadNivel1 _aForm;
        public static frmActividadNivel1 Instance(frmMDI mdiPricipal) {
            if (_aForm != null) return new frmActividadNivel1(mdiPricipal);
            _aForm = new frmActividadNivel1(mdiPricipal);
            return _aForm;
        }
        public frmActividadNivel1(frmMDI padre) {
            InitializeComponent();
            FrmParent = padre;
            //HabilitarBotones(true, true, true, false, false, false);
            HabilitarControles(false);
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
        }
        private void accesobtonesxperfil()
        {
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.codModulo, this.Name, out nuevo_a, out editar_a,
                out eliminar_a, out ver_a, out imprimir_a, out refrescar_a, out importar_a, out vista_a,
                out guardar_a, out cancelar_a, out  expmovi_a, out importarMP);
        }
        
        ActividadNivel1 actividad1 = new ActividadNivel1();
        //public frmActividadNivel1(frmMDI 
        void crearColumnas() {
            RadGridView grilla = CreateGridVista(gridControl);
            this.CreateGridColumn(grilla, "PRO09CODEMP", "codigoEmpresa", 0, "", 30, true, false, false);
            this.CreateGridColumn(grilla, "linea", "codigoLinea", 0, "", 100, true, false, false);
            this.CreateGridColumn(grilla, "linea Descripcion ", "descripcionLinea", 0, "", 170);
            this.CreateGridColumn(grilla, "Codigo", "codigo", 0, "", 100);
            this.CreateGridColumn(grilla, "Descripcion", "descripcion", 0, "", 100);
            this.CreateGridColumn(grilla, "Almacen", "codigoAlmacen", 0, "", 100, true, false, false);
            this.CreateGridColumn(grilla, "Almacen", "descripalmacen", 0, "", 200);
            this.CreateGridColumn(grilla, "AlmacenDefecto", "almacenxdefecto", 0, "", 140, true, false, false);
            this.CreateGridColumn(grilla, "Almacen por Defecto", "descripalmacenxdefecto", 0, "", 200);

            //Transaccion (Salida) por Linea
            this.CreateGridColumn(grilla, "Codigo Trans.", "CodigoTransaSalxDefecto", 0, "", 90);
            this.CreateGridColumn(grilla, "Descripcion Trans.", "descripTransaSalxDefecto", 0, "", 200);

            //Tipo de documento (Salida) por defecto
            this.CreateGridColumn(grilla, "Codigo Tip.Doc", "CodigoDocRespSalxDefecto", 0, "", 90);
            this.CreateGridColumn(grilla, "Descripcion Tip.Doc", "descripDocRespSalxDefecto", 0, "", 200);
            
            



        }
        void limpiar() {
            
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            
            txtcodAlmacenMP.Text = "";
            txtDesAlmacenMP.Text = "";
            
            txtCodAlmacenPorDefecto.Text = "";
            txtDesAlmacenPorDefecto.Text = "";
            
            txtCodigoLinea.Text = "";
            txtdescripcionLinea.Text = "";

            txtCodAlmacenPorDefecto.Text = "";
            txtDesAlmacenPorDefecto.Text = "";
            
            txtTipDocxDefecto.Text = "";
            txtDesTipDocxDefecto.Text = "";

            txtCodDocRespaldo.Text = "";
            txtDesDocRespaldo.Text = "";

        }
        bool Validar() {
            if (txtCodigoLinea.Text.Trim() == "" || txtdescripcionLinea.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe Ingresar codigo Linea", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);                
                txtCodigoLinea.Focus();
                return false;
            }
            if (txtcodAlmacenMP.Text.Trim() == "" || txtDesAlmacenMP.Text.Trim() == "" ) {
                RadMessageBox.Show("Almacen de Materia prima.", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtcodAlmacenMP.Focus();
                return false;
            }
            if (txtCodAlmacenPorDefecto.Text.Trim() == "" || txtDesAlmacenPorDefecto.Text.Trim() == "???") {                
                RadMessageBox.Show("Debe Ingresar almacen por defecto", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtCodAlmacenPorDefecto.Focus();
                return false;
            }
            if (txtCodigo.Text.Trim() == ""  || txtDescripcion.Text.Trim() == "") {
                RadMessageBox.Show("Debe Ingresar codigo y/o descripcion", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtDescripcion.Focus();
                return false;
            }

            if (txtTipDocxDefecto.Text.Trim() == "" || txtDesTipDocxDefecto.Text == "???") {
                RadMessageBox.Show("Debe Ingresar el tipo de documento", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtTipDocxDefecto.Focus();
                return false;
            }
            if (txtCodDocRespaldo.Text.Trim() == "" || txtDesDocRespaldo.Text == "???")
            {
                RadMessageBox.Show("Debe Ingresar documento de respaldo", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtCodDocRespaldo.Focus();
                return false;

            }
            return true;
        }

        void HabilitarControles(bool valor) {
            txtCodigo.Enabled = false;
            txtCodigo.TabStop = false;

            txtDescripcion.Enabled = valor;

            txtCodigoLinea.Enabled = valor;
            txtdescripcionLinea.Enabled = false;
            txtdescripcionLinea.TabStop = false;

            txtcodAlmacenMP.Enabled = valor;
            txtDesAlmacenMP.Enabled = false;
            txtDesAlmacenMP.TabStop = false;

            txtCodAlmacenPorDefecto.Enabled = valor;
            txtDesAlmacenPorDefecto.Enabled = false;
            txtDesAlmacenPorDefecto.TabStop = false;

            txtTipDocxDefecto.Enabled = valor;
            txtDesTipDocxDefecto.Enabled = false;
            txtDesTipDocxDefecto.TabStop = false;

            txtCodDocRespaldo.Enabled = valor;
            txtDesDocRespaldo.Enabled = false;
            txtDesDocRespaldo.TabStop = false;
        }
        void cargarEntidad() {
            actividad1.codigoEmpresa = Logueo.CodigoEmpresa;
            actividad1.codigoLinea = txtCodigoLinea.Text;
            actividad1.codigo = txtCodigo.Text;
            actividad1.descripcion = txtDescripcion.Text;
            actividad1.codigoAlmacen = txtcodAlmacenMP.Text;
            actividad1.almacenMP = txtCodAlmacenPorDefecto.Text;
            actividad1.CodigoDocRespSalxDefecto = txtCodDocRespaldo.Text.Trim();
            actividad1.CodigoTransaSalxDefecto = txtTipDocxDefecto.Text.Trim();

        }
        protected override void  OnBuscar()
        {
            var lista = ActividadNivel1Logic.Instance.ActividadNivel1Traer(Logueo.CodigoEmpresa,"");
            this.gridControl.DataSource = lista;
        }
        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            txtDescripcion.Enabled = true;
            limpiar();

            string codigo = string.Empty;
            ActividadNivel1Logic.Instance.ActividadNivelTraeCodigo(Logueo.CodigoEmpresa, out codigo);
            //LineaLogic.Instance.LineaGeneraCodigo(Logueo.CodigoEmpresa, out codigo);
            txtCodigo.Text = codigo;

            txtCodigo.Enabled = false;

            //HabilitarBotones(false, false, false, true, true, false);
            ComportarmientoBotones("nuevo");
            HabilitarControles(true);

            SendKeys.Send("{TAB}"); //--> Enfoco txtCodigo
            //SendKeys.Send("{TAB}");           
      
        }
        protected override void OnEditar()
        {
            if (gridControl.MasterTemplate.RowCount == 0) return;
            Estado = FormEstate.Edit;
            txtDescripcion.Enabled = true;
            txtcodAlmacenMP.Enabled = true;
            txtCodAlmacenPorDefecto.Enabled = true;
            txtTipDocxDefecto.Enabled = true;
            txtCodDocRespaldo.Enabled = true;
            ComportarmientoBotones("editar");
            //HabilitarBotones(false, false, false, true, true, false);

        }
        protected override void OnEliminar()
        {
                      if (gridControl.MasterTemplate.RowCount == 0) return;
            DialogResult res = RadMessageBox.Show("¿Desea eliminar el registro?", "Sistema", MessageBoxButtons.YesNo, 
                                                    RadMessageIcon.Question, 
                                                    MessageBoxDefaultButton.Button2);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                cargarEntidad();
                string msj = string.Empty;
                ActividadNivel1Logic.Instance.ActividadNivel1Eliminar(actividad1, out msj);
                RadMessageBox.Show(msj, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                HabilitarBotones(true, true, true, false, false, false);
                HabilitarControles(false);
                limpiar();
                OnBuscar();

            }
        }

        protected override void OnGuardar()
        {
            try
            {
                if (!Validar()) return;
                cargarEntidad();
                string msj = string.Empty;
                if (Estado == FormEstate.New)
                {
                    ActividadNivel1Logic.Instance.ActividadNivel1Insertar(actividad1, out msj);
                    RadMessageBox.Show(msj, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                else if (Estado == FormEstate.Edit)
                {
                    ActividadNivel1Logic.Instance.ActividadNivel1Actualizar(actividad1, out msj);
                    RadMessageBox.Show(msj, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                }



                actividad1.codigo = this.txtCodigo.Text;
                ComportarmientoBotones("grabar");
                OnCancelar();
                Util.enfocarFila(gridControl, "codigo", actividad1.codigo);
            }
            catch (Exception ex)
            {
                ComportarmientoBotones("grabar");
                OnCancelar();
            }
           

           
        }
        protected override void OnCancelar()
        {
            Estado = FormEstate.List;

            limpiar();
            OnBuscar();
            HabilitarControles(false);
            //HabilitarBotones(true, true, true, false, false, false);
            ComportarmientoBotones("cancelar");
            //gridControl.AutoGenerateColumns = false;

        }
        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void MostrarAyuda(enmAyuda tipo)
        {
            frmBusqueda frm;
            string codigoSeleccionado = string.Empty;
            switch (tipo)
            {
                case enmAyuda.enmTransaccion:
                    frm = new frmBusqueda(enmAyuda.enmTransaccion);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if (codigoSeleccionado != "")
                    {
                        txtCodDocRespaldo.Text = codigoSeleccionado;
                    }
                    break;
                case enmAyuda.enmTipoDocumentoAll:
                    frm = new frmBusqueda(enmAyuda.enmTipoDocumentoAll);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if (codigoSeleccionado != "")
                    {
                        txtTipDocxDefecto.Text = codigoSeleccionado;
                    }
                    break;
                case enmAyuda.enmAlmacen:
                    frm = new frmBusqueda(enmAyuda.enmAlmacen);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if (codigoSeleccionado != "")
                    {
                        txtCodAlmacenPorDefecto.Text = codigoSeleccionado;
                    }

                    break;
                case enmAyuda.enmAlmacenMP:
                    frm = new frmBusqueda(enmAyuda.enmAlmacen);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if (codigoSeleccionado != "")
                    {

                        txtcodAlmacenMP.Text = codigoSeleccionado;
                    }
                    break;
                case enmAyuda.enmLinea:
                    frm = new frmBusqueda(enmAyuda.enmLinea);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if (codigoSeleccionado != "")
                    {
                        txtCodigoLinea.Text = codigoSeleccionado;
                    }

                    break;

                default:
                    break;

            }
        }
        private void obtenerDescripcion(enmAyuda tipoAyuda, string valor)
        {
            string descripcion = "";
            string transaccion = string.Empty;
            switch (tipoAyuda)
            {
                case enmAyuda.enmAlmacen:
                    //GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtcodAlmacenMP.Text, "ALMACEN", out descripcion);
                    //     GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtCodAlmacenPorDefecto.Text.Trim(), "ALMACEN", out descripcion);
                    GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + valor, "ALMACEN", out descripcion);
                    txtDesAlmacenPorDefecto.Text = descripcion;
                    break;
                case enmAyuda.enmLinea:
                    //GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtCodigoLinea.Text, "LINEAPROD", out descripcion);
                    GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + valor, "LINEAPROD", out descripcion);
                    txtdescripcionLinea.Text = descripcion;
                    break;
                case enmAyuda.enmAlmacenMP:
                    GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + valor, "ALMACEN", out descripcion);
                    txtDesAlmacenMP.Text = descripcion;
                    break;
                //case enmAyuda.enmAlmacenxDefecto:
                //     GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtCodAlmacenPorDefecto.Text.Trim(), "ALMACEN", out descripcion);
                //     txtDesAlmacenPorDefecto.Text = descripcion;
                //    break;
                case enmAyuda.enmTipoDocumentoAll:

                    //GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtTipDocxDefecto.Text.Trim(), "TIPDOCMOV", out transaccion);
                    GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + valor, "TIPDOCMOV", out transaccion);
                    GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + valor + transaccion, "TIPDOCTODO", out descripcion);
                    txtDesTipDocxDefecto.Text = descripcion;
                    break;
                case enmAyuda.enmTransaccion:

                    //GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtCodDocRespaldo.Text.Trim(), "TRANMOVI", out transaccion);
                    //GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtCodDocRespaldo.Text.Trim(), "TRANSAC", out descripcion);
                    GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + valor, "TRANSAC", out descripcion);
                    txtDesDocRespaldo.Text = descripcion;
                    //GlobalLogic.Instance.DameDescripcion(
                    break;

            }
        }

        private void txtcodAlmacenMP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                MostrarAyuda(enmAyuda.enmAlmacenMP);
            }

        }

        private void radPanel1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void frmActividadNivel1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txtCodigoLinea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                MostrarAyuda(enmAyuda.enmLinea);
            }

        }

        private void txtCodAlmacenPorDefecto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                MostrarAyuda(enmAyuda.enmAlmacen);
            }

        }
        private void cargarRegistro() {
            string xcodigo = gridControl.CurrentRow.Cells["codigo"].Value.ToString();
            string xlinea = gridControl.CurrentRow.Cells["codigoLinea"].Value.ToString();

            var registro = ActividadNivel1Logic.Instance.ActividadNivel1TraerRegistro(Logueo.CodigoEmpresa,xlinea, xcodigo);
            if (registro == null) return;
            this.txtCodigoLinea.Text = registro.codigoLinea;
            this.txtcodAlmacenMP.Text = registro.codigoAlmacen;
            this.txtCodAlmacenPorDefecto.Text = registro.almacenMP;
            this.txtCodigo.Text = registro.codigo;
            this.txtDescripcion.Text = registro.descripcion;
            this.txtCodDocRespaldo.Text = registro.CodigoDocRespSalxDefecto; //--> Documento Respaldo
            this.txtTipDocxDefecto.Text = registro.CodigoTransaSalxDefecto;// --> Tipo de Transacion o Documento de transaccion

        }
        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                if (gridControl.Rows.Count == 0) return;
                if (e.CurrentRow != null)
                {
                    cargarRegistro();
                }
            }
            catch (Exception ex) { }
           
        }

        private void txtCodigoLinea_TextChanged(object sender, EventArgs e)
        {
            obtenerDescripcion(enmAyuda.enmLinea, txtCodigoLinea.Text.Trim());
        }
        
      
        private void txtcodAlmacenMP_TextChanged(object sender, EventArgs e)
        {
            obtenerDescripcion(enmAyuda.enmAlmacenMP, txtcodAlmacenMP.Text.Trim());                      

        }

        private void txtCodAlmacenPorDefecto_TextChanged(object sender, EventArgs e)
        {
            obtenerDescripcion(enmAyuda.enmAlmacen, txtCodAlmacenPorDefecto.Text.Trim());

        }

        private void txtTipDocxDefecto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                MostrarAyuda(enmAyuda.enmTipoDocumentoAll);
            }
        }

        private void txtTipDocxDefecto_TextChanged(object sender, EventArgs e)
        {
            
            obtenerDescripcion(enmAyuda.enmTipoDocumentoAll, txtTipDocxDefecto.Text.Trim());

        }

        private void txtCodDocRespaldo_TextChanged(object sender, EventArgs e)
        {
            obtenerDescripcion(enmAyuda.enmTransaccion, txtCodDocRespaldo.Text.Trim());
        }

        private void txtCodDocRespaldo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                MostrarAyuda(enmAyuda.enmTransaccion);
            }

        }

    }
}
