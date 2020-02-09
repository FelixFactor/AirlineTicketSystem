using System;
using System.Windows.Forms;

namespace AdminPanel
{
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();
            lblVersion.Text = $"version: {ProductVersion}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
