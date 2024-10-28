using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    [TableName("Spu_Fact_Trae_ProdEquiSunat")]
    public class Spu_Fact_Trae_ProdEquiSunat
    {
        [MapField("Codigo")]
        public string Codigo{get;set;}
        [MapField("Descripcion")]
        public string Descripcion{get;set;}
        [MapField("SegmentoCodigo")]
        public string  SegmentoCodigo{get;set;}
        [MapField("SegmentoDescripcion")]
        public string SegmentoDescripcion{get;set;}
        [MapField("FamiliaCodigo")]
        public string FamiliaCodigo{get;set;}
        [MapField("FamiliaDescripcion")]
        public string FamiliaDescripcion{get;set;}

  
    }
}
