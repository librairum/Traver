using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;


namespace Inv.BusinessEntities
{
    [TableName("ccc")]

    public class Voucher
    {
        [MapField("ccc01emp")]
        public string CodigoEmpresa  {get;set;}

        [MapField("ccc01ano")]
        public string Anio {get;set;}

        [MapField("ccc01mes")]
        public string Mes {get;set;}

        [MapField("ccc01subd")]
        public string libro {get;set;}
        
        [MapField("ccc01numer")]
        public string numero {get;set;}

        [MapField("ccc01fecha")]
        public Nullable<DateTime> fecha {get;set;}

        [MapField("ccc01deta")]
        public string detalle {get;set;}

        [MapField("flag")]
        public string flag {get;set;}

         [MapField("astip")]
        public string astip {get;set;}

        [MapField("trans")]
        public string trans {get;set;}
    }

    [TableName("ccd")]
    public class VoucherDetalle{


        [MapField("ccd01emp")]
        public string CodigoEmpresa { get; set; }

        [MapField("ccd01ano")]
        public string Anio { get; set; }

        [MapField("ccd01mes")]
        public string Mes { get; set; }

        [MapField("ccd01subd")]
        public string libro { get; set; }

        [MapField("ccd01numer")]
        public string NumeroVoucher { get; set; }

        [MapField("ccd01ord")]
        public double orden { get; set; }


        [MapField("ccd01cta")]
        public string cuenta { get; set; }

        [MapField("CtaCbleDesc")]
        public string CtaCbleDesc { get; set; }

        [MapField("ccd01deb")]
        public double ImporteDebe { get; set; }

        [MapField("ccd01hab")]
        public double ImporteHaber { get; set; }

        [MapField("ccd01con")]
        public string glosa { get; set; }

        [MapField("ccd01tipdoc")]
        public string TipoDocumento { get; set; }

        [MapField("TipDocDes")]
        public string TipDocumentoDescrip { get; set; }

        [MapField("CGestionDesc")]
        public string CGestionDescripcion { get; set; }
        
        //public Nullable<DateTime> FechaDoc { get; set; }
        private Nullable<DateTime> fechaDoc;
        [MapField("ccd01fedoc")]
        public Nullable<DateTime> FechaDoc
        {
            get { 
                //if(fechaDoc == "01/01/0000"
                if (fechaDoc == Convert.ToDateTime("1900-01-01 00:00")) {
                    fechaDoc = null;
                }
                return fechaDoc;
            }
            set { fechaDoc = value; }
        }
        

        
        //public Nullable<DateTime> FechaVencimiento { get; set; }
        private Nullable<DateTime> fechaVencimiento;
        [MapField("ccd01feven")]
        public Nullable<DateTime> FechaVencimiento
        {
            get
            {
                if (fechaVencimiento == Convert.ToDateTime("1900-01-01 00:00"))
                {
                    fechaVencimiento = null;
                }
                return fechaVencimiento;
            }
            set { fechaVencimiento = value; }
        }
        


        [MapField("ccd01ana")]
        public string analisis { get; set; }

        [MapField("ccd01cod")]
        public string CuentaCorriente { get; set; }

        [MapField("CtaCteDesc")]
        public string CtaCteDesc { get; set; }
        [MapField("ccd01dn")]
        public string moneda { get; set; }

        [MapField("ccd01tc")]
        public double TipoCambio { get; set; }


        [MapField("ccd01afin")]
        public string Afecto { get; set; }

        [MapField("ccd01cc")]
        public string CenCos { get; set; }

        [MapField("CCostoDesc")]
        public string CCostoDesc { get; set; }

        [MapField("ccd01cg")]
        public string CenGes { get; set; }


        [MapField("ccd01fevou")]        
        public Nullable<DateTime> FechaVoucher { get; set; }

        [MapField("ccd01ama")]
        public string Amarre { get; set; }

        [MapField("ccd01astip")]
        public string AsientoTipo { get; set; }

        [MapField("ccd01val")]
        public string valida { get; set; }

        [MapField("ccd01cd")]
        public string CenDir { get; set; }

        [MapField("ccd01car")]
        public double ImporteDebeEquivalencia { get; set; }

        [MapField("ccd01abo")]
        public double ImporteHaberEquivalencia { get; set; }

        [MapField("ccd01trans")]
        public string transa { get; set; }

        [MapField("ccd01TipoTransaccion")]
        public string TipoTransaccion { get; set; }

        [MapField("ccd01NroDocRetencion")]
        public string NroDocRetencion{ get; set; }


        [MapField("ccd01FechaRetencion")]
        public Nullable<DateTime> FechaRetencion { get; set; }

        [MapField("ccd01AfectoReteccion")]
        public string AfectoRetencion { get; set; }

        [MapField("ccd01FechaPagoRetencion")]
        public Nullable<DateTime> FechaPagoRetencion { get; set; }


        [MapField("ccd01TipoDocRetencion")]
        public string TipoDocRetencion { get; set; }

        [MapField("ccd01NroPago")]
        public string NroPago {get;set;}
        [MapField("ccd01FecPago")]
        public Nullable<DateTime> FechaPago {get;set;}
        [MapField("ccd01porcentaje")]
        public string Porcentaje {get;set;}
        [MapField("ccd01bienoservicio")]
        public string BienoServicio { get; set; }
        
        [MapField("ccd01ndoc")]
        public string NumDoc { get; set; }

        [MapField("AmarreSimbolo")]
        public string AmarreSimbolo { get; set; }


        [MapField("ccm01ana")]
        public string ccm01ana { get; set; }
        [MapField("ccm01cc")]
        public string ccm01cc { get; set; }

        [MapField("ccm01cg")]
        public string ccm01cg { get; set; }

        [MapField("ccm01ColReg")]
        public string ccm01ColReg { get; set; }

        [MapField("ccd01cqmtipo")]
        public string DocModTipo { get; set; }

        [MapField("ccd01cqmnumero")]
        public string DocModNumero { get; set; }

        [MapField("ccd01cqmfecha")]
        public Nullable<DateTime> DocModFecha { get; set; }

        [MapField("ccd01ams")]
        public string flagCuentaDestino { get; set; }

        [MapField("ccd01Comprobante")]
        public string DocComprobante { get; set; }

        [MapField("ccd01aniodua")]
        public string AnioDua { get; set; }

        [MapField("ccd01codmaquina")]
        public string CodigoMaquina { get; set; }
        //NUEVOS
        [MapField("ccd01codtraencurso")]
        public string CodigoTrabajoCurso { get; set; }

        //[MapField("Importecargo")]
        //public double Importecargo { get; set; }

        //[MapField("Importeabono")]
        //public double Importeabono { get; set; }

    }
    //Registro contable llama a tabla Centro Gestion segun Tipo
    [TableName("ccb02cg")]
    public class CentroGestion { 
        [MapField("ccb02cod")]
        public string ccb02cod {get;set;}
        
        [MapField("ccb02des")]
        public string ccb02des { get; set; }
    }

    
    [TableName("ccb13dpe")]

    public class DocumentosPendiente { 
        [MapField("ccb13tipdoc")]
        public string ccb13tipdoc {get;set;}
        [MapField("ccb13ndoc")]
        public string ccb13ndoc {get;set;}
        [MapField("ccb13fedoc")]
        public Nullable<DateTime> ccb13fedoc {get;set;}
        [MapField("ccb13dn")]
        public string ccb13dn {get;set;}
    
    }

}
