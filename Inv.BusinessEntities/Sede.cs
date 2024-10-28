using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
            [TableName("come05sedesCliente")]
    public class Sede
    {
                [MapField("come05empresa")]
                public string come05empresa { get; set; }
                [MapField("come05clientetipana")]
                public string come05clientetipana{get;set;}
                [MapField("come05clientecod")]
                public string come05clientecod{get;set;}
                [MapField("come05sedeclientescod")]
                public string come05sedeclientescod{get;set;}
                [MapField("come05sedeclientesdesc")]
                public string come05sedeclientesdesc{get;set;}
                [MapField("come05sedeclientesdireccion")]
                public string come05sedeclientesdireccion{get;set;}
                [MapField("come05sedeclientesreferencia")]
                 public string come05sedeclientesreferencia { get; set; }

                [MapField("come05DepCod")]
                public string come05DepCod { get; set; }
                [MapField("come05ProvCod")]
                public string come05ProvCod { get; set; }
                [MapField("come05DistCod")]
                public string come05DistCod { get; set; }
                [MapField("come05FlagDimiFiscal")]
                public string come05FlagDimiFiscal { get; set; }
                [MapField("come05PuertoCod")]
                public string come05PuertoCod { get; set; }

                [MapField("DptoDescripcion")]
                public string DptoDescripcion { get; set; }
                [MapField("ProvDescripcion")]
                public string ProvDescripcion { get; set; }
                [MapField("DistDescripcion")]
                public string DistDescripcion { get; set; }
                [MapField("PuertoDescripcion")]
                public string PuertoDescripcion { get; set; }
                
                    
               
    }
}
