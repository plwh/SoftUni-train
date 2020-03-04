using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.ExtractSentencesByKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string[] sentences = Console.ReadLine().Split(".?!".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            string pattern = $@"\b{word}\b";

            foreach (string sentence in sentences)
            {
                Match match = Regex.Match(sentence, pattern);
                if (match.Success)
                {
                    Console.WriteLine(sentence.Trim());
                }
            }
        }
    }
}
