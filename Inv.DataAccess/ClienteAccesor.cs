using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class ClienteAccesor : AccessorBase<ClienteAccesor>
    {
        [SprocName("sp_Inv_Help_Cliente")]
        public abstract List<Cliente> TraerCliente(string @cCodEmp, string @cCampo, string @cFiltro);

        [SprocName("spu_Come_Help_come05sedesCliente")]
        public abstract List<SedesCliente> TraerSedesCliente(string @come05empresa, string @come05clientetipana, string @come05clientecod);

        [SqlQuery(@"Select come05empresa,come05clientetipana,come05clientecod,come05sedeclientescod,come05sedeclientesdesc,come05sedeclientesdireccion
                     from come05sedesCliente
                     Where come05empresa = @come05empresa
                     And come05clientetipana = @come05clientetipana
                     And come05clientecod = @come05clientecod
                     And come05sedeclientescod = @come05sedeclientescod")]
        public abstract SedesCliente ObtenerSedesCliente(string @come05empresa, string @come05clientetipana, string @come05clientecod, string @come05sedeclientescod);
    }
}
