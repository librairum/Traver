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
    public partial class FrmRetencionLista : frmBaseDocumento
    {
        private static FrmRetencionLista _aForm;
        private frmMDI FrmParent { get; set; }

        

        public static FrmRetencionLista Instance(frmMDI padre)
        {
            if (_aForm != null) return new FrmRetencionLista(padre);
            _aForm = new FrmRetencionLista(padre);
            return _aForm;
        }


        public FrmRetencionLista(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }

        internal string tipoOrden = "", numeroOrden = "", TipoMoneda, Fecha, RetencionNro;
        protected override void OnVistaPreliminar()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string nombreReporte = "RptComprobantRetencion.rpt";
                //string numeroDocumento = "", tipoOrdenCompra ="";
                //tipoOrdenCompra = Util.GetCurrentCellText(gridControl.CurrentRow, "TipoOrdenCompra");
                //numeroDocumento = Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoOrdenCompra");
                //string[] nrodocumentos = new string[this.gridControl.SelectedRows.Count];
                //int x = 0;
                //foreach (GridViewRowInfo fila in gridControl.SelectedRows) {
                //    nrodocumentos[x] = Util.GetCurrentCellText(fila, "TipoOrdenCompra")  + 
                //                    Util.GetCurrentCellText(fila, "CodigoOrdenCompra");
                //    x++;
                //}
               // string xml = Util.ConvertiraXMLdinamico(nrodocumentos);
                //RetencionLogic.Instance.Trae
                string Ban01Numero = Util.GetCurrentCellText(gridControl.CurrentRow, "RetencionNro");
                DataTable dt = RetencionLogic.Instance.TraerRetencionReporte(Logueo.CodigoEmpresa, Ban01Numero);

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
        //PENDIENTE DE CERRAR FORMULARIO Y HABILITAR EL CBOPERIODOS
        private void FrmRetencionLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Se cerrara");
        }
        protected override void OnNuevo()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                
                // Inicio el constructor
                var frmInstance = FrmRetencionCab.Instance(this);
                // Luego de iniciar el constructor , envio el flag de tipo de operacion
                //frmInstance.Estado = FormEstate.New;
                Estado = FormEstate.New;
                var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRetencionCab);
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
                //ler nro de orden seleccionado 
                //numeroOrden = util.get
                numeroOrden = Util.GetCurrentCellText(gridControl, "CodigoOrdenCompra");
                // Inicio el constructor
                TipoMoneda = Util.GetCurrentCellText(gridControl, "Ban01Mon");
                Fecha = Util.GetCurrentCellText(gridControl, "RetencionFecha");
                RetencionNro = Util.GetCurrentCellText(gridControl, "RetencionNro");
                // Inicio el constructor
                var frmInstance = FrmRetencionCab.Instance(this);
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
        internal void UbicarCursor(string RetencionNro, string codigoEmpresa)
        {
            try
            {
                foreach (GridViewRowInfo row in gridControl.Rows)
                {
                    //string Mes = Util.GetCurrentCellText(row,"Mes");
                    string Retencion = Util.GetCurrentCellText(row, "RetencionNro");
                    if (RetencionNro == Retencion
                        && codigoEmpresa == Logueo.CodigoEmpresa)
                    {
                       
                        gridControl.CurrentRow = gridControl.Rows[row.Index];
                        
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                Util.ShowError("ERROR:: " + ex);
            }
        }

        public void TraerRetencion() 
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                List<RetencionCab> ListaRetencion = RetencionLogic.Instance.TraerRetencion(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
                this.gridControl.DataSource = ListaRetencion;
           
            }
            catch(Exception ex)
            {
                Util.ShowError("Error al traer datos de retencion : " + ex.Message);
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
                string  Ban01Numero = "", mensaje = "";
                int flag = 1;
                Ban01Numero = Util.GetCurrentCellText(gridControl.CurrentRow, "RetencionNro");
                RetencionLogic.Instance.Eliminar_Retencion(Logueo.CodigoEmpresa, Ban01Numero, out mensaje);
                Util.ShowMessage(mensaje, flag);

                if (flag == 1)
                {
                    TraerRetencion();
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) {
                Util.ShowAlert("Error al eliminar "+ ex);
            }
            
        }
        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            //if (this.gridControl.Rows.Count == 0) return;
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
                numeroOrden = Util.GetCurrentCellText(gridControl, "CodigoOrdenCompra");
                // Inicio el constructor
                TipoMoneda = Util.GetCurrentCellText(gridControl, "Ban01Mon");
                Fecha = Util.GetCurrentCellText(gridControl, "RetencionFecha");
                RetencionNro = Util.GetCurrentCellText(gridControl, "RetencionNro");
                var frmInstance = FrmRetencionCab.Instance(this);
                //frmInstance.tipoDocumento = Util.GetCurrentCellText(FrmParent.gridControl.CurrentRow, "FAC01COD");
                // Luego de iniciar el constructor , envio el flag de tipo de operacion
                //frmInstance.Estado = FormEstate.New;
                Estado = FormEstate.View;
                var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRetencionCab);
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
                                CreateGridColumn(grid, "Retencion", "RetencionNro", 0, "", 100, true, false, true);
                CreateGridColumn(grid, "Fecha", "RetencionFecha", 0, "", 70, true, false, true);
                CreateGridColumn(grid, "RUC", "Ban01Ruc", 0, "", 90, true, false, true);
                CreateGridColumn(grid, "Razon Social", "Ban01Proveedor", 0, "", 250, true, false, true);
                CreateGridColumn(grid, "Tipo de Cambio", "Ban01TipoCambio", 0, "{0:###,###0.0000}", 120, true, false, true, false, "right");
                CreateGridColumn(grid, "%", "Ban01Porcentaje", 0, "", 80, true, false, true,false,"right");
                CreateGridColumn(grid, "Total S/.", "TotalSoles", 0, "{0:###,###0.00}", 90, true, false, true,false,"right");
                CreateGridColumn(grid, "Ret S/.", "RetencionSoles", 0, "{0:###,###0.00}", 90, true, false, true, false, "right");
                CreateGridColumn(grid, "Total US$.", "TotalDolares", 0, "{0:###,###0.00}", 90, true, false, true, false, "right");
                CreateGridColumn(grid, "RET. US$.", "RetencionDolares", 0, "{0:###,###0.00}", 90, true, false, true, false, "right");
                CreateGridColumn(grid, "Estado Sunat", "EstadoSunat", 0, "{0:###,###0.00}", 100, true, false, true);
                CreateGridColumn(grid, "Reversion ", "Reversion", 0, "{0:###,###0.00}", 90, true, false, true);
                //campos visible = false
                CreateGridColumn(grid, "Moneda", "Ban01Mon", 0, "{0:###,###0.00}", 70, true, false, false);
                
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
                
            
                //List<DodcumentoOrdenCompra> lista = CompraDocumentoLogic.Instance(Logueo.CodigoEmpresa,
                //    Logueo.Anio, Logueo.Mes, "02", tipoOrden);
                //this.gridControl.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer datos de orden de compra, detalle : " + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        private void FrmRetencionLista_Load(object sender, EventArgs e)
        {
           // this.FormClosed += new FormClosedEventHandler(FrmRetencionLista_FormCLosed);
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVer);
           // HabilitaBotonPorNombre(BaseRegBotones.cbbAnulado);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPreliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVerFE);
            //HabilitaBotonPorNombre(BaseRegBotones.);

            
            this.AsignarToolTipBoton("anulado", "Anular factura");
            this.AsignarImageBoton("anulado", Properties.Resources.Menu_Mediano_CancelarDocumento_enabled);

            this.AsignarToolTipBoton("reporteretencion", "Ver reporte retencion");

            CrearColumnas();
            TraerRetencion();
            
        }
        protected override void OnVerFE()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string nombreReporte = "RptRegistroRetenciones.rpt";
                //string Ban01Numero = txtRetNro.Text.Trim();
                DataTable dt = RetencionLogic.Instance.Traer_RegistroRetenciones(Logueo.CodigoEmpresa, Logueo.Anio,Logueo.Mes);

                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = nombreReporte;
                reporte.DataSource = dt;

                reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                reporte.FormulasFields.Add(new Formula("RucEmpresa", Logueo.rucEmpresa));

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);

            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al traer vista preliminar");
            }
            Cursor.Current = Cursors.Default;
        }
        internal void RefrescarGrilla()
        {
            Cargar();
        }
       


        private void toolBar_Click(object sender, EventArgs e)
        {
             
        }

        private void toolBar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
