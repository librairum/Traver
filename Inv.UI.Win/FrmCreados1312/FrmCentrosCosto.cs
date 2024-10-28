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
    public partial class FrmCentrosCosto : frmBaseMante
    {
        private bool isLoaded = false;
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a,
            cancelar_a, expmovi_a;
        CommandBarStripElement menu;

        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbEditar;
        RadCommandBarBaseItem cbbEliminar;

        RadCommandBarBaseItem cbbVer;
        RadCommandBarBaseItem cbbVista;
        RadCommandBarBaseItem cbbImprimir;
        RadCommandBarBaseItem cbbRefrescar;
        RadCommandBarBaseItem cbbImportar;

        RadCommandBarBaseItem cbbGuardar;
        RadCommandBarBaseItem cbbCancelar;
        RadCommandBarBaseItem cbbExportarMovimientos;
        private frmMDI FrmParent { get; set; }
        private static FrmCentrosCosto _aForm;
        public static FrmCentrosCosto Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return  new FrmCentrosCosto(mdiPrincipal);
            _aForm = new FrmCentrosCosto(mdiPrincipal);
            return _aForm;
        }
        public FrmCentrosCosto(frmMDI padre)
        {
            InitializeComponent();
        

        }
        public void Cargar()
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable dt = DocumentoLogic.Instance.Trae_Centros_Costo(Logueo.CodigoEmpresa, Logueo.Anio);
            this.gridControl.DataSource = dt;
        }

        private void crearGrilla() 
        {
            RadGridView grilla = CreateGridVista(gridControl);
            this.CreateGridColumn(grilla, "Codigo", "ccb02cod", 0, "", 100, false,false,true);
            this.CreateGridColumn(grilla, "Descripcion", "ccb02des", 0, "", 200,false,false,true);
            this.CreateGridColumn(grilla, "flag", "flag", 0, "", 50, false, true, false);
            //grilla.Columns.Add("In21codigo", "Codigo", "In21codigo");

            //grilla.Columns.Add("In21descri", "Descripcion", "In21descri");
            //grilla.Columns[0].Width = 100;
            //grilla.Columns[1].Width = 300;
            //grilla.AllowEditRow = false;
        }

        protected override void OnNuevo() 
        {
            //Estado = FormEstate.New;
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            gridControl.Rows.AddNew();
            Estado = FormEstate.New;
            Util.SetCellInitEdit(gridControl, "ccb02cod");

        }
        protected override void OnEditar() {
            try {
                Estado = FormEstate.Edit;
                OcultarBotones();
                HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);

                Util.enfocarFila(gridControl, "ccb02des", "");
                Util.SetCellInitEdit(gridControl, "ccb02des");
                
            }
            catch (Exception ex) { 
            
            }
            //retorno la configuracion de los botones a su  configuracion inciial
            //HabilitarBotones(false, false, false, true, true, false);
            //habilitarBotones(false, true);
            
        }
        protected override void OnCancelar()
        {
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPreliminar);
            Cargar();
        }
        protected override void OnEliminar()            
        {
            try {
                Estado = FormEstate.List;
                if (gridControl.SelectedRows.Count == 0)
                    return;
                GridViewRowInfo row = this.gridControl.CurrentRow;
                string Codigo = Util.GetCurrentCellText(row, "ccb02cod");
                string Descripcion = Util.GetCurrentCellText(row, "ccb02des");
                string Mensaje = "";

                DialogResult result = RadMessageBox.Show("Está seguro de eliminar", 
                    Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR,
                    MessageBoxButtons.YesNo,
                    RadMessageIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                  
                    CentroCostoLogic.Instance.EliminarCentroCosto(Logueo.CodigoEmpresa, Codigo, out Mensaje);
                    Util.ShowMessage(Mensaje,1);
                }                                     
            }
            catch (Exception ex) {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                //RadMessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            OnCancelar();

        }
        private bool Validar() {
            try {
                if (this.gridControl.CurrentRow.Cells[0].Value == null ||
                    this.gridControl.CurrentRow.Cells[1].Value == null)
                {
                    RadMessageBox.Show("Completar el registro", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return false;
                }
            }
            catch (Exception ex) { 
            
            }            
            return true;
        }
        protected override void OnGuardar() 
        {
            if (this.gridControl.RowCount == 0) { return; }
            GridViewRowInfo row = this.gridControl.CurrentRow;
            string Codigo = Util.GetCurrentCellText(row, "ccb02cod");
            string Descripcion = Util.GetCurrentCellText(row, "ccb02des");
            string Mensaje = "";
            try 
            {
              if(Estado == FormEstate.New)
              {
                  CentroCostoLogic.Instance.InsertarCentroCosto(Logueo.CodigoEmpresa, Codigo,Logueo.Anio, Descripcion, out Mensaje);
                  Util.ShowMessage(Mensaje, 1);
              }
             else if(Estado == FormEstate.Edit)
             {

                 CentroCostoLogic.Instance.ActualizarCentroCosto(Logueo.CodigoEmpresa, Codigo, Descripcion, out Mensaje);
                 Util.ShowMessage(Mensaje, 1);
             }
            }
            catch (Exception ex) {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            OnCancelar(); // cancelo y actualizo la grilla , asgino al bandera de Form - estado  a List
            
        }

        private void gridControl_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try {
                //if (Estado == FormEstate.Edit || Estado == FormEstate.New ) {
                //    gridControl.Rows[indiceEditable].IsSelected = true;
                //    gridControl.Rows[indiceEditable].IsCurrent = true;
                //}
                
            }
            catch (Exception ex) {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            
        }

        private void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (Estado == FormEstate.List || Estado == FormEstate.View)
            {
                e.Cancel = true;
            }
            else
            {
                //e.Cancel = e.Row.Cells["flag"].Value == null ? true : false;
                e.Cancel = false;
            }
            
        }

        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            //if (Estado == FormEstate.New || Estado == FormEstate.Edit)
            //{
            //    e.Cancel = true;                

            //    RadMessageBox.Show("Debe completar o cancelar la operacion en el fila actual", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);

            //}
        }

        private void FrmCentrosCosto_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPreliminar);
            //Estado = FormEstate.View;
            crearGrilla();
            Cargar();
        }
        
    }
}
