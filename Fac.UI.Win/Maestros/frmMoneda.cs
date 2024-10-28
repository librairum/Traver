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
    public partial class frmMoneda : frmBase
    {
        #region "Instancia"
        private static frmMoneda _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmMoneda Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmMoneda(formParent);
            _aForm = new frmMoneda(formParent);
            return _aForm;
        }
        #endregion
        MonedaLogic datos = MonedaLogic.Instance;
        public frmMoneda(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Util.ConfigGridToEnterNavigation(this.gridControl);
            
            habilitarBotones(true, false, false, false, false, false, false, false, false);
            gridControl.CellBeginEdit += new GridViewCellCancelEventHandler(gridControl_CellBeginEdit);
            gridControl.CellFormatting += new CellFormattingEventHandler(gridControl_CellFormatting);
            gridControl.CommandCellClick += new CommandCellClickEventHandler(gridControl_CommandCellClick);
            gridControl.KeyDown += new KeyEventHandler(gridControl_KeyDown);
            
            
            Util.seleccionatFilaCompleta(gridControl);
        }
        void traerAyuda(enmAyuda tipo)
        {
            frmBusqueda frm;
            string[] datos;
            frm = new frmBusqueda(tipo);
            frm.ShowDialog();
            if(frm.Result != null)
                if (frm.Result.ToString() != "")
                {
                    datos = frm.Result.ToString().Split('|');
                    Util.SetValueCurrentCellText(gridControl, "FAC54FEMONEDACOD", datos[0]);
                    Util.SetValueCurrentCellText(gridControl, "glo04descripcion", datos[1]);
                }   
        }
        void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (Util.GetCurrentCellText(gridControl, "flag") == "") return;

            if (e.KeyValue == (char)Keys.F1)
                if (Util.IsCurrentColumn(gridControl, "FAC54FEMONEDACOD"))
                    traerAyuda(enmAyuda.enmMonedaFE);
                
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
                        // Si es modo editar
                    else if (Util.GetCurrentCellText(e.Row, "flag") == "1")
                        // Bloquear si la columna es codigo
                        if (Util.IsCurrentColumn(e.Column, "FAC54CODIGO"))
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
                Util.ResaltarAyuda(gridControl, "FAC54FEMONEDACOD");
                Util.SetCellGridFocus(gridControl, "FAC54CODIGO");
                Util.SetCellInitEdit(gridControl, "FAC54CODIGO");
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al agregar fila: " + ex.Message);
            }
        }
        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(gridControl);
            
            CreateGridColumn(Grid, "Codigo", "FAC54CODIGO", 0, "", 100, false, true);//	char	1
            CreateGridColumn(Grid, "Descripcion", "FAC54DESCRIPCION", 0, "", 250, false, true);	//varchar	50
            CreateGridColumn(Grid, "FAC54ABREV", "FAC54ABREV", 0, "", 70, false, true, false); //	varchar	20
            CreateGridColumn(Grid, "Signo", "FAC54SIGNO", 0, "", 100, false, true); //FAC54SIGNO	varchar	10
            CreateGridColumn(Grid, "Moneda FE", "FAC54FEMONEDACOD", 0, "", 170);  //FAC54FEMONEDACOD	char	3
            CreateGridColumn(Grid, "Desc. FE", "glo04descripcion", 0, "", 250);
            CreateGridColumn(Grid, "flag", "flag", 0, "", 70, true, false, false);
            CreateGridColumn(Grid, "flagBotones", "flagBotones", 0, "", 70, true, false, false);
            Util.AddButtonsToGrid(Grid);
        }
        private bool Validar()
        {
            Moneda entidadMoneda = new Moneda();

            entidadMoneda.FAC54CODIGO = Util.GetCurrentCellText(gridControl, "FAC54CODIGO");
            entidadMoneda.FAC54DESCRIPCION = Util.GetCurrentCellText(gridControl, "FAC54DESCRIPCION");
            entidadMoneda.FAC54ABREV = Util.GetCurrentCellText(gridControl, "FAC54CODIGO");
            entidadMoneda.FAC54SIGNO = Util.GetCurrentCellText(gridControl, "FAC54SIGNO");
            entidadMoneda.FAC54FEMONEDACOD = Util.GetCurrentCellText(gridControl, "FAC54FEMONEDACOD");
            if (entidadMoneda.FAC54CODIGO == "")
            {
                Util.ShowAlert("Ingresar codigo");
                Util.SetCellInitEdit(gridControl, "FAC54CODIGO");
                return false;
            }
            if (entidadMoneda.FAC54DESCRIPCION == "")
            {
                Util.ShowAlert("Ingresar descripcion");
                Util.SetCellInitEdit(gridControl, "FAC54DESCRIPCION");
                return false;
            }

            if (entidadMoneda.FAC54SIGNO == "")
            {
                Util.ShowAlert("Ingresar signo");
                Util.SetCellInitEdit(gridControl, "FAC54SIGNO");
                return false;
            }
            if (entidadMoneda.FAC54FEMONEDACOD == "")
            {
                Util.ShowAlert("Ingresar codigo de moneda para facturacion electronica");
                Util.SetCellInitEdit(gridControl, "FAC54FEMONEDACOD");
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

                Moneda entidadMoneda = new Moneda();             

                entidadMoneda.FAC54CODIGO = Util.GetCurrentCellText(gridControl, "FAC54CODIGO");
                entidadMoneda.FAC54DESCRIPCION = Util.GetCurrentCellText(gridControl, "FAC54DESCRIPCION");
                entidadMoneda.FAC54ABREV = Util.GetCurrentCellText(gridControl, "FAC54CODIGO");
                entidadMoneda.FAC54SIGNO = Util.GetCurrentCellText(gridControl, "FAC54SIGNO");
                entidadMoneda.FAC54FEMONEDACOD = Util.GetCurrentCellText(gridControl, "FAC54FEMONEDACOD");
                if (Validar() == false) return;
                str_flag = Util.GetCurrentCellText(gridControl, "flag");

                if (str_flag == "0")
                {
                    datos.InsertarMoneda(entidadMoneda, out int_flag, out str_mensaje);
                    //PaisesLogic.Instance.InsertarPais(PaisCodigo, PaisNombre, out int_flag, out str_mensaje);
                }
                else
                {
                    datos.ActualizarMoneda(entidadMoneda, out int_flag, out str_mensaje);
                    //isesLogic.Instance.ActualizarPais(PaisCodigo, PaisNombre, out int_flag, out str_mensaje);
                }
                Util.ShowMessage(str_mensaje, int_flag);
                if (int_flag == 1)
                    Cargar();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar detalle: " + ex.Message);
            }
        }

        private void EditarDetalle()
        {
            try
            {
                Util.SetValueCurrentCellText(gridControl, "flag", "1");
                Util.SetValueCurrentCellText(gridControl, "flagBotones", "E");
                Util.ResaltarAyuda(gridControl, "FAC54FEMONEDACOD");
                Util.SetCellGridFocus(gridControl, "FAC54CODIGO");
                Util.SetCellInitEdit(gridControl, "FAC54CODIGO");
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
                string MonedaCodigo = "";
                int int_flag = 0; string str_mensaje = "";
                MonedaCodigo = Util.GetCurrentCellText(gridControl, "FAC54CODIGO");
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");

                if (respuesta == true)
                {
                    MonedaLogic.Instance.EliminarMoneda(MonedaCodigo, out int_flag, out str_mensaje);                    

                }
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
            try
            {
                Cargar();
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
                gridControl.DataSource = datos.ListarMonedas("", "*");
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar: " + ex.Message);
            }

            
        }
        protected override void OnNuevo()
        {
            AgregarFila();
        }
        private void frmMoneda_Load(object sender, EventArgs e)
        {            
            CrearColumnas();
            Cargar();
        }

       
    }
}
