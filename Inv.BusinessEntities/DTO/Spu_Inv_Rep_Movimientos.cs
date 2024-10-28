using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Inv_Rep_Movimientos")]
    public class Spu_Inv_Rep_Movimientos
    {
                                                                    

        [MapField("IN07AA")]
        public string IN07AA { get; set; }
        
        [MapField("IN07MM")]
        public string IN07MM { get; set; }

        
        [MapField("IN07TIPDOC")]
        public string IN07TIPDOC { get; set; }

        [MapField("IN07CODDOC")]
        public string IN07CODDOC { get; set; }

        [MapField("IN07KEY")]
        public string IN07KEY { get; set; }

        [MapField("IN07ORDEN")]
        public string IN07ORDEN { get; set; }

        [MapField("IN07UNIMED")]
        public string IN07UNIMED { get; set; }

        [MapField("IN07FECDOC")]
        public Nullable<DateTime> IN07FECDOC { get; set; }

        [MapField("IN07CODALM")]
        public string IN07CODALM { get; set; }

        [MapField("IN07CODTRA")]
        public string IN07CODTRA { get; set; }

        [MapField("IN07NROCAJA")]
        public string IN07NROCAJA { get; set; }

        [MapField("IN07TRANSA")]
        public string IN07TRANSA { get; set; }

        [MapField("IN07CANART")]
        public double IN07CANART { get; set; }

        [MapField("IN07AREAXUNI")]
        public double IN07AREAXUNI { get; set; }

        [MapField("area")]
        public double area { get; set; }

        [MapField("IN07DocIngAA")]
        public string IN07DocIngAA { get; set; }

        [MapField("IN07DocIngMM")]
        public string IN07DocIngMM { get; set; }

        [MapField("IN07DocIngTIPDOC")]
        public string IN07DocIngTIPDOC { get; set; }
        
        [MapField("IN07DocIngCODDOC")]
        public string IN07DocIngCODDOC { get; set; }

        [MapField("IN01DESLAR")]
        public string IN01DESLAR { get; set; }

        [MapField("IN07PEDVEN")]
        public string IN07PEDVEN { get; set; }

        [MapField("IN07ORDPROD")]
        public string IN07ORDPROD { get; set; }

        [MapField("IN07CODCLI")]
        public string IN07CODCLI { get; set; }

        [MapField("clientenombre")]
        public string clientenombre { get; set; }

        [MapField("IN06REFDOC")]
        public string IN06REFDOC { get; set; }
        

    }
}
