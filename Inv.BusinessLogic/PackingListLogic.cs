using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;
using System.Transactions;
using System.Xml;

namespace Inv.BusinessLogic
{
    public class PackingListLogic
    {
        #region Singleton
        private static volatile PackingListLogic instance;
        private static object syncRoot = new Object();
        private PackingListLogic() { }
        public static PackingListLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new PackingListLogic();
                    }
                }
                return instance;
            }

        }
        #endregion
   
        

        #region "Metodos logicos por usar"
        
        public List<PackingList> TraePackingList(string @FAC60CODEMP, string @FAC60AA, string @FAC60MM)
        {
            return Accessor.Spu_Fac_Trae_PackingList(@FAC60CODEMP, @FAC60AA, @FAC60MM);
        }
        public List<Spu_Fac_Trae_PackingListTodo> TraeAyudaPackingDisponible(string @FAC60CODEMP,
        string @FAC60AA, string @FAC60MM)
        {
            return Accessor.Spu_Fac_Trae_PackingListConsumible(@FAC60CODEMP, @FAC60AA, @FAC60MM);
        }
       
        public void InsertarPackingListDet(string @FAC61CODEMP, string @FAC61NUMERO, string @XMLdetalle, out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Fac_Ins_PackingListDetXml(@FAC61CODEMP, @FAC61NUMERO, @XMLdetalle, out @flag, out @msgretorno);   
        }
        public List<Spu_Fac_Trae_PedidosDisponibles> TraeAyudaPedidosDisponibles(string @come01empresa, string @come01clientetipdoc, string @come01clientecod)
        {
            return Accessor.Spu_Fac_Trae_PedidosDisponibles(@come01empresa, @come01clientetipdoc, @come01clientecod);
        }
        
        #endregion


        #region "Metodo logicos en uso"
        public PackingList TraePackingListRegistro(string @FAC60CODEMP, string @FAC60NUMERO,
           string @FAC60AA, string @FAC60MM)
        {
            return Accessor.Spu_Fac_Trae_PackingListRegistro(@FAC60CODEMP, @FAC60NUMERO, @FAC60AA, @FAC60MM);
        }
      
        public List<PackingList> TraePackingDetalleFacturacion(string @FAC61CODEMP, string @FAC61NUMERO)
        {
            return Accessor.Spu_Fac_Trae_PackingDetalle(@FAC61CODEMP, @FAC61NUMERO);
        }
        public DataTable TraeReportePackingList(string @FAC60CODEMP, string @FAC60NUMERO)
        {
            return Accessor.Spu_Fac_Rep_PackingList(@FAC60CODEMP, @FAC60NUMERO);
        }
        public void InsertarPackingCab(PackingList packingCabecera, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fac_Ins_PackingListCab(packingCabecera.Empresa, packingCabecera.NumeroDocumento, 
            packingCabecera.anio, packingCabecera.mes, string.Format("{0:yyyyMMdd}", packingCabecera.Fecha, 103), 
            packingCabecera.ClienteCodigo, packingCabecera.ContainerNro, packingCabecera.PrecintoNros,
            out @flag,  out @msgretorno);
        }
        public void ActualizarPackingCab(PackingList packingCabecera, out int flag, out string mensaje)
        {
            Accessor.Spu_Fac_upd_packinglistcab(packingCabecera.Empresa, packingCabecera.NumeroDocumento, packingCabecera.anio,
                packingCabecera.mes, string.Format("{0:yyyyMMdd}", packingCabecera.Fecha, 103), packingCabecera.ClienteCodigo,
                packingCabecera.ContainerNro, packingCabecera.PrecintoNros, out flag, out mensaje);            
        }
        public void TraePackingListNumero(string @FAC61CODEMP, out string @Numero, out string @msgretorno, out int @flag)
        {
            Accessor.Spu_Fac_Trae_PackingListNumero(@FAC61CODEMP, out @Numero, out @msgretorno, out @flag);
        }

      
        #endregion
        #region "Packing list manual"
        public void InsertarPackingListDetManual(PackingList detalle, string @XMLdetalle, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fac_Ins_PackingListDetXmlManual(detalle.Empresa, detalle.NumeroDocumento, @XMLdetalle, out @flag, out @msgretorno);
        }
        public void EliminarPackingListDetManual(PackingList detalle, out int flag, out string mensaje)
        {
            Accessor.Spu_Fac_Del_PackingListDetManual(detalle.Empresa, detalle.NumeroDocumento,
                detalle.Item, out flag, out mensaje);
        }
       
        public void TraeTablaHtml(out string codigoHtmlOut)
        {
            Accessor.Spu_Fac_Trae_TablaHtmlCorreo(out @codigoHtmlOut);
        }

        public void Importar(PackingImportar importacion, out int estadoOperacion, out string mensaje)
        {
            Accessor.Spu_Fac_Ins_PackingImportar(importacion.FAC60CODEMP, importacion.FAC60NUMERO, importacion.FAC60AA,
            importacion.FAC60MM, string.Format("{0:yyyyMMdd}", importacion.FAC60FECHA, 103), importacion.FAC60CLIENTECOD, 
            importacion.FAC60CONTAINERNRO, importacion.FAC60PRECINTONROS, 
            importacion.FAC61ITEM,  importacion.FAC61SECUENCIA,  importacion.FAC61PRODCODCLIENTE,  importacion.FAC61PRODCODEMPRESA,  importacion.FAC61PRODDESCRIPCION, 
            importacion.FAC61PRODLARGO, importacion.FAC61PRODANCHO, importacion.FAC61PRODALTO,  importacion.FAC61PRODLARGOTEXTO, 
            importacion.FAC61PRODANCHOTEXTO,  importacion.FAC61PRODALTOTEXTO, importacion.FAC61PRODPIEZASXCAJAS, importacion.FAC61PRODCANTIDAD,
            importacion.FAC61PRODCAJASCANTIDAD, importacion.FAC61PRODAREA, importacion.FAC61PRODPESO,  importacion.FAC61PRODNROPROFORMACLIENTE, 
            importacion.FAC61PEDIDONUM, importacion.FAC61PEDITEM,  importacion.FAC61OBSERVACIONES,   importacion.FAC61VENTAUNIMED, importacion.FAC61VENTAPRECIO, 
            importacion.FAC61VENTASUBTOTAL,  importacion.flag,  importacion.errores,  importacion.canterrores,  importacion.codigousuario,  importacion.sistema, 
            out estadoOperacion, out mensaje);
        }
        public void EliminarPackingImportar(string @FAC60CODEMP, string @FAC60AA, string @FAC60MM, string @sistema, string @codigousuario, out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Fac_Del_PackingImportar(@FAC60CODEMP, @FAC60AA, @FAC60MM, @sistema, @codigousuario, out @flag, out @msgretorno);
        }

        public void InsertaPackingImportado(string @FAC60CODEMP, string @FAC60AA, string @FAC60MM, string @codigousuario, string @sistema,
        out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fac_Ins_PackingDesdePackingImportar(@FAC60CODEMP,  @FAC60AA, @FAC60MM, @codigousuario, @sistema,  out @flag , out  @msgretorno);
        }

        public List<PackingImportar> TraeValidacionImportacion(string @FAC60CODEMP, string @FAC60AA, string @FAC60MM,
         string @sistema, string @usuario)
        { 
            return Accessor.Spu_Fac_Trae_ValidacionPackingImportador(@FAC60CODEMP, @FAC60AA, @FAC60MM, @sistema, @usuario);
        }

        public DataTable TraeReporteFactura(string @FAC60CODEMP, string @FAC60NUMERO)
        { 
            return Accessor.Spu_Fac_Rep_PackingListFactura(@FAC60CODEMP, @FAC60NUMERO);
        }

        public DataTable TraeReporteCertificadoOrigen(string @FAC60CODEMP, string @FAC60NUMERO)
        {
            return Accessor.Spu_Fac_Rep_CertificadoOrigen(@FAC60CODEMP, @FAC60NUMERO);
        }

        public void EliminaPackingList(string @FAC60CODEMP, string @FAC60NUMERO,
        out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fac_Del_PackingList(@FAC60CODEMP, @FAC60NUMERO,
                                            out @flag, out @msgretorno);
        }
        #endregion

        #region Accessor
        private static PackingListAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return PackingListAccesor.CreateInstance(); }
        }
        #endregion Accessor
    }
}
