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

namespace Prod.UI.Win
{
    public partial class FrmRepControlProduccion : frmBaseReporte
    {
        public FrmRepControlProduccion(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            IniciarFormulario();
        }
        private frmMDI FrmParent { get; set; }
        private static FrmRepControlProduccion _aForm;
        public static FrmRepControlProduccion Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmRepControlProduccion(mdiPrincipal);
            _aForm = new FrmRepControlProduccion(mdiPrincipal);
            return _aForm;
        }

        private void IniciarFormulario()
        {
            CargarLineas(cboLineas);
            dtpFechaini.Value = DateTime.Now;
            dtpFechafin.Value = DateTime.Now;
            rbFecha.CheckState = CheckState.Checked;
            CrearColumnas();

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
            catch (Exception ex)
            {                
                Util.ShowError(ex.Message);
            }
        }
        
        private void CargarLineas(RadDropDownList cbo)
        {
            var lineas = LineaLogic.Instance.LineaAyuda(Logueo.CodigoEmpresa);
            cbo.DataSource = lineas;

            cbo.ValueMember = "codigo";
            cbo.DisplayMember = "descripcion";

        }
        private void CrearColumnas()
        {
            RadGridView Grid = this.CreateGrid(gridControl);
            CreateGridColumn(Grid, "Codigo", "codigo", 0, "", 80);
            CreateGridColumn(Grid, "Descripcion", "descripcion", 0, "", 120);
        }

        protected override void OnVista()
        {
            if (gridControl.SelectedRows.Count > 1)
            {
                RadMessageBox.Show("No puede seleccionar mas de una actividad", "Sistema", MessageBoxButtons.OK,
                                    RadMessageIcon.Error);
                return;
            }
            cargarReporte();
            
        }

        private void cboLineas_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLineas.SelectedValue == null) return;
            var actividaddes = ActividadNivel1Logic.Instance.ActividadNivel1TraerAyuda(Logueo.CodigoEmpresa,
                               cboLineas.SelectedValue.ToString());
            this.gridControl.DataSource = actividaddes;
        }

        private void rbTipoActividad_CheckStateChanged(object sender, EventArgs e)
        {
            if (rbTipoActividad.CheckState == CheckState.Checked)
            {
                this.cboLineas.Enabled = true;
                this.gridControl.Enabled = true;
                this.dtpFechaini.Value = DateTime.Now;
                this.dtpFechafin.Value = DateTime.Now;
            }
        }

        private void rbTipoCorte_CheckStateChanged(object sender, EventArgs e)
        {
            if (rbTipoCorte.CheckState == CheckState.Checked)
            {
                this.cboLineas.Enabled = false;
                this.gridControl.Enabled = false;
                this.dtpFechaini.Value = DateTime.Now;
                this.dtpFechafin.Value = DateTime.Now;
                // Fecha inicial es Fecha Fin - 30 dias
                this.dtpFechaini.Value = this.dtpFechaini.Value.AddDays(-30);

            }
            
        }

        private void rbTipoLinea_CheckStateChanged(object sender, EventArgs e)
        {
            if (rbTipoLinea.CheckState == CheckState.Checked)
            {
                this.cboLineas.Enabled = false;
                this.gridControl.Enabled = false;
                this.dtpFechaini.Value = DateTime.Now;
                this.dtpFechafin.Value = DateTime.Now;
                // Fecha inicial es Fecha Fin - 30 dias
                this.dtpFechaini.Value = this.dtpFechaini.Value.AddDays(-30);
            }
        }
        private void GenerarReporteProdAlmacen(string paramActNivel, string paramFecIni, string paramFecFin)
        {
            // fecha de acumulado del mes
            string pProdAcufecIni = "";
            string pProdAcufecFin = "";

            pProdAcufecIni = string.Format("{0}/{1}/{2}", "01", DateTime.Now.Month.ToString("0#"), DateTime.Now.Year);
            pProdAcufecFin = this.dtpFechafin.Value.ToShortDateString();

            //            C#: 
            //            net
            //NetworkCredential credentials = new NetworkCredential();

            //credential.UserName = “Tu Usuario”; 
            //credential.Password = “Su Password”; 
            //credential.Domain   = “Su dominio”;  

            ReporteViewer reporte = new ReporteViewer("documento");
            reporte.RutaServidor = Logueo.GetPathServerrReportSSRS();
            reporte.Ruta = Logueo.GetDirectorySSRRS();
            reporte.Nombre = "produccionxalmacenConParam";
            // dataset 
            Paramentro pEmpresa = new Paramentro("IN07CODEMP", Logueo.CodigoEmpresa);
            reporte.ParametersFields.Add(pEmpresa);

            Paramentro pLinea = new Paramentro("in06prodlineacod", cboLineas.SelectedValue.ToString());
            reporte.ParametersFields.Add(pLinea);
            Paramentro pActividad = new Paramentro("in06prodActiNivel1Cod", paramActNivel);
            reporte.ParametersFields.Add(pActividad);
            // Dataset3 -> Produccion Ultimo 30 dias o entre fecha
            Paramentro pFecInicial = new Paramentro("fechaIni", paramFecIni);
            reporte.ParametersFields.Add(pFecInicial);
            Paramentro pFecFinal = new Paramentro("fechaFin", paramFecFin);
            reporte.ParametersFields.Add(pFecFinal);


            // Dataset6 -> Produccion mensual acumualdo
            Paramentro pEmpresa1 = new Paramentro("IN07CODEMP1", Logueo.CodigoEmpresa);
            reporte.ParametersFields.Add(pEmpresa1);
            Paramentro pLinea1 = new Paramentro("in06prodlineacod1", cboLineas.SelectedValue.ToString());
            reporte.ParametersFields.Add(pLinea1);
            Paramentro pActividad1 = new Paramentro("in06prodActiNivel1Cod1", paramActNivel);
            reporte.ParametersFields.Add(pActividad1);

            // Fecha formateado
            Paramentro pAcumuladoFecInicial = new Paramentro("fechaIni1", pProdAcufecIni);
            reporte.ParametersFields.Add(pAcumuladoFecInicial);
            Paramentro pAcumuladoFecFinal = new Paramentro("fechaFin1", pProdAcufecFin);
            reporte.ParametersFields.Add(pAcumuladoFecFinal);

            ReporteViewerControladora controlsql = new ReporteViewerControladora(reporte);
            controlsql.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;
        }
        private void GenerarReporteProdxCorte(string paramActNivel, string paramFecIni, string paramFecFin)
        {
            ReporteViewer reporte = new ReporteViewer("documento");
            reporte.RutaServidor = Logueo.GetPathServerrReportSSRS();
            reporte.Ruta = Logueo.GetDirectorySSRRS();
            reporte.Nombre = "produccionalmacenCorteConParam";
            //dsConsumoCorteVsIngBloques

            Paramentro pEmpresa = new Paramentro("IN07CODEMP", Logueo.CodigoEmpresa);
            reporte.ParametersFields.Add(pEmpresa);
            
            Paramentro pFechaFin = new Paramentro("Fechafin", paramFecFin);
            reporte.ParametersFields.Add(pFechaFin);

            //ds:ReporteProdMesCorte
            Paramentro pEmpresa2 = new Paramentro("IN07CODEMP2", Logueo.CodigoEmpresa);
            reporte.ParametersFields.Add(pEmpresa2);

            Paramentro pIn06prodlineacod2 = new Paramentro("in06prodlineacod2", cboLineas.SelectedValue.ToString());
            reporte.ParametersFields.Add(pIn06prodlineacod2);

            Paramentro pIn06prodActiNivel1Cod2 = new Paramentro("in06prodActiNivel1Cod2", paramActNivel);
            reporte.ParametersFields.Add(pIn06prodActiNivel1Cod2);

            Paramentro pfechaFin2 = new Paramentro("fechaFin2", paramFecFin);
            reporte.ParametersFields.Add(pfechaFin2);

            //ds:ReporteProdCorte
            Paramentro pIN07CODEMP1 = new Paramentro("IN07CODEMP1", Logueo.CodigoEmpresa);
            reporte.ParametersFields.Add(pIN07CODEMP1);

            Paramentro pin06prodlineacod1 = new Paramentro("in06prodlineacod1", cboLineas.SelectedValue.ToString());
            reporte.ParametersFields.Add(pin06prodlineacod1);

            Paramentro pin06prodActiNivel1Cod1 = new Paramentro("in06prodActiNivel1Cod1", paramActNivel);
            reporte.ParametersFields.Add(pin06prodActiNivel1Cod1);

            Paramentro pfechaIni1 = new Paramentro("fechaIni1", paramFecIni);
            reporte.ParametersFields.Add(pfechaIni1);

            Paramentro pfechaFin1 = new Paramentro("fechaFin1", paramFecFin);
            reporte.ParametersFields.Add(pfechaFin1);

            ReporteViewerControladora controlsql = new ReporteViewerControladora(reporte);
            controlsql.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;
        }
        private void cargarReporte()
        {
            // fecha para reporte de produccion ultimo 30 dias
            string pFecIni = "";
            string pFecFin = "";
            pFecIni = this.dtpFechaini.Value.ToShortDateString();
            pFecFin = this.dtpFechafin.Value.ToShortDateString();
            string plinea = Util.convertiracadena(cboLineas.SelectedValue);
            string pActNivel = "";
            if (rbTipoLinea.CheckState == CheckState.Checked)
            {
                pActNivel = Constantes.ReporteControlProduccion.CodActLinea;
                
            }
            else if (rbTipoCorte.CheckState == CheckState.Checked)
            {
                pActNivel = Constantes.ReporteControlProduccion.CodActCorte;
            }
            else if (rbTipoActividad.CheckState == CheckState.Checked)
            {
                pActNivel = Util.convertiracadena(this.gridControl.CurrentRow.Cells["codigo"].Value);
            }

            if (rbTipoLinea.CheckState == CheckState.Checked)
            {
                GenerarReporteProdAlmacen(pActNivel, pFecIni, pFecFin);
            }
            else if (rbTipoActividad.CheckState == CheckState.Checked)
            {
                GenerarReporteProdAlmacen(pActNivel, pFecIni, pFecFin);
            }
            else if (rbTipoCorte.CheckState == CheckState.Checked)
            {
                GenerarReporteProdxCorte(pActNivel, pFecIni, pFecFin);
            }
            
            

        }

    }
}
