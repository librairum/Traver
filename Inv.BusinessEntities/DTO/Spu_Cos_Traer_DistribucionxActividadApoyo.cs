using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Cos_Traer_DistribucionxActividadApoyo")]
    public class Spu_Cos_Traer_DistribucionxActividadApoyo
    {
        [MapField("CODCTAAPOYO")]
        public string CODCTAAPOYO { get; set; }
        [MapField("DESCTAAPOYO")]
        public string DESCTAAPOYO { get; set; }
        [MapField("CODCTAPRINCIPAL")]
        public string CODCTAPRINCIPAL { get; set; }
        [MapField("DESCTAPRINCIPAL")]
        public string DESCTAPRINCIPAL { get; set; }
        [MapField("COS01TASA")]
        public double COS01TASA { get; set; }
    }
}
