using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("in07movi_ImportarCostos")]
    
    public class ImportarMovimientos
    {
        [MapField("IN07CODEMP")]
         public string IN07CODEMP {get;set;}
        [MapField("IN07AA")]
        public string IN07AA {get;set;}
        [MapField("IN07MM")]
         public string IN07MM {get;set;}
        [MapField("IN07TIPDOC")]
        public string IN07TIPDOC   {get;set;}
        [MapField("IN07CODDOC")]
        public string IN07CODDOC {get;set;}
        [MapField("IN07KEY")]
        public string IN07KEY {get;set;}
        [MapField("IN07ORDEN")]
        public  double IN07ORDEN{get;set;}
        [MapField("IN07UNIMED")]
        public string IN07UNIMED{get;set;}
        [MapField("IN07FECDOC")]
        public string IN07FECDOC{get;set;}
        [MapField("IN07CODALM")]
        public string IN07CODALM{get;set;}
        [MapField("IN07CODTRA")]
        public string IN07CODTRA{get;set;}
        [MapField("IN07TRANSA")]
        public string IN07TRANSA{get;set;}
        [MapField("IN07CANART")]
        public double IN07CANART{get;set;}
        [MapField("IN07COSUNI")]
        public double IN07COSUNI {get;set;}
        [MapField("IN07COUNSO")]
        public double IN07COUNSO {get;set;}
        [MapField("IN07COUNDO")]
        public double IN07COUNDO {get;set;}
        [MapField("IN07IMPORT")]
        public double IN07IMPORT {get;set;}
        [MapField("IN07IMPSOL")]
        public double IN07IMPSOL {get;set;}
        [MapField("IN07IMPDOL")]
        public double IN07IMPDOL {get;set;}
        [MapField("IN07COSALM")]
        public double IN07COSALM {get;set;}
        [MapField("IN07IMPALM")]
        public double IN07IMPALM {get;set;}
        [MapField("IN07COALSO")]
        public double IN07COALSO {get;set;}
        [MapField("IN07IMALSO")]
        public double IN07IMALSO {get;set;}
        [MapField("IN07COALDO")]
        public double IN07COALDO {get;set;}
        [MapField("IN07IMALDO")]
        public double IN07IMALDO {get;set;}
        [MapField("IN07CTAGTO")]
        public string IN07CTAGTO{get;set;}
        [MapField("IN07CTAING")]
        public string IN07CTAING {get;set;}
        [MapField("IN07LARGO")]
        public double IN07LARGO {get;set;}
        [MapField("IN07ANCHO")]
        public double IN07ANCHO {get;set;}
        [MapField("IN07ALTO")]
        public double IN07ALTO{get;set;}
        [MapField("IN07LARGOCAN")]
        public double IN07LARGOCAN{ get;set;}
        [MapField("IN07ANCHOCAN")]
        public double IN07ANCHOCAN {get;set;}
        [MapField("IN07ALTOCAN")]
        public double IN07ALTOCAN {get;set;}
        [MapField("IN07PROMSOL")]
        public double IN07PROMSOL {get;set;}
        [MapField("IN07PROMDOL")]
        public double IN07PROMDOL{get;set;}
        [MapField("IN07STATUS")]
        public string IN07STATUS {get;set;}
        [MapField("IN07CODBLOQUEEMP")]
        public string IN07CODBLOQUEEMP {get;set;}
        [MapField("IN07CODBLOQUEPROV")]
        public string IN07CODBLOQUEPROV {get;set;}
        [MapField("IN07PEDVENTA")]
        public string IN07PEDVENTA {get;set;}
        [MapField("IN07ORDPROD")]
        public string IN07ORDPROD {get;set;}
        [MapField("IN07NROCAJA")]
        public string IN07NROCAJA {get;set;} 
        [MapField("IN07PEDVEN")]
        public string IN07PEDVEN {get;set;}
        [MapField("in07pedvendestino")]
        public string in07pedvendestino {get;set;}
        [MapField("IN07DocIngAA")]
        public string IN07DocIngAA  {get;set;}
        [MapField("IN07DocIngMM")]
        public string IN07DocIngMM {get;set;}
        [MapField("IN07DocIngTIPDOC")]
        public  string IN07DocIngTIPDOC {get;set;}
        [MapField("IN07DocIngCODDOC")]
        public string IN07DocIngCODDOC  {get;set;}
        [MapField("IN07DocIngKEY")]
        public string IN07DocIngKEY {get;set;}
        [MapField("IN07DocIngORDEN")]
        public double IN07DocIngORDEN {get;set;}
        [MapField("in07pedvennum")]
        public string in07pedvennum {get;set;}
        [MapField("in07pedvencodprod")]
        public string in07pedvencodprod {get;set;}
        [MapField("in07pedvenitem")]
        public double in07pedvenitem {get;set;}
        [MapField("in07observacion")]
        public string  in07observacion {get;set;}
        [MapField("IN07AREAXUNI")]
        public double IN07AREAXUNI {get;set;}
        [MapField("IN07FLAGSTOCKREAL")]
        public string IN07FLAGSTOCKREAL {get;set;}
        [MapField("IN07PROVMATPRIMA")]
        public string IN07PROVMATPRIMA  {get;set;}
        [MapField("IN07CODCLI")]
        public string IN07CODCLI{get;set;}
        [MapField("IN07ORDENTRABAJO")]
        public string IN07ORDENTRABAJO {get;set;}
        [MapField("IN07OPERADOR")]
        public string IN07OPERADOR {get;set;}
        [MapField("IN06CODTRA")]
        public string IN06CODTRA {get;set;}
        [MapField("IN06REFDOC")]
        public string IN06REFDOC {get;set;}
        [MapField("IN06MONEDA")]
        public string IN06MONEDA {get;set;}
        [MapField("IN06CODPRO")]
        public string IN06CODPRO {get;set;}
        [MapField("IN06CENCOS")]
        public string IN06CENCOS {get;set;}
        [MapField("IN06OBRA")]
        public string IN06OBRA{ get; set;}
        [MapField("FLAG")]
        public  string FLAG{get;set;}
        [MapField("ERRORES")]
        public string ERRORES  {get;set;}
        [MapField("CANTERRORES")]
        public int CANTERRORES {get;set;}
        [MapField("CODIGOUSUARIO")]
        public string CODIGOUSUARIO {get;set;}
        [MapField("SISTEMA")]
        public string SISTEMA{ get;set;}

        //Datos de produccion
        [MapField("IN06MAQUINA")]
        public string IN06MAQUINA { get; set; }
        [MapField("in06prodlineacod")]
        public string in06prodlineacod {get;set;}

        [MapField("in06prodActiNivel1Cod")]
        public string in06prodActiNivel1Cod {get;set;}

        [MapField("in06prodTurnoCod")]
        public string in06prodTurnoCod {get;set;}

        [MapField("IN06CANTERACOD")]
        public string IN06CANTERACOD {get;set;}

        [MapField("IN06CONTRATISTACOD")]
        public string IN06CONTRATISTACOD {get;set;}

        [MapField("IN06PRODNATURALEZA")]
        public string IN06PRODNATURALEZA {get;set;}

        [MapField("IN06ORIGENTIPO")]
        public string IN06ORIGENTIPO {get;set;}

        [MapField("msgretorno")]
        public string msgretorno { get; set; }
    }
}
