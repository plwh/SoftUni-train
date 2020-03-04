using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.PrintASCII
{
    class Program
    {
        static void Main(string[] args)
        {
            int startIndex = int.Parse(Console.ReadLine());
            int endIndex = int.Parse(Console.ReadLine());

            for (int i = startIndex; i <= endIndex; i++)
            {
                char a = Convert.ToChar(i);
                Console.Write(a + " ");
            }
        }
    }
}
