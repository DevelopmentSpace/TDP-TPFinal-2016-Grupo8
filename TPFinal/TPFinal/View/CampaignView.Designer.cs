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
            this.secondIntervalLabel = new System.Windows.Forms.Label();
            this.intervalSecond = new System.Windows.Forms.TextBox();
            this.minuteIntervalLabel = new System.Windows.Forms.Label();
            this.imageBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewImages = new System.Windows.Forms.DataGridView();
            this.addImageButton = new System.Windows.Forms.Button();
            this.endTimeText = new System.Windows.Forms.GroupBox();
            this.minuteLabel = new System.Windows.Forms.Label();
            this.hourLabel = new System.Windows.Forms.Label();
            this.endTimeMinute = new System.Windows.Forms.TextBox();
            this.initTimeMinute = new System.Windows.Forms.TextBox();
            this.InitDateLabel = new System.Windows.Forms.Label();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.initTimeHour = new System.Windows.Forms.TextBox();
            this.endTimeHour = new System.Windows.Forms.TextBox();
            this.EndTimeLabel = new System.Windows.Forms.Label();
            this.InitTimeLabel = new System.Windows.Forms.Label();
            this.intervalMinute = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.campaignNameText = new System.Windows.Forms.TextBox();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
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
            this.campaingBox.Controls.Add(this.secondIntervalLabel);
            this.campaingBox.Controls.Add(this.intervalSecond);
            this.campaingBox.Controls.Add(this.minuteIntervalLabel);
            this.campaingBox.Controls.Add(this.imageBox);
            this.campaingBox.Controls.Add(this.endTimeText);
            this.campaingBox.Controls.Add(this.intervalMinute);
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
            // secondIntervalLabel
            // 
            this.secondIntervalLabel.AutoSize = true;
            this.secondIntervalLabel.Location = new System.Drawing.Point(268, 53);
            this.secondIntervalLabel.Name = "secondIntervalLabel";
            this.secondIntervalLabel.Size = new System.Drawing.Size(44, 13);
            this.secondIntervalLabel.TabIndex = 15;
            this.secondIntervalLabel.Text = "Second";
            // 
            // intervalSecond
            // 
            this.intervalSecond.Location = new System.Drawing.Point(246, 68);
            this.intervalSecond.Name = "intervalSecond";
            this.intervalSecond.Size = new System.Drawing.Size(85, 20);
            this.intervalSecond.TabIndex = 17;
            this.intervalSecond.Text = "30";
            this.intervalSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minuteIntervalLabel
            // 
            this.minuteIntervalLabel.AutoSize = true;
            this.minuteIntervalLabel.Location = new System.Drawing.Point(152, 52);
            this.minuteIntervalLabel.Name = "minuteIntervalLabel";
            this.minuteIntervalLabel.Size = new System.Drawing.Size(39, 13);
            this.minuteIntervalLabel.TabIndex = 14;
            this.minuteIntervalLabel.Text = "Minute";
            // 
            // imageBox
            // 
            this.imageBox.Controls.Add(this.label1);
            this.imageBox.Controls.Add(this.dataGridViewImages);
            this.imageBox.Controls.Add(this.addImageButton);
            this.imageBox.Location = new System.Drawing.Point(411, 33);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(452, 229);
            this.imageBox.TabIndex = 3;
            this.imageBox.TabStop = false;
            this.imageBox.Text = "Images Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "To delete images you must select the rows and press \'d\'";
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
            this.dataGridViewImages.Size = new System.Drawing.Size(440, 140);
            this.dataGridViewImages.TabIndex = 16;
            this.dataGridViewImages.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridViewImages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewImages_KeyPress);
            // 
            // addImageButton
            // 
            this.addImageButton.Location = new System.Drawing.Point(45, 186);
            this.addImageButton.Name = "addImageButton";
            this.addImageButton.Size = new System.Drawing.Size(75, 23);
            this.addImageButton.TabIndex = 14;
            this.addImageButton.Text = "Add images";
            this.addImageButton.UseVisualStyleBackColor = true;
            this.addImageButton.Click += new System.EventHandler(this.addPictureButton_Click);
            // 
            // endTimeText
            // 
            this.endTimeText.Controls.Add(this.minuteLabel);
            this.endTimeText.Controls.Add(this.hourLabel);
            this.endTimeText.Controls.Add(this.endTimeMinute);
            this.endTimeText.Controls.Add(this.initTimeMinute);
            this.endTimeText.Controls.Add(this.InitDateLabel);
            this.endTimeText.Controls.Add(this.endDateTimePicker);
            this.endTimeText.Controls.Add(this.initDateTimePicker);
            this.endTimeText.Controls.Add(this.EndDateLabel);
            this.endTimeText.Controls.Add(this.initTimeHour);
            this.endTimeText.Controls.Add(this.endTimeHour);
            this.endTimeText.Controls.Add(this.EndTimeLabel);
            this.endTimeText.Controls.Add(this.InitTimeLabel);
            this.endTimeText.Location = new System.Drawing.Point(30, 93);
            this.endTimeText.Name = "endTimeText";
            this.endTimeText.Size = new System.Drawing.Size(363, 169);
            this.endTimeText.TabIndex = 16;
            this.endTimeText.TabStop = false;
            this.endTimeText.Text = "Date Data";
            // 
            // minuteLabel
            // 
            this.minuteLabel.AutoSize = true;
            this.minuteLabel.Location = new System.Drawing.Point(238, 90);
            this.minuteLabel.Name = "minuteLabel";
            this.minuteLabel.Size = new System.Drawing.Size(39, 13);
            this.minuteLabel.TabIndex = 13;
            this.minuteLabel.Text = "Minute";
            // 
            // hourLabel
            // 
            this.hourLabel.AutoSize = true;
            this.hourLabel.Location = new System.Drawing.Point(131, 90);
            this.hourLabel.Name = "hourLabel";
            this.hourLabel.Size = new System.Drawing.Size(30, 13);
            this.hourLabel.TabIndex = 12;
            this.hourLabel.Text = "Hour";
            // 
            // endTimeMinute
            // 
            this.endTimeMinute.Location = new System.Drawing.Point(216, 132);
            this.endTimeMinute.Name = "endTimeMinute";
            this.endTimeMinute.Size = new System.Drawing.Size(85, 20);
            this.endTimeMinute.TabIndex = 11;
            this.endTimeMinute.Text = "00";
            this.endTimeMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // initTimeMinute
            // 
            this.initTimeMinute.Location = new System.Drawing.Point(216, 106);
            this.initTimeMinute.Name = "initTimeMinute";
            this.initTimeMinute.Size = new System.Drawing.Size(85, 20);
            this.initTimeMinute.TabIndex = 10;
            this.initTimeMinute.Text = "45";
            this.initTimeMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // initTimeHour
            // 
            this.initTimeHour.Location = new System.Drawing.Point(101, 106);
            this.initTimeHour.Name = "initTimeHour";
            this.initTimeHour.Size = new System.Drawing.Size(85, 20);
            this.initTimeHour.TabIndex = 4;
            this.initTimeHour.Text = "13";
            this.initTimeHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // endTimeHour
            // 
            this.endTimeHour.Location = new System.Drawing.Point(101, 133);
            this.endTimeHour.Name = "endTimeHour";
            this.endTimeHour.Size = new System.Drawing.Size(85, 20);
            this.endTimeHour.TabIndex = 5;
            this.endTimeHour.Text = "14";
            this.endTimeHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EndTimeLabel
            // 
            this.EndTimeLabel.AutoSize = true;
            this.EndTimeLabel.Location = new System.Drawing.Point(38, 136);
            this.EndTimeLabel.Name = "EndTimeLabel";
            this.EndTimeLabel.Size = new System.Drawing.Size(48, 13);
            this.EndTimeLabel.TabIndex = 9;
            this.EndTimeLabel.Text = "End time";
            // 
            // InitTimeLabel
            // 
            this.InitTimeLabel.AutoSize = true;
            this.InitTimeLabel.Location = new System.Drawing.Point(43, 109);
            this.InitTimeLabel.Name = "InitTimeLabel";
            this.InitTimeLabel.Size = new System.Drawing.Size(43, 13);
            this.InitTimeLabel.TabIndex = 8;
            this.InitTimeLabel.Text = "Init time";
            // 
            // intervalMinute
            // 
            this.intervalMinute.Location = new System.Drawing.Point(131, 68);
            this.intervalMinute.Name = "intervalMinute";
            this.intervalMinute.Size = new System.Drawing.Size(85, 20);
            this.intervalMinute.TabIndex = 11;
            this.intervalMinute.Text = "0";
            this.intervalMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Interval between images";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Name";
            // 
            // campaignNameText
            // 
            this.campaignNameText.Location = new System.Drawing.Point(131, 29);
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
            // ID
            // 
            this.ID.HeaderText = "Id";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 25;
            // 
            // Image
            // 
            this.Image.HeaderText = "Image";
            this.Image.MinimumWidth = 10;
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            this.Image.Width = 350;
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
        private System.Windows.Forms.TextBox endTimeHour;
        private System.Windows.Forms.TextBox initTimeHour;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox intervalMinute;
        private System.Windows.Forms.GroupBox imageBox;
        private System.Windows.Forms.Button addImageButton;
        private System.Windows.Forms.GroupBox endTimeText;
        private new System.Windows.Forms.Button AcceptButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.DataGridView dataGridViewImages;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox endTimeMinute;
        private System.Windows.Forms.TextBox initTimeMinute;
        private System.Windows.Forms.Label minuteLabel;
        private System.Windows.Forms.Label hourLabel;
        private System.Windows.Forms.TextBox intervalSecond;
        private System.Windows.Forms.Label secondIntervalLabel;
        private System.Windows.Forms.Label minuteIntervalLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewImageColumn Image;
    }
}