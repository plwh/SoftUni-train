using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\s([0-9A-Za-z]+(-*|_*|\.*)[0-9a-zA-Z]*@[a-z]+-*[a-z]*(\.[a-z]+)+\b)";
            Regex regex = new Regex(pattern);

            foreach (Match match in regex.Matches(input))
            {
                Console.WriteLine(match);
            }
        }
    }
}
