using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{

    [TableName("co05docu")]
 public class DocumentoXProveedor{
[MapField("CO05TIPDOC")]  public string CO05TIPDOC  { get;  set; } 
[MapField("CO05NRODOC")]  public string CO05NRODOC { get;  set; } 
[MapField("CO05FECHA")]  public string CO05FECHA { get;  set; } 
[MapField("CO05MONEDA")]  public string CO05MONEDA { get;  set; }
[MapField("CO05IMPORT")]  public string CO05IMPORT { get;  set; }
[MapField("CO05IMPDOL")]  public string CO05IMPDOL { get;  set; }

}
}
