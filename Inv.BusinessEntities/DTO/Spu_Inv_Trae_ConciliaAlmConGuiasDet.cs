using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Inv_Trae_ConciliaAlmConGuiasDet")]
    public class Spu_Inv_Trae_ConciliaAlmConGuiasDet
    {
        						

        [MapField("AlmacenGuia")]
        public string AlmacenGuia { get; set; }
        
        [MapField("CantidadMT2")]
        public double CantidadMT2 { get; set; }
        
        [MapField("CantidadOtraUniMed")]
        public double CantidadOtraUniMed { get; set; }

        [MapField("Guia_Nro")]
        public string Guia_Nro { get; set; }

        [MapField("Guia_Estado")]
        public string Guia_Estado { get; set; }

        [MapField("GuiaCantidadMT2")]
        public double GuiaCantidadMT2 { get; set; }

        [MapField("GuiaCantidadOtraUniMed")]
        public double GuiaCantidadOtraUniMed { get; set; }

        
    }
}
