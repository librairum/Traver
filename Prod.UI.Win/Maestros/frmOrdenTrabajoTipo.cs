using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

using Inv.BusinessEntities;
using Inv.BusinessLogic;
namespace Prod.UI.Win
{
    public partial class frmOrdenTrabajoTipo : frmBaseMante
    {
        public frmOrdenTrabajoTipo()
        {
            InitializeComponent();
        }
        public static frmOrdenTrabajoTipo formulario;
        private frmMDI FrmParent { get; set; }
        private static frmOrdenTrabajoTipo _aForm;
        public static frmOrdenTrabajoTipo Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmOrdenTrabajoTipo(mdiPrincipal);
            _aForm = new frmOrdenTrabajoTipo(mdiPrincipal);
            return _aForm;
        }
        private bool isLoaded;
        private void iniciarformulario()
        {
            this.HabilitarBotones(true, true, true, false, false, false);
            habilitarControles(false);
            limpiar();
            Cargar();
            Estado = FormEstate.List;
        }
        protected override void OnNuevo()
        {
            HabilitarBotones(false, false, false, true, true, false);
            habilitarControles(true);
            limpiar();
            string cCodigo = "";
            int cFlag = 0;
            string cMensaje = "";

            
            OrdenTrabajoLogic.Instance.TraerNroOrdenTrabajoTipo(Logueo.CodigoEmpresa, out cCodigo, out cFlag, out cMensaje);
            if (cFlag == 0)
            {
                this.txtCodigo.Text = cCodigo;
            }
            else {
                // Error al generar codigo 
                RadMessageBox.Show(cMensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            }
            txtDescripcion.Focus();
            Estado = FormEstate.New;   
        }
        protected override void OnEditar()
        {
            HabilitarBotones(false, false, false, true, true, false);
            habilitarControles(true);
            txtDescripcion.Focus();

            Estado = FormEstate.Edit;
        }
        protected override void OnEliminar()
        {
            int cFlag = 0;
            string cMensaje = "";
            DialogResult res = RadMessageBox.Show("Desea Eliminar el registro", "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                OrdenTrabajoLogic.Instance.EliminarOrdenTrabajoTipo(Logueo.CodigoEmpresa, txtCodigo.Text.Trim(), out cFlag, out cMensaje);
                if (cFlag == 0)
                {
                    RadMessageBox.Show(cMensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                else {
                    RadMessageBox.Show(cMensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                }
            }
            Estado = FormEstate.List;
            iniciarformulario();
        }
        
        protected override void OnCancelar()
        {
            iniciarformulario();
        }
        
        protected override void OnGuardar()
        {
            int cFlag = 0;
            string cMensaje = "";
            try
            {
                if (Estado == FormEstate.New)
                {
                    OrdenTrabajoLogic.Instance.InsertarOrdenTrabajoTipo(Logueo.CodigoEmpresa,
                        txtCodigo.Text.Trim(), txtDescripcion.Text.Trim(), out cFlag, out cMensaje);
                }
                else if (Estado == FormEstate.Edit)
                {
                    OrdenTrabajoLogic.Instance.ActualizarOrdenTrabajoTipo(Logueo.CodigoEmpresa,
                        txtCodigo.Text.Trim(), txtDescripcion.Text.Trim(), out cFlag, out cMensaje);
                }
                if (cFlag == 0)
                {
                    RadMessageBox.Show(cMensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                else {
                    RadMessageBox.Show(cMensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                }
                iniciarformulario();
            }
            catch (Exception ex)
            {
                iniciarformulario();
            }
        }
        private void CargarRegistro()
        {
            txtCodigo.Text = Util.convertiracadena(this.gridControl.CurrentRow.Cells["PRO01CODIGO"].Value);
            txtDescripcion.Text = Util.convertiracadena(this.gridControl.CurrentRow.Cells["PRO01DESCRIPCION"].Value);
        }
        private void cancelar()
        {
            Estado = FormEstate.List;
            iniciarformulario();
        }
        private void limpiar()
        {
            this.txtCodigo.Text = "";
            this.txtDescripcion.Text = "";
        }
        private void habilitarControles(bool valor)
        { 
            this.txtCodigo.Enabled = false;
            this.txtDescripcion.Enabled = valor;
        }
        
        public frmOrdenTrabajoTipo(frmMDI mdiPrincipal)
        {
            InitializeComponent();
            FrmParent = mdiPrincipal;
            iniciarformulario();
            CrearColumnas();
            isLoaded = true;
        }
        private void CrearColumnas()
        { 
             RadGridView Grid =  this.CreateGridVista(this.gridControl);
             this.CreateGridColumn(Grid, "Empresa", "PRO01CODEMP", 0, "", 70, true, false, false);
             this.CreateGridColumn(Grid, "Codigo", "PRO01CODIGO", 0, "", 90, true, false, true);
             this.CreateGridColumn(Grid, "Descripcion", "PRO01DESCRIPCION", 0, "", 150);           
        }
        private void Cargar()
        {
            List<OrdenTrabajoTipo> lista =  OrdenTrabajoLogic.Instance.TraerOrdenTrabajoTipo(Logueo.CodigoEmpresa, 
                                                                                             txtCodigo.Text.Trim());
            this.gridControl.DataSource = lista;

        }

        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if(!isLoaded) return;
            if (e.CurrentRow != null)
                CargarRegistro();

        }
    }
}
