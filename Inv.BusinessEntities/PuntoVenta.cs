using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
     [TableName("FAC55_PuntoVenta")]
    public class PuntoVenta
    {
         [MapField("FAC55CODEMP")]
         public string FAC55CODEMP {get;set;}
         [MapField("FAC55COD")]
         public string FAC55COD {get;set;}
	     [MapField("FAC55DESC")]
         public string FAC55DESC {get;set;}
	
    }
}
