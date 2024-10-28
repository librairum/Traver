using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{

   [TableName("Ban01RetencionDet")]
 public class RetencionDetalle{
[MapField("Ban01Empresa")]  public string Ban01Empresa  { get;  set; } 
[MapField("Ban01Numero")]  public string Ban01Numero  { get;  set; } 
[MapField("Ban01Ruc")]  public string Ban01Ruc  { get;  set; } 
[MapField("Ban01Tipo")]  public string Ban01Tipo  { get;  set; } 
[MapField("Ban01NroDoc")]  public string Ban01NroDoc  { get;  set; } 
[MapField("Ban01Codigo")]  public string Ban01Codigo  { get;  set; } 
[MapField("Ban01Id")]  public string Ban01Id  { get;  set; } 
[MapField("Ban01Nro")]  public string Ban01Nro  { get;  set; } 
[MapField("Ban01Serie")]  public string Ban01Serie  { get;  set; } 
[MapField("Ban01Correlativo")]  public string Ban01Correlativo  { get;  set; } 
[MapField("Ban01Pago")]  public string Ban01Pago  { get;  set; } 
[MapField("Ban01Retenido")]  public string Ban01Retenido  { get;  set; }
[MapField("Ban01PagoDolares")]  public string Ban01PagoDolares  { get;  set; }
[MapField("Ban01RetenidoDolares")]  public string Ban01RetenidoDolares  { get;  set; }
[MapField("Ban01PagoNeto")]  public string Ban01PagoNeto  { get;  set; }
[MapField("Ban01PagoNetoDolares")]  public string Ban01PagoNetoDolares  { get;  set; }
[MapField("Ban01PagoTotal")]  public string Ban01PagoTotal  { get;  set; }
[MapField("Ban01RetenidoTotal")]  public string Ban01RetenidoTotal  { get;  set; }
[MapField("Ban01PagoNetoTotal")]  public string Ban01PagoNetoTotal  { get;  set; }
[MapField("Ban01PagoDolaresTotal")]  public string Ban01PagoDolaresTotal  { get;  set; }
[MapField("Ban01RetenidoDolaresTotal")]  public string Ban01RetenidoDolaresTotal  { get;  set; }
[MapField("Ban01PagoNetoDolaresTotal")]  public string Ban01PagoNetoDolaresTotal  { get;  set; }
[MapField("Ban01Porcentaje")]  public string Ban01Porcentaje  { get;  set; }
 [MapField("Ban01FechaEmi")]  public string Ban01FechaEmi  { get;  set; } 
 }
}
