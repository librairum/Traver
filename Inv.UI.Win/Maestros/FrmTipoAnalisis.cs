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
    public partial class FrmTipoAnalisis : frmBaseMante
    {
        public FrmTipoAnalisis()
        {
            InitializeComponent();

        }
        private frmMDI FrmParent { get; set; }
        private static FrmTipoAnalisis _aForm;
        public static FrmTipoAnalisis Instance(frmMDI mdiPrincipal) {
            if (_aForm != null) return new FrmTipoAnalisis(mdiPrincipal);
            _aForm = new FrmTipoAnalisis(mdiPrincipal);
            return _aForm;
        }
        TipoAnalisis analisis = new TipoAnalisis();
        private void crearColumnas() 
        { 
                //ccb17cdgo	ccb17desc
            RadGridView grilla = this.CreateGridVista(gridControl);
            this.CreateGridColumn(grilla, "CodigoEmpresa", "CodigoEmpresa", 0, "", 120, true, false, false);
            this.CreateGridColumn(grilla, "Codigo", "Codigo", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "Descripcion", 0, "", 250, true, false, true);
        }
        void cargarEntidad() {
            analisis = new TipoAnalisis();
            analisis.CodigoEmpresa = Logueo.CodigoEmpresa;
            analisis.Codigo = txtcodigo.Text.Trim();
            analisis.Descripcion = txtdescripcion.Text.Trim();
        }
        public FrmTipoAnalisis(frmMDI padre) 
        {

            try
            {
                InitializeComponent();
            
            FrmParent = padre;
            HabilitarBotones(true, true, true, false, false, false);
            HabilitarControles(false);
            crearColumnas();
            OnBuscar();
            }
            catch (Exception)
            {

            }
        }
       
        void HabilitarControles(bool valor) {
            txtcodigo.Enabled = false;
            txtdescripcion.Enabled = valor;
        }

        void LimpiarControles() {
            txtcodigo.Text = "";
            txtdescripcion.Text = "";
        }

        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            LimpiarControles();
            string codigo = string.Empty;
            
            HabilitarBotones(false, false, false, true, true, false);
            HabilitarControles(true);

            
            TipoAnalisisLogic.Instance.TraerTipoAnalisisCodigo(Logueo.CodigoEmpresa, out codigo);
            txtcodigo.Text = codigo;
            txtdescripcion.Focus();
        }

        protected override void OnEditar()
        {
            Estado = FormEstate.Edit;
            HabilitarBotones(false, false, false, true, true, false);
            HabilitarControles(true);
        }

        protected override void OnEliminar()
        {
            if (gridControl.Rows.Count == 0) return;
            Estado = FormEstate.List;
            cargarEntidad();
            DialogResult res = RadMessageBox.Show("¿Desea eliminar el registro?", "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            string mensaje = string.Empty;
            if (res == System.Windows.Forms.DialogResult.Yes) 
            {
                TipoAnalisisLogic.Instance.EliminarTipoAnalisis(analisis, out mensaje);
            }
            
            OnBuscar();
            RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
        }
        bool Validar() 
        {
            if (txtcodigo.Text.Trim() == "" || txtcodigo.Text.Length == 0) 
            {
                RadMessageBox.Show("Ingresar codigo", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return false;    
            }
            if (txtdescripcion.Text.Trim() == "" || txtdescripcion.Text.Length == 0)
            {
                RadMessageBox.Show("Ingresar Descripcion", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return false;
            }
            
            return true;
        }
        protected override void OnGuardar()
        {
            if (!Validar()) return;
            cargarEntidad();
            string mensaje = string.Empty;
            if (Estado == FormEstate.New) {
                TipoAnalisisLogic.Instance.InsertarTipoAnalisis(analisis, out mensaje);
            }
            else if (Estado == FormEstate.Edit) {
                TipoAnalisisLogic.Instance.ActualizarTipoAnalisis(analisis, out mensaje);
            }
            RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
            //OnBuscar();
            OnCancelar();
    
            
        }
        protected override void OnCancelar()
        {
            Estado = FormEstate.List;
            HabilitarBotones(true, true, true, false, false, false);
            HabilitarControles(false);
            LimpiarControles();
            OnBuscar();
            if (gridControl.Rows.Count > 0) {
                Util.enfocarFila(gridControl, "Codigo", analisis.Codigo);
            }
        }
        protected override void OnBuscar()
        {
            try
            {
                Estado = FormEstate.List;
                var lista = TipoAnalisisLogic.Instance.TraerTipoAnalisis(Logueo.CodigoEmpresa);
                this.gridControl.DataSource = lista;
            }
            catch (Exception ex) {
                throw;
            }
        }

        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                if (e.CurrentRow == null) return;
                if (gridControl.CurrentRow.Cells["Codigo"] == null) return;
                txtcodigo.Text = gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                txtdescripcion.Text = gridControl.CurrentRow.Cells["Descripcion"].Value.ToString();
            
            }catch(Exception ex){
    
            }
        }

        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {            
            e.Cancel = Estado == FormEstate.Edit || Estado == FormEstate.New ? true : false;            
        }

    }
}
