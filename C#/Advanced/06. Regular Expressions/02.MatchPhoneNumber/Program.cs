using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = @"+359 2 222 2222 +359-2-222-2222 359-2-222-2222, +359/2/222/2222, +359-2 222 2222
                            +359 2-222-2222, +359-2-222-222, +359-2-222-22222";

            Regex re = new Regex(@"[+][359]+(\s|-)[2]\1[\d]{3}\1[\d]{4}\b");

            foreach (var match in re.Matches(text))
            {
                Console.WriteLine(match);
            }
        }
    }
}
