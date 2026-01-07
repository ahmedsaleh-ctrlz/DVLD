using DVLD.People;
using DVLD.User;
using DVLDDataBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //test
            
            //Application.Run(new frmAddEditLocalLicense(32));
            Application.Run(new frmLogin());
        }
    }
}
