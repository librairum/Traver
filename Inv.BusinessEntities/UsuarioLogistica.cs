using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("usuarios_logistica")]    
    public class UsuarioLogistica
    {
        [MapField("codigo")]
        public string codigo { get; set; }

        [MapField("nombre")]
        public string nombre { get; set; }

        [MapField("cargo")]
        public string cargo { get; set; }
    }
}
