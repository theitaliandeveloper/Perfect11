using Microsoft.Win32;
using Perfect11.TweaksInterface;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;

namespace Perfect11.Inbox.UninstallEdge
{
	public class Tweak : IPlugin
	{
		public string Name => "Uninstall Microsoft Edge";
		public string Description => "Remove Microsoft Edge from the system.";
		public string Category => "Apps";
		public string Execute()
		{
			void KillProcessIfRunning(string name)
			{
				try
				{
					foreach (var p in Process.GetProcessesByName(name))
					{
						try { p.Kill(); } catch { }
					}
				}
				catch { }
			}

			void RunHidden(string fileName, string args)
			{
				try
				{
					var psi = new ProcessStartInfo(fileName, args)
					{
						CreateNoWindow = true,
						UseShellExecute = false,
						RedirectStandardOutput = false,
						RedirectStandardError = false
					};
					var p = Process.Start(psi);
					p?.WaitForExit();
				}
				catch { }
			}

			void TryDeleteRegistryKey(RegistryKey hive, string subKey)
			{
				try
				{
					hive.DeleteSubKeyTree(subKey, throwOnMissingSubKey: false);
				}
				catch
				{
					
				}
			}

			void TryDeleteRegistryValue(RegistryKey hive, string subKey, string valueName)
			{
				try
				{
					using (var key = hive.OpenSubKey(subKey, writable: true))
					{
						key?.DeleteValue(valueName, throwOnMissingValue: false);
					}
				}
				catch { }
			}

			void TryCreateSetValue(RegistryKey hive, string subKey, string valueName, int dwordValue, bool createIfMissing = true)
			{
				try
				{
					if (createIfMissing)
				{
						using (var key = hive.CreateSubKey(subKey))
						{
							key?.SetValue(valueName, dwordValue, RegistryValueKind.DWord);
						}
					}
					else
					{
						using (var key = hive.OpenSubKey(subKey, writable: true))
						{
							key?.SetValue(valueName, dwordValue, RegistryValueKind.DWord);
						}
					}
				}
				catch { }
			}

			void TryDeleteDirectory(string path)
			{
				try
				{
					if (Directory.Exists(path))
						Directory.Delete(path, recursive: true);
				}
				catch
				{
					TryTakeOwnershipAndDelete(path);
				}
			}

			void TryTakeOwnershipAndDelete(string path)
			{
				try
				{
					if (File.Exists(path) || Directory.Exists(path))
					{
						RunHidden("takeown", $"/f \"{path}\" /a /r /d y");
						RunHidden("icacls", $"\"{path}\" /grant Everyone:F /t /c");
						try
						{
							if (File.Exists(path)) File.Delete(path);
							else if (Directory.Exists(path)) Directory.Delete(path, true);
						}
						catch {}
					}
				}
				catch { }
			}

			void TryDeleteIfExists(string file)
			{
				try
				{
					if (File.Exists(file))
						File.Delete(file);
				}
				catch { }
			}

			string GetCurrentUserSid()
			{
				try
				{
					var nt = WindowsIdentity.GetCurrent();
					return nt?.User?.Value ?? "";
				}
				catch { return ""; }
			}

			string[] RunPowerShellAndGetLines(string command)
			{
				try
				{
					var psi = new ProcessStartInfo("powershell", "-NoProfile -Command " + WrapForPowerShell(command))
					{
						CreateNoWindow = true,
						UseShellExecute = false,
						RedirectStandardOutput = true,
						RedirectStandardError = true
					};
					var p = Process.Start(psi);
					string output = p.StandardOutput.ReadToEnd();
					p.WaitForExit();
					return output.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
				}
				catch
				{
					return new string[0];
				}
			}

			string WrapForPowerShell(string cmd)
			{
				return "\"" + cmd.Replace("\"", "\\\"") + "\"";
			}

            string pf = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            string pf86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

            bool existsInPf = Directory.Exists(Path.Combine(pf, "Microsoft\\Edge"));
            bool existsInPf86 = Directory.Exists(Path.Combine(pf86, "Microsoft\\Edge"));

            if (!existsInPf && !existsInPf86)
            {
                throw new Exception("Microsoft Edge not found.");
            }
            if (existsInPf86)
            {
                KillProcessIfRunning("msedge");
                KillProcessIfRunning("MicrosoftEdgeUpdate");
                KillProcessIfRunning("msedgewebview2");
                TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft Edge");
                TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft Edge Update");
                TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft EdgeWebView");
                TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Active Setup\Installed Components\{9459C573-B17A-45AE-9F64-1857B5D58CEE}");
                TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\WOW6432Node\Microsoft\EdgeUpdate");
                TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\WOW6432Node\Microsoft\Edge");
                TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\WOW6432Node\Microsoft\Internet Explorer\EdgeIntegration");
                RunHidden("net", "stop MicrosoftEdgeElevationService");
                RunHidden("sc", "delete MicrosoftEdgeElevationService");
                RunHidden("net", "stop edgeupdate");
                RunHidden("sc", "delete edgeupdate");
                RunHidden("net", "stop edgeupdatem");
                RunHidden("sc", "delete edgeupdatem");
                TryDeleteDirectory(Path.Combine(pf86, "Microsoft\\Edge"));
                TryDeleteDirectory(Path.Combine(pf86, "Microsoft\\EdgeCore"));
                TryDeleteDirectory(Path.Combine(pf86, "Microsoft\\EdgeUpdate"));
                TryDeleteDirectory(Path.Combine(pf86, "Microsoft\\EdgeWebView"));
                TryDeleteDirectory(Path.Combine(pf86, "Microsoft\\Temp"));
                TryDeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Microsoft\\EdgeUpdate"));
                TryDeleteDirectory(Path.Combine(pf, "Microsoft\\Edge"));
                TryDeleteDirectory(Path.Combine(pf, "Microsoft\\EdgeCore"));
                TryDeleteDirectory(Path.Combine(pf, "Microsoft\\EdgeUpdate"));
                TryDeleteDirectory(Path.Combine(pf, "Microsoft\\EdgeWebView"));
                TryDeleteDirectory(Path.Combine(pf, "Microsoft\\Temp"));
                TryCreateSetValue(Registry.LocalMachine, @"Software\Microsoft\EdgeUpdate", "DoNotUpdateToEdgeWithChromium", 1);
                TryCreateSetValue(Registry.LocalMachine, @"Software\WOW6432Node\Microsoft\EdgeUpdate", "DoNotUpdateToEdgeWithChromium", 1);
            }
            else
            {
                KillProcessIfRunning("msedge");
                KillProcessIfRunning("MicrosoftEdgeUpdate");
                KillProcessIfRunning("msedgewebview2");
                TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft Edge");
                TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft Edge Update");
                TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft EdgeWebView");
                TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Active Setup\Installed Components\{9459C573-B17A-45AE-9F64-1857B5D58CEE}");
                TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\WOW6432Node\Microsoft\EdgeUpdate");
                TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Edge");
                TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Internet Explorer\EdgeIntegration");
                RunHidden("net", "stop MicrosoftEdgeElevationService");
                RunHidden("sc", "delete MicrosoftEdgeElevationService");
                RunHidden("net", "stop edgeupdate");
                RunHidden("sc", "delete edgeupdate");
                RunHidden("net", "stop edgeupdatem");
                RunHidden("sc", "delete edgeupdatem");
                TryDeleteDirectory(Path.Combine(pf, "Microsoft\\Edge"));
                TryDeleteDirectory(Path.Combine(pf, "Microsoft\\EdgeCore"));
                TryDeleteDirectory(Path.Combine(pf, "Microsoft\\EdgeUpdate"));
                TryDeleteDirectory(Path.Combine(pf, "Microsoft\\EdgeWebView"));
                TryDeleteDirectory(Path.Combine(pf, "Microsoft\\Temp"));
                TryCreateSetValue(Registry.LocalMachine, @"Software\Microsoft\EdgeUpdate", "DoNotUpdateToEdgeWithChromium", 1);
            }
            TryDeleteIfExists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Microsoft Edge.lnk"));
            TryDeleteIfExists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory), "Microsoft Edge.lnk"));
            TryDeleteIfExists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu), "Programs\\Microsoft Edge.lnk"));
            TryDeleteIfExists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu), "Programs\\Microsoft Edge.lnk"));
            TryDeleteIfExists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft\\Internet Explorer\\Quick Launch\\User Pinned\\TaskBar\\Microsoft Edge.lnk"));
            var systemTasksPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "System32", "Tasks");
            try
            {
                foreach (var f in Directory.EnumerateFiles(systemTasksPath, "*MicrosoftEdge*", SearchOption.AllDirectories))
                {
                    TryTakeOwnershipAndDelete(f);
                }
            }
            catch {}
            string userSid = GetCurrentUserSid();
            try
            {
                string psListCmd = "Get-AppxPackage -AllUsers | Where-Object { $_.PackageFullName -like '*microsoftedge*' } | Select-Object -ExpandProperty PackageFullName";
                var edgePackages = RunPowerShellAndGetLines(psListCmd);

                foreach (var pkg in edgePackages)
                {
                    if (string.IsNullOrWhiteSpace(pkg)) continue;
                    string packageName = pkg.Trim();

                    if (!string.IsNullOrEmpty(userSid))
                    {
                        TryCreateSetValue(Registry.LocalMachine, $@"SOFTWARE\Microsoft\Windows\CurrentVersion\Appx\AppxAllUserStore\EndOfLife\{userSid}\{packageName}", "", 0, createIfMissing: true);
                        TryCreateSetValue(Registry.LocalMachine, $@"SOFTWARE\Microsoft\Windows\CurrentVersion\Appx\AppxAllUserStore\EndOfLife\S-1-5-18\{packageName}", "", 0, createIfMissing: true);
                        TryCreateSetValue(Registry.LocalMachine, $@"SOFTWARE\Microsoft\Windows\CurrentVersion\Appx\AppxAllUserStore\Deprovisioned\{packageName}", "", 0, createIfMissing: true);
                    }

                    RunHidden("powershell", $"-Command \"Remove-AppxPackage -Package '{packageName}'\" 2>$null");
                    RunHidden("powershell", $"-Command \"Remove-AppxPackage -Package '{packageName}' -AllUsers\" 2>$null");
                }
            }
            catch {}
            try
            {
                var sysRoot = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                foreach (var f in Directory.EnumerateFiles(sysRoot, "Microsoft.MicrosoftEdge*", SearchOption.AllDirectories))
                {
                    TryTakeOwnershipAndDelete(f);
                }
            }
            catch { }

            try
            {
                foreach (var f in Directory.EnumerateFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "System32"), "MicrosoftEdge*.exe", SearchOption.AllDirectories))
                {
                    TryTakeOwnershipAndDelete(f);
                }
            }
            catch { }

            try
            {
                foreach (var f in Directory.EnumerateFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "SysWOW64"), "MicrosoftEdge*.exe", SearchOption.AllDirectories))
                {
                    TryTakeOwnershipAndDelete(f);
                }
            }
            catch { }
            TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\Clients\StartMenuInternet\Microsoft Edge");
            TryDeleteRegistryValue(Registry.LocalMachine, @"SOFTWARE\RegisteredApplications", "Microsoft Edge");
            TryDeleteRegistryValue(Registry.LocalMachine, @"SOFTWARE\Classes\.htm\OpenWithProgIds", "MSEdgeHTM");
            TryDeleteRegistryValue(Registry.LocalMachine, @"SOFTWARE\Classes\.html\OpenWithProgIds", "MSEdgeHTM");
            TryDeleteRegistryValue(Registry.LocalMachine, @"SOFTWARE\Classes\.mht\OpenWithProgIds", "MSEdgeMHT");
            TryDeleteRegistryValue(Registry.LocalMachine, @"SOFTWARE\Classes\.mhtml\OpenWithProgIds", "MSEdgeMHT");
            TryDeleteRegistryValue(Registry.LocalMachine, @"SOFTWARE\Classes\.pdf\OpenWithProgIds", "MSEdgePDF");
            TryDeleteRegistryValue(Registry.LocalMachine, @"SOFTWARE\Classes\.shtml\OpenWithProgIds", "MSEdgeHTM");
            TryDeleteRegistryValue(Registry.LocalMachine, @"SOFTWARE\Classes\.svg\OpenWithProgIds", "MSEdgeHTM");
            TryDeleteRegistryValue(Registry.LocalMachine, @"SOFTWARE\Classes\.webp\OpenWithProgIds", "MSEdgeHTM");
            TryDeleteRegistryValue(Registry.LocalMachine, @"SOFTWARE\Classes\.xht\OpenWithProgIds", "MSEdgeHTM");
            TryDeleteRegistryValue(Registry.LocalMachine, @"SOFTWARE\Classes\.xhtml\OpenWithProgIds", "MSEdgeHTM");
            TryDeleteRegistryValue(Registry.LocalMachine, @"SOFTWARE\Classes\.xml\OpenWithProgIds", "MSEdgeHTM");
            TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\WOW6432Node\Clients\StartMenuInternet\Microsoft Edge");
            TryDeleteRegistryValue(Registry.LocalMachine, @"SOFTWARE\WOW6432Node\RegisteredApplications", "Microsoft Edge");
            TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\WOW6432Node\Microsoft\Edge");
            TryDeleteRegistryKey(Registry.LocalMachine, @"SOFTWARE\WOW6432Node\Microsoft\Internet Explorer\EdgeIntegration");
            return "Microsoft Edge should now be uninstalled.";
        }
	}
}
