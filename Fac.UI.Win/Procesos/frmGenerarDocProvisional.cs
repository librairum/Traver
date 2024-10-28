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
namespace Fac.UI.Win
{
    public partial class frmGenerarDocProvisional : frmBaseReporte
    {
        private static frmGenerarDocProvisional _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmGenerarDocProvisional Instance(frmMDI padre)
        {
            if (_aForm != null) return new frmGenerarDocProvisional(padre);
            _aForm = new frmGenerarDocProvisional(padre);
            return _aForm;
        }
        private void verdocumentos()
        { 
            
        }
        protected override void OnVista()
        {
            //GlobalLogic.Instance.TraePackinglistTodo(
            GenerarDocumento();
        }
        protected override void OnImprimir()
        {
            
        }
        public frmGenerarDocProvisional(frmMDI padre)
        {
            InitializeComponent();
            crearcolumnas();
            cargar();
        }
        private void GenerarDocumento()
        {
            Cursor.Current = Cursors.WaitCursor;
            string numeroPacking = Util.GetCurrentCellText(gridControl, "numeroPacking");

            DataTable dt = GlobalLogic.Instance.TraeReportePackingList(Logueo.CodigoEmpresa, numeroPacking);

            Reporte reporte = new Reporte("Packing");
            //Codigo para reportes con logos dinamicos
            string rutalogo = System.IO.Path.Combine(Logueo.GetRutaIcono(), "logos", Util.convertiracadena(Logueo.RucEmpresa) + ".png");
            string rutalogoxdefecto = System.IO.Path.Combine(Logueo.GetRutaIcono(), "logos", "Logopordefecto.png");

            if (System.IO.File.Exists(rutalogo) == true)
            {
                //Util.ShowAlert("No existe el archivo logo en la ruta :" + rutalogo);
                //return;
                reporte.ParametersFields.Add(new Paramentro("@rutalogo", rutalogo));
            }
            else
            {
                reporte.ParametersFields.Add(new Paramentro("@rutalogo", rutalogoxdefecto));
            }
            
            reporte.Ruta = Logueo.GetRutaReporte();
            
            if (dt.Rows.Count == 0)
            {
                Util.ShowAlert("el packing no tiene detalles");
                return;
            }
            if (chkImprimePacking.Checked == false && chkImprimirCertificado.Checked == false && chkImprimeFactProvisional.Checked == false)
            {
                Util.ShowAlert("Debe seleccionar una opcion de impresion");
                return;
            }
            if (chkImprimePacking.Checked == true)
            {
                reporte.Nombre = "RptPackingList.rpt";
            }
            else if (chkImprimirCertificado.Checked == true)
            {
                reporte.Nombre = "RptCertificadoOrigen.rpt";
            }
            else if (chkImprimeFactProvisional.Checked == true)
            { 
            
            }

            reporte.DataSource = dt;
            ReporteControladora control = new ReporteControladora(reporte);
            control.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;
        }
        void crearcolumnas()
        {           
            RadGridView xGrid =  CreateGrid(gridControl);
            //FAC60CODEMP, FAC60NUMERO, FAC60AA, FAC60MM,  
            CreateGridColumn(xGrid, "Numero Packing", "numeroPacking", 0, "", 120, true, false);
            CreateGridColumn(xGrid, "Fecha Creacion", "FechaTexto", 0, "", 70);
            CreateGridColumn(xGrid, "Cod.Cliente", "FAC60CLIENTECOD", 0, "", 70, true, true, false);
            CreateGridColumn(xGrid, "Desc.Cliente", "ClienteDesc", 0, "", 200);
            CreateGridColumn(xGrid, "FechaDespacho", "FechaDespacho", 0, "", 70);
            CreateGridColumn(xGrid, "NroCajas", "NroCajas", 0, "{0:###,###0.00}", 100, true, false, true, "right");
            CreateGridColumn(xGrid, "Peso", "Peso", 0, "{0:###,###0.00}", 100, true, false, true, "right");
        }

        void cargar()
        {
            List<Spu_Come_Trae_PackingListTodo> lista =
            GlobalLogic.Instance.TraePackinglistTodo(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
            this.gridControl.DataSource = lista;
        }
    }
}
