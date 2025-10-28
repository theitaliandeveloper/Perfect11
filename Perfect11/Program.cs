using System;
using System.Windows.Forms;
using Perfect11.Library;

namespace Perfect11
{
    internal  class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
         void Main()
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
            if (Utilities.GetSystemArchitecture().ToLower() == "x86")
            {
                MessageBox.Show("You're running on Windows 32 bits, this program requires Windows 64 bits.","Perfect11",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else if (Utilities.GetSystemArchitecture().ToLower() == "a64")
            {
                var dialog = MessageBox.Show("You're running Windows on ARM. ARM64 support for this tool is experimental, and not everything will work fine. Are you sure to continue?","Perfect11",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);
                if (dialog == DialogResult.No)
                    return;
            }
            Application.Run(new Form1());
        }
    }
}
