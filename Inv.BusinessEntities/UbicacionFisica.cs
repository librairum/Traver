using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("in07ubicacion")]
    public class UbicacionFisica
    {
        [MapField("IN07CODEMP")]
        public string IN07CODEMP { get; set; }
        [MapField("IN07UBICACION")]
        public string IN07UBICACION { get; set; }
        [MapField("IN07NROCAJA")]
        public string IN07NROCAJA { get; set; }
        [MapField("IN07ESTADO")]
        public string IN07ESTADO { get; set; }
        [MapField("IN07FECHA")]
        public DateTime IN07FECHA { get; set; }
        [MapField("IN07USUARIO")]
        public string IN07USUARIO { get; set; }
    }
}
