using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("COS01ACTIVIDADCONTABLE")]
    public class ActividadesContable
    {

        [MapField("COS01CODEMP")]
        public string COS01CODEMP { get; set; }
        [MapField("COS01CODIGO")]
        public string COS01CODIGO { get; set; }
        [MapField("COS01DESCRIPCION")]
        public string COS01DESCRIPCION { get; set; }
        [MapField("COS01CODTIPO")]
        public string COS01CODTIPO { get; set; }
        [MapField("COS02DESCRIPCION")]
        public string COS02DESCRIPCION { get; set; }
        [MapField("COS01CTACBLE")]
        public string COS01CTACBLE { get; set; }        
    }
}
