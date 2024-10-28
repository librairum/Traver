using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("ccm01cta")]
    public class CuentaContable
    {
        //  Ayuda de cuenta corriente
        [MapField("ccm01cta")]
        public string ccm01cta { get; set; }

        [MapField("ccm01des")]
        public string ccm01des { get; set; }

        [MapField("ccm01dn")]
        public string ccm01dn { get; set; }

        [MapField("ccm01mov")]
        public string ccm01mov { get; set; }


        //campos flag 
        [MapField("ccm01ana")]
        public string ccm01ana { get; set; }

        [MapField("ccm01cc")]
        public string ccm01cc { get; set; }

        [MapField("ccm01cg")]
        public string ccm01cg { get; set; }
    }
}
