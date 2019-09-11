using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace SendMEmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                // Pulling data from text boxes into MailMessage obj.
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("loki@informatel.com");
                msg.To.Add(txtTo.Text);
                msg.Subject = txtSubject.Text;
                msg.Body = txtBody.Text;

                // Creating smtp client
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "loki@informatel.com";
                ntcd.Password = "*********";
                smtp.Credentials = ntcd;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(msg);


                MessageBox.Show("Your email has been sent.");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
