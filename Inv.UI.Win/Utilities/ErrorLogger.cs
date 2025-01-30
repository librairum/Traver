using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Inv.UI.Win.Utilities
{
    public static class ErrorLogger
    {
        private static bool mensajeMostrado = false; // Control para el mensaje único

        public static void RegistrarErrorEnLog(string mensajeError)
        {
            try
            {
                string fechaActual = DateTime.Now.ToString("yyyyMMdd"); // Solo la hora en el nombre
                string nombreArchivo = string.Format("ErrorLog_Inv.UI.Win_{0}.txt", fechaActual);

                // Usamos la ruta definida en la clase Logueo
                string rutaLog = Logueo.RutaLogErrores;

                if (!Directory.Exists(rutaLog))
                {
                    Directory.CreateDirectory(rutaLog); // Crear el directorio si no existe
                }

                string archivoLog = Path.Combine(rutaLog, nombreArchivo);
                using (StreamWriter sw = new StreamWriter(archivoLog, true))
                {
                    sw.WriteLine(string.Format("{0:HH:mm:ss} - {1}", DateTime.Now, mensajeError));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al escribir en el archivo de log: " + ex.Message);
            }
        }

        public static void MostrarMensajeUnicoAlUsuario()
        {
            if (!mensajeMostrado)
            {
                MessageBox.Show("Verifique los errores en el log.");
                mensajeMostrado = true;
            }
        }

        /// Limpia el contenido del archivo de log correspondiente a la hora actual.
        public static void LimpiarLog()
        {
            try
            {
                string fechaActual = DateTime.Now.ToString("yyyyMMdd"); // Solo la hora en el nombre
                string nombreArchivo = string.Format("ErrorLog_Inv.UI.Win_{0}.txt", fechaActual);

                // Usamos la ruta definida en la clase Logueo
                string rutaLog = Logueo.RutaLogErrores;
                string archivoLog = Path.Combine(rutaLog, nombreArchivo);

                if (File.Exists(archivoLog))
                {
                    File.WriteAllText(archivoLog, string.Empty); // Limpia el contenido del archivo
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al limpiar el archivo de log: " + ex.Message);
            }
        }
    }
}
