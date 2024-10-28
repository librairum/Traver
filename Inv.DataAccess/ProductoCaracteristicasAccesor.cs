using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class ProductoCaracteristicasAccesor : AccessorBase<ProductoCaracteristicasAccesor>
    {

        [SprocName("Spu_Glo_Trae_GLO01PRODUCTOS")]
        public abstract List<ProductoCaracteristicas> Spu_Glo_Trae_GLO01PRODUCTOS(string @cCampo,string @cFiltro);

        [SprocName("Spu_Glo_Trae_GLO01PRODUCTOS_Det")]
        public abstract List<ProductoCaracteristicas> Spu_Glo_Trae_GLO01PRODUCTOS_Det(string @glo01codigotabla, string @cCampo, string @cFiltro);
        [SprocName("Spu_Glo_Ins_GLO01PRODUCTOS")]
        public abstract void Spu_Glo_Ins_GLO01PRODUCTOS(string @glo01codigotabla, string @glo01codigo, string @glo01descripcion, 
        string @glo01texto1, string @glocomentario, out int @flag, out string @cMsgRetorno);
        [SprocName("Spu_Glo_Upd_GLO01PRODUCTOS")]
        public abstract void Spu_Glo_Upd_GLO01PRODUCTOS(string @glo01codigotabla, string @glo01codigo, string @glo01descripcion,
        string @glo01texto1, string @glocomentario, out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Glo_Del_GLO01PRODUCTOS")]
        public abstract void Spu_Glo_Del_GLO01PRODUCTOS(string @glo01codigotabla, string @glo01codigo, out int @flag, out string @cMsgRetorno);

	    
       

        
    }
}
