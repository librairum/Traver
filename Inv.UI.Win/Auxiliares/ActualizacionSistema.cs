using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Data.SqlClient;

using Inv.UI.Win.Utilities;
namespace Inv.UI.Win
{
    public class ActualizacionSistema
    {
        private SqlConnection cn;
        //private string nombreArchivoActualizacion = "Actualizacion.config";
        //private string nombreArchivoLocal = "Inv.UI.Win.exe.config";
        private string nombreArchivoLocal = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe.config";

        public ActualizacionSistema()
        { }

        private string LeerXml(string rutaArchivo, string nombreNodo)
        {
            XmlDocument xml;
            XmlNode nodo;
            string valor = "";

            try
            {
                xml = new XmlDocument();
                xml.Load(rutaArchivo);
                //Util.ShowMessage("Ruta archivo:" + rutaArchivo, 1);
                //Util.ShowMessage("nombre nodo:" + nombreNodo, 1);
                nodo = xml.DocumentElement.SelectSingleNode("//configuration/appSettings/add[@key='" + nombreNodo + "']").Attributes["value"];

                valor = nodo.Value.ToString();
                //Util.ShowMessage("valor nodo:" + valor, 1);
            }
            catch (IOException exIO)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al gestionar archivo : " + exIO.Message);
            }
            catch (Exception ex)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al obtener ruta origen version web :" + ex.Message);
            }

            return valor;
        }

        private string LeerXMLConexionWeb()
        {
            XmlDocument xml = new XmlDocument();
            string rutaArchivo = "";
            string valor = "";

            try
            {
                rutaArchivo = Path.Combine(Application.StartupPath, nombreArchivoLocal);
                xml.Load(rutaArchivo);
                XmlNode nodo = xml.DocumentElement.SelectSingleNode("//configuration/connectionStrings/add[@name='cnnInventarioWeb']").Attributes["connectionString"];
                valor = nodo.Value.ToString();
            }
            catch (Exception ex)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al leer xml:" + ex.Message + "ruta de archivo configuracion: " + rutaArchivo + " nodo : cnnInventarioWeb");
            }

            return valor;
        }

        internal string ObtenerNombreArchivoActualizacion()
        {
            string valor = "";
            string rutaConfig = "";

            try
            {
                rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal);
                valor = LeerXml(rutaConfig, "VersionFTP");
            }
            catch (Exception ex)
            {
                // Util.ShowError("Error al obtener nombre de archivo  actualizacion, detalle : " & ex.Message)
                ErrorLogger.RegistrarErrorEnLog(("Error al obtener nombre de archivo  actualizacion, detalle : " + ex.Message));
            }

            return valor;
        }


        internal string ObtenerRutaFTPActualizacion()
        {
            string valor = "";
            string ServidorFTP = "";
            string nombreCarpetaParaActualizacion = "";
            string nombreEmpresa = "";
            string nombreModulo = "";
            string RutaFtp;
            try
            {
                ServidorFTP = ObtenerDireccionFTP();
                nombreEmpresa = ObtenerNombreEmpresa();
                nombreModulo = ObtenerNombreModulo();
                nombreCarpetaParaActualizacion = ObtenerNombreCarpetaActualizacion();

                // / : BackSlash cuando es direccion web
                RutaFtp = ServidorFTP + "/" + nombreEmpresa + "/" + nombreModulo + "/" + nombreCarpetaParaActualizacion;
                valor = RutaFtp.Replace(@"\", "/");
                //Util.ShowMessage("Ruta FPT:" + RutaFtp, 1);
            }
            catch (IOException exIO)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al gestionar archivo : " + exIO.Message);
            }
            // Util.ShowError("Error al gestionar archivo : " & exIO.Message)
            catch (Exception ex)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al obtener ruta origen version web :" + ex.Message);
            }

            return valor;
        }
        internal string ObtenerRutaLocalActualizacion()
        {
            string valor = "";
            string rutaAppData = "";
            string nombreCarpetaParaActualizacion = "";
            string nombreEmpresa = "";
            string nombreModulo = "";
            string RutaActualizacionLocal;
            try
            {
                rutaAppData = ObtenerRutaAppData();
                nombreEmpresa = ObtenerNombreEmpresa();
                nombreModulo = ObtenerNombreModulo();
                nombreCarpetaParaActualizacion = ObtenerNombreCarpetaActualizacion();

                // \ : Slash cuando es direccion local
                RutaActualizacionLocal = rutaAppData + @"\" + nombreEmpresa + @"\" + nombreModulo + @"\" + nombreCarpetaParaActualizacion;
                // valor = Path.Combine(rutaAppData, nombreArchivoActualizacion)
                valor = RutaActualizacionLocal;
            }
            catch (IOException exIO)
            {
                // Util.ShowError("Error al gestionar archivo : " & exIO.Message)
                ErrorLogger.RegistrarErrorEnLog("Error al gestionar archivo : " + exIO.Message);
            }
            catch (Exception ex)
            {
                // Util.ShowError("Error al obtener ruta destino version web :" & ex.Message)
                ErrorLogger.RegistrarErrorEnLog("Error al obtener ruta destino version web :" + ex.Message);
            }

            return valor;
        }




        private string ObtenerNombreConfigWeb()
        {
            string valor = "", rutaConfig = "";
            try
            {
                rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal);
                valor = LeerXml(rutaConfig, "configWeb");
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al obtener nombre de archivo  actualizacion, detalle : " + ex.Message);
            }
            return valor;
        }


        internal string ObtenerRutaOrigenVersionWeb()
        {
            string valor = "", direccionFTP = "", nombreArchivoActualizacion = "";

            try
            {
                direccionFTP = ObtenerDireccionFTP();
                nombreArchivoActualizacion = ObtenerNombreConfigWeb();
                valor = Path.Combine(direccionFTP, nombreArchivoActualizacion);
            }
            catch (IOException exIO)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al gestionar archivo : " + exIO.Message);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al obtener ruta origen version web :" + ex.Message);
            }
            return valor;
        }
        /// <summary>
        /// Direccion destino donde guardar el archivo Actualizacion.config
        /// </summary>
        /// <returns></returns>
        internal string ObtenerRutaDestinoVersionWeb()
        {
            string valor = "", rutaAppData = "", nombreArchivoActualizacion = "";
            try
            {

                rutaAppData = ObtenerRutaAppData();
                nombreArchivoActualizacion = ObtenerNombreConfigWeb();
                valor = Path.Combine(rutaAppData, nombreArchivoActualizacion);

            }
            catch (IOException exIO)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al gestionar archivo : " + exIO.Message);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al obtener ruta destino version web :" + ex.Message);
            }
            return valor;
        }
        internal string ObtenerRutaAppData()
        {
            string valor = "";
            string rutaAppData = "";

            try
            {
                rutaAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                valor = rutaAppData;
            }
            catch (IOException exIO)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al gestionar archivo : " + exIO.Message);
            }
            catch (Exception ex)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al obtener ruta AppData :" + ex.Message);
            }

            return valor;
        }
        internal string ObtenerNombreEmpresa()
        {
            string valor = "";
            string rutaConfig = "";

            try
            {
                rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal);
                valor = LeerXml(rutaConfig, "empresa");
            }
            catch (IOException exIO)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al gestionar archivo : " + exIO.Message);
            }
            // Util.ShowError("Error al gestionar archivo : " & exIO.Message)
            catch (Exception ex)
            {
                // Util.ShowError("Error al obtenerm nombre de empresa :" & ex.Message)
                ErrorLogger.RegistrarErrorEnLog("Error al obtenerm nombre de empresa :" + ex.Message);
            }

            return valor;
        }
        internal string ObtenerNombreModulo()
        {
            string valor = "";
            string rutaConfig = "";

            try
            {
                rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal);
                valor = LeerXml(rutaConfig, "modulo");
            }
            catch (IOException exIO)
            {
                // Util.ShowError("Error al gestionar archivo : " & exIO.Message)
                ErrorLogger.RegistrarErrorEnLog("Error al gestionar archivo : " + exIO.Message);
            }
            catch (Exception ex)
            {
                // Util.ShowError("Error al obtener nombre de modulo :" & ex.Message)
                ErrorLogger.RegistrarErrorEnLog("Error al obtener nombre de modulo :" + ex.Message);
            }

            return valor;
        }
        /// <summary>
        /// Obtiene el nombre de usuario con lectura desde App.config
        /// </summary>
        /// <returns>nombre de usario para ingresar a FTP</returns>        
        internal string ObtenerUsuario()
        {
            string valor = "";
            string rutaConfig = "";

            try
            {
                rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal);
                valor = LeerXml(rutaConfig, "usuario");
            }
            catch (IOException exIO)
            {
                // Util.ShowError("Error al gestionar archivo : " & exIO.Message)
                ErrorLogger.RegistrarErrorEnLog("Error al gestionar archivo : " + exIO.Message);
            }
            catch (Exception ex)
            {
                // Util.ShowError("Error al obtener usuario :" & ex.Message)
                ErrorLogger.RegistrarErrorEnLog("Error al obtener usuario :" + ex.Message);
            }

            return valor;
        }
        /// <summary>
        /// Obtiene la valor de la clave desde el App.config
        /// </summary>
        /// <returns>valor de clave del usuario FTP</returns>
        internal string ObtenerClave()
        {
            string valor = "";
            string rutaConfig = "";

            try
            {
                rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal);
                valor = LeerXml(rutaConfig, "clave");
            }
            catch (IOException exIO)
            {
                // Util.ShowError("Error al gestionar archivo : " & exIO.Message)
                ErrorLogger.RegistrarErrorEnLog("Error al gestionar archivo : " + exIO.Message);
            }
            catch (Exception ex)
            {
                // Util.ShowError("Error al obtener clave :" & ex.Message)
                ErrorLogger.RegistrarErrorEnLog("Error al obtener clave :" + ex.Message);
            }

            return valor;
        }

        internal string ObtenerNombreActualizador()
        {
            string valor = "";
            string rutaConfig = "";

            try
            {
                rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal);
                valor = LeerXml(rutaConfig, "nombreActualizacion");
            }
            catch (IOException exIO)
            {
                // Util.ShowError("Error al gestionar archivo : " & exIO.Message)
                ErrorLogger.RegistrarErrorEnLog("Error al gestionar archivo : " + exIO.Message);
            }
            catch (Exception ex)
            {
                // Util.ShowError("Error al obtener nombre de actualizador:" & ex.Message)
                ErrorLogger.RegistrarErrorEnLog("Error al obtener nombre de actualizador:" + ex.Message);
            }

            return valor;
        }
        /// <summary>
        /// Conexion al ftp con ruta web leido desde el config del programa instalado
        /// </summary>
        /// <returns></returns>
        internal string ObtenerDireccionFTP()
        {
            string valor = "";
            string rutaConfig = "";
            string urlweb = "";
            try
            {
                rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal);
                urlweb = LeerXml(rutaConfig, "urlweb");
                valor = urlweb;
            }
            // valor = valor.Replace("\", "/")
            catch (IOException exIO)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al obtener direccion FTP : " + exIO.Message);
            }
            catch (Exception ex)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al obtener direccion FTP:" + ex.Message);
            }

            return valor;
        }
        internal string ObtenerVersionUsuario()
        {
            string valor = "";
            string rutaConfig = "";

            try
            {
                rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal);
                valor = LeerXml(rutaConfig, "versionUsuario");
            }
            catch (IOException exIO)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al gestionar archivo : " + exIO.Message);
            }
            // Util.ShowError("Error al gestionar archivo : " & exIO.Message)
            catch (Exception ex)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al obtener version :" + ex.Message);
            }

            return valor;
        }
        /// <summary>
        /// Obtiene el valor de la version donde esta ejecutando el proyecto
        /// </summary>
        /// <returns></returns>
        internal string ObtenerVersion()
        {
            string valormododesarrollo = "";
            string valor = "";
            string rutaConfig = "";
            string rutaConfiguracion = "";
            string rutadondeestainstaladoelsistema = "";

            try
            {
                rutaConfiguracion = Path.Combine(Application.StartupPath, nombreArchivoLocal);
                valormododesarrollo = LeerXml(rutaConfiguracion, "modoDesarrollo");
                rutadondeestainstaladoelsistema = LeerXml(rutaConfiguracion, "RutaDondeEstaInstaladoElPrograma");

                if (valormododesarrollo == "NO")
                {
                    rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal);
                    valor = LeerXml(rutaConfig, "version");
                }
                else
                {
                    rutaConfiguracion = Path.Combine(rutadondeestainstaladoelsistema, nombreArchivoLocal);
                    valor = LeerXml(rutaConfiguracion, "version");
                }
            }
            catch (IOException exIO)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al gestionar archivo : " + exIO.Message);
            }
            // Util.ShowError("Error al gestionar archivo : " & exIO.Message)
            catch (Exception ex)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al obtener version :" + ex.Message);
            }

            return valor;
        }
        /// <summary>
        /// Obtiene la version del archivo Actualizacion.config en AppData
        /// </summary>
        /// <returns>Valor de la version</returns>
        internal string ObtenerVersionWeb(string RutaLocalActualizacion, string ArchivoNombre)
        {
            string valor = "";
            string rutaConfigWeb = "";

            try
            {
                rutaConfigWeb = Path.Combine(RutaLocalActualizacion, ArchivoNombre);
                valor = LeerXml(rutaConfigWeb, "version");
            }
            catch (IOException exIO)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al gestionar archivo : " + exIO.Message);
            }
            catch (Exception ex)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al obtener version web:" + ex.Message);
            }

            return valor;
        }


        internal bool EsModoActualiza()
        {
            string valor = "";
            string rutaConfiguracion = "";
            bool estado = false;

            try
            {
                rutaConfiguracion = Path.Combine(Application.StartupPath, nombreArchivoLocal);
                valor = LeerXml(rutaConfiguracion, "modoActualiza");

                if (valor == "NO")
                    estado = false;
                else if (valor == "SI")
                    estado = true;
            }
            catch (IOException exIO)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al gestionar archivo : " + exIO.Message);
            }
            catch (Exception ex)
            {
                // Util.ShowError("Error al leer nodo actualiza:" & ex.Message)
                ErrorLogger.RegistrarErrorEnLog("Error al leer nodo actualiza:" + ex.Message);
            }

            return estado;
        }
        /// <summary>
        /// Obtiene el nombre de la carpeta parche, el metodo lee el documento Actualizacion.config
        /// </summary>
        /// <returns>nombre de la carpeta parche</returns>
        internal string ObtenerRutaParche()
        {
            string valor = "";
            string rutaAppData = "";
            string nombreCarpeta = "";

            try
            {
                rutaAppData = ObtenerRutaAppData();
                nombreCarpeta = ObtenerNombreCarpetaActualizacion();
                valor = Path.Combine(rutaAppData, nombreCarpeta);
            }
            catch (Exception ex)
            {
                ErrorLogger.RegistrarErrorEnLog("Error en obtener ruta de parche :" + ex.Message);
            }

            return valor;
        }
        internal string ObtenerNombreCarpetaActualizacion()
        {
            string rutaConfig = "";
            string valor = "";

            try
            {
                rutaConfig = Path.Combine(Application.StartupPath, nombreArchivoLocal);
                valor = LeerXml(rutaConfig, "CarpetaActualizacion");
            }
            catch (Exception ex)
            {
                ErrorLogger.RegistrarErrorEnLog("Error Inesperado" + ex.Message);
            }

            return valor;
        }
        /// <summary>
        /// Leer el nombre dle archivo zip a descargar desde el FTP
        /// </summary>
        /// <returns>nombre de archivo zip en FTP</returns>
        internal string ObtenerNombreZip()
        {
            string valor = "";
            string rutaConfiguracion = "";
            rutaConfiguracion = Path.Combine(Application.StartupPath, nombreArchivoLocal);
            valor = LeerXml(rutaConfiguracion, "nombreZip");
            return valor;
        }

        internal string ObtenerRutaDondeEstaInstaladoElPrograma()
        {
            string valor = "";
            string RutaDondeEstaInstaladoElPrograma = "";
            RutaDondeEstaInstaladoElPrograma = Path.Combine(Application.StartupPath, nombreArchivoLocal);
            valor = LeerXml(RutaDondeEstaInstaladoElPrograma, "RutaDondeEstaInstaladoElPrograma");
            return valor;
        }
        internal bool EsModoDesarrollo()
        {
            string valor = "";
            string rutaConfiguracion = "";
            bool estado = false;

            try
            {
                rutaConfiguracion = Path.Combine(Application.StartupPath, nombreArchivoLocal);
                valor = LeerXml(rutaConfiguracion, "modoDesarrollo");

                if (valor == "NO")
                    estado = false;
                else if (valor == "SI")
                    estado = true;
            }
            catch (IOException exIO)
            {
                // Util.ShowError("Error al gestionar archivo : " & exIO.Message)
                ErrorLogger.RegistrarErrorEnLog("Error al gestionar archivo : " + exIO.Message);
            }
            catch (Exception ex)
            {
                // Util.ShowError("Error al leer nodo actualiza:" & ex.Message)
                ErrorLogger.RegistrarErrorEnLog("Error al leer nodo actualiza:" + ex.Message);
            }

            return estado;
        }
        internal string ObtenerVersionBasedeDatos()
        {
            string valor = "";
            string rutaConfiguracion = "";
            rutaConfiguracion = Path.Combine(ObtenerRutaAppData(), nombreArchivoLocal);
            valor = LeerXml(rutaConfiguracion, "versionbd");
            return valor;
        }
        internal string ObtenerNombreScript()
        {
            string valor = "";
            string rutaConfiguracion = "";
            rutaConfiguracion = Path.Combine(Application.StartupPath, nombreArchivoLocal);
            valor = LeerXml(rutaConfiguracion, "nombreScript");
            return valor;
        }
        internal string ObtenerTipoEjecucion()
        {
            string valor = "";
            string rutaConfiguracion = "";
            rutaConfiguracion = Path.Combine(Application.StartupPath, nombreArchivoLocal);
            valor = LeerXml(rutaConfiguracion, "modoEjecucion");
            return valor;
        }
        internal string ObtenerCadenaConexion()
        {
            string valor = "";
            string rutaConfiguracion = "";
            XmlDocument xml = new XmlDocument();

            try
            {
                rutaConfiguracion = Path.Combine(Application.StartupPath, nombreArchivoLocal);
                xml.Load(rutaConfiguracion);
                XmlNode nodo = xml.DocumentElement.SelectSingleNode("//configuration/connectionStrings/add[@name='cnnInventario']").Attributes["connectionString"];
                valor = nodo.Value.ToString();
            }
            catch (Exception ex)
            {
                ErrorLogger.RegistrarErrorEnLog("Error al leer xml : " + ex.Message);
            }

            return valor;
        }
    }
}
