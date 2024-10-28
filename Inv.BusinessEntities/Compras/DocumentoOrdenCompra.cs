using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    [TableName("co03docu")]
    public class DodcumentoOrdenCompra
    {
        [MapField("CO03CODEMP")]
        public string CodigoEmpresa { get; set; }
        [MapField("CO03AA")]
        public string Anio { get; set; }
        [MapField("CO03MES")]
        public string Mes { get; set; }
        [MapField("CO03TIPO")]
        public string TipoOrdenCompra { get; set; }
        [MapField("CO03CODIGO")]
        public string CodigoOrdenCompra { get; set; }
        [MapField("CO03FECHA")]
        public Nullable<DateTime> FechaOrdenCompra { get; set; }
        [MapField("CO03CODPRO")]
        public string CodigoProveedor { get; set; }
        [MapField("CO03TIDO")]
        public string CO03TIDO { get; set; }
        [MapField("CO03FACTUR")]
        public string CO03FACTUR { get; set; }
        [MapField("CO03NROGUI")]
        public string CO03NROGUI { get; set; }
        [MapField("CO03CODCOM")]
        public string CO03CODCOM { get; set; }
        [MapField("CO03FECFAC")]
        public Nullable<DateTime> CO03FECFAC { get; set; }
        [MapField("CO03FECGUI")]
        public Nullable<DateTime> CO03FECGUI { get; set; }
        [MapField("CO03ALMA")]
        public string CO03ALMA { get; set; }
        [MapField("CO03AREA")]
        public string CentroCosto { get; set; }
        [MapField("CO03FORPAG")]
        public string FormaPago { get; set; }
        [MapField("CO03ASUNTO")]
        public string Atencion { get; set; }
        [MapField("CO03REFER")]
        public string CO03REFER { get; set; }
        [MapField("CO03PRESUP")]
        public string NroSolicitud { get; set; }
        [MapField("CO03FECPRE")]
        public Nullable<DateTime> FechaSolicitud { get; set; }
        [MapField("CO03TIPMON")]
        public string TipoMoneda { get; set; }
        [MapField("CO03CHEQUE")]
        public string GiraCheque { get; set; }
        [MapField("CO03OBSER1")]
        public string CO03OBSER1 { get; set; }
        [MapField("CO03OBSER2")]
        public string CO03OBSER2 { get; set; }
        [MapField("CO03LOCEXT")]
        public string CompLocExt { get; set; }
        [MapField("CO03CAMBIO")]
        public double TipoCambio { get; set; }
        [MapField("CO03FLAIMP")]
        public string FlagImporte { get; set; }
        [MapField("CO03IMPBRU")]
        public double ImporteBruto { get; set; }
        [MapField("CO03DSCTO")]
        public double Descuento { get; set; }
        [MapField("CO03PORIMP")]
        public double ImporteIgv { get; set; }
        [MapField("CO03MONIMP")]
        public double MontoImporte { get; set; }
        [MapField("CO03TOTAL")]
        public double Total { get; set; }
        [MapField("CO03ESTADO")]
        public string Estado { get; set; }
        
        [MapField("EstadoDescripcion")]
        public string EstadoDescripcion { get; set; }

        [MapField("CO03SALDO")]
        public double CO03SALDO { get; set; }
        [MapField("CO03CANCEL")]
        public string FlagCancelado { get; set; }
        [MapField("CO03TRAINV")]
        public string CO03TRAINV { get; set; }
        [MapField("CO03TRACON")]
        public string CO03TRACON { get; set; }
        [MapField("CO03FLAMOV")]
        public string CO03FLAMOV { get; set; }
        [MapField("CO03OBSER3")]
        public string CO03OBSER3 { get; set; }
        [MapField("CO03OBSER4")]
        public string CO03OBSER4 { get; set; }
        [MapField("CO03HOJA")]
        public string CO03HOJA { get; set; }
        [MapField("CO03MONDSC")]
        public double CO03MONDSC { get; set; }
        [MapField("CO03FLAAPR")]
        public string CO03FLAAPR { get; set; }
        [MapField("CO03CODRES")]
        public string CO03CODRES { get; set; }
        [MapField("CO03CODSEC")]
        public string CO03CODSEC { get; set; }
        [MapField("CO03PLAENT")]
        public string PlazoEntrega { get; set; }
        [MapField("CO03CODENTREG")]
        public string CodigoEntrega { get; set; }
        
        [MapField("CO03ENTREG")]
        public string DireccionEntrega { get; set; }
  
        [MapField("CO03DEST1")]
        public string Destino1 { get; set; }
        [MapField("CO03DEST2")]
        public string Destino2 { get; set; }
        [MapField("CO03OBSERV")]
        public string Observacion { get; set; }
        [MapField("CO03TIPDOC")]
        public string CO03TIPDOC { get; set; }
        [MapField("CO03SEGURO_2")]
        public double CO03SEGURO_2 { get; set; }
        [MapField("CO03FOB_2")]
        public double CO03FOB_2 { get; set; }
        [MapField("CO03NROCOT")]
        public string CO03NROCOT { get; set; }
        [MapField("CO03PLAZO")]
        public string CO03PLAZO { get; set; }
        [MapField("Co03FecEnt")]
        public Nullable<DateTime> FechaEntrega { get; set; }
        [MapField("CO03IMPIGV")]
        public double CO03IMPIGV { get; set; }
        [MapField("Co03Igv")]
        public double Co03Igv { get; set; }
        [MapField("CO03USUARIOLOGISTICA")]
        public string UsuarioLogistica { get; set; }
        [MapField("CO03CODAREA")]
        public string CodigoArea { get; set; }
        [MapField("NombreProveedor")]
        public string NombreProveedor { get; set; }

        //datos apra traer datos de la cabera de orden de compra
            [MapField("RucProveedor")]
            public string RucProveedor { get; set; }
            
            [MapField("TelfProveedor")]
            public string TelfProveedor {get;set;}
            [MapField("DireccProveedor")]
            public string DireccProveedor {get;set;}
            [MapField("CentroCostoDesc")]
            public string CentroCostoDesc { get; set; }
            [MapField("FormaPagoDes")]
            public string FormaPagoDes {get;set;}
            [MapField("UsuarioLogisticaDesc")]
            public string UsuarioLogisticaDesc {get;set;}
            [MapField("TipoMonedaDesc")]
            public string TipoMonedaDesc { get; set; }

            [MapField("ccm02nom")]
            public string ccm02nom { get; set; }

    }
}