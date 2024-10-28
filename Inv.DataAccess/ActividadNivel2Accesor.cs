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
    public abstract class ActividadNivel2Accesor : AccessorBase<ActividadNivel2Accesor>
    {
        [SprocName("Spu_Pro_Ins_PRO10ACTIVIDADNIVEL2")]
        public abstract void Spu_Pro_Ins_PRO10ACTIVIDADNIVEL2(string @PRO10CODEMP, string @PRO10LINEACOD, string @PRO10ACTIVIDADCOD, string @PRO10COD, 
                                                              string @PRO10DESC,out string @msgretorno);
        [SprocName("Spu_Pro_Upd_PRO10ACTIVIDADNIVEL2")]
        public abstract void Spu_Pro_Upd_PRO10ACTIVIDADNIVEL2(string @PRO10CODEMP, string @PRO10LINEACOD, string @PRO10ACTIVIDADCOD, string @PRO10COD,
                                                              string @PRO10DESC, out string @msgretorno);
        [SprocName("Spu_Pro_Del_PRO10ACTIVIDADNIVEL2")]
        public abstract void Spu_Pro_Del_PRO10ACTIVIDADNIVEL2(string @PRO10CODEMP, string @PRO10LINEACOD, string @PRO10ACTIVIDADCOD, string @PRO10COD,
                                                                out string @msgretorno);
        [SprocName("Spu_Pro_Trae_PRO10ACTIVIDADNIVEL2")]
        public abstract List<ActividadNivel2> Spu_Pro_Trae_PRO10ACTIVIDADNIVEL2(string @PRO10CODEMP);
        
        [SprocName("Spu_Pro_Trae_CodigoActividadNivel2")]
        public abstract void  Spu_Pro_Trae_CodigoActividadNivel2( string @codigoEmpresa , out string @codigo );

        [SprocName("Spu_Pro_Trae_PRO10ACTIVIDADNIVEL2REGISTRO")]
        public abstract ActividadNivel2 Spu_Pro_Trae_PRO10ACTIVIDADNIVEL2REGISTRO(string @PRO10CODEMP, string @PRO10LINEACOD, string @PRO10ACTIVIDADCOD, string @PRO10COD);
    }
}
