using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AdminPanel
{
    public partial class AdminForm : Form
    {
        //the list are created here to be accessed to all methods below
        List<Airport> Locations;
        List<Aircraft> Fleet;
        List<Flight> Flights;
        List<Airport> AllAirports;
    
        FrontForm Front = new FrontForm();
        public AdminForm(FrontForm front)
        {
            try
            {
                Locations = SaveLoad.LoadAirports();
                Fleet = SaveLoad.LoadFleet();
                Flights = SaveLoad.LoadFlights();
                AllAirports = SaveLoad.LoadAllAirports();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }

            Front = front;
            InitializeComponent();

            //the first panel to be displayed
            FlightPanel flightPanel = new FlightPanel(Flights, Fleet, Locations);
            
            //displaying method with inputed panel
            AddControls(flightPanel);
            btnFlight.BackColor = SystemColors.Control;
            btnFlight.Enabled = false;
            
        }
        //<<<<<<<<<<<<<<<< FUNCTIONS >>>>>>>>>>>>>>>>>
        private void AddControls(UserControl panels)
        {
            UserControl toAdd = panels;
            //the main panel 
            mainpanel.Controls.Clear();
            mainpanel.Controls.Add(toAdd);
        }
        //<<<<<<<<<<<<<<<<< BUTTONS >>>>>>>>>>>>>>>>>>>>>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
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
            AirportPanel portPanel = new AirportPanel(Locations, Flights, AllAirports);
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
            try
            {
                SaveLoad.SaveAirports(Locations);
                SaveLoad.SaveFleet(Fleet);
                SaveLoad.SaveFlights(Flights);
            }
            catch(Exception)
            {

            }
        }
        //<<<<<<<<<<<<<<<< EVENTS >>>>>>>>>>>>>>>>>>>>
        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            ToolTip exit = new ToolTip();
            exit.SetToolTip(btnExit,"Returns to Front Menu");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Front.Visible = true;
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save your work before exiting?", "Save your work", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    SaveLoad.SaveAirports(Locations);
                    SaveLoad.SaveFleet(Fleet);
                    SaveLoad.SaveFlights(Flights);
                }
                catch(Exception) { }
            }
        }
    }
}
