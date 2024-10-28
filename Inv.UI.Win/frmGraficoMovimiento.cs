using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.Pivot.Core;  //agegar
using Telerik.WinControls.UI;
using Inv.BusinessEntities;
using Inv.BusinessLogic;
using Telerik.Pivot.Core.Aggregates; // agrega 
using System.Drawing.Drawing2D; 
using System.Drawing;
namespace Inv.UI.Win
{
    public partial class frmGraficoMovimiento : Telerik.WinControls.UI.RadForm
    {
        LocalDataSourceProvider dataProvider = new LocalDataSourceProvider(); // varaible que sirve como un dt para nuestro pivot.
        //dataProvider.ItemsSource = dataset.Orders;
        private bool isLoaded = false;
        
        public frmGraficoMovimiento()
        {
            
            InitializeComponent();
            construirPivot();
            cargarDatos();
            this.radChartView1.DataSource = this.radPivotGrid1; // linea para generar el grafico con lso seleccioan en epivto.
            this.radChartView1.ShowToolTip = true;
            isLoaded = true;
            /*
             Movimiento Producto Terminado (Cubo)
                -Row: Transaccion , Año , Mes
                -Columnas : Almacen , Doc.Transac
                -Campo a sumar : Area
             */

        }
        private void construirPivot() {
            dataProvider.BeginInit();
             //Filas 
            dataProvider.RowGroupDescriptions.Add(new PropertyGroupDescription() { PropertyName = "IN07TRANSA", CustomName = "Transaccion", GroupComparer = new GroupNameComparer() });
            dataProvider.RowGroupDescriptions.Add(new PropertyGroupDescription() { PropertyName = "in12DesLar", CustomName = "Doc.Trans", GroupComparer = new GroupNameComparer() });
            dataProvider.RowGroupDescriptions.Add(new DateTimeGroupDescription() { PropertyName = "IN07FECDOC", Step = DateTimeStep.Year, GroupComparer = new GroupNameComparer() });
            //dataProvider.RowGroupDescriptions.Add(new DateTimeGroupDescription() { PropertyName = "IN07FECDOC", Step = DateTimeStep.Quarter, GroupComparer = new GroupNameComparer() });
            //dataProvider.RowGroupDescriptions.Add(new DateTimeGroupDescription() { PropertyName = "IN07FECDOC", Step = DateTimeStep.Month, GroupComparer = new GroupNameComparer() });
            dataProvider.EndInit();

            //Columnas del pivot
            dataProvider.BeginInit();
            dataProvider.ColumnGroupDescriptions.Add(new PropertyGroupDescription() { PropertyName = "IN07CODALM", GroupComparer = new GrandTotalComparer() }); // no tengo mucha idea de que significa el resto de parametor , pero aca en mi columnha indique desea ver codigo de almacen
            dataProvider.EndInit();

            //campo resumido
            dataProvider.BeginInit();
            dataProvider.AggregateDescriptions.Add(new PropertyAggregateDescription() { PropertyName = "IN07CANART", AggregateFunction = AggregateFunctions.Sum });
            // no tengo mucha idea de que significa el resto de parametor , pero aca en mi columnha indique desea ver cantidad dar ticolos
            dataProvider.EndInit();
            //this.radPivotGrid1.ChartDataProvider.IncludeColumnSubTotals = true; // mostrar subtotal por 
            //this.radPivotGrid1.ChartDataProvider.IncludeRowSubTotals = true; // mostrar fila de subtotales
            //this.radPivotGrid1.ChartDataProvider.IncludeColumnGrandTotals = true; // incluir columan de total de todo 
            //this.radPivotGrid1.ChartDataProvider.IncludeRowSubTotals = true; // incluir fila de subttoaol
            
            //dataProvider.Culture = new System.Globalization.CultureInfo("es-ES"); 
        }
        void cargarDatos() {
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
            Cursor.Current = Cursors.WaitCursor;

            var lista = DocumentoLogic.Instance.RptMovimientoDetGrafico(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, flag, fecini, fecfin);

            dataProvider.ItemsSource = lista; // aca asigna todo la data a dataprovidar ( es como su datatable para el pivot )



            //this.gridControl.DataSource = lista;
            Cursor.Current = Cursors.Default;

            this.radPivotGrid1.DataProvider = dataProvider;  // esta linea entrega al informacion al pivot.
        }
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            cargarDatos();
            
            
        }

        private void btnVista_Click(object sender, EventArgs e)
        {
            this.radPivotGrid1.PrintPreview();
        }

        private void radPivotGrid1_PrintElementFormatting(object sender, PrintElementEventArgs e)
        {
            PivotCellPrintElement cell = e.PrintElement as PivotCellPrintElement;
            if(cell != null && cell.Value != null && (Convert.ToDouble(cell.Value)) < 2000)
            {
	            cell.BackColor = Color.Yellow;
            }

            if(cell != null && cell.Value != null && (Convert.ToDouble(cell.Value)) > 3000)
            {
	            cell.BackColor = Color.Lavender;
            }
        }

        private void radPivotGrid1_PrintElementPaint(object sender, PrintElementPaintEventArgs e)
        {
            PivotCellPrintElement cell = e.PrintElement as PivotCellPrintElement;
            if(cell != null && cell.Value != null)
            {

	            if((Convert.ToDouble(cell.Value)) > 2000 && ((Convert.ToDouble(cell.Value)) < 3000))
	            { 
		            Brush b = new HatchBrush(HatchStyle.BackwardDiagonal, Color.DarkGray, Color.Transparent);
                    e.Graphics.FillRectangle(b, e.Bounds);		            
	            }

            }
        }
    }
}
