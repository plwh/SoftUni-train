using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.MagicExcWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            string first = input[0];
            string second = input[1];

            bool isExchangeable = false;
            var newFirst = first.Distinct().ToArray();
            var newSecond = second.Distinct().ToArray();

            if (newFirst.Length == newSecond.Length) isExchangeable = true;

            Console.WriteLine(isExchangeable ? "true":"false");
        }
    }
}
