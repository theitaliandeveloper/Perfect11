using Perfect11.Library;
using Perfect11.Properties;
using Perfect11.TweaksInterface;
using ReaLTaiizor.Enum.Poison;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perfect11
{
    public partial class Form1 : Form
    {
        private List<string> _listSystemApps = new List<string>();
        private List<IPlugin> _tweaks = new List<IPlugin>();
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
                poisonLabel2.Theme = ThemeStyle.Dark;
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
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pages.SelectedTab = welcomePage; // Always start from the first tab
            editionLabel.Text = AppEdition;
            theme.Text = AppEdition;
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
                    string output2 = PowerShell.Execute(command2);
                    string output = PowerShell.Execute(command);
#if DEBUG
                    MessageBox.Show(output2);
                    MessageBox.Show(output);
#endif
                    if (!output.ToLower().Contains("error") && !output2.ToLower().Contains("error"))
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
            if (ChkShowUWPSystem.Checked) MessageBox.Show("You're about to show system UWP apps. Those apps if removed can break several things in your system. Proceed with caution.", "Perfect11 - WARNING", MessageBoxButtons.OK);
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
            if (!Directory.Exists("Tweaks"))
            {
                Directory.CreateDirectory("Tweaks");
            }
            if (File.Exists("Tweaks\\Perfect11.TweaksInterface.dll"))
            {
                File.Delete("Tweaks\\Perfect11.TweaksInterface.dll");
            }
            tweaksList.View = View.Details;
            tweaksList.Columns.Add("Name", 150);
            tweaksList.Columns.Add("Description", 300);
            tweaksList.FullRowSelect = true;
            int totalWidth = tweaksList.ClientSize.Width;
            tweaksList.Columns[0].Width = (int)(totalWidth * 0.4);
            tweaksList.Columns[1].Width = (int)(totalWidth * 0.6);

            // Load plugins
            _tweaks = Utilities.LoadTweaks("Tweaks");

            // Populate ListView
            foreach (var plugin in _tweaks)
            {
                var item = new ListViewItem(plugin.Name);
                item.SubItems.Add(plugin.Description);
                item.Tag = plugin; // store the plugin object for later
                tweaksList.Items.Add(item);
            }
            if (tweaksList.Items.Count == 0) runTweaks.Enabled = false;
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
                        await Task.Run(() => plugin.Execute()); // run in background thread
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
            int totalWidth = tweaksList.ClientSize.Width;
            tweaksList.Columns[0].Width = (int)(totalWidth * 0.4);
            tweaksList.Columns[1].Width = (int)(totalWidth * 0.6);
        }
    }
}
