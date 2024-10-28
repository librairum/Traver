using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using System.Data;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class GlobalAccesor : AccessorBase<GlobalAccesor>
    {
        [SprocName("Spu_Glo_Trae_ValorxDefecto")]
        public abstract void DameValorxDefecto(string @GLO02EMPRESACOD, string @GLO02MODULOCOD, string @GLO02CODIGO, 
                                                out string @valorxDefecto);
        [SprocName("sp_Inv_Dame_Descripcion")]
        public abstract void DameDescripcion(string @cCodigo, string @cFlag, out string @cDescripcion);

        [SprocName("sp_Inv_Ins_Rango_Impresion")]
        public abstract void InsertarRangoImpresion(string @cEmpresa, string @cUsuario, string @cProceso, string @cValor, out string @cMsgRetorno);

        [SprocName("sp_Inv_Del_Rango_Impresion")]
        public abstract void EliminarRangoImpresion(string @cEmpresa, string @cUsuario, string @cProceso, out string @cMsgRetorno);
        [SprocName("Spu_Glo_Trae_Nombredemodulo")]
        public abstract void TraerNombreModulo(string @codigo, out string @nombre);

        /* ===========================================================================================================================================================*/
/* ================================================= Ayuda para Modulo Factura / Cabecera de factura =========================================================*/
        [SprocName("Spu_Fact_Trae_ccb17ana")]
        public abstract List<TipoAnalisis>  Spu_Fact_Trae_ccb17ana(string @ccb17emp,string @cCampo,string @cFiltro);
        
        [SprocName("Spu_Fact_Trae_Clientes")]
        public abstract List<CuentaCorriente> Spu_Fact_Trae_Clientes(string @ccm02emp, string @ccm02tipana, string @cCampo, string @cFiltro);

        [SprocName("Spu_Fact_Help_FAC54_MONEDA")]
        public abstract List<Moneda> Spu_Fact_Help_FAC54_MONEDA(string @campo, string @filtro);
        [SprocName("Spu_Fact_Help_Detraccion")]
        public abstract List<Detraccion> Spu_Fact_Help_Detraccion(string @facturafecha);

        [SprocName("Spu_Fact_Help_FAC51_PAISES")]
        public abstract List<Paises> Spu_Fact_Help_FAC51_PAISES(string @campo, string @filtro);

        [SprocName("Spu_Fact_Help_FAC53_FORMAPAGO")]
        public abstract List<FormaPago> Spu_Fact_Help_FAC53_FORMAPAGO(string @campo, string @filtro);

        [SprocName("Spu_Fact_Help_FAC52_PUERTOS")]
        public abstract List<Puertos> Spu_Fact_Help_FAC52_PUERTOS(string @campo, string @filtro);

        [SprocName("Spu_Glo_Trae_glo01tablas_Det")]
        public abstract List<TablaGlobal> Spu_Glo_Trae_glo01tablas_Det(string @glo01codigotabla, string @cCampo, string @cFiltro);

        [SprocName("Spu_Fact_Help_FAC50_BANCOS")]
        public abstract List<Bancos> Spu_Fact_Help_FAC50_BANCOS(string @campo, string @filtro);
        
        [SprocName("Spu_Fact_Help_FAC55_PuntoVenta")]
        public abstract List<PuntoVenta> Spu_Fact_Help_FAC55_PuntoVenta(string @FAC55CODEMP,string @campo,string @Filtro);

        [SprocName("Spu_Fact_Help_FAC56_Vendedor")]
        public abstract List<Vendedor> Spu_Fact_Help_FAC56_Vendedor(string @FAC56CODEMP, string @campo, string @Filtro);

        [SprocName("Spu_Fact_Trae_NumDocFact")]
        public abstract void Spu_Fact_Trae_NumDocFact(string @FAC04CODEMP, string @FAC01COD, string @FAC04SERIEDOC, out string @FAC04NRODOC);

        [SprocName("Spu_Fact_Dame_Descripcion")]
        public abstract void Spu_Fact_Dame_Descripcion(string @cCodigo, string @cFlag, out string @cDescripcion);

        [SprocName("Spu_Glo_Trae_glo01tablas")]
        public abstract List<TablaGlobal> Spu_Glo_Trae_glo01tablas(string @cCampo, string @cFiltro);

        [SprocName("Spu_Glo_Trae_glo01tablas_Det")]
        public abstract List<TablaGlobal> TraeRegistrosDeTablaGlobal(string @glo01codigotabla, string @cCampo, string @cFiltro);

        
        [SprocName("Spu_Glo_Ins_glo01tablas")]
        public abstract void Spu_Glo_Ins_glo01tablas(string @glo01codigotabla, string @glo01codigo,
        string @glo01descripcion,string @glo01texto1, string @glocomentario, out int @flag, 
        out string @cMsgRetorno);

        [SprocName("Spu_Glo_Upd_glo01tablas")]
        public abstract void Spu_Glo_Upd_glo01tablas(string @glo01codigotabla, string @glo01codigo,
        string @glo01descripcion, string @glo01texto1, string @glocomentario, out int @flag,
        out string @cMsgRetorno);

        [SprocName("Spu_Glo_Del_glo01tablas")]
        public abstract void Spu_Glo_Del_glo01tablas(string @glo01codigotabla, string @glo01codigo, 
        out int @flag,out string @cMsgRetorno);

        /* ===========================================================================================================================================================*/
        
        /* ===========================================================================================================================================================*/
        /* ======================================================== Mantenimiento Tabla :GLO02VALORESXDEFECTO ========================================================*/
        /* ===========================================================================================================================================================*/
        [SprocName("Spu_Pro_Ins_ValorxDefecto")]
        public abstract void Spu_Pro_Ins_ValorxDefecto(string @GLO02EMPRESACOD, string @GLO02MODULOCOD, string @GLO02CODIGO, 
                                        string @GLO02DESCRIPCION, string @GLO02VALOR, out int @flag, out string @msgretorno);
        [SprocName("Spu_Pro_Upd_ValorxDefecto")]
        public abstract void Spu_Pro_Upd_ValorxDefecto(string @GLO02EMPRESACOD, string @GLO02MODULOCOD,string @GLO02CODIGO,
        string @GLO02DESCRIPCION, string @GLO02VALOR, out int @flag,out string @msgretorno);

        [SprocName("Spu_Pro_Del_ValorxDefecto")]
        public abstract void Spu_Pro_Del_ValorxDefecto(string @GLO02EMPRESACOD, string @GLO02MODULOCOD, 
        string @GLO02CODIGO, out int @flag, out string @msgretorno);

        [SprocName("Spu_Pro_Trae_ValoresxDefecto")]
        public abstract List<ValorxDefecto> Spu_Pro_Trae_ValoresxDefecto ( string @GLO02EMPRESACOD, string @GLO02MODULOCOD);
        [SprocName("Spu_Pro_Trae_ValoresxDefectoCodigo")]
        public abstract void Spu_Pro_Trae_ValoresxDefectoCodigo(string @GLO02EMPRESACOD, string @GLO02MODULOCOD, out string @GLO02CODIGO);
        
        [SprocName("Spu_Fact_Trae_ArtxTip")]
        public abstract List<Spu_Fact_Trae_ArtxTip> Spu_Fact_Trae_ArtxTip(string @IN01CODEMP, string @IN01AA, string @IN04CODALM, string @opcion);

        [SprocName("Spu_Fact_Help_TablaCatalagoFE")]
        public abstract List<CatalogoFA> Spu_Fact_Help_TablaCatalagoFE(string @glo04CodigoTabla);

        
        /* ================================================== Procedimiento para prueba de reporte ============================================== */
        [SprocName("Spu_Glo_Trae_ConsultaTest")]
        public abstract DataTable Spu_Glo_Trae_ConsultaTest();

        /* ================================================= Procedimiento para ayuda de Tabla Glboal 01 ========================================= */
        [SprocName("Sp_Glo_Trae_glo01tablas")]
        public abstract List<TablaGlobal> Sp_Glo_Trae_glo01tablas(string @glo01codigotabla, string @opcion, string @cCampo, string @cFiltro);

        [SprocName("Spu_Fact_Help_Ubigeo_DepartamentoFE")]
        public abstract List<TablaGlobal> Spu_Fact_Help_Ubigeo_DepartamentoFE(string @empresa);

        [SprocName("Spu_Fact_Help_Ubigeo_ProvinciaFE")]
        public abstract List<TablaGlobal> Spu_Fact_Help_Ubigeo_ProvinciaFE(string @CodigoDepartamento);

        [SprocName("Spu_Fact_Help_Ubigeo_DistritoFE")]
        public abstract List<TablaGlobal> Spu_Fact_Help_Ubigeo_DistritoFE(string @CodigoDepartamento, string @CodigoProvincia);

        [SprocName("Spu_Fact_Help_Tablas")]
        public abstract List<Funciones> Spu_Fact_Help_Tablas(string @empresa);

        

        /* ===============================================  Mantenimiento de Campos Opcionales =====================================================*/
        [SprocName("Spu_Fact_Trae_CamposOpcionales")]
        public abstract List<Funciones> Spu_Fact_Trae_CamposOpcionales(string @empresa);

        [SprocName("Spu_Fact_Ins_CampoOpcional")]
        public abstract void Spu_Fact_Ins_CampoOpcional(string @FAC71TablaDesc, string @FAC71CampoFEDesc,
        out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Del_CampoOpcional")]
        public abstract void Spu_Fact_Del_CampoOpcional(string @FAC71TablaDesc, string @FAC71CampoFEDesc, 
        out int @flag, out string @msgretorno);
        
        [SprocName("sp_Glo_Trae_Empresas")]
        public abstract List<Empresa> sp_Glo_Trae_Empresas(string @cSistema, string @cOrden);

        [SprocName("Spu_Glo_Trae_EmpresaDet")]
        public abstract List<Empresa> Spu_Glo_Trae_EmpresaDet(string @Sistema, string @CodigoEmpresa);
        
        [SprocName("sp_Glo_Help_Empresas")]
        public abstract List<Empresa> sp_Glo_Help_Empresas(string @cEmpresa, string @cCampo, string @cFiltro);

        [SprocName("Spu_Fact_Ins_Empresa")]
        public abstract void Spu_Fact_Ins_Empresa(string @cSistema, string @cCodigo, string @cNombre,
        string @cDireccion, string @cRepresentante, string @cCargo, int @Igv, string @Ruc, 
        string @cEjercicio, string @cClave, string @cCodEmpContabi, string @cCodEmpAlmacen,
        string @CorreoFacturaElectonica, string @DepartamentoCod, string @ProvinciaCod, 
        string @DistritoCod, string @urbanizacion, out int @cFlag, out string @cMsgRetorno);
        
        [SprocName("Spu_Fact_Upd_Empresa")]
        public abstract void Spu_Fact_Upd_Empresa(string @cSistema,string @cCodigo, string @cNombre, 
        string @cDireccion,string @cRepresentante,string @cCargo,int @Igv, string @Ruc, string @cEjercicio,
        string @cClave, string @cCodEmpContabi, string @cCodEmpAlmacen, string @CorreoFacturaElectonica, 
        string @DepartamentoCod, string @ProvinciaCod,string @DistritoCod,string @urbanizacion,
        out int @cFlag, out string @cMsgRetorno);
        

        [SprocName("sp_Glo_Del_Empresa")]
        public abstract void sp_Glo_Del_Empresa(string @cSistema, string @cCodigo, out string @cMsgRetorno);
        [SprocName("Spu_Come_Trae_PackingListTodo")]
        public abstract List<Spu_Come_Trae_PackingListTodo> Spu_Come_Trae_PackingListTodo(string @FAC60CODEMP, string @FAC60AA,
        string @FAC60MM);
        // Traer reporte de packing list
        [SprocName("Spu_Come_Rep_PackingList")]
        public abstract DataTable Spu_Come_Rep_PackingList(string @FAC60CODEMP, string @FAC60NUMERO);

        [SprocName("Spu_Come_Rep_CabFacturaconDetalle")]
        public abstract DataTable Spu_Come_Rep_CabFacturaconDetalle(string @FAC04CODEMP, string @FAC04AA,
        string @FAC04MM,string @FAC01COD, string @FAC04NUMDOC,string @NombreEmpresa);
        
        [SprocName("Spu_Come_Trae_PackingListConsumible")]
        public abstract List<Spu_Come_Trae_PackingListTodo> Spu_Come_Trae_PackingListConsumible(string @FAC60CODEMP, 
        string @FAC60AA, string @FAC60MM);
        
        [SprocName("Spu_Come_Ins_DetPackingADetGuia")]
        public abstract void Spu_Come_Ins_DetPackingADetGuia(string @CodigoEmpresa, string @FAC01COD, string @FAC34NROGUIA, 
        string @NumeroPacking, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Trae_CodProdSunat")]
        public abstract void Spu_Fact_Trae_CodProdSunat(string @IN01CODEMP, string @IN01AA, string @ProductoCodigo, string @opcion, out string @ProductoSunatCod);

        [SprocName("Spu_Fact_Trae_TipoCambio")]
        public abstract void Spu_Fact_Trae_TipoCambio(string @dFecha, out double @nTipCam);

        [SprocName("Spu_Fac_Trae_ArtxCliente")]
        public abstract List<Spu_Fact_Trae_ArtxTip> Spu_Fac_Trae_ArtxCliente(string @IN01CODEMP, string @IN01AA, string @opcion);
        
        [SprocName("Spu_Com_Trae_Descripcion")]
        public abstract void DameDescripcionCompras(string @cCodigo, string @cFlag, out string @cDescripcion);


        [SprocName("Spu_Com_Dame_Descripcion")]
        public abstract void ComprasDameDescripcion(string @cEmpresa, string @cCodigo, string @cFlag, out string @cDescripcion);


        [SprocName("Spu_Com_Trae_TablasLibros")]
        public abstract List<TablaGlobal> TraeLibros(string @Codigotabla, string @Codigo, string @Filtro);


        [SprocName("Spu_Glo_Trae_TipoProveedor")]
        public abstract void ComprasTraeTipoProveedor(string @codctacte, out int @canexiste);

        [SprocName("Spu_Com_Trae_TablaGlobales")]
        public abstract List<TablaGlobal> ComprasTraeTablas(string @glo01codigotabla, string @opcion, string @cCampo, string @cFiltro);


        [SprocName("Spu_Glo_Trae_DimeExisteVoucher")]
        public abstract void ComprasTraeDimeExisteVoucher(string @cEmpresa, string @cAno, string @cMes, string @cLibro, string @cVoucher, out float @nRegistros);

        [SprocName("Spu_Glo_Trae_TiCambioFecha")]
        public abstract void Spu_Glo_Trae_TiCambioFecha(string @dFecha, string @cTipCam, string @cValCam, out float @nTipCam);


        [SprocName("Spu_Glo_Trae_DameEstadoPeriodo")]
        public abstract void Spu_Glo_Trae_DameEstadoPeriodo(string @cEmpresa, string @cAno, string @cMes, out int @nEstado, out int @nEstadoConc);


        [SprocName("sp_Inv_Help_Libros_Todos")]
        public abstract List<Libro> TraeAyudaLibroInventario(string @cEmpresa,string @anio, string @cCampo, string @cFiltro);
    }
}
