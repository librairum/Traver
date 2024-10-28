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
    public partial class frmFormaPago : frmBase
    {
        #region "Instancia"
        private static frmFormaPago _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmFormaPago Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmFormaPago(formParent);
            _aForm = new frmFormaPago(formParent);
            return _aForm;
        }
        #endregion
        void frmPuertos_Load(object sender, EventArgs e)
        {
            
            CrearColumnas();
            Cargar();
        }
        private void Cargar()
        {
            try
            {
                List<FormaPago> lista = FormaPagoLogic.Instance.TraeFormaPagos("", "*");
                gridControl.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar: " + ex.Message);
            }
        }
        
        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(this.gridControl);
            
            CreateGridColumn(Grid, "Codigo", "FAC53COD", 0,"", 90, false, true);
            CreateGridColumn(Grid, "Descripcion", "FAC53DESC", 0, "", 300, false, true);
            CreateGridColumn(Grid, "Desc.EEUU","FAC53DESCEEUU", 0, "", 300, false, true);
            CreateGridColumn(Grid, "Dias", "FAC53DIAS", 0, "", 90, false, true);

            CreateGridColumn(Grid, "flag", "flag", 0, "", 90, true, false, false);
            CreateGridColumn(Grid, "flagBotones", "flagBotones", 0, "", 90, true, false, false);

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

                GridViewRowInfo row = gridControl.CurrentRow;
                Util.SetValueCurrentCellText(gridControl, "flag", "0");
                Util.SetValueCurrentCellText(gridControl, "flagBotones", "E");

                Util.SetCellGridFocus(gridControl, "FAC53COD");
                Util.SetCellInitEdit(gridControl, "FAC53COD");

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al agregar fila: " + ex.Message);
            }
        }



        public frmFormaPago(frmMDI padre)
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
        private bool Validar()
        {
            string FormaPagoCodigo = "", FormaPagoDesc = "", FormaPagoDesEU = "";
            int FormaPagoDias = 0;
            FormaPagoCodigo = Util.GetCurrentCellText(gridControl, "FAC53COD");
            FormaPagoDesc = Util.GetCurrentCellText(gridControl, "FAC53DESC");
            FormaPagoDesEU = Util.GetCurrentCellText(gridControl, "FAC53DESCEEUU");
            FormaPagoDias = Util.GetCurrentCellInt(gridControl, "FAC53DIAS");

            if (FormaPagoCodigo == "")
            {
                Util.ShowAlert("Ingresar codigo de pago");
                Util.SetCellGridFocus(gridControl, "FAC53COD");
                return false;
            }
            if (FormaPagoDesc == "")
            {
                Util.ShowAlert("Ingresar descriocipn de pago");
                Util.SetCellGridFocus(gridControl, "FAC53DESC");
                return false;
            }
            if (FormaPagoDesEU == "")
            {
                Util.ShowAlert("Ingresar descriocipn de pago EU");
                Util.SetCellGridFocus(gridControl, "FAC53DESCEEUU");
                return false;
            }
            if (FormaPagoDias == 0)
            {
                Util.ShowAlert("Ingresar pago de dias");
                Util.SetCellGridFocus(gridControl, "FAC53DIAS");
                return false;
            }
            return true;
        }
        private void GuardarDetalle()
        {
            try
            {
                string FormaPagoCodigo = "", FormaPagoDesc = "", FormaPagoDesEU = "";
                int FormaPagoDias = 0;
                int int_flag = 0; string str_mensaje = "", str_flag = "";
                FormaPagoCodigo = Util.GetCurrentCellText(gridControl, "FAC53COD");
                FormaPagoDesc = Util.GetCurrentCellText(gridControl, "FAC53DESC");
                FormaPagoDesEU = Util.GetCurrentCellText(gridControl, "FAC53DESCEEUU");
                FormaPagoDias = Util.GetCurrentCellInt(gridControl, "FAC53DIAS");
                str_flag = Util.GetCurrentCellText(gridControl, "flag");
                if (Validar() == false) return;
                if (str_flag == "0")
                {
                    FormaPagoLogic.Instance.InsertarFormaPago(FormaPagoCodigo, FormaPagoDesc,
                    FormaPagoDesEU, FormaPagoDias, out int_flag, out str_mensaje);

                }
                else if (str_flag == "1")
                {
                    FormaPagoLogic.Instance.ActualizarFormaPago(FormaPagoCodigo,
                                    FormaPagoDesc, FormaPagoDesEU, FormaPagoDias,
                                    out int_flag, out str_mensaje);
                }
                Util.ShowMessage(str_mensaje, int_flag);
                if (int_flag == 1)
                    Cargar();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar detalle: " +ex.Message);
            }
        }

        private void EditarDetalle()
        {
            Util.SetValueCurrentCellText(gridControl, "flag", "1");
            Util.SetValueCurrentCellText(gridControl, "flagBotones", "E");
            Util.SetCellGridFocus(gridControl, "FAC53COD");
            Util.SetCellInitEdit(gridControl, "FAC53COD");
        }

        private void EliminarDetalle()
        {
            try
            {
                string FormaPagoCodigo = "";
                int int_flag = 0; string str_mensaje = "";
                bool respuesta = Util.ShowQuestion("¿Desea eliminar registro?");
                // si la repsuesta es no , salir de flujo
                if (respuesta == false) return;

                FormaPagoCodigo = Util.GetCurrentCellText(gridControl, "FAC53COD");
                FormaPagoLogic.Instance.EliminarFormaPago(FormaPagoCodigo, out int_flag, out str_mensaje);

                Util.ShowMessage(str_mensaje, int_flag);

                if (int_flag == 1)                
                    Cargar();               
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar detalle: " + ex.Message);
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
        public override void OnCancelar()
        {
            this.Close();
        }
    }
}
