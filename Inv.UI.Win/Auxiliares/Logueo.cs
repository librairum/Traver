using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inv.UI.Win
{
    public static class Logueo
    {
        public static string CodigoEmpresa = "01";
        public static string NombreEmpresa = "XXXXXX";
        public static string RucEmpresa = "";
        public static string TipoAnalisisCliente = "01";
        public static string TipoAnalisisProveedor = "02";
        public static string TipoAnalisisMateriaPrima = "10";
        public static string TipoAnalisisFabricante = "02";
        public static string Anio = "2020";
        public static string Mes = "01";
        public static double TipoCambio = 1;
        public static string codigoPerfil = "";
        public static string nomPerfil = "";
        public static string UserName = "XXXX";
        public static string UsuarioVerReporte = "S";
        public static string UsuarioVeReportesConImporte = "S";
        public static string clavePasada = "";
        public static string codModulo = "01";
        public static string opcxbotones = "";
        public static string TipoArticulo = "";
        public static string claveActual = "";
        public static string MP_codnaturaleza = "01";
        public static string PP_codnaturaleza = "02";
        public static string PT_codnaturaleza = "03";
        public static string PS_codnaturaleza = "04";
        public static string MP_AlmxDefecto = "03";
        public static string PP_AlmxDefecto = "10";
        public static string PT_AlmxDefecto = "06";
        public static string PS_AlmaxDefecto = "01";
        public static string PS_AlmaxDefectoStock = "TO";                     
        public static string TipoAnalisisContratista = "13";
        public static string sedetipodondeseejecutaelsistema = "";

        //para tipo de origen del documento M= manual, A=Automatico
        public static string OrigenTipo_manual = "M";
        public static string OrigenTipo_automatico = "A";
        public static string MonedaxDefecto = "S";


        
        //
        public static string GetRutaReporte()
        {
            return string.Format("{0}{1}", Application.StartupPath, @"\Reportes\");
        }
        public static string GetRutaIcono() {
            return string.Format("{0}{1}", Application.StartupPath, @"\Iconos\");
        }
      
    }
}
