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
    public abstract class OrdenTrabajoAccesor :AccessorBase<OrdenTrabajoAccesor>
    {
        [SprocName("Spu_Pro_Traer_OrdenTrabajoEjecutada")]
        public abstract List<OrdenTrabajo> TraerOrdenTrabajo(string @PRO13CODEMP, string @PRO13DOCINGALMAA, string @PRO13DOCINGALMMM, 
                                                             string @PRO13DOCINGALMCODDOC, string @IN06TIPDOC);
        
        [SprocName("Spu_Pro_Ins_PRO13ORDENTRABAJOEJEC")]
        public abstract void InsertarOrdenTrabajo(string @PRO13CODEMP,string @PRO13COD,string @PRO13PRODUCTOCOD,
        string @PRO13DOCINGALMAA, string @PRO13DOCINGALMMM, string @PRO13DOCINGALMTIPDOC,
        string @PRO13DOCINGALMCODDOC, string @PRO13ORDPROD, string @PRO13LINEACOD, string @PRO13ACTIVIDADNIVELCOD, string @PRO13AA, string @PRO13MM,
        string @PRO13ORDENTRABAJOTIPO,  out int @flag, out string @msgretorno);

        [SprocName("Spu_Pro_Upd_PRO13ORDENTRABAJOEJEC")]
        public abstract void ActualizarOrdenTrabajo(string @PRO13CODEMP, string @PRO13COD, string @PRO13PRODUCTOCOD,
        string @PRO13DOCINGALMAA, string @PRO13DOCINGALMMM, string @PRO13DOCINGALMTIPDOC,
        string @PRO13DOCINGALMCODDOC, string @PRO13ORDPROD, string @PRO13LINEACOD, string @PRO13ACTIVIDADNIVELCOD, string @PRO13AA, string @PRO13MM,
        string @PRO13ORDENTRABAJOTIPO,  out int @flag, out string @msgretorno);

        [SprocName("Spu_Pro_Del_PRO13ORDENTRABAJOEJEC")]
        public abstract void EliminarOrdenTrabajo(string @PRO13CODEMP, string @PRO13COD, out string @msgretorno);

        [SprocName("Spu_Pro_Trae_OTNumero")]
        public abstract void TraerNumeroOT(string @PRO13CODEMP, out string @NumOT);
        
        [SprocName("Spu_Pro_TraerRegistroOrdenTrabajo")]
        public abstract  OrdenTrabajo TraerRegistroOT(string @PRO13CODEMP, string @PRO13COD);

        #region "Orden trabajo Tipo"
        [SprocName("Spu_Pro_Trae_OrdenTrabajoTipo")]
        public abstract List<OrdenTrabajoTipo> TraerOrdenTrabajoTipo(string @Empresa, string @Codigo);
        [SprocName("Spu_Pro_Traer_NroOrdenTrabajoTipo")]
        public abstract void TraerNroOrdenTrabajoTipo(string @Empresa, out string @Codigo, out int @flag, out string @mensaje);
        [SprocName("Spu_Pro_Ins_OrdenTrabajoTipo")]
        public abstract void InsertarOrdenTrabajoTipo(string @Empresa, string @Codigo, string @Descripcion, out  int @flag, out string @mensaje);
        [SprocName("Spu_Pro_Upd_OrdenTrabajoTipo")]
        public abstract void ActualizarOrdenTrabajoTipo(string @Empresa, string @Codigo, string @Descripcion, out  int @flag, out string @mensaje);
        [SprocName("Spu_Pro_Del_OrdenTrabajoTipo")]
        public abstract void EliminarOrdenTrabajoTipo(string @Empresa, string @Codigo, out int @flag, out string @mensaje);
        
        #endregion

    }
}
