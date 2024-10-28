using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fac.UI.Win
{
    public class Constantes
    {

        //    cbbNuevoON
        //cbbEliminarON
        //cbbEditaON
        //cbbAnulado
        //cbbCopiar
        //cbbVer
        //cbbAgregarDetalleON
        //cbbGeneraPDF.Visibility = bGenerarPDF == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
        //cbbImprimir.Visibility = bImprimir == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
        //cbbVistaPreliminar.Visibility = bVistaPreliminar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
        //cbbGenerarFE.Visibility = bGenerarFE == true ? ElementVisibility.Visible  : ElementVisibility.Collapsed;
        //cbbVerFE.Visibility = bVerFE == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
        //cbbDarBajaFE.Visibility = bDarBajaFE == true ? 
        public class BotonesDeDocumento
        {
            public const bool bNuevoON = true;
            public const bool bNuevoOFF = false;
            public const bool bEliminarON = true;
            public const bool bEliminarOFF = false;
            public const bool bEditaON = true;
            public const bool bEditaOFF = false;
            public const bool bAnuladoON = true;
            public const bool bAnuladoOFF = false;
            public const bool bCopiarON = true;
            public const bool bCopiarOFF = false;
            public const bool bVerON = true;
            public const bool bVerOFF = false;
            public const bool bAgregarDetalleON = true;
            public const bool bAgregarDetalleOFF = false;
            public const bool bGenerarPdfON = true;
            public const bool bGenerarPdfOFF = false;
            public const bool bImprimirON = true;
            public const bool bImprimirOFF = false;
            public const bool bVistaPreliminarON = true;
            public const bool bVistaPreliminarOFF = false;
            public const bool bGenerarFeON = true;
            public const bool bGenerarFeOFF = false;
            public const bool bVerFeON = true;
            public const bool bVerFeOFF = false;
            public const bool bDarBajaFeON = true;
            public const bool bDarBajaFeOFF = false;
            
        }
        public class Botones
        {
            //HabilitarBotones(bool guardar, bool cancelar,
            // bool vistaprevia, bool imprimir, bool importar,bool exportar,bool navegacion
            public const bool bGuardarON = true,bGuardarOFF = false;           
            public const bool bCancelarON = true, bCancelarOFF = false;            
            public const bool bVistaPreviaON = true, bVistaPreviaOFF = false;            
            public const bool bImprimirON = true, bImprimirOFF = false;            
            public const bool bImportarON = true, bImportarOFF = false;            
            public const bool bExportarON = true, bExportarOFF = false;
            public const bool bNavegacionON = true, bNavegacionOFF = false;
            public const bool bCopiarON = true, bCopiarOFF = false;

            public const bool bGenerarPdfON = true, bGenerarPdfOFF = false;
            public const bool bGenerarFeON = true, bGenerarFeOFF = false;
            public const bool bVerFeON = true, bVerFeOFF = false;
            public const bool bDarBajaON = true, bDarBajaOFF = false;
        }
        public class DropDownItems
        {
            public const string Seleccione = "--SELECCIONE--";
            public const string Todos = "--TODOS--";
            public const string Ninguna = "--NINGUNA--";
        }

        public class ProTerCarateristicas
        {
            public const string tipo = "01";
            public const string color = "02";
            public const string tonalidad = "03";

            public const string ancho = "04";
            public const string largo = "05";
            public const string espesor = "06";

            public const string formato = "11";
            public const string acabado = "07";
            public const string relleno = "08";
            public const string borde = "09";
            public const string modelo = "10";
            public const string calidad = "12";
            public const string rucEmpresa = "20420310383";
            public const string almacen = "06";
        }

        public class MensajesGenericos
        {
            public const string MSG_ERROR_INESPERADO = "Ha ocurrido un error inesperado. Consulte con su Administrador de sistema.";
            public const string MSG_TITULO_INFO = "Mensaje";
            public const string MSG_TITULO_CONFIRMAR = "Confirmar...";
            public const string MSG_TITULO_ERROR = "Error";
            public const string MSG_TITULO_ALERTA = "Atención!";
        }

        public class Tablas
        {
            public const string CODIGO_TABLA_MONEDA = "56";
        }
    }
}
