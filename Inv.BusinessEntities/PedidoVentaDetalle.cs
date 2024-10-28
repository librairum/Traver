using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    public class PedidoVentaDetalle
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        //public string UnidadMedida { get; set; }
        //public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime FechaEntrega { get; set; }

        [MapField("come01productocantidad")]
        public double Cantidad { get; set; }
        [MapField("come01productopreciosol")]
        public double PrecioSoles { get; set; }
        [MapField("come01productopreciodol")]
        public double PrecioDolar { get; set; }
        [MapField("come01productoimportesol")]
        public double ImporteSoles { get; set; }
        [MapField("come01productoimportedol")]
        public double ImporteDolar { get; set; }
        [MapField("come01productopeso")]
        public double Peso { get; set; }
        [MapField("come01productonrocajas")]
        public double NroCajas { get; set; }
        [MapField("come01tipcambio")]
        public decimal TipoCambio { get; set; }
        [MapField("come01pedvennum")]
        public string Numero { get; set; }
        [MapField("come01pedvencodprod")]
        public string CodigoProducto { get; set; }
        [MapField("come01observaciones")]
        public string Observaciones { get; set; }
        [MapField("come01productounimed")]
        public string UnidadMedida { get; set; }
        [MapField("come01productocodcliente")]
        public string CodigoCliente { get; set; }
        [MapField("come01productodesccliente")]
        public string DescripcionProducto { get; set; }
        [MapField("come01productounimedcliente")]
        public string UnidadMedidaCliente { get; set; }
        [MapField("come01empresa")]
        public string CodigoEmpresa { get; set; }

    }
}
