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
            this.theme = new ReaLTaiizor.Forms.FormTheme();
            this.pages = new ReaLTaiizor.Controls.PoisonTabControl();
            this.welcomePage = new ReaLTaiizor.Controls.PoisonTabPage();
            this.poisonLabel2 = new ReaLTaiizor.Controls.PoisonLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.poisonLabel1 = new ReaLTaiizor.Controls.PoisonLabel();
            this.controlBoxEdit1 = new ReaLTaiizor.Controls.ControlBoxEdit();
            this.theme.SuspendLayout();
            this.pages.SuspendLayout();
            this.welcomePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.theme.Sizable = true;
            this.theme.Size = new System.Drawing.Size(1329, 788);
            this.theme.SmartBounds = true;
            this.theme.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.theme.TabIndex = 0;
            this.theme.Text = "Perfect11";
            // 
            // pages
            // 
            this.pages.Controls.Add(this.welcomePage);
            this.pages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pages.Location = new System.Drawing.Point(3, 28);
            this.pages.Name = "pages";
            this.pages.SelectedIndex = 0;
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
            this.welcomePage.HorizontalScrollbarSize = 20;
            this.welcomePage.Location = new System.Drawing.Point(4, 38);
            this.welcomePage.Name = "welcomePage";
            this.welcomePage.Size = new System.Drawing.Size(1315, 690);
            this.welcomePage.TabIndex = 0;
            this.welcomePage.Text = "Welcome";
            this.welcomePage.VerticalScrollbarBarColor = true;
            this.welcomePage.VerticalScrollbarHighlightOnWheel = false;
            this.welcomePage.VerticalScrollbarSize = 22;
            // 
            // poisonLabel2
            // 
            this.poisonLabel2.AutoSize = true;
            this.poisonLabel2.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel2.Location = new System.Drawing.Point(416, 379);
            this.poisonLabel2.Name = "poisonLabel2";
            this.poisonLabel2.Size = new System.Drawing.Size(465, 38);
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
            // controlBoxEdit1
            // 
            this.controlBoxEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlBoxEdit1.BackColor = System.Drawing.Color.Transparent;
            this.controlBoxEdit1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.controlBoxEdit1.DefaultLocation = true;
            this.controlBoxEdit1.Location = new System.Drawing.Point(1246, 3);
            this.controlBoxEdit1.Name = "controlBoxEdit1";
            this.controlBoxEdit1.Size = new System.Drawing.Size(77, 19);
            this.controlBoxEdit1.TabIndex = 2;
            this.controlBoxEdit1.Text = "controlBoxEdit1";
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
    }
}

