using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.Data;
using BLToolkit.DataAccess;
namespace Inv.BusinessEntities
{
    [TableName("segformulario")]
   public class Segformulario
    {
        /*codigo int identity primary key,
     nombre varchar(100),
     descripcion varchar(100)*/
        [MapField("codigo")]
        public int codigo { get; set; }
        [MapField("nombre")]
        public string nombre { get; set; }
        [MapField("descripcion")]
        public string descripcion { get; set; }
    }
}
