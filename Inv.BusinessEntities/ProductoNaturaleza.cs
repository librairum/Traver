using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("IN20PRODUCTONATURALEZA")]
    public class ProductoNaturaleza
    {        
        [MapField("IN20CODEMP")]
        public string codigoEmpresa {get;set;}
        [MapField("IN20COD")]
        public string codigo {get;set;}
        [MapField("IN20DESCRIPCION")]
        public string descripcion {get;set;}
        
    }
}
