using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CountSubstringOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string stringToSearchFor = Console.ReadLine().ToLower();

            int count = Occurences(text, stringToSearchFor);

            Console.WriteLine(count);
        }

        public static int Occurences(string str, string val)
        {
            int occurrences = 0;
            int startingIndex = 0;

            while ((startingIndex = str.IndexOf(val, startingIndex)) >= 0)
            {
                ++occurrences;
                ++startingIndex;
            }

            return occurrences;
        }

    }
}
