using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Telerik.WinControls;
using Telerik.WinControls.UI;

using Inv.BusinessEntities;
using Inv.BusinessLogic;

namespace Fac.UI.Win
{
    public partial class frmRepArtiClixArtiProd : frmBaseReporte
    {
        #region "Instancia"
        private static frmRepArtiClixArtiProd _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmRepArtiClixArtiProd Instance(frmMDI padre)
        {
            if (_aForm != null) return new frmRepArtiClixArtiProd(padre);
            _aForm = new frmRepArtiClixArtiProd(padre);
            return _aForm;
        }
        #endregion
        public frmRepArtiClixArtiProd(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }
        private void CrearColumnas()
        {
            RadGridView Grid =  CreateGrid(this.gridControl);
            CreateGridColumn(Grid, "Codigo", "ccm02cod", 0, "", 90);
            CreateGridColumn(Grid, "Nombre", "ccm02nom", 0, "", 250);
        }
        private void CargarClientes()
        {
            gridControl.DataSource = CuentaCorrienteLogic.Instance.TraeClientesConProdPropio(Logueo.CodigoEmpresa, "01");

        }

        private void frmRepArtiClixArtiProd_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            CargarClientes();
        }
        protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;
            string[] registros = new string[this.gridControl.SelectedRows.Count];

            try
            {
                int x = 0;
                //Crear xml para reporte
                foreach (GridViewRowInfo fila in gridControl.SelectedRows)
                {

                    registros[x] = Util.GetCurrentCellText(fila, "ccm02cod");
                    x++;
                }
                string xml = Util.ConvertiraXMLdinamico(registros);

                Reporte reporte = new Reporte("Documento");
                DataTable dt;
                dt = ArticuloLogic.Instance.TraeArtiClixArtiProd(Logueo.CodigoEmpresa, Logueo.Anio, xml);
                reporte.Ruta = Logueo.GetRutaReporte();

                reporte.Nombre = "RptArtiClixArtiProd.rpt";
                reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                reporte.FormulasFields.Add(new Formula("titulo", "Relacion producto cliente por producto deisi"));
                reporte.DataSource = dt;

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar reporte:" + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

    }
}
