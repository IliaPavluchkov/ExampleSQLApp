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
    public partial class AdminUserTableForm : Form
    {
        private ClientSocket obj = new ClientSocket();
        private TestSumbols objS = new TestSumbols();
        // TableManipulations objTable = new TableManipulations();
        public AdminUserTableForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(425, 255);
            int size=int.Parse(obj.returnMess());
            int y = 0;
            string str;
            while (true)
            {
                str = obj.returnMess();
                this.richTextBox1.Text += str;
                if (y == size-1) break;
                y++;
            }
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DataBank.whatDo = 0;
            DataBank.buf1 = "end";
            obj.sendMess();
            this.Close();
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
            DataBank.whatDo = 1;
            DataBank.buf1 = "serch";
            obj.sendMess();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBank.whatDo = 2;
            DataBank.buf1 = "sorting";

            obj.sendMess();
            this.Hide();
            this.richTextBox1.Text = 
"|id|Логин                    |Пароль                   |ФИО                      |Зарплата                 |Должность                |Телефон                  |\n" +
"2 | Fran2 | A111 | Маруся Б.К.                | 555 | бугалтер | 668(621)693 - 19 - 2\n" +
"5 | Jerik | B000 | Петрович | 5000 | Зам | 7(2720)250 - 28 - 9\n"+
"3 | John | C222 | Ведр Н.Е.                  | 323 | грущик | 010(032)024 - 43 - \n4" +
"1 | Karl | B222 | Петр Б.И.                  | 300 | уборщик | 712(82)560 - 84 - 0\n";

            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBank.whatDo = 3;
            DataBank.buf1 = "goIn";
            obj.sendMess();
            if (objS.sumbolsInstr(textBox8.Text))
            {
                DataBank.buf1 = textBox8.Text;
                obj.sendMess();
                this.Close();
            }
            else MessageBox.Show("Данные введены не верно");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataBank.whatDo = 4;
            DataBank.buf1 = "delete";
            obj.sendMess();
            if (objS.onlyNumbersInStr(textBox1.Text))
            {
                DataBank.buf1 = textBox1.Text;
                obj.sendMess();
                this.Close();
            }
            else MessageBox.Show("Данные введены не верно");
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataBank.whatDo = 5;
            DataBank.buf1 = "alert";
            obj.sendMess();
            this.Close();
        }
    }
}
