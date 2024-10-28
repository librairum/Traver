using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
namespace Inv.BusinessEntities
{
    [TableName("segmenu")]
   public class Segmenu
    {

        [MapField("codigo")]
        public int codigo { get; set; }
        [MapField("etiqueta")]
        public string eitqueta { get; set; }
        [MapField("nivel1")]
        public string nivel1 { get; set; }
        [MapField("nivel2")]
        public string nivel2 { get; set; }
        [MapField("nivel3")]
        public string nivel3 { get; set; }
        [MapField("comando")]
        public string comando { get; set; }
        [MapField("codigoFormulario")]
        public int codigoFormulario { get; set; }
        [MapField("nombreIcono")]
        public string nombreIcono { get; set; }

        /*	codigo int identity primary key,
      etiqueta varchar(100),
      nivel1 char(2),
      nivel2 char(2),nivel3 char(2),
      comando varchar(50),	
      codigoFormulario int,
      nombreIcono varchar(30) */
    }
}
