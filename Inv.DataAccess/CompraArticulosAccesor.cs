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
    public abstract class CompraArticulosAccesor: AccessorBase<CompraArticulosAccesor>
    {

        [SprocName("Spu_Com_Trae_AlmacenesxArticulo")]
        public abstract List<ComprasArticuloAlmacen> TraeAlmacenesxArti(string @cCodEmp, string @cAnno, string @cMes, string @cCodigo, string @cCodAlm);

        [SprocName("Spu_Com_Trae_ProvexArti")]
        public abstract  List<CompraProveedoresPorArticulo> TraeProveedor(string @cCodemp, string @cAno, string @cArticulo);

        [SprocName("Spu_Com_Trae_EquixArti")]
        public abstract List<CompraEquivalenciaPorArticulo> TraeEquivalencia(string @cCodemp, string @cAno, string @cCodigo);

        [SprocName("Spu_Com_Trae_VerificarCodigosColqui")]
        public abstract  void TraeVerificacionCodigosColqui(string @cCodEmp, string @cAno, string @cCodigo, string @cOpcion, out string @cFlag);


        [SprocName("Spu_Com_Del_Articulo")]
        public abstract void EliminarArticulo(string @cEmpresa, string @cAnno, string @cMes, string @cCodigo, string @cFlag, out int @flag, out string @cMsgRetorno);


        


        [SprocName("Spu_Com_Ins_CabeceraArticulo")]
        public abstract void InsertarCabecera(string @cEmpresa, string @cAnno, string @cCodigo, string @cDescripcion,
        string @cUnidad,string @cProveedor,string @cMovimiento, string @cUnidadEquivalente, 
        string @in01tipo,string @in01estado, double @IN01MONTOEQUI,  string @IN01UNIDADMAYOR,  
        string @IN01TIPOPLACTAS,  out int @flag,out string @cMsgRetorno);

        [SprocName("Spu_Com_Upd_CabeceraArticulo")]
        public abstract void ActualizarCabecera(string @cEmpresa, string @cAnno, string @cCodigo,    
        string @cDescripcion, string @cUnidad, string @cProveedor, string @cMovimiento, 
        string @cUnidadEquivalente,  string @in01tipo, string @in01estado, 
        double @IN01MONTOEQUI, string @IN01UNIDADMAYOR, string @IN01TIPOPLACTAS,  
        out int @flag,out string @cMsgRetorno );


        [SprocName("Spu_Com_Trae_CodigoGeneradoArticuloColqui")]
        public abstract void TraeCodigoGeneradoArtiColqui(string @cCodEmp, string @cAno, string @cLinArt, string @cGrupArt, string @cSubGrupArt, out string @cTraeCodigo);

        [SprocName("Spu_Com_Trae_UnidadMedida")]
        public abstract List<UnidaddeMedida> TraeAyudaUnidadMedida(string @cCodEmp,string @cCampo,string @cFiltro);

        [SprocName("Spu_Com_Trae_VerEstructuraArticulo")]
        public abstract DataTable TraeEstructuraArticulo(string @cCodEmp, string @cAnno, string @cCodigo);

        [SprocName("Spu_Com_Trae_EstructuraCodigo")]
        public abstract DataTable TraeEstructuraCodigo(string @cSistema, string @cCodigo, string @cTabla);

        
        [SprocName("Spu_Com_Trae_AutocompletaArticulo")]
        public abstract List<Articulo> AutocompletarArticulo(string @cCodEmp, string @cAnno, string @cTipoOrd, string @cCampo, string @cFiltro);

      

        [SprocName("Spu_Com_Ins_ArticuloTodo")]
        public abstract void Spu_Com_Ins_ArticuloTodo(string @cIN01CODEMP, string @cIN01AA, string @cIN01KEY, string @cIN01DESLAR,
        string @cIN01UNIMED, string @cIN01UNIDADEQUI, double @nIN01MONTOEQUI, string @cIN01CODPRO, string @cIN01MOV,
        string @cIN01UNIDADMAYOR,string @cIN01ESTADO, string @cIN01TIPO, string @cIN01PRODNATURALEZA, string @cIN01TIPOPLACTAS,
        string @XmlDetalle,out int @flag,out string @mensaje);

        #region "Almacen"
        [SprocName("Spu_Com_Trae_AlmacenxArticuloRegistro")]
        public abstract List<ArticuloPorAlmacen> TraeAlmxArtiRegistro(string @cCodEmp, string @cAnno, 
         string @cAlmacen, string @cFiltro);
        
        [SprocName("Spu_Com_Trae_RegistroEtiqueta")]
        public abstract List<ArticuloPorAlmacen> TraeAlmxArtiRegistroEtiqueta(string @cCodEmp,
        string @cAnno,string @cMes,string @cAlmacen,string @cFiltro);

        [SprocName("Spu_Com_Ins_DetalleArticulo")]
        public abstract void InsertaDetArtixAlm(string @cCodEmp,string @cAnno,string @cMes,string @cCodigo,
        string @cCodAlm,string @cUbicacion,double @nMinimo,double @nSeguridad,double @nMaximo,
        double @nReponer, double @nStockInicial,double @nPromDolar,double @nImpDolar,double @nPromSoles,
        double @nImpSoles,string @dFecha,out int @flag,out string @cMsgRetorno);


        [SprocName("Spu_Com_Del_ArticuloxAlmacen")]
        public abstract  void EliminarDetArtixAlm(string @cCodEmp, string @cAnno, 
        string @cCodigo, string @cCodAlm,  out int @flag, out string  @cMsgRetorno);

        [SprocName("Spu_Com_Trae_AyudaAlmacen")]
        public abstract List<Almacen> TraeAyudaAlmacen(string @cCodEmp, string @cCampo, string @cFiltro);

        [SprocName("Spu_Com_Upd_DetalleArticulo")]
        public abstract void ActualizaDettArtixAlm(string @cCodEmp, string @cAnno, string @cCodigo, string @cCodAlm,
        string @cUbicacion,double @nMinimo,double @nSeguridad,double @nMaximo,double @nReponer,
        double @nStockInicial,double @nPromDolar,double @nImpDolar,double @nPromSoles,double @nImpSoles,
        string @dFecha,out int @flag,out string @cMsgRetorno);


  

        #endregion

        #region "Proveedor"

        #endregion

        #region "Modulo Facturacion"
        [SprocName("Spu_Fac_Ins_ArticuloTodo")]
        public abstract void InsertarArticuloTodoFact(string @cIN01CODEMP, string @cIN01AA, string @cIN01KEY, string @cIN01DESLAR,
        string @cIN01UNIMED, string @cIN01UNIDADEQUI, double @nIN01MONTOEQUI, string @cIN01CODPRO, string @cIN01MOV,
        string @cIN01UNIDADMAYOR, string @cIN01ESTADO, string @cIN01TIPO, string @cIN01PRODNATURALEZA, string @cIN01TIPOPLACTAS,
        string @XmlDetalle, out int @flag, out string @mensaje);


        [SprocName("Spu_Fac_Ins_CabeceraArticulo")]
        public abstract void InsertarCabeceraFact(string @cEmpresa, string @cAnno, string @cCodigo, string @cDescripcion,
        string @cUnidad, string @cProveedor, string @cMovimiento, string @cUnidadEquivalente,
        string @in01tipo, string @in01estado, double @IN01MONTOEQUI, string @IN01UNIDADMAYOR,
        string @IN01TIPOPLACTAS, out int @flag, out string @cMsgRetorno);


        [SprocName("Spu_Fac_Upd_CabeceraArticulo")]
        public abstract void ActualizarCabeceraFact(string @cEmpresa, string @cAnno, string @cCodigo,
        string @cDescripcion, string @cUnidad, string @cProveedor, string @cMovimiento,
        string @cUnidadEquivalente, string @in01tipo, string @in01estado,
        double @IN01MONTOEQUI, string @IN01UNIDADMAYOR, string @IN01TIPOPLACTAS,
        out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Fac_Del_Articulo")]
        public abstract void EliminarArticuloFact(string @cEmpresa, string @cAnno, string @cMes, 
            string @cCodigo, string @cFlag, out int @flag, out string @cMsgRetorno);
        
        #endregion

    }
}
