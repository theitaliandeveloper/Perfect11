using Microsoft.Win32;
using Perfect11.TweaksInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfect11.Inbox.UninstallOneDrive
{
    public class Tweak : IPlugin
    {
        public string Name => "Uninstall OneDrive";
        public string Description => "Remove OneDrive from the system.";
        public void Execute()
        {
            // --- Step 0: Check if OneDrive exists ---
            bool Exists()
            {
                bool regExists = false;
                try
                {
                    using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
                    {
                        if (key != null)
                            regExists = key.GetSubKeyNames().Any(n => n.ToLower().Contains("onedrive"));
                    }
                }
                catch { }

                return regExists;
            }

            if (!Exists())
            {
                throw new Exception("OneDrive not found, cannot continue!");
            }
            // --- Step 1: Check if OneDrive folders contain files ---
            string usersRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 3), "Users");
            foreach (var dir in Directory.GetDirectories(usersRoot))
            {
                string oneDrivePath = Path.Combine(dir, "OneDrive");
                if (Directory.Exists(oneDrivePath) && Directory.EnumerateFileSystemEntries(oneDrivePath).Any())
                {
                    throw new Exception("OneDrive files found, cannot continue!");
                }
            }

            // --- Step 2: Kill OneDrive process ---
            foreach (var proc in Process.GetProcessesByName("OneDrive"))
                try { proc.Kill(); } catch { }

            // --- Step 3: Uninstall OneDrive executables ---
            foreach (string setupPath in new[]
            {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "System32", "OneDriveSetup.exe"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "SysWOW64", "OneDriveSetup.exe")
            })
            {
                if (File.Exists(setupPath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = setupPath,
                        Arguments = "/uninstall",
                        CreateNoWindow = true,
                        UseShellExecute = false
                    })?.WaitForExit(5000);
                }
            }

            // --- Step 4: Remove folders ---
            void TryDelete(string path, bool isDir)
            {
                try
                {
                    if (isDir && Directory.Exists(path)) Directory.Delete(path, true);
                    else if (!isDir && File.Exists(path)) File.Delete(path);
                }
                catch { }
            }

            TryDelete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Microsoft", "OneDrive"), true);
            TryDelete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft", "OneDrive"), true);

            foreach (var dir in Directory.GetDirectories(usersRoot))
            {
                TryDelete(Path.Combine(dir, "AppData", "Local", "Microsoft", "OneDrive"), true);
                TryDelete(Path.Combine(dir, "OneDrive"), true);
                TryDelete(Path.Combine(dir, "AppData", "Roaming", "Microsoft", "Windows", "Start Menu", "Programs", "OneDrive.lnk"), false);
            }

            // --- Step 5: Clean registry (HKLM + HKU) ---
            try
            {
                using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\SyncRootManager", true))
                {
                    if (key != null)
                    {
                        foreach (var sub in key.GetSubKeyNames().Where(k => k.Contains("OneDrive")).ToArray())
                            key.DeleteSubKeyTree(sub, false);
                    }
                }
            }
            catch { }

            foreach (string userHive in Registry.Users.GetSubKeyNames())
            {
                if (!userHive.StartsWith("S-")) continue;

                string[] paths =
                {
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\BannerStore",
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\AutoplayHandlers\Handlers",
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths",
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"
                };

                foreach (string p in paths)
                {
                    try
                    {
                        using (var key = Registry.Users.OpenSubKey($"{userHive}\\{p}", true))
                        {
                            if (key == null) continue;
                            foreach (var sub in key.GetSubKeyNames().Where(n => n.Contains("OneDrive")).ToArray())
                                key.DeleteSubKeyTree(sub, false);
                        }
                    }
                    catch { }
                }

                try
                {
                    Registry.SetValue($@"HKEY_USERS\{userHive}\SOFTWARE\Classes\CLSID\{{018D5C66-4533-4307-9B53-224DE2ED1FE6}}", "System.IsPinnedToNameSpaceTree", 0, RegistryValueKind.DWord);
                    Registry.SetValue($@"HKEY_USERS\{userHive}\SOFTWARE\Classes\WOW6432Node\CLSID\{{018D5C66-4533-4307-9B53-224DE2ED1FE6}}", "System.IsPinnedToNameSpaceTree", 0, RegistryValueKind.DWord);
                    Registry.Users.DeleteSubKeyTree($"{userHive}\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Desktop\\NameSpace\\{{018D5C66-4533-4307-9B53-224DE2ED1FE6}}", false);

                    using (var env = Registry.Users.OpenSubKey(userHive + "\\Environment", true))
                        env?.DeleteValue("OneDrive", false);

                    using (var run = Registry.Users.OpenSubKey(userHive + @"\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                        run?.DeleteValue("OneDriveSetup", false);
                }
                catch { }
            }

            // --- Step 6: Remove scheduled tasks ---
            void DeleteTask(string name)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "schtasks",
                        Arguments = $"/delete /tn \"{name}\" /f",
                        CreateNoWindow = true,
                        UseShellExecute = false
                    });
                }
                catch { }
            }

            DeleteTask(@"\OneDrive Reporting Task");
            DeleteTask(@"\OneDrive Standalone Update Task");

            Console.WriteLine("OneDrive has been completely removed.");
        }
    }
}
