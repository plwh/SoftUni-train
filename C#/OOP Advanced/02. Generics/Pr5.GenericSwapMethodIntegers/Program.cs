using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr5.GenericSwapMethodIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<int>> boxes = new List<Box<int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);
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
