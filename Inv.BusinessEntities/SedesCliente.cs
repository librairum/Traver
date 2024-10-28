using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("come05sedesCliente")]
    public class SedesCliente
    {
        [MapField("come05clientecod")]
        public string CodigoCliente { get; set; }
        [MapField("come05sedeclientescod")]
        public string CodigoSede { get; set; }
        [MapField("come05sedeclientesdesc")]
        public string NombreSede { get; set; }
        [MapField("come05sedeclientesdireccion")]
        public string Direccion { get; set; }
        [MapField("come05empresa")]
        public string CodigoEmpresa { get; set; }
        [MapField("come05clientetipana")]
        public string CodigoTipoAnalisis { get; set; }
    }
}
