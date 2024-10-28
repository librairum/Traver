using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Inv_Traer_CantidadProductoxNaturaleza")]
    public class ProductosNaturaleza
    {
        [MapField("Cantidad")]
        public int Cantidad { get; set; }

        [MapField("in01aa")]
        public string in01aa {get;set;}

        [MapField("Naturaleza")]
        public string Naturaleza { get; set; }

    }
}
