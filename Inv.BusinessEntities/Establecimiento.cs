using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Glo03Establecimientos")]
    public class Establecimiento
    {
        [MapField("Glo03Empresa")]
        public string Glo03Empresa { get; set; }
        [MapField("Glo03codigo")]
        public string Glo03codigo { get; set; }
        [MapField("Glo03Descripcion")]
        public string Glo03Descripcion { get; set; }
    }
}
