using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessEntities;
using Inv.BusinessLogic;
using Telerik.WinControls.UI;

namespace Prod.UI.Win
{
    public partial class FrmRepErroresComunes : frmBaseReporte
    {
        private bool isLoaded = true;
        private frmMDI FrmParent { get; set; }
        private static FrmRepErroresComunes _aForm;
        public static FrmRepErroresComunes Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmRepErroresComunes(mdiPrincipal);
            _aForm = new FrmRepErroresComunes(mdiPrincipal);
            return _aForm;
        }
        public FrmRepErroresComunes(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            CrearColumnas();
            OnBuscar();
            //Cargar();
            CargarPeriodos(cboperiodosini);
            CargarPeriodos(cboperiodosfin);
            //cboperiodosini.SelectedValue = Logueo.Mes;
            //cboperiodosfin.SelectedValue = Logueo.Mes;
            dtpfechaIni.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
        }

        //private void Cargar()
        //{
        //    List<CuentaCorriente> lista =  CuentaCorrienteLogic.Instance.Glo_Traer_CuentasCorrientes(Logueo.CodigoEmpresa, 
        //                                                                                                 "14", "ccm02cod");
        //    this.gridControl.DataSource = lista;
        //}
        protected override void OnBuscar()
        {

            List<ErroresComunes> lista = ErroresComunesLogic.Instance.ListarErroresTodos(Logueo.CodigoEmpresa, "", "*");
            this.gridControl.DataSource = lista;
        }
        protected override void OnVista()
        {
            string flagTipo = "";
            string flagfecha = "";
            try
            {
                
             
                if (rbFecha.IsChecked)
                {
                    flagfecha = "P";
                }
                else if (rbPeriodo.IsChecked)
                {
                    flagfecha = "P";
                }
                string[] seleccionados = new string[this.gridControl.SelectedRows.Count];
                int x = 0;
                foreach (var r in gridControl.SelectedRows)
                {
                    seleccionados[x] = Util.convertiracadena(r.Cells["PRO10CODIGO"].Value);
                    x++;
                }
                Cursor.Current = Cursors.WaitCursor;
                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                DataTable datos = null;
                string fecini = "";
                string fecfin = "";
                if (flagfecha == "P")
                {
                    fecini = cboperiodosini.SelectedValue.ToString();
                    fecfin = cboperiodosfin.SelectedValue.ToString();
                }
                else if (flagfecha == "R")
                {
                    fecini = dtpfechaIni.Value.ToString();
                    fecfin = dtpFechaFin.Value.ToString();
                }

                if (rbResumido.IsChecked)
                {
                    reporte.Nombre = "RptResErroresComunes.rpt";
                }
                else if (rbDetallado.IsChecked)
                {
                    reporte.Nombre = "RptDetErrroresComunes.rpt";
                }

                string cEmpresa = Logueo.CodigoEmpresa;
                string cAnio = Logueo.Anio;
                
                 datos = ErroresComunesLogic.Instance.TraerReporteErroresComununes(cEmpresa, cAnio, flagfecha, 
                                                    fecini, fecfin, Util.ConvertiraXML(seleccionados));
                 reporte.DataSource = datos;

                 string cTitulo = "Reporte Errores comunes";
                 string cSubTitulo = "De " + fecini + " Al " + fecfin;
                 reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                 reporte.FormulasFields.Add(new Formula("Anio", Logueo.Anio));
                 reporte.FormulasFields.Add(new Formula("Titulo", cTitulo));
                 reporte.FormulasFields.Add(new Formula("subtitulo", cSubTitulo));
                // Parametors de entrada apra el reporte
                
                //Asignado el reporte al visor
                 ReporteControladora controles = new ReporteControladora(reporte);
                 controles.VistaPrevia(enmWindowState.Normal);
                 Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema");
            }
        }
        private void CrearColumnas()
        {
            RadGridView Grid = CreateGrid(this.gridControl);
            CreateGridColumn(Grid, "Codigo", "PRO10CODIGO", 0, "", 60);
            CreateGridColumn(Grid, "Nombre", "PRO10DESCRIPCION", 0, "", 150);                        
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
        
    }
}
