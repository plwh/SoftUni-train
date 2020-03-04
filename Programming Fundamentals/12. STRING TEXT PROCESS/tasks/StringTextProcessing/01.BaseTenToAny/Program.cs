using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01.BaseTenToAny
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            BigInteger baseToConvert = BigInteger.Parse(input[0]);
            BigInteger numberToConvert = BigInteger.Parse(input[1]);
            string result = "";

            while (numberToConvert > 0)
            {
                int remainder = (int)(numberToConvert % baseToConvert);
                result = remainder + result;
                numberToConvert /= baseToConvert;
            }

            Console.WriteLine(result);
        }
    }
}
