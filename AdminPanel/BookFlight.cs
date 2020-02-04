using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassLibrary;

namespace AdminPanel
{
    public partial class BookFlight : UserControl
    {
        Flight toBook = new Flight();
        
        
        public BookFlight(Flight selection)
        {
            toBook = selection;
            InitializeComponent();
            tbFlightNumber.Text = $"FlyHi0{toBook.FlightNumber.ToString()}";
            tbFrom.Text = toBook.Origin.City + toBook.Origin.AirportName;
            tbDestination.Text = toBook.Destination.City + toBook.Destination.AirportName;
            tbDate.Text = toBook.Date.ToLongDateString();
            tbHour.Text = toBook.Date.ToShortTimeString();
            if (toBook.Plane.FirstClass == 0)
            {
                rbExec.Enabled = false;
            }
            if (toBook.Plane.SecondClass == 0)
            {
                rbEcon.Enabled = false;
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            
        }

        private void rbExec_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExec.Checked == true)
            {
                cbSeats.DataSource = toBook.Plane.ExecSeats;
            }
            else
            {
                cbSeats.DataSource = toBook.Plane.EconSeats;
            }
        }
    }
}
