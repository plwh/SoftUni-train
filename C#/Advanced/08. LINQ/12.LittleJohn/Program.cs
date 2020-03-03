using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _12.LittleJohn
{
    class Program
    {
        static void Main(string[] args)
        {
            string arrowsData = "";

            for (int i = 0; i < 4; i++)
            {
                arrowsData += " " + Console.ReadLine();
            }

            int smallArrowsCount = 0;
            int mediumArrowsCount = 0;
            int largeArrowsCount = 0;

            var pattern = @"(>-{5}>)|(>>-{5}>)|(>>>-{5}>>)";
            MatchCollection matches = Regex.Matches(arrowsData, pattern);

            foreach (Match match in matches)
            {
                if(match.Groups[1].Success) smallArrowsCount++;

                if(match.Groups[2].Success) mediumArrowsCount++;

                if(match.Groups[3].Success) largeArrowsCount++;
            }

            int number = int.Parse($"{smallArrowsCount}{mediumArrowsCount}{largeArrowsCount}");

            string binary = Convert.ToString(number, 2);
            var binaryArray = binary.ToCharArray();
            Array.Reverse(binaryArray);
            string binaryReversed = new string(binaryArray);

            Console.WriteLine(Convert.ToInt32(binary+binaryReversed,2));
            
        }
    }
}
