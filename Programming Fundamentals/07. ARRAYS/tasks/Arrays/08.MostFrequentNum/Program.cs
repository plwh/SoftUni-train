using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MostFrequentNum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int mostFrequentNumber = arr.GroupBy(v => v)
                                        .OrderByDescending(g => g.Count())
                                        .First()
                                        .Key;

            Console.WriteLine(mostFrequentNumber);
        }
    }
}
