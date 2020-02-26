using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AdminPanel
{
    public partial class FleetPanel : UserControl
    {
        List<Aircraft> Planes;
        List<Flight> Flights;

        public FleetPanel(List<Aircraft> fleet, List<Flight> flights)
        {
            Flights = flights;
            Planes = fleet;
            InitializeComponent();
            gbEditBtns.Location = new System.Drawing.Point(248, 3);
            RefreshList();
            ClearFields();
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<< BUTTONS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //SelectedIndex = -1 is no object and returns error
            if (cboxManufacturer.SelectedIndex != -1)
            {
                if (cboxModel.SelectedIndex != -1)
                {
                    //default number of seats is already inputed, but checks if some funny guy decides to make the Seats field empty or 0
                    if (CheckEmptySeats())
                    {
                        try
                        {
                            string manufacturer = cboxManufacturer.Text;
                            string model = cboxModel.Text;
                            Planes.Add(new Aircraft
                            {
                                AircraftID = NextNumber(),
                                Manufacturer = manufacturer,
                                Model = model,
                                TotalSeats = Convert.ToInt16(tbSeats.Text),
                                FirstClass = 0,
                                SecondClass = (int)(Convert.ToInt16(tbSeats.Text))
                            });
                            RefreshList();
                            ClearFields();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                        MessageBox.Show("A plane with 0 seats?!\n Please enter the number of seats!", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Please choose a model from the Model's menu!", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Please choose a manufacturer from the Manufacturer's menu!", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //matches the selected item with the list
                Aircraft toEdit = CheckPlaneList((Aircraft)DGVFleet.CurrentRow.DataBoundItem);

                //checks if being used to avoid changes during scheduled flight plans
                if (IsUsed(toEdit))
                {
                    DGVFleet.Enabled = false;
                    gbButtons.Visible = false;
                    gbEditBtns.Visible = true;
                    gbEdit.Visible = true;
                    tbEcon.Text = toEdit.SecondClass.ToString();
                    tbExec.Text = toEdit.FirstClass.ToString();
                    tbSeats.Text = toEdit.TotalSeats.ToString();
                }
                else
                    MessageBox.Show($"{toEdit.ToString()} cannot be edited while it has an active flight plan!", "Cannot complete action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //matches the selected item with the list
                Aircraft toDelete = CheckPlaneList((Aircraft)DGVFleet.CurrentRow.DataBoundItem);

                //checks usage in flight plans, unables delete if being used
                if (IsUsed(toDelete))
                {
                    DialogResult answer;
                    answer = MessageBox.Show($"Are you sure you want to delete {toDelete.ToString()}?", "Confirm action", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (answer == DialogResult.Yes)
                    {
                        Planes.Remove(toDelete);
                        RefreshList();
                    }
                }
                else
                    MessageBox.Show($"{toDelete.ToString()} cannot be deleted while it has an active flight plan!", "Cannot complete action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReturnFromEdit();
            ClearFields();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckEmptySeats())
            {
                //doesn't allow the seats to be empty fields
                if (!string.IsNullOrWhiteSpace(tbExec.Text))
                {
                    if (!string.IsNullOrWhiteSpace(tbEcon.Text))
                    {
                        try
                        {
                            Aircraft toEdit = CheckPlaneList((Aircraft)DGVFleet.CurrentRow.DataBoundItem);
                            toEdit.TotalSeats = Convert.ToInt16(tbSeats.Text);
                            toEdit.FirstClass = Convert.ToInt16(tbExec.Text);
                            toEdit.SecondClass = Convert.ToInt16(tbEcon.Text);
                            ReturnFromEdit();
                            ClearFields();
                            RefreshList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }


        //<<<<<<<<<<<<<<<<<<<<< FUNCTIONS >>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// matches the selected index with the list
        /// </summary>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        private Aircraft CheckPlaneList(Aircraft toCheck)
        {
            Aircraft tested = null;

            //matches the result from the datagridview to the list
            foreach (Aircraft item in Planes)
            {
                if (item.AircraftID == toCheck.AircraftID)
                {
                    tested = item;
                    break;
                }
            }
            if (tested != null)
                return tested;
            else
                throw new NullReferenceException("There is no aircraft selected.\nPlease try again.");
        }
        /// <summary>
        /// runs the flight list to check if the plane is associated with a flight
        /// </summary>
        /// <param name="isUsed"></param>
        /// <returns></returns>
        private bool IsUsed(Aircraft isUsed)
        {
            List<Flight> Results = CreateResults(isUsed.AircraftID);

            if (Results.Count != 0)
            {
                foreach (Flight item in Results)
                {
                    //if the flight is planned no changes can be done to the plane, unless the flight has finished
                    if (DateTime.UtcNow < item.EstimatedTimeArrival)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private List<Flight> CreateResults(int aircraftID)
        {
            var result = Flights.Where(f => f.Plane.AircraftID == aircraftID);
            return result.ToList();
        }
        private void RefreshList()
        {
            DGVFleet.DataSource = null;
            if (Planes.Count != 0)
            {
                DGVFleet.DataSource = Planes;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }
        private void ClearFields()
        {
            cboxManufacturer.Text = "--Select Manufacturer--";
            cboxModel.Items.Clear();
            cboxModel.Text = "--Select Model--";
            tbSeats.Text = string.Empty;
        }
        /// <summary>
        /// Grabs the string in the cboxManufacturer and loads the cboxModel with 2 models from that manufacturer
        /// </summary>
        /// <param name="tosearch"></param>
        private void FillModelList(string tosearch)
        {
            if (tosearch == "Boeing")
            {
                cboxModel.Items.Add("737-800");
                cboxModel.Items.Add("757-200");
            }
            else
            {
                cboxModel.Items.Add("A320-200");
                cboxModel.Items.Add("A321 NEO");
            }
        }
        /// <summary>
        /// returns the next id based on the index from the list
        /// </summary>
        /// <returns>returns the next id based on the index from the list</returns>
        private int NextNumber()
        {
            if (Planes.Count != 0)
            {
                var last = Planes[Planes.Count - 1];
                return last.AircraftID + 1;
            }
            else
            {
                int number = 1;
                return number;
            }
        }
        private void ReturnFromEdit()
        {
            gbButtons.Visible = true;
            gbEditBtns.Visible = false;
            gbEdit.Visible = false;
            DGVFleet.Enabled = true;
        }
        private bool CheckEmptySeats()
        {
            if (string.IsNullOrWhiteSpace(tbSeats.Text) || tbSeats.Text == "0")
                return false;
            else
                return true;
        }


        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< EVENTS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        private void tbSeats_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSeats.Text))
                tbSeats.SelectionStart = 0;
            else
                tbSeats.SelectAll();
        }
        private void DGVFleet_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DGVFleet.CurrentRow.Selected = true;
            }
            catch (Exception)
            {

            }
        }
        private void cboxManufacturer_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboxManufacturer.SelectedIndex != -1)
            {
                string name = cboxManufacturer.SelectedItem.ToString();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    ClearFields();
                    FillModelList(name);
                }
            }
        }
        private void cboxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxModel.SelectedIndex != -1)
            {
                if (cboxModel.SelectedIndex == 0)
                    tbSeats.Text = "160";
                else
                    tbSeats.Text = "200";
            }
        }
        private void tbExec_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbExec.Text))
                tbExec.SelectionStart = 0;
            else
                tbExec.SelectAll();
        }
        private void tbEcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbEcon.Text))
                tbEcon.SelectionStart = 0;
            else
                tbEcon.SelectAll();
        }
    }
}
