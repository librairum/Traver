using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;


namespace Inv.BusinessEntities
{

    public class CompraProveedoresPorArticulo
    {
        [MapField("co20codemp")]
        public string co20codemp {get;set;}

        [MapField("co20ano")]
        public string co20ano {get;set;}

        [MapField("co20articulo")]
        public string co20articulo {get;set;}

        [MapField("co20codigo")]
        public string co20codigo {get;set;}

        [MapField("co20descripcion")]
        public string co20descripcion { get; set; }


    }
}
