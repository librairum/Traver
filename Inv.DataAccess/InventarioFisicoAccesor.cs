using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
using System.Data;


namespace Inv.DataAccess
{
    public abstract class InventarioFisicoAccesor : AccessorBase<InventarioFisicoAccesor>
    {
        [SprocName("Spu_Inv_Trae_InvFisicoPorAnio")]
        public abstract List<InventarioFisico> InventarioFisicoPorAnio(string @IN04CODEMP, string @IN04AA);

        [SprocName("Spu_Inv_Del_InvFisico")]
        public abstract void InventarioFisicoEliminar(string @cCodEmp, string @cAlmacen, string @cAno, string @cFecha, out string @Msg);

        [SprocName("sp_Inv_Ins_InvFisArt")]
        public abstract void InventarioFisicoInsertar(string @cCodEmp, string @cAlmacen,string @cAno,string @cFecha,out string @Msg);

        [SprocName("Spu_Inv_Trae_InvFisico")]
        public abstract List<InventarioFisico> InventarioFisicoTraer(string @In04CodEmp, string @in04aa, string @In04CodAlm, string @cFecha);

        [SprocName("Spu_Inv_Rep_InvFisico")]
        public abstract DataTable InventarioFisicoRepToma(string @In04CodEmp, string @in04aa, string @In04CodAlm, string @cFecha);

        [SprocName("Spu_Inv_Rep_InvFisicoDiferencias")]
        public abstract DataTable InventarioFisicoRepDife(string @In04CodEmp, string @in04aa, string @In04CodAlm, string @cFecha);

        [SprocName("Spu_Inv_Upd_InvFisico")]
        public abstract void InventarioFisicoUpd(string @IN04CODEMP, string @IN04AA,string @IN04FECINV,string @IN04CODALM,
            string @IN04KEY,int @IN04ITEM,double @IN04CANTFISICA , string @in04observacion, string @in04estado, out int @FlagOK,out string @Msg);

        [SprocName("Spu_Inv_Upd_InventarioMasivo")]
        public abstract void Spu_Inv_Upd_InventarioMasivo(string @CodEmp, string @Anio, string @FechaInventario,
            string @CodigoAlmacen, string @XMLRango, out int @FlagOK, out string @Msg);
        /*@CodEmp  VARCHAR(02),  -- Codigo de Empresa        
    @Ano  VARCHAR(04), -- Año        
    @FechaInventario varchar(10), -- anio-dia-mes
    @CodigoAlmacen char(2),

    @XMLRango xml    
         @FlagOK int output,
    @Msg varchar(200) output
         */


    }

    
}
