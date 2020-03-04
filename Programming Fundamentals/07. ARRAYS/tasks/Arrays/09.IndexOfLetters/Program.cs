using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] alphabet = new string[]
        {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};

            for (int i = 0; i < input.Length; i++)
            {
                string currElement = input[i].ToString();

                if (alphabet.Contains(currElement))
                {
                    Console.WriteLine($"{input[i]} -> {Array.IndexOf(alphabet,currElement)}");
                }
            }
        }
    }
}
