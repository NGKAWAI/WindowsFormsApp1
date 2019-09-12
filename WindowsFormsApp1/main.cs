using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class main : Form
    {
        public string strr;
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            label1.Text = strr;
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
    }
}
