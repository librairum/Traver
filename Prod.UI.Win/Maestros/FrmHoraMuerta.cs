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
    public partial class FrmHoraMuerta : frmBaseMante
    {
        public FrmHoraMuerta(frmMDI mdiPrincipal)
        {
            InitializeComponent();
            iniciarFormulario();            
        }
        public static FrmHoraMuerta formulario;
        private frmMDI FrmParent { get; set; }
        private static FrmHoraMuerta _aForm;
        public static FrmHoraMuerta Instance(frmMDI mdiPrincipal) 
        {
            if (_aForm != null) return new FrmHoraMuerta(mdiPrincipal);
            _aForm = new FrmHoraMuerta(mdiPrincipal);
            return _aForm;
        }
        private void limpiar() {
            this.txtCodigo.Text = "";
            this.txtDescripcion.Text = "";
        }
        private void habilitarControles(bool valor) {
            this.txtCodigo.Enabled = false;
            this.txtDescripcion.Enabled = valor;
        }
        private void iniciarFormulario() {
            limpiar();
            habilitarControles(false);
            HabilitarBotones(true, true, true, false, false, false);
            crearColumnas();
            cargar();
            Estado = FormEstate.List;
        }
        private void crearColumnas() {
             RadGridView Grid =  this.CreateGridVista(this.gridControl);
             this.CreateGridColumn(Grid, "PRO01CODEMP", "PRO01CODEMP", 0, "", 50, true, false, false);
             this.CreateGridColumn(Grid, "Codigo", "PRO01CODIGO", 0, "", 120, true, false, true);
             this.CreateGridColumn(Grid, "Descripcion", "PRO01DESCRIPCION", 0, "", 120, true, false, true);
        }
        private void cargar() {
            MotivoHoraMuerta obj= new MotivoHoraMuerta();
            obj.PRO01CODEMP = Logueo.CodigoEmpresa;
            obj.PRO01CODIGO = this.txtCodigo.Text;
            obj.PRO01DESCRIPCION = this.txtDescripcion.Text;
            var lista = MotivoHoraMuertaLogic.Instance.TraerMotivoHoraMuesta(obj, "*");
            this.gridControl.DataSource = lista;
        }
        protected override void OnNuevo()
        {
            limpiar();
            string nuevocodigo = "";
            MotivoHoraMuertaLogic.Instance.TraerCodigo(Logueo.CodigoEmpresa, out nuevocodigo);
            this.txtCodigo.Text = nuevocodigo;
            
            habilitarControles(true);
            HabilitarBotones(false, false, false, true, true, false);
            Estado = FormEstate.New;
        }
        protected override void OnCancelar()
        {
            iniciarFormulario();
            
        }
        protected override void OnEditar()
        {
            habilitarControles(true);
            HabilitarBotones(false, false, false, true, true, false);
            Estado = FormEstate.Edit;
        }
        protected override void OnGuardar()
        {
            
            MotivoHoraMuerta obj= new MotivoHoraMuerta();
            obj.PRO01CODEMP = Logueo.CodigoEmpresa;
            obj.PRO01CODIGO = this.txtCodigo.Text;
            obj.PRO01DESCRIPCION = this.txtDescripcion.Text;
            string mensaje = "";
            int flag = 0;
            try
            {
                if (Estado == FormEstate.New)
                {

                    MotivoHoraMuertaLogic.Instance.InsertarMotivoHoraMuerta(obj, out mensaje, out flag);
                    if (flag == 1)
                    {
                        RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                    else {
                        RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                    
                }
                else if (Estado == FormEstate.Edit)
                {
                    MotivoHoraMuertaLogic.Instance.ActualizarMotivoHoraMuerta(obj, out mensaje, out flag);
                    if (flag == 1)
                    {
                        RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                    } else {
                        RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                    
                }
            }
            catch (Exception ex) {
                Util.ShowError(ex.Message);
                
            }
            iniciarFormulario();
            
        }
        protected override void OnEliminar()
        {

            if (this.gridControl.Rows.Count == 0)
                return;
           MotivoHoraMuerta mhm = new MotivoHoraMuerta();
            mhm.PRO01CODEMP = Logueo.CodigoEmpresa;
            mhm.PRO01CODIGO = this.gridControl.CurrentRow.Cells["PRO01CODIGO"].Value.ToString();
            mhm.PRO01DESCRIPCION = this.gridControl.CurrentRow.Cells["PRO01DESCRIPCION"].Value.ToString();
            string mensaje = "";
            int flag = 0;
            DialogResult respuesta = RadMessageBox.Show("¿Desea eliminar el registro?", "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            { 
            MotivoHoraMuertaLogic.Instance.EliminarMotivoHoraMuerta(mhm, out mensaje, out flag);
            if (flag == 1)
            {
                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            } else {
                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            }
            iniciarFormulario();
            }
        }
        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (this.gridControl.Rows.Count == 0)
                return;
            if (e.CurrentRow == null)
                return;            
            this.txtCodigo.Text = e.CurrentRow.Cells["PRO01CODIGO"].Value.ToString();
            this.txtDescripcion.Text = e.CurrentRow.Cells["PRO01DESCRIPCION"].Value.ToString();
            
            
        }
        
    }
}
