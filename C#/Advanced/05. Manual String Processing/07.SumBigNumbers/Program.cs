using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SumBigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string numOne = Console.ReadLine();
            string numTwo = Console.ReadLine();

            var maxLength = Math.Max(numOne.Length, numTwo.Length);

            numOne = numOne.PadLeft(maxLength + 1, '0');
            numTwo = numTwo.PadLeft(maxLength + 1, '0');

            var numOneDigits = numOne.Select(x => int.Parse(x.ToString())).ToArray();
            var numTwoDigits = numTwo.Select(x => int.Parse(x.ToString())).ToArray();

            var sum = new int[numOne.Length];
            int currSum = 0;

            for (int i = sum.Length - 1; i >= 0; i--)
            {
                int total = numOneDigits[i] + numTwoDigits[i] + currSum;
                sum[i] = total % 10;

                if (total > 9)
                {
                    currSum = 1;
                }
                else
                {
                    currSum = 0;
                }
            }

            var result = string.Join("", sum.SkipWhile(x => x == 0));
            Console.WriteLine(result);
        }
    }
}
