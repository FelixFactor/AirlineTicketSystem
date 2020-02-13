using System.Windows.Forms;
using ClassLibrary;

namespace AdminPanel
{
    public partial class ShowPDF : Form
    {
        BookFlight Form;
        //Ticket Passenger;


        //TODO mudar o construtor para levar o passageiro para poder enviar emails
        public ShowPDF(BookFlight form, string filename, string path)
        {
            Form = form;
            
            InitializeComponent();
            
            string pathToOpen = SaveLoad.CreateDir(path);
            string fileToOpen = $"{pathToOpen}\\{filename}.pdf";

            foxitPDF.OpenFile(fileToOpen);
        }

        private void btnReturn_Click(object sender, System.EventArgs e)
        {
            this.Close();
            Form.BackToSearch();
        }
    }
}
