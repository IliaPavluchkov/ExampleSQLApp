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
    public partial class SetFinans : Form
    {
        ClientSocket obj = new ClientSocket();
        TestSumbols test = new TestSumbols();
        public SetFinans()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(425, 255);
            string message = obj.returnMess();
            string[] words = message.Split('|');
            for(int i=1;i<13;i++)
            chart1.Series["Now age"].Points.AddXY(i,int.Parse(words[i-1]));
            DataBank.whatDo = 0;
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
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (test.onlyNumbersInStr(textBox1.Text) && test.onlyNumbersInStr(textBox2.Text)) {
                if (int.Parse(textBox1.Text)<=12 && int.Parse(textBox1.Text) >= 1) {
                    DataBank.year = textBox8.Text;
                    DataBank.whatDo = 1;
                    DataBank.buf1 = "set";
                    Thread.Sleep(50);
                    obj.sendMess();
                    DataBank.buf1 = textBox1.Text;
                    Thread.Sleep(50);
                    obj.sendMess();
                    DataBank.buf1 = textBox2.Text;
                    Thread.Sleep(50);
                    obj.sendMess();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Всего только 12 месяцев");
                }
            }else
            {
                MessageBox.Show("Вводите цифры");
            }
        }
    }
}
