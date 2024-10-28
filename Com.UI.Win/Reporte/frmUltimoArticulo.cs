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
    public partial class frmUltimoArticulo : frmBaseReporte
    {
        private static frmUltimoArticulo _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmUltimoArticulo Instance(frmMDI padre)
        {
            if (_aForm != null) return new frmUltimoArticulo(padre);
            _aForm = new frmUltimoArticulo(padre);
            return _aForm;
        }
        public frmUltimoArticulo(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;

            this.gridUltimaCompra.ShowFilteringRow = true;
        }
        private void CrearColumnas()
        {
           
            
            RadGridView Grid = CreateGrid(gridUltimaCompra);

            CreateGridColumn(Grid, "Codigo", "In01Key", 0, "", 70);
            CreateGridColumn(Grid, "Descripcion", "In01DesLar", 0, "", 250);
            CreateGridColumn(Grid, "Unidad Medida", "In01UniMed", 0, "", 250);

        }
        private void Cargar()
        {
            try
            {

                string tipoOrdenCompra = "C";
                DataTable lista = ArticuloLogic.Instance.Traer_UltimoArticulo(Logueo.CodigoEmpresa, dtpFechaIni.Value.ToString(), dtpFechaFin.Value.ToString(), Logueo.Anio, "IN01KEY","*");
                gridUltimaCompra.DataSource = lista;
                this.gridUltimaCompra.Columns[0].FilterDescriptor = new Telerik.WinControls.Data.FilterDescriptor(null, Telerik.WinControls.Data.FilterOperator.StartsWith, null);
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
            catch (Exception ex)
            {
                Util.ShowAlert("Error al traer vista");
            }
            Cursor.Current = Cursors.Default;
        }
        
        private void frmRepUltimaCompra_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            DateTime Fecha = DateTime.Today.Date;
            this.dtpFechaIni.Value = Fecha;
            this.dtpFechaFin.Value = Fecha;
            this.rpOpciones.Visible = true;
            CrearColumnas();
            Cargar();
            //CargarDetalleUltimaCompra();
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnCopiarTodo_Click(object sender, EventArgs e)
        {
            SeleccionarTodoFilas();
        }


        private void SeleccionarTodoFilas()
        {
            try
            {

                gridUltimaCompra.SelectAll();

                DataObject dataObj = gridUltimaCompra.GetClipboardContent();
                if (dataObj != null)
                {
                    Clipboard.SetDataObject(dataObj);
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al copiar todo las filas , detalle:" + ex.Message);
            }
        }

       
    }
}
