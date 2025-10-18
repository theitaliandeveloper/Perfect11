using Microsoft.Win32;
using Perfect11.TweaksInterface;
using System.ServiceProcess;
using System;
using System.Management;
using System.Diagnostics;
using System.IO;

namespace Perfect11.Inbox.ManageTelemetry
{
    public class Tweak : IPlugin
    {
        public string Name => "Enable/Disable Telemetry";
        public string Description => "Enable or Disable Telemetry components.";
        public string Category => "Privacy";
        public string Execute()
        {
            void ControlService(string serviceName, string action)
            {
                try
                {
                    using (ServiceController sc = new ServiceController(serviceName))
                    {
                        Console.WriteLine($"Service '{serviceName}' current status: {sc.Status}");

                        switch (action.ToLower())
                        {
                            case "start":
                                if (sc.Status == ServiceControllerStatus.Stopped)
                                {
                                    sc.Start();
                                    sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                                    Console.WriteLine("Service started successfully.");
                                }
                                else Console.WriteLine("Service is already running.");
                                break;

                            case "stop":
                                if (sc.Status == ServiceControllerStatus.Running)
                                {
                                    sc.Stop();
                                    sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                                    Console.WriteLine("Service stopped successfully.");
                                }
                                else Console.WriteLine("Service is not running.");
                                break;

                            case "restart":
                                if (sc.Status == ServiceControllerStatus.Running)
                                {
                                    sc.Stop();
                                    sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                                    sc.Start();
                                    sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                                    Console.WriteLine("Service restarted successfully.");
                                }
                                else
                                {
                                    sc.Start();
                                    sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                                    Console.WriteLine("Service started successfully.");
                                }
                                break;

                            default:
                                Console.WriteLine("Invalid action. Use start | stop | restart");
                                break;
                        }
                    }
                }
                catch (InvalidOperationException ex)
                {
                    throw new Exception($"Service '{serviceName}' not found or cannot be controlled: {ex.Message}");
                }
                catch (System.ServiceProcess.TimeoutException)
                {
                    throw new Exception("Operation timed out.");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            void SetServiceStartupType(string serviceName, string startupType)
            {
                try
                {
                    // startupType can be: "Automatic", "Manual", or "Disabled"
                    string wmiPath = $"Win32_Service.Name='{serviceName}'";
                    using (ManagementObject service = new ManagementObject(wmiPath))
                    {
                        ManagementBaseObject inParams = service.GetMethodParameters("ChangeStartMode");
                        inParams["StartMode"] = startupType;
                        service.InvokeMethod("ChangeStartMode", inParams, null);
                        Console.WriteLine($"Service '{serviceName}' startup type set to {startupType}.");
                    }
                }
                catch (ManagementException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            bool IsTelemetryActivated()
            {
                try
                {
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection");
                    int value = (int)rk.GetValue("AllowTelemetry");
                    rk.Close();
                    return value != 0;
                } catch
                {
                    return true;
                }
            }
            if (IsTelemetryActivated())
            {
                // Step 1: Registry
                RegistryKey rk;
                rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection");
                rk.SetValue("AllowTelemetry",0,RegistryValueKind.DWord);
                rk.SetValue("MaxTelemetryAllowed", 0, RegistryValueKind.DWord);
                rk.Close();
                rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection");
                rk.SetValue("AllowTelemetry", 0, RegistryValueKind.DWord);
                rk.SetValue("MaxTelemetryAllowed", 0, RegistryValueKind.DWord);
                rk.Close();
                // Step 2: Stop and Disable Service
                ControlService("DiagTrack","stop");
                SetServiceStartupType("DiagTrack","Disabled");
                // Step 3: Hopefully Disable CompatTelRunner.exe
                ProcessStartInfo info = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = @"/c takeown /F C:\Windows\System32\CompatTelRunner.exe && icacls C:\Windows\System32\CompatTelRunner.exe /grant everyone:F",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                var proc = Process.Start(info);
                proc.WaitForExit();
                try
                {
                    File.Move(@"C:\Windows\System32\CompatTelRunner.exe", @"C:\Windows\System32\CompatTelRunner.exe.backup");
                } catch
                {
                    throw new Exception("Error while attempting to disable Telemetry file.");
                }
                return "Windows Telemetry has been disabled successfully!";
            }
            else
            {
                // Step 1: Registry
                RegistryKey rk;
                rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection");
                rk.DeleteValue("AllowTelemetry");
                rk.DeleteValue("MaxTelemetryAllowed");
                rk.Close();
                rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection");
                rk.DeleteValue("AllowTelemetry");
                rk.DeleteValue("MaxTelemetryAllowed");
                rk.Close();
                // Step 2: Enable and Start Service
                SetServiceStartupType("DiagTrack", "Automatic");
                ControlService("DiagTrack", "start");
                // Step 3: Enable back CompatTelRunner.exe
                ProcessStartInfo info = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = @"/c takeown /F C:\Windows\System32\CompatTelRunner.exe.backup && icacls C:\Windows\System32\CompatTelRunner.exe.backup /grant everyone:F",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                var proc = Process.Start(info);
                proc.WaitForExit();
                try
                {
                    File.Move(@"C:\Windows\System32\CompatTelRunner.exe.backup", @"C:\Windows\System32\CompatTelRunner.exe");
                }
                catch
                {
                    throw new Exception("Error while attempting to enable back Telemetry file.");
                }
                return "Windows Telemetry has been enabled successfully!";
            }
        }
    }
}
