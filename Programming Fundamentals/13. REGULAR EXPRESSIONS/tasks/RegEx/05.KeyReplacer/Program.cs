using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.KeyReplacer
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyString = Console.ReadLine();
            string text = Console.ReadLine();

            Regex reg = new Regex(@"(^\w+)");
            string startKey = reg.Match(keyString).ToString();

            reg = new Regex(@"(\w+$)");
            string endKey = reg.Match(keyString).ToString();

            reg = new Regex($@"{startKey}(?'word'.*?){endKey}");

            StringBuilder result = new StringBuilder();

            foreach (Match match in reg.Matches(text))
            {
                result.Append(match.Groups["word"].Value);
            }

            Console.WriteLine(result.Length == 0 ? "Empty result" : result.ToString());
        }
    }
}
