﻿namespace TPFinal.View
{
    partial class CampaignViewListAll
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
            this.searchButton = new System.Windows.Forms.Button();
            this.searchText = new System.Windows.Forms.TextBox();
            this.dataGridViewCampaigns = new System.Windows.Forms.DataGridView();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCampaigns)).BeginInit();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(478, 33);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 20);
            this.searchButton.TabIndex = 0;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(372, 33);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(100, 20);
            this.searchText.TabIndex = 1;
            // 
            // dataGridViewCampaigns
            // 
            this.dataGridViewCampaigns.AllowUserToAddRows = false;
            this.dataGridViewCampaigns.AllowUserToDeleteRows = false;
            this.dataGridViewCampaigns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCampaigns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn,
            this.NameColumn,
            this.InitDateColumn,
            this.EndDateColumn});
            this.dataGridViewCampaigns.Location = new System.Drawing.Point(12, 69);
            this.dataGridViewCampaigns.Name = "dataGridViewCampaigns";
            this.dataGridViewCampaigns.ReadOnly = true;
            this.dataGridViewCampaigns.Size = new System.Drawing.Size(631, 245);
            this.dataGridViewCampaigns.TabIndex = 2;
            // 
            // idColumn
            // 
            this.idColumn.HeaderText = "ID";
            this.idColumn.Name = "idColumn";
            this.idColumn.ReadOnly = true;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // InitDateColumn
            // 
            this.InitDateColumn.HeaderText = "Init date";
            this.InitDateColumn.Name = "InitDateColumn";
            this.InitDateColumn.ReadOnly = true;
            // 
            // EndDateColumn
            // 
            this.EndDateColumn.HeaderText = "End date";
            this.EndDateColumn.Name = "EndDateColumn";
            this.EndDateColumn.ReadOnly = true;
            // 
            // CampaignViewListAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 352);
            this.Controls.Add(this.dataGridViewCampaigns);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.searchButton);
            this.Name = "CampaignViewListAll";
            this.Text = "CampaignViewListAll";
            this.Load += new System.EventHandler(this.CampaignViewListAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCampaigns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.DataGridView dataGridViewCampaigns;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDateColumn;
    }
}