using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Prod.UI.Win;
namespace Prod.UI.Win
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
            
            Application.Run(new Acceso.frmLogin());
            //Application.Run(new FrmOptimizacionUsoBloques());
        }
    }
}
