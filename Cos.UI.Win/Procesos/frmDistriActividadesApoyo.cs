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
    public partial class frmDistriActividadesApoyo : frmBaseMante
    {
        TasasDistribucion distribucion;
        private frmMDI FrmParent { get; set; }
        private static frmDistriActividadesApoyo _aForm;
        public static frmDistriActividadesApoyo Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmDistriActividadesApoyo(mdiPrincipal);
            _aForm = new frmDistriActividadesApoyo(mdiPrincipal);
            return _aForm;
        }

        public frmDistriActividadesApoyo(frmMDI padre)
        {
            InitializeComponent();
            HabilitarBotones(false, false, false, true, false,true);
            //
            CrearColumnasActividadesApoyo();
            CrearColumnasActividadesPrincipal();
            CrearColumnasActDistribuidas();
            //
            CargarActividadesApoyo();

            CargarActividadesDistribuidas();
        }

       
        private void CrearColumnasActividadesApoyo() {
            RadGridView Grid = this.CreateGridVista(this.gridActApoyo);
            this.CreateGridColumn(Grid, "Codigo", "COS01CODIGO", 0, "", 60);
            this.CreateGridColumn(Grid, "Descripcion", "COS01DESCRIPCION", 0, "", 250);
        }
        private void CrearColumnasActividadesPrincipal() { 
            RadGridView Grid = this.CreateGridVista(this.gridActPrincipal);
            this.CreateGridColumn(Grid, "Codigo", "CODCTAPRINCIPAL", 0, "", 60);
            this.CreateGridColumn(Grid, "Descripcion", "DESCTAPRINCIPAL", 0, "", 250);
            this.CreateGridColumn(Grid, "Tasa", "COS01TASA", 0, "", 120, false, true, true, true);
            
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "COS01TASA";
            //summaryItem.FormatString = "{0:###,##0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Sum;

            GridViewSummaryRowItem rowItem = new GridViewSummaryRowItem() { summaryItem };
            Grid.SummaryRowsBottom.Add(rowItem);
            Grid.MasterTemplate.ShowTotals = true;
            Grid.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
        }
        private void CrearColumnasActDistribuidas() {
            					

            RadGridView Grid = this.CreateGridVista(this.gridActDistribuida);

            this.CreateGridColumn(Grid, "Flag Distribucion", "FlagDistribucion", 0, "", 80);
            this.CreateGridColumn(Grid, "Act.Origen Cod", "COS01ACTIVIDADORIGEN", 0, "", 80);
            this.CreateGridColumn(Grid, "Act origen Desc", "COS01ACTIVIDADORIGENDESC", 0, "", 150);
            this.CreateGridColumn(Grid, "Act origen Imp.", "COS01IMPORTEORIGINAL", 0, "{0:###,##0.00}", 80, true, false, true, true);
            //this.CreateGridColumn(Grid, "TipoCosto", "COS01TIPOCOSTO", 0, "", 50);
            //this.CreateGridColumn(Grid, "COS01COSTO", "COS01COSTO", 0, "", 50);

            this.CreateGridColumn(Grid, "Act.Destino Cod", "COS01ACTIVIDADDESTINO", 0, "", 80);
            this.CreateGridColumn(Grid, "Act.Destino Cod", "COS01ACTIVIDADDESTINODESC", 0, "", 150);
            this.CreateGridColumn(Grid, "Act.Destino %", "COS01PORCENTAJE", 0, "{0:###,##0.00}", 80, true, false, true, true);
            this.CreateGridColumn(Grid, "Act.Destino Imp", "COS01IMPORTE", 0, "{0:###,##0.00}", 80, true, false, true, true);

            // Suma del importe
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "COS01IMPORTE";
            summaryItem.FormatString = "{0:###,###0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Sum;

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryItem);

            Grid.SummaryRowsBottom.Add(summaryRowItem);

            Grid.MasterTemplate.ShowTotals = true;
            Grid.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            									
        }
        private void GuardarDistribucion(List<ActividadesContable> lista) { 
            
        }
        private void CrearColumnasActividadDistribuidas() { }
        
        private void CargarActividadesApoyo() {
            var actapoyo = ActividadesContableLogic.Instance.TraerActividadesContablexTipo(Logueo.CodigoEmpresa, Logueo.ActContableTipo);
            this.gridActApoyo.DataSource = actapoyo;
        }

        private void CargarActividadesPrincipal(string CodigoActividadApoyo)
        {            
            var actprincipal = TasasDistribucionLogic.Instance.TraerDistribucionActividades(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                Logueo.CodigoLinea, Logueo.CodigoLoteCosto,CodigoActividadApoyo, Logueo.CodigoLinea);

            this.gridActPrincipal.DataSource = actprincipal;
        }

        private void CargarActividadesDistribuidas()
        {
            var gastosdistri = TasasDistribucionLogic.Instance.TraerGastosDistribuidos(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
            Logueo.CodigoLinea, Logueo.CodigoLoteCosto);

            this.gridActDistribuida.DataSource = gastosdistri;
        }

        

        
        private bool ValidarDistribucion() {

            //int total = Convert.ToInt32(this.gridActPrincipal.MasterView.SummaryRows[0].Cells[1].Value);
            if (this.gridActPrincipal.Rows.Count == 0) {
                ShowAlertExclamation("Sistema", "No existe actividades principales relacionado");
                return false;
            }
            if (totalDistribucion < 100) {
                ShowAlertExclamation("Sistema", "Completar la distribucion a 100%");
                return false;
            }
            if (totalDistribucion > 100) {
                ShowAlertExclamation("Sistema", "Distribucion excede a 100%");
                return false;
            }
            return true;
        }
        protected override void OnGuardar()
        {
            try
            {

                distribucion = new TasasDistribucion();
                if (!ValidarDistribucion()) return;
                for (int i = 0; i < this.gridActPrincipal.Rows.Count; i++)
                {
                    distribucion.COS01CODEMP = Logueo.CodigoEmpresa;
                    distribucion.COS01ANIO = Logueo.Anio;
                    distribucion.COS01MES = Logueo.Mes;
                    distribucion.COS01LINEA = Logueo.CodigoLinea;
                    distribucion.COS01LOTE = Logueo.CodigoLoteCosto;
                    distribucion.COS01ACTAPOYO = this.gridActApoyo.CurrentRow.Cells["COS01CODIGO"].Value.ToString();
                    distribucion.COS01ACTPRINCIPAL = this.gridActPrincipal.Rows[i].Cells["CODCTAPRINCIPAL"].Value.ToString();
                    distribucion.COS01TASA = Convert.ToDouble(this.gridActPrincipal.Rows[i].Cells["COS01TASA"].Value);
                   
                    int cantidadRegistros = 0;
                    TasasDistribucionLogic.Instance.TraerCantidadRegistros(distribucion, out cantidadRegistros);

                    string mensaje = string.Empty;
                    int flag = 0;
                    if (cantidadRegistros == 0)
                    {
                        TasasDistribucionLogic.Instance.InsertarTasasDsitribucion(distribucion, out mensaje, out flag);
                    }
                    else
                    {
                        TasasDistribucionLogic.Instance.ActualizarTasasDistribucion(distribucion, out mensaje, out flag);
                    }
                }
                ShowAlertOk("Sistema", "Registro guardado");
            }
            catch (Exception ex) {
                ShowAlertError("Sistema", ex.Message);
            }
            string codigoApoyo = this.gridActApoyo.CurrentRow.Cells["COS01CODIGO"].Value.ToString();
            CargarActividadesPrincipal(codigoApoyo);
        }
        private int totalDistribucion = 0;
        private void gridActPrincipal_GroupSummaryEvaluate(object sender, GroupSummaryEvaluationEventArgs e)
        {
            if (e.SummaryItem.Name == "COS01TASA")
            {
                totalDistribucion = Convert.ToInt32(e.Value);
            }
            
        }
        
        private void gridActApoyo_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                if (e.CurrentRow == null) return;
                if (e.CurrentRow.Cells["COS01CODIGO"] == null) return;
                if (e.CurrentRow.Cells["COS01CODIGO"].Value == null) return;
                string codigoApoyo = this.gridActApoyo.CurrentRow.Cells["COS01CODIGO"].Value.ToString();
                CargarActividadesPrincipal(codigoApoyo);
            }
            catch (Exception ex ) { }
            
        }

        private void gridActPrincipal_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            //if (totalDistribucion >100)
            //{ e.Cancel = true; }
            //else { e.Cancel = false; }

        }


        
        private void btnGrabarDistribuir_Click(object sender, EventArgs e)
        {
            
        }
        private void GenerarDistribucion() {
            TasasDistribucionLogic.Instance.GenerarDistribucion(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                                                                           Logueo.CodigoLinea, Logueo.CodigoLoteCosto);
        }
        private void btnDistribuir_Click(object sender, EventArgs e)
        {
            //Traer los actividaddes principales x Actividad de Apoyo
     
            //Validar todos las actividades de apoyo debe ser asignado con un porcentaje de distribucion.
            if (this.gridActDistribuida.Rows.Count > 0)
            {
                DialogResult res;
                ShowAlertQuestion("Sistema", "Las actividades distribuidos se eliminara ¿Desea continuar?", out res);
                if (res == System.Windows.Forms.DialogResult.Yes) {
                    GenerarDistribucion();
                }
            }
            else {
                GenerarDistribucion();
            }
            

            // Traer los resultados de la distribucion
            CargarActividadesDistribuidas();
        }

        protected override void OnVista()
        {
            ReporteViewer reportesql = new ReporteViewer("Documento");
            reportesql.RutaServidor = Logueo.GetPathServerrReportSSRS();
            reportesql.Ruta = Logueo.GetDirectorySSRRS();
            reportesql.Nombre = "RptCostActConVsActProd";
            // agregar parametros de entradas

            Paramentro pEmpresa = new Paramentro("COS01CODEMP", Logueo.CodigoEmpresa);
            reportesql.ParametersFields.Add(pEmpresa);

            Paramentro pAnio = new Paramentro("COS01ANIO", Logueo.Anio);
            reportesql.ParametersFields.Add(pAnio);

            Paramentro pMes = new Paramentro("COS01MES", Logueo.Mes);
            reportesql.ParametersFields.Add(pMes);

            Paramentro pLinea = new Paramentro("COS01LINEA", Logueo.CodigoLinea);
            reportesql.ParametersFields.Add(pLinea);

            Paramentro pLote = new Paramentro("COS01LOTE", Logueo.CodigoLoteCosto);
            reportesql.ParametersFields.Add(pLote);
            
            ReporteViewerControladora controlsql = new ReporteViewerControladora(reportesql);
            controlsql.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;
        }

    }
}
