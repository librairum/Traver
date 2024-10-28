using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("ccb17ana")]
    public class TipoAnalisis
    {
        [MapField("ccb17emp")]
        public string CodigoEmpresa { get; set; }
        [MapField("ccb17cdgo")]
        public string Codigo { get; set; }
        [MapField("ccb17desc")]
        public string Descripcion { get; set; }
    }
}
