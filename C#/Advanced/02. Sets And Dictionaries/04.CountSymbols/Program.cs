using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            foreach (char i in input)
            {
                if (!symbols.ContainsKey(i))
                {
                    symbols[i] = 1;
                }
                else
                {
                    symbols[i]++;
                }
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
