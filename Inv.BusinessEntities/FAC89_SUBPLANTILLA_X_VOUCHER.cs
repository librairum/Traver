using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("FAC89_SUBPLANTILLA_X_VOUCHER")]
    public class FAC89_SUBPLANTILLA_X_VOUCHER
    {
        [MapField("FAC89CODEMP")]
        public string FAC89CODEMP { get; set; }

        [MapField("FAC89TIPDOCCOD")]
        public string FAC89TIPDOCCOD { get; set; }

        [MapField("FAC89SUBPLANTILLACOD")]
        public string FAC89SUBPLANTILLACOD { get; set; }

        [MapField("FAC89CORRELATIVO")]
        public string FAC89CORRELATIVO { get; set; }

        [MapField("FAC89ASIENTOTIPOCOD")]
        public string FAC89ASIENTOTIPOCOD { get; set; }

        [MapField("FAC89DOCMONEDA")]
        public string FAC89DOCMONEDA { get; set; }

        [MapField("FAC89DOCESTADOSUNAT")]
        public string FAC89DOCESTADOSUNAT { get; set; }

        [MapField("FAC89NUMERACIONNOMENCLATURA")]
        public string FAC89NUMERACIONNOMENCLATURA { get; set; }

    }
}
