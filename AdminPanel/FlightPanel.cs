using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace AdminPanel
{
    public partial class FlightPanel : UserControl
    {
        List<Airport> Airports;
        List<Flight> Flights;
        List<Aircraft> Fleet;

        public FlightPanel(List<Flight> flights, List<Aircraft> fleet, List<Airport> ports)
        {
            Flights = flights;
            Airports = ports;
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
            DateTime setDate = calendar.SelectionRange.Start;

            //SelectedIndex = -1 refers to null
            if (cboxOrigin.SelectedIndex != -1)
            {
                if(cboxDestination.SelectedIndex != -1)
                {
                    if (origin.City == destination.City)
                    {
                        MessageBox.Show("Destination Airport cannot be the same as the Airport of Origin!!", "Cannot create flight", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if(cbAircrafts.SelectedIndex != -1) 
                        {
                            //splits the textBox into hours minutes
                            string[] hourMinute = tbHour.ToString().Trim().Split(':');
                            if (!string.IsNullOrWhiteSpace(hourMinute[1]) && !string.IsNullOrEmpty(hourMinute[2]))
                            {
                                double setHours = double.Parse(hourMinute[1]);
                                double setMinutes = double.Parse(hourMinute[2]);

                                //checks for incorrect time input
                                if (setHours > 23 || setMinutes >= 60)
                                    MessageBox.Show("Incorrect Hour");
                                else if (setHours < 6 && setHours > 23)
                                    MessageBox.Show("Due to legislation \nair traffic during 00.00 and 06.00 is limited for comercial flights.");
                                else
                                {
                                    //since the date starts at 00.00 we have to add the time to it
                                    //adds the variables from the split above to the date
                                    setDate = setDate.AddHours(setHours).AddMinutes(setMinutes);

                                    if (IsBeingUsed(plane, setDate))//IsbeingUsed checks if the plane has a flight plan on the chosen date, and between minus or plus 8hours than the one it is in
                                    {
                                        MessageBox.Show($"Aircraft {plane.InternalID} cannot be selected for this flight " +
                                            $"\nbecause it already has a flight plan scheduled.", "Cannot create flight", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else
                                    {
                                        CreateFlight(origin, destination, plane, setDate);
                                        //CreateFlight(destination, origin, plane, setDate.AddHours(8));//creates the return flight
                                        RefreshFlights();
                                        RefreshLists();
                                    }
                                }
                            }
                            else
                                MessageBox.Show("Enter time of departure(6-23h)");
                        }
                        else
                            MessageBox.Show("Please select an aircraft for this flight.");
                    }
                }
                else 
                    MessageBox.Show("Please select a Destination!", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
                MessageBox.Show("Please select an Origin!", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Flight toDelete = (Flight)DGVFlights.CurrentRow.DataBoundItem;

                //CheckFlight matches the datagridview item with the item from the list
                if (CheckFlightList(toDelete))
                {
                    if (toDelete.TakenSeats.Count == 0)
                    {
                        DialogResult answer;
                        answer = MessageBox.Show($"Are you sure you want to delete the flight n.{toDelete.FlightNumber} from {toDelete.Origin} to {toDelete.Destination}?", "Confirm action", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (answer == DialogResult.Yes)
                        {
                            //the idea is not to remove any flight, just make them invisible, but for now it is erased for good
                            Flights.Remove(toDelete);
                            RefreshFlights();
                            RefreshLists();
                        }
                    }
                    else
                        MessageBox.Show("Cannot delete a flight that already has tickets sold.", "Cannot complete action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("You must select a flight", "Nothing to delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException)
            {

            }
        }


        //<<<<<<<<<<<<<<<<<< FUNCTIONS >>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// goes through flight's list to avoid creating a flight with the same plane at the same hour or close
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        private bool IsBeingUsed(Aircraft plane, DateTime checkDate)
        {
            if (Flights.Count != 0)
            {
                //uses Linq to create a list of variables(objects in this case) matching the chosen plane for the flight
                var result = Flights.Where(f => f.Plane.AircraftID == plane.AircraftID);

                //this query matches the result above to the selected date
                var otherResult = result.Where(f => f.Date.Date.CompareTo(checkDate.Date) == 0);

                List<Flight> CheckTime = otherResult.ToList();
                if (CheckTime.Count != 0)
                {
                    //runs the query to check the time of departure and return the error
                    //if the flight to be created has between 6h above or below the departure
                    foreach (Flight item in CheckTime)
                    {
                        if (checkDate.Hour < item.Date.Hour)
                        {
                            if (checkDate.Hour > item.Date.Hour - 6)
                                return true;
                        }
                        else//checkDate.Hour > item.Hour
                        {
                            if (checkDate.Hour < item.Date.Hour + 6)
                                return true;
                        }    
                            
                    }
                    return false;
                }
                else
                    return false;
            }
            else
                return false;

        }
        /// <summary>
        /// the bindingContext allows for the comboBoxes to be handled separately from one another
        /// </summary>
        public void RefreshLists()
        {
            if (Airports.Count != 0)
            {
                //combo box of Destination locations 
                cboxDestination.BindingContext = new BindingContext();
                cboxDestination.DataSource = null;
                cboxDestination.DataSource = Airports;
                //combo box of Origin locations 
                cboxOrigin.DataSource = null;
                cboxOrigin.DataSource = Airports;
            }
            if (Fleet.Count != 0)
            {
                //combo box of aircrafts
                cbAircrafts.DataSource = null;
                cbAircrafts.DataSource = Fleet;
            }
            
            cboxDestination.SelectedIndex = -1;
            cboxOrigin.SelectedIndex = -1;
            cbAircrafts.SelectedIndex = -1;
            cboxDestination.Text = "--- Select a Destination ---";
            cboxOrigin.Text = "--- Select an Origin ---";
            cbAircrafts.Text = "--- Select an Aircraft ---";
            tbHour.Text = "  :  ";
        }
        private void CreateFlight(Airport origin, Airport destination, Aircraft plane, DateTime setDate)
        {
            Flights.Add(new Flight { EntryNumber = NextNumber(), Origin = origin, Destination = destination, Date = setDate, Plane = plane, EstimatedTimeArrival = setDate.AddHours(4) });
        }
        private void RefreshFlights()
        {
            DGVFlights.DataSource = null;
            if (Flights.Count != 0)
                DGVFlights.DataSource = Flights; 
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
                return true;
            else
                return false;
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
