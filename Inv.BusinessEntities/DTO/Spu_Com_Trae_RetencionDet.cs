using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;


namespace Inv.BusinessEntities
{
    [TableName("Spu_Com_Trae_RetencionDet")]
    public class Spu_Com_Trae_RetencionDet
    {
            [MapField("Ban01Empresa")]
            public string Ban01Empresa {get;set;}

            [MapField("Ban01Numero")]
            public string Ban01Numero {get;set;}

            [MapField("Ban01Ruc")]
            public string Ban01Ruc {get;set;}

            [MapField("Ban01Tipo")]
            public string Ban01Tipo { get; set; }

            [MapField("Ban01NroDoc")]
            public string Ban01NroDoc { get; set; }

            [MapField("Ban01Codigo")]
            public string Ban01Codigo { get; set; }

            [MapField("Ban01Id")]
            public string Ban01Id { get; set; }

            [MapField("Ban01Nro")]
            public string Ban01Nro { get; set; }

            [MapField("Ban01Serie")]
            public string Ban01Serie { get; set; }

            [MapField("Ban01Correlativo")]
            public string Ban01Correlativo { get; set; }

            [MapField("Ban01Pago")]
            public double Ban01Pago { get; set; }

            [MapField("Ban01Retenido")]
            public double Ban01Retenido { get; set; }

            [MapField("Ban01PagoDolares")]
            public double Ban01PagoDolares { get; set; }

            [MapField("Ban01RetenidoDolares")]
            public double Ban01RetenidoDolares { get; set; }

            [MapField("Ban01PagoNeto")]
            public double Ban01PagoNeto { get; set; }

            [MapField("Ban01PagoNetoDolares")]
            public double Ban01PagoNetoDolares { get; set; }

            [MapField("Ban01PagoTotal")]
            public double Ban01PagoTotal { get; set; }

            [MapField("Ban01RetenidoTotal")]
            public double Ban01RetenidoTotal { get; set; }

            [MapField("Ban01PagoNetoTotal")]
            public double Ban01PagoNetoTotal { get; set; }

            [MapField("Ban01PagoDolaresTotal")]
            public double Ban01PagoDolaresTotal { get; set; }

            [MapField("Ban01RetenidoDolaresTotal")]
            public double Ban01RetenidoDolaresTotal { get; set; }

            [MapField("Ban01PagoNetoDolaresTotal")]
            public double Ban01PagoNetoDolaresTotal { get; set; }

            [MapField("CO05TIPDOC")]
            public string CO05TIPDOC { get; set; }

            [MapField("CO05NRODOC")]
            public string CO05NRODOC { get; set; }

            [MapField("CO05FECHA")]
            public Nullable<DateTime> CO05FECHA { get; set; }

            [MapField("CO05MONEDA")]
            public string CO05MONEDA { get; set; }

            [MapField("CO05AFECTORET")]
            public string CO05AFECTORET { get; set; }

            [MapField("CO05IMPORT")]
            public double CO05IMPORT { get; set; }

            [MapField("CO05IMPDOL")]
            public double CO05IMPDOL { get; set; }

            [MapField("CO05TC")]
            public double CO05TC { get; set; }

            [MapField("Ban01FechaEmi")]
            public Nullable<DateTime> Ban01FechaEmi { get; set; }

            [MapField("Ban01Porcentaje")]
            public double Ban01Porcentaje { get; set; }

            
    }
}
