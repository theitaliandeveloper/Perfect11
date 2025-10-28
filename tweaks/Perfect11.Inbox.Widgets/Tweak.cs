using Microsoft.Win32;
using Perfect11.TweaksInterface;

namespace Perfect11.Inbox.Widgets
{
    public class Tweak : IPlugin
    {
        public string Name => "Enable/Disable Widgets";
        public string Description => "Enable or Disable Windows 11 Widgets";
        public string Category => "Annoyances";

        public string Execute()
        {
            bool Enabled()
            {
                try
                {
                    using (var key = Registry.CurrentUser.OpenSubKey(
                        @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced"))
                    {
                        object value = key?.GetValue("TaskbarDa");
                        if (value is int intValue)
                            return intValue == 1;
                    }
                }
                catch { }
                return true;
            }
            if (Enabled())
            {
                using (var key = Registry.CurrentUser.CreateSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced"))
                {
                    key?.SetValue("TaskbarDa", 0, RegistryValueKind.DWord);
                }
                using (var policyKey = Registry.LocalMachine.CreateSubKey(
                    @"SOFTWARE\Policies\Microsoft\Dsh"))
                {
                    policyKey?.SetValue("AllowNewsAndInterests", 0, RegistryValueKind.DWord);
                }
                using (var taskbarKey = Registry.CurrentUser.CreateSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Feeds"))
                {
                    taskbarKey?.SetValue("ShellFeedsTaskbarViewMode", 2, RegistryValueKind.DWord);
                }
                return "Widgets have been disabled successfully! Please consider to restart File Explorer or log off and log back in for changes to apply.";
            }
            else
            {
                using (var key = Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced"))
                {
                    key?.SetValue("TaskbarDa", 1, RegistryValueKind.DWord);
                }

                using (var policyKey = Registry.LocalMachine.CreateSubKey(
                    @"SOFTWARE\Policies\Microsoft\Dsh"))
                {
                    policyKey?.SetValue("AllowNewsAndInterests", 1, RegistryValueKind.DWord);
                }

                using (var taskbarKey = Registry.CurrentUser.CreateSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Feeds"))
                {
                    taskbarKey?.SetValue("ShellFeedsTaskbarViewMode", 0, RegistryValueKind.DWord);
                }
                return "Widgets have been enabled successfully! Please consider to restart File Explorer or log off and log back in for changes to apply.";
            }
        }
    }
}
