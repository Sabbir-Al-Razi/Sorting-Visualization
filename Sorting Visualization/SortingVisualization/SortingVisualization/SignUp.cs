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
    public partial class SignUp : Form
    {
        int f = 0;
        int counter = 0;
        int nam = 0;
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                if (label7.Visible == true || label8.Visible == true || label11.Visible==true || label12.Visible==true)
                {
                    label7.Visible = false;
                    label8.Visible = false;
                    label11.Visible = false;
                    label12.Visible = false;
                }

                if (textBox4.Text.Contains("@") && textBox4.Text.Contains(".com") )
                {
                    if(f==0){
                        if (counter == 0)
                        {
                            user_Name();
                            if (nam == 0)
                            {

                                if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && textBox4.Text != null && textBox5.Text != null)
                                {
                                    if (textBox2.Text == textBox3.Text)
                                    {
                                        SqlConnection con = new SqlConnection(@"Data Source=SABBIR;Initial Catalog=sorting_algo;Integrated Security=True;");
                                        con.Open();
                                        if (con.State == ConnectionState.Open)
                                        {
                                            String str = "insert into register(username,pass,confirm_pass,email,phone,approve) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','False')";
                                            SqlCommand cmd = new SqlCommand(str, con);
                                            cmd.ExecuteNonQuery();
                                            this.Hide();
                                            Login lgn = new Login();
                                            lgn.Show();
                                        }
                                    }
                                }
                                else
                                {
                                    label6.Show();
                                    label6.Text = "Password doesn't match";

                                }
                            }
                            else label12.Visible = true;
                        }
                        else
                            label11.Visible = true;
                    }
                    else
                    
                        MessageBox.Show("check phone number!");
                    //    //label8.Visible = true;

                    //}
                }
                else
                {
                    //MessageBox.Show("Enter all required DATA !!!");
                    label8.Visible = true;

                }
            }
            else
            {
                label7.Visible = true;
            }

            //SqlDataAdapter sda = new SqlDataAdapter("Insert INTO  Table1(uname,pass,email,phone) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", con);
            //// DataTable dt = new DataTable();
            ////  sda.Fill(dt);
            //// if (dt.Rows[0][0].ToString() == "1")
            //// {
            //this.Hide();
            //Login ss = new Login();
            //ss.Show();
            //// }
            ////else
            ////{
            ////  MessageBox.Show("Please fill up the filled");
            ////}
          
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            label6.Hide();
            groupBox1.Hide();
            //label7.Hide();
           // label8.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login lgn = new Login();
            lgn.Show();
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            label9.Text = " 1.Must Have one Capital letter\n 2.Must Have one Small letter\n 3.Must Have one Digit\n 4.Must Have exact 8 Characters";
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }
        public void phone_chek()
        {
            String x = textBox5.Text;
            //int f = 0;
            if (x.Length == 11)
            {
                for (int i = 0; i < 11; i++)
                {
                    if (x[i] == '0' || x[i] == '1' || x[i] == '2' || x[i] == '3' || x[i] == '4' || x[i] == '5' || x[i] == '6' || x[i] == '7' || x[i] == '8' || x[i] == '9')
                    {
                        f = 0;
                    }
                    else f = 1;
                }
            }
            else f = 1;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            phone_chek();
            if (f == 0)
                label10.Visible = false;
            else label10.Visible = true;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string p = textBox2.Text;
            int a=0,b=0,c=0;
            if (p.Length == 8)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (char.IsUpper(p[i]))
                        a++;
                    else if (char.IsLower(p[i]))
                        b++;
                    else if (char.IsDigit(p[i]))
                        c++;

                }
                if (a >= 1 && b >= 1 && c >= 1)
                {
                    counter = 0;
                    label11.Visible = false;
                }
            }
            else
            {
                counter = 1;
                label11.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=SABBIR;Initial Catalog=sorting_algo;Integrated Security=True;");
            //con.Open();
            //if (con.State == ConnectionState.Open)
            //{
            //    SqlDataAdapter sd = new SqlDataAdapter("Select username from register where username='"+textBox1.Text+"'", con);
            //        DataTable da = new DataTable();
            //        sd.Fill(da);
            //        if (da.Rows[0][0].ToString() != "1")
            //        {
            //            nam = 1;
            //            label12.Visible = true;
            //        }
            //        else
            //        {
            //            nam = 0;
            //            label12.Visible = false;
            //        }
            //}
        }
        public void user_Name()
        {
            SqlConnection con = new SqlConnection(@"Data Source=SABBIR;Initial Catalog=sorting_algo;Integrated Security=True;");
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                SqlDataAdapter sd = new SqlDataAdapter("Select username from register where username='" + textBox1.Text + "'", con);
                DataTable da = new DataTable();
                sd.Fill(da);
                
                if (da.Rows.Count == 0)
                {
                    nam = 0;
                    label12.Visible = false;
                }
                else
                {
                   
                    nam = 1;
                    label12.Visible = true;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
