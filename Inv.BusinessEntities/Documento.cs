using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("In06Docu")]
    public class Documento
    {
        [MapField("IN06CODEMP")]
        public string CodigoEmpresa { get; set; }
        [MapField("IN06AA")]
        public string Anio { get; set; }
        [MapField("IN06MM")]
        public string Mes { get; set; }
        [MapField("IN06TIPDOC")]
        public string TipoDoc { get; set; }
        [MapField("IN06CODDOC")]
        public string CodigoDoc { get; set; }
        [MapField("IN06FECDOC")]
        public Nullable<DateTime> FechaDoc { get; set; }
        [MapField("IN06CODTRA")]
        public string CodigoTransa { get; set; }
        [MapField("IN06TRANSA")]
        public string Transaccion { get; set; }
        [MapField("IN06MONEDA")]
        public string Moneda { get; set; }
        [MapField("IN06CAMBIO")]
        public double TipoCambio { get; set; }
        [MapField("IN06CODPRO")]
        public string CodigoProveedor { get; set; }
        [MapField("IN06CODCLI")]
        public string CodigoCliente { get; set; }
        [MapField("IN06CENCOS")]
        public string CodigoCentroCosto { get; set; }
        [MapField("IN06RESPENT")]
        public string Responsable { get; set; }
        [MapField("IN06RESPREC")]
        public string ResponsableReceptor { get; set; }
        [MapField("IN06OBRA")]
        public string CodigoObra { get; set; }
        [MapField("IN06MAQUINA")]
        public string CodigoMaquina { get; set; }
        [MapField("IN06LOTE")]
        public string Lote { get; set; }
        [MapField("IN06PEDIDO")]
        public string Pedido { get; set; }
        [MapField("IN06REFDOC")]
        public string ReferenciaDoc { get; set; }
        [MapField("IN06ALMAEM")]
        public string CodigoAlmacenEmisor { get; set; }
        [MapField("IN06ALMARE")]
        public string CodigoAlmacenReceptor { get; set; }
        [MapField("IN06OBSERVA")]
        public string Observacion { get; set; }
        [MapField("IN06ITEM")]
        public string Item { get; set; }
        [MapField("IN06ANOITEM")]
        public string AnioItem { get; set; }
        [MapField("IN06ORDCOMP")]
        public string OrdenCompra { get; set; }
        [MapField("IN06FLAGVEN")]
        public string FlagVen { get; set; }
        [MapField("IN06FLAVEN")]
        public string FlaVen { get; set; }
        [MapField("IN06ANOORDCOMP")]
        public string AnioOrdenCompra { get; set; }

        public string Tipo_Documento {get;set;}

        public string in12TipDoc { get; set; }

            
        [MapField("IN06NOTASALIDAAA")]
        public string IN06NOTASALIDAAA{get;set;}
        [MapField("IN06NOTASALIDAMM")]
        public string IN06NOTASALIDAMM{get;set;}
        [MapField("IN06NOTASALIDATIPDOC")]
        public string IN06NOTASALIDATIPDOC {get;set;}
        [MapField("IN06NOTASALIDACODDOC")]
        public string IN06NOTASALIDACODDOC {get;set;}
        

        [MapField("IN06NOTASALIDA")]
        public string IN06NOTASALIDA { get; set; }

        /*in12DesLar	
INGRESO POR PRODUCCION	Hoja control produccion - Seleccion y empaque*/
        public string in12DesLar { get; set; }
        public string in15Descripcion { get; set; }
//        Tipo_Documento	in12TipDoc
//Salida por reeseleccion	52
        [MapField("in06prodlineacod")]
        public string codigoLinea {get;set;}
        [MapField("in06prodTurnoCod")]
        public string codigoTurno { get; set; }
        [MapField("in06prodActiNivel1Cod")]
        public string codigoActiNivel1 { get; set; }
        
        [MapField("IN06CANTERACOD")]
        public string IN06CANTERACOD { get; set; }
        
        [MapField("IN06CONTRATISTACOD")]
        public string IN06CONTRATISTACOD { get; set; }
        [MapField("IN06PRODNATURALEZA")]
        public string IN06PRODNATURALEZA { get; set; }
        
        [MapField("IN06DOCRESCTACTETIPANA")]
        public string IN06DOCRESCTACTETIPANA {get;set;}

        [MapField("IN06DOCRESCTACTENUMERO")]
        public string IN06DOCRESCTACTENUMERO {get;set;}

        [MapField("OrigenTipo")]
        public string OrigenTipo { get; set; }

        [MapField("ctactedocresnombre")]
        public string ctactedocresnombre { get; set; }

        [MapField("IN06CODTRAANTERIOR")]
        public string IN06CODTRAANTERIOR { get; set; }

        [MapField("CentroCostoMP")]
        public string CentroCostoMP { get; set; }

        [MapField("CCostoDesc")]
        public string CCostoDesc { get; set; }
        
        public string DescripcionMaquina { get; set; }

        /*
         SELECT tipdoc.IN12DesLar as TipoDocumento, doc.IN06CODDOC as Numero
        , transa.in15Descripcion as [DocRespaldo]
        , doc.IN06REFDOC as DocRespaldoNro
        ,linea.PRO08DESC as [Linea] 
        , act.PRO09DESC  as Proceso
        ,turno.PRO12DESC as [Turno]
         */
        /*get and set para grilla de produccion */

        public string Proceso { get; set; }
        public string Linea { get; set; }
        public string Turno { get; set; }
        public string DocRespaldoNro { get; set; }
        public string DocRespaldo { get; set; }
        public string Numero { get; set; }
        public string TipoDocumento { get; set; }
        public string Codtransa { get; set; }
        public string CodTipDoc { get; set; }
    }

}
