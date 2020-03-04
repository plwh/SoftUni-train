using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PairsByDiff
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int difference = int.Parse(Console.ReadLine());
            int count = 0;

            foreach(int i in arr)
            {
                foreach (int j in arr)
                {
                    if (i - j == difference) count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
