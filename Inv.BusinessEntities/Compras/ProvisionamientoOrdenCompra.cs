using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{

    public class ProvisionamientoOrdenCompra
    {
       [MapField("Co03Tipo")]
        public string TipoOrden {get;set;}
        //O/T
        [MapField("Co03Codigo")]
        public string CodigoOrden {get;set;}
        //#O/C

        [MapField("CO03FECHA")]
        public Nullable<DateTime> Fecha {get;set;}
        //Fecha

        [MapField("Co03Presup")]
        public string Solicitud {get;set;}
        //Solicitud


        [MapField("CO03CODPRO")]
        public string Proveed {get;set;}
        //Proveed

        [MapField("Ccm02Nom")]
        public string NombreProveedor {get;set;}
        //Nombre Proveedor

        [MapField("CO03ESTADO")]
        public string EstadoAtencion {get;set;}
        //Estado Atencion


        [MapField("CO03CANCEL")]
        public string EstadoPago {get;set;}
        //Estado Pago


        [MapField("CO03AA")]
        public string anio {get;set;}
        [MapField("CO03MES")]
        public string mes { get; set; }

        [MapField("CO03TIPMON")]
        public string TipoMoneda { get; set; }

        //Importe Total
        
        [MapField("CO03CAMBIO")]
        public float Cambio {get;set;}

        [MapField("CO03IMPBRU")]
        public float ImporteBruto { get; set; }

        [MapField("CO03DSCTO")]
        public float Descuento { get; set; }

        [MapField("CO03MONIMP")]
        public float MontoImporte { get; set; }

        [MapField("CO03TOTAL")]
        public float Total { get; set; }

        [MapField("CO03IMREGU")]
        public float MontoRegularizar { get; set; }

        public string EstadoAtencionDescripcion { get; set; }
        public string EstadoPagoDescripcion { get; set; }

        [MapField("CO03FORPAG")]
        public string FormaPago { get; set; }
        /*
        lblTipoCambio = fProvOrdCompra.dcOrdenCompra.Resultset("CO03CAMBIO")
        lblImpBruto = fProvOrdCompra.dcOrdenCompra.Resultset("CO03IMPBRU")
        lblImpDscto = fProvOrdCompra.dcOrdenCompra.Resultset("CO03DSCTO")
        lblImpIgv = fProvOrdCompra.dcOrdenCompra.Resultset("CO03MONIMP")
        lblImpTotal = fProvOrdCompra.dcOrdenCompra.Resultset("CO03TOTAL")
        */
    }
}
