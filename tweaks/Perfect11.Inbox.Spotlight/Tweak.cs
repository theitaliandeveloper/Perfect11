using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Perfect11.TweaksInterface;

namespace Perfect11.Inbox.Spotlight
{
    public class Tweak : IPlugin
    {
        public string Name => "Enable/Disable Windows Spotlight";
        public string Description => "Enable or Disable Windows Spotlight feature";
        public string Category => "Annoyances";
        public string Execute()
        {
            bool IsNotWindowsSpotlight()
            {
                const string keyPath = @"SOFTWARE\Policies\Microsoft\Windows\CloudContent";
                const string valueName = "DisableWindowsSpotlightFeatures";

                try
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
                    {
                        if (key == null)
                            return false;

                        object value = key.GetValue(valueName);
                        if (value == null)
                            return false;
                        if (value is int intValue)
                            return intValue == 1;

                        string stringValue = value.ToString();
                        if (int.TryParse(stringValue, out int parsed))
                            return parsed == 1;

                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            if (!IsNotWindowsSpotlight())
            {
                using (var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CloudContent"))
                {
                    key?.SetValue("DisableCloudOptimizedContent", 1, RegistryValueKind.DWord);
                }
                using (var key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CloudContent"))
                {
                    key?.SetValue("DisableWindowsSpotlightFeatures", 1, RegistryValueKind.DWord);
                    key?.SetValue("DisableWindowsSpotlightWindowsWelcomeExperience", 1, RegistryValueKind.DWord);
                    key?.SetValue("DisableWindowsSpotlightOnActionCenter", 1, RegistryValueKind.DWord);
                    key?.SetValue("DisableWindowsSpotlightOnSettings", 1, RegistryValueKind.DWord);
                    key?.SetValue("DisableThirdPartySuggestions", 1, RegistryValueKind.DWord);
                }
                using (var key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"))
                {
                    key?.SetValue("ContentDeliveryAllowed", 0, RegistryValueKind.DWord);
                    key?.SetValue("FeatureManagementEnabled", 0, RegistryValueKind.DWord);
                    key?.SetValue("SubscribedContentEnabled", 0, RegistryValueKind.DWord);
                    key?.SetValue("SubscribedContent-338387Enabled", 0, RegistryValueKind.DWord);
                    key?.SetValue("RotatingLockScreenOverlayEnabled", 0, RegistryValueKind.DWord);
                }
                using (var key = Registry.CurrentUser.CreateSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel"))
                {
                    key?.SetValue("{2cc5ca98-6485-489a-920e-b3e88a6ccce3}", 1, RegistryValueKind.DWord);
                }
                return "Spotlight was disabled successfully.";
            }
            else
            {
                using (var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CloudContent"))
                {
                    key.DeleteValue("DisableCloudOptimizedContent", false);
                }
                using (var key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CloudContent"))
                {
                    key.DeleteValue("DisableWindowsSpotlightFeatures", false);
                    key.DeleteValue("DisableWindowsSpotlightWindowsWelcomeExperience", false);
                    key.DeleteValue("DisableWindowsSpotlightOnActionCenter", false);
                    key.DeleteValue("DisableWindowsSpotlightOnSettings", false);
                    key.DeleteValue("DisableThirdPartySuggestions", false);
                }
                using (var key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"))
                {
                    key.DeleteValue("ContentDeliveryAllowed", false);
                    key.DeleteValue("FeatureManagementEnabled", false);
                    key.DeleteValue("SubscribedContentEnabled", false);
                    key.DeleteValue("SubscribedContent-338387Enabled", false);
                    key.DeleteValue("RotatingLockScreenOverlayEnabled", false);
                }
                using (var key = Registry.CurrentUser.CreateSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel"))
                {
                    key.DeleteValue("{2cc5ca98-6485-489a-920e-b3e88a6ccce3}", false);
                }
                return "Spotlight was enabled successfully.";
            }
        }
    }
}
