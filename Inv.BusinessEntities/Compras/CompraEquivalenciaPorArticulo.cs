using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    public class CompraEquivalenciaPorArticulo
    {
        [MapField("co21codemp")]
        public string co21codemp {get;set;}

        [MapField("co21ano")]
        public string co21ano {get;set;}
            
        [MapField("co21Articulo")]
        public string  co21Articulo {get;set;}

        [MapField("co21codigo")]
        public string co21codigo {get;set;}

        [MapField("co21descripcion")]
        public string co21descripcion { get; set; }





    }
}
