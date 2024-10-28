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
   public abstract class VentaDocumentoAccesor : AccessorBase<VentaDocumentoAccesor>
    {
       [SprocName("Spu_Fact_Rep_CabFacturaconDetalle")]
       public abstract DataTable Spu_Fact_Rep_CabFacturaconDetalle(string @FAC04CODEMP, string @FAC01COD, string @FAC04NUMDOC);

       [SprocName("Spu_Fact_Rep_FacturaAnticipo")]
       public abstract DataTable Spu_Fact_Rep_FacturaAnticipo(string @FAC04CODEMP, string @FAC01COD, string @FAC04NUMDOC);

       [SprocName("Spu_Fact_Trae_DocParaVouCont")]
       public abstract List<Spu_Fact_Trae_DocParaVouCont> Spu_Fact_Trae_DocParaVouCont(string @FAC04CODEMP, string @FAC04AA,
       string @FAC04MM, string @FLAG);

       [SprocName("Spu_Fact_Ins_VoucherContable")]
       public abstract void Spu_Fact_Ins_VoucherContable(string @ccc01emp, string @ccc01ano, string @ccc01mes, string @XMLrango,
       out int @flag, out string @MsgRetorno);

       //Consutla factura por cliente
       [SprocName("Spu_Fac_Rep_ClienteAnalisis")]
       public abstract DataTable TraeReporteDocumentosVenta(string @FAC04CODEMP, string @XMLrango);


       [SprocName("Spu_Fac_Trae_DocumentosVentaEmitido")]
       public abstract List<DocumentoVentasEmitido> TraeDocumentosVentaEmitido(string @FAC04CODEMP, string @fechaini,
       string @fechafin, string @Flag, string @FAC04TIPANA, string @FAC04CODCLI);

       [SprocName("Spu_Fact_Rep_VentasAnuales")]
       public abstract List<Spu_Fact_Rep_VentasAnuales> TraeVentasAnuales(string @empresa, string @Anio,
       string @MesInicio, string @MesFin);

       [SprocName("Spu_Fact_Trae_VentasContabilidad")]
       public abstract List<Spu_Fact_Trae_VentasContabilidad> TraeVentasContabilidad(string @empresa, string @Anio,
       string @MesIni, string @MesFin);

       [SprocName("Spu_Fact_Rep_GuiasCantera")]
       public abstract List<Spu_Fact_Rep_GuiasCantera> TraeGuiasCantera(string @empresa, string @Anio,
       string @MesIni, string @MesFin);

       [SprocName("Spu_Fact_Rep_VentaXSede")]
       public abstract List<Spu_Fact_Rep_VentaXSede> TraeVentaPorSede(string @FAC04CODEMP, string @FAC04AA,
       string @MESINI, string @MESFIN);


       [SprocName("Spu_Fac_Trae_RepVentasAdministracion")]
       public abstract List<Spu_Fac_Trae_RepVentasAdministracion> TraeVentasAdministracion(string @FAC04CODEMP, string @FAC04AA,
       string @FAC04MM, string @TipDoc, string @PlantillaDoc);

       
       [SprocName("Spu_Fac_Trae_RepVentasAdministracion")]
       public abstract DataTable TraeRepVentasAdministracion(string @FAC04CODEMP, string @FAC04AA,
       string @FAC04MM, string @TipDoc, string @PlantillaDoc);



       [SprocName("Spu_Fac_Rep_TraeGuiasAdministracion")]
       public abstract List<TraeReporteGuiasAdministracion> TraeGuiasAdministracion(string @FAC34CODEMP,
       string @FAC01COD, string @FAC34AA, string @FAC34MM, string @FAC03COD);
       
       [SprocName("Spu_Fac_Rep_TraeGuiasAdministracion")]
       public abstract DataTable TraeRepGuiasAdministracion(string @FAC34CODEMP, string @FAC01COD,
       string @FAC34AA, string @FAC34MM, string @FAC03COD);
    }
}
