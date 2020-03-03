using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "ivan ivanov, Ivan ivanov, ivan Ivanov, IVan Ivanov, Ivan IvAnov, Ivan	Ivanov, Ivan Ivanov";
            Regex re = new Regex(@"\b[A-Z]{1}[a-z]+[' '][A-Z]{1}[a-z]+\b");

            foreach (var match in re.Matches(text))
            {
                Console.WriteLine(match);
            }
        }
    }
}
