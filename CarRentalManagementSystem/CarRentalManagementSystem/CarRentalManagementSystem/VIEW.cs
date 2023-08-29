using Bunifu.UI.WinForms.Helpers.Transitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CarRentalManagementSystem
{
    public partial class VIEW : Form
    {
        public VIEW()
        {
            InitializeComponent();
        }

        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            MyProgress.Value= startpoint;
            Percentage.Text = "" + startpoint;
            if (MyProgress.Value == 100) 
            {
                MyProgress.Value = 0;
                timer1.Stop();
                LOGIN log = new LOGIN();
                log.Show();
                this.Hide();
            }
        }
        private void viewpic_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void VIEW_Load(object sender, EventArgs e)
        {

        }
    }

}