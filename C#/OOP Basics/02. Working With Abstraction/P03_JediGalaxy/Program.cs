using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            short[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(short.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            FillMatrix(ref matrix);

            long sumOfStars = 0;
            string command;

            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoCoordinates = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilCoordinates = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evilRow = evilCoordinates[0];
                int evilCol = evilCoordinates[1];

                DestroyStars(evilRow, evilCol, ref matrix);
              
                int ivoRow = ivoCoordinates[0];
                int ivoCol = ivoCoordinates[1];

                sumOfStars += CollectStars(ivoRow, ivoCol, matrix);
            }

            Console.WriteLine(sumOfStars);
        }

        private static long CollectStars(int ivoRow, int ivoCol, int[,] matrix)
        {
            long result = 0;
            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (IsValidIndex(ivoRow, ivoCol, matrix))
                {
                    result += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }
            return result;
        }

        private static void DestroyStars(int row, int col, ref int[,] matrix)
        {
            while (row >= 0 && col >= 0)
            {
                if (IsValidIndex(row, col, matrix))
                {
                    matrix[row, col] = 0;
                }
                row--;
                col--;
            }
        }

        private static bool IsValidIndex(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void FillMatrix(ref int[,] matrix)
        {
            int value = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }
    }
}
