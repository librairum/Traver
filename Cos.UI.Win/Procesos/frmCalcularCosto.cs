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

namespace Cos.UI.Win
{
    public partial class frmCalcularCosto : frmBase
    {
        private frmMDI FrmParent { get; set; }
        private static frmCalcularCosto _aForm;
        public frmCalcularCosto(frmMDI padre)
        {
            InitializeComponent();           
            HabilitarBotones(false, false, false, false, true, false, true, false);
            CrearColumnas();
            OnBuscar();
            CrearColumnasGastosContables();
            OnBuscarGastosContables();
            CrearColumnasMovProduccion();
            OnBuscarMovProduccion();
        }
        public static frmCalcularCosto Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmCalcularCosto(mdiPrincipal);
            _aForm = new frmCalcularCosto(mdiPrincipal);
            return _aForm;
        }
        #region "DetalleCosto"
        private void CrearColumnas() { 
            RadGridView  Grid = this.CreateGridVista(this.gridControl);
                //
                this.CreateGridColumn(Grid, "Tipo Costo", "COS03TIPOCOSTODESC", 0, "", 100);
                this.CreateGridColumn(Grid, "Costo", "COS03COSTODESC", 0, "", 100);
                // Actividad
                this.CreateGridColumn(Grid, "Actividad", "ActividadDes", 0, "", 100);
                this.CreateGridColumn(Grid, "Actividad Imp.", "COS03IMPORTEACTIVIDAD", 0, "", 100);
                //OT
                this.CreateGridColumn(Grid, "OT", "COS03ORDENTRABAJO", 0, "", 100);
                this.CreateGridColumn(Grid, "OT Ratio", "COS03RATIOOTXACTIVIDAD", 0, "", 100);
                this.CreateGridColumn(Grid, "OT Importe", "COS03IMPORTEOTXACTIVIDAD", 0, "", 100);
                // Producto
                this.CreateGridColumn(Grid, "Producto", "COS03MOVPRODKEY", 0, "", 100);
                this.CreateGridColumn(Grid, "Producto Ratio", "COS03RATIOPRODUCTOXOT", 0, "", 100);
                this.CreateGridColumn(Grid, "Producto Imp", "COS03IMPORTEXPRODUCTOXOT", 0, "", 100);

                // Suma del importe
                GridViewSummaryItem summaryItem = new GridViewSummaryItem();
                summaryItem.Name = "COS03IMPORTEXPRODUCTOXOT";
                summaryItem.FormatString = "{0:###,###0.00}";
                summaryItem.Aggregate = GridAggregateFunction.Sum;

                GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
                summaryRowItem.Add(summaryItem);

                Grid.SummaryRowsBottom.Add(summaryRowItem);

                Grid.MasterTemplate.ShowTotals = true;
                Grid.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;

                
        }
        // el boton de refrescar se comportara como procesar
        protected override void OnRefrescar()
        {
            //Procesar
            ContabilidadGastosLogic.Instance.CalcularCostos(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                                    Logueo.CodigoLinea, Logueo.CodigoLoteCosto, "");

                       
            // Traer resultado del proceso
            OnBuscar();
        }
        
        protected override void OnBuscar()
        {
            List<CostosDetalle> lista = DocumentoLogic.Instance.TraerDetalleCostos(Logueo.CodigoEmpresa,
                                    Logueo.Anio, Logueo.Mes, Logueo.CodigoLinea, Logueo.CodigoLoteCosto);
            this.gridControl.DataSource = lista;
        }
        #endregion
        #region Gastos Contables
        private void OnBuscarGastosContables()
        {
            
            List<GastosContabilidad> lista = 
             ContabilidadGastosLogic.Instance.TraerContabilidadGastos(Logueo.CodigoEmpresa, Logueo.Anio,
                                                  Logueo.Mes, Logueo.CodigoLinea, Logueo.CodigoLoteCosto);
            
            this.gridGastosContables.DataSource = lista;
        }
        private void CrearColumnasGastosContables() {
            RadGridView GridView = this.CreateGridVista(this.gridGastosContables);
            this.CreateGridColumn(GridView, "Cod.ActConta", "COS01CODIGO", 0, "", 70, true, false, false);
            this.CreateGridColumn(GridView, "Act.Contable", "COS01DESCRIPCION", 0, "", 120);            
            this.CreateGridColumn(GridView, "Codigo", "COS01COSTOCOD", 0, "", 80, true, false, false);
            this.CreateGridColumn(GridView, "Descripcion", "COS01COSTODESC", 0, "", 120);
            this.CreateGridColumn(GridView, "Importe", "COS01IMPORTE", 0, "", 90);

            // Suma del importe
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "COS01IMPORTE";
            summaryItem.FormatString = "{0:###,###0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Sum;

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryItem);

            GridView.SummaryRowsBottom.Add(summaryRowItem);

            GridView.MasterTemplate.ShowTotals = true;
            GridView.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
        }
        #endregion
        #region Movimientos Produccion
        private void OnBuscarMovProduccion()
        {
            List<MovimientosProduccion> lista = DocumentoLogic.Instance.TraerImportarMovimientosProduccion(Logueo.CodigoEmpresa,
                                                        Logueo.Anio, Logueo.Mes, Logueo.CodigoLinea, Logueo.CodigoLoteCosto);
            this.gridMovProduccion.DataSource = lista;
        }
        private void CrearColumnasMovProduccion() {
            RadGridView GridView = this.CreateGridVista(this.gridMovProduccion);                                                                        
            this.CreateGridColumn(GridView, "Cod.Act.", "COS01RODACTNIV1COD", 0, "", 70, true, false, false);
            this.CreateGridColumn(GridView, "Actvidida", "PRO09DESC", 0, "", 120);
            this.CreateGridColumn(GridView, "OT", "COS01ORDENTRABAJO", 0, "", 60);
            this.CreateGridColumn(GridView, "Cod.Prod", "COS01MOVIPRODKEY", 0, "", 150);                        
            this.CreateGridColumn(GridView, "Cantidad", "COS01CANART", 0, "{0:###,###0.00}", 70);                        
        }
        #endregion
        protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;
            ReporteViewer reportesql = new ReporteViewer("Documento");
            reportesql.RutaServidor = Logueo.GetPathServerrReportSSRS(); // obtener el nombre de la carpeta donde esta nuestro reporte
            reportesql.Ruta = Logueo.GetDirectorySSRRS();
            reportesql.Nombre = "RptCuadroCostos";

            Paramentro pEmpresa = new Paramentro("COS03CODEMP", Logueo.CodigoEmpresa);
            reportesql.ParametersFields.Add(pEmpresa);
            Paramentro pAnio = new Paramentro("COS03ANIO", Logueo.Anio);
            reportesql.ParametersFields.Add(pAnio);
            Paramentro pMes = new Paramentro("COS03MES", Logueo.Mes);
            reportesql.ParametersFields.Add(pMes);
            Paramentro pLinea = new Paramentro("COS03LINEA", Logueo.CodigoLinea);
            reportesql.ParametersFields.Add(pLinea);
            Paramentro pLote = new Paramentro("CO03LOTE", Logueo.CodigoLoteCosto);
            reportesql.ParametersFields.Add(pLote);

            ReporteViewerControladora controlsql = new ReporteViewerControladora(reportesql);
            controlsql.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;
        }
    }
}
