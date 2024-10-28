using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fac.UI.Win
{
    public enum FormEstate
    {
        List = 0,
        New = 1,
        Edit = 2,
        View = 3,
        ChangeState = 4
    }
    public enum DetailEstate
    { 
        Read = 0,
        New = 1,
        Edit = 2,
        Save = 3,
        Cancel = 4,
        Delete = 5
    }
    public enum DetalleEstado 
    { 
        Nuevo = 0,
        Edita = 1,
        Elimina = 2,
        Guarda = 3,
        Cancela = 4
    }
    public enum GridEstate
    { 
        
    }
    public enum enmDroDownItems
    {
        Seleccione = 0,
        Todos = 0,
        Ninguna = 0
    }
    public enum RespuestaMensaje
    { 
        Si = 0,
        No = 1,
        Cancelar = 2
    }
    
    public enum OrigenInstancia
    {
        Principal = 0,
        Externo1 = 1,
        Externo2 = 2,
        Externo3 = 3
    }
    public enum BaseRegBotones
    { 
            cbbNuevo = 0,
            cbbEditar = 1,
            cbbEliminar = 2,
            cbbGuardar  = 3,
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
            cbbEnviarCorreo = 35,
            cbbModificarPeso = 36,
            cbbOnVistaGE = 37

    }
    public class BaseForm
    {

    }

    public enum enmAyudaFactura
    { 
        
    }
    public enum enmAyudaBoleta
    { 
    
    }
    public enum enmTipoFormulario
    { 
        enmProceso = 0,
        enmProcesoDetalle = 1,
        enmMantenimiento = 2,
        enmMantenimientoDetalle= 3,
        enmReporte = 4,
    }
    public enum BaseTipoDocumento
    { 
        enmBoleta = 0,
        enmFactura =1,
        enmNotaDebito=2,
        enmNotaCredito =3
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
        enmSubPlantilla = 48,
        enmTransportista = 49,
        enmVehxTranporYchofer = 50,
        enmchoferxtransportistas = 51,
        enmDestinatario = 52,
        enmdestinaEstab = 53,
        enmMotvioDeTraslado = 54,
        enmEstablecimientos = 55,
        enmEmpresa = 56,
        enmEstados = 57,

        enmBuscaArti = 58,
        enmBuscaArtiProv = 59,
        enmBuscaConductor = 60,
        enmBuscaTransportista = 61,
        enmBuscaDestinatario = 62,
        enmBuscaTipDoc = 63,
        enmBuscaTipArt = 64,
        enmBuscaPlantilla = 65,

        enmLibros = 66,
        enmCtaContable = 67,
        enmFlagCargoAbono = 68,
        enmTipoImporteDocu = 69,

        enmFactCab_SubPlantilla = 70,
        enmFactCab_TipoAnalisis = 71,
        enmFactCab_Cliente = 72,
        enmFactCab_Moneda = 73,
        enmFactCab_Tienda = 74,
        enmFactCab_ExpPaisOrigen = 75,
        enmFactCab_ExpPaisDestino = 76,
        enmFactCab_ExpCondPago = 77,
        enmFactCab_ExpConDespacho = 78,
        enmFactCab_ExpPuertoEmbarque = 79,
        enmFactCab_ExpPuertoEmbarqueDes = 80,
        enmFactCab_ExpBancoLocal = 81,
        enmFactDet_ArtxTipo = 82,
        // Nota de Credito o Debito
        enmNotaCD_SubPlantilla = 83,
        enmNotaCD_TipoDocumento = 84,
        enmNotaCD_NroDocumento = 85,
        enmNotaCD_ArtxTipo = 86, 
        enmNotaCD_Motivo = 87,
        enmMonedaFE = 88,
        enmGuiaPendientePorFactura = 89,
        enmCliente_TipoDoc = 90,
        enmCliente_SituacionSunat = 91,
        enmCliente_SituacionDomi = 92,
        enmCliente_Pais = 93,
        enmCliente_Dpto = 94,
        enmCliente_Prov = 95,
        enmCliente_Dist = 96,
        enmCliente_FormaPago = 97,
        enmTablaFE = 98,
        enmTipDocGlobal = 99,
        enmEmpAlmacen = 100,
        enmEmpContable = 101,
        enmTipoOrdenCompra = 102,
        enmCliente_TipoCliente = 103,
        enmPackingListDisponible = 104,
        enmSerie = 105,
        enmUniVenta = 106,
        enmtipoVenta=107,
        enmPlantillaFE=108,
        enmOperacionFE=109,
        enmEstablecimientoxSerie = 110,
        enmProductoSunat=111,
        enmAsiento=112,
        enmFacDet_ArtxCliente = 113,
        enmSegTipoDocumento = 124,
        enmSegUsuario = 125,
        enmFormaPagoSunat = 126,
        enmDetraccionCod = 127,
        enmLineaArti = 128,
        enmGrupoArti = 129,
        enmSubGrupoArti = 130,
        enmCuentaContable = 131,
        enmUniMedEquiv = 132,
        enmFactCab_Vendedor=133,
        enmUniMedGuia = 134,
        enmCatalogoD37 = 135,
        enmCatalogo61 = 136,
        enmFAC03SubPlantillaFAC89 = 137,
        enmEstadoSUNAT = 138
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

