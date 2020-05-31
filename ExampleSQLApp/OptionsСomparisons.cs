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
    public partial class OptionsСomparisons : Form
    {
        private TestSumbols test = new TestSumbols();
        private ClientSocket obj = new ClientSocket();
        public OptionsСomparisons()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(425, 255);
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
            DataBank.whatDo = 1;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (test.onlyNumbersInStr(textBox8.Text))
            {
                if (int.Parse(textBox8.Text) > 1 && int.Parse(textBox8.Text) < 7)
                {
                    if (test.onlyNumbersInStr(textBox1.Text))
                    {
                        if (int.Parse(textBox1.Text) > 2 && int.Parse(textBox1.Text) < 1000) 
                        {
                            if (test.sumbolsInstr(richTextBox1.Text))
                            {
                                if (test.moreOneEnter(richTextBox1.Text))
                                {
                                    DataBank.buf1 = textBox8.Text;
                                    Thread.Sleep(60);
                                    obj.sendMess();
                                    DataBank.buf1 = textBox1.Text;
                                    Thread.Sleep(60);
                                    obj.sendMess();
                                    DataBank.buf1 = richTextBox1.Text;
                                    Thread.Sleep(60);
                                    obj.sendMess();
                                    DataBank.whatDo = 2;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Не верно введены поставщики\nНеобходимо хотябы 2 поставщика");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не верно введены поставщики");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не верно введена шкала\nШкала >2 но <1000");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не верно введена шкала");
                    }
                }
                else
                {
                    MessageBox.Show("Не верно введено коллическто экспертов\nКолличество экспертов >1 но <7");
                }
            }
            else
            {
                MessageBox.Show("Не верно введено коллическто экспертов");
            }
            
        }
    }
}
