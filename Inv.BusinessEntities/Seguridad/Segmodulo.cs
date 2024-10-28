using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;

namespace Inv.BusinessEntities
{
    [TableName("segmodulo")]
    public class Segmodulo
    {

        [MapField("Codigo")]
        public int Codigo { get; set; }
        [MapField("Nombre")]
        public string Nombre { get; set; }

    }
}
