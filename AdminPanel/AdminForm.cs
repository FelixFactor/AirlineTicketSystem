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
        //lists are instanced because of 1st use <<<let it be>>>
        List<Airport> Locations = new List<Airport>();
        List<Aircraft> Fleet = new List<Aircraft>();
        List<Flight> Flights = new List<Flight>();

        FrontForm Front = new FrontForm();
        public AdminForm(FrontForm front)
        {
            Front = front;
            //check if lists are empty so that a loading error is prevented in the 1st launch
            //adcionar check files
            if (!(Directory.Exists(SaveLoad.PathToData)))
            {
                if (!File.Exists(SaveLoad.PathToData))
                {
                    SaveLoad.SaveFleet(Fleet);
                    SaveLoad.SaveFlights(Flights);
                    SaveLoad.SaveAirports(Locations);
                }
            }
            
            InitializeComponent();
            Flights = SaveLoad.LoadFlights();
            Fleet = SaveLoad.LoadFleet();
            Locations = SaveLoad.LoadAirports();
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
            FleetPanel fleetPanel = new FleetPanel(Fleet);
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
            AirportPanel portPanel = new AirportPanel(Locations);
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
            exit.SetToolTip(btnExit,"Saves & Returns to Main");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Front.Visible = true;
        }
    }
}
