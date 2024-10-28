using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{

    [TableName("Ban01RetencionCab")]
 public class RetencionCab{

    [MapField("Ban01Empresa")]
     public string Ban01Empresa { get; set; }
    [MapField("RetencionNro")]
     public string RetencionNro { get; set; }
    [MapField("RetencionFecha")]
     public string RetencionFecha { get; set; }
     [MapField("Ban01Id")]
     public string Ban01Id { get; set; }
     [MapField("Ban01Anio")]
     public string Ban01Anio { get; set; }
     [MapField("Ban01Mes")]
     public string Ban01Mes { get; set; }
     [MapField("Ban01FechaEmi")]
     public Nullable<DateTime> Ban01FechaEmi { get; set; }
     [MapField("Ban01Proveedor")]
     public string Ban01Proveedor { get; set; }
     [MapField("Ban01Ruc")]
     public string Ban01Ruc { get; set; }
     [MapField("Ban01TipoCambio")]
     public double Ban01TipoCambio { get; set; }
     [MapField("Ban01Mon")]
     public string Ban01Mon { get; set; }
     [MapField("Ban01Porcentaje")]
     public int Ban01Porcentaje { get; set; }
     [MapField("Ban01Total")]
     public double Ban01Total { get; set; }
     [MapField("Ban01Retenido")]
     public double Ban01Retenido { get; set; }
     [MapField("Ban01Estado")]
     public string Ban01Estado { get; set; }
     [MapField("Ban01Usuario")]
     public string Ban01Usuario { get; set; }
     [MapField("Ban01Pc")]
     public string Ban01Pc { get; set; }
     [MapField("Ban01FechaRegistro")]
     public Nullable<DateTime> Ban01FechaRegistro { get; set; }
     [MapField("Ban01Tipo")]
     public string Ban01Tipo { get; set; }
     [MapField("Ban01FechaImp")]
     public Nullable<DateTime> Ban01FechaImp { get; set; }
     [MapField("Ban01VouchEmp")]
     public string Ban01VouchEmp { get; set; }
     [MapField("Ban01VouchAno")]
     public string Ban01VouchAno { get; set; }
     [MapField("Ban01VouchMes")]
     public string Ban01VouchMes { get; set; }
     [MapField("Ban01VouchSubd")]
     public string Ban01VouchSubd { get; set; }
     [MapField("Ban01VouchNumer")]
     public string Ban01VouchNumer { get; set; }
     [MapField("Ban01TotalDolares")]
     public double Ban01TotalDolares { get; set; }
     [MapField("Ban01RetenidoDolares")]
     public double Ban01RetenidoDolares { get; set; }
     [MapField("TotalSoles")]
     public double TotalSoles { get; set; }
     [MapField("RetencionSoles")]
     public double RetencionSoles { get; set; }
     [MapField("TotalDolares")]
     public double TotalDolares { get; set; }
     [MapField("RetencionDolares")]
     public double RetencionDolares { get; set; }
     [MapField("EstadoSunat")]
     public string EstadoSunat { get; set; }

}
}
