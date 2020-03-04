using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CharMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            string first = input[0];
            string second = input[1];

            Console.WriteLine(SumCharacters(first, second));
        }

        static int SumCharacters(string a, string b)
        {
            int result = 0;
            string longerElement = (a.Length > b.Length) ? a : b;
            string shorterElement = (a.Length > b.Length) ? b : a;

            for (int i = 0; i < longerElement.Length; i++)
            {
                if (i > shorterElement.Length - 1)
                {
                    result += (int)longerElement[i];
                }
                else
                {
                    result += (int)shorterElement[i] * (int)longerElement[i];
                }
            }
            return result;
        }
    }
}
