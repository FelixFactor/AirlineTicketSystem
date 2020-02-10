using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AdminPanel
{
    public partial class AirportPanel : UserControl
    {
        readonly List<Airport> Airports = new List<Airport>();
        readonly List<Flight> Flights;
        
        public AirportPanel(List<Airport> ports, List<Flight> flights)
        {
            Flights = flights;
            Airports = ports;
            InitializeComponent();

            RefreshList();
            this.gbEditor.Location = new System.Drawing.Point(209, 98);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckCity() != null)
            {
                if (CheckCountry() != null)
                {
                    if (CheckShort() != null)
                    {
                        Airports.Add(new Airport { AirportName = Utils.UpperCase(tbAirportName.Text), 
                        Country = Utils.UpperCase(textBoxCountry.Text), 
                        City = Utils.UpperCase(textBoxCity.Text),
                        ShortName = tbShortName.Text.ToUpper() });
                        RefreshList();
                        ClearFields();
                    }
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Airport toEdit = MatchAirportList((Airport)listBoxAirports.SelectedItem);
                if (IsUsed(toEdit))
                {
                    listBoxAirports.Enabled = false;
                    gbEditor.Visible = true;
                    textBoxCity.Text = toEdit.City;
                    textBoxCountry.Text = toEdit.Country;
                    tbShortName.Text = toEdit.ShortName;
                    tbAirportName.Text = toEdit.AirportName;
                }
                else
                    MessageBox.Show($"{toEdit.City} Airport cannot be edited \nwhile it is an Origin/Destination of a Flight!", "Cannot complete action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Airport toErase = MatchAirportList((Airport)listBoxAirports.SelectedItem);
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
                else 
                    MessageBox.Show($"{toErase.City} Airport cannot be deleted \nwhile it is an Origin/Destination of a Flight!", "Cannot complete action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // <<<<<<<<<<<<<<<<< EDIT BUTTONS >>>>>>>>>>>>>>>>>>>>>>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Airport local = MatchAirportList((Airport)listBoxAirports.SelectedItem);

            Airports.Remove(local);

            if (CheckCity() != null)
            {
                if (CheckCountry() != null)
                {
                    if (CheckShort() != null)
                    {
                        Airports.Add(new Airport 
                        {
                            AirportName = Utils.UpperCase(tbAirportName.Text),
                            Country = Utils.UpperCase(textBoxCountry.Text),
                            City = Utils.UpperCase(textBoxCity.Text),
                            ShortName = tbShortName.Text.ToUpper()
                        });
                        listBoxAirports.Enabled = true;
                        gbEditor.Visible = false;
                        RefreshList();
                        ClearFields();
                    }
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            gbEditor.Visible = false;
            listBoxAirports.Enabled = true;
        }
        //<<<<<<<<<<<<<<<< FUNCTIONS >>>>>>>>>>>>>>>>>
        /// <summary>
        /// matches objects from the selection with the list
        /// </summary>
        /// <param name="tester"></param>
        /// <returns>returns the object from the list</returns>
        private Airport MatchAirportList(Airport tester)
        {
            Airport tested = null;

            foreach (Airport port in Airports)
            {
                if (tester == port)
                {
                    tested = port;
                    break;
                }
            }
            if (tested != null)
                return tested;
            else 
                throw new NullReferenceException("Airport not found.\nPlease check and try again.");
        }
        private bool IsUsed(Airport toEdit)
        {
            foreach (Flight item in Flights)
            {
                if (item.Origin.City == toEdit.City || item.Destination.City == toEdit.City)
                    return false;
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
            if (Airports.Count != 0)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            listBoxAirports.DataSource = null;
            listBoxAirports.DataSource = Airports;
        }
        private string CheckCity()
        {
            if (!(string.IsNullOrWhiteSpace(textBoxCity.Text)))
            {
                string city = Utils.UpperCase(textBoxCity.Text);
                string toSearch = Utils.UpperCase(textBoxCity.Text);
                foreach (Airport airport in Airports)
                {
                    string search = airport.City;

                    if (search == toSearch)
                    {
                        MessageBox.Show($"You already have an Airport connection to {toSearch}!", "Cannot add Airport!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        city = null;
                        break;
                    }
                }
                if (city != null)
                    return city;
                else
                    return null;
            }
            else
            {
                MessageBox.Show("Input a location, please.", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        private string CheckCountry()
        {
            if (!(string.IsNullOrWhiteSpace(textBoxCountry.Text)))
            {
                string country = Utils.UpperCase(textBoxCountry.Text);
                return country;
            }
            else
            {
                MessageBox.Show("Input a country, please.", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        private string CheckShort()
        {
            if (!(string.IsNullOrWhiteSpace(tbShortName.Text) || tbShortName.Text.Length > 3 || tbShortName.Text.Length < 3))
            {
                string shortName = Utils.UpperCase(tbShortName.Text);
                return shortName;
            }
            else
            {
                MessageBox.Show("Please input an Airport short name composed of 3 letters. \nBe creative!", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
    }
}
