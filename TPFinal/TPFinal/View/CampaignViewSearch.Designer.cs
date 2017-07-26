namespace TPFinal.View
{
    partial class CampaignViewSearch
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
            this.searchText = new System.Windows.Forms.TextBox();
            this.dataGridViewCampaigns = new System.Windows.Forms.DataGridView();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameTextLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCampaigns)).BeginInit();
            this.SuspendLayout();
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(372, 9);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(271, 20);
            this.searchText.TabIndex = 1;
            this.searchText.TextChanged += new System.EventHandler(this.searchText_TextChanged);
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
            this.dataGridViewCampaigns.Location = new System.Drawing.Point(12, 45);
            this.dataGridViewCampaigns.Name = "dataGridViewCampaigns";
            this.dataGridViewCampaigns.ReadOnly = true;
            this.dataGridViewCampaigns.Size = new System.Drawing.Size(631, 245);
            this.dataGridViewCampaigns.TabIndex = 2;
            this.dataGridViewCampaigns.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewCampaigns_KeyPress);
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
            // nameTextLabel
            // 
            this.nameTextLabel.AutoSize = true;
            this.nameTextLabel.Location = new System.Drawing.Point(282, 12);
            this.nameTextLabel.Name = "nameTextLabel";
            this.nameTextLabel.Size = new System.Drawing.Size(84, 13);
            this.nameTextLabel.TabIndex = 3;
            this.nameTextLabel.Text = "Search by name";
            // 
            // CampaignViewSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 311);
            this.Controls.Add(this.nameTextLabel);
            this.Controls.Add(this.dataGridViewCampaigns);
            this.Controls.Add(this.searchText);
            this.Name = "CampaignViewSearch";
            this.Text = "CampaignViewSearch";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCampaigns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.DataGridView dataGridViewCampaigns;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDateColumn;
        private System.Windows.Forms.Label nameTextLabel;
    }
}