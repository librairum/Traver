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
    public partial class frmProvisionFacturas : frmBaseDocumento
    {
        internal string tipoOrden = "", nroOrden = "", fecha = "";
        internal string codigoProveedor = "", nombreProveedor = "";
        internal string tipoMoneda = "", tipoCambio = "";
        internal string ImpBruto = "", ImpDscto = "", ImpIgv = "", ImpTotal = "";
        internal string montoRegular = "", formaPago = "";
        internal string anio = "", mes = "";
        

        private static frmProvisionFacturas _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmProvisionFacturas Instance(frmMDI padre) {
            if (_aForm != null) return new frmProvisionFacturas(padre);
            _aForm = new frmProvisionFacturas(padre);
            return _aForm;
        }
        
        public frmProvisionFacturas(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }

        private void CrearColumnas() {
            try
            {
                RadGridView Grid = this.CreateGridVista(this.gridOrdenCompra);

                CreateGridColumn(Grid, "TipoOrden", "TipoOrden", 0, "", 70, true, false, false);
                CreateGridColumn(Grid, "Nro.\nOrden", "CodigoOrden", 0, "", 70);
                CreateGridColumn(Grid, "Fecha", "Fecha", 0, "{0:dd/MM/yyyy}", 70);
                CreateGridColumn(Grid, "Solicitud", "Solicitud", 0, "", 90);
                CreateGridColumn(Grid, "Proveed", "Proveed", 0, "", 90);
                CreateGridColumn(Grid, "NombreProveedor", "NombreProveedor", 0, "", 200);

                CreateGridColumn(Grid, "Estado\nAtencion", "EstadoAtencion", 0, "", 100, true, false, false);
                CreateGridColumn(Grid, "Estado\nAtencion", "EstadoAtencionDescripcion", 0, "", 100);

                CreateGridColumn(Grid, "Estado\nPago", "EstadoPago", 0, "", 70, true, false, false);
                CreateGridColumn(Grid, "Estado\nPago", "EstadoPagoDescripcion", 0, "", 100);



                CreateGridColumn(Grid, "anio", "anio", 0, "", 70, true, false, false);
                CreateGridColumn(Grid, "mes", "mes", 0, "", 70, true, false, false);

                //columna ajustar monto
                CreateGridColumn(Grid, "Monto\nRegularizar", "MontoRegularizar", 0, "{0:###,###0.00}", 100, 
                                     false, true, true, true, "right");
                Util.AddButtonsToGrid(Grid, BaseRegBotonesDetalle.btnRegularizar);
                //
                CreateGridColumn(Grid, "Moneda", "TipoMoneda", 0, "", 80, true, false, true, true, "right");

                //Tipo de cambio a 4 decimales
                //CreateGridColumn(Grid, "Cambio", "Cambio", 0, "{0:###,###0.00}", 90, true, false, true, true, "right");
                CreateGridDecimalColumn(Grid, "T.C", "TipoCambio", 0, "{0:F04}", 40, true, false, true, true, "right");

                CreateGridColumn(Grid, "Importe\nBruto", "ImporteBruto", 0, "{0:###,###0.00}", 90, true, false, true, true, "right");
                CreateGridColumn(Grid, "Des\ncuento", "Descuento", 0, "{0:###,###0.00}", 70, true, false, true, true, "right");
                CreateGridColumn(Grid, "Monto\nImporte", "MontoImporte", 0, "{0:###,###0.00}", 90, true, false, true, true, "right");
                CreateGridColumn(Grid, "Total", "Total", 0, "{0:###,###0.00}", 90, true, false, true, true, "right");
                //Forma Pago 
                CreateGridColumn(Grid, "FormaPago", "FormaPago", 0, "", 70, true, false, false);




                RadGridView GridDetalle = CreateGridVista(gridFactura);

                CreateGridColumn(GridDetalle, "T.T", "TipoDocumento", 0, "", 50);
                CreateGridColumn(GridDetalle, "Nro.", "NumeroDocumento", 0, "", 90);
                CreateGridColumn(GridDetalle, "Fecha", "Fecha", 0, "{0:dd/MM/yyyy}", 80);

                CreateGridColumn(GridDetalle, "T.M.", "TipoMoneda", 0, "", 60);
                CreateGridColumn(GridDetalle, "Importe", "Importe", 0, "{0:###,###0.00}", 100,
                                                EsLectura.Si, EsEditable.No, EsVisible.Si, EsNumero.Si,
                                                AlinearElemento.derecha); // formato ###,###,##0.00

                CreateGridColumn(GridDetalle, "T.C.", "TipoCambio", 0, "{0:###,###0.00}", 70,
                                            EsLectura.Si, EsEditable.No, EsVisible.Si, EsNumero.Si,
                                            AlinearElemento.derecha); // formato ###,##0.0000

                CreateGridColumn(GridDetalle, "Estado", "Estado", 0, "", 90, EsLectura.Si,
                                                  EsEditable.No, EsVisible.No, EsNumero.No,
                                                                AlinearElemento.izquierda);
                CreateGridColumn(GridDetalle, "Estado", "EstadoPagoDescripcion", 0, "", 90,
                                                 EsLectura.Si, EsEditable.No, EsVisible.No,
                                                    EsNumero.No, AlinearElemento.izquierda);
                
                CreateGridColumn(GridDetalle, "S.D.", "Libro", 0, "", 70);
                CreateGridColumn(GridDetalle, "Voucher", "Voucher", 0, "", 90);

                CreateGridColumn(GridDetalle, "T.D.", "InvTipo", 0, "", 70);
                CreateGridColumn(GridDetalle, "Documento", "CO05INVNRO", 0, "", 90);

                CreateGridColumn(GridDetalle, "Anio", "Anio", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "Mes", "Mes", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "Tipo", "Tipo", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "Codigo", "Codigo", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "FechaVencimiento", "FechaVencimiento", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "FechaPago", "FechaPago", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "PorIgv", "PorIgv", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "ImpBruto", "ImpBruto", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "ImpIna", "ImpIna", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "ImpIgv", "ImpIgv", 0, "", 70, true, false, false);
                
                CreateGridColumn(GridDetalle, "CO05IMPBDOL", "CO05IMPBDOL", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05IMPINADOL", "CO05IMPINADOL", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05IMPIGVDOL", "CO05IMPIGVDOL", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05IMPDOL", "CO05IMPDOL", 0, "", 70, true, false, false);
                
                
                
                
                CreateGridColumn(GridDetalle, "CO05ASITIP", "CO05ASITIP", 0, "", 70, true, false, false);
                
                CreateGridColumn(GridDetalle, "CO05INVTRANS", "CO05INVTRANS", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05INVFEC", "CO05INVFEC", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05NROAUTORIZACION", "CO05NROAUTORIZACION", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05CON", "CO05CON", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05BIENOSERVSUNAT", "CO05BIENOSERVSUNAT", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05AFECTORET", "CO05AFECTORET", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05AFECTODETRACCION", "CO05AFECTODETRACCION", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05DETRATIPOPERACION", "CO05DETRATIPOPERACION", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05DETRAPORCENTAJE", "CO05DETRAPORCENTAJE", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05DETRAIMPORTE", "CO05DETRAIMPORTE", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05DETRAIMPORTE_EQUI", "CO05DETRAIMPORTE_EQUI", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CodCte", "CodCte", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05DETRATIPOSERVICIO", "CO05DETRATIPOSERVICIO", 0, "", 70, true, false, false);
                //CreateGridColumn(GridDetalle, "CO05INVTRANS", "CO05INVTRANS", 0, "", 70, true, false, false);
                //CreateGridColumn(GridDetalle, "CO05INVNRO", "CO05INVNRO", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05INVREFDOC", "DocumentoReferencia", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "Importe S/.", "ImpTotal", 0, "", 70, true, false, false);
             
   
                CreateGridColumn(GridDetalle, "CentroCosto", "CentroCosto", 0, "", 70, true, false, true);
                CreateGridColumn(GridDetalle, "CentroCostoDescripcion", "CentroCostoDescripcion", 0, "", 70, true, false, true);

                CreateGridColumn(GridDetalle, "docmodtipo", "docmodtipo", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "docmodnumero", "docmodnumero", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "docmodfecha", "docmodfecha", 0, "", 70, true, false, false);

                
            }
            catch (Exception ex) {
                Util.ShowError("Error al crear columnas , detalle:" + ex.Message);
            }

        }
        private void Cargar()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string flagOrden = "";
                if (rbOrdenCompra.Checked)
                {
                    flagOrden = "C";
                }
                else if(rbOrdenTrabajo.Checked){
                    flagOrden = "T";
                }

                List<ProvisionamientoOrdenCompra> lista =
                ProvisionamientoLogic.Instance.TraeProvisionamientos(Logueo.CodigoEmpresa, dtpFechaIni.Value.ToShortDateString(),
                dtpFechaFin.Value.ToShortDateString(), "02", flagOrden);
                this.gridOrdenCompra.DataSource = lista;
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        internal void CargarFactura( ) {
            string anio = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "anio");
            string mes = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "mes");
            string tipoOrden = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "TipoOrden");
            string nroOrden = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "CodigoOrden");
                
                List<ProvisionamientoOrdenCompraDetalle> listaDetalle =
                        ProvisionamientoLogic.Instance.TraeProvisionamientosDetalle(Logueo.CodigoEmpresa,
                        anio, mes, tipoOrden, nroOrden, anio, mes);
                this.gridFactura.DataSource = listaDetalle;
        }

        
        private string DameDescripcion(string codigo, string flag)
        {

            string descripcion = "";
            GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, codigo, flag, out descripcion);
            return descripcion;

        }
        private void frmProvisionFacturas_Load(object sender, EventArgs e)
        {
            
            OcultarBarraBotones();
            //OcultarBotones();
            //HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);

            //HabilitaBotonPorNombre(BaseRegBotones.cbbVer);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbRefrescar);


            string fechaFormateado = "01" + "/" + Logueo.Mes + "/" + Logueo.Anio;
            DateTime fechaInicio = Convert.ToDateTime(fechaFormateado);
            
            int diasdelmes = DateTime.DaysInMonth(Convert.ToInt16(Logueo.Anio), Convert.ToInt16(Logueo.Mes));
            string fechaFinalFormateado = Convert.ToString(diasdelmes) + "/" + Logueo.Mes + "/" + Logueo.Anio;
            DateTime fechaFin = Convert.ToDateTime(fechaFinalFormateado);
            

            dtpFechaIni.Value = fechaInicio;
            dtpFechaFin.Value = fechaFin;

            CrearColumnas();
            Cargar();
        }

        private void gridOrdenCompra_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (gridOrdenCompra.Rows.Count == 0) return;
            Cursor.Current = Cursors.WaitCursor;
            try
            {                
                CargarFactura();                
            }
            catch (Exception ex) {
                Util.ShowAlert("Error al cambiar registro");
            }
            Cursor.Current = Cursors.Default;
        }

        private void VerRegularizacion(bool estado) 
        {
            
        }

        private void gridOrdenCompra_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridCommandCellElement cellElemet = e.CellElement as GridCommandCellElement;
            if (cellElemet == null) return;
            if (e.CellElement.ColumnInfo is GridViewCommandColumn) {
                RadButtonElement commandButton = ((RadButtonElement)((GridCommandCellElement)cellElemet).Children[0]);

                commandButton.Image = Properties.Resources.regularizar_enabled;
                commandButton.ImageAlignment = ContentAlignment.MiddleCenter;

            }
        }
        private void RegularizarFactura() 
        {
            double monto = Util.GetCurrentCellDbl(gridOrdenCompra, "MontoRegularizar");
            if (monto == 0)
            {
                Util.ShowAlert("ingresar un valor mayor a cero");
                Util.SetCellInitEdit(gridOrdenCompra.CurrentRow, "MontoRegularizar");
            }
            else {
                Util.ShowAlert("Regularizacion aplicado a Factura");
            }
            
        }

        private void gridOrdenCompra_CommandCellClick(object sender, EventArgs e)
        {

            if (Util.IsCurrentColumn(gridOrdenCompra.CurrentColumn, 
                                "btnRegularizar")) 
            {
                RegularizarFactura();
            }
        }
        private void AbrirFormulario() { 
            
             
            //frmProvFacturaDet
            var frmInstance = frmProvFacturaDetOC.Instance(this);
            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProvFacturaDetOC);
            if (frmExist != null) {
                frmInstance.BringToFront(); return;
            }

            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            frmInstance.MdiParent = this.ParentForm;
            
            ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);
            frmInstance.Show();
        }

        private void cbbNuevo_Click(object sender, EventArgs e)
        {
           
            Estado = FormEstate.New;

            tipoOrden = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "TipoOrden");
            nroOrden = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "CodigoOrden");
            formaPago = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "FormaPago");
            codigoProveedor = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "Proveed");                        
            anio = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "anio");
            mes = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "mes");
            tipoMoneda = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "TipoMoneda");
            
            AbrirFormulario();
        }

        private void cbbEditar_Click(object sender, EventArgs e)
        {
            
             try
            {
                Estado = FormEstate.Edit;
                tipoOrden = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "TipoOrden");
                nroOrden = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "CodigoOrden");
                formaPago = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "FormaPago");
                codigoProveedor = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "Proveed");
                anio = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "anio");
                mes = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "mes");
                fecha = Util.GetCurrentCellText(this.gridOrdenCompra.CurrentRow, "Fecha");                 
                tipoMoneda = Util.GetCurrentCellText(this.gridOrdenCompra.CurrentRow, "TipoMoneda");

                AbrirFormulario();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al editar");
            }
        }

        private void cbbEliminar_Click(object sender, EventArgs e)
        {
            Estado = FormEstate.List;
            EliminarFactura();
        }

        private void dtpFechaIni_ValueChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void dtpFechaFin_Validating(object sender, CancelEventArgs e)
        {

        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            Cargar();
        }
        
        //UBICAR CURSOR
        internal void UbicarCursor(string CO05CODEMP, string CO05AA, string CO05MES, string CO05TIPO, string CO05CODIGO, string CO05TIPDOC, string CO05NRODOC, string CO05CODCTE)
        {
            foreach (GridViewRowInfo row in gridFactura.Rows)
            {
                //string Mes = Util.GetCurrentCellText(row,"Mes");

                if(CO05CODEMP == Logueo.CodigoEmpresa
                    && CO05AA == Logueo.Anio
                    && CO05MES == Util.GetCurrentCellText(row, "Mes")
                    && CO05TIPO == Util.GetCurrentCellText(row, "Tipo")
                    && CO05CODIGO == Util.GetCurrentCellText(row, "Codigo")
                    && CO05TIPDOC == Util.GetCurrentCellText(row, "TipoDocumento")
                    && CO05NRODOC == Util.GetCurrentCellText(row, "NumeroDocumento")
                    && CO05CODCTE == Util.GetCurrentCellText(row, "CodCte"))
                {
                    gridFactura.CurrentRow = gridFactura.Rows[row.Index];
                    return;
                }
            }
        }

        //END CURSOR


        private void EliminarFactura()
        {
            Cursor.Current = Cursors.WaitCursor;

            string anio = "", mes = "", libroContable = "", VoucherContableNro = "", tipoOrdenCompra = "",
                        nroDocumentoOrdenCompra = "", tipoDocProvisionamiento = "", nroDocProvisionamiento = "",
                        anioOrdenCompra = "", mesOrdenCompra = "", codigoCuentaCorriente = "";
            string invTipo = "", invNroDocumento = "", invFecha = "", tipoCambio = "", moneda = "";
            string mensaje = ""; int flag = 0;
            
            try
            {
                bool respuesta = Util.ShowQuestion("¿Esta seguro de eliminar la provision?");
                if (respuesta == false) { return; }
                GridViewRowInfo fila = gridFactura.MasterView.CurrentRow;
                
                anio = Logueo.Anio;
                mes = Util.GetCurrentCellText(fila, "Mes");
                libroContable = Util.GetCurrentCellText(fila, "Libro");
                VoucherContableNro = Util.GetCurrentCellText(fila, "Voucher");
                
                tipoOrdenCompra = Util.GetCurrentCellText(fila, "Tipo");
                nroDocumentoOrdenCompra = Util.GetCurrentCellText(fila, "Codigo");
                
                tipoDocProvisionamiento = Util.GetCurrentCellText(fila, "TipoDocumento");
                nroDocProvisionamiento = Util.GetCurrentCellText(fila, "NumeroDocumento");

                anioOrdenCompra = Logueo.Anio;
                mesOrdenCompra = Util.GetCurrentCellText(fila, "Mes");

                codigoCuentaCorriente = Util.GetCurrentCellText(fila, "CodCte");

                //Valida Si periodo esta cerrado
                
                //Elimino Compras
                flag = 0; mensaje = "";
                ProvisionFacturaLogic.Instance.Eliminar(Logueo.CodigoEmpresa, anio, mes, tipoOrdenCompra, nroDocumentoOrdenCompra, tipoDocProvisionamiento,
                        nroDocProvisionamiento, anioOrdenCompra, mesOrdenCompra, codigoCuentaCorriente, out flag, out mensaje);
                 
                if (flag != 1)
                        {
                            // Muestra error si es diferente de 1
                            Util.ShowMessage(mensaje, flag);
                            return;
                        }

                
                //Elimino contabilidad
                flag = 0; mensaje = "";
                if ((libroContable!="")  && (VoucherContableNro!=""))

                {
                ProvisionFacturaLogic.Instance.EliminarDocumentoContabilidad(Logueo.CodigoEmpresa, 
                                        anio, mes, libroContable, VoucherContableNro, out flag, out mensaje);
                    

                    if (flag != 1) {
                        // Muestra error si es diferente de 1
                        Util.ShowMessage(mensaje, flag);
                        return;
                    }
                }



                //Elimino inventario (Movimiento)

                invTipo = Util.GetCurrentCellText(fila, "InvTipo");
                invNroDocumento = Util.GetCurrentCellText(fila, "CO05INVNRO");
                invFecha = Util.GetCurrentCellText(fila, "CO05INVFEC");
                tipoCambio = Util.GetCurrentCellText(fila, "TipoCambio");

                if ((invTipo != "") && (invNroDocumento != ""))
                    {
                        flag=0; mensaje = "";
                        ProvisionFacturaLogic.Instance.EliminarDocumentoInventario(Logueo.CodigoEmpresa, anio, 
                        mes, invTipo, invNroDocumento,  "E", invFecha, tipoCambio, moneda, out flag, out mensaje);
                
                        if (flag != 1) {
                            Util.ShowMessage(mensaje, flag);
                            return;
                        }
                    }


                // Como llego al final no hubro error y
                Util.ShowMessage("OK :: Se elimino con exito", 1);

                //Actualizao orden de compra
                    ProvisionFacturaLogic.Instance.TraeControlOrdCompXOrdCom(Logueo.CodigoEmpresa, anioOrdenCompra, mes, "C", nroDocumentoOrdenCompra);
                    
                //Refresco Grilla

                this.Cargar();
                
            }
            catch (Exception ex) {
                Util.ShowError("Error al eliminar provision");
            }
            Cursor.Current = Cursors.Default;

        }

        private void rbOrdenCompra_CheckedChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void rbOrdenTrabajo_CheckedChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gridFactura_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                cbbEditar_Click(sender,e);
            //Cursor.Current = Cursors.WaitCursor;
            //if (gridFactura.Rows.Count == 0) return;
            ////Estado = FormEstate.View;
            //Estado = FormEstate.Edit;

            //tipoOrden = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "TipoOrden");
            //nroOrden = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "CodigoOrden");
            //formaPago = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "FormaPago");
            //codigoProveedor = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "Proveed");
            //anio = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "anio");
            //mes = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "mes");
            //fecha = Util.GetCurrentCellText(this.gridOrdenCompra.CurrentRow, "Fecha");
            //tipoMoneda = Util.GetCurrentCellText(this.gridOrdenCompra.CurrentRow, "TipoMoneda");

            //AbrirFormulario();
            //Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al editar");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
