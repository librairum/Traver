using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    //    public abstract class TipoDocumentoClienteAccesor : AccessorBase<TipoDocumentoClienteAccesor>
    public abstract class TipoDocumentoVentasAccesor : AccessorBase<TipoDocumentoVentasAccesor>
    {

       [SprocName("Spu_Fact_Trae_FAC01_TIPDOC")]
       public abstract List<TipoDocumentoVentas> TraerTipoDocumentoVentas(string @FAC01CODEMP, string @campo, string @filtro);
       
        [SprocName("Spu_Fact_Ins_FAC01_TIPDOC")]
        public abstract void InsertarTipoDocumentVentas(string @FAC01CODEMP, string @FAC01COD,
        string @FAC01DESC, string @FAC01TIPDOC, string @FAC01FETIPDOC, string @FAC01CODLIBRO, 
        out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Upd_FAC01_TIPDOC")]
        public abstract void ActualizarTipoDocumentoVentas(string @FAC01CODEMP, string @FAC01COD, string @FAC01DESC, 
        string @FAC01TIPDOC, string @FAC01FETIPDOC, string @FAC01CODLIBRO, out int @flag , out string @msgretorno);
        
        [SprocName("Spu_Fact_Del_FAC01_TIPDOC")] 
        public abstract void EliminarTipoDocumentVentas(string @FAC01CODEMP, string @FAC01COD,
        out int @flag, out string @msgretorno);
                    
    }
}
