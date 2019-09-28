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
    public partial class Form7 : Form
    {
        public string strr;
        public Form7()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void update() {
            string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
            MySqlConnection con = new MySqlConnection(connectionStr);
            MySqlDataAdapter sda = new MySqlDataAdapter("Select 藥物品稱, 劑量,次數,時間or方法,開始時間, 結束日期,id From `drug`  where  身份証 = '" + textBox4.Text + "'", con);
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
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();

            }
        }
        void mouseclick()
        {
            string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
            MySqlConnection con1 = new MySqlConnection(connectionStr);
            con1.Open();
            MySqlDataAdapter sda1 = new MySqlDataAdapter("Select 藥物品稱, 劑量,次數,時間or方法,開始時間, 結束日期,id From `drug`  where  id ='"+ dataGridView1.CurrentRow.Cells[6].Value.ToString() + "' and  身份証 = '" + textBox4.Text + "'", con1);
            DataTable dll = new DataTable();
            sda1.Fill(dll);
            textBox8.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox11.Clear();
            label19.Text = "";
            if (dll.Rows[0][0] != null)
            {
                textBox8.Text = dll.Rows[0][0].ToString();
            }
            if (dll.Rows[0][1] != null)
            {
                textBox13.Text = dll.Rows[0][1].ToString();
            }
            if (dll.Rows[0][2] != null)
            {
                textBox14.Text = dll.Rows[0][2].ToString();
            }
            if (dll.Rows[0][3] != null)
            {
                textBox11.Text = dll.Rows[0][3].ToString();
            }
            dateTimePicker2.Text = dll.Rows[0][4].ToString();
            dateTimePicker3.Text = dll.Rows[0][5].ToString();
            label19.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            button3.Text = "Update";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
            MySqlConnection con = new MySqlConnection(connectionStr);
            MySqlDataAdapter sda1 = new MySqlDataAdapter("Select count(*) From `personal`  where " + comboBox1.Text + " like '" + textBox1.Text + "%'", con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("Select 名子,性別,床號,電話,國籍,出生日期,緊急電話,地址,身份証 From `personal`  where " + comboBox1.Text + " like '" + textBox1.Text + "%'", con);
                DataTable dl = new DataTable();
                con.Open();
                sda.Fill(dl);
                textBox6.Clear();
                textBox7.Clear();
                textBox10.Clear();
                textBox9.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                textBox4.Clear();
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
                MySqlDataAdapter sqlct = new MySqlDataAdapter(sql2, con);
                DataTable dt3 = new DataTable();
                sqlct.Fill(dt3);
                if (dt3.Rows[0][0].ToString() == "1")
                {
                    string sql1 = "select BLODID,BLOBData from `MySchool` where BLODID=" + dl.Rows[0][8].ToString() + " ";
                    MySqlCommand command1 = new MySqlCommand(sql1, con);
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

                    }
                    con.Close();

                }
                update();
            }
            else
            {
                MessageBox.Show("信息輸入錯誤");
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
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
                MySqlConnection con = new MySqlConnection(connectionStr);
                if (button3.Text == "save")
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string sql = "INSERT INTO `drug`(身份証, 藥物品稱, 劑量,次數,時間or方法,開始時間, 結束日期,注意事項,經手人)" +
                           " VALUES ('" + textBox4.Text + "',N'" + textBox8.Text + "',N'" + textBox13.Text + "','" + textBox14.Text + "','" + textBox11.Text + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "','" + textBox12.Text + "','" + strr + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("可以了");
                    MySqlDataAdapter sda = new MySqlDataAdapter("Select 藥物品稱, 劑量,次數,時間or方法,開始時間, 結束日期,id From `drug`  where  身份証 = '" + textBox4.Text + "'", con);
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
                        dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                        dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                        dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();

                    }
                    con.Close();
                }
                else if (button3.Text == "Update") {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    //藥物品稱, 劑量,次數,時間or方法,開始時間, 結束日期,注意事項,經手人
                    string sql = "UPDATE `drug` Set 藥物品稱='" + textBox8.Text + "',劑量='" + textBox13.Text + "',次數='" + textBox14.Text + "',時間or方法='" + textBox11.Text + "',開始時間='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "', 結束日期='" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "',注意事項='" + textBox12.Text + "',經手人='" + strr + "' where id = '" +label19.Text +"' and `身份証` = '" + textBox4.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("更改完成");
                    textBox8.Clear();
                    textBox13.Clear();
                    textBox14.Clear();
                    textBox11.Clear();
                    label19.Text = "";
                    button3.Text = "save";
                    update();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "你錯了");
            }



        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            mouseclick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox11.Clear();
            label19.Text = "";
            button3.Text = "save";
            update();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
            MySqlConnection con = new MySqlConnection(connectionStr);
            if (con.State == ConnectionState.Closed)
                con.Open();
            string sqldel = "DELETE FROM `drug` WHERE id = '" + label19.Text + "' and `身份証` = '" + textBox4.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sqldel, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("清除成功");
            textBox8.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox11.Clear();
            label19.Text = "";
            button3.Text = "save";
            update();
        }
    }
 }
