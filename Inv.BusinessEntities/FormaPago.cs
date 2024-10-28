using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
//using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.BusinessEntities
{
    [TableName("FAC53_FORMAPAGO")]
    public class FormaPago
    {
        [MapField("FAC53COD")]
        public string FAC53COD {get;set;}
        [MapField("FAC53DESC")]
        public string FAC53DESC {get;set;}
        [MapField("FAC53DESCEEUU")]
        public string FAC53DESCEEUU {get;set;}
        [MapField("FAC53DIAS")]
        public int FAC53DIAS { get; set; }
        
        //Modulo Compras
        // Campos de la tabla Forma de Pago
        [MapField("Co02Codemp")]
        public string Co02Codemp {get;set;}
        
        [MapField("Co02codigo")]
        public string Co02codigo {get;set;}
        
        [MapField("Co02descripcion")]
        public string Co02descripcion {get;set;}

        [MapField("co02dias")]
        public string co02dias { get; set; }

    }
}
