using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace _14.FactTrailingZeroes
{
    class Program
    {

        static BigInteger CalcFactorial(int n)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        static void CalcTrailingZeroes(BigInteger number)
        {
            int count = 0;
            string numberToString = number.ToString();
            for (int i = numberToString.Length-1; i >= 0 ; i--)
            {
                int currDigit = int.Parse(numberToString[i].ToString());

                if(currDigit == 0)
                { 
                    count++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(count);
        }

        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            CalcTrailingZeroes(CalcFactorial(num));
        }
    }
}
