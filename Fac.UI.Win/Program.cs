﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Fac.UI.Win.Maestros;
using Fac.UI.Win.Acceso;
namespace Fac.UI.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			ActualizacionSistema configuracion = new ActualizacionSistema();
            if (configuracion.EsModoActualiza() == false)
            {
                Application.Run(new Acceso.frmLogin());
                //Application.Run(new frmDevolucion());
                
            }
            else
            {
                Application.Run(new frmSplash());
            }
        }
    }
}
