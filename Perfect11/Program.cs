using System;
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
            // Hide exception window because of some nags with the library.
#if DEBUG
            Application.ThreadException += (s, e) =>
            {
                Console.WriteLine($"Error: {e.Exception.Message}\n{e.Exception.StackTrace}");
            };
#else
            Application.ThreadException += (s, e) => { };
#endif
            Application.Run(new Form1());
        }
    }
}
