using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
#if !DEBUG
            Application.ThreadException += (s, e) =>
            {
                Console.WriteLine($"Errore: {e.Exception.Message}\n{e.Exception.StackTrace}"); // Nasconde la finestra eccezioni
            };
#endif
            Application.Run(new Form1());
        }
    }
}
