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
using Com.UI.Win;

namespace Com.UI.Win
{
    public partial class frmMoviDocumentoCompraRpt : frmBaseReg
    {
        #region "Instancia"
        private static frmMoviDocumentoCompraRpt _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmMoviDocumentoCompraRpt Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmMoviDocumentoCompraRpt(formParent);
            _aForm = new frmMoviDocumentoCompraRpt(formParent);
            return _aForm;
        }
        //public static frmGenerarAsientos Instance(frmMDI formParent)
        //{
        //    if (_aForm != null) return new frmGenerarAsientos(formParent);
        //    _aForm = new frmGenerarAsientos(formParent);
        //    return _aForm;
        //}
        #endregion
        VentaDocumentoLogic datos = VentaDocumentoLogic.Instance;
        public frmMoviDocumentoCompraRpt(frmMDI padre)
        {
            InitializeComponent();
           //rmParent = padre;
            this.KeyPreview = false;
           // CrearColumnas();

            //this.OptEstado0.Click += new EventHandler(OptEstado_Click);
            //this.OptEstado1.Click += new EventHandler(OptEstado_Click);
            //this.OptEstado2.Click += new EventHandler(OptEstado_Click);
            //IniciarControles();
        }
        private void btnMostrarReporte_Click(object sender, EventArgs e)
        {
        }

        private void frmMoviDocumentoCompraRpt_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            radGroupBox2.Enabled = true;
            HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia);
            OptAnual.IsChecked = true;
        }
        protected override void OnVista()
        {
            
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string opcion = "";
                if(OptAnual.IsChecked)
                {
                    opcion = "A";
                }
                else if(OptMensual.IsChecked)
                {
                    opcion = "M";
                }

                DataTable dt = ArticuloLogic.Instance.TraerReporteMovimiento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,opcion);
                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = "Rpt_DetDoc.rpt";
                reporte.DataSource = dt;

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al generar reporte");
            }
            Cursor.Current = Cursors.Default;
        }

    }
}
