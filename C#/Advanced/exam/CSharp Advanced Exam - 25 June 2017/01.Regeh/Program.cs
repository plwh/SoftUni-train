using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var pattern = @"\[\w+<([\d]+)REGEH([\d]+)>\w+\]";
            var rgx = new Regex(pattern);
            string result = "";
            var currIndex = 0;

            foreach (Match match in rgx.Matches(text))
            {
                int firstNum = int.Parse(match.Groups[1].Value);
                int secondNum = int.Parse(match.Groups[2].Value);

                currIndex += firstNum;

                result += GetCharacterAtValidIndex(currIndex, text);
                
                currIndex += secondNum;

                result += GetCharacterAtValidIndex(currIndex, text);
            }

            Console.WriteLine(result);
        }

        private static char GetCharacterAtValidIndex(int currIndex, string text)
        {
            int validIndex = 0;
            char result = ' ';
            if (currIndex >= text.Length)
            {
                validIndex = (currIndex % text.Length) + 1;

                result = text[validIndex];
            }
            else
            {
                result = text[currIndex];
            }
            return result;
        }
    }
}
