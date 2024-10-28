using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prod.UI.Win
{
    public class Constantes
    {

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

        }
        public class ReporteControlProduccion
        {
            public const string CodActLinea = "05";
            public const string CodActCorte = "01";
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
