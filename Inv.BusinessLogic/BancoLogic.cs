using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class BancoLogic
    {

         #region Singleton
        private static volatile BancoLogic instance;
        private static object syncRoot = new Object();
        private BancoLogic() { }
        public static BancoLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new BancoLogic();
                    }

                }
                return instance;
            }
        }
        #endregion

        public void InsertarBanco(string @FAC50CODBANCO, string @FAC50DESCRIPCION,
        string @FAC50BANKCODE, string @FAC50ACOUNTNUMBER, out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Fact_Ins_FAC50BANCOS(@FAC50CODBANCO, @FAC50DESCRIPCION,
                @FAC50BANKCODE, @FAC50ACOUNTNUMBER, out @flag, out @msgretorno);
        }


        public void ActualizarBanco(string @FAC50CODBANCO, string @FAC50DESCRIPCION,
        string @FAC50BANKCODE, string @FAC50ACOUNTNUMBER, out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Fact_Upd_FAC50BANCOS(@FAC50CODBANCO, @FAC50DESCRIPCION, 
                 @FAC50BANKCODE, @FAC50ACOUNTNUMBER, out @flag, out @msgretorno);
        }


        public void EliminarBanco(string @FAC50CODBANCO, out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Fact_Del_FAC50BANCOS(@FAC50CODBANCO, out @flag, out @msgretorno);
        }


        public List<Bancos> TraeBancos(string @campo, string @filtro)
        { 
            return Accessor.Spu_Fact_Trae_FAC50BANCOS(@campo, @filtro);
        }

        #region Accessor
        private static BancoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return BancoAccesor.CreateInstance(); }
        }
        #endregion Accessor
    }
}
