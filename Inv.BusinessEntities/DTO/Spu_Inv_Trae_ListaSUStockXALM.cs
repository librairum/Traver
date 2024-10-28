using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Inv_Trae_ListaSUStockXALM")]
    public class Spu_Inv_Trae_ListaSUStockXALM
    {
        [MapField("In01key")]
        public string In01key { get; set; }
        
        [MapField("IN01DESLAR")]
        public string IN01DESLAR { get; set; }
        
        [MapField("IN01UNIMED")]
        public string IN01UNIMED { get; set; }

        [MapField("Stock")]
        public string Stock { get; set; }

        [MapField("AlmacenCod")]
        public string AlmacenCod { get; set; }

        [MapField("AlmDescripcion")]
        public string AlmDescripcion { get; set; }
    }
}
