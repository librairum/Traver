using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("glo01tablas")]
    public class TablaGlobal
    {
        [MapField("glo01codigotabla")]
        public string  glo01codigotabla {get;set;}

        [MapField("glo01codigo")]
        public string glo01codigo {get;set;}

        [MapField("glo01descripcion")]
        public string glo01descripcion {get;set;}

        [MapField("glo01texto1")]
        public string glo01texto1 {get;set;}

        [MapField("glocomentario")]
        public string glocomentario { get; set; }

         //Para tabla de Ubigeo de Factura Electronica
        
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        [MapField("glo02Codigo")]
        public string glo02Codigo { get; set; }
        [MapField("glo02descripcion")]
        public string glo02descripcion { get; set; }

    }
}
