using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("PRO15MOTIVOS")]
   public class Motivo
    {
        [MapField("PRO15CODEMP")]
        public string PRO15CODEMP {get;set;}
        [MapField("PRO15CODIGO")]
        public string PRO15CODIGO {get;set;}
        [MapField("PRO15DESCRIPCION")]
        public string PRO15DESCRIPCION { get; set; }
    }
}
