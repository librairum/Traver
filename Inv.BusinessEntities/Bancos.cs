using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;


namespace Inv.BusinessEntities
{
    [TableName("FAC50_BANCOS")]
    public class Bancos
    {
        [MapField("FAC50CODBANCO")]
        public string FAC50CODBANCO {get;set;}
        [MapField("FAC50DESCRIPCION")]
        public string FAC50DESCRIPCION {get;set;}
        [MapField("FAC50BANKCODE")]
        public string FAC50BANKCODE {get;set;}
        [MapField("FAC50ACOUNTNUMBER")]
        public string FAC50ACOUNTNUMBER { get; set; }
    }
}
