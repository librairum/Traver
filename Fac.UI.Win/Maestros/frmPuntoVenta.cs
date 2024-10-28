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
    public partial class frmPuntoVenta : frmBaseMante
    {
        #region "Instancia"
        private static frmPuntoVenta _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmPuntoVenta Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmPuntoVenta(formParent);
            _aForm = new frmPuntoVenta(formParent);
            return _aForm;
        }
        #endregion
        PuntoVentaLogic datos = PuntoVentaLogic.Instance;
        public frmPuntoVenta(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            
            CrearColumnas();
            Cargar();
            
            Util.ConfigGridToEnterNavigation(gridControl);

            gestionarBotones(true, false, false, false, false);

            gridControl.CellBeginEdit += new GridViewCellCancelEventHandler(gridControl_CellBeginEdit);
            gridControl.CellFormatting += new CellFormattingEventHandler(gridControl_CellFormatting);
            gridControl.CommandCellClick += new CommandCellClickEventHandler(gridControl_CommandCellClick);
            //gridControl.CurrentCellChanged += new CurrentCellChangedEventHandler(gridControl_CurrentCellChanged);
        }

        void gridControl_CurrentCellChanged(object sender, CurrentCellChangedEventArgs e)
        {
            //Util.ShowAlert(sender.ToString());
            RadGridView Grid =  (RadGridView)sender;
            string columnName = Grid.CurrentColumn.Name;
            Util.SetCellInitEdit(Grid, columnName);
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

        void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Util.FormateoBotones(gridControl, Estado, e);
        }
        void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(gridControl);
            CreateGridColumn(Grid, "Empresa", "FAC55CODEMP", 0, "", 90, true, false, false);
            
            CreateGridColumn(Grid, "Codigo","FAC55COD", 0, "", 70, false, true);
            CreateGridColumn(Grid, "Descripcion", "FAC55DESC", 0, "", 150, false, true);
            
            CreateGridColumn(Grid, "flag", "flag", 0, "", 120, false, true, false);
            CreateGridColumn(Grid, "flagBotones", "flagBotones", 0, "", 120, false, true, false);

            Util.AddButtonsToGrid(Grid);

            
        }
        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            AgregarFila();
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

                Util.SetValueCurrentCellText(row, "flag", "0");
                Util.SetValueCurrentCellText(row, "flagBotones", "E");

                Util.SetCellGridFocus(row, "FAC55COD");
                Util.SetCellInitEdit(row, "FAC55COD");
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        private void Cargar()
        {
            try
            {
                gridControl.DataSource = datos.TraePuntosDeVenta(Logueo.CodigoEmpresa, "", "*");
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
            
        }
        bool Validar()
        {
            GridViewRowInfo row = this.gridControl.CurrentRow;
            string PuntoVentaCodigo = Util.GetCurrentCellText(row, "FAC55COD");
            string PuntoVentaDesc = Util.GetCurrentCellText(row, "FAC55DESC");
            if (PuntoVentaCodigo == "")
            {
                Util.ShowAlert("Ingresar codigo");
                return false;
            }
            if (PuntoVentaDesc == "")
            {
                Util.ShowAlert("Ingresar descripcion");
                return false;
            }

            return true;
        }
        private void GuardarDetalle()
        {

            if (Validar() == false) return;
            string str_mensaje = "";
            int int_flag = 0;

            

            GridViewRowInfo row = gridControl.CurrentRow;
            string codigo = "", descripcion = "";
            
            codigo = Util.GetCurrentCellText(row, "FAC55COD");
            descripcion = Util.GetCurrentCellText(row, "FAC55DESC");
            
            bool EsNuevo = Util.GetCurrentCellFlag(row, "flag");
            if (EsNuevo == true)
            {
                datos.InsertarPuntoDeVenta(Logueo.CodigoEmpresa, codigo, descripcion, out int_flag, out str_mensaje);
            }
            else
            {
                datos.ActualizarPuntoDeVenta(Logueo.CodigoEmpresa, codigo, descripcion, out int_flag, out str_mensaje);
            }

            Util.ShowMessage(str_mensaje, int_flag);
            if (int_flag == 1)
            {
               Cargar();                                
            }
            
            
        }
        private void EditarDetalle()
        {
            Estado = FormEstate.Edit;
            GridViewRowInfo row = gridControl.CurrentRow;
            Util.SetValueCurrentCellText(row, "flag", "1");
            Util.SetValueCurrentCellText(row, "flagBotones", "E");
            Util.SetCellGridFocus(row, "FAC55COD");
            Util.SetCellInitEdit(gridControl, "FAC55COD");
        }
        private void EliminarDetalle()
        {
            try
            {
                string PuntoVentaCodigo = "";
                int int_flag = 0; string str_mensaje = "";
                PuntoVentaCodigo = Util.GetCurrentCellText(gridControl, "FAC55COD");
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");
                if (respuesta == true)
                {
                    datos.EliminarPuntoDeVenta(Logueo.CodigoEmpresa, PuntoVentaCodigo, 
                                                out int_flag, out str_mensaje);

                    if (int_flag == 1)
                    {
                        Util.ShowMessage(str_mensaje, int_flag);
                        Cargar();
                    }
                }
                
                //if (int_flag == 1)
                //   
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
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
        void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (gridControl.RowCount == 0) return;
            try
            {
                if (e.Row != null)
                    if (Util.GetCurrentCellText(e.Row, "flag") == "")
                    {
                        e.Cancel = true;
                    }
                    else if(Util.GetCurrentCellText(e.Row, "flag") == "1") {  // modo edicion
                        if (e.Column.Name == "FAC55COD")
                        {
                            e.Cancel = true;
                        }
                    }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }


    }
}
