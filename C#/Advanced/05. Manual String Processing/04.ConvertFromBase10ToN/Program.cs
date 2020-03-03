using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ConvertFromBase10ToN
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int targetBase = input[0];
            int numberToConvert = input[1];

            string result = "";

            while (numberToConvert > 0)
            {
                result = numberToConvert % targetBase + result;
                numberToConvert = numberToConvert / targetBase;
            }

            Console.WriteLine(result);
        }
    }
}
