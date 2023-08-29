using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalManagementSystem
{
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\CarRentalDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            con.Open();
            string query = "select * from RentalTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RentalDGV.DataSource = ds.Tables[0];
            con.Close();

        }
        private void populateReturn()
        {
            con.Open();
            string query = "select * from ReturnTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ReturnDGv.DataSource = ds.Tables[0];
            con.Close();

        }
        private void ReturnDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CarRegTb.Text = RentalDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustNameTb.Text = RentalDGV.SelectedRows[0].Cells[2].Value.ToString();
            ReturnDate.Text = RentalDGV.SelectedRows[0].Cells[4].Value.ToString();
            DateTime d1 = ReturnDate.Value.Date;
            DateTime d2 = DateTime.Now;
            TimeSpan t = d2 - d1;
            int NoOfDays = Convert.ToInt32(t.TotalDays);
            if (NoOfDays <= 0)
            {
                DelayTb.Text = "No Delay";
                FineTb.Text = "0";
            }else
            {
                DelayTb.Text = "" +NoOfDays;
                FineTb.Text = "" + (NoOfDays *500);
            }
        }   

        private  void DeleteOnReturn()
        {
            int rentId;
            rentId = Convert.ToInt32(RentalDGV.SelectedRows[0].Cells[0].Value.ToString());
            con.Open();
            string query = "delete from RentalTbl where RentId =" + rentId + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Rental deleted Successfully");
            con.Close();
            //UpdateOnRentDelete();
            populate();
        }

        private void Return_Load(object sender, EventArgs e)
        {
            populate();
            populateReturn();
        }

        private void ReternedDGv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (CarIdTb.Text == "" || CustNameTb.Text == "" || FineTb.Text == "" || DelayTb.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into ReturnTbl values(" + CarIdTb.Text + " ,'" + CarRegTb.Text + "','" + CustNameTb.Text + "','" + ReturnDate.Value.ToShortDateString()+ "','" +FineTb.Text + "')";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Successfully Returned");
                    con.Close();
                    populateReturn();
                    populate();
                    DeleteOnReturn();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void CarRegTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
