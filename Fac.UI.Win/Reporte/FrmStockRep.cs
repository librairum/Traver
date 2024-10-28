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

namespace Fac.UI.Win
{
    public partial class FrmStockRep : frmBaseReporte
    {
        private bool isLoaded = false;
        ColumnGroupsViewDefinition columnGroupsView;
        RadGridView grilla;
        private void FrmStockRep_Load(object sender, EventArgs e)
        {
            Crearcolumnas();
            CrearcolumnasDet();
           // CargarCombos();
            OnBuscar();
            isLoaded = true;
            this.gestionarBotones(ElementVisibility.Visible, ElementVisibility.Visible, ElementVisibility.Visible);
            
        }
        private frmMDI FrmParent { get; set; }
        private static FrmStockRep _aForm;

         public static FrmStockRep Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmStockRep(mdiPrincipal);
            _aForm = new FrmStockRep(mdiPrincipal);
            return _aForm;
        }

         public FrmStockRep(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            this.gridControl.CustomFiltering += new GridViewCustomFilteringEventHandler(abrirFiltro);
        }
         void abrirFiltro(object sender, GridViewCustomFilteringEventArgs e) {
             MessageBox.Show("Filtro de grilla");
         }
        public FrmStockRep()
        {
            InitializeComponent();
        }

        private void Crearcolumnas()
        {
             grilla =  this.CreateGrid(this.gridControl);
            //{0:###,###0.00} {0:###,###0.00}
           
             this.CreateGridColumn(grilla, "Codigo", "IN01KEY", 0, "", 120, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "IN01DESLAR", 0, "", 300, true, false, true);
            this.CreateGridColumn(grilla, "Unidad Medida", "IN01UNIMED", 0, "", 40, true, false, true);
            this.CreateGridColumn(grilla, "Real", "StockRealArea", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            this.CreateGridColumn(grilla, "Reserva", "StockReservaArea", 0, "{0:###,###0.00}", 90, true, false, true, "right");
            this.CreateGridColumn(grilla, "Pedido", "StockProduccionArea", 0, "{0:###,###0.00}", 120, true, false, true, "right");
            this.CreateGridColumn(grilla, "Disponible", "StockDisponibleArea", 0, "{0:###,###0.00}", 100, true, false, true, "right");
            this.CreateGridColumn(grilla, "#Cajas", "CajasCantidad", 0, "{0:###,###0.00}", 85, true, false, true, "right");
            this.CreateGridColumn(grilla, "Tipo", "tipo", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Color.", "color", 0, "", 100, true, false, true);
            this.CreateGridColumn(grilla, "Tonalidad", "tonalidad", 0, "", 100, true, false, true);
            this.CreateGridColumn(grilla, "Formato", "formato", 0, "", 85, true, false, true);
            this.CreateGridColumn(grilla, "Acabado", "acabado", 0, "", 100, true, false, true);
            this.CreateGridColumn(grilla, "Relleno", "relleno", 0, "", 100, true, false, true);
            this.CreateGridColumn(grilla, "Borde", "borde", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Modelo", "modelo", 0, "", 100, true, false, true);


            // Suma Stock Real
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "StockRealArea";
            summaryItem.FormatString = "{0:###,###0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Sum;

            // Suma Stock Reserva
            GridViewSummaryItem summaryStockReserva = new GridViewSummaryItem();
            summaryStockReserva.Name = "StockReservaArea";
            summaryStockReserva.FormatString = "{0:###,###0.00}";
            summaryStockReserva.Aggregate = GridAggregateFunction.Sum;

            // Suma Stock produccion a pedido
            GridViewSummaryItem summaryStockProduccion = new GridViewSummaryItem();
            summaryStockProduccion.Name = "StockProduccionArea";
            summaryStockProduccion.FormatString = "{0:###,###0.00}";
            summaryStockProduccion.Aggregate = GridAggregateFunction.Sum;

            // Suma Stok disponible
            GridViewSummaryItem summaryStockDisponible = new GridViewSummaryItem();
            summaryStockDisponible.Name = "StockDisponibleArea";
            summaryStockDisponible.FormatString = "{0:###,###0.00}";
            summaryStockDisponible.Aggregate = GridAggregateFunction.Sum;

            //// Conteo de cajas
             // Nota : Se quito,por se inflaban el nro de caja
            //GridViewSummaryItem summaryItemCajas = new GridViewSummaryItem();
            //summaryItemCajas.Name = "CajasCantidad";
            //summaryItemCajas.FormatString = "{0}";
            //summaryItemCajas.Aggregate = GridAggregateFunction.Count;


            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem() { summaryItem, summaryStockReserva, summaryStockProduccion, summaryStockDisponible };
            //summaryRowItem.Add(summaryItem);

            grilla.SummaryRowsBottom.Add(summaryRowItem);

            //// Conteo de cajas
            //GridViewSummaryItem summaryItemCajas = new GridViewSummaryItem();
            //summaryItemCajas.Name = "CajasCantidad";
            //summaryItemCajas.FormatString = "Contar = {0}";
            //summaryItemCajas.Aggregate = GridAggregateFunction.Count;

            //GridViewSummaryRowItem summaryRowItemCajas = new GridViewSummaryRowItem();
            //summaryRowItemCajas.Add(summaryItemCajas);

            //grilla.SummaryRowsBottom.Add(summaryRowItemCajas);

            grilla.MasterTemplate.ShowTotals = true;
            grilla.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            //this.gridControl.MasterView.SummaryRows[1].PinPosition = PinnedRowPosition.Bottom;
            crearGrupos();
            
        }
        void crearGrupos()
        {
            try {

                this.columnGroupsView = new ColumnGroupsViewDefinition();
                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("General"));
                this.columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());

                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["IN01KEY"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["IN01DESLAR"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["IN01UNIMED"]);

                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Stock"));
                this.columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
                this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grilla.Columns["StockRealArea"]);
                this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grilla.Columns["StockReservaArea"]);
                this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grilla.Columns["StockDisponibleArea"]);
                this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grilla.Columns["StockProduccionArea"]);
                this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grilla.Columns["CajasCantidad"]);



                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("detalle"));
                
                this.columnGroupsView.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
                this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grilla.Columns["tipo"]);
                this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grilla.Columns["color"]);
                this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grilla.Columns["tonalidad"]);
                this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grilla.Columns["formato"]);
                this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grilla.Columns["acabado"]);
                this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grilla.Columns["relleno"]);
                this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grilla.Columns["borde"]);
                this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grilla.Columns["modelo"]);

                grilla.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                grilla.ViewDefinition = columnGroupsView;
            }
            catch (Exception ex) {
                MessageBox.Show("Erro crear Grupo:" + ex.Message);
            }
            

        }
        private void CrearcolumnasDet()
        {

            RadGridView gridDet = this.CreateGrid(this.gridControlDet);
            this.CreateGridColumn(gridDet, "Cliente", "Cliente", 0, "", 200, true, false, true);
            this.CreateGridColumn(gridDet, "Pedido Nro", "ClientePedidonro", 0, "", 100, true, false, true);
            this.CreateGridColumn(gridDet, "Anio", "IN07AA", 0, "", 75, true, false, true, "center");
            this.CreateGridColumn(gridDet, "Mes", "IN07MM", 0, "", 50, true, false, true, "center");
            this.CreateGridColumn(gridDet, "Doc Tip", "IN07TIPDOC", 0, "", 50, true, false, true, "center");
            this.CreateGridColumn(gridDet, "Doc Nro", "IN07CODDOC", 0, "", 100, true, false, true,"center");
            this.CreateGridColumn(gridDet, "Almacen", "IN07CODALM", 0, "", 100, true, false, true, "center");
            this.CreateGridColumn(gridDet, "Uni Med", "IN07UNIMED", 0, "", 100, true, false, true, "center");
            this.CreateGridColumn(gridDet, "Caja Nro.", "IN07NROCAJA", 0, "", 150, true, false, true, "center");
            this.CreateGridColumn(gridDet, "Ubicacion.", "Ubicacion", 0, "", 150, true, false, true, "center");
            this.CreateGridColumn(gridDet, "Stock Real Area", "StockRealArea", 0, "{0:###,###0.00}", 100, true, false, true, "right");
            this.CreateGridColumn(gridDet, "Stock Reserva Area", "StockReservaArea", 0, "{0:###,###0.00}", 100, true, false, true, "right");
            this.CreateGridColumn(gridDet, "Stock Produccion a Pedido", "StockProduccionArea", 0, "{0:###,###0.00}", 100, true, false, true, "right");
            this.CreateGridColumn(gridDet, "Stock Disponible Area", "StockDisponibleArea", 0, "{0:###,###0.00}", 100, true, false, true, "right");
        }
        protected  void OnBuscarDet()
        {
            string codigoproducto = string.Empty;
            if (this.gridControl.RowCount == 0)
                return;

            codigoproducto = this.gridControl.CurrentRow.Cells["in01key"].Value.ToString();

            //base.OnBuscar();
            Cursor.Current = Cursors.WaitCursor;
            
            var lista = ArticuloLogic.Instance.TraerProdTerStockDet(Logueo.CodigoEmpresa, codigoproducto);
            this.gridControlDet.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }
        protected override void OnRefrescar()
        {
            OnBuscar();
        }
        protected override void OnBuscar()
        {
            //base.OnBuscar();
            Cursor.Current = Cursors.WaitCursor;

            var lista = ArticuloLogic.Instance.TraerProdTerStock(Logueo.CodigoEmpresa, Logueo.Anio);
            //this.gridControl.DataSource = lista;
            grilla.DataSource = lista;
           
            Cursor.Current = Cursors.Default;
        }
        protected override void OnVista()
        {
            //string mensajeOut = string.Empty;
            string periodostock;
            string periodoreporte;
            var codigosSeleccionados = new string[gridControl.SelectedRows.Count];
            var x = 0;

            foreach (var filaSeleccionado in gridControl.SelectedRows)
            {
                //codigosSeleccionados[x] = (string)gridControl.Columns["CodigoEmpleado"].value((int) filaSeleccionado);
                codigosSeleccionados[x] = filaSeleccionado.Cells["IN01KEY"].Value.ToString();
                //e.CellElement.RowInfo.Cells["Title"].Value.ToString();
                x++;
            }


            Cursor.Current = Cursors.WaitCursor;

            if (rbtrepstockresumido.CheckState == CheckState.Checked)
            {
                periodostock = (Logueo.Mes + "-" + Logueo.Anio);
                periodoreporte = (Logueo.Anio + Logueo.Mes);

                //GlobalLogic.Instance.InsertarRangoImpresion(Logueo.CodigoEmpresa, "Admin", this.txtCodigoTipDoc.Text, this.txtNroDocumento.Text, out mensajeOut);
                var datos = DocumentoLogic.Instance.RptStockProdterRes(Logueo.CodigoEmpresa, periodoreporte);
                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = "RptStockRes.rpt";
                reporte.DataSource = datos;

                reporte.FormulasFields.Add(new Formula("periodostock", periodostock));
                reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
            }
            else if (rbtrepstockdetallado.CheckState == CheckState.Checked)
            {
                //GlobalLogic.Instance.InsertarRangoImpresion(Logueo.CodigoEmpresa, "Admin", this.txtCodigoTipDoc.Text, this.txtNroDocumento.Text, out mensajeOut);
                var datos = DocumentoLogic.Instance.RptStockProdter(Logueo.CodigoEmpresa, "06", Logueo.Anio, Logueo.Mes, Util.ConvertiraXML(codigosSeleccionados));
                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = "RptStockDet.rpt";
                reporte.DataSource = datos;

                periodostock = (Logueo.Mes + "" + Logueo.Anio);
                reporte.FormulasFields.Add(new Formula("periodostock", periodostock));
                reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
            }
            else if (rbtrepstockcontabilidad.CheckState == CheckState.Checked)
            {
                //GlobalLogic.Instance.InsertarRangoImpresion(Logueo.CodigoEmpresa, "Admin", this.txtCodigoTipDoc.Text, this.txtNroDocumento.Text, out mensajeOut);
                var datos = DocumentoLogic.Instance.RptStockProdter(Logueo.CodigoEmpresa, "06", Logueo.Anio, Logueo.Mes, Util.ConvertiraXML(codigosSeleccionados));
                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = "RptStockDetContabilidad.rpt";
                reporte.DataSource = datos;

                periodostock = (Logueo.Mes + "-" + Logueo.Anio);
                reporte.FormulasFields.Add(new Formula("periodostock", periodostock));
                reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
            }

            Cursor.Current = Cursors.Default;
            
        }
        private void gridControl_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try
            {
                var row = e.CurrentRow.Cells;
                
                //  Si no ha cargado la pantalla por complet 
                if (!isLoaded) return;

                
                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["IN01KEY"].Value != null)
                    {
                        OnBuscarDet();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbtRefresh_Click(object sender, EventArgs e)
        {
            OnBuscar();
        }

        private void gridControl_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            
        }
    }

}