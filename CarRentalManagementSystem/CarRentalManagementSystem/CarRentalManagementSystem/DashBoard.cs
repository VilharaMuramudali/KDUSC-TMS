using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarRentalManagementSystem
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\CarRentalDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            string querycar = "select Count (*) from CarTbl";
            SqlDataAdapter sda = new SqlDataAdapter(querycar,con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            carlbl.Text= dt.Rows[0][0].ToString();

            string querycus = "select Count (*) from CustomerTbl";
            SqlDataAdapter sda1 = new SqlDataAdapter(querycus, con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            customerlbl.Text = dt1.Rows[0][0].ToString();

            string queryuser = "select Count (*) from UserTbl";
            SqlDataAdapter sda2 = new SqlDataAdapter(queryuser, con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            userlbl.Text = dt2.Rows[0][0].ToString();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
    }
}
