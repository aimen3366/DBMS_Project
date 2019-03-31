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
    public partial class StudentEvalutions : Form
    {
        public StudentEvalutions()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");
        string str = "Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";

        public void Fill()
        {
            using (SqlDataAdapter s = new SqlDataAdapter("SELECT Id,Id FROM Student", con))
            {
                DataTable tbl = new DataTable();
                s.Fill(tbl);
                comboBox1.DataSource = tbl;
                comboBox1.DisplayMember = "Id";
                comboBox1.ValueMember = "Id";
            }

            using (SqlDataAdapter s = new SqlDataAdapter("SELECT Id,Name FROM AssessmentComponent", con))
            {
                DataTable tbl = new DataTable();
                s.Fill(tbl);
                comboBox2.DataSource = tbl;
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
            }

            using (SqlDataAdapter s = new SqlDataAdapter("SELECT Id,MeasurementLevel FROM RubricLevel", con))
            {
                DataTable tbl = new DataTable();
                s.Fill(tbl);
                comboBox3.DataSource = tbl;
                comboBox3.DisplayMember = "RubricMeasurementId";
                comboBox3.ValueMember = "Id";
            }
        }

        public void Calculations()
        {
            int totalmarks=0;
            string sql = "Select TotalMarks, from AssessmentComponent where Name='" + comboBox2.SelectedValue + "')";

            
                
                using (SqlConnection conn = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    
                    try
                    {
                        conn.Open();
                        totalmarks = (int)cmd.ExecuteScalar();
                    MessageBox.Show(Convert.ToString(totalmarks));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StudentEvalutions_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculations();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DashboardSystem s = new DashboardSystem();
            s.Show();
            this.Hide();
        }
    }
}
