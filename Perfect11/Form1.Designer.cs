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
            this.controlBoxEdit1 = new ReaLTaiizor.Controls.ControlBoxEdit();
            this.pages = new ReaLTaiizor.Controls.PoisonTabControl();
            this.welcomePage = new ReaLTaiizor.Controls.PoisonTabPage();
            this.poisonLabel2 = new ReaLTaiizor.Controls.PoisonLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.poisonLabel1 = new ReaLTaiizor.Controls.PoisonLabel();
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
            this.theme.SuspendLayout();
            this.pages.SuspendLayout();
            this.welcomePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.debloatPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // theme
            // 
            this.theme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.theme.Controls.Add(this.controlBoxEdit1);
            this.theme.Controls.Add(this.pages);
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
            this.pages.Controls.Add(this.debloatPage);
            this.pages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pages.Location = new System.Drawing.Point(3, 28);
            this.pages.Name = "pages";
            this.pages.SelectedIndex = 1;
            this.pages.Size = new System.Drawing.Size(1323, 732);
            this.pages.TabIndex = 1;
            this.pages.UseSelectable = true;
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
            this.welcomePage.HorizontalScrollbarSize = 8;
            this.welcomePage.Location = new System.Drawing.Point(4, 38);
            this.welcomePage.Name = "welcomePage";
            this.welcomePage.Size = new System.Drawing.Size(1315, 690);
            this.welcomePage.TabIndex = 0;
            this.welcomePage.Text = "Welcome";
            this.welcomePage.VerticalScrollbarBarColor = true;
            this.welcomePage.VerticalScrollbarHighlightOnWheel = false;
            this.welcomePage.VerticalScrollbarSize = 27;
            // 
            // poisonLabel2
            // 
            this.poisonLabel2.AutoSize = true;
            this.poisonLabel2.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel2.Location = new System.Drawing.Point(416, 379);
            this.poisonLabel2.Name = "poisonLabel2";
            this.poisonLabel2.Size = new System.Drawing.Size(492, 40);
            this.poisonLabel2.TabIndex = 3;
            this.poisonLabel2.Text = "Perfect11 is a tool made by a guy who loves to optimize Windows.\r\nIt allows to in" +
    "stalls apps, remove bloatware, configure services and even more.";
            this.poisonLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Perfect11.Properties.Resources.win11logo;
            this.pictureBox1.Location = new System.Drawing.Point(559, 156);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // poisonLabel1
            // 
            this.poisonLabel1.AutoSize = true;
            this.poisonLabel1.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel1.FontSize = ReaLTaiizor.Extension.Poison.PoisonLabelSize.Tall;
            this.poisonLabel1.Location = new System.Drawing.Point(374, 336);
            this.poisonLabel1.Name = "poisonLabel1";
            this.poisonLabel1.Size = new System.Drawing.Size(533, 25);
            this.poisonLabel1.TabIndex = 2;
            this.poisonLabel1.Text = "Welcome to Perfect11, the tool that makes Windows 11 almost perfect.";
            this.poisonLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.debloatPage.HorizontalScrollbarSize = 8;
            this.debloatPage.Location = new System.Drawing.Point(4, 38);
            this.debloatPage.Name = "debloatPage";
            this.debloatPage.Size = new System.Drawing.Size(1315, 690);
            this.debloatPage.TabIndex = 1;
            this.debloatPage.Text = "Debloat";
            this.debloatPage.VerticalScrollbarBarColor = true;
            this.debloatPage.VerticalScrollbarHighlightOnWheel = false;
            this.debloatPage.VerticalScrollbarSize = 17;
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
            this.ChkShowUWPSystem.Size = new System.Drawing.Size(134, 17);
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
            this.LstUWPRemove.UseSelectable = true;
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
            this.LstUWP.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Black;
            this.LstUWP.TabIndex = 2;
            this.LstUWP.TileSize = new System.Drawing.Size(348, 20);
            this.LstUWP.UseCompatibleStateImageBehavior = false;
            this.LstUWP.UseSelectable = true;
            this.LstUWP.View = System.Windows.Forms.View.Tile;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
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
            this.Load += new System.EventHandler(this.Form1_Load);
            this.theme.ResumeLayout(false);
            this.pages.ResumeLayout(false);
            this.welcomePage.ResumeLayout(false);
            this.welcomePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.debloatPage.ResumeLayout(false);
            this.debloatPage.PerformLayout();
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
    }
}

