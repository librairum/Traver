using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.BusinessEntities
{
    [TableName("FAC51_PAISES")]
    public class Paises
    {
        [MapField("FAC51CODPAIS")]
        public string FAC51CODPAIS {get;set;}

        [MapField("FAC51DESCRIPCION")]
        public string FAC51DESCRIPCION { get; set; }
    }
}
