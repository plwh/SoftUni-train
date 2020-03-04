using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Java
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int width = 3 * n + 6;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}~ ~ ~{1}", new string(' ', n), new string(' ', n * 2));
            }

            Console.WriteLine(new string('=', width - 1));

            for (int j = 0; j < n-2; j++)
            {
                if (j == (n - 2) / 2)
                {
                    Console.WriteLine("|{0}JAVA{0}|{1}|", new string('~',n),new string(' ', n-1));
                }
                else
                {
                    Console.WriteLine("|{0}|{1}|",new string('~',n*2+4),new string(' ',n-1));
                }
            }

            Console.WriteLine(new string('=', width - 1));
            
            for (int k = 0, l = 8 + 2 * (n - 1); k < n; k++)
            {              
                Console.WriteLine("{0}\\{1}/{0}", new string(' ', k), new string('@', l -= 2));          
            }

            Console.WriteLine(new string('=', width - n));
        }
    }
}
