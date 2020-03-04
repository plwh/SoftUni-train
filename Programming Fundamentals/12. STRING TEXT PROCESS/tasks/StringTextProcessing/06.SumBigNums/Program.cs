using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SumBigNums
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            string secondNumber = Console.ReadLine();

            var maxLength = Math.Max(firstNumber.Length, secondNumber.Length);

            firstNumber = firstNumber.PadLeft(maxLength + 1, '0');
            secondNumber = secondNumber.PadLeft(maxLength + 1, '0');

            var firstDigits = firstNumber.Select(x => int.Parse(x.ToString())).ToArray();
            var secondDigits = secondNumber.Select(x => int.Parse(x.ToString())).ToArray();

            var sum = new int[firstNumber.Length];

            int currSum = 0;

            for (int i = sum.Length-1; i >= 0 ; i--)
            {
                int total = firstDigits[i] + secondDigits[i] + currSum;
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

            var result = string.Join(string.Empty, sum.SkipWhile(x => x == 0));
            Console.WriteLine(result);
        }
    }
}
