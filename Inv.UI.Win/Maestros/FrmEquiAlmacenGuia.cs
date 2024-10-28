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
    public partial class FrmEquiAlmacenGuia : frmBaseMante
    {
        private bool isLoaded = false;
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbGuardar;
        public FrmEquiAlmacenGuia()
        {
            InitializeComponent();
            Crearcolumnas();
        }
        private frmMDI FrmParent { get; set; }
        private static FrmEquiAlmacenGuia _aForm;
        public static FrmEquiAlmacenGuia Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmEquiAlmacenGuia(mdiPrincipal);
            _aForm = new FrmEquiAlmacenGuia(mdiPrincipal);
            return _aForm;
        }
        private void Ctrl_Up(object sender, KeyEventArgs e)
        {
            Util.SendEnter(e, ActiveControl, this);
        }
        public FrmEquiAlmacenGuia(frmMDI padre)
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
            var lista = EquiAlmacenGuiaLogic.Instance.TraerEquiAlmVSGuias(Logueo.CodigoEmpresa);
            this.gridControl.DataSource = lista;
        }

        protected override void OnNuevo()
        {
            this.Estado = FormEstate.New;
            Habilitar(true);
            Limpiar();
            this.txtAlmTranCod.Focus();
            HabilitarBotones(false, false, false, true, true, false);
       }

        protected override void OnEditar()
        {
            RadMessageBox.Show("No se Puede Editar, Elimine y vuelva a Crear", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);

            //habilitarBotones(false,true);
            
        }
        protected override void OnEliminar()
        {
            if (this.gridControl.RowCount == 0)
                return;
            EquiAlmacenGuias Equialmguia = new EquiAlmacenGuias();
            
            try
            {
                    DialogResult result = RadMessageBox.Show("Está seguro de eliminar",
                    Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR,
                    MessageBoxButtons.YesNo, 
                    RadMessageIcon.Question);
                
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    string msgRetorno = string.Empty;
                    int flag;

                    Equialmguia.in20empresacod = Logueo.CodigoEmpresa;
                    Equialmguia.in20codtraalm = txtAlmTranCod.Text;
                    Equialmguia.in20codmotivoguia = TxtGuiaMotivoCod.Text; 
                    
                    EquiAlmacenGuiaLogic.Instance.EquiAlmGuiaEliminar(Equialmguia,out flag, out msgRetorno);
                    RadMessageBox.Show(msgRetorno,Constantes.MensajesGenericos.MSG_TITULO_INFO,
                        MessageBoxButtons.OK, RadMessageIcon.Info);

                    OnBuscar();

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
            int flag; 

            EquiAlmacenGuias Equialmguia = new EquiAlmacenGuias();

            try
            {
                Equialmguia.in20empresacod= Logueo.CodigoEmpresa;
                Equialmguia.in20codtraalm = txtAlmTranCod.Text.Trim();
                Equialmguia.in20codmotivoguia = TxtGuiaMotivoCod.Text.Trim();
                
                if (this.Estado == FormEstate.New)
                {
                    //NUEVO
                    EquiAlmacenGuiaLogic.Instance.EquiAlmGuiaInsertar(Equialmguia, out flag, out mensajeRetorno);
                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    OnBuscar();
                    Habilitar(false);
                    cbbNuevo.IsMouseOver = true;
                    cbbNuevo.Focus();
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
        
        }

        private bool Validar()
        {
            cbbGuardar.IsMouseOver = false;
            if (this.txtAlmTranCod.Text.Trim() == "")
            {
                RadMessageBox.Show("Debe ingresar Codigo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtAlmTranCod.Focus();
                return false;
            }

            if (this.txtAlmTranDesc.Text.Trim() == "" || txtAlmTranDesc.Text.Trim() == "???")
            {
                RadMessageBox.Show("Transaccion Almacen No Valida", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.TxtGuiaMotivoCod.Focus();
                return false;
            }

            if (this.TxtGuiaMotivoCod.Text.Trim() == "")
            {
                RadMessageBox.Show("Debe ingresar Motivo Guia Cod", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtAlmTranCod.Focus();
                return false;
            }

            if (this.TxtGuiaMotivoCod.Text.Trim() == "" || TxtGuiaMotivoDesc.Text.Trim() == "???") {
                RadMessageBox.Show("Motivo  Guia No Valida", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.TxtGuiaMotivoCod.Focus();
                return false;
            }
            return true;
        }

        #region metodosdemantenimineto

        public void Habilitar(bool valor)
        {
            //Estos controles siempre estan deshabilitados, por que se arman
            this.txtAlmTranCod.Enabled = valor;
            this.txtAlmTranDesc.Enabled = valor;
            this.TxtGuiaMotivoCod.Enabled = valor;
            this.TxtGuiaMotivoDesc.Enabled = valor;
        }

        public void Limpiar()
        {
            this.txtAlmTranCod.Text = "";
            this.txtAlmTranDesc.Text = "";
            this.TxtGuiaMotivoCod.Text = "";
            this.TxtGuiaMotivoDesc.Text = "";
        }

        private void CargarRegistro()
        {

            if (this.gridControl.RowCount == 0)
                return;

                this.txtAlmTranCod.Text = this.gridControl.CurrentRow.Cells["in20codtraalm"].Value.ToString();
                this.txtAlmTranDesc.Text = this.gridControl.CurrentRow.Cells["MotivoGuiaDesc"].Value.ToString();
                this.TxtGuiaMotivoCod.Text = this.gridControl.CurrentRow.Cells["in20codmotivoguia"].Value.ToString();
                this.TxtGuiaMotivoDesc.Text = this.gridControl.CurrentRow.Cells["TranAlmDesc"].Value.ToString();
        }

        
        private void Crearcolumnas()
        {
            RadGridView grilla = this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(grilla, "Empresa", "in20empresacod", 0, "", 50, true, false, false);
            this.CreateGridColumn(grilla, "Tran Alm Cod", "in20codtraalm", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Tran Alm Desc", "TranAlmDesc", 0, "", 250, true, false, true);
            this.CreateGridColumn(grilla, "Guia Mot Cod", "in20codmotivoguia", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Guia Mot Desc", "MotivoGuiaDesc", 0, "", 250, true, false, true);
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
                    if (e.CurrentRow.Cells["in20empresacod"].Value != null)
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
      
        private void FrmEquiAlmacenGuia_Load(object sender, EventArgs e)
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
                            this.TxtGuiaMotivoCod.Text = codigoSeleccionado;
                    
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
                    case enmAyuda.enmTransaccion:
                        {
                            txtAlmTranDesc.Text = string.Empty;
                        if (!string.IsNullOrEmpty(txtAlmTranCod.Text)) {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "TIPDOCSN", out descripcion);
                            txtAlmTranDesc.Text = descripcion;
                        }
                        break;
                        }
                    case enmAyuda.enmequialmguias:
                        {
                            TxtGuiaMotivoDesc.Text = string.Empty;
                        if (!string.IsNullOrEmpty(TxtGuiaMotivoCod.Text))
                        {
                            GlobalLogic.Instance.DameDescripcion(codigo, "EQUIALMGUIA", out descripcion);
                            TxtGuiaMotivoDesc.Text = descripcion;
                        }
                        break;
                        }

                        
                }
            }
            catch (Exception ex) { 
            
            }
        }

        private void txtAlmTranCod_TextChanged(object sender, EventArgs e)
        {
            ObtenerDescripcion(enmAyuda.enmTransaccion, txtAlmTranCod.Text);
        }

        private void TxtGuiaMotivoCod_TextChanged(object sender, EventArgs e)
        {
            ObtenerDescripcion(enmAyuda.enmequialmguias, TxtGuiaMotivoCod.Text);
        }

       
      

      
    }


}
