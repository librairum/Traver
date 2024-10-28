using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;


namespace Inv.BusinessEntities
{
    [TableName("in29artixalmaxplactas")]
    public class ConfiguraVoucherContable
    {
        [MapField("IN29CODEMP")]
        public string IN29CODEMP { get; set; }

        [MapField("IN29AA")]
        public string IN29AA { get; set; }


        [MapField("IN29CODALM")]
        public string IN29CODALM { get; set; }


        [MapField("in29transaccionCod")]
        public string in29transaccionCod { get; set; }


        [MapField("IN29TIPOARTI")]
        public string IN29TIPOARTI { get; set; }

        [MapField("IN29CTAALMACEN")]
        public string IN29CTAALMACEN { get; set; }

        [MapField("IN29CTAGASTOS")]
        public string IN29CTAGASTOS { get; set; }


        [MapField("IN29CTAVAREXISTENCIAS")]
        public string IN29CTAVAREXISTENCIAS { get; set; }
        
        [MapField("IN29CTANUEVE")]
        public string IN29CTANUEVE { get; set; }

        [MapField("in29CuentaDebe")]
        public string in29CuentaDebe { get; set; }

        [MapField("in29CuentaHaber")]
        public string in29CuentaHaber { get; set; }

        
    }
}
