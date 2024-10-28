using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using Inv.BusinessEntities;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;

namespace Inv.DataAccess
{
    public abstract class GuiaComprasAccesor : AccessorBase<GuiaComprasAccesor>
    {

        [SprocName("Spu_Inv_Trae_ArticulosSinAtender")]
        public abstract List<Movimiento> Spu_Inv_Trae_ArticulosSinAtender(string @cCodEmp, 
        string  @cAnno,string @cMes, string @cArticulo, string @cAlmacen);

        [SprocName("Spu_Com_Trea_RegistroInventarioCab")]
        public abstract Documento TraerRegistroInventarioCab(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @IN06TIPDOC, string @IN06CODDOC);


        [SprocName("Spu_Com_Trae_DetalleDocumento")]
        public abstract List<Movimiento> Spu_Com_Trae_DetalleDocumento(string @cCodEmp,
        string @cAnno,string @cMes,string @cTipDoc,string @cNumDoc);

        [SprocName("Spu_Inv_Trae_OptPresupuestoArticulo")]
        public abstract void Spu_Inv_Trae_OptPresupuestoArticulo(string @cCodEmp,
        string @cAnno,string @cMes,string @cCenCosto,string @cCodAlm, string @cArticulo,
        string @cMoneda,double @nCantidad,out double @nPresupuesto);

        //insertar
        [SprocName("Spu_Inv_Ins_DetalleDocumentoCan")]
        public abstract void Spu_Inv_Ins_DetalleDocumentoCan(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cKey, string @cCodAlm,
        string @cCodTra,string @cTransa,double @nCanArt,double @nCosUni,
            double @nImport,
        string @dFechaDoc,double @nTipoCambio,string @cMoneda,
        double @nOrden,string @cUnidad,string @IN07CODBLOQUEEMP,
        string @IN07CODBLOQUEPROV,double @IN07LARGO,double @IN07ANCHO,
        double @IN07ALTO,double @IN07LARGOCAN,double @IN07ANCHOCAN,
        double @IN07ALTOCAN, out string @IN07STATUS,out int @flag,
        out string @cMsgRetorno);
            //Spu_Inv_Trae_OptPresupuestoArticulo

        [SprocName("Spu_Inv_Upd_Almacen")]
        public abstract void Spu_Inv_Upd_Almacen(string @cCodEmp,string @cAnno, string @cMes, string @cTranMov,
        string @cCodAlm,string @cKey,int @nOperacion, double @nCanArt,double @nCosUni,
        string @dFechaDoc,double @nTipoCambio, string @cMoneda,string @cUnidad,out int @flag,out string @cMsgRetorno);

        [SprocName("Spu_Com_Trae_DameTotDocumento")]
        public abstract void Spu_Com_Trae_DameTotDocumento(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc,
        string @cNumDoc,string @cMoneda, out double @ntotCant, out double @ntotcDol, out  double @ntotIDol, 
        out  double @ntotcSol, out  double @ntotISol);



        [SprocName("Spu_Com_Trae_AyudaArticulosOrdenCompra")]
        public abstract List<DocumentoOrdenCompraDetalle> Spu_Com_Trae_AyudaArticulosOrdenCompra(string @cCodEmp,
        string @cAnno,string @cMes,string @cTipoOrd,string @cCodigo);


        [SprocName("Spu_Com_Trae_DameNoDetalleMovi")]
        public abstract void Spu_Com_Trae_DameNoDetalleMovi(string @cEmpresa, string @cAno,string @cMes,
        string @cTipdoc,string @cCoddoc,out double @nOrden);


        [SprocName("Spu_Com_Ins_DetalleDocumento")]
        public abstract void Spu_Com_Ins_DetalleDocumento(string @cCodEmp, string @cAnno,string @cMes,
        string @cTipDoc,string @cNumDoc,string @cKey,string @cCodAlm, string @cCodTra,string @cTransa,double @nCanArt,double @nCosUni,
        double @nImport,double @nCosUni_convertido,double @nImport_convertido, string @dFechaDoc,double @nTipoCambio, 
        string @cMoneda,double @nOrden, string @cEmpCom,string @cOrdCom,string @cCorrel,string @cUnidad, string @canoordcom, 
        out int @flag,out string @cMsgRetorno);

        [SprocName("Spu_Com_Del_DetalleDocumento")]
        public abstract void Spu_Com_Del_DetalleDocumento(string @cCodEmp, string @cAnno,
        string @cMes,string @cTipDoc,string @cNumDoc,string @cArticu,double @nOrden,
        string @cTranMov,string @dFechaDoc,double @nTipoCambio,string @cMoneda,
        string @ordcompra,string @anoordcompra,out int @flag,out string @cMsgRetorno);

        [SprocName("Spu_Com_Trae_ExisteArtiXAlma")]
        public abstract void Spu_Com_Trae_ExisteArtiXAlma(string @cCodEmp, string @cAnno, string @cMes,
        string @cAlmacen, out int @cantidadRegistros);

        [SprocName("Spu_Com_Trae_NroOrdenMovi")]
         public abstract void Spu_Com_Trae_NroOrdenMovi(string @cEmpresa,string @cAno,string @cMes,string @cTipdoc,string @cCoddoc,out double @nOrden);

    }
}
