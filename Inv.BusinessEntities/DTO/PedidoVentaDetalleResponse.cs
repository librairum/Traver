using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    public class PedidoVentaDetalleResponse
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string UnidadMedida { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public double Importe { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}
