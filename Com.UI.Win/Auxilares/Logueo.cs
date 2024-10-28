using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace Com.UI.Win
{
    public static class Logueo
    {
        public static string CodigoEmpresa = "01";
        public static string CodModulo = "03";
        public static string NombreEmpresa = "";
        public static string gbRucEmpresa = "";
        public static string UserName = "";
        public static string TipoAnalisisCliente = "01";
        public static string TipoAnalisisProveedor = "02";
        public static string TipoAnalisisMateriaPrima = "10";
        public static string TipoAnalisisFabricante = "02";
        public static string TipoAnalisisTransportista = "11";
        public static string TipoAnalisisChofer = "12";
        public static string TipoAnalisisDestinatario = "15";
        //public static string Anio = "2015";
        //public static string Mes = "01";
        public static string Anio = "2021";
        public static string Mes = "01";
        public static double TipoCambio = 2.9;
        public static string codigoPerfil = "";
        public static string nomPerfil = "";
        public static string clavePasada = "";
        public static string nombreModulo = "VENTAS";
        public const string rucEmpresa = "20420310383";
        public static string MP_codnaturaleza = "01";
        public static string PP_codnaturaleza = "02";
        public static string PT_codnaturaleza = "03";
        public static string PS_codnaturaleza = "04";
        public static string[] rowselectedbyuser = new string[1000];
        public static int countofrowsselectedbyuser = 0;
        public static string periodo = "201803";
        public static double Igv = 18;
        public static string FlagNotCreyDeb = "";        
        public static string[] aArreglo;

        //Compras
        //llenar desde el logueo el valor de esta variable con la seleccion de empresa
        //S=empresa es reteedoro / N= No es retenedora
        public static string FlagRetencion = "S";
        public static string ImporteRetencion = "";
        public static string ComprasPeriodoCerrado = "";
        public static string AccesoaPeriodoCerrado = "";
        //Grilla de provision factura
        public static RadGridView gridProvFactura = new RadGridView();
        
        public static string mesProvivision = "";
        public static string nroVoucher = "";
        public static string codigoLibro = "";
        public static string anioDocumento = "";
        public static string TipoProvision = ""; // C/OC --> Provision Con Orden Compra / Provision Sin Orden Compra
        public static string FerProvision = ""; // Tomar dos valores V -> Voucher  , D-> Documento
        public static string BiMoneda = ""; // "S" u otro valor de moneda
        public static string ModifTC = ""; // "S" u otro tipo de cambio.

        public static string OCompraTipoParaDocSinOCompra = "0"; 
        public static string OCompraNumeroParaDocSinOCompra = "00000";

        // ruta del servidor de reportes
        public static string GetPathServerrReportSSRS()
        {
            //return "http://servidor:8081/Reports_SQL2008"; // URL de reportes
            return "http://servidor:8081/ReportServer_SQL2008"; // URL de servicio de reportes.                                                
        }

        // carpeta de reporte en SSRS
        public static string GetDirectorySSRRS()
        {
            return "ReportesVentaNacional";
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
