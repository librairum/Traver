using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class CanterasAccesor : AccessorBase<CanterasAccesor>
    {
        [SprocName("Spu_Inv_Traer_CanterasRegistro")]
        public abstract Canteras Spu_Inv_Traer_CanterasRegistro(string @IN20CODEMP, string @IN20CODIGO);
        
        [SprocName("Spu_Inv_Traer_Canteras")]
        public abstract List<Canteras> Spu_Inv_Traer_Canteras(string @IN20CODEMP);
        
        [SprocName("Spu_Inv_Ins_Canteras")]
        public abstract void Spu_Inv_Ins_Canteras (string @IN20CODEMP,string @IN20CODIGO, string @IN20DESC, string @IN20CODPROVEEDOR,out string @cMsgRetorno);
        [SprocName("Spu_Inv_Upd_Canteras")]
        public abstract void Spu_Inv_Upd_Canteras(string @IN20CODEMP, string @IN20CODIGO, string @IN20DESC, string @IN20CODPROVEEDOR, 
                                                   out string @cMsgRetorno);
        [SprocName("Spu_Inv_Del_Canteras")]
        public abstract void Spu_Inv_Del_Canteras(string @IN20CODEMP, string @IN20CODIGO, string @IN20DESC, string @IN20CODPROVEEDOR, 
                                                    out string @cMsgRetorno);
        [SprocName("Spu_Inv_Traer_CanterasCodigo")]
        public abstract void Spu_Inv_Traer_CanterasCodigo(string @IN20CODEMP, out string @codigo);

        [SprocName("Spu_Inv_Traer_CanterasxContratista")]
        public abstract List<Canteras> Spu_Inv_Traer_CanterasxContratista(string @IN20CODEMP, string @Analisis, string @codigo);


    }
}
