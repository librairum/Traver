using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Pro_Traer_OTxLinea")]
    public class Spu_Pro_Traer_OTxLinea
    {
        [MapField("OrdenTrabajo")]
        public string OrdenTrabajo { get; set; }

        [MapField("CodigoProducto")]
        public string CodigoProducto { get; set; }

        [MapField("Descripcion")]
        public string Descripcion { get; set; }

        [MapField("Ancho")]
        public double Ancho { get; set; }

        [MapField("Alto")]
        public double Alto { get; set; }

        [MapField("Espesor")]
        public double Espesor { get; set; }

        [MapField("Color")]
        public string Color { get; set; }

    }
}
