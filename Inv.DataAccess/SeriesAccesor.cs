using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class SeriesAccesor : AccessorBase<SeriesAccesor>
    {
        
        [SprocName("Spu_Fact_Trae_FAC07_SERIES")]
        public abstract List<Series> TraeSeries(string @FAC07CODEMP, string @FAC01COD,
            string @campo, string @filro);

        [SprocName("Spu_Fact_Ins_FAC07_SERIES")]
        public abstract void InsertarSerie(string @FAC07CODEMP, string @FAC01COD, string @FAC07SERIE, string @FAC07DESC,
        string @FAC07ABREVIA, string @FAC07NUMERO, string @FAC07AESTABLECIMIENTOCOD,
        out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Upd_FAC07_SERIES")]
        public abstract void ActualizarSerie(string @FAC07CODEMP, string @FAC01COD, string @FAC07SERIE,
        string @FAC07DESC, string @FAC07ABREVIA, string @FAC07NUMERO, string @FAC07AESTABLECIMIENTOCOD,
        out int @flag, out string @msgretorno);

        
        [SprocName("Spu_Fact_Del_FAC07_SERIES")]
        public abstract void EliminarSerie(string @FAC07CODEMP, string @FAC01COD,
            string @FAC07SERIE, out int @flag, out string @msgretorno);

        
        /*
         CREATE Procedure [dbo].[Spu_Fact_Del_FAC07_SERIES]  
@FAC07CODEMP char(2),  
@FAC01COD char(2),  
@FAC07SERIE varchar(3),  
@msgretorno varchar(100) output  
         */
    }
}
