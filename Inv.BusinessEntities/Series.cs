using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
namespace Inv.BusinessEntities
{
    [TableName("FAC07_SERIES")]
   public class Series
    {
        [MapField("FAC07CODEMP")]
        public string FAC07CODEMP { get; set; }
        
        [MapField("FAC01COD")]
        public string FAC01COD { get; set; }
        
        [MapField("FAC07SERIE")]
        public string FAC07SERIE { get; set; }
        
        [MapField("FAC07DESC")]
        public string FAC07DESC { get; set; }

        [MapField("FAC07ABREVIA")]
        public string FAC07ABREVIA { get; set; }

        [MapField("FAC07NUMERO")]
        public string FAC07NUMERO { get; set; }

        [MapField("FAC07AESTABLECIMIENTOCOD")]
        public string FAC07AESTABLECIMIENTOCOD { get; set; }

        //descripcion de tipo documento
        [MapField("FAC01DESC")]
        public string FAC01DESC { get; set; }


    }
}
