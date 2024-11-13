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
    public partial class FrmRepMovimientos : frmBaseReporte
    {
        private bool isLoaded = false;
        ColumnGroupsViewDefinition columnGroupsView;
        private void FrmStockRep_Load(object sender, EventArgs e)
        {
            Crearcolumnas();
            isLoaded = true;
            OnBuscar();
            
        }
        private frmMDI FrmParent { get; set; }
        private static FrmRepMovimientos _aForm;

         public static FrmRepMovimientos Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmRepMovimientos(mdiPrincipal);
            _aForm = new FrmRepMovimientos(mdiPrincipal);
            return _aForm;
        }

        public FrmRepMovimientos(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            // Establecer el mes por defecto            
            rbtMensual.CheckState = CheckState.Checked;
            this.dtpFechaini.Value = DateTime.Now;
            this.dtpFechafin.Value = DateTime.Now;
            HabilitarBotones(true, true, true, false,true);

        }
        public FrmRepMovimientos()
        {
            InitializeComponent();            
        }

        private void Crearcolumnas()
        {


           RadGridView grilla =  this.CreateGrid(this.gridControl);
           grilla.ShowFilteringRow = true;
               
          
            this.CreateGridColumn(grilla, "Año", "IN07AA", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Mes", "IN07MM", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Cliente", "clientenombre", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Nro", "IN07PEDVEN", 0, "", 90, true, false, true);

            this.CreateGridColumn(grilla, "Tipo", "IN07TIPDOC", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "Nro", "IN07CODDOC", 0, "", 50, true, false, true);

            this.CreateGridColumn(grilla, "Codigo.", "IN07KEY", 0, "", 150, true, false, true);
            this.CreateGridColumn(grilla, "Item", "IN07ORDEN", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "IN01DESLAR", 0, "", 300, true, false, true);
            this.CreateGridColumn(grilla, "Uni Med", "IN07UNIMED", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Doc Fecha", "IN07FECDOC", 0, "{0:dd/MM/yyyy}", 90, true, false, true);
            this.CreateGridColumn(grilla, "Almacen", "IN07CODALM", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Doc.Res", "IN07CODTRA", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Doc.Res Nro", "IN06REFDOC", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "Transa", "IN07TRANSA", 0, "", 30, true, false, true);
            this.CreateGridColumn(grilla, "Caja Nro", "IN07NROCAJA", 0, "", 80, true, false, true,"center");
             this.CreateGridColumn(grilla, "Cantidad", "IN07CANART", 0, "{0:###,###0.00}", 50, true, false, true, "right");
             this.CreateGridColumn(grilla, "Area X Uni", "IN07AREAXUNI", 0, "{0:###,###0.000000}", 80, true, false, true, "right");
            this.CreateGridColumn(grilla, "Area", "area", 0, "{0:###,###0.00}", 80, true, false, true, "right");

            this.CreateGridColumn(grilla, "Año.", "IN07DocIngAA", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Mes", "IN07DocIngMM", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Tipo", "IN07DocIngTIPDOC", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Nro", "IN07DocIngCODDOC", 0, "", 50, true, false, true);


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

          //  crearGrupos();

        }
     
        protected override void OnBuscar()
        {
            string flag = "M";

                //Capturar fechas
            string fecini="";
            string fecfin="";

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

            var lista = DocumentoLogic.Instance.RptMovimientoDet(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, flag, fecini, fecfin);
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
            var datos = DocumentoLogic.Instance.RptStockProdter(Logueo.CodigoEmpresa,"06" ,Logueo.Anio, Logueo.Mes, Util.ConvertiraXML(codigosSeleccionados));
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
        protected override void OnRefrescar()
        {
            this.Cursor = Cursors.WaitCursor;
            OnBuscar();
            this.Cursor = Cursors.Default;
        }
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OnBuscar();
            this.Cursor = Cursors.Default;
        }
        protected override void OnSeleccionarTodo()
        {
            gridControl.SelectAll();
        }
        

    }

}