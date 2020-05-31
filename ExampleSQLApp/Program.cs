using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ExampleSQLApp
{
    static class Program
    {
      
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]

        static void Main()
        {
             
        Application.EnableVisualStyles();

            DataBank.whatDo = 0;

            ClientSocket obj=new ClientSocket();

            try
            {
                string mes;
                while (true)
                {
                    obj.startMes();
                    Application.Run(new LoginForm());
                    if (DataBank.whatDo == 3) 
                    {
                        DataBank.buf1 = DataBank.whatDo.ToString();
                        obj.sendMess();
                        break; 
                    }
                    DataBank.buf1 = DataBank.whatDo.ToString();
                    obj.sendMess();
                    Thread.Sleep(75);
                    if (DataBank.whatDo == 1)
                    {
                        DataBank.buf1 = DataBank.buf2;
                        obj.sendMess();

                        // получаем ответ
                        mes=obj.returnMess();
                        if (mes == "error")
                        {
                            MessageBox.Show("Неправильный логин или пароль");
                            continue;
                        }
                        else if (mes=="admin")
                        {
                            while (true)
                            {
                                Application.Run(new AdminForm());

                                if (DataBank.whatDo == 1)
                                {
                                    DataBank.whatDo = 0;
                                    Thread.Sleep(40);
                                    obj.sendMess();
                                    while (true)
                                    {
                                        
                                        Application.Run(new AdminUserTableForm());

                                        if (DataBank.whatDo == 0)
                                        {
                                            break;
                                        }
                                        else if (DataBank.whatDo == 1)
                                        {
                                            Application.Run(new SerchForm());
                                            //DataBank.buf1 = "userTable";
                                            continue;
                                        }
                                        else if (DataBank.whatDo == 2)
                                        {

                                        }
                                        else if (DataBank.whatDo == 3)
                                        {
                                            mes = obj.returnMess();
                                            if (mes == "Не было ни одного совпадения")
                                            {
                                                //MessageBox.Show(mes);
                                                continue;
                                            }
                                            else
                                            {
                                                DataBank.idUser = Convert.ToInt32(mes);
                                                while (true)
                                                {
                                                    Application.Run(new UserForm());

                                                    if (DataBank.whatDo == 3)
                                                    {
                                                        DataBank.buf2 = "";
                                                       // DataBank.buf1 = "userTable";
                                                        DataBank.idUser = 0;
                                                        break;
                                                    }
                                                    if (DataBank.whatDo == 2)
                                                    {
                                                        DataBank.whatDo = 10;
                                                        Application.Run(new RedacktForm());
                                                        if (DataBank.whatDo == 3)
                                                        {
                                                            DataBank.buf1 = "end";
                                                            obj.sendMess();
                                                        }
                                                        continue;
                                                    }
                                                }
                                            }
                                            continue;
                                        }
                                        else if (DataBank.whatDo == 4)
                                        {
                                            mes = obj.returnMess();
                                            //MessageBox.Show(mes);
                                            //DataBank.buf1 = "userTable";
                                            continue;
                                        }
                                        else if (DataBank.whatDo == 5)
                                        {
                                            Application.Run(new AlertUserForm());
                                            //DataBank.buf1 = "userTable";
                                            continue;
                                        }
                                    }
                                }
                                else if (DataBank.whatDo == 2)
                                {
                                    while (true) { 
                                    Application.Run(new ProviderForm());
                                    if (DataBank.whatDo == 1)
                                    {
                                        break;
                                    }
                                    if (DataBank.whatDo == 2)
                                    {
                                        Application.Run(new OptionsСomparisons());
                                        if (DataBank.whatDo == 1)
                                        {
                                            continue;
                                        }
                                        if (DataBank.whatDo == 2)
                                        {
                                            string how = obj.returnMess();
                                            string size = obj.returnMess();
                                            for (int i = 0; i < int.Parse(how); i++)
                                            {
                                                Application.Run(new Compar(int.Parse(size)));
                                                if (DataBank.whatDo == 2)
                                                {
                                                    break;
                                                }
                                            }
                                            if(DataBank.whatDo!=2)
                                            DataBank.whatDo = 10;
                                        }
                                    }
                                    }
                                }
                                else if (DataBank.whatDo == 3)
                                {
                                    while (true)
                                    {
                                        Application.Run(new SetFinans());
                                        if (DataBank.whatDo == 1)
                                        {
                                            continue;
                                        }else if(DataBank.whatDo == 2)
                                        {
                                            DataBank.buf1 = "end";
                                            obj.sendMess();
                                            break;
                                        }
                                    }
                                }
                                else if (DataBank.whatDo == 4)
                                {
                                    obj.sendMess();
                                    break;
                                }
                            }

                        }
                        else if (mes[0] == 'P')
                        {
                            MessageBox.Show("Пользователь учетной записи уже в сети");
                            continue;
                        }
                        else
                        {
                            DataBank.idUser = Convert.ToInt32(mes);
                            while (true)
                            {
                                Application.Run(new UserForm());
                                if (DataBank.whatDo == 1)
                                {
                                    DataBank.buf2 = "";
                                    DataBank.buf1 = "";
                                    DataBank.idUser = 0;
                                    break; 
                                }
                                if (DataBank.whatDo == 2)
                                {
                                    Application.Run(new RedacktForm());
                                    if (DataBank.whatDo == 3)
                                    {
                                        DataBank.buf1 = "end";
                                        obj.sendMess();
                                    }
                                    continue;
                                }
                                if (DataBank.whatDo == 5)
                                {
                                    continue;
                                }
                            }
                        }

                    }
                    else if (DataBank.whatDo == 2)
                    {
                        while (true)
                        {
                            Application.Run(new Registration());
                            if (DataBank.whatDo == 4)
                            {
                                
                                obj.sendMess();
                                break;
                            }
                            else if (DataBank.whatDo == 5)
                            {
                                break;
                            }
                            else continue;
                        }
                    }
                    else if (DataBank.whatDo == 3)
                    {
                        break;
                    }
                    else continue;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                try
                {
                    obj.closeSoc();

                }catch(Exception e)
                {
                    MessageBox.Show("Ошибка соединения с сервером");
                }
            }
        }
    }
}
