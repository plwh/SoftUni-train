using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StringLength
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input.Length > 20)
            {
                input = input.Substring(0, 20);
            }
            else
            {
                input = input.PadRight(20, '*');
            }

            Console.WriteLine(input);
        }
    }
}
