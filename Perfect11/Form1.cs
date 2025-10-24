using Perfect11.Library;
using Perfect11.Properties;
using Perfect11.TweaksInterface;
using ReaLTaiizor.Enum.Poison;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Threading;
using DiscUtils.Udf;
using System.Windows.Forms.Design;

namespace Perfect11
{
    public partial class Form1 : Form
    {
        private List<string> _listSystemApps = new List<string>();
        private List<IPlugin> _tweaks = new List<IPlugin>();
        private CancellationTokenSource _cts;
        private bool _isDownloading = false;
        string url = $"https://software-static.download.prss.microsoft.com/dbazure/888969d5-f34g-4e03-ac9d-1f9786c66749/26200.6584.250915-1905.25h2_ge_release_svc_refresh_CLIENT_CONSUMER_x64FRE_{Utilities.GetLanguageCode()}.iso";
        string destination = Path.Combine(@"C:\Temp", @"windows.iso");
        private static string AppEdition = "Perfect11 Community Edition";
        public Form1()
        {
            InitializeComponent();
            InitializeDarkMode();
            GetUWPSystem();
            GetUWP();
            InitializeTweaks();
        }
        public void DarkMode(bool status)
        {
            if (status)
            {
                pages.Theme = ThemeStyle.Dark;
                welcomePage.Theme = ThemeStyle.Dark;
                debloatPage.Theme = ThemeStyle.Dark;
                poisonLabel1.Theme = ThemeStyle.Dark;
                poisonLabel1.ForeColor = Color.FromArgb(255,255,255);
                poisonLabel2.Theme = ThemeStyle.Dark;
                poisonLabel2.ForeColor = Color.FromArgb(255, 255, 255);
                LblInstalledCount.Theme = ThemeStyle.Dark;
                LblRemoveCount.Theme = ThemeStyle.Dark;
                LstUWP.Theme = ThemeStyle.Dark;
                LstUWPRemove.Theme = ThemeStyle.Dark;
                ChkShowUWPSystem.Theme = ThemeStyle.Dark;
                BtnRunUninstaller.Theme = ThemeStyle.Dark;
                addAllButton.Theme = ThemeStyle.Dark;
                addButton.Theme = ThemeStyle.Dark;
                removeAllButton.Theme = ThemeStyle.Dark;
                removeButton.Theme = ThemeStyle.Dark;
                welcomePage.BackgroundImage = Resources.win11wallpaperdark;
                tweaksPage.Theme = ThemeStyle.Dark;
                tweaksList.Theme = ThemeStyle.Dark;
                runTweaks.Theme = ThemeStyle.Dark;
                editionLabel.Theme = ThemeStyle.Dark;
                LstUWP.BackColor = Color.FromArgb(17, 17, 17);
                LstUWPRemove.BackColor = Color.FromArgb(17, 17, 17);
                tweaksList.BackColor = Color.FromArgb(17, 17, 17);
                githubLink.Theme = ThemeStyle.Dark;
                upgradePage.Theme = ThemeStyle.Dark;
                poisonLabel3.Theme = ThemeStyle.Dark;
                poisonLabel4.Theme = ThemeStyle.Dark;
                poisonLabel5.Theme = ThemeStyle.Dark;
                upgradeMethod.Theme = ThemeStyle.Dark;
                bypassWin11RequirementsCheck.Theme = ThemeStyle.Dark;
                automateOOBECheck.Theme = ThemeStyle.Dark;
                poisonLabel6.Theme = ThemeStyle.Dark;
                poisonLabel7.Theme = ThemeStyle.Dark;
                upgradeButton.Theme = ThemeStyle.Dark;
                statusLabel.Theme = ThemeStyle.Dark;
                installProgress.Theme = ThemeStyle.Dark;
            }
            else
            {
                pages.Theme = ThemeStyle.Light;
                welcomePage.Theme = ThemeStyle.Light;
                debloatPage.Theme = ThemeStyle.Light;
                poisonLabel1.Theme = ThemeStyle.Light;
                poisonLabel2.Theme = ThemeStyle.Light;
                LblInstalledCount.Theme = ThemeStyle.Light;
                LblRemoveCount.Theme = ThemeStyle.Light;
                LstUWP.Theme = ThemeStyle.Light;
                LstUWPRemove.Theme = ThemeStyle.Light;
                ChkShowUWPSystem.Theme = ThemeStyle.Light;
                BtnRunUninstaller.Theme = ThemeStyle.Light;
                addAllButton.Theme = ThemeStyle.Light;
                addButton.Theme = ThemeStyle.Light;
                removeAllButton.Theme = ThemeStyle.Light;
                removeButton.Theme = ThemeStyle.Light;
                welcomePage.BackgroundImage = Resources.win11wallpaperlight;
                tweaksPage.Theme = ThemeStyle.Light;
                tweaksList.Theme = ThemeStyle.Light;
                runTweaks.Theme = ThemeStyle.Light;
                editionLabel.Theme = ThemeStyle.Light;
                LstUWP.BackColor = Color.FromArgb(255,255,255);
                LstUWPRemove.BackColor = Color.FromArgb(255,255,255);
                tweaksList.BackColor = Color.FromArgb(255,255,255);
                githubLink.Theme = ThemeStyle.Light;
                upgradePage.Theme = ThemeStyle.Light;
                poisonLabel3.Theme = ThemeStyle.Light;
                poisonLabel4.Theme = ThemeStyle.Light;
                poisonLabel5.Theme = ThemeStyle.Light;
                upgradeMethod.Theme = ThemeStyle.Light;
                bypassWin11RequirementsCheck.Theme = ThemeStyle.Light;
                automateOOBECheck.Theme = ThemeStyle.Light;
                poisonLabel6.Theme = ThemeStyle.Light;
                poisonLabel7.Theme = ThemeStyle.Light;
                upgradeButton.Theme = ThemeStyle.Light;
                statusLabel.Theme = ThemeStyle.Light;
                installProgress.Theme = ThemeStyle.Light;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pages.SelectedTab = welcomePage; // Always start from the first tab
            editionLabel.Text = AppEdition;
            //theme.Text = AppEdition;
            LstUWP.View = View.Details;
            LstUWP.Columns.Clear();
            LstUWP.Columns.Add("App Name", -2, HorizontalAlignment.Left);
            LstUWPRemove.View = View.Details;
            LstUWPRemove.Columns.Clear();
            LstUWPRemove.Columns.Add("App Name", -2, HorizontalAlignment.Left);
            int totalWidth1 = LstUWP.ClientSize.Width;
            int totalWidth2 = LstUWPRemove.ClientSize.Width;
            LstUWP.Columns[0].Width = totalWidth1;
            LstUWPRemove.Columns[0].Width = totalWidth2;
            statusLabel.Visible = false;
            installProgress.Visible = false;
        }
        private void GetUWP()
        {
            LstUWP.Items.Clear();
            string output = PowerShell.Execute("Get-AppxPackage -allusers | Select-Object -ExpandProperty Name");
            string[] lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string current = line.Trim();
                if (_listSystemApps != null)
                {
                    if ((_listSystemApps.Any(current.Contains)) && !ChkShowUWPSystem.Checked)
                        continue;
                }
                if (!LstUWP.Items.Cast<ListViewItem>().Any(item => item.Text.Equals(current, StringComparison.OrdinalIgnoreCase)))
                {
                    LstUWP.Items.Add(new ListViewItem(current));
                }
            }
            var compare = LstUWP.Items.Cast<ListViewItem>().Select(item => item.Text).ToList();
            foreach (ListViewItem removeItem in LstUWPRemove.Items)
            {
                if (compare.Contains(removeItem.Text))
                {
                    var itemToRemove = LstUWP.Items
                        .Cast<ListViewItem>()
                        .FirstOrDefault(x => x.Text == removeItem.Text);
                    if (itemToRemove != null)
                        LstUWP.Items.Remove(itemToRemove);
                }
            }
            RefreshUWP();
        }
        private void RefreshUWP()
        {
            int installed = LstUWP.Items.Count;
            int remove = LstUWPRemove.Items.Count;
            LblInstalledCount.Text = "Installed (" + installed.ToString() + ")";
            LblRemoveCount.Text = "Removing (" + remove.ToString() + ")";

            if (installed == 0)
                addAllButton.Enabled =
                addButton.Enabled =
                false;
            else
                addAllButton.Enabled =
                addButton.Enabled =
                true;

            if (remove == 0)
                removeAllButton.Enabled =
                removeButton.Enabled =
                BtnRunUninstaller.Enabled =
                false;
            else
                removeAllButton.Enabled =
                removeButton.Enabled =
                BtnRunUninstaller.Enabled =
                true;
        }
        private void GetUWPSystem()
        {
            _listSystemApps.Clear();

            using (StringReader reader = new StringReader(Resources.UWPSystemAppList))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        _listSystemApps.Add(line.Trim());
                }
            }
        }
        private string RemoveUWP()
        {
            string success = "Successfully removed:" + "\n";
            string failed = "Failed to remove:" + "\n";

            foreach (ListViewItem item in LstUWPRemove.Items)
            {
                string appName = item.Text;
                string command = $"Get-AppxPackage -allusers -Name \"{appName}\" | Remove-AppxPackage -allusers";
                string command2 = $"Get-AppxProvisionedPackage -online | Where PackageName -like *\"{appName}\"* | Remove-AppxProvisionedPackage -online";
                try
                {
                    string output3 = Utilities.EolApp(appName);
                    string output2 = PowerShell.Execute(command2);
                    string output = PowerShell.Execute(command);
#if DEBUG
                    MessageBox.Show(output3);
                    MessageBox.Show(output2);
                    MessageBox.Show(output);
#endif
                    if (!output.ToLower().Contains("error") && !output2.ToLower().Contains("error") && !output3.ToLower().Contains("error"))
                    {
                        success += "\t" + appName + "\n";
                    }
                    else
                    {
                        failed += "\t" + appName + "\n";
                    }
                }
                catch (Exception ex)
                {
                    failed += $"\t{appName} ({ex.Message})\n";
                }
            }
            return success + (failed != "Failed to remove:" + "\n" ? "\n" + failed : "");
        }

        private void ChkShowUWPSystem_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkShowUWPSystem.Checked) MessageBox.Show("You're about to show system UWP apps. Those apps if removed can break several things in your system. Proceed with caution.", "Perfect11", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            GetUWP();
        }

        private void addAllButton_Click(object sender, EventArgs e)
        {
            var itemsToMove = LstUWP.Items.Cast<ListViewItem>().ToList();
            foreach (var item in itemsToMove)
            {
                LstUWPRemove.Items.Add((ListViewItem)item.Clone());
            }
            LstUWP.Items.Clear();
            RefreshUWP();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (LstUWP.SelectedItems.Count == 0) return;
            foreach (ListViewItem selectedItem in LstUWP.SelectedItems.Cast<ListViewItem>().ToList())
            {
                LstUWPRemove.Items.Add((ListViewItem)selectedItem.Clone());
                LstUWP.Items.Remove(selectedItem);
            }
            RefreshUWP();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (LstUWPRemove.SelectedItems.Count > 0)
            {
                List<ListViewItem> selectedItems = new List<ListViewItem>();

                foreach (ListViewItem selectedItem in LstUWPRemove.SelectedItems)
                {
                    selectedItems.Add(selectedItem);
                }

                // Move each selected item
                foreach (ListViewItem item in selectedItems)
                {
                    LstUWP.Items.Add((ListViewItem)item.Clone());
                    LstUWPRemove.Items.Remove(item);
                }

                RefreshUWP();
            }
        }

        private void removeAllButton_Click(object sender, EventArgs e)
        {
            List<ListViewItem> itemsToMove = new List<ListViewItem>();
            foreach (ListViewItem item in LstUWPRemove.Items)
            {
                itemsToMove.Add((ListViewItem)item.Clone());
            }
            LstUWP.Items.AddRange(itemsToMove.ToArray());
            LstUWPRemove.Items.Clear();
            RefreshUWP();
        }

        private void BtnRunUninstaller_Click(object sender, EventArgs e)
        {
            if (LstUWPRemove.Items.Count == 0) { MessageBox.Show("No items were selected for removal.","Perfect11", MessageBoxButtons.OK,MessageBoxIcon.Information); }
            else
            {
                Enabled = false;
                MessageBox.Show(RemoveUWP(),"Perfect11",MessageBoxButtons.OK,MessageBoxIcon.Information);
                LstUWPRemove.Items.Clear();
                GetUWP();
                Enabled = true;
            }
        }
        private void InitializeTweaks()
        {
            const string tweaksFolder = "Tweaks";
            const string interfaceDll = "Perfect11.TweaksInterface.dll";

            // Ensure folder exists and remove old interface DLL
            if (!Directory.Exists(tweaksFolder))
                Directory.CreateDirectory(tweaksFolder);

            string interfacePath = Path.Combine(tweaksFolder, interfaceDll);
            if (File.Exists(interfacePath))
                File.Delete(interfacePath);

            // Load categorized plugins
            var categorizedPlugins = Utilities.LoadTweaks(tweaksFolder);

            // Setup ListView
            tweaksList.View = View.Details;
            tweaksList.FullRowSelect = true;
            tweaksList.ShowGroups = true;
            tweaksList.Items.Clear();
            tweaksList.Groups.Clear();

            // Setup columns
            tweaksList.Columns.Clear();
            tweaksList.Columns.Add("Tweak");
            tweaksList.Columns.Add("Description");
            AdjustListViewColumns();

            // Add groups and items
            foreach (var category in categorizedPlugins.OrderBy(c => c.Key))
            {
                var group = new ListViewGroup(category.Key);
                tweaksList.Groups.Add(group);

                foreach (var plugin in category.Value.OrderBy(p => p.Name))
                {
                    var item = new ListViewItem(plugin.Name)
                    {
                        Group = group,
                        Tag = plugin
                    };
                    item.SubItems.Add(plugin.Description);
                    tweaksList.Items.Add(item);
                }
            }

            // Enable or disable run button
            runTweaks.Enabled = tweaksList.Items.Count > 0;
        }

        // Adjust column widths dynamically based on ListView client width
        private void AdjustListViewColumns()
        {
            if (tweaksList.Columns.Count < 2) return;

            int totalWidth = tweaksList.ClientSize.Width;
            tweaksList.Columns[0].Width = (int)(totalWidth * 0.3); // Tweak column
            tweaksList.Columns[1].Width = (int)(totalWidth * 0.7); // Description column
        }
        private void InitializeDarkMode()
        {
            if (Utilities.IsAppsDarkMode())
            {
                DarkMode(true);
            }
            else
            {
                DarkMode(false);
            }
        }

        private async void runTweaks_Click(object sender, EventArgs e)
        {
            if (tweaksList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select one or more plugins to run.","Perfect11",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            Enabled = false; // prevent multiple clicks
            try
            {
                foreach (ListViewItem item in tweaksList.SelectedItems)
                {
                    if (item.Tag is IPlugin plugin)
                    {
                        string result = await Task.Run(() => plugin.Execute()); // run in background thread
                        MessageBox.Show(result,"Perfect11",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running plugin: {ex.Message}", "Perfect11", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                Enabled = true;
            }
        }

        private void tweaksList_Resize(object sender, EventArgs e)
        {
            AdjustListViewColumns();
        }

        private void githubLink_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://github.com/theitaliandeveloper/Perfect11/");
            }
            catch
            {
                MessageBox.Show("Looks like your browser is not available, please copy the link below and paste it in your browser's address bar:\n\nhttps://github.com/theitaliandeveloper/Perfect11/","Perfect11",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void pages_SelectedIndexChanged(object sender, EventArgs e)
        {
#if !DEBUG // For UI Testing do not prevent using pages if not 11
            if (pages.SelectedTab != upgradePage && _cts != null)
            {
                MessageBox.Show("Upgrade to Windows 11 is in progress, cannot change tab.", "Perfect11", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pages.SelectedTab = upgradePage;
            }
            if ((pages.SelectedTab == debloatPage || pages.SelectedTab == tweaksPage) && !Utilities.IsWindows11())
            {
                MessageBox.Show("In order to use these features you need to upgrade to Windows 11.","Perfect11",MessageBoxButtons.OK,MessageBoxIcon.Information);
                pages.SelectedTab = upgradePage;
            }
            else if (pages.SelectedTab == upgradePage && Utilities.IsWindows11())
            {
                if (MessageBox.Show("You're already using Windows 11, there's no need to upgrade. However, this page might be useful as well for reinstallation. Are you sure to continue?", "Perfect11", MessageBoxButtons.YesNo, MessageBoxIcon.Information,MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    pages.SelectedTab = welcomePage;
                }
            }
#endif
        }

        private void poisonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            statusLabel.Text = "Ready.";
            installProgress.Value = 0;
            upgradeButton.Enabled = true;
            statusLabel.Visible = true;
            installProgress.Visible = true;
            if (upgradeMethod.SelectedIndex == 3)
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Filter = "Disc Image File|*.iso",
                    Title = "Select custom ISO",
                    Multiselect = false
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in ofd.FileNames)
                    {
                        destination = fileName;
                    }
                }
                else
                {
                    upgradeMethod.SelectedIndex = 0;
                }
            }
            if (upgradeMethod.SelectedIndex == 3 || upgradeMethod.SelectedIndex == 2) // Both Mini11 and custom ISO
            {
                automateOOBECheck.Enabled = false;
                automateOOBECheck.Checked = false;
                bypassWin11RequirementsCheck.Enabled = false;
                bypassWin11RequirementsCheck.Checked = false;
            }
            else if (upgradeMethod.SelectedIndex == 1) // Windows 11 LTSC
            {
                automateOOBECheck.Enabled = true;
            }
            if (upgradeMethod.SelectedIndex != 0) // if not normal installation
            {
                bypassWin11RequirementsCheck.Enabled = false;
                bypassWin11RequirementsCheck.Checked = false;
            }
            else
            {
                automateOOBECheck.Enabled = true;
                bypassWin11RequirementsCheck.Enabled = true;
                bypassWin11RequirementsCheck.Checked = true;
            }
        }

        private async void upgradeButton_Click(object sender, EventArgs e)
        {
            if (upgradeMethod.SelectedIndex == 1)
            {
                url = "https://oemsoc.download.prss.microsoft.com/dbazure/X23-81951_26100.1742.240906-0331.ge_release_svc_refresh_CLIENT_ENTERPRISES_OEM_x64FRE_en-us.iso_640de540-87c4-427f-be87-e6d53a3a60b4?t=2c3b664b-b119-4088-9db1-ccff72c6d22e&P1=102816950270&P2=601&P3=2&P4=OC448onxqdmdUsBUApAiE8pj1FZ%2bEPTU3%2bC6Quq29MVwMyyDUtR%2fsbiy7RdVoZOHaZRndvzeOOnIwJZ2x3%2bmP6YK9cjJSP41Lvs0SulF4SVyL5C0DdDmiWqh2QW%2bcDPj2Xp%2bMrI9NOeElSBS5kkOWP8Eiyf2VkkQFM3g5vIk3HJVvu5sWo6pFKpFv4lML%2bHaIiTSuwbPMs5xwEQTfScuTKfigNlUZPdHRMp1B3uKLgIA3r0IbRpZgHYMXEwXQ%2fSLMdDNQthpqQvz1PThVkx7ObD55CXgt0GNSAWRfjdURWb8ywWk1gT7ozAgpP%2fKNm56U5nh33WZSuMZIuO1SBM2vw%3d%3d";
            }
            else if (upgradeMethod.SelectedIndex == 2)
            {
                url = "https://archive.org/download/mini11-24h2/Mini11%20LTS%2024H2%20AIO%20v1%20Triton.iso";
            }
#if !DEBUG
            // Se stiamo già scaricando → annulla
            if (_isDownloading)
            {
                if (_cts != null && !_cts.IsCancellationRequested)
                {
                    _cts.Cancel();
                    statusLabel.Text = "Canceling...";
                    upgradeButton.Enabled = false;
                }
                return;
            }
            try
            {
                upgradeMethod.Enabled = false;
                bypassWin11RequirementsCheck.Enabled = false;
                automateOOBECheck.Enabled = false;
                string setupArguments = "";
                installProgress.Value = 0;
                upgradeButton.Text = "Cancel";
                _isDownloading = true;
                _cts = new CancellationTokenSource();
                if (!Directory.Exists("C:\\Temp"))
                    Directory.CreateDirectory("C:\\Temp");
                if (upgradeMethod.SelectedIndex != 3)
                {
                    destination = Path.Combine(@"C:\Temp", @"windows.iso");
                    statusLabel.Text = "Downloading ISO...";
                    await DownloadFileAsync(url, destination, _cts.Token);
                    statusLabel.Text = "Download completed!";
                }
                Thread.Sleep(1000);
                statusLabel.Text = "Extracting...";
                await Task.Run(() => ExtractIsoWithProgress(destination, Path.Combine(@"C:\Temp","Perfect11_W11_TMP"), _cts.Token));
                statusLabel.Text = "Extraction complete!";
                Thread.Sleep(1000);
                if (automateOOBECheck.Checked)
                {
                    statusLabel.Text = "Applying OOBE automation tweak...";
                    if (!Directory.Exists(Path.Combine(@"C:\Temp", @"Perfect11_W11_TMP\sources\$OEM$\$$\Panther")))
                    {
                        Directory.CreateDirectory(Path.Combine(@"C:\Temp", @"Perfect11_W11_TMP\sources\$OEM$\$$\Panther"));
                    }
                    if (File.Exists(Path.Combine(@"C:\Temp", @"Perfect11_W11_TMP\sources\$OEM$\$$\Panther\unattend.xml")))
                    {
                        File.Delete(Path.Combine(@"C:\Temp", @"Perfect11_W11_TMP\sources\$OEM$\$$\Panther\unattend.xml"));
                    }
                    File.WriteAllText(Path.Combine(@"C:\Temp", @"Perfect11_W11_TMP\sources\$OEM$\$$\Panther\unattend.xml"),Resources.unattend_OOBEAutomate);
                }
                statusLabel.Text = "Checking Windows 11 Setup... (ignore the Windows Server title and texts)";
                if (bypassWin11RequirementsCheck.Checked)
                {
                    setupArguments += "/Product Server /Compat IgnoreWarning /MigrateDrivers All";
                }
                ProcessStartInfo info = new ProcessStartInfo
                {
                    FileName = Path.Combine(@"C:\Temp", @"Perfect11_W11_TMP\sources\setupprep.exe"),
                    Arguments = setupArguments
                };
                using (var process = Process.Start(info))
                {
                    process?.WaitForExit();
                }
                _cts = null;
                MessageBox.Show("Almost done! Now follow the prompts to continue the Windows 11 installation! Perfect11 will now close.","Perfect11",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Application.Exit();
            }
            catch (OperationCanceledException)
            {
                statusLabel.Text = "Installation aborted!";
                try
                {
                    if (File.Exists(destination))
                        File.Delete(destination);
                    if (Directory.Exists(Path.Combine(@"C:\Temp", "Perfect11_W11_TMP")))
                        Directory.Delete(Path.Combine(@"C:\Temp", "Perfect11_W11_TMP"), true);
                }
                catch { }
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Error: " + ex.Message;
                try
                {
                    if (File.Exists(destination))
                        File.Delete(destination);
                    if (Directory.Exists(Path.Combine(@"C:\Temp", "Perfect11_W11_TMP")))
                        Directory.Delete(Path.Combine(@"C:\Temp", "Perfect11_W11_TMP"), true);
                } catch { }
            }
            finally
            {
                _isDownloading = false;
                upgradeButton.Text = "Install";
                upgradeButton.Enabled = true;
                upgradeMethod.Enabled = true;
                if (upgradeMethod.SelectedIndex == 3 || upgradeMethod.SelectedIndex == 2) // Both Mini11 and custom ISO
                {
                    automateOOBECheck.Enabled = false;
                    automateOOBECheck.Checked = false;
                    bypassWin11RequirementsCheck.Enabled = false;
                    bypassWin11RequirementsCheck.Checked = false;
                }
                else if (upgradeMethod.SelectedIndex == 1) // Windows 11 LTSC
                {
                    automateOOBECheck.Enabled = true;
                }
                if (upgradeMethod.SelectedIndex != 0) // if not normal installation
                {
                    bypassWin11RequirementsCheck.Enabled = false;
                    bypassWin11RequirementsCheck.Checked = false;
                }
                else
                {
                    automateOOBECheck.Enabled = true;
                    bypassWin11RequirementsCheck.Enabled = true;
                    bypassWin11RequirementsCheck.Checked = true;
                }
                _cts = null;
            }
#else
            MessageBox.Show(destination + " " +  url, "Perfect11");
#endif
        }
        public async Task DownloadFileAsync(string url, string destinationPath, CancellationToken token)
        {
            using (HttpClient client = new HttpClient { Timeout = TimeSpan.FromHours(2) })
            using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, token))
            using (Stream contentStream = await response.Content.ReadAsStreamAsync())
            using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
            {
                long? totalBytes = response.Content.Headers.ContentLength;
                long totalRead = 0;
                byte[] buffer = new byte[8192];
                int bytesRead;
                DateTime lastUpdate = DateTime.Now;

                while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length, token)) > 0)
                {
                    await fileStream.WriteAsync(buffer, 0, bytesRead, token);
                    totalRead += bytesRead;

                    if (totalBytes.HasValue)
                    {
                        int progress = (int)((totalRead * 100L) / totalBytes.Value);
                        if (progress > 100) progress = 100;

                        installProgress.Value = progress;
                        statusLabel.Text = $"ISO Download Progress: {progress}%";

                        // Aggiorna la UI ogni ~200ms
                        if ((DateTime.Now - lastUpdate).TotalMilliseconds > 200)
                        {
                            Application.DoEvents();
                            lastUpdate = DateTime.Now;
                        }
                    }
                }
            }
        }
        // Assicurati di avere:
        // using System.Text;

        private void ExtractIsoWithProgress(string isoPath, string extractPath, CancellationToken token)
        {
            // Log file per diagnosticare i file che falliscono
            string logPath = Path.Combine(Path.GetDirectoryName(isoPath) ?? ".", "extract_errors.log");
            File.WriteAllText(logPath, $"Extraction started: {DateTime.Now}\r\n");

            using (FileStream isoStream = File.OpenRead(isoPath))
            {
                object reader = null;
                bool isUdf = false;

                // Provo prima UDF, poi ISO9660/Joliet (CDReader)
                try
                {
                    reader = new DiscUtils.Udf.UdfReader(isoStream);
                    isUdf = true;
                }
                catch (Exception exUdf)
                {
                    try
                    {
                        // rewind stream and try CDReader
                        isoStream.Seek(0, SeekOrigin.Begin);
                        reader = new DiscUtils.Iso9660.CDReader(isoStream, true);
                        isUdf = false;
                    }
                    catch (Exception exCd)
                    {
                        File.AppendAllText(logPath, $"Failed to open ISO with Udf ({exUdf.Message}) and CDReader ({exCd.Message})\r\n");
                        throw new Exception("Unable to open ISO with UDF or ISO9660 readers. See log for details.");
                    }
                }

                // Ottieni file list (entrambi supportano GetFiles con stessa signature)
                var allFiles = (reader as dynamic).GetFiles("", "*", SearchOption.AllDirectories) as IEnumerable<string>;
                var filesList = allFiles.ToList();
                int totalFiles = filesList.Count;
                int extractedCount = 0;

                // Imposta progress bar
                Invoke(new Action(() =>
                {
                    installProgress.Maximum = Math.Max(1, totalFiles);
                    installProgress.Value = 0;
                }));

                foreach (string rawFile in filesList)
                {
                    token.ThrowIfCancellationRequested();

                    string sourcePath = rawFile; // il percorso così com'è per il reader
                                                 // Costruiamo il percorso locale su disco (convertendo slash)
                    string localRelative = sourcePath.TrimStart('/', '\\').Replace('/', Path.DirectorySeparatorChar);
                    string destination = Path.Combine(extractPath, localRelative);

                    try
                    {
                        // Crea directory di destinazione
                        string dir = Path.GetDirectoryName(destination);
                        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                            Directory.CreateDirectory(dir);

                        // Proviamo ad aprire il file con varie strategie
                        Stream srcStream = TryOpenFileWithVariants(reader, sourcePath, logPath);
                        if (srcStream == null)
                        {
                            // se non siamo riusciti ad aprire, logga e continua
                            File.AppendAllText(logPath, $"[SKIP] Could not open: '{sourcePath}'\r\n");
                            extractedCount++;
                            Invoke(new Action(() =>
                            {
                                installProgress.Value = extractedCount;
                                statusLabel.Text = $"Skipped: ({extractedCount}/{totalFiles})";
                            }));
                            continue;
                        }

                        // Copia stream su file
                        using (srcStream)
                        using (FileStream dst = new FileStream(destination, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            srcStream.CopyTo(dst);
                        }

                        extractedCount++;
                        Invoke(new Action(() =>
                        {
                            installProgress.Value = extractedCount;
                            statusLabel.Text = $"Extracted ({extractedCount}/{totalFiles})";
                        }));
                    }
                    catch (OperationCanceledException)
                    {
                        // rilanciamo per la chiamante
                        throw;
                    }
                    catch (Exception exFile)
                    {
                        File.AppendAllText(logPath, $"[ERROR] File: '{sourcePath}' -> {exFile.GetType().Name}: {exFile.Message}\r\n");
                        extractedCount++;
                        Invoke(new Action(() =>
                        {
                            installProgress.Value = extractedCount;
                            statusLabel.Text = $"Error at ({extractedCount}/{totalFiles})";
                        }));
                    }
                }

                File.AppendAllText(logPath, $"Extraction finished: {DateTime.Now}\r\n");
            }
        }

        /// <summary>
        /// Tenta di aprire il file usando diverse varianti del percorso richiesto dal reader.
        /// Restituisce lo Stream se riesce, altrimenti null.
        /// </summary>
        private Stream TryOpenFileWithVariants(object reader, string originalPath, string logPath)
        {
            // Normalizzazioni da provare
            var candidates = new List<string>();

            // percorso così com'è (probabilmente con '/')
            candidates.Add(originalPath);

            // versione senza slash iniziale
            if (originalPath.StartsWith("/") || originalPath.StartsWith("\\"))
                candidates.Add(originalPath.TrimStart('/', '\\'));

            // con slash iniziale
            if (!originalPath.StartsWith("/"))
                candidates.Add("/" + originalPath.TrimStart('/', '\\'));

            // replace slash/backslash
            candidates.Add(originalPath.Replace('\\', '/'));
            candidates.Add(originalPath.Replace('/', '\\'));

            // varianti con normalizzazione Unicode (Form C)
            try
            {
                string normalized = originalPath.Normalize(System.Text.NormalizationForm.FormC);
                if (!candidates.Contains(normalized))
                    candidates.Add(normalized);
            }
            catch { /* ignore */ }

            // proviamo le candidate una alla volta
            foreach (string p in candidates.Distinct())
            {
                try
                {
                    // alcuni reader richiedono stringa con '/', altri accettano entrambe;
                    // usiamo dynamic per chiamare OpenFile
                    var rdr = reader as dynamic;
                    Stream s = null;

                    // Proviamo prima con (string, FileMode.Open)
                    try
                    {
                        s = rdr.OpenFile(p, FileMode.Open);
                    }
                    catch
                    {
                        // se sbaglia, proviamo a chiamare senza FileMode (alcune versioni hanno overload diverso)
                        try
                        {
                            s = rdr.OpenFile(p);
                        }
                        catch
                        {
                            s = null;
                        }
                    }

                    if (s != null)
                        return s;
                }
                catch (Exception ex)
                {
                    // loggare l'eccezione ma continuiamo con altre varianti
                    File.AppendAllText(logPath, $"[TRY FAILED] '{p}' => {ex.Message}\r\n");
                }
            }

            // non abbiamo trovato nulla
            return null;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cts != null)
                e.Cancel = true;
        }
    }
}
