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
    public partial class frmRegistroContableDet : frmBaseReg
    {
        #region"instancia"
        private static frmRegistroContableDet _aForm;
        private frmProvFactRegContable FrmParent { get; set; }

        public static frmRegistroContableDet Instance(frmProvFactRegContable padre)
        {
            if (_aForm != null) return new frmRegistroContableDet(padre);
            _aForm = new frmRegistroContableDet(padre);
            return _aForm;
        }


        public frmRegistroContableDet(frmProvFactRegContable padre)
        {
            InitializeComponent();
            FrmParent = padre;
            this.Text = "Registro contable detalle";
        }

        //public frmRegistroContableDet() {
        //    InitializeComponent();
        //    this.Text = "Registro contable detalle";
        //}



        #endregion


        private string orden;
        private bool activaCuentaDestino = false;

        private void HabilitarControles(bool estado)
        {

            #region "Cuenta contable"
            this.txtCuentaCod.Enabled = estado;
            this.txtCuentaDesc.Enabled = false;
            Util.ResaltaAyudaPorEstado(txtCuentaCod);

            this.txtCuentaDestinoCod.Enabled = estado;
            this.txtCuentaDestinoDesc.Enabled = false;
            Util.ResaltaAyudaPorEstado(txtCuentaDestinoCod);

            this.txtcomprobante.Enabled = estado;
            this.txtglosa.Enabled = estado;
            #endregion

            #region "Campos personalizados"
            this.txtCentroCostoCod.Enabled = false;
            this.txtCentroCostoDesc.Enabled = false;
            Util.ResaltaAyudaPorEstado(txtCentroCostoCod);

            this.txtMaquinaCod.Enabled = false;
            this.txtMaquinaDesc.Enabled = false;
            Util.ResaltaAyudaPorEstado(txtMaquinaCod);

            this.txtCentroGestionCod.Enabled = false;
            this.txtCentroGestionDesc.Enabled = false;
            Util.ResaltaAyudaPorEstado(txtCentroGestionCod);

            this.txtCuentaCorrienteCod.Enabled = false;
            this.txtCuentaCorrienteDesc.Enabled = false;
            Util.ResaltaAyudaPorEstado(txtCuentaCorrienteCod);


            this.txtTrabajocursoCod.Enabled = false;
            this.txtTrabajoCursoDesc.Enabled = false;
            Util.ResaltaAyudaPorEstado(txtTrabajocursoCod);

            this.txtCuentaDestinoCod.Enabled = false;
            this.txtCuentaDestinoDesc.Enabled = false;
            Util.ResaltaAyudaPorEstado(txtCuentaDestinoCod);

            #endregion


            #region "Tipo de documento"
            this.txtTipDocCod.Enabled = estado;
            this.txtTipDocDesc.Enabled = false;
            Util.ResaltaAyudaPorEstado(txtTipDocCod);

            #region "Documento modifica"
            this.txtTipDocModCod.Enabled = estado;
            this.txtTipDocModDesc.Enabled = false;
            Util.ResaltaAyudaPorEstado(txtTipDocModCod);

            this.txtTipDocModNum.Enabled = estado;
            this.txtModFecha.Enabled = estado;

            #endregion
            #endregion
            #region "Canpos personalizados 2"
            this.txtNroDoc.Enabled = estado;
            this.txtAnioDua.Enabled = estado;
            this.txtNroPago.Enabled = estado;




            this.txtFecDoc.Enabled = estado;
            this.txtFecPago.Enabled = estado;
            this.txtFecVcto.Enabled = estado;
            #endregion

            #region "Campos personalizados 3"

            this.txtColumna.Enabled = estado;
            Util.ResaltaAyudaPorEstado(txtColumna);

            this.txtMoneda.Enabled = estado;
            Util.ResaltaAyudaPorEstado(txtMoneda);

            this.txtTipoCambio.Enabled = estado;
            #endregion


            #region "Cuadro de retencion"
            //cuadro de retencion
            this.txtAfectoRetencion.Enabled = estado;

            this.txtRetencionTipTransaCod.Enabled = false;
            this.txtRetencionTipoTransaDesc.Enabled = false;

            this.txtRetencionTipoDocCod.Enabled = false;
            this.txtRetencionTipoDocDesc.Enabled = false;
            Util.ResaltaAyudaPorEstado(txtRetencionTipoDocCod);

            this.txtRetencionNro.Enabled = false;


            this.txtRetencionFecha.Enabled = false;
            this.txtRetencionFecPago.Enabled = false;
            #endregion

            #region "valores monetarios"
            this.txtDebeEquivalente.Enabled = estado;
            this.txtDebe.Enabled = estado;

            this.txtHaberEquivalente.Enabled = estado;
            this.txtHaber.Enabled = estado;
            #endregion






        }
        /// <summary>
        /// Habilita los controles del formulario segun los flag que trae los cuentosw contables
        /// </summary>
        private void HabilitarControlsPorCuentaContable()
        {


            txtCentroCostoCod.Enabled = false;

            txtCentroGestionCod.Enabled = false;
            txtCuentaCorrienteCod.Enabled = false;

            if (activaCentroCosto)
            {
                txtCentroCostoCod.Enabled = true;
                Util.ResaltarAyuda(txtCentroCostoCod);
            }

            if (activaCuentaCorriente)
            {
                txtCuentaCorrienteCod.Enabled = true;
                Util.ResaltarAyuda(txtCuentaCorrienteCod);
            }

            if (activaCentroGestion)
            {
                txtCentroGestionCod.Enabled = true;
                Util.ResaltarAyuda(txtCentroGestionCod);
            }

            if (activaCuentaDestino)
            {
                txtCuentaDestinoCod.Enabled = true;
                Util.ResaltarAyuda(txtCuentaDestinoCod);
            }
        }
        private void frmRegistroContableDet_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            //si traer dato un registro los botones que debe visualizar es guardar y cancelar
            //Modo visualizacion
            if (Estado == FormEstate.List)
            {
                HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
                HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
                HabilitarControles(false);
            }
            else if (Estado == FormEstate.Edit)
            {
                HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
                EditarRegistro();
            }
            else if (Estado == FormEstate.New)
            {
                //Nuevo registros
                HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
                NuevoRegistro();
            }



            if (FrmParent.seleccionaFilaaEditar == true)
            {
                CargarDetalle();
            }



            //HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
        }

        protected override void OnNuevo()
        {
            NuevoRegistro();
            Util.ResaltaAyudaPorEstado(txtCentroCostoCod);
            Util.ResaltaAyudaPorEstado(txtCuentaDestinoCod);
            Util.ResaltaAyudaPorEstado(txtCuentaCod);
            Util.ResaltaAyudaPorEstado(txtMaquinaCod);
            Util.ResaltaAyudaPorEstado(txtCuentaCorrienteCod);
            Util.ResaltaAyudaPorEstado(txtCentroGestionCod);
            Util.ResaltaAyudaPorEstado(txtTrabajocursoCod);
            Util.ResaltaAyudaPorEstado(txtTipDocCod);
            Util.ResaltaAyudaPorEstado(txtTipDocModCod);
            Util.ResaltaAyudaPorEstado(txtColumna);
            Util.ResaltaAyudaPorEstado(txtMoneda);
            Util.ResaltaAyudaPorEstado(txtRetencionTipTransaCod);
            Util.ResaltaAyudaPorEstado(txtRetencionTipoDocCod);



            //HabilitarControles(true);
            //txtCuentaCod.Enabled = true;

            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);


            //Util.ResaltaAyudaPorEstado(txtCentroCostoCod
        }

        private void EditarRegistro()
        {
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            HabilitarControles(true);
            //valida si hay controles con su flag de activado
            //lectura de flag de activacion
            LeerFlagActivacion();
            if (activaCentroCosto == true)
            {
                //txtCentroCostoCod.Enabled = true;
                Util.ResaltaAyudaPorEstado(txtCentroCostoCod);
            }

            if (activaCuentaCorriente == true)
            {
                //txtCuentaCorrienteCod.Enabled = true;
                Util.ResaltaAyudaPorEstado(txtCuentaCorrienteCod);
            }

            if (activaCentroGestion == true)
            {
                //txtCentroGestionCod.Enabled = true;
                Util.ResaltaAyudaPorEstado(txtCentroGestionCod);
            }
            if (activaCuentaDestino == true)
            {
                txtCuentaCod.Enabled = false;
                txtCuentaDestinoCod.Enabled = true;
                Util.ResaltaAyudaPorEstado(txtCuentaDestinoCod);
            }
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
                    VoucherLogic.Instance.EliminaDetalle(Logueo.CodigoEmpresa, Logueo.Anio,
                         FrmParent.LeerMesPorTipoProvision(), FrmParent.LeerLibro(), FrmParent.LeerNroVoucher(),
                         Util.ConvertiraDecimal(orden), out flag, out mensaje);

                    if (flag == 1)
                    {
                        Util.ShowMessage(mensaje, flag);
                        //refresco al grilla de detalle de cuenta
                        FrmParent.CargarDetalleRegistroContable(FrmParent.LeerLibro(), FrmParent.LeerNroVoucher());
                        this.Close();
                    }
                    else
                    {
                        Util.ShowMessage(mensaje, flag);
                    }

                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar registro");
            }
            Cursor.Current = Cursors.Default;
        }
        private bool ValidacionControles()
        {
            bool flag = true;
            if (txtCentroCostoCod.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar codigo de centro costo");
                flag = false;
            }
            if (txtAfectoRetencion.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar estado de afecto de retencion");
                flag = false;
            }
            if (txtAnioDua.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar año DUA");
                flag = false;
            }
            if (txtCentroGestionCod.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar codigo de centro gestion");
                flag = false;
            }
            if (txtColumna.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar columna");
                flag = false;
            }
            if (txtcomprobante.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar codigo de comprobante");
                flag = false;
            }
            if (txtCuentaCod.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar codigo cuenta de origen");
                flag = false;
            }
            if (txtCuentaCorrienteCod.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar codigo de cuenta corriente");
                flag = false;
            }
            if (txtCuentaDestinoCod.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar codigo de cuenta destino");
                flag = false;
            }
            /* if (txtDebeDolares.Text.Trim() == "")
             {
                 Util.ShowAlert("Ingresar si debe dolares");
                 flag = false;
             }
             if (txtDebeSoles.Text.Trim() == "")
             {
                 Util.ShowAlert("Ingresar si debe soles");
                 flag = false;
             }*/
            if (txtglosa.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar glosa");
                flag = false;
            }
            /*   if (txtHaberDolares.Text.Trim() == "")
               {
                   Util.ShowAlert("Ingresar monto haber dolares");
                   flag = false;
               }
               if (txtHaberSoles.Text.Trim() == "")
               {
                   Util.ShowAlert("Ingresar monto haber soles");
                   flag = false;
               }*/
            if (txtMaquinaCod.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar codigo maquina");
                flag = false;
            }
            if (txtMoneda.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar moneda de pago");
                flag = false;
            }
            if (txtNroDoc.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar nro de documento");
                flag = false;
            }
            if (txtNroPago.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar nro de pago");
                flag = false;
            }
            if (txtRetencionNro.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar nro de retencion");
                flag = false;
            }
            if (txtRetencionTipoDocCod.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar codigo de tipo de documento de retención");
                flag = false;
            }
            if (txtRetencionTipTransaCod.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar codigo de tipo de transacción de retención");
                flag = false;
            }
            if (txtTipDocCod.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar codigo del tipo de documento");
                flag = false;
            }
            if (txtTipDocModCod.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar codigo de tipo de documento modificado ");
                flag = false;
            }
            if (txtTipDocModNum.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar numero de documento modificado");
                flag = false;
            }
            if (txtTipoCambio.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar tipo de cambio");
                flag = false;
            }
            if (txtTrabajocursoCod.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar codigo de trabajo en curso");
                flag = false;
            }

            return flag;
        }
        private bool ValidaIngreso()
        {

            if (txtCuentaCod.Text == "")
            {
                Util.ShowAlert("Debe seleccionar una cuenta");
                txtCuentaCod.Focus();
                return false;

            }

            if (txtCuentaCorrienteCod.Enabled)
            {
                if (txtCuentaCorrienteCod.Text == "")
                {
                    Util.ShowAlert("Debe seleccionar una cuenta corriente");
                    txtCuentaCorrienteCod.Focus();
                    return false;
                }
            }

            if (txtCentroCostoCod.Enabled)
            {
                if (txtCentroCostoCod.Text == "")
                {
                    Util.ShowAlert("Debe seleccionar un centro de costo");
                    txtCentroCostoCod.Focus();
                    return false;
                }
            }

            if (txtCentroGestionCod.Enabled)
            {
                if (txtCentroGestionCod.Text == "")
                {
                    Util.ShowAlert("Debe seleccionar centro de gestion");
                    txtCentroGestionCod.Focus();
                    return false;
                }
            }

            if (txtMaquinaCod.Enabled)
            {
                if (txtMaquinaCod.Text == "")
                {
                    Util.ShowAlert("Debe seleccionar codigo de maquina");
                    txtMaquinaCod.Focus();
                    return false;
                }
            }

            if (txtTrabajocursoCod.Enabled)
            {
                if (txtTrabajocursoCod.Text == "")
                {
                    Util.ShowAlert("Debe seleccionar un trabajo en curso");
                    txtTrabajocursoCod.Focus();
                    return false;

                }
            }

            if (txtglosa.Text == "")
            {
                Util.ShowAlert("Debe ingresar glosa");
                txtglosa.Focus();
                return false;
            }

            if (txtNroDoc.Text == "")
            {
                Util.ShowAlert("Debe ingresar numero de documento");
                txtNroDoc.Focus();
                return false;
            }

            //if (Util.EsNumero(txtDebe.Text) == false) {
            //    Util.ShowAlert("Debe ingresar valor numerico");
            //    txtDebe.Focus();
            //    return false;
            //}

            //if (Util.EsNumero(txtHaber.Text) == false) {
            //    Util.ShowAlert("Debe ingresar valor numerico");
            //    txtHaber.Focus();
            //    return false;
            //}

            //if (Util.EsNumero(txtDebeEquivalente.Text) == false) {
            //    Util.ShowAlert("Debe ingresar valor numerico");
            //    txtDebeEquivalente.Focus();
            //    return false;
            //}


            //if (Util.EsNumero(txtHaberEquivalente.Text) == false) {
            //    Util.ShowAlert("Debe ingresar valor numerico");
            //    txtHaber.Focus();
            //    return false;
            //}




            return true;
        }
        protected override void OnGuardar()
        {
            bool procesoExitoso = false;

            //if (ValidacionControles()) {
            //    return;
            //}
            int flag = 0;
            string mensaje = "", codigoMoneda = "";
            double importeDebe = 0, importeHaber = 0,
                importeDebeEquiv = 0, importeHaberEquiv = 0;
            string jalar = "";

            try
            {

                VoucherDetalle entidad = new VoucherDetalle();

                if (ValidaIngreso() == false) return;

                entidad.CodigoEmpresa = Logueo.CodigoEmpresa;
                entidad.Anio = Logueo.Anio;
                entidad.Mes = FrmParent.LeerMes();
                entidad.libro = FrmParent.LeerLibro();
                entidad.NumeroVoucher = FrmParent.LeerNroVoucher();
                entidad.AsientoTipo = FrmParent.LeerAsientoTipo();
                entidad.transa = "N";
                entidad.Amarre = "";
                entidad.Porcentaje = FrmParent.LeerTasa();
                //Asigna el valor de analisis 
                entidad.analisis = flagTipoAnalisis;


                #region"Configuracion de principal de cuenta contable detalle"
                entidad.cuenta = txtCuentaCod.Text.Trim();
                entidad.glosa = txtglosa.Text;
                entidad.DocComprobante = txtcomprobante.Text.Trim();
                #endregion
                #region "Configuracion segun cuenta contable"

                //prueba de asginar de vlaores por defecto en codigo
                entidad.CenCos = txtCentroCostoCod.Text;
                //entidad.CenCos = "CC01";
                entidad.CenGes = txtCentroGestionCod.Text;
                //entidad.CenGes = "CG01";
                //maquina
                entidad.CodigoMaquina = txtMaquinaCod.Text.Trim();
                //entidad.CodigoMaquina = "MA01";

                //trabajo en curso
                entidad.CodigoTrabajoCurso = txtTrabajocursoCod.Text.Trim();
                //e0ntidad.CodigoTrabajoCurso = "TC01";
                //cuenta corriente
                entidad.CuentaCorriente = txtCuentaCorrienteCod.Text;
                #endregion

                #region "Configuracion del documento de la cuenta contable"
                entidad.TipoDocumento = txtTipDocCod.Text;
                entidad.NumDoc = txtNroDoc.Text;
                if (txtFecDoc.Text.Length == 10)
                {
                    entidad.FechaDoc = Util.ConvertiraFecha(txtFecDoc.Text);
                }
                else
                {

                    entidad.FechaDoc = null;

                }

                entidad.AnioDua = txtAnioDua.Text.Trim();
                entidad.NroPago = txtNroPago.Text.Trim();


                if (txtFecPago.Text.Length == 10)
                {
                    entidad.FechaPago = Util.ConvertiraFecha(txtFecPago.Text);
                }
                else
                {

                    entidad.FechaPago = null;

                }

                if (txtFecVcto.Text.Length == 10)
                {
                    entidad.FechaVencimiento = Util.ConvertiraFecha(txtFecVcto.Text);
                }
                else
                {

                    entidad.FechaVencimiento = null;

                }
                #endregion

                #region"Documento modifica"
                // Documento modifica
                entidad.DocModTipo = txtTipDocModCod.Text.Trim();
                entidad.DocModNumero = txtTipDocModNum.Text.Trim();

                if (txtModFecha.Text.Length == 10)
                {
                    entidad.DocModFecha = Util.ConvertiraFecha(txtModFecha.Text.Trim());
                }
                else
                {
                    entidad.DocModFecha = null;
                }
                #endregion

                #region "Configuracion moneda, column y tip.cambio"
                // campo de columna
                entidad.Afecto = txtColumna.Text.Trim();
                entidad.moneda = txtMoneda.Text;
                entidad.TipoCambio = Util.ConvertiraDecimal(txtTipoCambio.Text);
                #endregion

                #region "Importes e Importes equivalentes"
                if (txtMoneda.Text.ToUpper() == "S")
                {
                    importeDebe = Util.ConvertiraDecimal(txtDebe.Text);
                    importeHaber = Util.ConvertiraDecimal(txtHaber.Text);

                    importeDebeEquiv = Util.ConvertiraDecimal(txtDebeEquivalente.Text);
                    importeHaberEquiv = Util.ConvertiraDecimal(txtHaberEquivalente.Text);
                }
                else if (txtMoneda.Text.ToUpper() == "D")
                {
                    // Dolares
                    importeDebeEquiv = Util.ConvertiraDecimal(txtDebe.Text);
                    importeHaberEquiv = Util.ConvertiraDecimal(txtHaber.Text);

                    importeDebe = Util.ConvertiraDecimal(txtDebeEquivalente.Text);
                    importeHaber = Util.ConvertiraDecimal(txtHaberEquivalente.Text);
                }




                if (Util.EsNumero(txtDebe.Text) == false)
                {
                    Util.ShowAlert("Debe ingresar un valor numerico"); return;
                }
                if (importeDebe > 0 && importeHaber > 0)
                {
                    Util.ShowAlert("Debe ingresar solo el Debe o el Haber");
                    return;
                }


                if (importeDebeEquiv > 0 && importeHaberEquiv > 0)
                {
                    Util.ShowAlert("Debe ingresar solo el Debe o el Haber");
                    return;
                }

                if (codigoMoneda.ToUpper() == "S")
                {
                    if (importeDebe > 0 && importeHaber > 0)
                    {
                        Util.ShowAlert("Solo se permite ingresar valor en los importes de  Debe o Haber");
                        return;
                    }

                }
                else if (codigoMoneda.ToUpper() == "D")
                {
                    if (importeDebeEquiv > 0 && importeHaberEquiv > 0)
                    {
                        Util.ShowAlert("Solo se permite ingresar valor en los importes equivalentes de Debe o haber");
                        return;
                    }
                }

                entidad.ImporteDebe = importeDebe;
                entidad.ImporteHaber = importeHaber;
                entidad.ImporteDebeEquivalencia = importeDebeEquiv;
                entidad.ImporteHaberEquivalencia = importeHaberEquiv;
                #endregion

                #region "Flag de retencion"

                if (txtAfectoRetencion.Text.Trim() == "" || txtAfectoRetencion.Text.Trim().ToUpper() != "S")
                {
                    txtAfectoRetencion.Text = "N";
                }

                entidad.AfectoRetencion = txtAfectoRetencion.Text.Trim();
                #endregion

                #region "retencion"
                //Tipo de transaccion 
                entidad.TipoTransaccion = txtRetencionTipTransaCod.Text.Trim();

                //tipo documento 
                entidad.TipoDocRetencion = txtRetencionTipoDocCod.Text.Trim();

                //numero documento
                entidad.NroDocRetencion = txtRetencionNro.Text.Trim();
                //fecha
                if (txtRetencionFecha.Text.Length == 10)
                {
                    entidad.FechaRetencion = Util.ConvertiraFecha(txtRetencionFecha.Text.Trim());
                }
                else
                {
                    entidad.FechaRetencion = null;
                }

                if (txtRetencionFecPago.Text.Length == 10)
                {
                    //fecha pago
                    entidad.FechaPagoRetencion = Util.ConvertiraFecha(txtRetencionFecPago.Text.Trim());
                }
                else
                {
                    entidad.FechaPagoRetencion = null;
                }


                #endregion


                if (Estado == FormEstate.New)
                {

                    string tipoLibro = FrmParent.DameDescripcion(Logueo.CodigoEmpresa + FrmParent.LeerLibro(), "03");
                    string afecto = "";

                    afecto = FrmParent.DameDescripcion(Logueo.CodigoEmpresa + Logueo.Anio + entidad.cuenta, "FA");

                    if ((tipoLibro == "C" || tipoLibro == "V") && (afecto == "A"))
                    {
                        if (Util.ShowQuestion("¿Desea Calcular IGV Automaticamente?") == true)
                        {
                            jalar = "I";
                        }
                    }


                    entidad.valida = jalar;

                    VoucherLogic.Instance.InsertarDetalle(entidad, out flag, out mensaje);
                    Util.ShowMessage(mensaje, flag);
                    //despues de guardar cerrar y mostrar la grilla
                    this.Close();

                }
                else if (Estado == FormEstate.Edit)
                {

                    //definir el valor de orden del detalle de registro contable

                    //entidad.orden = 0;
                    entidad.orden = Util.ConvertiraDecimal(this.orden);
                    VoucherLogic.Instance.ActualizoDetalle(entidad, out flag, out mensaje);
                    Util.ShowMessage(mensaje, flag);

                }
                //validar si el proceso de grabar o actualizar fue exitosa 
                if (flag == 1)
                {
                    //desactivar los controles y prepar el formulario para un nuevo registro
                    OnCancelar();
                    //refrescar la grilla de registro contable
                    FrmParent.CargarDetalleRegistroContable(FrmParent.LeerLibro(), FrmParent.LeerNroVoucher(), 0);

                }


            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar . " + ex.Message);
            }

        }


        private void CargarDetalle()
        {
            try
            {
                string anioprovision, nrovoucher, mesprovision, libro;
                double nroorden;
                anioprovision = FrmParent.LeerAnioPorTipoProvision();
                mesprovision = FrmParent.LeerMesPorTipoProvision();
                libro = FrmParent.LeerLibro();
                nrovoucher = FrmParent.LeerNroVoucher();
                nroorden = FrmParent.LeerNumeroOrden();
                VoucherDetalle registro = VoucherLogic.Instance.TraeDetalleVoucher(Logueo.CodigoEmpresa,
                    anioprovision, mesprovision, libro,
                       nrovoucher, nroorden)[0];

                #region "Configuracion principal cuenta contable detalle"
                txtCuentaCod.Text = registro.cuenta;
                txtglosa.Text = registro.glosa;
                txtcomprobante.Text = registro.DocComprobante;
                #endregion

                #region "Configuracion segun cuenta contable"
                txtCentroCostoCod.Text = registro.CenCos;
                txtCentroGestionCod.Text = registro.CenGes;
                txtMaquinaCod.Text = registro.CodigoMaquina;
                txtTrabajocursoCod.Text = registro.CodigoTrabajoCurso;
                txtCuentaCorrienteCod.Text = registro.CuentaCorriente;
                #endregion


                #region "Configuracion del documento de la cuenta contable"
                txtTipDocCod.Text = registro.TipoDocumento;
                txtNroDoc.Text = registro.NumDoc;

                if (registro.FechaDoc != null && string.Format("{0:dd/MM/yyyy}", registro.FechaDoc).Length == 10)
                {
                    txtFecDoc.Text = string.Format("{0:dd/MM/yyyy}", registro.FechaDoc);
                }

                txtAnioDua.Text = registro.AnioDua;
                txtNroPago.Text = registro.NroPago;


                if (registro.FechaPago != null && string.Format("{0:dd/MM/yyyy}", registro.FechaRetencion).Length == 10)
                {
                    txtFecPago.Text = string.Format("{0:dd/MM/yyyy}", registro.FechaRetencion);
                }

                if (registro.FechaVencimiento != null && string.Format("{0:dd/MM/yyyy}", registro.FechaVencimiento).Length == 10)
                {
                    txtFecVcto.Text = string.Format("{0:dd/MM/yyyy}", registro.FechaVencimiento);
                }




                #endregion
                #region "Documento modifica"
                txtTipDocModCod.Text = registro.DocModTipo;
                txtTipDocModNum.Text = registro.DocModNumero;



                if (registro.DocModFecha != null && string.Format("{0:dd/MM/yyyy}", registro.DocModFecha).Length == 10)
                {
                    txtModFecha.Text = string.Format("{0:dd/MM/yyyy}", registro.DocModFecha);
                }
                #endregion

                #region "configuracion moneda, columna y tip.cambio"
                txtColumna.Text = Util.convertiracadena(registro.Afecto);
                txtMoneda.Text = registro.moneda;
                txtTipoCambio.Text = Util.AsignarNumeroFormateado4dec(registro.TipoCambio);
                // txtTipoCambio.Text = string.Format("{0:###,##0.00}", txtTipoCambio.Text);

                #endregion

                //txtCuentaDestinoCod.Text =  registro.cuentadestino;
                #region "Importes e Importes equivalentes"
                txtDebe.Text = Util.AsignarNumeroFormateado(registro.ImporteDebe);
                txtHaber.Text = Util.AsignarNumeroFormateado(registro.ImporteHaber);

                txtDebeEquivalente.Text = Util.AsignarNumeroFormateado(registro.ImporteDebeEquivalencia);
                txtHaberEquivalente.Text = Util.AsignarNumeroFormateado(registro.ImporteHaberEquivalencia);
                #endregion


                #region "flag de retencion"
                if (registro.AfectoRetencion == null | Util.convertiracadena(registro.AfectoRetencion) == "" || registro.AfectoRetencion == "N")
                {
                    txtAfectoRetencion.Text = "N";
                }
                else
                {
                    txtAfectoRetencion.Text = registro.AfectoRetencion;
                }

                #endregion


                #region "retencion"
                txtRetencionTipTransaCod.Text = registro.TipoTransaccion;
                txtRetencionTipoDocCod.Text = registro.TipoDocRetencion;
                txtRetencionNro.Text = registro.NroDocRetencion;

                if (registro.FechaRetencion != null && string.Format("{0:dd/MM/yyyy}", registro.FechaRetencion).Length == 10)
                {
                    txtRetencionFecha.Text = string.Format("{0:dd/MM/yyyy}", registro.FechaRetencion);
                }


                if (registro.FechaPagoRetencion != null && string.Format("{0:dd/MM/yyyy}", registro.FechaPagoRetencion).Length == 10)
                {
                    txtRetencionFecPago.Text = string.Format("{0:dd/MM/yyyy}", registro.FechaPagoRetencion);
                }


                #endregion

                //transa
                //amarre
                txtNroPago.Text = registro.NroPago;

                //orden del registro
                orden = Util.convertiracadena(registro.orden);

                #region"flag de activacion de campos"
                string flagCuentaDestino = Util.convertiracadena(registro.flagCuentaDestino);
                //el flag activa el campo de cuenta destino
                if (flagCuentaDestino.ToUpper() == "S" && flagCuentaDestino.ToUpper() != "")
                {
                    activaCuentaDestino = true;
                }
                else if (flagCuentaDestino == "N" || flagCuentaDestino == "")
                {
                    activaCuentaDestino = false;
                }



                if (activaCuentaDestino == false)
                {
                    txtCuentaCod.Text = registro.cuenta;
                }
                else
                {
                    txtCuentaDestinoCod.Text = registro.cuenta;
                }

                //flag de activar campo cuenta corriente, lee el flag de la tabla ccd (Voucher)
                flagTipoAnalisis = Util.convertiracadena(registro.analisis);

                //flag para activar centro de costo
                flagCentroCosto = Util.convertiracadena(registro.CenCos);

                //flag para activar centro de gestion
                flagCentroGestion = Util.convertiracadena(registro.CenGes);
                #endregion

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar detalle");
            }
        }
        protected override void OnCancelar()
        {
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            HabilitarControles(false);

            if (Estado == FormEstate.New)
            {
                Limpiar(this);
            }


        }
        bool activaCuentaCorriente = false, activaCentroCosto = false, activaCentroGestion = false,
                activaColReg = false;

        /// <summary>
        /// Trae los estados para activar la ayuda de centro de gestion, centro de costo y tipoAnalisis para cuenta corriente.
        /// </summary>
        private void LeerFlagActivacion()
        {


            activaCuentaCorriente = false; activaCentroCosto = false;
            activaCentroGestion = false; activaCuentaDestino = false;

            if (flagTipoAnalisis != "" && flagTipoAnalisis != "N" && flagTipoAnalisis.Length == 2)
            {
                activaCuentaCorriente = true;
            }

            if (flagCentroCosto != "" && flagCentroCosto.ToUpper() == "S")
            {
                activaCentroCosto = true;

            }

            if (flagCentroGestion != "" && flagCentroGestion.ToUpper() == "S")
            {
                activaCentroGestion = true;

            }

            //flag para ver si la cuenta es destino
            if (flagCuentaDestino != "" && flagCuentaDestino.ToUpper() == "S")
            {
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
        private void AsignarMontos(double saldoSoles, double saldoDolares)
        {
            double montoValor = 0;
            string tipoMoneda = txtMoneda.Text;
            //string tipoCambio = "";

            if (this.FrmParent.tipoCambio.ToUpper() == "S")
            {
                //importe
                montoValor = saldoSoles < 0 ? Math.Abs(saldoSoles) : 0;
                txtDebe.Text = montoValor.ToString();

                montoValor = saldoSoles > 0 ? Math.Abs(saldoSoles) : 0;
                txtHaber.Text = montoValor.ToString();

                //importe equivalentess
                montoValor = saldoDolares < 0 ? Math.Abs(saldoDolares) : 0;
                txtDebeEquivalente.Text = montoValor.ToString();

                montoValor = saldoDolares > 0 ? Math.Abs(saldoDolares) : 0;
                txtHaberEquivalente.Text = montoValor.ToString();



            }
            else if (this.FrmParent.tipoCambio.ToUpper() == "D")
            {
                //importe no equivalente
                montoValor = saldoDolares < 0 ? Math.Abs(saldoDolares) : 0;
                txtDebeEquivalente.Text = montoValor.ToString();

                montoValor = saldoDolares > 0 ? Math.Abs(saldoDolares) : 0;
                txtHaberEquivalente.Text = montoValor.ToString();

                //importe equivalente
                montoValor = saldoSoles < 0 ? Math.Abs(saldoSoles) : 0;
                txtDebe.Text = montoValor.ToString();

                montoValor = saldoSoles < 0 ? Math.Abs(saldoSoles) : 0;
                txtHaber.Text = montoValor.ToString();


            }
        }
        private string flagTipoAnalisis = "", flagCentroCosto = "", flagCentroGestion = "", flagColReg = "", flagCuentaDestino = "";

        private void TraerAyuda(enmAyuda tipo)
        {
            double saldoDolares = 0, saldoSoles = 0;
            string[] datos = new string[2];
            string codigo = "";
            Cursor.Current = Cursors.WaitCursor;
            frmBusqueda frm;


            if (tipo == enmAyuda.enmCentroGestion)
            {
                if (txtCuentaCod.Text.Trim() == "")
                {
                    Util.ShowError("Ingresar cuenta");
                    return;
                }
                codigo = txtCuentaCod.Text.Trim();
                frm = new frmBusqueda(tipo, codigo);
                frm.ShowDialog();
            }
            else if (tipo == enmAyuda.enmTipoDocumento || tipo == enmAyuda.enmDocuModificaTipo || tipo == enmAyuda.enmTipoDocumentoRetencion)
            {

                frm = new frmBusqueda(enmAyuda.enmTipoDocumento);
                frm.ShowDialog();
            }
            else if (tipo == enmAyuda.enmHabyMov || tipo == enmAyuda.enmHabyMovDestino)
            {
                frm = new frmBusqueda(enmAyuda.enmHabyMov);
                frm.ShowDialog();
            }
            else
            {

                frm = new frmBusqueda(tipo);
                frm.ShowDialog();
            }



            if (frm.Result == null)
            {
                return;
            }

            datos = new string[frm.Result.ToString().Split('|').Length];
            datos = frm.Result.ToString().Split('|');



            switch (tipo)
            {

                case enmAyuda.enmCentroCosto:

                    txtCentroCostoCod.Text = datos[0];
                    txtCentroCostoDesc.Text = datos[1];

                    break;

                case enmAyuda.enmCentroGestion:
                    txtCentroGestionCod.Text = datos[0];
                    txtCentroGestionDesc.Text = datos[1];
                    break;

                case enmAyuda.enmHabyMov:
                    //frm = new frmBusqueda(enmAyuda.enmHabyMov);
                    txtCuentaCod.Text = datos[0];
                    txtCuentaDesc.Text = datos[1];
                    txtMoneda.Text = datos[2];
                    flagTipoAnalisis = datos[3];
                    flagCentroCosto = datos[4];
                    flagCentroGestion = datos[5];
                    flagCuentaDestino = datos[6];
                    LeerFlagActivacion();

                    break;

                case enmAyuda.enmProveedor:
                    //frm = new frmBusqueda(enmAyuda.enmProveedor);
                    txtCuentaCorrienteCod.Text = datos[0];
                    txtCuentaCorrienteDesc.Text = datos[1];
                    break;

                case enmAyuda.enmHabyMovDestino:
                    //frm = new frmBusqueda(enmAyuda.enmHabyMov);
                    txtCuentaDestinoCod.Text = datos[0];
                    txtCuentaDestinoDesc.Text = datos[1];

                    break;

                case enmAyuda.enmMaquina:
                    txtMaquinaCod.Text = datos[0];
                    txtMaquinaDesc.Text = datos[1];
                    break;

                case enmAyuda.enmMoneda:
                    //frm = new frmBusqueda(enmAyuda.enmMoneda);
                    txtMoneda.Text = datos[0];
                    break;


                case enmAyuda.enmRetencionTipDoc:
                    txtRetencionTipoDocCod.Text = datos[0];
                    break;

                case enmAyuda.enmRetencionTipTransa:
                    txtRetencionTipTransaCod.Text = datos[0];
                    txtRetencionTipoTransaDesc.Text = datos[1];
                    break;

                case enmAyuda.enmTipoDocumento:

                    txtTipDocCod.Text = datos[0];
                    txtTipDocDesc.Text = datos[1];

                    break;
                case enmAyuda.enmDocuModificaTipo:
                    txtTipDocModCod.Text = datos[0];
                    txtTipDocModDesc.Text = datos[1];
                    break;




                case enmAyuda.enmDocumentosPendientes:
                    //frm = new frmBusqueda(enmAyuda.enmDocumentosPendientes);
                    txtTipDocModCod.Text = datos[0];
                    txtTipDocModDesc.Text = datos[1];

                    if (datos[2] != "")
                    {

                        txtFecDoc.Text = Util.convertiracadena(datos[2]);
                    }

                    saldoDolares = Convert.ToDouble(datos[3]);
                    saldoSoles = Convert.ToDouble(datos[4]);

                    AsignarMontos(saldoSoles, saldoDolares);


                    break;

                case enmAyuda.enmTrabajoCurso:
                    txtTrabajocursoCod.Text = datos[0];
                    txtTrabajoCursoDesc.Text = datos[1];
                    break;
                case enmAyuda.enmOrdenColumn:
                    //capturo el valor de la descrcion de orden columna
                    txtColumna.Text = datos[0];

                    break;

                case enmAyuda.enmTipoDocumentoRetencion:
                    txtRetencionTipoDocCod.Text = datos[0];
                    txtRetencionTipoDocDesc.Text = datos[1];
                    break;

                case enmAyuda.enmTipoTransaccionRetencion:
                    txtRetencionTipTransaCod.Text = datos[0];
                    txtRetencionTipoTransaDesc.Text = datos[1];
                    break;
                default:
                    break;
            }

            //frmBusqueda frm  = new frmBusqueda(

            /*
                    
                    case "NumeroDocumento":
                        TraerAyuda(enmAyuda.enmDocumentosPendientes);
                        break;
                                        
             
             */
        }
        #region "Eventos de cajas de texto"

        private void txtCuentaCod_TextChanged(object sender, EventArgs e)
        {
            string descripcion = "";
            if (txtCuentaCod.Text.Trim() != "")
            {
                GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, Logueo.Anio + txtCuentaCod.Text.Trim(), "C3", out descripcion);
                txtCuentaDesc.Text = descripcion;
            }
        }

        private void txtCuentaDestinoCod_TextChanged(object sender, EventArgs e)
        {
            string descripcion = "";
            if (txtCuentaDestinoCod.Text != "")
            {
                GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, Logueo.Anio + txtCuentaCod.Text, "C3", out descripcion);
                txtCuentaDestinoDesc.Text = descripcion;
            }
            else
            {
                txtCuentaCorrienteDesc.Text = "";
            }
        }

        private void txtCentroCostoCod_TextChanged(object sender, EventArgs e)
        {
            string descripcion = "";
            if (txtCentroCostoCod.Text != "")
            {
                GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, Logueo.CodigoEmpresa + Logueo.Anio + txtCentroCostoCod.Text, "T1", out descripcion);
                txtCentroCostoDesc.Text = descripcion;
            }
            else
            {
                txtCentroCostoDesc.Text = "";
            }

        }

        private void txtMaquinaCod_TextChanged(object sender, EventArgs e)
        {
            if (txtMaquinaCod.Text != "")
            {

            }
            else
            {
                txtMaquinaDesc.Text = "";
            }
        }

        private void txtCuentaCorrienteCod_TextChanged(object sender, EventArgs e)
        {
            string descripcion = "";
            if (txtCuentaCorrienteCod.Text.Trim() != "")
            {
                GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, Logueo.CodigoEmpresa + "02" + txtCuentaCorrienteCod.Text.Trim(), "CR", out descripcion);
                txtCuentaCorrienteDesc.Text = descripcion;
            }
            else
            {
                txtCuentaCorrienteDesc.Text = "";
            }



        }

        private void txtCentroGestionCod_TextChanged(object sender, EventArgs e)
        {
            string descripcion = "";
            if (txtCentroGestionCod.Text.Trim() != "")
            {
                GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, Logueo.CodigoEmpresa + Logueo.Anio + txtCentroGestionCod.Text.Trim(), "UG", out descripcion);
                txtCentroGestionDesc.Text = descripcion;
            }
            else
            {
                txtCentroGestionDesc.Text = "";
            }
        }

        private void txtTrabajocursoCod_TextChanged(object sender, EventArgs e)
        {
            if (txtTrabajocursoCod.Text != "")
            {

            }
            else
            {
                txtTrabajoCursoDesc.Text = "";
            }
        }

        private void txtTipDocCod_TextChanged(object sender, EventArgs e)
        {
            string descripcion = "";
            //traer al descricion del codigo de tipo de documento
            if (txtTipDocCod.Text.Trim() != "")
            {
                GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, Logueo.CodigoEmpresa + txtTipDocCod.Text.Trim(), "TD", out descripcion);
                txtTipDocDesc.Text = descripcion;

            }
            else
            {
                txtTipDocDesc.Text = "";
            }


        }

        private void txtTipDocModCod_TextChanged(object sender, EventArgs e)
        {
            string descripcion = "";
            if (txtTipDocModCod.Text.Trim() != "")
            {
                GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, Logueo.CodigoEmpresa + txtTipDocCod.Text.Trim(), "TD", out descripcion);
                txtTipDocModDesc.Text = descripcion;
            }
            else
            {
                txtTipDocModDesc.Text = "";
            }
        }

        private void txtRetencionTipTransaCod_TextChanged(object sender, EventArgs e)
        {

            string descripcion = "";
            if (txtRetencionTipTransaCod.Text.Trim() != "")
            {
                GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, Logueo.CodigoEmpresa + txtRetencionTipTransaCod.Text.Trim(), "TRANSARETENCION", out descripcion);
                txtRetencionTipoTransaDesc.Text = descripcion;
            }
            else
            {
                txtRetencionTipoTransaDesc.Text = "";
            }
        }

        private void txtRetencionTipoDocCod_TextChanged(object sender, EventArgs e)
        {
            string descripcion = "";
            if (txtRetencionTipoDocCod.Text.Trim() != "")
            {

                GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, Logueo.CodigoEmpresa + txtRetencionTipoDocCod.Text.Trim(), "TD", out descripcion);
                txtRetencionTipoDocDesc.Text = descripcion;
            }
            else
            {
                txtRetencionTipoDocDesc.Text = "";
            }
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
            if (e.KeyCode == Keys.F1)
            {
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



        private void Limpiar(Control controlFormulario)
        {
            try
            {


                foreach (Control ctrl in controlFormulario.Controls)
                {
                    //((RadTextBox)ctrl).Text = "";
                    if (ctrl is RadPanel)
                    {
                        Limpiar(ctrl);


                    }

                    if (ctrl is Panel)
                    {
                        Limpiar(ctrl);
                    }
                    if (ctrl is GroupBox)
                    {
                        Limpiar(ctrl);
                    }

                    if (ctrl is RadGroupBox)
                    {
                        Limpiar(ctrl);
                    }

                    if (ctrl is RadTextBox)
                    {

                        ctrl.Text = "";
                        ((RadTextBox)ctrl).Text = "";

                    }
                    if (ctrl is RadDateTimePicker)
                    {
                        ((RadDateTimePicker)ctrl).Value = DateTime.Now;
                    }

                }


            }
            catch (Exception ex)
            {
                Util.ShowError("Error al limpiar controles " + ex.Message);
            }
        }

        //boton nuevo
        private void NuevoRegistro()
        {
            string descripcion;
            descripcion = "";
            try
            {

                Estado = FormEstate.New;
                
                HabilitarControles(true);
                HabilitarControlsPorCuentaContable();

                Limpiar(this);
                //Inicia valores
           
                if (FrmParent.fechaVencimiento != "")
                {
                    txtFecVcto.Text = string.Format("{0:dd/MM/yyyy}", FrmParent.fechaVencimiento);
                }

                txtTipoCambio.Text = FrmParent.tipoCambio;
                txtglosa.Text = FrmParent.concepto;
               txtTipDocCod.Text = FrmParent.tipoDocumento;
                GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, Logueo.CodigoEmpresa + txtTipDocCod.Text.Trim(), "TD", out descripcion);
                txtTipDocDesc.Text = descripcion;

               txtNroDoc.Text = FrmParent.nroDocumento;
               txtMoneda.Text = FrmParent.tipoMoneda;
                txtFecDoc.Text = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(FrmParent.FechaDocCab));
                txtTipoCambio.Text = FrmParent.tipoCambio;

                txtDebe.Text = "0.00";
                txtDebeEquivalente.Text = "0.00";
                txtHaber.Text = "0.00";
                txtHaberEquivalente.Text = "0.00";
      
                txtAfectoRetencion.Text = "N";


            }
            catch (Exception ex)
            {
                Util.ShowError("Error al iniciar formulario");
            }


        }
        //bool CalcularMontoEquivalente = true;
        /// <summary>
        /// Metodo para calcular los montos equivalentes y no equivalente  segun un tipo de moneda.
        /// </summary>
        /// <param name="calcularMontoEquivalente">Indicar true para asignar monto equivalente , false para asignar a los montos no equivlaentes</param>
        private void CalcularEquivalentes(bool calcularMontoEquivalente)
        {
            string tipoMoneda;
            double valorDebe, valorHaber, valorDebeEquivalente, valorHaberEquivalente;
            double valorTipoCambio;

            valorTipoCambio = Util.ConvertiraDecimal(txtTipoCambio.Text);

            valorDebe = Util.ConvertiraDecimal(txtDebe.Text);
            valorHaber = Util.ConvertiraDecimal(txtHaber.Text);
            valorDebeEquivalente = Util.ConvertiraDecimal(txtDebeEquivalente.Text);
            valorHaberEquivalente = Util.ConvertiraDecimal(txtHaberEquivalente.Text);

            tipoMoneda = txtMoneda.Text.Trim();


            if (tipoMoneda.ToUpper() == "D")
            {
                if (valorTipoCambio > 0)
                {
                    //se aplica ese calculo cuando sucede variacion del valor de monto no equivalente
                    if (calcularMontoEquivalente == true)
                    {
                        //Mis valores equivalente sera en soles cuando multiplque el tipo de cambio
                        valorDebeEquivalente = valorDebe * valorTipoCambio;
                        valorHaberEquivalente = valorHaber * valorTipoCambio;
                    }
                    else
                    {
                        valorDebe = valorDebeEquivalente / valorTipoCambio;
                        valorHaber = valorHaberEquivalente / valorTipoCambio;
                    }




                }
                else
                {
                    //los valores equivalente de la conversiond e Dolares en monto de soles, 
                    //ya que el valor de tipo cambio debe ser mayor a 0
                    valorDebeEquivalente = 0; valorHaberEquivalente = 0;
                }
            }
            else if (tipoMoneda.ToUpper() == "S")
            {
                if (valorTipoCambio > 0)
                {
                    if (calcularMontoEquivalente == true)
                    {
                        valorDebeEquivalente = valorDebe / valorTipoCambio;
                        valorHaberEquivalente = valorHaber / valorTipoCambio;
                    }
                    else
                    {
                        valorDebe = valorDebeEquivalente * valorTipoCambio;
                        valorHaber = valorHaberEquivalente * valorTipoCambio;
                    }

                }
                else
                {
                    valorDebeEquivalente = 0; valorHaberEquivalente = 0;

                }
            }

            txtHaber.Text = Util.AsignarNumeroFormateado(valorHaber);
            txtDebe.Text = Util.AsignarNumeroFormateado(valorDebe);
            txtHaberEquivalente.Text = Util.AsignarNumeroFormateado(valorHaberEquivalente);
            txtDebeEquivalente.Text = Util.AsignarNumeroFormateado(valorDebeEquivalente);


        }


        private void txtDebe_Leave(object sender, EventArgs e)
        {

            if (txtDebe.Text != "")
            {
                bool esNUmero = false;
                double resultado = 0;

                esNUmero = double.TryParse(txtDebe.Text.Trim(), out resultado);

                if (!esNUmero)
                {
                    Util.ShowError("No es numero");
                    return;
                }

                txtDebe.Text = string.Format("{0:###,##0.00}", resultado);
                CalcularEquivalentes(true);


            }

        }

        private void txtDebeEquivalente_Leave(object sender, EventArgs e)
        {
            if (txtDebeEquivalente.Text != "")
            {
                bool esNUmero = false;
                double resultado = 0;

                esNUmero = double.TryParse(txtDebeEquivalente.Text.Trim(), out resultado);

                if (!esNUmero)
                {
                    Util.ShowError("No es numero");
                    return;
                }

                txtDebeEquivalente.Text = string.Format("{0:###,##0.00}", resultado);

                //CalcularEquivalentes(false);


            }
        }

        private void txtHaber_Leave(object sender, EventArgs e)
        {
            if (txtHaber.Text != "")
            {
                bool esNUmero = false;
                double resultado = 0;

                esNUmero = double.TryParse(txtHaber.Text.Trim(), out resultado);

                if (!esNUmero)
                {
                    Util.ShowError("No es numero");
                    return;
                }

                txtHaber.Text = string.Format("{0:###,##0.00}", resultado);
                CalcularEquivalentes(true);

            }

        }

        private void txtHaberEquivalente_Leave(object sender, EventArgs e)
        {
            if (txtHaberEquivalente.Text != "")
            {
                bool esNUmero = false;
                double resultado = 0;

                esNUmero = double.TryParse(txtHaberEquivalente.Text.Trim(), out resultado);

                if (!esNUmero)
                {
                    Util.ShowError("No es numero");
                    return;
                }

                txtHaberEquivalente.Text = string.Format("{0:###,##0.00}", resultado);
                //CalcularEquivalentes(false);
            }
        }

        private void txtCuentaCod_Leave(object sender, EventArgs e)
        {
            if (txtCuentaCod.Text != "")
            {

                LeerFlagActivacion();
            }
        }

        private void txtAfectoRetencion_TextChanged(object sender, EventArgs e)
        {
            //modo lectura del registro detalle
            if (Estado == FormEstate.List) { return; }

            if (txtAfectoRetencion.Text.Trim().ToUpper() == "S")
            {
                txtRetencionTipTransaCod.Enabled = true;
                txtRetencionTipoDocCod.Enabled = true;
                txtRetencionNro.Enabled = true;

                txtRetencionFecha.Enabled = true;
                txtRetencionFecPago.Enabled = true;

            }
            else
            {
                //limpiar controles
                txtRetencionTipTransaCod.Text = "";
                txtRetencionTipoDocCod.Text = "";
                txtRetencionNro.Text = "";
                txtRetencionFecha.Text = "";
                txtRetencionFecPago.Text = "";

                //inhabilitar controles
                txtRetencionTipTransaCod.Enabled = false;
                txtRetencionTipoDocCod.Enabled = false;
                txtRetencionNro.Enabled = false;
                txtRetencionFecha.Enabled = false;
                txtRetencionFecPago.Enabled = false;
            }
        }

        private void txtTipoCambio_TextChanged(object sender, EventArgs e)
        {
            if (txtTipoCambio.Text != "")
            {
                double valorTipoCambio = Util.ConvertiraDecimal(txtTipoCambio.Text.Trim());
                CalcularEquivalentes(true);
            }
        }

        private void txtCuentaCorrienteCod_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void txtAfectoRetencion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnGuardar();
            }
        }

        private void txtRetencionFecPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnGuardar();
            }
        }

        private void txtFecDoc_Leave(object sender, EventArgs e)
        {
            double TipoCambio;
            Compra_Traer_TipoCambioLogic.Instance.TipoCambioTraer(txtFecDoc.Text, out TipoCambio);
            txtTipoCambio.Text = TipoCambio.ToString();
        }


    }
}
