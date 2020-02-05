using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AdminPanel
{
    public partial class AirportPanel : UserControl
    {
        List<Airport> Locations = new List<Airport>();
        
        public AirportPanel(List<Airport> ports)
        {
            Locations = ports;
            InitializeComponent();

            RefreshList();
            this.gbEditor.Location = new System.Drawing.Point(215, 33);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckCity() != null)
            {
                if (CheckCountry() != null)
                {
                    if (CheckShort() != null)
                    {
                        string country = textBoxCountry.Text;
                        string city = textBoxCity.Text;
                        string shortName = tbShortName.Text;
                        Locations.Add(new Airport { AirportName = string.Empty, Country = country, City = city, ShortName = shortName.ToUpper() });
                        RefreshList();
                        ClearFields();
                    }
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Airport local = (Airport)listBoxAirports.SelectedItem;
            Airport toEdit = CheckList(local);

            if (toEdit != null)
            {
                toEdit = CheckList(local);
                listBoxAirports.Enabled = false;
                gbEditor.Visible = true;
                textBoxCity.Text = toEdit.City;
                textBoxCountry.Text = toEdit.Country;
                tbShortName.Text = toEdit.ShortName;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Airport local = (Airport)listBoxAirports.SelectedItem;
            Airport toErase = CheckList(local);

            if (toErase != null)
            {
                DialogResult answer;
                answer = MessageBox.Show($"Are you sure you want to drop the {toErase.City} Airport connection?", "Confirm your action", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    Locations.Remove(toErase);
                    RefreshList();
                }
            }
        }
        // <<<<<<<<<<<<<<<<< EDIT BUTTON >>>>>>>>>>>>>>>>>>>>>>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Airport local = CheckList((Airport)listBoxAirports.SelectedItem);
            if (CheckCity() != null)
            {
                if (CheckCountry() != null)
                {
                    if (CheckShort() != null)
                    {
                        local.City = Utils.UpperCase(textBoxCity.Text);
                        local.Country = Utils.UpperCase(textBoxCountry.Text);
                        local.ShortName = Utils.UpperCase(tbShortName.Text);
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
        private Airport CheckList(Airport tester)
        {
            try
            {
                Airport tested = null;
                foreach (Airport port in Locations)
                {
                    if (tester.City == port.City)
                    {
                        tested = port;
                        break;
                    }
                }
                return tested;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Something went wrong. /n Try again please.", "Critical ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return null;
            }
        }
        private void ClearFields()
        {
            textBoxCountry.Text = string.Empty;
            textBoxCity.Text = string.Empty;
            tbShortName.Text = string.Empty;
        }
        private void RefreshList()
        {
            listBoxAirports.DataSource = null;
            listBoxAirports.DataSource = Locations;
        }
        private string CheckCity()
        {
            if (!(string.IsNullOrWhiteSpace(textBoxCity.Text)))
            {
                string city = Utils.UpperCase(textBoxCity.Text);
                string toSearch = Utils.UpperCase(textBoxCity.Text);
                foreach (Airport airport in Locations)
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
