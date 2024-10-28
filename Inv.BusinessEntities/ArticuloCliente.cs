using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;


namespace Inv.BusinessEntities
{
    //In20artiClientes
     [TableName("In20artiClientes")]
    public class ArticuloCliente
    {

        [MapField("In20codemp")]
         public string In20codemp{get;set;}
        [MapField("In20clientecod")]
         public string In20clientecod{get;set;}
        [MapField("In20Codigo")]
         public string In20Codigo{get;set;}
        [MapField("In20Descripcion")]
         public string In20Descripcion{get;set;}
        [MapField("In20Familia")]
         public string In20Familia{get;set;}
        [MapField("In20UndMed")]
         public string In20UndMed{get;set;}
        [MapField("In20Formato")]
         public string In20Formato {get;set;}
        [MapField("In20Color")]
         public string In20Color{get;set;}
        [MapField("In20Pulido")]
         public string In20Pulido{get;set;}
        [MapField("In20Relleno")]
         public string In20Relleno{get;set;}
        [MapField("In20Comentario")]
         public string In20Comentario{get;set;}
        [MapField("In20Especial")]
         public string In20Especial{get;set;}
        [MapField("In20Especial1")]
         public string In20Especial1 {get;set;}
        [MapField("In20UndxCaja")]
         public double In20UndxCaja{get;set;}
        [MapField("In20PiezasxCaja")]
         public int In20PiezasxCaja{get;set;}
        [MapField("In20estado")]
         public string In20estado{get;set;}
        [MapField("In20CodigoPropio")]
        public string In20CodigoPropio { get; set; }
        [MapField("NombreCliente")]
        public string NombreCliente { get; set; }
    }
}
