using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int[] max = numbers.Select((i, index) => new {
                                 Item = i,
                                 index,
                                 PrevEqual = index == 0 || numbers.ElementAt(index - 1) == i,
                                 NextEqual = index == numbers.Count - 1 || numbers.ElementAt(index + 1) == i,
                                                          })
                                .Where(x => x.PrevEqual || x.NextEqual)
                                .GroupBy(x => x.Item)
                                .OrderByDescending(g => g.Count())
                                .First().Select(x => x.Item).ToArray();

            foreach (int i in max) Console.Write(i + " ");          
        }
    }
}
