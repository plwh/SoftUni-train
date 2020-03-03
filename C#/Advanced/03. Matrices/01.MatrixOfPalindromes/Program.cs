using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).ToArray();
            string[,] matrix = new string[input[0],input[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    char firstLastLetter = (char)(i + 97);
                    char middleLetter = (char)(i + j + 97);
                    string palindrome = String.Format($"{firstLastLetter}{middleLetter}{firstLastLetter}");
                    matrix[i, j] = palindrome;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
