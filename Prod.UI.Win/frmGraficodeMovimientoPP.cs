using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.Pivot.Core;  //agegar --> LocalDataSourceProvider
using Telerik.Pivot.Core.Aggregates;  // agregar -> AggregateFunctions
using Inv.BusinessLogic;
using Telerik.WinControls.UI;
namespace Prod.UI.Win
{
    public partial class frmGraficodeMovimientoPP : Telerik.WinControls.UI.RadForm
    {

        LocalDataSourceProvider dataProvider = new LocalDataSourceProvider(); // varaible que sirve como un dt para nuestro pivot.
        private void construirPivot()
        {
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
            //string fecini = string.Format("{0:dd/MM/yyyy}", this.dtpFechaini.Value);
            string fecini = "01/01/2012";
            //string fecfin = string.Format("{0:dd/MM/yyyy}", this.dtpFechafin.Value);
            string fecfin = "28/04/2015";

            var lista = DocumentoLogic.Instance.RptMovimientoDetGrafico(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, "R", fecini, fecfin);

            dataProvider.ItemsSource = lista; // aca asigna todo la data a dataprovidar ( es como su datatable para el pivot )
            dataProvider.Culture = new System.Globalization.CultureInfo("es-ES");
            this.radPivotGrid1.DataProvider = dataProvider;  // esta linea entrega al informacion al pivot.
            this.radChartView1.DataSource = this.radPivotGrid1; // linea para generar el grafico con lso seleccioan en epivto.
            this.radChartView1.ShowToolTip = true;
            
            //ver titulo en el grafico
            this.radChartView1.Title = "GRAFICO DE MOVIMIENTOS";
            this.radChartView1.ShowTitle = true;
            this.radChartView1.ChartElement.TitleElement.TextOrientation = Orientation.Horizontal;
            this.radChartView1.ChartElement.TitlePosition = TitlePosition.Top;
            //this.radChartView1.ChartElement.TitleElement.FlipText = true;

            //leyendas
            this.radChartView1.ShowLegend = true;
            this.radChartView1.LegendTitle = "Cantidad de arnticulos";
            this.radChartView1.ChartElement.LegendElement.DrawBorder = false;
            
            //Label
            
            //this.radChartView1.Controllers.Add(new SmartLabelsController());
            this.radChartView1.ShowSmartLabels = true;
            
            //this.radChartView1.ShowTrackBall = true;
            //this.radChartView1.ShowStillIndicators = true;
        }
        public frmGraficodeMovimientoPP()
        {
            InitializeComponent();
            construirPivot();
        }
    }
}
