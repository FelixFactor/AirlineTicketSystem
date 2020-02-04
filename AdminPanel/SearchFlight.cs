using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassLibrary;
using System.Linq;

namespace AdminPanel
{
    public partial class SearchFlight : UserControl
    {
        List<Flight> FlyHiFlights;
        List<Flight> SearchedFlights = new List<Flight>();
        ClientServices Form;

        public SearchFlight(List<Flight> flights, ClientServices frm)
        {
            Form = frm;
            FlyHiFlights = flights;
            InitializeComponent();
            dateBox.MinDate = DateTime.UtcNow;
            checkOrigin.Enabled = false;
            RefreshList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSearch();
            tbOrigin.Text = string.Empty;
            tbDestination.Text = string.Empty;
            dateBox.Value = DateTime.UtcNow;
            checkOrigin.Checked = false;
            btnBooking.Enabled = false;
        }
        /// <summary>
        /// 1st-checks if the origin is empty if(true) searches by date; if(false) checks the origin text with the list and creates a searchlist; 
        /// then for the destination and last if unckecked(flexible date) for the date in the searchlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnBooking.Enabled = true;
            ClearSearch();
            if (string.IsNullOrWhiteSpace(tbOrigin.Text))
            {
                var dateResult = FlyHiFlights.Where(f => f.Date.ToShortDateString() == dateBox.Value.ToShortDateString());
                SearchList((List<Flight>)dateResult.ToList());
            }
            else
            {
                string toSearchFrom = Utils.UpperCase(tbOrigin.Text);
                var results = FlyHiFlights.Where(f => f.Origin.City == toSearchFrom);
                SearchList((List<Flight>)results.ToList());
                if (!string.IsNullOrWhiteSpace(tbDestination.Text) && SearchedFlights.Count != 0)
                {
                    string toSearchWhere = Utils.UpperCase(tbDestination.Text);
                    var resultsDest = SearchedFlights.Where(f => f.Destination.City == toSearchWhere);
                    SearchList((List<Flight>)resultsDest.ToList());
                }
                else if (checkOrigin.Checked == false && SearchedFlights.Count != 0)
                {
                    var dateResult = SearchedFlights.Where(f => f.Date.ToShortDateString() == dateBox.Value.ToShortDateString());
                    SearchList((List<Flight>)dateResult.ToList());
                }
            }
            if (SearchedFlights.Count == 0)
            {
                MessageBox.Show("No flights were found!", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnBooking.Enabled = false;
            }
            RefreshList();
        }
        private void btnBooking_Click(object sender, EventArgs e)
        {
            try
            {
                Flight toBook = CheckList(DGVSearch.CurrentRow.DataBoundItem as Flight);
                if (toBook != null)
                {
                    BookFlight booking = new BookFlight(toBook);
                    Form.AddControls(booking);
                    Form.GoToBooking();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please choose a flight from the list!", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //<<<<<<<<<<<<<<< FUNCTIONS >>>>>>>>>>>>>>>>>>
        /// <summary>
        /// copies the result to the SearchedFlights List
        /// </summary>
        /// <param name="result"></param>
        private void SearchList(List<Flight> result)
        {
            SearchedFlights.Clear();
            SearchedFlights = result;
        }
        private void RefreshList()
        {
            if (SearchedFlights.Count != 0)
            {
                DGVSearch.DataSource = null;
                DGVSearch.DataSource = SearchedFlights;
                DGVSearch.AutoResizeColumns();
                //DGVSearch.Sort(AData, System.ComponentModel.ListSortDirection.Ascending);
            }
        }
        private void ClearSearch()
        {
            DGVSearch.DataSource = null;
            SearchedFlights.Clear();
        }
        private Flight CheckList(Flight toCheck)
        {
            Flight listed = new Flight();
            if (toCheck != null)
            {
                foreach (Flight item in FlyHiFlights)
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

        //<<<<<<<<<<<<<<<<<<<<<<<<<<< EVENTS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void checkOrigin_CheckedChanged(object sender, EventArgs e)
        {
            if (checkOrigin.Checked == true)
            {
                dateBox.Enabled = false;
            }
            else
            {
                dateBox.Enabled = true;
            }
            
        }
        private void tbOrigin_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbOrigin.Text))
            {
                checkOrigin.Enabled = false;
                checkOrigin.Checked = false;
            }
            else
            {
                checkOrigin.Enabled = true;
            }
        }
    }
}
