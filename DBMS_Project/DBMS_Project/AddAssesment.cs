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

namespace DBMS_mini
{
    public partial class AddAssesment : Form
    {
        public AddAssesment()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");
        string str = "Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddAssesment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.Assessment' table. You can move, or remove it, as needed.
            this.assessmentTableAdapter.Fill(this.projectBDataSet.Assessment);

        }


        public void display()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Assessment", con);
                    DataTable tbl = new DataTable();
                    da.Fill(tbl);
                    dataGridView1.DataSource = tbl;

                }

            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
                MessageBox.Show("Error occurred");
            }// TODO: This line of code loads data into the 'projectBDataSet.Student' table. 


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(str))
                {

                    con.Open();
                    string query = "INSERT INTO Assessment(Title,DateCreated,TotalMarks,TotalWeightage) VALUES ('" + textBox1.Text.ToString() + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Added and Saved");
                    display();
                }
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
                MessageBox.Show("Error");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DashboardSystem s = new DashboardSystem();
            s.Show();
            this.Hide();
        }
    }
}
