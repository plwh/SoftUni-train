using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }

            var dividers = Console.ReadLine().Split().Select(int.Parse).ToList();

            Predicate<int> checker = x => {
                foreach (int a in dividers)
                {
                    if (a == 0) continue;

                    if (x % a != 0) return false;
                }

                return true;
            };

            foreach (int number in numbers)
                if (checker(number)) Console.Write(number + " ");
        }
    }
}
