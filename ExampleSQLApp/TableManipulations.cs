    using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSQLApp
{
    class TableManipulations
    {
        public string setLineTable(string str)
        {
            string finishedLine="";
            int i = 0,counter=0,x=0;
            int size = str.Length;

            while (true)
            {
                if (str[i] != '\n')
                {
                    if (str[i] == '|')
                    {
                        x ++;
                        finishedLine += str[i];
                       
                    }
                    else 
                    {
                        if (str[i + 1] == '|')
                        {
                            if (x == 1)
                            {
                                finishedLine += str[i];
                                counter = 0;
                                i++;
                                continue;
                            }
                            finishedLine += str[i];
                            for (; counter < 26; counter++)
                            {
                                finishedLine += ' ';
                            }
                            counter = 0;
                        }
                        else
                        {
                            finishedLine += str[i];
                            counter++;
                        }
                    }
                    
                }
                else break;
                i++;
            }
            return finishedLine;
        }
    }
}
