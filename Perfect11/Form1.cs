using Microsoft.VisualBasic.ApplicationServices;
using Perfect11.Library;
using Perfect11.Properties;
using ReaLTaiizor.Enum.Poison;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perfect11
{
    public partial class Form1 : Form
    {
        private List<string> _listSystemApps = new List<string>();
        public Form1()
        {
            InitializeComponent();
            DarkMode(true);
            GetUWPSystem();
            GetUWP();
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
            }
            else
            {
                pages.Theme = ThemeStyle.Light;
                welcomePage.Theme = ThemeStyle.Light;
                debloatPage.Theme = ThemeStyle.Light;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void GetUWP()
        {
            LstUWP.Items.Clear();

            // Run PowerShell to get UWP app names
            string output = PowerShell.Execute("Get-AppxPackage -allusers | Select-Object -ExpandProperty Name");

            // Split output into lines
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
            _listSystemApps.Clear(); // Optional: clear old entries

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

            foreach (var item in LstUWPRemove.Items)
            {
                string appName = item.ToString();

                // Build the command
                string command = $"Get-AppxPackage -allusers -Name \"{appName}\" | Remove-AppxPackage -allusers";

                try
                {
                    string output = PowerShell.Execute(command);

                    // Basic success/failure logic (you can enhance this)
                    if (!string.IsNullOrWhiteSpace(output) && !output.ToLower().Contains("error"))
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

            // Return status summary
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
                LstUWPRemove.Items.Add((ListViewItem)item.Clone()); // Clone to avoid reference issues
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
                // Create a temporary list to avoid modifying collection during iteration
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
            // Create a temporary list to hold items to move
            List<ListViewItem> itemsToMove = new List<ListViewItem>();

            foreach (ListViewItem item in LstUWPRemove.Items)
            {
                // Clone the item to add to the other ListView
                itemsToMove.Add((ListViewItem)item.Clone());
            }

            // Add to destination ListView
            LstUWP.Items.AddRange(itemsToMove.ToArray());

            // Clear source ListView
            LstUWPRemove.Items.Clear();

            RefreshUWP();
        }

        private void BtnRunUninstaller_Click(object sender, EventArgs e)
        {
            if (LstUWPRemove.Items.Count == 0) { MessageBox.Show("No items were selected for removal.","Perfect11", MessageBoxButtons.OK,MessageBoxIcon.Information); }
            else
            {
                Enabled = false;

                MessageBox.Show(RemoveUWP());

                LstUWPRemove.Items.Clear();
                GetUWP();
                Enabled = true;
            }
        }
    }
}
