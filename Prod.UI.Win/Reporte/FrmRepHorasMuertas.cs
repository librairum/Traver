﻿using System;
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
    public partial class FrmRepHorasMuertas : frmBaseReporte
    {

        private frmMDI FrmParent { get; set; }
        private static FrmRepHorasMuertas _aForn;
        public static FrmRepHorasMuertas Instance(frmMDI mdiPrincipal)
        {
            if (_aForn != null) return new FrmRepHorasMuertas(mdiPrincipal);
            _aForn = new FrmRepHorasMuertas(mdiPrincipal);
            return _aForn;
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
        private void IniciarFormulario()
        {
            CargarPeriodos(cboperiodosini);
            CargarPeriodos(cboperiodosfin);
            CargarLineas(cboLineas);
            cboperiodosini.SelectedValue = Logueo.Mes;
            cboperiodosfin.SelectedValue = Logueo.Mes;
            dtpFechaini.Value = DateTime.Now;
            dtpFechafin.Value = DateTime.Now;
            rbPeriodo.CheckState = CheckState.Checked;
            CrearColumnas();
        }

        protected override void OnVista()
        {
            try
            {
                if (gridControl.SelectedRows.Count > 1)
                {
                    RadMessageBox.Show("No puede seleccionar mas de una actividad", "Sistema", MessageBoxButtons.OK,
                                        RadMessageIcon.Error);
                    return;
                }
                

                //Llenar XML
                string[] seleccionados = new string[this.gridControl.SelectedRows.Count];
                int x = 0;
                foreach (var r in gridControl.SelectedRows)
                {
                    seleccionados[x] = r.Cells["codigo"].Value.ToString();
                    x++;
                }

                Cursor.Current = Cursors.WaitCursor;

                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                DataTable datos = null;
                string fecini = "";
                string fecfin = "";

                if (rbFecha.IsChecked)
                {
                    fecini = dtpFechaini.Value.ToString();
                    fecfin = dtpFechafin.Value.ToString();
                }
                else
                {
                    fecini = cboperiodosini.SelectedValue.ToString();
                    fecfin = cboperiodosfin.SelectedValue.ToString();
                }
                
                
                reporte.Nombre = "RptHorasMuerta.rpt";
                

                string cEmpresa = Logueo.CodigoEmpresa;
                string cAnio = Logueo.Anio;
                string cLinea = Util.convertiracadena(this.cboLineas.SelectedValue);
                string cFecIni = fecini; string cFecFin = fecfin;

                string cFlag = rbFecha.IsChecked ? "R" : "P";
                datos = HoraMuertaDetalleLogic.Instance.TraerReporteHoraMuerta(cEmpresa, cAnio, cLinea, cFecIni, 
                                                               cFecFin, cFlag, Util.ConvertiraXML(seleccionados));
                reporte.DataSource = datos;
                string cTitulo = "Reporte de Horas Muertas";
                string cSubTitulo = "De " + cFecIni + " Al " + cFecFin;
                reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                reporte.FormulasFields.Add(new Formula("Anio", Logueo.Anio));
                reporte.FormulasFields.Add(new Formula("titulo", cTitulo));
                reporte.FormulasFields.Add(new Formula("subtitulo", cSubTitulo));
                ReporteControladora controles = new ReporteControladora(reporte);
                controles.VistaPrevia(enmWindowState.Normal);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema");
            }
        }

        public FrmRepHorasMuertas(frmMDI padre)
        {
            InitializeComponent();
            IniciarFormulario();

        }

        private void cboLineas_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLineas.SelectedValue == null) return;
            var actividaddes = ActividadNivel1Logic.Instance.ActividadNivel1TraerAyuda(Logueo.CodigoEmpresa,
                               cboLineas.SelectedValue.ToString());
            this.gridControl.DataSource = actividaddes;
        }

    }
}