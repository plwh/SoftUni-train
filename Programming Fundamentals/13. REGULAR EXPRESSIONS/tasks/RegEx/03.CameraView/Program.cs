using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.CameraView
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split(' ');
            int elementsToSkip = int.Parse(firstLine[0]);
            int elementsToTake = int.Parse(firstLine[1]);
            string text = Console.ReadLine();
            string pattern = @"(?<=\|<.{" + elementsToSkip + "})([^|]{0," + elementsToTake + "})";
            Regex regex = new Regex(pattern);

            Console.WriteLine(string.Join(", ", from Match match in regex.Matches(text) select match.Value));
        }
    }
}
