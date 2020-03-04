using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MultiplyBigNums
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine().TrimStart(new char[] { '0' });
            int digit = int.Parse(Console.ReadLine());


            if (number == "0" || digit == 0 || number == string.Empty)
            {
                Console.WriteLine(0);
                return;
            }

            int product = 0;
            int numInMind = 0;
            int remainder = 0;

            StringBuilder result = new StringBuilder();

            for (int i = number.Length-1;  i >= 0; i--)
            {
                product = int.Parse(number[i].ToString()) * digit + numInMind;
                numInMind = product / 10;
                remainder = product % 10;
                result.Append(remainder);

                if (i == 0 && numInMind != 0)
                {
                    result.Append(numInMind);
                }
            }

            char[] resultToArray = result.ToString().ToCharArray();
            Array.Reverse(resultToArray);
            Console.WriteLine(resultToArray);
        }
    }
}
