using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.BusinessEntities
{
    [TableName("co01Serviciodetraccion")]
    public class Detraccion
    {
        [MapField("co01codigo")]
        public string Codigo { get; set; }
        [MapField("co01descripcion")]
        public string Descripcion { get; set; }
        [MapField("co01Tasaretencion")]
        public double Porcentaje { get; set; }
        public double Importe { get; set; }
    }
}
