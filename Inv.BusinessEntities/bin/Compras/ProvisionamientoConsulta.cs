using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    /*
     Consulta de Factura con orden de compra
     */
    public class ProvisionamientoConsulta
    {
        [MapField("CO05CODIGO")]
        public string DCompra {get;set;}

        [MapField("CO05CODCTE")]
        public string Proveedor  {get;set;}

        [MapField("Ccm02Nom")]
        public string NombreProveedor {get;set;}

        [MapField("Co05Tipdoc")]
        public string Tipo  {get;set;}

        [MapField("Co05NroDoc")]
        public string NroDocumento { get; set; }


        [MapField("CO05MONEDA")]
        public string Moneda { get; set; }


        [MapField("CO05FECHA")]
        public string Fecha { get; set; }

        [MapField("Co05Estado")]
        public string Estado { get; set; }

        [MapField("Co05Libro")]
        public string Libro { get; set; }

        [MapField("CO05NUMER")]
        public string NroVoucher { get; set; }

        [MapField("CO05IMPORT")]
        public double ImporteSoles { get; set; }

        [MapField("CO05IMPDOL")]
        public double ImporteDolares { get; set; }


        [MapField("CO05ASITIP")]
        public string AsientoTipo { get; set; }

/*
ccm02nom	varchar	100
CO05CODIGO	varchar	5
CO05TIPDOC	varchar	2
CO05NRODOC	varchar	12
CO05CODCTE	varchar	11
CO05FECHA	datetime	NULL
CO05IMPORT	float	NULL
CO05MONEDA	varchar	1
CO05ESTADO	varchar	1
CO05LIBRO	varchar	2
CO05NUMER	varchar	10
CO05ASITIP	varchar	6
CO05IMPDOL	float	NULL

CO05CODIGO
D.Compra
    

CO05CODCTE
Proveedor


Ccm02Nom
Nombre Proveedor

Co05Tipdoc
Tipo


Co05NroDoc
Nº Documento


CO05MONEDA
Moneda


CO05FECHA
Fecha


Co05Estado
Estado

Co05Libro
Libro


CO05NUMER
Nº Voucher


CO05IMPORT
Importe (S/.)


CO05IMPDOL
Importe (US$)


CO05ASITIP
ATipo

        */
    }
}
