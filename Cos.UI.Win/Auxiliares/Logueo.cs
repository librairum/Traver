using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cos.UI.Win
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
        public static string codModulo = "06";
        public static string nomModulo = "COSTOS";
        public static string opcxbotones = "";
        public static string TipoArticulo = "";
        
        public static string MP_codnaturaleza = "01";
        public static string PP_codnaturaleza = "02";
        public static string PT_codnaturaleza = "03";
        public static string MP_AlmxDefecto = "03";
        public static string PP_AlmxDefecto = "10";
        public static string PT_AlmxDefecto = "06";
        public static string ActContableTipo = "02";
        public static string CodigoLoteCosto = "";
        public static string CodigoLinea = "";

        // ruta del servidor de reportes
        public static string GetPathServerrReportSSRS()
        {
            //return "http://SISTEMAS:8080/ReportServer_SQL2008R2";
            //return "http://sistemas:8080/ReportServer";
            //return "http://william:8080/ServidorReportes";
            return "http://william:8080/webservicereportes";
        }

        // carpeta de reporte en SSRS
        public static string GetDirectorySSRRS()
        {
            return "Report Project2";
        }

        public static string GetRutaReporte()
        {
            return string.Format("{0}{1}", Application.StartupPath, @"\Reportes\");
        }
        public static string GetRutaIcono() {
            return string.Format("{0}{1}", Application.StartupPath, @"\Iconos\");
        }
    }
}
