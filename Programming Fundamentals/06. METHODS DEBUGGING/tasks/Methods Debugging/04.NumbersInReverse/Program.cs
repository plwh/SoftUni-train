using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.NumbersInReverse
{
    class Program
    {
        static void PrintInReverse(double number)
        {
            string numberToString = number.ToString();
            string result = "";

            for (int i = 0; i < numberToString.Length; i++)
            {
                result = numberToString[i] + result;
            }

            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            PrintInReverse(a);
        }
    }
}
