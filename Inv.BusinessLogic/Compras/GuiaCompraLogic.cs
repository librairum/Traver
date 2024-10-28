using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class GuiaCompraLogic
    {
       #region Singleton
       private static volatile GuiaCompraLogic instance;
       private static object syncRoot = new Object();
       private GuiaCompraLogic() { }
       public static GuiaCompraLogic Instance 
       {
           get 
           {
               if (instance == null) 
               {
                   lock (syncRoot) 
                   {
                       if (instance == null)
                           instance = new GuiaCompraLogic();
                   }
               }
               return instance;
           }
       }
       #endregion


       public List<Movimiento> TraeArticulosSinAtender(string @cCodEmp,
       string @cAnno, string @cMes, string @cArticulo, string @cAlmacen)
       { 
        return Accessor.Spu_Inv_Trae_ArticulosSinAtender(@cCodEmp,
            @cAnno, @cMes, @cArticulo, @cAlmacen);
       }

       public Documento TraerRegistroInventarioCab(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @IN06TIPDOC, string @IN06CODDOC)
       {
           return Accessor.TraerRegistroInventarioCab(@IN06CODEMP, @IN06AA, @IN06MM, @IN06TIPDOC, @IN06CODDOC);
       }

       public List<Movimiento> TraeDetalleDocumento(string @cCodEmp,
       string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc)
       {
           return Accessor.Spu_Com_Trae_DetalleDocumento(@cCodEmp, @cAnno,
               @cMes, @cTipDoc, @cNumDoc);

       }


       public void TraePresupuestoArticulo(string @cCodEmp,
       string @cAnno, string @cMes, string @cCenCosto, string @cCodAlm, string @cArticulo,
       string @cMoneda, double @nCantidad, out double @nPresupuesto)
       { 
        Accessor.Spu_Inv_Trae_OptPresupuestoArticulo(@cCodEmp,
            @cAnno, @cMes, @cCenCosto, @cCodAlm, @cArticulo,
            @cMoneda, @nCantidad, out @nPresupuesto);
       }

       //insertar

       public void InsertarDetalleDocumentoCan(Movimiento movi,
           double tipoCambio, string tipoMoneda, out string estado, out int flag,
       out string mensaje)
       {
           Accessor.Spu_Inv_Ins_DetalleDocumentoCan(movi.CodigoEmpresa,
     movi.Anio,
     movi.Mes,
     movi.CodigoTipoDocumento,
     movi.CodigoDocumento,
     movi.CodigoArticulo,
     movi.CodigoAlmacen,
     movi.CodigoTransaccion,
     movi.Transaccion,
     movi.Cantidad,
     movi.CostoUnidad,
     movi.ImporteSoles,
     string.Format("{0:dd/MM/yyyy}", movi.FechaDoc),
     tipoCambio, tipoMoneda, movi.Orden, movi.UnidadMedida,
     movi.CodBloEmp, movi.CodBloqProv, movi.Largo, movi.Ancho,
     movi.Alto, movi.LargoCan, movi.AnchoCan, movi.AltoCan,
     out estado, out flag, out mensaje);

      }



       public void ActualizarAlmacen(string @cCodEmp, string @cAnno, string @cMes, 
       string @cTranMov, string @cCodAlm, string @cKey, int @nOperacion, 
       double @nCanArt, double @nCosUni, string @dFechaDoc, double @nTipoCambio, 
       string @cMoneda, string @cUnidad, out int @flag, out string @cMsgRetorno)
       {
           Accessor.Spu_Inv_Upd_Almacen(@cCodEmp, @cAnno, @cMes, @cTranMov,
               @cCodAlm, @cKey, @nOperacion, @nCanArt, @nCosUni, @dFechaDoc,
               @nTipoCambio, @cMoneda, @cUnidad, out @flag, out @cMsgRetorno);
       }

       public void TraeTotalesDocumento(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc,
       string @cNumDoc, string @cMoneda, out double @ntotCant, out double @ntotcDol, out  double @ntotIDol,
       out  double @ntotcSol, out  double @ntotISol)
       { 
            Accessor.Spu_Com_Trae_DameTotDocumento(@cCodEmp, @cAnno, @cMes, @cTipDoc,
            @cNumDoc,@cMoneda, out @ntotCant, out @ntotcDol, out  @ntotIDol, 
            out  @ntotcSol, out  @ntotISol);
       }
       public List<DocumentoOrdenCompraDetalle> TraeAyudaArticulosOC(string @cCodEmp,
        string @cAnno, string @cMes, string @cTipoOrd, string @cCodigo)
       { 
           
        return Accessor.Spu_Com_Trae_AyudaArticulosOrdenCompra(@cCodEmp,
                                    @cAnno, @cMes, @cTipoOrd, @cCodigo);
       }

       public void TraeDameNoDetalleMovi(string @cEmpresa, string @cAno, string @cMes,
       string @cTipdoc, string @cCoddoc, out double @nOrden)
       {
           Accessor.Spu_Com_Trae_DameNoDetalleMovi(@cEmpresa, @cAno, @cMes, @cTipdoc,
                    @cCoddoc, out @nOrden);
       }


       public  void InsertarDetalleDocumento(string @cCodEmp, string @cAnno, string @cMes,
       string @cTipDoc, string @cNumDoc, string @cKey, string @cCodAlm, 
       string @cCodTra, string @cTransa, double @nCanArt, double @nCosUni,
       double @nImport, double @nCosUni_convertido, double @nImport_convertido, 
       string @dFechaDoc, double @nTipoCambio, string @cMoneda, double @nOrden, 
       string @cEmpCom, string @cOrdCom, string @cCorrel, string @cUnidad, 
       string @canoordcom, out int @flag, out string @cMsgRetorno)
       {
           Accessor.Spu_Com_Ins_DetalleDocumento(@cCodEmp, 
               @cAnno, 
               @cMes,
                @cTipDoc, 
                @cNumDoc, 
                @cKey, 
                @cCodAlm, 
                @cCodTra, 
                @cTransa, 
                @nCanArt, 
                @nCosUni,
                @nImport, 
                @nCosUni_convertido, 
                @nImport_convertido, 
                string.Format("{0:dd/MM/yyyy}",@dFechaDoc), 
                @nTipoCambio,
                @cMoneda, 
                @nOrden, 
                @cEmpCom, 
                @cOrdCom, 
                @cCorrel, 
                @cUnidad, 
                @canoordcom,
          out @flag, out  @cMsgRetorno);
       }
       public void EliminarDetalleDocumento(string @cCodEmp, string @cAnno,
       string @cMes, string @cTipDoc, string @cNumDoc, string @cArticu, double @nOrden,
       string @cTranMov, string @dFechaDoc, double @nTipoCambio, string @cMoneda,
       string @ordcompra, string @anoordcompra, out int @flag, out string @cMsgRetorno)
       { 
        Accessor.Spu_Com_Del_DetalleDocumento( @cCodEmp,  @cAnno,
            @cMes,  @cTipDoc,  @cNumDoc,  @cArticu,  @nOrden,
            @cTranMov,  @dFechaDoc,  @nTipoCambio,  @cMoneda,
            @ordcompra,  @anoordcompra, out  @flag, out  @cMsgRetorno);
       }
       public void TraeExisteArtiXAlma(string @cCodEmp, string @cAnno, string @cMes,
       string @cAlmacen, out int cantidadRegistros)
       {

           Accessor.Spu_Com_Trae_ExisteArtiXAlma(@cCodEmp, @cAnno, @cMes, @cAlmacen, out cantidadRegistros);
       }

       public void TraerNroIrdenMovimiento(string @cEmpresa, string @cAno, string @cMes, string @cTipdoc, string @cCoddoc, out double @nOrden)
       {
           Accessor.Spu_Com_Trae_NroOrdenMovi(@cEmpresa, @cAno, @cMes, @cTipdoc, @cCoddoc, out @nOrden);
           
       }

       #region Accessor
       private static GuiaComprasAccesor Accessor
       {
           [System.Diagnostics.DebuggerStepThrough]
           get { return GuiaComprasAccesor.CreateInstance(); }
       }
       #endregion  
    }
}
