using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("COS01LOTECOSTO")]
    public class LoteCosto
    {
        [MapField("COS01CODEMP")]
        public string CodigoEmpresa { get; set; }
        [MapField("COS01ANIO")]
        public string Anio { get; set; }
        [MapField("COS01MES")]
        public string Mes { get; set; }
        [MapField("COS01LINEA")]
        public string CodigoLinea { get; set; }
        [MapField("COS01CODIGO")]
        public string Codigo { get; set; }
        [MapField("COS01DESCRIPCION")]
        public string Descripcion { get; set; }
        [MapField("PRO08DESC")]
        public string DescripcionLinea { get; set; }
    }
}
