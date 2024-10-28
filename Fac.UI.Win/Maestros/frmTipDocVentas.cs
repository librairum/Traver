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
using System.Data.Linq;
using System.Linq;
using Telerik.WinControls.UI;
namespace Fac.UI.Win.Maestros
{
    public partial class frmTipDocVentas : frmBaseMante
    {
        private bool isLoaded = false;
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbGrabar;
        TipoDocumentoVentas tipodocuVentas = new TipoDocumentoVentas();
                
        Series serie = new Series();
        public frmTipDocVentas()
        {
            InitializeComponent();
            
        }
        #region "metodoso de serie"
        void habilitarCajasSerie(bool valor) {
            txtSerieCod.Enabled = valor;
            txtSerieDes.Enabled = valor;
            txtSerieNumero.Enabled = valor;
            txtCodDocTipElec.Enabled = valor;
            txtDescTipDocElec.Enabled = false;
            txtEstablecimientoCod.Enabled = valor;
            txtEstablecimientoDes.Enabled = false;
        }
        void onCargarSerie() {
            try
            {
                cargarEntidadSerie();
                
                var lista = SeriesLogic.Instance.TraeSeries(serie, "FAC07SERIE", "*");
                this.gridSerie.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer serie: " + ex.Message);
            }
        }
        void cargarRegistroSerie()
        {
            try
            {
                //BaselimpiarCajas(this);
                limpiarcajasSerie();
                if (gridSerie.RowCount == 0)
                    return;
                string codigo = "";
                string nombre = "";
                string numero = "";
                string codigoEstablecimiento = "";

                GridViewRowInfo row = gridSerie.CurrentRow;
                codigo = Util.GetCurrentCellText(row, "FAC07SERIE");                
                nombre = Util.GetCurrentCellText(row, "FAC07DESC");                
                numero = Util.GetCurrentCellText(row, "FAC07NUMERO");                
                codigoEstablecimiento = Util.GetCurrentCellText(row, "FAC07AESTABLECIMIENTOCOD");
                                
                txtSerieCod.Text = codigo;
                txtSerieDes.Text = nombre;
                txtSerieNumero.Text = numero;
                txtEstablecimientoCod.Text = codigoEstablecimiento;
                
                string descripcionEstablecimiento = "";
                GlobalLogic.Instance.DameDescripcionFA(Logueo.CodigoEmpresa + txtEstablecimientoCod.Text, "ESTABLSXSERIE", out descripcionEstablecimiento);
                txtEstablecimientoDes.Text = descripcionEstablecimiento;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al carga registro sede: " + ex.Message);
            }
        }
        void cargarEntidadSerie()
        {
            serie.FAC07CODEMP = Logueo.CodigoEmpresa;                        
            serie.FAC01COD = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC01COD");
            serie.FAC07SERIE = txtSerieCod.Text.Trim();
            serie.FAC07DESC = txtSerieDes.Text.Trim();
            serie.FAC07ABREVIA = "";
            serie.FAC07NUMERO = txtSerieNumero.Text.Trim();
            serie.FAC07AESTABLECIMIENTOCOD = txtEstablecimientoCod.Text.Trim();                        
        }
        bool ValidarSerie() {
            cbbGrabar.IsMouseOver = false;
            if (string.IsNullOrEmpty(txtSerieCod.Text.Trim()))
            {                
                Util.ShowAlert("Ingresar codigo");
                txtSerieCod.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSerieDes.Text.Trim()))
            {                
                Util.ShowAlert("Ingresar descripcion");
                txtSerieDes.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSerieNumero.Text.Trim()))
            {                
                Util.ShowAlert("Ingresar numero");
                txtSerieNumero.Focus();
                return false;
            }
            return true;
        }
        void habilitaBotonSerie(bool iud,bool sc) { 
        //iud insert update del
            //sc save - cancel
            
            if (iud && !sc)
            {
                btnNuevo.Visibility = ElementVisibility.Visible;
                btnEditar.Visibility = ElementVisibility.Visible; btnEliminar.Visibility = ElementVisibility.Visible;
                btnGuardar.Visibility = ElementVisibility.Collapsed; btnCancelar.Visibility = ElementVisibility.Collapsed;
            }
            else {
                btnNuevo.Visibility = ElementVisibility.Collapsed;
                btnEditar.Visibility = ElementVisibility.Collapsed; btnEliminar.Visibility = ElementVisibility.Collapsed;
                btnGuardar.Visibility = ElementVisibility.Visible; btnCancelar.Visibility = ElementVisibility.Visible;

            }
        }
        void iniciarfrmSerie() {
            crearColumnasSerie();
            habilitarCajasSerie(false);
            onCargarSerie();
            habilitaBotonSerie(true, false);
          
        }
        void limpiarcajasSerie() {
            this.txtSerieCod.Text = "";
            this.txtSerieDes.Text = "";
            this.txtSerieNumero.Text = "";
            this.txtEstablecimientoCod.Text = "";
            this.txtEstablecimientoDes.Text = "";
        }
        void crearColumnasSerie()
        {
            CreateGridVista(this.gridSerie);
            this.CreateGridColumn(this.gridSerie, "Serie", "FAC07SERIE", 0, "", 100);
            this.CreateGridColumn(this.gridSerie, "Descripcion", "FAC07DESC", 0, "", 250);
            this.CreateGridColumn(this.gridSerie, "Numero", "FAC07NUMERO", 0, "", 120);
            
            //campo oculto
            this.CreateGridColumn(this.gridSerie, "FAC07AESTABLECIMIENTOCOD", "FAC07AESTABLECIMIENTOCOD", 0, "", 10, true, false, false);
        }
        void nuevoSerie() {
            if (txtCodigo.Enabled || txtDescripcion.Enabled) return;
            Estado = FormEstate.New; 
            this.habilitarCajasSerie(true);
            this.limpiarcajasSerie();
            txtSerieCod.Focus();
            habilitaBotonSerie(false,  true);          
        }

        void editarSerie() {
            if (txtCodigo.Enabled || txtDescripcion.Enabled) return;
            if (this.gridSerie.Rows.Count == 0) return;
            Estado = FormEstate.Edit;
            habilitarCajasSerie(true);
            txtSerieCod.Enabled = false;
            txtSerieDes.Focus();
            habilitaBotonSerie(false, true);
          
        }

        void eliminarSerie() {
            try
            {
                if (txtCodigo.Enabled || txtDescripcion.Enabled) return;
                Estado = FormEstate.List;

                if (this.gridSerie.MasterView.Rows.Count == 0) return;

                cargarEntidadSerie();
                string msj = string.Empty;
                int flag = 0;
         
                 bool respuesta =  Util.ShowQuestion("¿Esta seguro de eliminar el registro  " +  serie.FAC01COD + "?");

                if (respuesta == true)
                {
                    SeriesLogic.Instance.EliminarSerie(serie, out flag, out msj);
                    Util.ShowMessage(msj, flag);
                    if (flag == 1)
                    {
                        
                        int indice = gridSerie.MasterView.CurrentRow.Index;
                        onCargarSerie();
                        if (indice > 0)
                        {
                            gridSerie.MasterView.Rows[indice - 1].IsSelected = true;
                            gridSerie.MasterView.Rows[indice - 1].IsCurrent = true;
                        }
                        
                    }
                }

                
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar serie:" + ex.Message);
            }
        }
        void cancelarSerie() {
            Estado = FormEstate.List;
            habilitarCajasSerie(false);
            //BaseHabilitarCajas(this, false);
            habilitaBotonSerie(true, false);

            cargarRegistroSerie();
        }
        void guardarSerie() {
            try
            {
                if (!ValidarSerie()) return;
                cargarEntidadSerie();
                string msj = string.Empty;
                int flag = 0;
                if (Estado == FormEstate.New)
                {
                    SeriesLogic.Instance.InsertarSerie(serie, out flag, out msj);

                }
                else if (Estado == FormEstate.Edit)
                {
                    SeriesLogic.Instance.ActualizarSerie(serie, out flag, out msj);

                }

                Util.ShowMessage(msj, flag);

                if (flag == 1)
                {
                    
                    onCargarSerie();
                    Util.enfocarFila(this.gridSerie, "FAC07SERIE", serie.FAC07SERIE);                    
                    Estado = FormEstate.List;
                    cancelarSerie();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
         

        #endregion
        public frmTipDocVentas(frmMDI padre) {
            InitializeComponent();
            
            txtCodDocTipElec.KeyDown += new KeyEventHandler(txtCodDocTipElec_KeyDown);
        }

        void txtCodDocTipElec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                frmBusqueda frm = new frmBusqueda(enmAyuda.enmTipDocGlobal, "");
                string[] datos;
                frm.ShowDialog();
                if (frm.Result == null) return;
                if (frm.Result.ToString() == "") return;
                datos = frm.Result.ToString().Split('|');
                txtCodDocTipElec.Text = datos[0];
                txtDescTipDocElec.Text = datos[1];
            }
        }


        
        private static frmTipDocVentas _aForm;
        private frmMDI frmParent { get; set; }
        public static frmTipDocVentas Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmTipDocVentas(formParent);
            _aForm = new frmTipDocVentas(formParent);
            return _aForm;
        }
        #region "metodos de formulario"
        void crearColumnas()
        {
            this.CreateGridVista(gridControl);

            this.CreateGridColumn(gridControl, "Codigo", "FAC01COD", 0, "", 50);
            this.CreateGridColumn(gridControl, "Descripcion", "FAC01DESC", 0, "", 220);
            this.CreateGridColumn(gridControl, "TipDoc", "FAC01TIPDOC", 0, "", 10,true,false,false);
            
            // campos ocultos equivalente para facturacion electronica.
            this.CreateGridColumn(gridControl, "FAC01FETIPDOC", "FAC01FETIPDOC", 0, "", 10,true,false,false);
            this.CreateGridColumn(gridControl, "TipDocFEDesc", "TipDocFecDesc", 0, "", 10, true, false, false);

            
        }
        void OnCargar() {
            try
            {
                var lista = TipoDocumentoVentasLogic.Instance.TraerTipoDocumentoVentas(Logueo.CodigoEmpresa, "FAC01COD", "*");
                this.gridControl.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar: " + ex.Message);
            }
        }


        #endregion

        #region "Eventos de botones"
        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            BaselimpiarCajas(this);
            BaseHabilitarCajas(this, true);
            txtDescTipDocElec.Enabled = false;
            txtCodigo.Focus();
            rbGuia.CheckState = CheckState.Checked;
            gestionarBotones(false, false, false, true, true);
       
        }
     
        void cargarEntidad() {
            
            tipodocuVentas.FAC01COD = txtCodigo.Text;
            tipodocuVentas.FAC01CODEMP = Logueo.CodigoEmpresa;
            tipodocuVentas.FAC01DESC = txtDescripcion.Text;

            tipodocuVentas.FAC01TIPDOC = rbGuia.CheckState == CheckState.Checked ? "2" : "1";
            tipodocuVentas.FAC01FETIPDOC = txtCodDocTipElec.Text.Trim();

            
        }
        protected override void OnEditar()
        {
            Estado = FormEstate.Edit;
            //BaselimpiarCajas(this);
            BaseHabilitarCajas(this, true);
            txtDescTipDocElec.Enabled = false;
            txtCodigo.Enabled = false;
            txtDescripcion.Focus();
            gestionarBotones(false, false, false, true, true);
        }

        void enfocaRegistroAnterior() {
            int indice = gridControl.MasterView.CurrentRow.Index;
            OnCargar();
            if (indice > 0)
            {
                gridControl.MasterView.Rows[indice - 1].IsSelected = true;
                gridControl.MasterView.Rows[indice - 1].IsCurrent = true;
            }
        }
        protected override void OnEliminar()
        {
            try
            {
                if (this.gridControl.MasterView.Rows.Count == 0) return;
                cargarEntidad();
                string msj = string.Empty;
                int flag = 0;

                bool res = Util.ShowQuestion("¿Esta seguro de eliminar el registro " + tipodocuVentas.FAC01COD + "?");
                if (res == true)
                {

                    TipoDocumentoVentasLogic.Instance.EliminarTipoDocumentVentas(tipodocuVentas, out flag, out msj);
                    Util.ShowMessage(msj, flag);
                    if (flag == 1)
                    {
                        enfocaRegistroAnterior();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar : " + ex.Message);
            }      
            
        }
        bool Validar() 
        {
            cbbGrabar.IsMouseOver = false;
            if(string.IsNullOrEmpty(txtCodigo.Text.Trim()))
            {                
                Util.ShowAlert("Ingresar codigo");
                txtCodigo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text.Trim())) {                
                Util.ShowAlert("Ingresar descripcion");
                txtDescripcion.Focus();
                return false;
            }
            return true;
        }

        protected override void OnGuardar()
        {
            
            if (!Validar())
                return;
            cargarEntidad();
            try
            {
                string msj = string.Empty;
                int flag = 0;
                if (Estado == FormEstate.New)
                {

                    TipoDocumentoVentasLogic.Instance.InsertarTipoDocumentVentas(tipodocuVentas, out flag, out msj);
                    cbbNuevo.IsMouseOver = true;
                    cbbNuevo.Focus();
                }
                else if (Estado == FormEstate.Edit)
                {
                    TipoDocumentoVentasLogic.Instance.ActualizarTipoDocumentoVentas(tipodocuVentas, out flag, out msj);
                    cbbNuevo.IsMouseOver = false;
                }
                Util.ShowMessage(msj, flag);
                if (flag == 1)
                {
                    OnCancelar();
                    OnCargar();
                    Util.enfocarFila(this.gridControl, "FAC01COD", tipodocuVentas.FAC01COD);
                    Estado = FormEstate.List;
                    cbbGrabar.IsMouseOver = false;
                    cbbNuevo.IsMouseOver = false;
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        
        protected override void OnCancelar()
        {
            Estado = FormEstate.List;
            BaselimpiarCajas(this);
            BaseHabilitarCajas(this,false);
            gestionarBotones(true, true, true, false, false);
            CargarRegistro();

        }

        #endregion
        void CargarRegistro() {
            try
            {
                if (gridControl.RowCount == 0)
                    return;
                string codigo = string.Empty;
                string nombre = string.Empty;
                string tipoDoc = "";
                string facturaElectronicaTipo = "";
                string facturaElectronicaDesc = "";

                codigo = gridControl.CurrentRow.Cells["FAC01COD"].Value.ToString();
                nombre = gridControl.CurrentRow.Cells["FAC01DESC"].Value.ToString();
                tipoDoc = gridControl.CurrentRow.Cells["FAC01TIPDOC"].Value.ToString();
                facturaElectronicaTipo = Util.GetCurrentCellText(gridControl, "FAC01FETIPDOC");
                facturaElectronicaDesc = Util.GetCurrentCellText(gridControl, "TipDocFecDesc");

                txtCodigo.Text = codigo;
                txtDescripcion.Text = nombre;
                txtCodDocTipElec.Text = facturaElectronicaTipo;
                txtDescTipDocElec.Text = facturaElectronicaDesc;

                if (tipoDoc == "1")                
                    rbComprobante.CheckState = CheckState.Checked;                                   
                else 
                    rbGuia.CheckState = CheckState.Checked;                
                                                                
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
            
        }
        private void gridControl_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try
            {
                //if (!isLoaded) return;
                if (gridControl.Rows.Count == 0) return;
                if (Estado == FormEstate.New) return;
                var row = e.CurrentRow.Cells;

                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["FAC01COD"].Value != null)
                    {
                        CargarRegistro();
                        onCargarSerie();
                        cargarRegistroSerie();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        private void gridSerie_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                //if (!isLoaded) return;
                if (gridSerie.Rows.Count == 0) return;
                if (Estado == FormEstate.New) return;
                                                                       
                    if (Util.GetCurrentCellText(gridSerie.CurrentRow, "FAC07SERIE") != "")
                    {
                        cargarRegistroSerie();
                    }               
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevoSerie();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            editarSerie();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarSerie();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarSerie();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarSerie();
        }

        private void txtEstablecimientoCod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == (char)Keys.F1)
                {
                    frmBusqueda frm = new frmBusqueda(enmAyuda.enmEstablecimientoxSerie);
                    frm.ShowDialog();
                    if (frm.Result == null) { return; }
                    if (frm.Result.ToString() == "") { return; }
                    string[] datos = frm.Result.ToString().Split('|');
                    if (datos.Length == 0) return;
                    txtEstablecimientoCod.Text =  datos[0];
                    txtEstablecimientoDes.Text =  datos[1];
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        private void frmTipDocVentas_Load(object sender, EventArgs e)
        {
            menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
            cbbNuevo = menu.Items["cbbNuevo"];
            cbbGrabar = menu.Items["cbbGuardar"];

            crearColumnas();


            OnCargar();
            //isLoaded = true;
            BaseHabilitarCajas(this, false);
            gestionarBotones(true, true, true, false, false);
            rbGuia.CheckState = CheckState.Checked;
            txtCodigo.MaxLength = 2;
            iniciarfrmSerie();
            
            //this.gridControl

            /******************************metodos de serie*********************************/
            iniciarfrmSerie();
        }
     
    }
}
