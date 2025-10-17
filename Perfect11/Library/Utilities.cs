using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

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
    }
}
