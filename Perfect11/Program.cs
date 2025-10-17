using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Perfect11.Library;

namespace Perfect11
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
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            // Check if the system is Windows 11
            if (!Utilities.IsWindows11())
            {
                MessageBox.Show("This tool requires Windows 11!","Perfect11",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            // Hide exception window because of some nags with the library.
#if DEBUG
            Application.ThreadException += (s, e) =>
            {
                Console.WriteLine($"Errore: {e.Exception.Message}\n{e.Exception.StackTrace}");
            };
#else
            Application.ThreadException += (s, e) => { };
#endif
            Application.Run(new Form1());
        }
    }
}
