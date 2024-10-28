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

namespace Com.UI.Win.Procesos
{
    public partial class frmProvFacturaDetSinOC : frmBaseMante
    {

        private static frmProvFacturaDetSinOC _aForm;
        internal string tipoDocumento = "", nroDocumento = "",
        fechaDocumento = "", fechaVencimiento = "", libro = "",
        nroVoucher = "", porcentajeIgv = "", importeAfecto = "",
        importeInafecto = "", importeIgv = "", importeDocumento = "",
        tipoMoneda = "", tipoCambio = "", mesProvision = "",
        concepto = "", asientoTipo = "", anioFactura = "", mesFactura = "",
        OCTipo = "", OCNumero = "";

        string formatonumero = "{0:###,###,##0.00}";
        internal bool tieneDetraccion = false;
        int contadorerrorfecha = 0;


        #region "Instancia Provision factura sin Orden de compra"
        private frmProvFacturaSinOC FrmParentSinOC { get; set; }
        public static frmProvFacturaDetSinOC Instance(frmProvFacturaSinOC padre)
        {
            if (_aForm != null) return new frmProvFacturaDetSinOC(padre);
            _aForm = new frmProvFacturaDetSinOC(padre);
            return _aForm;
        }

        public frmProvFacturaDetSinOC(frmProvFacturaSinOC padre)
        {
            InitializeComponent();
            FrmParentSinOC = padre;
            this.Text = "Detalle de factura sin orden de compra";

        }

        #endregion
        #region "Metodos Contabilidad"
        private void CargarContabidad(GridViewRowInfo fila)
        {
            //bool activarControlesContabilidad = true;
            //activarControlesContabilidad = esDocumentoContabilizado();
            //txtLibro.Enabled = activarControlesContabilidad;
            //txtNroVoucher.Enabled = activarControlesContabilidad;
            //txtAsientoTipo.Enabled = activarControlesContabilidad;

            txtLibro.Text = Util.GetCurrentCellText(fila, "Libro");
            txtNroVoucher.Text = Util.GetCurrentCellText(fila, "Voucher");

            txtAsientoTipo.Text = Util.GetCurrentCellText(fila, "CO05ASITIP");
            string descripcion = DameDescripcion(Logueo.CodigoEmpresa + txtAsientoTipo.Text.Trim(), "AST");
            txtAsientoTipoDesc.Text = descripcion;
        }
        private void LeerContabilidad(ProvisionFactura entidad)
        {
            entidad.libro = txtLibro.Text;
            entidad.NumeroVoucher = txtNroVoucher.Text;
            entidad.AsientoTipo = txtAsientoTipo.Text;

        }
        private void ProcesarContabilidad()
        {
            if (txtAsientoTipo.Enabled == true && txtNroVoucher.Enabled == true && txtLibro.Enabled == true)
            {
                if (txtAsientoTipo.Text != "" && txtNroVoucher.Text != "" && txtLibro.Text != "")
                {
                    GrabarVoucher();
                }
            }
        }
        private double DevolverImportePorMoneda(string tipoMoneda, string Importe1, string Importe2)
        {
            double importeSalida = 0;
            if (txtTipoMoneda.Text.ToUpper().Trim() == "S")
            {
                importeSalida = Convert.ToDouble(Importe1);
            }
            else
            {
                importeSalida = Convert.ToDouble(Importe2);
            }
            return importeSalida;

        }
        private void AsignarHabSolesyHabDolares(string ValorAfin, out double SalidaHabSoles, out double SalidaHabDolares)
        {
            double HabSol = 0, HabDol = 0;
            if (ValorAfin == "1" || ValorAfin == "2" || ValorAfin == "3")
            {

                HabSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteAfecto.Text, txtImporteAfectoEquiv.Text);
                HabDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteAfectoEquiv.Text, txtImporteAfecto.Text);
            }

            if (ValorAfin == "4" || ValorAfin == "5" || ValorAfin == "9" || ValorAfin == "2")
            {
                HabSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteInafecto.Text, txtImporteInafectoEquiv.Text);
                HabDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteInafectoEquiv.Text, txtImporteInafecto.Text);
            }

            if (ValorAfin == "6" || ValorAfin == "7" || ValorAfin == "8")
            {
                HabSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteIgv.Text, txtImporteIgvEquiv.Text);
                HabDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteIgvEquiv.Text, txtImporteIgv.Text);
            }

            if (ValorAfin == "0")
            {
                HabSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteDocumento.Text, txtImporteDocumentoEquiv.Text);
                HabDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteDocumentoEquiv.Text, txtImporteDocumento.Text);
            }
            SalidaHabSoles = HabSol;
            SalidaHabDolares = HabDol;

        }
        private void AsignarDebSolesyDebDolares(string ValorAfin, out double SalidaDebSoles, out double SalidaDebDolares)
        {

            double DebSol = 0, DebDol = 0;
            if (ValorAfin == "1" || ValorAfin == "2" || ValorAfin == "3")
            {
                DebSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteAfecto.Text, txtImporteAfectoEquiv.Text);
                DebDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteAfectoEquiv.Text, txtImporteAfecto.Text);
            }

            if (ValorAfin == "4" || ValorAfin == "5" || ValorAfin == "9")
            {
                DebSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteInafecto.Text, txtImporteInafectoEquiv.Text);
                DebDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteInafectoEquiv.Text, txtImporteInafecto.Text);
            }
            if (ValorAfin == "6" || ValorAfin == "7" || ValorAfin == "8")
            {
                DebSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteIgv.Text, txtImporteIgvEquiv.Text);
                DebDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteIgvEquiv.Text, txtImporteIgv.Text);
            }

            if (ValorAfin == "0")
            {
                DebSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteDocumento.Text, txtImporteDocumentoEquiv.Text);
                DebDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteDocumentoEquiv.Text, txtImporteDocumento.Text);
            }

            SalidaDebSoles = DebSol;
            SalidaDebDolares = DebDol;
        }
        private bool esDocumentoContabilizado()
        {
            bool encontroRegistros = false;
            float CantidadRegistros = 0;
            GlobalLogic.Instance.ComprasTraeDimeExisteVoucher(Logueo.CodigoEmpresa,
                    Logueo.Anio, Logueo.Mes, txtLibro.Text, txtNroVoucher.Text,
                    out CantidadRegistros);
            encontroRegistros = CantidadRegistros > 0 ? true : false;
            return encontroRegistros;
        }
        #endregion


        
        private void CrearColumnas()
        {

            Telerik.WinControls.UI.RadGridView Grid = CreateGridVista(grdiCtaCte);
            CreateGridColumn(Grid, "Tipo", "Tipo", 0, "", 70);
            CreateGridColumn(Grid, "PagoFecha", "PagoFecha", 0, "", 90);
            CreateGridColumn(Grid, "Banco", "Banco", 0, "", 70);
            CreateGridColumn(Grid, "PagoNro", "PagoNro", 0, "", 100);
            CreateGridColumn(Grid, "ImporteSol", "ImporteSol", 0, "", 100, true, false, true, true);
            CreateGridColumn(Grid, "ImporteDol", "ImporteDol", 0, "", 100,true,false,true,true);
        }
        

        #region "Metodos Contabilidad"
        private VoucherDetalle LeerDetalleVoucher(ComprasAsientoTipoDetalle registro, double importeDebe, double importeHaber,
                                                     double importeDebeEquivalencia, double importeHaberEquivalencia, string CentroCosto)
        {
            VoucherDetalle detalle = new VoucherDetalle();
            detalle.CodigoEmpresa = Logueo.CodigoEmpresa;
            detalle.Anio = Logueo.Anio;
            detalle.Mes = txtMesProvision.Text;
            detalle.libro = txtLibro.Text;
            detalle.NumeroVoucher = txtNroVoucher.Text;
            detalle.cuenta = registro.ccd03def;
            detalle.ImporteDebe = importeDebe;
            detalle.ImporteHaber = importeHaber;
            //detalle.debSol = DebeSoles;
            //detalle.habSol = HaberSoles;
            detalle.glosa = txtConcepto.Text;
            detalle.TipoDocumento = txtTipoDocumento.Text;
            detalle.NumDoc = txtnrodocumento.Text;
            detalle.FechaDoc = dtpFechaDocumento.Value;
            detalle.FechaVencimiento = dtpFechaVencimiento.Value;
            //
            detalle.DocModTipo = txtdocmodtipo.Text.Trim();
            detalle.DocModNumero = txtdocmodnumero.Text.Trim();
            detalle.DocModFecha = dtpdocmodfecha.Value;
            

            //string codigoProveedor = FrmParentConOC.codigoProveedor;
            string codigoProveedor = txtProveedor.Text.Trim();
            detalle.CuentaCorriente = codigoProveedor;
            detalle.moneda = txtTipoMoneda.Text.ToUpper().Trim();
            detalle.TipoCambio = double.Parse(txtTipocambio.Text);
            detalle.Afecto = registro.ccd03afin;
            detalle.CenCos = CentroCosto;
            detalle.CenGes = "";
            detalle.AsientoTipo = txtAsientoTipo.Text;
            detalle.valida = "";
            detalle.ImporteDebeEquivalencia = importeDebeEquivalencia;
            detalle.ImporteHaberEquivalencia = importeHaberEquivalencia;
            detalle.transa = "N";
            detalle.Amarre = "";
            detalle.NroPago = "";
            detalle.FechaPago = null;
            detalle.Porcentaje = "";

            return detalle;
        }
        private void GrabarVoucher()
        {
            GlobalLogic LogicaGlobal = GlobalLogic.Instance;
            VoucherLogic LogicaVoucher = VoucherLogic.Instance;
            AsientoTipoLogic LogicaAsientoTipo = AsientoTipoLogic.Instance;
            try
            {

                float cantidadRegistros = 0;
                LogicaGlobal.ComprasTraeDimeExisteVoucher(Logueo.CodigoEmpresa, Logueo.Anio,
                txtMesProvision.Text, txtLibro.Text, txtNroVoucher.Text, out cantidadRegistros);

                if (cantidadRegistros > 0)
                {
                    Util.ShowAlert("Ya existe voucher"); return;
                }

                Voucher entidad = new Voucher();
                int flag = 0; string msj = "";



                entidad = new Voucher();
                entidad.CodigoEmpresa = Logueo.CodigoEmpresa;
                entidad.Anio = Logueo.Anio;
                entidad.Mes = txtMesProvision.Text;
                entidad.libro = txtLibro.Text;
                entidad.fecha = dtpFechaDocumento.Value;
                entidad.detalle = txtConcepto.Text;
                entidad.astip = txtAsientoTipo.Text;
                entidad.trans = "N";
                string nroVoucher = "";
                LogicaVoucher.InsertarCabecera(entidad, txtNroVoucher.Text.Trim().ToUpper(), out nroVoucher, out flag, out msj);
                
                //VoucherLogic.Instance.InsertarCabecera(entidad, out nroVoucher, out flag, out msj);
                txtNroVoucher.Text = nroVoucher;
                //--> valida si cabecera es deshabilitado o bloqueado por validacion, entonces
                // deberia actualizar con los datos qu muestra en pantalla
                //Actualizar Cabecera VOucher  

                //insercion de cabecera voucher
                List<ComprasAsientoTipoDetalle> listaDetAsientoTipo = new List<ComprasAsientoTipoDetalle>();
                if (flag == 1)
                {
                    listaDetAsientoTipo = LogicaAsientoTipo.TraeDetalleAsientoTipo(Logueo.CodigoEmpresa, txtAsientoTipo.Text,Logueo.Anio);
                }

                if (Estado == FormEstate.Edit)
                {
                    entidad = new Voucher();
                    entidad.CodigoEmpresa = Logueo.CodigoEmpresa;
                    entidad.Anio = Logueo.Anio;
                    entidad.Mes = txtMesProvision.Text;
                    entidad.libro = txtLibro.Text;
                    entidad.numero = txtNroVoucher.Text;
                    LogicaVoucher.EliminarDetalle(entidad, out flag, out msj);
                    //VoucherLogic.Instance.EliminarDetalle(entidad, out flag, out msj);
                    txtLibro.Enabled = true;

                }

                string descripcion = "";
                LogicaGlobal.ComprasDameDescripcion(Logueo.CodigoEmpresa, txtTipoDocumento.Text, "SG", out descripcion);

                foreach (ComprasAsientoTipoDetalle itm in listaDetAsientoTipo)
                {
                    double DebSol = 0, DebDol = 0;
                    double HabSol = 0, HabDol = 0;



                    if (itm.ccd03ca == "C") // si es cargo
                    {
                        if (descripcion == "+") // si tipo documento es ingresos
                        {
                            HabSol = 0; HabDol = 0;
                            // asiganar valores al debe soles y debe dolares
                            AsignarDebSolesyDebDolares(itm.ccd03afin, out DebSol, out DebDol);
                        }
                        else // si tipo documento es egreso
                        {
                            DebSol = 0;
                            DebDol = 0;
                            // asiganar valores al haber
                            AsignarHabSolesyHabDolares(itm.ccd03afin, out HabSol, out HabDol);

                        }
                    }
                    else // si es abono
                    {

                        if (descripcion == "+")
                        {
                            DebSol = 0; 
                            DebDol = 0;
                            HabSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteDocumento.Text, txtImporteDocumentoEquiv.Text);
                            HabDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteDocumentoEquiv.Text, txtImporteDocumento.Text);
                        }
                        else
                        {
                            HabSol = 0; 
                            HabDol = 0;
                            DebSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteDocumento.Text, txtImporteDocumentoEquiv.Text);
                            DebDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteDocumentoEquiv.Text, txtImporteDocumento.Text); ;

                        }
                    }

                    string descripcionSalida = "";

                    string centroCosto = "";

                    LogicaGlobal.ComprasDameDescripcion(Logueo.CodigoEmpresa, Logueo.CodigoEmpresa + Logueo.Anio + itm.ccd03def,
                                                                "FC", out descripcionSalida);
                    centroCosto = descripcionSalida;


                    double factor = Convert.ToDouble(decimal.Round(decimal.Parse(itm.ccd03porcen.ToString()) / 100, 4));

                    DebSol = Convert.ToDouble(decimal.Round(Convert.ToDecimal(DebSol * factor), 2));
                    HabSol = Convert.ToDouble(decimal.Round(Convert.ToDecimal(HabSol * factor), 2));
                    DebDol = Convert.ToDouble(decimal.Round(Convert.ToDecimal(DebDol * factor), 2));
                    HabDol = Convert.ToDouble(decimal.Round(Convert.ToDecimal(HabDol * factor), 2));

                    if (txtLibro.Enabled)
                    {

                        VoucherDetalle detalle = new VoucherDetalle();

                        detalle = LeerDetalleVoucher(itm, DebSol, HabSol, DebDol, HabDol, centroCosto);
                        string mensajeSalida = "";
                        int flagSalida = 0;
                        if ((DebSol + HabSol + DebDol + HabDol) != 0) // Solo se genera el detalle si hay un monto mayor a cero
                        {
                            LogicaVoucher.InsertarDetalle(detalle, out flagSalida, out mensajeSalida);
                        }
                        //Util.ShowMessage(mensajeSalida, flagSalida);

                    }
                    
                }

            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al grabar voucher");
            }
        }
        private void ActualizaPagos()
        {
            double ImpDocumento = 0;
            if (chkCancelacion.Checked)
            {
                ImpDocumento = double.Parse(txtImporteDocumento.Text);
            }
            else
            {
                ImpDocumento = 0;
            }
            string esAfectoDetraccion = "";
            esAfectoDetraccion = chkAfectoDetraccion.Checked ? "S" : "N";


            if (txtporcentaje.Text == "")
            {
                txtporcentaje.Text = "0";
            }

            if (txtimportedetraccion.Text == "")
            {
                txtimportedetraccion.Text = "0";
            }

            if (txtimportedetraccion_equi.Text == "")
            {
                //txtimportedetraccion_equi.Text = "0";                
                txtimportedetraccion_equi.Text = Util.NumberFormat("0", formatonumero);

            }

            string tipoOrden = "", nroOrden = "", anio = "", mes = "", codigoProveedor = "";


            tipoOrden = OCTipo;
            nroOrden = OCNumero;
            anio = Logueo.Anio;
            mes = txtMesProvision.Text;
            codigoProveedor = txtProveedor.Text;

            ProvisionFacturaLogic.Instance.ActualizaProvisionFacturaPago(Logueo.CodigoEmpresa,
                Logueo.Anio, txtMesProvision.Text,
                tipoOrden,
                nroOrden,
                txtTipoDocumento.Text,
                txtnrodocumento.Text,
                double.Parse(txtImporteDocumento.Text),
                ImpDocumento,
                anio,
                mes,
                codigoProveedor,
                esAfectoDetraccion,
                txttipooperacion.Text,
                txttiposervicio.Text,
                double.Parse(txtporcentaje.Text),
                double.Parse(txtimportedetraccion.Text),
                double.Parse(txtimportedetraccion_equi.Text));

            //Refresar grilla de factura si valor es diferente a -1( Error)

            //FrmParentConOC.CargarFactura();
        }
        #endregion

        #region "Contabilidad"
        private void btnVerContabilidad_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Logueo.TipoProvision = "S/OC";
                Logueo.gridProvFactura = FrmParentSinOC.gridFactura;
                this.tipoDocumento = txtTipoDocumento.Text.Trim();
                this.nroDocumento = txtnrodocumento.Text.Trim();
                this.fechaDocumento = dtpFechaDocumento.Value.ToShortDateString();
                this.fechaVencimiento = dtpFechaVencimiento.Value.ToShortDateString();
                this.libro = txtLibro.Text.Trim();
                this.nroVoucher = txtNroVoucher.Text.Trim();
                this.tipoMoneda = txtTipoMoneda.Text.Trim().ToUpper();
                this.tipoCambio = txtTipocambio.Text.Trim();
                //txtPorigv -> Provision, txtporcentaje -> detraccion
                this.porcentajeIgv = txtPorIgv.Text.Trim();
                this.importeAfecto = txtImporteAfecto.Text;
                this.importeInafecto = txtImporteAfecto.Text;
                this.importeIgv = txtImporteIgv.Text;
                this.importeDocumento = txtImporteDocumento.Text;
                this.mesProvision = txtMesProvision.Text;
                this.tieneDetraccion = chkAfectoDetraccion.Checked;
                this.concepto = txtConcepto.Text.Trim();
                this.asientoTipo = txtAsientoTipo.Text;
                this.anioFactura = Logueo.Anio;
                this.mesFactura = txtMesProvision.Text.Trim();

 


                var frmInstance = frmProvFactRegContable.Instance(this);

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
                Util.ShowError("Error al ver contabilidad");
            }
            Cursor.Current = Cursors.Default;
        }

        private void txtLibro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmLibros);
            }
        }

        private void txtAsientoTipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmAsiento);
            }
        }
        private void txtNroVoucher_Leave(object sender, EventArgs e)
        {
            if (txtLibro.Text != "")
            {
                string nuevoNumeroVoucher = "";
                ProvisionFacturaLogic.Instance.TraeCorrelativoVoucher(Logueo.CodigoEmpresa, Logueo.Anio,
                                Logueo.Mes, txtLibro.Text, txtNroVoucher.Text, out nuevoNumeroVoucher);
                txtNroVoucher.Text = nuevoNumeroVoucher;
            }
        }
        #endregion
        #region "Detraccion"
        private void CargarDetraccion(GridViewRowInfo fila)
        {
            txttipooperacion.Text = Util.GetCurrentCellText(fila, "CO05DETRATIPOPERACION");
            txttiposervicio.Text = Util.GetCurrentCellText(fila, "CO05DETRATIPOSERVICIO");
            txtporcentaje.Text = Util.GetCurrentCellText(fila, "CO05DETRAPORCENTAJE");
            txtimportedetraccion.Text = Util.GetCurrentCellText(fila, "CO05DETRAIMPORTE");
            txtimportedetraccion_equi.Text = Util.GetCurrentCellText(fila, "CO05DETRAIMPORTE_EQUI");
        }
        private void LeerDetraccion(ProvisionFactura entidad)
        {

            entidad.DetraTipoOperacion = txttipooperacion.Text;
            entidad.DetraTipoServicio = txttiposervicio.Text;

            string porcentajeCadena = (txtporcentaje.Text == "" ? "0" : txtporcentaje.Text);
            entidad.DetraPorcentaje = double.Parse(porcentajeCadena);

            string ImporteDetraccionCadena = (txtimportedetraccion.Text == "" ? "0" : txtimportedetraccion.Text);
            entidad.DetraImporte = double.Parse(ImporteDetraccionCadena);

            string ImporteDetraccionEquivCadena = (txtimportedetraccion_equi.Text == "" ? "0" : txtimportedetraccion_equi.Text);
            entidad.DetraImporte_Equiv = double.Parse(ImporteDetraccionEquivCadena);
        }
        #endregion
        private void CargarDatos() {
            string descripcionref;
            try
            {
                GridViewRowInfo fila = FrmParentSinOC.gridFactura.MasterView.CurrentRow;
                
                txtMesProvision.Text = Util.GetCurrentCellText(fila, "Mes");
                txtTipoDocumento.Text = Util.GetCurrentCellText(fila, "TipoDocumento");
                txtnrodocumento.Text = Util.GetCurrentCellText(fila, "NumeroDocumento");
                dtpFechaDocumento.Text = Util.GetCurrentCellText(fila, "Fecha");
                dtpFechaVencimiento.Text = Util.GetCurrentCellText(fila, "FechaVencimiento");
                dtpFechaPago.Text = Util.GetCurrentCellText(fila, "FechaPago");
                txtPorIgv.Text = Util.GetCurrentCellText(fila, "PorIgv");
                txtTipoMoneda.Text = Util.GetCurrentCellText(fila, "TipoMoneda");
                // Traer tipo y Numero orden Compra
                OCTipo = Util.GetCurrentCellText(fila, "Tipo"); 
                OCNumero = Util.GetCurrentCellText(fila, "Codigo");
                //Traer descripcion de Nombre Proveedor

                string nombreProveedor = Util.GetCurrentCellText(fila, "NombreProveedor");
                gpxCtaCte.Text = nombreProveedor;
                txtProveedor.Text = Util.GetCurrentCellText(fila, "CodCte");
                txtProveedorDesc.Text = Util.GetCurrentCellText(fila, "NombreProveedor");

                string valor = Util.GetCurrentCellText(fila, "TipoCambio").Trim() == "" ? "0" : Util.GetCurrentCellText(fila, "TipoCambio").Trim();
                txtTipocambio.Text = Util.NumberFormat(valor, "{0:#,###0.0000}");

                txtConcepto.Text = Util.GetCurrentCellText(fila, "CO05CON");
                txtbienoservicio.Text = Util.GetCurrentCellText(fila, "CO05BIENOSERVSUNAT");

                chkCancelacion.Checked = Util.GetCurrentCellText(fila, "Estado") == "3" ? true : false;
                chkAfectoDetraccion.Checked = Util.GetCurrentCellText(fila, "CO05AFECTODETRACCION") == "S" ? true : false;
                
                if (chkAfectoDetraccion.Checked)
                {
                    gpxDetraccion.Visible = true;
                }
                else
                {
                    gpxDetraccion.Visible = false;
                }

                txtCentroCosto.Text = Util.GetCurrentCellText(fila, "CentroCosto");

                txtCentroCostoDesc.Text = Util.GetCurrentCellText(fila, "CentroCostoDescripcion");


                
                txtdocmodtipo.Text = Util.GetCurrentCellText(fila, "docmodtipo");
                txtdocmodtipodesc.Text = DameDescripcion(Logueo.CodigoEmpresa + txtdocmodtipo.Text, "TD");
                txtdocmodnumero.Text = Util.GetCurrentCellText(fila, "docmodnumero");
                dtpdocmodfecha.Text = Util.GetCurrentCellText(fila, "docmodfecha");

                descripcionref = DameDescripcion(txtTipoDocumento.Text, "TDREF");
                if (descripcionref == "S")
                {
                    gboxdocmodifica.Visible = true;
                }
                else
                {
                    gboxdocmodifica.Visible = false;
                }


               
                //Traer bien o servicio descricpion
                string afectoaRetencion = Util.GetCurrentCellText(fila, "CO05AFECTORET");

                if (afectoaRetencion != "")
                {
                    rbAfectoRet.Checked = afectoaRetencion == "S" ? true : false;
                    rbNoAfectoRet.Checked = afectoaRetencion == "S" ? false : true;
                }

                AsignarValoresaImportes(txtTipoMoneda.Text.Trim());

                #region "Campos Adicionales"



                //Validacion de bloque Contabilidad         
                CargarContabidad(fila);
                
                CargarDetraccion(fila);
                #endregion
                //trae descripcion de detraccion tipo operacion
                DateTime FechaDocumento = Convert.ToDateTime(Util.GetCurrentCellText(fila, "Fecha"));



                //bool esValidoPeriodoCerrado = ValidaPeriodoCerrado(Util.GetCurrentCellText(fila, "Anio"), txtMesProvision.Text);
                bool esPeriodoCerrado = false;
                HabilitarCamposPorEstadoPeriodo(esPeriodoCerrado);
               
                //Cargar el flujo de la caja
                //string codigoProveedor = FrmParentSinOC.codigoProveedor;
                //TraeSubFlujoPago(codigoProveedor, txtTipoDocumento.Text, txtnrodocumento.Text);
            }catch (Exception ex) {
                Util.ShowError("Error al cargar datos");
            }
        }
        private void TraeSubFlujoPago(string CtaCte, string TipDoc, string NroDoc)
        {

            ProvisionFacturaLogic ProvFactura = ProvisionFacturaLogic.Instance;
            //List
            List<Spu_Com_Trae_FlujoDePago> listaFlujoPago =
            ProvFactura.ComprasTraeFlujoPago(Logueo.CodigoEmpresa, CtaCte, TipDoc, NroDoc);


        }
        private void HabilitarCamposPorEstadoPeriodo(bool esPeriodoCerrado)
        {


            //if (esValidoPeriodoCerrado == true)
            if (esPeriodoCerrado == true)
            {
                //cuando el periodo esta cerrado entonces bloquear todo la modifcaion del formulario
                MuestrayOcultaDatos(false);
                Logueo.ComprasPeriodoCerrado = "S";
            }
            else
            {
                Logueo.ComprasPeriodoCerrado = "N";

                bool activarControlContabilidad = true;
                //si encontre registor mayor a cero en esDocumentoContabilidad, su valor es false
                //desactivar la activacion de controles
                activarControlContabilidad = esDocumentoContabilizado() == true? false:true;
                //Contabilidad
                txtLibro.Enabled = activarControlContabilidad;
                txtNroVoucher.Enabled = activarControlContabilidad;
                txtAsientoTipo.Enabled = activarControlContabilidad;

                txtMesProvision.Enabled = false;
                txtTipoDocumento.Enabled = false;
                txtnrodocumento.Enabled = false;
                //txtPorIgv.Enabled = false;

                
                if (activarControlContabilidad == false)
                {
                    MuestrayOcultaDatos(false);
                    
                }
                #region "resalta ayuda"
                Util.ResaltaAyudaPorEstado(txtTipoDocumento);
                Util.ResaltaAyudaPorEstado(txtbienoservicio);
                Util.ResaltaAyudaPorEstado(txtLibro);
                Util.ResaltaAyudaPorEstado(txtAsientoTipo);
                Util.ResaltaAyudaPorEstado(txtTipTransGuia);
                Util.ResaltaAyudaPorEstado(txtTipDocGuia);
                Util.ResaltaAyudaPorEstado(txttipooperacion);
                Util.ResaltaAyudaPorEstado(txttiposervicio);
                #endregion

            }

        }


   

        private void AsignarValoresaImportes(string tipoMoneda)
        {

            GridViewRowInfo fila = FrmParentSinOC.gridFactura.MasterView.CurrentRow;
            //Controles de Montos
            if (txtImporteAfecto.Text == "")
            {
                txtImporteAfecto.Text = "0";
            }


            string importeBrutoDolares = Util.GetCurrentCellTextNumero(fila, "CO05IMPBDOL");
            string importeInafectaDolares = Util.GetCurrentCellTextNumero(fila, "CO05IMPINADOL");
            string importeIgvDolares = Util.GetCurrentCellTextNumero(fila, "CO05IMPIGVDOL");
            string importeDolares = Util.GetCurrentCellTextNumero(fila, "CO05IMPDOL");

            string importeBruto = Util.GetCurrentCellTextNumero(fila, "ImpBruto");
            string importeInafecto = Util.GetCurrentCellTextNumero(fila, "ImpIna");
            string importeIgv = Util.GetCurrentCellTextNumero(fila, "ImpIgv");
            string valorpordefecto = Util.NumberFormat("0", formatonumero);

            if (tipoMoneda.ToUpper() == "S")
            {

                txtImporteAfecto.Text = importeBruto == "" ? valorpordefecto : Util.NumberFormat(importeBruto, formatonumero);
                txtImporteInafecto.Text = importeInafecto == "" ? valorpordefecto : Util.NumberFormat(importeInafecto, formatonumero);
                txtImporteIgv.Text = importeIgv == "" ? valorpordefecto : Util.NumberFormat(importeIgv, formatonumero);

                string importeTotal = Util.GetCurrentCellTextNumero(fila, "ImpTotal");
                txtImporteDocumento.Text = importeTotal == "" ? valorpordefecto : Util.NumberFormat(importeTotal, formatonumero);


                //interferencia equivalencia

                txtImporteAfectoEquiv.Text = importeBrutoDolares == "" ? valorpordefecto : Util.NumberFormat(importeBrutoDolares, formatonumero);
                txtImporteInafectoEquiv.Text = importeInafectaDolares == "" ? valorpordefecto : Util.NumberFormat(importeInafectaDolares, formatonumero);
                txtImporteIgvEquiv.Text = importeIgvDolares == "" ? valorpordefecto : Util.NumberFormat(importeIgvDolares, formatonumero);                
                txtImporteDocumentoEquiv.Text = importeDolares == "" ? valorpordefecto : Util.NumberFormat(importeDolares, formatonumero);
                
                
            }
            else
            {
                                
                txtImporteAfecto.Text = importeBrutoDolares == "" ? valorpordefecto : Util.NumberFormat(importeBrutoDolares, formatonumero);
                txtImporteInafecto.Text = importeInafectaDolares == "" ? valorpordefecto : Util.NumberFormat(importeInafectaDolares, formatonumero);
                txtImporteIgv.Text =  importeIgvDolares == "" ? valorpordefecto : Util.NumberFormat(importeIgvDolares, formatonumero);
                txtImporteDocumento.Text = importeDolares == "" ? valorpordefecto : Util.NumberFormat(importeDolares, formatonumero);

                // equivalencia
                txtImporteAfectoEquiv.Text =  importeBruto == "" ? valorpordefecto : Util.NumberFormat(importeBruto, formatonumero);
                txtImporteInafectoEquiv.Text = importeInafecto == "" ? valorpordefecto : Util.NumberFormat(importeInafecto, formatonumero);
                txtImporteIgvEquiv.Text =  importeIgv == "" ? valorpordefecto : Util.NumberFormat(importeIgv, formatonumero);
                
                string importe = Util.GetCurrentCellTextNumero(fila, "ImpTotal");
                txtImporteDocumentoEquiv.Text =  importe == "" ? valorpordefecto : Util.NumberFormat(importe, formatonumero);
                
            }

            

        }
        private void TraerAyuda(enmAyuda tipo)
        {

            string[] datos;
            Cursor.Current = Cursors.WaitCursor;
            frmBusqueda frm;
            if (tipo == enmAyuda.enmServicioDetraccion)
            {
                frm = new frmBusqueda(tipo, dtpFechaDocumento.Value.ToString());
            }
            else
            {
                frm = new frmBusqueda(tipo);
            }
            Cursor.Current = Cursors.Default;
            frm.ShowDialog();
            if (frm.Result == null) return;
            if (frm.Result.ToString() == "") return;
            datos = frm.Result.ToString().Split('|');



            switch (tipo)
            {

                case enmAyuda.enmTipoDocumento:
                    txtTipoDocumento.Text = datos[0]; //ccb02cod
                    txtTipoDocumento.Focus();
                    break;
            
                case enmAyuda.enmTransaccion:
                    txtTipTransGuia.Text = datos[0];
                    txtTipTransGuiaDesc.Text = datos[1];
                    txtTipTransGuia.Focus();
                    break;

                case enmAyuda.enmTipoDocumentoGuia:
                    txtTipDocGuia.Text = datos[0];
                    txtTipDocGuiaDesc.Text = datos[1];
                    txtTipDocGuia.Focus();
                    break;

                case enmAyuda.enmAsiento:
                    txtAsientoTipo.Text = datos[0];
                    txtAsientoTipoDesc.Text = datos[1];
                    txtAsientoTipo.Focus();
                    break;

                case enmAyuda.enmLibros:
                    txtLibro.Text = datos[0];
                    txtLibroDesc.Text = datos[1];
                    txtLibro.Focus();
                    break;
                case enmAyuda.enmBienServicio:
                    txtbienoservicio.Text = datos[0];
                    lblBienOServicio.Text = datos[1];
                    break;
                case enmAyuda.enmTipoOperacionDetraccion:
                    txttipooperacion.Text = datos[0];
                    txttipooperacionDesc.Text = datos[1];
                    break;

                case enmAyuda.enmServicioDetraccion:
                    txttiposervicio.Text = datos[0];
                    txttiposervicioDesc.Text = datos[1];
                    txtporcentaje.Text = datos[2];
                    break;
                case enmAyuda.enmCentroCosto:
                    txtCentroCosto.Text = datos[0];
                    txtCentroCostoDesc.Text = datos[1];
                    break;
                case enmAyuda.enmProveedor:
                    txtProveedor.Text = datos[0];
                    txtProveedorDesc.Text = datos[1];
                    break;
                case enmAyuda.enmDocuModificaTipo:
                    txtdocmodtipo.Text = datos[0]; //ccb02cod
                    txtdocmodtipo.Focus();
                    break;     
            }

        }

        private void HabilitarControles(bool valor)
        {
            txtMesProvision.Enabled = valor;
            txtTipoDocumento.Enabled = valor;
            txtnrodocumento.Enabled = valor;
            dtpFechaDocumento.Enabled = valor;
            dtpFechaVencimiento.Enabled = valor;
            dtpFechaPago.Enabled = valor;
            txtPorIgv.Enabled = valor;
            //gpxCtaCte.Text = "Nombre de cuenta corriente";
            txtTipocambio.Enabled = valor;
            txtImporteAfecto.Enabled = valor;
            txtImporteInafecto.Enabled = valor;
            txtImporteIgv.Enabled = valor;
            txtImporteDocumento.Enabled = valor;

            txtImporteAfectoEquiv.Enabled = valor;
            txtImporteInafectoEquiv.Enabled = valor;
            txtImporteIgvEquiv.Enabled = valor;
            txtImporteDocumentoEquiv.Enabled = valor;
            txtTipoMoneda.Enabled = valor;

            txtConcepto.Enabled = valor;
            txtbienoservicio.Enabled = valor;
            rbAfectoRet.Enabled = valor;
            rbNoAfectoRet.Enabled = valor;
            chkCancelacion.Enabled = valor;
            chkAfectoDetraccion.Enabled = valor;

            txtdocmodtipo.Enabled = valor;
            txtdocmodnumero.Enabled = valor;
            dtpdocmodfecha.Enabled = valor;

            //Contabilidad            
            txtLibro.Enabled = valor;
            txtNroVoucher.Enabled = valor;
            txtAsientoTipo.Enabled = valor;

            //Inventarios
            txtTipDocGuia.Enabled = valor;
            txtTipTransGuia.Enabled = valor;
            txtNroGuia.Enabled = valor;
            dtpFechaGuia.Enabled = valor;

            //Detraccion esta habilitado por defecto

            //txtnroautorizacion esta retirado del diseño

            #region "resalta ayuda controles"
            Util.ResaltaAyudaPorEstado(txtTipoDocumento);
            Util.ResaltaAyudaPorEstado(txtbienoservicio);
            Util.ResaltaAyudaPorEstado(txtLibro);
            Util.ResaltaAyudaPorEstado(txtAsientoTipo);
            Util.ResaltaAyudaPorEstado(txtTipTransGuia);
            Util.ResaltaAyudaPorEstado(txtTipDocGuia);
            Util.ResaltaAyudaPorEstado(txttipooperacion);
            Util.ResaltaAyudaPorEstado(txttiposervicio);
            Util.ResaltaAyudaPorEstado(txtProveedor);
            Util.ResaltaAyudaPorEstado(txtCentroCosto);
            Util.ResaltaAyudaPorEstado(txtdocmodtipo);
            #endregion

        }
        private void CalcularTotales()
        {
            try
            {
                decimal ValorBruto, ValorInafecto, ValorIgv, ValorTotal;
                decimal ValorBrutoEquivalente, ValorInafectoEquivalente,
                             ValorIgvEquivalente, ValorTotalEquivalente;

                //No procesar calculo tota en modo editar
                //if (Estado == FormEstate.Edit) return;
                if (txtImporteAfecto.Text == "")
                {
                    txtImporteAfecto.Text = Util.NumberFormat("0", formatonumero);
                }

                if (txtImporteInafecto.Text == "")
                {
                    txtImporteInafecto.Text = Util.NumberFormat("0", formatonumero);
                }

                ValorBruto = decimal.Parse(txtImporteAfecto.Text);
                ValorInafecto = decimal.Parse(txtImporteInafecto.Text);
                ValorIgv = (ValorBruto * decimal.Parse(txtPorIgv.Text)) / 100;
                ValorTotal = ValorBruto + ValorInafecto + ValorIgv;

                
                txtImporteIgv.Text = Util.NumberFormat(ValorIgv.ToString(), formatonumero);                
                txtImporteDocumento.Text = Util.NumberFormat(ValorTotal.ToString(), formatonumero);
                

                //ValorBrutoEquivalente = 
                decimal tipoCambio = decimal.Parse(txtTipocambio.Text);

                if (txtTipoMoneda.Text.ToUpper() == "S")
                {
                    //decimal.Parse(ValorBruto / tipoCambio, 2);
                    ValorBrutoEquivalente = decimal.Round((ValorBruto / tipoCambio), 2);
                }
                else
                {
                    ValorBrutoEquivalente = decimal.Round((ValorBruto * tipoCambio), 2);
                }
                txtImporteAfectoEquiv.Text = Util.NumberFormat(ValorBrutoEquivalente.ToString(), formatonumero);
                //txtImporteAfectoEquiv.Text = Util.AsignarNumeroFormateado(ValorBrutoEquivalente);
                //txtImporteAfectoEquiv.Text = ValorBrutoEquivalente.ToString();



                if (txtTipoMoneda.Text.ToUpper() == "S")
                {
                    ValorInafectoEquivalente = decimal.Round((ValorInafecto / tipoCambio), 2);
                }
                else
                {
                    ValorInafectoEquivalente = decimal.Round((ValorInafecto * tipoCambio), 2);
                }


                ValorIgvEquivalente = (ValorBrutoEquivalente * decimal.Parse(txtPorIgv.Text)) / 100;
                ValorTotalEquivalente = ValorBrutoEquivalente + ValorInafectoEquivalente + ValorIgvEquivalente;
                
                txtImporteInafectoEquiv.Text = Util.NumberFormat(ValorInafectoEquivalente.ToString(), formatonumero);
                txtImporteIgvEquiv.Text = Util.NumberFormat(ValorIgvEquivalente.ToString(), formatonumero);
                txtImporteDocumentoEquiv.Text = Util.NumberFormat(ValorTotalEquivalente.ToString(), formatonumero);
                


                VerificaRetencion();
                if (txtporcentaje.Text == "")
                {
                    txtporcentaje.Text = "0";
                }

                CalcularImporteDetraccion(txtporcentaje.Text);

            }
            catch (Exception ex)
            {
                Util.ShowError("Error en calcular totales");
            }

        }
        private void AsignaRetencionMontoEquivalente(bool esMontoEquivalente = false)
        {
            if (esMontoEquivalente)
            {
                if (txtImporteAfectoEquiv.Text.Trim() == "")
                {
                    
                    txtImporteAfectoEquiv.Text = Util.NumberFormat("0");
                }
                if (txtImporteInafectoEquiv.Text.Trim() == "")
                {
                    txtImporteInafectoEquiv.Text = Util.NumberFormat("0");
                    
                }
            }
            else
            {
                CalcularTotales();               
            }

            string tipoMoneda = txtTipoMoneda.Text.ToUpper();

            double ImporteRetencion = double.Parse(Logueo.ImporteRetencion);


            if (Logueo.FlagRetencion == "S")
            {
                //if(FrmParent.codigoProveedor)
                string codigoProveedor = FrmParentSinOC.codigoProveedor;
                if (verifica_agente_y_buenaportador(codigoProveedor) == true)
                {
                    switch (tipoMoneda)
                    {
                        case "S":

                            double ImporteDocumento = double.Parse(txtImporteDocumento.Text.Trim());
                            double ImporteInafecto = double.Parse(txtImporteInafecto.Text.Trim());

                            rbAfectoRet.Checked = (ImporteDocumento - ImporteInafecto > ImporteRetencion) ? true : false;
                            rbNoAfectoRet.Checked = (ImporteDocumento - ImporteInafecto > ImporteRetencion) ? false : true;
                            break;

                        case "D":

                            double ImporteDocumentoEquiv = double.Parse(txtImporteDocumentoEquiv.Text.Trim());
                            double ImporteInafectoEquiv = double.Parse(txtImporteInafectoEquiv.Text.Trim());

                            rbAfectoRet.Checked = (ImporteDocumentoEquiv - ImporteInafectoEquiv > ImporteRetencion) ? true : false;
                            rbNoAfectoRet.Checked = (ImporteDocumentoEquiv - ImporteInafectoEquiv > ImporteRetencion) ? false : true;
                            break;

                        default:
                            Util.ShowAlert("Moneda No Valida");
                            break;
                    }

                }
                else
                {
                    rbNoAfectoRet.Checked = true;
                }
            }


        }
        private void TraeDescripcion(string flag, string codigo, out string descripcion)
        {
            GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, codigo, flag, out descripcion);
        }
        private bool ValidarFechaPeriodo(DateTime fecha, string periodo)
        {

            bool fechaValida = false;
            string mes = fecha.Month.ToString("0#");
            string anio = fecha.Year.ToString();
            if (double.Parse(anio + mes) > double.Parse(periodo))
            {
                Util.ShowAlert("fecha NO valida, Pertenece a un periodo posterior");
                fechaValida = false;

            }
            else if (double.Parse(anio + mes) < double.Parse(periodo))
            {
                RadMessageLocalizationProvider.CurrentProvider = new Auxilares.CulturaVentanaMensaje();
                 DialogResult result = RadMessageBox.Show("fecha anterior al periodo, Esta seguro de utilizar esta fecha ?", 
                    Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR, MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    fechaValida = true;
                }
                
            }
            else if (double.Parse(anio + mes) == double.Parse(periodo))
            {
                fechaValida = true;
            }


            return fechaValida;
        }
        private void VerificaRetencion()
        {
            string FacturaConDetraccion, FacturaFecha;
            double FacturaValorEnSoles;

            try
            {
                string TipoMoneda, TipoDocumento, NroDocumento;

                TipoMoneda = txtTipoMoneda.Text;
                TipoDocumento = txtTipoDocumento.Text;
                NroDocumento = txtnrodocumento.Text;
                FacturaConDetraccion = chkAfectoDetraccion.Checked ? "S" : "N";
                FacturaFecha = dtpFechaDocumento.Value.ToShortDateString();

                //Capturar el importe en soles
                if (TipoMoneda == "S")
                {
                    FacturaValorEnSoles = Convert.ToDouble(txtImporteDocumento.Text) - Convert.ToDouble(txtImporteInafecto.Text);

                }
                else if (TipoMoneda == "D")
                {
                    FacturaValorEnSoles = Convert.ToDouble(txtImporteDocumentoEquiv.Text) - Convert.ToDouble(txtImporteInafectoEquiv.Text);
                }
                else
                {
                    FacturaValorEnSoles = 0;
                    Util.ShowAlert("Moneda No Valida");
                }


                //Analisis -> 02

                //string codigoProveedor = FrmParentSinOC.codigoProveedor;
                string codigoProveedor = txtProveedor.Text.Trim();
                int esAfectaRetencion = 0;
                ProvisionFacturaLogic.Instance.TraeRetencion(Logueo.CodigoEmpresa, Logueo.TipoAnalisisProveedor,
                codigoProveedor, FacturaFecha, FacturaValorEnSoles,
                FacturaConDetraccion, TipoDocumento, out esAfectaRetencion);

                if (esAfectaRetencion == 1)
                {
                    rbAfectoRet.Checked = true;
                    rbNoAfectoRet.Checked = false;
                }
                else
                {
                    rbNoAfectoRet.Checked = true;
                    rbAfectoRet.Checked = false;
                }

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al verificar retencion");
            }
        }

        private void CalcularImporteDetraccion(string Porcentaje)
        {
            
            try
            {
                
                if (chkAfectoDetraccion.Checked == false) {return; }
                if (txtTipoMoneda.Text.ToUpper() != "S" && txtTipoMoneda.Text.ToUpper() != "D")
                {
                    Util.ShowAlert("Debe Especificar Moneda"); return;
                }
                if (txtTipocambio.Text == "") { Util.ShowAlert("Tipo de cambio No Valido"); return; }
                if (txtImporteDocumento.Text == "" || txtImporteDocumentoEquiv.Text == "") { Util.ShowAlert("Importe No Valido"); return; }
                if (txtporcentaje.Text == "") { Util.ShowAlert("Porcentaje No Valido"); return; }
                if (Util.EsNumero(txtporcentaje.Text) == false) { Util.ShowAlert("Porcentaje No Valido"); return; }

                Cursor.Current = Cursors.WaitCursor;

                //'Calcular detraccion sobre la moneda original
                decimal ImporteDetraccion = Convert.ToDecimal(txtImporteDocumento.Text) * (Convert.ToDecimal(Porcentaje) / 100);
                decimal ImporteDetraccionOriginal = 0, ImporteDetraccionEquivalente = 0;

                if (txtTipoMoneda.Text.ToUpper() == "S")
                {
                    ImporteDetraccionOriginal = decimal.Round(ImporteDetraccion, 2);
                    ImporteDetraccionEquivalente = decimal.Round(ImporteDetraccion / decimal.Parse(txtTipocambio.Text), 2);
                }
                else if (txtTipoMoneda.Text.ToUpper() == "D")
                {
                    ImporteDetraccionOriginal = decimal.Round(ImporteDetraccion, 2);
                    ImporteDetraccionEquivalente = decimal.Round(ImporteDetraccion * decimal.Parse(txtTipocambio.Text), 2);
                }

                txtimportedetraccion.Text = Util.NumberFormat(ImporteDetraccionOriginal.ToString(), formatonumero);
                txtimportedetraccion_equi.Text = Util.NumberFormat(ImporteDetraccionEquivalente.ToString(), formatonumero);

                Cursor.Current = Cursors.Default;
            }
            
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
            }
            
        }

        private bool verifica_agente_y_buenaportador(string rucctatcte)
        {
            bool flagExitoso = false;
            //try
            //{
            //    int datoSalida = 0;
            //    GlobalLogic.Instance.ComprasTraeTipoProveedor(rucctatcte, out datoSalida);

            //    if (datoSalida == 0)
            //    {
            //        flagExitoso = true;
            //    }
            //    else
            //    {
            //        flagExitoso = false;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Util.ShowError("Error al verificar agente y buen aportador");
            //    flagExitoso = false;
            //}
            return flagExitoso;
        }
        private void InicializaDatos()
        {

            txtMesProvision.Enabled = false;
            txtTipoDocumento.Enabled = true;
            txtnrodocumento.Enabled = true;
            txtMesProvision.Text = Logueo.Mes;
            txtTipoDocumento.Text = "";
            
            txtnrodocumento.Text = "";
            dtpFechaDocumento.Value = DateTime.Now;
            dtpFechaVencimiento.Value = DateTime.Now;
            dtpFechaPago.Value = DateTime.Now;
            txtPorIgv.Text = Logueo.Igv.ToString();
            //gpxCtaCte.Text = FrmParentSinOC.nombreProveedor;
            gpxCtaCte.Text = txtProveedorDesc.Text;


            txtImporteAfecto.Text = Util.NumberFormat("0", formatonumero);
            txtImporteInafecto.Text = Util.NumberFormat("0", formatonumero);
            txtImporteIgv.Text = Util.NumberFormat("0", formatonumero);
            txtImporteDocumento.Text = Util.NumberFormat("0", formatonumero);

            txtImporteAfectoEquiv.Text = Util.NumberFormat("0", formatonumero);
            txtImporteInafectoEquiv.Text = Util.NumberFormat("0", formatonumero);
            txtImporteIgvEquiv.Text = Util.NumberFormat("0", formatonumero);
            txtImporteDocumentoEquiv.Text = Util.NumberFormat("0", formatonumero);
            txtTipoMoneda.Text = FrmParentSinOC.tipoMoneda;

            txtTipocambio.Text = Util.NumberFormat("1", "{0:#,####0.0000}");

            txtConcepto.Text = "";
            txtbienoservicio.Text = "";
            rbNoAfectoRet.Checked = true;
            chkAfectoDetraccion.Checked = false;
            chkCancelacion.Checked = false;


            //contabilidad
            txtLibro.Text = "";
            txtNroVoucher.Text = "";
            txtAsientoTipo.Text = "";

            //Inventario            
            txtTipDocGuia.Text = "";
            txtTipTransGuia.Text = "";
            txtNroGuia.Text = "";
            dtpFechaGuia.Value = DateTime.Now;

            //detraccion
            gpxDetraccion.Visible = false;
            txttipooperacion.Text = "";
            txttiposervicio.Text = "";

            txtporcentaje.Text = Util.NumberFormat("0", formatonumero);
            txtimportedetraccion.Text = Util.NumberFormat("0", formatonumero);
            txtimportedetraccion_equi.Text = Util.NumberFormat("0", formatonumero);

            

            //
            gboxdocmodifica.Visible = false;
            txtdocmodtipo.Text="";
            txtdocmodnumero.Text = "";
            dtpdocmodfecha.Value = DateTime.Now;
        }
        private void DesactivarRegistroContable()
        {
            float CantidadRegistros = 0;
            bool  esDocumentoContabilizado = false;

            //Formulario principal
            txtMesProvision.Enabled = false;
            txtTipoDocumento.Enabled = false;
            txtnrodocumento.Enabled = false;

            string anio = "";
            
            //anio = Util.GetCurrentCellText(FrmParentSinOC.gridFactura.CurrentRow, "Anio");
            anio = Logueo.Anio;
            //Contabilidad
            CantidadRegistros = 0;

            GlobalLogic.Instance.ComprasTraeDimeExisteVoucher(Logueo.CodigoEmpresa,
            anio,
            txtMesProvision.Text, txtLibro.Text, txtNroVoucher.Text, out CantidadRegistros);

            esDocumentoContabilizado = CantidadRegistros > 0 ? true : false;

            if (esDocumentoContabilizado == true)
            {
                txtLibro.Enabled = false;
                txtNroVoucher.Enabled = false;
                txtAsientoTipo.Enabled = false;
                MuestrayOcultaDatos(false);
            }

        }
        private void MuestrayOcultaDatos(bool valor)
        {

            txtMesProvision.Enabled = valor;
            txtTipoDocumento.Enabled = valor;
            txtnrodocumento.Enabled = valor;
            dtpFechaDocumento.Enabled = valor;
            dtpFechaVencimiento.Enabled = valor;
            dtpFechaPago.Enabled = valor;

            txtTipoMoneda.Enabled = valor;
            txtTipocambio.Enabled = valor;
            txtPorIgv.Enabled = valor;

            chkCancelacion.Enabled = valor;
            chkAfectoDetraccion.Enabled = valor;

            txtConcepto.Enabled = valor;
            txtbienoservicio.Enabled = valor;

            gpxCtaCte.Text = FrmParentSinOC.nombreProveedor;
            txtImporteAfecto.Enabled = valor;
            txtImporteInafecto.Enabled = valor;
            txtImporteIgv.Enabled = valor;
            txtImporteDocumento.Enabled = valor;

            txtImporteAfectoEquiv.Enabled = valor;
            txtImporteInafectoEquiv.Enabled = valor;
            txtImporteIgvEquiv.Enabled = valor;
            txtImporteDocumentoEquiv.Enabled = valor;


            rbAfectoRet.Enabled = valor;
            rbNoAfectoRet.Enabled = valor;

            ////Contabilidad
            //txtLibro.Enabled = valor;
            //txtNroVoucher.Enabled = valor;
            //txtAsientoTipo.Enabled = valor;
            ////Inventario
            //txtTipTransGuia.Enabled = valor;
            //txtNroGuia.Enabled = valor;
            //txtTipDocGuia.Enabled = valor;
            //txtnroautorizacion esta retirado del diseño

            //Detraccion
            txttipooperacion.Enabled = valor;
            txttiposervicio.Enabled = valor;
            txtporcentaje.Enabled = valor;
            txtimportedetraccion.Enabled = valor;
            txtimportedetraccion_equi.Enabled = valor;
            txtProveedor.Enabled = valor;
            txtCentroCosto.Enabled = valor;

            //
            txtdocmodtipo.Enabled = valor;
            txtdocmodnumero.Enabled = valor;
            dtpdocmodfecha.Enabled = valor;
        }

         private ProvisionFactura LeerProvisionFactura() {
            string tipo = "", codigo = "";
            
            tipo = FrmParentSinOC.tipoOrden;
            codigo = FrmParentSinOC.nroOrden;

            ProvisionFactura provision = new ProvisionFactura();
            provision.Empresa = Logueo.CodigoEmpresa;
            provision.Anio = Logueo.Anio;
            provision.Mes = txtMesProvision.Text.Trim();
                        
             if (Estado == FormEstate.New)
             {
                 provision.Tipo = Logueo.OCompraTipoParaDocSinOCompra;
                 provision.Codigo = Logueo.OCompraNumeroParaDocSinOCompra;
            } else
             {
                 provision.Tipo = OCTipo;
                 provision.Codigo = OCNumero;
             }

            provision.TipoDocumento = txtTipoDocumento.Text;
            provision.NroDoc = txtnrodocumento.Text;
            provision.FechaDocumento = dtpFechaDocumento.Value;
            provision.FechaVencimiento = dtpFechaVencimiento.Value;
            provision.FechaPago = dtpFechaPago.Value;
            provision.PorIgv = double.Parse(txtPorIgv.Text);
             
             
          
            double ImpAfecto = 0, ImpAfectoEquiv = 0, ImpInafecto = 0,
                    ImpInafectoEquiv = 0, ImpIgv = 0, ImpIgvEquiv = 0,
                    ImpDocumento = 0, ImpDocumentoEquiv = 0;

            ImpAfecto = double.Parse(txtImporteAfecto.Text);
            ImpAfectoEquiv = double.Parse(txtImporteAfectoEquiv.Text);

            ImpInafecto = double.Parse(txtImporteInafecto.Text);
            ImpInafectoEquiv = double.Parse(txtImporteInafectoEquiv.Text);

            ImpDocumento = double.Parse(txtImporteDocumento.Text);
            ImpDocumentoEquiv = double.Parse(txtImporteDocumentoEquiv.Text);

            ImpIgv = double.Parse(txtImporteIgv.Text);
            ImpIgvEquiv = double.Parse(txtImporteIgvEquiv.Text);

            bool esTipoMonedaSoles = false;
            if (txtTipoMoneda.Text.ToUpper() == "S")
            {
                esTipoMonedaSoles = true;
            }

            provision.ImporteAfecto = esTipoMonedaSoles ? ImpAfecto : ImpAfectoEquiv;
            provision.ImporteInafecto = esTipoMonedaSoles ? ImpInafecto : ImpInafectoEquiv;
            provision.ImporteIgv = esTipoMonedaSoles ? ImpIgv : ImpIgvEquiv;
            provision.Importe = esTipoMonedaSoles ? ImpDocumento : ImpDocumentoEquiv;

            provision.ImporteAfDol = esTipoMonedaSoles ? ImpAfectoEquiv : ImpAfecto;
            provision.ImporteInafDol = esTipoMonedaSoles ? ImpInafectoEquiv : ImpInafecto;
            provision.ImporteIgvDol = esTipoMonedaSoles ? ImpIgvEquiv : ImpIgv;
            provision.ImporteDocDol = esTipoMonedaSoles ? ImpDocumentoEquiv : ImpDocumento;

            provision.Moneda = txtTipoMoneda.Text.ToUpper().Trim();


            provision.TipoCambio = double.Parse(txtTipocambio.Text);
            provision.Concepto = txtConcepto.Text;
            string codCte = "", aniOrdCom = "", mesOrdCom = "";
            
            //codCte = FrmParentSinOC.codigoProveedor;
            codCte = txtProveedor.Text.Trim();
            //aniOrdCom = FrmParentSinOC.anio;
            //mesOrdCom = FrmParentSinOC.mes;
            aniOrdCom = Logueo.Anio;
            mesOrdCom = txtMesProvision.Text.Trim();
            provision.CodCte = codCte;
            provision.AnioOrdCom = aniOrdCom; // anio de orden de compra
            provision.MesOrdCom = mesOrdCom; // mes de orden de compra
            provision.AfectoDetraccion = chkAfectoDetraccion.Checked ? "S" : "N";
            provision.AfectoRet = rbAfectoRet.Checked ? "S" : "N";
            provision.Estado = chkCancelacion.Checked ? "3" : "0";
            provision.NroAutorizacion = ""; // el contro fue retirado del diseño
            provision.BienesoServicioSunat = txtbienoservicio.Text.Trim();
            provision.CentroCosto = txtCentroCosto.Text.Trim();

            provision.DocModTipo= txtdocmodtipo.Text.Trim();
            provision.DocModNumero = txtdocmodnumero.Text.Trim();
            provision.DocModFecha= dtpdocmodfecha.Value;
             //Agregar centro de coste como parametro
            //contabilidad       
            LeerContabilidad(provision);
     
            //Detraccion
            LeerDetraccion(provision);                
            
            return provision;
        }
     
        protected override void OnGuardar()
        {

                Cursor.Current = Cursors.WaitCursor;

            try{
                 
                 #region"Validaciones General"
            
                if(txtConcepto.Text == "")
                {
                    Util.ShowAlert("ERROR:: Ingrese un Concepto");

                    return;

                }
                //PENDIENTE
                //if(txtCentroCosto.Text == "")
                //{
                //    Util.ShowAlert("ERROR:: Ingrese un Centro de Costo");
                //    txtCentroCosto.Focus();
                //    return;
                //}
                 if (ValidarFechaPeriodo(dtpFechaDocumento.Value, Logueo.periodo) == false)
                 {
                     return;
                 }
                 
                 if (txtProveedorDesc.Text == "" || txtProveedorDesc.Text == "???")
                 {
                     Util.ShowAlert("Proveedor No valido");
                     return;
                 }
                 
                 if (gboxdocmodifica.Visible == true)
                 {
                     if (txtdocmodtipo.Text == "" || txtdocmodnumero.Text == "")
                        {


                            Util.ShowError("VALIDACION  :: NO se guardo el registro, Ingrese Documento de Referencia  ");
                            return;
                        }        
                 }

                 VerificaRetencion();
                 #endregion
                 #region"Validaciones Montos"
                 // 'Validar los importes
                 decimal ImporteAfecto = 0, TipoCambio = 0, ImporteAfectoEquivalente = 0;
                 ImporteAfecto = decimal.Parse(txtImporteAfecto.Text);
                 TipoCambio = decimal.Parse(txtTipocambio.Text);
                 ImporteAfectoEquivalente = decimal.Parse(txtImporteAfectoEquiv.Text);
                 if (txtTipoMoneda.Text.ToUpper() == "S")
                 {

                     if (decimal.Round((ImporteAfecto / TipoCambio), 2) != decimal.Round(ImporteAfectoEquivalente, 2))
                     {
                         bool respuesta = Util.ShowQuestion("Importe de soles / Tipo Cambio <> Importe Dolares , ¿Desea continuar?");
                         if (respuesta == false) return;
                     }
                 }
                 else
                 {

                     if (decimal.Round(ImporteAfecto * TipoCambio, 2) != decimal.Round(ImporteAfectoEquivalente, 2))
                     {
                         bool respuesta = Util.ShowQuestion(" Importe de soles * Tipo Cambio <> Importe Dolares , ¿Desea continuar?");
                         if (respuesta == false) return;
                     }
                 }
                 #endregion


                ProvisionFactura provision = new ProvisionFactura();
                
                provision = LeerProvisionFactura();

                int flagSalida = 0; string mensajeSalida = "";

                if (Estado == FormEstate.New)
                {
                    ProcesarContabilidad();
                    ProvisionFacturaLogic.Instance.Insertar(provision, out flagSalida, out mensajeSalida);
                    Util.ShowMessage(mensajeSalida, flagSalida);
                    if (flagSalida == 1) {
                        ActualizaPagos();                                             
                        FrmParentSinOC.Cargar("*");
                        
                        DesactivarRegistroContable();
                    }
                    //Nuevo
                    Estado = FormEstate.New;
                    InicializaDatos();
                    HabilitarControles(true);
                    txtMesProvision.Enabled = false;
                    HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                    this.gpxFlotante.Visible = false;
                }
                else if (Estado == FormEstate.Edit)
                {
                    if ( (txtLibro.Enabled == false && txtNroVoucher.Enabled == false 
                            && txtAsientoTipo.Enabled == false) && (txtTipDocGuia.Enabled == false && txtTipTransGuia.Enabled == false
                            && txtNroGuia.Enabled == false)) 
                    {
                    
                    }else{
                        ProcesarContabilidad();
                        provision = LeerProvisionFactura();
                        flagSalida = 0; mensajeSalida = "";
                        ProvisionFacturaLogic.Instance.Actualizar(provision, out flagSalida, out mensajeSalida);
                        Util.ShowMessage(mensajeSalida, flagSalida);
                        
                        if (flagSalida == 1)
                        {
                           ActualizaPagos(); 
                        //'CAPTURO EN Queryable REGISTRO ESTOY
                        //// CO05CODEMP, CO05AA, CO05MES, CO05TIPO, CO05CODIGO, CO05TIPDOC, CO05NRODOC, CO05CODCTE

                           FrmParentSinOC.Cargar("*");
                           //UBICAR CURSOR
                           FrmParentSinOC.UbicarCursor(Logueo.CodigoEmpresa, Logueo.Anio, provision.Mes,
                               provision.Tipo, provision.Codigo, provision.TipoDocumento,
                               provision.NroDoc, provision.CodCte);

                            CargarDatos();
                            DesactivarRegistroContable();
                            this.gpxFlotante.Visible = false;
              
                            Estado = FormEstate.Edit;

                        }
                        else
                            {
                                //No hago nada, queda como edit
                                Estado = FormEstate.Edit;
                            }

                    }
                }
                else {
                    Util.ShowAlert("Opcion no valido");
                }
          
                
            }
            catch (Exception ex) {
                Util.ShowError("Error al guardar"); 
            }
            Cursor.Current = Cursors.Default;

     
        }
        
        //chkAfectoDetraccion
        private void chkAfectoDetraccion_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            gpxDetraccion.Visible = chkAfectoDetraccion.Checked;

          
        }

        private void txtbienoservicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmBienServicio);
            }
        }

        private void txtTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTipoDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmTipoDocumento);
            }
        }
        private void txtCentroCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1) {
                TraerAyuda(enmAyuda.enmCentroCosto);
            }
        }

        private void txtProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1) {
                TraerAyuda(enmAyuda.enmProveedor);
            }
        }
        private void txtImporteAfecto_Leave(object sender, EventArgs e)
        {
            if (txtImporteAfecto.Text.Trim() == "")
            {
                txtImporteAfecto.Text = Util.NumberFormat("0", formatonumero);
            }
            else {
                txtImporteAfecto.Text = Util.NumberFormat(txtImporteAfecto.Text.Trim(), formatonumero);
            }


            
            //AsignaRetencionMontoEquivalente(false);
            CalcularTotales();
        }

        private void txtImporteInafecto_Leave(object sender, EventArgs e)
        {

            if (txtImporteInafecto.Text.Trim() == "")
            {
                txtImporteInafecto.Text = Util.NumberFormat("0", formatonumero);
            }
            else {
                txtImporteInafecto.Text = Util.NumberFormat(txtImporteInafecto.Text.Trim(), formatonumero);
            }
            
            //AsignaRetencionMontoEquivalente(false);
            CalcularTotales();

        }

        private void txtImporteAfectoEquiv_Leave(object sender, EventArgs e)
        {
            string valor = txtImporteAfectoEquiv.Text.Trim() == "" ? "0" : txtImporteAfectoEquiv.Text.Trim();
            txtImporteAfectoEquiv.Text = Util.NumberFormat(valor, formatonumero);
           // AsignaRetencionMontoEquivalente(true);
            //CalcularTotales();
        }

        private void txtImporteInafectoEquiv_Leave(object sender, EventArgs e)
        {
            string valor = txtImporteInafectoEquiv.Text.Trim() == "" ? "0" : txtImporteInafectoEquiv.Text.Trim();
            txtImporteInafectoEquiv.Text = Util.NumberFormat(valor, formatonumero);
            //AsignaRetencionMontoEquivalente(true);
            //CalcularTotales();
        }

        private void dtpFechaDocumento_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Estado == FormEstate.Edit) return;
            //    bool esFechaValida = ValidarFechaPeriodo(dtpFechaDocumento.Value, Logueo.Anio + Logueo.Mes);
               
            //    if (contadorerrorfecha<=1)
            //    {
            //        if (esFechaValida == false)
            //        {
            //            contadorerrorfecha = contadorerrorfecha + 1;
            //            dtpFechaDocumento.Focus();
            //        }
            //    }

            //    /* Observacion */
            //    //If CDate(Format(cmbFechaDocumento, "dd/mm/yyyy")) < CDate("01/03/2011") Then
            //    //txtPorIgv.Text = "19" ' Igv antes del 01/03/2011
            //    //Else
            //    //txtPorIgv.Text = gbIgv 'IGv Actual
            //    //End If

            //    // Logueo.Igv --> 18 es el valor de esta variable existente en el archivo Logueo.            
            //    txtPorIgv.Text = Logueo.Igv.ToString();

            //    float TipoCambio = 0;
            //    GlobalLogic.Instance.ComprasTraeTiCambioFecha(dtpFechaDocumento.Value.ToShortDateString(), "B", "V", out TipoCambio);
            //    txtTipocambio.Text = TipoCambio.ToString();

            //    if (txtImporteAfecto.Text != "")
            //    {
            //        if (double.Parse(txtImporteAfecto.Text) > 0)
            //        {
            //            CalcularTotales();

            //        }
            //    }


            //    dtpFechaVencimiento.Value = dtpFechaDocumento.Value;
            //    dtpFechaPago.Value = dtpFechaDocumento.Value;
            //}
            //catch (Exception ex)
            //{
            //    Util.ShowError("Error en Fecha de documento");
            //}

        }

        private void txtTipocambio_Leave(object sender, EventArgs e)
        {
            try
            {
                
                string valor = txtTipocambio.Text.Trim() == "" ? "1" : txtTipocambio.Text.Trim();
                txtTipocambio.Text = Util.NumberFormat(valor, "{0:#,###0.0000}");

                double numero = 0;
                bool numeroValido = double.TryParse(txtImporteAfecto.Text.Trim(), out numero);

                if (numero > 0)
                {
                    CalcularTotales();
                }

            }
            catch (Exception ex) {
                Util.ShowError("Error al formatear tipo de cambio");
            }

          
        }

        private void txtbienoservicio_TextChanged(object sender, EventArgs e)
        {
            string descripcion = "";
            TraeDescripcion("GLO02", "30" + txtbienoservicio.Text, out descripcion);
            lblBienOServicio.Text = descripcion;
        }
        protected override void OnAnterior()
        {
            int iIndice = FrmParentSinOC.gridFactura.MasterView.CurrentRow.Index - 1;
            if (iIndice < 0)
            {
                return;
            }
            FrmParentSinOC.gridFactura.MasterView.CurrentRow = FrmParentSinOC.gridFactura.MasterView.Rows[iIndice];
            CargarDatos();
            gpxFlotante.Visible = false;
        }
        protected override void OnSiguiente() 
        {
            int iIndice = FrmParentSinOC.gridFactura.MasterView.CurrentRow.Index + 1;
            if (iIndice > FrmParentSinOC.gridFactura.MasterView.Rows.Count - 1)
            {
                return;
            }
            FrmParentSinOC.gridFactura.MasterView.CurrentRow = FrmParentSinOC.gridFactura.MasterView.Rows[iIndice];
            CargarDatos();
            gpxFlotante.Visible = false;
        }
        protected override void OnPrimero() 
        {
            int iIndice = 0;
            FrmParentSinOC.gridFactura.MasterView.CurrentRow = FrmParentSinOC.gridFactura.MasterView.Rows[iIndice];
            CargarDatos();
            gpxFlotante.Visible = false;
        }
        protected override void OnUltimo()
        {
            int iIndice = FrmParentSinOC.gridFactura.MasterView.Rows.Count - 1;
            FrmParentSinOC.gridFactura.MasterView.CurrentRow = FrmParentSinOC.gridFactura.MasterView.Rows[iIndice];
            CargarDatos();
            gpxFlotante.Visible = false;
        }
        private void frmProvFacturaDetSinOC_Load(object sender, EventArgs e)
        {

            //FrmParentSinOC.gridFactura.CurrentRow = FrmParentSinOC.gridFactura.Rows[15];

            //Iniciar ubicacion en txtConcepto
            Point ubicacionGrupoFlotante = new Point();
            ubicacionGrupoFlotante.X = this.txtConcepto.Location.X;
            ubicacionGrupoFlotante.Y = this.txtConcepto.Location.Y + this.txtConcepto.Height;
            this.gpxFlotante.Location = ubicacionGrupoFlotante;
            this.gpxFlotante.Visible = false;
            this.gpxFlotante.Height = 200;
            this.gpxFlotante.Width = 300;
            //End ubicacion

            OcultarBotones();

            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);


            txtTipoMoneda.MaxLength = 1;

            CrearColumnas();
            CrearColumnasSugerencia();

            Estado = FrmParentSinOC.Estado;

            switch (Estado)
            {

                case FormEstate.New:
                    InicializaDatos();
                    HabilitarControles(true);
                    txtMesProvision.Enabled = false;
                    HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                    //txtPorIgv.Enabled = false;
                    
                    break;

                case FormEstate.Edit:
                    HabilitarControles(true);
                    txtMesProvision.Enabled = false;
                    txtTipoDocumento.Enabled = false;
                    txtnrodocumento.Enabled = false;
                    txtProveedor.Enabled = false;
                    CargarDatos();
                    HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);

                    break;
                case FormEstate.View :
                     HabilitarControles(false);
                    txtMesProvision.Enabled = false;
                    txtTipoDocumento.Enabled = false;
                    txtnrodocumento.Enabled = false;
                    txtProveedor.Enabled = false;
                    CargarDatos();
            HabilitaBotonPorNombre(BaseRegBotones.cmdAnterior);
            HabilitaBotonPorNombre(BaseRegBotones.cmdSiguiente);
            HabilitaBotonPorNombre(BaseRegBotones.cmdPrimero);
            HabilitaBotonPorNombre(BaseRegBotones.cmdUltimo);
                    break;
                default: break;
            }
            gpxFlotante.Visible = false;
        }



        private void txtTipDocGuia_KeyDown(object sender, KeyEventArgs e)
        {

        }
        //Detraccion
        private void txttipooperacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                //TraerAyuda(enmAyuda.servicio
                TraerAyuda(enmAyuda.enmTipoOperacionDetraccion);
            }
        }

        private void txttiposervicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmServicioDetraccion);
            }
        }

        private void dtpFechaVencimiento_Leave(object sender, EventArgs e)
        {
            dtpFechaPago.Value = dtpFechaVencimiento.Value;
        }

        private void txtAsientoTipo_Leave(object sender, EventArgs e)
        {
            //devolver descripcion
            string descripcion = DameDescripcion(Logueo.CodigoEmpresa + txtAsientoTipo.Text.Trim(), "AST");
            txtAsientoTipoDesc.Text = descripcion;
        }
        private void CargarConceptoPorNombre(string codigoConcepto) { 
                
        }
        //Metodo para saber si un formulario esta abierto
        private bool IsFormOpen(string formularioName) 
        {
            foreach(Form form in Application.OpenForms)
            {
                if(form.Name == formularioName)
                {
                    return true;
                }
                
            }
            return false;

        }
        private void txtConcepto_TextChanged(object sender, EventArgs e)
        {

            //LLENA LOS DATOS DEL SP A TRAER DE LA BASE DE DATOS
            if (txtConcepto.Enabled == true)
            {
                //
                this.gridSugerencia.DataSource = ProvisionFacturaLogic.Instance.AutoCompletaMotivoProvision(Logueo.CodigoEmpresa, txtConcepto.Text);

                if (gridSugerencia.Rows.Count == 0)
                {
                    this.gpxFlotante.Visible = false;
                    txtConcepto.Focus();
                    return;
                }
                else
                {
                    this.gpxFlotante.Visible = true;
                    txtConcepto.Focus();
                    return;
                }

            }
            
        }
        private double Redondeo(double valorNumerico, int cantidadDecimal = 0) { 
            decimal valorFormateado;
            string numeroCadena = valorNumerico.ToString();
            valorFormateado = decimal.Round(decimal.Parse(numeroCadena), cantidadDecimal);
            //Convert.ToDouble(valorFormateado,);
            double valorNumericoRedondeado = double.Parse(valorFormateado.ToString());
            return valorNumericoRedondeado;
        }
        private void txtimportedetraccion_Leave(object sender, EventArgs e)
        {

            double importeDetraccion = double.Parse(txtimportedetraccion.Text);
            double importeDetraccionEquiv = (importeDetraccion / double.Parse(txtTipocambio.Text));

            double importeDetraccionFormato = Redondeo(importeDetraccionEquiv, 2);

            txtimportedetraccion_equi.Text = Util.NumberFormat(importeDetraccionFormato.ToString(), formatonumero);
           
        }

        private void txtPorIgv_Leave(object sender, EventArgs e)
        {
            if (Util.EsNumero(txtPorIgv.Text) == true)
            {
                CalcularTotales();
            }
        }
        private void txtporcentaje_Leave(object sender, EventArgs e)
        {
            try
            {
                CalcularImporteDetraccion(txtporcentaje.Text);
            }
            catch (Exception ex) {
                Util.ShowAlert("Error al calcular importe");
            }
            
        }
        private string DameDescripcion(string codigo, string flag)
        { 

            string descripcion = "";
             GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa,  codigo, flag, out descripcion);
            return descripcion;
        }
        private string  ValidaProveedorSunat(string empresa, string codigoctacte) {
            string descripcion = "";
            ProvisionFacturaLogic.Instance.TraeValidaProvSunat(Logueo.CodigoEmpresa, "1", "01", codigoctacte, out descripcion);
            return descripcion;
        }
        private void txtProveedor_Leave(object sender, EventArgs e)
        {
            try
            {
                string mensaProv, estadoProv, proveedorValido, estadoProvDom, proveedorValidoDom = "";
                estadoProv = "01";
                proveedorValido = "1";
                estadoProvDom = "01";
                proveedorValidoDom = "1";
                txtProveedorDesc.Text = DameDescripcion(Logueo.CodigoEmpresa + Logueo.TipoAnalisisProveedor + txtProveedor.Text, "CR");
                //valida estado
                //estadoProv = DameDescripcion(Logueo.CodigoEmpresa + "02" + txtProveedor.Text, "HABPROV");

                //proveedorValido = DameDescripcion("07" + estadoProv, "GLE");

                //if (proveedorValido != "1" && txtProveedor.Text.Trim() != "")
                //{
                //    Util.ShowAlert("Estado de Ruc No Valido : " + DameDescripcion("07" + estadoProv, "GL"));
                //    txtProveedor.Focus();
                //    return;
                //}

                //// Validar Situacion de Domicilio
                //estadoProvDom = DameDescripcion(Logueo.CodigoEmpresa + "02" + txtProveedor.Text, "DOMPROV");
                //proveedorValidoDom = DameDescripcion("08" + estadoProvDom, "GLE");
                //if (proveedorValido != "1" && txtProveedor.Text.Trim() != "")
                //{
                //    Util.ShowAlert("Estado de Ruc No Valido " + DameDescripcion("08" + estadoProvDom, "GL"));
                //    txtProveedor.Focus();
                //    return;
                //}

                //mensaProv = ValidaProveedorSunat(Logueo.CodigoEmpresa, txtProveedor.Text);
                //if (mensaProv != "")
                //{
                //    bool respuesta = Util.ShowQuestion("Proveedor con datos no validos segun SUNAT : " + mensaProv + ", ¿Desea seguir trabajando con el proveedor?");
                //    if (respuesta == true)
                //    {
                //        txtProveedor.Focus();
                //    }
                //}
            }
            catch (Exception ex) {

                Util.ShowError("Error al leer proveedor");
            }
               

        }
        private void txttiposervicio_Leave(object sender, EventArgs e)
       { 
            
             string tipoServicio = DameDescripcion(txttiposervicio.Text + 
                       dtpFechaDocumento.Value.ToShortDateString(), "DETRADESCRI");
             txttiposervicioDesc.Text = tipoServicio;
             
            string porcentaje = DameDescripcion(txttiposervicio.Text +
                 dtpFechaDocumento.Value.ToShortDateString(), "DETRATASA");

            txtporcentaje.Text = porcentaje;                        
        }

        private void txtbienoservicio_Leave(object sender, EventArgs e)
        {
            string descripcion = DameDescripcion("30" +  txtbienoservicio.Text.Trim(), "GLO02");
            lblBienOServicio.Text = descripcion;
        }

        private void txtCentroCosto_Leave(object sender, EventArgs e)
        {
            string descripcion = "";
            descripcion = DameDescripcion(Logueo.CodigoEmpresa + txtCentroCosto.Text.Trim(), "CENTROCOSTO"); //CC -> CENTROCOSTO
            txtCentroCostoDesc.Text = descripcion;
        }

        private void txtLibro_Leave(object sender, EventArgs e)
        {
            string descripcion = DameDescripcion(txtLibro.Text, "LI");
            txtLibroDesc.Text = descripcion;
        }

        private void txtTipoDocumento_Leave(object sender, EventArgs e)
        {
            string descripcion = "";
            string descripcionref = "";
            if (txtTipoDocumento.Text != "") 
            {
                // Traer Descripcion Tipo Documento
                descripcion = DameDescripcion(Logueo.CodigoEmpresa + txtTipoDocumento.Text, "TD");
                if (descripcion == "???" || descripcion == "") 
                {
                    Util.ShowAlert("Tipo de documento No Valido");
                    return;
                }

                // Traer Referencia Tipo Documento
                descripcionref = DameDescripcion(txtTipoDocumento.Text, "TDREF");
                if (descripcionref == "S")
                {
                    gboxdocmodifica.Visible = true;
                }
                else
                {
                    gboxdocmodifica.Visible = false;
                }
            }
     
        }
        private void txttipooperacion_Leave(object sender, EventArgs e)
        {
            //lblhelp(0) = DameDescripcion("15" & Trim(txttipooperacion.Text), "GL")
            txttipooperacionDesc.Text =  DameDescripcion("15" + txttipooperacion.Text, "GL");

        }

        private void btnVerInventario_Click(object sender, EventArgs e)
        {

        }
        private void txtLibro_TextChanged(object sender, EventArgs e)
        {
            if (txtLibro.Text != "")
            {
                txtLibroDesc.Text = DameDescripcion(txtLibro.Text, "LI");
            }
        }

        private void txtAsientoTipo_TextChanged(object sender, EventArgs e)
        {
            if (txtAsientoTipo.Text != "")
            {
                txtAsientoTipoDesc.Text = DameDescripcion(txtAsientoTipo.Text, "AST");
            }
        }

        private void txtTipDocGuia_TextChanged(object sender, EventArgs e)
        {
            if (txtTipDocGuia.Text != "")
            {
                txtTipDocGuiaDesc.Text = DameDescripcion(Logueo.CodigoEmpresa + txtTipDocGuia.Text, "TDG");
            }
        }

        private void txtTipTransGuia_TextChanged(object sender, EventArgs e)
        {
            if (txtTipTransGuia.Text != "")
            {
                string descripcion = DameDescripcion(Logueo.CodigoEmpresa + txtTipTransGuia.Text, "TRANSA");
                txtTipTransGuia.Text = descripcion;
            }
        }

        private void txttipooperacion_TextChanged(object sender, EventArgs e)
        {
            if (txttipooperacion.Text != "")
            {
                string descripcion = DameDescripcion("15" + txttipooperacion.Text, "GL");
                txttipooperacionDesc.Text = descripcion;
            }
        }

        private void txttiposervicio_TextChanged(object sender, EventArgs e)
        {
            if (txttiposervicio.Text != "")
            {
                string codigoBusqueda = txttiposervicio.Text + dtpFechaDocumento.Value.ToShortDateString();

                string descripcion = DameDescripcion(codigoBusqueda, "DETRADESCRI");
                txttiposervicioDesc.Text = descripcion;
            }
        }

        private void txtTipoMoneda_TextChanged(object sender, EventArgs e)
        {
            txtTipoMoneda.Text = txtTipoMoneda.Text.ToUpper();
        }

        private void txtCentroCosto_TextChanged(object sender, EventArgs e)
        {
            //txtCentroCosto
        }

        private void txtnrodocumento_Leave(object sender, EventArgs e)
        { 
            if (txtDcoRef.Text.Trim() == "")
            {
                txtDcoRef.Text = txtnrodocumento.Text.Trim();
            }
        }       
        private void txtImporteIgv_Leave(object sender, EventArgs e)
        {
            if (txtImporteIgv.Text.Trim() == "")
            {
                txtImporteIgv.Text = Util.NumberFormat("0", formatonumero);
            }
            else
            {
                txtImporteIgv.Text = Util.NumberFormat(txtImporteIgv.Text.Trim(), formatonumero);
            }
        }

        private void txtImporteDocumento_Leave(object sender, EventArgs e)
        {
            if (txtImporteDocumento.Text.Trim() == "")
            {
                txtImporteDocumento.Text = Util.NumberFormat("0", formatonumero);
            }
            else
            {
                txtImporteDocumento.Text = Util.NumberFormat(txtImporteDocumento.Text.Trim(), formatonumero);
            }
        }

        private void txtImporteIgvEquiv_Leave(object sender, EventArgs e)
        {
            if (txtImporteIgvEquiv.Text.Trim() == "")
            {
                txtImporteIgvEquiv.Text = Util.NumberFormat("0", formatonumero);
            }
            else
            {
                txtImporteIgvEquiv.Text = Util.NumberFormat(txtImporteIgvEquiv.Text.Trim(), formatonumero);
            }
        }
        private void txtImporteDocumentoEquiv_Leave(object sender, EventArgs e)
        {
            if (txtImporteDocumentoEquiv.Text.Trim() == "")
            {
                txtImporteDocumentoEquiv.Text = Util.NumberFormat("0", formatonumero);
            }
            else
            {
                txtImporteDocumentoEquiv.Text = Util.NumberFormat(txtImporteDocumentoEquiv.Text.Trim(), formatonumero);
            }
        }

        private void txtImporteAfecto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Util.ValidaFormatoDecimal(e);
        }

        private void txtImporteInafecto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Util.ValidaFormatoDecimal(e);
        }

        private void txtImporteIgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Util.ValidaFormatoDecimal(e);
        }

        private void txtImporteDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Util.ValidaFormatoDecimal(e);
        }


        private void txtImporteAfectoEquiv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Util.ValidaFormatoDecimal(e);
        }
        
        private void txtImporteInafectoEquiv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Util.ValidaFormatoDecimal(e);
        }


        private void CrearColumnasSugerencia()
        {
            RadGridView Grid = CreateGridVista(this.gridSugerencia);
            Grid.ShowColumnHeaders = false;
            CreateGridColumn(Grid, "Codigo", "CO07ITEM", 0, "", 90, true,false,false);
            CreateGridColumn(Grid, "Descripcion", "CO07DESCRIPCION", 0, "", 250);
        }

        private void txtImporteIgvEquiv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Util.ValidaFormatoDecimal(e);
        }

        private void txtImporteDocumentoEquiv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Util.ValidaFormatoDecimal(e);
        }

        private void txtTipocambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Util.ValidaFormatoDecimal(e);
        }

        private void txtdocmodtipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmDocuModificaTipo);
            }
        }
        private void txtdocmodtipo_Leave(object sender, EventArgs e)
        {
            string descripcion = "";

            if (txtdocmodtipo.Text != "")
            {
                // Traer Descripcion Tipo Documento
                descripcion = DameDescripcion(Logueo.CodigoEmpresa + txtdocmodtipo.Text, "TD");
                txtdocmodtipodesc.Text = descripcion;

            }

        }

        private void txtConcepto_KeyDown(object sender, KeyEventArgs e)
        {
            string textconcepto = txtConcepto.Text;
            int contador = textconcepto.Length;
            //MOSTRAR GRILLA FLOTANTE
            if (e.KeyValue == (char)Keys.Back || txtConcepto.Text == String.Empty)
            {
                this.gpxFlotante.Visible = false;
            }
            else 
            {
                  gridSugerencia.Focus();
            }
        }

        private void gridSugerencia_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            GridViewRowInfo row = this.gridSugerencia.CurrentRow;
            string Concepto = Util.GetCurrentCellText(row, "CO07DESCRIPCION");
            txtConcepto.Text = Concepto;
            this.gpxFlotante.Visible = false;

        }

        private void gridSugerencia_KeyDown(object sender, KeyEventArgs e)
        {
            GridViewRowInfo row = gridSugerencia.CurrentRow;
            if (e.KeyValue == (char)Keys.Enter)
            {
                string DescripcionConcepto = Util.GetCurrentCellText(row, "CO07DESCRIPCION");
                txtConcepto.Text = DescripcionConcepto;
                gpxFlotante.Visible = false;

            }
            txtConcepto.Focus();
            //txtbienoservicio.Focus();
        }

        private void dtpFechaDocumento_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyValue == (char)Keys.Enter)
                {
                    if (Estado == FormEstate.Edit) return;
                    bool esFechaValida = ValidarFechaPeriodo(dtpFechaDocumento.Value, Logueo.Anio + Logueo.Mes);
                    if (esFechaValida == false)
                    {
                        dtpFechaDocumento.Focus();
                    }

                    /* Observacion */
                    //If CDate(Format(cmbFechaDocumento, "dd/mm/yyyy")) < CDate("01/03/2011") Then
                    //txtPorIgv.Text = "19" ' Igv antes del 01/03/2011
                    //Else
                    //txtPorIgv.Text = gbIgv 'IGv Actual
                    //End If

                    // Logueo.Igv --> 18 es el valor de esta variable existente en el archivo Logueo.            
                    txtPorIgv.Text = Logueo.Igv.ToString();

                    float TipoCambio = 0;
                    GlobalLogic.Instance.ComprasTraeTiCambioFecha(dtpFechaDocumento.Value.ToShortDateString(), "B", "V", out TipoCambio);
                    txtTipocambio.Text = TipoCambio.ToString();

                    if (txtImporteAfecto.Text != "")
                    {
                        if (double.Parse(txtImporteAfecto.Text) > 0)
                        {
                            CalcularTotales();

                        }
                    }


                    dtpFechaVencimiento.Value = dtpFechaDocumento.Value;
                    dtpFechaPago.Value = dtpFechaDocumento.Value;
                }
            }

            catch (Exception ex)
            {
                Util.ShowError("Error en Fecha de documento");
            }
        }

        
    }
}
