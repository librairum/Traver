using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("IN20CANTERA")]
    public class Canteras
    {        
        [MapField("IN20CODEMP")]
        public string IN20CODEMP {get; set;}
        
        [MapField("IN20CODIGO")]
        public string IN20CODIGO {get;set;}
        
        [MapField("IN20DESC")]
        public string IN20DESC { get; set; }
        
        [MapField("IN20CODPROVEEDOR")]
        public string IN20CODPROVEEDOR { get; set; }
        
        public string NOMPROV { get; set; }
    }
}
