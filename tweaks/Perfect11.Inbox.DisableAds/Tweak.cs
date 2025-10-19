using Microsoft.Win32;
using Perfect11.TweaksInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfect11.Inbox.DisableAds
{
    public class Tweak : IPlugin
    {
        public string Name => "Disable ADs";
        public string Description => "Disables ADs and promotions in Windows.";
        public string Category => "Annoyances";
        public string Execute()
        {
            // 1️ ContentDeliveryManager
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"))
            {
                key?.SetValue("SubscribedContent-338393Enabled", 0, RegistryValueKind.DWord);
                key?.SetValue("RotatingLockScreenEnabled", 0, RegistryValueKind.DWord);
                key?.SetValue("RotatingLockScreenOverlayEnabled", 0, RegistryValueKind.DWord);
                key?.SetValue("SubscribedContent-338387Enabled", 0, RegistryValueKind.DWord);
                key?.SetValue("SilentInstalledAppsEnabled", 0, RegistryValueKind.DWord);
                key?.SetValue("SoftLandingEnabled", 0, RegistryValueKind.DWord);
            }

            // 2️ AdvertisingInfo
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo"))
            {
                key?.SetValue("Enabled", 0, RegistryValueKind.DWord);
            }

            // 3️ Privacy
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Privacy"))
            {
                key?.SetValue("TailoredExperiencesWithDiagnosticDataEnabled", 0, RegistryValueKind.DWord);
            }

            // 4️ Explorer
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced"))
            {
                key?.SetValue("Start_IrisRecommendations", 0, RegistryValueKind.DWord);
                key?.SetValue("ShowSyncProviderNotifications", 0, RegistryValueKind.DWord);
            }

            // 5️ UserProfileEngagement
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\UserProfileEngagement"))
            {
                key?.SetValue("ScoobeSystemSettingEnabled", 0, RegistryValueKind.DWord);
            }

            return "ADs disabled successfully.";
        }
    }
}
