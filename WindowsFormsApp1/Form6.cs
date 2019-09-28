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
using System.IO;
using System.Drawing.Imaging;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    
    public partial class Form6 : Form
    {
        public string strr;
        public Form6()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
            MySqlConnection con1 = new MySqlConnection(connectionStr);
            MySqlDataAdapter sda1 = new MySqlDataAdapter("Select 名子,身份証 From `personal`  where 身份証 = '" + textBox1.Text + "'", con1);
            DataTable dl = new DataTable();
            sda1.Fill(dl);
            textBox4.Text = dl.Rows[0][0].ToString();
            textBox6.Text = dl.Rows[0][1].ToString();
            MySqlConnection con = new MySqlConnection(connectionStr);
            MySqlDataAdapter sda = new MySqlDataAdapter("select 人物,`日期`,收縮壓,舒張壓 from bloodp where 身份証='" + textBox1.Text + "' and `日期`>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and `日期`<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'", con);
            DataTable di = new DataTable();
            sda.Fill(di);
            dataGridView1.Rows.Clear();
            dataGridView1.Columns["日期"].DefaultCellStyle.Format = "yyyy-MM-dd";
            foreach (DataRow item in di.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Columns["日期"].DefaultCellStyle.Format = "MM/dd/yyyy";
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                string st = item[1].ToString();
                dataGridView1.Rows[n].Cells[1].Value = st.Substring(0,10);
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
            }
        }
    }
}
