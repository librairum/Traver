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
    public partial class FrmValidaciones : frmBaseReporte
    {
        private frmMDI FrmParent { get; set; }
        private static FrmValidaciones _aForm;
        public static FrmValidaciones Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmValidaciones(mdiPrincipal);
            _aForm = new FrmValidaciones(mdiPrincipal);
            return _aForm;
        }

        
        
        public FrmValidaciones(frmMDI padre) {
            InitializeComponent();
            FrmParent = padre;
            IniciarFormulario();
        }
        public FrmValidaciones()
        {
            InitializeComponent();
            IniciarFormulario();         
        }

        private void FrmValidaciones_Load(object sender, EventArgs e)
        {

        }

        private void IniciarFormulario()
        {
           rbvalidaciones.CheckState = CheckState.Checked;
        }

        
        
        protected override void OnVista()
        {
       

            Cursor.Current = Cursors.WaitCursor;

            string titulo = "";
            string subtitulo = "";
            
             Reporte reporte = new Reporte("Documento");
             reporte.Ruta = Logueo.GetRutaReporte();

             DataTable datos = null;
             titulo = "VALIDACIONES";
             reporte.Nombre = "RptValidaciones.rpt";
             datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_Valida(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
            //
            reporte.DataSource = datos;

            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
            reporte.FormulasFields.Add(new Formula("Anio", Logueo.Anio));
            reporte.FormulasFields.Add(new Formula("titulo", titulo));
            reporte.FormulasFields.Add(new Formula("subtitulo", subtitulo));

            ReporteControladora controles = new ReporteControladora(reporte);
            controles.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;
        }


        
    }
}
