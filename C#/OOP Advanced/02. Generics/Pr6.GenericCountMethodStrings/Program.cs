using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr6.GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                boxes.Add(new Box<string>(Console.ReadLine()));
            }

            string elementToCompare = Console.ReadLine();

            Console.WriteLine(GetGreaterElementsCount(boxes, elementToCompare));
        }

        static int GetGreaterElementsCount<T>(IEnumerable<Box<T>> elements, T elementToCompare)
            where T : IComparable<T>
        {
            int count = 0;
            foreach (var element in elements)
            {
                if (element.CompareTo(elementToCompare) > 0)
                    count++;
            }
            return count;
        }
    }
}
