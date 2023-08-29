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
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace CarRentalManagementSystem
{
    public partial class Rental : Form
    {
        public Rental()
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

       /* private  void UpdateonRent()
        {

            con.Open();
            string query = "update CarTbl set Available = '"+"Yes"+"' where RegNum ='" + CarRegCb.SelectedValue.ToString() + "';";   

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
           // MessageBox.Show("Car Successfully Updated");
            con.Close();
            populate();

        }*/

        private void fillcombo()
            {
                con.Open();
            string query = "select  RegNum from CarTbl where Available = '"+"Yes"+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr;
            rdr= cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RegNum", typeof(string));
            dt.Load(rdr);
            CarRegCb.ValueMember = "RegNum";
            CarRegCb.DataSource = dt;
            con.Close();
            }

        private void fillCustomer()
        {
            con.Open();
            string query = "select CustId from CustomerTbl";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(int));
            dt.Load(rdr);
            CustIdCb.ValueMember = "CustId";
            CustIdCb.DataSource = dt;
            con.Close();
        }

        private void UpdateOnRent()
        {
                con.Open();
                string query = "update CarTbl set Available='" +" No" + "' where RegNum ='" + CarRegCb.SelectedValue.ToString() + "';";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Car Successfully Updated");
                con.Close();
                populate();

        }

        private void UpdateOnRentDelete()
        {
            con.Open();
            string query = "update CarTbl set Available='" + " Yes" + "' where RegNum ='" + CarRegCb.SelectedValue.ToString() + "';";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Car Successfully Updated");
            con.Close();
            populate();

        }

        private void Rental_Load(object sender, EventArgs e)
        {
            fillcombo();
            fillCustomer();
            populate();  
        }

        private void RentalDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CarIdTb.Text = RentalDGV.SelectedRows[0].Cells[0].Value.ToString();
            CarRegCb.SelectedValue=RentalDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustNameTb.Text = RentalDGV.SelectedRows[0].Cells[2].Value.ToString();
            CostTb.Text = RentalDGV.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void CarRegCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fetchCustName()
        {
            con.Open();
            string query = "select * from CustomerTbl where CustId = " + CustIdCb.SelectedValue.ToString() + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows) 
            { 
                CustNameTb.Text = dr["CustName"].ToString();
            }
            con .Close();   
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (CarIdTb.Text == "" || CustNameTb.Text == "" || CostTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into RentalTbl values(" + CarIdTb.Text + " ,'" + CarRegCb.SelectedValue.ToString() + "','" + CustNameTb.Text + "','" + RentDate.Value.ToShortDateString() + "','" + RentDate.Value.ToShortDateString() + "','" + CostTb.Text + "')";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Successfully Rented");
                    con.Close();
                    UpdateOnRent();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }
        private void CarRegCb_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void CustIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        private void CustIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCustName();
        }

        

        private void CostTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void RentDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CarIdTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from RentalTbl where RentId =" + CarIdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rental deleted Successfully");
                    con.Close();
                    UpdateOnRentDelete();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

