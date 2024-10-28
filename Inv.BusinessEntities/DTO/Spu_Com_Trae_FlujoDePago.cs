using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Com_Trae_FlujoDePago")]
    public class Spu_Com_Trae_FlujoDePago
    {
        public string Tipo{get;set;}
        public string CO05CODCTE {get;set;}
        public string CO05TIPDOC {get;set;}
        public string CO05NRODOC {get;set;}
        public string PagoBanco {get;set;}
        public string PagoBancoCuenta {get;set;}
        public string PagoTipo {get;set;}
        public string PagoNro {get;set;}
        public Nullable<DateTime> PagoFecha {get;set;}
        public double importeSol {get;set;}
        public double importeDol {get;set;}
        public string Ban01Descripcion { get; set; }

    }
}
