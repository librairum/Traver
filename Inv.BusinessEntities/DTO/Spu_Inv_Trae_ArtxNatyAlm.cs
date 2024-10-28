using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Inv_Trae_ArtxNatyAlm")]
    public class Spu_Inv_Trae_ArtxNatyAlm
    {

        [MapField("IN01KEY")]
        public string IN01KEY { get; set; }
        
        [MapField("IN01DESLAR")]
        public string IN01DESLAR { get; set; }
        
        [MapField("IN01UNIMED")]
        public string IN01UNIMED { get; set; }
        
        [MapField("tipo")]
        public string tipo { get; set; }
        
        [MapField("color")]
        public string color { get; set; }
        
        [MapField("tonalidad")]
        public string tonalidad { get; set; }

        [MapField("formato")]
        public string formato { get; set; }

        [MapField("acabado")]
        public string acabado { get; set; }
           

        [MapField("relleno")]
        public string relleno { get; set; }

        [MapField("borde")]
        public string borde { get; set; }

        [MapField("modelo")]
        public string modelo { get; set; }
    }
}
