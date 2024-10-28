using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
   public class Fac_GuiaTransporteLogic
    {
       #region Singleton
        private static volatile Fac_GuiaTransporteLogic instance;
        private static object syncRoot = new Object();

        private Fac_GuiaTransporteLogic() { }

        public static Fac_GuiaTransporteLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Fac_GuiaTransporteLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public List<GuiaTransporte> TraerGuiasTransporte(string codigoEmpresa, string Anio,
            string Mes, string campo, string filtro)
        {
            return Accessor.TraerGuiasTransporte(codigoEmpresa, Anio, Mes, campo, filtro);
        }

        public List<GuiaTransporte> Spu_Fact_Trae_GuiasParaFacturar(string codigoEmpresa, string Anio,string Mes,string FlagPeriodo,string FechaRangoIni, string FechaRangoFin)
        {
            return Accessor.Spu_Fact_Trae_GuiasParaFacturar(codigoEmpresa, Anio, Mes,FlagPeriodo,FechaRangoIni,FechaRangoFin);
        }

       

        public string Dame_Descripcion(string @cCodigo, string @cFlag, out string @cDescripcion) {
            return Accessor.Spu_Fact_Dame_Descripcion(@cCodigo, @cFlag, out @cDescripcion);
        }
        //string @FAC35CODEMP, string @FAC01COD, string @FAC34NROGUIA
        
        
       /*Funcion para traer ventana de ayuda */


        public DataTable Spu_Fact_Help_FAC03_SUBPLANTILLA(string @FAC03CODEMP, string @FAC01COD, string @campo, 
            string @Filtro, string @NombreUsuario) {
                return Accessor.Spu_Fact_Help_FAC03_SUBPLANTILLA(@FAC03CODEMP, @FAC01COD, @campo, @Filtro, @NombreUsuario);
        }
        //        Set dcHelp.Recordset = CLS_COMANDO.Ejec_Comando_1("Spu_Fact_Help_FAC60_TRANSPORTISTA", gbCodEmpresa, "", "*")

        public DataTable Spu_Fact_Help_FAC60_TRANSPORTISTA(string @FAC60CodEmp, string @campo, string @filtro) {
            return Accessor.Spu_Fact_Help_FAC60_TRANSPORTISTA(@FAC60CodEmp, @campo, @filtro);
        }
        public DataTable Spu_Fact_Trae_FAC03_SUBPLANTILLAXVOUCHER(string @FAC03CODEMP) 
        {
            return Accessor.Trae_FAC03_SUBPLANTILLAXVOUCHER(@FAC03CODEMP);
        }

        public DataTable Spu_Fact_Help_VehxTranporYchofer(string @FAC69Empresa, string @FAC69CodTransportista, string @FAC69Codchofer) {
            return Accessor.Spu_Fact_Help_VehxTranporYchofer(@FAC69Empresa, @FAC69CodTransportista, @FAC69Codchofer);
        }

        public DataTable Spu_Fact_Help_choferxtransportistas(string @FAC61CodEmp, string @FAC69CodTransportista) {
            return Accessor.Spu_Fact_Help_choferxtransportistas(@FAC61CodEmp, @FAC69CodTransportista);
        }

        public DataTable Spu_Fact_Help_FAC64_DESTINATARIO(string @FAC64CodEmp, string @campo, string @filtro) {
            return Accessor.Spu_Fact_Help_FAC64_DESTINATARIO(@FAC64CodEmp, @campo, @filtro);
        }

        public DataTable Spu_Fact_Help_FAC65_DESTINARIOESTAB(string @FAC65CodEmp, string @FAC64CODIGO, string @campo, string @filtro) { 
        return Accessor.Spu_Fact_Help_FAC65_DESTINARIOESTAB( @FAC65CodEmp,  @FAC64CODIGO,  @campo,  @filtro);
        }

        //nuevo ayuda para traer descripcion de descripcion del destino

        public DataTable TraerDestinatarioDireccion(string codigoEmpresa, string codigoCliente, string @campo, string codigoSede)
        {
            return Accessor.Spu_Fact_Help_sedeCliente(codigoEmpresa, codigoCliente, @campo, codigoSede);
        }
        public DataTable Spu_Fact_Help_FAC66_MOTIVODETRASLADO(string @campo, string @filtro) {
            return Accessor.Spu_Fact_Help_FAC66_MOTIVODETRASLADO(@campo, @filtro);
        }

        public DataTable Spu_Fact_Help_FAC63_ESTABLECIMIENTOS(string @FAC63CODEMP, string @campo, string @filtro) {
            return Accessor.Spu_Fact_Help_FAC63_ESTABLECIMIENTOS(@FAC63CODEMP, @campo, @filtro);
        }

        public DataTable Spu_Fact_Help_empresa(string @Sistema, string @campo, string @filtro) { 
            return Accessor.Spu_Fact_Help_empresa(Sistema, @campo, @filtro);
        }

        public DataTable Spu_Fact_Help_FAC67_ESTADOS(string @campo, string @filtro) {
            return Accessor.Spu_Fact_Help_FAC67_ESTADOS(@campo, @filtro);
        }
       //dar de baja guia de transporte
        public void DarBajaGuiaRemision(string @FAC34CODEMP, string @FAC01COD,
          string @FAC34NROGUIA, string @FAC34FECHABAJA, string @FAC34MOTIVOBAJA, out int @flag, out string @msgretorno)
        {
            @flag = 0; @msgretorno = "";
            Accessor.Spu_Fac_Upd_DarBajaGuiaRemision(@FAC34CODEMP, @FAC01COD, @FAC34NROGUIA, 
            @FAC34FECHABAJA, @FAC34MOTIVOBAJA, out @flag, out @msgretorno);
        }
        public string DameNroDocumentoGuia(string @FAC34CODEMP, string @FAC01COD, string @FAC34SERIEGUIA, out string @FAC34NROGUIA) 
        {
            return Accessor.Spu_Fact_Trae_NumGuia(@FAC34CODEMP, @FAC01COD, @FAC34SERIEGUIA, out @FAC34NROGUIA);
        }

        public DataTable TRAE_FAC91_GUIAREMISION_VALORXDEFECTO(string @FAC91CODEMP, string @FAC91SERIEGUIA) 
        {
            return Accessor.TRAE_FAC91_GUIAREMISION_VALORXDEFECTO(@FAC91CODEMP, @FAC91SERIEGUIA);
        }
        public DataTable Spu_Fact_Trae_ArtxTip(string @IN01CODEMP, string @IN01AA, string @IN04CODALM, string @opcion) {
            return Accessor.Spu_Fact_Trae_ArtxTip(@IN01CODEMP, @IN01AA, @IN04CODALM, @opcion);
        }




        public void Spu_Fact_Ins_FAC35_DETGUIA(string @FAC35CODEMP, string @FAC01COD, string @FAC34NROGUIA, 
           out int @FAC35CODGUIADET, string @FAC35CODPROD, string @FAC35DESCPROD, string @FAC35UNIMED, 
            float @FAC35CANTIDAD, float @FA35NROPIEZAS, float @FA35PESO, float @FA35NROCAJAS, string @FAC35CODPROD_PROV,
            string @FAC35DESCPROD_PROV, string @FAC35UNIMED_PROV, 
out int @flag,out string @msgretorno) 
        { 
            Accessor.Spu_Fact_Ins_FAC35_DETGUIA(@FAC35CODEMP, @FAC01COD, @FAC34NROGUIA, 
            out @FAC35CODGUIADET, @FAC35CODPROD, @FAC35DESCPROD, @FAC35UNIMED, 
            @FAC35CANTIDAD, @FA35NROPIEZAS, @FA35PESO, @FA35NROCAJAS, @FAC35CODPROD_PROV,
            @FAC35DESCPROD_PROV, @FAC35UNIMED_PROV, out@flag, out @msgretorno);
        }
public void Spu_Fact_Upd_FAC35_DETGUIA(string @FAC35CODEMP, string @FAC01COD, string @FAC34NROGUIA,
            int @FAC35CODGUIADET, string @FAC35CODPROD, string @FAC35DESCPROD, string @FAC35UNIMED,
            float @FAC35CANTIDAD, float @FA35NROPIEZAS, float @FA35PESO, float @FA35NROCAJAS, string @FAC35CODPROD_PROV,
            string @FAC35DESCPROD_PROV, string @FAC35UNIMED_PROV,
            out int @flag, out string @msgretorno) {
                Accessor.Spu_Fact_Upd_FAC35_DETGUIA(@FAC35CODEMP, @FAC01COD, @FAC34NROGUIA,
                @FAC35CODGUIADET, @FAC35CODPROD, @FAC35DESCPROD, @FAC35UNIMED,
                @FAC35CANTIDAD, @FA35NROPIEZAS, @FA35PESO, @FA35NROCAJAS, @FAC35CODPROD_PROV,
                @FAC35DESCPROD_PROV, @FAC35UNIMED_PROV,
                out @flag, out @msgretorno);
        }
        public void Spu_Fact_Ins_FAC34_GUIAREMISION(GuiaTransporte cabeceraguia,string @xmldocrelacionados, out int flag,out string mensaje) {
            Accessor.Spu_Fact_Ins_FAC34_GUIAREMISION(cabeceraguia.FAC34CODEMP, cabeceraguia.FAC01COD, cabeceraguia.FAC34NROGUIA, cabeceraguia.FAC34SERIEGUIA,
                                                              cabeceraguia.FAC34CORRELATIVOGUIA, cabeceraguia.FAC34AA, cabeceraguia.FAC34MM, cabeceraguia.FAC03COD,
                                                              cabeceraguia.FAC02COD, cabeceraguia.FAC03TIPART, string.Format("{0:yyyyMMdd}", cabeceraguia.FAC34FECHA), cabeceraguia.FAC34ORICODEMP,
                                                              cabeceraguia.FAC34ORICODESTAB, cabeceraguia.FAC34ORIDESESTAB, cabeceraguia.FAC34ORIDOMPARTIDA,
                                                              cabeceraguia.FAC34DESCODEMP, cabeceraguia.FAC34DESDESEMP, cabeceraguia.FAC34DESCODESTAB,
                                                             cabeceraguia.FAC34DESDESESTAB, cabeceraguia.FAC34DESTDIRECCION, cabeceraguia.FAC34CODTRANSPORTISTA,
                                                             cabeceraguia.FAC34DESTRANSPORTISTA, cabeceraguia.FAC34TRAYCODIGO, cabeceraguia.FAC34TRAYMARCA,
                                                             cabeceraguia.FAC34TRAYPLACA, cabeceraguia.FAC34TRAYMARCASR, cabeceraguia.FAC34TRAYPLACASR,
                                                             cabeceraguia.FAC34CHOFCOD, cabeceraguia.FAC34CHOFNOMBRE, cabeceraguia.FAC34CHOFLICCONDUCIR,
                                                             cabeceraguia.FAC34MOTRASLCOD, cabeceraguia.FAC34MOTRASLDESC, cabeceraguia.FAC34MOTRASLDESCEXTRA,
                                                             cabeceraguia.FAC34OBSERVACION, cabeceraguia.FAC34ESTADO, cabeceraguia.FAC34FECHAINITRASLADO,
                                                             cabeceraguia.FAC34REFERENCIA, cabeceraguia.FAC34CONTENEDOR, cabeceraguia.FAC34PRECINTO,
                                                             cabeceraguia.FAC34FLAGORIPROD, cabeceraguia.FAC34CLICOD, cabeceraguia.FAC34OCTIPCOD,
                                                             cabeceraguia.FAC34OCNRO, cabeceraguia.FAC34ESTADOPROCESOCOD, cabeceraguia.FAC34INDITRASLADOVEHICATM1,cabeceraguia.FAC34MODATRASLADO, cabeceraguia.FAC34CODPROV, cabeceraguia.FAC34DESCPROV,  cabeceraguia.FAC34DIRECCPROV, @xmldocrelacionados, out flag, out  mensaje);
            
        }

        public void Spu_Fact_Upd_FAC34_GUIAREMISION(GuiaTransporte cabeceraguia, string @xmldocrelacionados, out int flag, out string mensaje)
        {
            Accessor.Spu_Fact_Upd_FAC34_GUIAREMISION(cabeceraguia.FAC34CODEMP, cabeceraguia.FAC01COD, cabeceraguia.FAC34NROGUIA, cabeceraguia.FAC34SERIEGUIA,
                                                              cabeceraguia.FAC34CORRELATIVOGUIA, cabeceraguia.FAC34AA, cabeceraguia.FAC34MM, cabeceraguia.FAC03COD,
                                                              cabeceraguia.FAC02COD, cabeceraguia.FAC03TIPART,
                                                              string.Format("{0:yyyyMMdd}", cabeceraguia.FAC34FECHA), cabeceraguia.FAC34ORICODEMP,
                                                              cabeceraguia.FAC34ORICODESTAB, cabeceraguia.FAC34ORIDESESTAB, cabeceraguia.FAC34ORIDOMPARTIDA,
                                                              cabeceraguia.FAC34DESCODEMP, cabeceraguia.FAC34DESDESEMP, cabeceraguia.FAC34DESCODESTAB,
                                                             cabeceraguia.FAC34DESDESESTAB, cabeceraguia.FAC34DESTDIRECCION, cabeceraguia.FAC34CODTRANSPORTISTA,
                                                             cabeceraguia.FAC34DESTRANSPORTISTA, cabeceraguia.FAC34TRAYCODIGO, cabeceraguia.FAC34TRAYMARCA,
                                                             cabeceraguia.FAC34TRAYPLACA, cabeceraguia.FAC34TRAYMARCASR, cabeceraguia.FAC34TRAYPLACASR,
                                                             cabeceraguia.FAC34CHOFCOD, cabeceraguia.FAC34CHOFNOMBRE, cabeceraguia.FAC34CHOFLICCONDUCIR,
                                                             cabeceraguia.FAC34MOTRASLCOD, cabeceraguia.FAC34MOTRASLDESC, cabeceraguia.FAC34MOTRASLDESCEXTRA,
                                                             cabeceraguia.FAC34OBSERVACION, cabeceraguia.FAC34ESTADO, cabeceraguia.FAC34FECHAINITRASLADO,
                                                             cabeceraguia.FAC34REFERENCIA, cabeceraguia.FAC34CONTENEDOR, cabeceraguia.FAC34PRECINTO,
                                                             cabeceraguia.FAC34FLAGORIPROD, cabeceraguia.FAC34CLICOD, cabeceraguia.FAC34OCTIPCOD,cabeceraguia.FAC34OCNRO,
                                                             cabeceraguia.FAC34PESOUNIMED, cabeceraguia.FAC34INDITRASLADOVEHICATM1, cabeceraguia.FAC34MODATRASLADO,cabeceraguia.FAC34CODPROV,cabeceraguia.FAC34DESCPROV,cabeceraguia.FAC34DIRECCPROV, @xmldocrelacionados, out flag, out  mensaje);

        }
        public void Spu_Fact_Upd_EstadoGuia(string @FAC34CODEMP, string @FAC01COD, string @FAC34NROGUIA, string @FAC34ESTADONEW,
                                                       out int @flag,out string @msgretorno) {
             Accessor.Spu_Fact_Upd_EstadoGuia(@FAC34CODEMP, @FAC01COD, @FAC34NROGUIA, @FAC34ESTADONEW,out @flag, out @msgretorno);
        }
		public void Spu_Fact_Del_FAC34_GUIAREMISION(string @FAC34CODEMP, string @FAC01COD, string @FAC34NROGUIA, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Del_FAC34_GUIAREMISION(@FAC34CODEMP, @FAC01COD, @FAC34NROGUIA, out @flag, out @msgretorno);
        }
		public void Spu_Fact_Del_FAC35_DETGUIA(string @FAC35CODEMP, string @FAC01COD, string @FAC34NROGUIA, 
            int @FAC35CODGUIADET, out int @flag, out string @msgretorno) {
                Accessor.Spu_Fact_Del_FAC35_DETGUIA(@FAC35CODEMP, @FAC01COD, @FAC34NROGUIA, @FAC35CODGUIADET, out @flag, out @msgretorno);
        }
        public DataTable Spu_Fact_Rep_Guias(string @FAC35CODEMP, string @XMLrango)
        {
            return Accessor.Spu_Fact_Rep_Guias(@FAC35CODEMP, @XMLrango);
        }
        //public DataTable Spu_Fact_Rep_Guias(string @FAC35CODEMP, string @FAC01COD, string @FAC34NROGUIA)
        //{
        //    return Accessor.Spu_Fact_Rep_Guias(@FAC35CODEMP, @FAC01COD, @FAC34NROGUIA);
//}
        public List<GuiaTransporte> TraerGuiaPendientePorFacturar(string @FAC35CODEMP, string @FAC01COD)
        { 
            return Accessor.Spu_Fac_Trae_GuiaPendienteDeFactura(@FAC35CODEMP, @FAC01COD);
        }


        public void ActualizarEstadoProceso(string @XMLdetalle, string @FAC34ESTADOPROCESOCOD,
                string @FAC34ESTADOPROCESOOBSERVACION, string @FAC04ESTADOPROCESOFECHA, string @FAC04ESTADOPROCESOHORA,
                string @FlagOperacion, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Upd_GUIAREMISIONESTADOPROCESO(@XMLdetalle, @FAC34ESTADOPROCESOCOD, @FAC34ESTADOPROCESOOBSERVACION,
            @FAC04ESTADOPROCESOFECHA, @FAC04ESTADOPROCESOHORA, @FlagOperacion, out @flag, out @msgretorno);
        }

        public void Fact_Trae_CantidadUnidadMedida(string @FAC34CODEMP, string @FAC01COD, string @FAC34NROGUIA, out string @FAC34PESOUNIMED, out string @FAC34PESOCANTIDAD)
        {
            Accessor.Spu_Fact_Trae_GuiaRemisionPesoBruto(@FAC34CODEMP, @FAC01COD, @FAC34NROGUIA, out @FAC34PESOUNIMED, out @FAC34PESOCANTIDAD);
        }
        public DataTable Spu_Fact_Trae_DocRelacionxGui(string @FAC34CODEMP, string @FAC01COD, string @FAC34NROGUIA) 
        {
           return Accessor.Spu_Fact_Trae_DocRelacionxGui(@FAC34CODEMP, @FAC01COD, @FAC34NROGUIA);
        }

        #region "Importacion"
        public void InsertarGuiasTransporte(GuiaTransporte cabecera, DetalleGuiaTransporte detalle, int contador, int item,
            string contratista, string labor, string usuario, out int flag, out string mensaje)
        {
            Accessor.Spu_Fac_Ins_GuiasImportar(cabecera.FAC34CODEMP, cabecera.FAC34AA, cabecera.FAC34MM, contador, item,
                detalle.FAC35CANTIDAD, detalle.FAC35UNIMED, detalle.FAC35DESCPROD, detalle.FA35PESO, string.Format("{0:yyyyMMdd}", cabecera.FAC34FECHA),
                cabecera.FAC34SERIEGUIA, cabecera.FAC34NROGUIA,
                cabecera.FAC34MOTRASLDESC, cabecera.FAC34ORIDOMPARTIDA, cabecera.FAC34DESTDIRECCION, cabecera.FAC34CLICOD, cabecera.FAC34CLIDES,
                cabecera.FAC34CODTRANSPORTISTA, cabecera.FAC34DESTRANSPORTISTA, cabecera.FAC34CHOFLICCONDUCIR, cabecera.FAC34CHOFNOMBRE,
                cabecera.FAC34TRAYMARCA, cabecera.FAC34TRAYPLACA, cabecera.FAC34TRAYMARCASR, cabecera.FAC34TRAYPLACASR, contratista,
                labor, usuario, out flag, out mensaje);
        }

        
   


        #endregion
        //public void ActualizarEstadoProceso(string @FAC34CODEMP, string @FAC01COD, string @FAC34NROGUIA,
        //    string @FAC34ESTADOPROCESOCOD, out int @flag, out string @msgretorno)
        //{
        //    Accessor.Spu_Fact_Upd_GUIAREMISIONESTADOPROCESO(@FAC34CODEMP, @FAC01COD, @FAC34NROGUIA, @FAC34ESTADOPROCESOCOD, 
        //        out @flag, out @msgretorno);
        //}
        //}

        #region "Importacion"
        

        public DataTable TraeGuiasImportadas(string @Empresa, string @USUARIO)
        {
            return Accessor.Spu_Fac_Trae_GuiasImportadas(@Empresa, @USUARIO);
        }

   
        public void EliminarGuiasImportadas(string @Empresa, string @USUARIO)
        {
            Accessor.Spu_Fac_Del_GuiasImportadas(@Empresa, @USUARIO);
        }


               public DataTable ValidacionImporteGuias(string @Empresa, string @Anio, string @Mes, string @Usuario, string @flag)
        {
            return Accessor.Spu_Fact_Trae_ValImpGuias(@Empresa, @Anio, @Mes, @Usuario, @flag);
        }

        public void InsertarGuiaRemisionImportada(string @Empresa, string @Anio, string @Mes, string @Usuario, out int @flag, out string @Msgretorno)
        {
            Accessor.Spu_Fact_Ins_GuiasRemisionImp(@Empresa, @Anio, @Mes, @Usuario, out @flag, out @Msgretorno);
        }

 
        
        #endregion
        #region Accessor

        private static GuiaTransporteAccesor  Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return GuiaTransporteAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
