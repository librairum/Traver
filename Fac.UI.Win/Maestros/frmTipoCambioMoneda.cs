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
    public partial class frmTipoCambioMoneda : frmBase
    {
        #region "Instancia"
        private static frmTipoCambioMoneda _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmTipoCambioMoneda Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmTipoCambioMoneda(formParent);
            _aForm = new frmTipoCambioMoneda(formParent);
            return _aForm;
        }
        #endregion
        
        public frmTipoCambioMoneda(frmMDI padre)
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
                    if(Util.IsCurrentColumn(gridControl, "MonedaOrigenCod")){
                        Util.SetValueCurrentCellText(gridControl, "MonedaOrigenCod", datos[0]);
                    }

                    if(Util.IsCurrentColumn(gridControl, "MonedaDestinoCod")){
                        Util.SetValueCurrentCellText(gridControl, "MonedaDestinoCod", datos[0]);
                    }
                }   
                    
                    //Util.SetValueCurrentCellText(gridControl, "FAC54FEMONEDACOD", datos[0]);
                    //Util.SetValueCurrentCellText(gridControl, "glo04descripcion", datos[1]);
                
        }
        void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (Util.GetCurrentCellText(gridControl, "flag") == "") return;

            if (e.KeyValue == (char)Keys.F1)
                if (Util.IsCurrentColumn(gridControl, "MonedaOrigenCod"))
                {
                    //traerAyuda(enmAyuda.enmMonedaFE);
                    traerAyuda(enmAyuda.enmFactCab_Moneda);
                }
            if (Util.IsCurrentColumn(gridControl, "MonedaDestinoCod"))
                {
                    //traerAyuda(enmAyuda.enmMonedaFE);
                    traerAyuda(enmAyuda.enmFactCab_Moneda);
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
                        // Si es modo editar
                    else if (Util.GetCurrentCellText(e.Row, "flag") == "1")
                        // Bloquear si la columna es codigo
                        if (Util.IsCurrentColumn(e.Column, "Fecha"))
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

                Util.ResaltarAyuda(gridControl, "MonedaOrigenCod");
                Util.ResaltarAyuda(gridControl, "MonedaDestinoCod");

                Util.SetCellGridFocus(gridControl, "Fecha");
                Util.SetCellInitEdit(gridControl, "Fecha");
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al agregar fila: " + ex.Message);
            }
        }
        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(gridControl);

            CreateGridDateColumn(Grid, "fecha", "Fecha", 0, "{0:dd/MM/yyyy}", 100, false, true);
            CreateGridColumn(Grid, "MonedaOrigenCod", "MonedaOrigenCod", 0, "", 100, true, true);
            CreateGridColumn(Grid, "MonedaDestinoCod", "MonedaDestinoCod", 0, "", 100, true, true);
            CreateGridColumn(Grid, "TipoCambio", "TipoCambio", 0, "", 100, false, true);

            CreateGridColumn(Grid, "flag", "flag", 0, "", 70, true, false, false);//nuevo --> 0, Editar-->1
            CreateGridColumn(Grid, "flagBotones", "flagBotones", 0, "", 70, true, false, false);
            
            Util.AddButtonsToGrid(Grid);

        }
        private bool Validar()
        {
            Moneda entidadMoneda = new Moneda();

            TipoCambioMoneda cambioMoneda = new TipoCambioMoneda();
            cambioMoneda.fecha = Convert.ToDateTime(Util.GetCurrentCellValue(this.gridControl, "Fecha"));
            cambioMoneda.origencod = Util.GetCurrentCellText(this.gridControl, "MonedaOrigenCod");
            cambioMoneda.destinocod = Util.GetCurrentCellText(this.gridControl, "MonedaDestinoCod");
            cambioMoneda.tipocambio = Util.GetCurrentCellDbl(this.gridControl, "TipoCambio");
            
            
            if(cambioMoneda.origencod ==""){
                Util.ShowAlert("Ingresar codigo de origen");
                return false;
            }
            if (cambioMoneda.destinocod == "") {
                Util.ShowAlert("ingresar codigo de destino");
                return false;
            }

            if (cambioMoneda.tipocambio == 0) {
                Util.ShowAlert("Ingresar tipo de cambio");
                return false;
            }
            /*
            entidadMoneda.FAC54CODIGO = Util.GetCurrentCellText(gridControl, "FAC54CODIGO");
            entidadMoneda.FAC54DESCRIPCION = Util.GetCurrentCellText(gridControl, "FAC54DESCRIPCION");
            entidadMoneda.FAC54ABREV = Util.GetCurrentCellText(gridControl, "FAC54CODIGO");
            entidadMoneda.FAC54SIGNO = Util.GetCurrentCellText(gridControl, "FAC54SIGNO");
            entidadMoneda.FAC54FEMONEDACOD = Util.GetCurrentCellText(gridControl, "FAC54FEMONEDACOD");
            */
            

            return true;
        }
        private void GuardarDetalle()
        {
            try
            {
                string str_mensaje = "", str_flag = "";
                int int_flag = 0;

                TipoCambioMoneda entidad = new TipoCambioMoneda();
                entidad.fecha = Convert.ToDateTime(Util.GetCurrentCellValue(this.gridControl, "fecha"));
                entidad.origencod = Util.GetCurrentCellText(this.gridControl, "MonedaOrigenCod");
                entidad.destinocod = Util.GetCurrentCellText(this.gridControl, "MonedaDestinoCod");
                entidad.tipocambio = Util.GetCurrentCellDbl(this.gridControl, "TipoCambio");


                if (Validar() == false) return;
                str_flag = Util.GetCurrentCellText(gridControl, "flag");

                
                
                
                if (str_flag == "0")
                {
                    MonedaLogic.Instance.InsertarTipoCambioOtrosMonedas(entidad, out int_flag, out str_mensaje);
                    
                    
                }
                else
                {
                    MonedaLogic.Instance.ActualizarTipoCambioOtrosMoneda(entidad, out int_flag, out str_mensaje);                    
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
                
                Util.SetCellGridFocus(gridControl, "TipoCambio");
                Util.SetCellInitEdit(gridControl, "TipoCambio");
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
                
                int int_flag = 0; string str_mensaje = "";
                
                TipoCambioMoneda entidad = new TipoCambioMoneda();
                entidad.fecha= Convert.ToDateTime(Util.GetCurrentCellValue(gridControl, "fecha"));
                entidad.destinocod =  Util.GetCurrentCellText(gridControl, "MonedaDestinoCod");
                entidad.origencod = Util.GetCurrentCellText(gridControl, "MonedaOrigenCod");
                
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");

                if (respuesta == true)
                {

                    MonedaLogic.Instance.EliminarTipoCambioOtrosMoneda(entidad, out int_flag, out str_mensaje);
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
                //gridControl.DataSource = datos.ListarMonedas("", "*");

                gridControl.DataSource = MonedaLogic.Instance.TraeTipoCambioOtrosMoneda();
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
