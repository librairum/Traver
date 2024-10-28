using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Fact_Trae_DocParaVouCont")]
    public class Spu_Fact_Trae_DocParaVouCont
    {

        [MapField("FAC04FECHA")]
        public Nullable<DateTime> FAC04FECHA { get; set; }

        [MapField("FAC01CODLIBRO")]
        public string FAC01CODLIBRO { get; set; }

        [MapField("FAC01COD")]
        public string FAC01COD { get; set; }

        [MapField("FAC01DESC")]
        public string FAC01DESC { get; set; }

        [MapField("FAC04NUMDOC")]
        public string FAC04NUMDOC { get; set; }

        [MapField("FAC04MONEDA")]
        public string FAC04MONEDA { get; set; }

        [MapField("FAC04TIPCAMBIO")]
        public double FAC04TIPCAMBIO { get; set; }

        [MapField("FAC04IMPSUBTOTAL")]
        public double FAC04IMPSUBTOTAL {get;set;}

        [MapField("FAC04IMPIGV")]
        public double FAC04IMPIGV { get;set;}

        [MapField("FAC04IMPTOTAL")]
        public double FAC04IMPTOTAL {get;set;}

        [MapField("FAC04ESTADODOC")]
        public double FAC04ESTADODOC {get;set;}

        [MapField("FAC04CONTASIENTOTIPO")]
        public string FAC04CONTASIENTOTIPO {get;set;}

        [MapField("FAC04CONTLIBRO")]
        public string FAC04CONTLIBRO {get;set;}

        [MapField("FAC04CONTVOUCHER")]
        public string FAC04CONTVOUCHER {get;set;}

        [MapField("FAC04ESTADOCONTABLE")]
        public string FAC04ESTADOCONTABLE { get; set; }

        [MapField("NOMBRECLIENTE")]
        public string NOMBRECLIENTE { get; set; }

        [MapField("TipoDoc")]
        public string TipoDoc { get; set; }

        [MapField("EstadoSunat")]
        public string EstadoSunat { get; set; }

        [MapField("EstadoUsuario")]
        public string EstadoUsuario { get; set; }

    }
}
