using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("PROVEEDOR")]
    public class Proveedor
    {
        [MapField("ccm02cod")]
        public string Codigo { get; set; }
        [MapField("ccm02nom")]
        public string Nombre { get; set; }
    }
}
