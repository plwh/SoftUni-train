using System;
using System.Collections.Generic;

namespace Pr7.GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<double>> boxes = new List<Box<double>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double value = double.Parse(Console.ReadLine());
                boxes.Add(new Box<double>(value));
            }

            double elementToCompare = double.Parse(Console.ReadLine());

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
