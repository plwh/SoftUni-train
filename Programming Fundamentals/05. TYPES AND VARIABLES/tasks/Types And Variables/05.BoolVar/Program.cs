using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BoolVar
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool variable = Boolean.Parse(input);

            Console.WriteLine((variable)? "Yes" : "No");
        }
    }
}
