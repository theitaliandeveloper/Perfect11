using Microsoft.Win32;
using Perfect11.TweaksInterface;
using System;
using System.Diagnostics;
using System.IO;

namespace Perfect11.Inbox.DisableVBS
{
    public class Tweak : IPlugin
    {
        public string Name => "Disable VBS";
        public string Description => "Disables Virtualization Based Security and Credential Guard (requires additional steps)";
        public string Category => "Annoyances";
        public string Execute()
        {
            void RunCommand(string command)
            {
                var psi = new ProcessStartInfo("cmd.exe", "/c " + command)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    //Verb = "runas"
                };

                using (var process = Process.Start(psi))
                {
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                    {
                        throw new InvalidOperationException($"Comando fallito: {command}");
                    }
                }
            }
            try
            {
                Registry.SetValue(
                @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Lsa",
                "LsaCfgFlags",
                0,
                RegistryValueKind.DWord
            );
                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DeviceGuard",
                    "LsaCfgFlags",
                    0,
                    RegistryValueKind.DWord
                );
                RunCommand("mountvol X: /s");
                string windowsDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                string source = Path.Combine(windowsDir, @"System32\SecConfig.efi");
                string dest = @"X:\EFI\Microsoft\Boot\SecConfig.efi";
                Directory.CreateDirectory(Path.GetDirectoryName(dest));
                File.Copy(source, dest, true);
                RunCommand(@"bcdedit /create {0cb3b571-2f2e-4343-a879-d86a476d7215} /d ""DebugTool"" /application osloader");
                RunCommand(@"bcdedit /set {0cb3b571-2f2e-4343-a879-d86a476d7215} path ""\EFI\Microsoft\Boot\SecConfig.efi""");
                RunCommand(@"bcdedit /set {bootmgr} bootsequence {0cb3b571-2f2e-4343-a879-d86a476d7215}");
                RunCommand(@"bcdedit /set {0cb3b571-2f2e-4343-a879-d86a476d7215} loadoptions DISABLE-LSA-ISO,DISABLE-VBS");
                RunCommand(@"bcdedit /set {0cb3b571-2f2e-4343-a879-d86a476d7215} device partition=X:");
                RunCommand("mountvol X: /d");
                return "Disabling Credential Guard is almost done!\r\nNow, restart your system and when asked, press F3 or the Windows key to disable both credential guard and virtualization based security.\r\nAfter reboot, you might need to set up your PIN again.";
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
