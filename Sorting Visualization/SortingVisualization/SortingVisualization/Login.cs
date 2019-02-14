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

namespace SortingVisualization
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=SABBIR;Initial Catalog=sorting_algo;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*)From register where username='" + textBox1.Text + "' and pass='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                string x;
                //SqlDataAdapter s = new SqlDataAdapter("Select approve From register where username='" + textBox1.Text + "' and pass='" + textBox2.Text + "'", con);
                //DataTable d = new DataTable();
                //s.Fill(d);
                con.Open();
                string s = "Select approve From register where username='" + textBox1.Text + "' and pass='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(s, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    x = (dr["approve"].ToString());
                   // MessageBox.Show(x);
                    //}
                    //if (dt.Rows[0][0].ToString() == "1")
                    //{
                    //    SqlDataAdapter sd = new SqlDataAdapter("Select approve from register where id=dt.Rows[0][0] and approve = 'True'", con);
                    //    DataTable da = new DataTable();
                    //    sda.Fill(da);
                    //    if (da.Rows[0][0].ToString() == "1")
                    //    {
                    if (x == "True")
                    {
                        this.Hide();
                        Form2 lgn = new Form2();
                        lgn.Show();
                    }
                    else
                        MessageBox.Show("You need approval from Admin!!");
                }
                else
                    MessageBox.Show("data base error");
            }
            else if (textBox1.Text == "Admin" && textBox2.Text == "AIUB")
            {
                this.Hide();
                Admin lgn = new Admin();
                MessageBox.Show("You have logged in as Admin");
                lgn.Show();
            }
            else
            {
                MessageBox.Show("Please check Your Username and password");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp fm = new SignUp();
            fm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
