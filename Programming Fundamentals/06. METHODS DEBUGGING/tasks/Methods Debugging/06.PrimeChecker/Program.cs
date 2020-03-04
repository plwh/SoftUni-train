using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.PrimeChecker
{
    class Program
    {
        static bool IsPrime(double number)
        {
            if (number < 2)
            {
                return false;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        return false;   
                    }
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(a));
        }
    }
}
