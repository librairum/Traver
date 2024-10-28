using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;

namespace Inv.DataAccess
{
    public abstract class Compras_TraerTipoCambioAccesor : AccessorBase<Compras_TraerTipoCambioAccesor>
    {
       


       [SprocName("Spu_Comp_Trae_TipoCambio")]
       public abstract void Spu_Comp_Trae_TipoCambio(string @dFecha, out double @nTipCam);
    }
}
