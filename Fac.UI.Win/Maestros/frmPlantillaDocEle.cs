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
    public partial class frmPlantillaDocEle : frmBaseMante
    {
        #region "Instancia"
        private static frmPlantillaDocEle _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmPlantillaDocEle Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmPlantillaDocEle(formParent);
            _aForm = new frmPlantillaDocEle(formParent);
            return _aForm;
        }
        #endregion
        
        PlantillaLogic datos = PlantillaLogic.Instance;

        public frmPlantillaDocEle(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            gestionarBotones(true, false, false, false, false);
            CrearColumnas();
            Cargar();
            Util.ConfigGridToEnterNavigation(gridControl);
            gridControl.CellBeginEdit += new GridViewCellCancelEventHandler(gridControl_CellBeginEdit);
            gridControl.CellFormatting += new CellFormattingEventHandler(gridControl_CellFormatting);
            gridControl.CommandCellClick += new CommandCellClickEventHandler(gridControl_CommandCellClick);
            gridControl.KeyDown += new KeyEventHandler(gridControl_KeyDown);
        }

        void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            frmBusqueda frm;
            string[] datos;
            if(e.KeyValue == (char)Keys.F1)
                if(Util.IsCurrentColumn(gridControl.CurrentColumn, "Fac70PlantillaFETipDoc") == true)
                {
                    frm = new frmBusqueda(enmAyuda.enmTipDocGlobal, "01");
                    frm.ShowDialog();
                    if(frm.Result == null) return;
                    if(frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');                        
                    Util.SetValueCurrentCellText(gridControl, "Fac70PlantillaFETipDoc", datos[0]); //Codigo
                    Util.SetValueCurrentCellText(gridControl, "PlantillaFETipDocDesc", datos[1]);  //Descripcion                        
                }                    
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

                Util.SetCellGridFocus(row, "Fac70PlantillaFETipDoc");
                Util.SetCellInitEdit(row, "Fac70PlantillaFETipDoc");

                Util.ResaltarAyuda(this.gridControl, "Fac70PlantillaFETipDoc");
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al agregar fila: " + ex.Message);
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

        void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (gridControl.RowCount == 0) return;
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
        void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(gridControl);
            CreateGridColumn(Grid, "TipDoc", "Fac70PlantillaFETipDoc", 0, "", 90);
            CreateGridColumn(Grid, "Desc.TipDoc", "PlantillaFETipDocDesc", 0, "", 120);

            CreateGridColumn(Grid, "Codigo", "Fac70PlantillaFECod", 0, "", 90, false, true);
            CreateGridColumn(Grid, "Descripcion", "Fac70PlantillaFEDesc", 0, "", 250, false, true);

            CreateGridColumn(Grid, "flag", "flag", 0, "", 120, false, true, false);
            CreateGridColumn(Grid, "flagBotones", "flagBotones", 0, "", 120, false, true, false);

            Util.AddButtonsToGrid(Grid);
        }

        void Cargar()
        {
            gridControl.DataSource = PlantillaLogic.Instance.TraePlantillasFE();
        }
        bool Validar()
        { 
    //          If txtCodigo = "" Then Beep: MsgBox "Ingrese Código", vbExclamation: txtCodigo.SetFocus: Exit Sub
    //If txtDescripcion = "" Then Beep: MsgBox "Ingrese Descripción", vbExclamation: txtDescripcion.SetFocus: Exit Sub
    //If txtTipoDocuCodigo = "" Then Beep: MsgBox "Ingrese Tipo de Documento", vbExclamation: txtTipoDocuCodigo.SetFocus: Exit Sub
    //If LblTipDocDescripcion.Caption = "" Then Beep: MsgBox "Ingrese Tipo de Documento", vbExclamation: txtTipoDocuCodigo.SetFocus: Exit Sub
            GridViewRowInfo row = gridControl.CurrentRow;


            string PlantillaTipDoc = Util.GetCurrentCellText(row, "Fac70PlantillaFETipDoc");
            string PlantillaCod = Util.GetCurrentCellText(row, "Fac70PlantillaFECod");
            string PlantillaDesc = Util.GetCurrentCellText(row, "Fac70PlantillaFEDesc");
            if (PlantillaTipDoc == "")
            {
                Util.ShowAlert("Ingresar Tipo documento");
                Util.SetCellGridFocus(row, "Fac70PlantillaFETipDoc");
                return false;
            }
            if (PlantillaCod == "")
            {
                Util.ShowAlert("Ingresar codigo de plantilla");
                Util.SetCellGridFocus(row, "Fac70PlantillaFECod");
                return false;
            }
            if (PlantillaDesc == "")
            {
                Util.ShowAlert("Ingresar descripcion");
                Util.SetCellGridFocus(row, "Fac70PlantillaFEDesc");
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


                string PlantillaTipDoc = Util.GetCurrentCellText(row, "Fac70PlantillaFETipDoc");
                string PlantillaCod = Util.GetCurrentCellText(row, "Fac70PlantillaFECod");
                string PlantillaDesc = Util.GetCurrentCellText(row, "Fac70PlantillaFEDesc");

                bool EsNuevo = Util.GetCurrentCellFlag(row, "flag");

                if (EsNuevo == true)
                {
                    datos.InsertarPlantillaFE(PlantillaTipDoc, PlantillaCod, PlantillaDesc, out int_flag, out str_mensaje);
                }
                else
                {
                    datos.ActualizarPlantillaFE(PlantillaTipDoc, PlantillaCod, PlantillaDesc, out int_flag, out str_mensaje);
                }

                Util.ShowMessage(str_mensaje, int_flag);
                if (int_flag == 1)
                    Cargar();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error en guardar detalle:  " +ex.Message);
            }
        }
        private void EditarDetalle()
        {
            Estado = FormEstate.Edit;
            GridViewRowInfo row = gridControl.CurrentRow;
            Util.SetValueCurrentCellText(row, "flag", "1");
            Util.SetValueCurrentCellText(row, "flagBotones", "E");
            Util.SetCellGridFocus(row, "Fac70PlantillaFETipDoc");
            Util.SetCellInitEdit(gridControl, "Fac70PlantillaFETipDoc");
        }
        private void EliminarDetalle()
        {
            try
            {
                int int_flag = 0; string str_mensaje = "";
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");
                if (respuesta == true)
                {
                    GridViewRowInfo row = gridControl.CurrentRow;
                    string PlantillaTipDoc = Util.GetCurrentCellText(row, "Fac70PlantillaFETipDoc");
                    string PlantillaCod = Util.GetCurrentCellText(row, "Fac70PlantillaFECod");
                    string PlantillaDesc = Util.GetCurrentCellText(row, "Fac70PlantillaFEDesc");
                    datos.EliminarPlantillaFE(PlantillaTipDoc, PlantillaCod, out int_flag, out str_mensaje);
                    
                    Util.ShowMessage(str_mensaje, int_flag);

                    if (int_flag == 1)                    
                        CancelarDetalle();                    
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar detalle : " +ex.Message);
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


    }
}
