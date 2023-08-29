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
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\CarRentalDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string query = "select count(*) from UserTbl where Uname ='" + Uname.Text + "' and  Upass='" + pword.Text + "'";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable(); 
            sda.Fill(dt);   
            if (dt.Rows[0][0].ToString()== "1")
            {
                MainForm mainForm= new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Uname.Text = "";
            pword.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Uname_TextChanged(object sender, EventArgs e)
        {

        }

        private void pword_TextChanged(object sender, EventArgs e)
        {

        }
    }
   }


