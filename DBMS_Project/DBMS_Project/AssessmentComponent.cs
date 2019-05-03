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
    public partial class AssessmentComponent : Form
    {
        public AssessmentComponent()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");
        string str = "Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";

        private void AssessmentComponent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.AssessmentComponent' table. You can move, or remove it, as needed.
           

            display();
            this.assessmentComponentTableAdapter.Fill(this.projectBDataSet.AssessmentComponent);
            Fill();

        }

        public void display()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from AssessmentComponent", con);
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

        public void Fill()
        {
            using (SqlDataAdapter s = new SqlDataAdapter("SELECT Id,Details FROM Rubric", con))
            {
                DataTable tbl = new DataTable();
                s.Fill(tbl);
                comboBox2.DataSource = tbl;
                comboBox2.DisplayMember = "Details";
                comboBox2.ValueMember = "Id";
            }

            using (SqlDataAdapter s = new SqlDataAdapter("SELECT Id,Title FROM Assessment", con))
            {
                DataTable tbl = new DataTable();
                s.Fill(tbl);
                comboBox1.DataSource = tbl;
                comboBox1.DisplayMember = "Title";
                comboBox1.ValueMember = "Id";
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(str))
                {

                    con.Open();
                    string query = "INSERT INTO AssessmentComponent(Name,RubricId,TotalMarks,DateCreated,DateUpdated,AssessmentId) VALUES ('" + textBox1.Text.ToString() + "',(select Id from Rubric where Id='" + comboBox2.SelectedValue + "'),'"+textBox3.Text+"','" + DateTime.Now.ToString("MM/dd/yyyy") + "','"+DateTime.Now.ToString("MM/dd/yyyy")+"','" + comboBox1.SelectedValue + "')";
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
