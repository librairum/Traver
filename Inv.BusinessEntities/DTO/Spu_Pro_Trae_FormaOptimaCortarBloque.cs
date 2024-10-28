using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Pro_Trae_FormaOptimaCortarBloque")]
    public class Spu_Pro_Trae_FormaOptimaCortarBloque
    {
        [MapField("BloqueNro")]
        public string BloqueNro { get; set; }
        
        [MapField("BloqueVolumen")]
        public double BloqueVolumen { get; set; }

        
        [MapField("BloqueAncho")]
        public double BloqueAncho { get; set; }

        [MapField("BloqueLargo")]
        public double BloqueLargo { get; set; }

        [MapField("BloqueEspesor")]
        public double BloqueEspesor { get; set; }


        [MapField("BloqueAreaTotal")]
        public int BloqueAreaTotal { get; set; }

        [MapField("BaldosasAreaMaxima")]
        public int BaldosasAreaMaxima { get; set; }

        [MapField("BaldosasAreaMaximaForma")]
        public string BaldosasAreaMaximaForma { get; set; }

        [MapField("BaldosasAreaMaximaMerma")]
        public int BaldosasAreaMaximaMerma { get; set; }
        
        [MapField("BaldosaMermaRatio")]
        public int BaldosaMermaRatio { get; set; }
    }
}
