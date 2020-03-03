using System;
using System.Text.RegularExpressions;

namespace _03.CryptoBlockchain
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string text = "";
            string result = "";
            for (int i = 0; i < n; i++)
            {
                text += Console.ReadLine();
            }

            Regex rgx = new Regex(@"([\[]|[{])(.*?)([}]|[\]])");
            Regex extractNumbers = new Regex(@"\d+");

            foreach (Match match in rgx.Matches(text))
            {
                var openingTag = match.Groups[1].Value;
                var textBetweenTags = match.Groups[2].Value;
                var closingTag = match.Groups[3].Value;

                if ((openingTag == "[" && closingTag == "]") || (openingTag == "{" && closingTag == "}"))
                {
                    string numbers = extractNumbers.Match(textBetweenTags).Value;
                    result += ConvertNumbersToCharacters(numbers, match.Length);
                }
            }

            Console.WriteLine(result);
        }

        private static string ConvertNumbersToCharacters(string v, int cryptoLength)
        {
            string result = "";
            for (int i = 0; i < v.Length; i+=3)
            {
                var currNum = int.Parse(v.Substring(i, 3));
                result += (char)(currNum - cryptoLength);
            }
            return result;
        }
    }
}
