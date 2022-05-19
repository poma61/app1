using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using AcademiaLider.CapaPresentacion;

namespace AcademiaLider
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
<<<<<<< HEAD
            Application.Run(new AcademiaLider.CapaPresentacion.Login());
=======
            //Application.Run(new frmPrincipal());
            Application.Run(new frmMain());
>>>>>>> 1c991e5d116dbbb484a490b214152649d586ec41
        }
    }
}
