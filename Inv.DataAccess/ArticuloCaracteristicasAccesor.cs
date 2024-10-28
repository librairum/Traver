using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;


namespace Inv.DataAccess
{
    public abstract class ArticuloCaracteristicasAccesor : AccessorBase<ArticuloCaracteristicasAccesor>
    {
        [SprocName("Spu_Glo_Help_GloCaracProTerm")]
        public abstract List<ArticuloCaracteristicas> TraerArticuloCaracteristicas(string @glo01codigotabla);

        [SprocName("Spu_Glo_Trae_GloCaracTablas")]
        public abstract List<ArticuloCaracteristicas> ArticuloCaracteristicasTablas(string @glo01codigo);

        [SprocName("Spu_Glo_Trae_Glo01ProdTermCaracReg")]
        public abstract ArticuloCaracteristicas ArticuloCaracteristicasRegistro(string @glo01codigotabla,string @glo01codigo);

        [SprocName("Spu_Glo_Help_GloUnidMedxTipo")]
        public abstract List<ArticuloCaracteristicas> ArticuloCaracticasUnidMedXTipo(string @glo01codigotabla);

        [SprocName("Spu_Glo_Upd_UnidMedxTipo")]
        public abstract void ArticuloUnidadMedidaxTipoActualizar(string @glo01codigotabla, string @glo01codigo, string @glo01anchoUnimed,
                                                            string @glo01largoUnimed, string @glo01altoUnimed, out string @MsgRetorno); 

        // Mantenimiento
        [SprocName("Spu_Inv_Ins_Glo01ProdTermCarac")]
        public abstract void ArticuloCaracteristicasInsertar(string @glo01codigotabla, string @glo01codigo, string @glo01descripcion, string @glo01texto1, string @glocomentario, int @glo01lonCodTabla, double @glo01area, string @glo01descripcionAbreviada, out int @flagok, out string @msgretorno);

        [SprocName("Spu_Inv_Upd_Glo01ProdTermCarac")]
        public abstract void ArticuloCaracteristicasModificar(string @glo01codigotabla, string @glo01codigo, string @glo01descripcion, string @glo01texto1, string @glocomentario, int @glo01lonCodTabla, double @glo01area, string @glo01descripcionAbreviada, out int @flagok, out string @msgretorno);

        [SprocName("Spu_Inv_Del_Glo01ProdTermCarac")]
        public abstract void ArticuloCaracteristicasEliminar(string @glo01codigotabla, string @glo01codigo,out int @flagok, out string @msgretorno);

    }

   }