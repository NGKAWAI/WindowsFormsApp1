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
    public partial class Form8 : Form
    {
        public string strr;
        public Form8()
        {
            InitializeComponent();
            timer1_Tick(this, null);
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            label12.Text = string.Format("{0:00}:{1:00}:{2:00}", t.Hour, t.Minute, t.Second);
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DVprintPreviewDialog.Document = DVprintDocument;
            DVprintPreviewDialog.ShowDialog ();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DVprintDocument.Print();
        }

        private void DVprintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = 25;
            int x2 = 0;
            int y = 0;
            e.Graphics.DrawString("病人病歷詳情", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, x));
            x = x+ 17;
            e.Graphics.DrawString("打印時間: "+dateTimePicker2.Text, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(650, x));
            x = x + 17;
            e.Graphics.DrawString(label13.Text, new Font("Arial", 12), Brushes.Black, new Point(25, x));
            x = x + 17;
            if (pictureBox1.Image != null)
            {
                Image newImage = pictureBox1.Image;
                e.Graphics.DrawImage(newImage, 25, x, 150, 200);
                x2 = x + 217;
            }
            else {
                x2 = x + 217;
                y = 150;
            }
            e.Graphics.DrawString("姓名",new Font("Arial",12),Brushes.Black,new Point(180-y,x));
            e.Graphics.DrawString("身份証編號", new Font("Arial", 12), Brushes.Black, new Point(180 - y, x+30));
            e.Graphics.DrawString("出生日期", new Font("Arial", 12), Brushes.Black, new Point(180 - y, x+60));
            e.Graphics.DrawString("性別", new Font("Arial", 12), Brushes.Black, new Point(180 - y, x +90));
            e.Graphics.DrawString("年齡", new Font("Arial", 12), Brushes.Black, new Point(180 - y, x +120));
            e.Graphics.DrawString("地址", new Font("Arial", 12), Brushes.Black, new Point(180 - y, x +150));
            e.Graphics.DrawString(label13.Text, new Font("Arial", 12), Brushes.Black, new Point(25, x2));
        }
    }
}
