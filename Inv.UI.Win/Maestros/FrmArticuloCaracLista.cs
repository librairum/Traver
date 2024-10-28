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
    public partial class FrmArticuloCaracLista : frmBaseMante
    {
        private bool isLoaded = false;
        
        ArticuloCaracteristicas articulocaracteristicas = new ArticuloCaracteristicas();
        public FrmArticuloCaracLista()
        {
            InitializeComponent();
            Crearcolumnas();
            CrearcolumnasDet();
            Mostrarcodformato(false);
            OnBuscar();
        }
        
        private frmMDI FrmParent { get; set; }
        private static FrmArticuloCaracLista _aForm;

        public static FrmArticuloCaracLista Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmArticuloCaracLista(mdiPrincipal);
            _aForm = new FrmArticuloCaracLista(mdiPrincipal);
            return _aForm;
        }
        void Habilitar(bool estado) {
            this.txtcodigo.Enabled = estado;
            this.txtdescripcion.Enabled = estado;
            this.txtAbreviatura.Enabled = estado;
        }
        public FrmArticuloCaracLista(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Crearcolumnas();
            CrearcolumnasDet();
            Mostrarcodformato(false);
                        
            OnBuscar();
            //this.cargarPermisos(this.Name);
            HabilitarBotones(true, true, true, false, false, false);
            //desactivo controles 
            Habilitar(false);
            Estado = FormEstate.List;
        }

        private void Crearcolumnas()
        {         
            RadGridView grilla =  this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(grilla, "Codigo", "codigotabla", 0, "", 120, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "descripcion", 0, "", 270, true, false, true);
        }

        private void CrearcolumnasDet()
        {        
            RadGridView grillaDet = this.CreateGridVista(this.gridControlDet);
            this.CreateGridColumn(grillaDet, "Codigo Tabla", "codigotabla", 0, "", 30, true, false, true);
            this.CreateGridColumn(grillaDet, "Codigo", "codigo", 0, "", 80, true, false, true);
            this.CreateGridColumn(grillaDet, "Descripcion", "descripcion", 0, "", 200, true, false, true);
            this.CreateGridColumn(grillaDet, "Area Modelo", "glo01area", 0, "", 80, true, false, true);
        }

        private void FrmArticuloCaracLista_Load(object sender, EventArgs e)
        {
            Crearcolumnas();
            CrearcolumnasDet();
            isLoaded=true;
            // Carga en modo ver
            BloquearControlesDatos(false);

            if (gridControl.IsLoaded) {
                if (gridControl.RowCount > 0)
                {
                    OnBuscarDet(gridControl.CurrentRow.Cells["codigotabla"].Value.ToString());
                }
            }
            //this.cargarPermisos(this.Name);
            HabilitarBotones(true, true, true, false, false, false);
        }
        protected override void OnBuscar()
        {
            //base.OnBuscar();
            var lista = ArticuloCaracteristicasLogic.Instance.ArticuloCaracteristicasTablas("--");
            this.gridControl.DataSource = lista;
        }

        protected void OnBuscarDet(string codigotabla)
        {
            //base.OnBuscar();

            var lista = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(codigotabla);
            this.gridControlDet.DataSource = lista;
            
        }

        private void BloquearControlesDatos(bool valor)
        {
            txtcodigo.Enabled = valor;
            txtdescripcion.Enabled = valor;
            txtarea.Enabled = valor;
            txtAbreviatura.Enabled = valor;
            //Para el formato
            Mostrarcodformato(false);
           }

        private void Mostrarcodformato(bool valor)
        {
                //Para el formato
                //txtlargo.Visible = valor;
                //txtancho.Visible = valor;
                //txtespesor.Visible = valor;
                rpFormato.Visible = valor;
                //txtcodigo.Enabled = !valor;
        }
        private void LimpiarControlesDatos()
        {
            txtcodigo.Text = "";
            txtdescripcion.Text = "";
            txtlargo.Text = "";
            txtancho.Text = "";
            txtespesor.Text = "";
            txtarea.Text = "";
            txtAbreviatura.Text = "";
        }

        private void CargarDocumento(string codigotabla,string codigo)
        {
            //BloquearIngresoDatos();
            //Carga el documento y su detalle
            var articulocaracteristicas = ArticuloCaracteristicasLogic.Instance.ArticuloCaracteristicasRegistro(codigotabla, codigo);
            
            if (articulocaracteristicas.codigo != null)
            {
                this.txtcodigo.Text = articulocaracteristicas.codigo;
                this.txtdescripcion.Text = articulocaracteristicas.descripcion;
                this.txtarea.Text = Convert.ToString(articulocaracteristicas.glo01area);
                this.txtAbreviatura.Text = articulocaracteristicas.glo01descripcionAbreviada;
                // Si tiene codigo de formato separa las medidas del formato 
                if (codigotabla == Constantes.ProTerCarateristicas.formato)
                {
                    txtancho.Text = articulocaracteristicas.codigo.Substring(0, 3);
                    txtlargo.Text = articulocaracteristicas.codigo.Substring(3, 3);
                    txtespesor.Text = articulocaracteristicas.codigo.Substring(6, 3);
                }
            }
        }
   
        protected override void OnNuevo()
        {
            this.Estado = FormEstate.New;
            BloquearControlesDatos(true);
            LimpiarControlesDatos();
            
            // 

            if (this.gridControl.CurrentRow.Cells["codigotabla"].Value.ToString() == Constantes.ProTerCarateristicas.formato)
            {
                Mostrarcodformato(true);
            }
            else
            {
                Mostrarcodformato(false);
            }

            if (this.gridControl.CurrentRow.Cells["codigotabla"].Value.ToString() == Constantes.ProTerCarateristicas.modelo)
            {
               txtarea.Enabled=true;
            }
            else
            {
                txtarea.Enabled = false;
            }

            //habilitarBotones(false, false, false, false, false, false);
            HabilitarBotones(false, false, false, true, true, false);
            //habilitarBotones(false, true);
            txtcodigo.Focus();
        }

        protected override void OnEditar()
        {
             if (this.gridControl.RowCount == 0)
                return;
            this.Estado = FormEstate.Edit;
            BloquearControlesDatos(true);
            // Controles que no se pueden modificar
            txtcodigo.Enabled = false;

            if (this.gridControl.CurrentRow.Cells["codigotabla"].Value.ToString() == Constantes.ProTerCarateristicas.modelo)
            {
                txtarea.Enabled = true;
            }
            else
            {
                txtarea.Enabled = false;
            }
            if (this.gridControl.CurrentRow.Cells["Codigotabla"].Value.ToString() == Constantes.ProTerCarateristicas.formato)
            {
                Mostrarcodformato(true);
            }
            //habilitarBotones(false, false, false, false, false, false);
            HabilitarBotones(false, false, false, true, true, false);
            //habilitarBotones(false, true);
       }

        protected override void OnEliminar()
        {
            if (this.gridControlDet.RowCount == 0)
                return;

            try
            {
                DialogResult result = RadMessageBox.Show("Está seguro de eliminar", Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR, MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    string msgRetorno = string.Empty;
                    string codigotabla = string.Empty;
                    string codigo = string.Empty;
                    int flagok = -1;

                    codigotabla = this.gridControl.CurrentRow.Cells["codigotabla"].Value.ToString();
                    codigo = this.gridControlDet.CurrentRow.Cells["codigo"].Value.ToString();

                    ArticuloCaracteristicas articulocaracteristicas = new ArticuloCaracteristicas();
                    articulocaracteristicas.codigotabla = codigotabla;
                    articulocaracteristicas.codigo = codigo;

                    ArticuloCaracteristicasLogic.Instance.ArticuloCaracteristicasEliminar(articulocaracteristicas,out flagok,out msgRetorno);

                    if (flagok != -1)
                    {
                        RadMessageBox.Show(msgRetorno, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);

                    }
                    else {
                        RadMessageBox.Show(msgRetorno, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);
                    }


                    //OnBuscarDet(codigotabla);
                }
            }
            catch (Exception)
            {

                RadMessageBox.Show(Constantes.MensajesGenericos.MSG_ERROR_INESPERADO, Constantes.MensajesGenericos.MSG_TITULO_ERROR, MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            OnCancelar();
        }
    
        protected override void OnGuardar()
        {
            if (!Validar())
                return;

            string mensajeRetorno = string.Empty;
            int flagok = -1;
            double areamodelo = 0;
            try
            {

                if (this.gridControl.CurrentRow.Cells["codigotabla"].Value.ToString() == Constantes.ProTerCarateristicas.modelo)
                {
                    areamodelo = Convert.ToDouble(txtarea.Text);
                }
                

                articulocaracteristicas.codigotabla = this.gridControl.CurrentRow.Cells["codigotabla"].Value.ToString();
                articulocaracteristicas.codigo = txtcodigo.Text;
                articulocaracteristicas.descripcion = txtdescripcion.Text;
                articulocaracteristicas.glo01area = areamodelo;
                articulocaracteristicas.glo01descripcionAbreviada = txtAbreviatura.Text.Trim();
                articulocaracteristicas.glo01altoUnimed = txtespesor.Text;
                articulocaracteristicas.glo01anchoUnimed = txtancho.Text;
                articulocaracteristicas.glo01largoUnimed = txtlargo.Text;
                
                if (this.Estado == FormEstate.New)
                {
                    //NUEVO
                    ArticuloCaracteristicasLogic.Instance.ArticuloCaracteristicasInsertar(articulocaracteristicas,out flagok, out mensajeRetorno);
                    if (flagok != -1)
                    {
                        RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                     
                        
                        //return;
                    }
                    else
                    {
                        RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                    //Habilitar(false);
                    //RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                else
                {
                    //MODIFICA
                    ArticuloCaracteristicasLogic.Instance.ArticuloCaracteristicasModificar(articulocaracteristicas,out flagok, out mensajeRetorno);
                    if (flagok != -1)
                    {
                        RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                        
                        //return;
                    }
                    else
                    {
                        RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                }
                
                //this.Estado = FormEstate.Edit;
                
            }
            catch (Exception)
            {

                RadMessageBox.Show("Ha ocurrido error inesperado al registrar caracteristicas", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            OnCancelar();
            if (Estado == FormEstate.New)
            {

                //this.OnEnforcarRegistro(true, gridControlDet, articulocaracteristicas.codigo, "codigo");
            }
            else
            {
                //this.OnEnforcarRegistro(false, gridControlDet, articulocaracteristicas.codigo, "codigo");
            }
            

            Estado = FormEstate.List;
            HabilitarBotones(true, true, true, false, false, false);
            //habilitarBotones(true, false);

        }
        
     
        /// <summary>
        /// Obtener el ultimo registro insertad o actualizado
        /// </summary>
        /// <param name="esNuevo">bandera de operacion</param>
        /// <param name="gv">nombre de la grilla</param>
        /// <param name="codigoRegistro">codigo ingresa en cadena si es nuevo enviar solo en blanco  -> "" </param>

        protected override void OnCancelar()
        {
            Estado = FormEstate.List;
            //OnBuscar();
            if (gridControl.IsLoaded)
            {
                if (gridControl.RowCount > 0)
                {
                    OnBuscarDet(gridControl.CurrentRow.Cells["codigotabla"].Value.ToString());
                }
            }

            Habilitar(false);
            //this.cargarPermisos(this.Name);
            HabilitarBotones(true, true, true, false, false, false);
            Mostrarcodformato(false);
            
        }
        private bool Validar()
        {
            if (this.txtcodigo.Text.Length == 0)
            {
                RadMessageBox.Show("Debe ingresar codigo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtcodigo.Focus();
                return false;
            }

            if (this.txtdescripcion.Text.Length == 0)
            {
                RadMessageBox.Show("Debe ingresar descripcion", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtdescripcion.Focus();
                return false;
            }            
            return true;
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            OnGuardar();
        }

        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
       
            try
            {
                string codigotabla = string.Empty;
                var row = e.CurrentRow.Cells;
                if (!isLoaded) return;
                
                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["codigotabla"].Value != null)
                    {

                        codigotabla = e.CurrentRow.Cells["codigotabla"].Value.ToString();
                        OnBuscarDet(codigotabla);
                    }
                }
            }
            catch (Exception ex) { 
            
            }
        //  Si no ha cargado la pantalla por complet 
            
                }
        private void gridControlDet_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
            {
                try
                {
                    string codigotabla = string.Empty;
                    string codigo = string.Empty;
                    var row = e.CurrentRow.Cells;

                    //  Si no ha cargado la pantalla por complet 
                    if (!isLoaded) return;

                    if (e.CurrentRow.Cells != null)
                    {
                        if (e.CurrentRow.Cells["codigotabla"].Value != null)
                        {
                            codigo = e.CurrentRow.Cells["codigo"].Value.ToString();
                            codigotabla = e.CurrentRow.Cells["codigotabla"].Value.ToString();
                            CargarDocumento(codigotabla, codigo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            string codigotabla = string.Empty;
            string codigo=string.Empty;

            LimpiarControlesDatos();
            BloquearControlesDatos(false);
            // Capturar codigo de tabla y codigo
              codigotabla = (string)this.gridControlDet.CurrentRow.Cells["codigotabla"].Value;
              codigo = (string)this.gridControlDet.CurrentRow.Cells["codigo"].Value;
            CargarDocumento(codigotabla, codigo);
            //habilitarBotones(true, true, true, true, true, true);
            OnCancelar();
        }

       
        private void MostrarAyuda(enmAyuda tipoAyuda)
        {
            frmBusqueda frm = new frmBusqueda(tipoAyuda);
            string codigoSeleccionado = string.Empty;
            switch (tipoAyuda)
            {
                case enmAyuda.enmLargo:
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtlargo.Text = codigoSeleccionado;

                    break;
       
                case enmAyuda.enmAncho:
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtancho.Text = codigoSeleccionado;

                    break;
                case enmAyuda.enmEspesor:
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtespesor.Text = codigoSeleccionado;
                    break;
                default:
                    break;
            }
        }

        private void txtlargo_TextChanged(object sender, EventArgs e)
        {
            this.productoterminadoarmarcodigoformato();
        }
        private void txtAncho_TextChanged(object sender, EventArgs e)
        {
            this.productoterminadoarmarcodigoformato();
        }
        private void txtEspesor_TextChanged(object sender, EventArgs e)
        {
            this.productoterminadoarmarcodigoformato();
        }

        private void productoterminadoarmarcodigoformato()
        {
            try
            {
                this.txtcodigo.Text = txtancho.Text + txtlargo.Text +txtespesor.Text;

                var articulo = ArticuloLogic.Instance.ProterDescripcionFormato(txtcodigo.Text);

                if (articulo != null)
                {
                    this.txtdescripcion.Text = articulo.IN01DESLAR;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void txtlargo_KeyDown(object sender, KeyEventArgs e)
        {
            Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmLargo);
        }

        private void txtancho_KeyDown(object sender, KeyEventArgs e)
        {
            Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmAncho);
        }

        private void txtespesor_KeyDown(object sender, KeyEventArgs e)
        {
            Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmEspesor);
        }

        private void gridControlDet_Click(object sender, EventArgs e)
        {

        }

        private void radPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Ctrl_Up(object sender, KeyEventArgs e)
        {
            Util.SendEnter(e, ActiveControl, this);
        }

        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            if (Estado == FormEstate.List) return;
            if (Estado == FormEstate.Edit || Estado == FormEstate.New)
            {
                RadMessageBox.Show("Debe terminar el proceso actual", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void gridControlDet_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            if (Estado == FormEstate.List) return;
            if (Estado == FormEstate.New)
            {
                RadMessageBox.Show("Debe terminar el proceso actual", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                e.Cancel = true;
            }
        }
    }
}
