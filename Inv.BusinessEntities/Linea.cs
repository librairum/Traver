using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("PRO08LINEA")]
    public class Linea
    {
        [MapField("PRO08CODEMP")]
        public string codigoEmpresa { get; set; }
        [MapField("PRO08COD")]
        public string codigo { get; set; }
        [MapField("PRO08DESC")]
        public string descripcion { get; set; }
    
    }
}
