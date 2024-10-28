using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class CompraDocumentoLogic
    {
         #region Singleton
        private static volatile CompraDocumentoLogic instance;
        private static object syncRoot = new Object();

        private CompraDocumentoLogic() { }

        public static CompraDocumentoLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new CompraDocumentoLogic();
                    }
                }

                return instance;
            }
        }
        #endregion
        public void InsertarOrdenCompra(DodcumentoOrdenCompra entidad, out int flag, out string mensajeRetorno)
        {
            Accessor.Spu_Com_Ins_Orden_Compra(entidad.CodigoEmpresa,
                entidad.Anio, entidad.Mes, entidad.TipoOrdenCompra,
        entidad.CodigoOrdenCompra, string.Format("{0:yyyyMMdd}",entidad.FechaOrdenCompra),
        entidad.CodigoProveedor, entidad.Atencion, entidad.NroSolicitud,
        string.Format("{0:yyyyMMdd}",entidad.FechaSolicitud), entidad.CentroCosto, entidad.CompLocExt,
        entidad.FormaPago, entidad.PlazoEntrega,
        string.Format("{0:yyyyMMdd}", entidad.FechaEntrega), entidad.CodigoEntrega, entidad.DireccionEntrega,
        entidad.TipoCambio, entidad.GiraCheque, entidad.Destino1,
        entidad.Destino2, entidad.Observacion, entidad.ImporteIgv,
        entidad.TipoMoneda, entidad.UsuarioLogistica,
        entidad.CodigoArea, out  flag, out  mensajeRetorno);
        }
        public void ActualizarOrdenCompra(DodcumentoOrdenCompra entidad, out int flag, out string mensajeRetorno)
        {
            Accessor.Spu_Com_Upd_Orden_Compra(entidad.CodigoEmpresa,
                entidad.Anio, entidad.Mes, entidad.TipoOrdenCompra,
            entidad.CodigoOrdenCompra, string.Format("{0:yyyyMMdd}", entidad.FechaOrdenCompra),
            entidad.CodigoProveedor, entidad.Atencion, entidad.NroSolicitud,
            string.Format("{0:yyyyMMdd}", entidad.FechaSolicitud), entidad.CentroCosto, entidad.CompLocExt,
            entidad.FormaPago, entidad.PlazoEntrega,
            string.Format("{0:yyyyMMdd}", entidad.FechaEntrega), entidad.CodigoEntrega, entidad.DireccionEntrega,
            entidad.TipoCambio, entidad.GiraCheque, entidad.Destino1,
            entidad.Destino2, entidad.Observacion, entidad.ImporteIgv,
            entidad.TipoMoneda, entidad.UsuarioLogistica,
            entidad.CodigoArea, out  flag, out  mensajeRetorno);
        }
        //public  void Spu_Com_Upd_Orden_Compra(string @cCodemp, string @cAno, string @cMes, string @cTipoOrdCompra,
        //string @cCodigoOrdCompra, string @cFechaOrdCompra, string @cCodpro, string @cAtencion, string @cNroSolicitud,
        //string @cFechaSolicitud, string @cCentroCosto, string @cCompLocExt, string @cForpag, string @cPlazoEntrega,
        //string @cFechaEntrega, string @cDirEntrega, double @Tipocambio, string @cGirarCheque, string @cDestino1,
        //string @cDestino2, string @cObservacion, double @Igv, string @cTipMon, string @usuariologistica,
        //string @cArea, out int @flag, out string @cMsgRetorno)
        //{

        //}

        public void EliminarOrdenCompra(string @cCodemp, string @cAno, string @cMes, string @cTipo,
        string @cCodigo, out int @flag, out string @cMsgRetorno)
        {
            Accessor.Spu_Com_Del_Orden_Compra(@cCodemp, @cAno, @cMes,
                @cTipo, @cCodigo, out @flag, out @cMsgRetorno);
        }
        public List<DodcumentoOrdenCompra> TraeOrdenesdeCompras(string @cCodemp, string @cAno,
        string @cMes, string @cTipAna, string @cTipOrden)
        {
            return Accessor.Spu_Com_Trae_Orden_Compra(@cCodemp, @cAno,
                    @cMes, @cTipAna, @cTipOrden);
        }

        public void TraeCodigoNroOrden(string @cCodemp, string @Anio,string @cTipo, out string @cNroOrden)
        { 
            Accessor.Spu_Com_Dame_Nro_Orden(@cCodemp,@Anio, @cTipo, out @cNroOrden);
        }

        public List<DocumentoOrdenCompraDetalle> TraeDetalleOrdenCompra(string @cCodEmp, string @cAno, string @cMes, string @cTipo, string @cCodigo)
        { 
        return Accessor.Spu_Com_Trae_Detalle(@cCodEmp, @cAno, @cMes, @cTipo, @cCodigo);
        }

        public void TraeUltimoPrecio(string @cCodEmp, string @cArticulo, out double @cPrecio, out double @cDesc)
        { 
            Accessor.Spu_Com_Trae_UltimoPrecio(@cCodEmp, @cArticulo, out @cPrecio, out @cDesc);
        }

        public void TraeNumeroItemDetalle(string @cCodemp, string @cAno, string @cMes, string @cTipo, string @cCodigo, out double @nOrden)
        {
            Accessor.Spu_Com_Dame_Nro_Detalle(@cCodemp, @cAno, @cMes, @cTipo, @cCodigo, out @nOrden);
        }
        public void InsertarDetalleOrdenCompra(string @cCodemp, string @cAno, string @cMes, string @cTipoOrd,
          string @cCodigoOrd, string @XMLrango, out int @flag, out string @cMsgRetorno)
        { 
            Accessor.Spu_Com_Ins_OrdenCompraDetalle(@cCodemp, @cAno, @cMes, @cTipoOrd, @cCodigoOrd, @XMLrango, 
                        out @flag, out @cMsgRetorno);
        }

        public void EliminarDetalleOrdenCompra(string @cCodemp,  string @cAno,  string @cMes,  string @cTipo,  
        string @cCodigo,  string @cArticu,  out int @flag, out string @mensaje)
        { 
            Accessor.Spu_Com_Del_OrdenCompraDetalle(@cCodemp,  @cAno,  @cMes,  @cTipo,  
                                        @cCodigo,  @cArticu,  out @flag, out @mensaje);
        }
        public void AnulaOrdenCompra(string @cCodemp, string @cAno, string @cMes, 
                        string @cTipo, string @cCodigo, out int @flag, out string @cMsgRetorno)
        { 
            Accessor.Spu_Com_Upd_OrdenCompraAnula(@cCodemp, @cAno, @cMes,  @cTipo, @cCodigo, out @flag, out @cMsgRetorno);
        }

        public DataTable TraeReporteOrdenCompra(string @cCodEmp, string @cAno, string @cMes, string @cAnalisis, string @XMLrango)
        {
            return Accessor.Spu_Com_Rep_OrdCompra(@cCodEmp, @cAno, @cMes, @cAnalisis, @XMLrango);
        }

        public void TraeArituclosPorNaturaleza()
        { 
            
        }


        #region Accessor

        private static CompraDocumentoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return CompraDocumentoAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
