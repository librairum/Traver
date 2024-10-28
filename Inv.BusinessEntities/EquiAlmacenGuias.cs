using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("In20EquiAlmVSGuias")]
    public class EquiAlmacenGuias
    {
        [MapField("in20empresacod")]
        public string in20empresacod { get; set; }
        [MapField("in20codtraalm")]
        public string in20codtraalm { get; set; }
        [MapField("in20codmotivoguia")]
        public string in20codmotivoguia { get; set; }
        [MapField("MotivoGuiaDesc")]
        public string MotivoGuiaDesc { get; set; }
        [MapField("TranAlmDesc")]
        public string TranAlmDesc { get; set; }
    }
}
	