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
    public partial class StudentAttendance : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");
        string str = "Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
        public StudentAttendance()
        {
            InitializeComponent();
            
        }
        

        private void StudentAttendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.StudentAttendance' table. You can move, or remove it, as needed.
            this.studentAttendanceTableAdapter.Fill(this.projectBDataSet.StudentAttendance);
            FillData();

        }

        public void FillData()
        {
            using (SqlDataAdapter s = new SqlDataAdapter("SELECT Id,AttendanceDate FROM ClassAttendance", con))
            {
                DataTable tbl = new DataTable();
                s.Fill(tbl);
                comboBox1.DataSource = tbl;
                comboBox1.DisplayMember = "AttendanceDate";
                comboBox1.ValueMember = "Id";
            }

            using (SqlDataAdapter s = new SqlDataAdapter("SELECT Id, FROM Student", con))
            {
                DataTable tbl = new DataTable();
                s.Fill(tbl);
                comboBox2.DataSource = tbl;
                comboBox2.DisplayMember = "FirstName";
                comboBox2.ValueMember = "Id";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int status = 5;
            if (comboBox3.Text == "Inctive")
            {
                status = 6;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();


                    string query = "INSERT INTO StudentAttendance(AttendanceId,StudentId,AttendanceStatus) VALUES ((select Id from ClassAttendance where Id='"+comboBox1.SelectedValue+"'), (select StudentId from StudentAttendance where StudentId='" + comboBox2.SelectedValue + "'),'" + status + "')";
                  
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    comboBox3.Text = "";

                }
            }

            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
                MessageBox.Show("Error occurred");
            }
        }

        public void display()
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DashboardSystem s = new DashboardSystem();
            s.Show();
            this.Hide();
        }
    }
}

