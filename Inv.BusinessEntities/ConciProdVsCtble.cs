using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("COS03CONCIPRODVSCTBLE")]
    public class ConciProdVsCtble
    {
        [MapField("COS03CODEMP")]
        public string COS03CODEMP {get;set;}
        [MapField("COS03CODACTCONTABLE")]
        public string COS03CODACTCONTABLE {get;set;}
        [MapField("PRO08DESC")]
        public string PRO08DESC { get; set; }
        [MapField("COS03CODLINEAPRODUCCION")]
        public string COS03CODLINEAPRODUCCION {get;set;}
        [MapField("PRO09DESC")]
        public string PRO09DESC { get; set; }
        [MapField("COS03CODACTPRODUCCION")]
        public string COS03CODACTPRODUCCION { get; set; }
        [MapField("COS01DESCRIPCION")]
        public string COS01DESCRIPCION { get; set; }

    }
}
