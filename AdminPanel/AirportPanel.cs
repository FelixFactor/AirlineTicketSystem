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
            Airport local = (Airport)listBoxAirports.SelectedItem;
            Airport toEdit = CheckList(local, Flights);

            if (toEdit != null)
            {
                listBoxAirports.Enabled = false;
                gbEditor.Visible = true;
                textBoxCity.Text = toEdit.City;
                textBoxCountry.Text = toEdit.Country;
                tbShortName.Text = toEdit.ShortName;
                tbAirportName.Text = toEdit.AirportName;
            }
            else
            {
                MessageBox.Show("Airport cannot be edited because it is in use!", "Cannot complete action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Airport local = (Airport)listBoxAirports.SelectedItem;
            Airport toErase = CheckList(local, Flights);

            if (toErase != null)
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
            {
                MessageBox.Show("Airport cannot be deleted because it is in use!", "Cannot complete action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // <<<<<<<<<<<<<<<<< EDIT BUTTONS >>>>>>>>>>>>>>>>>>>>>>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Airport local = CheckList((Airport)listBoxAirports.SelectedItem, Flights);

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
        /// tests objects selected from the listBox
        /// </summary>
        /// <param name="tester"></param>
        /// <returns>returns the object from the list or null</returns>
        private Airport CheckList(Airport tester, List<Flight> flights)
        {
            try
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
                foreach (Flight item in flights)
                {
                    if (item.Origin.City == tested.City || item.Destination.City == tested.City)
                    {
                        tested = null;
                        break;
                    }
                }
                return tested;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Reference lost. \nPlease try again.", "Critical ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
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
                {
                    return city;
                }
                else
                {
                    return null;
                }
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
            if (!(string.IsNullOrWhiteSpace(tbShortName.Text)))
            {
                string shortName = Utils.UpperCase(tbShortName.Text);
                return shortName;
            }
            else
            {
                MessageBox.Show("Input an Airport short name, please. \n Be creative!", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
    }
}
