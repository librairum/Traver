using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("in15tran")]
    public class TipoTransaccion
    {
        [MapField("in15codemp")]
        public string in15codemp { get; set; }
        [MapField("in15Codigo")]
        public string in15Codigo { get; set; }
        [MapField("in15Descripcion")]
        public string in15Descripcion { get; set; }
        [MapField("in15TipoMovimiento")]
        public string in15TipoMovimiento { get; set; }
        [MapField("in15Valorizado")]
        public string in15Valorizado { get; set; }
        [MapField("in15Liquidacion")]
        public string in15Liquidacion { get; set; }
        [MapField("in15ctactetipana")]
        public string in15ctactetipana { get; set; }
    }
}
