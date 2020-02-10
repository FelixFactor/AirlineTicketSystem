using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassLibrary;
using System.Drawing;
using System.IO;

namespace AdminPanel
{
    public partial class AdminForm : Form
    {
        
        List<Airport> Locations = SaveLoad.LoadAirports();
        List<Aircraft> Fleet = SaveLoad.LoadFleet();
        List<Flight> Flights = SaveLoad.LoadFlights();

        FrontForm Front = new FrontForm();
        public AdminForm(FrontForm front)
        {
            Front = front;
            InitializeComponent();

            FlightPanel flightPanel = new FlightPanel(Flights, Fleet, Locations);
            
            AddControls(flightPanel);
            btnFlight.BackColor = SystemColors.Control;
            btnFlight.Enabled = false;
            
        }
        //<<<<<<<<<<<<<<<< FUNCTIONS >>>>>>>>>>>>>>>>>
        private void AddControls(UserControl panels)
        {
            UserControl toAdd = panels;
            mainpanel.Controls.Clear();
            mainpanel.Controls.Add(toAdd);
        }
        //<<<<<<<<<<<<<<<<< BUTTONS >>>>>>>>>>>>>>>>>>>>>
        private void btnExit_Click(object sender, EventArgs e)
        {
            SaveLoad.SaveAirports(Locations);
            SaveLoad.SaveFleet(Fleet);
            SaveLoad.SaveFlights(Flights);
            this.Close();
        }
        private void btnFlight_Click_1(object sender, EventArgs e)
        {
            FlightPanel flightPanel = new FlightPanel(Flights, Fleet, Locations);
            AddControls(flightPanel);
            btnFlight.BackColor = SystemColors.Control;
            btnAirport.BackColor = Color.SteelBlue;
            btnFleet.BackColor = Color.SteelBlue;
            btnFlight.Enabled = false;
            btnFleet.Enabled = true;
            btnAirport.Enabled = true;
        }
        private void btnFleet_Click(object sender, EventArgs e)
        {
            FleetPanel fleetPanel = new FleetPanel(Fleet, Flights);
            AddControls(fleetPanel);
            btnFlight.BackColor = Color.SteelBlue;
            btnAirport.BackColor = Color.SteelBlue;
            btnFleet.BackColor = SystemColors.Control;
            btnFlight.Enabled = true;
            btnFleet.Enabled = false;
            btnAirport.Enabled = true;
        }
        private void btnAirport_Click(object sender, EventArgs e)
        {
            AirportPanel portPanel = new AirportPanel(Locations, Flights);
            AddControls(portPanel);
            btnFlight.BackColor = Color.SteelBlue;
            btnFleet.BackColor = Color.SteelBlue;
            btnAirport.BackColor = SystemColors.Control;
            btnFlight.Enabled = true;
            btnFleet.Enabled = true;
            btnAirport.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveLoad.SaveAirports(Locations);
            SaveLoad.SaveFleet(Fleet);
            SaveLoad.SaveFlights(Flights);
        }
        //<<<<<<<<<<<<<<<< EVENTS >>>>>>>>>>>>>>>>>>>>
        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            ToolTip exit = new ToolTip();
            exit.SetToolTip(btnExit,"Saves & Returns to Front Menu");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Front.Visible = true;
        }
    }
}
