using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.AnonymousVox
{
    class Program
    {
        static void Main(string[] args)
        {
            string encodedText = Console.ReadLine();
            string[] placeholders = Console.ReadLine().Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"([a-zA-Z]+)(.+)\1";
            Regex regex = new Regex(pattern);


            MatchCollection matches = regex.Matches(encodedText);

            int placeHolderIndex = 0;

            foreach (Match match in matches)
            {
                if (placeHolderIndex > placeholders.Length) break;

                encodedText = ReplaceFirst(encodedText,match.Groups[2].Value, placeholders[placeHolderIndex++]);
            }

            Console.WriteLine(encodedText);
        }

        static string ReplaceFirst(string text, string oldValue, string newValue)
        {
            string substringWithOldValue = text.Substring(0, text.IndexOf(oldValue) + oldValue.Length);

            string substringWithNewValue = substringWithOldValue.Replace(oldValue, newValue);

            return substringWithNewValue + text.Substring(substringWithOldValue.Length);
        }

    }
}
