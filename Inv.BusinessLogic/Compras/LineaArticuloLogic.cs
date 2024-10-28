using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class LineaArticuloLogic
    {

        #region Singleton
        private static volatile LineaArticuloLogic instance;
        private static object syncRoot = new Object();

        private LineaArticuloLogic() { }

        public static LineaArticuloLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new LineaArticuloLogic();
                    }
                }

                return instance;
            }
        }
        #endregion


        public List<LineaArticulo> TraeLineaArticulo(string @cCodEmp)
        {
            return Accessor.TraeLineaArticulo(@cCodEmp);
        }


        public List<GrupoArticulo> TraeGrupoArticulo(string @cCodEmp, string @cCodLinArt)
        {
            return Accessor.TraeGrupoArticulo(@cCodEmp, @cCodLinArt);
        }


        public List<SubGrupoArticulo> TraeSubGrupoArticulo(string @cCodEmp, string @cCodLinArt, string @cCodGrupArt)
        { 
            return Accessor.TraeSubGrupoArticulo(@cCodEmp, @cCodLinArt, @cCodGrupArt);
        }


        public void InsertarLinArt(string @cCodEmp, string @cCodLinArt, string @cDescripcion,string Anio , 
            out int @flag, out string @cMsgRetorno)
        { 
            Accessor.InsertarLinArt(@cCodEmp, @cCodLinArt, @cDescripcion, Anio, out @flag, out @cMsgRetorno);
        }


        public void ActualizarLinArt(string @cCodEmp, string @cCodLinArt, string @cDescripcion, out int @flag, out string @cMsgRetorno) 
        { 
            Accessor.ActualizarLinArt(@cCodEmp, @cCodLinArt, @cDescripcion, out @flag, out @cMsgRetorno);
        }



        public void InsertarGrupoArticulo(string @cCodEmp, string @cCodLinArt, string @cCodGrupArt, string @cDescripcion, string Anio,
                                            out int @flag, out string @cMsgRetorno) 
        { 
            Accessor.InsertarGrupoArticulo(@cCodEmp, @cCodLinArt, @cCodGrupArt, @cDescripcion, Anio, out @flag, out @cMsgRetorno);
        }


        public void ActualizarGrupoArticulo(string @cCodEmp, string @cCodLinArt, string @cCodGrupArt, string @cDescripcion, out int @flag, out string @cMsgRetorno)
        { 
            Accessor.ActualizarGrupoArticulo(@cCodEmp, @cCodLinArt, @cCodGrupArt, @cDescripcion, out @flag, out @cMsgRetorno);
        }


        public void InsertarSubGrupoArticulo(string @cCodEmp, string @cCodLinArt, string @cCodGrupArt, string @cCodSubGrupArt, string @cDescripcion, 
            string Anio, out int @flag, out string @cMsgRetorno)
        { 
            Accessor.InsertarSubGrupoArticulo(@cCodEmp, @cCodLinArt, @cCodGrupArt, @cCodSubGrupArt, @cDescripcion, Anio, out @flag, out @cMsgRetorno);
        }


        public void ActualizarSubGrupoArticulo(string @cCodEmp, string @cCodLinArt, string @cCodGrupArt, string @cCodSubGrupArt, 
                                                string @cDescripcion, out int @flag, out string @cMsgRetorno)
        { 
            Accessor.ActualizarSubGrupoArticulo(@cCodEmp, @cCodLinArt, @cCodGrupArt, @cCodSubGrupArt, @cDescripcion, out @flag, out @cMsgRetorno);
        }



        public void TraeCodigLineaArticulo(string @cCodEmp, out string @codigogenerado)
        { 
            Accessor.TraeCodigLineaArticulo(@cCodEmp, out @codigogenerado);
        }



        public void TraeCodigoGrupoArticulo(string @cCodEmp, string @cCodLinArt, out string @codigogenerado)
        { 
            Accessor.TraeCodigoGrupoArticulo(@cCodEmp, @cCodLinArt, out @codigogenerado);
        }


        public void TraeCodigoSubGrupoArticulo(string @cCodEmp, string @cCodLinArt, string @cCodGrupArt, out string @codigogenerado)
        { 
            Accessor.TraeCodigoSubGrupoArticulo(@cCodEmp, @cCodLinArt, @cCodGrupArt, out @codigogenerado);
        }


        public void EliminarLineaArticulo(string @cCodEmp, string @cCodigo, out int @flag, out string @cMsgRetorno)
        { 
            Accessor.EliminarLineaArticulo(@cCodEmp, @cCodigo, out @flag, out @cMsgRetorno);
        }


        public void EliminarGrupoArticulo(string @cCodEmp, string @cCodLin, string @cCodGrup,
            out int @flag, out string @cMsgRetorno) 
        { 
            Accessor.EliminarGrupoArticulo(@cCodEmp, @cCodLin, @cCodGrup, out @flag, out @cMsgRetorno);
        }


        public void EliminarSubGrupoArticulo(string @cCodEmp, string @cCodLin, string @cCodGrup,
                                                string @cCodSubGrup, out int @flag, out string @cMsgRetorno)
        { 
            Accessor.EliminarSubGrupoArticulo(@cCodEmp, @cCodLin, @cCodGrup,
                                               @cCodSubGrup, out @flag, out @cMsgRetorno);
        }


        #region Accessor

        private static LineaArticulosAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return LineaArticulosAccesor.CreateInstance(); }
        }

        #endregion Accessor

    }
}
