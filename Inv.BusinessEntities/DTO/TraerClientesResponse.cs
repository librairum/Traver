using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("TraerClientesResponse")]
    public class TraerClientesResponse
    {
        [MapField("ccm02cod")]
        public string Codigo { get; set; }
        [MapField("ccm02nom")]
        public string Nombre { get; set; }
        [MapField("ccm02ruc")]
        public string Ruc { get; set; }
        [MapField("ccm02tipana")]
        public string CodigoTipoAnalisis { get; set; }
        [MapField("ccm02dir")]
        public string Direccion { get; set; }
    }
}
