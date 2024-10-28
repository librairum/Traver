using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{

    [TableName("co04movi")]
 public class DocumentoOrdenCompraDetalle{
[MapField("CO04CODEMP")]  public string Empresa  { get;  set; } 
[MapField("CO04AA")]  public string Anio { get;  set; } 
[MapField("CO04MES")]  public string Mes  { get;  set; } 
[MapField("CO04TIPO")]  public string TipoOrden  { get;  set; } 
[MapField("CO04CODIGO")]  public string CodigoOrden  { get;  set; } 
[MapField("CO04CORREL")]  public string Item  { get;  set; } 
[MapField("CO04TIPDET")]  public string TipoOrdenDetalle  { get;  set; } 
[MapField("CO04ARTICU")]  public string CodigoArticulo  { get;  set; } 
[MapField("CO04CANTID")]  public double Cantidad  { get;  set; } 
[MapField("CO04PRECIO")]  public double Precio  { get;  set; } 
[MapField("CO04DESCT1")]  public double Descuento1  { get;  set; } 
[MapField("CO04DESCT2")]  public double Descuento2  { get;  set; } 
[MapField("CO04IMPUST")]  public double Igv  { get;  set; } 
[MapField("CO04IMPBRU")]  public double ImporteBruto  { get;  set; } 
[MapField("CO04IMPIGV")]  public double ImporteIgv  { get;  set; } 
[MapField("CO04IMPNET")]  public double Total  { get;  set; } 
[MapField("CO04AREA")]  public string Destino  { get;  set; } 
[MapField("CO04DESCRI")]  public string NombreArticulo  { get;  set; } 
[MapField("CO04UNIDAD")]  public string Unidad  { get;  set; } 
[MapField("CO04ESTADO")]  public string Estado  { get;  set; } 
[MapField("CO04FLAGTR")]  public string CO04FLAGTR  { get;  set; } 
[MapField("CO04CODPRO")]  public string CodigoProveedor  { get;  set; } 
[MapField("CO04FECDOC")]  public Nullable<DateTime> FechaOrden  { get;  set; } 
[MapField("CO04ALMA")]  public string CO04ALMA  { get;  set; } 
[MapField("CO04CODGAS")]  public string CO04CODGAS  { get;  set; } 
[MapField("CO04CANATE")]  public double CantidadAtendida { get;  set; } 
[MapField("CO04CANCON")]  public double CO04CANCON  { get;  set; } 
[MapField("CO04CLAGA1")]  public string CO04CLAGA1  { get;  set; } 
[MapField("CO04CLAGA2")]  public string CO04CLAGA2  { get;  set; } 
[MapField("CO04DSCT1")]  public double Valodcto1  { get;  set; } 
[MapField("CO04DSCT2")]  public double Valodcto2  { get;  set; } 
[MapField("CO04MOVI1")]  public string CO04MOVI1  { get;  set; } 
[MapField("CO04MOVI2")]  public string CO04MOVI2  { get;  set; } 
[MapField("CO04DESCR1")]  public string CO04DESCR1  { get;  set; } 
[MapField("CO04CCOSA")]  public string CO04CCOSA  { get;  set; } 
[MapField("CO04CCOSV")]  public string CO04CCOSV  { get;  set; } 
[MapField("CO04CODALM")]  public string CO04CODALM  { get;  set; } 
[MapField("CO04TIPINV")]  public string CO04TIPINV  { get;  set; }
[MapField("CO04MEMO")] public string CO04MEMO { get; set; } 
[MapField("CO04IMAGEN")]  public string ArchivoImg  { get;  set; }
[MapField("CO04MEMO2")] public string Memo { get; set; }
[MapField("BaseIGV")] public string BaseIGV { get; set; }

}
}
