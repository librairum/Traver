using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    
    public class CompraArticuloLogic
    {
        #region Singleton
        private static volatile CompraArticuloLogic instance;
        private static object syncRoot = new Object();
        private CompraArticuloLogic() { }

        public static CompraArticuloLogic Instace 
        {
            get 
            {
                if (instance == null) 
                {
                    lock (syncRoot) 
                    {
                        if (instance == null)
                            instance = new CompraArticuloLogic();
                    }
                }
                return instance;
            }
        }
        #endregion



        public List<ComprasArticuloAlmacen> TraeAlmacenesxArti(string @cCodEmp, string @cAnno, string @cMes, string @cCodigo, string @cCodAlm)
        {
            return Accessor.TraeAlmacenesxArti(@cCodEmp, @cAnno, @cMes, @cCodigo, @cCodAlm);
        }


        public List<CompraProveedoresPorArticulo> TraeProveedor(string @cCodemp, string @cAno, string @cArticulo)
        { 
            return Accessor.TraeProveedor(@cCodemp, @cAno, @cArticulo);
        }


        public List<CompraEquivalenciaPorArticulo> TraeEquivalencia(string @cCodemp, string @cAno, string @cCodigo)
        { 
            return Accessor.TraeEquivalencia(@cCodemp, @cAno, @cCodigo);
        }


        public void TraeVerificacionCodigosColqui(string @cCodEmp, string @cAno, string @cCodigo, string @cOpcion, out string @cFlag)
        { 
            Accessor.TraeVerificacionCodigosColqui(@cCodEmp, @cAno, @cCodigo, @cOpcion, out @cFlag);
        }

        public void EliminarArticulo(string @cEmpresa, string @cAnno, string @cMes, string @cCodigo, 
        string @cFlag, out int @flag, out string @cMsgRetorno)
        { 
            Accessor.EliminarArticulo(@cEmpresa, @cAnno, @cMes, @cCodigo, @cFlag, out @flag, out @cMsgRetorno);
        }

        public void InsertarCabecera(CompraArticulo entidad, out int flag, out string mensaje)
        { 
            Accessor.InsertarCabecera(entidad.codigoEmpresa, entidad.anio, entidad.codigoArticulo, entidad.descripcion,
            entidad.unimed, entidad.codigoProveedor, entidad.movimiento, entidad.unidadEquivalencia,             
            entidad.tipo, entidad.estado, entidad.montoEquivalencia, entidad.unidadMayor,
            entidad.tipoPlactas, out flag, out mensaje);
        }


        public void ActualizarCabecera(CompraArticulo entidad,
        out int flag, out string mensaje)
        {
            Accessor.ActualizarCabecera(entidad.codigoEmpresa, entidad.anio, entidad.codigoArticulo, entidad.descripcion,
                entidad.unimed, entidad.codigoProveedor, entidad.movimiento, entidad.unidadEquivalencia,
                entidad.tipo, entidad.estado, entidad.montoEquivalencia, entidad.unidadMayor, entidad.tipoPlactas,
                out flag, out mensaje);

        }

        public void TraeCodigoGeneradoArtiColqui(string @cCodEmp, string @cAno, 
        string @cLinArt, string @cGrupArt, string @cSubGrupArt, out string @cTraeCodigo)
        { 
            Accessor.TraeCodigoGeneradoArtiColqui(@cCodEmp, @cAno, @cLinArt, 
                                    @cGrupArt, @cSubGrupArt, out @cTraeCodigo);
        }
        public List<UnidaddeMedida> TraeAyudaUnidadMedida(string @cCodEmp, string @cCampo, string @cFiltro)
        { 
            return Accessor.TraeAyudaUnidadMedida(@cCodEmp, @cCampo, @cFiltro);
        }
        public DataTable TraeEstructuraArticulo(string @cCodEmp, string @cAnno, string @cCodigo)
        { 
            return Accessor.TraeEstructuraArticulo(@cCodEmp, @cAnno, @cCodigo);
        }
        public DataTable TraeEstructuraCodigo(string @cSistema, string @cCodigo, string @cTabla)
        { 
            return Accessor.TraeEstructuraCodigo(@cSistema, @cCodigo, @cTabla);
        }

        public List<Articulo> AutocompletarArticulo(string @cCodEmp, string @cAnno, string @cTipoOrd, string @cCampo, string @cFiltro)
        { 
            return Accessor.AutocompletarArticulo(@cCodEmp, @cAnno, @cTipoOrd, @cCampo, @cFiltro);
        }

        public void InsertarTodoArticulo(CompraArticulo arti,
        string XmlDetalleSalida, out int flagSalida, out string mensajeSalida)
        { 
            Accessor.Spu_Com_Ins_ArticuloTodo(arti.codigoEmpresa, arti.anio, 
            arti.codigoArticulo, arti.descripcion, arti.unimed, arti.unidadEquivalencia, 
            arti.montoEquivalencia, arti.codigoProveedor, arti.movimiento,
            arti.unidadMayor, arti.estado, arti.tipo, 
            arti.codigoNaturaleza, arti.tipoPlactas,
            XmlDetalleSalida, out flagSalida, out mensajeSalida);
        }

        #region "Almacen"
        public List<ArticuloPorAlmacen> TraeAlmxArtiRegistro(string @cCodEmp, string @cAnno,
         string @cAlmacen, string @cFiltro)
        {
            return Accessor.TraeAlmxArtiRegistro(@cCodEmp, @cAnno,@cAlmacen,  @cFiltro);
        }

        public List<ArticuloPorAlmacen> TraeAlmxArtiRegistroEtiqueta(string @cCodEmp,
        string @cAnno, string @cMes, string @cAlmacen, string @cFiltro)
        { 
            return Accessor.TraeAlmxArtiRegistroEtiqueta(@cCodEmp,@cAnno, 
                                                 @cMes, @cAlmacen, @cFiltro);
        }

        public void InsertaDetArtixAlm(string @cCodEmp, string @cAnno,string @Mes, string @cCodigo,
        string @cCodAlm, string @cUbicacion, double @nMinimo, double @nSeguridad, 
        double @nMaximo, double @nReponer, double @nStockInicial, double @nPromDolar, 
        double @nImpDolar, double @nPromSoles, double @nImpSoles, string @dFecha, 
        out int @flag, out string @cMsgRetorno) 
        {
                Accessor.InsertaDetArtixAlm(@cCodEmp, @cAnno,@Mes, @cCodigo,
                 @cCodAlm, @cUbicacion, @nMinimo, @nSeguridad, @nMaximo,
                 @nReponer, @nStockInicial, @nPromDolar, @nImpDolar, @nPromSoles,
                 @nImpSoles, @dFecha, out  @flag, out  @cMsgRetorno); 
        }



        public void EliminarDetArtixAlm(string @cCodEmp, string @cAnno,
        string @cCodigo, string @cCodAlm, out int @flag, out string @cMsgRetorno)
        { 
            Accessor.EliminarDetArtixAlm(@cCodEmp, @cAnno, @cCodigo, @cCodAlm, 
                                                    out @flag, out @cMsgRetorno);
        }


        public List<Almacen> TraeAyudaAlmacen(string @cCodEmp, string @cCampo, string @cFiltro)
        {
            return Accessor.TraeAyudaAlmacen(@cCodEmp, @cCampo, @cFiltro);
        }


        public void ActualizaDettArtixAlm(string @cCodEmp, string @cAnno, string @cCodigo, string @cCodAlm,
        string @cUbicacion, double @nMinimo, double @nSeguridad, double @nMaximo, double @nReponer,
        double @nStockInicial, double @nPromDolar, double @nImpDolar, double @nPromSoles, double @nImpSoles,
        string @dFecha, out int @flag, out string @cMsgRetorno)
        {
            Accessor.ActualizaDettArtixAlm(@cCodEmp,
            @cAnno, @cCodigo, @cCodAlm,
            @cUbicacion, @nMinimo, @nSeguridad, @nMaximo, @nReponer,
            @nStockInicial, @nPromDolar, @nImpDolar, @nPromSoles, @nImpSoles,
            @dFecha, out @flag, out @cMsgRetorno);
            
        }
        #endregion
        #region "modulo Facturacion"
        public void InsertarTodoArticuloFact(CompraArticulo arti,
        string XmlDetalleSalida, out int flagSalida, out string mensajeSalida)
        {
            Accessor.InsertarArticuloTodoFact(arti.codigoEmpresa, arti.anio,
            arti.codigoArticulo, arti.descripcion, arti.unimed, arti.unidadEquivalencia,
            arti.montoEquivalencia, arti.codigoProveedor, arti.movimiento,
            arti.unidadMayor, arti.estado, arti.tipo,
            arti.codigoNaturaleza, arti.tipoPlactas,
            XmlDetalleSalida, out flagSalida, out mensajeSalida);
        }

        public void InsertarCabeceraFact(CompraArticulo entidad, out int flag, out string mensaje)
        {
            Accessor.InsertarCabeceraFact(entidad.codigoEmpresa, entidad.anio, entidad.codigoArticulo, entidad.descripcion,
            entidad.unimed, entidad.codigoProveedor, entidad.movimiento, entidad.unidadEquivalencia,
            entidad.tipo, entidad.estado, entidad.montoEquivalencia, entidad.unidadMayor,
            entidad.tipoPlactas, out flag, out mensaje);
        }


        public void ActualizarCabeceraFact(CompraArticulo entidad,
        out int flag, out string mensaje)
        {
            Accessor.ActualizarCabeceraFact(entidad.codigoEmpresa, entidad.anio, entidad.codigoArticulo, entidad.descripcion,
                entidad.unimed, entidad.codigoProveedor, entidad.movimiento, entidad.unidadEquivalencia,
                entidad.tipo, entidad.estado, entidad.montoEquivalencia, entidad.unidadMayor, entidad.tipoPlactas,
                out flag, out mensaje);

        }

        public void EliminarArticuloFact(string @cEmpresa, string @cAnno, string @cMes, string @cCodigo, 
        string @cFlag, out int @flag, out string @cMsgRetorno)
        { 
            
            Accessor.EliminarArticuloFact(@cEmpresa,@cAnno, @cMes, @cCodigo, @cFlag, out @flag, out @cMsgRetorno);
        }

        //EliminarArticuloFact
        #endregion
        #region Accessor
        private static CompraArticulosAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return CompraArticulosAccesor.CreateInstance(); }
        }
        #endregion Accessor
    }
}
