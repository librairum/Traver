using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Inv_Trae_PtXPedVenta")]
    public class Spu_Inv_Trae_PtXPedVenta
    {

        [MapField("come01pedvencodprod")]
        public string come01pedvencodprod { get; set; }
        
        [MapField("come01pedvenitem")]
        public double come01pedvenitem { get; set; }
        
        [MapField("come01prodcantequiprod")]
        public double come01prodcantequiprod { get; set; }
        
        [MapField("IN01DESLAR")]
        public string IN01DESLAR { get; set; }

        [MapField("in01unimed")]
        public string in01unimed { get; set; }
        
    }
}
