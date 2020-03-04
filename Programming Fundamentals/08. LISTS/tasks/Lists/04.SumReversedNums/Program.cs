using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SumReversedNums
{
    class Program
    {
        static string ReverseDigits(string num)
        {
            string r = "";
            foreach (char n in num) r = n + r;
            return r;
        }

        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int sum = 0;

            foreach (int i in sequence)
            {
                sum += int.Parse(ReverseDigits(i.ToString()));
            }

            Console.WriteLine(sum);
        }
    }
}
