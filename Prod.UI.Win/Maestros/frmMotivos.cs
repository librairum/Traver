using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessEntities;
using Inv.BusinessLogic;
using Telerik.WinControls.UI;
namespace Prod.UI.Win
{
    public partial class frmMotivos : frmBaseMante
    {
        private frmMDI FrmParent { get; set; }
        private static frmMotivos _aForm;
        public static frmMotivos Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmMotivos(mdiPrincipal);
            _aForm = new frmMotivos(mdiPrincipal);
            return _aForm;
        }

        public frmMotivos(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            iniciarformulario();
        }
        
        private void iniciarformulario() 
        {
            CrearColumnas();
            Cargar();
            limpiar();
            HabilitarBotones(true, true, true, false, false, false);
            HabilitraControles(false);
        }
        private void limpiar()
        {
            this.txtCodigo.Text = "";
            this.txtDescripcion.Text = "";
        }
        protected override void OnNuevo()
        {
            limpiar();
            string nuevocodigo = string.Empty;
            MotivoLogic.Instance.TraerNuevoCodigo(Logueo.CodigoEmpresa, out nuevocodigo);
            this.txtCodigo.Text = nuevocodigo;
            HabilitarBotones(false, false, false, true, true, false);
            HabilitraControles(true);            
            Estado = FormEstate.New;
        }
        private void CrearColumnas()
        {
            RadGridView Grid = this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(Grid, "CodigoEmpresa", "", 0, "", 50, true, false, false);
            this.CreateGridColumn(Grid, "Codigo", "PRO15CODIGO", 0, "", 90, true, false);
            this.CreateGridColumn(Grid, "Descripcion", "PRO15DESCRIPCION", 0, "", 150, true, false);
        }
        private void Cargar()
        {
            this.gridControl.DataSource = MotivoLogic.Instance.TraerLista(Logueo.CodigoEmpresa);
        }
        private void HabilitraControles(bool valor) 
        {
            this.txtCodigo.Enabled = false;
            this.txtDescripcion.Enabled = valor;
        }
        protected override void OnCancelar()
        {
            HabilitarBotones(true, true, true, false, false, false);
            HabilitraControles(false);
            Cargar();
            Estado = FormEstate.List;
        }
        private bool Validar()
        {
            if (txtDescripcion.Text.Trim() == "")
            {
                RadMessageBox.Show("Ingresar descripcion", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return false;
            }
            return true;
        }
        protected override void OnGuardar()
        {
            Motivo m = new Motivo();
            if (!Validar())
                return;

            m.PRO15CODEMP = Logueo.CodigoEmpresa;
            m.PRO15CODIGO = txtCodigo.Text.Trim();
            m.PRO15DESCRIPCION = txtDescripcion.Text.Trim();
            int cflag = 0;
            string cmsgretorno = "";
            if (Estado == FormEstate.New)
            {
                MotivoLogic.Instance.Insertar(m, out cflag, out cmsgretorno);
                if (cflag == 0)
                {
                    RadMessageBox.Show(cmsgretorno, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                else {
                    RadMessageBox.Show(cmsgretorno, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            else if (Estado == FormEstate.Edit)
            {
                MotivoLogic.Instance.Actualizar(m, out cflag, out cmsgretorno);
                if (cflag == 0)
                {
                    RadMessageBox.Show(cmsgretorno, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                else
                {
                    RadMessageBox.Show(cmsgretorno, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            OnCancelar();
        }
        protected override void OnEditar()
        {
            HabilitarBotones(false, false, false, true, true, false);
            HabilitraControles(true);
            Estado = FormEstate.Edit;
        }
        protected override void OnEliminar()
        {
            Motivo m = new Motivo();
            m.PRO15CODEMP = Logueo.CodigoEmpresa;
            m.PRO15CODIGO = txtCodigo.Text.Trim();
            int cflag = 0 ;
            string cmsgretorno = "";
            DialogResult res;
            res = RadMessageBox.Show("¿Desea eliminar el registro?", "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                MotivoLogic.Instance.Eliminar(m, out cflag, out cmsgretorno);
                if (cflag == 0)
                {
                    RadMessageBox.Show(cmsgretorno, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                else if (cflag == -1)
                {
                    RadMessageBox.Show(cmsgretorno, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            OnCancelar();
            
        }
        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if(this.gridControl.RowCount == 0) return;
            if (e.CurrentRow != null)
            {
                this.txtCodigo.Text = e.CurrentRow.Cells["PRO15CODIGO"].Value.ToString();
                this.txtDescripcion.Text = e.CurrentRow.Cells["PRO15DESCRIPCION"].Value.ToString();
            }
            
        }
    }
}
