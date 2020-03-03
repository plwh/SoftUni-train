using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _10.UseYourChainsBuddy
{
    class Program
    {
        static void Main(string[] args)
        {
            // set console to be able to read more than 254 characters
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));

            string input = Console.ReadLine();
            string result = "";
            var paragraphTagPattern = @"<p>(.*?)<\/p>";
            MatchCollection matches = Regex.Matches(input, paragraphTagPattern);

            foreach (Match match in matches)
            {
                string text = match.Groups[1].Value;
                var characterPattern = @"[^a-z0-9]+";
                text = Regex.Replace(text, characterPattern, " ");
                text = ConvertLetters(text);

                result += text;
            }

            Console.WriteLine(result);
        }

        private static string ConvertLetters(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char i in text)
            {
                // check if character is between a to m
                if (i >= 97 && i <= 109)
                {
                    sb.Append((char)(i + 13));
                } // check if character is between n to z
                else if (i >= 110 && i <= 122)
                {
                    sb.Append((char)(i - 13));
                } // append rest
                else
                {
                    sb.Append(i);
                }
            }

            return sb.ToString();
        }
    }
}
