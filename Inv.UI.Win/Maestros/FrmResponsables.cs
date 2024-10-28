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
    public partial class FrmResponsables : frmBaseMante
    {
        public FrmResponsables()
        {
            InitializeComponent();
        }
        private frmMDI FrmParent { get; set; }
        private static FrmResponsables _aForm;
        public static FrmResponsables Instance(frmMDI mdiPrincipal) {
            if (_aForm != null) return new FrmResponsables(mdiPrincipal);
            _aForm = new FrmResponsables(mdiPrincipal);
            return _aForm;
        }
        Responsable responsables = new Responsable(); 
        private void crearColumnas() 
        { 
                //ccb17cdgo	ccb17desc
            RadGridView grilla = this.CreateGridVista(gridControl);
            this.CreateGridColumn(grilla, "CodigoEmpresa", "Empresa", 0, "", 120, true, false, false);
            this.CreateGridColumn(grilla, "Codigo", "Codigo", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Nombres", "Nombre", 0, "", 250, true, false, true);
            this.CreateGridColumn(grilla, "Tipo", "Tipo", 0, "", 250, true, false, true);
        }
        
        protected override void OnBuscar()
        {
            try
            {
                Estado = FormEstate.List;
                var lista = ResponsableLogic.Instance.TraerResponsables(Logueo.CodigoEmpresa);
                this.gridControl.DataSource = lista;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        void cargarEntidad() {

            string tiporesponsable = string.Empty;
            
            responsables = new Responsable();
            responsables.Empresa = Logueo.CodigoEmpresa;
            responsables.Codigo = txtcodigo.Text.Trim();
            responsables.Nombre = txtdescripcion.Text.Trim();
            
            if (rbtemisor.Checked == true)
            { tiporesponsable = "A"; }
            else
            { tiporesponsable = "R"; }

            responsables.Tipo = tiporesponsable;
            
        }
        public FrmResponsables(frmMDI padre) 
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
            rbtemisor.Enabled = valor;
            rbtreceptor.Enabled = valor;
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

            
            ResponsableLogic.Instance.TraerResponsableNuevoCodigo(Logueo.CodigoEmpresa, out codigo);
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
                ResponsableLogic.Instance.EliminarResponsables(responsables.Empresa,responsables.Codigo, out mensaje);
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
                ResponsableLogic.Instance.InsertarResponsables(responsables.Empresa,responsables.Codigo,responsables.Nombre,responsables.Tipo, out mensaje);
            }
            else if (Estado == FormEstate.Edit) {
                ResponsableLogic.Instance.ActualizarResponsables(responsables.Empresa, responsables.Codigo, responsables.Nombre, responsables.Tipo, out mensaje);
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
                Util.enfocarFila(gridControl, "Codigo", responsables.Codigo);
            }
        }
      

        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                
                if (e.CurrentRow == null) return;
                if (gridControl.CurrentRow.Cells["Codigo"] == null) return;
                
                txtcodigo.Text = gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                txtdescripcion.Text = gridControl.CurrentRow.Cells["Nombre"].Value.ToString();
                if (gridControl.CurrentRow.Cells["Tipo"].Value.ToString() == "A") 
                    {
                        rbtemisor.Checked = true;
                    } else
                    {
                        rbtreceptor.Checked = true;
                    }
            
            }catch(Exception ex){
    
            }
        }

        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {            
            e.Cancel = Estado == FormEstate.Edit || Estado == FormEstate.New ? true : false;            
        }

    }
}
