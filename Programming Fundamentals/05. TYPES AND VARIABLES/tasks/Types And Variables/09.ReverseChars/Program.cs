using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.ReverseChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "";

            for (int i = 0; i  < 3; i ++)
            {
                a = Console.ReadLine() + a;
            }

            Console.WriteLine(a);
        }
    }
}
