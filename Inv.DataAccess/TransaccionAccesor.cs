using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class TransaccionAccesor : AccessorBase<TransaccionAccesor>
    {
        

        [SprocName("sp_Inv_Trae_Transaccion")]
        public abstract List<TipoTransaccion> TransaccionTraer(string @cCodEmp, string @cOrden, string @cFiltro);

        [SprocName("Spu_Inv_Trae_TransaccionRegistro")]
        public abstract TipoTransaccion TransaccionTraerRegistro(string @in15codemp, string @in15Codigo);

        [SprocName("sp_Inv_Ins_Transaccion")]
        public abstract void TransaccionInsertar(string @cCodEmp, string @cCodigo, string @cDescripcion, string @cTipoMov, string @cValorizado, string @cLiquidacion, 
                                                 string @in15ctactetipana, out string @cMsgRetorno);

        [SprocName("sp_Inv_Upd_Transaccion")]
        public abstract void TransaccionModificar(string @cCodEmp, string @cCodigo, string @cDescripcion, string @cTipoMov, string @cValorizado, string @cLiquidacion, 
                                                  string @in15ctactetipana, out string @cMsgRetorno);

        [SprocName("sp_Inv_Del_Transaccion")]
        public abstract void TransaccionEliminar(string @cCodEmp, string @cCodigo, out string @cMsgRetorno);

    }

}
