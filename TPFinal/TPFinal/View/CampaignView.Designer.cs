namespace TPFinal.View
{
    partial class CampaignView
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
            this.initDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.campaingBox = new System.Windows.Forms.GroupBox();
            this.imageBox = new System.Windows.Forms.GroupBox();
            this.dataGridViewImages = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.addPictureButton = new System.Windows.Forms.Button();
            this.endTimeText = new System.Windows.Forms.GroupBox();
            this.InitDateLabel = new System.Windows.Forms.Label();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.initTimeText = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.EndTimeLabel = new System.Windows.Forms.Label();
            this.InitTimeLabel = new System.Windows.Forms.Label();
            this.intervalText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.campaignNameText = new System.Windows.Forms.TextBox();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.campaingBox.SuspendLayout();
            this.imageBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImages)).BeginInit();
            this.endTimeText.SuspendLayout();
            this.SuspendLayout();
            // 
            // initDateTimePicker
            // 
            this.initDateTimePicker.Location = new System.Drawing.Point(101, 26);
            this.initDateTimePicker.Name = "initDateTimePicker";
            this.initDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.initDateTimePicker.TabIndex = 0;
            this.initDateTimePicker.Value = new System.DateTime(2017, 7, 15, 0, 0, 0, 0);
            this.initDateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(101, 52);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endDateTimePicker.TabIndex = 1;
            this.endDateTimePicker.Value = new System.DateTime(2017, 7, 22, 0, 0, 0, 0);
            // 
            // campaingBox
            // 
            this.campaingBox.Controls.Add(this.imageBox);
            this.campaingBox.Controls.Add(this.endTimeText);
            this.campaingBox.Controls.Add(this.intervalText);
            this.campaingBox.Controls.Add(this.label6);
            this.campaingBox.Controls.Add(this.label3);
            this.campaingBox.Controls.Add(this.campaignNameText);
            this.campaingBox.Location = new System.Drawing.Point(12, 12);
            this.campaingBox.Name = "campaingBox";
            this.campaingBox.Size = new System.Drawing.Size(869, 278);
            this.campaingBox.TabIndex = 2;
            this.campaingBox.TabStop = false;
            this.campaingBox.Text = "Campaign Data";
            this.campaingBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // imageBox
            // 
            this.imageBox.Controls.Add(this.label1);
            this.imageBox.Controls.Add(this.dataGridViewImages);
            this.imageBox.Controls.Add(this.addPictureButton);
            this.imageBox.Location = new System.Drawing.Point(428, 33);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(425, 201);
            this.imageBox.TabIndex = 3;
            this.imageBox.TabStop = false;
            this.imageBox.Text = "Images Data";
            // 
            // dataGridViewImages
            // 
            this.dataGridViewImages.AllowUserToAddRows = false;
            this.dataGridViewImages.AllowUserToDeleteRows = false;
            this.dataGridViewImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Image});
            this.dataGridViewImages.Location = new System.Drawing.Point(6, 23);
            this.dataGridViewImages.Name = "dataGridViewImages";
            this.dataGridViewImages.ReadOnly = true;
            this.dataGridViewImages.Size = new System.Drawing.Size(413, 140);
            this.dataGridViewImages.TabIndex = 16;
            this.dataGridViewImages.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridViewImages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewImages_KeyPress);
            // 
            // ID
            // 
            this.ID.HeaderText = "Id";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Image
            // 
            this.Image.HeaderText = "Image";
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            this.Image.Width = 275;
            // 
            // addPictureButton
            // 
            this.addPictureButton.Location = new System.Drawing.Point(46, 169);
            this.addPictureButton.Name = "addPictureButton";
            this.addPictureButton.Size = new System.Drawing.Size(75, 23);
            this.addPictureButton.TabIndex = 14;
            this.addPictureButton.Text = "Add pictures";
            this.addPictureButton.UseVisualStyleBackColor = true;
            this.addPictureButton.Click += new System.EventHandler(this.addPictureButton_Click);
            // 
            // endTimeText
            // 
            this.endTimeText.Controls.Add(this.InitDateLabel);
            this.endTimeText.Controls.Add(this.endDateTimePicker);
            this.endTimeText.Controls.Add(this.initDateTimePicker);
            this.endTimeText.Controls.Add(this.EndDateLabel);
            this.endTimeText.Controls.Add(this.initTimeText);
            this.endTimeText.Controls.Add(this.textBox2);
            this.endTimeText.Controls.Add(this.EndTimeLabel);
            this.endTimeText.Controls.Add(this.InitTimeLabel);
            this.endTimeText.Location = new System.Drawing.Point(30, 93);
            this.endTimeText.Name = "endTimeText";
            this.endTimeText.Size = new System.Drawing.Size(355, 141);
            this.endTimeText.TabIndex = 16;
            this.endTimeText.TabStop = false;
            this.endTimeText.Text = "Date Data";
            // 
            // InitDateLabel
            // 
            this.InitDateLabel.AutoSize = true;
            this.InitDateLabel.Location = new System.Drawing.Point(41, 26);
            this.InitDateLabel.Name = "InitDateLabel";
            this.InitDateLabel.Size = new System.Drawing.Size(45, 13);
            this.InitDateLabel.TabIndex = 2;
            this.InitDateLabel.Text = "Init date";
            this.InitDateLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(36, 58);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(50, 13);
            this.EndDateLabel.TabIndex = 3;
            this.EndDateLabel.Text = "End date";
            // 
            // initTimeText
            // 
            this.initTimeText.Location = new System.Drawing.Point(101, 79);
            this.initTimeText.Name = "initTimeText";
            this.initTimeText.Size = new System.Drawing.Size(200, 20);
            this.initTimeText.TabIndex = 4;
            this.initTimeText.Text = "10:30";
            this.initTimeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(101, 106);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "11:30";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EndTimeLabel
            // 
            this.EndTimeLabel.AutoSize = true;
            this.EndTimeLabel.Location = new System.Drawing.Point(38, 109);
            this.EndTimeLabel.Name = "EndTimeLabel";
            this.EndTimeLabel.Size = new System.Drawing.Size(48, 13);
            this.EndTimeLabel.TabIndex = 9;
            this.EndTimeLabel.Text = "End time";
            // 
            // InitTimeLabel
            // 
            this.InitTimeLabel.AutoSize = true;
            this.InitTimeLabel.Location = new System.Drawing.Point(43, 82);
            this.InitTimeLabel.Name = "InitTimeLabel";
            this.InitTimeLabel.Size = new System.Drawing.Size(43, 13);
            this.InitTimeLabel.TabIndex = 8;
            this.InitTimeLabel.Text = "Init time";
            // 
            // intervalText
            // 
            this.intervalText.Location = new System.Drawing.Point(131, 68);
            this.intervalText.Name = "intervalText";
            this.intervalText.Size = new System.Drawing.Size(200, 20);
            this.intervalText.TabIndex = 11;
            this.intervalText.Text = "00:30";
            this.intervalText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Interval";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Name";
            // 
            // campaignNameText
            // 
            this.campaignNameText.Location = new System.Drawing.Point(131, 33);
            this.campaignNameText.Name = "campaignNameText";
            this.campaignNameText.Size = new System.Drawing.Size(200, 20);
            this.campaignNameText.TabIndex = 6;
            this.campaignNameText.Text = "Campaign Name";
            this.campaignNameText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(359, 317);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 3;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(596, 317);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "jpg";
            this.openFileDialog.FileName = "image";
            this.openFileDialog.Filter = "Imagenes PNG|*.png|Imagenes JPG|*.jpg";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "To delete images you must select the rows and press \'d\'";
            // 
            // CampaignView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 359);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.campaingBox);
            this.Name = "CampaignView";
            this.Text = "CampaignView";
            this.campaingBox.ResumeLayout(false);
            this.campaingBox.PerformLayout();
            this.imageBox.ResumeLayout(false);
            this.imageBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImages)).EndInit();
            this.endTimeText.ResumeLayout(false);
            this.endTimeText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker initDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.GroupBox campaingBox;
        private System.Windows.Forms.Label InitDateLabel;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.Label EndTimeLabel;
        private System.Windows.Forms.Label InitTimeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox campaignNameText;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox initTimeText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox intervalText;
        private System.Windows.Forms.GroupBox imageBox;
        private System.Windows.Forms.Button addPictureButton;
        private System.Windows.Forms.GroupBox endTimeText;
        private new System.Windows.Forms.Button AcceptButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.DataGridView dataGridViewImages;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.Label label1;
    }
}