using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class ServiciosAccesor : AccessorBase<ServiciosAccesor>
    {

        [SprocName("Spu_Fac_Trae_NuevoCodigoServicio")]
        public abstract void TraerNuevoCodigo(string @FAC10CODEMP, out string @CodigoNuevo);

        [SprocName("Spu_Fac_Ins_Servicio")]
        public abstract void Spu_Fac_Ins_Servicio(string @FAC10CODEMP, string @FAC10SERVCOD, string @FAC10SERVDESC, string @FAC10SERVCODSUNAT, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fac_Upd_Servicio")]
        public abstract void Spu_Fac_Upd_Servicio(string @FAC10CODEMP, string @FAC10SERVCOD, string @FAC10SERVDESC, string @FAC10SERVCODSUNAT, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fac_Del_Servicio")]
        public abstract void Spu_Fac_Del_Servicio(string @FAC10CODEMP, string @FAC10SERVCOD, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fac_Trae_Servicios")]
        public abstract List<Servicios> Spu_Fac_Trae_Servicios(string @FAC10CODEMP);

    }
}
