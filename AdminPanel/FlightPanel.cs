using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
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

            calendar.MinDate = DateTime.UtcNow.AddDays(1);
            
            RefreshLists();
            RefreshFlights();
           
        }
        private void btnCreateFlight_Click_1(object sender, EventArgs e)
        {
            Airport origin = (Airport)cboxOrigin.SelectedItem;
            Airport destination = (Airport)cboxDestination.SelectedItem;
            Aircraft plane = (Aircraft)cbAircrafts.SelectedItem;
            DateTime setDate = new DateTime();
            try
            {
                setDate = HourMinute();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (CheckAirport(origin))
            {
                if(CheckAirport(destination))
                {
                    if (origin.City == destination.City)
                    {
                        MessageBox.Show("Destination Airport cannot be the same as the Airport of Origin!!", "Cannot create flight", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if(IsBeingUsed(plane, setDate))
                    {
                        MessageBox.Show($"Aircraft {plane.AircraftID} cannot be selected for this flight \nbecause it is being used for another flight.", "Cannot create flight", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        CreateFlight(origin, destination, plane, setDate);
                        CreateFlight(destination, origin, plane, setDate.AddHours(8));
                        RefreshFlights();
                        RefreshLists();
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
        /// <summary>
        /// goes through flights to avoid creating a flight with the same plane at the same hour or close
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        private bool IsBeingUsed(Aircraft plane, DateTime checkDate)
        {
            var result = Flights.Where(f => f.Plane.AircraftID == plane.AircraftID);
            var otherResult = result.Where(f => f.Date.Date == checkDate.Date);
            List<Flight> CheckTime = otherResult.ToList();
            if (CheckTime.Count != 0)
            {
                foreach (Flight item in CheckTime)
                {
                    if (checkDate.Hour >= item.Date.Hour -8 || checkDate.Hour <= item.Date.Hour + 8)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Flight toDelete = (Flight)DGVFlights.CurrentRow.DataBoundItem;
            if (CheckFlightList(toDelete))
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
            else
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
        private void CreateFlight(Airport origin, Airport destination, Aircraft plane, DateTime setDate)
        {
            Flights.Add(new Flight { EntryNumber = NextNumber(), Origin = origin, Destination = destination, Date = setDate, Plane = plane });
            RefreshFlights();
            RefreshLists();
        }
        private bool CheckAirport(Airport origin)
        {
            Airport exists = null;
            foreach (Airport airport in Locations)
            {
                if (origin.City == airport.City)
                {
                    exists = airport;
                    break;
                }
            }
            if (exists != null)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        /// matches the selected item with the list
        /// </summary>
        /// <param name="toCheck"></param>
        /// <returns>the same object from the list</returns>
        private bool CheckFlightList(Flight toCheck)
        {
            Flight listed = null;
            foreach (Flight item in Flights)
            {
                if (item == toCheck)
                {
                    listed = item;
                    break;
                }
            }
            if (listed != null)
            {
                return true;
            }
            else
            {
                return false;
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
                return last.EntryNumber + 1;
            }
            else
            {
                int number = 1;
                return number;
            }
        }
        private DateTime HourMinute()
        {
            string[] hourMinute = tbHour.ToString().Split(':');
            double setHours = double.Parse(hourMinute[1]);
            double setMinutes = double.Parse(hourMinute[2]);
            if (setHours >= 24 || setMinutes >= 60)
            {
                throw new Exception("Incorrect Hour");
            }
            //day starts at 00.00, the upper lines add the hours so it can display proper departure time
            DateTime setDate = calendar.SelectionRange.Start.AddHours(setHours).AddMinutes(setMinutes);
            return setDate;
        }





        //<<<<<<<<<<<<<<<<<<<<<<<<<<< EVENTS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void tbHour_Enter(object sender, EventArgs e)
        {
            tbHour.SelectAll();
        }
        private void tbHour_Click(object sender, EventArgs e)
        {
            tbHour.SelectAll();
        }
    }
}
