using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
