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
    public partial class frmOrdenesdeCompra : frmBaseDocumento
    {
        private static frmOrdenesdeCompra _aForm;
        private frmMDI FrmParent { get; set; }

        

        public static frmOrdenesdeCompra Instance(frmMDI padre)
        {
            if (_aForm != null) return new frmOrdenesdeCompra(padre);
            _aForm = new frmOrdenesdeCompra(padre);
            return _aForm;
        }


        public frmOrdenesdeCompra(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }

        internal string tipoOrden = "", numeroOrden = "";
        protected override void OnVistaPreliminar()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string nombreReporte = "RptOrdenCompra.rpt";
                //string numeroDocumento = "", tipoOrdenCompra ="";
                //tipoOrdenCompra = Util.GetCurrentCellText(gridControl.CurrentRow, "TipoOrdenCompra");
                //numeroDocumento = Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoOrdenCompra");
                string[] nrodocumentos = new string[this.gridControl.SelectedRows.Count];
                int x = 0;
                foreach (GridViewRowInfo fila in gridControl.SelectedRows) {
                    nrodocumentos[x] = Util.GetCurrentCellText(fila, "TipoOrdenCompra")  + 
                                    Util.GetCurrentCellText(fila, "CodigoOrdenCompra");
                    x++;
                }
                string xml = Util.ConvertiraXMLdinamico(nrodocumentos);
                DataTable dt = CompraDocumentoLogic.Instance.TraeReporteOrdenCompra(Logueo.CodigoEmpresa, 
                                                                        Logueo.Anio, Logueo.Mes, "02", xml);

                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = nombreReporte;
                reporte.DataSource = dt;

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);

            }
            catch (Exception ex) {
                Util.ShowAlert("Error al traer vista preliminar");
            }
            Cursor.Current = Cursors.Default;
        }
        protected override void OnNuevo()
        {
            Cursor.Current = Cursors.WaitCursor;                        
            try
            {
                if (rbOrdenCompra.Checked)
                {
                    tipoOrden = "C";
                }
                else if (rbOrdenTrabajo.Checked)
                {
                    tipoOrden = "T";
                }

                // Inicio el constructor
                var frmInstance = frmOrdenCompraDetalle.Instance(this);                
                // Luego de iniciar el constructor , envio el flag de tipo de operacion
                //frmInstance.Estado = FormEstate.New;
                Estado = FormEstate.New;
                var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOrdenCompraDetalle);
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
                Util.ShowError("Erro al crear orden de compra, detalle: " + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        protected override void OnEditar()
        {
            if (this.gridControl.Rows.Count == 0) return;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (rbOrdenCompra.Checked)
                {
                    tipoOrden = "C";
                }
                else if (rbOrdenTrabajo.Checked)
                {
                    tipoOrden = "T";
                }
                //ler nro de orden seleccionado 
                //numeroOrden = util.get
                numeroOrden = Util.GetCurrentCellText(gridControl, "CodigoOrdenCompra");
                // Inicio el constructor
                var frmInstance = frmOrdenCompraDetalle.Instance(this);
                //frmInstance.tipoDocumento = Util.GetCurrentCellText(FrmParent.gridControl.CurrentRow, "FAC01COD");
                // Luego de iniciar el constructor , envio el flag de tipo de operacion
                //frmInstance.Estado = FormEstate.New;
                Estado = FormEstate.Edit;
                var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOrdenCompraDetalle);
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
                Util.ShowError("Error al editar orden de compra, detalle: " + ex.Message);

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
                string tipoOrden = "", numeroOrdenCompra = "", mensaje = "";
                int flag = 0;
                if (rbOrdenCompra.Checked)
                {
                    tipoOrden = "C";
                }
                else if (rbOrdenTrabajo.Checked)
                {
                    tipoOrden = "T";
                }
                numeroOrdenCompra = Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoOrdenCompra");

                CompraDocumentoLogic.Instance.EliminarOrdenCompra(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                    tipoOrden, numeroOrdenCompra, out flag, out mensaje);
                Util.ShowMessage(mensaje, flag);
                if (flag == 1)
                {
                    Cargar();
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) {
                Util.ShowAlert("Error al eliminar");
            }
            
        }
        protected override void OnVer()
        {
            if (this.gridControl.Rows.Count == 0) return;
            Cursor.Current = Cursors.WaitCursor;
            
            try
            {
                if (rbOrdenCompra.Checked)
                {
                    tipoOrden = "C";
                }
                else if (rbOrdenTrabajo.Checked)
                {
                    tipoOrden = "T";
                }
                //ler nro de orden seleccionado 
                //numeroOrden = util.get
                numeroOrden = Util.GetCurrentCellText(gridControl, "CodigoOrdenCompra");
                // Inicio el constructor
                var frmInstance = frmOrdenCompraDetalle.Instance(this);
                //frmInstance.tipoDocumento = Util.GetCurrentCellText(FrmParent.gridControl.CurrentRow, "FAC01COD");
                // Luego de iniciar el constructor , envio el flag de tipo de operacion
                //frmInstance.Estado = FormEstate.New;
                Estado = FormEstate.View;
                var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOrdenCompraDetalle);
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
        protected override void OnAnular()
        {
            try
            {
                if (this.gridControl.Rows.Count == 0) { return; }
                

                bool respuesta = Util.ShowQuestion("¿Estas seguro de Anular la Orden de Compra?");
                if (respuesta == false) { return; }

                Cursor.Current = Cursors.WaitCursor;
                    string codigoTipoOrden = "";
                    string codigoOrdenCompra = "";
                    int flag = 0; string mensaje = "";

                    if (rbOrdenCompra.Checked == true)
                    {
                        codigoTipoOrden = "C";
                    }
                    else if (rbOrdenTrabajo.Checked == true)
                    {
                        codigoTipoOrden = "T";
                    }
                    
                    codigoOrdenCompra = Util.GetCurrentCellText(this.gridControl.CurrentRow, "CodigoOrdenCompra");
                    CompraDocumentoLogic.Instance.AnulaOrdenCompra(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, codigoTipoOrden, codigoOrdenCompra, out flag, out mensaje);
                    Util.ShowMessage(mensaje, flag);

                    if (flag == 1)
                    {
                        Cargar();
                    }
                    Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al anular");
            }

        }
        private void CrearColumnas()
        {
            try
            {
                RadGridView grid = CreateGridVista(this.gridControl);
                CreateGridColumn(grid, "O/T", "TipoOrdenCompra", 0, "", 70, true, false, true); //CO03TIPO
                CreateGridColumn(grid, "# O/C", "CodigoOrdenCompra", 0, "", 70, true, false, true); //CO03CODIGO
                CreateGridColumn(grid, "Fecha", "FechaOrdenCompra", 0, "{0:dd/MM/yyyy}", 70, true, false, true); //CO03FECHA
                CreateGridColumn(grid, "Solicitud", "NroSolicitud", 0, "", 70, true, false, true);
                CreateGridColumn(grid, "Proveed.", "CodigoProveedor", 0, "", 120, true, false, true); // CO03CODPRO
                CreateGridColumn(grid, "Nombre Proveedor", "NombreProveedor", 0, "", 250, true, false, true); // NombreProveedor

                CreateGridColumn(grid, "CodEstado", "Estado", 0, "", 90, true, false, false); //CO03ESTADO
                
                CreateGridColumn(grid, "Est. Pago", "FlagCancelado", 0, "", 90, true, false, false); //CO03CANCEL
                CreateGridColumn(grid, "PRN", "FlagImporte", 0, "", 70, true, false, false); // CO03FLAIMP
                
                //columnas pra datos de cabecera
                CreateGridColumn(grid, "RucProveedor", "RucProveedor", 0, "", 70, true, false, false);
                CreateGridColumn(grid, "TelfProveedor", "TelfProveedor", 0, "", 70, true, false, false);

                CreateGridColumn(grid, "DireccProveedor", "DireccProveedor", 0, "", 70, true, false, false);
                CreateGridColumn(grid, "Atencion", "Atencion", 0, "", 70, true, false, false);
                
                CreateGridColumn(grid, "F.Presentacion", "FechaSolicitud", 0, "", 70, true, false, false);

                CreateGridColumn(grid, "CentroCostoCod", "CentroCosto", 0, "", 70, true, false, false);
                CreateGridColumn(grid, "CentroCostoDesc", "CentroCostoDesc", 0, "", 70, true, false, false);
                CreateGridColumn(grid, "CompLocExt", "CompLocExt", 0, "", 70, true, false, false);

                CreateGridColumn(grid, "FormaPago", "FormaPago", 0, "", 70, true, false, false);
                CreateGridColumn(grid, "FormaPagoDes", "FormaPagoDes", 0, "", 70, true, false, true);

                CreateGridColumn(grid, "PlazoEntrega", "PlazoEntrega", 0, "", 70, true, false, false);
                CreateGridColumn(grid, "FechaEntrega", "FechaEntrega", 0, "", 70, true, false, false);

                CreateGridColumn(grid, "CodigoEntrega", "CodigoEntrega", 0, "", 70, true, false, false);
                CreateGridColumn(grid, "DireccionEntrega", "DireccionEntrega", 0, "", 70, true, false, false);

                CreateGridColumn(grid, "TipoCambio", "TipoCambio", 0, "", 70, true, false, true);
                CreateGridColumn(grid, "GiraCheque", "GiraCheque", 0, "", 70, true, false, false);

                CreateGridColumn(grid, "UsuarioLogistica", "UsuarioLogistica", 0, "", 70, true, false, false);
                CreateGridColumn(grid, "UsuarioLogisticaDesc", "UsuarioLogisticaDesc", 0, "", 70, true, false, false);

                CreateGridColumn(grid, "Destino1", "Destino1", 0, "", 70, true, false, false);
                CreateGridColumn(grid, "Destino2", "Destino2", 0, "", 70, true, false, false);
                CreateGridColumn(grid, "Observacion", "Observacion", 0, "", 70, true, false, false);
                CreateGridColumn(grid, "TipoMoneda", "TipoMoneda", 0, "", 70, true, false, true);
                CreateGridColumn(grid, "TipoMonedaDesc", "TipoMonedaDesc", 0, "", 70, true, false, true);
                CreateGridColumn(grid, "CodigoArea", "CodigoArea", 0, "", 70, true, false, false);

                CreateGridColumn(grid, "Base Imp", "ImporteBruto", 0, "{0:###,###0.00}", 70, true, false, true, false, "right");
                CreateGridColumn(grid, "Dscto Imp", "Descuento", 0, "{0:###,###0.00}", 70, true, false, true, false, "right");
                CreateGridColumn(grid, "IGV %", "ImporteIgv", 0, "", 70, true, false, true, false, "right"); //tasa IGV
                CreateGridColumn(grid, "IGV Imp", "MontoImporte", 0, "{0:###,###0.00}", 70, true, false, true, false, "right"); //Importe IGV
                CreateGridColumn(grid, "Total Imp", "Total", 0, "{0:###,###0.00}", 70, true, false, true, false, "right");
                CreateGridColumn(grid, "Estado", "EstadoDescripcion", 0, "", 90, true, false, true, false, "right"); //CO03ESTADO
                /*
co03Tipo
O/T

co03Codigo
# O/C

co03Fecha
Fecha

co03Presup
Solicitud

CO03CODPRO
Proveed


Ccm02Nom
Nombre Proveedor

CO03ESTADO
Estado

CO03CANCEL
Est Pago

CO03fLAIMP
PRN

                 */

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al crear columnas, detalle: " + ex.Message);
            }
        }
        public void Cargar()
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                
                string tipoOrden = "";
                if (rbOrdenCompra.Checked)
                {
                    tipoOrden = "C";
                }else if (rbOrdenTrabajo.Checked){
                    tipoOrden = "T";
                }
                List<DodcumentoOrdenCompra> lista = CompraDocumentoLogic.Instance.TraeOrdenesdeCompras(Logueo.CodigoEmpresa,
                    Logueo.Anio, Logueo.Mes, Logueo.TipoAnalisisProveedor, tipoOrden);
                this.gridControl.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer datos de orden de compra, detalle : " + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        private void frmOrdenesdeCompra_Load(object sender, EventArgs e)
        {   
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVer);
           // HabilitaBotonPorNombre(BaseRegBotones.cbbAnulado);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPreliminar);
            this.AsignarToolTipBoton("anulado", "Anular factura");
            this.AsignarImageBoton("anulado", Properties.Resources.Menu_Mediano_CancelarDocumento_enabled);
            CrearColumnas();
            Cargar();
            
        }
        internal void RefrescarGrilla()
        {
            Cargar();
        }
        private void rbOrdenCompra_CheckedChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void rbOrdenTrabajo_CheckedChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (this.gridControl.Rows.Count == 0) return;
            OnVer();
        }

        private void toolBar_Click(object sender, EventArgs e)
        {

        }

        
    }
}
