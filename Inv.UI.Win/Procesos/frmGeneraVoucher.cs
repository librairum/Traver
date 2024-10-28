using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessLogic;
using Inv.BusinessEntities;
using Telerik.WinControls.UI;
namespace Inv.UI.Win
{
    public partial class frmVoucher : frmBaseMante
    {


        public static frmVoucher formulario;

        private frmMDI FrmParent { get; set; }
        private static frmVoucher _aForm;
        public static frmVoucher Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmVoucher(mdiPrincipal);
            _aForm = new frmVoucher(mdiPrincipal);
            return _aForm;
        }

        private bool isLoaded = false;
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a,
            cancelar_a, expmovi_a;
        CommandBarStripElement menu;

        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbEditar;
        RadCommandBarBaseItem cbbEliminar;

        RadCommandBarBaseItem cbbVer;
        RadCommandBarBaseItem cbbVista;
        RadCommandBarBaseItem cbbImprimir;
        RadCommandBarBaseItem cbbRefrescar;
        RadCommandBarBaseItem cbbImportar;

        RadCommandBarBaseItem cbbGuardar;
        RadCommandBarBaseItem cbbCancelar;
        RadCommandBarBaseItem cbbExportarMovimientos;
       
        public frmVoucher(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
                        
        }
        
        void ConfigurarEventos()
        {
            
            OnBuscar();
            this.HabilitarBotones(true, true, true, false, false, false);
        }
        //public FrmUniMed()
        //{
        //    InitializeComponent();
        //    crearGrilla();
        //    OnBuscar();
        //    this.HabilitarBotones(true, true, true, false, false, false);
        //    habilitarBotones(true, false);
        //}
        void seleccionaActualizado(string codigo, RadGridView grid, string nomCol)
        {
            foreach (GridViewRowInfo r in grid.Rows)
            {
                if (r.Cells[nomCol].Value.Equals(codigo))
                {
                    grid.Rows[r.Index].IsCurrent = true;
                    grid.Rows[r.Index].IsSelected = true;
                }
            }
        }
       

        
        private void ComportarmientoBotones(string accion)
        {

            switch (accion)
            {
                case "cargar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = ElementVisibility.Collapsed;

                    break;
                case "nuevo":

                    if (cbbNuevo != null) cbbNuevo.Visibility = ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = guardar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = cancelar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    break;
                case "editar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = guardar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = cancelar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    break;
                case "grabar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = ElementVisibility.Collapsed;
                    break;
                case "cancelar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = ElementVisibility.Collapsed;
                    break;
            }
        }
        void accesobotonesperfil()
        {            
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.codModulo, this.Name, out nuevo_a, out editar_a,
              out eliminar_a, out ver_a, out imprimir_a, out refrescar_a, out importar_a, out vista_a,
              out guardar_a, out cancelar_a, out expmovi_a);
        }

        private void frmVoucher_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            //HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            txtConcepto.Text = "Consumo del presente mes";
            txtMesProvision.Text = Logueo.Mes;
            Util.ResaltarAyuda(txtcodLibro);
        }
        private void habilita(bool valor) {
            txtConcepto.Enabled = valor;
            dtpFechaVoucher.Enabled = valor;
            txtLibro.Enabled = valor;
            txtNroVoucher.Enabled = valor;
            txtConcepto.Enabled = valor;
        }

        private void Limpiar() {
            txtConcepto.Text = "";
            dtpFechaVoucher.Text = "";
            txtLibro.Text = "";
            txtMesProvision.Text = "";
            txtNroVoucher.Text = "";
            txtTipoCambio.Text = "";
        }

        protected override void OnNuevo()
        {
            habilita(true);
            Limpiar();
        }

        protected override void OnGuardar()
        {
            GuardarVoucherxtiptransaccion();
        }

        protected  void GuardarVoucher()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (validaIngCon() == true)
            {
                Util.ShowAlert("Existe voucher");
                return;
            }


            if (grabarCabeceraVoucher() == false)
            {
                Util.ShowAlert("No se puede registrar cabecera voucher");
                return;
            }

            try
            {
                DataTable dt = VoucherLogic.Instance.GeneraVoucherContable(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
                if (dt.Rows.Count == 0)
                {
                    Util.ShowAlert("No hay movimiento para generar voucher");
                    return;
                }

                //Generar el detalle de voucher
                //iterando en el datatable.
                foreach (DataRow dr in dt.Rows)
                {
                    //a -> Almacen
                    double aDeberSoles = 0, aHaberSoles = 0, aDeberDolares = 0, aHaberDolares = 0;
                    //g -> gastos
                    double gDeberSoles = 0, gHaberSoles = 0, gDeberDolares = 0, gHaberDolares = 0;

                    string cObra = "", CtaNueve = "", cuenta = "", ctaAlmacen = "";

                    //inserto Almacen
                    aHaberSoles = Convert.ToDouble(dr["importe"]);
                    aHaberDolares = Util.Redondear(aHaberSoles / Convert.ToDouble(txtTipoCambio.Text.Trim()), 2);
                    ctaAlmacen = dr["CtaAlmacen"].ToString();

                    grabarDetalleVoucher(ctaAlmacen, aDeberSoles, aHaberSoles, aDeberDolares, aHaberDolares);

                    //inserto gastos
                    gDeberSoles = Convert.ToDouble(dr["importe"]);
                    gDeberDolares = Util.Redondear(gDeberSoles / Convert.ToDouble(txtTipoCambio.Text.Trim()), 2);
                    cObra = dr["Obra"].ToString();
                    CtaNueve = dr["CtaNueve"].ToString();
                    cuenta = cObra.Trim() + CtaNueve.Trim();

                    grabarDetalleVoucher(cuenta, gDeberSoles, gHaberSoles, gDeberDolares, gHaberDolares);

                }

                Util.ShowMessage("Termino de generar asiento de consumo", 1);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al generar voucher");
            }


            Cursor.Current = Cursors.WaitCursor;
            //OnCancelar();
        }
        protected  void GuardarVoucherxtiptransaccion()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (validaIngCon() == true)
            {
                Util.ShowAlert("Existe voucher");
                return;
            }


            if (grabarCabeceraVoucher() == false)
            {
                Util.ShowAlert("No se puede registrar cabecera voucher");
                return;
            }

            try
            {
                DataTable dt = VoucherLogic.Instance.GeneraVoucherContablexTipTran(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
                if (dt.Rows.Count == 0)
                {
                    Util.ShowAlert("No hay movimiento para generar voucher");
                    return;
                }

                //Generar el detalle de voucher
                //iterando en el datatable.
                foreach (DataRow dr in dt.Rows)
                {
                    //a -> 
                    string Cuenta = "";
                    double aDebeSoles = 0, aHaberSoles = 0, aDebeDolares = 0, aHaberDolares = 0;
                    

                    //inserto Almacen
                    aDebeSoles = Convert.ToDouble(dr["Debe"]);
                    aDebeDolares = Util.Redondear(aDebeSoles / Convert.ToDouble(txtTipoCambio.Text.Trim()), 2);
                    aHaberSoles = Convert.ToDouble(dr["Haber"]);
                    aHaberDolares = Util.Redondear(aHaberSoles / Convert.ToDouble(txtTipoCambio.Text.Trim()), 2);

                    Cuenta = dr["Cuenta"].ToString();

                    grabarDetalleVoucher(Cuenta, aDebeSoles, aHaberSoles, aDebeDolares, aHaberDolares);
                }

                Util.ShowMessage("Termino de generar asiento de consumo", 1);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al generar voucher");
            }


            Cursor.Current = Cursors.WaitCursor;
            //OnCancelar();
        }
        protected override void OnCancelar()
        {
           // habilita(false);
            Limpiar();
            this.Close();
        }

        private void asignaTipoCambio() { 
            double tipoCambio = 0;
            VoucherLogic.Instance.TraeTipoCambioFecha(dtpFechaVoucher.Value.ToString(), "B", "V", out tipoCambio);
            txtTipoCambio.Text = tipoCambio.ToString();
        }

        private void TraerAyuda(enmAyuda tipoAyuda) {
            frmBusqueda frm;
            string codigoSeleccionado = "";
            try
            {
                switch (tipoAyuda) { 
                    case enmAyuda.enmLibro:
                        frm = new frmBusqueda(tipoAyuda);
                        frm.Owner = this;
                        frm.ShowDialog();
                        if (frm.Result != null){                                                
                            codigoSeleccionado = frm.Result.ToString().ToUpper();
                            if (!string.IsNullOrEmpty(codigoSeleccionado)) txtLibro.Text = codigoSeleccionado;
                                txtcodLibro.Text = codigoSeleccionado.Split('|')[0];
                                txtLibro.Text = codigoSeleccionado.Split('|')[1];
                            }                        
                        break;
                        
                }
            }
            catch (Exception ex) {
                Util.ShowError("Error al traer ayuda libro");
            }
        }
        private bool validaIngCon() {
            bool encontroRegistro = false;
            try
            {
                double cantidadRegistros = 0;
                VoucherLogic.Instance.ExisteDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, 
                    txtcodLibro.Text.Trim(), txtNroVoucher.Text.Trim(), out cantidadRegistros);

                if (Convert.ToUInt32(cantidadRegistros) == 0)
                {
                    encontroRegistro = false;
                }
                else {
                    encontroRegistro = true;
                }
                
            }
            catch (Exception ex) {
                Util.ShowError("Error al validar documento"); 
            }
            return encontroRegistro;
        }
        
        private void grabarDetalleVoucher(string cuenta, double importeDebe, double importeHaber, double importeDebeEquivalencia, 
            double importeHaberEquivalencia) {
            try
            {
                string centroCosto = "";
                string codigo = "";
                
                string obra = "";
                string cuentaCorriente = "";
                codigo = Logueo.CodigoEmpresa + Logueo.Anio + obra;

                string salidaTexto = "";
                //obtener descipn de centro costo
                GlobalLogic.Instance.DameDescripcionCompras(codigo, "FC", out salidaTexto);
                centroCosto = salidaTexto;
                
                //obtener descripcion cuenta corriente
                codigo = "";
                //GlobalLogic.Instance.DameDescripcion(codigo, "CT", out salidaTexto);

                //if (cuentaCorriente == "" || cuentaCorriente == "???") {
                //    Util.ShowAlert("Cuenta corriente no valida"); ; return;
                //}
         
                VoucherDetalle detalle = new VoucherDetalle();
                detalle.CodigoEmpresa = Logueo.CodigoEmpresa;
                detalle.Anio = Logueo.Anio;
                detalle.Mes = txtMesProvision.Text.Trim();
                detalle.libro = txtcodLibro.Text.Trim();
                detalle.NumeroVoucher = txtNroVoucher.Text.Trim();
                detalle.cuenta = cuenta;
                detalle.ImporteDebe = importeDebe;
                detalle.ImporteHaber = importeHaber;
                detalle.glosa = txtConcepto.Text.Trim();
                detalle.TipoDocumento = "";
                detalle.NumDoc = "";
                detalle.FechaDoc = dtpFechaVoucher.Value;
                detalle.FechaVencimiento = dtpFechaVoucher.Value;
                detalle.CuentaCorriente = cuentaCorriente;
                detalle.moneda = "S";
                detalle.TipoCambio = Convert.ToDouble(txtTipoCambio.Text.Trim());
                detalle.Afecto = "";
                detalle.CenCos = centroCosto;
                detalle.CenGes = "";
                detalle.AsientoTipo = "";
                detalle.valida = "";
                detalle.ImporteDebeEquivalencia = importeDebeEquivalencia;
                detalle.ImporteHaberEquivalencia = importeHaberEquivalencia;
                detalle.transa = "N";
                detalle.Amarre = "";
                string respuesta = "";
                VoucherLogic.Instance.GeneraDetalle(detalle, out respuesta);
                //Util.ShowMessage(respuesta,1);

            }
            catch (Exception ex) {
                Util.ShowError("Error al guardar detalle de voucher");
            }
        }
        private bool grabarCabeceraVoucher()
        {

            string respuesta = "", nroVoucher="";
            bool procesoExitoso = false;
            try
            {
                Voucher entidad = new Voucher();
                entidad.CodigoEmpresa = Logueo.CodigoEmpresa;
                entidad.Anio = Logueo.Anio;
                entidad.Mes = txtMesProvision.Text.Trim();
                entidad.libro = txtcodLibro.Text.Trim();//guardar codigo
                entidad.fecha = dtpFechaVoucher.Value;
                entidad.detalle = txtConcepto.Text.Trim();

                nroVoucher = txtNroVoucher.Text.Trim();
                VoucherLogic.Instance.GeneraCabecera(entidad, txtNroVoucher.Text.Trim(), out respuesta);
                
                procesoExitoso = true;
                //OnCancelar();
            }
            catch (Exception ex) {
                Util.ShowError("Error al grabar cabecera Voucher");
            }
            return procesoExitoso;
        }


        private void actualizar() {
            try
            {
                if (!validaIngCon()) {
                    Util.ShowAlert("Voucher no existe");
                    return;

                }

                if (!grabarCabeceraVoucher()) {
                    Util.ShowAlert("no se pudo registrar cabecera");
                    return;
                }

            }
            catch (Exception ex) {
                Util.ShowError("Error al actualiza");
            }
        }

        private void txtLibro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                //mostrarAyuda(enmAyuda.enmNaturaleza);
                TraerAyuda(enmAyuda.enmLibro);
                
            }
        }

        private void txtcodLibro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {                
                TraerAyuda(enmAyuda.enmLibro);
            }
        }

        private void dtpFechaVoucher_Leave(object sender, EventArgs e)
        {
            asignaTipoCambio();
        }
    }
}
