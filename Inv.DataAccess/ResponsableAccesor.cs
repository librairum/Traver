using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class ResponsableAccesor: AccessorBase<ResponsableAccesor>
    {
        [SprocName("sp_Inv_Help_Responsables")]
        public abstract List<Responsable> TraerResponsable(string @cCodEmp, string @cCampo, string @cFiltro, string @flag);

        [SprocName("Spu_Inv_Rep_ResponsableAlm")]
        public abstract List<Responsable> TraerResponsableXAlm(string @in23codemp);

        [SprocName("Spu_Inv_Trae_Responsables")]
        public abstract List<Responsable> TraerResponsables(string @in23codemp);

        [SprocName("sp_Inv_Ins_Responsable")]
        public abstract void sp_Inv_Ins_Responsable(string @cCodEmp,
        string @cCodigo, string @cDescripcion, string @cTipo, out string @cMsgRetorno);

        [SprocName("sp_Inv_Upd_Responsable")]
        public abstract void sp_Inv_Upd_Responsable(string @cCodEmp,
        string @cCodigo, string @cDescripcion, string @cTipo, out string @cMsgRetorno);

        [SprocName("sp_Inv_Del_Responsable")]
        public abstract void sp_Inv_Del_Responsable(string @cCodEmp, string @cCodigo, 
        out string @cMsgRetorno);

        [SprocName("Spu_Inv_Trae_ResponsablesCodigo")]
        public abstract void Spu_Inv_Trae_ResponsablesCodigo(string @in23codemp, out string @Codigo);
        
    }
}
