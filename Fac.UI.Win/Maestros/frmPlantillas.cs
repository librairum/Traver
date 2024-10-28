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
namespace Fac.UI.Win.Maestros
{
    public partial class frmPlantillas : frmBaseMante
    {
        public frmPlantillas()
        {
            InitializeComponent();
        }
        bool isLoaded = false;
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbGrabar;
        Plantilla plantilla = new Plantilla();
        private static frmPlantillas _aForm;

        private frmMDI frmParent { get; set; }
        void crearColumnas(){
            this.CreateGridVista(gridControl);
            this.CreateGridColumn(gridControl, "Codigo", "FAC02COD", 0, "", 80);
            this.CreateGridColumn(gridControl, "Nombre", "FAC02DESC", 0, "", 300);
            
        }
        void OnCargar() {
            var lista = PlantillaLogic.Instance.TraerPlantilla(Logueo.CodigoEmpresa, "FAC02COD", "*");
            this.gridControl.DataSource = lista;
        }
        public static frmPlantillas Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmPlantillas(formParent);
            _aForm = new frmPlantillas(formParent);
            return _aForm;
        }
        public frmPlantillas(frmMDI frmPadre) {
            InitializeComponent();
            menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
            cbbNuevo = menu.Items["cbbNuevo"];
            cbbGrabar = menu.Items["cbbGuardar"];
            crearColumnas();
            OnCargar();
            BaseHabilitarCajas(this,false);
            gestionarBotones(true, true, true, false, false);
            txtCodigo.MaxLength = 2;
            isLoaded = true;
        }
        void cargarEntidad() {
            
            plantilla.FAC02CODEMP = Logueo.CodigoEmpresa;
            plantilla.FAC02COD = txtCodigo.Text;
            plantilla.FAC02DESC = txtDescripcion.Text;
        }
        bool Validar() {
            cbbGrabar.IsMouseOver = false;
            if(string.IsNullOrEmpty(txtCodigo.Text.Trim())){
                MessageBox.Show("Ingresar codigo");
                txtCodigo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text.Trim())) {
                MessageBox.Show("Ingresar nombre");
                txtDescripcion.Focus();
                return false;
            }
            return true;
        }
        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            BaseHabilitarCajas(this, true);
            BaselimpiarCajas(this);
            txtCodigo.Focus();
            gestionarBotones(false, false, false, true, true);
            
        }
        protected override void OnEditar()
        {
            Estado = FormEstate.Edit;
            BaseHabilitarCajas(this, true);
            this.txtCodigo.Enabled = false;
            txtDescripcion.Focus();
            gestionarBotones(false, false, false, true, true);
        }
        void enfocaRegistroAnterior()
        {
            int indice = gridControl.MasterView.CurrentRow.Index;
            OnCargar();
            if (indice > 0)
            {
                gridControl.MasterView.Rows[indice - 1].IsSelected = true;
                gridControl.MasterView.Rows[indice - 1].IsCurrent = true;
            }
        }
        protected override void OnEliminar()
        {
            try
            {
                if (this.gridControl.MasterView.Rows.Count == 0) return;
                cargarEntidad();
                string msj = string.Empty;
                DialogResult res = MessageBox.Show("Esta seguro de eliminar el registro seleccionado : " +
                    plantilla.FAC02COD + "", "Sistema", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    //TipoDocumentoVentasLogic.Instance(plantilla, out msj);
                    PlantillaLogic.Instance.EliminarPlantilla(plantilla, out msj);
                    MessageBox.Show(msj);
                    enfocaRegistroAnterior();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al Eliminar : " + ex.Message);
            }
        }

        protected override void OnGuardar()
        {
            try
            {
                if (!Validar())
                    return;
                cargarEntidad();
                string msj = string.Empty;
                if (Estado == FormEstate.New)
                {
                    PlantillaLogic.Instance.InsertarPlantilla(plantilla, out msj);
                    cbbNuevo.IsMouseOver = true;
                    cbbNuevo.Focus();
                }
                else if (Estado == FormEstate.Edit)
                {
                    PlantillaLogic.Instance.ActualizarPlantilla(plantilla, out msj);
                    cbbNuevo.IsMouseOver = false;
                }
                OnCancelar();
                OnCargar();
                Util.enfocarFila(this.gridControl, "FAC02COD", plantilla.FAC02COD);
                MessageBox.Show(msj);
                Estado = FormEstate.List;
                cbbGrabar.IsMouseOver = false;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar : " + ex.Message);
            }
        }

        protected override void OnCancelar()
        {
            Estado = FormEstate.List;
            BaselimpiarCajas(this);
            BaseHabilitarCajas(this, false);
            gestionarBotones(true, true, true, false, false);
            cargarRegistro();
        }
        void cargarRegistro() {
            try
            {
                if (gridControl.RowCount == 0)
                    return;
                string codigo = string.Empty;
                string nombre = string.Empty;
                codigo = gridControl.CurrentRow.Cells["FAC02COD"].Value.ToString();
                nombre = gridControl.CurrentRow.Cells["FAC02DESC"].Value.ToString();
                                        
                txtCodigo.Text = codigo;
                txtDescripcion.Text = nombre;


            }
            catch (Exception ex)
            {
            }
        }
        private void gridControl_RowsChanged(object sender, Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
        {
           
        }

        private void gridControl_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try
            {
                if (!isLoaded) return;
                if (Estado == FormEstate.New) return;

                var row = e.CurrentRow.Cells;

                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["FAC02COD"].Value != null)
                    {
                        cargarRegistro();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
