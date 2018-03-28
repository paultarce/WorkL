namespace TPBDApp.SecondaryForms
{
    partial class LoginForm
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
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAutentificare = new System.Windows.Forms.Button();
            this.btnIesire = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(134, 66);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(153, 20);
            this.txtPass.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Parola";
            // 
            // btnAutentificare
            // 
            this.btnAutentificare.Location = new System.Drawing.Point(134, 115);
            this.btnAutentificare.Name = "btnAutentificare";
            this.btnAutentificare.Size = new System.Drawing.Size(75, 23);
            this.btnAutentificare.TabIndex = 2;
            this.btnAutentificare.Text = "Autentificare";
            this.btnAutentificare.UseVisualStyleBackColor = true;
            this.btnAutentificare.Click += new System.EventHandler(this.btnAutentificare_Click);
            // 
            // btnIesire
            // 
            this.btnIesire.Location = new System.Drawing.Point(215, 115);
            this.btnIesire.Name = "btnIesire";
            this.btnIesire.Size = new System.Drawing.Size(75, 23);
            this.btnIesire.TabIndex = 3;
            this.btnIesire.Text = "Iesire";
            this.btnIesire.UseVisualStyleBackColor = true;
            this.btnIesire.Click += new System.EventHandler(this.btnIesire_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 207);
            this.Controls.Add(this.btnIesire);
            this.Controls.Add(this.btnAutentificare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPass);
            this.Name = "LoginForm";
            this.Text = "Autentificare";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAutentificare;
        private System.Windows.Forms.Button btnIesire;
    }
}