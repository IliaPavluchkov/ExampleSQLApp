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
    public partial class RedacktForm : Form
    {
        public RedacktForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(425, 255);
            if (DataBank.whatDo == 2)
            {
                this.textBox5.Enabled = false;
                this.textBox6.Enabled = false;
            }
            ClassUser obj = new ClassUser();
            obj.setInfoUser();
            this.textBox1.Text = obj.returnLogin();
            this.textBox2.Text = obj.returnPas();
            this.textBox3.Text = obj.returnName();
            this.textBox4.Text = obj.returnPhoneNumber();
            this.textBox5.Text = obj.returnPozition();
            this.textBox6.Text = obj.returnZp();
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

        private void endRegistration_Click(object sender, EventArgs e)
        {
            TestSumbols obj = new TestSumbols();
            ClassUser objU = new ClassUser();
            bool buff;
            if (buff = obj.sumbolsInstr(textBox1.Text) == true)
            {
                if (buff = obj.sumbolsInstr(textBox2.Text) == true)
                {
                    if (buff = obj.sumbolsInstr(textBox3.Text) == true)
                    {
                        if (buff = obj.numbersInStr(textBox4.Text) == true)
                        {
                            if (buff = obj.sumbolsInstr(textBox5.Text) == true)
                            {
                                if (buff = obj.onlyNumbersInStr(textBox6.Text) == true)
                                {
                                    
                                    objU.redactUser(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
                                    MessageBox.Show("Редактировани прошло успешно");
                                    DataBank.whatDo = 2;
                                    this.Close();
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
