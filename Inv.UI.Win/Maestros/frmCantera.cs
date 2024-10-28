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

namespace Inv.UI.Win.Maestros
{
    public partial class frmCantera : frmBaseMante
    {
        private bool isLoaded = false;
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
        private frmMDI FrmParent { get; set; }
        private static frmCantera _aForm;
        public static frmCantera Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmCantera(mdiPrincipal);
            _aForm = new frmCantera(mdiPrincipal);
            return _aForm;
        }

        void accesobotonesperfil() {
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.codModulo,this.Name, out nuevo_a, out editar_a,
              out eliminar_a, out ver_a, out imprimir_a, out refrescar_a, out importar_a, out vista_a,
              out guardar_a, out cancelar_a, out expmovi_a, out importarMP);
        }

        private void ComportarmientoBotones(string accion) {

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

        public frmCantera(frmMDI padre) {
            InitializeComponent();
            FrmParent = padre;
            CrearColumnas();
            Habilitar(false);
            menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
            cbbNuevo = menu.Items["cbbNuevo"];
            cbbEliminar = menu.Items["cbbEliminar"];
            cbbEditar = menu.Items["cbbEditar"];

            cbbVer = menu.Items["cbbVer"];
            cbbVista = menu.Items["cbbVista"];
            cbbImprimir = menu.Items["cbbImprimir"];
            cbbRefrescar = menu.Items["cbbRefrescar"];
            cbbImportar = menu.Items["cbbImportar"];

            cbbGuardar = menu.Items["cbbGuardar"];
            cbbCancelar = menu.Items["cbbCancelar"];
            
            accesobotonesperfil();
            ComportarmientoBotones("cargar");
            //this.cargarPermisos(this.Name);
        } 
        public void Habilitar(bool valor)
        {
            //Estos controles siempre estan deshabilitados, por que se arman
            this.txtcodigo.Enabled = valor;
            this.txtdescripcion.Enabled = valor;
            this.txtCodProveedor.Enabled = valor;
            this.txtDesProveedor.Enabled = false;
        }
        
        void CrearColumnas() {
            RadGridView grid = CreateGridVista(this.gridControl);
            this.CreateGridColumn(grid, "Empresa", "IN20CODEMP", 0, "", 120, true, false, false);
            this.CreateGridColumn(grid, "Codigo", "IN20CODIGO", 0, "", 120);
            this.CreateGridColumn(grid, "Descripcion", "IN20DESC", 0, "", 180);
            this.CreateGridColumn(grid, "Proveedor", "IN20CODPROVEEDOR", 0, "", 120);        
            
            //this.CreateGridColumn(gridControl, "
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
        public void Limpiar()
        {
            this.txtcodigo.Text = "";
            this.txtdescripcion.Text = "";
            this.txtCodProveedor.Text = "";
            this.txtDesProveedor.Text = "";
        }
        protected override void OnBuscar()
        {
            //base.OnBuscar();

            var lista = CanterasLogic.Instance.TraerCanteras(Logueo.CodigoEmpresa);
            this.gridControl.DataSource = lista;
        }
        protected override void OnNuevo()
        {
            this.Estado = FormEstate.New;
            Habilitar(true);
            Limpiar();            
            txtcodigo.Enabled = false;
            this.txtdescripcion.Focus();
            //HabilitarBotones(false, false, false, true, true, false);
            //habilitarBotones(false,true);
            ComportarmientoBotones("nuevo");
            cbbNuevo.IsMouseOver = false;
            string codigo = string.Empty;
            CanterasLogic.Instance.CanteraTraerCodigo(Logueo.CodigoEmpresa, out codigo);
            txtcodigo.Text = codigo;
            
        }
        protected override void OnEditar()
        {
            this.Estado = FormEstate.Edit;
            Habilitar(true);
            //Deshabilito los valores que no se pueden modificar
            ComportarmientoBotones("editar");
            txtcodigo.Enabled = false;
            //HabilitarBotones(false, false, false, true, true, false);
            txtdescripcion.Focus();
            
        }
        protected override void OnEliminar()
        {
            if (this.gridControl.RowCount == 0)
                return;

            try
            {
                DialogResult result = RadMessageBox.Show("Está seguro de eliminar",
                    Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR, MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    string msgRetorno = string.Empty;
                    string codigocantera = string.Empty;
                    codigocantera = this.gridControl.CurrentRow.Cells["IN20CODIGO"].Value.ToString();

                    Canteras cantera = new Canteras();
                    cantera.IN20CODEMP= Logueo.CodigoEmpresa;
                    cantera.IN20CODIGO = codigocantera;



                    CanterasLogic.Instance.CanteraEliminar(cantera, out msgRetorno);
                    RadMessageBox.Show(msgRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    enfocaRegistroAnterior();
                    
                    //RadMessageBox.Show(msgRetorno, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);

                }
            }
            catch (Exception ex)
            {
                
            }
            OnBuscar();

        }
        protected override void OnCancelar()
        {
            ComportarmientoBotones("cancelar");
            //HabilitarBotones(true, true, true, false, false, false);
            //habilitarBotones(true, false);

            Habilitar(false);
            OnBuscar();

        }
        private bool Validar() {

            if (txtcodigo.Text.Length == 0) {
                RadMessageBox.Show("Debe ingresar Codigo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtcodigo.Focus();
                return false;
            }
          
            if (txtdescripcion.Text.Length == 0 )
            {
                RadMessageBox.Show("Debe ingresar Descripcion de cantera", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtdescripcion.Focus();
                return false;
            }
            if (txtCodProveedor.Text.Length == 0)
            {
                RadMessageBox.Show("Debe ingresar Codigo proveedor", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtCodProveedor.Focus();
                return false;
            }
            if (txtDesProveedor.Text.Length == 0 || txtDesProveedor.Text == "???") {
                RadMessageBox.Show("Debe ingresar Descripcion de proveedor", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtCodProveedor.Focus();
                return false;
            }
            return true;

        }
        private void MostrarAyuda(enmAyuda tipoAyuda) {
            try
            {
                frmBusqueda frm;
                string codigoSeleccionado = string.Empty;
                switch (tipoAyuda)
                {
                    case enmAyuda.enmProveedor:
                        frm = new frmBusqueda(tipoAyuda, Logueo.TipoAnalisisProveedor); // proveedor
                        frm.Owner = this;
                        frm.ShowDialog();
                        if (frm.Result != null)
                            codigoSeleccionado = frm.Result.ToString();
                        if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtCodProveedor.Text = codigoSeleccionado;
                        break;
                    case enmAyuda.enmprovmateriaprima:
                        frm = new frmBusqueda(tipoAyuda);
                        frm.Owner = this;
                        frm.ShowDialog();
                        if(frm.Result != null)
                            codigoSeleccionado = frm.Result.ToString();
                        if (codigoSeleccionado != "")
                            this.txtCodProveedor.Text = codigoSeleccionado;
                        
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { 
            
            }
            
        }
        private void ObtenerDescripcion(enmAyuda tipoAyuda, string codigo) {
            //if (!isLoaded) return;
            string descripcion = "";
            try
            {
                switch(tipoAyuda){
                    case enmAyuda.enmProveedor:
                        this.txtDesProveedor.Text = "";
                        if (!string.IsNullOrEmpty(codigo))
                        {

                            codigo = Logueo.CodigoEmpresa + Logueo.TipoAnalisisMateriaPrima + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "PROVEEDOR", out descripcion);
                            this.txtDesProveedor.Text = descripcion;
                            codigo = "";
                        }
                        break;
                }
                
            }
            catch (Exception ex) { 
            
            }
        }

        protected override void OnGuardar()
        {
            if (!Validar()) return;
            string mensajeRetorno = string.Empty;
            Canteras cantera = new Canteras();
            cantera.IN20CODEMP = Logueo.CodigoEmpresa;
            cantera.IN20CODIGO = this.txtcodigo.Text.Trim();
            cantera.IN20CODPROVEEDOR = this.txtCodProveedor.Text.Trim();
            cantera.IN20DESC = this.txtdescripcion.Text.Trim();
            try
            {
                if (Estado == FormEstate.New) {
                    CanterasLogic.Instance.CanteraInsertar(cantera, out mensajeRetorno);
                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    Habilitar(false);
                    cbbNuevo.IsMouseOver = true;
                    cbbNuevo.Focus();
                    
                }
                else if (Estado == FormEstate.Edit)
                {
                    CanterasLogic.Instance.CanteraActualizar(cantera, out mensajeRetorno);
                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    
                }
                else {
                    RadMessageBox.Show("Opcion no valida", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                Limpiar();
                OnCancelar();
                Util.enfocarFila(gridControl, "IN20CODIGO", cantera.IN20CODIGO);
            }
            catch (Exception ex) { 
            
            }
            Estado = FormEstate.List;

        }
        private void CargarRegistro() {
            try
            {
                if (this.gridControl.RowCount == 0) return;
                string codigo = string.Empty;
                codigo = this.gridControl.CurrentRow.Cells["IN20CODIGO"].Value.ToString();
                var cantera = CanterasLogic.Instance.CanteraTraerRegistro(Logueo.CodigoEmpresa, codigo);
                if (cantera != null)
                { 
                    
                    this.txtcodigo.Text = cantera.IN20CODIGO;
                    this.txtdescripcion.Text = cantera.IN20DESC;
                    this.txtCodProveedor.Text = cantera.IN20CODPROVEEDOR;
                    ObtenerDescripcion(enmAyuda.enmProveedor, txtCodProveedor.Text);
                }
            }
            catch (Exception ex) { 
            
            }
        }
        private void txtCodProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1) {

                MostrarAyuda(enmAyuda.enmprovmateriaprima);
            }
        }

        private void txtCodProveedor_TextChanged(object sender, EventArgs e)
        {
            ObtenerDescripcion(enmAyuda.enmProveedor,txtCodProveedor.Text.Trim());
        }

        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                var row = e.CurrentRow.Cells;

                //  Si no ha cargado la pantalla por complet 
                if (!isLoaded) return;

                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["IN20CODIGO"].Value != null)
                    {
                        CargarRegistro();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmCantera_Load(object sender, EventArgs e)
        {
            OnBuscar();
            CargarRegistro();
            isLoaded = true;
            HabilitarBotones(true, true, true, false, false, false);
            
        }


    }
}
