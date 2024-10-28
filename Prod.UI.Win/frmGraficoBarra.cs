using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.Charting;
using Inv.BusinessLogic;
namespace Prod.UI.Win
{
    public partial class frmGraficoBarra : Telerik.WinControls.UI.RadForm
    {
        public frmGraficoBarra()
        {
            InitializeComponent();
            //LinearAxis verticalAxis = new LinearAxis();
            //verticalAxis.AxisType = AxisType.Second;
            //CategoricalAxis horizontalAxis = new CategoricalAxis();

            //BarSeries barra = null;
            //for(int i = 2005; i < 2016; i++){
            //    barra = new BarSeries("Cantidad", "Naturaleza");
            //    barra.Name = "Test" + i.ToString();
            //    barra.HorizontalAxis = horizontalAxis;
            //    barra.VerticalAxis = verticalAxis;
            //    barra.DataSource = ArticuloLogic.Instance.TraerArticulosxNaturaleza(i.ToString());
            //    this.radChartView1.Series.Add(barra);
            //}
            
            //this.radChartView1.ShowGrid = false;
            //this.radChartView1.ShowToolTip = true;

        }
        //construir pivot
        void loadPivot() { 
            
        }

        private void frmGraficoBarra_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'premium_DeisiProd0707DataSet.in07movi' table. You can move, or remove it, as needed.
            this.in07moviTableAdapter.Fill(this.premium_DeisiProd0707DataSet.in07movi);
            this.radPivotGrid1.ChartDataProvider.GeneratedSeriesType = Telerik.WinControls.UI.GeneratedSeriesType.Bar;
            this.radChartView1.DataSource = this.radPivotGrid1;
        }
    }
}
