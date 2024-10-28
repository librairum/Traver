using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{

    [TableName("ccc03astip")]
    public class ComprasAsientoTipo
    {
        public string ccc03cod { get; set; }
        public string ccc03des { get; set; }
        //MODIFICADO 512
        public string ccc03lib { get; set; }
    }
   
      
    [TableName("ccd03astip")]
    public class ComprasAsientoTipoDetalle
    {
        [MapField("ccd03cod")]
        public string ccd03cod { get; set; }

        

        [MapField("ccd03ord")]
        public short ccd03ord { get; set; }

        [MapField("ccd03cta")]
        public string ccd03cta { get; set; }


        //ccd03emp	varchar
//ccd03cod	varchar
//ccd03ord	smallint
//ccd03cta	varchar
        [MapField("ccd03afin")]
        public string ccd03afin { get; set; }
        [MapField("ccd03ca")]
        public string ccd03ca { get; set; }
//ccd03afin	varchar
//ccd03ca	varchar
//ccd03req	varchar
        [MapField("ccd03mul")]
        public string ccd03mul { get; set; }

//ccd03mul	varchar
            [MapField("ccd03def")]
        public string ccd03def { get; set; }
//ccd03def	varchar
        [MapField("ccd03porcen")]
            public float ccd03porcen { get; set; }
//ccd03porcen	float
        
 
    }
}
