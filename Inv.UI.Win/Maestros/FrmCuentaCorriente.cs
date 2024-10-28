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
using System.Reflection;
namespace Inv.UI.Win
{
    public partial class FrmCuentaCorriente : frmBaseMante
    {
        private bool isLoaded = false;
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbGuardar;
        private int estadoSede = 0;
        private int estadoProductxCli = 0;
        private int filaEditada = 0;
        private int rowAffected = 0;
        
        private frmMDI FrmParent { get; set; }
        private static FrmCuentaCorriente _aForm;
        public static FrmCuentaCorriente Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmCuentaCorriente(mdiPrincipal);
            _aForm = new FrmCuentaCorriente(mdiPrincipal);
            return _aForm;
        }
        void cargarPermisos() {
            bool Nuevo, Editar, Eliminar;
            var permisos = SegMenuPorPerfilLogic.Instance.Trae_OpcionesPorPerfil(Logueo.codigoPerfil, Logueo.CodigoEmpresa, this.Name);
            if (permisos != null)
            {
                string variable = permisos.opcxmenu;
                Nuevo = (variable.Substring(0, 1).CompareTo("1") == 0);
                Editar = (variable.Substring(1, 1).CompareTo("1") == 0);
                Eliminar = (variable.Substring(2, 1).CompareTo("1") == 0);
                this.HabilitarBotones(Nuevo, Editar, Eliminar, false, false, false);
            }
            
        }
        public FrmCuentaCorriente(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Crearcolumnas();

            //habilitarBotones(true,false);
            OnCancelar();
            cargarAnalisis();
            CrearColumnasProductos();
            
            menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
            cbbNuevo = menu.Items["cbbNuevo"];
            cbbGuardar = menu.Items["cbbGuardar"];
        }
        
        void cargarAnalisis() {
            radDropDownList1.DataSource = TipoAnalisisLogic.Instance.TraerTipoAnalisis(Logueo.CodigoEmpresa);
            radDropDownList1.ValueMember = "codigo";
            radDropDownList1.DisplayMember = "descripcion";
            if (radDropDownList1.Items.Count > 0 ) {
                radDropDownList1.SelectedIndex = 1;
                OnBuscar();
            }
        }
        public FrmCuentaCorriente()
        {
            InitializeComponent();
            Crearcolumnas();
            cargarAnalisis();
            HabilitarBotones(true, true, true, false, false, false);
            //habilitarBotones(true,false);
            OnCancelar();
         
        }

       
        //ver onbuscar
        protected override void OnBuscar()
        {
            //base.OnBuscar();
            var lista = CuentaCorrienteLogic.Instance.CuentaCorrienteTraer(Logueo.CodigoEmpresa,
                radDropDownList1.SelectedValue.ToString());
            this.gridControl.DataSource = lista;
        }

        protected override void OnNuevo()
        {
            this.Estado = FormEstate.New;
            Habilitar(true);
            Limpiar();
            this.txtcodigo.Focus();
            //desactiva boton por grupo            
            HabilitarBotones(false, false, false, true, true, false);
            
            //habilita y deshabilit botones de productos x cliente
            HabilitarBtnProd(false, false, false, false, false);

            //habilita y deshabilita botones de sede pro cliente
            HabilitarBtnSede(false, false, false, false, false);
            
            radDropDownList1.Tag = "d";
            cbbNuevo.IsMouseOver = false;
        }

        protected override void OnEditar()
        {
            this.Estado = FormEstate.Edit;
            Habilitar(true);
            //Deshabilito los valores que no se pueden modificar
            txtcodigo.Enabled = false;
            HabilitarBotones(false, false, false, true, true, false);
            //habilitarBotones(false,true);
            txtdescripcion.Focus();
            
        }
        void enfocaRegistroAnterior()
        {
            int indice = gridControl.CurrentRow.Index;
            //OnCargar();
            OnBuscar();
            OnBuscarSede(Logueo.CodigoEmpresa, this.gridControl.CurrentRow.Cells[0].Value.ToString());
            OnBuscarProdcutosxCliente();
            if (indice > 0)
            {
                gridControl.MasterView.Rows[indice - 1].IsSelected = true;
                gridControl.MasterView.Rows[indice - 1].IsCurrent = true;
            }
        }
        protected override void OnEliminar()
        {
            if (this.gridControl.RowCount == 0)
                return;

            try
            {
                DialogResult result = RadMessageBox.Show("Está seguro de eliminar", 
                    Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR, 
                    MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    string msgRetorno = string.Empty;
                    string codigocuentacorriente = string.Empty;
                    codigocuentacorriente = this.gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();

                    CuentaCorriente cuentacorriente = new CuentaCorriente();
                    cuentacorriente.ccm02emp = Logueo.CodigoEmpresa;

                    cuentacorriente.ccm02tipana = radDropDownList1.SelectedValue.ToString();
                    cuentacorriente.ccm02cod = codigocuentacorriente;
                    if (gridControl.CurrentRow.Index > 0 && gridControl.CurrentRow.Index < gridControl.RowCount) {
                        rowAffected = gridControl.CurrentRow.Index;
                    }
                    
                    CuentaCorrienteLogic.Instance.CuentaCorrienteEliminar(cuentacorriente, out msgRetorno);
                    RadMessageBox.Show(msgRetorno, 
                        Constantes.MensajesGenericos.MSG_TITULO_INFO, 
                        MessageBoxButtons.OK, RadMessageIcon.Info);
                    enfocaRegistroAnterior();
                }
            }
            catch (Exception)
            {

                RadMessageBox.Show(Constantes.MensajesGenericos.MSG_ERROR_INESPERADO, 
                                   Constantes.MensajesGenericos.MSG_TITULO_ERROR,
                                   MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            //gridControl.Rows[rowAffected].IsCurrent = true;
      
        }

        protected override void OnGuardar()
        {
            if (!Validar())
                return;

            string mensajeRetorno = string.Empty;
            string mensajeRetorno1 = string.Empty;
            string fechaini = string.Empty;
            CuentaCorriente cuentacorriente = new CuentaCorriente();
            try
            {                
                cuentacorriente.ccm02emp = Logueo.CodigoEmpresa;
                cuentacorriente.ccm02tipana = radDropDownList1.SelectedValue.ToString();
                cuentacorriente.ccm02cod = txtcodigo.Text;
                cuentacorriente.ccm02nom = txtdescripcion.Text;
                cuentacorriente.ccm02nomabrev = txtNomAbrev.Text.Trim();
                //linea para con al fecha actual de registro es necesario para registrar
                cuentacorriente.ccm02fec = DateTime.Now;
                if (this.Estado == FormEstate.New)
                {
                    //NUEVO
                    CuentaCorrienteLogic.Instance.CuentaCorrienteInsertar(cuentacorriente, out mensajeRetorno);
                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    cbbNuevo.IsMouseOver = true;
                    cbbNuevo.Focus();             
                }
                else if (this.Estado == FormEstate.Edit)
                {
                    //Modificar
                    CuentaCorrienteLogic.Instance.CuentaCorrienteModificar(cuentacorriente, out mensajeRetorno);
                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    
                }
                else
                {
                    RadMessageBox.Show("Opcion no validad", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }

            }
            catch (Exception)
            {

                RadMessageBox.Show("Ha ocurrido error inesperado al registrar ", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            Habilitar(false);
            OnBuscar();
            bool bandera = Estado == FormEstate.New ? true : false;

            this.OnEnfocarRegistro(bandera, gridControl, cuentacorriente.ccm02cod, "ccm02cod");

            this.Estado = FormEstate.List;
            HabilitarBtnSede(true, false, false, true, true);
        }
        protected override void OnCancelar()
        {
                   
            Habilitar(false);
            HabilitarBotones(true, true, true, false, false, false);
            //habilitarBotones(true, false);
            OnCancelarSede();
            cancelarProducto();
            this.GridProductosxCliente.ReadOnly = true;
            Estado = FormEstate.List;
            HabilitarBtnSede(true, false, false, true, true);
        }
        
        private bool Validar()
        {
            cbbGuardar.IsMouseOver = false;
            if (this.txtcodigo.Text.Length == 0)
            {
                RadMessageBox.Show("Debe ingresar Codigo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtcodigo.Focus();
                return false;
            }

            if (this.txtdescripcion.Text.Length == 0)
            {
                RadMessageBox.Show("Debe ingresar Descripcion", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtdescripcion.Focus();
                return false;
            }
            
            return true;
        }
    
        #region metodosdemantenimineto
        void OnEnforcarAnterior(int rowBefore) {
            gridControl.Rows[rowBefore].IsCurrent = true;
            
        }
        public void Habilitar(bool valor)
        {
            //Estos controles siempre estan deshabilitados, por que se arman
            this.txtcodigo.Enabled = valor;
            this.txtdescripcion.Enabled = valor;
            this.txtNomAbrev.Enabled = valor;
        }
      
        public void Limpiar()
        {
            this.txtcodigo.Text = "";
            this.txtdescripcion.Text = "";
            this.txtNomAbrev.Text = "";
        }

        private void CargarRegistro()
        {

            if (this.gridControl.RowCount == 0)
                return;

            string codigo = string.Empty;
            codigo = this.gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();
            string tipo = string.Empty;
            tipo = this.gridControl.CurrentRow.Cells["ccm02tipana"].Value.ToString();
            var cuentacorriente = CuentaCorrienteLogic.Instance.CuentaCorrienteTraerRegistro(Logueo.CodigoEmpresa,tipo,codigo);

            if (cuentacorriente != null)
            {
                this.txtcodigo.Text = cuentacorriente.ccm02cod;
                this.txtdescripcion.Text = cuentacorriente.ccm02nom;
                this.txtNomAbrev.Text = cuentacorriente.ccm02nomabrev;
                if (gridControl.RowCount > 0)
                {

                    commandBarStripElement1.Enabled = true;
                    commandBarStripElement3.Enabled = true;
                    commandBarStripElement4.Enabled = true;
                    limpiarSede();
                    OnCancelarSede();
                    OnBuscarSede(Logueo.CodigoEmpresa, txtcodigo.Text);
                    
                    
                    cancelarProducto();
                    OnBuscarProdcutosxCliente();
                    HabilitarBotones(true, true, true, false, false, false);
                    //habilitarBotones(true, false);
                    
                    //botones de productos x cliente
                    HabilitarBtnProd(false, false, true, true, true);
                    
                    
                    //botones de sedes
                    HabilitarBtnSede(true, false, false, true, true);
                    
                    HabilitarSedes(false);
                }
                else {
                    HabilitarBtnProd(false, false, false, false, false);
                    HabilitarBtnSede(false, false, false, false, false);
                    commandBarStripElement1.Enabled = false;
                    commandBarStripElement3.Enabled = false;
                    commandBarStripElement4.Enabled = false;
                    if (gridControlSedes.Rows.Count > 0)
                    {
                        gridControlSedes.Rows.Clear();
                        GridProductosxCliente.Rows.Clear();
                        limpiarSede();
                        
                    }
                }
            }
        }
       
        private void Crearcolumnas()
        {
            RadGridView grilla = this.CreateGridVista(this.gridControl);


            this.CreateGridColumn(grilla, "Tipo", "ccm02tipana", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Codigo", "ccm02cod", 0, "", 150, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "ccm02nom", 0, "", 250, true, false, true);

        }
        #endregion metodosdemantenimineto



        /*----------------------------------------------------------CONTROLES Y CODIGO DE PESTAÑAN SEDE ---------------------------*/
        #region "metodos Sede"
        private void HabilitarBtnSede(bool bNuevo, bool bGuardar, bool bCancenlar, bool bEditar, 
            bool bEliminar)
        {
            cmdNuevo.Enabled = bNuevo;
            cmbGrabar.Enabled = bGuardar;
            cmbCancelar.Enabled = bCancenlar;
            cmdModificar.Enabled = bEditar;
            cmdEliminar.Enabled = bEliminar;
        }
        private void CrearColumnasSedes()
        {            
            RadGridView grillaControSede = this.CreateGridVista(gridControlSedes);
            this.CreateGridColumn(grillaControSede, "Codigo", "come05sedeclientescod", 0, "", 50, true, false, true);
            this.CreateGridColumn(grillaControSede, "Nombre", "come05sedeclientesdesc", 0, "", 100, true, false, true);
            this.CreateGridColumn(grillaControSede, "Descripcion", "come05sedeclientesdireccion", 0, "", 80, true, false, true);
            this.CreateGridColumn(grillaControSede, "Referencia", "come05sedeclientesreferencia", 0, "", 100, true, false, true);

        }
        private void CargarRegistroSede()
        {

            if (this.gridControlSedes.RowCount == 0)
                return;

            string codigo = string.Empty;
            codigo = this.gridControlSedes.CurrentRow.Cells["come05sedeclientescod"].Value.ToString();
            string descripcion = string.Empty;
            descripcion = this.gridControlSedes.CurrentRow.Cells["come05sedeclientesdesc"].Value.ToString();
            string direccion = string.Empty;
            direccion = this.gridControlSedes.CurrentRow.Cells["come05sedeclientesdireccion"].Value.ToString();
            string referencia = string.Empty;
            referencia = this.gridControlSedes.CurrentRow.Cells["come05sedeclientesreferencia"].Value.ToString();
            /**obtengo el codigo de de la grilla de cliente **/
            string codigoCliente = this.gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();
            /*trae un solo registro de sede */
           var registroSede =  SedeLogic.Instance.TraeSedeRegistro(Logueo.CodigoEmpresa, Logueo.TipoAnalisisCliente, codigoCliente, codigo);
           
           if (registroSede != null) {
               this.txtcodigoSede.Text = registroSede.come05sedeclientescod;
               this.txtdescripcionSede.Text = registroSede.come05sedeclientesdesc;
               this.txtdireccionSede.Text = registroSede.come05sedeclientesdireccion;
               this.txtreferenciaSede.Text = registroSede.come05sedeclientesreferencia;
               //desactivo los controles si cambio de seleccion en la grilla de sedes
               Habilitar(false);
               //activo el modo edicion cuando inicio la seleccion de item de grilla sede
               estadoSede = 2;
           }
         
        }
     
        private void OnBuscarSede(string codEmpresa,string codigoCliente)
        {
            string tipoAnalisis = this.radDropDownList1.SelectedValue.ToString();
            var lista = SedeLogic.Instance.TraeSede(codEmpresa,codigoCliente ,tipoAnalisis);            
            this.gridControlSedes.DataSource = lista;
        }
        private void OnNuevoSede() {
            if (!isLoaded) return;
            //validar si tenemos datos en la grilla de cuenta corriente
            if (gridControl.RowCount == 0)
            {
                return;
            }
            estadoSede = 1;
            HabilitarSedes(true);
            limpiarSede();
            txtcodigoSede.Focus();
            Sede sede = new Sede();

            
            sede.come05empresa = Logueo.CodigoEmpresa;
            sede.come05clientetipana = Logueo.TipoAnalisisCliente;
            string codigoCliente_ = this.gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();
            sede.come05clientecod = codigoCliente_;
            string codigosalida = string.Empty;
            SedeLogic.Instance.SedeGeneraCodigo(sede, out codigosalida);
            if (string.IsNullOrEmpty(codigosalida)) {
                codigosalida = "001";
            }
            txtcodigoSede.Text = codigosalida;
            txtcodigoSede.Enabled = false;
            txtcodigo.Enabled = false;
            HabilitarBtnSede(false, true, true, false, false);
            
            
        }       
        private bool ValidarCtrlSedes() {
            if (this.txtcodigoSede.Text.Length == 0)
            {
                RadMessageBox.Show("Debe ingresar Codigo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtcodigo.Focus();
                return false;
            }
            if (this.txtdescripcionSede.Text.Length == 0) {
                RadMessageBox.Show("Debe ingresar descripcion", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtdescripcionSede.Focus();
                return false;
            }

            if (this.txtdireccionSede.Text.Length == 0)
            {
                RadMessageBox.Show("Debe ingresar direccion", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtdireccionSede.Focus();
                return false;
            }

            if (this.txtreferenciaSede.Text.Length == 0)
            {
                RadMessageBox.Show("Debe ingresar referencia", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtreferenciaSede.Focus();
                return false;
            }


            return true;
        }
        void seleccionaActualizado(string codigo, RadGridView grid,string nomCol) {
            foreach (GridViewRowInfo r in grid.Rows)
            {
                if (r.Cells[nomCol].Value.Equals(codigo)) {
                    grid.Rows[r.Index].IsCurrent = true;
                    grid.Rows[r.Index].IsSelected = true;
                }
            }
        }
        
        private void OnGuardarSedes() {
            if (!ValidarCtrlSedes())
                return;
            string mensajeRetorno = string.Empty;
            Sede sede = new Sede();
            try
            {
             
                sede.come05empresa = Logueo.CodigoEmpresa;
                sede.come05clientetipana = radDropDownList1.SelectedValue.ToString();                
                string codigoCliente_ = this.gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();
                sede.come05clientecod = codigoCliente_;
                string _codigoSede = string.Empty;
                sede.come05sedeclientesdesc = txtdescripcionSede.Text;
                sede.come05sedeclientesdireccion = txtdireccionSede.Text;
                sede.come05sedeclientesreferencia = txtreferenciaSede.Text;
                /*1 es grabar*/
                if (estadoSede==1)
                {
                    
                    sede.come05sedeclientescod = txtcodigoSede.Text;
                    //NUEVO
                    SedeLogic.Instance.SedeInsertar(sede, out mensajeRetorno);                  
                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);                   
                    HabilitarSedes(false);                  
                    
                    limpiarSede();
                    OnBuscarSede(Logueo.CodigoEmpresa, codigoCliente_);
                }
                    /*2 es editar*/
                else if (estadoSede==2)
                {
                    sede.come05sedeclientescod = this.gridControlSedes.CurrentRow.Cells[0].Value.ToString();
                  
                    //Modificar
                    SedeLogic.Instance.SedeActualizar(sede, out mensajeRetorno);
                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    OnBuscarSede(Logueo.CodigoEmpresa,codigoCliente_);
                   

                    limpiarSede();
                    HabilitarSedes(false);
                    
                }
                else
                {
                    RadMessageBox.Show("Opcion no validad", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }
                OnBuscarSede(Logueo.CodigoEmpresa, this.gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString());
                
            }
            catch (Exception)
            {

                RadMessageBox.Show("Ha ocurrido error inesperado al registrar ", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            OnCancelarSede();
            //FocusUpdated(sede.come05sedeclientescod);
            if (estadoSede == 1) {
                this.OnEnfocarRegistro(true, gridControl, sede.come05sedeclientescod, "come05sedeclientescod");
            }
            else if (estadoSede == 2) {
                this.OnEnfocarRegistro(false, gridControl, sede.come05sedeclientescod, "come05sedeclientescod");
            }
            estadoSede = 0;
            
        }   
        private void OnEditarSede() {
            if (gridControlSedes.SelectedRows.Count > 0) {
                estadoSede = 2;
                HabilitarSedes(true);
                this.txtcodigoSede.Enabled = false;
                this.txtdescripcionSede.Focus();
                HabilitarBtnSede(false, true, true, false, false);
                
            }                        
        }
        private void HabilitarSedes(bool valor){
            this.txtcodigoSede.Enabled = valor;
            this.txtdescripcionSede.Enabled = valor;
            this.txtdireccionSede.Enabled = valor;
            this.txtreferenciaSede.Enabled = valor;
        }
        private void limpiarSede() {
            this.txtcodigoSede.Text = "";
            this.txtdescripcionSede.Text = "";
            this.txtdireccionSede.Text = "";
            this.txtreferenciaSede.Text = "";
           
        }
        private void OnEliminarSede() {
            
            if (txtcodigoSede.Text.Length == 0 || txtdescripcionSede.Text.Length == 0)
                return;
            DialogResult result = RadMessageBox.Show("Está seguro de eliminar",
                Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR,
                MessageBoxButtons.YesNo, RadMessageIcon.Question);
             if (result == System.Windows.Forms.DialogResult.Yes)
             {
                 string codigoCliente_ = this.gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();

                 Sede sede = new Sede();
                 sede.come05empresa = Logueo.CodigoEmpresa;
                 sede.come05clientecod = codigoCliente_;
                 sede.come05clientetipana = Logueo.TipoAnalisisCliente;
                 sede.come05sedeclientescod = txtcodigoSede.Text;
                 string mensajeRetorno = string.Empty;
                 SedeLogic.Instance.SedeElminar(sede, out mensajeRetorno);
                 RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                 limpiarSede();
                 HabilitarSedes(false);
                 OnBuscarSede(Logueo.CodigoEmpresa, codigoCliente_); 
             }                        
             estadoSede = 0;
             OnCancelarSede();
        }
        private void OnCancelarSede() {
            try {
                limpiarSede();
                
                HabilitarSedes(false);
                string codigoCLiente_ = "";
                if (this.gridControl.CurrentRow.Cells["ccm02cod"].Value != null) {
                    codigoCLiente_ = this.gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();
                    OnBuscarSede(Logueo.CodigoEmpresa, codigoCLiente_);                    
                }
                                
                estadoSede = 0;
                gridControlSedes.Enabled = true;
                cargarPermisos();
                //HabilitarBtnSede(true, false, false, true, true);
            }
            catch (Exception ex) {
                //RadMessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            
       
        }
        #endregion

        private void gridControl_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try
            {
                var row = e.CurrentRow.Cells;

                //  Si no ha cargado la pantalla por complet 
                if (!isLoaded) return;

                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["ccm02cod"].Value != null)
                    {
                        CargarRegistro();
                        GridProductosxCliente.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void FrmCuentaCorriente_Load(object sender, EventArgs e)
        {
            CrearColumnasSedes();
            
            //Capturo el primer registro valido 
            CargarRegistro();
            
            HabilitarSedes(false);
            isLoaded = true;
            //CrearColumnasProductos(false, true);       
            //metodo para habilitar botones de mantenimiento del formulario base     
            //HabilitarBotones(true, true, true, false, false, false);
            cargarPermisos();
            //this.gestionarBotones(true, true, true, true,
             //true, false);
            //habilitarBotones(true,false);
            //metodo para botones del mantenimiento producto x cliente
            HabilitarBtnProd(false, false, true, true, true);         
            //metodo para botones de  mantenimiento de sede.
            HabilitarBtnSede(true, false, false, true, true);
            //focoFiltro();
            OnBuscar();
            
        }

        private void gridControlSedes_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {

                
                var row = e.CurrentRow.Cells;
           
                //  Si no ha cargado la pantalla por complet 
                //if (!isLoaded) return;
                if (gridControlSedes.IsLoaded) { 
                
                
                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["come05sedeclientescod"].Value != null)
                    {
                        CargarRegistroSede();
                    }
                }
                }
            }
            catch (Exception ex) {
                //MessageBox.Show(ex.Message);
            }
        }
        /*boton nuevo eliminado por error*/
        private void commandBarButton1_Click(object sender, EventArgs e)
        {
            OnNuevoSede();
          
        }

        private void cmdEditarSede_Click(object sender, EventArgs e)
        {
            OnEditarSede();
        }
        /*boton guardar*/
        private void commandBarButton1_Click_1(object sender, EventArgs e)
        {
            
            OnGuardarSedes();                                 
           
        }

        private void cmdEliminarSede_Click(object sender, EventArgs e)
        {
            OnEliminarSede();
            
        }

        private void cmbCancelar_Click(object sender, EventArgs e)
        {
            OnCancelarSede();
        }

        private void txtcodigoSede_Leave(object sender, EventArgs e)
        {
            string codigocliente;
            codigocliente=this.gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();

            var miregistro = SedeLogic.Instance.TraeSedeRegistro(Logueo.CodigoEmpresa,Logueo.TipoAnalisisCliente, codigocliente, this.txtcodigoSede.Text);

            if (miregistro != null) {
                RadMessageBox.Show("Ya existe un registro con este codigo.", "Aviso",
                    MessageBoxButtons.OK, RadMessageIcon.Info);
                txtcodigoSede.Clear();
                txtcodigoSede.Focus();
            }
        }



        private void cmdNuevo_Click(object sender, EventArgs e)
        {
            OnNuevoSede();
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            OnEliminarSede();
        }
        private void cmdModificar_Click(object sender, EventArgs e)
        {
            OnEditarSede();
        }
        /*----------------------------------------------------------CONTROLES Y CODIGO DE PESTAÑAN SEDE --------------------------------------*/
        
        /*------------------------------------------CONTROLES Y CODIGO DE PESTAÑAN PRODUCTOS POR CLIENTE --------------------------------------*/

        #region "Metodos de ProductoxCliente"
       
        private void HabilitarBtnProd(bool  bSave, bool bCancel, bool bAdd, bool bDel, bool bUpd)
        {
            cmdSaveProductos.Enabled = bSave;
            cmdCancelProductos.Enabled = bCancel;
            cmdAddProducts.Enabled = bAdd;
            cmdDelProducts.Enabled = bDel;
            cmdUpdateProducts.Enabled = bUpd;
            
        }
        private void OnBuscarProdcutosxCliente() {
            if (!isLoaded) return;
            if (Logueo.CodigoEmpresa != null && gridControl.CurrentRow != null)
            {
                string codigoCliente = this.gridControl.CurrentRow.Cells[1].Value.ToString();
                this.GridProductosxCliente.DataSource = ArticuloClienteLogic.Instance.TraerArticuloCliente(Logueo.CodigoEmpresa,
                codigoCliente);                               
            }
            
        }

        private void CrearColumnasProductos() {
            RadGridView grillaProducxClie =  this.CreateGridVista(this.GridProductosxCliente);

            this.CreateGridColumn(grillaProducxClie, "Codigo", "In20Codigo", 0, "", 50, false, true, true);
            this.CreateGridColumn(grillaProducxClie, "Descripcion", "In20Descripcion", 0, "", 50, false, true, true);
            this.CreateGridColumn(grillaProducxClie, "Familia", "In20Familia", 0, "", 50, false, true, true);
            this.CreateGridColumn(grillaProducxClie, "Unidad", "In20UndMed", 0, "", 50, false, true, true);
            this.CreateGridColumn(grillaProducxClie, "Formato", "In20Formato", 0, "", 50, false, true, true);
            this.CreateGridColumn(grillaProducxClie, "Color", "In20Color", 0, "", 50, false, true, true);
            this.CreateGridColumn(grillaProducxClie, "Pulido", "In20Pulido", 0, "", 50, false, true, true);
            this.CreateGridColumn(grillaProducxClie, "Relleno", "In20Relleno", 0, "", 50, false, true, true);
            this.CreateGridColumn(grillaProducxClie, "Comentario", "In20Comentario", 0, "", 85, false, true, true);

            this.CreateGridColumn(grillaProducxClie, "Especial", "In20Especial", 0, "", 50, false, true, true);
            this.CreateGridColumn(grillaProducxClie, "Especial1", "In20Especial1", 0, "", 50, false, true, true);
            this.CreateGridColumn(grillaProducxClie, "Unidad por caja", "In20UndxCaja", 0, "", 50, false, true, true,true);
            this.CreateGridColumn(grillaProducxClie, "Piezas por caja", "In20PiezasxCaja", 0, "", 50, false, true, true,false);
            this.CreateGridColumn(grillaProducxClie, "Estado", "In20estado", 0, "", 50, false, false, false);
            this.CreateGridColumn(grillaProducxClie, "Codigo Propio", "In20CodigoPropio", 0, "", 50, false, true, false);
            this.CreateGridColumn(grillaProducxClie, "EsEditable", "", 0, "", 50, false, false, false, false);
            grillaProducxClie.AllowEditRow = false;
        }
       /*agregar de los articulos existentes */

        private bool ValidarProducto() {
            //bool bandera = string.IsNullOrEmpty(retornarValor(0)) ?  true :  false;
                  int indice = GridProductosxCliente.RowCount - 1;
                    var grilla = GridProductosxCliente.Rows[indice];
                if (grilla.Cells[0].Value == null)
                {
                    RadMessageBox.Show("Debe completar el registro actual", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return false; 
                }
                if (grilla.Cells[1].Value == null)
                {
                    RadMessageBox.Show("Debe completar el registro actual", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return false;
                }          
                if (grilla.Cells[11].Value == null)
                {
                    RadMessageBox.Show("Debe completar el registro actual", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return false;
                }

                if (grilla.Cells[12].Value == null)
                {
                    RadMessageBox.Show("Debe completar el registro actual", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return false;
                }
            return true;
        }
        object  retornarValor(int posicion) {
            
            
            return this.GridProductosxCliente.CurrentRow.Cells[posicion].Value;
            
        }
        private void grabarProducto() {
            ArticuloCliente entidad = new ArticuloCliente();
            try
            {
                if (!ValidarProducto())
                    return;
                string mmiMensaje = string.Empty;
                
                GridViewRowInfo fila = GridProductosxCliente.CurrentRow;
                entidad.In20codemp = Logueo.CodigoEmpresa;
                
                entidad.In20clientecod = this.gridControl.CurrentRow.Cells[1].Value.ToString();

                entidad.In20Codigo = fila.Cells[0].Value != null ? fila.Cells[0].Value.ToString() : null;  
                //retornarValor(0).ToString();
                entidad.In20Descripcion = fila.Cells[1].Value != null ? fila.Cells[1].Value.ToString() : null;   
                //retornarValor(1).ToString();

                entidad.In20Familia = fila.Cells[2].Value != null ? fila.Cells[2].Value.ToString() : null;
                entidad.In20UndMed = fila.Cells[3].Value != null ? fila.Cells[3].Value.ToString() : null;
                entidad.In20Formato = fila.Cells[4].Value != null ? fila.Cells[4].Value.ToString() : null;
                entidad.In20Color = fila.Cells[5].Value != null ? fila.Cells[5].Value.ToString() : null;
                entidad.In20Pulido = fila.Cells[6].Value != null ? fila.Cells[6].Value.ToString() : null;
                entidad.In20Relleno = fila.Cells[7].Value != null ? fila.Cells[7].Value.ToString() : null;
                entidad.In20Comentario =fila.Cells[8].Value != null ? fila.Cells[8].Value.ToString() : null;
                entidad.In20Especial = fila.Cells[9].Value != null  ? fila.Cells[9].Value.ToString() : null;
                entidad.In20Especial1 = fila.Cells[10].Value != null ? fila.Cells[10].Value.ToString() : null;
                entidad.In20UndxCaja = fila.Cells[11].Value != null ? Convert.ToDouble(fila.Cells[11].Value) : 0;
                entidad.In20PiezasxCaja = fila.Cells[12].Value != null ? Convert.ToInt32(fila.Cells[12].Value) : 0;
                                                 
                entidad.In20CodigoPropio = "";
                if (estadoProductxCli == 1)
                {
                    entidad.In20estado = "A";
                    ArticuloClienteLogic.Instance.InsertarArticuloCliente(entidad, out mmiMensaje);
                    
                    RadMessageBox.Show(mmiMensaje, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    OnBuscarProdcutosxCliente();
                    GridProductosxCliente.Rows[GridProductosxCliente.RowCount - 1].IsCurrent = true;
                    GridProductosxCliente.Rows[GridProductosxCliente.RowCount - 1].IsSelected = true;
                }
                else if (estadoProductxCli == 2)
                {
                    ArticuloClienteLogic.Instance.ActualizarArticuloCliente(entidad, out mmiMensaje);
                    RadMessageBox.Show(mmiMensaje, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    
                }
                
                estadoProductxCli = 0;
              
            }
            catch (Exception ex)
            {                                
                estadoProductxCli = 0;
            }
            
            HabilitarBtnProd(false, false, true, true, true);                       
            //FocusProducto(entidad.In20Codigo);
            seleccionaActualizado(entidad.In20Codigo, GridProductosxCliente, "In20Codigo");            

            //ver el ultimo registro ingresado
            cancelarProducto();
        }
                
        //metodo agregar nuevo producto x cliente
        private void agregarProducto()
        {                             
            //validar para evitar inserta mas de un row en blanco y sin guardar.
            try {
                //protegerRegistro();
                if (GridProductosxCliente.RowCount == 0)
                {
                    this.GridProductosxCliente.AllowEditRow = true;
                    this.GridProductosxCliente.ReadOnly = false;
                    GridViewRowInfo rowinfo = GridProductosxCliente.Rows.AddNew();
                    rowinfo.Cells[14].Value = "A";
                    rowinfo.Cells[0].BeginEdit();
                    //presiono el boton de + o agregar una nueva fila a la grilla                    
                }
                else
                {
                    if (!ValidarProducto())
                        return;
                    //this.GridProductosxCliente.ReadOnly = false;
                    this.GridProductosxCliente.AllowEditRow = true;
                    this.GridProductosxCliente.ReadOnly = false;
                    this.GridProductosxCliente.Rows.AddNew();
                    estadoProductxCli = 1;
                    this.GridProductosxCliente.CurrentRow.Cells[0].BeginEdit();
                    this.GridProductosxCliente.CurrentRow.Cells[15].Value = "0";
                    this.GridProductosxCliente.CurrentRow.Cells[13].Value = "A";                    
                }
                filaEditada = this.GridProductosxCliente.CurrentRow.Index;
                HabilitarBtnProd(true, true, false, false, false);                
            }
            catch (Exception ex) {             
            }                        
            //estado cero para nuevo registro
        }
        private void eliminarProducto() {
            if (this.GridProductosxCliente.RowCount == 0)
                return;
            ArticuloCliente entidad = new ArticuloCliente();
            //entidad.In20codemp, entidad.In20clientecod, entidad.In20Codigo
            entidad.In20codemp=Logueo.CodigoEmpresa;
            entidad.In20clientecod = this.gridControl.CurrentRow.Cells[1].Value.ToString();
            entidad.In20Codigo = this.GridProductosxCliente.CurrentRow.Cells[0].Value.ToString();
            if (this.GridProductosxCliente.CurrentRow.Cells[13].Value.ToString() != null)
            {
                entidad.In20CodigoPropio = this.GridProductosxCliente.CurrentRow.Cells[14].Value.ToString();
            }
            else {
                entidad.In20CodigoPropio = "";
            }
            //entidad.In20CodigoPropio = this.gridControl.CurrentRow.Cells[12].Value.ToString();
            string mimensaje = string.Empty;
             DialogResult result = RadMessageBox.Show("Está seguro de eliminar", 
                 Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR, MessageBoxButtons.YesNo, RadMessageIcon.Question);
             if (result == System.Windows.Forms.DialogResult.Yes)
             {
                 ArticuloClienteLogic.Instance.EliminarArticuloCliente(entidad, out mimensaje);
                 RadMessageBox.Show(mimensaje, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
             }

             cancelarProducto();
            //protegerRegistro();
        }
        private void editarProducto() {
            this.GridProductosxCliente.AllowEditRow = true;
            this.GridProductosxCliente.ReadOnly = false;
            //protegerRegistro();
            estadoProductxCli = 2;
            //numero es modo edicion
            this.GridProductosxCliente.CurrentRow.Cells[15].Value = "2";
            var fila = GridProductosxCliente.CurrentRow;
        
            this.GridProductosxCliente.CurrentRow.Cells[1].BeginEdit();
            filaEditada = GridProductosxCliente.CurrentRow.Index;

            //metodos de botones de producto x cliente en modo ediciobn
            HabilitarBtnProd(true, true, false, false, false);                        
        }
        private void cancelarProducto()
        {
            //metodos de botones de producto x cliente en modo cancelar
            HabilitarBtnProd(false, false, true, true, true);
            
            OnBuscarProdcutosxCliente();
            
            //protegerRegistro();
            estadoProductxCli = 0;
            this.GridProductosxCliente.ReadOnly = true;
            this.GridProductosxCliente.AllowEditRow = false;
            
        }
        private void cmdAddProducts_Click(object sender, EventArgs e)
        {
            agregarProducto();
            estadoProductxCli = 1;            
        }

        private void cmdDelProducts_Click(object sender, EventArgs e)
        {
            eliminarProducto();
        }
       
        private void GridProductosxCliente_CellBeginEdit(object sender, Telerik.WinControls.UI.GridViewCellCancelEventArgs e)
        {
            try {
                if (this.GridProductosxCliente.CurrentRow.Cells[15].Value.Equals("1"))
                {
                    this.GridProductosxCliente.CurrentRow.Cells[e.ColumnIndex].EndEdit();
                    
                }
            }
            catch (Exception ex) { 
            
            }
            
        }  

        private void cmdCancelProductos_Click(object sender, EventArgs e)
        {
            cancelarProducto();
            OnBuscarProdcutosxCliente();
            //protegerRegistro();
            estadoProductxCli = 0;
        }


        private void cmdSaveProductos_Click(object sender, EventArgs e)
        {
            grabarProducto();
        }

        private void cmdUpdateProducts_Click(object sender, EventArgs e)
        {
            if (this.GridProductosxCliente.RowCount == 0)
                return;
            editarProducto();          
        }

        private void GridProductosxCliente_SelectionChanged(object sender, EventArgs e)
        {           
                try
                {   
                    if (estadoProductxCli == 2) {
                    GridProductosxCliente.Rows[filaEditada].IsCurrent = true;
                    GridProductosxCliente.Rows[filaEditada].IsSelected = true;                                      
                    }
                    if (estadoProductxCli == 1) {
                        GridProductosxCliente.Rows[filaEditada].IsCurrent = true;
                        GridProductosxCliente.Rows[filaEditada].IsSelected = true;                                      
                    }
                }
                catch (Exception ex)
                {
                }                        
        }
                        
        private void radDropDownList1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                OnCancelarSede();
                limpiarSede();
                OnBuscar();
                if (gridControlSedes.RowCount > 0) {
                    gridControlSedes.Rows.Clear();
                }
                if (GridProductosxCliente.RowCount > 0) {
                    GridProductosxCliente.Rows.Clear();
                }
            }
            catch (Exception ex) { 
            
            }
        }


        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            //try
            //{
            //    if (this.Estado == FormEstate.New || Estado == FormEstate.Edit)
            //    {
            //        MessageBox.Show("No se puede seleccior otro registro mientras crea o edita");
            //        e.Cancel = true;
            //    }
            //}
            //catch (Exception ex) { 
            
            //}
            
        }

  
        //private void RemoveClickEvent(Button b)
        //{
        //    FieldInfo f1 = typeof(Control).GetField("EventClick",
        //        BindingFlags.Static | BindingFlags.NonPublic);
        //    object obj = f1.GetValue(b);
        //    PropertyInfo pi = b.GetType().GetProperty("Events",
        //        BindingFlags.NonPublic | BindingFlags.Instance);
        //    EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
        //    list.RemoveHandler(obj, list[obj]);
        //}


        

        }

        #endregion
     
 

       

       
    }

