namespace TPFinal
{
    partial class Application
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.adminMenu = new System.Windows.Forms.Button();
            this.adButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // adminMenu
            // 
            this.adminMenu.Location = new System.Drawing.Point(26, 112);
            this.adminMenu.Name = "adminMenu";
            this.adminMenu.Size = new System.Drawing.Size(99, 23);
            this.adminMenu.TabIndex = 0;
            this.adminMenu.Text = "Add Campaign";
            this.adminMenu.UseVisualStyleBackColor = true;
            this.adminMenu.Click += new System.EventHandler(this.button1_Click);
            // 
            // adButton
            // 
            this.adButton.Location = new System.Drawing.Point(172, 112);
            this.adButton.Name = "adButton";
            this.adButton.Size = new System.Drawing.Size(75, 23);
            this.adButton.TabIndex = 1;
            this.adButton.Text = "Ad view";
            this.adButton.UseVisualStyleBackColor = true;
            this.adButton.Click += new System.EventHandler(this.adButton_Click);
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.adButton);
            this.Controls.Add(this.adminMenu);
            this.Name = "Application";
            this.Text = "Ad aplication";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button adminMenu;
        private System.Windows.Forms.Button adButton;
    }
}

