using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassLibrary;
using System.Linq;

namespace AdminPanel
{
    public partial class BookFlight : UserControl
    {
        Flight toBook = new Flight();
        List<string> EconAvailable = new List<string>();
        List<string> ExecAvailable = new List<string>();
        ClientServices Form;
        
        public BookFlight(Flight selection, ClientServices form)
        {
            Form = form;
            toBook = selection;
            EconAvailable = toBook.Plane.EconSeats;
            ExecAvailable = toBook.Plane.ExecSeats;
            InitializeComponent();
            btnCheckIn.Enabled = false;
            gbExec.Location = new System.Drawing.Point(363, 140);
            tbBirthDate.Mask = "0000/00/00";
            tbBirthDate.ValidatingType = typeof(DateTime);
            tbBirthDate.TypeValidationCompleted += new TypeValidationEventHandler(tbBirthDate_TypeValidationCompleted);
            if (toBook.Plane.FirstClass == 0)
            {
                rbExec.Enabled = false;
            }
            if (toBook.Plane.SecondClass == 0)
            {
                rbEcon.Enabled = false;
            }
            AvailableSeats();
        }


        //<<<<<<<<<<<<<<<<<<<<<<<<<<< FUNCTIONS >>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// Checks for seats taken in the selected flight and removes them from the available
        /// </summary>
        private void AvailableSeats()
        {
            if (toBook.TakenSeats.Count != 0)
            {
                foreach (string seat in toBook.TakenSeats)
                {
                    if (seat.Length == 2)
                    {
                        foreach (string seatAvailable in toBook.Plane.ExecSeats)
                        {
                            if (seat == seatAvailable)
                            {
                                ExecAvailable.Remove(seat);
                            }
                        }
                    }
                    else
                    {
                        foreach (string seatAvailable in toBook.Plane.EconSeats)
                        {
                            if (seat == seatAvailable)
                            {
                                EconAvailable.Remove(seat);
                            }
                        }
                    }
                }
            }
        }
        private void FillAvailableList(string row)
        {
            if (gbEcon.Visible == true)
            {
                var result = EconAvailable.Where(e => e.StartsWith(row));
                List<string> Tofill = result.ToList();
                cbSeats.DataSource = Tofill;
            }
            else
            {
                var result = ExecAvailable.Where(e => e.StartsWith(row));
                List<string> Tofill = result.ToList();
                cbSeats.DataSource = Tofill;
            }
        }
        private void DeselectRB()
        {
            rbExecA.Checked = false;
            rbExecB.Checked = false;
            rbExecE.Checked = false;
            rbExecF.Checked = false;
            rbEconA.Checked = false;
            rbEconB.Checked = false;
            rbEconC.Checked = false;
            rbEconD.Checked = false;
            rbEconE.Checked = false;
            rbEconF.Checked = false;
        }


        //<<<<<<<<<<<<<<<<<<<<<<<<<<< BUTTONS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            Passenger newPassenger = new Passenger
            {
                PassengerName = tbName.Text,
                LastName = tbLastName.Text,
                Identification = tbIdentification.Text,
                Email = tbEmail.Text,
                Seat = cbSeats.Text,
                Address = tbAddress.Text,
                TaxNumber = tbTaxNumber.Text,
                IdPassenger = $"Pass{toBook.FlightNumber}" + DateTime.UtcNow.ToShortTimeString().ToString()
            };
            toBook.Passengers.Add(newPassenger);
            toBook.TakenSeats.Add(newPassenger.Seat);

            Form.BackToSearch();
        }


        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<< EVENTS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void rbExec_CheckedChanged(object sender, EventArgs e)
        {
            DeselectRB();
            cbSeats.DataSource = null;
            if (rbExec.Checked == true)
            {
                gbExec.Visible = true;
                gbEcon.Visible = false;
            }
            else
            {
                gbEcon.Visible = true;
                gbExec.Visible = false;
            }
        }
        private void rbEconA_CheckedChanged(object sender, EventArgs e)
        {
            cbSeats.DataSource = null;
            if (rbEconA.Checked == true)
            {
                FillAvailableList("A");
            }
            else if (rbEconB.Checked == true)
            {
                FillAvailableList("B");
            }
            else if (rbEconC.Checked == true)
            {
                FillAvailableList("C");
            }
            else if (rbEconD.Checked == true)
            {
                FillAvailableList("D");
            }
            else if (rbEconE.Checked == true)
            {
                FillAvailableList("E");
            }
            else
            {
                FillAvailableList("F");
            }
        }
        private void rbExecA_CheckedChanged(object sender, EventArgs e)
        {
            cbSeats.DataSource = null;
            if (rbExecA.Checked == true)
            {
                FillAvailableList("A");
            }
            else if (rbExecB.Checked == true)
            {
                FillAvailableList("B");
            }
            else if (rbExecE.Checked)
            {
                FillAvailableList("E");
            }
            else
            {
                FillAvailableList("F");
            }
        }
        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbName.Text) && !string.IsNullOrWhiteSpace(tbLastName.Text) && !string.IsNullOrWhiteSpace(tbIdentification.Text) && !string.IsNullOrWhiteSpace(tbEmail.Text) && !string.IsNullOrEmpty(cbSeats.Text) && (rbMan.Checked || rbWoman.Checked))
            {
                btnCheckIn.Enabled = true;
            }
            else
            {
                btnCheckIn.Enabled = false;
            }
        }
        private void tbBirthDate_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            if (!e.IsValidInput)
            {
                toolTip1.ToolTipTitle = "Invalid Date";
                toolTip1.Show("The data you supplied must be a valid date in the format yyyy/mm/dd.", tbBirthDate, 150, 0, 5000);
            }
            else
            {
                //Now that the type has passed basic type validation, enforce more specific type rules.
                DateTime userDate = (DateTime)e.ReturnValue;
                if (userDate > DateTime.UtcNow)
                {
                    toolTip1.ToolTipTitle = "Invalid Date";
                    toolTip1.Show("The date in this field must be older than today's date.", tbBirthDate, 150, 0, 5000);
                    e.Cancel = true;
                }
            }
        }
        private void tbBirthDate_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbBirthDate.Text))
            {
                tbBirthDate.SelectionStart = 0;
            }
            else { tbBirthDate.SelectAll(); }
        }

    }
}
