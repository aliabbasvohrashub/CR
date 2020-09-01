using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bajaj.Dinesh.Biller
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Global.MDIForm = new MDIForm());
        }
    }
}