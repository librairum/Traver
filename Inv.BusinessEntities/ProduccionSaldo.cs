using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("COS02PRODUCCIONSALDOINICIAL")]
    public class ProduccionSaldo
    {

        [MapField("COS02CODEMP")]
        public string COS02CODEMP { get; set; }
        [MapField("COS02ANIO")]
        public string COS02ANIO { get; set; }
        [MapField("COS02MES")]
        public string COS02MES { get; set; }
        [MapField("COS02ALMACOD")]
        public string COS02ALMACOD { get; set; }
        [MapField("COS02PRODCOD")]
        public string COS02PRODCOD { get; set; }
        [MapField("COS02PRODCANTIDAD")]
        public double COS02PRODCANTIDAD { get; set; }
        [MapField("COS02PRODAREA")]
        public double COS02PRODAREA { get; set; }
        [MapField("COS02PRODVOLUMEN")]
        public double COS02PRODVOLUMEN { get; set; }
        [MapField("COS02PRODIMPSOL")]
        public double COS02PRODIMPSOL { get; set; }
        [MapField("COS02LINEACOD")]
        public string COS02LINEACOD { get; set; }
        [MapField("COS02ACTCOD")]
        public string COS02ACTCOD { get; set; }
        [MapField("COS01FLAG")]
        public string COS01FLAG { get; set; }
        [MapField("COS01ERRORES")]
        public string COS01ERRORES { get; set; }
        [MapField("COS01CANTERRORES")]
        public int COS01CANTERRORES { get; set; }
        [MapField("COS01CODIGOUSUARIO")]
        public string COS01CODIGOUSUARIO { get; set; }
        [MapField("COS01SISTEMA")]
        public string COS01SISTEMA { get; set; }

    }
}
