using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class SedeAccesor : AccessorBase<SedeAccesor>
    {

        [SprocName("sp_Glo_Trae_Cuentas_Corrientes")]
        public abstract List<CuentaCorriente> Glo_Traer_CuentasCorrientes(string @cCodEmp, string @cTipoAnal, string @cOrden);
        [SprocName("Spu_Inv_Trae_Sedes")]
        public abstract List<Sede> TraeSede(string @cCodigoEmp, string @cCodigoCliente, string @come05clientetipana);
        [SprocName("Spu_Inv_Trae_SedeRegistro")]
        public abstract Sede TraeSedeRegistro(string @come05empresa, string @come05clientetipana, string @come05clientecod, string @come05sedeclientescod);
        [SprocName("Spu_Inv_Ins_Sede")]

        public abstract void SedeInsertar(string @cCodEmp, string @cCodigoClientepana, string @cCodigoClienteCod,
            string @cCodigoSede, string @cDescripcionSede, string @cDireccionSede,
            string @cReferenciaSede, out string @cMsgRetorno);

        [SprocName("Spu_Inv_Up_Sede")]
        public abstract void SedeActualiar(string @cCodEmp, string cCodigoClientepana, string cCodigoClienteCod, string cCodigoSede,
            string cDescripcionSede, string cDireccionSede, string cReferenciaSede, out string cMsgRetorno);

        [SprocName("Spu_Inv_Del_Sede")]
        public abstract void SedeEliminar(string @cCodEmp, string @cCodigoClientepana, string @cCodigoClienteCod, string @cCodigoSede, out string @cMsgRetorno);
        /*@cCodEmp varchar(2),  
@cCodigoClientepana varchar(2),  
@cCodigoClienteCod varchar(20),  
@MsgRetorno varchar(100) output*/
        [SprocName("Spu_Inv_GenCod_Sede")]
        public abstract void SedeGeneraCodigo(string @cCodEmp, string @cCodigoClientepana, string @cCodigoClienteCod, out string @MsgRetorno);

#region "facturacion"
        [SprocName("Spu_Fac_Trae_DomicilioDestinatario")]
        public abstract List<Sede> Spu_Fac_Trae_DomicilioDestinatario(string @cCodigoEmp, string @come05clientetipana, string @cCodigoCliente);
        #endregion
        #region "metodos globales"
        [SprocName("Spu_Glo_Trae_Sedes")]
        public abstract List<Sede> Glo_TraeSedes(string @cCodigoEmp, string @cCodigoCliente);
        
        [SprocName("Spu_Glo_Ins_Sede")]
        public abstract void Glo_InsertarSede(string @cCodEmp, string @cCodigoClientepana, string @cCodigoClienteCod,
                string @cCodigoSede, string @cDescripcionSede, string @cDireccionSede, string @cReferenciaSede,
                string @come05DepCod, string @come05ProvCod, string @come05DistCod, string @come05FlagDimiFiscal,
                string @come05PuertoCod, out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Glo_Upd_Sede")]
        public abstract void Glo_ActualizarSede(string @cCodEmp, string @cCodigoClientepana, string @cCodigoClienteCod, string @cCodigoSede,
            string @cDescripcionSede, string @cDireccionSede, string @cReferenciaSede,
            string @come05DepCod, string @come05ProvCod, string @come05DistCod, string @come05FlagDimiFiscal,
            string @come05PuertoCod, out int @flag, out string @cMsgRetorno);
        
        [SprocName("Spu_Glo_Del_Sede")]
        public abstract void EliminarSede(string @cCodEmp, string @cCodigoClientepana, string @cCodigoClienteCod,
            string @cCodigoSede, out string @cMsgRetorno);


        [SprocName("Spu_Glo_Trae_SedeRegistro")]
        public abstract Sede Glo_TraeSedeRegistro(string @come05empresa, string @come05clientetipana,
                    string @come05clientecod, string @come05sedeclientescod);
        [SprocName("Spu_Glo_GenCod_Sede")]
        public abstract void Glo_SedeGeneraCodigo(string @cCodEmp, string @cCodigoClientepana, string @cCodigoClienteCod, out string @MsgRetorno);
        #endregion

    }
}
