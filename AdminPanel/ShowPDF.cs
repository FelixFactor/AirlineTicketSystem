using System;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using ClassLibrary;

namespace AdminPanel
{
    public partial class ShowPDF : Form
    {
        BookFlight Form;
        Passenger ticket;
        string pathToOpen;
        string fileToOpen;

        
        public ShowPDF(BookFlight form, string path, Passenger passenger)
        {
            Form = form;
            ticket = passenger;

            InitializeComponent();
            
            pathToOpen = SaveLoad.CreateDir(path);
            fileToOpen = $"{pathToOpen}\\{ticket.InternPersonId}.pdf";
        }

        private void btnReturn_Click(object sender, System.EventArgs e)
        {
            this.Close();
            Form.BackToSearch();
        }

        private void btnSendEmail_Click(object sender, System.EventArgs e)
        {
            try
            {
                string[] network = GetAuthentication();

                MailMessage m = new MailMessage();
                SmtpClient sc = new SmtpClient();

                m.From = new MailAddress($"{network[0]}");
                m.To.Add(new MailAddress(ticket.Email));
                m.Subject = "Your Boarding Pass";
                m.Body = "Welcome aboard.\nInside you find your boarding pass with all information you need for your flight.\n\nThank you for flying with Fly Hi.";
                m.Attachments.Add(new Attachment(fileToOpen));

                sc.Host = "smtp.office365.com";
                sc.Port = 587;
                sc.Credentials = new System.Net.NetworkCredential($"{network[0]}", $"{network[1]}");

                sc.EnableSsl = true;
                sc.Send(m);

                MessageBox.Show($"Email sent to {ticket.Email}.");
            }
            catch (SmtpFailedRecipientException)
            {
                MessageBox.Show("A problem has occurred when sending the email. \nPlease verify the email and contact the administrator");
            }
        }
        /// <summary>
        /// gets from a file the authentication
        /// </summary>
        /// <returns>the authentication for the email sender</returns>
        private string[] GetAuthentication()
        {
            string[] network = new string[2];
            string path = SaveLoad.PathToTemplates;
            string file = $"{path}\\network.txt";
            StreamReader reader = new StreamReader(file);
            string line = reader.ReadLine();

            network = line.Split(',');
            return network;
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            
        }
    }
}
