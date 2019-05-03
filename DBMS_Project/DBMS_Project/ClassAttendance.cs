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
    public partial class ClassAttendance : Form
    {
        public ClassAttendance()
        {
            InitializeComponent();
        }
        string str = "Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
        SqlConnection con = new SqlConnection();
        public void disp()
        {

            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from ClassAttendance", con);
                DataTable tbl = new DataTable();
                da.Fill(tbl);
                dataGridView1.DataSource = tbl;

            }
        }

        private void ClassAttendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.ClassAttendance' table. You can move, or remove it, as needed.
            this.classAttendanceTableAdapter.Fill(this.projectBDataSet.ClassAttendance);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    string query = "INSERT INTO ClassAttendance(AttendanceDate) VALUES ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy")+ "')";
                    SqlCommand cmd = new SqlCommand(query, con);                  
                    cmd.ExecuteNonQuery();
                    con.Close();
                    dateTimePicker1.Text = "";
                    disp();
                   
                }
            }

            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
                MessageBox.Show("Error occurred");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
