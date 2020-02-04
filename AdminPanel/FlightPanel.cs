using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace AdminPanel
{
    public partial class FlightPanel : UserControl
    {
        List<Airport> Locations;
        List<Flight> Flights;
        List<Aircraft> Fleet;

        public FlightPanel(List<Flight> flights, List<Aircraft> fleet, List<Airport> ports)
        {
            Flights = flights;
            Locations = ports;
            Fleet = fleet;
            
            InitializeComponent();

            calendar.MinDate = DateTime.Now.AddDays(1);
            
            RefreshLists();
            RefreshFlights();
           
        }
        private void btnCreateFlight_Click_1(object sender, EventArgs e)
        {
            Airport origin = (Airport)cboxOrigin.SelectedItem;
            Airport destination = (Airport)cboxDestination.SelectedItem;
            Aircraft plane = (Aircraft)cbAircrafts.SelectedItem;
            if (origin != null)
            {
                if(destination != null)
                {
                    if (origin == destination)
                    {
                        MessageBox.Show("Destination Airport cannot be the same \nas the Airport of Origin!!", "Cannot create flight", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        try
                        {
                            string[] hourMinute = tbHour.ToString().Split(':');
                            double setHours = double.Parse(hourMinute[1]);
                            double setMinutes = double.Parse(hourMinute[2]);
                            DateTime setdate = calendar.SelectionRange.Start.AddHours(setHours).AddMinutes(setMinutes);
                            //day starts at 00.00, the upper line adds the hours so it can display proper departure time
                            Flights.Add(new Flight { FlightNumber = NextNumber(), Origin = origin, Destination = destination, Date = setdate, Plane = plane});
                            RefreshFlights();
                            RefreshLists();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Departure hour is incorrect.", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a Destination!", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Please select an Origin!", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Flight toDelete = CheckList((Flight)DGVFlights.CurrentRow.DataBoundItem);
                if (toDelete != null)
                {
                    DialogResult answer;
                    answer = MessageBox.Show($"Are you sure you want to delete the flight n.{toDelete.FlightNumber} from {toDelete.Origin} to {toDelete.Destination}?", "Confirm action", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (answer == DialogResult.Yes)
                    {
                        Flights.Remove(toDelete);
                        RefreshFlights();
                        RefreshLists();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You must select a flight", "Nothing to delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //<<<<<<<<<<<<<<<<<< FUNCTIONS >>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// the bindingContext allows for the comboBoxes to be handled separately from one another
        /// </summary>
        public void RefreshLists()
        {
            if (Locations.Count != 0)
            {
                //Drop Down Destination
                cboxDestination.BindingContext = new BindingContext();
                cboxDestination.DataSource = null;
                cboxDestination.DataSource = Locations;
                //Drop down ORIGIN
                cboxOrigin.DataSource = null;
                cboxOrigin.DataSource = Locations;
            }
            if (Fleet.Count != 0)
            {
                cbAircrafts.DataSource = null;
                cbAircrafts.DataSource = Fleet;
            }
            cboxDestination.Text = "--- Select a Destination ---";
            cboxOrigin.Text = "--- Select an Origin ---";
            cbAircrafts.Text = "--- Select an Aircraft ---";
            tbHour.Text = "  :  ";
        }
        private void RefreshFlights()
        {
            DGVFlights.DataSource = null;
            if (Flights.Count != 0)
            {
                DGVFlights.DataSource = Flights;
            }
        }
        /// <summary>
        /// checks the list for a selected object
        /// </summary>
        /// <param name="toCheck"></param>
        /// <returns>the same object from the list</returns>
        private Flight CheckList(Flight toCheck)
        {
            Flight listed = new Flight();
            if (toCheck != null)
            {
                foreach (Flight item  in Flights)
                {
                    if (item == toCheck)
                    {
                        listed = item;
                        break;
                    }
                }
                return listed;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// checks the last entry in the list
        /// </summary>
        /// <returns>an int based on the ID from the last entry</returns>
        private int NextNumber()
        {
            if (Flights.Count != 0)
            {
                var last = Flights[Flights.Count - 1];
                return last.FlightNumber + 1;
            }
            else
            {
                int number = 1;
                return number;
            }
        }
        //<<<<<<<<<<<<<<<<<<<<<<<<<<< EVENTS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void tbHour_Enter(object sender, EventArgs e)
        {
            tbHour.SelectionStart = 0;
        }
        private void tbHour_Click(object sender, EventArgs e)
        {
            tbHour.SelectionStart = 0;
        }
    }
}
