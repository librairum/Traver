using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessLogic;
using Telerik.WinControls.UI;
namespace Inv.UI.Win
{
    public partial class FrmRepMPIngvsCorte : frmBaseReporte    
    {
        public FrmRepMPIngvsCorte(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            CargarPeriodos(this.cbomesini);
            CargarPeriodos(this.cbomesfin);
        }
        RadGridView grilla;
        ColumnGroupsViewDefinition columnGroupsView;
        private frmMDI FrmParent { get; set; }
        private static FrmRepMPIngvsCorte _aForm;
        public static FrmRepMPIngvsCorte Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmRepMPIngvsCorte(mdiPrincipal);
            _aForm = new FrmRepMPIngvsCorte(mdiPrincipal);
            return _aForm;
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

                cbo.SelectedValue = anio;
            }


            catch (Exception)
            {

                throw;
            }
        }
        protected override void OnVista()
        {
            //string ranfecini = this.cbomesini.SelectedValue.ToString().Substring(0, 2);
            //string ranfecfin = this.cbomesfin.SelectedValue.ToString().Substring(0, 2);
            string ranfecini = this.cbomesini.SelectedValue.ToString();
            string ranfecfin = this.cbomesfin.SelectedValue.ToString();
            Cursor.Current = Cursors.WaitCursor;
            var datos = DocumentoLogic.Instance.TraerReportIngVsCortes(Logueo.CodigoEmpresa, Logueo.Anio +  ranfecini, Logueo.Anio + ranfecfin);
            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();
            reporte.Nombre = "RptMPIngVsCorte.rpt";
            reporte.DataSource = datos;
            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
            reporte.FormulasFields.Add(new Formula("Anio", Logueo.Anio));
            reporte.FormulasFields.Add(new Formula("titulo", "Cuadro Estadistico"));
            string subtitulo = "";
            if (ranfecini == ranfecfin)
            {
                subtitulo = ranfecini + "-" + Logueo.Anio;
            }
            else
            {
                subtitulo = ("DEL   " + ranfecini + "   AL  " + ranfecfin);
            }
            reporte.FormulasFields.Add(new Formula("subtitulo", subtitulo));
            ReporteControladora control = new ReporteControladora(reporte);
            control.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;

        }
        private void CargarCombos()
        { 
            
        }
    }
}
