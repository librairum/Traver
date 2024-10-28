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
    public abstract class MaquinaAccesor : AccessorBase<MaquinaAccesor>
    {
        [SprocName("Spu_Pro_Ins_PRO11MAQUINA")]
        public abstract void Spu_Pro_Ins_PRO11MAQUINA(string @PRO11CODEMP, string @PRO11COD, string @PRO11DESC, string @PRO11ACTIVIDADREL, out string @msgretorno);
        [SprocName("Spu_Pro_Upd_PRO11MAQUINA")]
        public abstract void Spu_Pro_Upd_PRO11MAQUINA(string @PRO11CODEMP, string @PRO11COD, string @PRO11DESC, string @PRO11ACTIVIDADREL, out string @msgretorno);
        [SprocName("Spu_Pro_Del_PRO11MAQUINA")]
        public abstract void Spu_Pro_Del_PRO11MAQUINA(string @PRO11CODEMP, string @PRO11COD, out string @msgretorno);
        
        [SprocName("Spu_Pro_Trae_PRO11MAQUINA")]
        public abstract List<Maquina> Spu_Pro_Trae_PRO11MAQUINA(string @PRO11CODEMP);
        
        [SprocName("Spu_Pro_Trae_CodigoMaquina")]
        public abstract void Spu_Pro_Trae_CodigoMaquina(string @codigoEmpresa, out string @codigo);
        [SprocName("Spu_Pro_Trae_PRO11MAQUINARegistro")]
        public abstract Maquina Spu_Pro_Trae_PRO11MAQUINARegistro(string @PRO11CODEMP, string @PRO11COD);
        [SprocName("Spu_Pro_Trae_MaquinaxLineaActividad")]
        public abstract List<Maquina> Spu_Pro_Trae_MaquinaxLineaActividad( string @PRO11CODEMP, string @PRO11ACTIVIDADREL);

        #region"Inventario"
        [SprocName("Spu_Inv_Trae_Maquina")]
        public abstract List<MaquinaInventario> TraeMaquinaInventario(string @cCodEmp, string @cCampo, string @cFiltro);
        #endregion

    }
}
