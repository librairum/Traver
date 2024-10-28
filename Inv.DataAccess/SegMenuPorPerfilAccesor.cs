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
    public abstract class SegMenuPorPerfilAccesor : AccessorBase<SegMenuPorPerfilAccesor>
    {
        [SprocName("Spu_Seg_Trae_menuxperfil")]
        public abstract List<SegMenuPorPerfil> Trae_Menu_Por_Perfil(string @codigoPerfil, string @cCodModulo);
        [SprocName("Spu_Inv_Traer_OpcionesxMenu")]
        public abstract SegMenuPorPerfil Spu_Inv_Traer_OpcionesxMenu(string @codigoPerfil, string @codmodulo, string @nombreMenu);
    }
}
