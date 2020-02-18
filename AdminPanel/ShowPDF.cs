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

            foxitPDF.OpenFile(fileToOpen);
        }

        private void btnReturn_Click(object sender, System.EventArgs e)
        {
            this.Close();
            Form.BackToSearch();
        }

        private void btnSendEmail_Click(object sender, System.EventArgs e)
        {
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();

            m.From = new MailAddress("");
            m.To.Add(new MailAddress(ticket.Email));
            m.Subject = "Your Boarding Pass";
            //m.IsBodyHtml = true;
            m.Body = "Welcome aboard.\nInside you find your boarding pass with all information you need for your flight.\n\nThank you for flying with Fly Hi.";
            m.Attachments.Add(new Attachment(fileToOpen));

            sc.Host = "smtp.office365.com";
            sc.Port = 587;
            sc.Credentials = new System.Net.NetworkCredential("", "");

            sc.EnableSsl = true;
            sc.Send(m);

            MessageBox.Show($"Email sent to {ticket.Email}.");
        }
    }
}
