using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Inv_Trae_ConciliaAlmConGuias")]
    public class Spu_Inv_Trae_ConciliaAlmConGuias
    {
	
        [MapField("AlmacenTranCod")]
        public string AlmacenTranCod { get; set; }
        
        [MapField("AlmacenTranDesc")]
        public string AlmacenTranDesc { get; set; }
        
        [MapField("AlmacenCantMT2")]
        public double AlmacenCantMT2 { get; set; }

        [MapField("AlmacenCantOtraUniMed")]
        public double AlmacenCantOtraUniMed { get; set; }

        [MapField("GuiaMovTraCod")]
        public string GuiaMovTraCod { get; set; }

        [MapField("GuiaMovTraDesc")]
        public string GuiaMovTraDesc { get; set; }

        [MapField("GuiaCantMT2")]
        public double GuiaCantMT2 { get; set; }

        [MapField("GuiaCantOtraUniMed")]
        public double GuiaCantOtraUniMed { get; set; }

        [MapField("DiferenciaCantMT2")]
        public double DiferenciaCantMT2 { get; set; }

        [MapField("DiferenciaCantOtraUniMed")]
        public double DiferenciaCantOtraUniMed { get; set; }
    }
}
