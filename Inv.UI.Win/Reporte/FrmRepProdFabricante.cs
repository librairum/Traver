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
    public partial class FrmRepProdFabricante: frmBaseReporte
    {
        private bool isLoaded = false;
        private frmMDI FrmParent { get; set; }
        private static FrmRepProdFabricante _aForm;

         public static FrmRepProdFabricante Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmRepProdFabricante(mdiPrincipal);
            _aForm = new FrmRepProdFabricante(mdiPrincipal);
            return _aForm;
        }

         public FrmRepProdFabricante(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }
        private void FrmRepProdFabricante_Load(object sender, EventArgs e)
        {
                  
            //
            this.rbtresumido.CheckState = CheckState.Checked;
            this.rbtrangoperiodo.CheckState = CheckState.Checked;


            // Llenar combo mese
            CargarPeriodos(cbomesini);
            CargarPeriodos(cbomesfin);

            // Fechas de hoy dia por defecto
            this.dtpranfechaini.Value = DateTime.Now;
            this.dtpranfechafin.Value = DateTime.Now;


            // Periodo por defecto
            this.cbomesini.SelectedValue = DateTime.Now.Month.ToString("0#"); 
            this.cbomesfin.SelectedValue = DateTime.Now.Month.ToString("0#"); 
          isLoaded = true;
        }

        public FrmRepProdFabricante()
        {
            InitializeComponent();
        }

        protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;

            //Capturar fechas
            string ranfecini;
            string ranfecfin;
            string flag;
            string subtitulo;

            
            if (rbtrangoperiodo.CheckState == CheckState.Checked)
            {

                ranfecini = this.cbomesini.SelectedValue.ToString().Substring(0, 2);
                ranfecfin = this.cbomesfin.SelectedValue.ToString().Substring(0, 2);
                subtitulo = ("DEL   " + ranfecini + "   AL  " + ranfecfin);
                flag = "P";

            }
            else
            {
                ranfecini = string.Format("{0:dd/MM/yyyy}", this.dtpranfechaini.Value);
                ranfecfin = string.Format("{0:dd/MM/yyyy}", this.dtpranfechafin.Value);
                subtitulo = ("DEL   " + ranfecini + "   AL  " + ranfecfin);
                flag = "R";
            }

            
            //GlobalLogic.Instance.InsertarRangoImpresion(Logueo.CodigoEmpresa, "Admin", this.txtCodigoTipDoc.Text, this.txtNroDocumento.Text, out mensajeOut);
            var datos = DocumentoLogic.Instance.RptProdFabricante(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.TipoAnalisisFabricante,flag,ranfecini,ranfecfin);
            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();

            reporte.DataSource = datos;

            if (rbtdetallado.CheckState == CheckState.Checked)
            {
                reporte.Nombre = "FrmProdFabricante.rpt";
                reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                reporte.FormulasFields.Add(new Formula("subtitulo", subtitulo));
            }
            else
            {
                reporte.Nombre = "FrmProdFabricanteRes.rpt";
                reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                reporte.FormulasFields.Add(new Formula("subtitulo", subtitulo));
            }
            

            ReporteControladora control = new ReporteControladora(reporte);
            control.VistaPrevia(enmWindowState.Normal);

            Cursor.Current = Cursors.Default;
            
        }
        private void CargarPeriodos(RadDropDownList cbo )
        {
            try
            {
                var periodo = PeriodoLogic.Instance.MesesxAnio(Logueo.CodigoEmpresa,Logueo.Anio);
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

                throw;
            }
        }

        
    }
}