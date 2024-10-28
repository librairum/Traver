using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    [TableName("IN06DOCUIMPORTAR")]
    public class ImportarMP
    {
        [MapField("IN06CODEMP")]
        public string @cCodEmp { get; set; }
        [MapField("IN06AA")]
        public string @cAnno { get; set; }
        [MapField("IN06MM")]
        public string @cMes { get; set; }

        [MapField("IN06TIPDOC")]
        public string @cTipoDocu { get; set; }
        [MapField("IN06CODDOC")]
        public string @cDocuNumer { get; set; }
        [MapField("IN06FECDOC")]
        public string @dFechaDoc { get; set; }
        [MapField("IN06CODTRA")]
        public double @cCodTra { get; set; }
        [MapField("IN06TRANSA")]
        public string @cTransac { get; set; }
        [MapField("IN06MONEDA")]
        public string @cMoneda { get; set; }

        [MapField("IN06CAMBIO")]
        public string @nTipoCambio { get; set; }
        [MapField("IN06CODPRO")]
        public string @cProveedor { get; set; }
        [MapField("IN06CODCLI")]
        public string @cCliente { get; set; }

        [MapField("IN06CENCOS")]
        public double @cCenCosto { get; set; }

        [MapField("IN06CENCOS")]
        public double @cResponsable { get; set; }

        [MapField("IN06RESPENT")]
        public double @cResponAlma { get; set; }
        [MapField("IN06RESPREC")]
        public double @cResponRece { get; set; }
        [MapField("IN06OBRA")]
        public double @cObra { get; set; }
        [MapField("IN06MAQUINA")]
        public double @cMaquinas { get; set; }
        [MapField("IN06LOTE")]
        public string @cLotes { get; set; }
        [MapField("IN06PEDIDO")]
        public string @cPedidos { get; set; }
        [MapField("IN06REFDOC")]
        public string @cDocumento { get; set; }
        [MapField("IN06ALMAEM")]
        public string @cAlmaEm { get; set; }
        //[MapField("-")]
        [MapField("IN06ALMARE")]
        public string @cAlmaRe { get; set; }
        [MapField("IN06FLAVEN")]
        public string IN06FLAVEN { get; set; }
    
    }
}
