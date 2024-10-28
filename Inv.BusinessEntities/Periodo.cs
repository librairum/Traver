using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("ccb03per")]
    public class Periodo
	{
        [MapField("ccb03tc")]
        public double ccb03tc { get; set; }
        [MapField("ccb03ipm")]
        public double ccb03ipm { get; set; }
        [MapField("ccb03cms")]
        public double ccb03cms { get; set; }
        [MapField("ccb03cmd")]
        public double ccb03cmd { get; set; }
        [MapField("ccb03fa00")]
        public double ccb03fa00 { get; set; }
        [MapField("ccb03fa01")]
        public double ccb03fa01 { get; set; }
        [MapField("ccb03InvClose")]
        public double ccb03InvClose { get; set; }
        [MapField("ccb03fa08")]
        public double ccb03fa08 { get; set; }
        [MapField("ccb03fa09")]
        public double ccb03fa09 { get; set; }
        [MapField("ccb03fa10")]
        public double ccb03fa10 { get; set; }
        [MapField("ccb03fa11")]
        public double ccb03fa11 { get; set; }
        [MapField("ccb03fa12")]
        public double ccb03fa12 { get; set; }
        [MapField("ccb03FacClose")]
        public double ccb03FacClose { get; set; }
        [MapField("ccb03fa02")]
        public double ccb03fa02 { get; set; }
        [MapField("ccb03fa03")]
        public double ccb03fa03 { get; set; }
        [MapField("ccb03fa04")]
        public double ccb03fa04 { get; set; }
        [MapField("ccb03fa05")]
        public double ccb03fa05 { get; set; }
        [MapField("ccb03fa06")]
        public double ccb03fa06 { get; set; }
        [MapField("ccb03fa07")]
        public double ccb03fa07 { get; set; }
        [MapField("ccb03proc")]
        public bool ccb03proc { get; set; }
        [MapField("ccb03conc")]
        public bool ccb03conc { get; set; }
        [MapField("ccb03emp")]
        public string ccb03emp { get; set; }
        [MapField("ccb03cod")]
        public string ccb03cod { get; set; }
        [MapField("ccb03des")]
        public string ccb03des { get; set; }
        [MapField("ccb03CtaClose")]
        public string ccb03CtaClose { get; set; }
        
        // Campos adicionales
        [MapField("PeriodoEstado")]
        public string PeriodoEstado { get; set; }


	}
}
