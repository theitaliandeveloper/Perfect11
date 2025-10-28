namespace Perfect11
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.theme = new ReaLTaiizor.Forms.FormTheme();
            this.githubLink = new ReaLTaiizor.Controls.PoisonLinkLabel();
            this.controlBoxEdit1 = new ReaLTaiizor.Controls.ControlBoxEdit();
            this.pages = new ReaLTaiizor.Controls.PoisonTabControl();
            this.welcomePage = new ReaLTaiizor.Controls.PoisonTabPage();
            this.poisonLabel2 = new ReaLTaiizor.Controls.PoisonLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.poisonLabel1 = new ReaLTaiizor.Controls.PoisonLabel();
            this.upgradePage = new ReaLTaiizor.Controls.PoisonTabPage();
            this.statusLabel = new ReaLTaiizor.Controls.PoisonLabel();
            this.installProgress = new ReaLTaiizor.Controls.PoisonProgressBar();
            this.poisonLabel6 = new ReaLTaiizor.Controls.PoisonLabel();
            this.poisonLabel7 = new ReaLTaiizor.Controls.PoisonLabel();
            this.upgradeButton = new ReaLTaiizor.Controls.PoisonButton();
            this.automateOOBECheck = new ReaLTaiizor.Controls.PoisonCheckBox();
            this.bypassWin11RequirementsCheck = new ReaLTaiizor.Controls.PoisonCheckBox();
            this.poisonLabel5 = new ReaLTaiizor.Controls.PoisonLabel();
            this.upgradeMethod = new ReaLTaiizor.Controls.PoisonComboBox();
            this.poisonLabel3 = new ReaLTaiizor.Controls.PoisonLabel();
            this.poisonLabel4 = new ReaLTaiizor.Controls.PoisonLabel();
            this.debloatPage = new ReaLTaiizor.Controls.PoisonTabPage();
            this.BtnRunUninstaller = new ReaLTaiizor.Controls.PoisonButton();
            this.LblRemoveCount = new ReaLTaiizor.Controls.PoisonLabel();
            this.LblInstalledCount = new ReaLTaiizor.Controls.PoisonLabel();
            this.ChkShowUWPSystem = new ReaLTaiizor.Controls.PoisonCheckBox();
            this.LstUWPRemove = new ReaLTaiizor.Controls.PoisonListView();
            this.removeAllButton = new ReaLTaiizor.Controls.PoisonButton();
            this.addAllButton = new ReaLTaiizor.Controls.PoisonButton();
            this.removeButton = new ReaLTaiizor.Controls.PoisonButton();
            this.addButton = new ReaLTaiizor.Controls.PoisonButton();
            this.LstUWP = new ReaLTaiizor.Controls.PoisonListView();
            this.tweaksPage = new ReaLTaiizor.Controls.PoisonTabPage();
            this.runTweaks = new ReaLTaiizor.Controls.PoisonButton();
            this.tweaksList = new ReaLTaiizor.Controls.PoisonListView();
            this.editionLabel = new ReaLTaiizor.Controls.PoisonLabel();
            this.theme.SuspendLayout();
            this.pages.SuspendLayout();
            this.welcomePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.upgradePage.SuspendLayout();
            this.debloatPage.SuspendLayout();
            this.tweaksPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // theme
            // 
            this.theme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.theme.Controls.Add(this.githubLink);
            this.theme.Controls.Add(this.controlBoxEdit1);
            this.theme.Controls.Add(this.pages);
            this.theme.Controls.Add(this.editionLabel);
            this.theme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.theme.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.theme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.theme.Location = new System.Drawing.Point(0, 0);
            this.theme.Name = "theme";
            this.theme.Padding = new System.Windows.Forms.Padding(3, 28, 3, 28);
            this.theme.Sizable = false;
            this.theme.Size = new System.Drawing.Size(1329, 788);
            this.theme.SmartBounds = true;
            this.theme.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.theme.TabIndex = 0;
            this.theme.Text = "Perfect11";
            // 
            // githubLink
            // 
            this.githubLink.BackColor = System.Drawing.Color.Transparent;
            this.githubLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.githubLink.Location = new System.Drawing.Point(1275, 762);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(48, 26);
            this.githubLink.TabIndex = 5;
            this.githubLink.Text = "GitHub";
            this.githubLink.UseCustomBackColor = true;
            this.githubLink.UseCustomForeColor = true;
            this.githubLink.UseSelectable = true;
            this.githubLink.UseStyleColors = true;
            this.githubLink.Click += new System.EventHandler(this.githubLink_Click);
            // 
            // controlBoxEdit1
            // 
            this.controlBoxEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlBoxEdit1.BackColor = System.Drawing.Color.Transparent;
            this.controlBoxEdit1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.controlBoxEdit1.DefaultLocation = true;
            this.controlBoxEdit1.Location = new System.Drawing.Point(1248, -1);
            this.controlBoxEdit1.Name = "controlBoxEdit1";
            this.controlBoxEdit1.Size = new System.Drawing.Size(77, 19);
            this.controlBoxEdit1.TabIndex = 2;
            this.controlBoxEdit1.Text = "controlBoxEdit1";
            // 
            // pages
            // 
            this.pages.Controls.Add(this.welcomePage);
            this.pages.Controls.Add(this.upgradePage);
            this.pages.Controls.Add(this.debloatPage);
            this.pages.Controls.Add(this.tweaksPage);
            this.pages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pages.Location = new System.Drawing.Point(3, 28);
            this.pages.Name = "pages";
            this.pages.SelectedIndex = 0;
            this.pages.Size = new System.Drawing.Size(1323, 732);
            this.pages.TabIndex = 1;
            this.pages.UseSelectable = true;
            this.pages.SelectedIndexChanged += new System.EventHandler(this.pages_SelectedIndexChanged);
            // 
            // welcomePage
            // 
            this.welcomePage.BackgroundImage = global::Perfect11.Properties.Resources.win11wallpaperdark;
            this.welcomePage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.welcomePage.Controls.Add(this.poisonLabel2);
            this.welcomePage.Controls.Add(this.pictureBox1);
            this.welcomePage.Controls.Add(this.poisonLabel1);
            this.welcomePage.HorizontalScrollbarBarColor = true;
            this.welcomePage.HorizontalScrollbarHighlightOnWheel = false;
            this.welcomePage.HorizontalScrollbarSize = 9;
            this.welcomePage.Location = new System.Drawing.Point(4, 38);
            this.welcomePage.Name = "welcomePage";
            this.welcomePage.Size = new System.Drawing.Size(1315, 690);
            this.welcomePage.TabIndex = 0;
            this.welcomePage.Text = "Welcome";
            this.welcomePage.VerticalScrollbarBarColor = true;
            this.welcomePage.VerticalScrollbarHighlightOnWheel = false;
            this.welcomePage.VerticalScrollbarSize = 51;
            // 
            // poisonLabel2
            // 
            this.poisonLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.poisonLabel2.AutoSize = true;
            this.poisonLabel2.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel2.Location = new System.Drawing.Point(422, 362);
            this.poisonLabel2.Name = "poisonLabel2";
            this.poisonLabel2.Size = new System.Drawing.Size(459, 38);
            this.poisonLabel2.TabIndex = 3;
            this.poisonLabel2.Text = "Perfect11 is a tool made by a guy who loves to optimize Windows.\r\nIt allows to in" +
    "stalls apps, remove bloatware, tweak the system and even more.";
            this.poisonLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.poisonLabel2.UseCustomBackColor = true;
            this.poisonLabel2.UseCustomForeColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Perfect11.Properties.Resources.win11logo;
            this.pictureBox1.Location = new System.Drawing.Point(563, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // poisonLabel1
            // 
            this.poisonLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.poisonLabel1.AutoSize = true;
            this.poisonLabel1.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel1.FontSize = ReaLTaiizor.Extension.Poison.PoisonLabelSize.Tall;
            this.poisonLabel1.Location = new System.Drawing.Point(384, 326);
            this.poisonLabel1.Name = "poisonLabel1";
            this.poisonLabel1.Size = new System.Drawing.Size(533, 25);
            this.poisonLabel1.TabIndex = 2;
            this.poisonLabel1.Text = "Welcome to Perfect11, the tool that makes Windows 11 almost perfect.";
            this.poisonLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.poisonLabel1.UseCustomBackColor = true;
            this.poisonLabel1.UseCustomForeColor = true;
            // 
            // upgradePage
            // 
            this.upgradePage.Controls.Add(this.statusLabel);
            this.upgradePage.Controls.Add(this.installProgress);
            this.upgradePage.Controls.Add(this.poisonLabel6);
            this.upgradePage.Controls.Add(this.poisonLabel7);
            this.upgradePage.Controls.Add(this.upgradeButton);
            this.upgradePage.Controls.Add(this.automateOOBECheck);
            this.upgradePage.Controls.Add(this.bypassWin11RequirementsCheck);
            this.upgradePage.Controls.Add(this.poisonLabel5);
            this.upgradePage.Controls.Add(this.upgradeMethod);
            this.upgradePage.Controls.Add(this.poisonLabel3);
            this.upgradePage.Controls.Add(this.poisonLabel4);
            this.upgradePage.HorizontalScrollbarBarColor = true;
            this.upgradePage.HorizontalScrollbarHighlightOnWheel = false;
            this.upgradePage.HorizontalScrollbarSize = 10;
            this.upgradePage.Location = new System.Drawing.Point(4, 38);
            this.upgradePage.Name = "upgradePage";
            this.upgradePage.Size = new System.Drawing.Size(1315, 690);
            this.upgradePage.TabIndex = 3;
            this.upgradePage.Text = "Upgrade";
            this.upgradePage.VerticalScrollbarBarColor = true;
            this.upgradePage.VerticalScrollbarHighlightOnWheel = false;
            this.upgradePage.VerticalScrollbarSize = 10;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Location = new System.Drawing.Point(516, 638);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(48, 19);
            this.statusLabel.TabIndex = 14;
            this.statusLabel.Text = "$status";
            this.statusLabel.UseCustomBackColor = true;
            // 
            // installProgress
            // 
            this.installProgress.Location = new System.Drawing.Point(5, 660);
            this.installProgress.Name = "installProgress";
            this.installProgress.Size = new System.Drawing.Size(1045, 27);
            this.installProgress.TabIndex = 13;
            // 
            // poisonLabel6
            // 
            this.poisonLabel6.AutoSize = true;
            this.poisonLabel6.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel6.Location = new System.Drawing.Point(5, 247);
            this.poisonLabel6.Name = "poisonLabel6";
            this.poisonLabel6.Size = new System.Drawing.Size(436, 114);
            this.poisonLabel6.TabIndex = 12;
            this.poisonLabel6.Text = resources.GetString("poisonLabel6.Text");
            this.poisonLabel6.UseCustomBackColor = true;
            // 
            // poisonLabel7
            // 
            this.poisonLabel7.AutoSize = true;
            this.poisonLabel7.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel7.FontSize = ReaLTaiizor.Extension.Poison.PoisonLabelSize.Tall;
            this.poisonLabel7.Location = new System.Drawing.Point(5, 210);
            this.poisonLabel7.Name = "poisonLabel7";
            this.poisonLabel7.Size = new System.Drawing.Size(218, 25);
            this.poisonLabel7.TabIndex = 11;
            this.poisonLabel7.Text = "Reasons to get Windows 11:";
            this.poisonLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.poisonLabel7.UseCustomBackColor = true;
            // 
            // upgradeButton
            // 
            this.upgradeButton.Enabled = false;
            this.upgradeButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            this.upgradeButton.Location = new System.Drawing.Point(1198, 645);
            this.upgradeButton.Name = "upgradeButton";
            this.upgradeButton.Size = new System.Drawing.Size(112, 42);
            this.upgradeButton.TabIndex = 10;
            this.upgradeButton.Text = "Install";
            this.upgradeButton.UseSelectable = true;
            this.upgradeButton.Click += new System.EventHandler(this.upgradeButton_Click);
            // 
            // automateOOBECheck
            // 
            this.automateOOBECheck.AutoSize = true;
            this.automateOOBECheck.Enabled = false;
            this.automateOOBECheck.Location = new System.Drawing.Point(5, 164);
            this.automateOOBECheck.Name = "automateOOBECheck";
            this.automateOOBECheck.Size = new System.Drawing.Size(353, 15);
            this.automateOOBECheck.TabIndex = 9;
            this.automateOOBECheck.Text = "Automate OOBE (skips parts of the OOBE, useful if reinstalling)";
            this.automateOOBECheck.UseSelectable = true;
            // 
            // bypassWin11RequirementsCheck
            // 
            this.bypassWin11RequirementsCheck.AutoSize = true;
            this.bypassWin11RequirementsCheck.Checked = true;
            this.bypassWin11RequirementsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bypassWin11RequirementsCheck.Enabled = false;
            this.bypassWin11RequirementsCheck.Location = new System.Drawing.Point(5, 131);
            this.bypassWin11RequirementsCheck.Name = "bypassWin11RequirementsCheck";
            this.bypassWin11RequirementsCheck.Size = new System.Drawing.Size(418, 15);
            this.bypassWin11RequirementsCheck.TabIndex = 8;
            this.bypassWin11RequirementsCheck.Text = "Bypass Windows 11 requirements (including RAM, CPU, TPM, Secure Boot)";
            this.bypassWin11RequirementsCheck.UseSelectable = true;
            // 
            // poisonLabel5
            // 
            this.poisonLabel5.AutoSize = true;
            this.poisonLabel5.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel5.Location = new System.Drawing.Point(5, 87);
            this.poisonLabel5.Name = "poisonLabel5";
            this.poisonLabel5.Size = new System.Drawing.Size(114, 19);
            this.poisonLabel5.TabIndex = 7;
            this.poisonLabel5.Text = "Upgrade method:";
            this.poisonLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.poisonLabel5.UseCustomBackColor = true;
            // 
            // upgradeMethod
            // 
            this.upgradeMethod.FormattingEnabled = true;
            this.upgradeMethod.ItemHeight = 23;
            this.upgradeMethod.Items.AddRange(new object[] {
            "Upgrade to Windows 11 (recommended, all languages)",
            "Install Windows 11 IoT Enterprise LTSC (English US only)",
            "Install Mini11 LTS (English UK only)",
            "Use a custom image (for advanced users)"});
            this.upgradeMethod.Location = new System.Drawing.Point(143, 87);
            this.upgradeMethod.Name = "upgradeMethod";
            this.upgradeMethod.PromptText = "--Please select--";
            this.upgradeMethod.Size = new System.Drawing.Size(1067, 29);
            this.upgradeMethod.TabIndex = 6;
            this.upgradeMethod.UseSelectable = true;
            this.upgradeMethod.SelectedIndexChanged += new System.EventHandler(this.poisonComboBox1_SelectedIndexChanged);
            // 
            // poisonLabel3
            // 
            this.poisonLabel3.AutoSize = true;
            this.poisonLabel3.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel3.Location = new System.Drawing.Point(5, 54);
            this.poisonLabel3.Name = "poisonLabel3";
            this.poisonLabel3.Size = new System.Drawing.Size(760, 19);
            this.poisonLabel3.TabIndex = 5;
            this.poisonLabel3.Text = "In this page, we\'ll get you on Windows 11 as Windows 10 is now end of life. This " +
    "process can take some time, so please be patient!";
            this.poisonLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.poisonLabel3.UseCustomBackColor = true;
            // 
            // poisonLabel4
            // 
            this.poisonLabel4.AutoSize = true;
            this.poisonLabel4.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel4.FontSize = ReaLTaiizor.Extension.Poison.PoisonLabelSize.Tall;
            this.poisonLabel4.Location = new System.Drawing.Point(5, 17);
            this.poisonLabel4.Name = "poisonLabel4";
            this.poisonLabel4.Size = new System.Drawing.Size(227, 25);
            this.poisonLabel4.TabIndex = 4;
            this.poisonLabel4.Text = "Let\'s get you on Windows 11!";
            this.poisonLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.poisonLabel4.UseCustomBackColor = true;
            // 
            // debloatPage
            // 
            this.debloatPage.Controls.Add(this.BtnRunUninstaller);
            this.debloatPage.Controls.Add(this.LblRemoveCount);
            this.debloatPage.Controls.Add(this.LblInstalledCount);
            this.debloatPage.Controls.Add(this.ChkShowUWPSystem);
            this.debloatPage.Controls.Add(this.LstUWPRemove);
            this.debloatPage.Controls.Add(this.removeAllButton);
            this.debloatPage.Controls.Add(this.addAllButton);
            this.debloatPage.Controls.Add(this.removeButton);
            this.debloatPage.Controls.Add(this.addButton);
            this.debloatPage.Controls.Add(this.LstUWP);
            this.debloatPage.HorizontalScrollbarBarColor = true;
            this.debloatPage.HorizontalScrollbarHighlightOnWheel = false;
            this.debloatPage.HorizontalScrollbarSize = 9;
            this.debloatPage.Location = new System.Drawing.Point(4, 38);
            this.debloatPage.Name = "debloatPage";
            this.debloatPage.Size = new System.Drawing.Size(1315, 690);
            this.debloatPage.TabIndex = 1;
            this.debloatPage.Text = "Debloat";
            this.debloatPage.VerticalScrollbarBarColor = true;
            this.debloatPage.VerticalScrollbarHighlightOnWheel = false;
            this.debloatPage.VerticalScrollbarSize = 31;
            // 
            // BtnRunUninstaller
            // 
            this.BtnRunUninstaller.Location = new System.Drawing.Point(1198, 645);
            this.BtnRunUninstaller.Name = "BtnRunUninstaller";
            this.BtnRunUninstaller.Size = new System.Drawing.Size(112, 42);
            this.BtnRunUninstaller.TabIndex = 12;
            this.BtnRunUninstaller.Text = "Remove selected";
            this.BtnRunUninstaller.UseSelectable = true;
            this.BtnRunUninstaller.Click += new System.EventHandler(this.BtnRunUninstaller_Click);
            // 
            // LblRemoveCount
            // 
            this.LblRemoveCount.AutoSize = true;
            this.LblRemoveCount.FontSize = ReaLTaiizor.Extension.Poison.PoisonLabelSize.Tall;
            this.LblRemoveCount.Location = new System.Drawing.Point(1198, 13);
            this.LblRemoveCount.Name = "LblRemoveCount";
            this.LblRemoveCount.Size = new System.Drawing.Size(112, 25);
            this.LblRemoveCount.TabIndex = 11;
            this.LblRemoveCount.Text = "Removing (0)";
            // 
            // LblInstalledCount
            // 
            this.LblInstalledCount.AutoSize = true;
            this.LblInstalledCount.FontSize = ReaLTaiizor.Extension.Poison.PoisonLabelSize.Tall;
            this.LblInstalledCount.Location = new System.Drawing.Point(5, 13);
            this.LblInstalledCount.Name = "LblInstalledCount";
            this.LblInstalledCount.Size = new System.Drawing.Size(98, 25);
            this.LblInstalledCount.TabIndex = 9;
            this.LblInstalledCount.Text = "Installed (0)";
            // 
            // ChkShowUWPSystem
            // 
            this.ChkShowUWPSystem.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkShowUWPSystem.AutoSize = true;
            this.ChkShowUWPSystem.Location = new System.Drawing.Point(5, 650);
            this.ChkShowUWPSystem.Name = "ChkShowUWPSystem";
            this.ChkShowUWPSystem.Size = new System.Drawing.Size(123, 15);
            this.ChkShowUWPSystem.TabIndex = 8;
            this.ChkShowUWPSystem.Text = "Show System Apps";
            this.ChkShowUWPSystem.UseSelectable = true;
            this.ChkShowUWPSystem.CheckedChanged += new System.EventHandler(this.ChkShowUWPSystem_CheckedChanged);
            // 
            // LstUWPRemove
            // 
            this.LstUWPRemove.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LstUWPRemove.FullRowSelect = true;
            this.LstUWPRemove.Location = new System.Drawing.Point(792, 46);
            this.LstUWPRemove.Name = "LstUWPRemove";
            this.LstUWPRemove.OwnerDraw = true;
            this.LstUWPRemove.Size = new System.Drawing.Size(518, 579);
            this.LstUWPRemove.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.LstUWPRemove.TabIndex = 7;
            this.LstUWPRemove.TileSize = new System.Drawing.Size(348, 20);
            this.LstUWPRemove.UseCompatibleStateImageBehavior = false;
            this.LstUWPRemove.UseCustomBackColor = true;
            this.LstUWPRemove.UseCustomForeColor = true;
            this.LstUWPRemove.UseSelectable = true;
            this.LstUWPRemove.UseStyleColors = true;
            this.LstUWPRemove.View = System.Windows.Forms.View.Tile;
            // 
            // removeAllButton
            // 
            this.removeAllButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            this.removeAllButton.Location = new System.Drawing.Point(592, 412);
            this.removeAllButton.Name = "removeAllButton";
            this.removeAllButton.Size = new System.Drawing.Size(144, 43);
            this.removeAllButton.TabIndex = 6;
            this.removeAllButton.Text = "< Remove all";
            this.removeAllButton.UseSelectable = true;
            this.removeAllButton.Click += new System.EventHandler(this.removeAllButton_Click);
            // 
            // addAllButton
            // 
            this.addAllButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            this.addAllButton.Location = new System.Drawing.Point(592, 342);
            this.addAllButton.Name = "addAllButton";
            this.addAllButton.Size = new System.Drawing.Size(144, 43);
            this.addAllButton.TabIndex = 5;
            this.addAllButton.Text = "Add all>";
            this.addAllButton.UseSelectable = true;
            this.addAllButton.Click += new System.EventHandler(this.addAllButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            this.removeButton.Location = new System.Drawing.Point(592, 265);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(144, 43);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "< Remove";
            this.removeButton.UseSelectable = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            this.addButton.Location = new System.Drawing.Point(592, 195);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(144, 43);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add >";
            this.addButton.UseSelectable = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // LstUWP
            // 
            this.LstUWP.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LstUWP.FullRowSelect = true;
            this.LstUWP.Location = new System.Drawing.Point(5, 46);
            this.LstUWP.Name = "LstUWP";
            this.LstUWP.OwnerDraw = true;
            this.LstUWP.Size = new System.Drawing.Size(518, 579);
            this.LstUWP.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.LstUWP.TabIndex = 2;
            this.LstUWP.TileSize = new System.Drawing.Size(348, 20);
            this.LstUWP.UseCompatibleStateImageBehavior = false;
            this.LstUWP.UseCustomBackColor = true;
            this.LstUWP.UseCustomForeColor = true;
            this.LstUWP.UseSelectable = true;
            this.LstUWP.UseStyleColors = true;
            this.LstUWP.View = System.Windows.Forms.View.Tile;
            // 
            // tweaksPage
            // 
            this.tweaksPage.Controls.Add(this.runTweaks);
            this.tweaksPage.Controls.Add(this.tweaksList);
            this.tweaksPage.HorizontalScrollbarBarColor = true;
            this.tweaksPage.HorizontalScrollbarHighlightOnWheel = false;
            this.tweaksPage.HorizontalScrollbarSize = 9;
            this.tweaksPage.Location = new System.Drawing.Point(4, 38);
            this.tweaksPage.Name = "tweaksPage";
            this.tweaksPage.Size = new System.Drawing.Size(1315, 690);
            this.tweaksPage.TabIndex = 2;
            this.tweaksPage.Text = "Tweak";
            this.tweaksPage.VerticalScrollbarBarColor = true;
            this.tweaksPage.VerticalScrollbarHighlightOnWheel = false;
            this.tweaksPage.VerticalScrollbarSize = 12;
            // 
            // runTweaks
            // 
            this.runTweaks.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            this.runTweaks.Location = new System.Drawing.Point(1189, 633);
            this.runTweaks.Name = "runTweaks";
            this.runTweaks.Size = new System.Drawing.Size(121, 54);
            this.runTweaks.TabIndex = 3;
            this.runTweaks.Text = "Run Tweaks";
            this.runTweaks.UseSelectable = true;
            this.runTweaks.Click += new System.EventHandler(this.runTweaks_Click);
            // 
            // tweaksList
            // 
            this.tweaksList.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tweaksList.FullRowSelect = true;
            this.tweaksList.Location = new System.Drawing.Point(0, 0);
            this.tweaksList.Name = "tweaksList";
            this.tweaksList.OwnerDraw = true;
            this.tweaksList.Size = new System.Drawing.Size(1310, 617);
            this.tweaksList.TabIndex = 2;
            this.tweaksList.UseCompatibleStateImageBehavior = false;
            this.tweaksList.UseCustomBackColor = true;
            this.tweaksList.UseCustomForeColor = true;
            this.tweaksList.UseSelectable = true;
            this.tweaksList.UseStyleColors = true;
            this.tweaksList.Resize += new System.EventHandler(this.tweaksList_Resize);
            // 
            // editionLabel
            // 
            this.editionLabel.AutoSize = true;
            this.editionLabel.BackColor = System.Drawing.Color.Transparent;
            this.editionLabel.Location = new System.Drawing.Point(12, 767);
            this.editionLabel.Name = "editionLabel";
            this.editionLabel.Size = new System.Drawing.Size(213, 21);
            this.editionLabel.TabIndex = 4;
            this.editionLabel.Text = "Perfect11 Community Edition";
            this.editionLabel.UseCustomBackColor = true;
            this.editionLabel.UseCustomFont = true;
            this.editionLabel.UseCustomForeColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1329, 788);
            this.Controls.Add(this.theme);
            this.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(126, 50);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Perfect11";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.theme.ResumeLayout(false);
            this.theme.PerformLayout();
            this.pages.ResumeLayout(false);
            this.welcomePage.ResumeLayout(false);
            this.welcomePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.upgradePage.ResumeLayout(false);
            this.upgradePage.PerformLayout();
            this.debloatPage.ResumeLayout(false);
            this.debloatPage.PerformLayout();
            this.tweaksPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.FormTheme theme;
        private ReaLTaiizor.Controls.PoisonTabControl pages;
        private ReaLTaiizor.Controls.PoisonTabPage welcomePage;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel2;
        private ReaLTaiizor.Controls.ControlBoxEdit controlBoxEdit1;
        private ReaLTaiizor.Controls.PoisonTabPage debloatPage;
        private ReaLTaiizor.Controls.PoisonListView LstUWP;
        private ReaLTaiizor.Controls.PoisonListView LstUWPRemove;
        private ReaLTaiizor.Controls.PoisonButton removeAllButton;
        private ReaLTaiizor.Controls.PoisonButton addAllButton;
        private ReaLTaiizor.Controls.PoisonButton removeButton;
        private ReaLTaiizor.Controls.PoisonButton addButton;
        private ReaLTaiizor.Controls.PoisonCheckBox ChkShowUWPSystem;
        private ReaLTaiizor.Controls.PoisonLabel LblInstalledCount;
        private ReaLTaiizor.Controls.PoisonLabel LblRemoveCount;
        private ReaLTaiizor.Controls.PoisonButton BtnRunUninstaller;
        private ReaLTaiizor.Controls.PoisonTabPage tweaksPage;
        private ReaLTaiizor.Controls.PoisonListView tweaksList;
        private ReaLTaiizor.Controls.PoisonButton runTweaks;
        private ReaLTaiizor.Controls.PoisonLabel editionLabel;
        private ReaLTaiizor.Controls.PoisonLinkLabel githubLink;
        private ReaLTaiizor.Controls.PoisonTabPage upgradePage;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel3;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel4;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel5;
        private ReaLTaiizor.Controls.PoisonComboBox upgradeMethod;
        private ReaLTaiizor.Controls.PoisonCheckBox bypassWin11RequirementsCheck;
        private ReaLTaiizor.Controls.PoisonCheckBox automateOOBECheck;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel6;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel7;
        private ReaLTaiizor.Controls.PoisonButton upgradeButton;
        private ReaLTaiizor.Controls.PoisonLabel statusLabel;
        private ReaLTaiizor.Controls.PoisonProgressBar installProgress;
    }
}

