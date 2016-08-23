using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manager;
using System.Threading;
using DataMaintenance;

namespace Browser
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
                ApplicationManager manager = new ApplicationManager();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form1 form = new Form1(manager);
                Application.Run(form);
        }
    }
}
