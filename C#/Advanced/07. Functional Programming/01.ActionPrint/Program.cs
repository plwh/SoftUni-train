using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToList();
            Action<string> print = n => Console.WriteLine(n);

            foreach (string i in input)
                print(i);
        }
    }
}
