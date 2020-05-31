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
    public partial class SerchForm : Form
    {
        private TestSumbols objS = new TestSumbols();
        private ClientSocket obj = new ClientSocket();
        public SerchForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(425, 255);
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

        private void endRegistration_Click(object sender, EventArgs e)
        {
            if (objS.sumbolsInstr(textBox1.Text))
            {
                DataBank.buf1=textBox1.Text;
                obj.sendMess();
                string mes = obj.returnMess();
                if (mes == "Не было ни одного совпадения")
                {
                    this.richTextBox1.Text = mes;
                }
                else
                {
                    int size = int.Parse(mes);
                    int y = 0;
                    string[] str;

                    str = obj.returnMassMess(size);
                    for (int i = 0; i < size; i++)
                        this.richTextBox1.Text += str[i]+"\n";
                    textBox1.Text = "";
                }
                    
            }
            else
            {
                MessageBox.Show("Ошибка ввода\nВведите не пустое поле");
            }
        }
    }
}
