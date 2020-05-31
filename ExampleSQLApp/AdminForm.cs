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
    public partial class AdminForm : Form
    {
        ClientSocket obj = new ClientSocket();
        public AdminForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(425, 255);
            label1.Text = "Финансовое положение за 2020 год";
            string message = obj.returnMess();
            string[] words = message.Split('|');
            for (int i = 1; i < 13; i++)
            this.chart1.Series["Now year"].Points.AddXY(i,int.Parse(words[i-1]));
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DataBank.whatDo = 4;
            DataBank.buf1 = "end";
            this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPo.X;
                this.Top += e.Y - lastPo.Y;

            }
   
    }
    
    private Point lastPo;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPo = new Point(e.X, e.Y);
        }

        private void endRegistration_Click(object sender, EventArgs e)
        {
            DataBank.whatDo = 1;
            DataBank.buf1 = "userTable";
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBank.whatDo = 2;
            DataBank.buf1 = "providers";
            Thread.Sleep(30);
            obj.sendMess();
            this.Close();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Black;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            DataBank.whatDo = 3;
            DataBank.buf1 = "option Chart";
            obj.sendMess();
            this.Close();
        }
    }
}
