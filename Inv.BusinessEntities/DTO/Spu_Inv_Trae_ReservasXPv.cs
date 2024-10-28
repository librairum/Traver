using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Inv_Trae_ReservasXPv")]
    public class Spu_Inv_Trae_ReservasXPv
    {
        [MapField("TipoReserva")]
        public string TipoReserva { get; set; }

        [MapField("in07pedvennum")]
        public string in07pedvennum { get; set; }
          
        [MapField("in07pedvenitem")]
        public int in07pedvenitem { get; set; }
        
        [MapField("in07pedvencodprod")]
        public string in07pedvencodprod { get; set; }
        
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
        public double IN07ORDEN { get; set; }
           
        [MapField("IN07CODALM")]
        public string IN07CODALM { get; set; }

        [MapField("IN07UNIMED")]
        public string IN07UNIMED { get; set; }

        [MapField("IN07NROCAJA")]
        public string IN07NROCAJA { get; set; }

        [MapField("IN07CANART")]
        public double IN07CANART { get; set; }

        [MapField("IN07AREAXUNI")]
        public double IN07AREAXUNI { get; set; }

        [MapField("IN07AREA")]
        public double IN07AREA { get; set; }

        [MapField("IN01DESLAR")]
        public string IN01DESLAR { get; set; }

    }
}
