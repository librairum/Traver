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

namespace Inv.UI.Win
{
    public partial class FrmRepMovimientosMP : frmBaseReporte
    {
        private frmMDI FrmParent { get; set; }
        private static FrmRepMovimientosMP _aForm;
        private bool isLoaded = false;
        ColumnGroupsViewDefinition columnGroupsView;
        public FrmRepMovimientosMP(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            
            isLoaded = true;
            rbtMensual.CheckState = CheckState.Checked;
            this.dtpFechaini.Value = DateTime.Now;
            this.dtpFechafin.Value = DateTime.Now;
            
            Crearcolumnas();
            OnBuscar();
            HabilitarBotones(true, true, true, false,true);

        }
        protected override void OnSeleccionarTodo()
        {
            try
            {
                gridControl.SelectAll();
            }
            catch (Exception ex)
            {
                Util.ShowError("ERROR");
            }

        }
       
        public static FrmRepMovimientosMP Instance(frmMDI mdiPrincipal) 
        {
            if (_aForm != null) return new FrmRepMovimientosMP(mdiPrincipal);
            _aForm = new FrmRepMovimientosMP(mdiPrincipal);
            return _aForm;
        }
        private void Crearcolumnas()
        {


            RadGridView grilla = this.CreateGrid(this.gridControl);
            grilla.ShowFilteringRow = true;
            this.CreateGridColumn(grilla, "Almacen", "IN07CODALM", 0, "", 50, true, false, true);                        
            this.CreateGridColumn(grilla, "Fecha", "IN07FECDOC", 0, "{0:dd/MM/yyyy}", 70, true, false, true);
            this.CreateGridColumn(grilla, "Proveedor", "Proveedor", 0, "", 100, true, false, true);
            this.CreateGridColumn(grilla, "Cantera", "DescripcionCantera", 0, "", 100, true, false, true);
            this.CreateGridColumn(grilla, "Contratista", "DescripcionContratista", 0, "", 100, true, false, true);            
            this.CreateGridColumn(grilla, "Color", "Color", 0, "", 80, true, false, true);

            this.CreateGridColumn(grilla, "Guia", "Guia", 0, "", 60, true, false, true);
            this.CreateGridColumn(grilla, "Bloque", "NroBloque", 0, "", 60, true, false, true);

            this.CreateGridColumn(grilla, "Codigo", "IN07CODBLOQUEPROV", 0, "", 100, true, false, true);

            this.CreateGridColumn(grilla, "Largo", "IN07LARGOCAN", 0, "{0:###,##0.00}", 60, true, false, true, "right", true);
            this.CreateGridColumn(grilla, "Ancho", "IN07ANCHOCAN", 0, "{0:###,##0.00}", 60, true, false, true, "right", true);
            this.CreateGridColumn(grilla, "Alto", "IN07ALTOCAN", 0, "{0:###,##0.00}", 50, true, false, true, "right", true);
            this.CreateGridColumn(grilla, "Volumen", "Volumen", 0, "{0:###,##0.00}", 60, true, false, true, "right", true);

            this.CreateGridColumn(grilla, "Largo", "IN07LARGO", 0, "{0:###,##0.00}", 60, true, false, true, "right", true);
            this.CreateGridColumn(grilla, "Ancho", "IN07ANCHO", 0, "{0:###,##0.00}", 60, true, false, true, "right", true);
            this.CreateGridColumn(grilla, "Alto", "IN07ALTO", 0, "{0:###,##0.00}", 50, true, false, true, "right", true);
            this.CreateGridColumn(grilla, "VolumenPL", "VolumenPL", 0, "{0:###,##0.00}", 60, true, false, true, "right", true);
                                 
            this.CreateGridColumn(grilla, "Estado", "ESTATUS", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Fec.Corte", "fechacorte", 0, "{0:dd/MM/yyyy}", 80, true, false, true, "right");          

            // Suma del Area
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "area";
            summaryItem.FormatString = "{0:###,###0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Sum;

            ////// Conteo de cajas
            //GridViewSummaryItem summaryItemCajas = new GridViewSummaryItem();
            //summaryItemCajas.Name = "IN07NROCAJA";
            //summaryItemCajas.FormatString = "{0}";
            //summaryItemCajas.Aggregate = GridAggregateFunction.Count;

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem() { summaryItem };

            grilla.SummaryRowsBottom.Add(summaryRowItem);
            grilla.MasterTemplate.ShowTotals = true;
            grilla.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;

            crearGrupos();

        }
        void crearGrupos() 
        {
            this.columnGroupsView = new ColumnGroupsViewDefinition();
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Bloque de Ingreso"));
            this.columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN07CODALM"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN07FECDOC"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["Proveedor"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["DescripcionCantera"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["DescripcionContratista"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["Color"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["Guia"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["NroBloque"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN07CODBLOQUEPROV"]);

            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Dimensiones de Cantera"));
            this.columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["IN07LARGOCAN"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["IN07ANCHOCAN"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["IN07ALTOCAN"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["Volumen"]);

            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Dimensiones de Planta"));
            this.columnGroupsView.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["IN07LARGO"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["IN07ANCHO"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["IN07ALTO"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["VolumenPL"]);

            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup(""));
            this.columnGroupsView.ColumnGroups[3].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridControl.Columns["ESTATUS"]);
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridControl.Columns["fechacorte"]);
            this.gridControl.ViewDefinition = columnGroupsView;
        }
        protected override void OnRefrescar()
        {
            this.Cursor = Cursors.WaitCursor;
            OnBuscar();
            this.Cursor = Cursors.Default;
        }
        protected override void OnBuscar()
        {
            string flag = "M";

            //Capturar fechas
            string fecini = "";
            string fecfin = "";

            //Si no ha cargado por completo la pantalla no realiza ninguna accion
            if (!isLoaded) return;


            if (rbtMensual.CheckState == CheckState.Checked)
            {
                flag = "M";
            }
            else if (rbtAnual.CheckState == CheckState.Checked)
            {
                flag = "A";
            }
            else if (rbtHistorico.CheckState == CheckState.Checked)
            {
                flag = "H";
            }
            else if (rbtRangoFechas.CheckState == CheckState.Checked)
            {
                flag = "R";
                fecini = string.Format("{0:dd/MM/yyyy}", this.dtpFechaini.Value);
                fecfin = string.Format("{0:dd/MM/yyyy}", this.dtpFechafin.Value);
            }



            //base.OnBuscar();
            Cursor.Current = Cursors.WaitCursor;
            var lista = DocumentoLogic.Instance.RptMovimientosMP(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, flag, fecini, fecfin);            
            this.gridControl.DataSource = lista;
            Cursor.Current = Cursors.Default;
        }

        protected override void OnVista()
        {
            //string mensajeOut = string.Empty;
            string periodostock;
            var codigosSeleccionados = new string[gridControl.SelectedRows.Count];
            var x = 0;

            foreach (var filaSeleccionado in gridControl.SelectedRows)
            {
                //codigosSeleccionados[x] = (string)gridControl.Columns["CodigoEmpleado"].value((int) filaSeleccionado);
                codigosSeleccionados[x] = filaSeleccionado.Cells["IN07KEY"].Value.ToString();
                //e.CellElement.RowInfo.Cells["Title"].Value.ToString();
                x++;
            }


            Cursor.Current = Cursors.WaitCursor;

            //GlobalLogic.Instance.InsertarRangoImpresion(Logueo.CodigoEmpresa, "Admin", this.txtCodigoTipDoc.Text, this.txtNroDocumento.Text, out mensajeOut);
            var datos = DocumentoLogic.Instance.RptStockProdter(Logueo.CodigoEmpresa, "06", Logueo.Anio, Logueo.Mes, Util.ConvertiraXML(codigosSeleccionados));
            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();
            reporte.Nombre = "RptProterStock.rpt";
            reporte.DataSource = datos;


            periodostock = (Logueo.Mes + "" + Logueo.Anio);


            reporte.FormulasFields.Add(new Formula("periodostock", periodostock));
            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));

            ////reporte.ParametersFields.Add(new Paramentro("@CodEmp", Logueo.CodigoEmpresa));
            ////reporte.ParametersFields.Add(new Paramentro("@Ano", Logueo.Anio));
            ////reporte.ParametersFields.Add(new Paramentro("@Mes", Logueo.Mes));

            ReporteControladora control = new ReporteControladora(reporte);
            control.VistaPrevia(enmWindowState.Normal);

            Cursor.Current = Cursors.Default;

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OnBuscar();
            this.Cursor = Cursors.Default;
        }
        //protected override void OnSeleccionarTodo()
        //{
        //    gridControl.SelectAll();
        //}
       
    }
}
