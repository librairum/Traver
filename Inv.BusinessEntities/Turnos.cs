using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("PRO12TURNOS")]
    public class Turnos
    {
        [MapField("PRO12CODEMP")]
        public string codigoEmpresa { get; set;}
        [MapField("PRO12COD")]
        public string codigo { get;set;}
        [MapField("PRO12DESC")]
        public string descripcion { get; set; }
        [MapField("descripcioncompleto")]
        public string descripcioncompleto { get; set; }
        
        [MapField("PRO12HORAINICIO")]
        public string  horainicio { get; set; }
        
        [MapField("PRO12HORAFIN")]
        public string horafin { get; set; }
        [MapField("PRO12HORAINICIOEXT")]
        public string horainicioextra { get; set; }
        [MapField("PRO12HORAFINEXT")]
        public string horafinextra{ get; set; }

        //Hora en formato de Texto 

    }
}
