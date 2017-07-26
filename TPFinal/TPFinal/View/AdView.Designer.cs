namespace TPFinal.View
{
    partial class AdView
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
            this.components = new System.ComponentModel.Container();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.textBanner = new System.Windows.Forms.TextBox();
            this.moveTextTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(12, 12);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(725, 376);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox.TabIndex = 0;
            this.imageBox.TabStop = false;
            // 
            // textBanner
            // 
            this.textBanner.Enabled = false;
            this.textBanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBanner.HideSelection = false;
            this.textBanner.Location = new System.Drawing.Point(12, 394);
            this.textBanner.Name = "textBanner";
            this.textBanner.Size = new System.Drawing.Size(725, 22);
            this.textBanner.TabIndex = 1;
            this.textBanner.Text = "                                                                                 " +
    "                                                                                " +
    "                           a";
            // 
            // moveTextTimer
            // 
            this.moveTextTimer.Tick += new System.EventHandler(this.moveTextTimer_Tick);
            // 
            // AdView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 426);
            this.Controls.Add(this.textBanner);
            this.Controls.Add(this.imageBox);
            this.Name = "AdView";
            this.Text = "\r\nAd viewer";
            this.Load += new System.EventHandler(this.AdView_Load);
            this.Leave += new System.EventHandler(this.AdView_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.TextBox textBanner;
        private System.Windows.Forms.Timer moveTextTimer;
    }
}