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
using Com.UI.Win.Procesos;
using System.Linq;

namespace Com.UI.Win
{
    public partial class frmProvFacturaSinOC : frmBaseDocumento
    {

        internal string tipoOrden = "", nroOrden = "", fecha = "";
        internal string codigoProveedor = "", nombreProveedor = "";
        internal string tipoMoneda = "", tipoCambio = "";
        internal string ImpBruto = "", ImpDscto = "", ImpIgv = "", ImpTotal = "";
        internal string montoRegular = "", formaPago = "";
        internal string anio = "", mes = "";

      


        private static frmProvFacturaSinOC _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmProvFacturaSinOC Instance(frmMDI padre) {
            if (_aForm != null) return new frmProvFacturaSinOC(padre);
            _aForm = new frmProvFacturaSinOC(padre);
            return _aForm;
        }
        
        public frmProvFacturaSinOC(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }


        private void CrearColumnas() {
            
            try
            {
                RadGridView GridDetalle = CreateGridVista(gridFactura);
                CreateGridColumn(GridDetalle, "Tipo", "TipoDocumento", 0, "", 70);
                CreateGridColumn(GridDetalle, "NumeroDocumento", "NumeroDocumento", 0, "", 90);
                CreateGridColumn(GridDetalle, "Moneda", "TipoMoneda", 0, "", 50);
                CreateGridColumn(GridDetalle, "Fecha", "Fecha", 0, "{0:dd/MM/yyyy}", 90);
                CreateGridColumn(GridDetalle, "Proveedor", "CodCte", 0, "", 90);
                CreateGridColumn(GridDetalle, "Nombre Proveedor", "NombreProveedor", 0, "", 200);
                CreateGridColumn(GridDetalle, "Concepto", "CO05CON", 0, "", 200);
                CreateGridColumn(GridDetalle, "Importe S/.", "ImpTotal", 0, "{0:###,###0.00}", 120, true, false, true, true, "right");
                CreateGridColumn(GridDetalle, "Importe U$", "CO05IMPDOL", 0, "{0:###,###0.00}", 120, true, false, true, true, "right");

                CreateGridColumn(GridDetalle, "libro", "libro", 0, "", 50);
                CreateGridColumn(GridDetalle, "nro", "voucher", 0, "", 80);
                CreateGridColumn(GridDetalle, "a.tipo", "co05asitip", 0, "", 70);
                CreateGridColumn(GridDetalle, "estado", "estado", 0, "", 70);
                
                // Campos Ocultos
                CreateGridColumn(GridDetalle, "Mes", "Mes", 0, "", 70, true, false, false, false, "");
                CreateGridColumn(GridDetalle, "FechaVencimiento", "FechaVencimiento", 0, "{0:dd/MM/yyyy}", 70, true, false, false, false, "");
                CreateGridColumn(GridDetalle, "FechaPago", "FechaPago", 0, "", 70, true, false, false, false, "");
                CreateGridColumn(GridDetalle, "PorIgv", "PorIgv", 0, "", 70, true, false, false, false, "");
                CreateGridColumn(GridDetalle, "TipoCambio", "TipoCambio", 0, "", 70, true, false, false, false, "");
                CreateGridColumn(GridDetalle, "CO05BIENOSERVSUNAT", "CO05BIENOSERVSUNAT", 0, "", 70, true, false, false, false, "");
                CreateGridColumn(GridDetalle, "CO05AFECTODETRACCION", "CO05AFECTODETRACCION", 0, "", 70, true, false, false, false, "");
                CreateGridColumn(GridDetalle, "CO05AFECTORET", "CO05AFECTORET", 0, "", 70, true, false, false, false, "");
                CreateGridColumn(GridDetalle, "CO05DETRATIPOPERACION", "CO05DETRATIPOPERACION", 0, "", 70, true, false, false, false, "");
                CreateGridColumn(GridDetalle, "CO05DETRATIPOSERVICIO", "CO05DETRATIPOSERVICIO", 0, "", 70, true, false, false, false, "");
                CreateGridColumn(GridDetalle, "CO05DETRAPORCENTAJE", "CO05DETRAPORCENTAJE", 0, "", 70, true, false, false, false, "");
                CreateGridColumn(GridDetalle, "CO05DETRAIMPORTE", "CO05DETRAIMPORTE", 0, "", 70, true, false, false, false, "");
                CreateGridColumn(GridDetalle, "CO05DETRAIMPORTE_EQUI", "CO05DETRAIMPORTE_EQUI", 0, "", 70, true, false, false, false, "");
                CreateGridColumn(GridDetalle, "ImpBruto", "ImpBruto", 0, "", 70, true, false, false, true);
                CreateGridColumn(GridDetalle, "ImpIna", "ImpIna", 0, "", 70, true, false, false, true);
                CreateGridColumn(GridDetalle, "ImpIgv", "ImpIgv", 0, "", 70, true, false, false, true);
                CreateGridColumn(GridDetalle, "Importe", "Importe", 0, "", 70, true, false, false,true);

                CreateGridColumn(GridDetalle, "CO05IMPBDOL", "CO05IMPBDOL", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05IMPINADOL", "CO05IMPINADOL", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "CO05IMPIGVDOL", "CO05IMPIGVDOL", 0, "", 70, true, false, false);

                CreateGridColumn(GridDetalle, "Estado Fact.", "ESTADOFACTURA", 0, "", 120, true, false, true);
                CreateGridColumn(GridDetalle, "CentroCosto", "CentroCosto", 0, "", 70, true, false, true);
                CreateGridColumn(GridDetalle, "CentroCostoDescripcion", "CentroCostoDescripcion", 0, "", 70, true, false, true);

                CreateGridColumn(GridDetalle, "docmodtipo", "docmodtipo", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "docmodnumero", "docmodnumero", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "docmodfecha", "docmodfecha", 0, "", 70, true, false, false);

                CreateGridColumn(GridDetalle, "O.Compra Tipo", "Tipo", 0, "", 70, true, false, false);
                CreateGridColumn(GridDetalle, "O.Compra Codigo", "Codigo", 0, "", 70, true, false, false);
                
            }
            catch (Exception ex) {
                Util.ShowAlert("Error al crear columnas");
            }
        }
        private void AbrirFormulario()
        {

            //frmProvFacturaDet
            var frmInstance = frmProvFacturaDetSinOC.Instance(this);
            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProvFacturaDetOC);
            if (frmExist != null)
            {
                frmInstance.BringToFront(); return;
            }

            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            frmInstance.MdiParent = this.ParentForm;

            ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);
            frmInstance.Show();
        }

        private void frmProvFacturaSinOC_Load(object sender, EventArgs e)
        {            
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVista);
            string fechaFormateado = "01" + "/" + Logueo.Mes + "/" + Logueo.Anio;
            DateTime fechaInicio = Convert.ToDateTime(fechaFormateado);
       
            int diasdelmes = DateTime.DaysInMonth(Convert.ToInt16(Logueo.Anio), Convert.ToInt16(Logueo.Mes));
            string fechaFinalFormateado = Convert.ToString(diasdelmes) + "/" + Logueo.Mes + "/" + Logueo.Anio;
            DateTime fechaFin = Convert.ToDateTime(fechaFinalFormateado);
            

            CrearColumnas();
            Cargar("*");
        }
        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            //tipoOrden = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "TipoOrden");
            //nroOrden = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "CodigoOrden");
            //formaPago = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "FormaPago");
            //codigoProveedor = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "Proveed");
            //anio = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "anio");
            //mes = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "mes");
            //tipoMoneda = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "TipoMoneda");

            AbrirFormulario();
        }

        protected override void OnEditar()
        {
            Estado = FormEstate.Edit;
            //tipoOrden = Util.GetCurrentCellText(gridFactura.CurrentRow, "Tipo");
            //nroOrden = Util.GetCurrentCellText(gridFactura.CurrentRow, "Codigo");
            //formaPago = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "FormaPago");
            //codigoProveedor = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "Proveed");
            //anio = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "anio");
            //mes = Util.GetCurrentCellText(gridOrdenCompra.CurrentRow, "mes");
            //fecha = Util.GetCurrentCellText(this.gridOrdenCompra.CurrentRow, "Fecha");
            //tipoMoneda = Util.GetCurrentCellText(this.gridOrdenCompra.CurrentRow, "TipoMoneda");
            this.mes = Util.GetCurrentCellText(gridFactura, "Mes");
            this.anio = Logueo.Anio;
            AbrirFormulario();
        }

        protected override void OnEliminar()
        {
            if (gridFactura.Rows.Count == 0) { Util.ShowAlert("No tiene registros para eliminar"); }
            try
            {
                GridViewRowInfo fila = gridFactura.MasterView.CurrentRow;
                string anio = "", mes = "", VoucherContablelibro = "", VoucherContablenumero = "", tipoOrdenCompra = "", 
                       nroDocumentoOrdenCompra = "", tipoDocProvisionamiento = "", nroDocProvisionamiento = "", 
                       anioOrdenCompra = "", mesOrdenCompra = "", codigoCuentaCorriente = "";

                int flagContabilidad = 0; string mensajeContabilidad = "";


                anio = Logueo.Anio;
                mes = Util.GetCurrentCellText(fila, "Mes");
                VoucherContablelibro = Util.GetCurrentCellText(fila, "Libro");
                VoucherContablenumero = Util.GetCurrentCellText(fila, "Voucher");
                
                tipoOrdenCompra = Util.GetCurrentCellText(fila, "tipo");
                nroDocumentoOrdenCompra = Util.GetCurrentCellText(fila, "codigo");
                
                tipoDocProvisionamiento = Util.GetCurrentCellText(fila, "TipoDocumento");
                nroDocProvisionamiento = Util.GetCurrentCellText(fila, "NumeroDocumento");
                anioOrdenCompra = Logueo.Anio;
                mesOrdenCompra = Util.GetCurrentCellText(fila, "Mes");
                codigoCuentaCorriente =  Util.GetCurrentCellText(fila, "CodCte");
                if (Logueo.ComprasPeriodoCerrado == "S") { 
                    Util.ShowAlert("No Se Puede Eliminar Factura, Pertenece a un Periodo Cerrado");
                }
                int flag = 0; string mensaje = "";

               
                bool respuesta = Util.ShowQuestion("Esta seguro de eliminar la provision?");
                if (respuesta == true) 
                {

                // Elimino Provision 
                ProvisionFacturaLogic.Instance.Eliminar(Logueo.CodigoEmpresa, Logueo.Anio, mes, tipoOrdenCompra, nroDocumentoOrdenCompra, tipoDocProvisionamiento,
                        nroDocProvisionamiento, anioOrdenCompra, mesOrdenCompra, codigoCuentaCorriente, out flag, out mensaje);
                        if (flag != 1)
                        {
                            Util.ShowMessage(mensaje, flag);
                            return;
                        }       

                // Elimino Voucher Contable    

                   if ((VoucherContablelibro != "") && (VoucherContablenumero != ""))
                   {
                       
                        ProvisionFacturaLogic.Instance.EliminarDocumentoContabilidad(Logueo.CodigoEmpresa, Logueo.Anio,
                            mes, VoucherContablelibro, VoucherContablenumero, out flagContabilidad, out mensajeContabilidad);

                        if (flagContabilidad != 1)
                        {
                            Util.ShowMessage(mensaje, flag);
                            return;
                        } 

                    }
                
                }

                // Si llega hasta este punto , es porque todo esta correcto, Cargo
                Cargar("*");

                // Si llega hasta este punto , es porque todo esta correcto, muestro mensaje

            }
            catch (Exception) {
                Util.ShowAlert("ERROR :: Al eliminar");
            }
           
        }
        internal void UbicarCursor(string CO05CODEMP, string CO05AA, string CO05MES, string CO05TIPO, string CO05CODIGO, string CO05TIPDOC, string CO05NRODOC, string CO05CODCTE) 
        {
            foreach (GridViewRowInfo row in gridFactura.Rows)
            {
                //string Mes = Util.GetCurrentCellText(row,"Mes");

                if (CO05CODEMP == Logueo.CodigoEmpresa
                    && CO05AA == Logueo.Anio
                    && CO05MES == Util.GetCurrentCellText(row, "Mes")
                    && CO05TIPO == Util.GetCurrentCellText(row, "Tipo")
                    && CO05CODIGO == Util.GetCurrentCellText(row, "Codigo")
                    && CO05TIPDOC == Util.GetCurrentCellText(row, "TipoDocumento")
                    && CO05NRODOC == Util.GetCurrentCellText(row, "NumeroDocumento")
                    && CO05CODCTE == Util.GetCurrentCellText(row, "CodCte"))
                {
                    //GridViewRowInfo filaActual = row.Index
                    //int IndiceFila = filaActual.Index;}

                       gridFactura.CurrentRow = gridFactura.Rows[row.Index];
                    return;
                }
            }
        }

        internal void Cargar(string filtro, string faturaTipo = "", string facturaNro = "")
        {
            Cursor.Current = Cursors.WaitCursor;
            List<ProvisionamientoOrdenCompraDetalle> lista =
            ProvisionFacturaLogic.Instance.TraeDocumentosSinOCPorPeriododeregistro(Logueo.CodigoEmpresa, Logueo.Anio,Logueo.Mes,"0",Logueo.TipoAnalisisProveedor);
            this.gridFactura.DataSource = lista;
            Cursor.Current = Cursors.Default;
         //ProvisionamientoLogic.Instance.Tra
        }

        private void gridFactura_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (gridFactura.Rows.Count == 0) return;
            this.mes = Util.GetCurrentCellText(gridFactura, "Mes");
            this.anio = Logueo.Anio;
            Estado = FormEstate.View;
            AbrirFormulario();


        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            Cargar("*");
        }

        
    }
}
