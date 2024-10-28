using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    [TableName("FAC88_EQUIPRODEMPVSPRODSUNAT")]
    public class EquivProdSunat
    {
        [MapField("FAC88CODEMP")]
        public string FAC88CODEMP { get; set; }
        [MapField("FAC88PRODEMPRESA")]
        public string FAC88PRODEMPRESA { get; set; }
        [MapField("FAC88PRODSUNATCODIGO")]
        public string FAC88PRODSUNATCODIGO { get; set; }
        [MapField("TipoCodigo")]
        public string TipoCodigo { get; set; }
        [MapField("TipoDescripcion")]
        public string TipoDescripcion { get; set; }
        [MapField("ProdSunatCodigo")]
        public string ProdSunatCodigo { get; set; }
        [MapField("ProdSunatDescripcion")]
        public string ProdSunatDescripcion { get; set; }
        [MapField("ProdSunatSegmento")]
        public string ProdSunatSegmento { get; set; }
        [MapField("ProdSunatClase")]
        public string ProdSunatClase { get; set; }

    }
}