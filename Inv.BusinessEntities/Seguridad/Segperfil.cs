using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Data;
using BLToolkit.Mapping;
namespace Inv.BusinessEntities
{
    [TableName("segperfil")]
   public  class Segperfil
    {
        [MapField("codigo")]
        public int codigo { get; set; }
        [MapField("nombre")]
        public string nombre { get; set; }
    }
}
