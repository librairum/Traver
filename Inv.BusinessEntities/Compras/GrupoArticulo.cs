using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("In02GrupArt")]
    public class GrupoArticulo
    {

        [MapField("In02CodEmp")]
        public string CodigoEmpresa {get;set;}


        [MapField("In02CodLinArt")]
        public string CodigoLinea {get;set;}

        [MapField("In02CodGrupArt")]
        public string Codigo {get;set;}

        [MapField("In02Descripcion")]
        public string Descripcion { get; set; }


    }
}
