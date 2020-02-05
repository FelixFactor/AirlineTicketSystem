using System.Windows.Forms;
using ClassLibrary;
using System;
using System.Collections.Generic;


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
            if (cboxManufacturer.SelectedIndex != -1)
            {
                if (cboxModel.SelectedIndex != -1)
                {
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
                                FirstClass = (int)(Convert.ToInt16(tbSeats.Text) * 0.05),
                                SecondClass = (int)(Convert.ToInt16(tbSeats.Text) * 0.95)
                            });
                            RefreshList();
                            ClearFields();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You must choose a Model!", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("You must choose a Manufacturer!", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Aircraft toEdit = CheckList((Aircraft)DGVFleet.CurrentRow.DataBoundItem, Flights);

                if (toEdit != null)
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
                {
                    MessageBox.Show("Airport cannot be edited because it is in use!", "Cannot complete action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You must select an aircraft", "Nothing to edit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Aircraft toDelete = CheckList((Aircraft)DGVFleet.CurrentRow.DataBoundItem, Flights);
                if (toDelete != null)
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
                {
                    MessageBox.Show("Aircraft cannot be deleted because it is in use!", "Cannot complete action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You must select an aircraft", "Nothing to delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (!string.IsNullOrWhiteSpace(tbExec.Text))
                {
                    if (!string.IsNullOrWhiteSpace(tbEcon.Text))
                    {
                        try
                        {
                            Aircraft toEdit = CheckList((Aircraft)DGVFleet.CurrentRow.DataBoundItem, Flights);
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
        private Aircraft CheckList(Aircraft toCheck, List<Flight> flights)
        {
            try
            {
                Aircraft tested = null;
                foreach (Aircraft item in Planes)//matches the result from the datagridview to the list
                {
                    if (item.AircraftID == toCheck.AircraftID)
                    {
                        tested = item;
                        break;
                    }
                }
                foreach (Flight item in flights)//checks if the plane is in use in a flight
                {
                    if (item.Plane.AircraftID == tested.AircraftID)
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
        private void RefreshList()
        {
            DGVFleet.DataSource = null;
            if (Planes.Count != 0)
            {
                DGVFleet.DataSource = Planes;
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
        /// Grabs the string in the cboxManufacturer and loads a XML with the same name, with all models refering to that Manufacturer
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
        /// 
        /// </summary>
        /// <returns>returns the next id based on the index from the list</returns>
        private int NextNumber()
        {
            if (Planes.Count != 0)
            {
                var last = Planes[Planes.Count - 1];
                return last.AircraftID+1;
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
            if (!string.IsNullOrWhiteSpace(tbSeats.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("A plane without seats?!\n Please enter the number of seats!", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }




        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< EVENTS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void tbSeats_Enter(object sender, EventArgs e)
        {
            tbSeats.SelectionStart = 0;
        }
        private void tbSeats_Click(object sender, EventArgs e)
        {
            tbSeats.SelectionStart = 0;
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
                {
                    tbSeats.Text = "160";
                }
                else
                {
                    tbSeats.Text = "200";
                }
            }
        }

        private void tbExec_MouseClick(object sender, MouseEventArgs e)
        {
            tbEcon.SelectionStart = 0;
            tbExec.SelectionStart = 0;
        }
    }
}
