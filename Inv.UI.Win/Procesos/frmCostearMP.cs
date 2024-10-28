using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using Inv.BusinessLogic;
using Inv.BusinessEntities;

namespace Inv.UI.Win
{
    public partial class frmCostearMP : frmBaseReg
    {


        private static frmCostearMP _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmCostearMP Instance(frmMDI padre)
        {
            if (_aForm != null) return new frmCostearMP(padre);
            _aForm = new frmCostearMP(padre);
            return _aForm;
        }
        public frmCostearMP(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }

       
        #region"Metodo general"
        private void AddCmdButtonToGrid(RadGridView Grid, string NameButon, string TextButton, string ColumnGrid)
        {
            GridViewCommandColumn cmdbtn = new GridViewCommandColumn();
            cmdbtn.Name = NameButon;
            cmdbtn.HeaderText = TextButton;
            Grid.Columns.Add(cmdbtn);
            Grid.Columns[NameButon].Width = 30;
            //Grid.Columns[NameButon].BestFit();
        }
        private void CrearColumnas()
        {

            //Costeo Cantera MP
            RadGridView Gridcantera = CreateGridVista(this.gridCantera);
            this.CreateGridColumn(Gridcantera, "Codigo", "IN20CODIGO", 0, "", 90, true, false, true);
            this.CreateGridColumn(Gridcantera, "Descripcion", "IN20DESC", 0, "", 120, true, false, true);
            //this.CreateGridColumn(Gridcantera, "Año", "IN40ANIO", 0, "", 70, true, false, true);
            //this.CreateGridColumn(Gridcantera, "Mes", "IN40MES", 0, "", 70, true, false, true);
            this.CreateGridColumn(Gridcantera, "Importe", "IN40IMPORTE", 0, "{0:###,###0.00}", 100, true, false, true, true, "right");

            // Suma Importe 
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "IN40IMPORTE";
            summaryItem.FormatString = "{0:###,###0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Sum;

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem() { summaryItem };
            //summaryRowItem.Add(summaryItem);

            Gridcantera.SummaryRowsBottom.Add(summaryRowItem);


            Gridcantera.MasterTemplate.ShowTotals = true;
            Gridcantera.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            //this.gridControl.MasterView.SummaryRows[1].PinPosition = PinnedRowPosition.Bottom;
            //crearGrupos();

            //Costeo Transporte MP
            RadGridView Gridtransporte = CreateGridVista(this.gridTransporte);
            this.CreateGridColumn(Gridtransporte, "Codigo", "IN20CODIGO", 0, "", 90, true, false, true);
            this.CreateGridColumn(Gridtransporte, "Descripcion", "IN20DESC", 0, "", 120, true, false, true);
            //this.CreateGridColumn(Gridtransporte, "Año", "IN41ANIO", 0, "", 70, true, false, true);
            //this.CreateGridColumn(Gridtransporte, "Mes", "IN41MES", 0, "", 70, true, false, true);
            this.CreateGridColumn(Gridtransporte, "Importe", "IN41IMPORTE", 0, "{0:###,###0.00}", 100, true, false, true,true,"right");
            //Restulado de costeo MP

            // Suma Importe 
            GridViewSummaryItem summaryItem2 = new GridViewSummaryItem();
            summaryItem2.Name = "IN41IMPORTE";
            summaryItem2.FormatString = "{0:###,###0.00}";
            summaryItem2.Aggregate = GridAggregateFunction.Sum;

            GridViewSummaryRowItem summaryRowItem2 = new GridViewSummaryRowItem() { summaryItem2 };
            //summaryRowItem.Add(summaryItem);

            Gridtransporte.SummaryRowsBottom.Add(summaryRowItem2);


            Gridtransporte.MasterTemplate.ShowTotals = true;
            Gridtransporte.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            //this.gridControl.MasterView.SummaryRows[1].PinPosition = PinnedRowPosition.Bottom;
            //crearGrupos();


        }
        private void CrearColumnasCosteo()
        {

            RadGridView gridCosteoMP = CreateGridVista(this.gridCosteoMP);
            this.CreateGridColumn(gridCosteoMP, "Cod Cantera", "IN42CANTERACOD", 0, "", 90, true, false, true);
            this.CreateGridColumn(gridCosteoMP, "Cantera", "IN20DESC", 0, "", 90, true, false, true);
            this.CreateGridColumn(gridCosteoMP, "Tip Costo", "IN42TIPCOSTO", 0, "", 120, true, false, true);
            this.CreateGridColumn(gridCosteoMP, "Cod Bloque", "IN42BLOQUECOD", 0, "", 120, true, false, true);
            this.CreateGridColumn(gridCosteoMP, "Descripcion", "IN01DESLAR", 0, "", 120, true, false, true);
            this.CreateGridColumn(gridCosteoMP, "Uni Medida", "IN07UNIMED", 0, "", 120, true, false, true);
            this.CreateGridColumn(gridCosteoMP, "Cantidad", "IN42CANTIDADMT3", 0, "{0:#,##0.00}", 120, true, false, true,true,"right");
            this.CreateGridColumn(gridCosteoMP, "Costo", "IN42IMPORTEDISTRIBUIDO", 0, "{0:#,##0.00}", 120, true, false, true, true, "right");

            // Suma Importe 
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "IN42IMPORTEDISTRIBUIDO";
            summaryItem.FormatString = "{0:###,###0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Sum;
            GridViewSummaryItem summaryItem4 = new GridViewSummaryItem();
            summaryItem4.Name = "IN42CANTIDADMT3";
            summaryItem4.FormatString = "{0:###,###0.00}";

            summaryItem4.Aggregate = GridAggregateFunction.Sum;
            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem() { summaryItem, summaryItem4 };
            //summaryRowItem.Add(summaryItem);

            gridCosteoMP.SummaryRowsBottom.Add(summaryRowItem);


            gridCosteoMP.MasterTemplate.ShowTotals = true;
            gridCosteoMP.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            //this.gridControl.MasterView.SummaryRows[1].PinPosition = PinnedRowPosition.Bottom;
            //crearGrupos();


            RadGridView gridCostoXBloque = CreateGridVista(this.gridcostoxbloque);
            this.CreateGridColumn(gridCostoXBloque, "Cod Cantera", "IN42CANTERACOD", 0, "", 90, true, false, true);
            this.CreateGridColumn(gridCostoXBloque, "Cantera", "IN20DESC", 0, "", 90, true, false, true);
            this.CreateGridColumn(gridCostoXBloque, "Tip Costo", "IN42TIPCOSTO", 0, "", 120, true, false, true);
            this.CreateGridColumn(gridCostoXBloque, "Cod Bloque", "IN42BLOQUECOD", 0, "", 120, true, false, true);
            this.CreateGridColumn(gridCostoXBloque, "Descripcion", "IN01DESLAR", 0, "", 120, true, false, true);
            this.CreateGridColumn(gridCostoXBloque, "Uni Medida", "IN07UNIMED", 0, "", 120, true, false, true);
            this.CreateGridColumn(gridCostoXBloque, "Cantidad", "IN42CANTIDADMT3", 0, "{0:#,##0.00}", 120, true, false, true, true, "right");
            this.CreateGridColumn(gridCostoXBloque, "Costo", "IN42IMPORTEDISTRIBUIDO", 0, "{0:#,##0.00}", 120, true, false, true, true, "right");

            // Suma Importe 
            GridViewSummaryItem summaryItem2 = new GridViewSummaryItem();
            summaryItem2.Name = "IN42CANTIDADMT3";
            summaryItem2.FormatString = "{0:###,###0.00}";
            summaryItem2.Aggregate = GridAggregateFunction.Sum;
            GridViewSummaryItem summaryItem3 = new GridViewSummaryItem();
            summaryItem3.Name = "IN42IMPORTEDISTRIBUIDO";
            summaryItem3.FormatString = "{0:###,###0.00}";
            summaryItem3.Aggregate = GridAggregateFunction.Sum;
            GridViewSummaryRowItem summaryRowItem2 = new GridViewSummaryRowItem() { summaryItem2, summaryItem3 };
            //summaryRowItem.Add(summaryItem);

            gridCostoXBloque.SummaryRowsBottom.Add(summaryRowItem2);

            gridCostoXBloque.MasterTemplate.ShowTotals = true;
            gridCostoXBloque.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            //this.gridControl.MasterView.SummaryRows[1].PinPosition = PinnedRowPosition.Bottom;
            //crearGrupos();
        }
        #endregion
        #region "Comentarios"


        //private void Grid_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        //{
        //    //string nombreGrilla = ((RadGridView)sender).Name;
        //    if (e.Row != null)
        //    {
        //        if (Util.convertiracadena(e.Row.Cells["Flag"].Value) == "")
        //        {
        //            e.Cancel = true;
        //        }
        //    }

        //}
        //private void Grid_CommandCellClick(object sender, EventArgs e)
        //{
        //    RadGridView Grid;
        //    if (this.gridLineaArticulo.Focused)
        //    {
        //        Grid = this.gridLineaArticulo;
        //    }
        //    else if (this.gridGrupoArticulo.Focused)
        //    {
        //        Grid = this.gridGrupoArticulo;
        //    }
        //    else if (this.gridSubGrupoArticulo.Focused)
        //    {
        //        Grid = this.gridSubGrupoArticulo;
        //    }

        //    //Grid.Columns[""].IsCurrent


        //}
        //private void Grid_CellFormating(object sender, CellFormattingEventArgs e)
        //{

        //}
        //private void Grid_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        //{



        //    string nombre = ((RadGridView)sender).Name;
        //    switch (nombre)
        //    {
        //        case "gridGrupoArticulo":

        //            if (((RadGridView)sender).IsLoaded)
        //            {
        //                string codigoLineaArticulo = Util.GetCurrentCellText(e.CurrentRow, "CodigoLinea");
        //                string codigoGrupoArticulo = Util.GetCurrentCellText(e.CurrentRow, "Codigo");
        //            }
        //            break;
        //        case "gridLineaArticulo":

        //            if (((RadGridView)sender).IsLoaded)
        //            {
        //                string codigo = Util.GetCurrentCellText(e.CurrentRow, "Codigo");
        //            }
        //            break;
        //        case "gridSubGrupoArticulo":
        //            if (((RadGridView)sender).IsLoaded)
        //            {

        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}
        //private void Grid_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        //{

        //}
        #endregion

        
        
        private void Cargar()
        {

            try
            {
                DataTable dtcantera = AlmacenLogic.Instance.TraerCostoCantera(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
                gridCantera.DataSource = dtcantera;

               DataTable dttransporte = AlmacenLogic.Instance.TraerCostoTransporte(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
               gridTransporte.DataSource = dttransporte;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar");
            }

        }

        private void CargarLineaArticulo()
        {
            List<LineaArticulo> listaLineaArti = LineaArticuloLogic.Instance.TraeLineaArticulo(Logueo.CodigoEmpresa);
            this.gridCantera.DataSource = listaLineaArti;
        }
        private void CargarGrupoArticulo(string CodigoLineaArticulo)
        {

            List<GrupoArticulo> listaGrupoArti = LineaArticuloLogic.Instance.TraeGrupoArticulo(Logueo.CodigoEmpresa, CodigoLineaArticulo);
            this.gridTransporte.DataSource = listaGrupoArti;

        }

        private void CargarSubGrupoArticulo(string CodigoLineaArticulo, string CodigoGrupoArticulo)
        {


            //List<SubGrupoArticulo> ListaSubGrupoArti = LineaArticuloLogic.Instance.TraeSubGrupoArticulo(Logueo.CodigoEmpresa,
            //                                            CodigoLineaArticulo, CodigoGrupoArticulo);

            //this.gridResultadoCosteo.DataSource = ListaSubGrupoArti;
        }


   
        

        private void gridLineaArticulo_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {

            //try
            //{
            //    if (e.CurrentRow != null)
            //    {
            //        string codigo = Util.GetCurrentCellText(e.CurrentRow, "Codigo");
            //        CargarGrupoArticulo(codigo);
            //        if (this.gridgastostransporte.Rows.Count == 0)
            //        {
            //            this.gridResultadoCosteo.Rows.Clear();
            //        }
            //        else
            //        {
            //            string codigoGrupo = Util.GetCurrentCellText(this.gridgastostransporte.CurrentRow, "Codigo");
            //            CargarSubGrupoArticulo(codigo, codigoGrupo);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Console.Write("Error en currentRowChanged");
            //}

        }

        private void gridGrupoArticulo_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {

            try
            {
                if (e.CurrentRow != null)
                {
                    string codigoLineaArticulo = Util.GetCurrentCellText(e.CurrentRow, "CodigoLinea");
                    string codigoGrupoArticulo = Util.GetCurrentCellText(e.CurrentRow, "Codigo");

                    CargarSubGrupoArticulo(codigoLineaArticulo, codigoGrupoArticulo);
                }
            }
            catch (Exception ex)
            {
                System.Console.Write("Error en currentRowChanged");
            }

        }
        private void deshabilitarBotonProdDet(string nombre, GridCommandCellElement CommandCell)
        {
            GridCommandCellElement cellElement = CommandCell;
            switch (nombre)
            {
                case "btnGrabarDet":

                    cellElement.CommandButton.Image = Properties.Resources.save_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                case "btnCancelarDet":
                    cellElement.CommandButton.Image = Properties.Resources.cancel_disabled;

                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                case "btnEliminarDet":
                    cellElement.CommandButton.Image = Properties.Resources.deleted_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                case "btnEditarDet":
                    cellElement.CommandButton.Image = Properties.Resources.edited_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                default:
                    break;
            }

        }
        private void habilitarBotonProdDet(string nombre, GridCommandCellElement CommandCell, bool bGrabar,
                                           bool bCancelar, bool bEliminar, bool bEditar)
        {
            GridCommandCellElement cellElement = CommandCell;
            switch (nombre)
            {
                case "btnGrabarDet":
                    cellElement.CommandButton.Image = bGrabar ? Properties.Resources.save_enabled : Properties.Resources.save_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bGrabar;
                    break;

                case "btnCancelarDet":
                    cellElement.CommandButton.Image = bCancelar ? Properties.Resources.cancel_enabled : Properties.Resources.cancel_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bCancelar;
                    break;

                case "btnEliminarDet":
                    cellElement.CommandButton.Image = bEliminar ? Properties.Resources.deleted_enabled : Properties.Resources.deleted_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEliminar;
                    break;

                case "btnEditarDet":
                    cellElement.CommandButton.Image = bEditar ? Properties.Resources.edited_enabled : Properties.Resources.edited_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEditar;
                    break;

                default:
                    break;
            }
        }

        private void gridGrupoArticulo_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
                if (cellElement == null) return;
                if (e.CellElement.ColumnInfo is GridViewCommandColumn)
                {


                    //if (gridgastostransporte.Rows[e.RowIndex].Cells["flag"].Value == null)
                    //    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, true);
                    //else
                    //    habilitarBotonProdDet(e.Column.Name, cellElement, true, true, false, false);


                }

            }
            catch (Exception ex)
            {
                Util.ShowError("Error cellformating : " + ex.Message);
            }
        }

        private void gridSubGrupoArticulo_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
                if (cellElement == null) return;
                if (e.CellElement.ColumnInfo is GridViewCommandColumn)
                {


                    //if (gridResultadoCosteo.Rows[e.RowIndex].Cells["flag"].Value == null)
                    //    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, true);
                    //else
                    //    habilitarBotonProdDet(e.Column.Name, cellElement, true, true, false, false);


                }

            }
            catch (Exception ex)
            {
                Util.ShowError("Error cellformating: " + ex.Message);
            }
        }

        private void btnAgregarLineaArticulo_Click(object sender, EventArgs e)
        {
            //this.gridResultadoCosteo.Enabled = false;
            //this.gridgastostransporte.Enabled = false;
            //this.btnAgregarGrupoArticulo.Enabled = false;
            //this.btnAgregaSubGrupoArticulo.Enabled = false;

            //AgregarRegistro(this.gridgastoscantera);



        }

        private void btnAgregarGrupoArticulo_Click(object sender, EventArgs e)
        {


            //this.btnAgregarLineaArticulo.Enabled = false;
            //this.btnAgregaSubGrupoArticulo.Enabled = false;
            //this.gridgastoscantera.Enabled = false;
            //this.gridResultadoCosteo.Enabled = false;

            //AgregarRegistro(this.gridgastostransporte);



        }


        int indiceEditable = 0;
        private void AgregarRegistro(RadGridView tabla)
        {
            try
            {
                //tabla.Rows.AddNew();
                //tabla.CurrentRow.Cells["Flag"].Value = "0";
                //tabla.CurrentRow.Cells["Descripcion"].BeginEdit();
                //indiceEditable = tabla.Rows[tabla.RowCount - 1].Index;

                //string codigoGenerado = "";
                //if (tabla.Name.ToUpper() == "GRIDLINEAARTICULO")
                //{
                //    LineaArticuloLogic.Instance.TraeCodigLineaArticulo(Logueo.CodigoEmpresa, out codigoGenerado);
                //    Util.SetValueCurrentCellText(tabla.CurrentRow, "Codigo", codigoGenerado);
                //    Util.SetValueCurrentCellText(tabla.CurrentRow, "Flag", "0");
                //}
                //else if (tabla.Name.ToUpper() == "GRIDGRUPOARTICULO")
                //{
                //    string lineaArticulo = Util.GetCurrentCellText(this.gridgastoscantera.CurrentRow, "Codigo");

                //    LineaArticuloLogic.Instance.TraeCodigoGrupoArticulo(Logueo.CodigoEmpresa, lineaArticulo, out codigoGenerado);
                //    Util.SetValueCurrentCellText(tabla.CurrentRow, "Codigo", codigoGenerado);
                //    Util.SetValueCurrentCellText(tabla.CurrentRow, "Flag", "0");
                //}
                //else if (tabla.Name.ToUpper() == "GRIDSUBGRUPOARTICULO")
                //{
                //    string lineaArticulo = Util.GetCurrentCellText(this.gridgastoscantera.CurrentRow, "Codigo");
                //    string grupoArticulo = Util.GetCurrentCellText(this.gridgastostransporte.CurrentRow, "Codigo");

                //    LineaArticuloLogic.Instance.TraeCodigoSubGrupoArticulo(Logueo.CodigoEmpresa,
                //                                lineaArticulo, grupoArticulo, out codigoGenerado);

                //    Util.SetValueCurrentCellText(tabla.CurrentRow, "Codigo", codigoGenerado);
                //    Util.SetValueCurrentCellText(tabla.CurrentRow, "Flag", "0");
                //}
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al agregar registro:" + ex.Message);
            }


        }

        private void gridLineaArticulo_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            //try
            //{
            //    string flag = Util.GetCurrentCellText(this.gridgastoscantera.CurrentRow, "Flag");
            //    if (flag != "")
            //    {
            //        e.Cancel = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Console.Write("Error en currentRowChanging");
            //}


        }

        private void gridGrupoArticulo_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            //try
            //{
            //    string flag = Util.GetCurrentCellText(this.gridgastostransporte.CurrentRow, "Flag");
            //    if (flag != "")
            //    {
            //        e.Cancel = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Console.Write("Error en currentRowChanging");
            //}


        }

        private void gridSubGrupoArticulo_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            //try
            //{
            //    string flag = Util.GetCurrentCellText(this.gridResultadoCosteo.CurrentRow, "Flag");
            //    if (flag != "")
            //    {
            //        e.Cancel = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Console.Write("Error en currentRowChanging");
            //}


        }
        #region "Linea de articulo"
        private void GuardarLineaArticulo(GridViewRowInfo filadetabla)
        {
            ////guardar y refrescar grilla
            //string codigo = Util.GetCurrentCellText(filadetabla, "Codigo");
            //string descripcion = Util.GetCurrentCellText(filadetabla, "Descripcion");

            //if (codigo == "") { Util.ShowAlert("Ingresar codigo"); return; }
            //if (descripcion == "") { Util.ShowAlert("Ingresar descripcion"); return; }
            //bool esNuevo = false;
            //esNuevo = Util.GetCurrentCellText(filadetabla, "Flag") == "0" ? true : false;
            //int flag = 0;
            //string mensaje = "";
            //if (esNuevo)
            //{
            //    LineaArticuloLogic.Instance.InsertarLinArt(Logueo.CodigoEmpresa, codigo, descripcion, 
            //                                            Logueo.Anio, out flag, out mensaje);
            //}
            //else
            //{
            //    LineaArticuloLogic.Instance.ActualizarLinArt(Logueo.CodigoEmpresa, codigo, descripcion, out flag, out mensaje);
            //}


            //if (flag != -1)
            //{
            //    Util.ShowMessage(mensaje, flag);
            //    CargarLineaArticulo();
            //    Util.enfocarFila(this.gridgastoscantera, "Codigo", codigo);
            //    this.btnAgregarGrupoArticulo.Enabled = true;
            //    this.btnAgregaSubGrupoArticulo.Enabled = true;
            //    this.gridgastostransporte.Enabled = true;
            //    this.gridResultadoCosteo.Enabled = true;
            //}


        }

        private void EditarLineaArticulo(GridViewRowInfo filadetabla)
        {
            //tabladatos.CurrentRow.Cells["Flag"].Value = "0";
            filadetabla.Cells["Flag"].Value = "1";
        }

        private void EliminarLineaArticulo(GridViewRowInfo filadetabla)
        {
            //ellminar yu refrescar grilla
            string codigo = Util.GetCurrentCellText(filadetabla, "Codigo");
            int flag = 0; string mensaje = "";
            bool esNuevo = false;
            esNuevo = Util.GetCurrentCellText(filadetabla, "Flag") == "0" ? true : false;

            LineaArticuloLogic.Instance.EliminarLineaArticulo(Logueo.CodigoEmpresa, codigo, out flag, out mensaje);
            Util.ShowMessage(mensaje, flag);

            if (flag != -1)
            {
                CargarLineaArticulo();
            }

        }

        private void CancelarLineaArticulo(GridViewRowInfo filadetabla)
        {
            //tabladatos.CurrentRow.Cells["Flag"].Value = "";
            filadetabla.Cells["Flag"].Value = "";

            //this.gridResultadoCosteo.Enabled = true;
            //this.gridgastostransporte.Enabled = true;
            //this.btnAgregarGrupoArticulo.Enabled = true;
            //this.btnAgregaSubGrupoArticulo.Enabled = true;

            CargarLineaArticulo();


        }
        #endregion
        #region "Grupo de articulo"
        private void EditarGrupoArticulo(GridViewRowInfo filadetabla)
        {
            filadetabla.Cells["Flag"].Value = "1";
        }

        private void EliminarGrupoArticulo(GridViewRowInfo filadetabla)
        {
            //string codigoLinea = Util.GetCurrentCellText(this.gridgastoscantera.CurrentRow, "Codigo");
            //string codigo = Util.GetCurrentCellText(filadetabla, "Codigo");
            //int flag = 0; string mensaje = "";
            //LineaArticuloLogic.Instance.EliminarGrupoArticulo(Logueo.CodigoEmpresa, codigoLinea, codigo, out flag, out mensaje);
            //Util.ShowMessage(mensaje, flag);
            //if (flag != -1)
            //{
            //    //CargarGrupoArticulo(codigoLinea);
            //    //this.btnAgregarLineaArticulo.Enabled = true;
            //    //this.btnAgregaSubGrupoArticulo.Enabled = true;
            //    //this.gridgastoscantera.Enabled = true;
            //    //this.gridResultadoCosteo.Enabled = true;
            //}
        }
        private void CancelarGrupoArticulo(GridViewRowInfo filadetabla)
        {


            filadetabla.Cells["Flag"].Value = "";

            //this.btnAgregarLineaArticulo.Enabled = true;
            //this.btnAgregaSubGrupoArticulo.Enabled = true;
            //this.gridgastoscantera.Enabled = true;
            //this.gridResultadoCosteo.Enabled = true;

            //string codigoLinea = Util.GetCurrentCellText(this.gridgastoscantera.CurrentRow, "Codigo");
            //CargarGrupoArticulo(codigoLinea);

        }
        #endregion
        #region"SubGrupo Articulo"
        private void GuardarSubGrupoArticulo(GridViewRowInfo filadetabla)
        {
            //string codigoLinea = Util.GetCurrentCellText(this.gridgastoscantera.CurrentRow, "Codigo");
            //string codigoGrupo = Util.GetCurrentCellText(this.gridgastostransporte.CurrentRow, "Codigo");
            //string codigo = Util.GetCurrentCellText(this.gridResultadoCosteo.CurrentRow, "Codigo");
            //string descripcion = Util.GetCurrentCellText(this.gridResultadoCosteo.CurrentRow, "Descripcion");
            //if (codigo == "")
            //{
            //    Util.ShowAlert("Ingresar codigo"); return;
            //}
            //if (descripcion == "")
            //{
            //    Util.ShowAlert("Ingresar descripcion"); return;
            //}
            //bool esNuevo = false;
            //esNuevo = Util.GetCurrentCellText(filadetabla, "Flag") == "0" ? true : false;

            //int flag = 0;
            //string mensaje = "";

            //if (esNuevo)
            //{
            //    LineaArticuloLogic.Instance.InsertarSubGrupoArticulo(Logueo.CodigoEmpresa, codigoLinea,
            //                                    codigoGrupo, codigo, descripcion,
            //                                    Logueo.Anio, out flag, out mensaje);
            //}
            //else
            //{
            //    LineaArticuloLogic.Instance.ActualizarSubGrupoArticulo(Logueo.CodigoEmpresa, codigoLinea,
            //        codigoGrupo, codigo, descripcion, out flag, out mensaje);
            //}
            //if (flag != -1)
            //{
            //    Util.ShowMessage(mensaje, flag);

            //    CargarSubGrupoArticulo(codigoLinea, codigoGrupo);
            //    Util.enfocarFila(this.gridCantera, "Codigo", codigo);

            //    this.gridCantera.Enabled = true;
            //    this.gridCantera.Enabled = true;

            //    this.gridCantera.Enabled = true;
            //    this.gridCantera.Enabled = true;
            //}




        }

        private void EditarSubGrupoArticulo(GridViewRowInfo filadetabla)
        {
            filadetabla.Cells["Flag"].Value = "1";
        }

        private void EliminarSubGrupoArticulo(GridViewRowInfo filadetabla)
        {
            string codigoLinea = Util.GetCurrentCellText(this.gridCantera.CurrentRow, "Codigo");
            string codigoGrupo = Util.GetCurrentCellText(this.gridCantera.CurrentRow, "Codigo");
            string codigo = Util.GetCurrentCellText(filadetabla, "Codigo");

            int flag = 0; string mensaje = "";

            LineaArticuloLogic.Instance.EliminarSubGrupoArticulo(Logueo.CodigoEmpresa, codigoLinea, codigoGrupo, codigo, out flag, out mensaje);
            Util.ShowMessage(mensaje, flag);
            //if (flag != -1)
            //{

            //    CargarSubGrupoArticulo(codigoLinea, codigoGrupo);
            //    this.btnAgregarLineaArticulo.Enabled = true;
            //    this.btnAgregarGrupoArticulo.Enabled = true;
            //    this.gridgastoscantera.Enabled = true;
            //    this.gridgastostransporte.Enabled = true;
            //}


            //CargarSubGrupoArticulo(codigoLinea);
        }

        private void CancelarSubGrupoArticulo(GridViewRowInfo filadetabla)
        {

            //filadetabla.Cells["Flag"].Value = "";

            //this.btnAgregarLineaArticulo.Enabled = true;
            //this.btnAgregarGrupoArticulo.Enabled = true;

            //this.gridgastoscantera.Enabled = true;
            //this.gridgastostransporte.Enabled = true;

            //string codigoLinea = Util.GetCurrentCellText(this.gridgastoscantera.CurrentRow, "Codigo");
            //string codigoGrupo = Util.GetCurrentCellText(this.gridgastostransporte.CurrentRow, "Codigo");
            ////CargarGrupoArticulo(codigoLinea);
            //CargarSubGrupoArticulo(codigoLinea, codigoGrupo);
        }

        #endregion

        private void gridLineaArticulo_CommandCellClick(object sender, EventArgs e)
        {
            //GridViewRowInfo fila = this.gridgastoscantera.CurrentRow;
            //if (this.gridgastoscantera.Columns["btnGrabarDet"].IsCurrent)
            //{

            //    GuardarLineaArticulo(fila);
            //}

            //if (this.gridgastoscantera.Columns["btnCancelarDet"].IsCurrent)
            //{
            //    CancelarLineaArticulo(fila);
            //}

            //if (this.gridgastoscantera.Columns["btnEliminarDet"].IsCurrent)
            //{
            //    EliminarLineaArticulo(fila);
            //}

            //if (this.gridgastoscantera.Columns["btnEditarDet"].IsCurrent)
            //{
            //    EditarLineaArticulo(fila);
            //}
        }

        private void gridGrupoArticulo_CommandCellClick(object sender, EventArgs e)
        {
            //GridViewRowInfo fila = this.gridgastostransporte.CurrentRow;
            //Cursor.Current = Cursors.WaitCursor;
            //if (this.gridgastostransporte.Columns["btnGrabarDet"].IsCurrent)
            //{
            //    GuardarGrupoArticulo(fila);
            //}

            //if (this.gridgastostransporte.Columns["btnCancelarDet"].IsCurrent)
            //{
            //    CancelarGrupoArticulo(fila);
            //}

            //if (this.gridgastostransporte.Columns["btnEliminarDet"].IsCurrent)
            //{
            //    EliminarGrupoArticulo(fila);
            //}

            //if (this.gridgastostransporte.Columns["btnEditarDet"].IsCurrent)
            //{
            //    EditarGrupoArticulo(fila);
            //}
            //Cursor.Current = Cursors.Default;
        }

        private void gridSubGrupoArticulo_CommandCellClick(object sender, EventArgs e)
        {
            //GridViewRowInfo fila = this.gridResultadoCosteo.CurrentRow;
            //Cursor.Current = Cursors.WaitCursor;
            //if (this.gridResultadoCosteo.Columns["btnGrabarDet"].IsCurrent)
            //{
            //    GuardarSubGrupoArticulo(fila);
            //}

            //if (this.gridResultadoCosteo.Columns["btnCancelarDet"].IsCurrent)
            //{
            //    CancelarSubGrupoArticulo(fila);
            //}

            //if (this.gridResultadoCosteo.Columns["btnEliminarDet"].IsCurrent)
            //{
            //    EliminarSubGrupoArticulo(fila);
            //}

            //if (this.gridResultadoCosteo.Columns["btnEditarDet"].IsCurrent)
            //{
            //    EditarSubGrupoArticulo(fila);
            //}
            //Cursor.Current = Cursors.Default;
        }

        private void gridGrupoArticulo_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Row != null)
            {
                if (Util.convertiracadena(e.Row.Cells["Flag"].Value) == "")
                {
                    e.Cancel = true;
                }
            }
        }

        private void gridSubGrupoArticulo_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Row != null)
            {
                if (Util.convertiracadena(e.Row.Cells["Flag"].Value) == "")
                {
                    e.Cancel = true;
                }
            }
        }


        private void frmCostearMP_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                OcultarBarra();
                //OcultarBarra();
                //HabilitaBotonPorNombre(BaseRegBotones.cbbVer);
                HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
                CrearColumnas();
                CrearColumnasCosteo();
                Cargar();

            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al iniciar formulario");
            }
            Cursor.Current = Cursors.Default;
        }

    

        private void CargarCosteo()
        {
            DataTable dtCostoMP = AlmacenLogic.Instance.TraerCostoMP(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
            gridCosteoMP.DataSource = dtCostoMP;
        }

        private void CargarCostoBloque()
        {
            DataTable dtcostoxbloque = AlmacenLogic.Instance.TraerCostoxBloque(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
            gridcostoxbloque.DataSource = dtcostoxbloque;
        }

        private void btnProcesarCosteo_Click(object sender, EventArgs e)
        {
            CargarCosteo();
            CargarCostoBloque();
        }

      
        
    }
}
