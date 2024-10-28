using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

using Inv.BusinessEntities;
using Inv.BusinessLogic;
namespace Fac.UI.Win
{
    public partial class frmClienteDet : frmBaseReg
    {
        #region "Instancia"
        private static frmClienteDet _aForm;
        private frmcliente FrmParent { get; set; }
        public static frmClienteDet Instance(frmcliente formParent)
        {
            if (_aForm != null) return new frmClienteDet(formParent);
            _aForm = new frmClienteDet(formParent);
            return _aForm;
        }
        #endregion
        private int estadoProductxCli = 0;
        private int filaEditada = 0;
        GlobalLogic datos = GlobalLogic.Instance;
        CuentaCorrienteLogic datosCliente = CuentaCorrienteLogic.Instance;
        public frmClienteDet(frmcliente padre)
        {
            InitializeComponent();
            FrmParent = padre;
            
            txttipdoc.KeyDown += new KeyEventHandler(TextBox_KeyDown);            
            txtsituacionsunat.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            txtsituaciondomicilio.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            txtCodPais.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            txtCodDpto.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            txtCodProvincia.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            txtCodDistrito.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            TxtFormaPago.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            txtTipoClienteCod.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            txtRuc.Leave += new EventHandler(txtRuc_Leave);
            
            txtcodigo.TextChanged += new EventHandler(txtcodigo_TextChanged);
            txtLineaCreditoMonedaCod.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            txtMonedaCod.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            //rbPersonaJuridico.Click += new EventHandler(OptTipoPersona_Click);
            //rbNoDomiciliado.Click += new EventHandler(OptTipoPersona_Click);
            //rbPersonaNatural.Click += new EventHandler(OptTipoPersona_Click);
            
        }

        void txtRuc_Leave(object sender, EventArgs e)
        {
            if (txtRuc.Text != "")
            {
                txtcodigo.Text = txtRuc.Text.Trim();
            }
        }

        void txtcodigo_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Text = txtcodigo.Text.Trim();
        }

        private void ActivaDatosPorTipoPersona()
        {
         if (rbPersonaJuridico.IsChecked == true || rbNoDomiciliado.IsChecked == true)
            {
                
                txtRazonSocial.Enabled = true;
                txtApePat.Enabled = false;
                txtApeMat.Enabled = false;
                txtNombres.Enabled = false;
                //txtRazonSocial.Focus();
            }
            else if (rbPersonaNatural.IsChecked == true)
            {
                txtRazonSocial.Enabled = false;
                txtApePat.Enabled = true;
                txtApeMat.Enabled = true;
                txtNombres.Enabled = true;
                //txtApePat.Focus();  
            }
        }

        //void OptTipoPersona_Click(object sender, EventArgs e)
        //{             
        //    string nombreControl  = ((RadRadioButton)sender).Name;
        //    if (nombreControl == "rbPersonaNatural")
        //    {
        //        rbPersonaNatural.CheckState = CheckState.Checked;
        //    }
        //    else if (nombreControl == "rbPersonaJuridico")
        //    {
        //        rbPersonaJuridico.CheckState = CheckState.Checked;
        //    }
        //    else if (nombreControl == "rbNoDomiciliado")
        //    {
        //        rbNoDomiciliado.CheckState = CheckState.Checked;
        //    }
        //    ActivaDatosPorTipoPersona();           
        //}

      
        void LimpiarControles()
        {
            txtTipoAnalisis.Text = "";
            txtcodigo.Text = "";
            txtRazonSocial.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            dtpFechaRegistro.Text = "";
            txttipdoc.Text = "";
            lbltipdoc.Text = "";

            txtRuc.Text = "";
            txtFax.Text = "";
            txtCorreoElectronico.Text = "";
            TxtRubro.Text = "";
            txtAtencion.Text = "";

            TxtFormaPago.Text = "";
            lblFormaPago.Text = "";

            txtsituacionsunat.Text = "";
            lblsituacionsunat.Text = "";

            txtsituaciondomicilio.Text = "";
            lblsituaciondomicilio.Text = "";

            txtMonedaCod.Text = "";
            txtMonedaDesc.Text = "";
            //optDolares.CheckState = CheckState.Unchecked;
            //optSoles.CheckState = CheckState.Unchecked;

            optCtaCte0.CheckState = CheckState.Unchecked;
            optCtaCte1.CheckState = CheckState.Unchecked;
            optCtaCte2.CheckState = CheckState.Unchecked;

            rbPersonaNatural.CheckState = CheckState.Unchecked;
            rbPersonaJuridico.CheckState = CheckState.Unchecked;
            rbNoDomiciliado.CheckState = CheckState.Unchecked;


            txtNombres.Text = "";
            txtApePat.Text = "";
            txtApeMat.Text = "";
            txtCorreo.Text = "";

            txtCodPais.Text = "";
            lblDescPais.Text = "";

            txtCodDpto.Text = "";
            lblDescDpto.Text = "";

            txtCodProvincia.Text = "";
            lblDescProvincia.Text = "";

            txtCodDistrito.Text = "";
            lblDescDistrito.Text = "";

            txtUrbanizacion.Text = "";

            txtTipoClienteCod.Text = "";
            txtTipoClienteDesc.Text = "";

            txtLineaCreditoCondPago.Text = "";
            txtLineaCreditoImpConcedido.Text = "";
            txtLineaCreditoImpSolicitado.Text = "";
            txtLineaCreditoMonedaCod.Text = "";
            txtLineaCreditoMonedaDesc.Text = "";
            //Flag validar proveedor
            chkFlagProdCliente.Checked = false;
        }
        void InhabilitarControles()
        {
            txtTipoAnalisis.Enabled = false;
            txtcodigo.Enabled = false;
            txtRazonSocial.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            dtpFechaRegistro.Enabled = false;
            txttipdoc.Enabled = false;
            //lbltipdoc.Text = Util.GetCurrentCellText(row, "TipDocDesc");

            txtRuc.Enabled = false;
            txtFax.Enabled = false;
            txtCorreoElectronico.Enabled = false;
            TxtRubro.Enabled = false;
            txtAtencion.Enabled = false;

            TxtFormaPago.Enabled = false;
            //lblFormaPago.Text = Util.GetCurrentCellText(row, "Co02descripcion");

            txtsituacionsunat.Enabled = false;
            //lblsituacionsunat.Text = Util.GetCurrentCellText(row, "SituacionSunatDesc");

            txtsituaciondomicilio.Enabled = false;
            //lblsituaciondomicilio.Text = Util.GetCurrentCellText(row, "SituacionDomicilioDesc");

            txtMonedaCod.Enabled = false;
            txtMonedaDesc.Enabled = false;
            //optDolares.Enabled = false;
            //optSoles.Enabled = false;
            
            optCtaCte0.Enabled = false;
            optCtaCte1.Enabled = false;
            optCtaCte2.Enabled = false;
                                    
            rbPersonaNatural.Enabled = false;
            rbPersonaJuridico.Enabled = false;
            rbNoDomiciliado.Enabled = false;

            
            txtNombres.Enabled = false;
            txtApePat.Enabled = false;
            txtApeMat.Enabled = false;
            txtCorreo.Enabled = false;

            txtCodPais.Enabled = false;
            //lblDescPais.Text = Util.GetCurrentCellText(row, "PaisDescripcion");

            txtCodDpto.Enabled = false;
            //lblDescDpto.Text = Util.GetCurrentCellText(row, "DepaDescrpicion");

            txtCodProvincia.Enabled = false;
            //lblDescProvincia.Text = Util.GetCurrentCellText(row, "ProviDescripcion");

            txtCodDistrito.Enabled = false;
            //lblDescDistrito.Text = Util.GetCurrentCellText(row, "DisDescripcion");

            txtUrbanizacion.Enabled = false;

            txtTipoClienteDesc.Enabled = false;

            txtLineaCreditoCondPago.Enabled = false;
            txtLineaCreditoImpConcedido.Enabled = false;
            txtLineaCreditoImpSolicitado.Enabled = false;
            txtLineaCreditoMonedaCod.Enabled = false;
            txtLineaCreditoMonedaDesc.Enabled = false;
            txtTipoClienteCod.Enabled = false;
            chkFlagProdCliente.Enabled = false;
            habilitarBotonesProductos(false, false, false, false, false);
            
        }

        void NuevoRegistro()
        {
            LimpiarControles();
            ResaltarCajasAyuda();
            txtTipoAnalisis.Text = "01";
            rbPersonaJuridico.CheckState = CheckState.Checked;
            if (rbPersonaJuridico.IsChecked == true)
            {
                txtRazonSocial.Enabled = true;
                txtRazonSocial.Focus();
            }
            TxtFormaPago.Text = "04";
            string descripcion = "";
            GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + TxtFormaPago.Text.Trim(), "FORMAPAGO", out descripcion);
            lblFormaPago.Text = descripcion;
            
            descripcion = "";
            txtsituacionsunat.Text = "01";
            GlobalLogic.Instance.DameDescripcion("07" + txtsituacionsunat.Text.Trim(), "GLOTA", out descripcion);
            lblsituacionsunat.Text = descripcion;

            descripcion = "";
            txtsituaciondomicilio.Text = "01";
            GlobalLogic.Instance.DameDescripcion("08" + txtsituaciondomicilio.Text.Trim(), "GLOTA", out descripcion);
            lblsituaciondomicilio.Text = descripcion;

            

            chkHabilitar.CheckState = CheckState.Unchecked;
            //Inhabilitar todo los botones del mantenimiento de producto en modo nuevo registro
            habilitarBotonesProductos(false, false, false, false, false);
        }
        void VerBotonesCabPorEstado(FormEstate parEstado)
        {
            OcultarBotones();
            if (parEstado == FormEstate.New)
            {                
                HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            }
            else if (parEstado == FormEstate.Edit)
            {
                HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            }
            else if (parEstado == FormEstate.View)
            {                                
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);                
                HabilitaBotonPorNombre(BaseRegBotones.cbbNavegacion);
            }
        }
        private void ResaltarCajasAyuda()
        {             
            Util.ResaltarAyuda(txttipdoc);
            Util.ResaltarAyuda(txtTipoClienteCod);
            Util.ResaltarAyuda(txtCodPais);
            Util.ResaltarAyuda(txtCodProvincia);
            Util.ResaltarAyuda(txtCodDpto);
            Util.ResaltarAyuda(txtCodDistrito);
            Util.ResaltarAyuda(TxtFormaPago);
            Util.ResaltarAyuda(txtMonedaCod);
            Util.ResaltarAyuda(txtsituacionsunat);
            Util.ResaltarAyuda(txtsituaciondomicilio);
            Util.ResaltarAyuda(txtLineaCreditoMonedaCod);
        }
        void EditarRegistro()
        {
            LimpiarControles();
            ResaltarCajasAyuda();
            txtTipoAnalisis.Enabled = false;
            txtcodigo.Enabled = false;
            LeerRegistro();
            // Si razon social tiene valor 
            /*
             * 2 optTipoPersona2 persona juridica
             * 1 optTipoPersona2 persona natural
             * 3 optTipoPersona3 sujeto no domiciliado
             */
            txtNombres.Enabled = false;
            txtApePat.Enabled = false; txtApeMat.Enabled = false;

            txtRazonSocial.Enabled = false;
            if (rbPersonaJuridico.CheckState == CheckState.Checked)
            { 
                
                txtRazonSocial.Enabled = true;
            }
            else if (rbPersonaNatural.CheckState == CheckState.Checked)
            {
                txtNombres.Enabled = true;
                txtApePat.Enabled = true; txtApeMat.Enabled = true; 
            }
            else if (rbNoDomiciliado.CheckState == CheckState.Checked)
            {
                txtRazonSocial.Enabled = true;
            }
            habilitarBotonesProductos(false, false, true, true, true);
        }
        
        void VerRegistro()
        {
            LimpiarControles();
            txtTipoAnalisis.Enabled = false;
            txtcodigo.Enabled = false;
            LeerRegistro();
            InhabilitarControles();

        }

        void LeerRegistro()
        {
            GridViewRowInfo row = FrmParent.gridControl.CurrentRow;
            txtTipoAnalisis.Text =  Util.GetCurrentCellText(row, "ccm02tipana");
            txtcodigo.Text = Util.GetCurrentCellText(row, "ccm02cod");
            txtRazonSocial.Text = Util.GetCurrentCellText(row, "ccm02nom");
            txtDireccion.Text = Util.GetCurrentCellText(row, "ccm02dir");
            txtTelefono.Text = Util.GetCurrentCellText(row, "ccm02tel");
            dtpFechaRegistro.Text = Util.GetCurrentCellText(row, "ccm02fec");
            txttipdoc.Text = Util.GetCurrentCellText(row, "ccm02tipdocidentidad");
            lbltipdoc.Text = Util.GetCurrentCellText(row, "TipDocDesc");
            
            txtRuc.Text = Util.GetCurrentCellText(row, "ccm02ruc");
            txtFax.Text = Util.GetCurrentCellText(row, "ccm02Fax");
            txtCorreoElectronico.Text = Util.GetCurrentCellText(row, "ccm02correo");
            TxtRubro.Text = Util.GetCurrentCellText(row, "ccm02rubpro");
            txtAtencion.Text = Util.GetCurrentCellText(row, "ccm02Aten");
            
            TxtFormaPago.Text = Util.GetCurrentCellText(row, "ccm02ForPag");
            lblFormaPago.Text = Util.GetCurrentCellText(row, "Co02descripcion");

            txtsituacionsunat.Text = Util.GetCurrentCellText(row,"ccm02EstadoContribuyente");
            lblsituacionsunat.Text = Util.GetCurrentCellText(row, "SituacionSunatDesc");

            txtsituaciondomicilio.Text = Util.GetCurrentCellText(row, "ccm02SituacionDomicilio");
            lblsituaciondomicilio.Text = Util.GetCurrentCellText(row, "SituacionDomicilioDesc");


            txtMonedaCod.Text = Util.GetCurrentCellText(row, "ccm02Moneda");
            string descripcionMoneda = "";
            GlobalLogic.Instance.DameDescripcionFA(txtMonedaCod.Text,
                                               "MONEDAFAC", out descripcionMoneda);
            txtMonedaDesc.Text = descripcionMoneda;

            //string str_Moneda = Util.GetCurrentCellText(row, "ccm02Moneda");
            //optDolares.CheckState = CheckState.Unchecked;
            //optSoles.CheckState = CheckState.Unchecked;

            //if (str_Moneda == "S")
            //{
            //    optSoles.CheckState = CheckState.Checked;
            //}
            //else if (str_Moneda == "D")
            //{
            //    optDolares.CheckState = CheckState.Checked;
            //}

            string str_TipoAgente = Util.GetCurrentCellText(row, "ccm02TipoAgenteRetencion");
            optCtaCte0.CheckState = CheckState.Unchecked;
            optCtaCte1.CheckState = CheckState.Unchecked;
            optCtaCte2.CheckState = CheckState.Unchecked;

            optCtaCte0.CheckState = str_TipoAgente == "0" ? CheckState.Checked : CheckState.Unchecked;
            optCtaCte1.CheckState = str_TipoAgente == "1" ? CheckState.Checked : CheckState.Unchecked;
            optCtaCte2.CheckState = str_TipoAgente == "2" ? CheckState.Checked : CheckState.Unchecked;
            

            string str_TipoRuc = Util.GetCurrentCellText(row, "ccm02TipoRuc");
            
            rbPersonaNatural.CheckState = CheckState.Unchecked;
            rbPersonaJuridico.CheckState = CheckState.Unchecked;
            rbNoDomiciliado.CheckState = CheckState.Unchecked;

            rbPersonaNatural.CheckState = str_TipoRuc == "1" ? CheckState.Checked : CheckState.Unchecked;
            rbPersonaJuridico.CheckState = str_TipoRuc == "2" ? CheckState.Checked : CheckState.Unchecked;
            rbNoDomiciliado.CheckState = str_TipoRuc == "3" ? CheckState.Checked : CheckState.Unchecked;

            txtNombres.Text = Util.GetCurrentCellText(row, "ccm02Nombres");
            txtApePat.Text = Util.GetCurrentCellText(row, "ccm02ApePaterno");
            txtApeMat.Text = Util.GetCurrentCellText(row, "ccm02ApeMaterno");
            txtCorreo.Text = Util.GetCurrentCellText(row, "ccm02CorreoFacturaElectronica");

            txtCodPais.Text = Util.GetCurrentCellText(row, "ccm02FEPaisCod");
            lblDescPais.Text = Util.GetCurrentCellText(row, "PaisDescripcion");

            txtCodDpto.Text = Util.GetCurrentCellText(row, "ccm02FEDepartamentoCod");
            lblDescDpto.Text = Util.GetCurrentCellText(row, "DepaDescrpicion");

            txtCodProvincia.Text = Util.GetCurrentCellText(row, "ccm02FEProvinciaCod");
            lblDescProvincia.Text = Util.GetCurrentCellText(row, "ProviDescripcion");

            txtCodDistrito.Text = Util.GetCurrentCellText(row, "ccm02FEDistritoCod");
            lblDescDistrito.Text = Util.GetCurrentCellText(row, "DisDescripcion");

            txtUrbanizacion.Text = Util.GetCurrentCellText(row, "ccm02FEUrbanizacion");

            txtTipoClienteCod.Text =  Util.GetCurrentCellText(row, "CCM02TIPOCLIENTECOD");
            txtTipoClienteDesc.Text = Util.GetCurrentCellText(row, "CCM02TIPOCLIENTEDESC");

            txtLineaCreditoMonedaCod.Text = Util.GetCurrentCellText(row, "ccm02LineaCreditoMoneda");

            string lineaCreditoDescripcionMoneda = "";
            GlobalLogic.Instance.DameDescripcionFA(txtLineaCreditoMonedaCod.Text,
                                               "MONEDAFAC", out lineaCreditoDescripcionMoneda);
            txtLineaCreditoMonedaDesc.Text = lineaCreditoDescripcionMoneda;

            string condicionPago  = "";
            condicionPago = Util.GetCurrentCellText(row, "ccm02LineaCreditoCondicionPago");
             txtLineaCreditoCondPago.Text  = condicionPago == "0" ? "": condicionPago;
            
             string importeConcendido = "";
             importeConcendido = Util.GetCurrentCellText(row, "ccm02LineaCreditoImporteConcedido");
             txtLineaCreditoImpConcedido.Text = importeConcendido == "0" ? "" : importeConcendido;

             string importeSolicitado = "";
             importeSolicitado = Util.GetCurrentCellText(row, "ccm02LineaCreditoImporteSolicitado");
             txtLineaCreditoImpSolicitado.Text = importeSolicitado == "0" ? "" : importeSolicitado;
             
            string flagDescripcionCliente = "";
            flagDescripcionCliente = Util.GetCurrentCellText(row, "ccm02FlagDescripcionCliente");
            chkFlagProdCliente.Checked = flagDescripcionCliente == "1" ? true : false;
            
            
        }
        

        void FocusNextControl(string pNombreControl)
        {
            switch (pNombreControl)
            {
                case "txtTipoAnalisis":
                    txtcodigo.Focus();
                    break;
                case "txtcodigo":
                    txttipdoc.Focus();
                    break;
                case "txttipdoc":
                    txtRuc.Focus();
                    break;
                case "txtRuc":
                    TxtFormaPago.Focus();
                    break;
                case "TxtFormaPago":
                    // Validar si esta marcado Persona Juridica
                    if (rbPersonaJuridico.IsChecked == true)
                        txtRazonSocial.Focus();
                     else if (rbPersonaNatural.IsChecked == true)
                        txtApePat.Focus();
                    
                    break;
                case "txtNombre":
                    txtDireccion.Focus();
                    break;
                case "txtApePat":
                    txtApeMat.Focus();
                    break;
                case "txtApeMat":
                    txtNombres.Focus();
                    break;
                case "txtNom":
                    txtDireccion.Focus();
                    break;
                case "txtDireccion":
                    txtAtencion.Focus();
                    break;
                case "txtTelefono":
                    txtFax.Focus();
                    break;
                case "txtFax":
                    TxtRubro.Focus();
                    break;
                case "txtAtencion":
                    txtCorreoElectronico.Focus();
                    break;
                case "txtCorreoElectronico":
                    txtTelefono.Focus();
                    break;
                case "TxtRubro":
                    txtsituacionsunat.Focus();
                    break;
                case "txtsituacionsunat":
                    txtsituaciondomicilio.Focus();
                    break;
                case "txtsituaciondomicilio":
                    txtCodPais.Focus();
                    break;
                case "txtCodPais":
                    txtCodDpto.Focus();
                    break;
                case "txtCodDpto":
                    txtCodProvincia.Focus();
                    break;
                case "txtCodProvincia":
                    txtCodDistrito.Focus();
                    break;
                case "txtCodDistrito":
                    txtUrbanizacion.Focus();
                    break;
                case "txtUrbanizacion":
                    txtCorreo.Focus();
                    break;
                case "txtCorreo":
                    break;
                default: break;
            } 
        }
        
        string[] TraerRespuestaDeAyuda(enmAyuda TipoBusqueda, object parametro1)
        {
            string[] datos = null;
            frmBusqueda frm = new frmBusqueda(TipoBusqueda, parametro1);
            frm.ShowDialog();
            if (frm.Result != null)
            {
                if (frm.Result.ToString() != "")
                {
                    datos = frm.Result.ToString().Split('|');
                }
            }
            return datos;                                            
        }
        void TraerAyuda(string  pNombreControl)
        {
            string[] datos;
            switch (pNombreControl)
            { 
                case "txttipdoc":
                    datos = TraerRespuestaDeAyuda(enmAyuda.enmCliente_TipoDoc, "");
                    if (datos == null) return;
                    txttipdoc.Text = datos[0];
                    lbltipdoc.Text = datos[1];
                    break;

                case "txtsituacionsunat":
                    datos = TraerRespuestaDeAyuda(enmAyuda.enmCliente_SituacionSunat, "");
                    if (datos == null) return;
                    txtsituacionsunat.Text = datos[0];
                    lblsituacionsunat.Text = datos[1];                    
                    break;

                case "txtsituaciondomicilio":
                    datos = TraerRespuestaDeAyuda(enmAyuda.enmCliente_SituacionDomi, "");
                    if (datos == null) return;
                    txtsituaciondomicilio.Text = datos[0];
                    lblsituaciondomicilio.Text = datos[1];                      
                    break;

                case "txtCodPais":
                    datos = TraerRespuestaDeAyuda(enmAyuda.enmCliente_Pais,"");
                    if (datos == null) return;
                    txtCodPais.Text = datos[0];
                    lblDescPais.Text = datos[1];                    
                    break;
                case "txtCodDpto":                    
                    datos = TraerRespuestaDeAyuda(enmAyuda.enmCliente_Dpto, "");
                    if (datos == null) return;
                    txtCodDpto.Text = datos[0];
                    lblDescDpto.Text = datos[1];
                    break;
                case "txtCodProvincia":
                    if (txtCodDpto.Text.Trim() == "") { Util.ShowAlert("Seleccionar Departamento"); return; }
                    datos = TraerRespuestaDeAyuda(enmAyuda.enmCliente_Prov, txtCodDpto.Text.Trim());
                    if (datos == null) return;
                    txtCodProvincia.Text = datos[0];
                    lblDescProvincia.Text = datos[1];
                    break;
                case "txtCodDistrito":
                    if (txtCodProvincia.Text.Trim() == "") { Util.ShowAlert("Seleccionar Provincia"); return; }
                    datos = TraerRespuestaDeAyuda(enmAyuda.enmCliente_Dist, txtCodDpto.Text.Trim() + "|"+ txtCodProvincia.Text.Trim());
                    if (datos == null) return;
                    txtCodDistrito.Text = datos[0];
                    lblDescDistrito.Text = datos[1];
                    break;
                case "TxtFormaPago":
                    datos = TraerRespuestaDeAyuda(enmAyuda.enmCliente_FormaPago, "");
                    if (datos == null) return;
                    TxtFormaPago.Text = datos[0];
                    lblFormaPago.Text = datos[1];
                    break;
                case "txtTipoClienteCod":
                    datos = TraerRespuestaDeAyuda(enmAyuda.enmCliente_TipoCliente, "");
                    if(datos == null) return;
                    txtTipoClienteCod.Text = datos[0];
                    txtTipoClienteDesc.Text = datos[1];
                    break;
                case "txtLineaCreditoMonedaCod":
                    datos = TraerRespuestaDeAyuda(enmAyuda.enmFactCab_Moneda, "");
                    if (datos == null) return;
                    txtLineaCreditoMonedaCod.Text = datos[0];
                    txtLineaCreditoMonedaDesc.Text = datos[1];
                    break;
                case "txtMonedaCod":
                    datos = TraerRespuestaDeAyuda(enmAyuda.enmFactCab_Moneda, "");
                    if (datos == null) return;
                    txtMonedaCod.Text = datos[0];
                    txtMonedaDesc.Text = datos[1];
                    break;
                default: 
                    break;
            }
        }
        void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(((RadTextBox)sender).Name);
            }
            
        }
        protected override void OnAnterior()
        {
            int int_indice = FrmParent.gridControl.MasterView.CurrentRow.Index - 1;
            if (int_indice < 0)
            {
                return;
            }
            FrmParent.gridControl.CurrentRow = FrmParent.gridControl.MasterView.Rows[int_indice];
            LeerRegistro();
        }
        protected override void OnSiguiente()
        {
            int int_indice = FrmParent.gridControl.MasterView.CurrentRow.Index + 1;
            if (int_indice > FrmParent.gridControl.MasterView.Rows.Count - 1)
            { return; }
            FrmParent.gridControl.CurrentRow = FrmParent.gridControl.MasterView.Rows[int_indice];
            LeerRegistro();
        }
        protected override void OnPrimero()
        {
            int int_indice = 0;
            FrmParent.gridControl.CurrentRow = FrmParent.gridControl.MasterView.Rows[int_indice];
            LeerRegistro();
        }
        protected override void OnUltimo()
        {
            int int_indice = FrmParent.gridControl.MasterView.Rows.Count - 1;
            FrmParent.gridControl.CurrentRow = FrmParent.gridControl.MasterView.Rows[int_indice];
            LeerRegistro();
        }
        private bool Validar()
        {

            if (txtcodigo.Text.Trim() == "")
            {
                txtcodigo.Focus();
                return false;
            }

            if (rbPersonaJuridico.CheckState == CheckState.Checked || rbNoDomiciliado.CheckState == CheckState.Checked)
            {
                if (txtRazonSocial.Text.Trim() == "")
                {
                    Util.ShowAlert("Ingresar nombre de cuenta corriente");
                    txtRazonSocial.Focus();
                    return false;
                }

            } else if(rbPersonaNatural.CheckState == CheckState.Checked) {
                if (txtApePat.Text.Trim() == "")
                {
                    Util.ShowAlert("Ingresar Apellido Paterno de cuenta corriente");
                    txtApePat.Focus();
                    return false;
                }
                if (txtApeMat.Text.Trim() == "")
                {
                    Util.ShowAlert("Ingresar Apellido Materno de cuenta corriente");
                    txtApeMat.Focus();
                    return false;
                }
                if (txtNombres.Text.Trim() == "")
                {
                    Util.ShowAlert("Ingresar nombre de cuenta corriente");
                    txtNombres.Focus();
                    return false;
                }
                txtRazonSocial.Text = txtApePat.Text.Trim() + " " + 
                                  txtApeMat.Text.Trim() + " " + 
                                  txtNombres.Text.Trim();
            }
            if (lbltipdoc.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar tipo de documento");
                txttipdoc.Focus();
                return false;
            }
            if (lblFormaPago.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar forma de pago");
                TxtFormaPago.Focus();
                return false;
            }
            
            if(lblsituacionsunat.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar situacion Sunat");
                txtsituacionsunat.Focus();
                return false;
            }

            if(lblsituaciondomicilio.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar situacion domicilio Sunat");
                txtsituaciondomicilio.Focus();
                return false;
            }

            long resultado = 0;
            
            if (long.TryParse(txtRuc.Text, out resultado) == false)
            {
                Util.ShowAlert("El codigo debe ser numerico");
                txtcodigo.Focus();
                return false;
            }
            return true;
        }

        protected override void OnGuardar()
        {
            try
            {

                if (Validar() == false) return;
                if (txtCodPais.Text.Trim() == "")
                {
                    Util.ShowAlert("Debe elegir pais");
                    return;
                }

                CuentaCorriente cuenta = new CuentaCorriente();
                
                cuenta.ccm02emp = Logueo.CodigoEmpresa;
                cuenta.ccm02tipana  = txtTipoAnalisis.Text.Trim();
                cuenta.ccm02cod = txtcodigo.Text.Trim();
                cuenta.ccm02nom = txtRazonSocial.Text.Trim();
                cuenta.ccm02dir  = txtDireccion.Text.Trim();
                cuenta.ccm02tel  = txtTelefono.Text.Trim();
                cuenta.ccm02fec = dtpFechaRegistro.Value;
                cuenta.ccm02ruc = txtRuc.Text.Trim();
                cuenta.ccm02fax = txtFax.Text.Trim();
                cuenta.ccm02rubpro = TxtRubro.Text.Trim();
                cuenta.ccm02Aten = txtAtencion.Text.Trim();
                
                //if(optDolares.CheckState == CheckState.Checked)
                //{
                //    cuenta.ccm02moneda = "D";
                //}else if(optSoles.CheckState == CheckState.Checked)
                //{
                //    cuenta.ccm02moneda = "S";
                //}

                cuenta.ccm02moneda = txtMonedaCod.Text.Trim();

                cuenta.Ccm02Forpag = TxtFormaPago.Text.Trim();
                cuenta.ccm02activo = (chkHabilitar.CheckState == CheckState.Checked) ? "S" : "N";
                cuenta.ccm02correo = txtCorreoElectronico.Text.Trim();

                if(optCtaCte0.CheckState == CheckState.Checked)
                {
                    cuenta.ccm02TipoAgenteRetencion =  "0";    
                }else if(optCtaCte1.CheckState == CheckState.Checked)
                {
                    cuenta.ccm02TipoAgenteRetencion =  "1";    
                }else if(optCtaCte2.CheckState == CheckState.Checked)
                {
                    cuenta.ccm02TipoAgenteRetencion =  "2";    
                }
                if(rbPersonaNatural.CheckState == CheckState.Checked)
                {
                    cuenta.ccm02TipoRuc = "1";    
                }else if(rbPersonaJuridico.CheckState == CheckState.Checked)
                {
                    cuenta.ccm02TipoRuc = "2";
                }else if(rbNoDomiciliado.CheckState == CheckState.Checked)
                {
                    cuenta.ccm02TipoRuc = "3";    
                }
            
                cuenta.ccm02ApePaterno = txtApePat.Text.Trim();
                cuenta.ccm02ApeMaterno = txtApeMat.Text.Trim();
                cuenta.ccm02Nombres = txtNombres.Text.Trim();
                cuenta.ccm02EstadoContribuyente = txtsituacionsunat.Text.Trim(); 
                cuenta.ccm02SituacionDomicilio = txtsituaciondomicilio.Text.Trim();

                cuenta.ccm02nroctadetraccion = txtctabancodetraccion.Text;
                cuenta.ccm02tipdocidentidad = Util.Right(txttipdoc.Text.Trim(), 1);
                
                cuenta.ccm02CorreoFacturaElectronica = txtCorreo.Text.Trim(); // correo para sunat
                cuenta.ccm02FEPaisCod = txtCodPais.Text.Trim();
           
                cuenta.ccm02FEDepartamentoCod = txtCodDpto.Text.Trim();
                cuenta.ccm02FEProvinciaCod = txtCodProvincia.Text.Trim();
                cuenta.ccm02FEDistritoCod = txtCodDistrito.Text.Trim();
                cuenta.ccm02FEUrbanizacion = txtUrbanizacion.Text.Trim();

                cuenta.CCM02TIPOCLIENTECOD = txtTipoClienteCod.Text.Trim();
                
                cuenta.ccm02LineaCreditoMoneda = txtLineaCreditoMonedaCod.Text.Trim();
                cuenta.ccm02LineaCreditoImporteSolicitado = txtLineaCreditoImpSolicitado.Text == "" ? 0 : Convert.ToDouble(txtLineaCreditoImpSolicitado.Text.Trim());
                cuenta.ccm02LineaCreditoImporteConcedido = txtLineaCreditoImpConcedido.Text == "" ? 0 : Convert.ToDouble(txtLineaCreditoImpConcedido.Text.Trim());
                cuenta.ccm02LineaCreditoCondicionPago = txtLineaCreditoCondPago.Text == "" ? 0 : Convert.ToInt32(txtLineaCreditoCondPago.Text.Trim());
                
                //Si el check esta marcado  "Si valido el codigo de proveedor"               
                cuenta.ccm02FlagDescripcionCliente = chkFlagProdCliente.Checked == true ? "1": "0";
                int int_flag = 0;
                string str_mensaje = "";

                if (FrmParent.Estado == FormEstate.New)
                {
                    datosCliente.InsertarCliente(cuenta, out int_flag, out str_mensaje);
                }
                else if (FrmParent.Estado == FormEstate.Edit)
                {
                    datosCliente.ActualizarCliente(cuenta, out int_flag, out str_mensaje);
                }


                if (int_flag == 1)
                {
                    // Ver mensaje de registro actualizado
                    Util.ShowMessage(str_mensaje, int_flag);
                    FrmParent.Estado = FormEstate.Edit;
                    FrmParent.Cargar();
                    txtcodigo.Enabled = false;
                    txtTipoAnalisis.Enabled = false;
                }
                else {
                    Util.ShowMessage(str_mensaje, int_flag);
                }                                    
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar detalle de cliente: " + ex.Message);
            }
        }
        protected override void OnCancelar()
        {
            this.Close();
        }


        private void frmClienteDet_Load(object sender, EventArgs e)
        {
            try
            {
                txtLineaCreditoImpSolicitado.MaskType = MaskType.Numeric;
                txtLineaCreditoImpSolicitado.Mask = "N";
                txtLineaCreditoImpConcedido.MaskType = MaskType.Numeric;
                txtLineaCreditoImpConcedido.Mask = "N";



                if (FrmParent.Estado == FormEstate.New)
                {
                    NuevoRegistro();

                }
                else if (FrmParent.Estado == FormEstate.Edit)
                {
                    EditarRegistro();
                }
                else if (FrmParent.Estado == FormEstate.View)
                {
                    VerRegistro();
                }

                VerBotonesCabPorEstado(FrmParent.Estado);

                //Configuracion de producto por cliente
                Util.ConfigGridToEnterNavigation(GridProductosxCliente);
                CrearColumnasProductos();
                //habilitarBotonesProductos(false, false, true, true, true);
                OnBuscarProductosxCliente();

                //enfocar primer control del formulario
                txtcodigo.Focus();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }


        private void IniciarOrdenControles()
        {
            CrearColumnasProductos();
            txtTipoAnalisis.TabStop = false;

            txtcodigo.TabStop = false;
            txttipdoc.TabStop = false;
            txtRuc.TabStop = false;
            txtRazonSocial.TabStop = false;

            txtApePat.TabStop = false;
            txtApeMat.TabStop = false;
            txtNombres.TabStop = false;

            txtDireccion.TabStop = false;

            txtCodPais.TabStop = false;
            txtCodDpto.TabStop = false;
            txtCodProvincia.TabStop = false;
            txtCodDistrito.TabStop = false;
            txtUrbanizacion.TabStop = false;
            txtCorreo.TabStop = false;

            radGroupBox1.TabStop = false;
            

            TxtFormaPago.TabStop = false;

            txtTelefono.TabStop = false;
            txtCorreoElectronico.TabStop = false;
            TxtRubro.TabStop = false;
            txtAtencion.TabStop = false;

            txtTipoClienteCod.TabStop = false;

            txtsituacionsunat.TabStop = false;
            txtsituaciondomicilio.TabStop = false;

    
            
            //txtimportesolicitado.AllowPromptAsInput = false;
            
            
            habilitarBotonesProductos(false, false, true, true, true);
        }
        
        #region "eventos de controles"
   
       
        private void txtsituaciondomicilio_KeyUp(object sender, KeyEventArgs e)
        {
            OnGuardar();
        }
        #endregion


        #region "Productos por cliente"
        private void OnBuscarProductosxCliente()
        {
            try
            {
                string codigoCliente = "";
                codigoCliente = txtcodigo.Text.Trim();
                List<ArticuloCliente> lista = ArticuloClienteLogic.Instance.TraerArticuloCliente(Logueo.CodigoEmpresa,
                codigoCliente);

                this.GridProductosxCliente.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer productos por cliente: " + ex.Message);
            }
        }
        private void CrearColumnasProductos()
        {
            RadGridView grillaProducxClie = this.CreateGridVista(this.GridProductosxCliente);

            this.CreateGridColumn(grillaProducxClie, "Codigo", "In20Codigo", 0, "", 100, false, true, true); // 0
            this.CreateGridColumn(grillaProducxClie, "Descripcion", "In20Descripcion", 0, "", 500, false, true, true); // 1
            this.CreateGridColumn(grillaProducxClie, "Familia", "In20Familia", 0, "", 90, false, true, true); // 2
            this.CreateGridColumn(grillaProducxClie, "Unidad", "In20UndMed", 0, "", 90, false, true, true); // 3
            this.CreateGridColumn(grillaProducxClie, "Formato", "In20Formato", 0, "", 90, false, true, true); // 4
            this.CreateGridColumn(grillaProducxClie, "Color", "In20Color", 0, "", 90, false, true, true); // 5
            this.CreateGridColumn(grillaProducxClie, "Pulido", "In20Pulido", 0, "", 90, false, true, true); // 6
            this.CreateGridColumn(grillaProducxClie, "Relleno", "In20Relleno", 0, "", 90, false, true, true);// 7
            this.CreateGridColumn(grillaProducxClie, "Comentario", "In20Comentario", 0, "", 90, false, true, true); // 8

            this.CreateGridColumn(grillaProducxClie, "Especial", "In20Especial", 0, "", 90, false, true, true); // 9
            this.CreateGridColumn(grillaProducxClie, "Especial1", "In20Especial1", 0, "", 90, false, true, true); // 10
            this.CreateGridColumn(grillaProducxClie, "Unidad por caja", "In20UndxCaja", 0, "{0:###,###0.00}", 70, false, true, true, true); // 11
            this.CreateGridColumn(grillaProducxClie, "Piezas por caja", "In20PiezasxCaja", 0, "", 70, false, true, true, false); // 12
            this.CreateGridColumn(grillaProducxClie, "Estado", "In20estado", 0, "", 90, false, false, false); // 13
            this.CreateGridColumn(grillaProducxClie, "Codigo Propio", "In20CodigoPropio", 0, "", 90, false, true, false); // 14
            this.CreateGridColumn(grillaProducxClie, "EsEditable", "EsEditable", 0, "", 50, false, false, false, false); // 15
            grillaProducxClie.AllowEditRow = false;
        }
        private bool ValidarProducto()
        {
            GridViewRowInfo fila = GridProductosxCliente.CurrentRow;
            if (txtcodigo.Text == "")
            {
                //RadMessageBox.Show("Ingresar codigo de cliente", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                Util.ShowAlert("Ingresar codigo de cliente");
                return false;
            }
            if (Util.GetCurrentCellText(fila, "In20Codigo") == "" || Util.GetCurrentCellText(fila, "In20Descripcion") == ""
                || Util.GetCurrentCellText(fila, "In20UndxCaja") == "" || Util.GetCurrentCellText(fila, "In20PiezasxCaja") == "")
            {
                Util.ShowAlert("Completar registro");
                return false;
            }

            return true;
        }
        object retornarValor(int posicion)
        {
            return this.GridProductosxCliente.CurrentRow.Cells[posicion].Value;
        }
        private void grabarProducto()
        {
            ArticuloCliente entidad = new ArticuloCliente();
            try
            {
                if (!ValidarProducto())
                    return;
                string mmiMensaje = string.Empty;
                int flag = 0;
                GridViewRowInfo fila = GridProductosxCliente.CurrentRow;
                entidad.In20codemp = Logueo.CodigoEmpresa;

                entidad.In20clientecod = txtcodigo.Text.Trim();


                entidad.In20Codigo = Util.GetCurrentCellText(fila, "In20Codigo");
                entidad.In20Descripcion = Util.GetCurrentCellText(fila, "In20Descripcion");
                entidad.In20Familia = Util.GetCurrentCellText(fila, "In20Familia");
                entidad.In20UndMed = Util.GetCurrentCellText(fila, "In20UndMed");
                entidad.In20Formato = Util.GetCurrentCellText(fila, "In20Formato");
                entidad.In20Color = Util.GetCurrentCellText(fila, "In20Color");
                entidad.In20Pulido = Util.GetCurrentCellText(fila, "In20Pulido");
                entidad.In20Relleno = Util.GetCurrentCellText(fila, "In20Relleno");
                entidad.In20Comentario = Util.GetCurrentCellText(fila, "In20Comentario");
                entidad.In20Especial = Util.GetCurrentCellText(fila, "In20Especial");
                entidad.In20Especial1 = Util.GetCurrentCellText(fila, "In20Especial1");
                entidad.In20UndxCaja = Util.GetCurrentCellDbl(fila, "In20UndxCaja");
                entidad.In20PiezasxCaja = Util.GetCurrentCellInt(fila, "In20PiezasxCaja");
                entidad.In20estado = Util.GetCurrentCellText(fila, "In20estado"); // trae el valor del estado del producto de cliente
                entidad.In20CodigoPropio = "";
                if (estadoProductxCli == 1) // flag de inserta
                {

                    entidad.In20estado = "A";
                    ArticuloClienteLogic.Instance.InsertarArticuloCliente(entidad,out mmiMensaje);

                    Util.ShowMessage(mmiMensaje, flag);

                    if (flag == 0)
                    {
                        OnBuscarProductosxCliente();
                        Util.enfocarFila(GridProductosxCliente, "In20Codigo", entidad.In20Codigo);
                    }
                }
                else if (estadoProductxCli == 2)//flag de actualiza
                {
                    ArticuloClienteLogic.Instance.ActualizarArticuloCliente(entidad,out mmiMensaje);

                    Util.ShowMessage(mmiMensaje, flag);

                    if (flag == 0)
                    {
                        OnBuscarProductosxCliente();
                        Util.enfocarFila(GridProductosxCliente, "In20Codigo", entidad.In20Codigo);
                    }
                }

                estadoProductxCli = 0;
                habilitarBotonesProductos(false, false, true, true, true);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al grabar producto : " + ex.Message);
                estadoProductxCli = 0;
            }

        }
        private void agregarProducto()
        {

            //validar para evitar inserta mas de un row en blanco y sin guardar.
            try
            {
                if (GridProductosxCliente.Rows.Count > 0)
                {
                    if (!ValidarProducto()) return;
                }
                this.GridProductosxCliente.AllowEditRow = true;
                this.GridProductosxCliente.ReadOnly = false;

                GridViewRowInfo row = this.GridProductosxCliente.Rows.AddNew();
                estadoProductxCli = 1; //flag de estaod nuevo producto x cliente

                Util.SetCellInitEdit(row, "In20Codigo");
                Util.SetValueCurrentCellText(row, "EsEditable", "0");
                Util.SetValueCurrentCellText(row, "In20estado", "A");

                filaEditada = this.GridProductosxCliente.CurrentRow.Index;
                habilitarBotonesProductos(true, true, false, false, false);
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
            //estado cero para nuevo registro
        }
        private void eliminarProducto()
        {
            if (this.GridProductosxCliente.RowCount == 0)
                return;
            try
            {
                ArticuloCliente entidad = new ArticuloCliente();

                entidad.In20codemp = Logueo.CodigoEmpresa;
                entidad.In20clientecod = txtcodigo.Text;
                entidad.In20Codigo = Util.GetCurrentCellText(GridProductosxCliente.CurrentRow, "In20Codigo");
                entidad.In20CodigoPropio = Util.GetCurrentCellText(GridProductosxCliente.CurrentRow, "In20CodigoPropio");

                string mimensaje = string.Empty;
                int flag = 1;
                bool respuesta = Util.ShowQuestion("¿Estado seguro de eliminar el registro?)");

                if (respuesta == true)
                {
                    ArticuloClienteLogic.Instance.EliminarArticuloCliente(entidad,out mimensaje);

                    Util.ShowMessage(mimensaje, flag);

                }


                cancelarProducto();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar : " + ex.Message);
            }
            //protegerRegistro();
        }
        private void editarProducto()
        {
            try
            {
                if (GridProductosxCliente.Rows.Count == 0) return;

                this.GridProductosxCliente.AllowEditRow = true;
                this.GridProductosxCliente.ReadOnly = false;

                estadoProductxCli = 2; // flag de edicion del producto                

                var fila = GridProductosxCliente.CurrentRow;

                //this.GridProductosxCliente.CurrentRow.Cells["In20Descripcion"].BeginEdit();
                Util.SetCellInitEdit(fila, "In20Descripcion");
                Util.SetValueCurrentCellText(fila, "EsEditable", "0");
                filaEditada = fila.Index;

                //metodos de botones de producto x cliente en modo ediciobn
                habilitarBotonesProductos(true, true, false, false, false);
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        private void cancelarProducto()
        {

            //flag del estado de mantenimiento - listado
            estadoProductxCli = 0;
            OnBuscarProductosxCliente();
            this.GridProductosxCliente.ReadOnly = true;
            this.GridProductosxCliente.AllowEditRow = false;

            //metodos de botones de producto x cliente en modo cancelar
            habilitarBotonesProductos(false, false, true, true, true);
        }

        private void habilitarBotonesProductos(bool bSave, bool bCancel, bool bAdd, bool bDel, bool bUpd)
        {
            cmdSaveProductos.Enabled = bSave;
            cmdCancelProductos.Enabled = bCancel;
            cmdAddProducts.Enabled = bAdd;
            cmdDelProducts.Enabled = bDel;
            cmdUpdateProducts.Enabled = bUpd;

        }
        #endregion



        private void cmdAddProducts_Click(object sender, EventArgs e)
        {
            agregarProducto();
        }

        private void cmdUpdateProducts_Click(object sender, EventArgs e)
        {
            editarProducto();
        }

        private void cmdDelProducts_Click(object sender, EventArgs e)
        {
            eliminarProducto();
        }

        private void cmdSaveProductos_Click(object sender, EventArgs e)
        {
            grabarProducto();
        }

        private void cmdCancelProductos_Click(object sender, EventArgs e)
        {
            cancelarProducto();
        }

        private void GridProductosxCliente_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            try
            {
                if (Util.GetCurrentCellText(GridProductosxCliente, "EsEditable") == "")
                {
                    e.Cancel = true;
                }             
            }
            catch (Exception ex)
            {

            }
        }

        private void GridProductosxCliente_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //estadoProductxCli  = 0  es listado de producto
                if (estadoProductxCli == 1 || estadoProductxCli == 2) // si la grilla esta en nuevo o edito
                {
                    //bloque el cambio de selecciona de fila.
                    GridProductosxCliente.Rows[filaEditada].IsCurrent = true;
                    GridProductosxCliente.Rows[filaEditada].IsSelected = true;
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cambiar seleccion de filka: " + ex.Message);
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblFormaPago_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttipdoc_TextChanged(object sender, EventArgs e)
        {
            rbNoDomiciliado.CheckState = CheckState.Unchecked;
            rbPersonaJuridico.CheckState = CheckState.Unchecked;
            rbPersonaNatural.CheckState = CheckState.Unchecked;

            if (txttipdoc.Text.Trim() == "1")
            {
                rbPersonaNatural.CheckState = CheckState.Checked;
            }
            else if (txttipdoc.Text.Trim() == "6")
            {
                rbPersonaJuridico.CheckState = CheckState.Checked;
            }
            else {
                rbNoDomiciliado.CheckState = CheckState.Checked;
            }
            
            //activar controles por opcion de persona seleccionado.
            ActivaDatosPorTipoPersona();



        }

        private void rbPersonaJuridico_CheckStateChanged(object sender, EventArgs e)
        {
            ActivaDatosPorTipoPersona();
        }

        private void rbPersonaNatural_CheckStateChanged(object sender, EventArgs e)
        {
            ActivaDatosPorTipoPersona();
        }

        private void rbNoDomiciliado_CheckStateChanged(object sender, EventArgs e)
        {
            ActivaDatosPorTipoPersona();
        }
    }
}
