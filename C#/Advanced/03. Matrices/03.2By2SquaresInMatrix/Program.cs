using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._2By2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');

            int m = int.Parse(input[0]);
            int n = int.Parse(input[1]);

            char[,] matrix = new char[m, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var currRow = Console.ReadLine().Split(' ').Select(a => char.Parse(a)).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currRow[j];
                }
            }

            PrintSquaresCount(matrix);
        }

        private static void PrintSquaresCount(char[,] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] && matrix[i + 1, j] == matrix[i + 1, j + 1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
