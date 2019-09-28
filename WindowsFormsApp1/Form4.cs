using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        DateTime date = DateTime.Now;
        public string strr;
        public string name;
        string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";

        public Form4()
        {
            InitializeComponent();
            timer1_Tick(this, null);
            timer1.Interval = 1000;
            timer1.Enabled = true;

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            date = DateTime.Now;
            MySqlConnection con = new MySqlConnection(connectionStr);
            MySqlDataAdapter lB = new MySqlDataAdapter("SELECT count(*) FROM `personal` where inoutside=true and 床號='" + name + "'", con);
            DataTable dl = new DataTable();
            lB.Fill(dl);
            if (dl.Rows[0][0].ToString() == "1")
            {

                MySqlDataAdapter lBB = new MySqlDataAdapter("SELECT 名子,床號,身份証 FROM `personal` where inoutside=true and 床號='" + name + "'", con);
                DataTable dll = new DataTable();
                lBB.Fill(dll);
                textBox3.Text = dll.Rows[0][2].ToString();
                label6.Text = dll.Rows[0][0].ToString();
                label7.Text = dll.Rows[0][1].ToString();
            }
            else
            {
                textBox3.Enabled = true;
                label6.Text = "空";
                label7.Text = name;
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            label8.Text = string.Format("{0:00}:{1:00}:{2:00}", t.Hour, t.Minute, t.Second);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionStr);
            con.Open();
            MySqlCommand lB = new MySqlCommand("update personal set `床號` = null where inoutside=true and 床號='" + name + "'", con);
            DataTable dl = new DataTable();
            lB.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("已清除"+name+"床位");
            textBox3.Enabled = true;
            label6.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionStr);
            MySqlDataAdapter lA = new MySqlDataAdapter("SELECT count(*) FROM `personal` where inoutside=true and 床號='" + name + "'", con);
            MySqlDataAdapter lAA = new MySqlDataAdapter("SELECT count(*) FROM `personal` where inoutside=true and 床號 is null and `身份証`='" + textBox3.Text + "'", con);
            DataTable dA = new DataTable();
            lA.Fill(dA);
            DataTable dAA = new DataTable();
            lAA.Fill(dAA);
            if (dAA.Rows[0][0].ToString() == "1")
            {
                if (dA.Rows[0][0].ToString() != "1")
                {
                    MySqlDataAdapter lABB = new MySqlDataAdapter("SELECT 名子 FROM `personal` where inoutside=true  and `身份証`='" + textBox3.Text + "'", con);
                    DataTable dABB = new DataTable();
                    lABB.Fill(dABB);
                    con.Open();
                    MySqlCommand lB = new MySqlCommand("update personal set `床號` = " + name + " where inoutside=true and 身份証='" + textBox3.Text + "'", con);
                    DataTable dl = new DataTable();
                    lB.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("成功加入"+name+"病床");
                    textBox3.Enabled = false;
                    label6.Text = dABB.Rows[0][0].ToString();

                }
                else
                {
                    MessageBox.Show(name + "床位已經有人");
                }
            }
            else
            {
                MySqlDataAdapter lAB = new MySqlDataAdapter("SELECT count(*) FROM `personal` where inoutside=true  and `身份証`='" + textBox3.Text + "'", con);
                DataTable dAB = new DataTable();
                lAB.Fill(dAB);
                if (dAB.Rows[0][0].ToString() == "1")
                {
                    MySqlDataAdapter lABB = new MySqlDataAdapter("SELECT 名子 FROM `personal` where inoutside=true  and `身份証`='" + textBox3.Text + "'", con);
                    DataTable dABB = new DataTable();
                    lABB.Fill(dABB);
                    label6.Text = dABB.Rows[0][0].ToString();
                    MessageBox.Show( dABB.Rows[0][0].ToString() + "病人已經有床號");
                }
                else
                {
                    MessageBox.Show("沒有這個病人");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Enabled == false)
            {
                if (MessageBox.Show("病人 : " + label6.Text + "\n收縮壓 : " + textBox1.Text + "\n舒張壓 : " + textBox2.Text + "\n日期 : " + dateTimePicker2.Value.ToString(), "是否正確", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MySqlConnection con = new MySqlConnection(connectionStr);
                    string sql = "INSERT INTO `bloodp`(日期1,日期,收縮壓,舒張壓,經手人,人物,身份証)" +
                                " VALUES ('" + dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','"+ dateTimePicker2.Value.ToString("yyyy-MM-dd")+"','" + textBox1.Text + "','" + textBox2.Text + "','" + strr + "','" + label6.Text + "','" + textBox3.Text + "')";
                    con.Open();
                    MySqlCommand IN = new MySqlCommand(sql, con);
                    IN.ExecuteNonQuery();
                    con.Close();
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            else { MessageBox.Show("請先加入病人"); }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
