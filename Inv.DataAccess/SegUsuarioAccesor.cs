using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class SegUsuarioAccesor : AccessorBase<SegUsuarioAccesor>
    {
        [SprocName("Spu_Seg_Trae_Autenticacion_Usuario")]
        public abstract List<SegUsuario> Seg_Trae_Autenticacion_Usuario(string @NombreUsuario, string @ClaveUsuario,
            string @codigoEmpresa);
        [SprocName("Spu_Seg_Trae_CodNom_Empresa")]
        public abstract List<Empresa> Seg_Trae_CodNom_Empresa();

        [SprocName("Spu_Seg_Trae_CodNom_Perfil")]
        public abstract List<Segperfil> Seg_Trae_CodNom_Perfil();

        [SprocName("Spu_Seg_Actualizar_Usuario")]
        public abstract void Spu_Seg_Actualizar_Usuario(string @Codigo, string @NombreUsuario, string @NomApe, 
        string @ClaveUsuario, string @CodigoPerfil, string @CodigoEmpresa, out string @msj);

        [SprocName("Spu_Seg_Eliminar_Usuario")]
        public abstract void Spu_Seg_Eliminar_Usuario(string @NombreUsuario, 
        string @ClaveUsuario, string @CodigoPerfil, string @CodigoEmpresa, out string @msj);

        [SprocName("Spu_Seg_Actualizar_Clave")]
        public abstract void Spu_Seg_Actualizar_Clave(string @Codigo, string @ClaveUsuario, string @CodigoPerfil, 
        string @CodigoEmpresa, out string @msj);


        [SprocName("Spu_Seg_Ins_UsuarioxSerie")]
        public abstract void Spu_Seg_Ins_UsuarioxSerie(string @CodigoSerie ,string @CodigoUsuario , 
        out int @flag, out string @mensaje );

        [SprocName("Spu_Seg_Del_UsuarioxSerie")]
        public abstract void Spu_Seg_Del_UsuarioxSerie(string @CodigoSerie, string @CodigoUsuario,
        out int @flag, out string @mensaje);

        [SprocName("Spu_Seg_Trae_TipoDocumentoxUsuario")]
        public abstract List<SegUsuario> Spu_Seg_Trae_TipoDocumentoxUsuario();

        [SprocName("Spu_Seg_Trae_Usuario")]
        public abstract List<SegUsuario> Spu_Seg_Trae_Usuario(string @CodigoEmpresa);

    }
}
