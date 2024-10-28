using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class LineaArticulosAccesor : AccessorBase<LineaArticulosAccesor>
    {

        [SprocName("Spu_Com_Trae_LineaArticulo1")]
        public abstract List<LineaArticulo> TraeLineaArticulo(string @cCodEmp);

        [SprocName("Spu_Com_Trae_GrupoArticulo1")]
        public abstract List<GrupoArticulo> TraeGrupoArticulo(string @cCodEmp, string @cCodLinArt);

        [SprocName("Spu_Com_Trae_SubGrupoArticulo1")]
        public abstract List<SubGrupoArticulo> TraeSubGrupoArticulo(string @cCodEmp, string @cCodLinArt, string @cCodGrupArt);

        [SprocName("Spu_Com_Ins_LinArt")]
        public abstract void InsertarLinArt(string @cCodEmp, string @cCodLinArt, string @cDescripcion, string @cAno, out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Com_Upd_LinArt")]
        public abstract void ActualizarLinArt(string @cCodEmp, string @cCodLinArt, string @cDescripcion, out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Com_Ins_GrupArt")]
        public abstract void InsertarGrupoArticulo(string @cCodEmp, string @cCodLinArt, string @cCodGrupArt,  string @cDescripcion,  string @cAno,
            out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Com_Upd_GrupArt")]
        public abstract void ActualizarGrupoArticulo(string @cCodEmp, string @cCodLinArt, string @cCodGrupArt, string @cDescripcion,
            out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Com_Ins_SubGrupArt")]
        public abstract void InsertarSubGrupoArticulo(string @cCodEmp, string @cCodLinArt, string @cCodGrupArt, string @cCodSubGrupArt, 
            string @cDescripcion, string @cAno, out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Com_Upd_SubGrupArt")]
        public abstract void ActualizarSubGrupoArticulo(string @cCodEmp, string @cCodLinArt, string @cCodGrupArt, string @cCodSubGrupArt, 
            string @cDescripcion, out int @flag, out string @cMsgRetorno);


        [SprocName("Spu_Com_Trae_CodigoLineaArticulo")]
        public abstract void TraeCodigLineaArticulo(string @cCodEmp, out string @codigogenerado);


        [SprocName("Spu_Com_Trae_CodigoGrupoArticulo")]
        public abstract void TraeCodigoGrupoArticulo(string @cCodEmp, string @cCodLinArt, out string @codigogenerado);

        [SprocName("Spu_Com_Trae_CodigoSubGrupoArticulo")]
        public abstract void TraeCodigoSubGrupoArticulo(string @cCodEmp, string @cCodLinArt, string @cCodGrupArt, out string @codigogenerado);

        [SprocName("Spu_Com_Del_LinArticulo")]
        public abstract void EliminarLineaArticulo(string @cCodEmp, string @cCodigo, out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Com_Del_GrupArticulo")]
        public abstract void EliminarGrupoArticulo(string @cCodEmp, string @cCodLin, string @cCodGrup, 
            out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Com_Del_SubGrupArticulo")]
        public abstract void EliminarSubGrupoArticulo(string @cCodEmp, string @cCodLin, string @cCodGrup, 
                                                string @cCodSubGrup, out int @flag,out string @cMsgRetorno);

    }
}
