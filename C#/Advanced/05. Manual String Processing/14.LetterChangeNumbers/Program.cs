using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.LetterChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;

            foreach (string i in input)
            {
                char firstLetter = i[0];
                char secondLetter = i[i.Length - 1];
                double number = double.Parse(i.Substring(1, i.Length - 2));

                if (isUpperCase(firstLetter))
                {
                    number /= firstLetter - 64;
                }
                else
                {
                    number *= firstLetter - 96;
                }

                if (isUpperCase(secondLetter))
                {
                    number -= secondLetter - 64;
                }
                else
                {
                    number += secondLetter - 96;
                }

                sum += number;
            }
            Console.WriteLine($"{sum:f2}");
        }

        private static bool isUpperCase(char firstLetter)
        {
            return firstLetter == Char.ToUpper(firstLetter);
        }
    }
}
