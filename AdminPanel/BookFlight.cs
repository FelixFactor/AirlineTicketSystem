using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassLibrary;
using System.Linq;
using System.Net.Mail;

namespace AdminPanel
{
    public partial class BookFlight : UserControl
    {
        Flight toBook;
        List<string> EconAvailable = new List<string>();
        List<string> ExecAvailable = new List<string>();
        ClientServices Form;
        
        public BookFlight(Flight selection, ClientServices form)
        {
            Form = form;
            toBook = selection;

            //these lists will have the available seats for purchase
            EconAvailable = toBook.Plane.EconSeats;
            ExecAvailable = toBook.Plane.ExecSeats;

            InitializeComponent();

            btnCheckIn.Enabled = false;
            gbExec.Location = new System.Drawing.Point(363, 140);

            //masked date of birth textBox settings
            tbBirthDate.Mask = "0000/00/00";
            tbBirthDate.ValidatingType = typeof(DateTime);
            tbBirthDate.TypeValidationCompleted += new TypeValidationEventHandler(tbBirthDate_TypeValidationCompleted);

            //checks upfront if the plane has executive and economy seats and disables the button if not
            if (toBook.Plane.FirstClass == 0)
                rbExec.Enabled = false;
            if (toBook.Plane.SecondClass == 0)
                rbEcon.Enabled = false;

            AvailableSeats();
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<< BUTTONS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (IsEmailValid(tbEmail.Text))
            {
                //variables
                string name = Utils.UpperCase(tbName.Text) + " " + Utils.UpperCase(tbLastName.Text);
                string internId = MakeId(name);
                string id = tbIdentification.Text;
                string email = tbEmail.Text;
                string gender = GetGender();
                string seat = cbSeats.Text;
                string seatClass = GetClass();
                //creates a new passenger
                Passenger newPassenger = new Passenger(internId, name, id, email, gender, seat, seatClass);
                //adds the seat to the taken seats in the plane
                toBook.TakenSeats.Add(cbSeats.Text);
                //adds the passenger to the plane
                toBook.Tickets.Add(newPassenger);

                //creates the PDF using the inputed fields
                Utils.FillPDF(newPassenger, toBook);

                MessageBox.Show($"The Boarding Pass for passenger {name} was created.");

                ShowPDF showPDF = new ShowPDF(this, toBook.FlightNumber, newPassenger);
                showPDF.ShowDialog();

                BackToSearch();
            }
            else
                MessageBox.Show("The email provided is invalid.");
            
        }

        
        //<<<<<<<<<<<<<<<<<<<<<<<<<<< FUNCTIONS >>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// Checks for seats taken in the selected flight and removes them from the available
        /// </summary>
        private void AvailableSeats()
        {
            //if any seats have already been taken it goes in the function
            if (toBook.TakenSeats.Count != 0)
            {
                //goes through the list
                foreach (string seat in toBook.TakenSeats)
                {
                    //if the seat has lenght 2 it's a executive seat
                    if (seat.Length == 2)
                    {
                        //runs the executive seats list in the plane
                        foreach (string seatAvailable in toBook.Plane.ExecSeats)
                        {
                            //if it finds a match removes the seat from the available seats list
                            if (seat == seatAvailable)
                            {
                                ExecAvailable.Remove(seat);
                            }
                        }
                    }
                    else
                    {
                        //all other lenghts are for economy class
                        foreach (string seatAvailable in toBook.Plane.EconSeats)
                        {
                            //if any seat is matched it's removed from the available seats list
                            if (seat == seatAvailable)
                            {
                                EconAvailable.Remove(seat);
                            }
                        }
                    }
                }
            }
        }
        //fills the comboBox with the seats from the selected row
        private void FillAvailableList(string row)
        {
            if (gbEcon.Visible == true)
            {
                //creates a result with the available seats for economy class
                var result = EconAvailable.Where(e => e.StartsWith(row));
                List<string> Tofill = result.ToList();
                //fills the combo box with the results converted to a list
                cbSeats.DataSource = Tofill;
            }
            else
            {
                //creates a result with the available seats for executive class
                var result = ExecAvailable.Where(e => e.StartsWith(row));
                List<string> Tofill = result.ToList();
                //fills the combo box with the results converted to a list
                cbSeats.DataSource = Tofill;
            }
        }
        private void DeselectRB()
        {
            //used when changing between economy and executive selection
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
        private string GetGender()
        {
            //used to fill the PDF with the apropriate title
            if (rbMan.Checked)
                return "Mr.";
            else
                return "Mrs.";
        }
        private string MakeId(string trans)
        {
            //splits the passenger name in the space
            string[] split = trans.Split(' ');
            //generates a random 
            Random n = new Random();
            int number = n.Next(10000);
            //concats the first letter of the name and last name with the random to create a file number to be stored
            string id = split[0][0] + split[1][0] + number.ToString();
            return id;
        }
        private string GetClass()
        {
            //used to fill the PDF with the apropriate class
            if (rbEcon.Checked)
                return "Economy";
            else
                return "Executive";
        }
        public void BackToSearch()
        {
            //used by the showPDF form to return to search tab
            Form.BackToSearch();
        }
        public bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
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
                FillAvailableList("A");

            else if (rbEconB.Checked == true)
                FillAvailableList("B");

            else if (rbEconC.Checked == true)
                FillAvailableList("C");

            else if (rbEconD.Checked == true)
                FillAvailableList("D");

            else if (rbEconE.Checked == true)
                FillAvailableList("E");

            else
                FillAvailableList("F");
        }
        private void rbExecA_CheckedChanged(object sender, EventArgs e)
        {
            cbSeats.DataSource = null;

            if (rbExecA.Checked == true)
                FillAvailableList("A");

            else if (rbExecB.Checked == true)
                FillAvailableList("B");

            else if (rbExecE.Checked)
                FillAvailableList("E");

            else
                FillAvailableList("F");
        }
        private void tbName_TextChanged(object sender, EventArgs e)
        {//TODO create an event for each textbox
            if (!string.IsNullOrWhiteSpace(tbName.Text) && !string.IsNullOrWhiteSpace(tbLastName.Text) && !string.IsNullOrWhiteSpace(tbIdentification.Text) && !string.IsNullOrWhiteSpace(tbEmail.Text) && !string.IsNullOrEmpty(cbSeats.Text) && (rbMan.Checked || rbWoman.Checked))
                btnCheckIn.Enabled = true;
            else
                btnCheckIn.Enabled = false;
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
                tbBirthDate.SelectionStart = 0;
            else  
                tbBirthDate.SelectAll(); 
        }
    }
}
