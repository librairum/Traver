using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Co05docu")]
    public class ProvisionFactura
    {
        [MapField("CO05CODEMP")]
        public string Empresa {get;set;}
        //CO05CODEMP	varchar
        [MapField("CO05AA")]
        public string Anio {get;set;}

        [MapField("CO05MES")]
        public string Mes {get;set;}

        [MapField("CO05TIPO")]
        public string Tipo {get;set;}

        [MapField("CO05CODIGO")]
        public string Codigo { get; set; }

        [MapField("CO05TIPDOC")]
        public string TipoDocumento { get; set; }


        [MapField("CO05NRODOC")]
        public string NroDoc { get; set; }

        [MapField("CO05CODCTE")]
        public string CodCte {get;set;}

        [MapField("CO05FECHA")]
        public Nullable<DateTime> FechaDocumento { get; set; }

        [MapField("CO05FECVEN")]
        public Nullable<DateTime> FechaVencimiento { get; set; }

        [MapField("CO05IMPORT")]
        public double Importe { get; set; }

        [MapField("CO05TC")]
        public double TipoCambio { get; set; }


        [MapField("CO05MONEDA")]
        public string Moneda
        {
            get;
            set;
        }

        [MapField("CO05ESTADO")]
        public string Estado { get; set; }


        [MapField("CO05FLABRO")]
        public string Flabro { get; set; }

        [MapField("CO05IMPPAG")]
        public double ImpPag { get; set; }

        [MapField("CO05PORIGV")]
        public double PorIgv { get; set; }

        [MapField("CO05IMPBRU")]
        public double ImporteAfecto { get; set; }

        [MapField("CO05IMPINA")]
        public double ImporteInafecto { get; set; }

        [MapField("CO05IMPIGV")]
        public double ImporteIgv { get; set; }

        [MapField("CO05IMPSUG")]
        public double ImpSug { get; set; }

        [MapField("CO05FECPAG")]
        public Nullable<DateTime> FechaPago { get; set; }

        [MapField("CO05CTA")]
        public string Cuenta { get; set; }

        [MapField("CO05LIBRO")]
        public string libro { get; set; }

        [MapField("CO05NUMER")]
        public string NumeroVoucher { get; set; }

        [MapField("CO05TRACON")]
        public string tracon { get; set; }

        [MapField("CO05CON")]
        public string Concepto { get; set; }

        [MapField("CO05INVTIP")]
        public string TipDocGuia { get; set; }

        [MapField("CO05INVNRO")]
        public string NroGuia { get; set; }

        [MapField("CO05INVREFDOC")]
        public string NroDocRef { get; set; }

        [MapField("CO05NROREG")]
        public string NroReg { get; set; }

        [MapField("CO05ASITIP")]
        public string AsientoTipo { get; set; }

        [MapField("CO05INVTRANS")]
        public string TipTransGuia { get; set; }

        [MapField("co05trainv")]
        public Nullable<DateTime> TraInv { get; set; }

        [MapField("Co05InvFec")]
        public string FechaGuia { get; set; }

        [MapField("Co05IMPBDOL")]
        public double ImporteAfDol { get; set; }

        [MapField("Co05IMPINADOL")]
        public double ImporteInafDol { get; set; }

        [MapField("Co05IMPIGVDOL")]
        public double ImporteIgvDol { get; set; }

        [MapField("Co05IMPDOL")]
        public double ImporteDocDol { get; set; }

        [MapField("CO05AFECTORET")]
        public string AfectoRet { get; set; }

        [MapField("CO05ANOORDCOM")]
        public string AnioOrdCom { get; set; }

        [MapField("CO05MESORDCOM")]
        public string MesOrdCom { get; set; }

        [MapField("CO05AFECTODETRACCION")]
        public string AfectoDetraccion { get; set; }

        [MapField("CO05NROAUTORIZACION")]
        public string NroAutorizacion { get; set; }

        [MapField("CO05DETRATIPOPERACION")]
        public string DetraTipoOperacion { get; set; }

        [MapField("CO05DETRATIPOSERVICIO")]
        public string DetraTipoServicio { get; set; }

        

        [MapField("CO05DETRAPORCENTAJE")]
        public double DetraPorcentaje { get; set; }

        [MapField("CO05DETRAIMPORTE")]
        public double DetraImporte { get; set; }

        [MapField("CO05DETRAIMPORTE_EQUI")]
        public double DetraImporte_Equiv { get; set; }

        [MapField("CO05BIENOSERVSUNAT")]
        public string BienesoServicioSunat { get; set; }

        [MapField("CO05CENTRODECOSTO")]
        public string CentroCosto { get; set; }

        [MapField("CO05DOCMODTIPO")]
        public string DocModTipo { get; set; }

        [MapField("CO05DOCMODNUMERO")]
        public string DocModNumero { get; set; }

        [MapField("CO05DOCMODFECHA")]
        public Nullable<DateTime> DocModFecha { get; set; }
    }
}
