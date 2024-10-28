using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    [TableName("in07movi_Importar")]
    public class ImportarDocumento
    {
        [MapField("IN07CODEMP")]
        public string IN07CODEMP { get; set; }
        [MapField("IN07AA")]
        public string IN07AA { get; set; }
        [MapField("IN07MM")]
        public string IN07MM { get; set; }
        [MapField("IN07TIPDOC")]
        public string IN07TIPDOC { get; set; }
        [MapField("IN07CODDOC")]
        public string IN07CODDOC { get; set; }
        [MapField("IN07KEY")]
        public string IN07KEY { get; set; }
        [MapField("IN07ORDEN")]
        public double IN07ORDEN { get; set; }
        [MapField("IN07UNIMED")]
        public string IN07UNIMED { get; set; }
        [MapField("IN07FECDOC")]
        public string IN07FECDOC { get; set; }

        [MapField("IN07CODALM")]
        public string IN07CODALM { get; set; }
        [MapField("IN07CODTRA")]
        public string IN07CODTRA { get; set; }
        [MapField("IN07TRANSA")]
        public string IN07TRANSA { get; set; }
        [MapField("IN07CANART")]
        public double IN07CANART { get; set; }
        [MapField("IN07COSUNI")]
        public double IN07COSUNI { get; set; }
        [MapField("IN07LARGO")]
        public double IN07LARGO { get; set; }
        [MapField("IN07ANCHO")]
        public double IN07ANCHO { get; set; }
        [MapField("IN07ALTO")]
        public double IN07ALTO { get; set; }
        [MapField("IN07PEDVENTA")]
        public string IN07PEDVENTA { get; set; }
        [MapField("IN07ORDPROD")]
        public string IN07ORDPROD { get; set; }
        [MapField("IN07NROCAJA")]
        public string IN07NROCAJA { get; set; }
        [MapField("IN07PEDVEN")]
        public string IN07PEDVEN { get; set; }
        //[MapField("-")]
        [MapField("in07pedvennum")]
        public string in07pedvennum { get; set; }
        [MapField("in07pedvencodprod")]
        public string in07pedvencodprod { get; set; }
        [MapField("in07pedvenitem")]
        public double in07pedvenitem { get; set; }
        [MapField("in07observacion")]
        public string in07observacion { get; set; }
        [MapField("IN07AREAXUNI")]
        public double IN07AREAXUNI { get; set; }
        [MapField("IN07FLAGSTOCKREAL")]
        public string IN07FLAGSTOCKREAL { get; set; }
        [MapField("IN07PROVMATPRIMA")]
        public string IN07PROVMATPRIMA { get; set; }
        //[MapField("-")]
        [MapField("IN06CODTRA")]
        public string IN06CODTRA { get; set; }
        [MapField("IN06REFDOC")]
        public string IN06REFDOC { get; set; }
        [MapField("IN06MONEDA")]
        public string IN06MONEDA { get; set; }
        [MapField("IN06CODPRO")]
        public string IN06CODPRO { get; set; }
        [MapField("IN06CENCOS")]
        public string IN06CENCOS { get; set; }
        [MapField("IN06OBRA")]
        public string IN06OBRA { get; set; }
        [MapField("flag")]
        public string flag { get; set; }
        [MapField("errores")]
        public string errores { get; set; }
        [MapField("Canterrores")]
        public int canterrores { get; set; }
        [MapField("codigousuario")]
        public string codigousuario {get;set;}
        [MapField("sistema")]
        public string sistema {get;set;}

        [MapField("IN07CODCLI")]
        public string IN07CODCLI { get; set; }
    }
}
