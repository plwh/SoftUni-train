using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.StringAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Hello";
            string str2 = "World";
            object concatenation = str1 + " " + str2;
            string result = (string)concatenation;

            Console.WriteLine(result);
        }
    }
}
