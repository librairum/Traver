using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class GlobalLogic
    {
        #region Singleton
        private static volatile GlobalLogic instance;
        private static object syncRoot = new Object();

        private GlobalLogic() { }

        public static GlobalLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new GlobalLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public void DameDescripcion(string @cCodigo, string @cFlag, out string @cDescripcion)
        {
            Accessor.DameDescripcion(cCodigo, cFlag, out cDescripcion);
        }
        public void DameValorxDefecto(string @GLO02EMPRESACOD, string @GLO02MODULOCOD, string @GLO02CODIGO,
                                                out string @valorxDefecto)
        {
            Accessor.DameValorxDefecto(@GLO02EMPRESACOD, @GLO02MODULOCOD, @GLO02CODIGO, out  @valorxDefecto);
        }
        public void InsertarRangoImpresion(string @cEmpresa, string @cUsuario, string @cProceso, string @cValor, out string @cMsgRetorno)
        {
            Accessor.InsertarRangoImpresion(cEmpresa, cUsuario, cProceso, cValor, out cMsgRetorno);
        }

        public void EliminarRangoImpresion(string @cEmpresa, string @cUsuario, string @cProceso, out string @cMsgRetorno)
        {
            Accessor.EliminarRangoImpresion(cEmpresa, cUsuario, cProceso, out cMsgRetorno);
        }
        public void TraerNombreModulo(string codigo, out string nombre) {
            Accessor.TraerNombreModulo(codigo, out nombre);            
        }
        /* =================================================================================================================================================== */ 
        /* =========================================================  Mantenimeinto de Valor x Defecto ======================================================== */
        /* =================================================================================================================================================== */ 
        public void InsertarValorxDefecto( ValorxDefecto valorxdefecto, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Pro_Ins_ValorxDefecto( valorxdefecto.GLO02EMPRESACOD, valorxdefecto.GLO02MODULOCOD, 
            valorxdefecto.GLO02CODIGO, valorxdefecto.GLO02DESCRIPCION, valorxdefecto.GLO02VALOR, out @flag,
            out @msgretorno);
        }

        public void ActualizarValorxDefecto(ValorxDefecto valorxdefecto,
                                    out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Pro_Upd_ValorxDefecto( valorxdefecto.GLO02EMPRESACOD, 
            valorxdefecto.GLO02MODULOCOD, valorxdefecto.GLO02CODIGO,
            valorxdefecto.GLO02DESCRIPCION, valorxdefecto.GLO02VALOR,
            out @flag, out @msgretorno);
        }
        public void EliminarValorxDefecto( ValorxDefecto valorxdefecto, out int @flag,
        out string @msgretorno)
        {
            Accessor.Spu_Pro_Del_ValorxDefecto( valorxdefecto.GLO02EMPRESACOD,
            valorxdefecto.GLO02MODULOCOD, valorxdefecto.GLO02CODIGO,           
            out @flag, out @msgretorno);
        }
        public  List<ValorxDefecto> TraerValorxDefecto (string @GLO02EMPRESACOD, string @GLO02MODULOCOD)
        {
            return Accessor.Spu_Pro_Trae_ValoresxDefecto(@GLO02EMPRESACOD,
            @GLO02MODULOCOD); 
        }
        public void TraeValoresxDefectoCodigo(string @GLO02EMPRESACOD, string @GLO02MODULOCOD, 
            out string @GLO02CODIGO)
        {
           Accessor.Spu_Pro_Trae_ValoresxDefectoCodigo(@GLO02EMPRESACOD, @GLO02MODULOCOD,  
                    out @GLO02CODIGO);
        }

        public List<TipoAnalisis>  Spu_Fact_Trae_ccb17ana(string @ccb17emp, string @cCampo, string @cFiltro)
        {
            return  Accessor.Spu_Fact_Trae_ccb17ana(@ccb17emp,@cCampo,@cFiltro);
        }


        public List<CuentaCorriente> Spu_Fact_Trae_Clientes(string @ccm02emp, string @ccm02tipana, string @cCampo, string @cFiltro)
        {
            return Accessor.Spu_Fact_Trae_Clientes(@ccm02emp, @ccm02tipana, @cCampo, @cFiltro);
        }
        
        public List<Moneda> Spu_Fact_Help_FAC54_MONEDA(string @campo, string @filtro)
        {
            return Accessor.Spu_Fact_Help_FAC54_MONEDA( @campo, @filtro);
        }
        public List<Detraccion> Spu_Fact_Help_Detraccion(string @facturafecha)
        {
            return Accessor.Spu_Fact_Help_Detraccion(@facturafecha);
        }
        
        public List<Paises> Spu_Fact_Help_FAC51_PAISES(string @campo, string @filtro)
        {
                 return Accessor.Spu_Fact_Help_FAC51_PAISES(@campo, @filtro);
        }

        public List<FormaPago> Spu_Fact_Help_FAC53_FORMAPAGO(string @campo, string @filtro)
        {
            return Accessor.Spu_Fact_Help_FAC53_FORMAPAGO(@campo, @filtro);
        }

        public List<Puertos> Spu_Fact_Help_FAC52_PUERTOS(string @campo, string @filtro)
        {
            return Accessor.Spu_Fact_Help_FAC52_PUERTOS(@campo, @filtro);
        }

        public List<TablaGlobal> Spu_Glo_Trae_glo01tablas_Det(string @glo01codigotabla, string @cCampo, string @cFiltro)
        {
            return Accessor.Spu_Glo_Trae_glo01tablas_Det(@glo01codigotabla, @cCampo, @cFiltro);
        }

        public List<TablaGlobal> TraeRegistrosDeTablaGlobal(string @glo01codigotabla, string @cCampo, string @cFiltro)
        { 
            return Accessor.TraeRegistrosDeTablaGlobal(@glo01codigotabla, @cCampo, @cFiltro);
        }
        public List<TablaGlobal> TraeTablasGlobales(string @cCampo, string @cFiltro)
        { 
            return Accessor.Spu_Glo_Trae_glo01tablas(@cCampo, @cFiltro);
        }

        public void InsertarTablaGlobal(TablaGlobal campo, out int @flag,
        out string @cMsgRetorno)
        {
            Accessor.Spu_Glo_Ins_glo01tablas(campo.glo01codigotabla,
            campo.glo01codigo, campo.glo01descripcion, campo.glo01texto1,
            campo.glocomentario, out @flag, out @cMsgRetorno);
        }

        public void ActualizarTablaGlobal(TablaGlobal campo, out int @flag,
        out string @cMsgRetorno)
        {
            Accessor.Spu_Glo_Upd_glo01tablas(campo.glo01codigotabla,
            campo.glo01codigo, campo.glo01descripcion, campo.glo01texto1,
            campo.glocomentario, out @flag, out @cMsgRetorno);
        }

        public void EliminarTablaGlobal(TablaGlobal campo,
        out int @flag, out string @cMsgRetorno)
        {
            Accessor.Spu_Glo_Del_glo01tablas(campo.glo01codigotabla, 
                        campo.glo01codigo, out @flag, out @cMsgRetorno);
        }

        public List<Bancos> Spu_Fact_Help_FAC50_BANCOS(string @campo, string @filtro)
        {
            return Accessor.Spu_Fact_Help_FAC50_BANCOS(@campo, @filtro);
            
        }
        public List<PuntoVenta> Spu_Fact_Help_FAC55_PuntoVenta(string @FAC55CODEMP, string @campo, string @Filtro)
        { 
            return Accessor.Spu_Fact_Help_FAC55_PuntoVenta(@FAC55CODEMP, @campo, @Filtro);
        }

        public List<Vendedor> Spu_Fact_Help_FAC56_Vendedor(string @FAC56CODEMP, string @campo, string @Filtro)
        {
            return Accessor.Spu_Fact_Help_FAC56_Vendedor(@FAC56CODEMP, @campo, @Filtro);
        }

        public void DameNroDocumento(string @FAC04CODEMP, string @FAC01COD, string @FAC04SERIEDOC, out string @FAC04NRODOC)
        { 
            Accessor.Spu_Fact_Trae_NumDocFact(@FAC04CODEMP, @FAC01COD, @FAC04SERIEDOC, out @FAC04NRODOC);
        }
        public void DameDescripcionFA(string @cCodigo, string @cFlag, out string @cDescripcion)
        { 
            Accessor.Spu_Fact_Dame_Descripcion(@cCodigo, @cFlag, out @cDescripcion);
        }

        public List<Spu_Fact_Trae_ArtxTip> Spu_Fact_Trae_ArtxTip(string @IN01CODEMP, string @IN01AA,
            string @IN04CODALM, string @opcion)
        { 
            return Accessor.Spu_Fact_Trae_ArtxTip(@IN01CODEMP, @IN01AA, @IN04CODALM,  @opcion);
        }

        public List<Spu_Fact_Trae_ArtxTip> TraeAyudaArtxCliente(string @IN01CODEMP, string @IN01AA, string @opcion)
        {
            return Accessor.Spu_Fac_Trae_ArtxCliente(@IN01CODEMP, @IN01AA, @opcion);
        }
        
        public List<CatalogoFA> TraeAyudaCatalogoFE(string @glo04CodigoTabla)
        {
            return Accessor.Spu_Fact_Help_TablaCatalagoFE(@glo04CodigoTabla);
        }

 
        /* === Prueba de Reporte === */
        public DataTable Spu_Glo_Trae_ConsultaTest()
        {
            return Accessor.Spu_Glo_Trae_ConsultaTest();        
        }
        public List<TablaGlobal> TraeAyudaGlobal(string @glo01codigotabla, string @opcion, string @cCampo, string @cFiltro)
        { 
            return Accessor.Sp_Glo_Trae_glo01tablas(@glo01codigotabla, @opcion, @cCampo, @cFiltro);
        }


        public List<TablaGlobal> TraeHelpDepartamentoFE(string @empresa)
        {
            return Accessor.Spu_Fact_Help_Ubigeo_DepartamentoFE(@empresa);
        }

        public List<TablaGlobal> TraeHelpProvinciaFE(string @CodigoDepartamento)
        {
            return Accessor.Spu_Fact_Help_Ubigeo_ProvinciaFE(@CodigoDepartamento); ;
        }


        public  List<TablaGlobal> TraeHelpDistritoFE(string @CodigoDepartamento, string @CodigoProvincia)
        {
            return Accessor.Spu_Fact_Help_Ubigeo_DistritoFE(@CodigoDepartamento, @CodigoProvincia);
        }

        public List<Funciones> TraeTablas(string @empresa)
        { 
            return Accessor.Spu_Fact_Help_Tablas(@empresa);
        }
        public void InsertarCampoOpcional(string @FAC71TablaDesc, string @FAC71CampoFEDesc, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Ins_CampoOpcional(@FAC71TablaDesc, @FAC71CampoFEDesc, out @flag, out @msgretorno);
        }
        public List<Funciones> TraeCamposOpcionales()
        {
            return Accessor.Spu_Fact_Trae_CamposOpcionales("");
        }
        public void EliminarCampoOpcional(string @FAC71TablaDesc, string @FAC71CampoFEDesc,
        out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Fact_Del_CampoOpcional(@FAC71TablaDesc, @FAC71CampoFEDesc, 
                                                        out @flag, out @msgretorno);
        }
        public void  InsertarEmpresa(Empresa emp, out int @cFlag,  out string @cMsgRetorno)
        {
            Accessor.Spu_Fact_Ins_Empresa(emp.Sistema, emp.Codigo, 
                emp.Nombre,
        emp.Direccion, emp.Representante, emp.Cargo, emp.Igv, emp.Ruc, 
        emp.Ejercicio, emp.Clave, emp.CodEmpContabilidad, emp.CodEmpAlmacen, 
        emp.CorreoFacturaElectonica, 
        emp.DepartamentoCod, emp.ProvinciaCod, emp.DistritoCod, emp.urbanizacion,
        out @cFlag, out @cMsgRetorno);
        }

        public void ActualizarEmpresa(Empresa emp,out int @cFlag, out string @cMsgRetorno)
        {
            Accessor.Spu_Fact_Upd_Empresa(emp.Sistema, emp.Codigo, emp.Nombre,
            emp.Direccion, emp.Representante, emp.Cargo, emp.Igv, emp.Ruc, emp.Ejercicio,
            emp.Clave, emp.CodEmpContabilidad, emp.CodEmpAlmacen, emp.CorreoFacturaElectonica,
            emp.DepartamentoCod, emp.ProvinciaCod, emp.DistritoCod, emp.urbanizacion, 
            out @cFlag, out @cMsgRetorno);
        }

        public void EliminarEmpresa(string @cSistema, string @cCodigo, out string @cMsgRetorno)
        { 
            Accessor.sp_Glo_Del_Empresa(@cSistema, @cCodigo, out @cMsgRetorno);
        }

        public List<Empresa> TraerEmpresas(string @cSistema, string @cOrden)
        { 
            return Accessor.sp_Glo_Trae_Empresas(@cSistema, @cOrden);
        }

        public List<Empresa> TraerEmpresaDet(string @Sistema, string @CodigoEmpresa)
        {
            return Accessor.Spu_Glo_Trae_EmpresaDet(@Sistema, @CodigoEmpresa);
        }

        public List<Empresa> AyudaEmpresa(string @cEmpresa, string @cCampo, string @cFiltro)
        {
            return Accessor.sp_Glo_Help_Empresas(@cEmpresa, @cCampo, @cFiltro);
        }
        public List<Spu_Come_Trae_PackingListTodo> TraePackinglistTodo(string Empresa, 
        string Anio, string Mes)
        { 
            return Accessor.Spu_Come_Trae_PackingListTodo(Empresa,  Anio, Mes);
        }
        public DataTable TraeReportePackingList(string @FAC60CODEMP, string @FAC60NUMERO)
        { 
            return Accessor.Spu_Come_Rep_PackingList(@FAC60CODEMP, @FAC60NUMERO);
        }
        public DataTable TraeReporteFactura(string @FAC04CODEMP, string @FAC04AA,
        string @FAC04MM, string @FAC01COD, string @FAC04NUMDOC, string @NombreEmpresa)
        { 
            return Accessor.Spu_Come_Rep_CabFacturaconDetalle(@FAC04CODEMP, @FAC04AA,
                                    @FAC04MM, @FAC01COD, @FAC04NUMDOC, @NombreEmpresa);
        }
        public  List<Spu_Come_Trae_PackingListTodo> TraeAyudaPackingDisponible(string @FAC60CODEMP,
        string @FAC60AA, string @FAC60MM)
        { 
            return Accessor.Spu_Come_Trae_PackingListConsumible(@FAC60CODEMP,  @FAC60AA, @FAC60MM);
        }
        public void InsertarDetPackingEnGuiaDet(string @CodigoEmpresa, string @FAC01COD, string @FAC34NROGUIA,
        string @NumeroPacking, out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Come_Ins_DetPackingADetGuia(@CodigoEmpresa, @FAC01COD, @FAC34NROGUIA, 
                       @NumeroPacking, out @flag, out @msgretorno);
        }

        public void TraeCodigoProductoSunat(string @IN01CODEMP, string @IN01AA, string @ProductoCodigo, string @opcion, out string @ProductoSunatCod)
        {
            Accessor.Spu_Fact_Trae_CodProdSunat(@IN01CODEMP, @IN01AA, @ProductoCodigo, @opcion, out @ProductoSunatCod);
        }

        public void TipoCambioTraer(string @fecha, out double @nTipCam)
        {
            Accessor.Spu_Fact_Trae_TipoCambio(@fecha, out @nTipCam);
            
        }
        public void DameDescripcionCompras(string @cCodigo, string @cFlag, out string @cDescripcion)
        {
             Accessor.DameDescripcionCompras(@cCodigo, @cFlag, out @cDescripcion);
        }

        #region "Compras"
        public void ComprasDameDescripcion(string @cEmpresa, string @cCodigo, string @cFlag, out string @cDescripcion) { 
            Accessor.ComprasDameDescripcion(@cEmpresa, @cCodigo, @cFlag, out @cDescripcion);
        }
        public List<TablaGlobal> TraeLibros(string @Codigotabla, string @Codigo, string @Filtro)
        { 
            return Accessor.TraeLibros(@Codigotabla, @Codigo, @Filtro);
        }

        public void ComprasTraeTipoProveedor(string @codctacte, out int @canexiste)
        { 
            Accessor.ComprasTraeTipoProveedor(@codctacte, out @canexiste);
        }
        public List<TablaGlobal> ComprasTraeTablas(string @glo01codigotabla, string @opcion, string @cCampo, string @cFiltro)
        {
            return Accessor.ComprasTraeTablas(@glo01codigotabla, @opcion, @cCampo, @cFiltro);
        }
        public void ComprasTraeDimeExisteVoucher(string @cEmpresa, string @cAno, string @cMes, string @cLibro, string @cVoucher, out float @nRegistros)
        {
            Accessor.ComprasTraeDimeExisteVoucher(@cEmpresa, @cAno, @cMes, @cLibro, @cVoucher, out @nRegistros);
        }

        public void ComprasTraeTiCambioFecha(string @dFecha, string @cTipCam, string @cValCam, out float @nTipCam)
        { 
            Accessor.Spu_Glo_Trae_TiCambioFecha(@dFecha, @cTipCam, @cValCam, out @nTipCam);
        }

        public void ComprasTraeEstadoPeriodo(string @cEmpresa, string @cAno, string @cMes, out int @nEstado, out int @nEstadoConc)
        { 
            Accessor.Spu_Glo_Trae_DameEstadoPeriodo(@cEmpresa, @cAno, @cMes, out @nEstado, out @nEstadoConc);
        }

        public List<Libro> TraeAyudaLibroInventario(string @cEmpresa, string @anio, string @cCampo, string @cFiltro)
        {
            return Accessor.TraeAyudaLibroInventario(@cEmpresa, @anio, @cCampo, @cFiltro);
        }

        #endregion
        #region Accessor

        private static GlobalAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return GlobalAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
