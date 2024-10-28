using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    public class Devolucion
    {
        public string Empresa { get; set; }
        public string Anio { get; set; }
        public string Mes { get; set; }
        public string CodigoTipDoc { get; set; }
        public string DescripcionTipDoc { get; set; }

        public string CodigoDocumento { get; set; }
        public Nullable<DateTime> Fecha { get; set; }
        public string DescripcionTransaccion { get; set; }
        public string NombreCliente { get; set; }
        public string ReferenciaDoc { get; set; }

        public string CodigoProducto {get;set;}
        public string DescripcionProducto {get;set;}
        public double Cantidad {get;set;}
        public string UnidadMedida {get;set;}
        public double Largo {get;set;}
        public double Ancho {get;set;}
        public double Alto {get;set;}
        public string NroCajas {get;set;}
        public double Area {get;set;}

    }
}
