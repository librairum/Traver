using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    [TableName("Funciones")]
    public class Funciones
    {
        [MapField("Empresa")]
        public string Empresa { get; set; }
        [MapField("Modulo")]
        public string Modulo { get; set; }
        [MapField("Codigo")]
        public string Codigo { get; set; }
        [MapField("Titulo")]
        public string Titulo { get; set; }
        [MapField("Descripcion")]
        public string Descripcion { get; set; }
        [MapField("Mensajealusuario")]
        public string Mensajealusuario { get; set; }
        [MapField("Estado")]
        public string Estado { get; set; }
        [MapField("CodigoModulo")]
        public string CodigoModulo { get; set; }

        // Tabla de Campos Opcionales de Factura Electronica
        [MapField("FAC71TablaDesc")]
        public string FAC71TablaDesc {get;set;}

        [MapField("FAC71CampoFEDesc")]
        public string FAC71CampoFEDesc { get; set; }
    }
}

/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inv.BusinessEntities
{
    class Funciones
    {
    }
}


*/