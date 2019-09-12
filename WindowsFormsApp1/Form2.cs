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
            // TODO: 這行程式碼會將資料載入 'dataDataSet.personal' 資料表。您可以視需要進行移動或移除。
            this.personalTableAdapter.Fill(this.dataDataSet.personal);

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gapwai\source\repos\WindowsFormsApp1\WindowsFormsApp1\Data.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select id,PW From [dbo].[table] where id='wayne'", con);
            SqlDataAdapter count = new SqlDataAdapter("SELECT count(*) FROM [dbo].[personal] where  inoutside='true' and 床號 is not NULL", con);
            DataTable di = new DataTable();

            DataTable ct = new DataTable();
            sda.Fill(di);

            count.Fill(ct);
            int x = 1;
            int a = Convert.ToInt32(ct.Rows[0][0].ToString());
            string b = Convert.ToString(a);
            label2.Text = ct.Rows[0][0].ToString();
            //
            while (x < 32) {
                SqlDataAdapter lB = new SqlDataAdapter("SELECT count(*) FROM dbo.personal where inoutside='true' and 床號='" + x + "'", con);
                DataTable dl = new DataTable();
                lB.Fill(dl);
                if (dl.Rows[0][0].ToString() == "1") {
                    SqlDataAdapter lBB = new SqlDataAdapter("SELECT cast([床號] as nvarchar)+':'+[名子] as Username FROM dbo.personal where inoutside='true' and 床號='" + x + "'", con);
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

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gapwai\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
            string boyorgril = "";
            if (boyRB.Checked) boyorgril += boyRB.Text;
            if (girlRB.Checked) boyorgril += girlRB.Text;
            //SqlDataAdapter mkt = new SqlDataAdapter("Select count(*) From [dbo].[table] where 身份証", con);

            if (MessageBox.Show("姓名=" + textBox1.Text + "\n" + "性別=" + boyorgril + "\n" + "出生日期 =" + dateTimePicker1.Value.ToString("MM/dd/yyyy") +
                "\n" + "身份証 =" + maskedTextBox3.Text + "\n" + "電話 =" + textBox6.Text + "\n" + "入院日期 =" + dateTimePicker2.Value.ToString("MM/dd/yyyy") +
                 "\n" + "國籍 =" + textBox8.Text + "\n" + "緊急電話 =" + textBox10.Text + "\n" + "地址 =" + textBox7.Text + textBox9.Text, "是否正確", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {


                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select MAX (ID) From [dbo].[personal]", con);
                SqlDataAdapter ads = new SqlDataAdapter("Select id,PW From [dbo].[table] where id='wayne'", con);
                DataTable dt = new DataTable();
                DataTable di = new DataTable();
                sda.Fill(dt);
                ads.Fill(di);

                int a;

                if (dt.Rows[0][0].ToString() == "1")
                {
                    a = Convert.ToInt32(dt.Rows[0][0].ToString());
                }
                else
                {
                    a = 0;
                }
                string b = Convert.ToString(a + 1);

                label2.Text = di.Rows[0][1].ToString();
                string sql = "INSERT INTO [dbo].[personal](ID,名子,性別,出生日期,身份証,電話,入院日期,國籍,緊急電話,床號,地址,經手人)" +
                    " VALUES ('" + b + "',N'" + textBox1.Text + "',N'" + boyorgril + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + maskedTextBox3.Text + "','" + textBox6.Text + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "',N'" + textBox8.Text + "','" + textBox10.Text + "','" + textBox2.Text + "',N'" + textBox7.Text + textBox9.Text + "','" + strr + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
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
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gapwai\source\repos\WindowsFormsApp1\WindowsFormsApp1\Data.mdf;Integrated Security=True;Connect Timeout=30");
                OpenFileDialog fileDialog = new OpenFileDialog();
                string sql = "insert into [dbo].[MySchool] (BLODID,BLOBData) values (@BLODID,@blobdata)";
                SqlCommand command = new SqlCommand(sql, connection);
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
                    SqlParameter prm = new SqlParameter
                    ("@blobdata", SqlDbType.VarBinary, mybyte.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, mybyte);
                    if (maskedTextBox3.Text == "")
                    {
                        MessageBox.Show("請先填寫左邊資料");
                    }
                    else {
                        command.Parameters.Add("@BLODID", SqlDbType.Int).Value = Convert.ToInt32(maskedTextBox3.Text);
                        command.Parameters.Add(prm);
                        //開啟資料庫連線
                        connection.Open();
                        command.ExecuteNonQuery();
                        //建立SQL語句
                        string sql1 = "select BLODID,BLOBData from [dbo].[MySchool] where BLODID=" + maskedTextBox3.Text + " ";
                        //建立SqlCommand物件
                        SqlCommand command1 = new SqlCommand(sql1, connection);
                        //建立DataAdapter物件
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command1);
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
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gapwai\source\repos\WindowsFormsApp1\WindowsFormsApp1\Data.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                if (maskedTextBox3.Text == "")
                {
                    MessageBox.Show("請先填寫左邊資料");
                }
                else {
                    string sql = "DELETE FROM [dbo].[MySchool]WHERE BLODID=" + maskedTextBox3.Text + " ";
                    SqlCommand cmd = new SqlCommand(sql, con);
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
    }
}
