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
    public partial class FrmTransaccion : frmBaseMante
    {
        private bool isLoaded = false;
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbGuardar;
        public FrmTransaccion()
        {
            InitializeComponent();
            Crearcolumnas();
        }
        private frmMDI FrmParent { get; set; }
        private static FrmTransaccion _aForm;
        public static FrmTransaccion Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmTransaccion(mdiPrincipal);
            _aForm = new FrmTransaccion(mdiPrincipal);
            return _aForm;
        }
        private void Ctrl_Up(object sender, KeyEventArgs e)
        {
            Util.SendEnter(e, ActiveControl, this);
        }
        public FrmTransaccion(frmMDI padre)
        {
            InitializeComponent();
            Crearcolumnas();
            FrmParent = padre;
            menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
            cbbNuevo = menu.Items["cbbNuevo"];
            cbbGuardar = menu.Items["cbbGuardar"];
            //this.cargarPermisos(this.Name);
            HabilitarBotones(true, true, true, false, false, false);
        }
        protected override void OnBuscar()
        {
            //base.OnBuscar();
            var lista = TransaccionLogic.Instance.TraerTransaccion(Logueo.CodigoEmpresa);
            this.gridControl.DataSource = lista;
        }

        protected override void OnNuevo()
        {
            this.Estado = FormEstate.New;
            Habilitar(true);
            Limpiar();
            this.txtcodigo.Focus();
            HabilitarBotones(false, false, false, true, true, false);
            //habilitarBotones(false,true);                        
        }

        protected override void OnEditar()
        {
            this.Estado = FormEstate.Edit;
            Habilitar(true);
            //Deshabilito los valores que no se pueden modificar
            txtcodigo.Enabled = false;
            HabilitarBotones(false, false, false, true, true, false);
            //habilitarBotones(false,true);
            
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
             TipoTransaccion transaccion = new TipoTransaccion();
            try
            {
                DialogResult result = RadMessageBox.Show("Está seguro de eliminar",
                    Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR,
                    MessageBoxButtons.YesNo, 
                    RadMessageIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    string msgRetorno = string.Empty;
                    string codigotransaccion = string.Empty;
                    codigotransaccion = this.gridControl.CurrentRow.Cells["in15Codigo"].Value.ToString();

                   
                    transaccion.in15codemp = Logueo.CodigoEmpresa;
                    transaccion.in15Codigo = codigotransaccion;


                    TransaccionLogic.Instance.TransaccionEliminar(transaccion, out msgRetorno);
                    RadMessageBox.Show(msgRetorno,
                        Constantes.MensajesGenericos.MSG_TITULO_INFO,
                        MessageBoxButtons.OK, RadMessageIcon.Info);
                    enfocaRegistroAnterior();
                }
            }
            catch (Exception)
            {

                RadMessageBox.Show(Constantes.MensajesGenericos.MSG_ERROR_INESPERADO, Constantes.MensajesGenericos.MSG_TITULO_ERROR, 
                    MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            OnCancelar();
          
        }
        protected override void OnCancelar()
        {
            //desactivo controles del formulario
            Habilitar(false);
            //this.cargarPermisos(this.Name);
            HabilitarBotones(true, true, true, false, false, false);
            
        }
        protected override void OnGuardar()
        {
            if (!Validar())
                return;

            string mensajeRetorno = string.Empty;
            string mensajeRetorno1 = string.Empty;
            string fechaini = string.Empty;

            TipoTransaccion transaccion = new TipoTransaccion();
            try
            {


                transaccion.in15codemp = Logueo.CodigoEmpresa;
                transaccion.in15Codigo = txtcodigo.Text.Trim();
                transaccion.in15Descripcion = txtdescripcion.Text.Trim();
                transaccion.in15ctactetipana = this.txtCodTipAnalisis.Text.Trim();
                if (this.Estado == FormEstate.New)
                {
                    //NUEVO
                    TransaccionLogic.Instance.TransaccionInsertar(transaccion, out mensajeRetorno);

                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);

                    OnBuscar();
                    Habilitar(false);
                    cbbNuevo.IsMouseOver = true;
                    cbbNuevo.Focus();
                    
                }
                else if (this.Estado == FormEstate.Edit)
                {
                    //Modificar
                    TransaccionLogic.Instance.TransaccionModificar(transaccion, out mensajeRetorno);

                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);

                    OnBuscar();
                    Habilitar(false);
                    
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
            OnCancelar();
            bool bandera = Estado == FormEstate.New ? true : false;
            
            if (Estado == FormEstate.New) {
                this.OnEnfocarRegistro(true, gridControl, transaccion.in15Codigo, "in15Codigo");
                
            }
            else if (Estado == FormEstate.Edit) {
                this.OnEnfocarRegistro(false, gridControl, transaccion.in15Codigo, "in15Codigo");
            }
            
            Estado = FormEstate.List;
          
        }

        private bool Validar()
        {
            cbbGuardar.IsMouseOver = false;
            if (this.txtcodigo.Text.Trim() == "")
            {
                RadMessageBox.Show("Debe ingresar Codigo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtcodigo.Focus();
                return false;
            }

            if (this.txtdescripcion.Text.Trim() == "")
            {
                RadMessageBox.Show("Debe ingresar Descripcion", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtdescripcion.Focus();
                return false;
            }

            if (this.txtCodTipAnalisis.Text.Trim() == "" || txtDesTipAnalisis.Text.Trim() == "???") {
                RadMessageBox.Show("Debe Tipo de analisis", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtCodTipAnalisis.Focus();
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
            this.txtCodTipAnalisis.Enabled = valor;
            this.txtDesTipAnalisis.Enabled = false;
        }

        public void Limpiar()
        {
            this.txtcodigo.Text = "";
            this.txtdescripcion.Text = "";
            this.txtCodTipAnalisis.Text = "";
            this.txtDesTipAnalisis.Text = "";
        }

        private void CargarRegistro()
        {

            if (this.gridControl.RowCount == 0)
                return;

            string codigo = string.Empty;
            codigo = this.gridControl.CurrentRow.Cells["in15Codigo"].Value.ToString();


            var transaccion = TransaccionLogic.Instance.TraerTransaccionRegistro(Logueo.CodigoEmpresa,codigo);

            if (transaccion != null)
            {
                this.txtcodigo.Text = transaccion.in15Codigo;
                this.txtdescripcion.Text = transaccion.in15Descripcion;
                this.txtCodTipAnalisis.Text = transaccion.in15ctactetipana;
                ObtenerDescripcion(enmAyuda.enmCuentaCorriente, txtCodTipAnalisis.Text);
            }
        }

        private void Crearcolumnas()
        {
            
            RadGridView grilla = this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(grilla, "Codigo", "in15Codigo", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "in15Descripcion", 0, "", 590, true, false, true);            
            this.CreateGridColumn(grilla, "TipoAnalisis", "in15ctactetipana", 0, "", 40, true, false, false);

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
                    if (e.CurrentRow.Cells["in15Codigo"].Value != null)
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
      
        private void FrmTransaccion_Load(object sender, EventArgs e)
        {
            //refresco grilla 
            OnBuscar();
            //Capturo el primer registro valido 
            CargarRegistro();
            isLoaded = true;
            //metodo para habilitar o deshabilitar los botones de mantenimineto 
            
            //habilito controles del formulario
            Habilitar(false);
        }
        private void MostrarAyuda(enmAyuda tipoAyuda) 
        {
            frmBusqueda frm;
            string codigoSeleccionado = string.Empty;
            switch (tipoAyuda) 
            { 
                case enmAyuda.enmCuentaCorriente:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();                          
                        if (codigoSeleccionado != "") 
                            this.txtCodTipAnalisis.Text = codigoSeleccionado;
                    
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
                    case enmAyuda.enmCuentaCorriente:
                        txtDesTipAnalisis.Text = string.Empty;
                        if (!string.IsNullOrEmpty(txtCodTipAnalisis.Text)) {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "TIPOANALISIS", out descripcion);
                            txtDesTipAnalisis.Text = descripcion;
                        }
                        break;
                }
            }
            catch (Exception ex) { 
            
            }
        }
        private void txtCodTipAnalisis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1) {
                MostrarAyuda(enmAyuda.enmCuentaCorriente);
            }
        }

        private void txtCodTipAnalisis_TextChanged(object sender, EventArgs e)
        {
            ObtenerDescripcion(enmAyuda.enmCuentaCorriente, txtCodTipAnalisis.Text);
        }
                  
    }


}
