using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prod.UI.Win
{
   public  class BaseForm
    {
    }
   public enum FormEstate
   {
       List = 0,
       New = 1,
       Edit = 2,
       View = 3
   }
   public enum enmDroDownItems
   {
       Seleccione = 0,
       Todos = 0,
       Ninguna = 0
   }
   public enum enmAyuda
   {
       enmTipoDocumento = 0,
       enmTransaccion = 1,
       enmProveedor = 2,
       enmPedido = 3,
       enmCliente = 4,
       enmCentroCosto = 5,
       enmResponsableReceptor = 6,
       enmResponsable = 7,
       enmObra = 8,
       enmMaquina = 9,
       enmLote = 10,
       enmProductoXAlmacen = 11,
       enmAlmacen = 12,
       enmMoneda = 13,
       enmprovmateriaprima = 14,
       // Caracteristicas de productos terminados
       enmTipo = 20,
       enmColor = 21,
       enmTonalidad = 22,
       enmFormato = 23,
       enmAcabado = 24,
       enmRelleno = 25,
       enmBorde = 26,
       enmModelo = 27,
       enmProductoXAlmacenIng = 28,
       enmCalidad = 29,
       enmUniMed = 30,
       enmProductoXPedVenSalida = 31,

       enmLargo = 40,
       enmAncho = 41,
       enmEspesor = 42,

       enmPedVentIng = 43,
       enmPedVentIngPT = 44,
       enmProductosxCliente = 45,
       enmEquivalenciaProducto = 46,
       enmNotaSalida = 47,
       enmLinea = 48,
       enmActividadNivel1 = 49,
       enmTurnos = 50,
       enmProducObjetivo = 51,
       enmCanastillasMultiple = 52,
       enmMateriaPrimaMultiple = 53,
       enmOperador = 54,
       enmAlmacenMP = 55,
       enmTipoDocumentoAll = 56,
       enmCanastillas = 57,
       enmMateriaPrima = 58,
       enmAlmacenxNaturaleza = 59,
       enmCanastillasMultipleMP= 60,
       enmCanastillasMultiplePP=61,
       enmActividadesRelacionadas = 62,
       enmMaquinaxLineaActividad = 63,
       enmMotivoHoraMuerta = 64,
       enmProductoxColorFormat = 65,
       enmMotivo = 66,
       enmOrdenTrabajoTipo = 67,
       enmTurnosxDetalle = 68,
       enmEscalla = 69,
       enmCostra = 70,
       enmCanastMultiPPResumido  = 71,
       enmCanastMultiMPResumido = 72,
       enmAlmacenxlineaxactividad = 73,
       enmCanastillasMultipleMPConParametros= 74
   }

}
