namespace BoardApp.SecondaryForms
{
    partial class EmailForm
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
            this.btnAddEmail = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxEmails = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddEmail
            // 
            this.btnAddEmail.Location = new System.Drawing.Point(12, 43);
            this.btnAddEmail.Name = "btnAddEmail";
            this.btnAddEmail.Size = new System.Drawing.Size(92, 37);
            this.btnAddEmail.TabIndex = 0;
            this.btnAddEmail.Text = "Add Email";
            this.btnAddEmail.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "Send Mail";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(123, 52);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(175, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type Email:";
            // 
            // listBoxEmails
            // 
            this.listBoxEmails.FormattingEnabled = true;
            this.listBoxEmails.Location = new System.Drawing.Point(123, 103);
            this.listBoxEmails.Name = "listBoxEmails";
            this.listBoxEmails.Size = new System.Drawing.Size(175, 134);
            this.listBoxEmails.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Remove Email";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // EmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 265);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxEmails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAddEmail);
            this.Name = "EmailForm";
            this.Text = "EmailForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddEmail;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxEmails;
        private System.Windows.Forms.Button button1;
    }
}