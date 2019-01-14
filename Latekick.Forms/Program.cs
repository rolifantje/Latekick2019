using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Latekick.Forms
{
    static class Program
    {

        public static Latekick.BOL.AccountManagement.User ThisUser = new Latekick.BOL.AccountManagement.User();        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Latekick.Forms.MainForm());
        }
    }
}
