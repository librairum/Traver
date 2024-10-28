using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace Com.UI.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            // 2. ============================================================
            ActualizacionSistema configuracion = new ActualizacionSistema();
            

            //Verificar si esta activo el modo actualiza             
            if (configuracion.EsModoActualiza() == true)
            {                
                Application.Run(new frmSplash());                
            }
            else
            {
                Application.Run(new frmLogin());
                
            }
        }
    }
}
