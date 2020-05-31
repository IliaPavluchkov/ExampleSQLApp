using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ExampleSQLApp
{
    public partial class LoginForm : Form
    {
        private ClientSocket obj = new ClientSocket();
        private ClassUser objClient = new ClassUser();

        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(425, 255);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DataBank.whatDo = 3;
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
   
        private void button1_Click(object sender, EventArgs e)
        {
            DataBank.whatDo = 1;
            DataBank.buf2 = loginField.Text + " " + passField.Text;
            this.Close();
            
           // this.Hide();
            //DataBank.objUserForm.ShowDialog();
            //this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBank.whatDo = 2;
            this.Close();
        }

    }
}
