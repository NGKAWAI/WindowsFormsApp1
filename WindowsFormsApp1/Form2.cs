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
    public partial class Form2 : Form
    {
        public string strr;
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
         
            string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
            MySqlConnection con = new MySqlConnection(connectionStr);
            MySqlDataAdapter sda = new MySqlDataAdapter("Select id,PW From `table` where id='wayne'", con);
            MySqlDataAdapter count = new MySqlDataAdapter("SELECT count(*) FROM `personal` where  inoutside=true and 床號 is not NULL", con);
            DataTable di = new DataTable();

            DataTable ct = new DataTable();
            sda.Fill(di);

            count.Fill(ct);
            int x = 1;
            int a = Convert.ToInt32(ct.Rows[0][0].ToString());
            string b = Convert.ToString(a);
            //
            while (x < 32) {
                MySqlDataAdapter lB = new MySqlDataAdapter("SELECT count(*) FROM `personal` where inoutside=true and 床號='" + x + "'", con);
                DataTable dl = new DataTable();
                lB.Fill(dl);
                if (dl.Rows[0][0].ToString() == "1") {
                    MySqlDataAdapter lBB = new MySqlDataAdapter("SELECT CONCAT(床號,':',名子) FROM `personal` where inoutside=true and 床號='" + x + "'", con);
                    DataTable dll = new DataTable();
                    lBB.Fill(dll);
                    listBox2.Items.Add(dll.Rows[0][0].ToString());
                    x += 1;
                }
                else {
                    listBox2.Items.Add(Convert.ToString(x) + ":");
                    x += 1;
                }
            }

        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
            MySqlConnection con = new MySqlConnection(connectionStr);
            string boyorgril = "";
            if (boyRB.Checked) boyorgril += boyRB.Text;
            if (girlRB.Checked) boyorgril += girlRB.Text;
            //SqlDataAdapter mkt = new SqlDataAdapter("Select count(*) From [dbo].[table] where 身份証", con);
            MySqlDataAdapter lA = new MySqlDataAdapter("SELECT count(*) FROM `personal` where inoutside=true and 床號='" + textBox2.Text + "'", con);
            DataTable dA = new DataTable();
            lA.Fill(dA);
            if (dA.Rows[0][0].ToString() != "1")
            {
                if (MessageBox.Show("姓名=" + textBox1.Text + "\n" + "性別=" + boyorgril + "\n" + "出生日期 =" + dateTimePicker1.Value.ToString("MM/dd/yyyy") +
                "\n" + "身份証 =" + maskedTextBox3.Text + "\n" + "電話 =" + textBox6.Text + "\n" + "入院日期 =" + dateTimePicker2.Value.ToString("MM/dd/yyyy") +
                 "\n" + "國籍 =" + textBox8.Text + "\n" + "緊急電話 =" + textBox10.Text + "\n" + "地址 =" + textBox7.Text + textBox9.Text, "是否正確", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    con.Open();
                    MySqlDataAdapter cou = new MySqlDataAdapter("Select count(id) From `personal`", con);
                    DataTable dc = new DataTable();
                    cou.Fill(dc);
                    int a = 0;
                    if (dc.Rows[0][0].ToString() == "1")
                    {
                        MySqlDataAdapter sda = new MySqlDataAdapter("Select max(id) From `personal`", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        a = Convert.ToInt32(dt.Rows[0][0].ToString());
                    }
                    else
                    {
                        a = 0;
                    }

                    MySqlDataAdapter ads = new MySqlDataAdapter("Select id,PW From `table` where id='wayne'", con);
                    DataTable di = new DataTable();
                    ads.Fill(di);

                    string b = Convert.ToString(a + 1);

                    string sql = "INSERT INTO `personal`(ID,名子,性別,出生日期,身份証,電話,入院日期,國籍,緊急電話,床號,地址,經手人)" +
                        " VALUES ('" + b + "',N'" + textBox1.Text + "',N'" + boyorgril + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + maskedTextBox3.Text + "','" + textBox6.Text + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "',N'" + textBox8.Text + "','" + textBox10.Text + "','" + textBox2.Text + "',N'" + textBox7.Text + textBox9.Text + "','" + strr + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    string sqlpt = "select count(*) from `MySchool` where BLODID=" + maskedTextBox3.Text + " ";
                    MySqlDataAdapter pt = new MySqlDataAdapter(sqlpt, con);
                    DataTable dt2 = new DataTable();
                    pt.Fill(dt2);
                    if (dt2.Rows[0][0].ToString() == "0")
                    {
                        string sqlpt2 = "insert into `MySchool` (BLODID) values (" + maskedTextBox3.Text + ")";
                        MySqlCommand cmdpt = new MySqlCommand(sqlpt2, con);
                        cmdpt.ExecuteNonQuery();

                    }
                    //院友號碼= b;
                    //姓名=textBox1.Text;
                    //性別= boyorgril;
                    //出生日期=dateTimePicker1.Value.ToString("MM/dd/yyyy");
                    //"身份証 ="+ maskedTextBox3.Text+;
                    //"電話 ="+textBox6.Text+;
                    //"入院日期 ="+dateTimePicker2.Value.ToString("MM/dd/yyyy")+;
                    //"國籍 ="+textBox8.Text+;
                    //"緊急電話 ="+textBox10.Text+;
                    //床號= textBox2.Text;
                    //"地址 ="+textBox7.Text+ textBox9.Text;
                    //經手人 = strr;
                    //相片 = textBox6.Text;
                    cmd.ExecuteNonQuery();

                    // cmd.Dispose();
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("這個床位已經有人");
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox6.Clear();
            textBox8.Clear();
            textBox10.Clear();
            textBox7.Clear();
            textBox9.Clear();
            maskedTextBox3.Clear();
            boyRB.Checked = false;
            girlRB.Checked = false;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
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
                    ("@blobdata",MySqlDbType.VarBinary, mybyte.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, mybyte);
                    if (maskedTextBox3.Text == "")
                    {
                        MessageBox.Show("請先填寫左邊資料");
                    }
                    else {
                        command.Parameters.Add("@BLODID", MySqlDbType.Int32).Value = Convert.ToInt32(maskedTextBox3.Text);
                        command.Parameters.Add(prm);
                        //開啟資料庫連線
                        connection.Open();
                        command.ExecuteNonQuery();
                        //建立SQL語句
                        string sql1 = "select BLODID,BLOBData from `MySchool` where BLODID=" + maskedTextBox3.Text + " ";
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



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
                MySqlConnection con = new MySqlConnection(connectionStr);
                con.Open();
                if (maskedTextBox3.Text == "")
                {
                    MessageBox.Show("請先填寫左邊資料");
                }
                else {
                    string sql = "DELETE FROM `MySchool` WHERE BLODID=" + maskedTextBox3.Text + " ";
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

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            int index = listBox2.IndexFromPoint(e.X, e.Y);
            textBox2.Text = Convert.ToString(index+1);
        }
    }
}
