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
    public partial class Rubriclevel : Form
    {
        public Rubriclevel()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text != "" && richTextBox1.Text != "")
                {
                    con.Open();
                    string query = "INSERT INTO RubricLevel(Details, RubricId,MeasurementLevel) VALUES ('" + richTextBox1.Text + "',(select Id from Rubric where Id='" + comboBox2.SelectedValue + "'),'" + textBox1.Text + "' )";
                    SqlDataAdapter CCmd = new SqlDataAdapter(query, con);

                    CCmd.SelectCommand.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("Addition of Rubric Successful!");
                }
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
                MessageBox.Show("Error");
            }
            display();
        }

        SqlConnection con = new SqlConnection(@"Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");
        string str = "Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";

        private void Rubriclevel_Load(object sender, EventArgs e)
        {
            
            display();
            this.rubricLevelTableAdapter.Fill(this.projectBDataSet.RubricLevel);
            Fill();
        }

        public void Fill()
        {
            using (SqlDataAdapter s = new SqlDataAdapter("SELECT Id,Id FROM Rubric", con))
            {
                DataTable tbl = new DataTable();
                s.Fill(tbl);
                comboBox2.DataSource = tbl;
                comboBox2.DisplayMember = "Id";
                comboBox2.ValueMember = "Id";
            }


        }

        public void display()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from RubricLevel", con);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DashboardSystem s = new DashboardSystem();
            s.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
