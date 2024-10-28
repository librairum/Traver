using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Inv_Rep_ProvMateriaPrima")]
    public class Spu_Inv_Rep_ProvMateriaPrima
    {

        [MapField("IN06TIPDOC")]
        public string IN06TIPDOC { get; set; }

        [MapField("IN06CODTRA")]
        public string IN06CODTRA { get; set; }

        [MapField("IN06CODPRO")]
        public string IN06CODPRO { get; set; }

        [MapField("IN06MM")]
        public string IN06MM { get; set; }
        

        [MapField("IN07KEY")]
        public string IN07KEY { get; set; }

        [MapField("IN07CODALM")]
        public string IN07CODALM { get; set; }

        [MapField("IN07UNIMED")]
        public string IN07UNIMED { get; set; }
        
        [MapField("IN07CANART")]
        public double IN07CANART { get; set; }

        [MapField("IN07NROCAJA")]
        public string IN07NROCAJA { get; set; }

        [MapField("IN07PROVMATPRIMA")]
        public string IN07PROVMATPRIMA { get; set; }
        
        [MapField("Area")]
        public double Area { get; set; }

        [MapField("IN01DESLAR")]
        public string IN01DESLAR { get; set; }

        [MapField("ProveedorNombre")]
        public string ProveedorNombre { get; set; }
                                                                                                                                                                                                                                                                                                           
    }
}
