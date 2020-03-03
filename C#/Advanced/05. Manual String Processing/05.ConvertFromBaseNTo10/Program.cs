using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _05.ConvertFromBaseNTo10
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');

            int initialBase = int.Parse(input[0]);
            string numberToConvert = input[1];

            BigInteger result = 0;

            for (int i = numberToConvert.Length-1, j = 0; i >= 0; i--,j++)
            {
                result += (BigInteger)((numberToConvert[i] - 48) * Math.Pow(initialBase, j));
            }

            Console.WriteLine(result);
        }
    }
}
