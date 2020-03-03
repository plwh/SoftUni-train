using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr4.GenericSwapMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                boxes.Add(box);
            }

            int[] indexTokens = Console.ReadLine().Split().Select(a => int.Parse(a)).ToArray();

            Swap(boxes, indexTokens[0], indexTokens[1]);
            boxes.ForEach(a => Console.WriteLine(a));
        }

        public static void Swap<T>(List<T> values, int firstIndex, int secondIndex)
        {
            var temp = values[firstIndex];
            values[firstIndex] = values[secondIndex];
            values[secondIndex] = temp;
        }
    }
}
