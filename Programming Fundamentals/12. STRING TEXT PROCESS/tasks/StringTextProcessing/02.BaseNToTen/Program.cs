using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _02.BaseNToTen
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            byte baseToConvert = byte.Parse(input[0]);
            string numberToConvert = input[1];
            BigInteger result = 0;

            for (int i = numberToConvert.Length-1, j = 0 ; i >= 0; i--,j++)
            {
                byte currDigit = byte.Parse(numberToConvert[i].ToString());
                result += currDigit * BigInteger.Pow(baseToConvert, j);
            }

            Console.WriteLine(result);
        }
    }
}
