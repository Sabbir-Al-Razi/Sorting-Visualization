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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sorting_algoDataSet.register' table. You can move, or remove it, as needed.
            this.registerTableAdapter.Fill(this.sorting_algoDataSet.register);
            this.registerTableAdapter.Fill(this.sorting_algoDataSet.register);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=SABBIR;Initial Catalog=sorting_algo;Integrated Security=True;");
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                String str = "update register set approve  ='" + comboBox1.Text + "'where id='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                Admin_Load(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 fm = new Form2();
            fm.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
