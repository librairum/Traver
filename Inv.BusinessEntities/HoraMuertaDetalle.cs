using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    [TableName("PRO01HORAMUERTADETALLE")]
    public class HoraMuertaDetalle
    {

        [MapField("PRO01CODEMP")]
        public string PRO01CODEMP { get; set; }
        [MapField("PRO01DOCMOVAA")]
        public string PRO01DOCMOVAA { get; set; }
        [MapField("PRO01DOCMOVMM")]
        public string PRO01DOCMOVMM { get; set; }
        [MapField("PRO01DOCMOVTIPDOC")]
        public string PRO01DOCMOVTIPDOC { get; set; }
        [MapField("PRO01DOCMOVCODDOC")]
        public string PRO01DOCMOVCODDOC { get; set; }
        [MapField("PRO01DOCMOVKEY")]
        public string PRO01DOCMOVKEY { get; set; }
        [MapField("PRO01DOCMOVORDEN")]
        public double PRO01DOCMOVORDEN { get; set; }

        [MapField("PRO01CORRELATIVO")]
        public int PRO01CORRELATIVO { get; set; }
        [MapField("PRO01CODMOTIVO")]
        public string PRO01CODMOTIVO { get; set; }
        [MapField("PRO01FECHA")]
        public Nullable<DateTime> PRO01FECHA { get; set; }
        [MapField("PRO01HORAINICIO")]
        public string PRO01HORAINICIO { get; set; }
        [MapField("PRO01HORAFIN")]
        public string PRO01HORAFIN { get; set; }
        // Campo Time
        public TimeSpan PRO01HORAINICIO_T { get; set; }
        public TimeSpan PRO01HORAFIN_T { get; set; }

        [MapField("PRO01OBSERVACION")]
        public string PRO01OBSERVACION { get; set; }
        [MapField("PRO01DESCRIPCION")]
        public string PRO01DESCRIPCION { get; set; }

        /*   		
	time	no	5
	time	no	5
	varchar	no	100
         */
    }
}
