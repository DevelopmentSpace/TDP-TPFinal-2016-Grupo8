namespace TPFinal.View
{
    partial class AdminView
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.campaignStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createCampaign = new System.Windows.Forms.ToolStripMenuItem();
            this.searchCampaign = new System.Windows.Forms.ToolStripMenuItem();
            this.bannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTextBanner = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTextBanner = new System.Windows.Forms.ToolStripMenuItem();
            this.rssSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createRssSource = new System.Windows.Forms.ToolStripMenuItem();
            this.searchRssSource = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.campaignStripMenuItem,
            this.bannerToolStripMenuItem,
            this.rssSourceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(595, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // campaignStripMenuItem
            // 
            this.campaignStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createCampaign,
            this.searchCampaign});
            this.campaignStripMenuItem.Name = "campaignStripMenuItem";
            this.campaignStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.campaignStripMenuItem.Text = "Campaign";
            // 
            // createCampaign
            // 
            this.createCampaign.Name = "createCampaign";
            this.createCampaign.Size = new System.Drawing.Size(109, 22);
            this.createCampaign.Text = "Create";
            this.createCampaign.Click += new System.EventHandler(this.createCampaign_Click);
            // 
            // searchCampaign
            // 
            this.searchCampaign.Name = "searchCampaign";
            this.searchCampaign.Size = new System.Drawing.Size(109, 22);
            this.searchCampaign.Text = "Search";
            this.searchCampaign.Click += new System.EventHandler(this.searchCampaign_Click);
            // 
            // bannerToolStripMenuItem
            // 
            this.bannerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createTextBanner,
            this.searchTextBanner});
            this.bannerToolStripMenuItem.Name = "bannerToolStripMenuItem";
            this.bannerToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.bannerToolStripMenuItem.Text = "TextBanner";
            // 
            // createTextBanner
            // 
            this.createTextBanner.Name = "createTextBanner";
            this.createTextBanner.Size = new System.Drawing.Size(109, 22);
            this.createTextBanner.Text = "Create";
            this.createTextBanner.Click += new System.EventHandler(this.createTextBanner_Click);
            // 
            // searchTextBanner
            // 
            this.searchTextBanner.Name = "searchTextBanner";
            this.searchTextBanner.Size = new System.Drawing.Size(109, 22);
            this.searchTextBanner.Text = "Search";
            this.searchTextBanner.Click += new System.EventHandler(this.searchTextBanner_Click);
            // 
            // rssSourceToolStripMenuItem
            // 
            this.rssSourceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createRssSource,
            this.searchRssSource});
            this.rssSourceToolStripMenuItem.Name = "rssSourceToolStripMenuItem";
            this.rssSourceToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.rssSourceToolStripMenuItem.Text = "RssSource";
            // 
            // createRssSource
            // 
            this.createRssSource.Name = "createRssSource";
            this.createRssSource.Size = new System.Drawing.Size(109, 22);
            this.createRssSource.Text = "Create";
            this.createRssSource.Click += new System.EventHandler(this.createRssBanner_Click);
            // 
            // searchRssSource
            // 
            this.searchRssSource.Name = "searchRssSource";
            this.searchRssSource.Size = new System.Drawing.Size(109, 22);
            this.searchRssSource.Text = "Search";
            this.searchRssSource.Click += new System.EventHandler(this.searchRssBanner_Click);
            // 
            // AdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 264);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminView";
            this.Text = "AdminView";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem campaignStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createCampaign;
        private System.Windows.Forms.ToolStripMenuItem bannerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rssSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchCampaign;
        private System.Windows.Forms.ToolStripMenuItem createTextBanner;
        private System.Windows.Forms.ToolStripMenuItem searchTextBanner;
        private System.Windows.Forms.ToolStripMenuItem createRssSource;
        private System.Windows.Forms.ToolStripMenuItem searchRssSource;
    }
}