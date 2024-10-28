using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{

    [TableName("Spu_Cos_Trae_DistribucionLineaxActApoyo")]
    public class Spu_Cos_Trae_DistribucionLineaxActApoyo
    {
        [MapField("PRO08CODEMP")]
        public string PRO08CODEMP { get; set; }
        [MapField("PRO08COD")]
        public string PRO08COD { get; set; }
        [MapField("PRO08DESC")]
        public string PRO08DESC { get; set; }
        [MapField("COS01TASA")]
        public string COS01TASA { get; set; }
    }
}
