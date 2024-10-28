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
    public partial class frmPaises : frmBase
    {
        #region "Instancia"
        private static frmPaises _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmPaises Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmPaises(formParent);
            _aForm = new frmPaises(formParent);
            return _aForm;
        }
        #endregion

        public frmPaises(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Util.ConfigGridToEnterNavigation(this.gridControl);            
            habilitarBotones(true, false, false, false, false, false, false, false, false);
            gridControl.CellBeginEdit += new GridViewCellCancelEventHandler(gridControl_CellBeginEdit);
            gridControl.CellFormatting += new CellFormattingEventHandler(gridControl_CellFormatting);
            gridControl.CommandCellClick += new CommandCellClickEventHandler(gridControl_CommandCellClick);            
            
            //this.Load += new EventHandler(frmPaises_Load);
            Util.seleccionatFilaCompleta(gridControl);
        }
        
        void frmPaises_Load(object sender, EventArgs e)
        {            
            CrearColumnas();
            Cargar();
        }
        
        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(gridControl);

            CreateGridColumn(Grid, "Cod.Pais", "FAC51CODPAIS", 0, "", 90, false, true);
            CreateGridColumn(Grid, "Des.Pais", "FAC51DESCRIPCION", 0, "", 90, false, true);
            CreateGridColumn(Grid, "flag", "flag", 0, "", 70, true, false, false);
            CreateGridColumn(Grid, "flagBotones", "flagBotones", 0, "", 70, true, false, false);
            Util.AddButtonsToGrid(Grid);

        }
        
        private void Cargar()
        {
            try
            {
                gridControl.DataSource = PaisesLogic.Instance.TraePaises("", "*");
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar: " + ex.Message);
            }
        }
        private bool Validar()
        {
            string PaisCodigo = Util.GetCurrentCellText(gridControl, "FAC51CODPAIS");
            string PaisNombre = Util.GetCurrentCellText(gridControl, "FAC51DESCRIPCION");
            if (PaisCodigo == "")
            {
                Util.ShowAlert("Ingresar codigo de pais");
                Util.SetCellGridFocus(gridControl, "FAC51CODPAIS");
                return false;
            }
            if (PaisNombre == "")
            {
                Util.ShowAlert("Ingresar nombre de pais");
                Util.SetCellGridFocus(gridControl, "FAC51DESCRIPCION");
                return false;
            }
            return true;
        }
        private void GuardarDetalle()
        {
            try
            {
                string str_mensaje = "", str_flag = "";
                int int_flag = 0;
                string PaisCodigo = Util.GetCurrentCellText(gridControl, "FAC51CODPAIS");
                string PaisNombre = Util.GetCurrentCellText(gridControl, "FAC51DESCRIPCION");

                if (Validar() == false) return;

                str_flag = Util.GetCurrentCellText(gridControl, "flag");
                if (str_flag == "0")
                {
                    PaisesLogic.Instance.InsertarPais(PaisCodigo, PaisNombre, out int_flag, out str_mensaje);
                }
                else {
                    PaisesLogic.Instance.ActualizarPais(PaisCodigo, PaisNombre, out int_flag, out str_mensaje);
                }
                Util.ShowMessage(str_mensaje, int_flag);
                if (int_flag == 1)
                    Cargar();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al gurdar detalle: " + ex.Message);
            }
        }

        private void EditarDetalle()
        {
            try
            {
                Util.SetValueCurrentCellText(gridControl, "flag", "1");
                Util.SetValueCurrentCellText(gridControl, "flagBotones", "E");
                Util.SetCellGridFocus(gridControl, "FAC51CODPAIS");
                Util.SetCellInitEdit(gridControl, "FAC51CODPAIS");
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        private void EliminarDetalle()
        {
            try
            {
                string PaisCodigo = "";
                int int_flag = 0; string str_mensaje = "";
                PaisCodigo = Util.GetCurrentCellText(gridControl, "FAC51CODPAIS");
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");

                if (respuesta == true)
                {
                    PaisesLogic.Instance.EliminarPais(PaisCodigo, out int_flag, out str_mensaje);
 
                }
                Util.ShowMessage(str_mensaje, int_flag);
                if (int_flag == 1)                
                    Cargar();                
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar detalle : " + ex.Message);
            }
        }

        private void CancelarDetalle()
        {
            try
            {
                Cargar();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        void gridControl_CommandCellClick(object sender, EventArgs e)
        {
            if (this.gridControl.Columns["btnGrabarDet"].IsCurrent)
            {
                GuardarDetalle();
            }

            if (this.gridControl.Columns["btnEditarDet"].IsCurrent)
            {
                //editarDetProducto();
                EditarDetalle();
            }

            if (this.gridControl.Columns["btnEliminarDet"].IsCurrent)
            {
                //EliminarDetProducto();
                EliminarDetalle();

            }

            if (this.gridControl.Columns["btnCancelarDet"].IsCurrent)
            {
                //cancelarDetProducto();
                CancelarDetalle();
            }
        }
        
        void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (gridControl.Rows.Count == 0) return;

            try
            {
                if (e.Row != null)
                    if (Util.GetCurrentCellText(e.Row, "flag") == "")
                        e.Cancel = true;

            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        
        void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Util.FormateoBotones(gridControl, Estado, e);
        }
        
       
        
        private void AgregarFila()
        {
            try
            {
                if (gridControl.Rows.Count > 0)
                {
                    if (gridControl.CurrentRow.Cells["flag"].Value != null)
                    {
                        Util.ShowAlert("Debe completar el registro actual");
                        return;
                    }
                }
                gridControl.Rows.AddNew();

                GridViewRowInfo row = this.gridControl.CurrentRow;


                Util.SetValueCurrentCellText(gridControl, "flag", "0");
                Util.SetValueCurrentCellText(gridControl, "flagBotones", "E");
                Util.SetCellGridFocus(gridControl, "FAC51CODPAIS");
                Util.SetCellInitEdit(gridControl, "FAC51CODPAIS");
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al agregar fila: " + ex.Message);
            }
        }

        protected override void OnNuevo()
        {
            AgregarFila();
        }

        
    }
}
