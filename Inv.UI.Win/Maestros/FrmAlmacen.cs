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
namespace Inv.UI.Win
{

    public partial class FrmAlmacen : frmBaseMante
    {
        private bool isLoaded = false;
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
        
            RadCommandBarBaseItem  cbbExportarMovimientos;
        private frmMDI FrmParent { get; set; }
        private static FrmAlmacen _aForm;
        void mensajeSistema(string texto) {
            RadMessageBox.Show(texto, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);
        }
        public static FrmAlmacen Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmAlmacen(mdiPrincipal);
            _aForm = new FrmAlmacen(mdiPrincipal);
            return _aForm;
        }
        private void Ctrl_Up(object sender, KeyEventArgs e)
        {
            Util.SendEnter(e, ActiveControl, this);            
        }
                
        public FrmAlmacen(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Crearcolumnas();
            Habilitar(false);
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
            
            OnBuscar();

            CargarRegistro();
            isLoaded = true;

            accesobotonesperfil();
            ComportarmientoBotones("cargar");
            //Eventos de formulario

            this.gridControl.BackColor = System.Drawing.Color.Aqua;
        }
        

        protected override void OnBuscar()
        {
            //base.OnBuscar();
            
            var lista = AlmacenLogic.Instance.AlmacenTraer(Logueo.CodigoEmpresa);
            this.gridControl.DataSource = lista;
            
        }
       
        protected override void OnNuevo()
        {
            this.Estado = FormEstate.New;
            Habilitar(true);
            Limpiar();
            this.txtcodigo.Focus();
            ComportarmientoBotones("nuevo");            
            //habilitarBotones(false,true);
            cbbNuevo.IsMouseOver = false;
        }

        protected override void OnEditar()
        {
            this.Estado = FormEstate.Edit;
            Habilitar(true);
            //Deshabilito los valores que no se pueden modificar
            txtcodigo.Enabled = false;
            ComportarmientoBotones("editar");
           
            txtdescripcion.Focus();
            //habilitarBotones(false, true);
         }
        protected override void OnCancelar()
        {
            ComportarmientoBotones("cancelar");
            Habilitar(false);
            OnBuscar();            
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
                    string codigoalmacen = string.Empty;
                    codigoalmacen = this.gridControl.CurrentRow.Cells["in09codigo"].Value.ToString();

                    Almacen almacen = new Almacen();
                    almacen.in09codemp = Logueo.CodigoEmpresa;
                    almacen.in09codigo = codigoalmacen;
                    

                    AlmacenLogic.Instance.AlmacenEliminar(almacen,out msgRetorno);
                    mensajeSistema(msgRetorno);
                    enfocaRegistroAnterior();
                    //RadMessageBox.Show(msgRetorno, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);
                 
                }
            }
            catch (Exception ex)
            {
                mensajeSistema(ex.Message);
                //RadMessageBox.Show(Constantes.MensajesGenericos.MSG_ERROR_INESPERADO, Constantes.MensajesGenericos.MSG_TITULO_ERROR, MessageBoxButtons.OK, RadMessageIcon.Info);
            }

      
        }
        
        protected override void OnGuardar()
        {
            if (!Validar())
                return;

            string mensajeRetorno = string.Empty;
            string mensajeRetorno1 = string.Empty;
            string fechaini = string.Empty;
              Almacen almacen = new Almacen();
            try
            {                                
              
                almacen.in09codemp = Logueo.CodigoEmpresa;
                almacen.in09codigo = txtcodigo.Text;
                almacen.in09descripcion = txtdescripcion.Text;
                almacen.in09PRODNATURALEZA = txtCodigoNaturaleza.Text.Trim();
                almacen.in09flagmaterecuperacion = chkRecuperacion.Checked ? "1" : "0";
                almacen.in09flagMatRechazado = chkRechazado.Checked ? "S" : "";
                almacen.In09FlagConsiderarProduccion = chkProduccion.Checked ? "S" : "";
                almacen.in09flagProductoBueno = chkProductoBueno.Checked ? "1" : "0";
                almacen.in09lineacod = txtCodigoLinea.Text.Trim();
                almacen.in09actividadnivel1cod = txtCodigoNivel.Text.Trim();
                almacen.in09FlagCostear = chkCostear.Checked ? "S" : "";
               
                if (this.Estado == FormEstate.New)
                {
                    //NUEVO
                    AlmacenLogic.Instance.AlmacenInsertar(almacen, out mensajeRetorno);                    
                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    
                    Habilitar(false);

                    cbbNuevo.IsMouseOver = true;
                    cbbNuevo.Focus();
                }
                else if (this.Estado == FormEstate.Edit)
                {                    
                    //Modificar
                    AlmacenLogic.Instance.AlmacenModificar(almacen, out mensajeRetorno);                    
                    RadMessageBox.Show(mensajeRetorno, "Aviso", 
                        MessageBoxButtons.OK, RadMessageIcon.Info);                                                                                                                                 
                }
                else
                {
                    RadMessageBox.Show("Opcion no validad", "Aviso", 
                        MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }

            }
            catch (Exception)
            {

                RadMessageBox.Show("Ha ocurrido error inesperado al registrar ", "Aviso", 
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            Limpiar();
            OnCancelar();

            if (Estado == FormEstate.Edit)
            {
                this.OnEnfocarRegistro(false, gridControl, almacen.in09codigo, "in09Codigo");
            }
            else {
                this.OnEnfocarRegistro(true, gridControl, almacen.in09codigo, "in09Codigo");
            }
            Estado = FormEstate.List;

        }

        private bool Validar()
        {
            cbbGuardar.IsMouseOver = false;
            if (this.txtcodigo.Text.Length == 0 || this.txtcodigo.Text == "")
            {
                RadMessageBox.Show("Debe ingresar Codigo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtcodigo.Focus();
                return false;
            }

            if (this.txtdescripcion.Text.Length == 0 || this.txtdescripcion.Text == "")
            {
                RadMessageBox.Show("Debe ingresar Descripcion", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtdescripcion.Focus();
                return false;
            }
            if ( this.txtCodigoNaturaleza.Text.Length == 0 || this.txtCodigoNaturaleza.Text == "" || this.txtDescripcionNaturaleza.Text == "???")
            {
                RadMessageBox.Show("Debe ingresar Naturaleza", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtCodigoNaturaleza.Focus();
                return false;
            }
        return true;
        }

        #region metodosdemantenimineto
        
        public void Habilitar(bool valor)
        {
            //Estos controles siempre estan deshabilitados, por que se arman
            this.txtcodigo.Enabled = valor;
            this.txtdescripcion.Enabled = valor;

            this.txtCodigoNaturaleza.Enabled = valor;
            this.txtDescripcionNaturaleza.Enabled = false;
            
            this.txtCodigoLinea.Enabled = valor;
            this.txtDescLinea.Enabled = false;

            this.txtCodigoNivel.Enabled = valor;
            this.txtDescNivel.Enabled = false;
            
            this.chkRecuperacion.Enabled = valor;
            this.chkRechazado.Enabled = valor;
            this.chkProduccion.Enabled = valor;
            this.chkProductoBueno.Enabled = valor;
            this.chkCostear.Enabled = valor;

        }

        public void Limpiar()
        {
            this.txtcodigo.Text = "";
            this.txtdescripcion.Text = "";
            this.txtCodigoNaturaleza.Text = "";
            this.txtDescripcionNaturaleza.Text = "";
            this.chkRecuperacion.CheckState = CheckState.Unchecked;
            this.chkRechazado.CheckState = CheckState.Unchecked;

            this.txtCodigoLinea.Text = "";
            this.txtCodigoNivel.Text = "";
            this.chkProduccion.CheckState = CheckState.Unchecked;
            this.chkProductoBueno.CheckState = CheckState.Unchecked;
            this.chkCostear.CheckState = CheckState.Unchecked;
        }

        private void CargarRegistro()
        {
            try {
                if (this.gridControl.RowCount == 0)
                    return;

                string codigo = string.Empty;
                codigo = this.gridControl.CurrentRow.Cells["in09codigo"].Value.ToString();


                var almacen = AlmacenLogic.Instance.AlmacenTraerRegistro(Logueo.CodigoEmpresa, codigo);

                if (almacen != null)
                {
                    this.txtcodigo.Text = almacen.in09codigo;
                    this.txtdescripcion.Text = almacen.in09descripcion;
                    this.txtCodigoNaturaleza.Text = almacen.in09PRODNATURALEZA;

                    this.chkRecuperacion.Checked = almacen.in09flagmaterecuperacion == "0" ? false : true;
                    this.chkRechazado.Checked = almacen.in09flagMatRechazado == "S" ? true : false;
                    this.chkProduccion.Checked = almacen.In09FlagConsiderarProduccion == "S"? true: false;
                    this.chkProductoBueno.Checked = almacen.in09flagProductoBueno == "1" ? true: false;
                    
                    // =============================== Linea ==============================================
                    this.txtCodigoLinea.Text = almacen.in09lineacod;
                    this.txtDescLinea.Text = almacen.in09lineaDesc;                                        

                    // ================================ Actividad nivel 1  =================================
                    this.txtCodigoNivel.Text = almacen.in09actividadnivel1cod;
                    this.txtDescNivel.Text = almacen.in09ActNivel1Desc;

                    // ================================ Costear  ===========================================
                    this.chkCostear.Checked = almacen.in09FlagCostear == "S" ? true : false;
                }
            }
            catch (Exception ex) {
                mensajeSistema(ex.Message);
            }
            
        }

        private void Crearcolumnas()
        {
            RadGridView grilla =  this.CreateGridVista(this.gridControl);

            this.CreateGridColumn(grilla, "Codigo", "in09codigo", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "in09descripcion", 0, "", 600, true, false, true);
            this.CreateGridColumn(grilla, "Ubicacion", "in09ubicacion", 0, "", 200, true, false, true);
            this.CreateGridColumn(grilla, "Naturaleza", "in09PRODNATURALEZA", 0, "", 100);
            this.CreateGridColumn(grilla, "Alm.Recuperacion", "flagRecuperacion", 0, "", 120);

            //Oculto
            this.CreateGridColumn(gridControl, "in09lineacod", "in09lineacod", 0, "", 90, true, false, false);
            
            //Visible
            this.CreateGridColumn(gridControl, "Linea", "in09lineaDesc", 0, "", 120, true, false, true);

            //Oculto
            this.CreateGridColumn(gridControl, "in09actividadnivel1cod", "in09actividadnivel1cod", 0, "", 90, true, false, false);

            //Visible
            this.CreateGridColumn(gridControl, "Act.Nivel", "in09ActNivel1Desc", 0, "", 120, true, false, true);
            
            MasterGridViewTemplate gvMaste = grilla.MasterTemplate;
            
        } 
        #endregion metodosdemantenimineto

        private void gridControl_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try
            {
                var row = e.CurrentRow.Cells;

                //  Si no ha cargado la pantalla por complet 
                if (!isLoaded) return;

                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["in09codigo"].Value != null)
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
        private void accesobotonesperfil()
        {            
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.codModulo, this.Name, out nuevo_a, out editar_a,
                out eliminar_a, out ver_a, out imprimir_a, out refrescar_a, out importar_a, out vista_a,
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
        
        private void gridControl_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (Estado == FormEstate.Edit)
                {
                    cbbEditar.Tag = txtcodigo.Text;
                   
                }
            }
            catch (Exception ex) { 
            
            }
        }
        private void mostrarAyuda(enmAyuda tipoAyuda)
        {
            frmBusqueda frm;
            string codigoSeleccionado = string.Empty;
            switch (tipoAyuda) 
            {
                case enmAyuda.enmNaturaleza:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if(!string.IsNullOrEmpty(codigoSeleccionado)) this.txtCodigoNaturaleza.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmLinea:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtCodigoLinea.Text = codigoSeleccionado;
                    break;

                case enmAyuda.enmActividadNivel1:
                    frm = new frmBusqueda(tipoAyuda,txtCodigoLinea.Text.Trim());
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtCodigoNivel.Text = codigoSeleccionado;

                    break;
                
            }
        }
        private void ObtenerDescripcion(enmAyuda tipoAyuda, string codigo) 
        {
            //if (!isLoaded) return;
            try
            {
                string descripcion = string.Empty;
                switch (tipoAyuda) 
                {
                    case enmAyuda.enmNaturaleza:                        
                        this.txtDescripcionNaturaleza.Text = string.Empty;
                        if (!string.IsNullOrEmpty(codigo)) 
                        {
                            GlobalLogic.Instance.DameDescripcion(this.txtCodigoNaturaleza.Text.Trim(), "NATURALEZA", out descripcion);
                        }
                        this.txtDescripcionNaturaleza.Text = descripcion;
                        break;

                    case enmAyuda.enmActividadNivel1:
                        this.txtDescNivel.Text = string.Empty;
                        if (!string.IsNullOrEmpty(codigo))
                        {

                            GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtCodigoLinea.Text + codigo, 
                                                                 "ACTIVIDADNIVEL1", out descripcion);
                        }
                        this.txtDescNivel.Text = descripcion;
                        break;

                    case enmAyuda.enmLinea:
                        txtDescLinea.Text = string.Empty;
                        if (!string.IsNullOrEmpty(codigo))
                        {
                            GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + this.txtCodigoLinea.Text.Trim(), "LINEAPROD", out descripcion);
                        }
                        txtDescLinea.Text = descripcion;
                        break;
                }

            }catch (Exception ex) { 
            
            }
        }
        private void txtCodigoNaturaleza_TextChanged(object sender, EventArgs e)
        {           
            ObtenerDescripcion(enmAyuda.enmNaturaleza, this.txtCodigoNaturaleza.Text.Trim());
        }
        private void txtCodigoLinea_TextChanged(object sender, EventArgs e)
        {
            ObtenerDescripcion(enmAyuda.enmLinea, this.txtCodigoLinea.Text.Trim());
        }
        private void txtCodigoNivel_TextChanged(object sender, EventArgs e)
        {
            ObtenerDescripcion(enmAyuda.enmActividadNivel1, this.txtCodigoNivel.Text.Trim());
        }
        private void txtCodigoNaturaleza_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1) {
                mostrarAyuda(enmAyuda.enmNaturaleza);
            }            
        }

        private void txtCodigoLinea_KeyDown(object sender, KeyEventArgs e)
        { 
            if(e.KeyValue == (char)Keys.F1)
            {
                mostrarAyuda(enmAyuda.enmLinea);
            }
        }
        private void txtCodigoNivel_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCodigoLinea.Text.Trim() == "")
            {
                Util.ShowAlert("Seleccionar linea");
                return;
            }
            if (e.KeyValue == (char)Keys.F1)
            {
                mostrarAyuda(enmAyuda.enmActividadNivel1);
            }
        }
   }
}