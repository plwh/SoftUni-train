using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FibonacciNums
{
    class Program
    {
        static int FibNumberAtPosition(int num)
        {
            int[] fibonacci = new int[num+1];
            for (int j = 0; j < fibonacci.Length; j++)
            {
                if (j < 2)
                {
                    fibonacci[j] = 1;
                }
                else
                {
                    fibonacci[j] = fibonacci[j - 1] + fibonacci[j - 2];
                }
            }

            return fibonacci[fibonacci.Length-1];
        }

        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine(FibNumberAtPosition(a));
        }
    }
}
