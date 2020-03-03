using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var lengths = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < lengths.Sum(); i++)
            {
                int numberToAdd = int.Parse(Console.ReadLine());

                if (i >= lengths[0])
                {
                    secondSet.Add(numberToAdd);
                }
                else
                {
                    firstSet.Add(numberToAdd);
                }
            }

            foreach (int i in firstSet)
            {
                if (secondSet.Contains(i))
                    Console.Write(i+" ");
            }
        }
    }
}
