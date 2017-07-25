namespace TPFinal.View
{
    partial class RssTextBannerSearch
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
            this.nameTextLabel = new System.Windows.Forms.Label();
            this.dataGridViewRssBanners = new System.Windows.Forms.DataGridView();
            this.searchText = new System.Windows.Forms.TextBox();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRssBanners)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextLabel
            // 
            this.nameTextLabel.AutoSize = true;
            this.nameTextLabel.Location = new System.Drawing.Point(282, 11);
            this.nameTextLabel.Name = "nameTextLabel";
            this.nameTextLabel.Size = new System.Drawing.Size(84, 13);
            this.nameTextLabel.TabIndex = 9;
            this.nameTextLabel.Text = "Search by name";
            // 
            // dataGridViewRssBanners
            // 
            this.dataGridViewRssBanners.AllowUserToAddRows = false;
            this.dataGridViewRssBanners.AllowUserToDeleteRows = false;
            this.dataGridViewRssBanners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRssBanners.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn,
            this.NameColumn,
            this.InitDateColumn,
            this.EndDateColumn,
            this.Url});
            this.dataGridViewRssBanners.Location = new System.Drawing.Point(12, 44);
            this.dataGridViewRssBanners.Name = "dataGridViewRssBanners";
            this.dataGridViewRssBanners.ReadOnly = true;
            this.dataGridViewRssBanners.Size = new System.Drawing.Size(631, 245);
            this.dataGridViewRssBanners.TabIndex = 8;
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(372, 8);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(271, 20);
            this.searchText.TabIndex = 7;
            this.searchText.TextChanged += new System.EventHandler(this.searchText_TextChanged);
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
            // Url
            // 
            this.Url.HeaderText = "URL";
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            // 
            // RssTextBannerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 308);
            this.Controls.Add(this.nameTextLabel);
            this.Controls.Add(this.dataGridViewRssBanners);
            this.Controls.Add(this.searchText);
            this.Name = "RssTextBannerSearch";
            this.Text = "RssTextBannerSearch";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRssBanners)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameTextLabel;
        private System.Windows.Forms.DataGridView dataGridViewRssBanners;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.TextBox searchText;
    }
}