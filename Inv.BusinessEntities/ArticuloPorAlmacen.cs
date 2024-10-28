using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("in04axal")]

    public class ArticuloPorAlmacen
    {

        [MapField("IN04CODEMP")]
        public string IN04CODEMP { get; set; }

        [MapField("IN04AA")]
        public string IN04AA { get; set; }

        [MapField("IN04MM")]
        public string IN04MM { get; set; }

        [MapField("IN04KEY")]
        public string IN04KEY { get; set; }
        
        [MapField("IN04CODALM")]
        public string IN04CODALM { get; set; }

        [MapField("IN04UBICAC")]
        public string IN04UBICAC { get; set; }

        [MapField("IN04STOMAX")]
        public double IN04STOMAX { get; set; }

        [MapField("IN04STOMIN")]
        public double IN04STOMIN { get; set; }

        [MapField("IN04STOSEG")]
        public double IN04STOSEG { get; set; }

        [MapField("IN04STOREP")]
        public double IN04STOREP { get; set; }
                                                
        [MapField("IN04FECINI")]
        public string IN04FECINI { get; set; }

        [MapField("IN04STOCK")]
        public double IN04STOCK { get; set; }

        [MapField("IN04CANTINGRE")]
        public double IN04CANTINGRE { get; set; }

        [MapField("IN04CANTSALID")]
        public double IN04CANTSALID { get; set; }
                
        [MapField("IN04IMPINGSOL")]
        public double IN04IMPINGSOL { get; set; }

        [MapField("IN04IMPSALSOL")]
        public double IN04IMPSALSOL { get; set; }
        
        [MapField("IN04IMPINGDOL")]
        public double IN04IMPINGDOL { get; set; }
        
        [MapField("IN04IMPSALDOL")]
        public double IN04IMPSALDOL { get; set; }
        
        [MapField("IN04PROMSOL")]
        public double IN04PROMSOL { get; set; }
        
        [MapField("IN04PROMDOL")]
        public double IN04PROMDOL { get; set; }

        [MapField("IN04FECHAING")]
        public string IN04FECHAING { get; set; }
        
        [MapField("IN04FECHASAL")]
        public string IN04FECHASAL { get; set; }

        [MapField("IN04COSTOSOL")]
        public double IN04COSTOSOL { get; set; }
        
        [MapField("IN04COSTODOL")]
        public double IN04COSTODOL { get; set; }

        [MapField("IN04ULTCOSSOL")]
        public double IN04ULTCOSSOL { get; set; }
        
        [MapField("IN04ULTCOSDOL")]
        public double IN04ULTCOSDOL { get; set; }

        [MapField("IN04ULTCANING")]
        public double IN04ULTCANING { get; set; }

        [MapField("IN04ULTCANSAL")]
        public double IN04ULTCANSAL { get; set; }

        // Detalle de sus caracteristicas
        [MapField("IN04FEINFI")]
        public string IN04FEINFI { get; set; }

        [MapField("IN04STINFI")]
        public double IN04STINFI { get; set; }

        [MapField("IN04TMP")]
        public string IN04TMP { get; set; }

        [MapField("IN04STOCKMES")]
        public double IN04STOCKMES { get; set; }

        [MapField("IN04STOCKINICIALMES")]
        public double IN04STOCKINICIALMES { get; set; }

        [MapField("IN04CANTINGINI")]
        public double IN04CANTINGINI { get; set; }

        [MapField("IN04CANTSALINI")]
        public double IN04CANTSALINI { get; set; }

        [MapField("IN04IMPINGINISOL")]
        public double IN04IMPINGINISOL { get; set; }

        [MapField("IN04IMPSALINISOL")]
        public double IN04IMPSALINISOL { get; set; }

        [MapField("IN04IMPINGINIDOL")]
        public double IN04IMPINGINIDOL { get; set; }

        [MapField("IN04IMPSALINIDOL")]
        public double IN04IMPSALINIDOL { get; set; }

        [MapField("IN04PROMINISOL")]
        public double IN04PROMINISOL { get; set; }

        [MapField("IN04PROMINIDOL")]
        public double IN04PROMINIDOL { get; set; }

    }
}