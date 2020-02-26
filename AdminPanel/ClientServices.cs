using ClassLibrary;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
namespace AdminPanel
{
    public partial class ClientServices : Form
    {
        List<Flight> FlightsToBook;
        
        FrontForm Form;
        public ClientServices(FrontForm form)
        {
            FlightsToBook = SaveLoad.LoadFlights();
            Form = form;
            InitializeComponent();
            
            btnBooking.Visible = false;
            SearchFlight searchFlight = new SearchFlight(FlightsToBook, this);
            AddControls(searchFlight);
            btnSearchFlight.BackColor = SystemColors.Control;
            btnSearchFlight.Enabled = false;
        }
        //<<<<<<<<<<<<<<<<<<<<<<<< FUNCTIONS >>>>>>>>>>>>>>>>>>>>>>>>>>>
        public void GoToBooking()
        {
            btnBooking.Visible = true;
            btnBooking.BackColor = SystemColors.Control;
            btnSearchFlight.BackColor = Color.SteelBlue;
            btnSearchFlight.Enabled = true;
        }
        public void AddControls(UserControl panels)
        {
            UserControl toAdd = panels;
            panelmain.Controls.Clear();
            panelmain.Controls.Add(toAdd);
        }
        public void BackToSearch()
        {
            btnSearchFlight.BackColor = SystemColors.Control;
            btnSearchFlight.Enabled = false;
            btnBooking.Visible = false;
            SearchFlight searchFlight = new SearchFlight(FlightsToBook, this);
            AddControls(searchFlight);
        }
        //<<<<<<<<<<<<<<<<<<<<<<<< BUTTONS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void btnExit_Click(object sender, System.EventArgs e)
        {
            SaveLoad.SaveFlights(FlightsToBook);
            this.Close();
        }
        private void btnSearchFlight_Click(object sender, System.EventArgs e)
        {
            DialogResult answer = MessageBox.Show("If you leave this tab you will lose this search and all inputed data in this form!\nDo you want to continue?", "Alert - Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (answer == DialogResult.Yes)
            {
                SearchFlight search = new SearchFlight(FlightsToBook, this);
                AddControls(search);
                btnBooking.Visible = false;
                btnSearchFlight.BackColor = SystemColors.Control;
            }
        }
        //<<<<<<<<<<<<<<<<<<<<<<<<<< EVENTS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void ClientServices_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form.Visible = true;
        }
        private void btnExit_MouseHover(object sender, System.EventArgs e)
        {
            ToolTip exit = new ToolTip();
            exit.SetToolTip(btnExit, "Returns to Main");
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SaveLoad.SaveFlights(FlightsToBook);
        }
    }
}
