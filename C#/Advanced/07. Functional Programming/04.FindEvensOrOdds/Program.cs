using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int lowerBound = int.Parse(input[0]);
            int upperBound = int.Parse(input[1]);
            string command = Console.ReadLine();

            int remainder = 0;
            if (command == "odd")
            {
                remainder = 1;
            }

            List<int> numbers = new List<int>();
            for (int i = lowerBound; i <= upperBound; i++)
            {
                numbers.Add(i);
            }

            List<int> filteredNumbers = Filter(numbers, n => n % 2 == remainder || n % 2 == -1);

            Console.WriteLine(String.Join(" ", filteredNumbers));
        }

        private static List<int> Filter(List<int> numbers, Predicate<int> p)
        {
            List<int> result = new List<int>();
            foreach (int num in numbers)
            {
                if (p(num))
                {
                    result.Add(num);
                }
            }
            return result;
        }
    }
}
