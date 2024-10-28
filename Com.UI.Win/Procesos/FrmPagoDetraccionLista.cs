using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using Inv.BusinessLogic;
using Inv.BusinessEntities;
namespace Com.UI.Win
{
    public partial class FrmPagoDetraccionLista : frmBaseDocumento
    {
        private static FrmPagoDetraccionLista _aForm;
        private frmMDI FrmParent { get; set; }
        public static FrmPagoDetraccionLista Instance(frmMDI padre)
        {
            if (_aForm != null) return new FrmPagoDetraccionLista(padre);
            _aForm = new FrmPagoDetraccionLista(padre);
            return _aForm;
        }
        public FrmPagoDetraccionLista(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }
        protected override void OnVistaPreliminar()
        {
            string nombreReporte = "";
            DataTable dt = new DataTable();
            string CodigoEmpresa = Logueo.CodigoEmpresa;

            string NroLote = "";
            NroLote = Util.GetCurrentCellText(gridControl, "CO26NUMLOTE");


            if (Resumen.Checked == true)
            {
                nombreReporte = "RptDetraccionRes.rpt";
                dt = DetraccionLogic.Instance.TraerDetraccionDet(CodigoEmpresa, NroLote);
            }
            else if (Detalle.Checked == true)
            {
                nombreReporte = "RptDetraccionDet.rpt";
                dt = DetraccionLogic.Instance.TraerDetraccionDet(CodigoEmpresa, NroLote);
            }

            List<Paramentro> parametros = new List<Paramentro>();
            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();
            reporte.Nombre = nombreReporte;
            reporte.DataSource = dt;
            ReporteControladora control = new ReporteControladora(reporte);
            control.VistaPrevia(enmWindowState.Normal);
        }
        protected override void OnNuevo()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var frmInstance = frmPagoDetraccionDet.Instance(this);
                Estado = FormEstate.New;
                var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPagoDetraccionDet);
                if (frmExist != null)
                {
                    frmInstance.BringToFront();
                    return;
                }
                Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
                frmInstance.MdiParent = this.ParentForm;

                ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);
                frmInstance.Show();

            }
            catch (Exception ex)
            {
                Util.ShowError("Error: " + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        public void TraerDetraccion() 
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                List<Detraccion> ListaRetencion = DetraccionLogic.Instance.TraerDetraccion(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
                this.gridControl.DataSource = ListaRetencion;
           
            }
            catch(Exception ex)
            {
                Util.ShowError("Error al traer datos de Detraccion : " + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        protected override void OnEliminar()
        {
            try
            {
                if (gridControl.Rows.Count == 0) { return; }
                
                bool respuesta = Util.ShowQuestion("¿Dese eliminar el documento?");
                if (respuesta == false) { return; }
                Cursor.Current = Cursors.WaitCursor;
                string mensaje = "", CO26NUMLOTE;
                int flag = 1;
 
                CO26NUMLOTE = Util.GetCurrentCellText(gridControl.CurrentRow, "CO26NUMLOTE");

                DetraccionLogic.Instance.Eliminar_Detraccion(Logueo.CodigoEmpresa, CO26NUMLOTE,out mensaje);
                Util.ShowMessage(mensaje, flag);
                TraerDetraccion();

                if (flag == 1)
                {
                    TraerDetraccion();
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) {
                Util.ShowAlert("Error al eliminar "+ ex);
            }
            
        }
        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (this.gridControl.Rows.Count == 0) return;
            OnVer(); 
        }
        protected override void OnVer()
        {
            if (this.gridControl.Rows.Count == 0) return;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
         
                //ler nro de orden seleccionado 
                //numeroOrden = util.get
                //numeroOrden = Util.GetCurrentCellText(gridControl, "CodigoOrdenCompra");
                //// Inicio el constructor
                //TipoMoneda = Util.GetCurrentCellText(gridControl, "Ban01Mon");
                //Fecha = Util.GetCurrentCellText(gridControl, "RetencionFecha");
                //RetencionNro = Util.GetCurrentCellText(gridControl, "RetencionNro");
                var frmInstance = frmPagoDetraccionDet.Instance(this);
                //frmInstance.tipoDocumento = Util.GetCurrentCellText(FrmParent.gridControl.CurrentRow, "FAC01COD");
                // Luego de iniciar el constructor , envio el flag de tipo de operacion
                //frmInstance.Estado = FormEstate.New;
                Estado = FormEstate.View;
                var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPagoDetraccionDet);
                if (frmExist != null)
                {
                    frmInstance.BringToFront();
                    return;
                }
                Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
                frmInstance.MdiParent = this.ParentForm;

                ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);
                frmInstance.Show();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al ver orden de compra, detalle:" + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        private void CrearColumnas()
        {
            try
            {
                RadGridView grid = CreateGridVista(this.gridControl);
                CreateGridColumn(grid, "CO26CODEMP", "CO26CODEMP", 0, "", 100, true, false, false);
                CreateGridColumn(grid, "Num", "CO26NUMLOTE", 0, "", 100, true, false, true);
                CreateGridColumn(grid, "Fecha", "CO26FECHA", 0, "{0:dd/MM/yyyy}", 70, true, false, true);
                CreateGridColumn(grid, "Ran Fec Ini", "CO26RANFECINI", 0, "{0:dd/MM/yyyy}", 90, true, false, true);
                CreateGridColumn(grid, "Ran Fec Fin", "CO26RANFECFIN", 0, "{0:dd/MM/yyyy}", 90, true, false, true);
                CreateGridColumn(grid, "Imp Documentos", "IMPORTETOTDOC", 0,"{0:###,###0.00}", 130, true, false, true, true, "right");
                CreateGridColumn(grid, "Imp Detraccion", "IMPORTETOTDET", 0, "{0:###,###0.00}", 90, true, false, true, true, "right");
              //  CreateGridColumn(grid, "Importe S/.", "IMPORTETOTDOC", 0, "{0:###,###0.00}", 90, true, false, true, false, "right");
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al crear columnas, detalle: " + ex.Message);
            }
        }
        private void FrmPagoDetraccionLista_Load(object sender, EventArgs e)
        {
           // this.FormClosed += new FormClosedEventHandler(FrmPagoDetraccionLista_FormCLosed);
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbExportar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVer);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPreliminar);
            CrearColumnas();
            TraerDetraccion();
        }

       
    }
}
