using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    [TableName("PackingImportar")]
    public class PackingImportar
    {
        [MapField("FAC60CODEMP")]
        public string FAC60CODEMP { get; set; }
        [MapField("FAC60NUMERO")]
        public string FAC60NUMERO { get; set; }
        [MapField("FAC60AA")]
        public string FAC60AA { get; set; }
        [MapField("FAC60MM")]
        public string FAC60MM { get; set; }
        [MapField("FAC60FECHA")]
        //public Nullable<DateTime> FAC60FECHA { get; set; }
        public string FAC60FECHA { get; set; }
        [MapField("FAC60CLIENTECOD")]
        public string FAC60CLIENTECOD { get; set; }
        [MapField("FAC60CONTAINERNRO")]
        public string FAC60CONTAINERNRO { get; set; }
        [MapField("FAC60PRECINTONROS")]
        public string FAC60PRECINTONROS { get; set; }
        [MapField("FAC61ITEM")]
        public int FAC61ITEM { get; set; }
        [MapField("FAC61SECUENCIA")]
        public int FAC61SECUENCIA { get; set; }
        [MapField("FAC61PRODCODCLIENTE")]
        public string FAC61PRODCODCLIENTE { get; set; }
        [MapField("FAC61PRODCODEMPRESA")]
        public string FAC61PRODCODEMPRESA { get; set; }
        [MapField("FAC61PRODDESCRIPCION")]
        public string FAC61PRODDESCRIPCION { get; set; }
        [MapField("FAC61PRODLARGO")]
        public double FAC61PRODLARGO { get; set; }
        [MapField("FAC61PRODANCHO")]
        public double FAC61PRODANCHO { get; set; }
        [MapField("FAC61PRODALTO")]
        public double FAC61PRODALTO { get; set; }
        [MapField("FAC61PRODLARGOTEXTO")]
        public string FAC61PRODLARGOTEXTO { get; set; }
        [MapField("FAC61PRODANCHOTEXTO")]
        public string FAC61PRODANCHOTEXTO { get; set; }
        [MapField("FAC61PRODALTOTEXTO")]
        public string FAC61PRODALTOTEXTO { get; set; }
        [MapField("FAC61PRODPIEZASXCAJAS")]
        public double FAC61PRODPIEZASXCAJAS { get; set; }
        [MapField("FAC61PRODCANTIDAD")]
        public double FAC61PRODCANTIDAD { get; set; }
        [MapField("FAC61PRODCAJASCANTIDAD")]
        public double FAC61PRODCAJASCANTIDAD { get; set; }
        [MapField("FAC61PRODAREA")]
        public double FAC61PRODAREA { get; set; }
        [MapField("FAC61PRODPESO")]
        public double FAC61PRODPESO { get; set; }
        [MapField("FAC61PRODNROPROFORMACLIENTE")]
        public string FAC61PRODNROPROFORMACLIENTE { get; set; }
        [MapField("FAC61PEDIDONUM")]
        public string FAC61PEDIDONUM { get; set; }
        [MapField("FAC61PEDITEM")]
        public int FAC61PEDITEM { get; set; }
        [MapField("FAC61OBSERVACIONES")]
        public string FAC61OBSERVACIONES { get; set; }
        [MapField("FAC61VENTAUNIMED")]
        public string FAC61VENTAUNIMED { get; set; }
        [MapField("FAC61VENTAPRECIO")]
        public double FAC61VENTAPRECIO { get; set; }
        [MapField("FAC61VENTASUBTOTAL")]
        public double FAC61VENTASUBTOTAL { get; set; }
        [MapField("flag")]
        public string flag { get; set; }
        [MapField("errores")]
        public string errores { get; set; }
        [MapField("canterrores")]
        public int canterrores { get; set; }
        [MapField("codigousuario")]
        public string codigousuario { get; set; }
        [MapField("sistema")]
        public string sistema { get; set; }
    }
}