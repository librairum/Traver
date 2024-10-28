using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Data;
using BLToolkit.Mapping;
namespace Inv.BusinessEntities
{
   public  class SegMenuPorPerfil
    {

       public string CodigoFormulario { get; set; }
       public string Etiqueta { get; set; }
       public string comando { get; set; }
       public string nombreFormulario { get; set; }
       public string nombreIcono { get; set; }
       public string DescripcionFormulario { get; set; }       
       public string opcxmenu { get; set; }
       public string FlagVerReportesConImportes { get; set; }
       
    }
}
