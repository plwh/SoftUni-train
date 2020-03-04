using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.VowelOrDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());

            switch (a)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    Console.WriteLine("vowel");
                    break;

                default:
                    if (char.IsDigit(a))
                    {
                        Console.WriteLine("digit");
                    }
                    else
                    {
                        Console.WriteLine("other");
                    }
                    break;
            }     
        }
    }
}
