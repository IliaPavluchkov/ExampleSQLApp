using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleSQLApp
{
    public partial class Compar : Form
    {
        ClientSocket obj = new ClientSocket();
        public Compar(int size)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(425, 255);
            string providers = obj.returnMess();
            obj.clearStream();
            string[] matr = obj.returnMassMess(size);
            this.richTextBox1.Enabled = false;
            this.richTextBox2.Enabled = false;
            richTextBox1.Text = providers;
            int strlenStr = providers.Length;
            for(int i = 0; i < strlenStr; i++)
            {
                if(providers[i]=='\n')
                {
                    richTextBox2.Text += "|";
                    continue;
                }
                richTextBox2.Text += providers[i];
            }
            for (int j = 0; j < matr.Length-1; j++)
            {
                richTextBox3.Text += matr[j];
                if (j != matr.Length - 1) { richTextBox3.Text += "\n"; }
            }
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Black;
        }
        private Point lastPo;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPo = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPo.X;
                this.Top += e.Y - lastPo.Y;

            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DataBank.whatDo = 2;
            DataBank.buf1 = "end";
            obj.sendMess();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataBank.whatDo = 1;
            DataBank.buf1 = richTextBox3.Text;
            obj.sendMess();
            this.Close();
        }
    }
}
