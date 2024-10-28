using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("in12tido")]
    public class TipoDocumento
    {
        [MapField("in12codemp")]
        public string in12codemp { get; set; }
        [MapField("In12tipDoc")]
        public string In12tipDoc { get; set; }
        [MapField("in12TipMov")]
        public string in12TipMov { get; set; }
        [MapField("In12DesLar")]
        public string In12DesLar { get; set; }
        [MapField("in12DesCor")]
        public string in12DesCor { get; set; }
        [MapField("in12WorStr")]
        public string in12WorStr { get; set; }
        [MapField("in12Serie")]
        public string in12Serie { get; set; }
        [MapField("In12NumCon")]
        public string In12NumCon { get; set; }
        [MapField("In12ExigeDevu")]
        public string In12ExigeDevu { get; set; }
        [MapField("in12naturaleza")]
        public string in12naturaleza { get; set; }
        [MapField("in12FlagGeneraDocNum")]
        public string in12FlagGeneraDocNum { get; set; }
        [MapField("in12longitudDocNum")]
        public int in12longitudDocNum { get; set; }


        [MapField("in12flagcalculacosto")]
        public string in12FlagCalCostoPromedio { get; set; }

        [MapField("in12FlagGeneraAsientoContable")]
        public string in12FlagGeneraAsientoContable { get; set; }

    }
}





