using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
namespace Inv.BusinessEntities
{
    [TableName("segmodulosxempresa")]
    public class Segmodulosxempresa
    {
        [MapField("codigoEmpresa")]
        public int codigoEmpresa {get;set;}
        [MapField("codigoModulo")]
        public string codigoModulo { get; set; }
    }
}
