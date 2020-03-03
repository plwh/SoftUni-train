using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetLength = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split().ToArray();

            Func<string, bool> checker = n => n.Length <= targetLength;

            foreach (string name in names)
            {
                if (checker(name))
                    Console.WriteLine(name);
            }
        }
    }
}
