using System.Windows.Forms;
using ClassLibrary;
using System;
using System.Collections.Generic;


namespace AdminPanel
{
    public partial class FleetPanel : UserControl
    {
        List<Aircraft> Planes;
        
        public FleetPanel(List<Aircraft> fleet)
        {
            Planes = fleet;
            InitializeComponent();
            RefreshList();
            ClearFields();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string manufacturer = cboxManufacturer.Text;
            string model = cboxModel.Text;
            if (cboxManufacturer.SelectedIndex != -1)
            {
                if (cboxModel.SelectedIndex != -1)
                {
                    if (!(string.IsNullOrWhiteSpace(tbSeats.Text)))
                    {
                        Planes.Add(new Aircraft { AircraftID = NextNumber(), Manufacturer = manufacturer, Model = model, TotalSeats = Convert.ToInt16(tbSeats.Text) });
                        RefreshList();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("A plane without seats?!\n Please enter the number of seats!", "Something is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                Aircraft toEdit = CheckList((Aircraft)DGVFleet.CurrentRow.DataBoundItem);

                if (toEdit != null)
                {
                    
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
                Aircraft toDelete = CheckList((Aircraft)DGVFleet.CurrentRow.DataBoundItem);
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
            }
            catch (Exception)
            {
                MessageBox.Show("You must select an aircraft", "Nothing to delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //<<<<<<<<<<<<<<<<<<<<< FUNCTIONS >>>>>>>>>>>>>>>>>>>>>
        private Aircraft CheckList(Aircraft toCheck)
        {
            Aircraft listed = new Aircraft();
            if (toCheck != null)
            {
                foreach (Aircraft item in Planes)
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
    }
}
