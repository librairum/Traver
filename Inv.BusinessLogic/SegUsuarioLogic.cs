using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.BusinessLogic;
using Inv.DataAccess;
using System.Threading;
namespace Inv.BusinessLogic
{
    public class SegUsuarioLogic
    {
         #region Singleton
        private static volatile SegUsuarioLogic instance;
        private static object syncRoot = new Object();

        private SegUsuarioLogic() { }

        public static SegUsuarioLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SegUsuarioLogic();
                    }
                }

                return instance;
            }
        }
        #endregion
        #region Accessor

        private static SegUsuarioAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return SegUsuarioAccesor.CreateInstance(); }
        }

        #endregion Accessor
        public List<Segperfil> listar_perfil() {
            return Accessor.Seg_Trae_CodNom_Perfil();
        }
        public List<Empresa> listar_empresa() 
        {
            return Accessor.Seg_Trae_CodNom_Empresa();

        }
        private static char Chr(int CharCode)
        {
            if (CharCode < (int)short.MinValue || CharCode > (int)ushort.MaxValue)
            {
                throw new ArgumentException("Argument_RangeTwoBytes1  CharCode");

            }
            else
            {
                if (CharCode >= 0)
                {
                    if (CharCode <= (int)sbyte.MaxValue)
                        return Convert.ToChar(CharCode);
                }
                try
                {
                    Encoding encoding = Encoding.GetEncoding(Thread.CurrentThread.CurrentCulture.TextInfo.ANSICodePage);
                    if (encoding.IsSingleByte && (CharCode < 0 || CharCode > (int)byte.MaxValue))
                        throw new ArgumentException("Error convertir char");
                    char[] chars1 = new char[2];
                    byte[] bytes = new byte[2];
                    Decoder decoder = encoding.GetDecoder();
                    int chars2;
                    if (CharCode >= 0 && CharCode <= (int)byte.MaxValue)
                    {
                        bytes[0] = checked((byte)(CharCode & (int)byte.MaxValue));
                        chars2 = decoder.GetChars(bytes, 0, 1, chars1, 0);
                    }
                    else
                    {
                        bytes[0] = checked((byte)((CharCode & 65280) >> 8));
                        bytes[1] = checked((byte)(CharCode & (int)byte.MaxValue));
                        chars2 = decoder.GetChars(bytes, 0, 2, chars1, 0);
                    }
                    return chars1[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private static int Asc(char String)
        {
            int num1 = Convert.ToInt32(String);
            if (num1 < 128)
                return num1;
            try
            {
                Encoding fileIoEncoding = Encoding.Default;
                char[] chars = new char[1]
                {
                  String
                };
                if (fileIoEncoding.IsSingleByte)
                {
                    byte[] bytes = new byte[1];
                    fileIoEncoding.GetBytes(chars, 0, 1, bytes, 0);
                    return (int)bytes[0];
                }
                else
                {
                    byte[] bytes = new byte[2];
                    if (fileIoEncoding.GetBytes(chars, 0, 1, bytes, 0) == 1)
                        return (int)bytes[0];
                    if (BitConverter.IsLittleEndian)
                    {
                        byte num2 = bytes[0];
                        bytes[0] = bytes[1];
                        bytes[1] = num2;
                    }
                    return (int)BitConverter.ToInt16(bytes, 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Encripta(string cClave)
        {

            cClave = cClave.Trim();

            var cRetorno = "";// cClave.Substring(cClave.Length - 1, 1);

            for (var i = 1; i <= cClave.Length - 1; i++)
            {
                var nLetra = Asc(Convert.ToChar(cClave.Substring(i - 1, 1))) + Asc(Convert.ToChar(cClave.Substring(i, 1)));

                cRetorno = cRetorno + Chr(nLetra);
            }

            return cRetorno + cClave.Substring(cClave.Length - 1, 1);
        }
        public string Desencripta(string cClaveEncriptada)
        {
            var cRetorno = "";

            for (var i = 1; i < cClaveEncriptada.Length; i++)
            {
                var nLetra = Asc(Convert.ToChar(cClaveEncriptada.Substring(i - 1, 1))) - Asc(Convert.ToChar(cClaveEncriptada.Substring(i, 1)));
                cRetorno = cRetorno + Chr(nLetra);
            }

            cRetorno += cClaveEncriptada.Substring(cClaveEncriptada.Length - 1, 1);

            return cRetorno.Trim();
        }

        public List<SegUsuario> Seg_Trae_Autenticacion_Usuario(string NombreUsuario, string ClaveUsuario, string xcodigoEmpresa)
        {
            return Accessor.Seg_Trae_Autenticacion_Usuario(NombreUsuario, ClaveUsuario, xcodigoEmpresa);
        }
        public void Spu_Seg_Actualizar_Usuario(SegUsuario entidad, out string mensaje)
        {
            Accessor.Spu_Seg_Actualizar_Usuario(entidad.Codigo, entidad.NombreUsuario, entidad.NomApe, entidad.ClaveUsuario, entidad.CodigoPerfil,
                entidad.CodigoEmpresa, out mensaje);
        }
        public void Spu_Seg_Eliminar_Usuario(SegUsuario entidad, out string mensaje)
        {
            Accessor.Spu_Seg_Eliminar_Usuario(entidad.NombreUsuario, entidad.ClaveUsuario, entidad.CodigoPerfil, entidad.CodigoEmpresa,
                out mensaje);
            //Accessor.Spu_Seg_Eliminar_Usuario(entidad.NombreUsuario, entidad.ClaveUsuario, entidad.CodigoPerfil,
            //    entidad.CodigoEmpresa, out mensaje);
        }

        public  void Spu_Seg_Actualizar_Clave(SegUsuario xentidad,out string Xmsj) {
            Accessor.Spu_Seg_Actualizar_Clave(xentidad.NombreUsuario, xentidad.ClaveUsuario, xentidad.CodigoPerfil,
                xentidad.CodigoEmpresa, out Xmsj);
        }



        public void InsertarUsuarioxSerie(string @CodigoSerie, string @CodigoUsuario,
        out int @flag, out string @mensaje)
        {
            Accessor.Spu_Seg_Ins_UsuarioxSerie(@CodigoSerie, @CodigoUsuario,
                            out @flag, out @mensaje);
        }


        public void EliminarUsuarioxSerie(string @CodigoSerie, string @CodigoUsuario,
        out int @flag, out string @mensaje)
        { 
            Accessor.Spu_Seg_Del_UsuarioxSerie(@CodigoSerie, @CodigoUsuario, out @flag, out @mensaje);
        }


        public List<SegUsuario> TraeTipoDocumentoxUsuario()
        {
            return Accessor.Spu_Seg_Trae_TipoDocumentoxUsuario();
        }

        /// <summary>
        /// La funcion trae un listado de los usuarios con el perfil de  facturacion Lima
        /// </summary>
        /// <param name="codigoEmpresa">Codigo de empresa</param>
        /// <returns></returns>
        public List<SegUsuario> TraeUsuarios(string codigoEmpresa)
        {
            return Accessor.Spu_Seg_Trae_Usuario(codigoEmpresa);
        }

    }
}
