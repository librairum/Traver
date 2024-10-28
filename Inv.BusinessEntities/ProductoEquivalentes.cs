using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System.Text;

namespace Inv.BusinessEntities
{
    [TableName("FAC20_PRODUCTOPROV")]
    public class ProductoEquivalentes
    {
        [MapField("FAC20CODEMP")]
        public string FAC20CODEMP { get; set; }
        [MapField("FAC20Codigo")]
        public string FAC20Codigo { get; set; }
        [MapField("FAC20PROVCODIGO")]
        public string FAC20PROVCODIGO { get; set; }
        [MapField("FAC20PROVPRODCOD")]
        public string FAC20PROVPRODCOD { get; set; }
        [MapField("FAC20PROVPRODDESC")]
        public string FAC20PROVPRODDESC { get; set; }
        [MapField("FAC20PROVPRODUNIMED")]
        public string FAC20PROVPRODUNIMED { get; set; }

        [MapField("NombreCliente")]
        public string NombreCliente { get; set; }
    }
}
