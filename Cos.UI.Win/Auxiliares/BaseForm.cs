using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cos.UI.Win
{
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

    public class BaseForm
    {

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

        enmPedVentIng=43,
        enmPedVentIngPT=44,
        enmProductosxCliente = 45,
        enmEquivalenciaProducto = 46,
        enmNotaSalida = 47,
        // Caracteristicas del producto
        enmContratista  = 48,
        enmCantera = 49,
        enmCuentaCorriente = 50,
        enmNaturaleza = 51,
        enmActCtbleTipo = 52,
        enmLinea = 53,
        enmActNivel1 = 54,
        enmActCtble = 55
        }
}
