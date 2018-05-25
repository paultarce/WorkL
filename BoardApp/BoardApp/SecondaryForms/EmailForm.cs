using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BoardApp.SecondaryForms
{
    public partial class EmailForm : Form
    {

        public string url;
        public EmailForm(string url)
        {
            InitializeComponent();
            this.url = url;
        }

       

        private void btnAddEmail_Click(object sender, EventArgs e)
        {
            int k = 0;
            foreach(var email in listBoxEmails.Items)
            {
                if(txtEmail.Text.Equals(email.ToString()))
                {
                    k = 1;
                }
            }
            if (k != 1)
            {
                listBoxEmails.Items.Add(txtEmail.Text);
            }
            else
            {
                MessageBox.Show("The email already exists");
            }
        }

        private void btnRemoveEmail_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBoxEmails);
            selectedItems = listBoxEmails.SelectedItems;

            if (listBoxEmails.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBoxEmails.Items.Remove(selectedItems[i]);
            }
            else
                MessageBox.Show("Select one Email");
        } 

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.UseDefaultCredentials = false;
                mail.From = new MailAddress(txtSenderEmail.Text);
                mail.To.Add("paul95_tarce@yahoo.com");
                mail.Subject = "Test Mail - 1";
                mail.Body = "mail with attachment";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(url);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(txtSenderEmail.Text, txtSenderPassword.Text);
                SmtpServer.EnableSsl = true;
                mail.IsBodyHtml = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Sent");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void EmailForm_Load(object sender, EventArgs e)
        {

        }
    }
}
