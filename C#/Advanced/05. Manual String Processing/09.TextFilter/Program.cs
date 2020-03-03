using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var bannedWords = Console.ReadLine().Split(new char[] { ' ', ',' },StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (string word in bannedWords)
            {
                var replacementText = new string('*',word.Length);
                text = text.Replace(word,replacementText);
            }

            Console.WriteLine(text);
        }
    }
}
