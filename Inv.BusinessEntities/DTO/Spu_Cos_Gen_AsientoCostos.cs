using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Cos_Gen_AsientoCostos")]
    public class Spu_Cos_Gen_AsientoCostos
    {
        [MapField("Empresa")]
        public string Empresa { get; set; }
        
        [MapField("Asiento")]
        public string Asiento { get; set; }

        [MapField("Motivo")]
        public string Motivo { get; set; }

        [MapField("Debe")]
        public double Debe { get; set; }

        [MapField("Haber")]
        public double Haber { get; set; }

    }
}
