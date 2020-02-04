using System;
using System.Windows.Forms;
using ClassLibrary;
using System.Collections.Generic;

namespace AdminPanel
{
    public partial class FrontForm : Form
    {
        
        public FrontForm()
        {
            InitializeComponent();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            MainForm Menu = new MainForm(this);
            Menu.Show();
            this.Visible = false;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutUs peca = new AboutUs();
            peca.Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            ClientServices Form = new ClientServices(this);
            Form.Show();
            this.Visible = false;
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            ToolTip exit = new ToolTip();
            exit.SetToolTip(btnExit, "Please don't go yet!");
        }

        private void btnAbout_MouseHover(object sender, EventArgs e)
        {
            ToolTip about = new ToolTip();
            about.SetToolTip(btnAbout, "I've made this!");
        }
    }
}
