using Microsoft.Win32;
using Perfect11.TweaksInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
        public static List<IPlugin> LoadTweaks(string path)
        {
            var plugins = new List<IPlugin>();

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
                        plugins.Add(plugin);
                }
            }

            return plugins;
        }
        public static bool IsAppsDarkMode()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize");
            int value = (int)rk.GetValue("AppsUseLightTheme");
            rk.Close();
            return value == 0;
        }
    }
}
