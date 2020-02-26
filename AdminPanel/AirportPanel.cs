using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPanel
{
    public partial class AirportPanel : UserControl
    {
        readonly List<Airport> Airports;
        readonly List<Flight> Flights;
        readonly List<Airport> AllAirports;
        
        public AirportPanel(List<Airport> ports, List<Flight> flights, List<Airport> allAirports)
        {
            AllAirports = allAirports;
            Flights = flights;
            Airports = ports;
            InitializeComponent();

            RefreshList();
            this.gbEditor.Location = new System.Drawing.Point(272, 160);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckCity() && CheckCountry() && CheckShort())//checks for empty TBs and returns error if true!
            {
                Airport airportNew = new Airport(NextNumber(),
                                                Usefull.UpperCase(textBoxCity.Text),
                                                Usefull.UpperCase(textBoxCountry.Text),
                                                tbShortName.Text.ToUpper(),
                                                Usefull.UpperCase(tbAirportName.Text));

                //checks if there is a airport with the same IATA code
                if (AirportExists(airportNew))
                {
                    Airports.Add(airportNew);
                    RefreshList();
                    ClearFields();
                    //not sure if this is correct but cleans the search list
                    BtnClean_Click(sender, e);
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //matches the DGV item with the list of Airports
                Airport toEdit = MatchAirportList((Airport)listBoxAirports.CurrentRow.DataBoundItem);
                if (IsUsed(toEdit))
                {
                    btnSave.Visible = true;
                    listBoxAirports.Enabled = false;
                    gbEditor.Visible = true;
                    textBoxCity.Text = toEdit.City;
                    textBoxCountry.Text = toEdit.Country;
                    tbShortName.Text = toEdit.IATA;
                    tbAirportName.Text = toEdit.Name;
                }
                else
                    MessageBox.Show($"{toEdit.City} Airport cannot be edited \nwhile it is an Origin/Destination of a Flight!", "Cannot complete action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Airport not found.\nPlease check and try again.");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //matches the DGV airport with the list of Airports
                Airport toErase = MatchAirportList((Airport)listBoxAirports.CurrentRow.DataBoundItem);
                if (IsUsed(toErase))
                {
                    DialogResult answer;
                    answer = MessageBox.Show($"Are you sure you want to drop the {toErase.City} Airport connection?", "Confirm your action", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (answer == DialogResult.Yes)
                    {
                        Airports.Remove(toErase);
                        RefreshList();
                    }
                }
                else //throws error message if the airport is being used in a flight already
                    MessageBox.Show($"{toErase.City} Airport cannot be deleted \nwhile it is an Origin/Destination of a Flight!", "Cannot complete action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Airport doesn't exist.\nReload page and try again!");
            }
        }
        private async void BtnSearch_Click_1(object sender, EventArgs e)
        {
            if (CheckCity())
            {
                //looks for the city name inputed, in a list of world Airports
                List<Airport> found = await GetAirport();

                if (found.Count != 0)
                {
                    ListResults.DataSource = null;
                    ListResults.DataSource = found;
                }
                else
                {
                    MessageBox.Show("No airports found in that city.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void BtnClean_Click(object sender, EventArgs e)
        {
            ClearFields();
            ListResults.DataSource = null;
        }

        // <<<<<<<<<<<<<<<<< EDIT BUTTONS >>>>>>>>>>>>>>>>>>>>>>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Airport local = MatchAirportList((Airport)listBoxAirports.CurrentRow.DataBoundItem);
            
            if (CheckCity() && CheckCountry() && CheckShort())
            {
                Airport airportNew = new Airport(local.InternId,
                                                Usefull.UpperCase(textBoxCity.Text),
                                                Usefull.UpperCase(textBoxCountry.Text),
                                                tbShortName.Text.ToUpper(),
                                                Usefull.UpperCase(tbAirportName.Text));

                if (AirportExists(airportNew))
                {
                    local.Name = Usefull.UpperCase(tbAirportName.Text);
                    local.Country = Usefull.UpperCase(textBoxCountry.Text);
                    local.City = Usefull.UpperCase(textBoxCity.Text);
                    local.IATA = tbShortName.Text.ToUpper();
                    listBoxAirports.Enabled = true;
                    gbEditor.Visible = false;
                    RefreshList();
                    ClearFields();
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            gbEditor.Visible = false;
            listBoxAirports.Enabled = true;
            ListResults.Visible = false; 
        }
        


        //<<<<<<<<<<<<<<<< FUNCTIONS >>>>>>>>>>>>>>>>>
        /// <summary>
        /// matches objects from the DGV selection with the list
        /// </summary>
        /// <param name="match"></param>
        /// <returns>returns the object from the list</returns>
        private Airport MatchAirportList(Airport match)
        {
            //the tested is equaled to null so that it throws a NullReferenceException when the funtion is called and there is no matching Airport
            Airport tested = null;

            foreach (Airport port in Airports)
            {
                if (match.InternId == port.InternId)
                {
                    tested = port;
                    return tested;
                }
            }
            return tested;
        }
        private bool AirportExists(Airport airportNew)
        {
            var result = Airports.Where(a => a.InternId == airportNew.InternId);
            if (result.ToList().Count == 1)//when in edition mode the result will return 1
            {
                return true;
            }
            else//the result will return 0 because it's a new airport
            {
                var checkName = Airports.Where(a => a.IATA == airportNew.IATA);//this will check for a repeated IATA code
                if (checkName.ToList().Count != 0)
                {
                    MessageBox.Show($"You already have an Airport connection to {Usefull.UpperCase(textBoxCity.Text)}!", "Cannot add Airport!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        /// if the airport is used in a flight this will return true
        /// </summary>
        /// <param name="toEdit"></param>
        /// <returns></returns>
        private bool IsUsed(Airport toEdit)
        {
            foreach (Flight item in Flights)
            {
                //checks the flight list to see if the airport is used in a flight, so you don't delete an aiport being used!
                if (item.Origin.InternId == toEdit.InternId || item.Destination.InternId == toEdit.InternId)
                {
                    //if the flight is over it allows to delete the Airport
                    if (item.EstimatedTimeArrival < DateTime.UtcNow)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
            return true;
        }
        private void ClearFields()
        {
            textBoxCountry.Text = string.Empty;
            textBoxCity.Text = string.Empty;
            tbShortName.Text = string.Empty;
            tbAirportName.Text = string.Empty;
        }
        private void RefreshList()
        {
            listBoxAirports.DataSource = null;
            //if the list is empty it will not refresh
            if (Airports.Count != 0)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                listBoxAirports.DataSource = Airports;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }
        /// <summary>
        /// generates the error if the city fields is empty
        /// </summary>
        /// <returns></returns>
        private bool CheckCity()
        {
            if (!(string.IsNullOrWhiteSpace(textBoxCity.Text)))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please input a location.", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        private bool CheckCountry()
        {
            if (!(string.IsNullOrWhiteSpace(textBoxCountry.Text)))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please input a country.", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        private bool CheckShort()
        {
            if (!(string.IsNullOrWhiteSpace(tbShortName.Text) || tbShortName.Text.Length > 3 || tbShortName.Text.Length < 3))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please input an Airport short name composed of 3 letters. \nBe creative!", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        private int NextNumber()
        {
            if (Airports.Count != 0)
            {
                var last = Airports[Airports.Count - 1];
                return last.InternId + 1;
            }
            else
            {
                int number = 1;
                return number;
            }
        }
        /// <summary>
        /// searches for airports in a list of all world airports with a user inputed city
        /// </summary>
        /// <returns></returns>
        private Task<List<Airport>> GetAirport()
        {
            var result = AllAirports.Where(a => a.City.StartsWith(Usefull.UpperCase(textBoxCity.Text)));
            return Task.FromResult(result.ToList());
        }
        /// <summary>
        /// checks the selected input with the actual list of airports
        /// </summary>
        /// <param name="selectedItem"></param>
        /// <returns></returns>
        private Airport SearchInAll(Airport selectedItem)
        {
            Airport tested = null;

            foreach (Airport port in AllAirports)
            {
                if (selectedItem.AirportID == port.AirportID)
                {
                    tested = port;
                    return tested;
                }
            }
            return tested;
        }


        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< EVENTS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        
        private void listBoxAirports_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                listBoxAirports.CurrentRow.Selected = true;
            }
            catch (Exception)
            {

            }
        }
        private void ListResults_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Airport toAdd = SearchInAll((Airport)ListResults.SelectedItem);
                textBoxCity.Text = toAdd.City;
                textBoxCountry.Text = toAdd.Country;
                tbShortName.Text = toAdd.IATA;
                tbAirportName.Text = toAdd.Name;
            }
            catch (NullReferenceException)
            {

            }
        }
        
    }
}
