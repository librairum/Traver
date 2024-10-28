using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
using System.Data;
namespace Inv.DataAccess
{
    public abstract class CuentaCorrienteAccesor: AccessorBase<CuentaCorrienteAccesor>
    {

        [SprocName("sp_Glo_Trae_Cuentas_Corrientes")]
        public abstract List<CuentaCorriente> Glo_Traer_CuentasCorrientes(string @cCodEmp, string @cTipoAnal, string @cOrden);
        [SprocName("sp_Inv_Trae_Cuentas_Corrientes")]
        public abstract List<CuentaCorriente> CuentaCorrienteTraer(string @cCodEmp,string @cTipoAnal,string @cOrden);

        [SprocName("Spu_Inv_Trae_CuentaCorrienteRegistro")]
        public abstract CuentaCorriente CuentaCorrienteTraerRegistro(string @ccm02emp, string @ccm02tipana,string @ccm02cod);

        [SprocName("sp_Inv_Ins_Cuenta_Corriente")]
        public abstract void CuentaCorrienteInsertar(string @cCodEmp, string @cTipAna, string @cCodigo, string @cNombre, string @cDireccion, string @cTelefono, string @dFecha, string @cRUC, string @cNumCuentaSol, string @cTipoPago, string @cNumCuentaDol, string @cNomAbrev , out string @cMsgRetorno);
   
        [SprocName("sp_Inv_Upd_Cuenta_Corriente")]
        public abstract void CuentaCorrienteModificar(string @cCodEmp, string @cTipAna, string @cCodigo, string @cNombre, string @cDireccion, string @cTelefono, string @dFecha, string @cRUC, string @cNumCuentaSol, string @cTipoPago, string @cNumCuentaDol, string @cNomAbrev, out string @cMsgRetorno);
 
        [SprocName("sp_Inv_Del_Cuenta_Corriente")]
        public abstract void CuentaCorrienteEliminar(string @cCodEmp, string @cTipAna,string @cCodigo,out string @cMsgRetorno);

        [SprocName("Spu_Fact_Trae_ccm02cta")]
        public abstract List<CuentaCorriente> TraeCliente(string @ccm02emp, string @ccm02tipana, string @campo, string @filtro);

        [SprocName("Spu_Fact_Ins_Cliente")]
        public abstract void Spu_Fact_Ins_Cliente(string @cCodEmp, string @cTipAna, string @cCodigo,
        string @cNombre, string @cDireccion, string @cTelefono, string @dFecha, string @cRUC,
        string @cFax, string @cRubPro, string @cAtencion, string @cMoneda, string @cForPag,
        string @cHabilitar, string @cCorreo, string @cTipoAgRet, string @cTipoPersona,
        string @cApePat, string @cApeMat, string @cNom, string @ccm02EstadoContribuyente,
        string @ccm02SituacionDomicilio, string @ccm02nroctadetraccion, string @ccm02tipdocidentidad,
        string @ccm02CorreoFacturaElectronica, string @ccm02FEDepartamentoCod,
        string @ccm02FEProvinciaCod, string @ccm02FEDistritoCod, string @ccm02FEUrbanizacion,
        string @ccm02FEPaisCod, string @CCM02TIPOCLIENTECOD, string @ccm02LineaCreditoMoneda,
        double @ccm02LineaCreditoImporteSolicitado, double @ccm02LineaCreditoImporteConcedido,
        int @ccm02LineaCreditoCondicionPago, string @ccm02FlagDescripcionCliente,
        out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Fact_Upd_Cliente")]
        public abstract void Spu_Fact_Upd_Cliente(string @cCodEmp, string @cTipAna,
        string @cCodigo, string @cNombre, string @cDireccion, string @cTelefono,
        string @dFecha, string @cRUC, string @cFax, string @cRubPro, string @cAtencion,
        string @cMoneda, string @cForPag, string @cHabilitar, string @cCorreo,
        string @cTipoAgRet, string @cTipoPersona,
        string @cApePat, string @cApeMat, string @cNom, string @ccm02EstadoContribuyente,
        string @ccm02SituacionDomicilio, string @ccm02nroctadetraccion,
        string @ccm02tipdocidentidad, string @ccm02CorreoFacturaElectronica,
        string @ccm02FEDepartamentoCod, string @ccm02FEProvinciaCod,
        string @ccm02FEDistritoCod, string @ccm02FEUrbanizacion,
        string @ccm02FEPaisCod, string @CCM02TIPOCLIENTECOD,
        string @ccm02LineaCreditoMoneda, double @ccm02LineaCreditoImporteSolicitado,
        double @ccm02LineaCreditoImporteConcedido, int @ccm02LineaCreditoCondicionPago,
        string @ccm02FlagDescripcionCliente,    
        out int @flag, out string @cMsgRetorno);


        [SprocName("Spu_Fact_Del_cliente")]
        public abstract void Spu_Fact_Del_cliente(string @cCodEmp, string @cTipAna, string @cCodigo, 
                                                  out int @flag, out string @cMsgRetorno);
        #region "::::::::::::::::::::::::::::::::::::::::::::::::  FACTURA  ::::::::::::::::::::::::::::::::::::::::::::::::::"
        [SprocName("Spu_Glo_Ins_CuentaCorriente")]
        public abstract void Spu_Glo_Ins_CuentaCorriente(string @ccm02emp, string @ccm02tipana, string @ccm02cod, string @ccm02nom ,
            string @ccm02dir,  string @ccm02tel,  string @ccm02fec,  string @ccm02ruc, string @ccm02ncta,  
            string @ccm02tpag,  string @ccm02nctadol,  string @ccm02fax,  string @ccm02respon,  
            string @ccm02rubpro,  string @ccm02Aten,  string @ccm02moneda,  string @Ccm02Forpag, 
            string @ccm02activo,  string @ccm02correo,  string @ccm02tel2,  string @ccm02fecnac,  
            string @ccm02tipojuridico,  double @ccm02descuento,  string @ccm02TipoAgenteRetencion,  string @ccm02dni,  
            string @ccm02localidad,  string @ccm02TipoRuc,  string @ccm02ApePaterno, string @ccm02ApeMaterno,  
            string @ccm02Nombres,  string @ccm02EstadoContribuyente,  string @ccm02SituacionDomicilio, 
            string @ccm02Brevete, string @ccm02tipdocidentidad, 
            string @ccm02EntidadEmiCod,string @ccm02NroRegistroMTC,string @ccm02TarjetaUnicaCirculacion,
            out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Glo_Upd_CuentaCorriente")]
        public abstract void Spu_Glo_Upd_CuentaCorriente(
        string @ccm02emp,string @ccm02tipana,string @ccm02cod,string @ccm02nom,
        string @ccm02dir,string @ccm02tel,string @ccm02fec,string @ccm02ruc,string @ccm02ncta,
        string @ccm02tpag,string @ccm02nctadol,string @ccm02fax,string @ccm02respon,string @ccm02rubpro,
        string @ccm02Aten,string @ccm02moneda,string @Ccm02Forpag,string @ccm02activo,string @ccm02correo,string @ccm02tel2,
        string @ccm02fecnac,string @ccm02tipojuridico,double @ccm02descuento,string @ccm02TipoAgenteRetencion,string @ccm02dni,
        string @ccm02localidad,string @ccm02TipoRuc,string @ccm02ApePaterno,string @ccm02ApeMaterno,string @ccm02Nombres,
        string @ccm02EstadoContribuyente,string @ccm02SituacionDomicilio, string @ccm02Brevete, string @ccm02tipdocidentidad,
        string @ccm02EntidadEmiCod, string @ccm02NroRegistroMTC, string @ccm02TarjetaUnicaCirculacion,
            out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Fac_Ins_Cuenta_Corriente")]
        public abstract void Spu_Fac_Ins_Cuenta_Corriente(string @cCodEmp, string @cTipAna, string @cCodigo, string @cNombre,
        string @cDireccion, string @cTelefono, DateTime @dFecha, string @cRuc, string @cNumCuentaSol, string @cTipoPago,
        string @cNumCuentaDol, string @cFax, string @cResponsable, string @cRubpro, string @cAten, string @cMoneda, 
        string @cFormaPago, string @cActivo, string @cCorreo, string @cTel2, DateTime @dFecnac, string @cTipojuridico,
        double @dDescuento, string @cTipoAgenteRetencion, string @cDni, string @cLocalidad, string @cTipoRuc, 
        string @cApePaterno, string @cApeMaterno, string @cNombres, string @cEstadoContribuyente, string @cSituacionDomicilio,  
               out string @cMsgRetorno);

        [SprocName("Sp_Fac_Upd_Cuenta_Corriente")]
        public abstract void Sp_Fac_Upd_Cuenta_Corriente(string @cCodEmp, string @cTipAna, string @cCodigo, string @cNombre,
        string @cDireccion, string @cTelefono, DateTime @dFecha, string @cRuc, string @cNumCuentaSol, string @cTipoPago,
        string @cNumCuentaDol, string @cFax, string @cResponsable, string @cRubpro, string @cAten, string @cMoneda,
        string @cFormaPago, string @cActivo, string @cCorreo, string @cTel2, DateTime @dFecnac, string @cTipojuridico,
        double @dDescuento, string @cTipoAgenteRetencion, string @cDni, string @cLocalidad, string @cTipoRuc,
        string @cApePaterno, string @cApeMaterno, string @cNombres, string @cEstadoContribuyente, string @cSituacionDomicilio,
               out string @cMsgRetorno);
        [SprocName("Sp_Fac_Del_Cuenta_Corriente")]
        public abstract void Sp_Fac_Del_Cuenta_Corriente(string @cCodEmp, string @cTipAna, string @cCodigo, out int @flag, out string @cMsgRetorno);


        [SprocName("Spu_Fac_Trae_ClientesConProdPropio")]
        public abstract List<CuentaCorriente> Spu_Fac_Trae_ClientesConProdPropio(string @ccm02emp, string @ccm02tipana);

        [SprocName("Spu_Com_Help_Proveedor")]
        public abstract List<CuentaCorriente> Spu_Com_Help_Proveedor(string @cCodEmp, string @cTipAna);

        #endregion

        #region "Compras"
        [SprocName("Spu_Com_Ins_CuentaCorriente")]
        public abstract void ComprasInsertarCuentaCorriente(string @cCodEmp,string @cTipAna,string @cCodigo,string @cNombre,
        string @cDireccion,string @cTelefono,string @dFecha,string @cRUC, string @cFax,string @cRubPro,string @cAtencion, 
        string @cMoneda, string @cForPag,string @cHabilitar,string @cCorreo,string @cTipoAgRet,string @cTipoPersona, string @cApePat,
        string @cApeMat,string @cNom, string @ccm02EstadoContribuyente,string @ccm02SituacionDomicilio,string @ccm02nroctadetraccion,
        string @ccm02paiscodigo, string @ccm02CorreoFacturaElectronica, out int @flag, out string @cMsgRetorno);
               
        [SprocName("Spu_Com_Upd_CuentaCorriente")]
        public abstract void ComprasActualizarCuentaCorriente(string @cCodEmp,string @cTipAna,string @cCodigo,string @cNombre,
        string @cDireccion,string @cTelefono,string @dFecha,string @cRUC, string @cFax,string @cRubPro,string @cAtencion, 
        string @cMoneda, string @cForPag,string @cHabilitar,string @cCorreo,string @cTipoAgRet,string @cTipoPersona, string @cApePat,
        string @cApeMat,string @cNom, string @ccm02EstadoContribuyente,string @ccm02SituacionDomicilio,string @ccm02nroctadetraccion,
        string @ccm02paiscodigo, string @ccm02CorreoFacturaElectronica, out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Com_Del_CuentaCorriente")]
        public abstract void ComprasEliminarCuentaCorriente(string @cCodEmp, string @cTipAna, string @cCodigo,
        out int @flag ,  out string @cMsgRetorno);


        [SprocName("Spu_Com_Trae_CuentaCorriente")]
        public abstract DataTable ComprasTraeCuentaCorriente(string @cCodEmp, string @cTipAnal, string @cTipoFiltro, string @cFiltro);


        
        #endregion

    }

}
