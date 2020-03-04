using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PrimesInRange
{
    class Program
    {
        static void Print(List<double> list)
        {
            string result = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    result += list[i];
                }
                else
                {
                    result += list[i] + ", ";
                }
            }

            Console.WriteLine(result);
        }

        static List<double> FindPrimesInRange(double startNum, double endNum)
        {
            List<double> result = new List<double>();

            for (double number = startNum; number <= endNum; number++)
            {
                bool isPrime = true;

                if (number < 2)
                {
                    isPrime = false;
                }
                else
                {
                    for (int i = 2; i <= Math.Sqrt(number); i++)
                    {
                        if (number % i == 0)
                        {
                            isPrime = false;
                        }
                    }
                }

                if (isPrime) result.Add(number);
            }
            return result;
        }

        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            Print(FindPrimesInRange(a, b));
        }
    }
}
