using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
namespace Inv.DataAccess
{
    public abstract class FuncionesAccessor : AccessorBase<FuncionesAccessor>
    {
        [SprocName("Spu_Pro_Trae_funciones")]
        public abstract List<Funciones> Spu_Pro_Trae_funciones (string @Empresa,string @CodigoModulo);
        
        [SprocName("Spu_Pro_Ins_funciones")]
        public abstract void Spu_Pro_Ins_funciones( string @Empresa, string @Modulo, string @Codigo, string @Titulo,
         string @Descripcion, string @Mensajealusuario,string @Estado, out int @flag, out string @msgretorno);
        
        [SprocName("Spu_Pro_Upd_funciones")]
        public abstract void Spu_Pro_Upd_funciones( string @Empresa, string @Modulo, string @Codigo,
        string @Titulo, string @Descripcion, string @Mensajealusuario, string @Estado, out int @flag, 
        out string @msgretorno);

        [SprocName("Spu_Pro_Del_funciones")]
        public abstract void Spu_Pro_Del_funciones(string @Empresa, string @Codigo,out int @flag, out string @msgretorno);

        [SprocName("Spu_Pro_Trae_FuncionesCodigo")]
        public abstract void Spu_Pro_Trae_FuncionesCodigo (string @Empresa, string @CodigoModulo, out string @Codigo);
    }
}
