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
    public partial class main : Form
    {
        public string strr;
        public main()
        {
            InitializeComponent();
            timer1_Tick(this, null);
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }

        private void main_Load(object sender, EventArgs e)
        {
            
            label1.Text = strr;
            string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
            MySqlConnection con = new MySqlConnection(connectionStr);
            MySqlDataAdapter sda = new MySqlDataAdapter("Select id,PW From `table` where id='wayne'", con);
            MySqlDataAdapter count = new MySqlDataAdapter("SELECT `床號`,`名子` FROM `personal` where  inoutside=true and 床號 is not NULL ORDER BY `床號`", con);
            DataTable di = new DataTable();
            sda.Fill(di);
            DataTable ct = new DataTable();
            count.Fill(ct);
            int x = 0;
            for (int i = 3; i < 38 ; i++)
            {
                MySqlDataAdapter lB = new MySqlDataAdapter("SELECT count(*) FROM `personal` where inoutside=true and 床號='" + (i-2) + "'", con);
                DataTable dl = new DataTable();
                lB.Fill(dl);
                if (dl.Rows[0][0].ToString() == "1")
                {
                    int b = i - 1;
                    this.Controls.Find("label" + i, true)[0].Text = ct.Rows[x][1].ToString();
                    this.Controls.Find("button" + b, true)[0].Text = Convert.ToString(i-2);
                    x +=1;

                }
                else
                {
                    int b = i - 1;
                    this.Controls.Find("label" + i, true)[0].Text = "'(空)'";
                    this.Controls.Find("button" + b, true)[0].Text = Convert.ToString(i-2);
                    
                }
                
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 住客入院ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 院友病ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 院友入院ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.strr = strr;
            form2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 ss = new Form1();
            this.Hide();

            ss.Show();
        }

        private void 院友查詢資料更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.strr = strr;
            form3.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void main_Resize_1(object sender, EventArgs e)
        {
         
        }

        private void panel1_Resize(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Form4 form4 = new Form4();
            form4.strr = strr;
            form4.name = bt.Text;
            form4.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            RefreshMyForm();
        }
        private void RefreshMyForm() 
        {   
            //update form with latest Data 
            label1.Text = strr;
            string connectionStr = "server=127.0.0.1;port=3307;database=data;uid=root;pwd=123456;";
            MySqlConnection con = new MySqlConnection(connectionStr);
            MySqlDataAdapter sda = new MySqlDataAdapter("Select id,PW From `table` where id='wayne'", con);
            MySqlDataAdapter count = new MySqlDataAdapter("SELECT `床號`,`名子` FROM `personal` where  inoutside=true and 床號 is not NULL ORDER BY `床號`", con);
            DataTable di = new DataTable();
            sda.Fill(di);
            DataTable ct = new DataTable();
            count.Fill(ct);
            int x = 0;
            for (int i = 3; i < 38; i++)
            {
                MySqlDataAdapter lB = new MySqlDataAdapter("SELECT count(*) FROM `personal` where inoutside=true and 床號='" + (i - 2) + "'", con);
                DataTable dl = new DataTable();
                lB.Fill(dl);
                if (dl.Rows[0][0].ToString() == "1")
                {
                    int b = i - 1;
                    this.Controls.Find("label" + i, true)[0].Text = ct.Rows[x][1].ToString();
                    this.Controls.Find("button" + b, true)[0].Text = Convert.ToString(i - 2);
                    x += 1;

                }
                else
                {
                    int b = i - 1;
                    this.Controls.Find("label" + i, true)[0].Text = "'(空)'";
                    this.Controls.Find("button" + b, true)[0].Text = Convert.ToString(i - 2);

                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.strr = strr;
            form4.name = button3.Text;
            form4.ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.strr = strr;
            form4.name = button4.Text;
            form4.ShowDialog();
        }

        private void 院友出院ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.strr = strr;
            form5.ShowDialog();
        }

        private void 院友血壓ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.strr = strr;
            form6.ShowDialog();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 藥物記錄ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.strr = strr;
            form7.ShowDialog();
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("即將關閉,是or否?", "確定", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
                Environment.Exit(Environment.ExitCode);
                InitializeComponent();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void 列印病歷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.strr = strr;
            form8.ShowDialog();
        }
    }

}