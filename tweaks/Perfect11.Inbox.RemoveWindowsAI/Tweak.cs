using Perfect11.TweaksInterface;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Perfect11.Inbox.RemoveWindowsAI
{
    public class Tweak : IPlugin
    {
        public string Name => "Remove Windows AI";
        public string Description => "Remove AI components in Windows (PowerShell script by zoicware)";
        public string Category => "Privacy";
        public string Execute()
        {
            if (MessageBox.Show("To use this tweak, you need to agree with the following additional license terms:\r\n\r\n" +
                "MIT License\r\n\r\nCopyright (c) 2024 zoicware\r\n\r\nPermission is hereby granted, free of charge, to any person obtaining a copy\r\nof this software and associated documentation files (the \"Software\"), to deal\r\nin the Software without restriction, including without limitation the rights\r\nto use, copy, modify, merge, publish, distribute, sublicense, and/or sell\r\ncopies of the Software, and to permit persons to whom the Software is\r\nfurnished to do so, subject to the following conditions:\r\n\r\nThe above copyright notice and this permission notice shall be included in all\r\ncopies or substantial portions of the Software.\r\n\r\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR\r\nIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,\r\nFITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE\r\nAUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER\r\nLIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,\r\nOUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE\r\nSOFTWARE." +
                "\r\n\r\n\r\nAgree?","Perfect11",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string PowerShell(string command)
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                    using (Process process = Process.Start(psi))
                    {
                        string output = process.StandardOutput.ReadToEnd();
                        process.WaitForExit();
                        return output;
                    }
                }
                return PowerShell("& ([scriptblock]::Create((irm 'https://git.vichingo455.freeddns.org/Vichingo455/RemoveWindowsAI/raw/branch/main/RemoveWindowsAi.ps1')))");
            }
            else
            {
                throw new Exception("Operation aborted by user.");
            }
        }
    }
}
