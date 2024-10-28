using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.ComponentModel;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;
using Inv.BusinessEntities;
using Inv.BusinessLogic;

//using Encriptador;
using System.Data.SqlClient;

namespace Inv.UI.Win
{
    public partial class frmSplash : Form
    {
        private ActualizacionSistema configuracion = new ActualizacionSistema();
        private string rutaActualizacionFtp;
        private string rutaActualizacionLocal;
        private string NombreArchivoActualizacion;
        private bool detectoActualizacion = false;
        public frmSplash()
        {
            InitializeComponent();
        }
        private void frmSplash_Load(object sender, EventArgs e)
        {
            IniciarVentanaSplash();
        }
        private void frmSplash_Shown(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy != true)
                backgroundWorker1.RunWorkerAsync();
        }
        private bool EncontroNuevoVersion()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool encontro = false;
            string LocalUpdateFile = "";
            try
            {
                string RutaMasArchivoFTP;
                RutaMasArchivoFTP = rutaActualizacionFtp + "/" + NombreArchivoActualizacion;

                string RutaMasArchivoLocal;
                RutaMasArchivoLocal = rutaActualizacionLocal + @"\" + NombreArchivoActualizacion;

                DescargaArchivo(RutaMasArchivoFTP, RutaMasArchivoLocal);

                // Verficar si ha descargado el archivo en ruta de actualzacion Local
                if (!File.Exists(RutaMasArchivoLocal))
                    throw new FileNotFoundException("No existe la ruta de Actualizacion local", LocalUpdateFile);


                string versionOnline = configuracion.ObtenerVersionWeb(rutaActualizacionLocal, NombreArchivoActualizacion);
                string versionLocal = configuracion.ObtenerVersion();

                if (Convert.ToInt32(versionLocal) < Convert.ToInt32(versionOnline))
                    encontro = true;
                else if (Convert.ToInt32(versionLocal) == Convert.ToInt32(versionOnline))
                    encontro = false;
            }
            catch (WebException exWebException)
            {
                MessageBox.Show("Error al iniciar sesion en el servidor o descargar archivo de actualizacion:" + exWebException.Message);
            }
            catch (IOException exInputOutpu)
            {
                MessageBox.Show("Error al gestionar archivo: " + exInputOutpu.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  en [buscar actualizaciones] : " + ex.Message);
                encontro = false;
            }

            Cursor.Current = Cursors.Default;
            return encontro;
        }
        private void IniciarVentanaSplash()
        {
            try
            {
                CheckForIllegalCrossThreadCalls = false;
                lblSistema.Text = configuracion.ObtenerNombreModulo();
                lblversion.Text = "V" + configuracion.ObtenerVersionUsuario();
                lblcopyright.Text = "";
                // Ruta de actualziacion FTP y Local
                // Ruta FTP, donde estan los archivos para actualizacion : FTP/Empresa/Modulo/ArchivosParaActualizacion
                rutaActualizacionFtp = configuracion.ObtenerRutaFTPActualizacion();
                // Ruta donde se instalo el archivo para actualizacion : appData/Empresa/Modulo/ArchivosParaActualizacion
                rutaActualizacionLocal = configuracion.ObtenerRutaLocalActualizacion();
                // Nombre Archivo de Actualizacion, se descarga desde  el FTP
                NombreArchivoActualizacion = configuracion.ObtenerNombreArchivoActualizacion();
                // Limpia Todos los archivos de la carpeta de actualizacion Local
                LimpiarArchivosDescargados(rutaActualizacionLocal);
            }
            catch (System.Data.SqlClient.SqlException exSql)
            {
                MessageBox.Show("Error conexion al servidor :" + exSql.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar formulario: " + ex.Message);
            }
        }
        private void IniciarVentanaLogin()
        {
            /*
            frmMdiPrincipal frmIngreso = new frmMdiPrincipal();            
            frmIngreso.Show();
            */
            Acceso.frmLogin frmIngreso = new Acceso.frmLogin();
            //frmLogin frmIngreso = new frmLogin();
            frmIngreso.Show();
            this.Hide();
        }
        private void IniciarActualizador()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                string nombreEjecutable = "";
                string rutaEjecutable = "";
                string tipoEjecucion = "";
                string cadenaConexion = "";
                string nombreCarpetaEmpresa = "";
                string nombreCarpetaModulo = "";
                string nombreEjecutableModulo = "";
                string nombreConfig = "";
                string versionprograma = "";
                string RutaDondeEstaInstaladoElPrograma = "";
                string modoDesarrollo = "";
                string nombreCarpetaParche = "";
                string nombreScript = "";
                string nombreZip = "";
                nombreEjecutable = configuracion.ObtenerNombreActualizador();
                rutaEjecutable = Path.Combine(Application.StartupPath, nombreEjecutable);
                tipoEjecucion = configuracion.ObtenerTipoEjecucion();


                if (configuracion.ObtenerCadenaConexion().Contains("§") == true)
                {
                    Util.ShowAlert("La cadena conexion contiene caracter prohibido");
                    return;
                }

                if (configuracion.ObtenerNombreEmpresa().Contains("§") == true)
                {
                    Util.ShowAlert("El nombre de empresa contiene caracter prohibido");
                    return;
                }
                cadenaConexion = (configuracion.ObtenerCadenaConexion()).Replace(' ', '§');
                //cadenaConexion = Encriptador.Rijndael.Desencriptar(configuracion.ObtenerCadenaConexion()).Replace(' ', '§');

                nombreCarpetaEmpresa = configuracion.ObtenerNombreEmpresa().Replace(' ', '§');
                nombreCarpetaModulo = configuracion.ObtenerNombreModulo();
                nombreEjecutableModulo = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe";
                nombreConfig = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe.config";
                versionprograma = configuracion.ObtenerVersion();
                RutaDondeEstaInstaladoElPrograma = configuracion.ObtenerRutaDondeEstaInstaladoElPrograma().Replace(' ', '§');
                nombreCarpetaParche = configuracion.ObtenerNombreCarpetaActualizacion();
                nombreScript = configuracion.ObtenerNombreScript();
                nombreZip = configuracion.ObtenerNombreZip();

                if (configuracion.EsModoDesarrollo() == true)
                    modoDesarrollo = "SI";
                else
                    modoDesarrollo = "NO";

                string datosconcatenados = tipoEjecucion + "|" + cadenaConexion + "|" + nombreCarpetaEmpresa + "|" + nombreCarpetaModulo + "|" + nombreEjecutableModulo + "|" + nombreConfig + "|" + versionprograma + "|" + RutaDondeEstaInstaladoElPrograma + "|" + modoDesarrollo + "|" + nombreCarpetaParche + "|" + nombreScript + "|" + nombreZip;


                Process.Start(rutaEjecutable, datosconcatenados);
                //Util.ShowAlert("Inicia proceso Actualizador_iniciarActualizado");
            }
            catch (Exception ex)
            {
                // Util.ShowError("Error al iniciarActualizar :" & ex.Message)
                MessageBox.Show("Error al iniciarActualizar :" + ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }
        private void LimpiarArchivosDescargados(string rutaActualizacionLocalaborrar)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string[] files = Directory.GetFiles(rutaActualizacionLocalaborrar);

                foreach (string f in files)
                    File.Delete(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar archivos descargos : " + ex.Message);
                Application.Exit();
            }

            Cursor.Current = Cursors.Default;
        }
        private bool DescargarArchivosActualizacion()
        {
            bool operacionExitoso = false;
            try
            {
                string nombreDebug = "";
                string nombreScript = "";

                string RutaMasArchivoFTP;
                string RutaMasArchivoLocal;

                // Descargo Debug.zip
                nombreDebug = configuracion.ObtenerNombreZip();
                RutaMasArchivoFTP = rutaActualizacionFtp + "/" + nombreDebug;
                RutaMasArchivoLocal = rutaActualizacionLocal + @"\" + nombreDebug;
                DescargaArchivo(RutaMasArchivoFTP, RutaMasArchivoLocal);

                // Descargo Script
                RutaMasArchivoFTP = "";
                RutaMasArchivoLocal = "";
                nombreScript = configuracion.ObtenerNombreScript();
                RutaMasArchivoFTP = rutaActualizacionFtp + "/" + nombreScript;
                RutaMasArchivoLocal = rutaActualizacionLocal + @"\" + nombreScript;
                DescargaArchivo(RutaMasArchivoFTP, RutaMasArchivoLocal);

                operacionExitoso = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al descargar archivos de actualizacion , detalle : " + ex.Message);
            }

            return operacionExitoso;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (detectoActualizacion == true)
                {
                    string versionOnline = "";
                    //Obtener version del archivo actualiza.config, descargado en %appdata%
                    versionOnline = configuracion.ObtenerVersionWeb(rutaActualizacionLocal, NombreArchivoActualizacion);

                    if (MessageBox.Show(string.Format("Version {0} disponible," + Environment.NewLine + "Actualizar?", versionOnline), "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (DescargarArchivosActualizacion() == true)
                            IniciarActualizador();
                    }
                    else
                        IniciarVentanaLogin();
                }
                else if (detectoActualizacion == false)
                    IniciarVentanaLogin();
            }
            catch (Exception ex)
            {
                // Util.ShowError("Error [RunWorkCompleted]: " & ex.Message)
                MessageBox.Show("Error [RunWorkCompleted]: " + ex.Message);
                Application.Exit();
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                detectoActualizacion = EncontroNuevoVersion();
            }
            catch (System.Data.SqlClient.SqlException exSql)
            {
                MessageBox.Show("Error en conexion a base de datos, revisar detalle:" + exSql.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en proceso de actualizacion revisar detalle :" + ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }
        private void DescargaArchivo(string RutaMasArchivoFTP, string RutaMasArchivoLocal)
        {
            Cursor.Current = Cursors.WaitCursor;
            string user = "";
            string pass = "";

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(RutaMasArchivoFTP);
                WebClient clienteWeb = new WebClient();
                user = configuracion.ObtenerUsuario();
                //pass = Encriptador.Rijndael.Desencriptar(configuracion.ObtenerClave().Trim());
                pass = configuracion.ObtenerClave().Trim();
                request.Credentials = new NetworkCredential(user, pass);
                request.UseBinary = true;
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();

                if (File.Exists(RutaMasArchivoLocal))
                    File.Delete(RutaMasArchivoLocal);

                FileStream writer = new FileStream(RutaMasArchivoLocal, FileMode.Create);
                long length = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[2048];
                readCount = responseStream.Read(buffer, 0, bufferSize);

                while (readCount > 0)
                {
                    writer.Write(buffer, 0, readCount);
                    readCount = responseStream.Read(buffer, 0, bufferSize);
                }

                responseStream.Close();
                response.Close();
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                string mensaje = "Instale o Actualice como administrador: " + Environment.NewLine + "Clic derecho sobre icono del programa -> Ejecutar como administrador";
                MessageBox.Show(mensaje + " detalle: " + ex.Message, "Sistema");
                Application.Exit();
            }

            Cursor.Current = Cursors.Default;
        }

    }
}
