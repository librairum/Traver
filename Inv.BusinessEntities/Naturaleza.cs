using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Naturaleza")]
    public class Naturaleza
    {
        [MapField("IN20COD")]
        public string Codigo { get; set; }

        [MapField("IN20DESCRIPCION")]
        public string Descripcion { get; set; }
        
    
    }
}
