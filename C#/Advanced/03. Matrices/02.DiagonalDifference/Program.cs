using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n,n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var currRow = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {                
                    matrix[i, j] = currRow[j];
                }
            }

            int primaryDiagonal = FindPrimaryDiagonal(matrix);
            int secondaryDiagonal = FindSecondaryDiagonal(matrix);
            int difference = Math.Abs(primaryDiagonal - secondaryDiagonal);

            Console.WriteLine(difference);
        }

        private static int FindPrimaryDiagonal(int[,] matrix)
        {
            int result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                result += matrix[i, i];
            }
            return result;
        }

        private static int FindSecondaryDiagonal(int[,] matrix)
        {
            int result = 0;
            for (int i = matrix.GetLength(0)-1, j = 0; i>=0; i--, j++)
            {
                result += matrix[j,i];
            }
            return result;
        }
    }
}
