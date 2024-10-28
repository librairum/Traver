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

namespace Fac.UI.Win
{
    public class ActualizacionSistema
    {
        private SqlConnection cn;
        public ActualizacionSistema()
        { }
        private string nombreArchivoLocal = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe.config";


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
                MessageBox.Show("Error al leer nodo del config : " + rutaArchivo + nombreNodo + valor + exIO.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer nodo del config  : " + rutaArchivo + nombreNodo + valor + ex.Message);
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
                MessageBox.Show("Error al leer xml:" + ex.Message + "ruta de archivo configuracion: " + rutaArchivo + " nodo : cnnInventarioWeb");
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
                Util.ShowError("Error al obtener nombre de archivo  Config : " + ex.Message);
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
                MessageBox.Show(("Error al leer version FTP : " + ex.Message));
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
            }
            catch (IOException exIO)
            {
                MessageBox.Show("Error al obtener ruta FTP Actualizacion : " + exIO.Message);
            }            
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener ruta FTP Actualizacion :" + ex.Message);
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
                
                valor = RutaActualizacionLocal;
            }
            catch (IOException exIO)
            {

                MessageBox.Show("Error al obtener ruta destino version web :" + exIO.Message);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al obtener ruta destino version web :" + ex.Message);
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
                MessageBox.Show("Error al obtener ruta AppData  : " + exIO.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener ruta AppData :" + ex.Message);
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
                MessageBox.Show("Error al obtener nombre de empresa : " + exIO.Message);
            }
            
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al obtener nombre de empresa :" + ex.Message);
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

                MessageBox.Show("Error al obtener nombre de modulo : " + exIO.Message);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al obtener nombre de modulo :" + ex.Message);
            }

            return valor;
        }
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

                MessageBox.Show("Error al obtener usuario : " + exIO.Message);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al obtener usuario :" + ex.Message);
            }

            return valor;
        }
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

                MessageBox.Show("Error al obtener clave : " + exIO.Message);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al obtener clave :" + ex.Message);
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

                MessageBox.Show("Error al obtener nombre de actualizador : " + exIO.Message);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al obtener nombre de actualizador:" + ex.Message);
            }

            return valor;
        }
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
                MessageBox.Show("Error al obtener direccion FTP : " + exIO.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener direccion FTP:" + ex.Message);
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
                MessageBox.Show("Error al obtener version usuario : " + exIO.Message);
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener version usuario:" + ex.Message);
            }

            return valor;
        }
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
                MessageBox.Show("Error al obtener version : " + exIO.Message);
            }            
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener version :" + ex.Message);
            }

            return valor;
        }
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
                MessageBox.Show("Error al obtener version web : " + exIO.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener version web:" + ex.Message);
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
                MessageBox.Show("Error al leer modo actualizar: " + exIO.Message);
            }
            catch (Exception ex)
            {                
                MessageBox.Show("Error al leer modo actualizar:" + ex.Message);
            }

            return estado;
        }
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
                MessageBox.Show("Error en obtener ruta de parche :" + ex.Message);
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
                MessageBox.Show("Error Inesperado", ex.Message);
            }

            return valor;
        }
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
                MessageBox.Show("Error al leer modo actualizar:" + exIO.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer modo actualizar:" + ex.Message);
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
                MessageBox.Show("Error al leer cadena conexion : " + ex.Message);
            }

            return valor;
        }
    }
}
