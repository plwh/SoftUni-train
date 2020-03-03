using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _04.ReplaceTag
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string line = Console.ReadLine();

            while (line != "end")
            {
                sb.AppendLine(line);
                line = Console.ReadLine();
            }

            string text = sb.ToString();
            var result = Regex.Replace(text, @"<a href=""", "[URL href=\"");
            result = Regex.Replace(result, @""">", "\"]");
            result = Regex.Replace(result,@"</a>","[/URL]");
            Console.Write(result);
        }
    }
}
