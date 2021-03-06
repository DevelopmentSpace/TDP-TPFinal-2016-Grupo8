﻿namespace TPFinal.View
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
            this.campaingBox = new System.Windows.Forms.GroupBox();
            this.secondIntervalLabel = new System.Windows.Forms.Label();
            this.intervalSecond = new System.Windows.Forms.TextBox();
            this.minuteIntervalLabel = new System.Windows.Forms.Label();
            this.imageBox = new System.Windows.Forms.GroupBox();
            this.hintLabel = new System.Windows.Forms.Label();
            this.addButtonImage = new System.Windows.Forms.Button();
            this.dataGridViewImages = new System.Windows.Forms.DataGridView();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.dateBox = new System.Windows.Forms.GroupBox();
            this.minuteLabel = new System.Windows.Forms.Label();
            this.hourLabel = new System.Windows.Forms.Label();
            this.endTimeMinute = new System.Windows.Forms.TextBox();
            this.initTimeMinute = new System.Windows.Forms.TextBox();
            this.InitDateLabel = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.initDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.initTimeHour = new System.Windows.Forms.TextBox();
            this.endTimeHour = new System.Windows.Forms.TextBox();
            this.EndTimeLabel = new System.Windows.Forms.Label();
            this.InitTimeLabel = new System.Windows.Forms.Label();
            this.intervalMinute = new System.Windows.Forms.TextBox();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.campaignNameText = new System.Windows.Forms.TextBox();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.campaingBox.SuspendLayout();
            this.imageBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImages)).BeginInit();
            this.dateBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // campaingBox
            // 
            this.campaingBox.Controls.Add(this.secondIntervalLabel);
            this.campaingBox.Controls.Add(this.intervalSecond);
            this.campaingBox.Controls.Add(this.minuteIntervalLabel);
            this.campaingBox.Controls.Add(this.imageBox);
            this.campaingBox.Controls.Add(this.dateBox);
            this.campaingBox.Controls.Add(this.intervalMinute);
            this.campaingBox.Controls.Add(this.intervalLabel);
            this.campaingBox.Controls.Add(this.nameLabel);
            this.campaingBox.Controls.Add(this.campaignNameText);
            this.campaingBox.Location = new System.Drawing.Point(12, 12);
            this.campaingBox.Name = "campaingBox";
            this.campaingBox.Size = new System.Drawing.Size(869, 299);
            this.campaingBox.TabIndex = 15;
            this.campaingBox.TabStop = false;
            this.campaingBox.Text = "Campaign Data";
            // 
            // secondIntervalLabel
            // 
            this.secondIntervalLabel.AutoSize = true;
            this.secondIntervalLabel.Location = new System.Drawing.Point(268, 77);
            this.secondIntervalLabel.Name = "secondIntervalLabel";
            this.secondIntervalLabel.Size = new System.Drawing.Size(44, 13);
            this.secondIntervalLabel.TabIndex = 15;
            this.secondIntervalLabel.Text = "Second";
            // 
            // intervalSecond
            // 
            this.intervalSecond.Location = new System.Drawing.Point(246, 92);
            this.intervalSecond.Name = "intervalSecond";
            this.intervalSecond.Size = new System.Drawing.Size(85, 20);
            this.intervalSecond.TabIndex = 3;
            this.intervalSecond.Text = "30";
            this.intervalSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minuteIntervalLabel
            // 
            this.minuteIntervalLabel.AutoSize = true;
            this.minuteIntervalLabel.Location = new System.Drawing.Point(152, 76);
            this.minuteIntervalLabel.Name = "minuteIntervalLabel";
            this.minuteIntervalLabel.Size = new System.Drawing.Size(39, 13);
            this.minuteIntervalLabel.TabIndex = 14;
            this.minuteIntervalLabel.Text = "Minute";
            // 
            // imageBox
            // 
            this.imageBox.Controls.Add(this.hintLabel);
            this.imageBox.Controls.Add(this.addButtonImage);
            this.imageBox.Controls.Add(this.dataGridViewImages);
            this.imageBox.Location = new System.Drawing.Point(411, 33);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(452, 260);
            this.imageBox.TabIndex = 15;
            this.imageBox.TabStop = false;
            this.imageBox.Text = "Images Data";
            // 
            // hintLabel
            // 
            this.hintLabel.AutoSize = true;
            this.hintLabel.Location = new System.Drawing.Point(104, 227);
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(269, 13);
            this.hintLabel.TabIndex = 24;
            this.hintLabel.Text = "To delete images you must select the rows and press \'d\'";
            // 
            // addButtonImage
            // 
            this.addButtonImage.Location = new System.Drawing.Point(23, 220);
            this.addButtonImage.Name = "addButtonImage";
            this.addButtonImage.Size = new System.Drawing.Size(75, 23);
            this.addButtonImage.TabIndex = 11;
            this.addButtonImage.Text = "Add image";
            this.addButtonImage.UseVisualStyleBackColor = true;
            this.addButtonImage.Click += new System.EventHandler(this.addButtonImage_Click);
            // 
            // dataGridViewImages
            // 
            this.dataGridViewImages.AllowUserToAddRows = false;
            this.dataGridViewImages.AllowUserToDeleteRows = false;
            this.dataGridViewImages.AllowUserToResizeColumns = false;
            this.dataGridViewImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Image});
            this.dataGridViewImages.Location = new System.Drawing.Point(6, 23);
            this.dataGridViewImages.Name = "dataGridViewImages";
            this.dataGridViewImages.ReadOnly = true;
            this.dataGridViewImages.RowTemplate.Height = 150;
            this.dataGridViewImages.Size = new System.Drawing.Size(440, 191);
            this.dataGridViewImages.TabIndex = 10;
            this.dataGridViewImages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewImages_KeyPress);
            // 
            // Image
            // 
            this.Image.HeaderText = "Image";
            this.Image.MinimumWidth = 10;
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            this.Image.Width = 370;
            // 
            // dateBox
            // 
            this.dateBox.Controls.Add(this.minuteLabel);
            this.dateBox.Controls.Add(this.hourLabel);
            this.dateBox.Controls.Add(this.endTimeMinute);
            this.dateBox.Controls.Add(this.initTimeMinute);
            this.dateBox.Controls.Add(this.InitDateLabel);
            this.dateBox.Controls.Add(this.endDateTimePicker);
            this.dateBox.Controls.Add(this.initDateTimePicker);
            this.dateBox.Controls.Add(this.EndDateLabel);
            this.dateBox.Controls.Add(this.initTimeHour);
            this.dateBox.Controls.Add(this.endTimeHour);
            this.dateBox.Controls.Add(this.EndTimeLabel);
            this.dateBox.Controls.Add(this.InitTimeLabel);
            this.dateBox.Location = new System.Drawing.Point(30, 124);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(363, 169);
            this.dateBox.TabIndex = 16;
            this.dateBox.TabStop = false;
            this.dateBox.Text = "Date information";
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
            this.endTimeMinute.TabIndex = 9;
            this.endTimeMinute.Text = "00";
            this.endTimeMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // initTimeMinute
            // 
            this.initTimeMinute.Location = new System.Drawing.Point(216, 106);
            this.initTimeMinute.Name = "initTimeMinute";
            this.initTimeMinute.Size = new System.Drawing.Size(85, 20);
            this.initTimeMinute.TabIndex = 7;
            this.initTimeMinute.Text = "45";
            this.initTimeMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // InitDateLabel
            // 
            this.InitDateLabel.AutoSize = true;
            this.InitDateLabel.Location = new System.Drawing.Point(50, 32);
            this.InitDateLabel.Name = "InitDateLabel";
            this.InitDateLabel.Size = new System.Drawing.Size(45, 13);
            this.InitDateLabel.TabIndex = 19;
            this.InitDateLabel.Text = "Init date";
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(101, 52);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endDateTimePicker.TabIndex = 5;
            this.endDateTimePicker.Value = new System.DateTime(2017, 7, 22, 0, 0, 0, 0);
            // 
            // initDateTimePicker
            // 
            this.initDateTimePicker.Location = new System.Drawing.Point(101, 26);
            this.initDateTimePicker.Name = "initDateTimePicker";
            this.initDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.initDateTimePicker.TabIndex = 4;
            this.initDateTimePicker.Value = new System.DateTime(2017, 7, 15, 0, 0, 0, 0);
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(45, 58);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(50, 13);
            this.EndDateLabel.TabIndex = 20;
            this.EndDateLabel.Text = "End date";
            // 
            // initTimeHour
            // 
            this.initTimeHour.Location = new System.Drawing.Point(101, 106);
            this.initTimeHour.Name = "initTimeHour";
            this.initTimeHour.Size = new System.Drawing.Size(85, 20);
            this.initTimeHour.TabIndex = 6;
            this.initTimeHour.Text = "13";
            this.initTimeHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // endTimeHour
            // 
            this.endTimeHour.Location = new System.Drawing.Point(101, 133);
            this.endTimeHour.Name = "endTimeHour";
            this.endTimeHour.Size = new System.Drawing.Size(85, 20);
            this.endTimeHour.TabIndex = 8;
            this.endTimeHour.Text = "14";
            this.endTimeHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EndTimeLabel
            // 
            this.EndTimeLabel.AutoSize = true;
            this.EndTimeLabel.Location = new System.Drawing.Point(47, 136);
            this.EndTimeLabel.Name = "EndTimeLabel";
            this.EndTimeLabel.Size = new System.Drawing.Size(48, 13);
            this.EndTimeLabel.TabIndex = 22;
            this.EndTimeLabel.Text = "End time";
            // 
            // InitTimeLabel
            // 
            this.InitTimeLabel.AutoSize = true;
            this.InitTimeLabel.Location = new System.Drawing.Point(52, 109);
            this.InitTimeLabel.Name = "InitTimeLabel";
            this.InitTimeLabel.Size = new System.Drawing.Size(43, 13);
            this.InitTimeLabel.TabIndex = 21;
            this.InitTimeLabel.Text = "Init time";
            // 
            // intervalMinute
            // 
            this.intervalMinute.Location = new System.Drawing.Point(131, 92);
            this.intervalMinute.Name = "intervalMinute";
            this.intervalMinute.Size = new System.Drawing.Size(85, 20);
            this.intervalMinute.TabIndex = 2;
            this.intervalMinute.Text = "0";
            this.intervalMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(6, 95);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(122, 13);
            this.intervalLabel.TabIndex = 18;
            this.intervalLabel.Text = "Interval between images";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(90, 56);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 17;
            this.nameLabel.Text = "Name";
            // 
            // campaignNameText
            // 
            this.campaignNameText.Location = new System.Drawing.Point(131, 53);
            this.campaignNameText.Name = "campaignNameText";
            this.campaignNameText.Size = new System.Drawing.Size(200, 20);
            this.campaignNameText.TabIndex = 1;
            this.campaignNameText.Text = "Campaign Name";
            this.campaignNameText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(307, 317);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 16;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(544, 317);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 17;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Imagenes JPG |*.jpg| Images PNG |*.png";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // CampaignView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 367);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.campaingBox);
            this.Name = "CampaignView";
            this.Text = "Campaign administration";
            this.campaingBox.ResumeLayout(false);
            this.campaingBox.PerformLayout();
            this.imageBox.ResumeLayout(false);
            this.imageBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImages)).EndInit();
            this.dateBox.ResumeLayout(false);
            this.dateBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox campaingBox;
        private System.Windows.Forms.Label secondIntervalLabel;
        private System.Windows.Forms.TextBox intervalSecond;
        private System.Windows.Forms.Label minuteIntervalLabel;
        private System.Windows.Forms.GroupBox imageBox;
        private System.Windows.Forms.DataGridView dataGridViewImages;
        private System.Windows.Forms.GroupBox dateBox;
        private System.Windows.Forms.Label minuteLabel;
        private System.Windows.Forms.Label hourLabel;
        private System.Windows.Forms.TextBox endTimeMinute;
        private System.Windows.Forms.TextBox initTimeMinute;
        private System.Windows.Forms.Label InitDateLabel;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.DateTimePicker initDateTimePicker;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.TextBox initTimeHour;
        private System.Windows.Forms.TextBox endTimeHour;
        private System.Windows.Forms.Label EndTimeLabel;
        private System.Windows.Forms.Label InitTimeLabel;
        private System.Windows.Forms.TextBox intervalMinute;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox campaignNameText;
        private new System.Windows.Forms.Button AcceptButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button addButtonImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label hintLabel;
        private System.Windows.Forms.DataGridViewImageColumn Image;
    }
}