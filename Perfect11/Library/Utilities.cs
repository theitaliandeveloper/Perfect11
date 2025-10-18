using Microsoft.Win32;
using Perfect11.TweaksInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;

namespace Perfect11.Library
{
    public class Utilities
    {
        public static bool IsWindows11()
        {
            string buildNumber = (string)Registry.GetValue(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion",
                "CurrentBuildNumber", null);
            return int.TryParse(buildNumber, out int build) && build >= 22000;
        }
        public static Dictionary<string, List<IPlugin>> LoadTweaks(string path)
        {
            var categorizedPlugins = new Dictionary<string, List<IPlugin>>(StringComparer.OrdinalIgnoreCase);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            foreach (var file in Directory.GetFiles(path, "*.dll"))
            {
                var assembly = Assembly.LoadFrom(file);
                var types = assembly.GetTypes()
                    .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                foreach (var type in types)
                {
                    if (Activator.CreateInstance(type) is IPlugin plugin)
                    {
                        var category = string.IsNullOrEmpty(plugin.Category) ? "Uncategorized" : plugin.Category;

                        if (!categorizedPlugins.ContainsKey(category))
                        {
                            categorizedPlugins[category] = new List<IPlugin>();
                        }

                        categorizedPlugins[category].Add(plugin);
                    }
                }
            }

            return categorizedPlugins;
        }
        public static bool IsAppsDarkMode()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize");
            int value = (int)rk.GetValue("AppsUseLightTheme");
            rk.Close();
            return value == 0;
        }
        public static string EolApp(string app)
        {
            try
            {
                // Use your PowerShell.Execute helper
                string packageFullName = PowerShell.Execute(
                    "Get-AppxPackage -AllUsers | Where-Object { $_.PackageFullName -like '*" + app +"*' } | Select-Object -ExpandProperty PackageFullName"
                );

                if (string.IsNullOrWhiteSpace(packageFullName))
                {
                    return "Sticky Notes package not found.";
                }

                Console.WriteLine($"Found package: {packageFullName}");

                // Get current user SID
                string userSid = WindowsIdentity.GetCurrent().User?.Value;
                if (string.IsNullOrEmpty(userSid))
                {
                    return "Unable to get current user SID.";
                }

                // Registry base path
                string basePath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Appx\AppxAllUserStore";
                string[] subKeys =
                {
                $@"EndOfLife\{userSid}\{packageFullName}",
                $@"EndOfLife\S-1-5-18\{packageFullName}",
                $@"Deprovisioned\{packageFullName}"
            };

                foreach (var subKey in subKeys)
                {
                    try
                    {
                        Registry.LocalMachine.CreateSubKey(basePath + "\\" + subKey);
                    }
                    catch (Exception ex)
                    {
                        return $"Error: {ex.Message}";
                    }
                }
                return "Deprovision completed successfully.";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
