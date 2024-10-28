using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Fact_Trae_Por_Periodo")]
    public class Spu_Fact_Trae_Por_Periodo
    {
        [MapField("FAC04CODEMP")]
        public string FAC04CODEMP { get; set; }
        [MapField("FAC01COD")]
        public string FAC01COD { get; set; }
        [MapField("FAC04NUMDOC")]
        public string FAC04NUMDOC { get; set; }
        [MapField("FAC04AA")]
        public string FAC04AA { get; set; }
        [MapField("FAC04MM")]
        public string FAC04MM { get; set; }
        [MapField("FAC04NRODOC")]
        public string FAC04NRODOC { get; set; }
        [MapField("FAC04SERIEDOC")]
        public string FAC04SERIEDOC { get; set; }
        [MapField("FAC04FECHA")]
        public Nullable<DateTime> FAC04FECHA { get; set; }
        [MapField("FAC04TIPANA")]
        public string FAC04TIPANA { get; set; }
        [MapField("FAC04CODCLI")]
        public string FAC04CODCLI { get; set; }
        [MapField("FAC04MONEDA")]
        public string FAC04MONEDA { get; set; }
        [MapField("FAC04TIPCAMBIO")]
        public double FAC04TIPCAMBIO { get; set; }
        [MapField("FAC04DONSUBTOTAL")]
        public double FAC04DONSUBTOTAL { get; set; }
        [MapField("FAC04DONIGV")]
        public double FAC04DONIGV { get; set; }
        [MapField("FAC04DONTOTAL")]
        public double FAC04DONTOTAL { get; set; }
        [MapField("FAC03COD")]
        public string FAC03COD { get; set; }
        [MapField("FAC02COD")]
        public string FAC02COD { get; set; }
        [MapField("FAC04CLINOMBRE")]
        public string FAC04CLINOMBRE { get; set; }
        [MapField("FAC04CLIDIRECCION")]
        public string FAC04CLIDIRECCION { get; set; }
        [MapField("FAC04CLIRUC")]
        public string FAC04CLIRUC { get; set; }
        [MapField("FAC04GLOSA")]
        public string FAC04GLOSA { get; set; }
        [MapField("FAC04DONGLAG")]
        public string FAC04DONGLAG { get; set; }
        [MapField("FAC04IGV")]
        public double FAC04IGV { get; set; }
        [MapField("FAC04IMPSUBTOTAL")]
        public double FAC04IMPSUBTOTAL { get; set; }
        [MapField("FAC04IMPIGV")]
        public double FAC04IMPIGV { get; set; }
        [MapField("FAC04IMPTOTAL")]
        public double FAC04IMPTOTAL { get; set; }
        [MapField("FAC04GUIAS")]
        public string FAC04GUIAS { get; set; }
        [MapField("FAC04DOCMODTIPDOC")]
        public string FAC04DOCMODTIPDOC { get; set; }
        [MapField("FAC04DOCMODNRO")]
        public string FAC04DOCMODNRO { get; set; }
        [MapField("FAC04DOCMODFECHA")]
        public Nullable<DateTime> FAC04DOCMODFECHA { get; set; }
        [MapField("FAC03TIPART")]
        public string FAC03TIPART { get; set; }
        [MapField("FAC04TIPMOTEMI")]
        public string FAC04TIPMOTEMI { get; set; }
        [MapField("FAC04TIPMOTEMIDES")]
        public string FAC04TIPMOTEMIDES { get; set; }
        [MapField("FAC04ESTADODOC")]
        public string FAC04ESTADODOC { get; set; }
        [MapField("FAC04CONTASIENTOTIPO")]
        public string FAC04CONTASIENTOTIPO { get; set; }
        [MapField("FAC04CONTLIBRO")]
        public string FAC04CONTLIBRO { get; set; }
        [MapField("FAC04CONTVOUCHER")]
        public string FAC04CONTVOUCHER { get; set; }
        [MapField("FAC04ESTADOCONTABLE")]
        public string FAC04ESTADOCONTABLE { get; set; }
        [MapField("FAC04ATENCIONESGLAG")]
        public string FAC04ATENCIONESGLAG { get; set; }
        [MapField("FAC04FETIPONOTA")]
        public string FAC04FETIPONOTA { get; set; }
        [MapField("FAC04EXPCODPAISORIGEN")]
        public string FAC04EXPCODPAISORIGEN { get; set; }
        [MapField("FAC04EXPCODPAISDESTINO")]
        public string FAC04EXPCODPAISDESTINO { get; set; }
        [MapField("FAC04EXPCODCONDPAGO")]
        public string FAC04EXPCODCONDPAGO { get; set; }
        [MapField("FAC04EXPCODCONDDESPACHO")]
        public string FAC04EXPCODCONDDESPACHO { get; set; }
        [MapField("FAC04EXPCODPUERTO")]
        public string FAC04EXPCODPUERTO { get; set; }
        [MapField("FAC04EXPCODBCOLOCAL")]
        public string FAC04EXPCODBCOLOCAL { get; set; }
        [MapField("FAC04EXPCDDOCCRED")]
        public string FAC04EXPCDDOCCRED { get; set; }
        [MapField("FAC04EXPLCEMITIDA")]
        public string FAC04EXPLCEMITIDA { get; set; }
        [MapField("FAC04EXPBANKCODE")]
        public string FAC04EXPBANKCODE { get; set; }
        [MapField("FAC04EXPNUMCUENTA")]
        public string FAC04EXPNUMCUENTA { get; set; }
        [MapField("FAC04EXPNROCONTAINER")]
        public string FAC04EXPNROCONTAINER { get; set; }
        [MapField("FAC04EXPNROPRECINTO")]
        public string FAC04EXPNROPRECINTO { get; set; }
        [MapField("FAC04ORDENCOMPRA")]
        public string FAC04ORDENCOMPRA { get; set; }
        [MapField("FAC04FECORDCOMPRA")]
        public Nullable<DateTime> FAC04FECORDCOMPRA { get; set; }
        [MapField("FAC04CODTIPOVENTA")]
        public string FAC04CODTIPOVENTA { get; set; }
        [MapField("FAC04ESTADODEPROCESO")]
        public string FAC04ESTADODEPROCESO { get; set; }
        [MapField("FAC04EXPCODPUERTODES")]
        public string FAC04EXPCODPUERTODES { get; set; }
        [MapField("FAC04TIENDA")]
        public string FAC04TIENDA { get; set; }
        [MapField("FAC04DESCUENTOGLOBAL")]
        public double FAC04DESCUENTOGLOBAL { get; set; }
        [MapField("FAC04EXPCONOEMBARQUE")]
        public string FAC04EXPCONOEMBARQUE { get; set; }
        [MapField("FAC04TOTALPESOADUANA")]
        public double FAC04TOTALPESOADUANA { get; set; }
        [MapField("FAC04TOTALPESO")]
        public double FAC04TOTALPESO { get; set; }
        [MapField("FAC04TOTALCAJAS")]
        public double FAC04TOTALCAJAS { get; set; }
        [MapField("FAC04TOTALCANTIDAD")]
        public double FAC04TOTALCANTIDAD { get; set; }
        [MapField("FAC04FETOTALGRAVADA")]
        public double FAC04FETOTALGRAVADA { get; set; }
        [MapField("FAC04FETOTALNOGRAVADA")]
        public double FAC04FETOTALNOGRAVADA { get; set; }
        [MapField("FAC04FETOTALEXONERADA")]
        public double FAC04FETOTALEXONERADA { get; set; }
        [MapField("FAC04FETOTALGRATUITA")]
        public double FAC04FETOTALGRATUITA { get; set; }
        [MapField("FAC04FETOTALDESCUENTO")]
        public double FAC04FETOTALDESCUENTO { get; set; }
        [MapField("FAC04IMPORTELETRAS")]
        public string FAC04IMPORTELETRAS { get; set; }
        [MapField("FAC04FECODBIENOSERVDETRACCION")]
        public string FAC04FECODBIENOSERVDETRACCION { get; set; }
        
        [MapField("FAC04FETOTALDETRACCION")]
        public double FAC04FETOTALDETRACCION { get; set; }
        [MapField("FAC04FEVALORREFDETRACCION")]
        public double FAC04FEVALORREFDETRACCION { get; set; }
        [MapField("FAC04FEPORCEDETRACCION")]
        public double FAC04FEPORCEDETRACCION { get; set; }
        [MapField("FAC04FEDESCDETRACCION")]
        public string FAC04FEDESCDETRACCION { get; set; }
        [MapField("FAC04MOTIVOBAJA")]
        public string FAC04MOTIVOBAJA { get; set; }
        [MapField("FAC04FECHABAJA")]
        public Nullable<DateTime> FAC04FECHABAJA { get; set; }
        [MapField("FAC04FERESUMENFECHA")]
        public Nullable<DateTime> FAC04FERESUMENFECHA { get; set; }
        [MapField("FAC04FERESUMENCODIGO")]
        public string FAC04FERESUMENCODIGO { get; set; }
        [MapField("FAC04FELUGARDESTINO")]
        public string FAC04FELUGARDESTINO { get; set; }
        [MapField("FAC04ESTADOSUNAT")]
        public string FAC04ESTADOSUNAT { get; set; }
        [MapField("FAC04LIQUIDACIONNRO")]
        public string @FAC04LIQUIDACIONNRO { get; set; }
        [MapField("FAC04FETIPODEOPERACION")]
        public string FAC04FETIPODEOPERACION { get; set; }
        [MapField("FAC04FECODIGOANEXOEMISOR")]
        public string FAC04FECODIGOANEXOEMISOR { get; set; }
        [MapField("FAC04CLAVE")]
        public string FAC04CLAVE { get; set; }
        
        [MapField("FAC04FORMAPAGOSUNAT")]
        public string FAC04FORMAPAGOSUNAT { get; set; }
        [MapField("FAC04FORMAPAGOSUNATCUOTAS")]
        public int FAC04FORMAPAGOSUNATCUOTAS { get; set; }
        [MapField("FAC04FORMAPAGOSUNATDIAS")]
        public int FAC04FORMAPAGOSUNATDIAS { get; set; }



        

        [MapField("ClienteNombre")]
        public string ClienteNombre { get; set; }

        [MapField("DocumentoEstadoAntesFE")]
        public string DocumentoEstadoAntesFE { get; set; }

        [MapField("DescMotivoNotaCredito")]
        public string DescMotivoNotaCredito { get; set; }

        [MapField("DescMotivoNotaDebito")]
        public string DescMotivoNotaDebito { get; set; }

        [MapField("TipoAnalisisDesc")]
        public string TipoAnalisisDesc {get;set;}

        [MapField("SubPlantillaDesc")]
        public string SubPlantillaDesc {get;set;}

        [MapField("MonedaDesc")]
        public string MonedaDesc {get;set;}

        [MapField("TiendaDesc")]
        public string TiendaDesc {get;set;}

        [MapField("PaisOrigenDesc")]
        public string PaisOrigenDesc {get;set;}

        [MapField("PaisDestinoDesc")]
        public string PaisDestinoDesc {get;set;}

        [MapField("ExpCondPagoDesc")]
        public string ExpCondPagoDesc {get;set;}

        [MapField("ExpCodCondDespachoDesc")]
        public string ExpCodCondDespachoDesc { get; set; }

        [MapField("ExpPuertoEmbarqueDesc")]
        public string  ExpPuertoEmbarqueDesc {get;set;}

        [MapField("ExpPuertoDesembarqueDesc")]
        public string ExpPuertoDesembarqueDesc {get;set;}

        [MapField("BancoDesc")]
        public string BancoDesc {get;set;}

        [MapField("FAC03DESC")]
        public string FAC03DESC { get; set; }
        
        //Descripcion de tipo de comprobante de pago
        [MapField("FAC01DESC")]
        public string FAC01DESC { get; set; }

        [MapField("EstadoProcesoSUNAT")]
        public string EstadoProcesoSUNAT { get; set; }

        [MapField("EstadoProcesoBizlink")]
        public string EstadoProcesoBizlink { get; set; }
        // Comunicado Baja
        [MapField("cbMotivo")]
        public string cbMotivo { get; set; }

        [MapField("cbEstadoSunat")]
        public string cbEstadoSunat { get; set; }

        [MapField("cbajaFecha")]
        public Nullable<DateTime> cbajaFecha { get; set; }

        //Resumen
        [MapField("EstadoResumen")]
        public string EstadoResumen { get; set; }

        //NC o ND
         [MapField("NCNDTipo")]
        public string NCNDTipo { get; set; }

        [MapField("NCNDNumero")]
         public string NCNDNumero { get; set; }

        [MapField("NCNDFecha")]
        public Nullable<DateTime> NCNDFecha { get; set; }

        [MapField("FAC04VENDEDORCOD")]
        public string FAC04VENDEDORCOD { get; set; }

        [MapField("FAC04VENDEDORNOMBRE")]
        public string FAC04VENDEDORNOMBRE { get; set; }

        	
        
    }
}
