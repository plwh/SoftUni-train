using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.CountIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int number = 0;

            while(true)
            {
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out number))
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
            }

            Console.WriteLine(count);
        }
    }
}
