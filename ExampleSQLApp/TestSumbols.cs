using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExampleSQLApp
{
    class TestSumbols
    {
        public bool sumbolsInstr(string str)
        {
            int Ru = 0, En = 0;
            str = str.ToUpper();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if ((c >= 'А') && (c <= 'Я'))
                    Ru++;
                else if ((c >= 'A') && (c <= 'Z')) En++;
            }
            if (Ru == 0 && En == 0)
            {
                return false;
            }
            else
            return true;
        }
        public bool onlyNumbersInStr(string str)
        {
            int sumb = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if ((c >= '0') && (c <= '9'))
                    sumb++;
                else
                    return false;
            }
            if (sumb == 0) { return false; }
            return true;
        }
        public bool numbersInStr(string str)
        {
            int nums = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if ((c >= '0') && (c <= '9'))
                    nums++;
            }
            if (nums == 0) { return false; }
            return true;
        }
        public bool moreOneEnter(string str)
        {
            int enter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (c == '\n')
                    enter++;
            }
            if (enter < 2) { return false; }
            return true;
        }
    }
}
