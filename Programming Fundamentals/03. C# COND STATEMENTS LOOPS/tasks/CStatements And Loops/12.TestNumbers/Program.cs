using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.TestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int boundary = int.Parse(Console.ReadLine());

            int combinations = 0;
            int totalSum = 0;

            for (int i = a; i >= 1; i--)
            {
               
                for (int j = 1; j <= b; j++)
                {
                    combinations++;
                    totalSum += (i * j) * 3;

                    if (totalSum >= boundary)
                    {
                        Console.WriteLine("{0} combinations", combinations);
                        Console.WriteLine("Sum: {0} >= {1}",totalSum,boundary);
                        return;
                    }
                }            
            }

            if (totalSum < boundary)
            {
                Console.WriteLine("{0} combinations", combinations);
                Console.WriteLine("Sum: {0}", totalSum);
            }
        }
    }
}
