using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;
using BLToolkit.Data;
namespace Inv.BusinessEntities
{
    [TableName("segmenuxperfil")]
    public class Segmenuxperfil
    {
        [MapField("codigoPerfil")]
        public string codigoPerfil { get; set; }
        [MapField("codigoMenu")]
        public string codigoMenu { get; set; }
        [MapField("opcxmenu")]
        public string opcxmenu { get; set; }
    }
}
