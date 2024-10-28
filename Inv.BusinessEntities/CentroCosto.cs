using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("ccb02cc")]
    public class CentroCosto
    {
        [MapField("ccb02cod")]
        public string Codigo { get; set; }
        [MapField("ccb02des")]
        public string Descripcion { get; set; }
    }
}
