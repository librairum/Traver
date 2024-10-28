using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;


namespace Inv.DataAccess
{
    public abstract class ArticuloPorAlmacenAccesor : AccessorBase<ArticuloPorAlmacenAccesor>
    {
       [SprocName("sp_Inv_Ins_Detalle_Articulo")]
        public abstract void ArticuloPorAlmacenInsertar(string @cCodEmp, string @cAnno, string @cCodigo, string @cCodAlm, 
           string @cUbicacion, double @nMinimo, double @nSeguridad, double @nMaximo, double @nReponer,
            double @nStockInicial, double @nPromDolar, double @nImpDolar, double @nPromSoles, double @nImpSoles, string @dFecha, 
           out string @cMsgRetorno);
        
       
        [SprocName("sp_Inv_Upd_Detalle_Articulo")]
        public abstract void ArticuloPorAlmacenModificar(string @cCodEmp, string @cAnno, string @cCodigo, string @cCodAlm, string @cUbicacion, double @nMinimo, double @nSeguridad, double @nMaximo, double @nReponer,
        double @nStockInicial, double @nPromDolar, double @nImpDolar, double @nPromSoles, double @nImpSoles, string @dFecha, out string @cMsgRetorno);


        [SprocName("sp_Inv_Del_ArticuloxAlmacen")]
        public abstract void ArticuloPorAlmacenEliminar(string @cCodEmp, string @cAnno, string @cCodigo, string @cCodAlm, out string @cMsgRetorno);

    }

   }