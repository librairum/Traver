using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("In23Responsable")]
    public class Responsable
    {
        [MapField("in23codemp")]
        public string Empresa { get; set; }

        [MapField("In23Codigo")]
        public string Codigo { get; set; }
       
        [MapField("In23Descri")]
        public string Nombre { get; set; }
        
        [MapField("in23tipo")]
        public string Tipo { get; set; }
        
        [MapField("TipoDesc")]
        public string TipoDesc { get; set; }
    }
}
