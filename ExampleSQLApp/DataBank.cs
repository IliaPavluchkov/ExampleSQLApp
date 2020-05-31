using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSQLApp
{
    class DataBank
    {

        public static int whatDo;
        public static string year;
        public static int idUser;

        public static string buf1;
        public static string buf2;
        public static NetworkStream stream;
        public static TcpClient client = null;

    }
}
