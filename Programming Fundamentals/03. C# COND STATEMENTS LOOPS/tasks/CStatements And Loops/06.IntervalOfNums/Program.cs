using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.IntervalOfNums
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a > b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            for (int i = a; i <= b; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
