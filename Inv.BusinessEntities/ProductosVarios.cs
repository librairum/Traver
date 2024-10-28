using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    [TableName("FAC11_PRODUCTOSVARIOS")]
    public class ProductosVarios
    {
        [MapField("FAC11CODEMP")]
        public string FAC11CODEMP { get; set; }
        [MapField("FAC11PRODCOD")]
        public string FAC11PRODCOD { get; set; }
        [MapField("FAC11PRODDESC")]
        public string FAC11PRODDESC { get; set; }
        [MapField("FAC11PRODUNIMED")]
        public string FAC11PRODUNIMED { get; set; }
        [MapField("FAC11PRODUNIMEDDESCRIPCION")]
        public string FAC11PRODUNIMEDDESCRIPCION { get; set; }
        [MapField("FAC11PRODCODSUNAT")]
        public string FAC11PRODCODSUNAT { get; set; }
        [MapField("FAC11SERVCODSUNATDESCRIPCION")]
        public string FAC11SERVCODSUNATDESCRIPCION { get; set; }
    }
}