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
    public partial class AlertUserForm : Form
    {
        ClientSocket obj = new ClientSocket();
        public AlertUserForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(425, 255);
            DataBank.buf1 = "0";
            Thread.Sleep(30);
            obj.sendMess();
            obj.clearStream();
            textBox1.Text= obj.returnMess();
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

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Black;
        }

        private void endRegistration_Click(object sender, EventArgs e)
        {
            DataBank.buf1 = "0";
            obj.sendMess();
            DataBank.buf1 = textBox1.Text;
            obj.sendMess();
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DataBank.buf1 = "end";
            obj.sendMess();
            this.Close();
        }
    }
}
