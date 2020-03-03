using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> uniqueUsernames = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                uniqueUsernames.Add(Console.ReadLine());
            }

            foreach (string i in uniqueUsernames)
            {
                Console.WriteLine(i);
            }
        }
    }
}
