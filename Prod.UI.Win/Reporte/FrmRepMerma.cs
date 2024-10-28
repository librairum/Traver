using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using Telerik.WinControls.UI;

using Inv.BusinessLogic;
using Inv.BusinessEntities;

namespace Prod.UI.Win
{
    public partial class FrmRepMerma : frmBaseReporte
    {
        private frmMDI FrmParent { get; set; }
        private static FrmRepMerma _aForm;
        public static FrmRepMerma Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmRepMerma(mdiPrincipal);
            _aForm = new FrmRepMerma(mdiPrincipal);
            return _aForm;
        }
        private void CargarContratista()
        {
            List<CuentaCorriente> lista =  CuentaCorrienteLogic.Instance.CuentaCorrienteTraer(Logueo.CodigoEmpresa, "13");
            this.gridControl.DataSource = lista;
        }
        private void CargarPeriodos(RadDropDownList cbo)
        {
            try
            {
                var periodo = PeriodoLogic.Instance.MesesxAnio(Logueo.CodigoEmpresa, Logueo.Anio);
                cbo.DataSource = periodo;
                cbo.DisplayMember = "ccb03des";
                cbo.ValueMember = "ccb03cod";
                string anio = "";
                string mes = "";
                mes = DateTime.Now.Month.ToString("0#");
                anio = DateTime.Now.Year.ToString();
                cbo.SelectedValue = anio + mes;

            }
            catch (Exception)
            {

            }
        }
        private void CrearColumnas()
        { 
            RadGridView Grid = this.CreateGrid(this.gridControl);
            this.CreateGridColumn(Grid, "ccm02emp", "ccm02emp", 0, "", 70,  true, false, false);
            this.CreateGridColumn(Grid, "ccm02tipana", "ccm02tipana", 0, "", 70,  true, false, false);
            this.CreateGridColumn(Grid, "ccm02cod", "ccm02cod", 0, "", 100,  true, false, true);
            this.CreateGridColumn(Grid, "ccm02nom", "ccm02nom", 0, "", 250, true, false, true);
        }
        private void IniciarFormulario()
        {
            CargarPeriodos(this.cboperiodosini);
            CargarPeriodos(this.cboperiodosfin);
            rbPeriodo.CheckState = CheckState.Checked;
            CrearColumnas();
            CargarContratista();
        }
        public FrmRepMerma(frmMDI padre)
        {
            InitializeComponent();
            IniciarFormulario();
            
        }
        protected override void OnVista()
        {
            string cContratistaSeleccionado = Util.GetCurrentCellText(gridControl, "ccm02cod");
            string cFecIni = Util.convertiracadena(cboperiodosini.SelectedValue);
            string cFecFin = Util.convertiracadena(cboperiodosfin.SelectedValue);
            if (rbPeriodo.CheckState == CheckState.Checked)
            {
                cFecIni = Util.convertiracadena(cboperiodosini.SelectedValue);
                cFecFin = Util.convertiracadena(cboperiodosfin.SelectedValue);
            }
            else if (rbFecha.CheckState == CheckState.Checked)
            {
                cFecIni = Util.convertiracadena(dtpFechaini.Value.ToShortDateString());
                cFecFin = Util.convertiracadena(dtpFechafin.Value.ToShortDateString());
            }
            Cursor.Current = Cursors.WaitCursor;
            //GenerarReporteMerma(cContratistaSeleccionado, cFecIni, cFecFin); 
            GenerarReporteMermaBloque(cFecIni, cFecFin);
            Cursor.Current = Cursors.Default;
        }
        private string traercontratistas()
        {

            string[] registros = new string[this.gridControl.SelectedRows.Count];
            string result = "";
            int  x  = 0 ;
            foreach (GridViewRowInfo row in this.gridControl.SelectedRows)
            {
                registros[x] = Util.GetCurrentCellText(row, "ccm02cod");
                 x++;
            }
            result = Util.ConvertiraXMLdinamico(registros);
            return result;
        }
        private void GenerarReporteMerma(string cCodigoContratista, string paramFecIni, string paramFecFin)
        {
            //string pProdAcufecIni = "";
            //string pProdAcufecFin = "";

            //pProdAcufecIni = string.Format("{0}/{1}/{2}", "01", DateTime.Now.Month.ToString("0#"), DateTime.Now.Year);
            //pProdAcufecFin = this.dtpFechafin.Value.ToShortDateString();
            ReporteViewer reporte = new ReporteViewer("documento");
            reporte.RutaServidor = Logueo.GetPathServerrReportSSRS();
            reporte.Ruta = Logueo.GetDirectorySSRRS();
            reporte.Nombre = "RptRendimientoyMermaxBloque.rdl";

            // dataset 
            Paramentro pEmpresa = new Paramentro("Empresa", Logueo.CodigoEmpresa);
            reporte.ParametersFields.Add(pEmpresa);
            Paramentro pFecInicial = new Paramentro("fechaini", paramFecIni);
            reporte.ParametersFields.Add(pFecInicial);
            Paramentro pFecFinal = new Paramentro("fechafin", paramFecFin);
            reporte.ParametersFields.Add(pFecFinal);
            string xml = traercontratistas();
            Paramentro pContratistas = new Paramentro("", xml);
            reporte.ParametersFields.Add(pContratistas);

            ReporteViewerControladora controlsql = new ReporteViewerControladora(reporte);
            controlsql.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;

        }
        private void GenerarReporteMermaBloque(string paramFecIni, string paramFecFin)
        {
            //string pProdAcufecIni = "";
            //string pProdAcufecFin = "";

            //pProdAcufecIni = string.Format("{0}/{1}/{2}", "01", DateTime.Now.Month.ToString("0#"), DateTime.Now.Year);
            //pProdAcufecFin = this.dtpFechafin.Value.ToShortDateString();
            ReporteViewer reporte = new ReporteViewer("documento");
            reporte.RutaServidor = Logueo.GetPathServerrReportSSRS();
            reporte.Ruta = Logueo.GetDirectorySSRRS();
            reporte.Nombre = "RptRendimientoyMermaxBloque.rdl";

            // dataset 
            //Paramentro pEmpresa = new Paramentro("Empresa", Logueo.CodigoEmpresa);
            //reporte.ParametersFields.Add(pEmpresa);
            //Paramentro pFecInicial = new Paramentro("fechaini", paramFecIni);
            //reporte.ParametersFields.Add(pFecInicial);
            //Paramentro pFecFinal = new Paramentro("fechafin", paramFecFin);
            //reporte.ParametersFields.Add(pFecFinal);
            //string xml = traercontratistas();
            //Paramentro pContratistas = new Paramentro("", xml);
            //reporte.ParametersFields.Add(pContratistas);

            ReporteViewerControladora controlsql = new ReporteViewerControladora(reporte);
            controlsql.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;

        }
    }
}
