using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using Inv.BusinessEntities;
using Inv.DataAccess;
namespace Inv.BusinessLogic
{
   public class SegMenuPorPerfilLogic
    {
       #region Singleton
        private static volatile SegMenuPorPerfilLogic instance;
        private static object syncRoot = new Object();

        private SegMenuPorPerfilLogic() { }

        public static SegMenuPorPerfilLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SegMenuPorPerfilLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

       #region Accessor

       private static SegMenuPorPerfilAccesor Accessor
       {
           [System.Diagnostics.DebuggerStepThrough]
           get { return SegMenuPorPerfilAccesor.CreateInstance(); }
       }

       #endregion Accessor

       public List<SegMenuPorPerfil> Trae_Menu_Por_Perfil(string codigoPerfil, string codModulo)
       {
           return Accessor.Trae_Menu_Por_Perfil(codigoPerfil, codModulo);
       }

       public SegMenuPorPerfil Trae_OpcionesPorPerfil(string @codigoPerfil, string @codmodulo,string @nombreMenu)
       {
           return Accessor.Spu_Inv_Traer_OpcionesxMenu(@codigoPerfil, @codmodulo,@nombreMenu);
       }

       public void asiganrpermisosxbotones(string codigoPerfil, string codmodulo, string nombreFormulario, out bool nuevo1, 
                                            out bool editar1,  out bool eliminar1, out bool ver1,
                                            out bool imprimir1, out bool refrescar1, 
                                            out bool importar1, out bool vistaprevia1, out bool guardar1, 
                                            out bool cancelar1, out bool exportarmovimientos,out bool importarMP)
       {
           string permisos = Trae_OpcionesPorPerfil(codigoPerfil, codmodulo ,nombreFormulario).opcxmenu;
           nuevo1 = (permisos.Substring(0, 1).CompareTo("1") == 0);
           editar1 = (permisos.Substring(1, 1).CompareTo("1") == 0);
           eliminar1 = (permisos.Substring(2, 1).CompareTo("1") == 0);
           ver1 = (permisos.Substring(3, 1).CompareTo("1") == 0);
           imprimir1 = (permisos.Substring(4, 1).CompareTo("1") == 0);
           refrescar1 = (permisos.Substring(5, 1).CompareTo("1") == 0);
           importar1 = (permisos.Substring(6, 1).CompareTo("1") == 0);
           vistaprevia1 = (permisos.Substring(7, 1).CompareTo("1") == 0);
           
           exportarmovimientos = (permisos.Substring(8, 1).CompareTo("1") == 0);
           guardar1 = (permisos.Substring(9, 1).CompareTo("1") == 0);
           cancelar1 = (permisos.Substring(10, 1).CompareTo("1") == 0);
           importarMP = (permisos.Substring(11, 1).CompareTo("1") == 0);

       }
    }

    
}
