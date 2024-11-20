using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inv.UI.Win
{
    public enum FormEstate
    {
        List = 0,
        New = 1,
        Edit = 2,
        View = 3
    }
    public enum DetailEstate
    {
        Read = 0, //  modom por default
        New = 1, // Agregar detalle
        Edit = 2, // Editala la grilla
        Cancel = 3
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
        enmLinea = 52,
        enmActividadNivel1 = 53,
        enmTurnos = 54, 
        enmProducObjetivo  = 55,
        enmCanastillasMultiple = 56,
        enmMateriaPrimaMultiple = 57,
        enmAlmacenxNaturaleza = 58,
        enmCanterasxContratista = 59,
        enmCanastillasMultipleMP= 60,
        enmCanastillasMultiplePP=61,
        enmOrdenTrabajo = 62,
        enmAlmacenTodos = 63,
        enmMotivo = 64,
        enmStockLinea = 65,
        enmLineaArti = 66,
        enmGrupoArti = 67,
        enmSubGrupoArti = 68,
        enmCuentaContable = 69,
        enmUniMedEquiv = 70,
        enmCalidadMP = 79,
        enmOrdenCompra = 80,
        enmMaquinaInventario  = 81,
        enmequialmguias = 82,
        enmarticulosconstocksuministros = 83,
        enmLibro = 84,
        enmCtaCteDesc = 85,
        enmTipoCostoMP = 86,
        enmBloquesCosteo = 87,
        enmFactTransportBloques = 88,
        enmEstadoInventarioFisico = 89
        }
    public enum BaseRegBotones
    {
        cbbNuevo = 0,
        cbbEditar = 1,
        cbbEliminar = 2,
        cbbGuardar = 3,
        cbbCancelar = 4,
        cbbVistaPrevia = 5,
        cbbImprimir = 6,
        cbbExportar = 7,
        cbbImportar = 8,
        cmdPrimero = 9,
        cmdSiguiente = 10,
        cmdAnterior = 11,
        cmdUltimo = 12,

        cbbCopiar = 13,
        cbbGeneraPDF = 14,
        cbbGenerarFE = 15,
        cbbVerFE = 16,
        cbbDarBaja = 17,
        cbbGenerarFactura = 18,
        cbbGenerarBoleta = 19,
        cbbNavegacion = 20,
        cbbAnulado = 21,
        cbbVer = 22,
        cbbDarBajaFE = 23,
        cbbAgregarDetalle = 26,
        cbbVistaPreliminar = 27,
        cbbCamEst = 28,
        cbbRefrescar = 29,
        cbbProcesarEstado = 30,
        cbbVista = 31,
        cbbDeshacerEstado = 32,
        cbbReporteFactura = 33,
        cbbReporteCertificado = 34,
        cbbEnviarCorreo = 35

    }
    public enum BaseRegBotonesDetalle
    {
        btnGuardarDet = 0,
        btnCancelarDet = 1,
        btnEliminarDet = 2,
        btnEditarDet = 3,
        btnVerDet = 4,
        btnNuevoDet = 5,
        btnRegularizar = 6
    }
}
