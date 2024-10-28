using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Inv.BusinessEntities
{
    [TableName("SegUsuario")]
   public class SegUsuario
    {
        [MapField("Codigo")]
        public string Codigo { get; set; }
        [MapField("NombreUsuario")]
        public string NombreUsuario { get; set; }
        [MapField("ClaveUsuario")]
        public string ClaveUsuario { get; set; }
        [MapField("CodigoPerfil")]
        public string  CodigoPerfil { get; set; }
        [MapField("CodigoEmpresa")]
        public string CodigoEmpresa { get; set; }
        [MapField("FlagVerReportesConImportes")]
        public string FlagVerReportesConImportes { get; set; }
        
        
        public string NomApe { get; set; }
        public string NomPerfil { get; set; }
        public string NomEmpresa { get; set; }

        //Datos de serie documento
        
        public string CodigoSerie	 {get;set;}
        public string CodigoUsuario	 {get;set;}
        public string CodTipoDocumento	 {get;set;}
        public string  DesTipoDocumento	{get;set;}
        public string CodSerie	 {get;set;}
        public string DesSerie { get; set; }

        

    }
}
