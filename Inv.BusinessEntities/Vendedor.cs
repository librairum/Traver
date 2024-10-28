using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
     [TableName("FAC56_Vendedor")]
    public class Vendedor
    {
         [MapField("FAC56CODEMP")]
         public string FAC56CODEMP {get;set;}
         [MapField("FAC56COD")]
         public string FAC56COD {get;set;}
	     [MapField("FAC56Nombre")]
         public string FAC56Nombre {get;set;}
          		
	
    }
}
