using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            Action<string> print = n => Console.WriteLine("Sir "+n);

            foreach (string i in input)
                print(i);
        }
    }
}
