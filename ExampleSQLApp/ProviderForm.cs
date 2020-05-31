using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleSQLApp
{
    public partial class ProviderForm : Form
    {
        private ClientSocket obj = new ClientSocket();
        public ProviderForm()
        {
            InitializeComponent();
            if (DataBank.whatDo == 10)
            {
              string[] str=  obj.returnMassMess(int.Parse(obj.returnMess()));
                for (int i = 0; i < str.Length-1; i++)
                {
                    richTextBox1.Text += str[i]+"\n";
                }
            }
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(425, 255);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DataBank.buf1 = "end";
            DataBank.whatDo = 1;
            Thread.Sleep(100);
            obj.sendMess();
            this.Close();
        }

        private void closeButton_DragEnter(object sender, DragEventArgs e)
        {
            closeButton.ForeColor = Color.Red;

        }

        private void closeButton_DragLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Black;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPo = new Point(e.X, e.Y);
        }
        private Point lastPo;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPo.X;
                this.Top += e.Y - lastPo.Y;

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

        private void button4_Click(object sender, EventArgs e)
        {
            DataBank.whatDo = 2;
            DataBank.buf1 = "continue";
            Thread.Sleep(30);
            obj.sendMess();
            this.Close();
        }
    }
}
