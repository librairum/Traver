using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("In01LinArt")]
    public class LineaArticulo
    {
        [MapField("In01CodEmp")]
        public string CodigoEmpresa {get;set;}

        [MapField("In01CodLinArt")]
        public string Codigo {get;set;}

        [MapField("In01Descripcion")]
        public string Descripcion { get; set; }
        

    }
}
