using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("come04PedVentaDocCliente")]
    public class TipoDocumentoCliente
    {
        [MapField("come04pedventadoccliDesc")]
        public string Descripcion { get; set; }
        [MapField("come04empresa")]
        public string CodigoEmpresa { get; set; }
        [MapField("come04pedventadocclicod")]
        public string Codigo { get; set; }
    }
}
