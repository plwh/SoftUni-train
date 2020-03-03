using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.SentenceExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
      
            var sentences = Console.ReadLine().Split(new char[] { '!', '.', '?'}, StringSplitOptions.RemoveEmptyEntries);

            var pattern = $@"\b{word}\b";

            foreach (var sentence in sentences)
            {
                if (Regex.IsMatch(sentence, pattern))
                {
                    Console.WriteLine(sentence.Trim());
                }
            }
        }
    }
}
