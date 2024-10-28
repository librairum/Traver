using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("COS02ACTIVIDADCONTABLETIPO")]    
    public class ActividadContableTipo
    {
        [MapField("COS02CODIGO")]
        public string COS02CODIGO { get; set; }

        [MapField("COS02DESCRIPCION")]
        public string COS02DESCRIPCION { get; set; }
    }
}
