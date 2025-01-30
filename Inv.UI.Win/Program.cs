using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Inv.UI.Win.Utilities;

namespace Inv.UI.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ActualizacionSistema configuracion = new ActualizacionSistema();

            // Limpia el archivo de log al iniciar la aplicación
            ErrorLogger.LimpiarLog();

            if (configuracion.EsModoActualiza() == true)
            {
                Application.Run(new frmSplash());
            }
            else
            {
                Application.Run(new Acceso.frmLogin());
            }
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new frmLineaArticulo());
        }
    }
}
