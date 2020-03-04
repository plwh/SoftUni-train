using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.WordInPlural
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string pluralWord = "";


            switch (word[word.Length - 1])
            {
                case 'y':
                    pluralWord = word.Remove(word.Length-1,1) + "ies";
                    break;

                case 'h':
                    if (word[word.Length - 2] == 'c' || word[word.Length - 2] == 's')
                    {
                        pluralWord = word + "es";
                    }
                    break;
                case 'o':
                case 's':
                case 'x':
                case 'z':
                    pluralWord = word + "es";
                    break;

                default:
                    pluralWord = word + "s";
                    break;
            }

            Console.WriteLine(pluralWord);
        }
    }
}
