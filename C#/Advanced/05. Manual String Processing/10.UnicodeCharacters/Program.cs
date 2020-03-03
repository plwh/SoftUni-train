using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var result = text.Select(t => $@"\u{Convert.ToUInt16(t):X4}").ToList();

            foreach (string i in result)
                Console.Write(i);
        }
    }
}
