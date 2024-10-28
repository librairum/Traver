using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("co01Serviciodetraccion")]
    public class ServicioDetraccion
    {
        [MapField("co01codigo")]
        public string Codigo {get;set;}

        [MapField("co01correlativo")]
        public int Correlativo {get;set;}

        [MapField("co01descripcion")]
        public string Descripcion {get;set;}

        [MapField("co01Tasaretencion")]
        public double TasaRetencion {get;set;}

        [MapField("co01fechadesde")]
        public Nullable<DateTime> FechaDesde {get;set;}

        [MapField("co01fechahasta")]
        public Nullable<DateTime> FechaHasta {get;set;}

    }
}
