using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSQLApp
{
    class ClassUser
    {
        private string login;
        private string pass;
        private string name;
        private string zp;
        private string position;
        private string phoneNumber;
        ClientSocket obj = new ClientSocket();
        public void setInfoUser()
        {
            obj.clearStream();
            string mes = obj.returnMess();
            string[] buffer = mes.Split('|');
            login = buffer[0];
            pass = buffer[1];
            name = buffer[2];
            zp = buffer[3];
            position = buffer[4];
            phoneNumber = buffer[5];
        }
        public void registration(string login, string pass, string name, string zp, string position, string phoneNumber)
        {
            DataBank.buf1 = "'" + login + "'" + ", " + "'" + pass + "'" + ", " + "'" + name + "'" + ", " + "'" + phoneNumber + "'" + ", " + "'" + position + "'" + ", " + "'" + zp + "'" ;
            obj.clearStream();
            obj.sendMess();
        }
        public void redactUser(string login, string pass, string name, string zp, string position, string phoneNumber)
        {
            DataBank.buf1 = login + "," +  pass  + ","  + name + "," + zp + "," + position + "," + phoneNumber;
            obj.clearStream();
            obj.sendMess();
        }
        public string returnLogin() { return login; }
        public string returnPas() { return pass; }
        public string returnName() { return name; }
        public string returnZp() { return zp; }
        public string returnPozition() { return position; }
        public string returnPhoneNumber() { return phoneNumber; }

    }
}
