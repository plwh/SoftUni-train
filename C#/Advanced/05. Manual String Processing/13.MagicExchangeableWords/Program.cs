using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.MagicExchangeableWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Trim().Split();

            var str1 = input[0].Distinct().ToArray();
            var str2 = input[1].Distinct().ToArray();
            
            Console.WriteLine(str1.Length == str2.Length ?"true":"false");
        }
    }
}
