using System.Windows.Forms;

namespace TPFinal.View
{
    partial class TextBannerViewDelete
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
            this.bannerBox = new System.Windows.Forms.GroupBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.idText = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.GroupBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.textBanner = new System.Windows.Forms.TextBox();
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.bannerNameText = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.bannerBox.SuspendLayout();
            this.textBox.SuspendLayout();
            this.dateBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // bannerBox
            // 
            this.bannerBox.Controls.Add(this.searchButton);
            this.bannerBox.Controls.Add(this.okButton);
            this.bannerBox.Controls.Add(this.idText);
            this.bannerBox.Controls.Add(this.idLabel);
            this.bannerBox.Controls.Add(this.textBox);
            this.bannerBox.Controls.Add(this.dateBox);
            this.bannerBox.Controls.Add(this.nameLabel);
            this.bannerBox.Controls.Add(this.bannerNameText);
            this.bannerBox.Location = new System.Drawing.Point(12, 12);
            this.bannerBox.Name = "bannerBox";
            this.bannerBox.Size = new System.Drawing.Size(876, 299);
            this.bannerBox.TabIndex = 18;
            this.bannerBox.TabStop = false;
            this.bannerBox.Text = "Banner Data";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(271, 27);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(60, 20);
            this.searchButton.TabIndex = 25;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(222, 27);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(44, 20);
            this.okButton.TabIndex = 22;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // idText
            // 
            this.idText.Location = new System.Drawing.Point(131, 27);
            this.idText.Name = "idText";
            this.idText.Size = new System.Drawing.Size(85, 20);
            this.idText.TabIndex = 20;
            this.idText.Text = "Banner Id";
            this.idText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(109, 30);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(16, 13);
            this.idLabel.TabIndex = 19;
            this.idLabel.Text = "Id";
            // 
            // textBox
            // 
            this.textBox.Controls.Add(this.textLabel);
            this.textBox.Controls.Add(this.textBanner);
            this.textBox.Location = new System.Drawing.Point(417, 79);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(452, 136);
            this.textBox.TabIndex = 15;
            this.textBox.TabStop = false;
            this.textBox.Text = "Text Data";
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(29, 42);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(109, 13);
            this.textLabel.TabIndex = 1;
            this.textLabel.Text = "Text that will be show";
            // 
            // textBanner
            // 
            this.textBanner.Enabled = false;
            this.textBanner.Location = new System.Drawing.Point(18, 62);
            this.textBanner.Name = "textBanner";
            this.textBanner.Size = new System.Drawing.Size(408, 20);
            this.textBanner.TabIndex = 0;
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
            this.dateBox.Location = new System.Drawing.Point(42, 79);
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
            this.endTimeMinute.Enabled = false;
            this.endTimeMinute.Location = new System.Drawing.Point(216, 132);
            this.endTimeMinute.Name = "endTimeMinute";
            this.endTimeMinute.Size = new System.Drawing.Size(85, 20);
            this.endTimeMinute.TabIndex = 9;
            this.endTimeMinute.Text = "00";
            this.endTimeMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // initTimeMinute
            // 
            this.initTimeMinute.Enabled = false;
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
            this.endDateTimePicker.Enabled = false;
            this.endDateTimePicker.Location = new System.Drawing.Point(101, 52);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endDateTimePicker.TabIndex = 5;
            this.endDateTimePicker.Value = new System.DateTime(2017, 7, 22, 0, 0, 0, 0);
            // 
            // initDateTimePicker
            // 
            this.initDateTimePicker.Enabled = false;
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
            this.initTimeHour.Enabled = false;
            this.initTimeHour.Location = new System.Drawing.Point(101, 106);
            this.initTimeHour.Name = "initTimeHour";
            this.initTimeHour.Size = new System.Drawing.Size(85, 20);
            this.initTimeHour.TabIndex = 6;
            this.initTimeHour.Text = "13";
            this.initTimeHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // endTimeHour
            // 
            this.endTimeHour.Enabled = false;
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
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(90, 56);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 17;
            this.nameLabel.Text = "Name";
            // 
            // bannerNameText
            // 
            this.bannerNameText.Enabled = false;
            this.bannerNameText.Location = new System.Drawing.Point(131, 53);
            this.bannerNameText.Name = "bannerNameText";
            this.bannerNameText.Size = new System.Drawing.Size(200, 20);
            this.bannerNameText.TabIndex = 1;
            this.bannerNameText.Text = "Banner Name";
            this.bannerNameText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(550, 329);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 24;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(295, 329);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 23;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // TextBannerViewDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 373);
            this.Controls.Add(this.bannerBox);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.CancelButton);
            this.Name = "TextBannerViewDelete";
            this.Text = "TextBannerViewDelete";
            this.bannerBox.ResumeLayout(false);
            this.bannerBox.PerformLayout();
            this.textBox.ResumeLayout(false);
            this.textBox.PerformLayout();
            this.dateBox.ResumeLayout(false);
            this.dateBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox bannerBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button okButton;
        private new System.Windows.Forms.Button CancelButton;
        private new System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.TextBox idText;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.GroupBox textBox;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.TextBox textBanner;
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
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox bannerNameText;

        public Button CancelButton1
        {
            get
            {
                return CancelButton;
            }

            set
            {
                CancelButton = value;
            }
        }
    }
}