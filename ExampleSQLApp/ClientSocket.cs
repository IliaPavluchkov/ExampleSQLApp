using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleSQLApp
{
    class ClientSocket
    {
        public string returnMess()
        {
            string message;
            byte[] data = new byte[64]; // буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            Thread.Sleep(50);
            do
            {
                bytes = DataBank.stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (DataBank.stream.DataAvailable);

            message = builder.ToString();
            return message;
        }
        public string[] returnMassMess(int size)
        {
            string[] message=new string[size];
            byte[] data = new byte[64]; // буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            int i = 0;
            Thread.Sleep(30);
            do
            {
                bytes = DataBank.stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                //for(int j=0;j< builder.Length; j++)
                //{
                //    if (builder[j] == '\n')
                //    {
                //        message[i] = builder.ToString();
                //        builder.Clear();
                //        i++;
                //    }
                //}
                
            }
            while (DataBank.stream.DataAvailable);
            string[] mess = builder.ToString().Split('\n');
            return mess;
        }
        public void sendMess()
        {
            string message;
            message = DataBank.buf1;
            byte[] data = Encoding.Unicode.GetBytes(message);
            DataBank.stream.Write(data, 0, data.Length);
        }

        public void startMes()
        {
         int port = 7770;
         string server = "127.0.0.1";
         DataBank. client = new TcpClient(server, port);
         DataBank.stream = DataBank.client.GetStream();
        }
        public void closeSoc()
        {
                DataBank.stream.Close();
                DataBank.client.Close();
        }
        public void clearStream()
        {
            DataBank.stream.Flush();
        }
    }
}
