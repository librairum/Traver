using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class TipoAnalisisAccesor: AccessorBase<TipoAnalisisAccesor>
    {
        [SprocName("Spu_Come_Trae_TipoAnaCtaCte")]
        public abstract List<TipoAnalisis> TraerTipoAnalisis(string @ccb17emp);

        [SprocName("Spu_Inv_Trae_cca")]
        public abstract List<TipoAnalisis> Spu_Inv_Trae_cca(string @codemp);

        [SprocName("Spu_Inv_Ins_TipoAnalisis")]
        public abstract void Spu_Inv_Ins_TipoAnalisis(string @CCB17EMP, string @CCB17CDGO, string @CCB17DESC, out string @CMSGRETORNO);

        [SprocName("Spu_Inv_Upd_TipoAnalisis")]
        public abstract void Spu_Inv_Upd_TipoAnalisis(string @CCB17EMP, string @CCB17CDGO, string @CCB17DESC, out string @CMSGRETORNO);

        [SprocName("Spu_Inv_Del_TipoAnalisis")]
        public abstract void Spu_Inv_Del_TipoAnalisis(string @CCB17EMP, string @CCB17CDGO, out string @CMSGRETORNO);

        [SprocName("Spu_Inv_Trae_TipoAnalisisCodigo")]
        public abstract void Spu_Inv_Trae_TipoAnalisisCodigo(string @CCB17EMP, out string @Codigo);

        [SprocName("Spu_Inv_Traer_TipoAnalisisRegistro")]
        public abstract List<TipoAnalisis> Spu_Inv_Traer_TipoAnalisisRegistro(string @ccb17emp, string @ccb17cdgo);

    }
}
