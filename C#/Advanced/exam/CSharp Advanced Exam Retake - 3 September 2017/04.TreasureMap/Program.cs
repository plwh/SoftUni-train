using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.TreasureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var pattern = @"(!|#)[^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*(?<!\d)(?<number>\d{3})-(?<password>\d{6}|\d{4})(?!\d)[^!#]*?(?!\1)(#|!)";

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                var rgx = new Regex(pattern);
                var matches = rgx.Matches(text);

                if (matches.Count == 1)
                {
                    PrintMatch(matches[0]);
                }
                else
                {
                    PrintMatch(matches[matches.Count / 2]);
                }
            }
        }

        private static void PrintMatch(Match match)
        {
            Console.Write($"Go to str. {match.Groups["street"]} {match.Groups["number"]}. ");
            Console.WriteLine($"Secret pass: {match.Groups["password"]}.");
        }
    }
}
