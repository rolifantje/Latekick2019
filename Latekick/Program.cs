using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Latekick
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
            Application.Run(new Latekick.Forms.MainForm());

            //   C:\Program Files\Microsoft SDKs\Windows\v6.0A\Bin>xsd.exe -c -l:c# -n:Latekick.BOL.Latekick "c:\\code\\winapps\\USA\\Latekick\\Latekick.BOL\\Latekick.xsd" /o:"c:\\code\\winapps\\USA\\Latekick\\Latekick.BOL\\Latekick"
        }

        public static void SaveBrisCredentials(string user, string pass)
        {

        }
    }
}
