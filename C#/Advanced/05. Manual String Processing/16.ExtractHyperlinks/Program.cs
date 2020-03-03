using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _16.ExtractHyperlinks
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine;
            StringBuilder sb = new StringBuilder();

            while (!((inputLine = Console.ReadLine()) == "END"))
            {
                sb.Append(inputLine);
            }

            string text = sb.ToString();
           
            Regex users = new Regex(@"<a.*?(?<!"">)href\s*?=\s*?([""'])?(\S.*?)(?:>|class|\1)");
            MatchCollection matches = users.Matches(text);

            foreach (Match hyperlink in matches)
            {
                Console.WriteLine(hyperlink.Groups[2]);
            }
        }
    }
}
