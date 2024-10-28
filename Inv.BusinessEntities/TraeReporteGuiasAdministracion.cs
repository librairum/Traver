using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inv.BusinessEntities
{
    public class TraeReporteGuiasAdministracion
    {


    public string Fecha {get;set;}

    public string NumeroGuia { get; set; }
    public string OC { get; set; }


    public string CodigoCliente {get;set;}
    public string NombreCliente { get; set; }
    public string Motivo {get;set;}
    public string MotivoDescripcion {get;set;}


    public double CantidadBaldosasMT2 {get;set;}
    public double CantidadMosaicosMT2 {get;set;}
    public double CantidadPlanchasMT2 {get;set;}
    public double CantidadOtrosMT2 {get;set;}

    public double TotalMT2 {get;set;}
    public double CantidadEscallaTM {get;set;}
    public double CantidadPolvoTM {get;set;}

    public double TotalTM {get;set;}
    public string Observacion {get;set;}


    }
}
