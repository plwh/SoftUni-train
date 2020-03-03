using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string strRegex = @"([0-9A-Za-z]+(-*|_*|\.*)[0-9a-zA-Z]*@[a-z]+-*[a-z]*(\.[a-z]+)+\b)";
            foreach (var match in Regex.Matches(text, strRegex))
            {
                Console.WriteLine(match);
            }
        }
    }
}
