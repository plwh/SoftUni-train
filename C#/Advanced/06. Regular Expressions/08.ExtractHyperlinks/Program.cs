using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.ExtractHyperlinks
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            var line = Console.ReadLine();

            while (line != "END")
            {
                sb.Append(line);
                line = Console.ReadLine();
            }

            string pattern = @"<a.*?(?<!"">)href\s*?=\s*?([""'])?(\S.*?)(?:>|class|\1)";
      
            MatchCollection matches = Regex.Matches(sb.ToString(), pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2].Value);
            }

        }
    }
}
