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
    public partial class Rubric : Form
    {
        
        public Rubric(int r)
        {
            InitializeComponent();
            
            
        }
        
        SqlConnection con = new SqlConnection(@"Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");
        string str = "Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";

        
        private void Rubric_Load(object sender, EventArgs e)
        {
            Fill();
            display();
            this.rubricTableAdapter.Fill(this.projectBDataSet.Rubric);
            Fill();
          

        }

        SqlCommand cmd;
        public void Fill()
        {
            using (SqlDataAdapter s = new SqlDataAdapter("SELECT Id,Name FROM Clo", con))
            {
                DataTable tbl = new DataTable();
                s.Fill(tbl);
                comboBox2.DataSource = tbl;
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text != "" && richTextBox1.Text != "")
                {
                    con.Open();
                    string query = "INSERT INTO Rubric(Details, CloId) VALUES ('" + richTextBox1.Text + "',(select Id from Clo where Id='" + comboBox2.SelectedValue + "'))";
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DashboardSystem s = new DashboardSystem();
            s.Show();
            this.Hide();
        }
        public void display()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Rubric", con);
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DashboardSystem s = new DashboardSystem();
            s.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DashboardSystem s = new DashboardSystem();
            s.Show();
            this.Hide();
        }
        int Id = 0;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());



       
           

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Rubric where Id =" + dataGridView1.Rows[Id].Cells[0].Value;

            cmd.ExecuteNonQuery();
            con.Close();
            dataGridView1.Rows.RemoveAt(Id);
            MessageBox.Show("Deleted");
            display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id_v = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            try
            {


                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    string query1 = "Select * from Rubric where CloId = '" + id_v + "'";
                    SqlCommand command = new SqlCommand(query1, con);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var rubric_id = Convert.ToInt32(reader["Id"]);

                            try
                            {
                                using (SqlConnection conn = new SqlConnection(str))
                                {


                                    conn.Open();
                                    SqlCommand cmd = conn.CreateCommand();
                                    cmd.CommandType = CommandType.Text;

                                    cmd.CommandText = "delete from AssessmentComponent where RubricId = '" + rubric_id + "'";
                                    cmd.ExecuteNonQuery();
                                    conn.Close();


                                }
                            }
                            catch (System.Data.SqlClient.SqlException sqlException)
                            {
                                System.Windows.Forms.MessageBox.Show(sqlException.Message);
                                MessageBox.Show("Error occurred");
                            }

                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
                MessageBox.Show("Error occurred");
            }

            try
            {

                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    string query1 = "Select * from Rubric where CloId = '" + id_v + "'";
                    SqlCommand command = new SqlCommand(query1, con);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var rubric_id = Convert.ToInt32(reader["Id"]);

                            try
                            {
                                using (SqlConnection conn = new SqlConnection(str))
                                {

                                    conn.Open();
                                    SqlCommand cmd = conn.CreateCommand();
                                    cmd.CommandType = CommandType.Text;

                                    cmd.CommandText = "delete from RubricLevel where RubricId = '" + rubric_id + "'";
                                    cmd.ExecuteNonQuery();
                                    conn.Close();


                                }
                            }
                            catch (System.Data.SqlClient.SqlException sqlException)
                            {
                                System.Windows.Forms.MessageBox.Show(sqlException.Message);
                                MessageBox.Show("Error occurred");
                            }
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
                MessageBox.Show("Error occurred");
            }







            try
            {

                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "delete from Rubric where CloId='" + id_v + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();


                }
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
                MessageBox.Show("Error occurred");
            }


            try
            {

                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from Clo where Id='" + id_v + "' ";

                    cmd.ExecuteNonQuery();
                    con.Close();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Clo", con);
                    DataTable tbl = new DataTable();
                    da.Fill(tbl);
                    dataGridView1.DataSource = tbl;

                }
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
                MessageBox.Show("Error occurred");
            }

            MessageBox.Show("Deleted");

        }

        private void linkLabel1_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DashboardSystem s = new DashboardSystem();
            s.Show();
            this.Hide();
        }
    }
    }

