using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
using System.Data;

namespace Inv.DataAccess
{
    public abstract class CompraDocumentoAccesor : AccessorBase<CompraDocumentoAccesor>
    {

        [SprocName("Spu_Com_Ins_Orden_Compra")]
        public abstract void Spu_Com_Ins_Orden_Compra(string @cCodemp, string @cAno, string @cMes, string @cTipoOrdCompra,
        string @cCodigoOrdCompra, string @cFechaOrdCompra, string @cCodpro, string @cAtencion, string @cNroSolicitud,
        string @cFechaSolicitud, string @cCentroCosto, string @cCompLocExt, string @cForpag, string @cPlazoEntrega,
        string @cFechaEntrega, string @codEntrega, string @cDirEntrega, double @Tipocambio, string @cGirarCheque, string @cDestino1,
        string @cDestino2, string @cObservacion, double @Igv, string @cTipMon, string @usuariologistica,
        string @cArea, out int @flag, out string @cMsgRetorno);


        [SprocName("Spu_Com_Upd_Orden_Compra")]
        public abstract void Spu_Com_Upd_Orden_Compra(string @cCodemp, string @cAno, string @cMes, string @cTipoOrdCompra,
        string @cCodigoOrdCompra, string @cFechaOrdCompra, string @cCodpro, string @cAtencion, string @cNroSolicitud,
        string @cFechaSolicitud, string @cCentroCosto, string @cCompLocExt, string @cForpag, string @cPlazoEntrega,
        string @cFechaEntrega, string @codEntrega, string @cDirEntrega, double @Tipocambio, string @cGirarCheque, string @cDestino1,
        string @cDestino2, string @cObservacion, double @Igv, string @cTipMon, string @usuariologistica,
        string @cArea, out int @flag, out string @cMsgRetorno);


        [SprocName("Spu_Com_Del_Orden_Compra")]
        public abstract void Spu_Com_Del_Orden_Compra(string @cCodemp,string @cAno,string @cMes,string @cTipo, 
        string @cCodigo,out int @flag,out string @cMsgRetorno);


        [SprocName("Spu_Com_Trae_Orden_Compra")]
        public abstract List<DodcumentoOrdenCompra> Spu_Com_Trae_Orden_Compra(string @cCodemp, string @cAno,  
        string @cMes ,   string @cTipAna , string @cTipOrden );

        [SprocName("Spu_Com_Dame_Nro_Orden")]
        public abstract void Spu_Com_Dame_Nro_Orden(string @cCodemp, string @Anio, string @cTipo, out string @cNroOrden);

        [SprocName("Spu_Com_Trae_Detalle")]
        public abstract List<DocumentoOrdenCompraDetalle> Spu_Com_Trae_Detalle(string @cCodEmp,string @cAno,string @cMes,string @cTipo,string @cCodigo);

        [SprocName("Spu_Com_Trae_UltimoPrecio")]
        public abstract void Spu_Com_Trae_UltimoPrecio(string @cCodEmp,string @cArticulo,out double @cPrecio,out double @cDesc);
        [SprocName("Spu_Com_Dame_Nro_Detalle")]
        public abstract void Spu_Com_Dame_Nro_Detalle(string @cCodemp,string @cAno,string @cMes,string @cTipo,string @cCodigo,out double @nOrden);

        [SprocName("Spu_Com_Ins_OrdenCompraDetalle")]
         public abstract void Spu_Com_Ins_OrdenCompraDetalle(string @cCodemp, string @cAno,  string @cMes,  string @cTipoOrd,    
          string @cCodigoOrd,  string @XMLrango,  out int @flag,  out string @cMsgRetorno);


        [SprocName("Spu_Com_Del_OrdenCompraDetalle")]
        public abstract void Spu_Com_Del_OrdenCompraDetalle(string @cCodemp,  string @cAno,  string @cMes,  string @cTipo,  
        string @cCodigo,  string @cArticu,  out int @flag, out string @mensaje);

        [SprocName("Spu_Com_Upd_OrdenCompraAnula")]
        public abstract void Spu_Com_Upd_OrdenCompraAnula(string @cCodemp,string @cAno,string @cMes,string @cTipo,string @cCodigo,out int @flag,out string @cMsgRetorno);

        //[SprocName("Spu_Com_Rep_OrdCompra")]
        //public abstract DataTable Spu_Com_Rep_OrdCompra(string @cCodEmp,string @cAno, string @cMes, string @cAnalisis, string @cNumeroDocumento);


        [SprocName("Spu_Com_Rep_OrdCompra")]
        public abstract DataTable Spu_Com_Rep_OrdCompra(string @cCodEmp, string @cAno, string @cMes, string @cAnalisis, string @XMLrango);


        
    }
}
