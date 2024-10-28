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

namespace Fac.UI.Win
{
    public partial class frmRepControlDevoluciones : frmBaseReporte
    {
        public frmRepControlDevoluciones()
        {
            InitializeComponent();
         

           

        }
        private frmMDI FrmParent { get; set; }
        private static frmRepControlDevoluciones _aForm;

        public static frmRepControlDevoluciones Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmRepControlDevoluciones(mdiPrincipal);
            _aForm = new frmRepControlDevoluciones(mdiPrincipal);
            return _aForm;
        }
        public frmRepControlDevoluciones(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }

        protected override void OnVista()
        {
            try
            {
                if (rbDetallado.CheckState == CheckState.Unchecked && rbResumido.CheckState == CheckState.Unchecked) {
                    RadMessageBox.Show("Seleccion opcion", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }
                Cursor.Current = Cursors.WaitCursor;
                var datos = DocumentoLogic.Instance.RptControlDevoluciones(Logueo.CodigoEmpresa);
                Reporte reporte = new Reporte("Documento");
                if (rbDetallado.CheckState == CheckState.Checked)
                {

                    reporte.Ruta = Logueo.GetRutaReporte();
                    reporte.DataSource = datos;
                    reporte.Nombre = "RptDevoluciones.rpt";
                }
                else if (rbResumido.CheckState == CheckState.Checked)
                {
                    reporte.Ruta = Logueo.GetRutaReporte();
                    reporte.DataSource = datos;
                    reporte.Nombre = "RptControlDevolucionRes.rpt";
                }


                reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                reporte.FormulasFields.Add(new Formula("titulo", "Reporte de devoluciones"));

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) { }
            
        }
    }
}
