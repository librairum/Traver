using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("PRO11MAQUINA")]
   public  class Maquina
    {

        [MapField("PRO11CODEMP")]
        public string codigoEmpresa {get;set;}
        [MapField("PRO11COD")]
        public string codigo {get;set;}
        [MapField("PRO11DESC")]
        public string descripcion { get; set; }
        [MapField("PRO11ACTIVIDADREL")]
        public string actrelacionada { get; set; }
        [MapField("PRO09DESC")]
        public string descactrelacionada { get; set; }
        //Inventario
        
    }
    [TableName("In20Maquina")]
    public class MaquinaInventario
    { 
        [MapField("In20Codigo")]
        public string codigo {get;set;}
        [MapField("In20Descripcion")]
        public string descripcion { get; set; }
    }
}
