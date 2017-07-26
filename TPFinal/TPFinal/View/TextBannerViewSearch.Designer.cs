namespace TPFinal.View
{
    partial class TextBannerViewSearch
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
            this.dataGridViewTextBanners = new System.Windows.Forms.DataGridView();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTextBanners)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextLabel
            // 
            this.nameTextLabel.AutoSize = true;
            this.nameTextLabel.Location = new System.Drawing.Point(282, 8);
            this.nameTextLabel.Name = "nameTextLabel";
            this.nameTextLabel.Size = new System.Drawing.Size(84, 13);
            this.nameTextLabel.TabIndex = 6;
            this.nameTextLabel.Text = "Search by name";
            // 
            // dataGridViewTextBanners
            // 
            this.dataGridViewTextBanners.AllowUserToAddRows = false;
            this.dataGridViewTextBanners.AllowUserToDeleteRows = false;
            this.dataGridViewTextBanners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTextBanners.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn,
            this.NameColumn,
            this.InitDateColumn,
            this.EndDateColumn,
            this.Text});
            this.dataGridViewTextBanners.Location = new System.Drawing.Point(12, 41);
            this.dataGridViewTextBanners.Name = "dataGridViewTextBanners";
            this.dataGridViewTextBanners.ReadOnly = true;
            this.dataGridViewTextBanners.Size = new System.Drawing.Size(631, 245);
            this.dataGridViewTextBanners.TabIndex = 5;
            this.dataGridViewTextBanners.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewTextBanners_KeyPress);
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
            // Text
            // 
            this.Text.HeaderText = "Text";
            this.Text.Name = "Text";
            this.Text.ReadOnly = true;
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(372, 5);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(271, 20);
            this.searchText.TabIndex = 4;
            this.searchText.TextChanged += new System.EventHandler(this.searchText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Select a row and press \"m\" to modify the row";
            // 
            // deleteLabel
            // 
            this.deleteLabel.AutoSize = true;
            this.deleteLabel.Location = new System.Drawing.Point(42, 298);
            this.deleteLabel.Name = "deleteLabel";
            this.deleteLabel.Size = new System.Drawing.Size(199, 13);
            this.deleteLabel.TabIndex = 13;
            this.deleteLabel.Text = "Select rows and press \"d\" to delete rows";
            // 
            // TextBannerViewSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 346);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteLabel);
            this.Controls.Add(this.nameTextLabel);
            this.Controls.Add(this.dataGridViewTextBanners);
            this.Controls.Add(this.searchText);
            this.Name = "TextBannerViewSearch";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTextBanners)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameTextLabel;
        private System.Windows.Forms.DataGridView dataGridViewTextBanners;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDateColumn;
        private new System.Windows.Forms.DataGridViewTextBoxColumn Text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label deleteLabel;
    }
}