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

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public string strr;
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

            // TODO: 這行程式碼會將資料載入 'dataDataSet.personal' 資料表。您可以視需要進行移動或移除。
            this.personalTableAdapter.Fill(this.dataDataSet.personal);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gapwai\source\repos\WindowsFormsApp1\WindowsFormsApp1\Data.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select 床號,名子,性別,身份証 From [dbo].[personal]  where 名子 like '" + textBox1.Text + "%' or 身份証 like '" + textBox1.Text + "% '", con);
            DataTable di = new DataTable();
            sda.Fill(di);

            dataGridView1.Rows.Clear();

            foreach (DataRow item in di.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();

            }
        }

        void mouseclick()
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gapwai\source\repos\WindowsFormsApp1\WindowsFormsApp1\Data.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda1 = new SqlDataAdapter("Select 名子,性別,床號,電話,國籍,出生日期,緊急電話,地址 From [dbo].[personal]  where 身份証 = '" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "'", con1);
            DataTable dl = new DataTable();
            sda1.Fill(dl);
            textBox6.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();

            textBox6.Text = dl.Rows[0].ToString();
            textBox10.Text = dl.Rows[0][1].ToString();
            if (dl.Rows[0][2] != null)
            {
                textBox9.Text = dl.Rows[0][2].ToString();
            }
            if (dl.Rows[0][3] != null)
            {
                textBox2.Text = dl.Rows[0][3].ToString();
            }
            if (dl.Rows[0][4] != null)
            {
                textBox3.Text = dl.Rows[0][4].ToString();
            }


            dateTimePicker1.Text = dl.Rows[0][5].ToString();
            if (dl.Rows[0][6] != null)
            {
                textBox5.Text = dl.Rows[0][6].ToString();
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
