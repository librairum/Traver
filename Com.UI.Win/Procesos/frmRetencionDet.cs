using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;

using Inv.BusinessEntities;
using Inv.BusinessLogic;

using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using Com.UI.Win.Procesos;

namespace Com.UI.Win
{
    public partial class frmRetencionDet : frmBaseReg
    {
        #region"instancia"
        private static frmRetencionDet _aForm;
        private FrmRetencionCab FrmParentCab { get; set; }
        //private FrmRetencionLista FrmParentRetencionLista { get; set; }
        string formatonumero = "{0:###,###,##0.00}";
        public static frmRetencionDet Instance(FrmRetencionCab padre)
        {
            if (_aForm != null) return new frmRetencionDet(padre);
            _aForm = new frmRetencionDet(padre);
            return _aForm;
        }

        internal string Ban01Nro;
        public frmRetencionDet(FrmRetencionCab padre)
        {
            InitializeComponent();
            FrmParentCab = padre;
            this.Text = "Registro contable detalle";
        }

        //public frmRetencionDet() {
        //    InitializeComponent();
        //    this.Text = "Registro contable detalle";
        //}
        


        #endregion


        private string orden;
        private bool activaCuentaDestino = false;
        
        private void HabilitarControles(bool estado)
        {

            #region "Cuenta contable"
            #endregion

            #region "Campos personalizados"
            this.txtDocOriTipDoc.Enabled = false;            
            this.txtDocOriNumero.Enabled = false;
            Util.ResaltaAyudaPorEstado(txtDocOriTipDoc);
       

           // this.txtCuentaCorrienteCod.Enabled = false;
            //this.txtCuentaCorrienteDesc.Enabled = false;
            //Util.ResaltaAyudaPorEstado(txtCuentaCorrienteCod);


           // this.txtTrabajocursoCod.Enabled = false;
            //this.txtTrabajoCursoDesc.Enabled = false;
            //Util.ResaltaAyudaPorEstado(txtTrabajocursoCod);

            //this.txtCuentaDestinoCod.Enabled = false;
            //this.txtCuentaDestinoDesc.Enabled = false;
            //Util.ResaltaAyudaPorEstado(txtCuentaDestinoCod);

            #endregion


            #region "Tipo de documento"
            #region "Documento modifica"
            #endregion
            #endregion
            #region "Canpos personalizados 2"
            #endregion


            #region "Cuadro de retencion"
            #endregion






        }
        /// <summary>
        /// Habilita los controles del formulario segun los flag que trae los cuentosw contables
        /// </summary>
        private void HabilitarControlsPorCuentaContable(){

        }
        private void frmRetencionDet_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            CargarControles(FrmParentCab.Estado);
               
        }
        public void BloquearControles(bool condicional) 
        {
             foreach (Control c in this.Controls)
            {
                
                  foreach(Control controlesPanel in c.Controls)
                    {
                        if (controlesPanel is RadTextBox)
                        {
                            controlesPanel.Enabled = condicional;
                            txtDocOriFecha.Enabled = condicional;
                              
                        }
                      
                    }
                
                
                
            }
        }
        public void IniciarControles() 
        {

            txtRetDocImpS.Text = Util.NumberFormat("0", formatonumero);
            txtRetDocImpD.Text = Util.NumberFormat("0", formatonumero);
            txtRetencionSol.Text = Util.NumberFormat("0", formatonumero);
            txtRetencionDol.Text = Util.NumberFormat("0", formatonumero);
            txtDocImpPagarSol.Text = Util.NumberFormat("0", formatonumero);
            txtDocImpPagarDol.Text = Util.NumberFormat("0", formatonumero);

            //PENDIENTE DE LIMPIAR LOS CAMPOS 
            txtDocOriTipDoc.Text = "";
            txtDocOriNumero.Text = "";
            txtDocOriFecha.Text = "";
            txtDocOriMoneda.Text = "";
            txtdocoriImpsol.Text = "";
            txtDocoriImpDol.Text = "";
            txtRetNroDoc.Text = "";

            //END LIMPIAR

            txtDocOriTipDoc.Enabled = false;
            txtDocOriNumero.Enabled = false;
            txtDocOriFecha.Enabled = false;
            txtDocOriMoneda.Enabled = false;
            txtdocoriImpsol.Enabled = false;
            txtDocoriImpDol.Enabled = false;
            Util.ResaltarAyuda(txtRetNroDoc);
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
        }
        public void CargarControles(FormEstate Estado) 
        {
            if (FrmParentCab.Estado == FormEstate.New)
            {
                //Nuevo registros
                IniciarControles();
            }
            else if (FrmParentCab.Estado == FormEstate.View)
            {
                Util.ResaltarAyuda(txtRetNroDoc);
                TraerRetencionDetalle();
                
                BloquearControles(false);
            }
            else if (FrmParentCab.Estado == FormEstate.Edit)
            {
                IniciarControles();
                //Util.ResaltarAyuda(txtRetNroDoc);
                TraerRetencionDetalle();
                //HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                //HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
                //txtRetDocTipo.Enabled = false;
                //txtRetNumero.Enabled = false;
                //txtRetFecha.Enabled = false;
                //txtRetMoneda.Enabled = false;
                //txtdocoriImpsol.Enabled = false;
                //txtDocoriImpDol.Enabled = false;
                //BloquearControles(true);
            }

        }
        public void Limpiar() 
        {

        }
         public void ValidarCampos(RadTextBox Inputs) 
        {

            if (Inputs.Text == "")
            {
                Util.ShowMessage("Ingrese datos para poder registrar un detalle de la retencion", 1);
            }
            else 
            {
                InsertarRetencionDet();
                FrmParentCab.TraerRetencionDetGrilla();
            }

          
        }
        public void TraerRetencionDetalle() 
        {
           GridViewRowInfo fila = FrmParentCab.gridControl.MasterView.CurrentRow; 
           try
           {

               List<Spu_Com_Trae_RetencionDet> ListaRetencionDet = RetencionLogic.Instance.TraerRetencionDet(Logueo.CodigoEmpresa, FrmParentCab.RetencionNumero);

               Ban01Nro = ListaRetencionDet[0].Ban01Nro;
               
               //
               txtDocOriTipDoc.Text = ListaRetencionDet[0].CO05TIPDOC;
               txtDocOriNumero.Text = ListaRetencionDet[0].CO05NRODOC;
               txtDocOriMoneda.Text = ListaRetencionDet[0].CO05MONEDA;
               if (ListaRetencionDet[0].CO05FECHA != null && string.Format("{0:dd/MM/yyyy}", ListaRetencionDet[0].CO05FECHA).Length == 10)
               {
                   txtDocOriFecha.Text = string.Format("{0:dd/MM/yyyy}", ListaRetencionDet[0].CO05FECHA);
               }
               //txtdocoriTipCambio.Text = Util.AsignarNumeroFormateado(ListaRetencionDet[0].CO05TC);
               txtdocoriImpsol.Text = Util.AsignarNumeroFormateado(ListaRetencionDet[0].CO05IMPORT);
               txtDocoriImpDol.Text = Util.AsignarNumeroFormateado(ListaRetencionDet[0].CO05IMPDOL);

               //
               txtRetDocImpS.Text = Util.AsignarNumeroFormateado(ListaRetencionDet[0].Ban01Pago);
               txtRetDocImpD.Text = Util.AsignarNumeroFormateado(ListaRetencionDet[0].Ban01PagoDolares);

               txtRetPorc.Text = Util.AsignarNumeroFormateado(ListaRetencionDet[0].Ban01Porcentaje);

               txtRetencionSol.Text = Util.AsignarNumeroFormateado(ListaRetencionDet[0].Ban01Retenido);
               txtRetencionDol.Text = Util.AsignarNumeroFormateado(ListaRetencionDet[0].Ban01RetenidoDolares);

               txtDocImpPagarSol.Text = Util.AsignarNumeroFormateado(ListaRetencionDet[0].Ban01PagoNeto);
               txtDocImpPagarDol.Text = Util.AsignarNumeroFormateado(ListaRetencionDet[0].Ban01PagoNetoDolares);
           }
           catch (Exception ex)
           {
               Util.ShowError("Error al cargar datos de cabera de documento, detalle: " + ex.Message);
           }
        }
        protected override void OnNuevo()
        {
            
            MessageBox.Show("Entro al nuevo");
            //Util.ResaltaAyudaPorEstado(txtCentroCostoCod);
            //Util.ResaltaAyudaPorEstado(txtCuentaDestinoCod);
            //Util.ResaltaAyudaPorEstado(txtCuentaCod);
            //Util.ResaltaAyudaPorEstado(txtMaquinaCod);
            //Util.ResaltaAyudaPorEstado(txtCuentaCorrienteCod);
            //Util.ResaltaAyudaPorEstado(txtCentroGestionCod);
            //Util.ResaltaAyudaPorEstado(txtTrabajocursoCod);
            //Util.ResaltaAyudaPorEstado(txtTipDocCod);
            //Util.ResaltaAyudaPorEstado(txtTipDocModCod);
            //Util.ResaltaAyudaPorEstado(txtColumna);
            //Util.ResaltaAyudaPorEstado(txtMoneda);
            //Util.ResaltaAyudaPorEstado(txtRetencionTipTransaCod);
            //Util.ResaltaAyudaPorEstado(txtRetencionTipoDocCod);
           
            
            
            //HabilitarControles(true);
            //txtCuentaCod.Enabled = true;

            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            

            //Util.ResaltaAyudaPorEstado(txtCentroCostoCod
        }

        private void EditarRegistro() {
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            HabilitarControles(true);
            //valida si hay controles con su flag de activado
            //lectura de flag de activacion
            LeerFlagActivacion();
        }
        protected override void OnEditar()
        {

            Estado = FormEstate.Edit;
            EditarRegistro();
        }


        protected override void OnEliminar()
        {

            bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");

            int flag = 0; string mensaje = "";
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                
                if (respuesta)
                {
                    //proceso eliminar
                    //obtener el numero de orden 
                  //  VoucherLogic.Instance.EliminaDetalle(Logueo.CodigoEmpresa, Logueo.Anio,
                       //  FrmParentCab.LeerMesPorTipoProvision(), FrmParentCab.LeerLibro(), FrmParentCab.LeerNroVoucher(),
                    //     Util.ConvertiraDecimal(orden), out flag, out mensaje);

                    if (flag == 1)
                    {
                        Util.ShowMessage(mensaje, flag);
                        //refresco al grilla de detalle de cuenta
                       // FrmParentCab.CargarDetalleRegistroContable(FrmParentCab.LeerLibro(), FrmParentCab.LeerNroVoucher());
                        this.Close();
                    }
                    else
                    {
                        Util.ShowMessage(mensaje, flag);
                    }

                }
            }
            catch (Exception ex) {
                Util.ShowError("Error al eliminar registro");
            }
            Cursor.Current = Cursors.Default;
        }
        private bool ValidacionControles() {
            bool flag = true;
          
            return flag;
        }
        //private bool ValidaIngreso() {
        //    return true;
        //}
        public void InsertarRetencionDet() 
        {
            GridViewRowInfo data = FrmParentCab.gridControl.MasterView.CurrentRow;
            string Ban01Tipo = Util.GetCurrentCellText(data, "Ban01Tipo");
            string Ban01NroDoc = Util.GetCurrentCellText(data, "Ban01NroDoc");
            string Ban01Codigo = Util.GetCurrentCellText(data, "Ban01Codigo");
            string Ban01Id = Util.GetCurrentCellText(data, "Ban01Id");
            string Ban01Parameters = Ban01Nro;
            string Mensaje = "";
            decimal DocImpPagarSol = decimal.Parse(txtRetDocImpS.Text);
            decimal RetencionSol = decimal.Parse(txtRetencionSol.Text);
            decimal DocImpPagarDol = decimal.Parse(txtRetDocImpD.Text);
            decimal RetencionDol = decimal.Parse(txtRetencionDol.Text);

            RetencionLogic.Instance.InsertarRetencionDet(Logueo.CodigoEmpresa, FrmParentCab.RetencionNumero, FrmParentCab.RucProveedor, txtDocOriTipDoc.Text, txtDocOriNumero.Text, Ban01Codigo, Ban01Id, Ban01Parameters, DocImpPagarSol, RetencionSol, DocImpPagarDol, RetencionDol, out Mensaje);
            Util.ShowMessage(Mensaje, 1);
            FrmParentCab.TraerRetencionDetGrilla();
        }
        public void ActualizarRetencionDet() 
        {
            GridViewRowInfo data = FrmParentCab.gridControl.MasterView.CurrentRow;
            string Ban01Tipo = Util.GetCurrentCellText(data, "Ban01Tipo");
            string Ban01NroDoc = Util.GetCurrentCellText(data, "Ban01NroDoc");
            string Ban01Codigo = Util.GetCurrentCellText(data, "Ban01Codigo");
            string Ban01Id = Util.GetCurrentCellText(data, "Ban01Id");
            string Ban01Parameters = Ban01Nro;
            string Mensaje = "";
            decimal DocImpPagarSol = decimal.Parse(txtRetDocImpS.Text);
            decimal RetencionSol = decimal.Parse(txtRetencionSol.Text);
            decimal DocImpPagarDol = decimal.Parse(txtRetDocImpD.Text);
            decimal RetencionDol = decimal.Parse(txtRetencionDol.Text);
            RetencionLogic.Instance.Actualizar_RetencionDet(Logueo.CodigoEmpresa, FrmParentCab.RetencionNumero, FrmParentCab.RucProveedor, txtDocOriTipDoc.Text, txtDocOriNumero.Text, Ban01Codigo, Ban01Id, Ban01Parameters, DocImpPagarSol, RetencionSol, DocImpPagarDol, RetencionDol, out Mensaje);
            Util.ShowMessage(Mensaje, 1);
            FrmParentCab.TraerRetencionDetGrilla();
        }
        protected override void OnGuardar()
        {
            try
            {

                if(txtRetNroDoc.Text == "")
                {
                    Util.ShowAlert("ERROR:: No se aceptan campos vacios ");
                    return;
                }
                if (FrmParentCab.Estado == FormEstate.New)
                {
                    InsertarRetencionDet();
                    IniciarControles();
                    //FrmParentRetencionLista.TraerRetencion();
                }
                else if(FrmParentCab.Estado == FormEstate.Edit)
                {
                        ActualizarRetencionDet();
                     //   FrmParentRetencionLista.TraerRetencion();
                    
                } 
            }catch(Exception ex){
            
                MessageBox.Show("Error ==> " + ex);
            }
            
        }
        

        private void CargarDetalle() {
            try
            {
                string anioprovision, nrovoucher, mesprovision, libro; 
                double nroorden;
             
                nrovoucher = FrmParentCab.LeerNroVoucher();
                nroorden = FrmParentCab.LeerNumeroOrden();
            }
            catch (Exception ex) {
                Util.ShowError("Error al cargar detalle");
            }
        }
        protected override void OnCancelar()
        {
            OcultarBotones();
            this.Close();
            
            if (Estado == FormEstate.New) {
                Limpiar(this);
            }
            
            
        }
        bool activaCuentaCorriente = false, activaCentroCosto = false, activaCentroGestion = false,
                activaColReg = false;

        /// <summary>
        /// Trae los estados para activar la ayuda de centro de gestion, centro de costo y tipoAnalisis para cuenta corriente.
        /// </summary>
        private void LeerFlagActivacion() {


            activaCuentaCorriente = false; activaCentroCosto = false;
            activaCentroGestion = false; activaCuentaDestino = false;

            if (flagTipoAnalisis != "" && flagTipoAnalisis != "N" && flagTipoAnalisis.Length == 2)
            {
                activaCuentaCorriente = true;                
            }

            if (flagCentroCosto != "" && flagCentroCosto == "S")
            {
                activaCentroCosto = true;
                
            }

            if (flagCentroGestion != "" && flagCentroGestion == "S") {
                activaCentroGestion = true;
                
            }
            
            //flag para ver si la cuenta es destino
            if (flagCuentaDestino != "" && flagCuentaDestino == "S") {
                activaCuentaDestino = true;
            }
            //configurar el resaltado de ayuda segun los flag de activar
            HabilitarControlsPorCuentaContable();

        }
        /// <summary>
        /// Asigna los valores a los controles de texto haber soles , dolares y debe soles , dolares
        /// segun el tipo de tipo de Cambio
        /// </summary>
        /// <param name="saldoSoles"></param>
        /// <param name="saldoDolares"></param>
        private void AsignarMontos(double saldoSoles, double saldoDolares) {
            double montoValor = 0;
            //string tipoMoneda = txtMoneda.Text;
            //string tipoCambio = "";
        }
        private string flagTipoAnalisis = "",  flagCentroCosto = "", flagCentroGestion = "", flagColReg = "", flagCuentaDestino = "";

        private void TraerAyuda(enmAyuda tipo)
        {
            double saldoDolares = 0, saldoSoles = 0;
            string[] datos = new string[2];
            string codigo = "";
            Cursor.Current = Cursors.WaitCursor;
            frmBusqueda frm;

            if (tipo == enmAyuda.enmCentroGestion)
            {
                if (txtCuentaCod.Text.Trim() == "") {
                 //   Util.ShowError("Ingresar cuenta");
                    return;
                }
                codigo = txtCuentaCod.Text.Trim();
                frm = new frmBusqueda(tipo, codigo);
                frm.ShowDialog();
            }
            else if (tipo == enmAyuda.enmTipoDocumento || tipo == enmAyuda.enmDocuModificaTipo || tipo == enmAyuda.enmTipoDocumentoRetencion) {

                frm = new frmBusqueda(enmAyuda.enmTipoDocumento);
                frm.ShowDialog();
            }
            else if (tipo == enmAyuda.enmHabyMov || tipo == enmAyuda.enmHabyMovDestino) {
                frm = new frmBusqueda(enmAyuda.enmHabyMov);
                frm.ShowDialog();
            }
            else if (tipo == enmAyuda.enmDocXProveedor)
            {
                codigo = FrmParentCab.RucProveedor.Trim();
                if (FrmParentCab.RucProveedor.ToString() == "")
                {
                    return;
                }
                codigo = FrmParentCab.RucProveedor.Trim();
                frm = new frmBusqueda(tipo, codigo);
                frm.ShowDialog();
            }
            else
            {

                frm = new frmBusqueda(tipo);
                frm.ShowDialog();
            }
            
        // Captura resultado de la ayuda

            if (frm.Result == null) {
                return;
            }

                datos = new string[frm.Result.ToString().Split('|').Length];
                datos = frm.Result.ToString().Split('|');
            
                switch (tipo) {
                        
                    case enmAyuda.enmCentroCosto:
                        
                            txtDocOriTipDoc.Text = datos[0];
                            txtDocOriNumero.Text = datos[1];
                            
                        break;

                    case enmAyuda.enmDocXProveedor:
                        txtDocOriTipDoc.Text = datos[0];
                        txtDocOriNumero.Text = datos[1];
                        txtDocOriFecha.Text = datos[2];
                        txtDocOriMoneda.Text = datos[3];
                        txtdocoriImpsol.Text = datos[4];
                        txtDocoriImpDol.Text = datos[5];
                        txtRetNroDoc.Text = datos[1];
                        txtRetPorc.Text = FrmParentCab.TasaRetencion;
                   
                            CalcularTotales(txtDocOriMoneda.Text);

                        
                        break;
                 

                    default:
                        break;
                }
            
             
        }
        public void CalcularTotales(string TipoMoneda) 
        {
            string TasaRetencion = FrmParentCab.TasaRetencion;
            string TipoCambioRetencion = FrmParentCab.TipoCambioRetencion;

            try { 
            decimal DocoriImporteD = decimal.Parse(txtDocoriImpDol.Text);
            decimal DocoriImporteS = decimal.Parse(txtdocoriImpsol.Text);

            decimal DTasaRetencion = decimal.Parse(TasaRetencion);
            decimal DTipoCambioRetencion = decimal.Parse(TipoCambioRetencion);
           

            if (TipoMoneda == "D")
            {
                txtRetDocImpD.Text = Util.NumberFormat(DocoriImporteD.ToString(), formatonumero);
                txtRetDocImpS.Text = Util.NumberFormat((decimal.Parse(txtRetDocImpD.Text) * DTipoCambioRetencion).ToString(), formatonumero);
               //retencion dolares
                txtRetencionDol.Text = Util.NumberFormat((decimal.Parse(txtRetDocImpD.Text) * DTasaRetencion / 100).ToString(), formatonumero);
              //retencion soles

                txtRetencionSol.Text = Util.NumberFormat((decimal.Parse(txtRetencionDol.Text) * DTipoCambioRetencion).ToString(), formatonumero);

            }
            else if (TipoMoneda == "S")
            {
                txtRetDocImpS.Text = Util.NumberFormat(DocoriImporteS.ToString(), formatonumero);
                txtRetDocImpD.Text = Util.NumberFormat((decimal.Parse(txtRetDocImpS.Text) / DTipoCambioRetencion).ToString(), formatonumero);

                txtRetencionSol.Text = Util.NumberFormat((decimal.Parse(txtRetDocImpS.Text) * DTasaRetencion / 100).ToString(), formatonumero);
                txtRetencionDol.Text = Util.NumberFormat((decimal.Parse(txtRetencionSol.Text) / DTipoCambioRetencion).ToString(), formatonumero);
            }
            //Calcular Neto a Pagar
            txtDocImpPagarSol.Text = Util.NumberFormat((decimal.Parse(txtRetDocImpS.Text) - decimal.Parse(txtRetencionSol.Text)).ToString(), formatonumero);
            txtDocImpPagarDol.Text = Util.NumberFormat((decimal.Parse(txtRetDocImpD.Text) - decimal.Parse(txtRetencionDol.Text)).ToString(), formatonumero);
            }catch(Exception ex)
            {
                Util.ShowMessage("No se puede hacer los calculos, algo salio mal",1);
            }
        }

        #region "Eventos de cajas de texto"
        
        private void txtCuentaCod_TextChanged(object sender, EventArgs e)
        {
            string descripcion = "";
            if (txtCuentaCod.Text.Trim() != "") {
                GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, Logueo.Anio+txtCuentaCod.Text.Trim(), "C3", out descripcion);
                //txtCuentaDesc.Text = descripcion;
            }
        }

        private void txtCuentaDestinoCod_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCentroCostoCod_TextChanged(object sender, EventArgs e)
        {
            string descripcion = "";
            if (txtDocOriTipDoc.Text != "")
            {
                GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, Logueo.CodigoEmpresa + Logueo.Anio + txtDocOriTipDoc.Text, "T1", out descripcion);
                txtDocOriNumero.Text = descripcion;
            }
            else {
                txtDocOriNumero.Text = "";
            }

        }

        private void txtCuentaCorrienteCod_TextChanged(object sender, EventArgs e)
        {   
        }



    


       

        private void txtRetencionTipTransaCod_TextChanged(object sender, EventArgs e)
        {

            string descripcion = "";
        }

        private void txtRetencionTipoDocCod_TextChanged(object sender, EventArgs e)
        {
            string descripcion = "";
  
        }
        private void txtMoneda_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtColumna_TextChanged(object sender, EventArgs e)
        {

        }


        /*APERTURAR AYUDA EN TXT CODIGO*/
        #region "Campos de ayuda"
        private void txtCuentaCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { 
                ////traer ventana de ayuda
                //Util.ShowAlert("Mostrar ventana de ayuda");
                ////luego de selccionar el control
                //txtCuentaCod.Text = "01";
                TraerAyuda(enmAyuda.enmHabyMov);
            }
        }

        private void txtCuentaDestino_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                ////traer ventana de ayuda
                //Util.ShowAlert("Mostrar ventana de ayuda");
                ////luego de selccionar el control
                //txtCuentaCod.Text = "01";
                TraerAyuda(enmAyuda.enmHabyMovDestino);
            }
        }
        private void txtCentroCostoCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                TraerAyuda(enmAyuda.enmCentroCosto);
                //traer ventana de ayuda
                //Util.ShowAlert("Mostrar ventana de ayuda");
                //luego de selccionar el control
                //txtCuentaCod.Text = "01";

            }
        }

        private void txtCuentaCorrienteCod_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.F1)
            {
                TraerAyuda(enmAyuda.enmProveedor);
                ////traer ventana de ayuda
                //Util.ShowAlert("Mostrar ventana de ayuda");
                ////luego de selccionar el control
                //txtCuentaCod.Text = "01";
                
            }
        }

        private void txtMaquinaCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {

                TraerAyuda(enmAyuda.enmMaquina);
                //traer ventana de ayuda
                //Util.ShowAlert("Mostrar ventana de ayuda");
                //luego de selccionar el control
                //txtCuentaCod.Text = "01";
                

            }
        }

        private void txtCentroGestionCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                TraerAyuda(enmAyuda.enmCentroGestion);
                ////traer ventana de ayuda
                //Util.ShowAlert("Mostrar ventana de ayuda");
                ////luego de selccionar el control
                //txtCuentaCod.Text = "01";

            }
        }

        private void txtTrabajocursoCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                TraerAyuda(enmAyuda.enmTrabajoCurso);                
            }
        }

        private void txtTipDocCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {                
                TraerAyuda(enmAyuda.enmTipoDocumento);
            }
        }

        private void txtTipDocModCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                TraerAyuda(enmAyuda.enmDocuModificaTipo);
            }
        }

        private void txtColumna_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //traer ventana de ayuda
                TraerAyuda(enmAyuda.enmOrdenColumn);

            }
        }

        private void txtMoneda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                ////traer ventana de ayuda
                //Util.ShowAlert("Mostrar ventana de ayuda");
                ////luego de selccionar el control
                //txtCuentaCod.Text = "01";
                TraerAyuda(enmAyuda.enmMoneda);
            }
        }

        private void txtRetencionTipTransaCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                ////traer ventana de ayuda
                //Util.ShowAlert("Mostrar ventana de ayuda");
                ////luego de selccionar el control
                //txtCuentaCod.Text = "01";
                TraerAyuda(enmAyuda.enmTipoTransaccionRetencion);

            }
        }

        private void txtRetencionTipoDocCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                TraerAyuda(enmAyuda.enmTipoDocumentoRetencion);
            }
        }
        /*SUFIJO PARA VALORES NUMÉRICOS Y DEL TIPO MONEDA INGRESADOS*/
        #endregion
        #endregion



        private void Limpiar(Control controlFormulario)  {
            try { 
            
            
                foreach (Control ctrl in controlFormulario.Controls) {
                    //((RadTextBox)ctrl).Text = "";
                    if (ctrl is RadPanel) {
                        Limpiar(ctrl);
                    
                    
                    }

                    if (ctrl is Panel) {
                        Limpiar(ctrl);
                    }
                    if (ctrl is GroupBox) {
                        Limpiar(ctrl);
                    }

                    if (ctrl is RadGroupBox) {
                        Limpiar(ctrl);
                    }

                    if (ctrl is RadTextBox) {

                        ctrl.Text = "";
                        ((RadTextBox)ctrl).Text = "";

                    }
                    if (ctrl is RadDateTimePicker) {
                        ((RadDateTimePicker)ctrl).Value = DateTime.Now;
                    }

                }

                
                }catch (Exception ex){
                    Util.ShowError("Error al limpiar controles "  + ex.Message);
                }
        }

        //boton nuevo
        private void NuevoRegistro()
        {
            //try
            //{


            Limpiar(this);
            
            string descripcion = "";
            //habilitar y limpiar controles del formulario
            //habilitar controles
            //limpiar controles Y/o asginar sus valores po defecto
            
            HabilitarControles(true);
            HabilitarControlsPorCuentaContable();
            
           
        }
        //bool CalcularMontoEquivalente = true;
        /// <summary>
        /// Metodo para calcular los montos equivalentes y no equivalente  segun un tipo de moneda.
        /// </summary>
        /// <param name="calcularMontoEquivalente">Indicar true para asignar monto equivalente , false para asignar a los montos no equivlaentes</param>
        private void CalcularEquivalentes(bool calcularMontoEquivalente) {
            string tipoMoneda; 
            double valorDebe , valorHaber, valorDebeEquivalente, valorHaberEquivalente;
            double valorTipoCambio;   

        }
     

    

   

        private void txtAfectoRetencion_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) {
            //    OnGuardar();
            //}
        }

        private void radLabel3_Click(object sender, EventArgs e)
        {

        }

        private void txtRetNroDoc_KeyDown(object sender, KeyEventArgs e)
        {

            //AGREGADO EL FORMULARIO DE AYUDA DE DOCUMENTO x PROVEEDOR
            if (e.KeyCode == Keys.F1)
            {
                TraerAyuda(enmAyuda.enmDocXProveedor);
            }
        }


        private void txtRetDocImpS_Leave(object sender, EventArgs e)
        {
            
        }

    }
}
