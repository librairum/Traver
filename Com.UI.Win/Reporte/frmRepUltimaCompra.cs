using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using Inv.BusinessLogic;
using Inv.BusinessEntities;

using System.Linq;
namespace Com.UI.Win
{
    public partial class frmRepUltimaCompra : frmBaseReporte
    {
        private static frmRepUltimaCompra _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmRepUltimaCompra Instance(frmMDI padre)
        {
            if (_aForm != null) return new frmRepUltimaCompra(padre);
            _aForm = new frmRepUltimaCompra(padre);
            return _aForm;
        }
        public frmRepUltimaCompra(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;

            this.gridUltimaCompra.ShowFilteringRow = true;
        }
        private void CrearColumnas()
        {
           
            
            RadGridView Grid = CreateGrid(gridUltimaCompra);

            CreateGridColumn(Grid, "Codigo", "in01key", 0, "", 250);
            CreateGridColumn(Grid, "Descripcion", "in01DesLar", 0, "", 350);

        }
        private void CrearColumnasDetalle()
        {
            RadGridView Grid = CreateGrid(gridDetalleCompra);

            CreateGridColumn(Grid, "Codigo", "Cod", 0, "", 70);
            CreateGridColumn(Grid, "Fecha", "CO04FECDOC", 0, "", 250);
            CreateGridColumn(Grid, "Proveedores", "CO04CODPRO", 0, "", 250);
            CreateGridColumn(Grid, "Nombre", "ccm02Nom", 0, "", 250);
            CreateGridColumn(Grid, "Cantidad", "CO04CANTID", 0, "{0:###,###0.00}", 100, true, false, true, "right");
            CreateGridColumn(Grid, "P.U", "CO04PRECIO", 0, "{0:###,###0.00}", 100, true, false, true, "right");
            CreateGridColumn(Grid, "Imp.Bruto", "CO04IMPBRU", 0, "{0:###,###0.00}", 100, true, false, true, "right");
            CreateGridColumn(Grid, "Igv", "CO04IMPIGV", 0, "{0:###,###0.00}", 100, true, false, true, "right");
            CreateGridColumn(Grid, "Total", "CO04IMPNET", 0,"{0:###,###0.00}",100,true,false,true, "right");
        }
        private void Cargar()
        {
            try
            {

                string tipoOrdenCompra = "C";
                List<Articulo> lista = ArticuloLogic.Instance.TraeArticuloCompras(Logueo.CodigoEmpresa,
                    Logueo.Anio, "*", tipoOrdenCompra, "in01key", Logueo.PS_codnaturaleza);
                gridUltimaCompra.DataSource = lista;
                this.gridUltimaCompra.Columns[0].FilterDescriptor = new Telerik.WinControls.Data.FilterDescriptor(null, Telerik.WinControls.Data.FilterOperator.StartsWith, null);
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al cargar");
            }
        }
        private void CargarDetalleUltimaCompra()
        {
            try
            {
                string codArt = Util.GetCurrentCellText(gridUltimaCompra, "in01key");
                
               // string tipoOrdenCompra = "C";
                DataTable lista = ArticuloLogic.Instance.CompraReporteUltimaCompraArticulo(Logueo.CodigoEmpresa, codArt, Logueo.TipoAnalisisProveedor);
                gridDetalleCompra.DataSource = lista;

            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al cargar");
            }
        }
        protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string nombreReporte = "RptUltimaCompra.rpt";
                string codArt = Util.GetCurrentCellText(gridUltimaCompra, "in01key");

                DataTable lista = ArticuloLogic.Instance.CompraReporteUltimaCompraArticulo(Logueo.CodigoEmpresa,codArt, Logueo.TipoAnalisisProveedor);

                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = nombreReporte;
                reporte.DataSource = lista;
                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
                //ArticuloLogic.Instance.CompraReporteUltimaCompraArticulo(Logueo.CodigoEmpresa, Logueo.Anio, "C", 
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al traer vista");
            }
            Cursor.Current = Cursors.Default;
        }
        
        private void frmRepUltimaCompra_Load(object sender, EventArgs e)
        {
            this.radPanel4.Visible = false;
            
            this.rpOpciones.Visible = false;
            CrearColumnas();
            CrearColumnasDetalle();
            Cargar();
            //CargarDetalleUltimaCompra();
        }

        private void gridUltimaCompra_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (gridUltimaCompra.Rows.Count == 0) return;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                CargarDetalleUltimaCompra();
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al cambiar registro");
            }
            Cursor.Current = Cursors.Default;
        }

        private void gridUltimaCompra_Click(object sender, EventArgs e)
        {

        }
       
    }
}
