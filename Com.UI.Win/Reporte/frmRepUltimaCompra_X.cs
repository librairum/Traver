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
namespace Com.UI.Win
{
    public partial class frmRepUltimaCompra : frmBaseReporte
    {

        private static frmRepUltimaCompra _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmRepUltimaCompra Instance(frmMDI padre) {
            if (_aForm != null) return new frmRepUltimaCompra(padre);
            _aForm = new frmRepUltimaCompra(padre);
            return _aForm;
        }
        public frmRepUltimaCompra(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }

        private void frmRepUltimaCompra_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            Cargar();
        }
        private void CrearColumnas() {
            RadGridView Grid = CreateGrid(gridControl);

            CreateGridColumn(Grid, "Codigo", "in01key", 0, "", 70);
            CreateGridColumn(Grid, "Descripcion", "in01DesLar", 0, "", 250);

        }
        private void Cargar() {
            try
            {
                
                string tipoOrdenCompra = "C";
                List<Articulo> lista=  ArticuloLogic.Instance.TraeArticuloCompras(Logueo.CodigoEmpresa, 
                    Logueo.Anio, "*", tipoOrdenCompra, "in01key",Logueo.PS_codnaturaleza);
                gridControl.DataSource = lista;
                
            }
            catch (Exception ex) {
                Util.ShowAlert("Error al cargar");
            }
        }
        protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string nombreReporte = "RptUltimaCompra.rpt";
                string codArt = Util.GetCurrentCellText(gridControl, "in01key");

                DataTable lista = ArticuloLogic.Instance.CompraReporteUltimaCompraArticulo(Logueo.CodigoEmpresa,
                    codArt, "02");

                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = nombreReporte;
                reporte.DataSource = lista;
                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
                //ArticuloLogic.Instance.CompraReporteUltimaCompraArticulo(Logueo.CodigoEmpresa, Logueo.Anio, "C", 
            }
            catch (Exception ex) {
                Util.ShowAlert("Error al traer vista");
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
