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
    public partial class UserForm : Form
    {
        ClientSocket obj = new ClientSocket();

        public UserForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(425, 255);
            this.textBox1.Enabled = false;
            this.textBox3.Enabled = false;
            this.textBox4.Enabled = false;
            this.textBox5.Enabled = false;
            this.textBox6.Enabled = false;
            this.textBox7.Enabled = false;
            this.textBox8.Enabled = false;
            ClassUser obj1 = new ClassUser();
            obj1.setInfoUser();
            this.textBox8.Text = obj1.returnLogin();
            this.textBox7.Text = obj1.returnPas();
            this.textBox3.Text = obj1.returnName();
            this.textBox4.Text = obj1.returnPhoneNumber();
            this.textBox5.Text = obj1.returnPozition();
            this.textBox6.Text = obj1.returnZp();
            obj.clearStream();
            textBox1.Text= obj.returnMess();
            obj.clearStream();
            textBox2.Text = obj.returnMess();

        }
        
        private void closeButton_Click(object sender, EventArgs e)
        {
            DataBank.buf1 = "end";
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(DataBank.whatDo!=10)
            DataBank.whatDo = 2;
            DataBank.buf1 = "redaction";
            obj.sendMess();
            this.Close();
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPo = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPo.X;
                this.Top += e.Y - lastPo.Y;

            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPo = new Point(e.X, e.Y);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBank.whatDo = 5;
            DataBank.buf1 = "aboutYou";
            obj.sendMess();
            Thread.Sleep(40);
            DataBank.buf1 = textBox2.Text;
            obj.sendMess();
            this.Close();
        }
    }
}
