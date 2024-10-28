using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class VentaDocumentoLogic
    {
        #region Singleton
        private static volatile VentaDocumentoLogic instance;
        private static object syncRoot = new Object();
        private VentaDocumentoLogic() { }
        public static VentaDocumentoLogic Instance 
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot) 
                    {
                        if (instance == null)
                            instance = new VentaDocumentoLogic();
                    }
                }
                return instance;
            }
        }
        #endregion

          public DataTable TraeReporteFactura(string @FAC04CODEMP, string @FAC01COD, string @FAC04NUMDOC)
        {
            return Accessor.Spu_Fact_Rep_CabFacturaconDetalle(@FAC04CODEMP, @FAC01COD, @FAC04NUMDOC);
        }
          public DataTable TraeReporteFacturaAnticipo(string @FAC04CODEMP, string @FAC01COD, string @FAC04NUMDOC)
          { 
            return Accessor.Spu_Fact_Rep_FacturaAnticipo(@FAC04CODEMP, @FAC01COD, @FAC04NUMDOC);
          }

          public void InsertarVoucheContable(string @ccc01emp, string @ccc01ano, string @ccc01mes, string @XMLrango,
        out int @flag, out string @MsgRetorno)
        {
            Accessor.Spu_Fact_Ins_VoucherContable(@ccc01emp, @ccc01ano, @ccc01mes, @XMLrango,
            out @flag, out @MsgRetorno);
        }
          public List<Spu_Fact_Trae_DocParaVouCont> TraeDocParaVouCount(string @FAC04CODEMP, string @FAC04AA,
          string @FAC04MM, string @FLAG)
          {
              return Accessor.Spu_Fact_Trae_DocParaVouCont(@FAC04CODEMP, @FAC04AA, @FAC04MM, @FLAG);
          }


        public DataTable TraeReporteDocumentosVenta(string @FAC04CODEMP, string @XMLrango)
        {
            return Accessor.TraeReporteDocumentosVenta(@FAC04CODEMP, @XMLrango);
        }
        public List<DocumentoVentasEmitido> TraeDocumentosVentaEmitido(string @FAC04CODEMP, string @fechaini,
        string @fechafin, string @Flag, string @FAC04TIPANA, string @FAC04CODCLI)
        { 
            return Accessor.TraeDocumentosVentaEmitido( @FAC04CODEMP,  @fechaini,
            @fechafin,  @Flag,  @FAC04TIPANA,  @FAC04CODCLI);
        }
        public List<Spu_Fact_Rep_VentasAnuales> TraeVentasAnuales(string @empresa, string @Anio,
        string @MesInicio, string @MesFin)
        { 
            return Accessor.TraeVentasAnuales(@empresa, @Anio, @MesInicio, @MesFin);
        }
        public List<Spu_Fact_Trae_VentasContabilidad> TraeVentasContabilidad(string @empresa, string @Anio,
        string @MesIni, string @MesFin)
        {
            return Accessor.TraeVentasContabilidad(@empresa, @Anio, @MesIni, @MesFin);
        }

        public List<Spu_Fact_Rep_GuiasCantera> TraeGuiasCantera(string @empresa, string @Anio,
        string @MesIni, string @MesFin)
        {
            return Accessor.TraeGuiasCantera(@empresa, @Anio, @MesIni, @MesFin);
        }
        

        public List<Spu_Fact_Rep_VentaXSede> TraeVentaPorSede(string @FAC04CODEMP, string @FAC04AA,
        string @MESINI, string @MESFIN)
        { 
            return Accessor.TraeVentaPorSede(@FAC04CODEMP, @FAC04AA, @MESINI, @MESFIN);
        }
        public List<Spu_Fac_Trae_RepVentasAdministracion> TraeVentasAdministracion(string @FAC04CODEMP, string @FAC04AA,
        string @FAC04MM, string @TipDoc, string @PlantillaDoc)
        {
            return Accessor.TraeVentasAdministracion(@FAC04CODEMP, @FAC04AA, @FAC04MM, @TipDoc, @PlantillaDoc);
        }

        

        public DataTable TraeRepVentasAdministracion(string @FAC04CODEMP, string @FAC04AA,
        string @FAC04MM, string @TipDoc, string @PlantillaDoc)
        { 
            return Accessor.TraeRepVentasAdministracion(@FAC04CODEMP, @FAC04AA, @FAC04MM, @TipDoc, @PlantillaDoc);
        }


        public List<TraeReporteGuiasAdministracion> TraeGuiasAdministracion(string @FAC34CODEMP,
        string @FAC01COD, string @FAC34AA, string @FAC34MM, string @FAC03COD)
        {
            return Accessor.TraeGuiasAdministracion(@FAC34CODEMP, @FAC01COD, @FAC34AA, @FAC34MM, @FAC03COD);
        }


        public DataTable TraeReporteGuiasAdministracion(string @FAC34CODEMP, string @FAC01COD,
            string @FAC34AA, string @FAC34MM, string @FAC03COD)
        {
            return Accessor.TraeRepGuiasAdministracion(@FAC34CODEMP, @FAC01COD, @FAC34AA, @FAC34MM, @FAC03COD);
        }
        #region Accessor
        private static VentaDocumentoAccesor Accessor
            {
                [System.Diagnostics.DebuggerStepThrough]
                get { return VentaDocumentoAccesor.CreateInstance(); }
            }
        #endregion
    }
}
