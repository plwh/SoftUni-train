using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _13.Factorial
{
    class Program
    {
        static void CalcFactorial(int n)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
        }
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            CalcFactorial(num);
        }
    }
}
