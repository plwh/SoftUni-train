using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var chemicals = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                foreach (string chemical in input)
                {
                    chemicals.Add(chemical);
                }
            }

            foreach (string i in chemicals) Console.Write(i + " ");
        }
    }
}
