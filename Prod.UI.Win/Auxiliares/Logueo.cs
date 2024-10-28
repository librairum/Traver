using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prod.UI.Win
{
    public static class Logueo
    {
        public static string CodigoEmpresa = "01";
        public static string NombreEmpresa = "";
        public static string UserName = "";
        public static string TipoAnalisisCliente = "01";
        public static string TipoAnalisisProveedor = "02";
        public static string TipoAnalisisMateriaPrima = "10";
        public static string TipoAnalisisFabricante = "02";
        public static string Anio = "2015";
        public static string Mes = "01";
        public static double TipoCambio = 2.9;
        public static string codigoPerfil = "";
        public static string nomPerfil = "";
        public static string clavePasada = "";
        public static string codModulo = "05";

        public static string MP_codnaturaleza = "01";
        public static string PP_codnaturaleza = "02";
        public static string PT_codnaturaleza = "03";

        public static string MP_AlmxDefecto = "03";
        public static string PP_AlmxDefecto = "10";
        public static string PT_AlmxDefecto = "06";

        public static string OrigenTipo_Manual = "M";
        public static string OrigentTipo_Automatico = "A";
        public static string codigoClientxDefecto = "000001";
        public static string CodigoLinea = "05";
        public static string codProcesoDesdoblado = "02";
        // ruta del servidor de reportes
        public static string GetPathServerrReportSSRS()
        {
            return "http://servidor:8080/ReportServer_SQL2008R2";
            //return "http://william:8080/ServidorReportes";
            
        }
        // carpeta de reporte en SSRS
        public static string GetDirectorySSRRS()
        {
            return "Report Project1";
        }
        public static string GetRutaReporte()
        {
            return string.Format("{0}{1}", Application.StartupPath, @"\Reportes\");
        }
        public static string GetRutaIcono()
        {
            return string.Format("{0}{1}", Application.StartupPath, @"\Iconos\");
        }

    }
}
