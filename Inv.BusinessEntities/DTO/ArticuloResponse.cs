using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("In01Arti")]
    public class ArticuloResponse
    {
        [MapField("In04Key")]
        public string Codigo { get; set; }
        [MapField("In01Deslar")]
        public string Descripcion { get; set; }
        [MapField("In01UniMed")]
        public string UnidadMedida { get; set; }
        [MapField("ProductoDescBreve")]
        public string ProductoDescBreve { get; set; }
        [MapField("Color")]
        public string Color { get; set; }
        [MapField("Formato")]
        public string Formato { get; set; }
        [MapField("Acabado")]
        public string Acabado { get; set; }
        [MapField("In01Key")]
        public string In01Key { get; set; }
        [MapField("StockXAlm")]
        public Double StockXAlm { get; set; }
    }
}
