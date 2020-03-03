using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.SeriesOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex("(.)\\1+");
            var str = "aaaaabbbbbcdddeeeedssaa";

            Console.WriteLine(regex.Replace(str, "$1"));
        }
    }
}
