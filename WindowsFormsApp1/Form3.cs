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


        }

        private void button1_Click(object sender, EventArgs e)
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            mouseclick();
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
                string sql= "UPDATE `personal` Set 名子='" + textBox6.Text + "',性別='" + textBox10.Text + "',電話='" + textBox2.Text + "',國籍='" + textBox3.Text + "',出生日期='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',緊急電話='" + textBox5.Text + "',地址='" + textBox7.Text + "',經手人='"+strr+"' where `身份証` = '" + textBox4.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("更改完成");
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
                MySqlConnection connection = new MySqlConnection(connectionStr);
                OpenFileDialog fileDialog = new OpenFileDialog();
                string sql = "insert into `MySchool` (BLODID,BLOBData) values (@BLODID,@blobdata)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                fileDialog.Multiselect = true;
                fileDialog.Title = "请选择文件";
                fileDialog.Filter = "Image Files(*.JPG;*.PNG;*.jpeg;*.GIF;*.BMP)|*.JPG;*.PNG;*.GIF;*.BMP;*.jpeg|All files(*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string file = fileDialog.FileName;//返回文件的完整路径      
                    string picturePath = @file;
                    FileStream fs = new FileStream(picturePath, FileMode.Open, FileAccess.Read);
                    //宣告Byte陣列
                    Byte[] mybyte = new byte[fs.Length];
                    //讀取資料
                    fs.Read(mybyte, 0, mybyte.Length);
                    fs.Close();
                    //轉換成二進位制資料，並儲存到資料庫
                    //MSqlDbType.VarBinary
                    MySqlParameter prm = new MySqlParameter
                    ("@blobdata", MySqlDbType.VarBinary, mybyte.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, mybyte);
                    if (textBox4.Text == "")
                    {
                        MessageBox.Show("請先請詢");
                    }
                    else
                    {
                        command.Parameters.Add("@BLODID", MySqlDbType.Int32).Value = Convert.ToInt32(textBox4.Text);
                        command.Parameters.Add(prm);
                        //開啟資料庫連線
                        connection.Open();
                        command.ExecuteNonQuery();
                        //建立SQL語句
                        string sql1 = "select BLODID,BLOBData from `MySchool` where BLODID=" + textBox4.Text + " ";
                        //建立SqlCommand物件
                        MySqlCommand command1 = new MySqlCommand(sql1, connection);
                        //建立DataAdapter物件
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command1);
                        //建立DataSet物件
                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet, "BLOBTest");
                        int c = dataSet.Tables["BLOBTest"].Rows.Count;
                        if (c > 0)
                        {
                            Byte[] mybyte2 = new byte[0];
                            mybyte2 = (Byte[])(dataSet.Tables["BLOBTest"].Rows[c - 1]["BLOBData"]);
                            MemoryStream ms = new MemoryStream(mybyte2);
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
                MySqlConnection con = new MySqlConnection(connectionStr);
                con.Open();
                if (textBox4.Text == "")
                {
                    MessageBox.Show("請先填寫左邊資料");
                }
                else
                {
                    string sql = "DELETE FROM `MySchool` WHERE BLODID=" + textBox4.Text + " ";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    pictureBox1.Image = null;
                    pictureBox1.Refresh();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
