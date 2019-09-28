using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
   
    public partial class Form5 : Form
    {
        public string strr;
        public Form5()
        {
            InitializeComponent();
        }

        void mouseclick()
        {
            string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
            MySqlConnection con1 = new MySqlConnection(connectionStr);
            con1.Open();
            MySqlDataAdapter sda1 = new MySqlDataAdapter("Select 名子,性別,床號,電話,國籍,出生日期,緊急電話,地址,身份証 From `personal`  where 身份証 = '" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "'", con1);
            DataTable dl = new DataTable();
            sda1.Fill(dl);
            textBox6.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox7.Clear();
            pictureBox1.Image = null;
            pictureBox1.Refresh();

            textBox6.Text = dl.Rows[0][0].ToString();
            textBox10.Text = dl.Rows[0][1].ToString();
            if (dl.Rows[0][8] != null)
            {
                textBox4.Text = dl.Rows[0][8].ToString();
            }
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
            if (dl.Rows[0][7] != null)
            {
                textBox7.Text = dl.Rows[0][7].ToString();
            }
            string sql2 = "select count(*) from `MySchool` where BLOBData is not NULL and BLODID=" + dl.Rows[0][8].ToString() + " ";
            MySqlDataAdapter sqlct = new MySqlDataAdapter(sql2, con1);
            DataTable dt3 = new DataTable();
            sqlct.Fill(dt3);
            if (dt3.Rows[0][0].ToString() == "1")
            {
                string sql1 = "select BLODID,BLOBData from `MySchool` where BLODID=" + dl.Rows[0][8].ToString() + " ";
                MySqlCommand command1 = new MySqlCommand(sql1, con1);
                //建立DataAdapter物件
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command1);
                //建立DataSet物件
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "BLOBTest");
                int c = dataSet.Tables["BLOBTest"].Rows.Count;
                //12634697 12358523
                if (c > 0)
                {
                    Byte[] mybyte2 = new byte[0];
                    mybyte2 = (Byte[])(dataSet.Tables["BLOBTest"].Rows[c - 1]["BLOBData"]);
                    MemoryStream ms = new MemoryStream(mybyte2);
                    pictureBox1.Image = Image.FromStream(ms);
                    con1.Close();
                }
            }
            con1.Close();

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
            MySqlConnection con = new MySqlConnection(connectionStr);

            MySqlDataAdapter sda = new MySqlDataAdapter("Select 床號,名子,性別,身份証 From `personal`  where 名子 like '" + textBox1.Text + "%' or 身份証 like '" + textBox1.Text + "% '", con);
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

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
            MySqlConnection con = new MySqlConnection(connectionStr);

            con.Open();
            if (textBox4.Text == "")
            {
                MessageBox.Show("請先請詢"); 
            }
            else
            {
                string sql2 = "INSERT INTO `outside`(名子,性別,出生日期,身份証,電話,國籍,緊急電話,地址,經手人)" +
                       " VALUES (N'" + textBox6.Text + "',N'" + textBox10.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + textBox4.Text + "','" + textBox2.Text + "',N'" + textBox3.Text + "','" + textBox5.Text + "',N'" + textBox7.Text+ "','" + strr + "')";
                //string sql = "UPDATE `personal` Set 名子='" + textBox6.Text + "',性別='" + textBox10.Text + "',電話='" + textBox2.Text + "',國籍='" + textBox3.Text + "',出生日期='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',緊急電話='" + textBox5.Text + "',地址='" + textBox7.Text + "',經手人='" + strr + "' where `身份証` = '" + textBox4.Text + "'";
                string sqldel = "DELETE FROM `personal` WHERE 身份証=" + textBox4.Text + " ";
                string sqldel2 = "DELETE FROM `myshool` WHERE 身份証=" + textBox4.Text + " ";
                MySqlCommand cmd = new MySqlCommand(sql2, con);
                MySqlCommand cmd2 = new MySqlCommand(sqldel, con);
                MySqlCommand cmd3 = new MySqlCommand(sqldel2, con);
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                MessageBox.Show("病人"+ textBox6.Text + "已經出院");
                textBox6.Clear();
                textBox10.Clear();
                textBox9.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                textBox4.Clear();
                textBox7.Clear();
            }
            con.Close();
        }
    }
}
