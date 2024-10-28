using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
namespace Inv.BusinessEntities
{
    [TableName("Spu_Come_Trae_PackingListTodo")]
    public class Spu_Come_Trae_PackingListTodo
    {
         					
         
         [MapField("FAC60CODEMP")]
         public string codigoEmpresa { get;set; }
         [MapField("FAC60NUMERO")]
         public string   numeroPacking {get;set;}
         [MapField("FAC60AA")]
         public string Anio {get;set;}
         [MapField("FAC60MM")]
         public string Mes {get;set;}
         
         [MapField("FechaTexto")]
         public string FechaTexto {get;set;}
         [MapField("FAC60CLIENTECOD")]
         public string clienteCodigo {get;set;}
         [MapField("ClienteDesc")]
         public string clienteDesc {get;set;}
         [MapField("FechaDespacho")]
	     public string fechaDespacho {get;set;}
         [MapField("NroCajas")]
	     public double nroCajas {get;set;}
	     [MapField("Peso")]
	     public double Peso {get;set;}	
         [MapField("Estado")]
         public string Estado {get;set;}

         [MapField("Cantidad")]
         public double Cantidad {get;set;}

         [MapField("Area")]
         public double Area { get; set; }
         

    }
}
