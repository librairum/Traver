using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.BusinessEntities
{
    [TableName("FAC52_PUERTOS")]
    public class Puertos
    {
        [MapField("FAC52CODPUERTO")]
        public string FAC52CODPUERTO {get;set;}

        [MapField("FAC52DESCRIPCION")]
        public string FAC52DESCRIPCION { get; set; }
    }
}
