using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("SPE_SUMMARYHEADER")]
    public class ResumenDeBoleta
    {
        public string  tipoDocumentoEmisor{get;set;}
        public string numeroDocumentoEmisor {get;set;}
        public string resumenId {get;set;}
        public string fechaEmisionComprobante {get;set;}
        public string  fechaGeneracionResumen  {get;set;}
        public string razonSocialEmisor {get;set;}
        public string correoEmisor {get;set;}
        public string resumenTipo {get;set;}
        

        public string FAC03DESC { get; set; }
        public string FAC04CLAVE { get; set; }
        public string ClienteNombre { get; set; }
        public string DocumentoEstado { get; set; }


        public string numeroFila { get; set; }
        public string tipoDocumento { get; set; }

        public string serieGrupoDocumento { get; set; }
        public string tipoMoneda { get; set; }
        public string tipoMonedaDesc { get; set; }
        public string numeroCorrelativoInicio { get; set; }
        public string numeroCorrelativoFin { get; set; }
        public string totalValorVentaOpGravadaConIgv { get; set; }
        public string totalValorVentaOpExoneradasIgv { get; set; }
        public string totalValorVentaOpInafectasIgv { get; set; }
        public string totalIsc { get; set; }
        public string totalIgv { get; set; }
        public string totalOtrosTributos { get; set; }
        public string totalVenta { get; set; }
        public string totalOtrosCargos { get; set; }

        public string FAC04FECHA { get; set; }
        public string FAC04NUMDOC { get; set; }
        public double FAC04IMPSUBTOTAL { get; set; }
        public double FAC04IMPIGV { get; set; }
        public double FAC04IMPTOTAL { get; set; }
    }
}
