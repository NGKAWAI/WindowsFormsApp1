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
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
            MySqlConnection con = new MySqlConnection(connectionStr);
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT Count(*) FROM `table`where id='" + textBox1.Text + "' and pw = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                string name = textBox1.Text;
                string totalstring =  name;
                main ss = new main();
                ss.strr = totalstring;
                this.Hide();

                ss.Show();
            }
            else
            {
                MessageBox.Show("please Check you Username and Password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string totalstring = name;
            Form8 ss = new Form8();
            ss.strr = totalstring;
            this.Hide();

            ss.Show();
        }
    }
}
