namespace BoardApp
{
    partial class FullScreenForm
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
            this.pbFullScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFullScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFullScreen
            // 
            this.pbFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFullScreen.Location = new System.Drawing.Point(2, 2);
            this.pbFullScreen.Name = "pbFullScreen";
            this.pbFullScreen.Size = new System.Drawing.Size(759, 476);
            this.pbFullScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFullScreen.TabIndex = 0;
            this.pbFullScreen.TabStop = false;
            this.pbFullScreen.Click += new System.EventHandler(this.pbFullScreen_Click);
            // 
            // FullScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(760, 480);
            this.Controls.Add(this.pbFullScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FullScreenForm";
            this.ShowInTaskbar = false;
            this.Text = "FullScreenForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pbFullScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFullScreen;
    }
}