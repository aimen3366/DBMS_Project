using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBMS_mini
{
    public partial class StudentPortal : Form
    {

        public StudentPortal()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection();
        string str = "Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";


        public int status=5;
       

        public void display()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Student", con);
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
            this.studentTableAdapter.Fill(this.projectBDataSet.Student);

        }




        private void StudentPortal_Load(object sender, EventArgs e)
        {
            display();

        }


        int Id = 0;

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();



            //Clearing the textboxes
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";


        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from Student where Id =" + dataGridView1.Rows[Id].Cells[0].Value;

                    cmd.ExecuteNonQuery();
                    con.Close();
                    dataGridView1.Rows.RemoveAt(Id);
                    MessageBox.Show("Deleted");
                    display();

                }

            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
                MessageBox.Show("Error occurred");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try

            {
                using (SqlConnection con = new SqlConnection(str))
                {

                    string query2 = "Update Student set [FirstName]='" + textBox1.Text + "' , [LastName]='" + textBox2.Text + "' , [Contact]='" + textBox3.Text + "', [Email]='" + textBox4.Text + "', [RegistrationNumber]='" + textBox5.Text + "',Status='" + textBox5.Text + "' where Id=@id ";
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.Parameters.AddWithValue("@id", Id);
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Updated");
                }


            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
                MessageBox.Show("Error");
            }


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DashboardSystem s = new DashboardSystem();
            s.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DashboardSystem s = new DashboardSystem();
            s.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        
       
        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox4.Text == "")
                {
                    MessageBox.Show("All fields required");
                }
                else
                {


                    string str = "Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
                    using (SqlConnection con = new SqlConnection(str))
                    {
                        con.Open();


                        if (comboBox1.SelectedValue == "Inactive")
                        {
                            status = 6;
                        }


                        else
                        {
                            string reguni = "SELECT RegistrationNumber FROM Student";
                            SqlCommand cmd = new SqlCommand(reguni, con);
                            var reader = cmd.ExecuteReader();
                            bool ss = true;
                            while (reader.Read())
                            {
                                if (reader[0].ToString() == textBox5.Text)
                                {
                                    ss = false;
                                }
                            }
                            if (ss == false)
                            {
                                MessageBox.Show("Roll number already exists");
                            }
                            reader.Close();
                            if (ss == true)
                            {
                                string queryaddastudent = "INSERT INTO Student(FirstName,LastName,Contact,Email,RegistrationNumber,Status) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + status + "')";
                                SqlCommand comd = new SqlCommand(queryaddastudent, con);
                                comd.ExecuteNonQuery();
                                MessageBox.Show("Added and Saved Student");

                                //Claering the boxes
                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox4.Text = "";
                                textBox5.Text = "";
                            }
                            display();
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
                MessageBox.Show("Error occurred");
            }
        }

        private void linkLabel1_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DashboardSystem s = new DashboardSystem();
            s.Show();
            this.Hide();
        }
    }
}


