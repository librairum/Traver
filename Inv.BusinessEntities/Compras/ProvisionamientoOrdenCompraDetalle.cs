using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    //Provisionamiente Factura para OC
    [TableName("co05docu")]
    public class ProvisionamientoOrdenCompraDetalle
    {
        [MapField("CO05CODEMP")]
        public string Empresa { get; set; }

        [MapField("CO05AA")]
        public string Anio { get; set; }
        
        [MapField("CO05MES")]
        public string Mes { get; set; }

        [MapField("CO05TIPO")]
        public string Tipo { get; set; }

        [MapField("CO05CODIGO")]
        public string Codigo { get; set; }

        
        [MapField("CO05TIPDOC")]
        public string TipoDocumento { get; set; }

        [MapField("CO05NRODOC")]
        public string NumeroDocumento { get; set; }

        [MapField("CO05CODCTE")]
        public string CodCte { get; set; }



        [MapField("Co05FECHA")]
        public Nullable<DateTime> Fecha { get; set; }

        [MapField("CO05FECVEN")]
        public Nullable<DateTime> FechaVencimiento { get; set; }

        
        [MapField("Co05Moneda")]
        public string TipoMoneda { get; set; }
        
        [MapField("Co05Estado")]
        public string Estado { get; set; }
        
        [MapField("CO05FLABRO")]
        public string Flabro { get; set; }

        [MapField("CO05PORIGV")]
        public string PorIgv { get; set; }

        [MapField("Co05TC")]
        public double TipoCambio { get; set; }

        [MapField("CO05IMPPAG")]
        public double ImpPag { get; set; }

        [MapField("Importe")]
        public double Importe { get; set; }

        

        [MapField("CO05IMPBRU")]
        public double ImpBruto { get; set; }

        [MapField("CO05IMPINA")]
        public double ImpIna { get; set; }

        [MapField("CO05IMPIGV")]
        public double ImpIgv { get; set; }

        [MapField("CO05IMPSUG")]
        public double ImpSug { get; set; }
       
        [MapField("CO05IMPORT")]
        public double ImpTotal { get; set; }

        [MapField("CO05FECPAG")]
        public Nullable<DateTime> FechaPago { get; set; }

        [MapField("CO05CTA")]
        public string CO05CTA { get; set; }

        [MapField("CO05CCO1")]
        public string CO05CCO1 { get; set; }

        [MapField("CO05CCO2")]
        public string CO05CCO2 { get; set; }



        [MapField("Co05Libro")]
        public string Libro { get; set; }

        [MapField("Co05Numer")]
        public string Voucher { get; set; }

        [MapField("CO05TRACON")]
        public string CO05TRACON { get; set; }

        [MapField("CO05TGAS")]
        public string CO05TGAS { get; set; }

        [MapField("CO05CON")]
        public string CO05CON { get; set; }

        [MapField("CO05INVTIP")]
        public string InvTipo { get; set; }

        

        [MapField("CO05NROREG")]
        public string CO05NROREG { get; set; }

        [MapField("CO05CPTO")]
        public string CO05CPTO { get; set; }

        [MapField("CO05ASITIP")]
        public string CO05ASITIP { get; set; }

        [MapField("CO05INVTRANS")]
        public string CO05INVTRANS { get; set; }

        [MapField("CO05INVFEC")]
        public Nullable<DateTime> CO05INVFEC { get; set; }

        [MapField("co05trainv")]
        public string co05trainv { get; set; }

        [MapField("CO05IMPDOL")]
        public double CO05IMPDOL { get; set; }

        [MapField("CO05IMPBDOL")]
        public double CO05IMPBDOL {get;set;}

        [MapField("CO05IMPINADOL")]
        public double CO05IMPINADOL { get; set; }
        [MapField("CO05IMPIGVDOL")]
        public double CO05IMPIGVDOL {get;set;}

        [MapField("CO05ANIOCOMPRA")]
        public string CO05ANIOCOMPRA { get; set; }


        [MapField("CO05MESCOMPRA")]
        public string CO05MESCOMPRA {get;set;}

        [MapField("CO05ANOORDCOM")]
        public string CO05ANOORDCOM {get;set;}

        [MapField("CO05AFECTODETRACCION")]
        public string CO05AFECTODETRACCION {get;set;}

        [MapField("CO05NROAUTORIZACION")]
        public string CO05NROAUTORIZACION { get; set; }


        [MapField("CO05AFECTORET")]
        public string CO05AFECTORET { get; set; }

        [MapField("CO05DETRATIPOPERACION")]
        public string CO05DETRATIPOPERACION { get; set; }

        [MapField("CO05DETRAPORCENTAJE")]
        public double CO05DETRAPORCENTAJE { get; set; }

        [MapField("CO05DETRAIMPORTE")]
        public double CO05DETRAIMPORTE {get;set;}

        [MapField("CO05DETRAIMPORTE_EQUI")]
        public double CO05DETRAIMPORTE_EQUI {get;set;}

        [MapField("CO05BIENOSERVSUNAT")]
        public string CO05BIENOSERVSUNAT { get; set; }

        [MapField("CO05MESORDCOM")]
        public string CO05MESORDCOM { get; set; }

        [MapField("CO05AREA")]
        public string CO05AREA { get; set; }

        [MapField("CO05DETRATIPOSERVICIO")]
        public string CO05DETRATIPOSERVICIO { get; set; }




        [MapField("Ccm02Nom")]
        public string NombreProveedor { get; set; }


        [MapField("CO05INVNRO")]
        public string CO05INVNRO { get; set; }

        [MapField("EstadoDescripcion")]
        public string EstadoDescripcion { get; set; }
        
        //Propiedad creado solo para hacer el enfoque a la fla del mantenimiento
        [MapField("ColumnaClave")]
        
        public string ColumnaClave { 
       
            get{
                //datos de orden compra                 // Factura
                return Estado + Anio + Mes + Tipo + Codigo + TipoDocumento + NumeroDocumento + CodCte;
            }
            
            
        }


        [MapField("CO05INVREFDOC")]
        public string DocumentoReferencia { get; set; }

        [MapField("CO05CENTRODECOSTO")]
        public string CentroCosto { get; set; }


        [MapField("ccb02des")]
        public string CentroCostoDescripcion { get; set; }


        [MapField("CO05DOCMODTIPO")]
        public string DocModTipo { get; set; }

        [MapField("CO05DOCMODNUMERO")]
        public string DocModNumero { get; set; }


        [MapField("CO05DOCMODFECHA")]
        public Nullable<DateTime> DocModFecha { get; set; }


        [MapField("ESTADOFACTURA")]
        public string EstadoFactura { get; set; }


    }
}
