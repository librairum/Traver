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

namespace Fac.UI.Win
{
    public partial class frmCamposOpcionales : frmBaseMante
    {
        #region "Instancia"
        private static frmCamposOpcionales _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmCamposOpcionales Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmCamposOpcionales(formParent);
            _aForm = new frmCamposOpcionales(formParent);
            return _aForm;
        }
        #endregion
        public frmCamposOpcionales(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            CrearColumnas();
            Cargar();
            Util.ConfigGridToEnterNavigation(this.gridControl);
            gestionarBotones(true, false, false, false, false);
            gridControl.CellBeginEdit += new GridViewCellCancelEventHandler(gridControl_CellBeginEdit);
            gridControl.KeyDown += new KeyEventHandler(gridControl_KeyDown);
            gridControl.CommandCellClick += new CommandCellClickEventHandler(gridControl_CommandCellClick);
            gridControl.CellFormatting += new CellFormattingEventHandler(gridControl_CellFormatting);
            gridControl.SelectionChanging += new GridViewSelectionCancelEventHandler(gridControl_SelectionChanging);
        }

        void gridControl_SelectionChanging(object sender, GridViewSelectionCancelEventArgs e)
        {
           //gridControl.CurrentRow
            
            string str_flag = Util.GetCurrentCellText(gridControl.CurrentRow, "flag");
            if (str_flag  != "")
            {
                e.Cancel = true;
            }
            
        }

        void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Util.FormateoBotones(gridControl, Estado, e);
        }

        void gridControl_CommandCellClick(object sender, EventArgs e)
        {
            if (this.gridControl.Columns["btnGrabarDet"].IsCurrent)
            {
                GuardarDetalle();
            }

            if (this.gridControl.Columns["btnEditarDet"].IsCurrent)
            {
                EditarDetalle();
            }

            if (this.gridControl.Columns["btnEliminarDet"].IsCurrent)
            {
                EliminarDetalle();
            }

            if (this.gridControl.Columns["btnCancelarDet"].IsCurrent)
            {
                CancelarDetalle();
            }
        }

        void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda();
            }
        }

        void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (Util.GetCurrentCellText(e.Row, "flag") == "")
                e.Cancel = true;
        }
        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(gridControl);
            CreateGridColumn(Grid, "Tabla", "FAC71TablaDesc", 0, "", 200, false, true);
            CreateGridColumn(Grid, "Campo", "FAC71CampoFEDesc", 0, "", 250, false, true);
            CreateGridColumn(Grid, "flag", "flag", 0, "", 120, true, false, false);
            Util.AddButtonsToGrid(Grid);
        }
        protected override void OnNuevo()
        {
            //gestionarBotones(false, false, false, true, true);
            
            AgregarFila();

        }
        private void AgregarFila()
        {
            try
            {
                if (gridControl.Rows.Count > 0)
                {
                    if (Util.GetCurrentCellText(gridControl.CurrentRow, "flag") == "0")
                    {
                        Util.ShowAlert("Debe completar el registro actual"); return;
                    }
                   
                }
                gridControl.Rows.AddNew();

                GridViewRowInfo row = this.gridControl.CurrentRow;

                Util.SetValueCurrentCellText(row, "flag", "0");
              
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al agregar fila: " + ex.Message);
            }
        }
        bool Validar()
        {
            GridViewRowInfo row = gridControl.CurrentRow;
            string Tabla = Util.GetCurrentCellText(row, "FAC71TablaDesc");
            string Campo = Util.GetCurrentCellText(row, "FAC71CampoFEDesc");
            if (Tabla == "")
            {
                Util.ShowAlert("Ingresar Descripcion");
                Util.SetCellGridFocus(row, "FAC71TablaDesc");
                return false;
            }
            if (Campo == "")
            {
                Util.ShowAlert("Ingresar descripcion del campo de factura electronica");
                Util.SetCellGridFocus(row, "FAC71CampoFEDesc");
                return false;
            }
            return true;
        }
        private void GuardarDetalle()
        {
            try
            {
                if (Validar() == false) return;
                string str_mensaje = "";
                int int_flag = 0;
                GridViewRowInfo row = gridControl.CurrentRow;
                string Tabla = Util.GetCurrentCellText(row, "FAC71TablaDesc");
                string Campo = Util.GetCurrentCellText(row, "FAC71CampoFEDesc");
                bool bFlag = Util.GetCurrentCellFlag(row, "flag");


                if (bFlag == true)
                {
                    GlobalLogic.Instance.InsertarCampoOpcional(Tabla, Campo, out int_flag, out str_mensaje);
                    Util.ShowMessage(str_mensaje, int_flag);

                    if (int_flag == 1)
                        CancelarDetalle();
                }
                else
                {
                    Util.ShowAlert("Opciono no valida");
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar detalle: " +ex.Message);
            }
        }

        private void EditarDetalle()
        { 
             Estado = FormEstate.Edit;
            GridViewRowInfo row = gridControl.CurrentRow;

            Util.SetValueCurrentCellText(row, "flag", "1");            
            Util.SetCellGridFocus(row, "FAC71TablaDesc");
            Util.SetCellInitEdit(gridControl, "FAC71TablaDesc");
            
        }

        private void EliminarDetalle()
        {
            try
            {
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");
                if (respuesta == true)
                {
                    GridViewRowInfo row = this.gridControl.CurrentRow;
                    string Tabla = Util.GetCurrentCellText(row, "FAC71TablaDesc");
                    string Campo = Util.GetCurrentCellText(row, "FAC71CampoFEDesc");

                    int int_flag = 0; string str_mensaje = "";

                    GlobalLogic.Instance.EliminarCampoOpcional(Tabla, Campo, out int_flag, out str_mensaje);
                    if (int_flag == 1)
                        OnCancelar();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar detalle : " +ex.Message);
            }
        }

        private void CancelarDetalle()
        {
            gestionarBotones(true, false, false, false, false);
            Cargar();
        }
        
        
       

        private void Cargar()
        {            
            gridControl.DataSource = GlobalLogic.Instance.TraeCamposOpcionales();
        }
        private void TraerAyuda()
        {
            try
            {
                frmBusqueda frm = new frmBusqueda(enmAyuda.enmTablaFE, "");
                string[] datos = new string[2];
                frm.ShowDialog();

                if (frm.Result != null)
                    if (frm.Result.ToString() != "")
                    {
                        datos = frm.Result.ToString().Split('|');
                        Util.SetValueCurrentCellText(gridControl, "FAC71TablaDesc", datos[1]);
                    }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer ayuda:" + ex.Message);
            }
        }
        


    }
}
