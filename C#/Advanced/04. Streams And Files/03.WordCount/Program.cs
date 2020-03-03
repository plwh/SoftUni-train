using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\words.txt";
            string textPath = @"..\..\text.txt";
            var text = File.ReadAllText(textPath).ToLower();
            var reader = new StreamReader(wordPath);
            var result = new Dictionary<string, int>();

            using (reader)
            {
                var word = "";
                while((word = reader.ReadLine()) != null)
                {
                    var pattern = string.Format(@"\b{0}\b", word.ToLower());
                    var match = Regex.Matches(text, pattern);
                    result.Add(word, match.Count);
                }
            }
            
            using (var writer = new StreamWriter(@"..\..\result.txt"))
            {
                foreach (var word in result.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine("{0} - {1}", word.Key, word.Value);
                }
            }
        }
    }
}
