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
    public abstract class TurnosAccesor : AccessorBase<TurnosAccesor>
    {
        [SprocName("Spu_Pro_Ins_PRO12TURNOS")]
        public abstract void Spu_Pro_Ins_PRO12TURNOS(string @PRO12CODEMP, string @PRO12COD, string @PRO12DESC,
            string @PRO12HORAINICIO, string @PRO12HORAFIN, string @PRO12HORAINICIOEXT, 
            string @PRO12HORAFINEXT, out string @msgretorno);
        
        [SprocName("Spu_Pro_Upd_PRO12TURNOS")]
        public abstract void Spu_Pro_Upd_PRO12TURNOS(string @PRO12CODEMP, string @PRO12COD, string @PRO12DESC,
                string  @PRO12HORAINICIO, string @PRO12HORAFIN, string  @PRO12HORAINICIOEXT, 
            string @PRO12HORAFINEXT, out string @msgretorno);
        
        [SprocName("Spu_Pro_Del_PRO12TURNOS")]
        public abstract void Spu_Pro_Del_PRO12TURNOS(string @PRO12CODEMP, string @PRO12COD, out string @msgretorno);
        
        [SprocName("Spu_Pro_Trae_PRO12TURNOS")]
        public abstract List<Turnos> Spu_Pro_Trae_PRO12TURNOS(string @PRO12CODEMP);
        
        [SprocName("Spu_Pro_Trae_CodigoTurnos")]
        public abstract void Spu_Pro_Trae_CodigoTurnos(string @codigoEmpresa, out string @codigo);
        [SprocName("Spu_Pro_Traer_RegistroPRO12TURNOS")]
        public abstract Turnos Spu_Pro_Traer_RegistroPRO12TURNOS( string @PRO12CODEMP, string @PRO12COD);
    }
}
