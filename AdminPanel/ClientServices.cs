using ClassLibrary;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
namespace AdminPanel
{
    public partial class ClientServices : Form
    {
        List<Flight> FlyHiFlights = new List<Flight>();
        
        FrontForm Form;
        public ClientServices(FrontForm form)
        {
            Form = form;
            InitializeComponent();
            
            FlyHiFlights = SaveLoad.LoadFlights();
            btnBooking.Visible = false;
            SearchFlight searchFlight = new SearchFlight(FlyHiFlights, this);
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
        //<<<<<<<<<<<<<<<<<<<<<<<< BUTTONS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void btnSearchFlight_Click(object sender, System.EventArgs e)
        {
            DialogResult answer = new DialogResult();
            answer = MessageBox.Show("If you leave this tab you will lose this search and all inputed data in this form!\nDo you want to continue?", "Alert - Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (answer == DialogResult.Yes)
            {
                SearchFlight search = new SearchFlight(FlyHiFlights, this);
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
    }
}
