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
    public partial class frmPuertos : frmBase
    {
        #region "Instancia"
        private static frmPuertos _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmPuertos Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmPuertos(formParent);
            _aForm = new frmPuertos(formParent);
            return _aForm;
        }
        #endregion
        public frmPuertos(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Util.ConfigGridToEnterNavigation(this.gridControl);
            Util.seleccionatFilaCompleta(gridControl);

            habilitarBotones(true, false, false, false, false, false, false, false, false);
            //Personalizar la grilla            
            
            gridControl.CellBeginEdit += new GridViewCellCancelEventHandler(gridControl_CellBeginEdit);
            gridControl.CellFormatting += new CellFormattingEventHandler(gridControl_CellFormatting);
            gridControl.CommandCellClick += new CommandCellClickEventHandler(gridControl_CommandCellClick);
            
            
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

        void frmPuertos_Load(object sender, EventArgs e)
        {                        
            CrearColumnas();
            Cargar();
        }
        private void Cargar()
        {
            gridControl.DataSource = PuertoLogic.Instance.Spu_Fact_Trae_FAC52PUERTOS("", "*");
        }
        private bool Validar()
        {
            string PuertoCodigo = "", PuertoNombre = "";
            PuertoCodigo = Util.GetCurrentCellText(gridControl, "FAC52CODPUERTO");
            PuertoNombre = Util.GetCurrentCellText(gridControl, "FAC52DESCRIPCION");
            if (PuertoCodigo == "")
            {
                Util.ShowAlert("Ingresar Codigo de puerto");
                Util.SetCellGridFocus(gridControl, "FAC52CODPUERTO");
                return false;
            }

            if (PuertoNombre == "")
            {
                Util.ShowAlert("Ingresar nombre de puerto");
                Util.SetCellGridFocus(gridControl, "FAC52DESCRIPCION");
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
                string PuertoCodigo = "", PuertoNombre = "";
                PuertoCodigo = Util.GetCurrentCellText(gridControl, "FAC52CODPUERTO");
                PuertoNombre = Util.GetCurrentCellText(gridControl, "FAC52DESCRIPCION");

                if (Validar() == false) return;

                str_flag = Util.GetCurrentCellText(gridControl, "flag");
                if (str_flag == "0")
                {
                    PuertoLogic.Instance.Spu_Fact_Ins_FAC52PUERTOS(PuertoCodigo, PuertoNombre, out int_flag, out str_mensaje);
                }
                else if (str_flag == "1")
                {
                    PuertoLogic.Instance.Spu_Fact_Upd_FAC52PUERTOS(PuertoCodigo, PuertoNombre, out int_flag, out str_mensaje);
                }

                Util.ShowMessage(str_mensaje, int_flag);
                if (int_flag == 1)
                    Cargar();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        private void EditarDetalle()
        {
            Util.SetValueCurrentCellText(gridControl, "flag", "1");
            Util.SetValueCurrentCellText(gridControl, "flagBotones", "E");
            Util.SetCellGridFocus(gridControl, "FAC52DESCRIPCION");
            Util.SetCellInitEdit(gridControl, "FAC52DESCRIPCION");
        }

        private void EliminarDetalle()
        {
            try
            {
                string PuertoCodigo = "";
                int int_flag = 0; string str_mensaje = "";
                PuertoCodigo = Util.GetCurrentCellText(gridControl, "FAC52CODPUERTO");
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");
                if (respuesta == true)
                {
                    PuertoLogic.Instance.Spu_Fact_Del_FAC52PUERTOS(PuertoCodigo, out int_flag, out str_mensaje);
                }
                Util.ShowMessage(str_mensaje, int_flag);
                if (int_flag == 1)
                {
                    Cargar();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        private void CancelarDetalle()
        {
            Cargar();
        }


        
        protected override void OnNuevo()
        {
            AgregarFila();    
        }

        
        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(this.gridControl);
            CreateGridColumn(gridControl, "Cod.Puerto", "FAC52CODPUERTO", 0, "", 90);
            CreateGridColumn(gridControl, "Des.Puerto", "FAC52DESCRIPCION", 0, "", 200, false, true);
            CreateGridColumn(gridControl, "flag", "flag", 0, "", 70, true, false, false);
            CreateGridColumn(gridControl, "flagBotones", "flagBotones", 0, "", 70, true, false, false);
            Util.AddButtonsToGrid(Grid);
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
                string NuevoCodigo = "";
                PuertoLogic.Instance.Spu_Fact_Trae_CodigoFAC52PUERTOS(out NuevoCodigo);
                Util.SetValueCurrentCellText(gridControl, "FAC52CODPUERTO", NuevoCodigo);
                Util.SetCellGridFocus(gridControl, "FAC52CODPUERTO");
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
    }
}
