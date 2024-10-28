using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    [TableName("In02GrupArt")]
    public class SubGrupoArticulo
    {
        [MapField("In03CodEmp")]
        public string CodigoEmpresa  {get;set;}
        
        [MapField("In03CodLinArt")]
        public string CodigoLineaArticulo {get;set;}

        [MapField("In03CodGrupArt")]
        public string CodigoGrupoArticulo  {get;set;}

        [MapField("In03CodSubGrupaRT")]
        public string Codigo  {get;set;}

        [MapField("In03Descripcion")]
        public string Descripcion { get; set; }
        
    }
}
