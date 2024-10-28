using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("FAC60_PACKINGLIST")]
    public class PackingList
    {
        [MapField("FAC60CODEMP")]
        public string Empresa { get; set; }

        [MapField("FAC60NUMERO")]
        public string NumeroDocumento { get; set; }

        [MapField("FAC60AA")]
        public string anio { get; set; }

        [MapField("FAC60MM")]
        public string mes { get; set; }

        [MapField("FAC60FECHA")]
        public Nullable<DateTime> Fecha { get; set; }

        public string FechaTexto { get; set; }

        [MapField("FAC60CLIENTECOD")]
        public string ClienteCodigo { get; set; }
        public string ClienteDesc { get; set; }

        [MapField("FAC60CONTAINERNRO")]
        public string ContainerNro { get; set; }

        
        [MapField("FAC61VENTAUNIMED")]
        public string VentaUnidaMedida { get; set; }

        [MapField("FAC61VENTAPRECIO")]
        public double VentaPrecio { get; set; }

        
        
        [MapField("FAC61VENTASUBTOTAL")]
        public double VentaSubTotal { get; set; }



        [MapField("FAC61ITEM")]
        public int Item { get; set; }

        [MapField("FAC61PRODNROPROFORMACLIENTE")]
        public string Proforma { get; set; }

        [MapField("FAC61PRODCODCLIENTE")]
        public string ProductoCliente { get; set; }

        [MapField("FAC61PRODCODEMPRESA")]
        public string ProductoEmpresa { get; set; }

        [MapField("FAC61PRODDESCRIPCION")]
        public string ProductoDescripcion { get; set; }

        public string ProductoClienteMasEmpresa { get; set; }
        [MapField("FAC61PRODLARGO")]
        public double Largo { get; set; }
        [MapField("FAC61PRODANCHO")]
        public double Ancho { get; set; }

        [MapField("FAC61PRODALTO")]
        public double Alto { get; set; }

        [MapField("FAC61PRODPIEZASXCAJAS")]
        public double PzasxCaja { get; set; }

        [MapField("FAC61PRODCAJASCANTIDAD")]
        public double Cajas { get; set; }

        [MapField("FAC61PRODCANTIDAD")]
        public double Cantidad { get; set; }

        [MapField("FAC61PRODAREA")]
        public double Area { get; set; }

        [MapField("FAC61PRODPESO")]
        public double Peso { get; set; }

        public string XMLDetalle { get; set; }

        [MapField("FAC61SECUENCIA")]
        public int Secuencia { get; set; }

        [MapField("FAC61PRODLARGOTEXTO")]
        public string LargoTexto {get;set;}
        [MapField("FAC61PRODANCHOTEXTO")]
        public string AnchoTexto {get;set;}
        [MapField("FAC61PRODALTOTEXTO")]
        public string AltoTexto { get; set; }

        [MapField("FAC61PEDIDONUM")]
        public string PedidoNumero { get; set; }
        [MapField("FAC61PEDITEM")]
        public int PedidoItem { get; set; }
        [MapField("FAC61OBSERVACIONES")]
        public string Observaciones {get;set;}

        [MapField("FAC60PRECINTONROS")]
        public string PrecintoNros { get; set; }                    
    }
}
