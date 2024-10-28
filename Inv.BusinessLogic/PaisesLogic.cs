using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class PaisesLogic
    {

        #region Singleton
        private static volatile PaisesLogic instance;
        private static object syncRoot = new Object();

        private PaisesLogic() { }

        public static PaisesLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new PaisesLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public List<Paises> TraePaises(string @campo, string @filtro)
        { 
            return Accessor.Spu_Fact_Trae_FAC51PAISES(@campo, @filtro);
        }


        public void InsertarPais(string @FAC51CODPAIS, string @FAC51DESCRIPCION, out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Fact_Ins_FAC51PAISES(@FAC51CODPAIS, @FAC51DESCRIPCION, out @flag, out @msgretorno);
        }

        public void ActualizarPais(string @FAC51CODPAIS, string @FAC51DESCRIPCION, out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Fact_Upd_FAC51PAISES(@FAC51CODPAIS, @FAC51DESCRIPCION, out @flag, out @msgretorno);
        }

        public void EliminarPais(string @FAC51CODPAIS, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Del_FAC51PAISES(@FAC51CODPAIS, out @flag, out @msgretorno);
        }
        #region Accessor

        private static PaisesAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return PaisesAccesor.CreateInstance(); }
        }

        #endregion Accessor

    }
}
