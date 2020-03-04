using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SearchForANum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
            integers.RemoveRange(numbers[0],integers.Count - numbers[0]);

            integers.RemoveRange(0, numbers[1]);

            Console.WriteLine(integers.Contains(numbers[2]) ? "YES!" : "NO!");
        }
    }
}
