using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.UnicodeChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            StringBuilder result = new StringBuilder();

            foreach (char c in sequence)
            {
                int cint = Convert.ToInt32(c);
                result.Append(String.Format("\\u{0:x4} ", cint).Trim());
            }
            Console.WriteLine(result);
        }
    }
}
