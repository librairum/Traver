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
    public partial class frmErroresComunes : frmBaseMante
    {
        bool isloaded = false;
        private frmMDI FrmParent { get; set; }
        private static frmErroresComunes _aForm;
        public static frmErroresComunes Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmErroresComunes(mdiPrincipal);
            _aForm = new frmErroresComunes(mdiPrincipal);
            return _aForm;
        }
        public frmErroresComunes(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            CrearColumnas();
            Cargar();
            habilitarControles(false);
            HabilitarBotones(true, true, true, false, false, false);
            isloaded = true;
        }
        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(this.gridControl);
            this.CreateGridColumn(Grid, "PRO10CODEMP", "PRO10CODEMP", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "Codigo", "PRO10CODIGO", 0, "", 50, true, false, true);
            this.CreateGridColumn(Grid, "Descripcion", "PRO10DESCRIPCION", 0, "", 220, true, false, true);
            this.CreateGridColumn(Grid, "Estado", "PRO10ESTADO", 0, "", 50, true, false, true);
        }
        private void Cargar()
        {
            List<ErroresComunes> lista = ErroresComunesLogic.Instance.ListarErroresTodos(Logueo.CodigoEmpresa, 
                                                                                            txtCodigo.Text, "*");
            this.gridControl.DataSource = lista;
        }
        private void limpiar()
        {
            this.txtCodigo.Text = "";
            this.txtDescripcion.Text = "";
            this.chkActivo.Checked = false;
        }
        private void habilitarControles(bool valor)
        {
            this.txtCodigo.Enabled = false; 
            this.txtDescripcion.Enabled = valor;
            this.chkActivo.Enabled = valor;
        }
        private void CargarRegistro()
        {
            if (!isloaded) return;
            /*
               this.CreateGridColumn(Grid, "Codigo", "PRO10CODIGO", 0, "", 50, true, false, true);
            this.CreateGridColumn(Grid, "Descripcion", "PRO10DESCRIPCION", 0, "", 220, true, false, true);
            this.CreateGridColumn(Grid, "Estado", "PRO10ESTADO", 0, "", 50, true, false, true);
             */
            this.txtCodigo.Text = Util.convertiracadena(this.gridControl.CurrentRow.Cells["PRO10CODIGO"].Value);
            this.txtDescripcion.Text = Util.convertiracadena(this.gridControl.CurrentRow.Cells["PRO10DESCRIPCION"].Value);
            if(Util.convertiracadena(this.gridControl.CurrentRow.Cells["PRO10ESTADO"].Value) !="") 
            {
                this.chkActivo.Checked = true;
            }

        }
        protected override void OnNuevo()
        {
            habilitarControles(true);
            HabilitarBotones(false, false, false, true, true, false);
            limpiar();
            string nuevoCodigo = "";
            ErroresComunesLogic.Instance.TraerCodigoNuevo(Logueo.CodigoEmpresa, out nuevoCodigo);
            this.txtCodigo.Text = nuevoCodigo;
            Estado = FormEstate.New;
        }
        protected override void OnEditar()
        {
            habilitarControles(true);
            HabilitarBotones(false, false, false, true, true, false);
            Estado = FormEstate.Edit;
        }
        protected override void  OnEliminar()
        {
            string codigo = Util.convertiracadena(this.gridControl.CurrentRow.Cells["PRO10CODIGO"].Value);
            string pmensaje = ""; int pflag = 0;
            DialogResult = RadMessageBox.Show("¿Desea eliminar el registro?", "Sistema", 
                                        MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                ErroresComunesLogic.Instance.EliminarErroresComunes(Logueo.CodigoEmpresa, codigo, out pmensaje, out pflag);
                if (pflag == 0)
                {
                    RadMessageBox.Show(pmensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                else
                {
                    RadMessageBox.Show(pmensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                }
                OnCancelar();    
            }
            
        }
        protected override void OnCancelar()
        {
            limpiar();
            habilitarControles(false);            
            HabilitarBotones(true, true, true, false, false, false);
            Cargar();
            Estado = FormEstate.List;
        }
        protected override void OnGuardar()
        {
            ErroresComunes entidad = new ErroresComunes();
            entidad.PRO10CODEMP = Logueo.CodigoEmpresa;
            entidad.PRO10CODIGO = txtCodigo.Text;
            entidad.PRO10DESCRIPCION = txtDescripcion.Text;
            entidad.PRO10ESTADO = chkActivo.Checked ? "A" : "";
            try
            {
                string pmensaje = ""; int pflag = 0;
                if (Estado == FormEstate.New)
                {
                    ErroresComunesLogic.Instance.InsertarErroresComunes(entidad, out pmensaje, out pflag);
                }
                else if (Estado == FormEstate.Edit)
                {
                    ErroresComunesLogic.Instance.ActualizarErroresComunes(entidad, out pmensaje, out pflag);
                }
                else
                {
                    RadMessageBox.Show("Opcion no valido", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                if (pflag == 0)
                {
                    RadMessageBox.Show(pmensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                else
                {
                    RadMessageBox.Show(pmensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            OnCancelar();
        }

        private void gridControl_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void gridControl_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (!isloaded) return;
            CargarRegistro();

        }
    }
}
