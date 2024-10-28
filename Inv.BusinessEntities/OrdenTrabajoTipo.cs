using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("PRO01ORDENTRABAJOTIPO")]
    public class OrdenTrabajoTipo
    {
        [MapField("PRO01CODEMP")]
        public string PRO01CODEMP {get;set;}
        [MapField("PRO01CODIGO")]
         public string PRO01CODIGO {get;set;}
        [MapField("PRO01DESCRIPCION")]
        public string PRO01DESCRIPCION { get; set; }

	
	
    }
}
